using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Asam.Ppc.Mvc4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapHttpRoute("DefaultApiGet",
                                  "api/{controller}/{action}/{id}",
                                  new { id = RouteParameter.Optional, action = "Get" },
                                  new { httpMethod = new HttpMethodConstraint("GET") }
                ); 

            routes.MapHttpRoute("DefaultApiPost",
                                  "api/{controller}/{action}/{id}",
                                  new { id = RouteParameter.Optional, action = "Post" },
                                  new { httpMethod = new HttpMethodConstraint("POST") }
                );

            routes.MapHttpRoute("DefaultApiPut",
                                  "api/{controller}/{action}/{id}",
                                  new { id = RouteParameter.Optional, action = "Put" },
                                  new { httpMethod = new HttpMethodConstraint("PUT") }
                );

            routes.MapRoute(
               "SubSectionRoute",
               "interview/{section}/{subsection}/{action}/{id}",
               new { controller = "Section", action = "Edit" }
           );

            routes.MapRoute(
                "SectionRoute",
                "interview/{section}/{action}/{id}",
                new { controller = "Section", action = "Edit" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute("Error", "{*url}", new { controller = "Error", action = "Http404" });
        }
    }
}