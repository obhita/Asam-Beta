namespace Asam.Ppc.Service.Handlers.Assessment.Mappers
{
    public interface IMapAssessmentSection
    {
        string Section { get; }
        string SubSection { get; }

        object Map (Domain.AssessmentModule.Assessment assessment);
    }
}