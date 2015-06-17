namespace Asam.Ppc.Mvc4.Controllers
{
    #region Using Statements

    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Agatha.Common;
    using Mvc.Infrastructure.Security;
    using Service.Messages.Common;
    using Service.Messages.Organization;

    #endregion

    public class OrganizationController : BaseController
    {
        #region Constructors and Destructors

        public OrganizationController(IRequestDispatcherFactory requestDispatcherFactory, IPatientAccessControlManager patientAccessControlManager)
            : base(requestDispatcherFactory, patientAccessControlManager)
        {
        }

        #endregion

        #region Public Methods and Operators

        public async Task<ActionResult> Index()
        {
            var requestDispatcher = CreateAsyncRequestDispatcher ();
            requestDispatcher.Add(new GetDtoByKeyRequest<OrganizationSummaryDto> ());
            var response = await requestDispatcher.GetAsync<DtoResponse<OrganizationSummaryDto>>();
            ViewData["Organization"] = response.DataTransferObject;
            return View ( response.DataTransferObject );
        }

        public async Task<ActionResult> Edit()
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new GetDtoByKeyRequest<OrganizationDto> ());
            AddLookupRequests(requestDispatcher, typeof(OrganizationAddressDto));
            AddLookupRequests(requestDispatcher, typeof(OrganizationPhoneDto));
            AddLookupRequests(requestDispatcher, typeof(AddressDto));
            var response = await requestDispatcher.GetAsync<DtoResponse<OrganizationDto>>();
            AddLookupResponsesToViewData(requestDispatcher);

            return View(response.DataTransferObject);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(string name = null, OrganizationAddressDto organizationAddressDto = null, OrganizationPhoneDto organizationPhoneDto = null)
        {
            if ( name != null )
            {
                var requestDispatcher = CreateAsyncRequestDispatcher ();
                requestDispatcher.Add ( new UpdateOrganizationNameRequest {Name = name} );
                var response = await requestDispatcher.GetAsync<DtoResponse<OrganizationDto>> ();

                //TODO: Handle Errors
                return new JsonResult {Data = new {sucess = true}};
            }
            if ( organizationAddressDto.Address != null )
            {
                var result = await Edit ( organizationAddressDto );
                return result;
            }
            if (organizationPhoneDto.Phone != null)
            {
                var result = await Edit( organizationPhoneDto);
                return result;
            }
            return new JsonResult ();
        }

        private async Task<ActionResult> Edit(OrganizationAddressDto organizationAddressDto)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new AddDtoRequest<OrganizationAddressDto> { DataTransferObject = organizationAddressDto });
            var response = await requestDispatcher.GetAsync<AddDtoResponse<OrganizationAddressDto>>();

            //TODO: Handle Errors
            return new JsonResult { Data = new
                {
                    originalHash = organizationAddressDto.OriginalHash,
                    newHash = response.DataTransferObject.OriginalHash,
                    newIsPrimary = organizationAddressDto.IsPrimary
                } };
        }

        private async Task<ActionResult> Edit(OrganizationPhoneDto organizationPhoneDto)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new AddDtoRequest<OrganizationPhoneDto> { DataTransferObject = organizationPhoneDto });
            var response = await requestDispatcher.GetAsync<AddDtoResponse<OrganizationPhoneDto>>();

            //TODO: Handle Errors
            return new JsonResult
                {
                    Data = new
                        {
                            originalHash = organizationPhoneDto.OriginalHash,
                            newHash = response.DataTransferObject.OriginalHash,
                            newIsPrimary = organizationPhoneDto.IsPrimary
                        }
                };
        }

        [HttpPost]
        public async Task<ActionResult> AddAddress(OrganizationAddressDto organizationAddressDto)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher ();
            requestDispatcher.Add(new AddDtoRequest<OrganizationAddressDto> { DataTransferObject = organizationAddressDto });
            var response = await requestDispatcher.GetAsync<AddDtoResponse<OrganizationAddressDto>>();

            return RedirectToAction ( "Edit" );
        }

        [HttpPost]
        public async Task<ActionResult> AddPhone(OrganizationPhoneDto organizationPhoneDto)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new AddDtoRequest<OrganizationPhoneDto> { DataTransferObject = organizationPhoneDto });
            var response = await requestDispatcher.GetAsync<AddDtoResponse<OrganizationPhoneDto>>();

            return RedirectToAction("Edit");
        }

        #endregion
    }
}