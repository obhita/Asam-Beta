namespace Asam.Ppc.Service.Messages.Organization
{
    #region Using Statements

    using System;
    using Agatha.Common;

    #endregion

    /// <summary>
    ///     Request to update system account;
    /// </summary>
    public class UpdateSystemAccountRequest : Request
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the key.
        /// </summary>
        /// <value>
        ///     The key.
        /// </value>
        public long Key { get; set; }

        /// <summary>
        ///     Gets or sets the EULA agreement date.
        /// </summary>
        /// <value>
        ///     The EULA agreement Date
        /// </value>
        public DateTime? EulaAgreeDate { get; set; }

        #endregion
    }
}