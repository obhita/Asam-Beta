using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Asam.Ppc.Domain.PatientModule;

namespace Asam.Ppc.Infrastructure.Domain.Repository
{
    using System.Linq;
    using global::NHibernate.Criterion;

    public class PatientRepository : NHibernateRepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        {}

        public IEnumerable<Patient> PatientSearchByKeyword ( string keyword, int page, int count, out int totalCount )
        {
            keyword = keyword + "%";
            var query = Session.QueryOver<Patient>()
                               .Where( Restrictions.On<Patient>(p => p.Name.FirstName).IsLike(keyword) ||
                                       Restrictions.On<Patient>(p => p.Name.LastName).IsLike(keyword))
                               .JoinQueryOver(p => p.Organization)
                               .Where(o => o.Key == UserContext.OrganizationKey)
                               .Skip(page * count)
                               .Take(count);
            var result = query.Future<Patient>();
            totalCount = query.ToRowCountQuery().FutureValue<int>().Value;
            return result.ToList();
        }
    }
}
