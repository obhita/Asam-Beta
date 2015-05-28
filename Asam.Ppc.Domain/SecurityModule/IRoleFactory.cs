namespace Asam.Ppc.Domain.SecurityModule
{
    #region

    using System;
    using OrganizationModule;

    #endregion

    public interface IRoleFactory
    {
        Role Create(Organization organization, string name, RoleType roleType = RoleType.UserDefined);
    }
}