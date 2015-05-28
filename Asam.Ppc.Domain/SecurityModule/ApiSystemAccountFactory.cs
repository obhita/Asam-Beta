namespace Asam.Ppc.Domain.SecurityModule
{
    using OrganizationModule;
    using Pillar.Domain.Primitives;

    public class ApiSystemAccountFactory : IApiSystemAccountFactory
    {
        private readonly IApiSystemAccountRepository _apiSystemAccountRepository;

        public ApiSystemAccountFactory(IApiSystemAccountRepository apiSystemAccountRepository)
        {
            _apiSystemAccountRepository = apiSystemAccountRepository;
        }

        public ApiSystemAccount Create(int ehrId, Organization organization, string userId, string userName, string identifier, Email email)
        {
            var apiSystemAccount = new ApiSystemAccount(ehrId, organization, userId, userName, identifier, email);
            _apiSystemAccountRepository.MakePersistent(apiSystemAccount);
            return apiSystemAccount;
        }
    }
}