namespace Asam.Ppc.Service.Messages.Security
{
    using System.Collections.Generic;
    using Agatha.Common;

    public class AssignRolesRequest:Request
    {
        public long SystemAccoutnKey { get; set; }

        public bool AddRoles { get; set; }

        public IEnumerable<long> Roles { get; set; }
    }
}