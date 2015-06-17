namespace Asam.Ppc.Domain.AssessmentModule
{
    #region Using Statements

    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using DrugAndAlcohol;
    using Events;
    using Pillar.Common.Utility;
    using Pillar.Domain.Event;

    #endregion

    /// <summary>
    /// Handle event when a section or subsection is visited.
    /// </summary>
    public class AssessmentUsedSubstancesChangedAndVisitedEventHandler : IDomainEventHandler<UsedSubstancesChangedEvent>
    {
        private readonly IAssessmentRepository _assessmentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssessmentUsedSubstancesChangedAndVisitedEventHandler" /> class.
        /// </summary>
        /// <param name="assessmentRepository">The assessment repository.</param>
        public AssessmentUsedSubstancesChangedAndVisitedEventHandler(IAssessmentRepository assessmentRepository)
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

            if (assessment.IsSubmitted)
            {
                return;
            }

            IEnumerable<string> usedSubstanceCodes = args.NewValues == null
                                                         ? Enumerable.Empty<string>()
                                                         : args.NewValues.Select(s => s.Code);

            IEnumerable<string> oldUsedSubstanceCodes = args.OldValues == null
                                                            ? Enumerable.Empty<string>()
                                                            : args.OldValues.Select(s => s.Code);
            #region Substance Ifs

            if (!usedSubstanceCodes.Contains(SubstanceCategory.Alcohol.Code))
            {
                var entityUse = new AlcoholUse();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () => assessment.DrugAndAlcoholSection.AlcoholUse),
                                                                entityUse);
            }
            if (!usedSubstanceCodes.Contains(SubstanceCategory.Methadone.Code))
            {
                var entityUse = new MethadoneUse();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () => assessment.DrugAndAlcoholSection.MethadoneUse),
                                                                entityUse);
            }
            if (!usedSubstanceCodes.Contains(SubstanceCategory.Heroin.Code))
            {
                var entityUse = new HeroinUse();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () => assessment.DrugAndAlcoholSection.HeroinUse),
                                                                entityUse);
            }
            if (!usedSubstanceCodes.Contains(SubstanceCategory.OtherOpiate.Code))
            {
                var entityUse = new OtherOpiateUse();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () =>
                                                                    assessment.DrugAndAlcoholSection.OtherOpiateUse),
                                                                entityUse);
            }
            if (!usedSubstanceCodes.Contains(SubstanceCategory.Barbiturates.Code))
            {
                var entityUse = new BarbiturateUse();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () =>
                                                                    assessment.DrugAndAlcoholSection.BarbiturateUse),
                                                                entityUse);
            }
            if (!usedSubstanceCodes.Contains(SubstanceCategory.OtherSedatives.Code))
            {
                var entityUse = new OtherSedativeUse();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () =>
                                                                    assessment.DrugAndAlcoholSection.OtherSedativeUse),
                                                                entityUse);
            }
            if (!usedSubstanceCodes.Contains(SubstanceCategory.Cocaine.Code))
            {
                var entityUse = new CocaineUse();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () => assessment.DrugAndAlcoholSection.CocaineUse),
                                                                entityUse);
            }
            if (!usedSubstanceCodes.Contains(SubstanceCategory.Stimulants.Code))
            {
                var entityUse = new StimulantUse();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () => assessment.DrugAndAlcoholSection.StimulantUse),
                                                                entityUse);
            }
            if (!usedSubstanceCodes.Contains(SubstanceCategory.Cannabis.Code))
            {
                var entityUse = new CannabisUse();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () => assessment.DrugAndAlcoholSection.CannabisUse),
                                                                entityUse);
            }
            if (!usedSubstanceCodes.Contains(SubstanceCategory.Hallucinogens.Code))
            {
                var entityUse = new HallucinogenUse();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () =>
                                                                    assessment.DrugAndAlcoholSection.HallucinogenUse),
                                                                entityUse);
            }
            if (!usedSubstanceCodes.Contains(SubstanceCategory.SolventInhalants.Code))
            {
                var entityUse = new SolventAndInhalantUse();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () =>
                                                                    assessment.DrugAndAlcoholSection
                                                                              .SolventAndInhalantUse), entityUse);
            }
            if (!usedSubstanceCodes.Contains(SubstanceCategory.MultiplePerDay.Code))
            {
                var entityUse = new MultipleSubstanceUsePerDay();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () =>
                                                                    assessment.DrugAndAlcoholSection
                                                                              .MultipleSubstanceUsePerDay), entityUse);
            }
            if (!usedSubstanceCodes.Contains(SubstanceCategory.Nicotine.Code))
            {
                var entityUse = new NicotineUse();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () => assessment.DrugAndAlcoholSection.NicotineUse),
                                                                entityUse);
            }
            if (!usedSubstanceCodes.Contains(SubstanceCategory.OtherSubstance.Code))
            {
                var entityUse = new OtherSubstanceUse();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () =>
                                                                    assessment.DrugAndAlcoholSection.OtherSubstanceUse),
                                                                entityUse);
            }
            if (!usedSubstanceCodes.Contains(SubstanceCategory.Heroin.Code) &&
                !usedSubstanceCodes.Contains(SubstanceCategory.Methadone.Code) &&
                !usedSubstanceCodes.Contains(SubstanceCategory.OtherOpiate.Code))
            {
                var cinaScale = new CinaScale();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () => assessment.DrugAndAlcoholSection.CinaScale),
                                                                cinaScale);
                var opiatesControlledEnvironment = new OpiatesInControlledEnvironment();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () =>
                                                                    assessment.DrugAndAlcoholSection
                                                                              .OpiatesInControlledEnvironment),
                                                                opiatesControlledEnvironment);
                var opiodMaintenanceTherapy = new OpioidMaintenanceTherapy();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () =>
                                                                    assessment.DrugAndAlcoholSection
                                                                              .OpioidMaintenanceTherapy),
                                                                opiodMaintenanceTherapy);
            }
            if (!usedSubstanceCodes.Contains(SubstanceCategory.Alcohol.Code) &&
                !usedSubstanceCodes.Contains(SubstanceCategory.Barbiturates.Code) &&
                !usedSubstanceCodes.Contains(SubstanceCategory.OtherSedatives.Code))
            {
                var ciwaScale = new CiwaScale();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () => assessment.DrugAndAlcoholSection.CiwaScale),
                                                                ciwaScale);
            }
            if (usedSubstanceCodes.Count(s => s != SubstanceCategory.Alcohol.Code) == 0)
            {
                var drugConsequences = new DrugConsequences();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () =>
                                                                    assessment.DrugAndAlcoholSection.DrugConsequences),
                                                                drugConsequences);
            }
            if (!usedSubstanceCodes.Any())
            {
                var addictionTreatmentHistory = new AddictionTreatmentHistory();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () =>
                                                                    assessment.DrugAndAlcoholSection
                                                                              .AddictionTreatmentHistory),
                                                                addictionTreatmentHistory);
                var additionalAddictionAndTreatmentItems =
                    new AdditionalAddictionAndTreatmentItems();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () =>
                                                                    assessment.DrugAndAlcoholSection
                                                                              .AdditionalAddictionAndTreatmentItems),
                                                                additionalAddictionAndTreatmentItems);
                var alcoholAndDrugInterviewerRating = new AlcoholAndDrugInterviewerRating();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () =>
                                                                    assessment.DrugAndAlcoholSection
                                                                              .AlcoholAndDrugInterviewerRating),
                                                                alcoholAndDrugInterviewerRating);
            }
            if (
                (!(usedSubstanceCodes.Contains(SubstanceCategory.Methadone.Code) &&
                   assessment.DrugAndAlcoholSection.MethadoneUse.HasHealthCareProviderPrescribedUse == true)) &&
                (!(usedSubstanceCodes.Contains(SubstanceCategory.OtherOpiate.Code) &&
                   assessment.DrugAndAlcoholSection.OtherOpiateUse.HasHealthCareProviderPrescribedUse == true)) &&
                (!(usedSubstanceCodes.Contains(SubstanceCategory.Barbiturates.Code) &&
                   assessment.DrugAndAlcoholSection.BarbiturateUse.HasHealthCareProviderPrescribedUse == true)) &&
                (!(usedSubstanceCodes.Contains(SubstanceCategory.OtherSedatives.Code) &&
                   assessment.DrugAndAlcoholSection.OtherSedativeUse.HasHealthCareProviderPrescribedUse == true)) &&
                (!(usedSubstanceCodes.Contains(SubstanceCategory.Stimulants.Code) &&
                   assessment.DrugAndAlcoholSection.StimulantUse.HasHealthCareProviderPrescribedUse == true)) &&
                (!(usedSubstanceCodes.Contains(SubstanceCategory.Nicotine.Code) &&
                   assessment.DrugAndAlcoholSection.NicotineUse.HasHealthCareProviderPrescribedUse == true)) &&
                (!(usedSubstanceCodes.Contains(SubstanceCategory.OtherSubstance.Code) &&
                   assessment.DrugAndAlcoholSection.OtherSubstanceUse.HasHealthCareProviderPrescribedUse == true)))
            {
                var interviewerEvaluation = new InterviewerEvaluation();
                assessment.DrugAndAlcoholSection.ReviseProperty(assessment.Key,
                                                                PropertyUtil.ExtractPropertyName(
                                                                    () =>
                                                                    assessment.DrugAndAlcoholSection
                                                                              .InterviewerEvaluation),
                                                                interviewerEvaluation);
            }

            #endregion
        }

    }
}