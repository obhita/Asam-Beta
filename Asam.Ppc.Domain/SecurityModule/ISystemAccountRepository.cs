namespace Asam.Ppc.Domain.SecurityModule
{
    using Pillar.Domain;

    #region Using Statements

    

    #endregion

    /// <summary>
    /// Interface for system account repository.
    /// </summary>
    public interface ISystemAccountRepository : IRepository<SystemAccount>
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns></returns>
        SystemAccount GetByIdentifier(string identifier);

        /// <summary>
        /// Gets the by staff key.
        /// </summary>
        /// <param name="staffKey">The staff key.</param>
        /// <returns></returns>
        SystemAccount GetByStaffKey ( long staffKey );

        #endregion
    }
}