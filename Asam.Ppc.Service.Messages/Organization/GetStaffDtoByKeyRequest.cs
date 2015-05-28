namespace Asam.Ppc.Service.Messages.Organization
{
    using System;
    using Agatha.Common;

    public class GetStaffDtoByKeyRequest : Request
    {
        public long Key { get; set; }
    }
}