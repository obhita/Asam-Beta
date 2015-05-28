namespace Asam.Ppc.Domain.SecurityModule
{
    using System.Collections.Generic;
    using Pillar.Domain;

    #region Using Statements

    

    #endregion

    public interface IRoleRepository : IRepository<Role>
    {
        IEnumerable<Role> GetByKeys ( params long[] keys );
        Role GetInternalRoleKeyByName ( string name );
    }
}