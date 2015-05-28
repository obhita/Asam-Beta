namespace Asam.Ppc.Service.Messages.Security
{
    using System;
    using Agatha.Common;

    public class GetRoleDtoByKeyRequest : Request
    {
        public long Key { get; set; }
    }
}