namespace Asam.Ppc.Infrastructure.Domain.Repository
{
    using System.Collections.Generic;
    using Ppc.Domain.SecurityModule;

    public class RoleRepository : NHibernateRepositoryBase<Role>, IRoleRepository
    {
        #region Constructors and Destructors

        public RoleRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        { }

        #endregion

        public IEnumerable<Role> GetByKeys(params long[] keys)
        {
            var query = Session.QueryOver<Role> ().WhereRestrictionOn ( r => r.Key ).IsIn ( keys )
                               .JoinQueryOver(r => r.Organization)
                               .Where(o => o.Key == UserContext.OrganizationKey)
                               .List ();
            return query;
        }

        public Role GetInternalRoleKeyByName ( string name )
        {
            var role = Session.QueryOver<Role>().Where(r => r.Name == name && r.RoleType == RoleType.Internal).SingleOrDefault ();
            return role;
        }
    }
}