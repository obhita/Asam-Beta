namespace Asam.Ppc.Domain.SecurityModule
{
    using Pillar.Domain;

    #region Using Statements

    

    #endregion

    /// <summary>
    /// Interface for system account repository.
    /// </summary>
    public interface IApiSystemAccountRepository : IRepository<ApiSystemAccount>
    {
        #region Public Methods and Operators

        void Save(ApiSystemAccount apiSystemAccount);

        /// <summary>
        /// Gets the by Api Combination Key.
        /// </summary>
        /// <param name="apiSystemAccount"></param>
        /// <returns></returns>
        ApiSystemAccount GetByApiCombinationKey(ApiSystemAccount apiSystemAccount);

        #endregion
    }
}