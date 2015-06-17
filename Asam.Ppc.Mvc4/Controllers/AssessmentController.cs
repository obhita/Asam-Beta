using System.Threading.Tasks;
using System.Web.Mvc;
using Agatha.Common;
using Asam.Ppc.Mvc.Infrastructure.Security;
using Asam.Ppc.Mvc.Infrastructure.Service;
using Asam.Ppc.Service.Messages.Assessment;

namespace Asam.Ppc.Mvc4.Controllers
{
    public class AssessmentController : BaseController
    {
        private readonly IRouteNavigationService _routeNavigationService;

        public AssessmentController(IRequestDispatcherFactory requestDispatcherFactory, 
            IRouteNavigationService routeNavigationService,
            IPatientAccessControlManager patientAccessControlManager)
            : base(requestDispatcherFactory, patientAccessControlManager)
        {
            _routeNavigationService = routeNavigationService;
        }

        public async Task<ActionResult> CreateForPatientId(long id)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new CreateAssessmentRequest { PatientId = id });
            var response = await requestDispatcher.GetAsync<CreateAssessmentResponse>();
            return RedirectToAction("Edit", new { id = response.AssessmentId });
        }

        public virtual ActionResult Edit(long id)
        {
            var initialRoute = _routeNavigationService.GetInitialRoute ( id );
            if (initialRoute.HasSubsection)
            {
                return RedirectToRoute("SubSectionRoute", new { id = id, section = initialRoute.Section, subSection = initialRoute.SubSection });
            }
            return RedirectToRoute("SectionRoute", new { id = id, section = initialRoute.Section });
        }
    }
}