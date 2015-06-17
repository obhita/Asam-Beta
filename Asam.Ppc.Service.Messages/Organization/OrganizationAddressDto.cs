namespace Asam.Ppc.Service.Messages.Organization
{
    using Common;
    using Common.Lookups;

    public class OrganizationAddressDto : KeyedDataTransferObject
    {
        #region Public Properties

        public AddressDto Address { get; set; }
        public bool IsPrimary { get; set; }
        public LookupDto OrganizationAddressType { get; set; }
        public int OriginalHash { get; set; }

        #endregion
    }
}