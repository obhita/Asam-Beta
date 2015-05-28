namespace Asam.Ppc.Mvc4.Controllers
{
    #region

    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Resources;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Agatha.Common;
    using Infrastructure;
    using Models;
    using Mvc.Infrastructure.Security;
    using NLog;
    using Newtonsoft.Json.Linq;
    using Primitives;
    using Service.Messages.Common;
    using Service.Messages.Organization;
    using Service.Messages.Security;
    
    #endregion

    public class StaffController : BaseController
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public StaffController(IRequestDispatcherFactory requestDispatcherFactory, IPatientAccessControlManager patientAccessControlManager)
            : base(requestDispatcherFactory, patientAccessControlManager)
        {
        }

        public ActionResult Create()
        {
            return View ();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PersonName name)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new CreateStaffRequest
                {
                    Name = name,
                });
            var response = await requestDispatcher.GetAsync<GetStaffDtoResponse>();
            return RedirectToAction("Edit", new { id = response.DataTransferObject.Key});
        }

        public async Task<ActionResult> Edit(long id)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new GetStaffDtoByKeyRequest { Key = id });
            requestDispatcher.Add(new GetAvailableRolesRequest { Key = id });
            var response = await requestDispatcher.GetAsync<GetStaffDtoResponse>();

            if (response.DataTransferObject == null)
            {
                throw new HttpException(404, "Staff record not found.");
            }
            SetupAvailableRoles(requestDispatcher);
            ViewData.TemplateInfo.HtmlFieldPrefix = "staffDto" ;
            return View(response.DataTransferObject);
        }

        private void SetupAvailableRoles(Mvc.Infrastructure.Service.IAsyncRequestDispatcher requestDispacther)
        {
            var response = requestDispacther.Get<GetAvailableRolesResponse>();
            if ( response.Roles != null )
            {
                ViewData["AvailableRoles"] =
                    response.Roles.Select ( ( r => new SelectListItem {Selected = false, Text = r.Name, Value = r.Key.ToString ()} ) ).OrderBy ( s => s.Text ).ToList ();
            }
            else
            {
                ViewData["AvailableRoles"] = Enumerable.Empty<SelectListItem> ().ToList ();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(long id, StaffDto staffDto)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add ( new SaveDtoRequest<StaffDto> { DataTransferObject = staffDto } );
            var response = await requestDispatcher.GetAsync<DtoResponse<StaffDto>>();
            return RedirectToAction("Edit", new { id });
        }

        private string ValidateSystemAccount(SystemAccountDto systemAccount)
        {
            var msgBuilder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(systemAccount.Identifier))
            {
                msgBuilder.Append("Identifier is required. ");
            }
            if (string.IsNullOrWhiteSpace(systemAccount.Email))
            {
                msgBuilder.Append("Email is required.");
            }
            return msgBuilder.ToString();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccount(long id, SystemAccountDto systemAccount)
        {
            systemAccount.Identifier = systemAccount.Email;
            systemAccount.CreateNew = true;
            var validationMsg = ValidateSystemAccount(systemAccount);
            if (validationMsg != string.Empty)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, validationMsg);
            }

            var requestDispatcher = CreateAsyncRequestDispatcher();

            //var federationAuthenticationModule = FederatedAuthentication.WSFederationAuthenticationModule ?? new WSFederationAuthenticationModule();
            requestDispatcher.Add(new AssignAccountRequest
                {
                    StaffKey = id,
                    SystemAccountDto = systemAccount
                });
            //requestDispatcher.Add(new GetAvailableRolesRequest { Key = id });
            var response = await requestDispatcher.GetAsync<AssignAccountResponse>();
            //SetupAvailableRoles(requestDispatcher);
            if (response.SystemAccountDto.DataErrorInfoCollection.Any())
            {
                var msg = response.SystemAccountDto.DataErrorInfoCollection.FirstOrDefault().Message;
                Logger.Error(msg);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, msg);
            }
            return RedirectToAction("Edit", new { id });
        }

        [HttpPost]
        public async Task<ActionResult> LinkAccount(long id, SystemAccountDto systemAccount)
        {
            systemAccount.Identifier = systemAccount.Email;
            systemAccount.CreateNew = false;
            var validationMsg = ValidateSystemAccount(systemAccount);
            if (validationMsg != string.Empty)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, validationMsg);
            }

            var requestDispacther = CreateAsyncRequestDispatcher();
            requestDispacther.Add(new AssignAccountRequest
                {
                    StaffKey = id,
                    SystemAccountDto = systemAccount
                });
            var response = await requestDispacther.GetAsync<AssignAccountResponse>();

            if (response.SystemAccountDto.DataErrorInfoCollection.Any())
            {
                var msg = response.SystemAccountDto.DataErrorInfoCollection.FirstOrDefault().Message;
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, msg);
            }
            return PartialView("EditorTemplates/SystemAccountDto", response.SystemAccountDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddRoles(long id, long[] roleKeys)
        {
            if (roleKeys != null)
            {
                var requestDisplacther = CreateAsyncRequestDispatcher();
                requestDisplacther.Add(new AssignRolesRequest
                    {
                        SystemAccoutnKey = id,
                        AddRoles = true,
                        Roles = roleKeys,
                    });
                var response = await requestDisplacther.GetAsync<AssignRolesResponse>();
            }
            return new JsonResult
                {
                    Data = new {}
                };
        }

        [HttpPost]
        public async Task<ActionResult> RemoveRoles(long id, long[] roleKeys)
        {
            if (roleKeys != null)
            {
                var requestDisplacther = CreateAsyncRequestDispatcher();
                requestDisplacther.Add(new AssignRolesRequest
                    {
                        SystemAccoutnKey = id,
                        AddRoles = false,
                        Roles = roleKeys,
                    });
                var response = await requestDisplacther.GetAsync<AssignRolesResponse>();
            }
            return new JsonResult
                {
                    Data = new {}
                };
        }

        // For testing only
        public string GetUser(string username, string admin, string adminPassword)
        {
            // Note: using JwtTokenContext instead of the following code if not for testing
            var baseAddress = new Uri(IdentityServerUtil.BaseAddress);
            var token = string.Empty;
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                try
                {
                    httpClient.SetBasicAuthentication(admin, adminPassword);

                    var response = httpClient.GetAsync("issue/simple?realm=" + baseAddress + "api/&tokenType=jwt").Result;
                    response.EnsureSuccessStatusCode();

                    var tokenResponse = response.Content.ReadAsStringAsync().Result;
                    var json = JObject.Parse(tokenResponse);
                    token = json["access_token"].ToString();
                    Logger.Debug("token: {0}", token);
                    var expiresIn = int.Parse(json["expires_in"].ToString());
                    var expiration = DateTime.UtcNow.AddSeconds(expiresIn);
                }
                catch (Exception ex)
                {
                    Logger.Error("Cannot generate JWT token: {0}", ex.Message);
                    if (ex.InnerException != null)
                    {
                        Logger.Error(ex.InnerException);
                    }
                }
            }
            var membershipUserDto = CallService(baseAddress, token, "api/membership/get/leo.smith");
            return membershipUserDto;
        }

        public async Task<ActionResult> ResetPassword(long id, long staffkey)
        {
            var requestDisplacther = CreateAsyncRequestDispatcher();
            requestDisplacther.Add(new ResetPasswordRequest()
            {
                SystemAccountKey = id
            });
            var response = await requestDisplacther.GetAsync<ResetPasswordResponse>();
            if ( response.ResponseCode == ResetPasswordResponseCode.Success )
            {
                return RedirectToAction ( "Edit", new {id = staffkey} );
            }
            return new HttpStatusCodeResult ( HttpStatusCode.InternalServerError, "Error resetting password: " + response.ResponseCode );
        }

        private static string CallService(Uri baseAddress, string token, string path)
        {
            try
            {
                using (var httpClient = new HttpClient() {BaseAddress = baseAddress})
                {
                    httpClient.SetToken("Session", token);
                    Logger.Debug("token: {0}", token);

                    var response = httpClient.GetAsync(path).Result;
                    response.EnsureSuccessStatusCode();
                    var result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Cannot call service with session token: {0}", ex.ToString());
                if (ex.InnerException != null)
                {
                    Logger.Error(ex.InnerException );
                }
                return null;
            }
        }

        private static T CallService<T>(Uri baseAddress, string token, string path)
        {
            using (var httpClient = new HttpClient() { BaseAddress = baseAddress })
            {
                httpClient.SetToken("Session", token);

                var response = httpClient.GetAsync(path).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsAsync<T>().Result;
            }
        }
    }
}