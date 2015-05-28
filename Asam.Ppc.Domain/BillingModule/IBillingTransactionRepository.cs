using Pillar.Domain;

namespace Asam.Ppc.Domain.BillingModule
{
    public interface IBillingTransactionRepository : IRepository<BillingTransaction>
    {
        void Save(BillingTransaction billingTransaction);
    }
}
