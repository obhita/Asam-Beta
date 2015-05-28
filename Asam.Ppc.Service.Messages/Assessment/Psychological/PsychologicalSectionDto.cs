using Asam.Ppc.Service.Messages.Common;

namespace Asam.Ppc.Service.Messages.Assessment.Psychological
{
    public class PsychologicalSectionDto : SectionDtoBase
    {
        public DepressionEvaluationDto DepressionEvaluation { get; set; }

        public InterviewerRatingDto InterviewerRating { get; set; }

        public PsychologicalHistoryDto PsychologicalHistory { get; set; }
    }
}
