using System.Web.Http;
using System.Web.Mvc;
using Asam.Ppc.Mvc.Infrastructure;
using AuthorizeAttribute = System.Web.Mvc.AuthorizeAttribute;

namespace Asam.Ppc.Mvc4
{
    using Mvc.Infrastructure.Security;
    using Mvc.Infrastructure.Service;
    using NLog;
    using Pillar.Common.InversionOfControl;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExtendedHandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new RequireHttpsAttribute());
            filters.Add(IoC.CurrentContainer.Resolve<AccessControlSecurityFilter>());
            if ( LogManager.GetCurrentClassLogger().IsDebugEnabled )
            {
                filters.Add ( new LogAccessFilter() );
            }
        }

        public static void RegisterWebApiGlobalFilters(HttpConfiguration config)
        {
            config.Filters.Add(new ExtendedExceptionFilterAttribute());
            if (LogManager.GetCurrentClassLogger().IsDebugEnabled)
            {
                config.Filters.Add(new LogAccessFilter());
            }
        }
    }
}