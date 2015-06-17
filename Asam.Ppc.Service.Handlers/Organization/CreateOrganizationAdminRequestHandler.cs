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

namespace Asam.Ppc.Service.Handlers.Organization
{
    using Common;
    using Domain.OrganizationModule;
    using Domain.SecurityModule;
    using Infrastructure.Permission;
    using Infrastructure.Services;
    using Messages.Common;
    using Messages.Organization;
    using Messages.Security;
    using Pillar.Domain.Primitives;
    using global::AutoMapper;

    public class CreateOrganizationAdminRequestHandler : ServiceRequestHandler<CreateOrganizationAdminRequest, CreateOrganizationAdminResponse> 
    {
        private readonly ISystemAccountRepository _systemAccountRepository;
        private readonly IRoleFactory _roleFactory;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ISystemAccountFactory _systemAccountFactory;
        private readonly ISystemAccountIdentityServiceManager _systemAccountIdentityServiceManager;

        public CreateOrganizationAdminRequestHandler ( ISystemAccountRepository systemAccountRepository,
                                                       IRoleFactory roleFactory,
                                                       IOrganizationRepository organizationRepository,
                                                       ISystemAccountFactory systemAccountFactory,
                                                       ISystemAccountIdentityServiceManager systemAccountIdentityServiceManager )
        {
            _systemAccountRepository = systemAccountRepository;
            _roleFactory = roleFactory;
            _organizationRepository = organizationRepository;
            _systemAccountFactory = systemAccountFactory;
            _systemAccountIdentityServiceManager = systemAccountIdentityServiceManager;
        }

        protected override void Handle(CreateOrganizationAdminRequest request, CreateOrganizationAdminResponse response)
        {
            var systemAccount = _systemAccountRepository.GetByIdentifier(request.Email);
            var organization = _organizationRepository.GetByKey(request.OrganizationKey);
            if ( systemAccount == null )
            {
                var identityServiceResponse = _systemAccountIdentityServiceManager.Create ( request.Username, request.Email );
                if ( identityServiceResponse.Sucess )
                {
                    systemAccount = _systemAccountFactory.Create(organization, request.Email, new Email(request.Email));
                    var systemAccountDto = Mapper.Map<SystemAccount, SystemAccountDto>(systemAccount);
                    response.SystemAccountDto = systemAccountDto;

                    var role = _roleFactory.Create(organization, "Default Organization Admin");
                    role.AddPermision(BasicAccessPermission.AccessUserInterfacePermission);
                    role.AddPermision(OrganizationPermission.OrganizationViewPermission);
                    role.AddPermision(OrganizationPermission.OrganizationEditPermission);
                    role.AddPermision(StaffPermission.StaffAddRolePermission);
                    role.AddPermision(StaffPermission.StaffCreateAccountPermission);
                    role.AddPermision(StaffPermission.StaffEditPermission);
                    role.AddPermision(StaffPermission.StaffLinkAccountPermission);
                    role.AddPermision(StaffPermission.StaffRemoveRolePermission);
                    role.AddPermision(StaffPermission.StaffViewPermission);
                    role.AddPermision(RolePermission.RoleAddPermissionPermission);
                    role.AddPermision(RolePermission.RoleEditPermission);
                    role.AddPermision(RolePermission.RoleRemovePermissionPermission);
                    role.AddPermision(RolePermission.RoleViewPermission);
                    role.AddPermision(PatientPermission.PatientEditPermission);
                    role.AddPermision(PatientPermission.PatientViewPermission);
                    role.AddPermision(AssessmentPermission.AssessmentEditPermission);
                    role.AddPermision(AssessmentPermission.AssessmentViewPermission);
                    role.AddPermision(StaffPermission.ResetPasswordPermission);
                    systemAccount.AddRole(role);
                }
                else
                {
                    var result = identityServiceResponse.ErrorMessage;
                    var dataErrorInfo = new DataErrorInfo(result, ErrorLevel.Error);
                    response.SystemAccountDto = new SystemAccountDto();
                    response.SystemAccountDto.AddDataErrorInfo(dataErrorInfo);
                }
            }
            else
            {
                _systemAccountIdentityServiceManager.ResetPassword ( systemAccount.Email.Address );
            }
        }
    }
}