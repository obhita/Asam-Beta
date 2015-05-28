using Asam.Ppc.Domain.AssessmentModule;

namespace Asam.Ppc.Infrastructure.Domain.Repository
{
    #region Using Statements

    #endregion

    /// <summary>
    ///     Ehr repository.
    /// </summary>
    public class AssessmentMetaDataRepository : NHibernateRepositoryBase<AssessmentMetaData>, IAssessmentMetaDataRepository
    {
        #region Constructors and Destructors

        public AssessmentMetaDataRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        { }

        #endregion
    }
}