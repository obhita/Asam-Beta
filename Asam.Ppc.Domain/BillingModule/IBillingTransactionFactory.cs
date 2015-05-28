namespace Asam.Ppc.Domain.BillingModule
{
    public interface IBillingTransactionFactory
    {
        BillingTransaction Create(long ehrKey, long organizationKey, string userEmail, string userName, string methodName, string parameters);
    }
}
