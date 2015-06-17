namespace Asam.Ppc.Service.Messages.Security
{
    using System;
    using Agatha.Common;

    public class UpdateRoleRequest : Request
    {
        public string  Name { get; set; }
        public long Key { get; set; }
    }
}