using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.UI;
using Asam.Ppc.Service.Messages.Assessment;
using Asam.Ppc.Service.Messages.Attributes;
using Asam.Ppc.Service.Messages.Common.Lookups;
using Asam.Ppc.Service.Messages.Common;

namespace Asam.Ppc.Mvc.Infrastructure
{
    using Pillar.Security.AccessControl;
    using Ppc.Infrastructure.Extensions;

    public static class HtmlHelpers
    {
        public static readonly string ValidationSummaryWarningCssClassName = "validation-summary-warnings";

        public static bool IsApiMode(this HtmlHelper htmlHelper)
        {
            return !(string.IsNullOrEmpty(WebConfigurationManager.AppSettings["IsApiMode"]) || WebConfigurationManager.AppSettings["IsApiMode"].Equals("false"));            
        }

        public static string GetLookupCategory(this HtmlHelper htmlHelper, string propertyName)
        {
            var metadata = ModelMetadata.FromStringExpression(propertyName,htmlHelper.ViewData);
            if (metadata.AdditionalValues.ContainsKey(LookupCategoryAttribute.LookupCategory))
            {
                var category = metadata.AdditionalValues[LookupCategoryAttribute.LookupCategory] as string;
                return category;
            }
            return propertyName;
        }

        public static IEnumerable<LookupDto> GetLookupOptionsForCategory(this HtmlHelper htmlHelper, string category)
        {
            var selectListItems = htmlHelper.ViewData[category + "LookupItems"] as IList<LookupDto>;
            if ( selectListItems == null )
            {
                
            }
            return selectListItems;
        }

        public static string GetQuestionType(this HtmlHelper htmlHelper, ModelMetadata propertyMetadata)
        {
            if(propertyMetadata.AdditionalValues.ContainsKey ( QuestionAttribute.Question) )
            {
                return propertyMetadata.AdditionalValues[QuestionAttribute.Question].ToString ();
            }
            return QuestionType.GeneralQuestion.ToString();
        }

        public static bool HasCheckAllAttribute(this HtmlHelper htmlHelper)
        {
            return htmlHelper.ViewData.ModelMetadata.AdditionalValues.ContainsKey(CheckAllAttribute.CheckAll);
        }

        public static IEnumerable<IQuestionGroup> GetQuestionGroups(this HtmlHelper htmlHelper, ModelMetadata propertyMetadata)
        {
            if(propertyMetadata.AdditionalValues.ContainsKey ( QuestionGroupAttribute.QuestionGroup ))
            {
                var groups =
                    ( propertyMetadata.AdditionalValues[QuestionGroupAttribute.QuestionGroup] as
                      IEnumerable<IQuestionGroup> ).OrderBy ( qg => qg.ApplyOrder );
                return groups;
            }
            return Enumerable.Empty<IQuestionGroup> ();
        }

        public static string GetAsamPpcResource(this HtmlHelper htmlHelper, string resourceName)
        {
           return AsamPpcResources.ResourceManager.GetString ( resourceName );
        }

        public static IList<string> GetLegendLabelsForModel(this HtmlHelper htmlHelper)
        {
            return GetLegendLabels(htmlHelper, htmlHelper.ViewData.ModelMetadata);
        }

        public static IList<string> GetLegendLabels(this HtmlHelper htmlHelper, ModelMetadata metaData)
        {
            var resourceString = AsamPpcScaleResources.ResourceManager.GetString(string.Format("{0}_{1}",
                                                                                  metaData.ContainerType.Name.Replace("Dto", ""),
                                                                                  metaData.PropertyName));
            if (resourceString != null)
            {
                return resourceString.Split(new[] { "|" }, StringSplitOptions.None).ToList();
            }

            return null;
        }

        public static bool IsLookupProperty(this HtmlHelper htmlHelper, ModelMetadata propertyMetadata)
        {
            return propertyMetadata.ModelType == typeof(LookupDto) ||
                   typeof(IEnumerable<LookupDto>).IsAssignableFrom ( propertyMetadata.ModelType );
        }

        public static MvcHtmlString CheckBoxListForModel<T> ( this HtmlHelper htmlHelper,
                                                              IEnumerable<T> items,
                                                              string value,
                                                              string text,
                                                              object htmlAttributes = null )
        {
            var propertyName = htmlHelper.ViewData.ModelMetadata.PropertyName;

            var enumerableModel = htmlHelper.ViewData.Model as IEnumerable;

            //Convert selected value list to a List<string> for easy manipulation
            var selectedValues = enumerableModel != null ? enumerableModel.OfType<T>(): Enumerable.Empty<T>();

            //Create div
            var divTag = new TagBuilder ( "div" );
            divTag.MergeAttributes ( new RouteValueDictionary ( htmlAttributes ), true );
            divTag.MergeAttributes ( htmlHelper.GetUnobtrusiveValidationAttributes ( propertyName, htmlHelper.ViewData.ModelMetadata ) );
            const string labelAndCheckboxDiv = "<label tabIndex=\"{4}\"><input type=\"checkbox\" name=\"{0}\" id=\"{0}_{1}\" " +
                                               "value=\"{1}\" {2} />{3}</label>";

            var innerHtmlBuilder = new StringBuilder ( );
            foreach ( var item in items )
            {
                innerHtmlBuilder.Append ( String.Format ( labelAndCheckboxDiv,
                    propertyName,
                    DataBinder.Eval ( item, value ),
                    selectedValues.Contains ( item ) ? "checked=\"checked\"" : "",
                    DataBinder.Eval ( item, text ),
                    0 ) );
            }
            divTag.InnerHtml = innerHtmlBuilder.ToString ( );
            return MvcHtmlString.Create ( divTag.ToString ( ) );
        }

        public static MvcHtmlString ReadOnlyEditor(this HtmlHelper html, string expression, object additionalViewData = null)
        {
            return ReadOnlyEditor ( html, expression, null, null, additionalViewData );
        }

        public static MvcHtmlString ReadOnlyEditor(this HtmlHelper html, string expression, string templateName, object additionalViewData = null)
        {
            return ReadOnlyEditor(html, expression, templateName, null, additionalViewData);
        }

        public static MvcHtmlString ReadOnlyEditor(this HtmlHelper html, string expression, string templateName, string htmlFieldName, object additionalViewData = null)
        {
            var mvcHtmlString = html.Editor(expression, templateName, htmlFieldName, additionalViewData);
            var htmlString = mvcHtmlString.ToHtmlString ();
            if (htmlString.Contains("<input ") || htmlString.Contains("<select "))
            {
                return new MvcHtmlString(htmlString.Replace("<input ", "<input disabled=\"disabled\"")
                                                   .Replace("<select ", "<select disabled=\"disabled\""));
            }
            return mvcHtmlString;
        }

        public static IEnumerable<ModelMetadata> GetPropertiesToRender(this HtmlHelper html)
        {
            return
                html.ViewData.ModelMetadata.Properties.Where(p => p.ShowForEdit)
                    .OrderBy(meta => meta.Order);
        }

        public static bool CanAccess(this HtmlHelper htmlHelper, string controllerName, string actionName, string httpMethod = "GET")
        {
            controllerName = "Asam.Ppc.Mvc4.Controllers." + controllerName.ToFirstLetterUpper() + "Controller";
            var accessControlManager = DependencyResolver.Current.GetService<IAccessControlManager>();
            var resourceRequest = new ResourceRequest
                {
                    controllerName,
                    actionName.ToFirstLetterUpper(),
                    httpMethod.ToUpper()
                };
            var result = accessControlManager.CanAccess(resourceRequest);
            //Debug.WriteLine("*** {0} access to {1}", result ? "has" : "has NOT", resourceRequest);
            return result;
        }

        public static MvcHtmlString SecureActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues,
                                                     object htmlAttributes)
        {
            MvcHtmlString result;
            if (htmlHelper.CanAccess(controllerName, actionName)) // HttpMothed always be get
            {
                result = htmlHelper.ActionLink(linkText, actionName, controllerName,
                                               new RouteValueDictionary(routeValues),
                                               HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            }
            else
            {
                result = new MvcHtmlString(string.Empty);
            }
            return result;
        }
    }
}
