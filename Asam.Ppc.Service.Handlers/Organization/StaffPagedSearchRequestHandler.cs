namespace Asam.Ppc.Service.Handlers.Organization
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Domain.OrganizationModule;
    using Messages.Organization;
    using NHibernate.Criterion;

    public class StaffPagedSearchRequestHandler : PagedSearchRequestHandler<Staff,StaffDto>
    {
        protected override ICriterion WhereExpress ( string keyword )
        {
            return Restrictions.On<Staff>(s => s.Name.FirstName).IsLike(keyword) ||
            Restrictions.On<Staff>(s => s.Name.LastName).IsLike(keyword);
        }

        protected override Expression<Func<Staff, Organization>> GetOrganization()
        {
            return (e => e.Organization);
        }
    }
}
