using Asam.Ppc.Domain.SecurityModule;

namespace Asam.Ppc.Infrastructure.Domain.Repository
{
    #region Using Statements

    #endregion

    public class ApiSystemAccountRepository : NHibernateRepositoryBase<ApiSystemAccount>, IApiSystemAccountRepository
    {
        #region Constructors and Destructors

        public ApiSystemAccountRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        { }

        #endregion

        #region Public Methods and Operators

        public void Save(ApiSystemAccount apiSystemAccount)
        {
            MakePersistent(apiSystemAccount);
            Session.Flush();
        }

        public ApiSystemAccount GetByApiCombinationKey(ApiSystemAccount apiSystemAccount)
        {
            var query = Session.QueryOver<ApiSystemAccount>()
                .Where(sa => sa.EhrId == apiSystemAccount.EhrId)
                .Where(sa => sa.OrganizationKey == apiSystemAccount.OrganizationKey)
                .Where(sa => sa.UserId == apiSystemAccount.UserId)
                .Where(sa => sa.UserName == apiSystemAccount.UserName);
            return query.SingleOrDefault();
        }

        #endregion
    }
}