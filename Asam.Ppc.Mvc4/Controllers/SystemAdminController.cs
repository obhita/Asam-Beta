#region License Header
// /*******************************************************************************
//  * Open Behavioral Health Information Technology Architecture (OBHITA.org)
//  * 
//  * Redistribution and use in source and binary forms, with or without
//  * modification, are permitted provided that the following conditions are met:
//  *     * Redistributions of source code must retain the above copyright
//  *       notice, this list of conditions and the following disclaimer.
//  *     * Redistributions in binary form must reproduce the above copyright
//  *       notice, this list of conditions and the following disclaimer in the
//  *       documentation and/or other materials provided with the distribution.
//  *     * Neither the name of the <organization> nor the
//  *       names of its contributors may be used to endorse or promote products
//  *       derived from this software without specific prior written permission.
//  * 
//  * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
//  * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
//  * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
//  * DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
//  * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
//  * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
//  * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
//  * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
//  * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
//  * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//  ******************************************************************************/
#endregion
namespace Asam.Ppc.Mvc4.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Agatha.Common;
    using Service.Messages.Organization;
    using Mvc.Infrastructure.Security;
    using NLog;
    using Service.Messages.Common;
    using Service.Messages.Security;

    public class SystemAdminController : BaseController
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public SystemAdminController ( IRequestDispatcherFactory requestDispatcherFactory, IPatientAccessControlManager patientAccessControlManager  )
            : base ( requestDispatcherFactory, patientAccessControlManager )
        {
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }

        public ActionResult CreateOrganization ()
        {
            return View ();
        }

        [HttpGet]
        public async Task<ActionResult> EditOrganization(long id)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new GetDtoByKeyRequest<OrganizationDto> { Key = id });
            AddLookupRequests(requestDispatcher, typeof(OrganizationAddressDto));
            AddLookupRequests(requestDispatcher, typeof(OrganizationPhoneDto));
            AddLookupRequests(requestDispatcher, typeof(AddressDto));
            var response = await requestDispatcher.GetAsync<DtoResponse<OrganizationDto>>();
            AddLookupResponsesToViewData(requestDispatcher);

            if ( response.DataTransferObject == null )
            {
                return new HttpUnauthorizedResult ();
            }

            return View(response.DataTransferObject);
        }

        [HttpPost]
        public async Task<ActionResult> EditOrganization(long id, string name = null, OrganizationAddressDto organizationAddressDto = null, OrganizationPhoneDto organizationPhoneDto = null)
        {
            if (name != null)
            {
                var requestDispatcher = CreateAsyncRequestDispatcher();
                requestDispatcher.Add(new UpdateOrganizationNameRequest { Key = id, Name = name });
                var response = await requestDispatcher.GetAsync<DtoResponse<OrganizationDto>>();
                if (response.DataTransferObject.DataErrorInfoCollection.Any())
                {
                    var msg = response.DataTransferObject.DataErrorInfoCollection.FirstOrDefault().Message;
                    Logger.Error(msg);
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, msg);
                }
            }
            if (organizationAddressDto.Address != null)
            {
                var response = await EditAddress(id, organizationAddressDto);
                if ( response != null )
                {
                    return response;
                }
            }
            if (organizationPhoneDto.Phone != null)
            {
                var response = await EditPhone(id, organizationPhoneDto);
                if (response != null)
                {
                    return response;
                }
            }

            return RedirectToAction("EditOrganization", new { id });
        }

        private async Task<ActionResult> EditAddress(long id, OrganizationAddressDto organizationAddressDto)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new AddDtoRequest<OrganizationAddressDto> { AggregateKey = id, DataTransferObject = organizationAddressDto });
            var response = await requestDispatcher.GetAsync<AddDtoResponse<OrganizationAddressDto>>();

            if (response.DataTransferObject.DataErrorInfoCollection.Any())
            {
                var msg = response.DataTransferObject.DataErrorInfoCollection.FirstOrDefault().Message;
                Logger.Error(msg);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, msg);
            }
            return null;
        }

        private async Task<ActionResult> EditPhone(long id, OrganizationPhoneDto organizationPhoneDto)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new AddDtoRequest<OrganizationPhoneDto> { AggregateKey = id, DataTransferObject = organizationPhoneDto });
            var response = await requestDispatcher.GetAsync<AddDtoResponse<OrganizationPhoneDto>>();

            if (response.DataTransferObject.DataErrorInfoCollection.Any())
            {
                var msg = response.DataTransferObject.DataErrorInfoCollection.FirstOrDefault().Message;
                Logger.Error(msg);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, msg);
            }
            return null;
        }

        [HttpPost]
        public async Task<ActionResult> AddAddress(long id, OrganizationAddressDto organizationAddressDto)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new AddDtoRequest<OrganizationAddressDto> { AggregateKey = id, DataTransferObject = organizationAddressDto });
            AddLookupRequests(requestDispatcher, typeof(OrganizationAddressDto));
            AddLookupRequests(requestDispatcher, typeof(AddressDto));
            var response = await requestDispatcher.GetAsync<AddDtoResponse<OrganizationAddressDto>>();
            AddLookupResponsesToViewData(requestDispatcher);

            if (response.DataTransferObject.DataErrorInfoCollection.Any())
            {
                var msg = response.DataTransferObject.DataErrorInfoCollection.FirstOrDefault().Message;
                Logger.Error(msg);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, msg);
            }
            return RedirectToAction("EditOrganization", new { id });
        }

        [HttpPost]
        public async Task<ActionResult> AddPhone(long id, OrganizationPhoneDto organizationPhoneDto)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new AddDtoRequest<OrganizationPhoneDto> { AggregateKey = id, DataTransferObject = organizationPhoneDto });
            AddLookupRequests(requestDispatcher, typeof(OrganizationPhoneDto));
            var response = await requestDispatcher.GetAsync<AddDtoResponse<OrganizationPhoneDto>>();
            AddLookupResponsesToViewData(requestDispatcher);

            if (response.DataTransferObject.DataErrorInfoCollection.Any())
            {
                var msg = response.DataTransferObject.DataErrorInfoCollection.FirstOrDefault().Message;
                Logger.Error(msg);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, msg);
            }
            return RedirectToAction("EditOrganization", new { id });
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrganizationAdmin(long id, string username, string email)
        {
            var requestDispacther = CreateAsyncRequestDispatcher();

            requestDispacther.Add(new CreateOrganizationAdminRequest
            {
                OrganizationKey = id,
                Username = username,
                Email = email
            });
            var response = await requestDispacther.GetAsync<CreateOrganizationAdminResponse>();

            if (response == null || response.SystemAccountDto == null)
            {
                var msg = "Error getting response.";
                Logger.Error(msg);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, msg);
            }

            if (response.SystemAccountDto.DataErrorInfoCollection != null && response.SystemAccountDto.DataErrorInfoCollection.Any())
            {
                var msg = response.SystemAccountDto.DataErrorInfoCollection.FirstOrDefault().Message;
                Logger.Error(msg);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, msg);
            }

            return RedirectToAction("EditOrganization", new { id });
        }

        public ActionResult CreateSystemAdminAccount ()
        {
            return View ();
        }

        [HttpPost]
        public async Task<ActionResult> CreateSystemAdminAccount(string username, string email)
        {
            var requestDispacther = CreateAsyncRequestDispatcher();

            requestDispacther.Add(new CreateSystemAdminRequest
            {
                Username = username,
                Email = email
            });
            var response = await requestDispacther.GetAsync<DtoResponse<SystemAccountDto>>();

            if (response.DataTransferObject.DataErrorInfoCollection.Any())
            {
                var msg = response.DataTransferObject.DataErrorInfoCollection.FirstOrDefault().Message;
                Logger.Error(msg);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, msg);
            }
            return RedirectToAction ( "Index" );
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrganization(string name)
        {
            var requestDispacther = CreateAsyncRequestDispatcher();

            requestDispacther.Add(new CreateOrganizationRequest
            {
                Name = name
            });
            var response = await requestDispacther.GetAsync<DtoResponse<OrganizationSummaryDto>>();

            if (response.DataTransferObject.DataErrorInfoCollection.Any())
            {
                var msg = response.DataTransferObject.DataErrorInfoCollection.FirstOrDefault().Message;
                Logger.Error(msg);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, msg);
            }
            return RedirectToAction("EditOrganization", new { id = response.DataTransferObject.Key });
        }
    }
}