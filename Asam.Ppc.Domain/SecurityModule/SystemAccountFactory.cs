namespace Asam.Ppc.Domain.SecurityModule
{
    using OrganizationModule;
    using Pillar.Domain.Primitives;

    public class SystemAccountFactory : ISystemAccountFactory
    {
        private readonly ISystemAccountRepository _systemAccountRepository;

        public SystemAccountFactory (ISystemAccountRepository systemAccountRepository)
        {
            _systemAccountRepository = systemAccountRepository;
        }

        public SystemAccount Create(Organization organization, string identifier, Email email)
        {
            var systemAccount = new SystemAccount(organization, identifier, email);
            _systemAccountRepository.MakePersistent ( systemAccount );
            return systemAccount;
        }

        public SystemAccount CreateSystemAdmin(string identifier, Email email)
        {
            var systemAccount = new SystemAccount(identifier, email);
            _systemAccountRepository.MakePersistent(systemAccount);
            return systemAccount;
        }
    }
}