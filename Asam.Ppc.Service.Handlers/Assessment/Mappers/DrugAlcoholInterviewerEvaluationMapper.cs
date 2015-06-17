using Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol;
using Asam.Ppc.Service.Messages.Assessment.DrugAndAlcohol;
using AutoMapper;
using Pillar.Common.Utility;

namespace Asam.Ppc.Service.Handlers.Assessment.Mappers
{
    public class DrugAlcoholInterviewerEvaluationMapper : IMapAssessmentSection
    {
        public string Section
        {
            get
            {
                return
                    PropertyUtil.ExtractPropertyName<Domain.AssessmentModule.Assessment, DrugAndAlcoholSection>(
                                                                                                                 a => a.DrugAndAlcoholSection);
            }
        }
        public string SubSection
        {
            get
            {
                return
                    PropertyUtil.ExtractPropertyName<DrugAndAlcoholSection, InterviewerEvaluation>( d => d.InterviewerEvaluation );
            }
        }
        public object Map(Domain.AssessmentModule.Assessment assessment)
        {
            var interviewerEvaluationDto = AssessmentMapper.MapAssessmentSection(assessment, Section, SubSection) as InterviewerEvaluationDto;
            Mapper.Map ( assessment.DrugAndAlcoholSection.UsedSubstances,
                         interviewerEvaluationDto );
            interviewerEvaluationDto.MethadoneHasHealthCareProviderPrescribedUse =
                assessment.DrugAndAlcoholSection.MethadoneUse.HasHealthCareProviderPrescribedUse;
            interviewerEvaluationDto.OtherOpiateHasHealthCareProviderPrescribedUse =
                assessment.DrugAndAlcoholSection.OtherOpiateUse.HasHealthCareProviderPrescribedUse;
            interviewerEvaluationDto.BarbituratesHasHealthCareProviderPrescribedUse =
                assessment.DrugAndAlcoholSection.BarbiturateUse.HasHealthCareProviderPrescribedUse;
            interviewerEvaluationDto.OtherSedativesHasHealthCareProviderPrescribedUse =
                assessment.DrugAndAlcoholSection.OtherSedativeUse.HasHealthCareProviderPrescribedUse;
            interviewerEvaluationDto.StimulantsHasHealthCareProviderPrescribedUse =
                assessment.DrugAndAlcoholSection.StimulantUse.HasHealthCareProviderPrescribedUse;
            interviewerEvaluationDto.NicotineHasHealthCareProviderPrescribedUse =
                assessment.DrugAndAlcoholSection.NicotineUse.HasHealthCareProviderPrescribedUse;
            interviewerEvaluationDto.OtherSubstanceHasHealthCareProviderPrescribedUse =
                assessment.DrugAndAlcoholSection.OtherSubstanceUse.HasHealthCareProviderPrescribedUse;
            return interviewerEvaluationDto;
        }
    }
}
