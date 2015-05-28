namespace Asam.Ppc.Service.Handlers.Security
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using Common;
    using Domain.OrganizationModule;
    using Domain.SecurityModule;
    using Infrastructure;
    using Infrastructure.Services;
    using Messages.Common;
    using Messages.Security;
    using NLog;
    using Pillar.Domain.Primitives;
    using global::AutoMapper;

    public class AssignAccountRequestHandler: ServiceRequestHandler<AssignAccountRequest, AssignAccountResponse>
    {
        protected readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly ISystemAccountRepository _systemAccountRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ISystemAccountFactory _systemAccountFactory;
        private readonly ISystemAccountIdentityServiceManager _systemAccountIdentityServiceManager;

        public AssignAccountRequestHandler ( ISystemAccountRepository systemAccountRepository,
                                             IStaffRepository staffRepository,
                                             IOrganizationRepository organizationRepository,
                                             ISystemAccountFactory systemAccountFactory,
                                             ISystemAccountIdentityServiceManager systemAccountIdentityServiceManager)
        {
            _systemAccountRepository = systemAccountRepository;
            _staffRepository = staffRepository;
            _organizationRepository = organizationRepository;
            _systemAccountFactory = systemAccountFactory;
            _systemAccountIdentityServiceManager = systemAccountIdentityServiceManager;
        }

        protected override void Handle(AssignAccountRequest request, AssignAccountResponse response)
        {
            if (request.SystemAccountDto.CreateNew)
            {
                var systemAccount = _systemAccountRepository.GetByIdentifier(request.SystemAccountDto.Identifier);
                var staff = _staffRepository.GetByKey(request.StaffKey);
                if (systemAccount != null) // account existing
                {
                    var dataErrorInfo = new DataErrorInfo(string.Format("Cannot create account because an account with the email {0} already exists.", request.SystemAccountDto.Identifier), ErrorLevel.Error);
                    response.SystemAccountDto = request.SystemAccountDto;
                    response.SystemAccountDto.AddDataErrorInfo(dataErrorInfo);
                }
                else
                {
                    // 1. create member login in Identity server
                    // 2. Create System account in domain
                    // 3. assign system account to the new staff
                    // 4. error handling: if the login/account is taken or cannot create new login
                    if ( staff != null )
                    {
                        var identityServerResponse = _systemAccountIdentityServiceManager.Create ( request.SystemAccountDto.Username, request.SystemAccountDto.Email );
                        if ( identityServerResponse.Sucess )
                        {
                            var organization = _organizationRepository.GetByKey(UserContext.OrganizationKey);
                            systemAccount = _systemAccountFactory.Create(organization,
                                                                          request.SystemAccountDto.Email,
                                                                          new Email(request.SystemAccountDto.Email));
                            systemAccount.AssignToStaff(staff);
                            var systemAccountDto = Mapper.Map<SystemAccount, SystemAccountDto>(systemAccount);
                            response.SystemAccountDto = systemAccountDto;
                        }
                        else
                        {
                            var result = identityServerResponse.ErrorMessage;
                            var dataErrorInfo = new DataErrorInfo(result, ErrorLevel.Error);
                            response.SystemAccountDto = request.SystemAccountDto;
                            response.SystemAccountDto.AddDataErrorInfo(dataErrorInfo);
                        }
                    }
                    else
                    {
                        Logger.Error(string.Format("Tried assigning invalid staff {0} to systemaccount {1}", request.StaffKey, systemAccount.Key));
                        response.SystemAccountDto.AddDataErrorInfo ( new DataErrorInfo ( "Invalid staff key.", ErrorLevel.Error ) );
                    }
                }
            }
            else
            {
                var systemAccount = _systemAccountRepository.GetByIdentifier(request.SystemAccountDto.Identifier);
                var staff = _staffRepository.GetByKey(request.StaffKey);
                if (systemAccount != null) // account existing
                {
                    if (systemAccount.Staff == null)
                    {
                        systemAccount.AssignToStaff(staff);
                        var systemAccountDto = Mapper.Map<SystemAccount, SystemAccountDto>(systemAccount);
                        response.SystemAccountDto = systemAccountDto;
                    }
                    else
                    {
                        var dataErrorInfo = new DataErrorInfo(string.Format("Cannot link account because an account with the email {0} has been assigned to another staff.", request.SystemAccountDto.Identifier), ErrorLevel.Error);
                        response.SystemAccountDto = request.SystemAccountDto;
                        response.SystemAccountDto.AddDataErrorInfo(dataErrorInfo);
                    }
                }
                else
                {
                    var dataErrorInfo = new DataErrorInfo(string.Format("Cannot link account because an account with the email {0} does not exist.", request.SystemAccountDto.Identifier), ErrorLevel.Error);
                    response.SystemAccountDto = request.SystemAccountDto;
                    response.SystemAccountDto.AddDataErrorInfo(dataErrorInfo);
                }
            }
        }
    }
}