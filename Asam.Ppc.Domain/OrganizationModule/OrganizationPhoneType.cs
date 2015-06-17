namespace Asam.Ppc.Domain.OrganizationModule
{
    using CommonModule;

    #region Using Statements

    

    #endregion

    /// <summary>
    ///     Organization Phone Type
    /// </summary>
    public class OrganizationPhoneType : Lookup
    {
        #region Static Fields

        /// <summary>
        ///     Office = 0.
        /// </summary>
        public static readonly OrganizationPhoneType Office = new OrganizationPhoneType
            {
                Code = "Office",
                SortOrder = 1,
                Value = 0
            };

        #endregion
    }
}