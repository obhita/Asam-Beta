#region Using Statements

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

#endregion

namespace Asam.Ppc.Mvc.Infrastructure
{
    /// <summary>
    /// Validation extensions.
    /// </summary>
    public static class ValidationExtensions
    {
        #region default code

        private const string HiddenListItem = @"<li style=""display:none""></li>";
        private static string _resourceClassKey;

        /// <summary>
        /// Gets or sets the resource class key.
        /// </summary>
        /// <value>
        /// The resource class key.
        /// </value>
        public static string ResourceClassKey
        {
            get { return _resourceClassKey ?? String.Empty; }
            set { _resourceClassKey = value; }
        }

        private static FieldValidationMetadata ApplyFieldValidationMetadata(HtmlHelper htmlHelper,
                                                                            ModelMetadata modelMetadata,
                                                                            string modelName)
        {
            FormContext formContext = htmlHelper.ViewContext.FormContext;
            FieldValidationMetadata fieldMetadata = formContext.GetValidationMetadataForField(modelName, true
                /* createIfNotFound */);

            // write rules to context object
            IEnumerable<ModelValidator> validators = ModelValidatorProviders.Providers.GetValidators(modelMetadata,
                                                                                                     htmlHelper
                                                                                                         .ViewContext);
            foreach (var rule in validators.SelectMany(v => v.GetClientValidationRules()))
            {
                fieldMetadata.ValidationRules.Add(rule);
            }

            return fieldMetadata;
        }

        private static string GetInvalidPropertyValueResource(HttpContextBase httpContext)
        {
            string resourceValue = null;
            if (!String.IsNullOrEmpty(ResourceClassKey) && (httpContext != null))
            {
                // If the user specified a ResourceClassKey try to load the resource they specified.
                // If the class key is invalid, an exception will be thrown.
                // If the class key is valid but the resource is not found, it returns null, in which
                // case it will fall back to the MVC default error message.
                resourceValue =
                    httpContext.GetGlobalResourceObject(ResourceClassKey, "InvalidPropertyValue",
                                                        CultureInfo.CurrentUICulture) as string;
            }
            return resourceValue ?? "Warning: Value not valid for this property."
                /*MvcResources.Common_ValueNotValidForProperty*/;
        }

        private static string GetUserErrorMessageOrDefault(HttpContextBase httpContext, ModelError error,
                                                           ModelState modelState)
        {
            if (!String.IsNullOrEmpty(error.ErrorMessage))
            {
                return error.ErrorMessage;
            }
            if (modelState == null)
            {
                return null;
            }

            string attemptedValue = (modelState.Value != null) ? modelState.Value.AttemptedValue : null;
            return String.Format(CultureInfo.CurrentCulture, GetInvalidPropertyValueResource(httpContext),
                                 attemptedValue);
        }


        // ValidationMessage

        /// <summary>
        /// Extend the validation message.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="modelName">Name of the model.</param>
        /// <returns><see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString ExtendedValidationMessage(this HtmlHelper htmlHelper, string modelName)
        {
            return ExtendedValidationMessage(htmlHelper, modelName, null /* validationMessage */,
                                             new RouteValueDictionary());
        }

        /// <summary>
        /// Extend the validation message.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="modelName">Name of the model.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns><see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString ExtendedValidationMessage(this HtmlHelper htmlHelper, string modelName,
                                                              object htmlAttributes)
        {
            return ExtendedValidationMessage(htmlHelper, modelName, null /* validationMessage */,
                                             HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Extendeds the validation message.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="modelName">Name of the model.</param>
        /// <param name="validationMessage">The validation message.</param>
        /// <returns><see cref="MvcHtmlString"/>.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames",
            Justification =
                "'validationMessage' refers to the message that will be rendered by the ValidationMessage helper.")]
        public static MvcHtmlString ExtendedValidationMessage(this HtmlHelper htmlHelper, string modelName,
                                                              string validationMessage)
        {
            return ExtendedValidationMessage(htmlHelper, modelName, validationMessage, new RouteValueDictionary());
        }

        /// <summary>
        /// Extend the validation message.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="modelName">Name of the model.</param>
        /// <param name="validationMessage">The validation message.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns><see cref="MvcHtmlString"/>.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames",
            Justification =
                "'validationMessage' refers to the message that will be rendered by the ValidationMessage helper.")]
        public static MvcHtmlString ExtendedValidationMessage(this HtmlHelper htmlHelper, string modelName,
                                                              string validationMessage, object htmlAttributes)
        {
            return ExtendedValidationMessage(htmlHelper, modelName, validationMessage,
                                             HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Validations the message.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="modelName">Name of the model.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns><see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString ValidationMessage(this HtmlHelper htmlHelper, string modelName,
                                                      IDictionary<string, object> htmlAttributes)
        {
            return ExtendedValidationMessage(htmlHelper, modelName, null /* validationMessage */, htmlAttributes);
        }

        /// <summary>
        /// Extended the validation message.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="modelName">Name of the model.</param>
        /// <param name="validationMessage">The validation message.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns><see cref="MvcHtmlString"/>.</returns>
        /// <exception cref="System.ArgumentNullException">modelName</exception>
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames",
            Justification =
                "'validationMessage' refers to the message that will be rendered by the ValidationMessage helper.")]
        public static MvcHtmlString ExtendedValidationMessage(this HtmlHelper htmlHelper, string modelName,
                                                              string validationMessage,
                                                              IDictionary<string, object> htmlAttributes)
        {
            if (modelName == null)
            {
                throw new ArgumentNullException("modelName");
            }

            return ExtendedValidationMessageHelper(htmlHelper,
                                                   ModelMetadata.FromStringExpression(modelName,
                                                                                      htmlHelper.ViewContext.ViewData),
                                                   modelName,
                                                   validationMessage,
                                                   htmlAttributes);
        }

        /// <summary>
        /// Extended the validation message for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <returns><see cref="MvcHtmlString"/>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString ExtendedValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                    Expression<Func<TModel, TProperty>>
                                                                                        expression)
        {
            return ExtendedValidationMessageFor(htmlHelper, expression, null /* validationMessage */,
                                                new RouteValueDictionary());
        }

        /// <summary>
        /// Extended the validation message for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="validationMessage">The validation message.</param>
        /// <returns><see cref="MvcHtmlString"/>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString ExtendedValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                            Expression<Func<TModel, TProperty>>
                                                                                expression, string validationMessage)
        {
            return ExtendedValidationMessageFor(htmlHelper, expression, validationMessage, new RouteValueDictionary());
        }

        /// <summary>
        /// Extended the validation message for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="validationMessage">The validation message.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString ExtendedValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                            Expression<Func<TModel, TProperty>>
                                                                                expression, string validationMessage,
                                                                            object htmlAttributes)
        {
            return ExtendedValidationMessageFor(htmlHelper, expression, validationMessage,
                                                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Extended the validation message for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="validationMessage">The validation message.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns><see cref="MvcHtmlString"/>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString ExtendedValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                    Expression<Func<TModel, TProperty>>
                                                                                        expression,
                                                                                    string validationMessage,
                                                                                    IDictionary<string, object>
                                                                                        htmlAttributes)
        {
            return ExtendedValidationMessageHelper(htmlHelper,
                                                   ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData),
                                                   ExpressionHelper.GetExpressionText(expression),
                                                   validationMessage,
                                                   htmlAttributes);
        }


        internal static FormContext GetFormContextForClientValidation(ViewContext viewContext)
        {
            return !viewContext.ClientValidationEnabled ? null : viewContext.FormContext;
        }


        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase",
            Justification = "Normalization to lowercase is a common requirement for JavaScript and HTML values")]
        private static MvcHtmlString ValidationMessageHelper(this HtmlHelper htmlHelper,
                                                             ModelMetadata modelMetadata,
                                                             string expression, string validationMessage,
                                                             IDictionary<string, object> htmlAttributes)
        {
            string modelName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);
            FormContext formContext = GetFormContextForClientValidation(htmlHelper.ViewContext);

            if (!htmlHelper.ViewData.ModelState.ContainsKey(modelName) && formContext == null)
            {
                return null;
            }
            ModelState modelState = htmlHelper.ViewData.ModelState[modelName];
            ModelErrorCollection modelErrors = (modelState == null) ? null : modelState.Errors;
            ModelError modelError = (((modelErrors == null) || (modelErrors.Count == 0))
                                         ? null
                                         : modelErrors.FirstOrDefault(m => !String.IsNullOrEmpty(m.ErrorMessage)) ??
                                           modelErrors[0]);

            if (modelError == null && formContext == null)
            {
                return null;
            }

            var builder = new TagBuilder("span");
            builder.MergeAttributes(htmlAttributes);
            builder.AddCssClass((modelError != null)
                                    ? HtmlHelper.ValidationMessageCssClassName
                                    : HtmlHelper.ValidationMessageValidCssClassName);

            if (!String.IsNullOrEmpty(validationMessage))
            {
                builder.SetInnerText(validationMessage);
            }
            else if (modelError != null)
            {
                builder.SetInnerText(GetUserErrorMessageOrDefault(htmlHelper.ViewContext.HttpContext, modelError,
                                                                  modelState));
            }

            if (formContext != null)
            {
                bool replaceValidationMessageContents = String.IsNullOrEmpty(validationMessage);

                if (htmlHelper.ViewContext.UnobtrusiveJavaScriptEnabled)
                {
                    builder.MergeAttribute("data-valmsg-for", modelName);
                    builder.MergeAttribute("data-valmsg-replace",
                                           replaceValidationMessageContents.ToString().ToLowerInvariant());
                }
                else
                {
                    FieldValidationMetadata fieldMetadata = ApplyFieldValidationMetadata(htmlHelper, modelMetadata,
                                                                                         modelName);
                    // rules will already have been written to the metadata object
                    fieldMetadata.ReplaceValidationMessageContents = replaceValidationMessageContents;
                        // only replace contents if no explicit message was specified

                    // client validation always requires an ID
                    builder.GenerateId(modelName + "_validationMessage");
                    fieldMetadata.ValidationMessageId = builder.Attributes["id"];
                }
            }

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase",
            Justification = "Normalization to lowercase is a common requirement for JavaScript and HTML values")]
        private static MvcHtmlString ExtendedValidationMessageHelper(this HtmlHelper htmlHelper,
                                                                     ModelMetadata modelMetadata,
                                                                     string expression, string validationMessage,
                                                                     IDictionary<string, object> htmlAttributes)
        {
            var mvcHtmlString = ValidationMessageHelper(htmlHelper, modelMetadata, expression, validationMessage,
                                                        htmlAttributes);

            string modelName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);
            FormContext formContext = GetFormContextForClientValidation(htmlHelper.ViewContext);

            if (!htmlHelper.ViewData.ModelState.ContainsKey(modelName) && formContext == null)
            {
                return mvcHtmlString;
            }

            ModelState modelState = htmlHelper.ViewData.ModelState[modelName];
            var extendedModelState = modelState as ExtendedModelState;
            ModelErrorCollection modelWarnings = null;
            if (extendedModelState == null)
            {
                return mvcHtmlString;
            }
            modelWarnings = extendedModelState.Warnings;
            ModelError modelWarning = (((modelWarnings == null) || (modelWarnings.Count == 0))
                                           ? null
                                           : modelWarnings.FirstOrDefault(m => !String.IsNullOrEmpty(m.ErrorMessage)) ??
                                             modelWarnings[0]);
            if (modelWarning == null)
            {
                return mvcHtmlString;
            }

            var builder = new TagBuilder("span");
            builder.MergeAttributes(htmlAttributes);
            builder.AddCssClass(modelWarning != null
                                    ? HtmlHelpers.ValidationSummaryWarningCssClassName
                                    : HtmlHelper.ValidationMessageValidCssClassName);

            builder.SetInnerText(GetUserErrorMessageOrDefault(htmlHelper.ViewContext.HttpContext, modelWarning, modelState));

            if (formContext != null)
            {
                bool replaceValidationMessageContents = String.IsNullOrEmpty(validationMessage);

                if (htmlHelper.ViewContext.UnobtrusiveJavaScriptEnabled)
                {
                    builder.MergeAttribute("data-valmsg-for", modelName);
                    builder.MergeAttribute("data-valmsg-replace",
                                           replaceValidationMessageContents.ToString().ToLowerInvariant());
                }
                else
                {
                    FieldValidationMetadata fieldMetadata = ApplyFieldValidationMetadata(htmlHelper, modelMetadata,
                                                                                         modelName);
                    // rules will already have been written to the metadata object
                    fieldMetadata.ReplaceValidationMessageContents = replaceValidationMessageContents;
                    // only replace contents if no explicit message was specified

                    // client validation always requires an ID
                    builder.GenerateId(modelName + "_validationMessage");
                    fieldMetadata.ValidationMessageId = builder.Attributes["id"];
                }
            }

            var mvcHtmlStringWithWarning =
                MvcHtmlString.Create((mvcHtmlString == null ? string.Empty : mvcHtmlString.ToHtmlString()) +
                                     builder.ToString(TagRenderMode.Normal));
            return mvcHtmlStringWithWarning;
        }

        #endregion

        // ValidationSummary

        /// <summary>
        /// Extended the validation summary.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <returns><see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString ExtendedValidationSummary(this HtmlHelper htmlHelper)
        {
            return ExtendedValidationSummary(htmlHelper, false /* excludePropertyErrors */);
        }

        /// <summary>
        /// Extended the validation summary.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="excludePropertyErrors">if set to <c>true</c> [exclude property errors].</param>
        /// <returns></returns>
        public static MvcHtmlString ExtendedValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors)
        {
            return ExtendedValidationSummary(htmlHelper, excludePropertyErrors, null /* message */);
        }

        /// <summary>
        /// Extended the validation summary.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static MvcHtmlString ExtendedValidationSummary(this HtmlHelper htmlHelper, string message)
        {
            return ExtendedValidationSummary(htmlHelper, false /* excludePropertyErrors */, message, null
                /* htmlAttributes */);
        }

        /// <summary>
        /// Extended the validation summary.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="excludePropertyErrors">if set to <c>true</c> [exclude property errors].</param>
        /// <param name="message">The message.</param>
        /// <returns><see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString ExtendedValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors,
                                                              string message)
        {
            return ExtendedValidationSummary(htmlHelper, excludePropertyErrors, message, null /* htmlAttributes */);
        }

        /// <summary>
        /// Extended the validation summary.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="message">The message.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString ExtendedValidationSummary(this HtmlHelper htmlHelper, string message,
                                                              object htmlAttributes)
        {
            return ExtendedValidationSummary(htmlHelper, false /* excludePropertyErrors */, message,
                                             HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Extended the validation summary.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="excludePropertyErrors">if set to <c>true</c> [exclude property errors].</param>
        /// <param name="message">The message.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns><see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString ExtendedValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors,
                                                              string message, object htmlAttributes)
        {
            return ExtendedValidationSummary(htmlHelper, excludePropertyErrors, message,
                                             HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Extended the validation summary.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="message">The message.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString ExtendedValidationSummary(this HtmlHelper htmlHelper, string message,
                                                              IDictionary<string, object> htmlAttributes)
        {
            return ExtendedValidationSummary(htmlHelper, false /* excludePropertyErrors */, message, htmlAttributes);
        }

        /// <summary>
        /// Extended the validation summary.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="excludePropertyErrors">if set to <c>true</c> [exclude property errors].</param>
        /// <param name="message">The message.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns><see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString ExtendedValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors,
                                                              string message, IDictionary<string, object> htmlAttributes)
        {
            var mvcHtmlString = htmlHelper.ValidationSummary(excludePropertyErrors, message, htmlAttributes);

            if (!htmlHelper.ViewData.ModelState.HasWarnings())
            {
                return mvcHtmlString;
            }

            FormContext formContext = GetFormContextForClientValidation(htmlHelper.ViewContext);

            var htmlSummary = new StringBuilder();
            var unorderedList = new TagBuilder("ul");
            IEnumerable<ModelState> modelStates = GetModelStateList(htmlHelper, excludePropertyErrors);

            foreach (var modelState in modelStates)
            {
                var extendedModelState = modelState as ExtendedModelState;
                if (extendedModelState == null)
                {
                    continue;
                }
                foreach (var modelError in extendedModelState.Warnings)
                {
                    string errorText = GetUserErrorMessageOrDefault(htmlHelper.ViewContext.HttpContext, modelError, null);
                    if (!String.IsNullOrEmpty(errorText))
                    {
                        var listItem = new TagBuilder("li");
                        listItem.SetInnerText(errorText);
                        htmlSummary.AppendLine(listItem.ToString(TagRenderMode.Normal));
                    }
                }
            }

            if (htmlSummary.Length == 0)
            {
                htmlSummary.AppendLine(HiddenListItem);
            }

            unorderedList.InnerHtml = htmlSummary.ToString();

            var divBuilder = new TagBuilder("div");
            divBuilder.MergeAttributes(htmlAttributes);
            divBuilder.AddCssClass((htmlHelper.ViewData.ModelState.HasWarnings())
                                       ? HtmlHelpers.ValidationSummaryWarningCssClassName
                                       : HtmlHelper.ValidationSummaryCssClassName);
            divBuilder.InnerHtml = unorderedList.ToString(TagRenderMode.Normal);

            if (formContext != null)
            {
                if (htmlHelper.ViewContext.UnobtrusiveJavaScriptEnabled)
                {
                    if (!excludePropertyErrors)
                    {
                        // Only put errors in the validation summary if they're supposed to be included there
                        divBuilder.MergeAttribute("data-valmsg-summary", "true");
                    }
                }
                else
                {
                    // client val summaries need an ID
                    divBuilder.GenerateId("validationSummary");
                    formContext.ValidationSummaryId = divBuilder.Attributes["id"];
                    formContext.ReplaceValidationSummary = !excludePropertyErrors;
                }
            }
            var htmlString = (mvcHtmlString == null ? string.Empty : mvcHtmlString.ToHtmlString()) +
                             divBuilder.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(htmlString);
        }


        // Returns non-null list of model states, which caller will render in order provided.
        private static IEnumerable<ModelState> GetModelStateList(HtmlHelper htmlHelper, bool excludePropertyErrors)
        {
            if (excludePropertyErrors)
            {
                ModelState ms;
                htmlHelper.ViewData.ModelState.TryGetValue(htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix, out ms);
                if (ms != null)
                {
                    return new ModelState[] {ms};
                }

                return new ModelState[0];
            }
            else
            {
                // Sort modelStates to respect the ordering in the metadata.                 
                // ModelState doesn't refer to ModelMetadata, but we can correlate via the property name.
                var ordering = new Dictionary<string, int>();

                var metadata = htmlHelper.ViewData.ModelMetadata;
                if (metadata != null)
                {
                    foreach (var m in metadata.Properties)
                    {
                        ordering[m.PropertyName] = m.Order;
                    }
                }

                return from kv in htmlHelper.ViewData.ModelState
                       let name = kv.Key
                       select kv.Value;
            }
        }
    }
}