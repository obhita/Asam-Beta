using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Asam.Ppc.Mvc.Infrastructure
{
    public static class LinkExtensions
    {
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, bool showActionLinkAsDisabled = false)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, null, new RouteValueDictionary(), new RouteValueDictionary(), showActionLinkAsDisabled);
        }

        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues, bool showActionLinkAsDisabled = false)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, null, GetRouteValueDictionary(routeValues), new RouteValueDictionary(), showActionLinkAsDisabled);
        }

        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, bool showActionLinkAsDisabled = false)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, controllerName, new RouteValueDictionary(), new RouteValueDictionary(), showActionLinkAsDisabled);
        }

        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues, bool showActionLinkAsDisabled = false)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, null, routeValues, new RouteValueDictionary(), showActionLinkAsDisabled);
        }

        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues, object htmlAttributes, bool showActionLinkAsDisabled = false)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, null, GetRouteValueDictionary(routeValues), GetRouteValueDictionary(htmlAttributes), showActionLinkAsDisabled);
        }

        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, bool showActionLinkAsDisabled = false)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, null, routeValues, htmlAttributes, showActionLinkAsDisabled);
        }

        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes, bool showActionLinkAsDisabled = false)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, controllerName, GetRouteValueDictionary(routeValues), GetRouteValueDictionary(htmlAttributes), showActionLinkAsDisabled);
        }

        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, bool showActionLinkAsDisabled)
        {
            MvcHtmlString result = MvcHtmlString.Empty;

            result = htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes);

            return result;
        }

        private static RouteValueDictionary GetRouteValueDictionary(object routeValues)
        {
            RouteValueDictionary result;

            if (routeValues is RouteValueDictionary)
            {
                result = routeValues as RouteValueDictionary;
            }
            else
            {
                result = new RouteValueDictionary(routeValues);
            }

            return result;
        }
    }
}
