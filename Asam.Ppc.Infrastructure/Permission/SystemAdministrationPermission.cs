namespace Asam.Ppc.Infrastructure.Permission
{
    using Pillar.Security.AccessControl;

    public class SystemAdministrationPermission
    {
        public static Permission SystemAdminPermission = new Permission { Name = "securitymodule/systemadminpermission" };
    }
}
