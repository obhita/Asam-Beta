namespace Asam.Ppc.Infrastructure.Services
{
    #region Using Statements

    using System.Linq;
    using Pillar.FluentRuleEngine;
    using Ppc.Domain.AssessmentModule;
    using Ppc.Domain.AssessmentModule.DrugAndAlcohol;
    using Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups;
    using Ppc.Domain.CommonModule.Lookups;

    #endregion

    public class AsamScoringCompletenessRuleCollection : AbstractRuleCollection<Assessment>, ICompletenessRuleCollection<Assessment>
    {
        #region Constructors and Destructors

        public AsamScoringCompletenessRuleCollection ()
        {
            AutoValidatePropertyRules = true;

            NewPropertyRule(() => CompletionSectionAcceptableLevelsOfCareRule).WithProperty(a => a.CompletionSection.AcceptableLevelsOfCare).NotNull();
            NewPropertyRule(() => CompletionSectionDetoxificationRequiredMoreThanHourlyMonitoringRule).WithProperty(a => a.CompletionSection.DetoxificationRequiredMoreThanHourlyMonitoring).NotNull();
            NewPropertyRule(() => CompletionSectionIsAbleToSelfAdministerMedicationRule).WithProperty(a => a.CompletionSection.IsAbleToSelfAdministerMedication).NotNull();
            NewPropertyRule(() => CompletionSectionIsCurrentlyResidingInCareLevel_III_1Rule).WithProperty(a => a.CompletionSection.IsCurrentlyResidingInCareLevel_III_1).NotNull();
            NewPropertyRule(() => CompletionSectionMedicalConditionEndangeredByContinuedSubstanceUseRule).WithProperty(a => a.CompletionSection.MedicalConditionEndangeredByContinuedSubstanceUse).NotNull();
            NewPropertyRule(() => CompletionSectionMedicalConditionExacerbatedByContinuedSubstanceUseRule).WithProperty(a => a.CompletionSection.MedicalConditionExacerbatedByContinuedSubstanceUse).NotNull();
            NewPropertyRule(() => CompletionSectionMedicalConditionMakesAbstinenceVitalRule).WithProperty(a => a.CompletionSection.MedicalConditionMakesAbstinenceVital).NotNull();
            NewPropertyRule(() => CompletionSectionPrnHourlyMonitoringSufficientToDetermineDetoxServiceLevelRule).WithProperty(a => a.CompletionSection.PrnHourlyMonitoringSufficientToDetermineDetoxServiceLevel).NotNull();
            NewPropertyRule(() => CompletionSectionRequiresTreatmentModeOnlyAvailableInCareLevel_III_7Rule).WithProperty(a => a.CompletionSection.RequiresTreatmentModeOnlyAvailableInCareLevel_III_7).NotNull();
            NewPropertyRule(() => CompletionSectionRespondedPositivelyToEmotionalSupportDuringInterviewRule).WithProperty(a => a.CompletionSection.RespondedPositivelyToEmotionalSupportDuringInterview).NotNull();
            NewPropertyRule(() => CompletionSectionSymptomsLifeThreateningBecauseOfSubstanceUseRule).WithProperty(a => a.CompletionSection.SymptomsLifeThreateningBecauseOfSubstanceUse).NotNull();
            NewPropertyRule(() => CompletionSectionSymptomsStabalizedDuringTreatmentDayRule).WithProperty(a => a.CompletionSection.SymptomsStabalizedDuringTreatmentDay).NotNull();
            NewPropertyRule(() => CompletionSectionTimingOfPositiveResponseToDetoxificationCareRule).WithProperty(a => a.CompletionSection.TimingOfPositiveResponseToWithdrawalManagementCare).NotNull();
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.AddictionTreatmentHistory.PreviousSubstanceUseTreatment == SubstanceTreatmentType.AlcoholAndDrug
                                 || a.DrugAndAlcoholSection.AddictionTreatmentHistory.PreviousSubstanceUseTreatment == SubstanceTreatmentType.AlcoholOnly,
                            () =>
                            NewPropertyRule ( () => AddictionTreatmentHistoryNumberOfTimesTreatedForAlcoholAbuseLifetimeRule )
                                .WithProperty ( a => a.DrugAndAlcoholSection.AddictionTreatmentHistory.NumberOfTimesTreatedForAlcoholAbuseLifetime )
                                .NotNull () );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.AddictionTreatmentHistory.PreviousSubstanceUseTreatment == SubstanceTreatmentType.AlcoholAndDrug
                                 || a.DrugAndAlcoholSection.AddictionTreatmentHistory.PreviousSubstanceUseTreatment == SubstanceTreatmentType.DrugOnly,
                            () =>
                            NewPropertyRule ( () => AddictionTreatmentHistoryNumberOfTimesDrugTreatmentLifetimeRule )
                                .WithProperty ( a => a.DrugAndAlcoholSection.AddictionTreatmentHistory.NumberOfTimesDrugTreatmentLifetime )
                                .NotNull () );
            ShouldRunWhen(a => a.DrugAndAlcoholSection.AddictionTreatmentHistory.PreviousSubstanceUseTreatment == SubstanceTreatmentType.AlcoholAndDrug
                                 || a.DrugAndAlcoholSection.AddictionTreatmentHistory.PreviousSubstanceUseTreatment == SubstanceTreatmentType.AlcoholOnly
                                 || a.DrugAndAlcoholSection.AddictionTreatmentHistory.PreviousSubstanceUseTreatment == SubstanceTreatmentType.DrugOnly,
                            () =>
                                {
                                    NewPropertyRule ( () => AddictionTreatmentHistoryUsuallyLeftDetoxificationBeforeAdvisedRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AddictionTreatmentHistory.UsuallyLeftDetoxificationBeforeAdvised )
                                        .NotNull ();
                                    NewPropertyRule ( () => AddictionTreatmentHistoryUsuallyEnteredContinuedTreatmentAfterDetoxificationRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AddictionTreatmentHistory.UsuallyEnteredContinuedTreatmentAfterDetoxification )
                                        .NotNull ();
                                    NewPropertyRule ( () => AddictionTreatmentHistoryHighestCareLevelFailedFromInPast90DaysRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AddictionTreatmentHistory.HighestCareLevelFailedFromInPast90Days )
                                        .NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.NumberOfTimesOverdosedOnDrugs > 0, () => NewPropertyRule(() => AdditionalAddictionAndTreatmentItemsSubstanceOverdoseInPast24HoursRule).WithProperty(a => a.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.SubstanceOverdoseInPast24Hours).NotNull());
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any (),
                            () =>
                                {
                                    NewPropertyRule ( () => AddictionTreatmentHistoryPreviousSubstanceUseTreatmentRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AddictionTreatmentHistory.PreviousSubstanceUseTreatment )
                                        .NotNull ();
                                    NewPropertyRule ( () => AdditionalAddictionAndTreatmentItemsAddictionSymptomsIncreasedRecentlyRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.AddictionSymptomsIncreasedRecently )
                                        .NotNull ();
                                    NewPropertyRule ( () => AdditionalAddictionAndTreatmentItemsConcernsAboutPursuingTreatmentRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.ConcernsAboutPursuingTreatment )
                                        .NotNull ();
                                    NewPropertyRule ( () => AdditionalAddictionAndTreatmentItemsCurrentStrengthOfSubstanceUseDesireRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.CurrentStrengthOfSubstanceUseDesire )
                                        .NotNull ();
                                    NewPropertyRule ( () => AdditionalAddictionAndTreatmentItemsFeelLikelyToContinueSubstanceUseOrRelapseRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.FeelLikelyToContinueSubstanceUseOrRelapse )
                                        .NotNull ();
                                    NewPropertyRule ( () => AdditionalAddictionAndTreatmentItemsHelpfulnessOfTreatmentRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.HelpfulnessOfTreatment )
                                        .NotNull ();
                                    NewPropertyRule ( () => AdditionalAddictionAndTreatmentItemsLikelihoodPreviousEnvironmentWillInduceSubstanceUseRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.LikelihoodPreviousEnvironmentWillInduceSubstanceUse )
                                        .NotNull ();
                                    NewPropertyRule ( () => AdditionalAddictionAndTreatmentItemsPossibleFutureRelapseCauseRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.PossibleFutureRelapseCause )
                                        .NotNull ();
                                    NewPropertyRule ( () => AdditionalAddictionAndTreatmentItemsStrategyToPreventRelapseRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.StrategyToPreventRelapse )
                                        .NotNull ();
                                    NewPropertyRule ( () => AdditionalAddictionAndTreatmentItemsStrengthOfSubstanceUseUrgeDueToEnvironmentalTriggersRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggers )
                                        .NotNull ();
                                    NewPropertyRule ( () => AdditionalAddictionAndTreatmentItemsWhichSubstanceIsMajorProblemRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.WhichSubstanceIsMajorProblem )
                                        .NotNull ();
                                    NewPropertyRule ( () => AlcoholAndDrugInterviewerRatingInterviewerScoreOfAlcoholTreatmentNeedRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AlcoholAndDrugInterviewerRating.InterviewerScoreOfAlcoholTreatmentNeed )
                                        .NotNull ();
                                    NewPropertyRule ( () => AlcoholAndDrugInterviewerRatingInterviewerScoreOfAttitudeRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AlcoholAndDrugInterviewerRating.InterviewerScoreOfAttitude )
                                        .NotNull ();
                                    NewPropertyRule ( () => AlcoholAndDrugInterviewerRatingInterviewerScoreOfDrugTreatmentNeedRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AlcoholAndDrugInterviewerRating.InterviewerScoreOfDrugTreatmentNeed )
                                        .NotNull ();
                                    NewPropertyRule ( () => AlcoholAndDrugInterviewerRatingInterviewerScoreOfReadinessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AlcoholAndDrugInterviewerRating.InterviewerScoreOfReadiness )
                                        .NotNull ();
                                    NewPropertyRule ( () => AlcoholAndDrugInterviewerRatingIsPatientExperiencingWithdrawalSignsSymptomsRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AlcoholAndDrugInterviewerRating.IsPatientExperiencingWithdrawalSignsSymptoms )
                                        .NotNull ();
                                    NewPropertyRule ( () => AlcoholAndDrugInterviewerRatingMajorityOfInformationFromCollateralSourceRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AlcoholAndDrugInterviewerRating.MajorityOfInformationFromCollateralSource )
                                        .NotNull ();
                                    NewPropertyRule ( () => AlcoholAndDrugInterviewerRatingPatientManifestingSeriousRelapseBehaviorsRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AlcoholAndDrugInterviewerRating.PatientManifestingSeriousRelapseBehaviors )
                                        .NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.AlcoholUse.AlcoholUsedToIntoxication == true, () =>
                {
                    NewPropertyRule(() => AlcoholUseLastUsedToIntoxificationRule).WithProperty(a => a.DrugAndAlcoholSection.AlcoholUse.LastUsedToIntoxification).NotNull();
                    NewPropertyRule(() => AlcoholUseNumberOfDaysIntoxicatedInPast30DaysRule).WithProperty(a => a.DrugAndAlcoholSection.AlcoholUse.NumberOfDaysIntoxicatedInPast30Days).NotNull();
                });
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.Alcohol ),
                            () =>
                                {
                                    NewPropertyRule(() => AlcoholHasStrongUrgesRule)
                                        .WithProperty(a => a.DrugAndAlcoholSection.AlcoholUse.HasStrongUrges)
                                        .NotNull();
                                    NewPropertyRule ( () => AlcoholUseNumberOfDaysUsedInPast30DaysRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AlcoholUse.NumberOfDaysUsedInPast30Days )
                                        .NotNull ();
                                    NewPropertyRule ( () => AlcoholUseNumberOfDaysWithSubstanceProblemsInLast30DaysRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AlcoholUse.NumberOfDaysWithSubstanceProblemsInLast30Days )
                                        .NotNull ();
                                    NewPropertyRule ( () => AlcoholUseNumberOfTimesWithdrawalCausedDeliriumTremensRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AlcoholUse.NumberOfTimesWithdrawalCausedDeliriumTremens )
                                        .NotNull ();
                                    NewPropertyRule ( () => AlcoholUseNumberOfTimesWithdrawalCausedSeizuresRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AlcoholUse.NumberOfTimesWithdrawalCausedSeizures )
                                        .NotNull ();
                                    NewPropertyRule ( () => AlcoholUseTroubledInLast30DaysBySubstanceProblemsRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AlcoholUse.TroubledInLast30DaysBySubstanceProblems )
                                        .NotNull ();
                                    NewPropertyRule ( () => AlcoholUseAlcoholUsedToIntoxicationRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AlcoholUse.AlcoholUsedToIntoxication )
                                        .NotNull ();
                                    NewPropertyRule ( () => AlcoholUseAmountOfMoneySpentInLast30DaysRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AlcoholUse.AmountOfMoneySpentInLast30Days )
                                        .NotNull ();
                                    NewPropertyRule ( () => AlcoholUseExperiencesWithdrawalSicknessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AlcoholUse.ExperiencesWithdrawalSickness )
                                        .NotNull ();
                                    NewPropertyRule ( () => AlcoholUseImportanceOfTreatmentForSubstanceProblemsRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.AlcoholUse.ImportanceOfTreatmentForSubstanceProblems )
                                        .NotNull ();
                                    NewPropertyRule ( () => AlcoholUseLastUsedRule ).WithProperty ( a => a.DrugAndAlcoholSection.AlcoholUse.LastUsed ).NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.AlcoholUse.ExperiencesWithdrawalSickness == true, () => NewPropertyRule(() => AlcoholUseUseSubstanceToPreventWithdrawalSicknessRule).WithProperty(a => a.DrugAndAlcoholSection.AlcoholUse.UseSubstanceToPreventWithdrawalSickness).NotNull());
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.Barbiturates ),
                            () =>
                            {
                                NewPropertyRule(() => BarbiturateHasStrongUrgesRule)
                                    .WithProperty(a => a.DrugAndAlcoholSection.BarbiturateUse.HasStrongUrges)
                                    .NotNull();
                                    NewPropertyRule ( () => BarbiturateUseExperiencesWithdrawalSicknessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.BarbiturateUse.ExperiencesWithdrawalSickness )
                                        .NotNull ();
                                    NewPropertyRule ( () => BarbiturateUseHasHealthCareProviderPrescribedUseRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.BarbiturateUse.HasHealthCareProviderPrescribedUse )
                                        .NotNull ();
                                    NewPropertyRule ( () => BarbiturateUseIncreasedDoseRequiredToGetSameEffectRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.BarbiturateUse.IncreasedDoseRequiredToGetSameEffect )
                                        .NotNull ();
                                    NewPropertyRule ( () => BarbiturateUseLastUsedRule ).WithProperty ( a => a.DrugAndAlcoholSection.BarbiturateUse.LastUsed ).NotNull ();
                                    NewPropertyRule ( () => BarbiturateUseNumberOfDaysUsedInPast30DaysRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.BarbiturateUse.NumberOfDaysUsedInPast30Days )
                                        .NotNull ();
                                    NewPropertyRule ( () => BarbiturateUseNumberOfMonthsUsedInLifetimeRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.BarbiturateUse.NumberOfMonthsUsedInLifetime )
                                        .NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.BarbiturateUse.ExperiencesWithdrawalSickness == true, () => NewPropertyRule(() => BarbiturateUseUseSubstanceToPreventWithdrawalSicknessRule).WithProperty(a => a.DrugAndAlcoholSection.BarbiturateUse.UseSubstanceToPreventWithdrawalSickness).NotNull());
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.BarbiturateUse.HasHealthCareProviderPrescribedUse == true, () => NewPropertyRule(() => BarbiturateUseWasSubstanceTakenAsPrescribedRule).WithProperty(a => a.DrugAndAlcoholSection.BarbiturateUse.WasSubstanceTakenAsPrescribed).NotNull());
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.Cannabis ),
                            () =>
                            {
                                NewPropertyRule(() => CannabisHasStrongUrgesRule)
                                    .WithProperty(a => a.DrugAndAlcoholSection.CannabisUse.HasStrongUrges)
                                    .NotNull();
                                    NewPropertyRule ( () => CannabisUseExperiencesWithdrawalSicknessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CannabisUse.ExperiencesWithdrawalSickness )
                                        .NotNull ();
                                    NewPropertyRule ( () => CannabisUseLastUsedRule ).WithProperty ( a => a.DrugAndAlcoholSection.CannabisUse.LastUsed ).NotNull ();
                                    NewPropertyRule ( () => CannabisUseNumberOfDaysUsedInPast30DaysRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CannabisUse.NumberOfDaysUsedInPast30Days )
                                        .NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.CannabisUse.ExperiencesWithdrawalSickness == true, () => NewPropertyRule(() => CannabisUseUseSubstanceToPreventWithdrawalSicknessRule).WithProperty(a => a.DrugAndAlcoholSection.CannabisUse.UseSubstanceToPreventWithdrawalSickness).NotNull());
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.Heroin )
                                 || a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.Methadone )
                                 || a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.OtherOpiate ),
                            () =>
                                {
                                    NewPropertyRule ( () => CinaScaleExperiencedNauseaOrVomitedRecentlyRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CinaScale.ExperiencedNauseaOrVomitedRecently )
                                        .NotNull ();
                                    NewPropertyRule ( () => CinaScaleFeelsHotOrColdRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CinaScale.FeelsHotOrCold )
                                        .NotNull ();
                                    NewPropertyRule ( () => CinaScaleHasAbdominalPainRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CinaScale.HasAbdominalPain )
                                        .NotNull ();
                                    NewPropertyRule ( () => CinaScaleHasMuscleAchesRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CinaScale.HasMuscleAches )
                                        .NotNull ();
                                    NewPropertyRule ( () => CinaScaleObservedGooseFleshRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CinaScale.ObservedGooseFlesh )
                                        .NotNull ();
                                    NewPropertyRule ( () => CinaScaleObservedLacriminationRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CinaScale.ObservedLacrimination )
                                        .NotNull ();
                                    NewPropertyRule ( () => CinaScaleObservedNasalCongestionRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CinaScale.ObservedNasalCongestion )
                                        .NotNull ();
                                    NewPropertyRule ( () => CinaScaleObservedRestlessnessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CinaScale.ObservedRestlessness )
                                        .NotNull ();
                                    NewPropertyRule ( () => CinaScaleObservedSweatingRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CinaScale.ObservedSweating )
                                        .NotNull ();
                                    NewPropertyRule ( () => CinaScaleObservedTremorRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CinaScale.ObservedTremor )
                                        .NotNull ();
                                    NewPropertyRule ( () => CinaScaleObservedYawningRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CinaScale.ObservedYawning )
                                        .NotNull ();
                                    NewPropertyRule ( () => OpiatesInControlledEnvironmentExperiencesWithdrawalSicknessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OpiatesInControlledEnvironment.ExperiencesWithdrawalSickness )
                                        .NotNull ();
                                    NewPropertyRule ( () => OpiatesInControlledEnvironmentIncreasedDoseRequiredToGetSameEffectRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OpiatesInControlledEnvironment.IncreasedDoseRequiredToGetSameEffect )
                                        .NotNull ();
                                    NewPropertyRule ( () => OpiatesInControlledEnvironmentUseSubstanceToPreventWithdrawalSicknessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OpiatesInControlledEnvironment.UseSubstanceToPreventWithdrawalSickness )
                                        .NotNull ();
                                    NewPropertyRule ( () => OpioidMaintenanceTherapyCompletedAtLeast6MonthOpioidMaintenanceTherapyVoluntarilyRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OpioidMaintenanceTherapy.CompletedAtLeast6MonthOpioidMaintenanceTherapyVoluntarily )
                                        .NotNull ();
                                    NewPropertyRule ( () => OpioidMaintenanceTherapyDetoxificationEndedLessThanOrEqual2YearsAgoRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OpioidMaintenanceTherapy.DetoxificationEndedLessThanOrEqual2YearsAgo )
                                        .NotNull ();
                                    NewPropertyRule ( () => OpioidMaintenanceTherapyGraduallyDetoxedFromOpioidMaintenanceTherapyRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OpioidMaintenanceTherapy.GraduallyDetoxedFromOpioidMaintenanceTherapy )
                                        .NotNull ();
                                    NewPropertyRule ( () => OpioidMaintenanceTherapyOpioidMaintenanceTherapyReadmissionMedicallyIndicatedRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OpioidMaintenanceTherapy.OpioidMaintenanceTherapyReadmissionMedicallyIndicated )
                                        .NotNull ();
                                    NewPropertyRule ( () => OpioidMaintenanceTherapyToBePrescribedOpioidDetoxificationProtocolRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OpioidMaintenanceTherapy.ToBePrescribedOpioidDetoxificationProtocol )
                                        .NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.Alcohol )
                                 || a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.Barbiturates )
                                 || a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.OtherSedatives ),
                            () =>
                                {
                                    NewPropertyRule ( () => CiwaScaleExperiencedNauseaOrVomitedRecentlyRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CiwaScale.ExperiencedNauseaOrVomitedRecently )
                                        .NotNull ();
                                    NewPropertyRule ( () => CiwaScaleHadDeliriumTremorsInPast24HoursRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CiwaScale.HadDeliriumTremorsInPast24Hours )
                                        .NotNull ();
                                    NewPropertyRule ( () => CiwaScaleHeadAcheOrFullnessSeverityRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CiwaScale.HeadAcheOrFullnessSeverity )
                                        .NotNull ();
                                    NewPropertyRule ( () => CiwaScaleObservedNervousnessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CiwaScale.ObservedNervousness )
                                        .NotNull ();
                                    NewPropertyRule ( () => CiwaScaleObservedSweatingRule ).WithProperty ( a => a.DrugAndAlcoholSection.CiwaScale.ObservedSweating ).NotNull ();
                                    NewPropertyRule ( () => CiwaScaleObservedTactileDisturbancesRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CiwaScale.ObservedTactileDisturbances )
                                        .NotNull ();
                                    NewPropertyRule ( () => CiwaScaleObservedTremorRule ).WithProperty ( a => a.DrugAndAlcoholSection.CiwaScale.ObservedTremor ).NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.Cocaine ),
                            () =>
                            {
                                NewPropertyRule(() => CocaineHasStrongUrgesRule)
                                    .WithProperty(a => a.DrugAndAlcoholSection.CocaineUse.HasStrongUrges)
                                    .NotNull();
                                    NewPropertyRule ( () => CocaineUseExperiencesWithdrawalSicknessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CocaineUse.ExperiencesWithdrawalSickness )
                                        .NotNull ();
                                    NewPropertyRule ( () => CocaineUseLastUsedRule ).WithProperty ( a => a.DrugAndAlcoholSection.CocaineUse.LastUsed ).NotNull ();
                                    NewPropertyRule ( () => CocaineUseNumberOfDaysUsedInPast30DaysRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.CocaineUse.NumberOfDaysUsedInPast30Days )
                                        .NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.CocaineUse.ExperiencesWithdrawalSickness == true, () => NewPropertyRule(() => CocaineUseUseSubstanceToPreventWithdrawalSicknessRule).WithProperty(a => a.DrugAndAlcoholSection.CocaineUse.UseSubstanceToPreventWithdrawalSickness).NotNull());
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Count ( s => s != SubstanceCategory.Alcohol ) > 0,
                            () =>
                                {
                                    NewPropertyRule ( () => DrugConsequencesImportanceOfTreatmentForSubstanceProblemRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.DrugConsequences.ImportanceOfTreatmentForSubstanceProblem )
                                        .NotNull ();
                                    NewPropertyRule ( () => DrugConsequencesNumberOfDaysExperiencedSubstanceProblemsInPast30DaysRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.DrugConsequences.NumberOfDaysExperiencedSubstanceProblemsInPast30Days )
                                        .NotNull ();
                                    NewPropertyRule ( () => DrugConsequencesTroubledInLast30DaysBySubstanceProblemsRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.DrugConsequences.TroubledInLast30DaysBySubstanceProblems )
                                        .NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.Hallucinogens ),
                            () =>
                            {
                                NewPropertyRule(() => HallucinogenHasStrongUrgesRule)
                                    .WithProperty(a => a.DrugAndAlcoholSection.HallucinogenUse.HasStrongUrges)
                                    .NotNull();
                                    NewPropertyRule ( () => HallucinogenUseExperiencesWithdrawalSicknessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.HallucinogenUse.ExperiencesWithdrawalSickness )
                                        .NotNull ();
                                    NewPropertyRule ( () => HallucinogenUseLastUsedRule ).WithProperty ( a => a.DrugAndAlcoholSection.HallucinogenUse.LastUsed ).NotNull ();
                                    NewPropertyRule ( () => HallucinogenUseNumberOfDaysUsedInPast30DaysRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.HallucinogenUse.NumberOfDaysUsedInPast30Days )
                                        .NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.HallucinogenUse.ExperiencesWithdrawalSickness == true, () => NewPropertyRule(() => HallucinogenUseUseSubstanceToPreventWithdrawalSicknessRule).WithProperty(a => a.DrugAndAlcoholSection.HallucinogenUse.UseSubstanceToPreventWithdrawalSickness).NotNull());
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.Heroin ),
                            () =>
                            {
                                NewPropertyRule(() => HeroinHasStrongUrgesRule)
                                    .WithProperty(a => a.DrugAndAlcoholSection.HeroinUse.HasStrongUrges)
                                    .NotNull();
                                    NewPropertyRule ( () => HeroinUseExperiencesWithdrawalSicknessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.HeroinUse.ExperiencesWithdrawalSickness )
                                        .NotNull ();
                                    NewPropertyRule ( () => HeroinUseIncreasedDoseRequiredToGetSameEffectRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.HeroinUse.IncreasedDoseRequiredToGetSameEffect )
                                        .NotNull ();
                                    NewPropertyRule ( () => HeroinUseLastUsedRule ).WithProperty ( a => a.DrugAndAlcoholSection.HeroinUse.LastUsed ).NotNull ();
                                    NewPropertyRule ( () => HeroinUseNumberOfDaysUsedInPast30DaysRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.HeroinUse.NumberOfDaysUsedInPast30Days )
                                        .NotNull ();
                                    NewPropertyRule ( () => HeroinUseNumberOfMonthsUsedInLifetimeRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.HeroinUse.NumberOfMonthsUsedInLifetime )
                                        .NotNull ();
                                    NewPropertyRule ( () => HeroinUseRouteOfIntakeRule ).WithProperty ( a => a.DrugAndAlcoholSection.HeroinUse.RouteOfIntake ).NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.HeroinUse.ExperiencesWithdrawalSickness == true, () => NewPropertyRule(() => HeroinUseUseSubstanceToPreventWithdrawalSicknessRule).WithProperty(a => a.DrugAndAlcoholSection.HeroinUse.UseSubstanceToPreventWithdrawalSickness).NotNull());
            ShouldRunWhen (
                           a =>
                           ( a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.Barbiturates ) &&
                             a.DrugAndAlcoholSection.BarbiturateUse.HasHealthCareProviderPrescribedUse == true ) ,
                           () => NewPropertyRule ( () => InterviewerEvaluationHasMaintainedBarbituatesDoseAtTherapeuticLevelsRule )
                                     .WithProperty ( a => a.DrugAndAlcoholSection.InterviewerEvaluation.HasMaintainedBarbituatesDoseAtTherapeuticLevels )
                                     .NotNull () );
            ShouldRunWhen(
                           a =>
                           (a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any(s => s == SubstanceCategory.OtherSedatives) &&
                             a.DrugAndAlcoholSection.OtherSedativeUse.HasHealthCareProviderPrescribedUse == true),
                           () => NewPropertyRule(() => InterviewerEvaluationHasMaintainedSedativeDoseAtTherapeuticLevelsRule)
                                     .WithProperty(a => a.DrugAndAlcoholSection.InterviewerEvaluation.HasMaintainedSedativeDoseAtTherapeuticLevels)
                                     .NotNull() );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.Methadone ),
                            () =>
                            {
                                NewPropertyRule(() => MethadoneHasStrongUrgesRule)
                                    .WithProperty(a => a.DrugAndAlcoholSection.MethadoneUse.HasStrongUrges)
                                    .NotNull();
                                    NewPropertyRule ( () => MethadoneUseExperiencesWithdrawalSicknessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.MethadoneUse.ExperiencesWithdrawalSickness )
                                        .NotNull ();
                                    NewPropertyRule ( () => MethadoneUseIncreasedDoseRequiredToGetSameEffectRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.MethadoneUse.IncreasedDoseRequiredToGetSameEffect )
                                        .NotNull ();
                                    NewPropertyRule ( () => MethadoneUseLastUsedRule ).WithProperty ( a => a.DrugAndAlcoholSection.MethadoneUse.LastUsed ).NotNull ();
                                    NewPropertyRule ( () => MethadoneUseNumberOfDaysUsedInPast30DaysRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.MethadoneUse.NumberOfDaysUsedInPast30Days )
                                        .NotNull ();
                                    NewPropertyRule ( () => MethadoneUseNumberOfMonthsUsedInLifetimeRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.MethadoneUse.NumberOfMonthsUsedInLifetime )
                                        .NotNull ();
                                    NewPropertyRule ( () => MethadoneUseRouteOfIntakeRule ).WithProperty ( a => a.DrugAndAlcoholSection.MethadoneUse.RouteOfIntake ).NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.MethadoneUse.ExperiencesWithdrawalSickness == true, () => NewPropertyRule(() => MethadoneUseUseSubstanceToPreventWithdrawalSicknessRule).WithProperty(a => a.DrugAndAlcoholSection.MethadoneUse.UseSubstanceToPreventWithdrawalSickness).NotNull());
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.MethadoneUse.HasHealthCareProviderPrescribedUse == true, () => NewPropertyRule(() => MethadoneUseWasSubstanceTakenAsPrescribedRule).WithProperty(a => a.DrugAndAlcoholSection.MethadoneUse.WasSubstanceTakenAsPrescribed).NotNull());
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.MultiplePerDay ),
                            () =>
                                {
                                    NewPropertyRule ( () => MultipleSubstanceUsePerDayLastUsedRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.MultipleSubstanceUsePerDay.LastUsed )
                                        .NotNull ();
                                    NewPropertyRule ( () => MultipleSubstanceUsePerDayNumberOfDaysUsedInPast30DaysRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.MultipleSubstanceUsePerDay.NumberOfDaysUsedInPast30Days )
                                        .NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.Nicotine ),
                            () =>
                            {
                                NewPropertyRule(() => NicotineHasStrongUrgesRule)
                                    .WithProperty(a => a.DrugAndAlcoholSection.NicotineUse.HasStrongUrges)
                                    .NotNull();
                                    NewPropertyRule ( () => NicotineUseExperiencesWithdrawalSicknessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.NicotineUse.ExperiencesWithdrawalSickness )
                                        .NotNull ();
                                    NewPropertyRule ( () => NicotineUseHasUsedSubstanceKnowingProblemsWorsenedRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.NicotineUse.HasUsedSubstanceKnowingProblemsWorsened )
                                        .NotNull ();
                                    NewPropertyRule ( () => NicotineUseLastUsedRule ).WithProperty ( a => a.DrugAndAlcoholSection.NicotineUse.LastUsed ).NotNull ();
                                    NewPropertyRule ( () => NicotineUseNumberOfDaysUsedInPast30DaysRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.NicotineUse.NumberOfDaysUsedInPast30Days )
                                        .NotNull ();
                                    NewPropertyRule ( () => NicotineUseSubstanceUseReductionAttemptedRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.NicotineUse.SubstanceUseReductionAttempted )
                                        .NotNull ();
                                    NewPropertyRule ( () => NicotineUseUnableToStopUsingSubstanceRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.NicotineUse.UnableToStopUsingSubstance )
                                        .NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.NicotineUse.ExperiencesWithdrawalSickness == true, () => NewPropertyRule(() => NicotineUseUseSubstanceToPreventWithdrawalSicknessRule).WithProperty(a => a.DrugAndAlcoholSection.NicotineUse.UseSubstanceToPreventWithdrawalSickness).NotNull());
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.OtherOpiate ),
                            () =>
                            {
                                NewPropertyRule(() => OtherOpiateHasStrongUrgesRule)
                                    .WithProperty(a => a.DrugAndAlcoholSection.OtherOpiateUse.HasStrongUrges)
                                    .NotNull();
                                    NewPropertyRule ( () => OtherOpiateUseDocumentedEvidenceOfOpioidDependenceAtLeast1YearRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OtherOpiateUse.DocumentedEvidenceOfOpioidDependenceAtLeast1Year )
                                        .NotNull ();
                                    NewPropertyRule ( () => OtherOpiateUseEvidenceFromUrineScreenOfOpioidDependenceRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OtherOpiateUse.EvidenceFromUrineScreenOfOpioidDependence )
                                        .NotNull ();
                                    NewPropertyRule ( () => OtherOpiateUseExperiencesWithdrawalSicknessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OtherOpiateUse.ExperiencesWithdrawalSickness )
                                        .NotNull ();
                                    NewPropertyRule ( () => OtherOpiateUseIncreasedDoseRequiredToGetSameEffectRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OtherOpiateUse.IncreasedDoseRequiredToGetSameEffect )
                                        .NotNull ();
                                    NewPropertyRule ( () => OtherOpiateUseLastUsedRule ).WithProperty ( a => a.DrugAndAlcoholSection.OtherOpiateUse.LastUsed ).NotNull ();
                                    NewPropertyRule ( () => OtherOpiateUseNumberOfDaysUsedInPast30DaysRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OtherOpiateUse.NumberOfDaysUsedInPast30Days )
                                        .NotNull ();
                                    NewPropertyRule ( () => OtherOpiateUseNumberOfMonthsUsedInLifetimeRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OtherOpiateUse.NumberOfMonthsUsedInLifetime )
                                        .NotNull ();
                                    NewPropertyRule ( () => OtherOpiateUseOpioidRelapseLikelyIndicatorRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OtherOpiateUse.OpioidRelapseLikelyIndicator )
                                        .NotNull ();
                                    NewPropertyRule ( () => OtherOpiateUseRouteOfIntakeRule ).WithProperty ( a => a.DrugAndAlcoholSection.OtherOpiateUse.RouteOfIntake ).NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.OtherOpiateUse.ExperiencesWithdrawalSickness == true, () => NewPropertyRule(() => OtherOpiateUseUseSubstanceToPreventWithdrawalSicknessRule).WithProperty(a => a.DrugAndAlcoholSection.OtherOpiateUse.UseSubstanceToPreventWithdrawalSickness).NotNull());
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.OtherOpiateUse.HasHealthCareProviderPrescribedUse == true, () => NewPropertyRule(() => OtherOpiateUseWasSubstanceTakenAsPrescribedRule).WithProperty(a => a.DrugAndAlcoholSection.OtherOpiateUse.WasSubstanceTakenAsPrescribed).NotNull());
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.OtherSedatives ),
                            () =>
                            {
                                NewPropertyRule(() => OtherSedativeHasStrongUrgesRule)
                                    .WithProperty(a => a.DrugAndAlcoholSection.OtherSedativeUse.HasStrongUrges)
                                    .NotNull();
                                    NewPropertyRule ( () => OtherSedativeUseExperiencesWithdrawalSicknessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OtherSedativeUse.ExperiencesWithdrawalSickness )
                                        .NotNull ();
                                    NewPropertyRule ( () => OtherSedativeUseHasHealthCareProviderPrescribedUseRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OtherSedativeUse.HasHealthCareProviderPrescribedUse )
                                        .NotNull ();
                                    NewPropertyRule ( () => OtherSedativeUseLastUsedRule ).WithProperty ( a => a.DrugAndAlcoholSection.OtherSedativeUse.LastUsed ).NotNull ();
                                    NewPropertyRule ( () => OtherSedativeUseNumberOfDaysUsedInPast30DaysRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OtherSedativeUse.NumberOfDaysUsedInPast30Days )
                                        .NotNull ();
                                    NewPropertyRule ( () => OtherSedativeUseNumberOfMonthsUsedInLifetimeRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OtherSedativeUse.NumberOfMonthsUsedInLifetime )
                                        .NotNull ();
                                    NewPropertyRule ( () => OtherSedativeUseUnableToStopUsingSubstanceRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OtherSedativeUse.UnableToStopUsingSubstance )
                                        .NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.OtherSedativeUse.ExperiencesWithdrawalSickness == true, () => NewPropertyRule(() => OtherSedativeUseUseSubstanceToPreventWithdrawalSicknessRule).WithProperty(a => a.DrugAndAlcoholSection.OtherSedativeUse.UseSubstanceToPreventWithdrawalSickness).NotNull());
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.OtherSedativeUse.HasHealthCareProviderPrescribedUse == true, () => NewPropertyRule(() => OtherSedativeUseWasSubstanceTakenAsPrescribedRule).WithProperty(a => a.DrugAndAlcoholSection.OtherSedativeUse.WasSubstanceTakenAsPrescribed).NotNull());
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.OtherSubstance ),
                            () =>
                            {
                                NewPropertyRule(() => OtherSubstanceHasStrongUrgesRule)
                                    .WithProperty(a => a.DrugAndAlcoholSection.OtherSubstanceUse.HasStrongUrges)
                                    .NotNull();
                                    NewPropertyRule ( () => OtherSubstanceUseExperiencesWithdrawalSicknessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OtherSubstanceUse.ExperiencesWithdrawalSickness )
                                        .NotNull ();
                                    NewPropertyRule ( () => OtherSubstanceUseLastUsedRule ).WithProperty ( a => a.DrugAndAlcoholSection.OtherSubstanceUse.LastUsed ).NotNull ();
                                    NewPropertyRule ( () => OtherSubstanceUseOtherSubstanceNameRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.OtherSubstanceUse.OtherSubstanceName )
                                        .NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.OtherSubstanceUse.ExperiencesWithdrawalSickness == true, () => NewPropertyRule(() => OtherSubstanceUseUseSubstanceToPreventWithdrawalSicknessRule).WithProperty(a => a.DrugAndAlcoholSection.OtherSubstanceUse.UseSubstanceToPreventWithdrawalSickness).NotNull());
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any ( s => s == SubstanceCategory.SolventInhalants ),
                            () =>
                            {
                                NewPropertyRule(() => SovlentAndInhalantHasStrongUrgesRule)
                                    .WithProperty(a => a.DrugAndAlcoholSection.SolventAndInhalantUse.HasStrongUrges)
                                    .NotNull();
                                    NewPropertyRule ( () => SolventAndInhalantUseExperiencesWithdrawalSicknessRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.SolventAndInhalantUse.ExperiencesWithdrawalSickness )
                                        .NotNull ();
                                    NewPropertyRule ( () => SolventAndInhalantUseLastUsedRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.SolventAndInhalantUse.LastUsed )
                                        .NotNull ();
                                    NewPropertyRule ( () => SolventAndInhalantUseNumberOfDaysUsedInPast30DaysRule )
                                        .WithProperty ( a => a.DrugAndAlcoholSection.SolventAndInhalantUse.NumberOfDaysUsedInPast30Days )
                                        .NotNull ();
                                } );
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.SolventAndInhalantUse.ExperiencesWithdrawalSickness == true, () => NewPropertyRule(() => SolventAndInhalantUseUseSubstanceToPreventWithdrawalSicknessRule).WithProperty(a => a.DrugAndAlcoholSection.SolventAndInhalantUse.UseSubstanceToPreventWithdrawalSickness).NotNull());
            ShouldRunWhen ( a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Any( s => s == SubstanceCategory.Stimulants), () =>
            {
                NewPropertyRule(() => StimulantHasStrongUrgesRule)
                    .WithProperty(a => a.DrugAndAlcoholSection.StimulantUse.HasStrongUrges)
                    .NotNull();
                NewPropertyRule ( () => StimulantUseExperiencesWithdrawalSicknessRule )
                    .WithProperty ( a => a.DrugAndAlcoholSection.StimulantUse.ExperiencesWithdrawalSickness )
                    .NotNull ();
                NewPropertyRule(() => StimulantUseLastUsedRule).WithProperty(a => a.DrugAndAlcoholSection.StimulantUse.LastUsed).NotNull();
                NewPropertyRule(() => StimulantUseNumberOfDaysUsedInPast30DaysRule).WithProperty(a => a.DrugAndAlcoholSection.StimulantUse.NumberOfDaysUsedInPast30Days).NotNull();
            });
            ShouldRunWhen(a => a.DrugAndAlcoholSection.StimulantUse.ExperiencesWithdrawalSickness == true, () => NewPropertyRule(() => StimulantUseUseSubstanceToPreventWithdrawalSicknessRule).WithProperty(a => a.DrugAndAlcoholSection.StimulantUse.UseSubstanceToPreventWithdrawalSickness).NotNull());
            NewPropertyRule(() => UsedSubstancesSubstanceHasEverUsedRule).WithProperty(a => a.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed).NotNull();
            NewPropertyRule(() => EmploymentAndSupportSectionAmountOfMoneyInPast30DaysFromEmploymentRule).WithProperty(a => a.EmploymentAndSupportSection.AmountOfMoneyInPast30DaysFromEmployment).NotNull();
            NewPropertyRule(() => EmploymentAndSupportSectionAmountOfMoneyInPast30DaysFromIllegalMeansRule).WithProperty(a => a.EmploymentAndSupportSection.AmountOfMoneyInPast30DaysFromIllegalMeans).NotNull();
            NewPropertyRule(() => EmploymentAndSupportSectionConcernAboutEmploymentProblemsInPast30DaysRule).WithProperty(a => a.EmploymentAndSupportSection.ConcernAboutEmploymentProblemsInPast30Days).NotNull();
            NewPropertyRule(() => EmploymentAndSupportSectionHasAutomobileAvailableForUseRule).WithProperty(a => a.EmploymentAndSupportSection.HasAutomobileAvailableForUse).NotNull();
            NewPropertyRule(() => EmploymentAndSupportSectionHasValidDriversLicenseRule).WithProperty(a => a.EmploymentAndSupportSection.HasValidDriversLicense).NotNull();
            NewPropertyRule(() => EmploymentAndSupportSectionNumberOfDaysWorkingInPast30DaysRule).WithProperty(a => a.EmploymentAndSupportSection.NumberOfDaysWorkingInPast30Days).NotNull();
            NewPropertyRule(() => EmploymentAndSupportSectionNumberOfDependentsRule).WithProperty(a => a.EmploymentAndSupportSection.NumberOfDependents).NotNull();
            NewPropertyRule(() => EmploymentAndSupportSectionWorkOrSchoolAffectOnRecoveryRule).WithProperty(a => a.EmploymentAndSupportSection.WorkOrSchoolAffectOnRecovery).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionClosestContactsNeedsAndWillingnessToHelpTreatmentRule).WithProperty(a => a.FamilyAndSocialHistorySection.ClosestContactsNeedsAndWillingnessToHelpTreatment).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionClosestPersonalContactInPast4MonthsRule).WithProperty(a => a.FamilyAndSocialHistorySection.ClosestPersonalContactInPast4Months).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionDealsWithProblemsFromFriendsThatRiskRelapseRule).WithProperty(a => a.FamilyAndSocialHistorySection.DealsWithProblemsFromFriendsThatRiskRelapse).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionDealsWithProblemsInFreeTimeThatRiskRelapseRule).WithProperty(a => a.FamilyAndSocialHistorySection.DealsWithProblemsInFreeTimeThatRiskRelapse).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionEmotionalAbuseInPast30DaysRule).WithProperty(a => a.FamilyAndSocialHistorySection.EmotionalAbuseInPast30Days).NotNull();
            ShouldRunWhen ( a => a.FamilyAndSocialHistorySection.HasRecentlyNeglectedOrAbusedFamilyMembers > LikertScale.NotAtAll, () => NewPropertyRule(() => FamilyAndSocialHistorySectionFamilyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_IIRule).WithProperty(a => a.FamilyAndSocialHistorySection.FamilyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II).NotNull());
            NewPropertyRule(() => FamilyAndSocialHistorySectionFreeTimeAffectOnRecoveryRule).WithProperty(a => a.FamilyAndSocialHistorySection.FreeTimeAffectOnRecovery).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionFriendsAffectOnRecoveryRule).WithProperty(a => a.FamilyAndSocialHistorySection.FriendsAffectOnRecovery).NotNull();
            ShouldRunWhen ( a => a.FamilyAndSocialHistorySection.HadProblemsInLifetimeWithChildren == YesNoNotApplicable.Yes, () => NewPropertyRule(() => FamilyAndSocialHistorySectionHadProblemsInPastMonthWithChildrenRule).WithProperty(a => a.FamilyAndSocialHistorySection.HadProblemsInPastMonthWithChildren).NotNull());
            ShouldRunWhen ( a => a.FamilyAndSocialHistorySection.HadProblemsInLifetimeWithCloseFriends == YesNoNotApplicable.Yes, () => NewPropertyRule(() => FamilyAndSocialHistorySectionHadProblemsInPastMonthWithCloseFriendsRule).WithProperty(a => a.FamilyAndSocialHistorySection.HadProblemsInPastMonthWithCloseFriends).NotNull());
            ShouldRunWhen ( a => a.FamilyAndSocialHistorySection.HadProblemsInLifetimeWithCoworkers == YesNoNotApplicable.Yes, () => NewPropertyRule(() => FamilyAndSocialHistorySectionHadProblemsInPastMonthWithCoworkersRule).WithProperty(a => a.FamilyAndSocialHistorySection.HadProblemsInPastMonthWithCoworkers).NotNull());
            ShouldRunWhen ( a => a.FamilyAndSocialHistorySection.HadProblemsInLifetimeWithFather == YesNoNotApplicable.Yes, () => NewPropertyRule(() => FamilyAndSocialHistorySectionHadProblemsInPastMonthWithFatherRule).WithProperty(a => a.FamilyAndSocialHistorySection.HadProblemsInPastMonthWithFather).NotNull());
            ShouldRunWhen ( a => a.FamilyAndSocialHistorySection.HadProblemsInLifetimeWithMother == YesNoNotApplicable.Yes, () => NewPropertyRule(() => FamilyAndSocialHistorySectionHadProblemsInPastMonthWithMotherRule).WithProperty(a => a.FamilyAndSocialHistorySection.HadProblemsInPastMonthWithMother).NotNull());
            ShouldRunWhen ( a => a.FamilyAndSocialHistorySection.HadProblemsInLifetimeWithNeighbors == YesNoNotApplicable.Yes, () => NewPropertyRule(() => FamilyAndSocialHistorySectionHadProblemsInPastMonthWithNeighborsRule).WithProperty(a => a.FamilyAndSocialHistorySection.HadProblemsInPastMonthWithNeighbors).NotNull());
            ShouldRunWhen ( a => a.FamilyAndSocialHistorySection.HadProblemsInLifetimeWithOtherFamily == YesNoNotApplicable.Yes, () => NewPropertyRule(() => FamilyAndSocialHistorySectionHadProblemsInPastMonthWithOtherFamilyRule).WithProperty(a => a.FamilyAndSocialHistorySection.HadProblemsInPastMonthWithOtherFamily).NotNull());
            ShouldRunWhen ( a => a.FamilyAndSocialHistorySection.HadProblemsInLifetimeWithSexPartner == YesNoNotApplicable.Yes, () => NewPropertyRule(() => FamilyAndSocialHistorySectionHadProblemsInPastMonthWithSexPartnerRule).WithProperty(a => a.FamilyAndSocialHistorySection.HadProblemsInPastMonthWithSexPartner).NotNull());
            ShouldRunWhen ( a => a.FamilyAndSocialHistorySection.HadProblemsInLifetimeWithSibling == YesNoNotApplicable.Yes, () => NewPropertyRule(() => FamilyAndSocialHistorySectionHadProblemsInPastMonthWithSiblingRule).WithProperty(a => a.FamilyAndSocialHistorySection.HadProblemsInPastMonthWithSibling).NotNull());
            NewPropertyRule(() => FamilyAndSocialHistorySectionHasRecentlyNeglectedOrAbusedFamilyMembersRule).WithProperty(a => a.FamilyAndSocialHistorySection.HasRecentlyNeglectedOrAbusedFamilyMembers).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionHowLikelyToCauseHarmNeglectOthersRule).WithProperty(a => a.FamilyAndSocialHistorySection.HowLikelyToCauseHarmNeglectOthers).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionImportanceOfTreatmentForFamilyMembersRule).WithProperty(a => a.FamilyAndSocialHistorySection.ImportanceOfTreatmentForFamilyMembers).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionIsAbleToLocateAndGetToCommunityResourcesSafelyRule).WithProperty(a => a.FamilyAndSocialHistorySection.IsAbleToLocateAndGetToCommunityResourcesSafely).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionIsOutpatientMonitoringAvailable8To24HoursRule).WithProperty(a => a.FamilyAndSocialHistorySection.IsOutpatientMonitoringAvailable8To24Hours).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionIsPatientAvailableForFollowupFor7DaysRule).WithProperty(a => a.FamilyAndSocialHistorySection.IsPatientAvailableForFollowupFor7Days).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionIsSupportPersonAvailableFor7DaysRule).WithProperty(a => a.FamilyAndSocialHistorySection.IsSupportPersonAvailableFor7Days).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionLivingArrangementAffectOnRecoveryRule).WithProperty(a => a.FamilyAndSocialHistorySection.LivingArrangementAffectOnRecovery).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionNeedForStaffSupportToMaintainRecoveryRule).WithProperty(a => a.FamilyAndSocialHistorySection.NeedForStaffSupportToMaintainRecovery).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionNumberOfCloseFriendsRule).WithProperty(a => a.FamilyAndSocialHistorySection.NumberOfCloseFriends).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionPhysicalAbuseInPast30DaysRule).WithProperty(a => a.FamilyAndSocialHistorySection.PhysicalAbuseInPast30Days).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionRiskPatientHarmedByOtherRule).WithProperty(a => a.FamilyAndSocialHistorySection.RiskPatientHarmedByOther).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionSatisfiedWithThisSituationRule).WithProperty(a => a.FamilyAndSocialHistorySection.SatisfiedWithThisSituation).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionSeriousConflictsWithFamilyInPast30DaysRule).WithProperty(a => a.FamilyAndSocialHistorySection.SeriousConflictsWithFamilyInPast30Days).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionSexualAbuseInPast30DaysRule).WithProperty(a => a.FamilyAndSocialHistorySection.SexualAbuseInPast30Days).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionSpendsFreeTimeWithRule).WithProperty(a => a.FamilyAndSocialHistorySection.SpendsFreeTimeWith).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionTroubledByFamilyProblemsInPast30DaysRule).WithProperty(a => a.FamilyAndSocialHistorySection.TroubledByFamilyProblemsInPast30Days).NotNull();
            NewPropertyRule(() => FamilyAndSocialHistorySectionTroubledBySocialProblemsInPast30DaysRule).WithProperty(a => a.FamilyAndSocialHistorySection.TroubledBySocialProblemsInPast30Days).NotNull();
            NewPropertyRule(() => GeneralInformationSectionAssessmentClassRule).WithProperty(a => a.GeneralInformationSection.AssessmentClass).NotNull();
            NewPropertyRule(() => GeneralInformationSectionInPenalOrChronicCareSettingRecentlyRule).WithProperty(a => a.GeneralInformationSection.InPenalOrChronicCareSettingRecently).NotNull();
            NewPropertyRule(() => GeneralInformationSectionInterviewCircumstancesRule).WithProperty(a => a.GeneralInformationSection.InterviewCircumstances).NotNull();
            NewPropertyRule(() => GeneralInformationSectionInterviewMethodRule).WithProperty(a => a.GeneralInformationSection.InterviewMethod).NotNull();
            NewPropertyRule(() => LegalSectionDesireAndExternalFactorsDrivingTreatmentRule).WithProperty(a => a.LegalSection.DesireAndExternalFactorsDrivingTreatment).NotNull();
            NewPropertyRule(() => LegalSectionImportanceOfCounselingForCurrentLegalProblemsRule).WithProperty(a => a.LegalSection.ImportanceOfCounselingForCurrentLegalProblems).NotNull();
            NewPropertyRule(() => LegalSectionIsCurrentlyAwaitingChargesTrialSentenceRule).WithProperty(a => a.LegalSection.IsCurrentlyAwaitingChargesTrialSentence).NotNull();
            NewPropertyRule(() => LegalSectionIsOnProbationOrParoleRule).WithProperty(a => a.LegalSection.IsOnProbationOrParole).NotNull();
            NewPropertyRule(() => LegalSectionNumberOfDaysCommitingCrimesForProfitInPast30DaysRule).WithProperty(a => a.LegalSection.NumberOfDaysCommitingCrimesForProfitInPast30Days).NotNull();
            NewPropertyRule(() => LegalSectionNumberOfTimesArrestedForArsonRule).WithProperty(a => a.LegalSection.NumberOfTimesArrestedForArson).NotNull();
            NewPropertyRule(() => LegalSectionNumberOfTimesArrestedForAssaultRule).WithProperty(a => a.LegalSection.NumberOfTimesArrestedForAssault).NotNull();
            NewPropertyRule(() => LegalSectionNumberOfTimesArrestedForBurglaryLarcenyRule).WithProperty(a => a.LegalSection.NumberOfTimesArrestedForBurglaryLarceny).NotNull();
            NewPropertyRule(() => LegalSectionNumberOfTimesArrestedForContemptOfCourtRule).WithProperty(a => a.LegalSection.NumberOfTimesArrestedForContemptOfCourt).NotNull();
            NewPropertyRule(() => LegalSectionNumberOfTimesArrestedForDrugChargesRule).WithProperty(a => a.LegalSection.NumberOfTimesArrestedForDrugCharges).NotNull();
            NewPropertyRule(() => LegalSectionNumberOfTimesArrestedForForgeryRule).WithProperty(a => a.LegalSection.NumberOfTimesArrestedForForgery).NotNull();
            NewPropertyRule(() => LegalSectionNumberOfTimesArrestedForHomicideRule).WithProperty(a => a.LegalSection.NumberOfTimesArrestedForHomicide).NotNull();
            NewPropertyRule(() => LegalSectionNumberOfTimesArrestedForOtherArrestRule).WithProperty(a => a.LegalSection.NumberOfTimesArrestedForOtherArrest).NotNull();
            NewPropertyRule(() => LegalSectionNumberOfTimesArrestedForParoleProbationViolationRule).WithProperty(a => a.LegalSection.NumberOfTimesArrestedForParoleProbationViolation).NotNull();
            NewPropertyRule(() => LegalSectionNumberOfTimesArrestedForProstitutionRule).WithProperty(a => a.LegalSection.NumberOfTimesArrestedForProstitution).NotNull();
            NewPropertyRule(() => LegalSectionNumberOfTimesArrestedForRapeRule).WithProperty(a => a.LegalSection.NumberOfTimesArrestedForRape).NotNull();
            NewPropertyRule(() => LegalSectionNumberOfTimesArrestedForRobberyRule).WithProperty(a => a.LegalSection.NumberOfTimesArrestedForRobbery).NotNull();
            NewPropertyRule(() => LegalSectionNumberOfTimesArrestedForShopliftingVandalismRule).WithProperty(a => a.LegalSection.NumberOfTimesArrestedForShopliftingVandalism).NotNull();
            NewPropertyRule(() => LegalSectionNumberOfTimesArrestedForWeaponsOffenseRule).WithProperty(a => a.LegalSection.NumberOfTimesArrestedForWeaponsOffense).NotNull();
            ShouldRunWhen ( a => a.LegalSection.NumberOfTimesArrestedForArson > 0 ||
                                 a.LegalSection.NumberOfTimesArrestedForAssault > 0 ||
                                 a.LegalSection.NumberOfTimesArrestedForBurglaryLarceny > 0 ||
                                 a.LegalSection.NumberOfTimesArrestedForContemptOfCourt > 0 ||
                                 a.LegalSection.NumberOfTimesArrestedForDrugCharges > 0 ||
                                 a.LegalSection.NumberOfTimesArrestedForForgery > 0 ||
                                 a.LegalSection.NumberOfTimesArrestedForHomicide > 0 ||
                                 a.LegalSection.NumberOfTimesArrestedForOtherArrest > 0 ||
                                 a.LegalSection.NumberOfTimesArrestedForParoleProbationViolation > 0 ||
                                 a.LegalSection.NumberOfTimesArrestedForProstitution > 0 ||
                                 a.LegalSection.NumberOfTimesArrestedForRape > 0 ||
                                 a.LegalSection.NumberOfTimesArrestedForRobbery > 0 ||
                                 a.LegalSection.NumberOfTimesArrestedForShopliftingVandalism > 0,
                            () =>
                            NewPropertyRule ( () => LegalSectionNumberOfTimesConvictedRule ).WithProperty ( a => a.LegalSection.NumberOfTimesConvicted ).NotNull () );
            NewPropertyRule(() => LegalSectionSeverityOfCurrentLegalProblemsRule).WithProperty(a => a.LegalSection.SeverityOfCurrentLegalProblems).NotNull();
            NewPropertyRule(() => LegalSectionWasVisitPromptedByCriminalJusticeSystemRule).WithProperty(a => a.LegalSection.WasVisitPromptedByCriminalJusticeSystem).NotNull();
            NewPropertyRule(() => MedicalSectionAuditoryDisturbanceLevelRule).WithProperty(a => a.MedicalSection.AuditoryDisturbanceLevel).NotNull();
            NewPropertyRule(() => MedicalSectionBloodPressureRule).WithProperty(a => a.MedicalSection.BloodPressure).NotNull();
            NewPropertyRule(() => MedicalSectionExperiencedAcuteAlcoholDisulfiramReactionInPast24HoursStatusRule).WithProperty(a => a.MedicalSection.ExperiencedAcuteAlcoholDisulfiramReactionInPast24HoursStatus).NotNull();
            NewPropertyRule(() => MedicalSectionFeverOf102DegreesOrMoreInPast24HoursRule).WithProperty(a => a.MedicalSection.FeverOf102DegreesOrMoreInPast24Hours).NotNull();
            NewPropertyRule(() => MedicalSectionHeartRateRule).WithProperty(a => a.MedicalSection.HeartRate).NotNull();
            ShouldRunWhen ( a => a.MedicalSection.PregnantStatus == YesNoNotSure.Yes,
                            () => NewPropertyRule ( () => MedicalSectionHighRiskPregnancyStatusRule ).WithProperty ( a => a.MedicalSection.HighRiskPregnancyStatus ).NotNull () );
            NewPropertyRule(() => MedicalSectionHivAidsMedicalTreatmentStatusRule).WithProperty(a => a.MedicalSection.HivAidsMedicalTreatmentStatus).NotNull();
            NewPropertyRule(() => MedicalSectionInterviewerObservationOfPatientAgitationLevelRule).WithProperty(a => a.MedicalSection.InterviewerObservationOfPatientAgitationLevel).NotNull();
            NewPropertyRule(() => MedicalSectionInterviewerObservationOfPatientSenseOfAwarenessRule).WithProperty(a => a.MedicalSection.InterviewerObservationOfPatientSenseOfAwareness).NotNull();
            NewPropertyRule(() => MedicalSectionInterviewerRatingOfPatientNeedForMedicalTreatmentRule).WithProperty(a => a.MedicalSection.InterviewerRatingOfPatientNeedForMedicalTreatment).NotNull();
            ShouldRunWhen(a => a.MedicalSection.MultipleSeriousMedicalProblemsExist == YesNoNotSure.Yes,
                          () =>
                              {
                                  NewPropertyRule ( () => MedicalSectionLevelOfConcernInPast30DaysAboutMedicalProblemsRule )
                                      .WithProperty ( a => a.MedicalSection.LevelOfConcernInPast30DaysAboutMedicalProblems )
                                      .NotNull ();
                                  NewPropertyRule ( () => MedicalSectionImportanceOfTreatmentForMedicalProblemsRule )
                                      .WithProperty ( a => a.MedicalSection.ImportanceOfTreatmentForMedicalProblems )
                                      .NotNull ();
                              } );
            NewPropertyRule(() => MedicalSectionLostConsciousnessFromHeadTraumaInPast24HoursRule).WithProperty(a => a.MedicalSection.LostConsciousnessFromHeadTraumaInPast24Hours).NotNull();
            NewPropertyRule(() => MedicalSectionMayRequireInpatientAcutePancreatitisTreatmentRule).WithProperty(a => a.MedicalSection.MayRequireInpatientAcutePancreatitisTreatment).NotNull();
            NewPropertyRule(() => MedicalSectionMayRequireInpatientGastrointestinalBleedingTreatmentRule).WithProperty(a => a.MedicalSection.MayRequireInpatientGastrointestinalBleedingTreatment).NotNull();
            NewPropertyRule(() => MedicalSectionMayRequireInpatientLiverTreatmentRule).WithProperty(a => a.MedicalSection.MayRequireInpatientLiverTreatment).NotNull();
            NewPropertyRule(() => MedicalSectionMedicalProblemThatWouldComplicateDetoxificationStatusRule).WithProperty(a => a.MedicalSection.MedicalProblemThatWouldComplicateDetoxificationStatus).NotNull();
            NewPropertyRule(() => MedicalSectionMobilityProblemsMayAffectTreatmentAttendanceRule).WithProperty(a => a.MedicalSection.MobilityProblemsMayAffectTreatmentAttendance).NotNull();
            ShouldRunWhen ( a => a.MedicalSection.SeizureInPast24Hours == YesNoNotSure.Yes,
                            () =>
                            NewPropertyRule ( () => MedicalSectionMultipleSeizuresInPast24HoursRule )
                                .WithProperty ( a => a.MedicalSection.MultipleSeizuresInPast24Hours )
                                .NotNull () );
            NewPropertyRule(() => MedicalSectionMultipleSeriousMedicalProblemsExistRule).WithProperty(a => a.MedicalSection.MultipleSeriousMedicalProblemsExist).NotNull();
            NewPropertyRule(() => MedicalSectionNeedForMedicalOrPhysicalRehabilitationRule).WithProperty(a => a.MedicalSection.NeedForMedicalOrPhysicalRehabilitation).NotNull();
            NewPropertyRule(() => MedicalSectionNumberOfDaysWithMedicalProblemsInPast30DaysRule).WithProperty(a => a.MedicalSection.NumberOfDaysWithMedicalProblemsInPast30Days).NotNull();
            NewPropertyRule(() => MedicalSectionPhysicalHealthsEffectOnSubstanceProblemsRule).WithProperty(a => a.MedicalSection.PhysicalHealthsEffectOnSubstanceProblems).NotNull();
            ShouldRunWhen ( a => a.Patient.Gender == Gender.Female,
                            () => NewPropertyRule ( () => MedicalSectionPregnantStatusRule ).WithProperty ( a => a.MedicalSection.PregnantStatus ).NotNull ());
            NewPropertyRule(() => MedicalSectionRequiresInpatientCardiacMonitoringRule).WithProperty(a => a.MedicalSection.RequiresInpatientCardiacMonitoring).NotNull();
            NewPropertyRule(() => MedicalSectionRequiresMedicalMonitoringForReemergenceOfSymptomsRule).WithProperty(a => a.MedicalSection.RequiresMedicalMonitoringForReemergenceOfSymptoms).NotNull();
            NewPropertyRule(() => MedicalSectionSeizureInPast24HoursRule).WithProperty(a => a.MedicalSection.SeizureInPast24Hours).NotNull();
            NewPropertyRule(() => MedicalSectionSexuallyTransmittedDiseaseStatusRule).WithProperty(a => a.MedicalSection.SexuallyTransmittedDiseaseStatus).NotNull();
            NewPropertyRule(() => MedicalSectionSignsOfIntoxicationExistRule).WithProperty(a => a.MedicalSection.SignsOfIntoxicationExist).NotNull();
            NewPropertyRule(() => MedicalSectionSignsOfToxicPsychosisExistRule).WithProperty(a => a.MedicalSection.SignsOfToxicPsychosisExist).NotNull();
            NewPropertyRule(() => MedicalSectionSufferedHeadTraumaInPast48HoursRule).WithProperty(a => a.MedicalSection.SufferedHeadTraumaInPast48Hours).NotNull();
            NewPropertyRule(() => MedicalSectionSufferedSeriousImpairmentFromOverdoseInPast24HoursRule).WithProperty(a => a.MedicalSection.SufferedSeriousImpairmentFromOverdoseInPast24Hours).NotNull();
            NewPropertyRule(() => MedicalSectionTuberculosisInfectionStatusRule).WithProperty(a => a.MedicalSection.TuberculosisInfectionStatus).NotNull();
            NewPropertyRule(() => MedicalSectionUnsteadinessOrLossOfBalanceRule).WithProperty(a => a.MedicalSection.UnsteadinessOrLossOfBalance).NotNull();
            NewPropertyRule(() => MedicalSectionVisualDisturbanceLevelRule).WithProperty(a => a.MedicalSection.VisualDisturbanceLevel).NotNull();
            NewPropertyRule(() => DepressionEvaluationObservedRetardationOfThoughtOrSpeechRule).WithProperty(a => a.PsychologicalSection.DepressionEvaluation.ObservedRetardationOfThoughtOrSpeech).NotNull();
            NewPropertyRule(() => DepressionEvaluationRangeOfEnergyInPastWeekRule).WithProperty(a => a.PsychologicalSection.DepressionEvaluation.RangeOfEnergyInPastWeek).NotNull();
            NewPropertyRule(() => DepressionEvaluationRangeOfGuiltInPastWeekRule).WithProperty(a => a.PsychologicalSection.DepressionEvaluation.RangeOfGuiltInPastWeek).NotNull();
            NewPropertyRule(() => DepressionEvaluationRangeOfInterestInDoingThingsInPastWeekRule).WithProperty(a => a.PsychologicalSection.DepressionEvaluation.RangeOfInterestInDoingThingsInPastWeek).NotNull();
            NewPropertyRule(() => DepressionEvaluationRangeOfIrritabilityInPastWeekRule).WithProperty(a => a.PsychologicalSection.DepressionEvaluation.RangeOfIrritabilityInPastWeek).NotNull();
            NewPropertyRule(() => DepressionEvaluationRangeOfMoodInPastWeekRule).WithProperty(a => a.PsychologicalSection.DepressionEvaluation.RangeOfMoodInPastWeek).NotNull();
            NewPropertyRule(() => InterviewerRatingActivePsychiatricDiagnosesOtherThanSubstanceAbuseRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.ActivePsychiatricDiagnosesOtherThanSubstanceAbuse).NotNull();
            NewPropertyRule(() => InterviewerRatingAppearanceofAgitationRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.AppearanceofAgitation).NotNull();
            NewPropertyRule(() => InterviewerRatingAppearanceOfAnxietyNervousnessRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.AppearanceOfAnxietyNervousness).NotNull();
            NewPropertyRule(() => InterviewerRatingAppearanceOfDepressionWithdrawalRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.AppearanceOfDepressionWithdrawal).NotNull();
            NewPropertyRule(() => InterviewerRatingAppearanceOfFluctuatingOrientationInLast24HoursRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.AppearanceOfFluctuatingOrientationInLast24Hours).NotNull();
            NewPropertyRule(() => InterviewerRatingAppearanceOfHostilityRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.AppearanceOfHostility).NotNull();
            NewPropertyRule(() => InterviewerRatingAppearanceOfLethargyRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.AppearanceOfLethargy).NotNull();
            NewPropertyRule(() => InterviewerRatingAppearanceOfParanoiaOrImpairedThinkingRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.AppearanceOfParanoiaOrImpairedThinking).NotNull();
            NewPropertyRule(() => InterviewerRatingAppearanceOfSpeechImpairmentBadPostureRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.AppearanceOfSpeechImpairmentBadPosture).NotNull();
            NewPropertyRule(() => InterviewerRatingAppearanceOfTroubleConcentratingOrRememberingRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.AppearanceOfTroubleConcentratingOrRemembering).NotNull();
            NewPropertyRule(() => InterviewerRatingCurrentBehaviorInconsistentWithSelfCareRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.CurrentBehaviorInconsistentWithSelfCare).NotNull();
            NewPropertyRule(() => InterviewerRatingCurrentProblemBehaviorsRequireContinuousInterventionsRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.CurrentProblemBehaviorsRequireContinuousInterventions).NotNull();
            NewPropertyRule(() => InterviewerRatingDemonstratingDangerToSelfOrOthersRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.DemonstratingDangerToSelfOrOthers).NotNull();
            NewPropertyRule(() => InterviewerRatingDoesPatientCarryPsychiatricDiagnosisRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.DoesPatientCarryPsychiatricDiagnosis).NotNull();
            NewPropertyRule(() => InterviewerRatingEvidenceOfChronicOrganicMentalDisabilityRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.EvidenceOfChronicOrganicMentalDisability).NotNull();
            NewPropertyRule(() => InterviewerRatingGlobalAssessmentOfFunctioningScoreRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.GlobalAssessmentOfFunctioningScore).NotNull();
            NewPropertyRule(() => InterviewerRatingHasSuicidalThoughtsRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.HasSuicidalThoughts).NotNull();
            NewPropertyRule(() => InterviewerRatingIndicatingRiskOfHarmToOthersRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.IndicatingRiskOfHarmToOthers).NotNull();
            NewPropertyRule(() => InterviewerRatingIndicatingRiskOfHarmToSelfOrVictimizationByOthersRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.IndicatingRiskOfHarmToSelfOrVictimizationByOthers).NotNull();
            NewPropertyRule(() => InterviewerRatingIntensiveCaseManagementAccessibleToPatientRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.IntensiveCaseManagementAccessibleToPatient).NotNull();
            NewPropertyRule(() => InterviewerRatingIsPatientMisrepresentingInformationRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.IsPatientMisrepresentingInformation).NotNull();
            NewPropertyRule(() => InterviewerRatingIsPatientUnableToUnderstandRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.IsPatientUnableToUnderstand).NotNull();
            NewPropertyRule(() => InterviewerRatingLevelOfSupervisionNeededForProtectionFromSelfHarmRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.LevelOfSupervisionNeededForProtectionFromSelfHarm).NotNull();
            NewPropertyRule(() => InterviewerRatingLikelihoodOfRecurrenceOfPsychiatricDecompensationRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.LikelihoodOfRecurrenceOfPsychiatricDecompensation).NotNull();
            NewPropertyRule(() => InterviewerRatingLimitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthersRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.LimitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers).NotNull();
            NewPropertyRule(() => InterviewerRatingPatientAbleToSafelyAccessNeededResourcesRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.PatientAbleToSafelyAccessNeededResources).NotNull();
            NewPropertyRule(() => InterviewerRatingPatientNeedForPsychiatricPsychologicalTreatmentRatingRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.PatientNeedForPsychiatricPsychologicalTreatmentRating).NotNull();
            NewPropertyRule(() => InterviewerRatingPatientRequires24HourControlledSupervisedEnvironmentRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.PatientRequires24HourControlledSupervisedEnvironment).NotNull();
            NewPropertyRule(() => InterviewerRatingPsychiatricEvaluationAndServicesAccessibleToPatientRule).WithProperty(a => a.PsychologicalSection.InterviewerRating.PsychiatricEvaluationAndServicesAccessibleToPatient).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.InterviewerRating.HasSuicidalThoughts > 0
                                 || a.PsychologicalSection.InterviewerRating.DemonstratingDangerToSelfOrOthers > 0
                                 || a.PsychologicalSection.InterviewerRating.IndicatingRiskOfHarmToOthers > 0
                                 || a.PsychologicalSection.InterviewerRating.IndicatingRiskOfHarmToSelfOrVictimizationByOthers > 0,
                            () =>
                            NewPropertyRule ( () => InterviewerRatingRiskOfHarmToSelfOrOthersIsHigherWithSubstanceUseRule )
                                .WithProperty ( a => a.PsychologicalSection.InterviewerRating.RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse )
                                .NotNull () );
            
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackChestPainsInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackChestPainsInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackChestPainsInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackChestPainsInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackChestPainsInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackChestPainsInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackChillsHotFlashesInLastMonth > 0,
                            () =>
                            NewPropertyRule ( () => PsychologicalHistoryAnxietyAttackChillsHotFlashesInLast24HoursRule )
                                .WithProperty ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackChillsHotFlashesInLast24Hours )
                                .NotNull () );
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackChillsHotFlashesInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackChillsHotFlashesInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackChillsHotFlashesInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackChokingInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackChokingInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackChokingInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackChokingInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackChokingInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackChokingInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackDistortedRealityInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackDistortedRealityInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackDistortedRealityInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackDistortedRealityInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackDistortedRealityInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackDistortedRealityInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackDizzinessFaintnessInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackDizzinessFaintnessInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackDizzinessFaintnessInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackDizzinessFaintnessInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackDizzinessFaintnessInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackDizzinessFaintnessInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackDyingSensationInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackDyingSensationInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackDyingSensationInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackDyingSensationInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackDyingSensationInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackDyingSensationInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackLoseControlInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackLoseControlInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackLoseControlInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackLoseControlInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackLoseControlInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackLoseControlInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackMoreThanOnceInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackMoreThanOnceInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackMoreThanOnceInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackMoreThanOnceInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackMoreThanOnceInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackMoreThanOnceInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackNauseaDiarrheaInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackNauseaDiarrheaInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackNauseaDiarrheaInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackNauseaDiarrheaInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackNauseaDiarrheaInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackNauseaDiarrheaInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackNumbnessInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackNumbnessInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackNumbnessInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackNumbnessInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackNumbnessInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackNumbnessInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackPalpitationsInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackPalpitationsInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackPalpitationsInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackPalpitationsInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackPalpitationsInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackPalpitationsInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackRandomInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackRandomInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackRandomInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackRandomInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackRandomInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackRandomInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackShortnessBreathInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackShortnessBreathInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackShortnessBreathInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackShortnessBreathInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackShortnessBreathInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackShortnessBreathInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackSweatyInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackSweatyInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackSweatyInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackSweatyInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackSweatyInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackSweatyInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackTremblingInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackTremblingInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackTremblingInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackTremblingInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackTremblingInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackTremblingInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackInLast24Hours > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyAttackWithin24HoursRelatedToSubstanceUseRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyAttackWithin24HoursRelatedToSubstanceUse).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyTensionWorryInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyTensionWorryInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyTensionWorryInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.AnxietyTensionWorryInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryAnxietyTensionWorryInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.AnxietyTensionWorryInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistoryCantWaitForThingsWantedBadlyRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.CantWaitForThingsWantedBadly).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodOfSeriousDepressionInLast24Hours > 0, () => NewPropertyRule(() => PsychologicalHistoryDepressionWithin24HoursRelatedToSubstanceUseRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.DepressionWithin24HoursRelatedToSubstanceUse).NotNull());
            NewPropertyRule(() => PsychologicalHistoryDifficultToWorkNowForFutureGainRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.DifficultToWorkNowForFutureGain).NotNull();
            NewPropertyRule(() => PsychologicalHistoryEmotionalProblemsCorrelationWithSubstanceUseRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.EmotionalProblemsCorrelationWithSubstanceUse).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.FeelLikeFailureInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryFeelLikeFailureInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.FeelLikeFailureInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.FeelLikeFailureInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryFeelLikeFailureInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.FeelLikeFailureInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistoryFeelLikeFailureInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.FeelLikeFailureInLifetime).NotNull();
            NewPropertyRule(() => PsychologicalHistoryHowDifficultProblemsForWorkHomeAndSocialInteractionRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.HowDifficultProblemsForWorkHomeAndSocialInteraction).NotNull();
            NewPropertyRule(() => PsychologicalHistoryHowEmotionalProblemsImpactRecoveryEffortsRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.HowEmotionalProblemsImpactRecoveryEfforts).NotNull();
            NewPropertyRule(() => PsychologicalHistoryHowImportantPsychologicalEmotionalCounselingRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.HowImportantPsychologicalEmotionalCounseling).NotNull();
            NewPropertyRule(() => PsychologicalHistoryHowTroubledByPsychologicalEmotionalProblemsLast30DaysRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.HowTroubledByPsychologicalEmotionalProblemsLast30Days).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.InabilityToFeelPleasureFromActivitiesInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryInabilityToFeelPleasureFromActivitiesInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.InabilityToFeelPleasureFromActivitiesInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.InabilityToFeelPleasureFromActivitiesInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryInabilityToFeelPleasureFromActivitiesInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.InabilityToFeelPleasureFromActivitiesInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistoryInabilityToFeelPleasureFromActivitiesInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.InabilityToFeelPleasureFromActivitiesInLifetime).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.InabilityToFeelPleasureFromActivitiesInLast24Hours > 0, () => NewPropertyRule(() => PsychologicalHistoryInabilityToFeelPleasureFromActivitiesRelatedToSubstanceUseRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.InabilityToFeelPleasureFromActivitiesRelatedToSubstanceUse).NotNull());
            NewPropertyRule(() => PsychologicalHistoryIsReceivingNeededCareRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.IsReceivingNeededCare).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.MedicatedForPsychologicalEmotionalProblemInLifetime == true, () => NewPropertyRule(() => PsychologicalHistoryMedicatedForPsychologicalEmotionalProblemInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.MedicatedForPsychologicalEmotionalProblemInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.MovingSpeakingSlowlyInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryMovingSpeakingSlowlyInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.MovingSpeakingSlowlyInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.MovingSpeakingSlowlyInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryMovingSpeakingSlowlyInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.MovingSpeakingSlowlyInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistoryMovingSpeakingSlowlyInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.MovingSpeakingSlowlyInLifetime).NotNull();
            NewPropertyRule(() => PsychologicalHistoryNumberOfDaysExperiencedPsychologicalEmotionalProblemsInLast30DaysRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.NumberOfDaysExperiencedPsychologicalEmotionalProblemsInLast30Days).NotNull();
            NewPropertyRule(() => PsychologicalHistoryPastPsychologicalOrEmotionalProblemsRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.PastPsychologicalOrEmotionalProblems).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.PoorAppetiteOrOvereatingInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryPoorAppetiteOrOvereatingInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.PoorAppetiteOrOvereatingInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.PoorAppetiteOrOvereatingInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryPoorAppetiteOrOvereatingInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.PoorAppetiteOrOvereatingInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistoryPoorAppetiteOrOvereatingInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.PoorAppetiteOrOvereatingInLifetime).NotNull();
            NewPropertyRule(() => PsychologicalHistoryReceivesPensionForPsychiatricDisabilityRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.ReceivesPensionForPsychiatricDisability).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodAttemptedSuicideInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodAttemptedSuicideInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodAttemptedSuicideInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodAttemptedSuicideInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodAttemptedSuicideInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodAttemptedSuicideInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistorySignificantPeriodAttemptedSuicideInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodAttemptedSuicideInLifetime).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodAttemptedSuicideInLast24Hours > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodAttemptedSuicideRelatedToSubstanceUseRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodAttemptedSuicideRelatedToSubstanceUse).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodCurbingViolentBehaviorInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodCurbingViolentBehaviorInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodCurbingViolentBehaviorInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodCurbingViolentBehaviorInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodCurbingViolentBehaviorInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodCurbingViolentBehaviorInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistorySignificantPeriodCurbingViolentBehaviorInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodCurbingViolentBehaviorInLifetime).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodCurbingViolentBehaviorInLast24Hours > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodCurbingViolentBehaviorRelatedToSubstanceUseRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodCurbingViolentBehaviorRelatedToSubstanceUse).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodExcessiveBehaviorInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodExcessiveBehaviorInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodExcessiveBehaviorInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodFidgetingInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodFidgetingInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodFidgetingInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodFidgetingInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodFidgetingInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodFidgetingInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistorySignificantPeriodFidgetingInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodFidgetingInLifetime).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodFlashbacksInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodFlashbacksInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodFlashbacksInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodHallucinationsInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodHallucinationsInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodHallucinationsInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodHallucinationsInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodHallucinationsInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodHallucinationsInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistorySignificantPeriodHallucinationsInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodHallucinationsInLifetime).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodHallucinationsInLast24Hours > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodHallucinationsRelatedToSubstanceUseRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodHallucinationsRelatedToSubstanceUse).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodImpairedThoughtInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodImpairedThoughtInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodImpairedThoughtInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodImpairedThoughtInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodImpairedThoughtInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodImpairedThoughtInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistorySignificantPeriodImpairedThoughtInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodImpairedThoughtInLifetime).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodImpairedThoughtInLast24Hours > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodImpairedThoughtRelatedToSubstanceUseRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodImpairedThoughtRelatedToSubstanceUse).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodIrritabilityInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodIrritabilityInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodIrritabilityInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodIrritabilityInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodIrritabilityInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodIrritabilityInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodLethargyInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodLethargyInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodLethargyInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodLethargyInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodLethargyInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodLethargyInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistorySignificantPeriodLethargyInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodLethargyInLifetime).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodMuscleTensionInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodMuscleTensionInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodMuscleTensionInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodMuscleTensionInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodMuscleTensionInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodMuscleTensionInLastMonth).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodNegativeThoughtsInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodNegativeThoughtsInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodNegativeThoughtsInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodOfSeriousDepressionInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodOfSeriousDepressionInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodOfSeriousDepressionInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodOfSeriousDepressionInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodOfSeriousDepressionInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodOfSeriousDepressionInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistorySignificantPeriodOfSeriousDepressionInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodOfSeriousDepressionInLifetime).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodParanoiaInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodParanoiaInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodParanoiaInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodParanoiaInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodParanoiaInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodParanoiaInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistorySignificantPeriodParanoiaInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodParanoiaInLifetime).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodParanoiaInLast24Hours > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodParanoiaRelatedToSubstanceUseRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodParanoiaRelatedToSubstanceUse).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodSleepDisorderInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodSleepDisorderInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodSleepDisorderInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodSleepDisorderInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodSleepDisorderInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodSleepDisorderInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistorySignificantPeriodSleepDisorderInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodSleepDisorderInLifetime).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodSuicidalThoughtsInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodSuicidalThoughtsInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodSuicidalThoughtsInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodSuicidalThoughtsInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodSuicidalThoughtsInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodSuicidalThoughtsInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistorySignificantPeriodSuicidalThoughtsInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodSuicidalThoughtsInLifetime).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodSuicidalThoughtsInLast24Hours > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodSuicidalThoughtsRelatedToSubstanceUseRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodSuicidalThoughtsRelatedToSubstanceUse).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodThoughtsOfSelfInjuryInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodThoughtsOfSelfInjuryInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodThoughtsOfSelfInjuryInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodThoughtsOfSelfInjuryInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodThoughtsOfSelfInjuryInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodThoughtsOfSelfInjuryInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistorySignificantPeriodThoughtsOfSelfInjuryInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodThoughtsOfSelfInjuryInLifetime).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodTroubleWithAttitudeTowardOthersInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodTroubleWithAttitudeTowardOthersInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodTroubleWithAttitudeTowardOthersInLast24Hours).NotNull());
            NewPropertyRule(() => PsychologicalHistorySignificantPeriodTroubleWithAttitudeTowardOthersInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodTroubleWithAttitudeTowardOthersInLifetime).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodUntruePerceptionInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodUntruePerceptionInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodUntruePerceptionInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodUntruePerceptionInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodUntruePerceptionInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodUntruePerceptionInLastMonth).NotNull());
            NewPropertyRule(() => PsychologicalHistorySignificantPeriodUntruePerceptionInLifetimeRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodUntruePerceptionInLifetime).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodUntruePerceptionInLast24Hours > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodUntruePerceptionRelatedToSubstanceUseRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodUntruePerceptionRelatedToSubstanceUse).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodViolentUrgesInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodViolentUrgesInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodViolentUrgesInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodViolentUrgesInLast24Hours > 0, () => NewPropertyRule(() => PsychologicalHistorySignificantPeriodViolentUrgesRelatedToSubstanceUseRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.SignificantPeriodViolentUrgesRelatedToSubstanceUse).NotNull());
            NewPropertyRule(() => PsychologicalHistoryTimesTreatedForPsychologicalOrEmotionalProblemsInHospitalRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.TimesTreatedForPsychologicalOrEmotionalProblemsInHospital).NotNull();
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.WorriedAboutAnxietyAttackInLastMonth > 0, () => NewPropertyRule(() => PsychologicalHistoryWorriedAboutAnxietyAttackInLast24HoursRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.WorriedAboutAnxietyAttackInLast24Hours).NotNull());
            ShouldRunWhen ( a => a.PsychologicalSection.PsychologicalHistory.WorriedAboutAnxietyAttackInLifetime > 0, () => NewPropertyRule(() => PsychologicalHistoryWorriedAboutAnxietyAttackInLastMonthRule).WithProperty(a => a.PsychologicalSection.PsychologicalHistory.WorriedAboutAnxietyAttackInLastMonth).NotNull());


            NewRuleSet(() => CompletionSectionRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.CompletionSection)).ToArray());
            NewRuleSet(() => AddictionTreatmentHistoryRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.AddictionTreatmentHistory)).ToArray());
            NewRuleSet(() => AdditionalAddictionAndTreatmentItemsRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems)).ToArray());
            NewRuleSet(() => AlcoholAndDrugInterviewerRatingRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.AlcoholAndDrugInterviewerRating)).ToArray());
            NewRuleSet(() => AlcoholUseRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.AlcoholUse)).ToArray());
            NewRuleSet(() => BarbiturateUseRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.BarbiturateUse)).ToArray());
            NewRuleSet(() => CannabisUseRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.CannabisUse)).ToArray());
            NewRuleSet(() => CinaScaleRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.CinaScale)).ToArray());
            NewRuleSet(() => CiwaScaleRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.CiwaScale)).ToArray());
            NewRuleSet(() => CocaineUseRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.CocaineUse)).ToArray());
            NewRuleSet(() => DrugConsequencesRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.DrugConsequences)).ToArray());
            NewRuleSet(() => HallucinogenUseRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.HallucinogenUse)).ToArray());
            NewRuleSet(() => HeroinUseRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.HeroinUse)).ToArray());
            NewRuleSet(() => InterviewerEvaluationRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.InterviewerEvaluation)).ToArray());
            NewRuleSet(() => MethadoneUseRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.MethadoneUse)).ToArray());
            NewRuleSet(() => MultipleSubstanceUsePerDayRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.MultipleSubstanceUsePerDay)).ToArray());
            NewRuleSet(() => NicotineUseRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.NicotineUse)).ToArray());
            NewRuleSet(() => OpiatesInControlledEnvironmentRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.OpiatesInControlledEnvironment)).ToArray());
            NewRuleSet(() => OpioidMaintenanceTherapyRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.OpioidMaintenanceTherapy)).ToArray());
            NewRuleSet(() => OtherOpiateUseRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.OtherOpiateUse)).ToArray());
            NewRuleSet(() => OtherSedativeUseRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.OtherSedativeUse)).ToArray());
            NewRuleSet(() => OtherSubstanceUseRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.OtherSubstanceUse)).ToArray());
            NewRuleSet(() => SolventAndInhalantUseRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.SolventAndInhalantUse)).ToArray());
            NewRuleSet(() => StimulantUseRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.StimulantUse)).ToArray());
            NewRuleSet(() => UsedSubstancesRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.DrugAndAlcoholSection.UsedSubstances)).ToArray());
            NewRuleSet(() => EmploymentAndSupportSectionRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.EmploymentAndSupportSection)).ToArray());
            NewRuleSet(() => FamilyAndSocialHistorySectionRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.FamilyAndSocialHistorySection)).ToArray());
            NewRuleSet(() => GeneralInformationSectionRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.GeneralInformationSection)).ToArray());
            NewRuleSet(() => LegalSectionRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.LegalSection)).ToArray());
            NewRuleSet(() => MedicalSectionRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.MedicalSection)).ToArray());
            NewRuleSet(() => DepressionEvaluationRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.PsychologicalSection.DepressionEvaluation)).ToArray());
            NewRuleSet(() => InterviewerRatingRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.PsychologicalSection.InterviewerRating)).ToArray());
            NewRuleSet(() => PsychologicalHistoryRuleSet, this.Where(r => ((IPropertyRule)r).ContainsPropertyPart<Assessment>(a => a.PsychologicalSection.PsychologicalHistory)).ToArray());
        }

        #endregion

        #region Public Properties

        public IRuleSet CompletionSectionRuleSet { get; private set; }
        public IRuleSet AddictionTreatmentHistoryRuleSet { get; private set; }
        public IRuleSet AdditionalAddictionAndTreatmentItemsRuleSet { get; private set; }
        public IRuleSet AlcoholAndDrugInterviewerRatingRuleSet { get; private set; }
        public IRuleSet AlcoholUseRuleSet { get; private set; }
        public IRuleSet BarbiturateUseRuleSet { get; private set; }
        public IRuleSet CannabisUseRuleSet { get; private set; }
        public IRuleSet CinaScaleRuleSet { get; private set; }
        public IRuleSet CiwaScaleRuleSet { get; private set; }
        public IRuleSet CocaineUseRuleSet { get; private set; }
        public IRuleSet DrugConsequencesRuleSet { get; private set; }
        public IRuleSet HallucinogenUseRuleSet { get; private set; }
        public IRuleSet HeroinUseRuleSet { get; private set; }
        public IRuleSet InterviewerEvaluationRuleSet { get; private set; }
        public IRuleSet MethadoneUseRuleSet { get; private set; }
        public IRuleSet MultipleSubstanceUsePerDayRuleSet { get; private set; }
        public IRuleSet NicotineUseRuleSet { get; private set; }
        public IRuleSet OpiatesInControlledEnvironmentRuleSet { get; private set; }
        public IRuleSet OpioidMaintenanceTherapyRuleSet { get; private set; }
        public IRuleSet OtherOpiateUseRuleSet { get; private set; }
        public IRuleSet OtherSedativeUseRuleSet { get; private set; }
        public IRuleSet OtherSubstanceUseRuleSet { get; private set; }
        public IRuleSet SolventAndInhalantUseRuleSet { get; private set; }
        public IRuleSet StimulantUseRuleSet { get; private set; }
        public IRuleSet UsedSubstancesRuleSet { get; private set; }
        public IRuleSet EmploymentAndSupportSectionRuleSet { get; private set; }
        public IRuleSet FamilyAndSocialHistorySectionRuleSet { get; private set; }
        public IRuleSet GeneralInformationSectionRuleSet { get; private set; }
        public IRuleSet LegalSectionRuleSet { get; private set; }
        public IRuleSet MedicalSectionRuleSet { get; private set; }
        public IRuleSet DepressionEvaluationRuleSet { get; private set; }
        public IRuleSet InterviewerRatingRuleSet { get; private set; }
        public IRuleSet PsychologicalHistoryRuleSet { get; private set; }


        public IPropertyRule AddictionTreatmentHistoryHighestCareLevelFailedFromInPast90DaysRule { get; private set; }
        public IPropertyRule AddictionTreatmentHistoryNumberOfTimesDrugTreatmentLifetimeRule { get; private set; }
        public IPropertyRule AddictionTreatmentHistoryNumberOfTimesTreatedForAlcoholAbuseLifetimeRule { get; private set; }
        public IPropertyRule AddictionTreatmentHistoryPreviousSubstanceUseTreatmentRule { get; private set; }
        public IPropertyRule AddictionTreatmentHistoryUsuallyEnteredContinuedTreatmentAfterDetoxificationRule { get; private set; }
        public IPropertyRule AddictionTreatmentHistoryUsuallyLeftDetoxificationBeforeAdvisedRule { get; private set; }
        public IPropertyRule AdditionalAddictionAndTreatmentItemsAddictionSymptomsIncreasedRecentlyRule { get; private set; }
        public IPropertyRule AdditionalAddictionAndTreatmentItemsConcernsAboutPursuingTreatmentRule { get; private set; }
        public IPropertyRule AdditionalAddictionAndTreatmentItemsCurrentStrengthOfSubstanceUseDesireRule { get; private set; }
        public IPropertyRule AdditionalAddictionAndTreatmentItemsFeelLikelyToContinueSubstanceUseOrRelapseRule { get; private set; }
        public IPropertyRule AdditionalAddictionAndTreatmentItemsHelpfulnessOfTreatmentRule { get; private set; }
        public IPropertyRule AdditionalAddictionAndTreatmentItemsLikelihoodPreviousEnvironmentWillInduceSubstanceUseRule { get; private set; }
        public IPropertyRule AdditionalAddictionAndTreatmentItemsPossibleFutureRelapseCauseRule { get; private set; }
        public IPropertyRule AdditionalAddictionAndTreatmentItemsStrategyToPreventRelapseRule { get; private set; }
        public IPropertyRule AdditionalAddictionAndTreatmentItemsStrengthOfSubstanceUseUrgeDueToEnvironmentalTriggersRule { get; private set; }
        public IPropertyRule AdditionalAddictionAndTreatmentItemsSubstanceOverdoseInPast24HoursRule { get; private set; }
        public IPropertyRule AdditionalAddictionAndTreatmentItemsWhichSubstanceIsMajorProblemRule { get; private set; }
        public IPropertyRule AlcoholAndDrugInterviewerRatingInterviewerScoreOfAlcoholTreatmentNeedRule { get; private set; }
        public IPropertyRule AlcoholAndDrugInterviewerRatingInterviewerScoreOfAttitudeRule { get; private set; }
        public IPropertyRule AlcoholAndDrugInterviewerRatingInterviewerScoreOfDrugTreatmentNeedRule { get; private set; }
        public IPropertyRule AlcoholAndDrugInterviewerRatingInterviewerScoreOfReadinessRule { get; private set; }
        public IPropertyRule AlcoholAndDrugInterviewerRatingIsPatientExperiencingWithdrawalSignsSymptomsRule { get; private set; }
        public IPropertyRule AlcoholAndDrugInterviewerRatingMajorityOfInformationFromCollateralSourceRule { get; private set; }
        public IPropertyRule AlcoholAndDrugInterviewerRatingPatientManifestingSeriousRelapseBehaviorsRule { get; private set; }
        public IPropertyRule AlcoholUseAlcoholUsedToIntoxicationRule { get; private set; }
        public IPropertyRule AlcoholUseAmountOfMoneySpentInLast30DaysRule { get; private set; }
        public IPropertyRule AlcoholUseExperiencesWithdrawalSicknessRule { get; private set; }
        public IPropertyRule AlcoholUseImportanceOfTreatmentForSubstanceProblemsRule { get; private set; }
        public IPropertyRule AlcoholUseLastUsedRule { get; private set; }
        public IPropertyRule AlcoholUseLastUsedToIntoxificationRule { get; private set; }
        public IPropertyRule AlcoholUseNumberOfDaysIntoxicatedInPast30DaysRule { get; private set; }
        public IPropertyRule AlcoholUseNumberOfDaysUsedInPast30DaysRule { get; private set; }
        public IPropertyRule AlcoholHasStrongUrgesRule { get; private set; }
        public IPropertyRule AlcoholUseNumberOfDaysWithSubstanceProblemsInLast30DaysRule { get; private set; }
        public IPropertyRule AlcoholUseNumberOfTimesWithdrawalCausedDeliriumTremensRule { get; private set; }
        public IPropertyRule AlcoholUseNumberOfTimesWithdrawalCausedSeizuresRule { get; private set; }
        public IPropertyRule AlcoholUseTroubledInLast30DaysBySubstanceProblemsRule { get; private set; }
        public IPropertyRule AlcoholUseUseSubstanceToPreventWithdrawalSicknessRule { get; private set; }
        public IPropertyRule BarbiturateUseExperiencesWithdrawalSicknessRule { get; private set; }
        public IPropertyRule BarbiturateUseHasHealthCareProviderPrescribedUseRule { get; private set; }
        public IPropertyRule BarbiturateUseIncreasedDoseRequiredToGetSameEffectRule { get; private set; }
        public IPropertyRule BarbiturateUseLastUsedRule { get; private set; }
        public IPropertyRule BarbiturateHasStrongUrgesRule { get; private set; }
        public IPropertyRule BarbiturateUseNumberOfDaysUsedInPast30DaysRule { get; private set; }
        public IPropertyRule BarbiturateUseNumberOfMonthsUsedInLifetimeRule { get; private set; }
        public IPropertyRule BarbiturateUseUseSubstanceToPreventWithdrawalSicknessRule { get; private set; }
        public IPropertyRule BarbiturateUseWasSubstanceTakenAsPrescribedRule { get; private set; }
        public IPropertyRule CannabisUseExperiencesWithdrawalSicknessRule { get; private set; }
        public IPropertyRule CannabisUseLastUsedRule { get; private set; }
        public IPropertyRule CannabisHasStrongUrgesRule { get; private set; }
        public IPropertyRule CannabisUseNumberOfDaysUsedInPast30DaysRule { get; private set; }
        public IPropertyRule CannabisUseUseSubstanceToPreventWithdrawalSicknessRule { get; private set; }
        public IPropertyRule CinaScaleExperiencedNauseaOrVomitedRecentlyRule { get; private set; }
        public IPropertyRule CinaScaleFeelsHotOrColdRule { get; private set; }
        public IPropertyRule CinaScaleHasAbdominalPainRule { get; private set; }
        public IPropertyRule CinaScaleHasMuscleAchesRule { get; private set; }
        public IPropertyRule CinaScaleObservedGooseFleshRule { get; private set; }
        public IPropertyRule CinaScaleObservedLacriminationRule { get; private set; }
        public IPropertyRule CinaScaleObservedNasalCongestionRule { get; private set; }
        public IPropertyRule CinaScaleObservedRestlessnessRule { get; private set; }
        public IPropertyRule CinaScaleObservedSweatingRule { get; private set; }
        public IPropertyRule CinaScaleObservedTremorRule { get; private set; }
        public IPropertyRule CinaScaleObservedYawningRule { get; private set; }
        public IPropertyRule CiwaScaleExperiencedNauseaOrVomitedRecentlyRule { get; private set; }
        public IPropertyRule CiwaScaleHadDeliriumTremorsInPast24HoursRule { get; private set; }
        public IPropertyRule CiwaScaleHeadAcheOrFullnessSeverityRule { get; private set; }
        public IPropertyRule CiwaScaleObservedNervousnessRule { get; private set; }
        public IPropertyRule CiwaScaleObservedSweatingRule { get; private set; }
        public IPropertyRule CiwaScaleObservedTactileDisturbancesRule { get; private set; }
        public IPropertyRule CiwaScaleObservedTremorRule { get; private set; }
        public IPropertyRule CocaineUseExperiencesWithdrawalSicknessRule { get; private set; }
        public IPropertyRule CocaineUseLastUsedRule { get; private set; }
        public IPropertyRule CocaineHasStrongUrgesRule { get; private set; }
        public IPropertyRule CocaineUseNumberOfDaysUsedInPast30DaysRule { get; private set; }
        public IPropertyRule CocaineUseUseSubstanceToPreventWithdrawalSicknessRule { get; private set; }
        public IPropertyRule CompletionSectionAcceptableLevelsOfCareRule { get; private set; }
        public IPropertyRule CompletionSectionDetoxificationRequiredMoreThanHourlyMonitoringRule { get; private set; }
        public IPropertyRule CompletionSectionIsAbleToSelfAdministerMedicationRule { get; private set; }
        public IPropertyRule CompletionSectionIsCurrentlyResidingInCareLevel_III_1Rule { get; private set; }
        public IPropertyRule CompletionSectionMedicalConditionEndangeredByContinuedSubstanceUseRule { get; private set; }
        public IPropertyRule CompletionSectionMedicalConditionExacerbatedByContinuedSubstanceUseRule { get; private set; }
        public IPropertyRule CompletionSectionMedicalConditionMakesAbstinenceVitalRule { get; private set; }
        public IPropertyRule CompletionSectionPrnHourlyMonitoringSufficientToDetermineDetoxServiceLevelRule { get; private set; }
        public IPropertyRule CompletionSectionRequiresTreatmentModeOnlyAvailableInCareLevel_III_7Rule { get; private set; }
        public IPropertyRule CompletionSectionRespondedPositivelyToEmotionalSupportDuringInterviewRule { get; private set; }
        public IPropertyRule CompletionSectionSymptomsLifeThreateningBecauseOfSubstanceUseRule { get; private set; }
        public IPropertyRule CompletionSectionSymptomsStabalizedDuringTreatmentDayRule { get; private set; }
        public IPropertyRule CompletionSectionTimingOfPositiveResponseToDetoxificationCareRule { get; private set; }
        public IPropertyRule CompletionSectionUnacceptableCareLevelsRule { get; private set; }
        public IPropertyRule CompletionSectionUnavailableCareLevelsRule { get; private set; }
        public IPropertyRule DepressionEvaluationObservedRetardationOfThoughtOrSpeechRule { get; private set; }
        public IPropertyRule DepressionEvaluationRangeOfEnergyInPastWeekRule { get; private set; }
        public IPropertyRule DepressionEvaluationRangeOfGuiltInPastWeekRule { get; private set; }
        public IPropertyRule DepressionEvaluationRangeOfInterestInDoingThingsInPastWeekRule { get; private set; }
        public IPropertyRule DepressionEvaluationRangeOfIrritabilityInPastWeekRule { get; private set; }
        public IPropertyRule DepressionEvaluationRangeOfMoodInPastWeekRule { get; private set; }
        public IPropertyRule DrugConsequencesImportanceOfTreatmentForSubstanceProblemRule { get; private set; }
        public IPropertyRule DrugConsequencesNumberOfDaysExperiencedSubstanceProblemsInPast30DaysRule { get; private set; }
        public IPropertyRule DrugConsequencesTroubledInLast30DaysBySubstanceProblemsRule { get; private set; }
        public IPropertyRule EmploymentAndSupportSectionAmountOfMoneyInPast30DaysFromEmploymentRule { get; private set; }
        public IPropertyRule EmploymentAndSupportSectionAmountOfMoneyInPast30DaysFromIllegalMeansRule { get; private set; }
        public IPropertyRule EmploymentAndSupportSectionConcernAboutEmploymentProblemsInPast30DaysRule { get; private set; }
        public IPropertyRule EmploymentAndSupportSectionHasAutomobileAvailableForUseRule { get; private set; }
        public IPropertyRule EmploymentAndSupportSectionHasValidDriversLicenseRule { get; private set; }
        public IPropertyRule EmploymentAndSupportSectionNumberOfDaysWorkingInPast30DaysRule { get; private set; }
        public IPropertyRule EmploymentAndSupportSectionNumberOfDependentsRule { get; private set; }
        public IPropertyRule EmploymentAndSupportSectionWorkOrSchoolAffectOnRecoveryRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionClosestContactsNeedsAndWillingnessToHelpTreatmentRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionClosestPersonalContactInPast4MonthsRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionDealsWithProblemsFromFriendsThatRiskRelapseRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionDealsWithProblemsInFreeTimeThatRiskRelapseRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionEmotionalAbuseInPast30DaysRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionFamilyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_IIRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionFreeTimeAffectOnRecoveryRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionFriendsAffectOnRecoveryRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionHadProblemsInPastMonthWithChildrenRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionHadProblemsInPastMonthWithCloseFriendsRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionHadProblemsInPastMonthWithCoworkersRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionHadProblemsInPastMonthWithFatherRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionHadProblemsInPastMonthWithMotherRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionHadProblemsInPastMonthWithNeighborsRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionHadProblemsInPastMonthWithOtherFamilyRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionHadProblemsInPastMonthWithSexPartnerRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionHadProblemsInPastMonthWithSiblingRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionHasRecentlyNeglectedOrAbusedFamilyMembersRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionHowLikelyToCauseHarmNeglectOthersRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionImportanceOfTreatmentForFamilyMembersRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionIsAbleToLocateAndGetToCommunityResourcesSafelyRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionIsOutpatientMonitoringAvailable8To24HoursRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionIsPatientAvailableForFollowupFor7DaysRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionIsSupportPersonAvailableFor7DaysRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionLivingArrangementAffectOnRecoveryRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionNeedForStaffSupportToMaintainRecoveryRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionNumberOfCloseFriendsRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionPhysicalAbuseInPast30DaysRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionRiskPatientHarmedByOtherRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionSatisfiedWithThisSituationRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionSeriousConflictsWithFamilyInPast30DaysRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionSexualAbuseInPast30DaysRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionSpendsFreeTimeWithRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionTroubledByFamilyProblemsInPast30DaysRule { get; private set; }
        public IPropertyRule FamilyAndSocialHistorySectionTroubledBySocialProblemsInPast30DaysRule { get; private set; }
        public IPropertyRule GeneralInformationSectionAssessmentClassRule { get; private set; }
        public IPropertyRule GeneralInformationSectionInPenalOrChronicCareSettingRecentlyRule { get; private set; }
        public IPropertyRule GeneralInformationSectionInterviewCircumstancesRule { get; private set; }
        public IPropertyRule GeneralInformationSectionInterviewMethodRule { get; private set; }
        public IPropertyRule HallucinogenUseExperiencesWithdrawalSicknessRule { get; private set; }
        public IPropertyRule HallucinogenUseLastUsedRule { get; private set; }
        public IPropertyRule HallucinogenHasStrongUrgesRule { get; private set; }
        public IPropertyRule HallucinogenUseNumberOfDaysUsedInPast30DaysRule { get; private set; }
        public IPropertyRule HallucinogenUseUseSubstanceToPreventWithdrawalSicknessRule { get; private set; }
        public IPropertyRule HeroinUseExperiencesWithdrawalSicknessRule { get; private set; }
        public IPropertyRule HeroinUseIncreasedDoseRequiredToGetSameEffectRule { get; private set; }
        public IPropertyRule HeroinUseLastUsedRule { get; private set; }
        public IPropertyRule HeroinHasStrongUrgesRule { get; private set; }
        public IPropertyRule HeroinUseNumberOfDaysUsedInPast30DaysRule { get; private set; }
        public IPropertyRule HeroinUseNumberOfMonthsUsedInLifetimeRule { get; private set; }
        public IPropertyRule HeroinUseRouteOfIntakeRule { get; private set; }
        public IPropertyRule HeroinUseUseSubstanceToPreventWithdrawalSicknessRule { get; private set; }
        public IPropertyRule InterviewerEvaluationHasMaintainedBarbituatesDoseAtTherapeuticLevelsRule { get; private set; }
        public IPropertyRule InterviewerEvaluationHasMaintainedSedativeDoseAtTherapeuticLevelsRule { get; private set; }
        public IPropertyRule InterviewerRatingActivePsychiatricDiagnosesOtherThanSubstanceAbuseRule { get; private set; }
        public IPropertyRule InterviewerRatingAppearanceOfAnxietyNervousnessRule { get; private set; }
        public IPropertyRule InterviewerRatingAppearanceOfDepressionWithdrawalRule { get; private set; }
        public IPropertyRule InterviewerRatingAppearanceOfFluctuatingOrientationInLast24HoursRule { get; private set; }
        public IPropertyRule InterviewerRatingAppearanceOfHostilityRule { get; private set; }
        public IPropertyRule InterviewerRatingAppearanceOfLethargyRule { get; private set; }
        public IPropertyRule InterviewerRatingAppearanceOfParanoiaOrImpairedThinkingRule { get; private set; }
        public IPropertyRule InterviewerRatingAppearanceOfSpeechImpairmentBadPostureRule { get; private set; }
        public IPropertyRule InterviewerRatingAppearanceOfTroubleConcentratingOrRememberingRule { get; private set; }
        public IPropertyRule InterviewerRatingAppearanceofAgitationRule { get; private set; }
        public IPropertyRule InterviewerRatingCurrentBehaviorInconsistentWithSelfCareRule { get; private set; }
        public IPropertyRule InterviewerRatingCurrentProblemBehaviorsRequireContinuousInterventionsRule { get; private set; }
        public IPropertyRule InterviewerRatingDemonstratingDangerToSelfOrOthersRule { get; private set; }
        public IPropertyRule InterviewerRatingDoesPatientCarryPsychiatricDiagnosisRule { get; private set; }
        public IPropertyRule InterviewerRatingEvidenceOfChronicOrganicMentalDisabilityRule { get; private set; }
        public IPropertyRule InterviewerRatingGlobalAssessmentOfFunctioningScoreRule { get; private set; }
        public IPropertyRule InterviewerRatingHasSuicidalThoughtsRule { get; private set; }
        public IPropertyRule InterviewerRatingIndicatingRiskOfHarmToOthersRule { get; private set; }
        public IPropertyRule InterviewerRatingIndicatingRiskOfHarmToSelfOrVictimizationByOthersRule { get; private set; }
        public IPropertyRule InterviewerRatingIntensiveCaseManagementAccessibleToPatientRule { get; private set; }
        public IPropertyRule InterviewerRatingIsPatientMisrepresentingInformationRule { get; private set; }
        public IPropertyRule InterviewerRatingIsPatientUnableToUnderstandRule { get; private set; }
        public IPropertyRule InterviewerRatingLevelOfSupervisionNeededForProtectionFromSelfHarmRule { get; private set; }
        public IPropertyRule InterviewerRatingLikelihoodOfRecurrenceOfPsychiatricDecompensationRule { get; private set; }
        public IPropertyRule InterviewerRatingLimitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthersRule { get; private set; }
        public IPropertyRule InterviewerRatingPatientAbleToSafelyAccessNeededResourcesRule { get; private set; }
        public IPropertyRule InterviewerRatingPatientNeedForPsychiatricPsychologicalTreatmentRatingRule { get; private set; }
        public IPropertyRule InterviewerRatingPatientRequires24HourControlledSupervisedEnvironmentRule { get; private set; }
        public IPropertyRule InterviewerRatingPsychiatricEvaluationAndServicesAccessibleToPatientRule { get; private set; }
        public IPropertyRule InterviewerRatingRiskOfHarmToSelfOrOthersIsHigherWithSubstanceUseRule { get; private set; }
        public IPropertyRule LegalSectionDesireAndExternalFactorsDrivingTreatmentRule { get; private set; }
        public IPropertyRule LegalSectionImportanceOfCounselingForCurrentLegalProblemsRule { get; private set; }
        public IPropertyRule LegalSectionIsCurrentlyAwaitingChargesTrialSentenceRule { get; private set; }
        public IPropertyRule LegalSectionIsOnProbationOrParoleRule { get; private set; }
        public IPropertyRule LegalSectionNumberOfDaysCommitingCrimesForProfitInPast30DaysRule { get; private set; }
        public IPropertyRule LegalSectionNumberOfTimesArrestedForArsonRule { get; private set; }
        public IPropertyRule LegalSectionNumberOfTimesArrestedForAssaultRule { get; private set; }
        public IPropertyRule LegalSectionNumberOfTimesArrestedForBurglaryLarcenyRule { get; private set; }
        public IPropertyRule LegalSectionNumberOfTimesArrestedForContemptOfCourtRule { get; private set; }
        public IPropertyRule LegalSectionNumberOfTimesArrestedForDrugChargesRule { get; private set; }
        public IPropertyRule LegalSectionNumberOfTimesArrestedForForgeryRule { get; private set; }
        public IPropertyRule LegalSectionNumberOfTimesArrestedForHomicideRule { get; private set; }
        public IPropertyRule LegalSectionNumberOfTimesArrestedForOtherArrestRule { get; private set; }
        public IPropertyRule LegalSectionNumberOfTimesArrestedForParoleProbationViolationRule { get; private set; }
        public IPropertyRule LegalSectionNumberOfTimesArrestedForProstitutionRule { get; private set; }
        public IPropertyRule LegalSectionNumberOfTimesArrestedForRapeRule { get; private set; }
        public IPropertyRule LegalSectionNumberOfTimesArrestedForRobberyRule { get; private set; }
        public IPropertyRule LegalSectionNumberOfTimesArrestedForShopliftingVandalismRule { get; private set; }
        public IPropertyRule LegalSectionNumberOfTimesArrestedForWeaponsOffenseRule { get; private set; }
        public IPropertyRule LegalSectionNumberOfTimesConvictedRule { get; private set; }
        public IPropertyRule LegalSectionSeverityOfCurrentLegalProblemsRule { get; private set; }
        public IPropertyRule LegalSectionWasVisitPromptedByCriminalJusticeSystemRule { get; private set; }
        public IPropertyRule MedicalSectionAuditoryDisturbanceLevelRule { get; private set; }
        public IPropertyRule MedicalSectionBloodPressureRule { get; private set; }
        public IPropertyRule MedicalSectionExperiencedAcuteAlcoholDisulfiramReactionInPast24HoursStatusRule { get; private set; }
        public IPropertyRule MedicalSectionFeverOf102DegreesOrMoreInPast24HoursRule { get; private set; }
        public IPropertyRule MedicalSectionHeartRateRule { get; private set; }
        public IPropertyRule MedicalSectionHighRiskPregnancyStatusRule { get; private set; }
        public IPropertyRule MedicalSectionHivAidsMedicalTreatmentStatusRule { get; private set; }
        public IPropertyRule MedicalSectionImportanceOfTreatmentForMedicalProblemsRule { get; private set; }
        public IPropertyRule MedicalSectionInterviewerObservationOfPatientAgitationLevelRule { get; private set; }
        public IPropertyRule MedicalSectionInterviewerObservationOfPatientSenseOfAwarenessRule { get; private set; }
        public IPropertyRule MedicalSectionInterviewerRatingOfPatientNeedForMedicalTreatmentRule { get; private set; }
        public IPropertyRule MedicalSectionLevelOfConcernInPast30DaysAboutMedicalProblemsRule { get; private set; }
        public IPropertyRule MedicalSectionLostConsciousnessFromHeadTraumaInPast24HoursRule { get; private set; }
        public IPropertyRule MedicalSectionMayRequireInpatientAcutePancreatitisTreatmentRule { get; private set; }
        public IPropertyRule MedicalSectionMayRequireInpatientGastrointestinalBleedingTreatmentRule { get; private set; }
        public IPropertyRule MedicalSectionMayRequireInpatientLiverTreatmentRule { get; private set; }
        public IPropertyRule MedicalSectionMedicalProblemThatWouldComplicateDetoxificationStatusRule { get; private set; }
        public IPropertyRule MedicalSectionMobilityProblemsMayAffectTreatmentAttendanceRule { get; private set; }
        public IPropertyRule MedicalSectionMultipleSeizuresInPast24HoursRule { get; private set; }
        public IPropertyRule MedicalSectionMultipleSeriousMedicalProblemsExistRule { get; private set; }
        public IPropertyRule MedicalSectionNeedForMedicalOrPhysicalRehabilitationRule { get; private set; }
        public IPropertyRule MedicalSectionNumberOfDaysWithMedicalProblemsInPast30DaysRule { get; private set; }
        public IPropertyRule MedicalSectionPhysicalHealthsEffectOnSubstanceProblemsRule { get; private set; }
        public IPropertyRule MedicalSectionPregnantStatusRule { get; private set; }
        public IPropertyRule MedicalSectionRequiresInpatientCardiacMonitoringRule { get; private set; }
        public IPropertyRule MedicalSectionRequiresMedicalMonitoringForReemergenceOfSymptomsRule { get; private set; }
        public IPropertyRule MedicalSectionSeizureInPast24HoursRule { get; private set; }
        public IPropertyRule MedicalSectionSexuallyTransmittedDiseaseStatusRule { get; private set; }
        public IPropertyRule MedicalSectionSignsOfIntoxicationExistRule { get; private set; }
        public IPropertyRule MedicalSectionSignsOfToxicPsychosisExistRule { get; private set; }
        public IPropertyRule MedicalSectionSufferedHeadTraumaInPast48HoursRule { get; private set; }
        public IPropertyRule MedicalSectionSufferedSeriousImpairmentFromOverdoseInPast24HoursRule { get; private set; }
        public IPropertyRule MedicalSectionTuberculosisInfectionStatusRule { get; private set; }
        public IPropertyRule MedicalSectionUnsteadinessOrLossOfBalanceRule { get; private set; }
        public IPropertyRule MedicalSectionVisualDisturbanceLevelRule { get; private set; }
        public IPropertyRule MethadoneUseExperiencesWithdrawalSicknessRule { get; private set; }
        public IPropertyRule MethadoneUseIncreasedDoseRequiredToGetSameEffectRule { get; private set; }
        public IPropertyRule MethadoneUseLastUsedRule { get; private set; }
        public IPropertyRule MethadoneHasStrongUrgesRule { get; private set; }
        public IPropertyRule MethadoneUseNumberOfDaysUsedInPast30DaysRule { get; private set; }
        public IPropertyRule MethadoneUseNumberOfMonthsUsedInLifetimeRule { get; private set; }
        public IPropertyRule MethadoneUseRouteOfIntakeRule { get; private set; }
        public IPropertyRule MethadoneUseUseSubstanceToPreventWithdrawalSicknessRule { get; private set; }
        public IPropertyRule MethadoneUseWasSubstanceTakenAsPrescribedRule { get; private set; }
        public IPropertyRule MultipleSubstanceUsePerDayLastUsedRule { get; private set; }
        public IPropertyRule MultipleSubstanceUsePerDayNumberOfDaysUsedInPast30DaysRule { get; private set; }
        public IPropertyRule NicotineUseExperiencesWithdrawalSicknessRule { get; private set; }
        public IPropertyRule NicotineUseHasUsedSubstanceKnowingProblemsWorsenedRule { get; private set; }
        public IPropertyRule NicotineUseLastUsedRule { get; private set; }
        public IPropertyRule NicotineHasStrongUrgesRule { get; private set; }
        public IPropertyRule NicotineUseNumberOfDaysUsedInPast30DaysRule { get; private set; }
        public IPropertyRule NicotineUseSubstanceUseReductionAttemptedRule { get; private set; }
        public IPropertyRule NicotineUseUnableToStopUsingSubstanceRule { get; private set; }
        public IPropertyRule NicotineUseUseSubstanceToPreventWithdrawalSicknessRule { get; private set; }
        public IPropertyRule OpiatesInControlledEnvironmentExperiencesWithdrawalSicknessRule { get; private set; }
        public IPropertyRule OpiatesInControlledEnvironmentIncreasedDoseRequiredToGetSameEffectRule { get; private set; }
        public IPropertyRule OpiatesInControlledEnvironmentUseSubstanceToPreventWithdrawalSicknessRule { get; private set; }
        public IPropertyRule OpioidMaintenanceTherapyCompletedAtLeast6MonthOpioidMaintenanceTherapyVoluntarilyRule { get; private set; }
        public IPropertyRule OpioidMaintenanceTherapyDetoxificationEndedLessThanOrEqual2YearsAgoRule { get; private set; }
        public IPropertyRule OpioidMaintenanceTherapyGraduallyDetoxedFromOpioidMaintenanceTherapyRule { get; private set; }
        public IPropertyRule OpioidMaintenanceTherapyOpioidMaintenanceTherapyReadmissionMedicallyIndicatedRule { get; private set; }
        public IPropertyRule OpioidMaintenanceTherapyToBePrescribedOpioidDetoxificationProtocolRule { get; private set; }
        public IPropertyRule OtherOpiateUseDocumentedEvidenceOfOpioidDependenceAtLeast1YearRule { get; private set; }
        public IPropertyRule OtherOpiateUseEvidenceFromUrineScreenOfOpioidDependenceRule { get; private set; }
        public IPropertyRule OtherOpiateUseExperiencesWithdrawalSicknessRule { get; private set; }
        public IPropertyRule OtherOpiateUseIncreasedDoseRequiredToGetSameEffectRule { get; private set; }
        public IPropertyRule OtherOpiateUseLastUsedRule { get; private set; }
        public IPropertyRule OtherOpiateHasStrongUrgesRule { get; private set; }
        public IPropertyRule OtherOpiateUseNumberOfDaysUsedInPast30DaysRule { get; private set; }
        public IPropertyRule OtherOpiateUseNumberOfMonthsUsedInLifetimeRule { get; private set; }
        public IPropertyRule OtherOpiateUseOpioidRelapseLikelyIndicatorRule { get; private set; }
        public IPropertyRule OtherOpiateUseRouteOfIntakeRule { get; private set; }
        public IPropertyRule OtherOpiateUseUseSubstanceToPreventWithdrawalSicknessRule { get; private set; }
        public IPropertyRule OtherOpiateUseWasSubstanceTakenAsPrescribedRule { get; private set; }
        public IPropertyRule OtherSedativeUseExperiencesWithdrawalSicknessRule { get; private set; }
        public IPropertyRule OtherSedativeUseHasHealthCareProviderPrescribedUseRule { get; private set; }
        public IPropertyRule OtherSedativeUseLastUsedRule { get; private set; }
        public IPropertyRule OtherSedativeHasStrongUrgesRule { get; private set; }
        public IPropertyRule OtherSedativeUseNumberOfDaysUsedInPast30DaysRule { get; private set; }
        public IPropertyRule OtherSedativeUseNumberOfMonthsUsedInLifetimeRule { get; private set; }
        public IPropertyRule OtherSedativeUseUnableToStopUsingSubstanceRule { get; private set; }
        public IPropertyRule OtherSedativeUseUseSubstanceToPreventWithdrawalSicknessRule { get; private set; }
        public IPropertyRule OtherSedativeUseWasSubstanceTakenAsPrescribedRule { get; private set; }
        public IPropertyRule OtherSubstanceUseExperiencesWithdrawalSicknessRule { get; private set; }
        public IPropertyRule OtherSubstanceUseLastUsedRule { get; private set; }
        public IPropertyRule OtherSubstanceHasStrongUrgesRule { get; private set; }
        public IPropertyRule OtherSubstanceUseOtherSubstanceNameRule { get; private set; }
        public IPropertyRule OtherSubstanceUseUseSubstanceToPreventWithdrawalSicknessRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackChestPainsInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackChestPainsInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackChillsHotFlashesInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackChillsHotFlashesInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackChokingInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackChokingInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackDistortedRealityInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackDistortedRealityInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackDizzinessFaintnessInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackDizzinessFaintnessInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackDyingSensationInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackDyingSensationInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackLoseControlInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackLoseControlInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackMoreThanOnceInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackMoreThanOnceInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackNauseaDiarrheaInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackNauseaDiarrheaInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackNumbnessInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackNumbnessInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackPalpitationsInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackPalpitationsInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackRandomInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackRandomInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackShortnessBreathInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackShortnessBreathInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackSweatyInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackSweatyInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackTremblingInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackTremblingInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyAttackWithin24HoursRelatedToSubstanceUseRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyTensionWorryInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryAnxietyTensionWorryInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryCantWaitForThingsWantedBadlyRule { get; private set; }
        public IPropertyRule PsychologicalHistoryDepressionWithin24HoursRelatedToSubstanceUseRule { get; private set; }
        public IPropertyRule PsychologicalHistoryDifficultToWorkNowForFutureGainRule { get; private set; }
        public IPropertyRule PsychologicalHistoryEmotionalProblemsCorrelationWithSubstanceUseRule { get; private set; }
        public IPropertyRule PsychologicalHistoryFeelLikeFailureInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryFeelLikeFailureInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryFeelLikeFailureInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistoryHowDifficultProblemsForWorkHomeAndSocialInteractionRule { get; private set; }
        public IPropertyRule PsychologicalHistoryHowEmotionalProblemsImpactRecoveryEffortsRule { get; private set; }
        public IPropertyRule PsychologicalHistoryHowImportantPsychologicalEmotionalCounselingRule { get; private set; }
        public IPropertyRule PsychologicalHistoryHowTroubledByPsychologicalEmotionalProblemsLast30DaysRule { get; private set; }
        public IPropertyRule PsychologicalHistoryInabilityToFeelPleasureFromActivitiesInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryInabilityToFeelPleasureFromActivitiesInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryInabilityToFeelPleasureFromActivitiesInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistoryInabilityToFeelPleasureFromActivitiesRelatedToSubstanceUseRule { get; private set; }
        public IPropertyRule PsychologicalHistoryIsReceivingNeededCareRule { get; private set; }
        public IPropertyRule PsychologicalHistoryMedicatedForPsychologicalEmotionalProblemInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryMovingSpeakingSlowlyInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryMovingSpeakingSlowlyInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryMovingSpeakingSlowlyInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistoryNumberOfDaysExperiencedPsychologicalEmotionalProblemsInLast30DaysRule { get; private set; }
        public IPropertyRule PsychologicalHistoryPastPsychologicalOrEmotionalProblemsRule { get; private set; }
        public IPropertyRule PsychologicalHistoryPoorAppetiteOrOvereatingInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryPoorAppetiteOrOvereatingInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistoryPoorAppetiteOrOvereatingInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistoryReceivesPensionForPsychiatricDisabilityRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodAttemptedSuicideInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodAttemptedSuicideInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodAttemptedSuicideInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodAttemptedSuicideRelatedToSubstanceUseRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodCurbingViolentBehaviorInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodCurbingViolentBehaviorInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodCurbingViolentBehaviorInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodCurbingViolentBehaviorRelatedToSubstanceUseRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodExcessiveBehaviorInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodFidgetingInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodFidgetingInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodFidgetingInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodFlashbacksInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodHallucinationsInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodHallucinationsInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodHallucinationsInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodHallucinationsRelatedToSubstanceUseRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodImpairedThoughtInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodImpairedThoughtInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodImpairedThoughtInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodImpairedThoughtRelatedToSubstanceUseRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodIrritabilityInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodIrritabilityInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodLethargyInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodLethargyInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodLethargyInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodMuscleTensionInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodMuscleTensionInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodNegativeThoughtsInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodOfSeriousDepressionInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodOfSeriousDepressionInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodOfSeriousDepressionInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodParanoiaInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodParanoiaInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodParanoiaInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodParanoiaRelatedToSubstanceUseRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodSleepDisorderInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodSleepDisorderInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodSleepDisorderInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodSuicidalThoughtsInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodSuicidalThoughtsInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodSuicidalThoughtsInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodSuicidalThoughtsRelatedToSubstanceUseRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodThoughtsOfSelfInjuryInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodThoughtsOfSelfInjuryInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodThoughtsOfSelfInjuryInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodTroubleWithAttitudeTowardOthersInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodTroubleWithAttitudeTowardOthersInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodUntruePerceptionInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodUntruePerceptionInLastMonthRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodUntruePerceptionInLifetimeRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodUntruePerceptionRelatedToSubstanceUseRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodViolentUrgesInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistorySignificantPeriodViolentUrgesRelatedToSubstanceUseRule { get; private set; }
        public IPropertyRule PsychologicalHistoryTimesTreatedForPsychologicalOrEmotionalProblemsInHospitalRule { get; private set; }
        public IPropertyRule PsychologicalHistoryWorriedAboutAnxietyAttackInLast24HoursRule { get; private set; }
        public IPropertyRule PsychologicalHistoryWorriedAboutAnxietyAttackInLastMonthRule { get; private set; }
        public IPropertyRule SolventAndInhalantUseExperiencesWithdrawalSicknessRule { get; private set; }
        public IPropertyRule SolventAndInhalantUseLastUsedRule { get; private set; }
        public IPropertyRule SovlentAndInhalantHasStrongUrgesRule { get; private set; }
        public IPropertyRule SolventAndInhalantUseNumberOfDaysUsedInPast30DaysRule { get; private set; }
        public IPropertyRule SolventAndInhalantUseUseSubstanceToPreventWithdrawalSicknessRule { get; private set; }
        public IPropertyRule StimulantUseExperiencesWithdrawalSicknessRule { get; private set; }
        public IPropertyRule StimulantUseLastUsedRule { get; private set; }
        public IPropertyRule StimulantHasStrongUrgesRule { get; private set; }
        public IPropertyRule StimulantUseNumberOfDaysUsedInPast30DaysRule { get; private set; }
        public IPropertyRule StimulantUseUseSubstanceToPreventWithdrawalSicknessRule { get; private set; }
        public IPropertyRule UsedSubstancesSubstanceHasEverUsedRule { get; private set; }

        #endregion

        public string CompletenessCategory { get { return "Report"; } }
    }
}