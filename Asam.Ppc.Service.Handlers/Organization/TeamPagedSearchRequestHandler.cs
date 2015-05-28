namespace Asam.Ppc.Service.Handlers.Organization
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Domain.OrganizationModule;
    using Messages.Organization;
    using NHibernate.Criterion;

    public class TeamPagedSearchRequestHandler : PagedSearchRequestHandler<Team, TeamSummaryDto>
    {
        protected override ICriterion WhereExpress ( string keyword )
        {
            return Restrictions.On<Team> ( t => t.Name ).IsLike ( keyword );
        }

        protected override Expression<Func<Team, Organization>> GetOrganization()
        {
            return (e => e.Organization);
        }
    }
}