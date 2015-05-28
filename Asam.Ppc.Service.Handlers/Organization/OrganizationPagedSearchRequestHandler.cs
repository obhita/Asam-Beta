namespace Asam.Ppc.Service.Handlers.Organization
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Domain.OrganizationModule;
    using Messages.Organization;
    using NHibernate.Criterion;

    public class OrganizationPagedSearchRequestHandler : PagedSearchRequestHandler<Domain.OrganizationModule.Organization, OrganizationSummaryDto>
    {
        protected override ICriterion WhereExpress(string keyword)
        {
            return Restrictions.On<Domain.OrganizationModule.Organization>(o => o.Name).IsLike(keyword);
        }

        protected override Expression<Func<Organization, Organization>> GetOrganization ()
        {
            return null;
        }
    }
}
