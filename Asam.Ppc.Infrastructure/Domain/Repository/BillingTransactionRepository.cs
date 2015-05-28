using Asam.Ppc.Domain.AssessmentModule;
using Asam.Ppc.Domain.BillingModule;

namespace Asam.Ppc.Infrastructure.Domain.Repository
{
    #region Using Statements

    #endregion

    /// <summary>
    ///     BillingTransaction repository.
    /// </summary>
    public class BillingTransactionRepository : NHibernateRepositoryBase<BillingTransaction>, IBillingTransactionRepository
    {
        #region Constructors and Destructors

        public BillingTransactionRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        { }

        #endregion

        public void Save(BillingTransaction billingTransaction)
        {
            MakePersistent(billingTransaction);
            Session.Flush();
        }
    }
}