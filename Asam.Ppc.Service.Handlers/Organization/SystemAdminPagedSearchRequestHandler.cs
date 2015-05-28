namespace Asam.Ppc.Service.Handlers.Organization
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Domain.SecurityModule;
    using Messages.Security;
    using NHibernate.Criterion;

    public class SystemAdminPagedSearchRequestHandler : PagedSearchRequestHandler<SystemAccount, SystemAccountDto>
    {
        protected override ICriterion WhereExpress(string keyword)
        {
            return  Restrictions.And ( Restrictions.On<SystemAccount>(o => o.Identifier).IsLike(keyword), Restrictions.Where<SystemAccount>( s => s.IsSystemAdmin ) );
        }

        protected override Expression<Func<SystemAccount, Domain.OrganizationModule.Organization>> GetOrganization()
        {
            return null;
        }
    }
}