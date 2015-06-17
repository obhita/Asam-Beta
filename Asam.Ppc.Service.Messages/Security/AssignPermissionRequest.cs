namespace Asam.Ppc.Service.Messages.Security
{
    using System;
    using System.Collections.Generic;
    using Agatha.Common;

    public class AssignPermissionRequest : Request
    {
        public long Key { get; set; }
        public bool  Add { get; set; }
        public IEnumerable<string> Permissions { get; set; }
    }
}