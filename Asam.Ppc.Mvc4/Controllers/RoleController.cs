namespace Asam.Ppc.Mvc4.Controllers
{
    #region

    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Agatha.Common;
    using Mvc.Infrastructure.Security;
    using Resources;
    using Service.Messages.Common;
    using Service.Messages.Security;

    #endregion

    public class RoleController : BaseController
    {

        public RoleController(IRequestDispatcherFactory requestDispatcherFactory, IPatientAccessControlManager patientAccessControlManager) 
            : base(requestDispatcherFactory,patientAccessControlManager)
        {
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RoleDto role)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new CreateRoleRequest
                {
                    Name = role.Name,
                });
            var response = await requestDispatcher.GetAsync<CreateRoleResponse>();
            return RedirectToAction("Edit", new { id = response.Role.Key });
        }

        public async Task<PartialViewResult> Edit(long id)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new GetRoleDtoByKeyRequest { Key = id });
            requestDispatcher.Add(new GetAvailablePermissionsRequest { Key = id });
            var response = await requestDispatcher.GetAsync<DtoResponse<RoleDto>>();

            if (response.DataTransferObject == null)
            {
                throw new HttpException(404, "Role record not found.");
            }
            SetupAvailablePermssions(requestDispatcher);
            return PartialView(response.DataTransferObject);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(long id, string name)
        {
            var requestDispatcher = CreateAsyncRequestDispatcher();
            requestDispatcher.Add(new UpdateRoleRequest { Key = id, Name = name });
            var response = await requestDispatcher.GetAsync<DtoResponse<RoleDto>>();
            return RedirectToAction("Edit", new { id = response.DataTransferObject.Key });
        }

        [HttpPost]
        public async Task<ActionResult> AddPermissions(long id, string[] permissions)
        {
            if (permissions != null)
            {
                var requestDispatcher = CreateAsyncRequestDispatcher();
                requestDispatcher.Add(new AssignPermissionRequest { Key = id, Add = true, Permissions = permissions });
                var response = await requestDispatcher.GetAsync<AssignPermissionResponse>();
            }
            return new JsonResult
                {
                    Data = new {}
                };
        }

        [HttpPost]
        public async Task<ActionResult> RemovePermissions(long id, string[] permissions)
        {
            if (permissions != null)
            {
                var requestDispatcher = CreateAsyncRequestDispatcher();
                requestDispatcher.Add(new AssignPermissionRequest { Key = id, Add = false, Permissions = permissions });
                var response = await requestDispatcher.GetAsync<AssignPermissionResponse>();
            }
            return new JsonResult
                {
                    Data = new {}
                };
        }


        private void SetupAvailablePermssions(Mvc.Infrastructure.Service.IAsyncRequestDispatcher requestDispatcher)
        {
            var response = requestDispatcher.Get<GetAvailablePermissionsResponse>();
            if ( response.Permissions == null || response.Permissions.Count () == 0 )
            {
                ViewData["AvailablePermissions"] = new List<SelectListItem> ();
            }
            else
            {
                ViewData["AvailablePermissions"] = response.Permissions.Select ( r =>
                                                                                 new SelectListItem
                                                                                     {
                                                                                         Selected = false,
                                                                                         Text = Permissions.ResourceManager.GetString ( r.Replace ( '/', '_' ) ),
                                                                                         Value = r
                                                                                     } ).OrderBy ( s => s.Text ).ToList ();
            }
        }
    }
}