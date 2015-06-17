namespace Asam.Ppc.Service.Messages.Security
{
    using System.Collections.Generic;
    using Agatha.Common;

    public class GetAvailableRolesResponse : Response
    {
        public IEnumerable<RoleDto> Roles { get; set; }
    }
}