namespace Asam.Ppc.Domain.SecurityModule
{
    using OrganizationModule;
    using Pillar.Domain.Primitives;

    public interface ISystemAccountFactory
    {
        SystemAccount Create(Organization organization, string identifier, Email email);
        SystemAccount CreateSystemAdmin ( string identifier, Email email );
    }
}