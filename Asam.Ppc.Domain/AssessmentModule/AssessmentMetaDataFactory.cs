namespace Asam.Ppc.Domain.AssessmentModule
{
    public class AssessmentMetaDataFactory : IAssessmentMetaDataFactory
    {
        private readonly IAssessmentMetaDataRepository _assessmentMetaDataRepository;

        public AssessmentMetaDataFactory (IAssessmentMetaDataRepository assessmentMetaDataRepository)
        {
            _assessmentMetaDataRepository = assessmentMetaDataRepository;
        }

        public AssessmentMetaData Create(long assessmentKey, string metaDataKey, string metaDataValue)
        {
            var assessmentMetaData = new AssessmentMetaData(assessmentKey, metaDataKey, metaDataValue);
            _assessmentMetaDataRepository.MakePersistent(assessmentMetaData);
            return assessmentMetaData;
        }
    }
}
