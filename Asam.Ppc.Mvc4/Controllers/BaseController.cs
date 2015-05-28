using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Agatha.Common;
using Asam.Ppc.Mvc.Infrastructure.Security;
using Asam.Ppc.Service.Messages.Attributes;
using Asam.Ppc.Service.Messages.Common.Lookups;
using IAsyncRequestDispatcher = Asam.Ppc.Mvc.Infrastructure.Service.IAsyncRequestDispatcher;

namespace Asam.Ppc.Mvc4.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public abstract class BaseController : Controller
    {
        private readonly IRequestDispatcherFactory _requestDispatcherFactory;
        protected readonly IPatientAccessControlManager _patientAccessControlManager;

        protected BaseController(IRequestDispatcherFactory requestDispatcherFactory, IPatientAccessControlManager patientAccessControlManager)
        {
            _requestDispatcherFactory = requestDispatcherFactory;
            _patientAccessControlManager = patientAccessControlManager;
        }

        public IAsyncRequestDispatcher CreateAsyncRequestDispatcher()
        {
            return _requestDispatcherFactory.CreateRequestDispatcher() as IAsyncRequestDispatcher;
        }

        public void AddLookupRequests( IAsyncRequestDispatcher asyncRequestDispatcher, Type dtoType )
        {
            var lookupCategories =
                dtoType.GetProperties()
                       .Where(
                           p =>
                           p.PropertyType == typeof (LookupDto) || p.PropertyType == typeof (IEnumerable<LookupDto>))
                       .Select(p =>
                           {
                               var categoryAttribute =
                                   (LookupCategoryAttribute)
                                   p.GetCustomAttributes(typeof (LookupCategoryAttribute), false).FirstOrDefault();
                               return (string) (categoryAttribute == null ? p.Name : categoryAttribute.Category);
                           })
                       .Distinct();

            foreach (var category in lookupCategories)
            {
                asyncRequestDispatcher.Add ( category, new GetLookupsByCategoryRequest { Category = category } );
            }
        }

        public void AddLookupResponsesToViewData ( IAsyncRequestDispatcher asyncRequestDispatcher )
        {
            foreach ( GetLookupsByCategoryResponse categoryResponse in asyncRequestDispatcher.Responses.Where(r => r.GetType () == typeof(GetLookupsByCategoryResponse)) )
            {
                ViewData[categoryResponse.Category + "LookupItems"] = categoryResponse.Lookups.ToList ();
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (TempData["ModelState"] != null && !ModelState.Equals(TempData["ModelState"]))
            {
                ModelState.Merge((ModelStateDictionary) TempData["ModelState"]);
            }
            base.OnActionExecuted(filterContext);
            ViewBag.CanAccessAllPatients = _patientAccessControlManager.CanAccessAllPatients;
        }
    }
}