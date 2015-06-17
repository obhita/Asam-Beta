namespace Asam.Ppc.Service.Handlers.Security
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Domain.SecurityModule;
    using Messages.Security;
    using NHibernate.Criterion;

    public class RolePagedSearchRequestHandler : PagedSearchRequestHandler<Role, RoleDto>
    {
        protected override ICriterion WhereExpress ( string keyword )
        {
            return Restrictions.And ( Restrictions.On<Role> ( r => r.Name ).IsLike ( keyword ), Restrictions.Where<Role> ( r => r.RoleType != RoleType.Internal ) );
        }

        protected override Expression<Func<Role, Domain.OrganizationModule.Organization>> GetOrganization()
        {
            return (e => e.Organization);
        }
    }
}