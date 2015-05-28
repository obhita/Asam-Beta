namespace Asam.Ppc.Mvc4.Controllers
{
    #region Using Statements

    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Agatha.Common;
    using Mvc.Infrastructure.Security;
    using Pillar.Agatha.Message;
    using Primitives;
    using Service.Messages.Common;
    using Service.Messages.Organization;

    #endregion

    public class TeamController : BaseController
    {
        #region Constructors and Destructors

        public TeamController(IRequestDispatcherFactory requestDispatcherFactory, IPatientAccessControlManager patientAccessControlManager)
            : base(requestDispatcherFactory, patientAccessControlManager)
        {
        }

        #endregion

        #region Public Methods and Operators

        [HttpPost]
        public async Task<ActionResult> AddPatients(long id, long[] patientKeysToAdd)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher ();
            foreach ( var patientKey in patientKeysToAdd )
            {
                requestDispatcher.Add(patientKey.ToString(), new AddDtoRequest<TeamPatientDto> { AggregateKey = id, DataTransferObject = new TeamPatientDto { Key = patientKey } });
            }
            await requestDispatcher.GetAllAsync ();

            return new JsonResult {Data = patientKeysToAdd};
        }

        [HttpPost]
        public async Task<ActionResult> AddStaff(long id, long[] staffKeysToAdd)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher ();
            foreach ( var staffKey in staffKeysToAdd )
            {
                requestDispatcher.Add(staffKey.ToString(), new AddDtoRequest<TeamStaffDto> { AggregateKey = id, DataTransferObject = new TeamStaffDto { Key = staffKey } });
            }
            await requestDispatcher.GetAllAsync ();

            return new JsonResult {Data = staffKeysToAdd};
        }

        public ActionResult Create()
        {
            return View ();
        }

        [HttpPost]
        public async Task<ActionResult> Create ( string name )
        {
            var requestDispatcher = CreateAsyncRequestDispatcher ();
            requestDispatcher.Add ( new CreateTeamRequest {Name = name} );
            var response = await requestDispatcher.GetAsync<DtoResponse<TeamSummaryDto>> ();
            return RedirectToAction ( "Edit", new TeamDto {Key = response.DataTransferObject.Key, Name = response.DataTransferObject.Name} );
        }

        public async Task<ActionResult> Edit(long id)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new GetDtoByKeyRequest<TeamDto, long> { Key = id });
            var response = await requestDispatcher.GetAsync<DtoResponse<TeamDto>>();
            return View("Edit", response.DataTransferObject);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(long id, string name)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher ();
            requestDispatcher.Add(new UpdateTeamNameRequest { Key = id, Name = name });
            var response = await requestDispatcher.GetAsync<DtoResponse<TeamSummaryDto>> ();

            return new JsonResult {Data = new {}};
        }

        [HttpPost]
        public async Task<ActionResult> RemovePatients(long id, long[] patientKeysToRemove)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher ();
            foreach ( var patientKey in patientKeysToRemove )
            {
                requestDispatcher.Add(patientKey.ToString(), new RemovePatientFromTeamRequest { TeamKey = id, PatientKey = patientKey });
            }
            await requestDispatcher.GetAllAsync ();

            return new JsonResult {Data = patientKeysToRemove};
        }

        [HttpPost]
        public async Task<ActionResult> RemoveStaff(long id, long[] staffKeysToRemove)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher ();
            foreach ( var staffKey in staffKeysToRemove )
            {
                requestDispatcher.Add(staffKey.ToString(), new RemoveStaffFromTeamRequest { TeamKey = id, StaffKey = staffKey });
            }
            await requestDispatcher.GetAllAsync ();

            return new JsonResult {Data = staffKeysToRemove};
        }

        #endregion
    }
}