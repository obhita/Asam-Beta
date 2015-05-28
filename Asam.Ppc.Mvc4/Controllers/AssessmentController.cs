using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Agatha.Common;
using Asam.Ppc.Domain.AssessmentModule;
using Asam.Ppc.Domain.SecurityModule;
using Asam.Ppc.Mvc.Infrastructure.Security;
using Asam.Ppc.Mvc.Infrastructure.Service;
using Asam.Ppc.Service.Messages.Assessment;
using Pillar.Common.InversionOfControl;

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

        [BusinessTransactionLogFilter]
        public virtual ActionResult Edit(long id)
        {
            var assessmentRepository = IoC.CurrentContainer.Resolve<IAssessmentRepository>();
            var assessment = assessmentRepository.GetByKey(id);
            var singleSignOn = SingleSignOnHelper.GetSingleSignOnParameters(HttpContext.ApplicationInstance);
            if (assessment.OrganizationKey.ToString() != singleSignOn.OrganizationId && singleSignOn.OrganizationId != null)
            {
                // return a 401
                // TODO: Create a custom 401 view
                return null;
            }

            var initialRoute = _routeNavigationService.GetInitialRoute ( id );
            return initialRoute.HasSubsection ? RedirectToRoute("SubSectionRoute", new { id, section = initialRoute.Section, subSection = initialRoute.SubSection }) : RedirectToRoute("SectionRoute", new { id, section = initialRoute.Section });
        }

        public ActionResult GetPrintView(long id)
        {
            return RedirectToAction ( "GetPrintView", "Section", new { id } );
        }
    }
}