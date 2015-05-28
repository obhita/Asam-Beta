namespace Asam.Ppc.Service.Handlers.Assessment.Mappers
{
    public interface IAssessmentSectionMapper
    {
        object Map ( Domain.AssessmentModule.Assessment assessment, string section, string subSection );
    }
}