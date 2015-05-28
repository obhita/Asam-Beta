using System.Collections.Generic;
using Asam.Ppc.Domain.AssessmentModule;
using NHibernate.Criterion;

namespace Asam.Ppc.Infrastructure.Domain.Repository
{
    using System.Linq;
    using Ppc.Domain.PatientModule;

    /// <summary>
    /// Assessment Repository
    /// </summary>
    public class AssessmentRepository : NHibernateRepositoryBase<Assessment>, IAssessmentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssessmentRepository" /> class.
        /// </summary>
        /// <param name="sessionProvider">The session provider.</param>
        public AssessmentRepository ( ISessionProvider sessionProvider )
            : base ( sessionProvider )
        {}

        public List<Assessment> GetAllAssessmentsByKeyword ( string keyword, int pageIndex, int pageSize, out int totalCount )
        {
            keyword = keyword + "%";
            var query = Session.QueryOver<Assessment> ()
                               .JoinQueryOver ( a => a.Patient )
                               .Where ( Restrictions.On<Patient>(p => p.Name.FirstName).IsLike(keyword) ||
                                        Restrictions.On<Patient>(p => p.Name.LastName).IsLike(keyword))
                               .JoinQueryOver ( p => p.Organization )
                               .Where ( o => o.Key == UserContext.OrganizationKey )
                               .Skip ( pageIndex * pageSize )
                               .Take ( pageSize );
            var result = query.Future<Assessment> ();
            totalCount = query.ToRowCountQuery ().FutureValue<int> ().Value;
            return result.ToList();
        }

        public IEnumerable<Assessment> GetPagedAssessmentsByPatientId ( long patientId, int pageIndex, int pageSize, out int totalCount )
        {
            var query = Session.QueryOver<Assessment>()
                               .JoinQueryOver(a => a.Patient)
                               .Where(p => p.Key == patientId)
                               .JoinQueryOver(p => p.Organization)
                               .Where(o => o.Key == UserContext.OrganizationKey)
                               .Skip(pageIndex * pageSize)
                               .Take(pageSize);
            var result = query.Future<Assessment>();
            totalCount = query.ToRowCountQuery().FutureValue<int>().Value;
            return result.ToList();
        }

        public void Evict(Assessment assessment)
        {
            Session.Evict(assessment);
        }

        public Assessment GetUnproxiedAssessment(Assessment assessment)
        {
            return (Assessment) Session.GetSessionImplementation().PersistenceContext.Unproxy(assessment);
        }
    }
}
