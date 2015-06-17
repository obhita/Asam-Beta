using System.Web.Mvc;
using Agatha.Common;
using Asam.Ppc.Mvc.Infrastructure.Security;

namespace Asam.Ppc.Mvc4.Controllers
{
    using Infrastructure;

    public class HomeController : BaseController
    {
        public HomeController(IRequestDispatcherFactory requestDispatcherFactory, IPatientAccessControlManager patientAccessControlManager) 
            : base(requestDispatcherFactory, patientAccessControlManager)
        {
        }

        public virtual ActionResult Index(string assessmentId = null)
        {
            if ( UserContext.IsSystemAdmin )
            {
                return RedirectToAction ( "Index", "SystemAdmin" );
            }
            if ( _patientAccessControlManager.CanAccessAllPatients )
            {
                ViewData["AssessmentId"] = assessmentId;

                return View ();
            }
            return HttpNotFound ();
        }
    }
}
