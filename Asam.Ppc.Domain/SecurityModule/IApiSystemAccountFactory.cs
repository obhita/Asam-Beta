namespace Asam.Ppc.Domain.SecurityModule
{
    using OrganizationModule;
    using Pillar.Domain.Primitives;

    public interface IApiSystemAccountFactory
    {
        ApiSystemAccount Create(int ehrId, Organization organization, string userId, string userName, string identifier, Email email);
    }
}