namespace Asam.Ppc.Service.Handlers.Security
{
    #region

    using Common;
    using Domain.OrganizationModule;
    using Domain.SecurityModule;
    using Infrastructure;
    using Messages.Security;
    using global::AutoMapper;

    #endregion

    public class CreateRoleRequestHandler : ServiceRequestHandler<CreateRoleRequest, CreateRoleResponse>
    {
        private readonly IRoleFactory _roleFactory;
        private readonly IOrganizationRepository _organizationRepository;

        public CreateRoleRequestHandler ( IRoleFactory roleFactory, IOrganizationRepository organizationRepository)
        {
            _roleFactory = roleFactory;
            _organizationRepository = organizationRepository;
        }

        protected override void Handle(CreateRoleRequest request, CreateRoleResponse response)
        {
            var organization = _organizationRepository.GetByKey ( UserContext.OrganizationKey );
            var role = _roleFactory.Create(organization, request.Name);
            var roleDto = Mapper.Map<Role, RoleDto>(role);
            response.Role = roleDto;
        }
    }
}