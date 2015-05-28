namespace Asam.Ppc.Service.Messages.Organization
{
    using Common;
    using Common.Lookups;

    #region Using Statements

    

    #endregion

    public class OrganizationPhoneDto : KeyedDataTransferObject
    {
        #region Public Properties

        public bool IsPrimary { get; set; }
        public LookupDto OrganizationPhoneType { get; set; }
        public PhoneDto Phone { get; set; }
        public int OriginalHash { get; set; }

        #endregion
    }
}