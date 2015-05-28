namespace Asam.Ppc.Service.Messages.Organization
{
    using Common;
    using Primitives;

    #region Using Statements

    

    #endregion

    /// <summary>
    ///     Data transfer object for Staff in context of a Team.
    /// </summary>
    public class TeamStaffDto : KeyedDataTransferObject
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public PersonName Name { get; set; }

        #endregion
    }
}