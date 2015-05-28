namespace Asam.Ppc.Domain.BillingModule
{
    /// <summary>
    /// 
    /// </summary>
    public class BillingTransactionFactory : IBillingTransactionFactory
    {
        /// <summary>
        /// Creates the specified description.
        /// </summary>
        /// <param name="ehrKey">The ehr key.</param>
        /// <param name="organizationKey">The organization key.</param>
        /// <param name="userEmail">The user email.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public BillingTransaction Create(
            long ehrKey, 
            long organizationKey,
            string userEmail, 
            string userName, 
            string methodName, 
            string parameters)
        {
            var billingTransaction = new BillingTransaction(
                ehrKey, 
                organizationKey, 
                userEmail, 
                userName, 
                methodName, 
                parameters);
            return billingTransaction;
        }
    }
}