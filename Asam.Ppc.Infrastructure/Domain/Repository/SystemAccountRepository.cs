namespace Asam.Ppc.Infrastructure.Domain.Repository
{
    #region Using Statements

    using System;
    using System.Linq;
    using Ppc.Domain.SecurityModule;

    #endregion

    public class SystemAccountRepository : NHibernateRepositoryBase<SystemAccount>, ISystemAccountRepository
    {
        #region Constructors and Destructors

        public SystemAccountRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        { }

        #endregion

        #region Public Methods and Operators

        public SystemAccount GetByIdentifier ( string identifier )
        {
            var query = Session.QueryOver<SystemAccount> ()
                               .Where(sa => sa.Identifier == identifier);
            return query.SingleOrDefault ();
        }

        public SystemAccount GetByStaffKey ( long staffKey )
        {
            var query = Session.QueryOver<SystemAccount>()
                               .Where(sa => sa.Staff != null && sa.Staff.Key == staffKey )
                               .JoinQueryOver(s => s.Organization)
                               .Where(o => o.Key == UserContext.OrganizationKey);
            return query.SingleOrDefault();
        }

        #endregion
    }
}