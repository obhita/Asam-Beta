namespace Asam.Ppc.Domain.OrganizationModule
{
    public class OrganizationFactory : IOrganizationFactory
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationFactory (IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public Organization Create ( string name )
        {
            var organization = new Organization ( name );
            _organizationRepository.MakePersistent(organization);
            return organization;
        }
    }
}
