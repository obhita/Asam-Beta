namespace Asam.Ppc.Infrastructure.Services
{
    using System.Collections.Generic;
    using Pillar.Security.AccessControl;

    public interface IProvidePermissions
    {
        IReadOnlyCollection<Permission> Permissions { get; }
    }
}