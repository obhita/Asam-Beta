using System.Web.Http;
using System.Web.Mvc;
using Asam.Ppc.Mvc.Infrastructure.Bootstrapper;
using Asam.Ppc.Mvc4.Controllers;
using Pillar.Common.InversionOfControl;

namespace Asam.Ppc.Mvc4.App_Start
{
    public class AsamConfig
    {
        public static void Bootstrap()
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();

            var dependencyResolver = new CustomDependencyResolver ( IoC.CurrentContainer );
            DependencyResolver.SetResolver(dependencyResolver);
            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;
        }
    }
}