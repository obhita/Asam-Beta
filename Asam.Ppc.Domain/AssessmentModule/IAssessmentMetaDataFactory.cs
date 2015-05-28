namespace Asam.Ppc.Domain.AssessmentModule
{
    public interface IAssessmentMetaDataFactory
    {
        AssessmentMetaData Create(long assessmentKey, string metaDataKey, string metaDataValue);
    }
}