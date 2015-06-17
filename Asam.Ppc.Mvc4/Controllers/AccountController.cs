namespace Asam.Ppc.Mvc4.Controllers
{
    using System.Net;
    using System.Resources;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Agatha.Common;
    using Models;
    using Mvc.Infrastructure.Security;
    using Resources;
    using Service.Messages.Security;

    public class AccountController : BaseController
    {
        private readonly ILogoutService _logoutService;

        public AccountController(IRequestDispatcherFactory requestDispatcherFactory, IPatientAccessControlManager patientAccessControlManager, ILogoutService logoutService)
            : base(requestDispatcherFactory, patientAccessControlManager)
        {
            _logoutService = logoutService;
        }

        public ActionResult Logout()
        {
            var signoutMessage = _logoutService.Logout();

            return Redirect(signoutMessage.WriteQueryString());
        }

        [HttpPost]
        public async Task<ActionResult> ChangPassword(ChangePasswordViewModel changePasswordViewModel)
        {
            var requestDisplacther = CreateAsyncRequestDispatcher();
            requestDisplacther.Add(new ChangePasswordRequest
            {
                OldPassword = changePasswordViewModel.OldPassword,
                NewPassword = changePasswordViewModel.NewPassword
            });
            var response = await requestDisplacther.GetAsync<ChangePasswordResponse>();

            var resourceManager = UserControlResources.ResourceManager;
            if (response.ResultCode == "Succeed")
            {
                return RedirectToAction ( "Index", "Home" );
            }
            return new HttpStatusCodeResult ( HttpStatusCode.BadRequest, resourceManager.GetString ( response.ResultCode ) );
        }

        
        public ActionResult ChangPassword ( )
        {
            return View ( new ChangePasswordViewModel () );
        }
    }
}