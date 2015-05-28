namespace Asam.Ppc.Service.Messages.Security
{
    using System.Collections.Generic;
    using Agatha.Common;

    public class GetAvailablePermissionsResponse : Response
    {
        public IEnumerable<string> Permissions { get; set; }
    }
}