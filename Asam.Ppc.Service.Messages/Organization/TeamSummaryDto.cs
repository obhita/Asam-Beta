namespace Asam.Ppc.Service.Messages.Organization
{
    using Common;

    #region Using Statements

    

    #endregion

    /// <summary>
    ///     Data transfer object for team summary.
    /// </summary>
    public class TeamSummaryDto : KeyedDataTransferObject
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        #endregion
    }
}