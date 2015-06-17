namespace Asam.Ppc.Infrastructure.Permission
{
    using Pillar.Security.AccessControl;

    public interface IInternalPermissionDescriptor : IPermissionDescriptor
    {
        bool IsInternal { get; }
    }
}
