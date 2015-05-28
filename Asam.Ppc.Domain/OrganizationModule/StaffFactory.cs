namespace Asam.Ppc.Domain.OrganizationModule
{
    using Primitives;

    public class StaffFactory : IStaffFactory
    {
        private readonly IStaffRepository _staffRepository;

        public StaffFactory (IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public Staff Create(Organization organization, PersonName name)
        {
            var staff = new Staff(organization, name);
            _staffRepository.MakePersistent ( staff );
            return staff;
        }
    }
}