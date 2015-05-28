namespace Asam.Ppc.Service.Handlers.Security
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using Common;
    using Domain.SecurityModule;
    using Infrastructure;
    using Infrastructure.Services;
    using Messages.Security;

    #endregion

    public class ChangePasswordRequestHandler : ServiceRequestHandler<ChangePasswordRequest, ChangePasswordResponse>
    {
        private readonly ISystemAccountRepository _systemAccountRepository;
        private readonly ISystemAccountIdentityServiceManager _systemAccountIdentityServiceManager;

        public ChangePasswordRequestHandler(ISystemAccountRepository systemAccountRepository, ISystemAccountIdentityServiceManager systemAccountIdentityServiceManager)
        {
            _systemAccountRepository = systemAccountRepository;
            _systemAccountIdentityServiceManager = systemAccountIdentityServiceManager;
        }

        protected override void Handle(ChangePasswordRequest request, ChangePasswordResponse response)
        {
            var systemAccount = _systemAccountRepository.GetByKey(UserContext.SystemAccountKey);
            if (systemAccount != null)
            {
                var identityServiceResponse = _systemAccountIdentityServiceManager.ChangePassword ( systemAccount.Identifier, request.OldPassword, request.NewPassword );
                if ( identityServiceResponse.Sucess )
                {
                    response.ResultCode = "Succeed";
                }
                else
                {
                    response.ResultCode = "InvalidCredentials";
                }
            }
        }
    }
}