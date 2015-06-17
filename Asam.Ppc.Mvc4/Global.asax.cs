using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Validation.Providers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Asam.Ppc.Mvc.Infrastructure;
using Asam.Ppc.Mvc.Infrastructure.Binders;
using Asam.Ppc.Mvc.Infrastructure.Service;
using Asam.Ppc.Mvc4.App_Start;
using Asam.Ppc.Mvc4.Controllers;
using Asam.Ppc.Service.Messages.Common.Lookups;
using NLog;

namespace Asam.Ppc.Mvc4
{
    using System.IdentityModel.Services;
    using System.IdentityModel.Tokens;
    using Infrastructure;
    using Mvc.Infrastructure.Security;
    using NLog.Config;
    using Pillar.Common.InversionOfControl;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : HttpApplication
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        static WebApiApplication ()
        {
            ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("user-context", typeof(UserContextLayoutRenderer));
        }

        protected void Application_Start ( )
        {
            AreaRegistration.RegisterAllAreas ( );

            AsamConfig.Bootstrap ( );

            ModelBinders.Binders.DefaultBinder = new AsamModelBinder ( );
            ModelBinders.Binders.Add ( typeof ( IEnumerable<LookupDto> ), new EnumerableLookupDtoModelBinder ( ) );
            ModelMetadataProviders.Current = IoC.CurrentContainer.Resolve<AsamModelMetadataProvider>();

            ModelValidatorProviders.Providers.Add ( new CompletenessModelValidatorProvider () );

            FilterConfig.RegisterGlobalFilters ( GlobalFilters.Filters );
            FilterConfig.RegisterWebApiGlobalFilters(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes ( RouteTable.Routes );
            BundleConfig.RegisterBundles ( BundleTable.Bundles );

            // More @ http://www.cnblogs.com/guogangj/archive/2012/10/10/2718360.html 
            // TODO: find a better solution for this.
            GlobalConfiguration.Configuration.Services.RemoveAll (
                typeof ( System.Web.Http.Validation.ModelValidatorProvider ), v => v is InvalidModelValidatorProvider );
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new AllowPrivateSetterContractResolver ( );

            //FederatedAuthentication.SessionAuthenticationModule.SessionSecurityTokenReceived +=
            //    SessionAuthenticationModule_SessionSecurityTokenReceived;

            //ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // http://www.codeproject.com/Articles/422572/Exception-Handling-in-ASP-NET-MVC
            var exception = Server.GetLastError();
            logger.Error(exception.Message, exception);
            if (exception is SecurityTokenException)
            {
                Server.ClearError();
                var logoutService = IoC.CurrentContainer.Resolve<ILogoutService>();
                var signoutMessage = logoutService.Logout();
                HttpContext.Current.Response.Redirect(signoutMessage.WriteQueryString());
                return;
            }

            var action = "HttpError";
            if (exception is HttpException)
            {
                var httpEx = exception as HttpException;

                switch (httpEx.GetHttpCode())
                {
                    case (int)HttpStatusCode.NotFound:
                        action = "Http404";
                        break;
                    default:
                        action = "HttpError";
                        break;
                }
            }
            var httpContext = HttpContext.Current;
            logger.Error(string.Format("{0} {1}", exception.Message, httpContext.Request.Url), exception);
            
            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var currentController = " ";
            var currentAction = " ";
            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null &&
                    !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                {
                    currentController = currentRouteData.Values["controller"].ToString();
                }

                if (currentRouteData.Values["action"] != null &&
                    !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                {
                    currentAction = currentRouteData.Values["action"].ToString();
                }
            }

            httpContext.ClearError();
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = exception is HttpException
                                                  ? ((HttpException) exception).GetHttpCode()
                                                  : (int) HttpStatusCode.InternalServerError;
            httpContext.Response.TrySkipIisCustomErrors = true;
            var controller = new ErrorController();
            var routeData = new RouteData();
            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = action;
            controller.ViewData.Model = new HandleErrorInfo(exception, currentController, currentAction);
            ((IController) controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
        }

        protected void WSFederationAuthenticationModule_SessionSecurityTokenCreated(object sender, SessionSecurityTokenCreatedEventArgs e)
        {
#if DEBUG
            e.SessionToken.IsPersistent = false;
#endif
            e.SessionToken.IsReferenceMode = true;
        }

        protected void SessionAuthenticationModule_SessionSecurityTokenReceived(object sender, SessionSecurityTokenReceivedEventArgs e)
        {
            // The sliding expiration implementation will extend the token validity interval based on the current interval length when it is detected as expired.
            var utcNow = DateTime.UtcNow;
            var validFrom = e.SessionToken.ValidFrom;
            var validTo = e.SessionToken.ValidTo;

            if (validTo > utcNow)
            {
                return;
            }

            var sessionAuthenticationModule = sender as SessionAuthenticationModule;

            if (sessionAuthenticationModule == null)
            {
                return;
            }

            var slidingExpiration = validTo - validFrom;
            var newValidTo = utcNow + slidingExpiration;
            e.SessionToken = sessionAuthenticationModule.CreateSessionSecurityToken(
                e.SessionToken.ClaimsPrincipal, e.SessionToken.Context, utcNow, newValidTo, e.SessionToken.IsPersistent);
            e.ReissueCookie = true;
        }
    }
}