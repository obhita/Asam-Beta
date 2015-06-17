namespace Asam.Ppc.Mvc.Infrastructure.Security
{
    using System;
    using System.Security.Claims;
    using Domain.SecurityModule;

    /// <summary>
    ///     This interface provides ability to manage permission claims.
    /// </summary>
    public interface IPermissionClaimsManager
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Issues the account staff claims.
        /// </summary>
        /// <param name="claimsPrincipal">The claims principal.</param>
        /// <param name="systemAccount">The system account.</param>
        void IssueAccountStaffClaims(ClaimsPrincipal claimsPrincipal, SystemAccount systemAccount);

        /// <summary>
        ///     Issues the system permission claims.
        /// </summary>
        /// <param name="claimsPrincipal">
        ///     The claims principal.
        /// </param>
        /// <param name="systemAccount">
        ///     The system account.
        /// </param>
        void IssueSystemPermissionClaims(ClaimsPrincipal claimsPrincipal, SystemAccount systemAccount);

        #endregion
    }
}
