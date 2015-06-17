using System.Collections.Generic;
using System.Linq;
using Asam.Ppc.Domain.AssessmentModule.Events;
using Pillar.Common.Utility;
using Pillar.Domain.Event;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol
{
    public class InterviewerEvaluationUsedSubstancesChangedEventHandler :
        IDomainEventHandler<UsedSubstancesChangedEvent>
    {
        private readonly IAssessmentRepository _assessmentRepository;

        public InterviewerEvaluationUsedSubstancesChangedEventHandler(IAssessmentRepository assessmentRepository)
        {
            _assessmentRepository = assessmentRepository;
        }

        /// <summary>
        ///     Handles the <see cref="T:Pillar.Domain.Event.IDomainEvent" />.
        /// </summary>
        /// <param name="args">
        ///     The args for the <see cref="T:Pillar.Domain.Event.IDomainEvent" />.
        /// </param>
        public void Handle(UsedSubstancesChangedEvent args)
        {
            Assessment assessment = _assessmentRepository.GetByKey(args.AssessmentId);
            InterviewerEvaluation interviewEvaluation = assessment.DrugAndAlcoholSection.InterviewerEvaluation;
            IEnumerable<string> usedSubstancesCodes = args.NewValues == null
                                                          ? Enumerable.Empty<string>()
                                                          : args.NewValues.Select(s => s.Code);

            if (!usedSubstancesCodes.Contains(SubstanceCategory.Methadone.Code))
            {
                interviewEvaluation.ReviseProperty(assessment.Key,
                                                   PropertyUtil.ExtractPropertyName(
                                                       () =>
                                                       interviewEvaluation.HasMaintainedMethadoneDoseAtTherapeuticLevels),
                                                   null);
            }
            if (!usedSubstancesCodes.Contains(SubstanceCategory.OtherOpiate.Code))
            {
                interviewEvaluation
                    .ReviseProperty(assessment.Key,
                                    PropertyUtil.ExtractPropertyName(
                                        () => interviewEvaluation.HasMaintainedOtherOpiatesDoseAtTherapeuticLevels),
                                    null);
            }
            if (!usedSubstancesCodes.Contains(SubstanceCategory.Barbiturates.Code))
            {
                interviewEvaluation
                    .ReviseProperty(assessment.Key,
                                    PropertyUtil.ExtractPropertyName(
                                        () => interviewEvaluation.HasMaintainedBarbituatesDoseAtTherapeuticLevels),
                                    null);
            }
            if (!usedSubstancesCodes.Contains(SubstanceCategory.OtherSedatives.Code))
            {
                interviewEvaluation
                    .ReviseProperty(assessment.Key,
                                    PropertyUtil.ExtractPropertyName(
                                        () => interviewEvaluation.HasMaintainedSedativeDoseAtTherapeuticLevels),
                                    null);
            }
            if (!usedSubstancesCodes.Contains(SubstanceCategory.Stimulants.Code))
            {
                interviewEvaluation
                    .ReviseProperty(assessment.Key,
                                    PropertyUtil.ExtractPropertyName(
                                        () => interviewEvaluation.HasMaintainedStimulantDoseAtTherapeuticLevels),
                                    null);
            }
            if (!usedSubstancesCodes.Contains(SubstanceCategory.Nicotine.Code))
            {
                interviewEvaluation
                    .ReviseProperty(assessment.Key,
                                    PropertyUtil.ExtractPropertyName(
                                        () => interviewEvaluation.HasMaintainedNicotineDoseAtTherapeuticLevels),
                                    null);
            }
            if (!usedSubstancesCodes.Contains(SubstanceCategory.OtherSubstance.Code))
            {
                interviewEvaluation
                    .ReviseProperty(assessment.Key,
                                    PropertyUtil.ExtractPropertyName(
                                        () => interviewEvaluation.HasMaintainedOtherDrugDoseAtTherapeuticLevels),
                                    null);
            }
        }
    }
}