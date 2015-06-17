namespace Asam.Ppc.Mvc.Infrastructure.Service
{
    #region Using Statements

    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    using NLog;
    using Newtonsoft.Json;
    using IActionFilter = System.Web.Http.Filters.IActionFilter;

    #endregion

    public class LogAccessFilter : ActionFilterAttribute, IActionFilter
    {
        #region Static Fields

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger ();

        #endregion

        #region Public Methods and Operators

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }
            if (continuation == null)
            {
                throw new ArgumentNullException("continuation");
            }

            var stopWatch = new Stopwatch();
            try
            {
                stopWatch.Start();
                Logger.Debug("Start - Controller: {0}, Action: {1}, Url: {2}, DateTime: {3}",
                               actionContext.ControllerContext.Controller,
                               actionContext.ActionDescriptor.ActionName,
                               actionContext.Request.RequestUri.AbsoluteUri,
                               DateTime.Now);

                if (actionContext.Request.Content != null && Logger.IsTraceEnabled)
                {
                    Logger.Trace("Request Content: {0}", actionContext.Request.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception e)
            {
                var tcs = new TaskCompletionSource<HttpResponseMessage>();
                tcs.SetException(e);
                return tcs.Task;
            }

            if (actionContext.Response != null)
            {
                var tcs = new TaskCompletionSource<HttpResponseMessage>();
                tcs.SetResult(actionContext.Response);
                return tcs.Task;
            }

            return CallOnActionExecutedAsync(actionContext, cancellationToken, continuation, stopWatch);
        }

        private async Task<HttpResponseMessage> CallOnActionExecutedAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation, Stopwatch stopWatch)
        {
            cancellationToken.ThrowIfCancellationRequested();

            HttpResponseMessage response = null;
            try
            {
                response = await continuation();
            }
            catch (Exception)
            {
                stopWatch.Stop();
                throw;
            }

            try
            {
                stopWatch.Stop();
                Logger.Debug("End - Controller: {0}, Action: {1}, Url: {2}, DateTime: {3}, Duration: {4} milliseconds",
                               actionContext.ControllerContext.Controller,
                               actionContext.ActionDescriptor.ActionName,
                               actionContext.Request.RequestUri.AbsoluteUri,
                               DateTime.Now,
                               stopWatch.ElapsedMilliseconds);
                if (Logger.IsTraceEnabled && response.Content != null)
                {
                    Logger.Trace("Results: {0}", response.Content.ReadAsStringAsync().Result);
                }
            }
            catch
            {
                // Catch is running because OnActionExecuted threw an exception, so we just want to re-throw the exception.
                // We also need to reset the response to forget about it since a filter threw an exception.
                actionContext.Response = null;
                throw;
            }
            return response;
        }

        public override void OnActionExecuted ( ActionExecutedContext filterContext )
        {
            base.OnActionExecuted ( filterContext );
            Logger.Debug ( "End - Controller: {0}, Action: {1}, Url: {2}, DateTime: {3}",
                           filterContext.Controller,
                           filterContext.ActionDescriptor.ActionName,
                           filterContext.RequestContext.HttpContext.Request.Url,
                           DateTime.Now );
            if ( Logger.IsTraceEnabled )
            {
                var resultString = filterContext.Result.ToString ();
                if ( filterContext.Result is JsonResult )
                {
                    var jsonResult = ( filterContext.Result as JsonResult );
                    var serializer = new JavaScriptSerializer ();
                    if ( jsonResult.MaxJsonLength.HasValue )
                    {
                        serializer.MaxJsonLength = jsonResult.MaxJsonLength.Value;
                    }
                    if ( jsonResult.RecursionLimit.HasValue )
                    {
                        serializer.RecursionLimit = jsonResult.RecursionLimit.Value;
                    }
                    resultString = serializer.Serialize ( jsonResult.Data );
                }
                else if ( filterContext.Result is ViewResultBase )
                {
                    resultString = JsonConvert.SerializeObject ( ( filterContext.Result as ViewResultBase ).Model );
                }
                else if ( filterContext.Result is ContentResult )
                {
                    var contentResult = filterContext.Result as ContentResult;
                    resultString = string.Format ( "Content Type: {0}, Content: {1}", contentResult.ContentType, contentResult.Content );
                }
                else if ( filterContext.Result is RedirectResult )
                {
                    var redirectResult = filterContext.Result as RedirectResult;
                    resultString = string.Format ( "Redirect: {0}", redirectResult.Url );
                }
                else if ( filterContext.Result is RedirectToRouteResult )
                {
                    var redirectResult = filterContext.Result as RedirectToRouteResult;
                    resultString = string.Format ( "Redirect: {0}, Route Data: {1}",
                                                   redirectResult.RouteName,
                                                   string.Join ( ",", redirectResult.RouteValues.Select ( rv => string.Format ( "{{{0}: {1}}}", rv.Key, rv.Value ) ) ) );
                }
                else if ( filterContext.Result is HttpStatusCodeResult )
                {
                    var httpResult = filterContext.Result as HttpStatusCodeResult;
                    resultString = string.Format ( "Http Status: {0} - {1}", httpResult.StatusCode, httpResult.StatusDescription );
                }
                else if ( filterContext.Result is JavaScriptResult )
                {
                    var scriptResult = filterContext.Result as JavaScriptResult;
                    resultString = scriptResult.Script;
                }
                Logger.Trace ( "Result: {0}", JsonConvert.SerializeObject ( resultString ) );
                Logger.Trace ( "View Data: {0}", JsonConvert.SerializeObject ( filterContext.Controller.ViewData ) );
            }
        }

        public override void OnActionExecuting ( ActionExecutingContext filterContext )
        {
            Logger.Debug ( "Start - Controller: {0}, Action: {1}, Url: {2}, DateTime: {3}",
                           filterContext.Controller,
                           filterContext.ActionDescriptor.ActionName,
                           filterContext.RequestContext.HttpContext.Request.Url,
                           DateTime.Now );
            if ( Logger.IsTraceEnabled )
            {
                using ( var reader = new StreamReader ( filterContext.HttpContext.Request.InputStream ) )
                {
                    Logger.Trace ( "Request Content: {0}", reader.ReadToEnd () );
                }
            }
            base.OnActionExecuting ( filterContext );
        }

        #endregion
    }
}