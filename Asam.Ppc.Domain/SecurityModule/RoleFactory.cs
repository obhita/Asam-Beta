namespace Asam.Ppc.Domain.SecurityModule
{
    using OrganizationModule;

    public class RoleFactory : IRoleFactory
    {
        private readonly IRoleRepository _roleRepository;

        public RoleFactory (IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Role Create(Organization organization, string name, RoleType roleType = RoleType.UserDefined)
        {
            var role = new Role(organization, name, roleType);
            _roleRepository.MakePersistent ( role );
            return role;
        }
    }
}