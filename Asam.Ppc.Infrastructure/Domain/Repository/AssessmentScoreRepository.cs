using Asam.Ppc.Domain.Scoring.ScoringModule;

namespace Asam.Ppc.Infrastructure.Domain.Repository
{
    using System.Linq;
    using Ppc.Domain.AssessmentModule;

    public class AssessmentScoreRepository : NHibernateRepositoryBase<AssessmentScore>, IAssessmentScoreRepository
    {
        public AssessmentScoreRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        {}

        public AssessmentScore GetAssessmentScoreByAssessment ( Assessment assessment )
        {
            if ( assessment.Patient.OrganizationKey == UserContext.OrganizationKey )
            {
                var query = Session.QueryOver<AssessmentScore> ()
                                   .Where ( score => score.AssessmentKey == assessment.Key )
                                   .OrderBy ( score => score.CreatedTimestamp )
                                   .Desc;
                return query.List<AssessmentScore> ().FirstOrDefault ();
            }
            return null;
        }
    }
}
