namespace Asam.Ppc.Service.Messages.Security
{
    using Agatha.Common;

    public class CreateRoleResponse : Response
    {
        public RoleDto Role { get; set; }
    }
}