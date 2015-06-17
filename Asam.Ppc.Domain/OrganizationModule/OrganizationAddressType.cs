namespace Asam.Ppc.Domain.OrganizationModule
{
    using CommonModule;

    public class OrganizationAddressType : Lookup
    {
        /// <summary>
        ///     Office = 0.
        /// </summary>
        public static readonly OrganizationAddressType Office = new OrganizationAddressType
        {
            Code = "Office",
            SortOrder = 1,
            Value = 0
        };
    }
}
