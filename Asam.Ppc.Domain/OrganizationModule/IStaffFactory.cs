namespace Asam.Ppc.Domain.OrganizationModule
{
    using Primitives;

    public interface IStaffFactory
    {
        Staff Create(Organization organization, PersonName name);
    }
}