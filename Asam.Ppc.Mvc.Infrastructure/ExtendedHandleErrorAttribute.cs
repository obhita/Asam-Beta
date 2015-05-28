using System.Web;
using System.Web.Mvc;
using NLog;

namespace Asam.Ppc.Mvc.Infrastructure
{
    /// <summary>
    /// Extended build-in handle error attribute.
    /// </summary>
    public class ExtendedHandleErrorAttribute : HandleErrorAttribute
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Called when an exception occurs.
        /// </summary>
        /// <param name="filterContext">The action-filter context.</param>
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            if (new HttpException(null, filterContext.Exception).GetHttpCode() != 500)
            {
                return;
            }

            if (!ExceptionType.IsInstanceOfType(filterContext.Exception))
            {
                return;
            }

            // if the request is AJAX return JSON else view. //http://stackoverflow.com/questions/4707755/asp-net-mvc-ajax-error-handling
            if (filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Exception != null)//(filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new
                            {
                                error = true,
                                message = filterContext.Exception.Message,
                                stackTrace = filterContext.Exception.StackTrace
                            }
                    };
                filterContext.ExceptionHandled = true;
            }
            else
            {
                var controllerName = (string) filterContext.RouteData.Values["controller"];
                var actionName = (string) filterContext.RouteData.Values["action"];
                var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

                filterContext.Result = new ViewResult
                    {
                        ViewName = View,
                        MasterName = Master,
                        ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                        TempData = filterContext.Controller.TempData
                    };
            }

            logger.Error(filterContext.Exception.Message, filterContext.Exception);

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;

            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}
