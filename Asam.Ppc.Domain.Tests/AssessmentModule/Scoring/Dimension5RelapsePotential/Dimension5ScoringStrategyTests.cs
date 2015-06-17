using Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups;
using Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory;
using Asam.Ppc.Domain.AssessmentModule.Legal;
using Asam.Ppc.Domain.AssessmentModule.Psychological;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.Scoring.ScoringModule.Dimension5RelapsePotential;
using Asam.Ppc.Domain.Tests.Extensions;
using Asam.Ppc.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asam.Ppc.Domain.Tests.AssessmentModule.Scoring.Dimension5RelapsePotential
{
    [TestClass]
    public class Dimension5ScoringStrategyTests
    {
        #region Public Properties

        public TestContext TestContext { get; set; }

        #endregion
        

        #region Public Methods

        [TestMethod]
        [DataSource("D5_CareLevel_0_5_EarlyInterventionScore")]
        public void D5_CalculateCareLevel_0_5_EarlyInterventionScoreTests()
        {
            var interviewerScoreOfAttitude = new ScaleOf0To9 ( TestContext.GetUInt32("InterviewerScoreOfAttitude"));
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var likelihoodPreviousEnvironmentWillInduceSubstanceUse = TestContext.GetLookup<LikertScale>("LikelihoodPreviousEnvironmentWillInduceSubstanceUse");
            var freeTimeAffectOnRecovery = TestContext.GetLookup<FreeTimeAffectOnRecovery>("FreeTimeAffectOnRecovery");
            var dealsWithProblemsInFreeTimeThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse>("DealsWithProblemsInFreeTimeThatRiskRelapse");
            var anyAddictionDiagnosisExceptNicotine = TestContext.GetBoolean("AnyAddictionDiagnosisExceptNicotine");

            var doesNotUnderstandNeedToAlterCurrentDrugUsePattern = TestContext.GetBoolean("DoesNotUnderstandNeedToAlterCurrentDrugUsePattern");
            var needsToAcquireSkillsToChangeCurrentDrugUsePattern = TestContext.GetBoolean("NeedsToAcquireSkillsToChangeCurrentDrugUsePattern");
            var isMet = TestContext.GetBoolean("IsMet");
         
            var dimension5ScoringStrategy = new Dimension5ScoringStrategy();
            var careLevel_0_5_Score = dimension5ScoringStrategy.CalculateCareLevel_0_5_EarlyInterventionScore (
                interviewerScoreOfAttitude,
                strategyToPreventRelapse,
                likelihoodPreviousEnvironmentWillInduceSubstanceUse,
                freeTimeAffectOnRecovery,
                dealsWithProblemsInFreeTimeThatRiskRelapse,
                anyAddictionDiagnosisExceptNicotine );

            Assert.AreEqual(doesNotUnderstandNeedToAlterCurrentDrugUsePattern, careLevel_0_5_Score.DoesNotUnderstandNeedToAlterCurrentDrugUsePattern, "DoesNotUnderstandNeedToAlterCurrentDrugUsePattern didn't match.");
            Assert.AreEqual(needsToAcquireSkillsToChangeCurrentDrugUsePattern, careLevel_0_5_Score.NeedsToAcquireSkillsToChangeCurrentDrugUsePattern, "NeedsToAcquireSkillsToChangeCurrentDrugUsePattern didn't match.");
            Assert.AreEqual(isMet, careLevel_0_5_Score.IsMet, "CareLevel_III_7_Score didn't match.");
        }

        [TestMethod]
        [DataSource("D5_CareLevel_I_OutpatientScore")]
        public void D5_CalculateCareLevel_I_OutpatientScoreTests()
        {
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var desireAndExternalFactorsDrivingTreatment = TestContext.GetLookup<DesireAndExternalFactorsDrivingTreatment>("DesireAndExternalFactorsDrivingTreatment");
            var likelihoodPreviousEnvironmentWillInduceSubstanceUse = TestContext.GetLookup<LikertScale>("LikelihoodPreviousEnvironmentWillInduceSubstanceUse");
            var howTroubledByPsychologicalEmotionalProblemsLast30Days = TestContext.GetLookup<LikertScale>("HowTroubledByPsychologicalEmotionalProblemsLast30Days");
            var howDifficultProblemsForWorkHomeAndSocialInteraction = TestContext.GetLookup<ProblemsForWorkHomeAndSocialInteractionScale>("HowDifficultProblemsForWorkHomeAndSocialInteraction");
            var howImportantPsychologicalEmotionalCounseling = TestContext.GetLookup<PsychologicalEmotionalCounselingImportanceScale>("HowImportantPsychologicalEmotionalCounseling");
            var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale>("HowEmotionalProblemsImpactRecoveryEfforts");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));

            var isAbleToAchieveRecoveryGoalsOrAwarenessOfDrugProblem = TestContext.GetBoolean("IsAbleToAchieveRecoveryGoalsOrAwarenessOfDrugProblem");
            var isAbleToAchieveMentalHealthGoalsOnlyWithTherapeuticContact = TestContext.GetBoolean("IsAbleToAchieveMentalHealthGoalsOnlyWithTherapeuticContact");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            if(TestContext.GetBoolean ( "ForDebug" ))
            {
                
            }

            var dimension5ScoringStrategy = new Dimension5ScoringStrategy();
            var careLevel_I_Score = dimension5ScoringStrategy.CalculateCareLevel_I_OutpatientScore (
                helpfulnessOfTreatment,
                possibleFutureRelapseCause,
                strategyToPreventRelapse,
                desireAndExternalFactorsDrivingTreatment,
                likelihoodPreviousEnvironmentWillInduceSubstanceUse,
                howTroubledByPsychologicalEmotionalProblemsLast30Days,
                howDifficultProblemsForWorkHomeAndSocialInteraction,
                howImportantPsychologicalEmotionalCounseling,
                howEmotionalProblemsImpactRecoveryEfforts,
                patientNeedForPsychiatricPsychologicalTreatmentRating );

            Assert.AreEqual(isAbleToAchieveRecoveryGoalsOrAwarenessOfDrugProblem, careLevel_I_Score.IsAbleToAchieveRecoveryGoalsOrAwarenessOfDrugProblem, "IsAbleToAchieveRecoveryGoalsOrAwarenessOfDrugProblem didn't match.");
            Assert.AreEqual(isAbleToAchieveMentalHealthGoalsOnlyWithTherapeuticContact, careLevel_I_Score.IsAbleToAchieveMentalHealthGoalsOnlyWithTherapeuticContact, "IsAbleToAchieveMentalHealthGoalsOnlyWithTherapeuticContact didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_I_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_I_Score.IsMet, "CareLevel_I_Score didn't match.");
        }


        [TestMethod]
        [DataSource("D5_CareLevelOpioidMaintenanceTherapyScore")]
        public void D5_CalculateCareLevelOpioidMaintenanceTherapyScoreTests()
        {
            var opioidRelapseLikelyIndicator = TestContext.GetLookup<LikertScale>("OpioidRelapseLikelyIndicator");
            var highestCareLevelFailedFromInPast90Days = TestContext.GetLookup<CareLevel>("HighestCareLevelFailedFromInPast90Days");
            var likelihoodPreviousEnvironmentWillInduceSubstanceUse = TestContext.GetLookup<LikertScale>("LikelihoodPreviousEnvironmentWillInduceSubstanceUse");
            var strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers = TestContext.GetLookup<LikertScale>("StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggers");
            var currentStrengthOfSubstanceUseDesire = TestContext.GetLookup<LikertScale>("CurrentStrengthOfSubstanceUseDesire");
            var addictionSymptomsIncreasedRecently = TestContext.GetLookup<IncreaseInAddictionSymptoms>("AddictionSymptomsIncreasedRecently");
            var feelLikelyToContinueSubstanceUseOrRelapse = TestContext.GetLookup<SubstanceUseOrRelapseLikelihood>("FeelLikelyToContinueSubstanceUseOrRelapse");
            var dealsWithProblemsInFreeTimeThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse>("DealsWithProblemsInFreeTimeThatRiskRelapse");
            var interviewerScoreOfAttitude = new ScaleOf0To9 ( TestContext.GetUInt32 ( "InterviewerScoreOfAttitude" ) );
            var interviewerScoreOfReadiness = new ScaleOf0To9 ( TestContext.GetUInt32("InterviewerScoreOfReadiness"));
            var concernsAboutPursuingTreatment = TestContext.GetLookup<ConcernsAboutPursuingTreatment>("ConcernsAboutPursuingTreatment");
            var desireAndExternalFactorsDrivingTreatment = TestContext.GetLookup<DesireAndExternalFactorsDrivingTreatment>("DesireAndExternalFactorsDrivingTreatment");
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var cantWaitForThingsWantedBadly = TestContext.GetBoolean("CantWaitForThingsWantedBadly");
            var difficultToWorkNowForFutureGain = TestContext.GetBoolean("DifficultToWorkNowForFutureGain");
            var anyOpioidAddictionDiagnosis = TestContext.GetBoolean("AnyOpioidAddictionDiagnosis");

            var requiresStructuredTherapyForRecoveryDueToOpiateCravings = TestContext.GetBoolean("RequiresStructuredTherapyForRecoveryDueToOpiateCravings");
            var experiencingIntensifiedAddictionSymptomsWithDeterioratingFunctions = TestContext.GetBoolean("ExperiencingIntensifiedAddictionSymptomsWithDeteriorating");
            var hasHighRiskOfRelapseWithoutOpioidMaintenanceTherapy = TestContext.GetBoolean("HasHighRiskOfRelapseWithoutOpioidMaintenanceTherapy");
            var isMet = TestContext.GetBoolean("IsMet");
            if(TestContext.GetBoolean ( "ForDebug" ))
            {
                
            }

            var dimension5ScoringStrategy = new Dimension5ScoringStrategy();
            var careLevel_OMT_Score = dimension5ScoringStrategy.CalculateCareLevelOpioidMaintenanceTherapyScore (
                opioidRelapseLikelyIndicator,
                highestCareLevelFailedFromInPast90Days,
                likelihoodPreviousEnvironmentWillInduceSubstanceUse,
                strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers,
                currentStrengthOfSubstanceUseDesire,
                addictionSymptomsIncreasedRecently,
                feelLikelyToContinueSubstanceUseOrRelapse,
                dealsWithProblemsInFreeTimeThatRiskRelapse,
                interviewerScoreOfAttitude,
                interviewerScoreOfReadiness,
                concernsAboutPursuingTreatment,
                desireAndExternalFactorsDrivingTreatment,
                helpfulnessOfTreatment,
                possibleFutureRelapseCause,
                strategyToPreventRelapse,
                cantWaitForThingsWantedBadly,
                difficultToWorkNowForFutureGain,
                anyOpioidAddictionDiagnosis );
            
            Assert.AreEqual(requiresStructuredTherapyForRecoveryDueToOpiateCravings, careLevel_OMT_Score.RequiresStructuredTherapyForRecoveryDueToOpiateCravings, "RequiresStructuredTherapyForRecoveryDueToOpiateCravings didn't match.");
            Assert.AreEqual(experiencingIntensifiedAddictionSymptomsWithDeterioratingFunctions, careLevel_OMT_Score.ExperiencingIntensifiedAddictionSymptomsWithDeterioratingFunctions, "ExperiencingIntensifiedAddictionSymptomsWithDeterioratingFunctions didn't match.");
            Assert.AreEqual(hasHighRiskOfRelapseWithoutOpioidMaintenanceTherapy, careLevel_OMT_Score.HasHighRiskOfRelapseWithoutOpioidMaintenanceTherapy, "HasHighRiskOfRelapseWithoutOpioidMaintenanceTherapy didn't match.");
            Assert.AreEqual(isMet, careLevel_OMT_Score.IsMet, "CareLevel_OMT_Score didn't match.");
        }


        [TestMethod]
        [DataSource("D5_CareLevel_II_1_IntensiveOutpatientScore")]
        public void D5_CalculateCareLevel_II_1_IntensiveOutpatientScoreTests()
        {
            var d5_CareLevel_I_OutpatientScoreIsMet = TestContext.GetBoolean("D5_CareLevel_I_OutpatientScoreIsMet");
            var likelihoodPreviousEnvironmentWillInduceSubstanceUse = TestContext.GetLookup<LikertScale>("LikelihoodPreviousEnvironmentWillInduceSubstanceUse");
            var strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers = TestContext.GetLookup<LikertScale>("StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggers");
            var currentStrengthOfSubstanceUseDesire = TestContext.GetLookup<LikertScale>("CurrentStrengthOfSubstanceUseDesire");
            var opioidRelapseLikelyIndicator = TestContext.GetLookup<LikertScale>("OpioidRelapseLikelyIndicator");
            var feelLikelyToContinueSubstanceUseOrRelapse = TestContext.GetLookup<SubstanceUseOrRelapseLikelihood>("FeelLikelyToContinueSubstanceUseOrRelapse");
            var howTroubledByPsychologicalEmotionalProblemsLast30Days = TestContext.GetLookup<LikertScale>("HowTroubledByPsychologicalEmotionalProblemsLast30Days");
            var howDifficultProblemsForWorkHomeAndSocialInteraction = TestContext.GetLookup<ProblemsForWorkHomeAndSocialInteractionScale>("HowDifficultProblemsForWorkHomeAndSocialInteraction");
            var howImportantPsychologicalEmotionalCounseling = TestContext.GetLookup<PsychologicalEmotionalCounselingImportanceScale>("HowImportantPsychologicalEmotionalCounseling");
            var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale>("HowEmotionalProblemsImpactRecoveryEfforts");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));

            var activeParticipantWithIntensifiedSymptomsAndDeterioratingFunctions = TestContext.GetBoolean("ActiveParticipantWithIntensifiedSymptomsAndDeteriorating");
            var hasImpairedRecognitionAndModerateRiskOfRelapse = TestContext.GetBoolean("HasImpairedRecognitionAndModerateRiskOfRelapse");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            var dimension5ScoringStrategy = new Dimension5ScoringStrategy();
            var careLevel_II_1_Score = dimension5ScoringStrategy.CalculateCareLevel_II_1_IntensiveOutpatientScore (
                d5_CareLevel_I_OutpatientScoreIsMet,
                likelihoodPreviousEnvironmentWillInduceSubstanceUse,
                strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers,
                currentStrengthOfSubstanceUseDesire,
                opioidRelapseLikelyIndicator,
                feelLikelyToContinueSubstanceUseOrRelapse,
                howTroubledByPsychologicalEmotionalProblemsLast30Days,
                howDifficultProblemsForWorkHomeAndSocialInteraction,
                howImportantPsychologicalEmotionalCounseling,
                howEmotionalProblemsImpactRecoveryEfforts,
                patientNeedForPsychiatricPsychologicalTreatmentRating );

            Assert.AreEqual(activeParticipantWithIntensifiedSymptomsAndDeterioratingFunctions, careLevel_II_1_Score.ActiveParticipantWithIntensifiedSymptomsAndDeterioratingFunctions, "ActiveParticipantWithIntensifiedSymptomsAndDeterioratingFunctions didn't match.");
            Assert.AreEqual(hasImpairedRecognitionAndModerateRiskOfRelapse, careLevel_II_1_Score.HasImpairedRecognitionAndModerateRiskOfRelapse, "HasImpairedRecognitionAndModerateRiskOfRelapse didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_II_1_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_II_1_Score.IsMet, "careLevel_II_1_Score didn't match.");
        }


        [TestMethod]
        [DataSource("D5_CareLevel_II_5_PartialHospitalization")]
        public void D5_CalculateCareLevel_II_5_PartialHospitalizationScoreTests()
        {
            var d5_CareLevel_I_OutpatientScoreIsMet = TestContext.GetBoolean("D5_CareLevel_I_OutpatientScoreIsMet");
            var likelihoodPreviousEnvironmentWillInduceSubstanceUse = TestContext.GetLookup<LikertScale>("LikelihoodPreviousEnvironmentWillInduceSubstanceUse");
            var strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers = TestContext.GetLookup<LikertScale>("StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggers");
            var currentStrengthOfSubstanceUseDesire = TestContext.GetLookup<LikertScale>("CurrentStrengthOfSubstanceUseDesire");
            var opioidRelapseLikelyIndicator = TestContext.GetLookup<LikertScale>("OpioidRelapseLikelyIndicator");
            var feelLikelyToContinueSubstanceUseOrRelapse = TestContext.GetLookup<SubstanceUseOrRelapseLikelihood>("FeelLikelyToContinueSubstanceUseOrRelapse");
            var addictionSymptomsIncreasedRecently = TestContext.GetLookup<IncreaseInAddictionSymptoms>("AddictionSymptomsIncreasedRecently");
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var cantWaitForThingsWantedBadly = TestContext.GetBoolean("CantWaitForThingsWantedBadly");
            var difficultToWorkNowForFutureGain = TestContext.GetBoolean("DifficultToWorkNowForFutureGain");
            var howTroubledByPsychologicalEmotionalProblemsLast30Days = TestContext.GetLookup<LikertScale>("HowTroubledByPsychologicalEmotionalProblemsLast30Days");
            var howDifficultProblemsForWorkHomeAndSocialInteraction = TestContext.GetLookup<ProblemsForWorkHomeAndSocialInteractionScale>("HowDifficultProblemsForWorkHomeAndSocialInteraction");
            var howImportantPsychologicalEmotionalCounseling = TestContext.GetLookup<PsychologicalEmotionalCounselingImportanceScale>("HowImportantPsychologicalEmotionalCounseling");
            var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale>("HowEmotionalProblemsImpactRecoveryEfforts");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            

            var activeParticipantWithIntensifiedSymptomsDespiteModifiedTreatmentPlan = TestContext.GetBoolean("ActiveParticipantWithIntensifiedSymptomsDespiteModified");
            var hasHighLikelihoodForContinueUseOrRelapseNeedsCloseOutpatientMonitoring = TestContext.GetBoolean("HasHighLikelihoodForContinueUseOrRelapseNeedsCloseOut");
            var hasPsychiatricSymptomsHighRiskOfAlcoholDrugMentalDisorderRelapse = TestContext.GetBoolean("HasPsychiatricSymptomsHighRiskOfAlcoholDrugMentalDisorder");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            var dimension5ScoringStrategy = new Dimension5ScoringStrategy();
            var careLevel_II_5_Score = dimension5ScoringStrategy.CalculateCareLevel_II_5_PartialHospitalizationScore (
                d5_CareLevel_I_OutpatientScoreIsMet,
                likelihoodPreviousEnvironmentWillInduceSubstanceUse,
                strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers,
                currentStrengthOfSubstanceUseDesire,
                opioidRelapseLikelyIndicator,
                feelLikelyToContinueSubstanceUseOrRelapse,
                addictionSymptomsIncreasedRecently,
                helpfulnessOfTreatment,
                possibleFutureRelapseCause,
                strategyToPreventRelapse,
                livingArrangementAffectOnRecovery,
                cantWaitForThingsWantedBadly,
                difficultToWorkNowForFutureGain,
                howTroubledByPsychologicalEmotionalProblemsLast30Days,
                howDifficultProblemsForWorkHomeAndSocialInteraction,
                howImportantPsychologicalEmotionalCounseling,
                howEmotionalProblemsImpactRecoveryEfforts,
                patientNeedForPsychiatricPsychologicalTreatmentRating );
                

            Assert.AreEqual(activeParticipantWithIntensifiedSymptomsDespiteModifiedTreatmentPlan, careLevel_II_5_Score.ActiveParticipantWithIntensifiedSymptomsDespiteModifiedTreatmentPlan, "ActiveParticipantWithIntensifiedSymptomsDespiteModifiedTreatmentPlan didn't match.");
            Assert.AreEqual(hasHighLikelihoodForContinueUseOrRelapseNeedsCloseOutpatientMonitoring, careLevel_II_5_Score.HasHighLikelihoodForContinueUseOrRelapseNeedsCloseOutpatientMonitoring, "HasHighLikelihoodForContinueUseOrRelapseNeedsCloseOutpatientMonitoring didn't match.");
            Assert.AreEqual(hasPsychiatricSymptomsHighRiskOfAlcoholDrugMentalDisorderRelapse, careLevel_II_5_Score.HasPsychiatricSymptomsHighRiskOfAlcoholDrugMentalDisorderRelapse, "HasPsychiatricSymptomsHighRiskOfAlcoholDrugMentalDisorderRelapse didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_II_5_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_II_5_Score.IsMet, "CareLevel_OMT_Score didn't match.");
        }

        [TestMethod]
        [DataSource("D5_CareLevel_III_1_ClinicallyManaged")]
        public void D5_CalculateCareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScoreTests()
        {
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var freeTimeAffectOnRecovery = TestContext.GetLookup<FreeTimeAffectOnRecovery>("FreeTimeAffectOnRecovery");
            var dealsWithProblemsInFreeTimeThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse>("DealsWithProblemsInFreeTimeThatRiskRelapse");
            var strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers = TestContext.GetLookup<LikertScale>("StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggers");
            var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale>("HowEmotionalProblemsImpactRecoveryEfforts");
            var appearanceOfParanoiaOrImpairedThinking = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfParanoiaOrImpairedThinking"));
            var appearanceOfTroubleConcentratingOrRemembering = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfTroubleConcentratingOrRemembering"));
            var hasImminentSevereConsequences = TestContext.GetBoolean("HasImminentSevereConsequences");
            var interviewerScoreOfAttitude = new ScaleOf0To9 (TestContext.GetUInt32("InterviewerScoreOfAttitude"));
            var interviewerScoreOfReadiness = new ScaleOf0To9 (TestContext.GetUInt32("InterviewerScoreOfReadiness"));
            var concernsAboutPursuingTreatment = TestContext.GetLookup<ConcernsAboutPursuingTreatment>("ConcernsAboutPursuingTreatment");
            var desireAndExternalFactorsDrivingTreatment = TestContext.GetLookup<DesireAndExternalFactorsDrivingTreatment>("DesireAndExternalFactorsDrivingTreatment");
            var levelOfSupervisionNeededForProtectionFromSelfHarm = new ScaleOf0To8(TestContext.GetUInt32("LevelOfSupervisionNeededForProtectionFromSelfHarm"));
            var patientAbleToSafelyAccessNeededResources = TestContext.GetBoolean("PatientAbleToSafelyAccessNeededResources");
            var needForStaffSupportToMaintainRecovery = TestContext.GetLookup<NeedForStaffSupportToMaintainRecovery>("NeedForStaffSupportToMaintainRecovery");
            var unacceptableCareLevels = TestContext.GetLookups<CareLevel>("UnacceptableCareLevels");
            var noRelapseRecognitionImminentDangerPsychiatricProblems = TestContext.GetBoolean("NoRelapseRecognitionImminentDangerPsychiatricProblems");
            var experiencingIntensifiedAddictionSymptomsOrPsychiatric = TestContext.GetBoolean("ExperiencingIntensifiedAddictionSymptomsOrPsychiatric");
            var noRecognitionOfRelapseHarmToSelfNeeds2HourCare = TestContext.GetBoolean("NoRecognitionOfRelapseHarmToSelfNeeds2HourCare");
            var isStabilizingUnableToStopUseOrPsychiatricProblems = TestContext.GetBoolean("IsStabilizingUnableToStopUseOrPsychiatricProblems");
            var experiencingPsychiatricOrAddictionSymptomsHarm = TestContext.GetBoolean("ExperiencingPsychiatricOrAddictionSymptomsHarm");
            var hasImpairedRecognitionAndModerateRiskOfRelapse = TestContext.GetBoolean("HasImpairedRecognitionAndModerateRiskOfRelapse");

            var hasLimitedSkillsImminentDangerOfRelapseWithDangerousConsequences = TestContext.GetBoolean("HasLimitedSkillsImminentDangerOfRelapseWithDangerous");
            var understandsPsychiatricAndSubstanceAbuseRiskOfRelapseAtLowerLevelOfCare = TestContext.GetBoolean("UnderstandsPsychiatricAndSubstanceAbuseRiskOfRelapseAtLower");
            var requiresStaffSupportInRecoveryEffortAndTransitionToCommunityLife = TestContext.GetBoolean("RequiresStaffSupportInRecoveryEffortAndTransitionToCommunity");
            var highRiskOfPsychiatricAndSubstanceAbuseWithDangerousConsequencesNeeds24HourCare = TestContext.GetBoolean("HighRiskOfPsychiatricAndSubstanceAbuseWithDangerousConsequences");
            var hasModerateRiskOfPsychiatricProblemsAndSubstanceAbuseRelapseNeeds24HourCare = TestContext.GetBoolean("HasModerateRiskOfPsychiatricProblemsAndSubstanceAbuseRelapse");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");


            var dimension5ScoringStrategy = new Dimension5ScoringStrategy();
            var careLevel_III_1_Score = dimension5ScoringStrategy.
                CalculateCareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore(
                helpfulnessOfTreatment,
                possibleFutureRelapseCause,
                strategyToPreventRelapse,
                livingArrangementAffectOnRecovery,
                freeTimeAffectOnRecovery,
                dealsWithProblemsInFreeTimeThatRiskRelapse,
                strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers,
                howEmotionalProblemsImpactRecoveryEfforts,
                appearanceOfParanoiaOrImpairedThinking,
                appearanceOfTroubleConcentratingOrRemembering,
                hasImminentSevereConsequences,
                interviewerScoreOfAttitude,
                interviewerScoreOfReadiness,
                concernsAboutPursuingTreatment,
                desireAndExternalFactorsDrivingTreatment,
                levelOfSupervisionNeededForProtectionFromSelfHarm,
                patientAbleToSafelyAccessNeededResources,
                needForStaffSupportToMaintainRecovery,
                unacceptableCareLevels,
                noRelapseRecognitionImminentDangerPsychiatricProblems,
                experiencingIntensifiedAddictionSymptomsOrPsychiatric,
                noRecognitionOfRelapseHarmToSelfNeeds2HourCare,
                isStabilizingUnableToStopUseOrPsychiatricProblems,
                experiencingPsychiatricOrAddictionSymptomsHarm,
                hasImpairedRecognitionAndModerateRiskOfRelapse);


            Assert.AreEqual(hasLimitedSkillsImminentDangerOfRelapseWithDangerousConsequences, careLevel_III_1_Score.HasLimitedSkillsImminentDangerOfRelapseWithDangerousConsequences, "HasLimitedSkillsImminentDangerOfRelapseWithDangerousConsequences didn't match.");
            Assert.AreEqual(understandsPsychiatricAndSubstanceAbuseRiskOfRelapseAtLowerLevelOfCare, careLevel_III_1_Score.UnderstandsPsychiatricAndSubstanceAbuseRiskOfRelapseAtLowerLevelOfCare, "UnderstandsPsychiatricAndSubstanceAbuseRiskOfRelapseAtLowerLevelOfCare didn't match.");
            Assert.AreEqual(highRiskOfPsychiatricAndSubstanceAbuseWithDangerousConsequencesNeeds24HourCare, careLevel_III_1_Score.HighRiskOfPsychiatricAndSubstanceAbuseWithDangerousConsequencesNeeds24HourCare, "HighRiskOfPsychiatricAndSubstanceAbuseWithDangerousConsequencesNeeds24HourCare didn't match.");
            Assert.AreEqual(hasModerateRiskOfPsychiatricProblemsAndSubstanceAbuseRelapseNeeds24HourCare, careLevel_III_1_Score.HasModerateRiskOfPsychiatricProblemsAndSubstanceAbuseRelapseNeeds24HourCare, "HasModerateRiskOfPsychiatricProblemsAndSubstanceAbuseRelapseNeeds24HourCare didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_III_1_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_III_1_Score.IsMet, "CareLevel_III_1_Score didn't match.");
        }


        [TestMethod]
        [DataSource("D5_CareLevel_III_3_ClinicallyManagedMediumIntensity")]
        public void D5_CalculateCareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScoreTests()
        {
            var hasImminentSevereConsequences = TestContext.GetBoolean("HasImminentSevereConsequences");
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var freeTimeAffectOnRecovery = TestContext.GetLookup<FreeTimeAffectOnRecovery>("FreeTimeAffectOnRecovery");
            var dealsWithProblemsInFreeTimeThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse>("DealsWithProblemsInFreeTimeThatRiskRelapse");
            var strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers = TestContext.GetLookup<LikertScale>("StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggers");
            var numberOfTimesTreatedForAlcoholAbuseLifetime = TestContext.GetUInt32("NumberOfTimesTreatedForAlcoholAbuseLifetime");
            var numberOfTimesDrugTreatmentLifetime = TestContext.GetUInt32("NumberOfTimesDrugTreatmentLifetime");
            var timesTreatedForPsychologicalOrEmotionalProblemsInHospital = TestContext.GetUInt32("TimesTreatedForPsychologicalOrEmotionalProblemsInHospital");
            var receivesPensionForPsychiatricDisability = TestContext.GetBoolean("ReceivesPensionForPsychiatricDisability");
            var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale>("HowEmotionalProblemsImpactRecoveryEfforts");
            var appearanceOfParanoiaOrImpairedThinking = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfParanoiaOrImpairedThinking"));
            var appearanceOfTroubleConcentratingOrRemembering = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfTroubleConcentratingOrRemembering"));
            var currentStrengthOfSubstanceUseDesire = TestContext.GetLookup<LikertScale>("CurrentStrengthOfSubstanceUseDesire");
            var opioidRelapseLikelyIndicator = TestContext.GetLookup<LikertScale>("OpioidRelapseLikelyIndicator");
            var addictionSymptomsIncreasedRecently = TestContext.GetLookup<IncreaseInAddictionSymptoms>("AddictionSymptomsIncreasedRecently");
            var feelLikelyToContinueSubstanceUseOrRelapse = TestContext.GetLookup<SubstanceUseOrRelapseLikelihood>("FeelLikelyToContinueSubstanceUseOrRelapse");
            var highestCareLevelFailedFromInPast90Days = TestContext.GetLookup<CareLevel>("HighestCareLevelFailedFromInPast90Days");
            var appearanceOfFluctuatingOrientationInLast24Hours = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfFluctuatingOrientationInLast24Hours"));
            var appearanceOfSpeechImpairmentBadPosture = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfSpeechImpairmentBadPosture"));
            var limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers = new ScaleOf0To8(TestContext.GetUInt32("LimitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers"));
            var likelihoodOfRecurrenceOfPsychiatricDecompensation = new ScaleOf0To8(TestContext.GetUInt32("LikelihoodOfRecurrenceOfPsychiatricDecompensation"));
            var evidenceOfChronicOrganicMentalDisability = TestContext.GetLookup<YesNoNotSure>("EvidenceOfChronicOrganicMentalDisability");
            var levelOfSupervisionNeededForProtectionFromSelfHarm = new ScaleOf0To8(TestContext.GetUInt32("LevelOfSupervisionNeededForProtectionFromSelfHarm"));
            var hasPsychiatricSymptomsHighRiskOfAlcoholDrugMentalDisorderRelapse = TestContext.GetBoolean("HasPsychiatricSymptomsHighRiskOfAlcoholDrugMentalDisorderRelapse");
            
            var noRelapseRecognitionImminentDangerPsychiatricProblemsAndSubstanceAbuse = TestContext.GetBoolean("NoRelapseRecognitionImminentDangerPsychiatricProblems");
            var experiencingIntensifiedAddictionSymptomsOrPsychiatricProblemsDespiteAmendedTreatmentPlan = TestContext.GetBoolean("ExperiencingIntensifiedAddictionSymptomsOrPsychiatricProblems");
            var requiresRelapsePreventionDeliveredAtSlowerPaceIn24HourCare = TestContext.GetBoolean("RequiresRelapsePreventionDeliveredAtSlowerPaceIn24HourCare");
            var activeParticipantLowerLevelCareContinuedUseOrPsychiatricProblemsNeeds24HourCare = TestContext.GetBoolean("ActiveParticipantLowerLevelCareContinuedUseOrPsychiatric");
            var hasPsychiatricSymptomsModerateRiskOrPsychiatricProblemsSubstanceUseNeeds24HourCare = TestContext.GetBoolean("HasPsychiatricSymptomsModerateRiskOrPsychiatricProblems");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");
            if(TestContext.GetBoolean ( "ForDebug" ))
            {
                
            }

            var dimension5ScoringStrategy = new Dimension5ScoringStrategy();
            var careLevel_III_3_Score = dimension5ScoringStrategy.
                CalculateCareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore (
                    hasImminentSevereConsequences,
                    helpfulnessOfTreatment,
                    possibleFutureRelapseCause,
                    strategyToPreventRelapse,
                    livingArrangementAffectOnRecovery,
                    freeTimeAffectOnRecovery,
                    dealsWithProblemsInFreeTimeThatRiskRelapse,
                    strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers,
                    numberOfTimesTreatedForAlcoholAbuseLifetime,
                    numberOfTimesDrugTreatmentLifetime,
                    timesTreatedForPsychologicalOrEmotionalProblemsInHospital,
                    receivesPensionForPsychiatricDisability,
                    howEmotionalProblemsImpactRecoveryEfforts,
                    appearanceOfParanoiaOrImpairedThinking,
                    appearanceOfTroubleConcentratingOrRemembering,
                    currentStrengthOfSubstanceUseDesire,
                    opioidRelapseLikelyIndicator,
                    addictionSymptomsIncreasedRecently,
                    feelLikelyToContinueSubstanceUseOrRelapse,
                    highestCareLevelFailedFromInPast90Days,
                    appearanceOfFluctuatingOrientationInLast24Hours,
                    appearanceOfSpeechImpairmentBadPosture,
                    limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers,
                    likelihoodOfRecurrenceOfPsychiatricDecompensation,
                    evidenceOfChronicOrganicMentalDisability,
                    levelOfSupervisionNeededForProtectionFromSelfHarm,
                    hasPsychiatricSymptomsHighRiskOfAlcoholDrugMentalDisorderRelapse );

            Assert.AreEqual(noRelapseRecognitionImminentDangerPsychiatricProblemsAndSubstanceAbuse, careLevel_III_3_Score.NoRelapseRecognitionImminentDangerPsychiatricProblemsAndSubstanceAbuse, "NoRelapseRecognitionImminentDangerPsychiatricProblemsAndSubstanceAbuse didn't match.");
            Assert.AreEqual(experiencingIntensifiedAddictionSymptomsOrPsychiatricProblemsDespiteAmendedTreatmentPlan, careLevel_III_3_Score.ExperiencingIntensifiedAddictionSymptomsOrPsychiatricProblemsDespiteAmendedTreatmentPlan, "ExperiencingIntensifiedAddictionSymptomsOrPsychiatricProblemsDespiteAmendedTreatmentPlan didn't match.");
            Assert.AreEqual(requiresRelapsePreventionDeliveredAtSlowerPaceIn24HourCare, careLevel_III_3_Score.RequiresRelapsePreventionDeliveredAtSlowerPaceIn24HourCare, "RequiresRelapsePreventionDeliveredAtSlowerPaceIn24HourCare didn't match.");
            Assert.AreEqual(activeParticipantLowerLevelCareContinuedUseOrPsychiatricProblemsNeeds24HourCare, careLevel_III_3_Score.ActiveParticipantLowerLevelCareContinuedUseOrPsychiatricProblemsNeeds24HourCare, "ActiveParticipantLowerLevelCareContinuedUseOrPsychiatricProblemsNeeds24HourCare didn't match.");
            Assert.AreEqual(hasPsychiatricSymptomsModerateRiskOrPsychiatricProblemsSubstanceUseNeeds24HourCare, careLevel_III_3_Score.HasPsychiatricSymptomsModerateRiskOrPsychiatricProblemsSubstanceUseNeeds24HourCare, "HasPsychiatricSymptomsModerateRiskOrPsychiatricProblemsSubstanceUseNeeds24HourCare didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_III_3_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_III_3_Score.IsMet, "CareLevel_III_3_Score didn't match.");

        }


        [TestMethod]
        [DataSource("D5_CareLevel_III_5_ClinicallyManagedHighIntensity")]
        public void D5_CalculateCareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScoreTests()
        {
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var dimension2SeverityNumber = TestContext.GetInt32("Dimension2SeverityNumber");
            var dimension3SeverityNumber = TestContext.GetInt32("Dimension3SeverityNumber");
            var detoxificationRequiredMoreThanHourlyMonitoring = TestContext.GetBoolean("DetoxificationRequiredMoreThanHourlyMonitoring");
            var feelLikelyToContinueSubstanceUseOrRelapse = TestContext.GetLookup<SubstanceUseOrRelapseLikelihood>("FeelLikelyToContinueSubstanceUseOrRelapse");
            var hasImminentSevereConsequences = TestContext.GetBoolean("HasImminentSevereConsequences");
            var currentStrengthOfSubstanceUseDesire = TestContext.GetLookup<LikertScale>("CurrentStrengthOfSubstanceUseDesire");
            var opioidRelapseLikelyIndicator = TestContext.GetLookup<LikertScale>("OpioidRelapseLikelyIndicator");
            var addictionSymptomsIncreasedRecently = TestContext.GetLookup<IncreaseInAddictionSymptoms>("AddictionSymptomsIncreasedRecently");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var interviewerScoreOfAlcoholTreatmentNeed = new ScaleOf0To9( TestContext.GetUInt32("InterviewerScoreOfAlcoholTreatmentNeed"));
            var interviewerScoreOfDrugTreatmentNeed = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfDrugTreatmentNeed"));
            var concernAboutEmploymentProblemsInPast30Days = TestContext.GetLookup<LikertScale>("ConcernAboutEmploymentProblemsInPast30Days");
            var troubledByFamilyProblemsInPast30Days = TestContext.GetLookup<LikertScale>("TroubledByFamilyProblemsInPast30Days");
            var troubledBySocialProblemsInPast30Days = TestContext.GetLookup<LikertScale>("TroubledBySocialProblemsInPast30Days");
            var severityOfCurrentLegalProblems = TestContext.GetLookup<LikertScale>("SeverityOfCurrentLegalProblems");
            var highestCareLevelFailedFromInPast90Days = TestContext.GetLookup<CareLevel>("HighestCareLevelFailedFromInPast90Days");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var howTroubledByPsychologicalEmotionalProblemsLast30Days = TestContext.GetLookup<LikertScale>("HowTroubledByPsychologicalEmotionalProblemsLast30Days");
            var howDifficultProblemsForWorkHomeAndSocialInteraction = TestContext.GetLookup<ProblemsForWorkHomeAndSocialInteractionScale>("HowDifficultProblemsForWorkHomeAndSocialInteraction");
            var howImportantPsychologicalEmotionalCounseling = TestContext.GetLookup<PsychologicalEmotionalCounselingImportanceScale>("HowImportantPsychologicalEmotionalCounseling");
            var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale>("HowEmotionalProblemsImpactRecoveryEfforts");

            if(TestContext.GetBoolean ( "ForDebug" ))
            {
                
            }

            var noRecognitionOfRelapseHarmToSelfNeeds2HourCare = TestContext.GetBoolean("NoRecognitionOfRelapseHarmToSelfNeeds2HourCare");
            var isStabilizingUnableToStopUseOrPsychiatricProblemsNeeds24HourCare = TestContext.GetBoolean("IsStabilizingUnableToStopUseOrPsychiatricProblemsNeeds");
            var experiencingPsychiatricOrAddictionSymptomsHarmToSelfNeeds24HourCare = TestContext.GetBoolean("ExperiencingPsychiatricOrAddictionSymptomsHarmToSelfNeeds");
            var crisisSituationWithImminentDangerOfRelapseAndConsequences = TestContext.GetBoolean("CrisisSituationWithImminentDangerOfRelapseAndConsequences");
            var activeParticipantLowerLevelCareContinuedUseOrPsychiatricProblemsInAbsenceOf24HourCare = TestContext.GetBoolean("ActiveParticipantLowerLevelCareContinuedUseOrPsychiatric");
            var psychiatricSymptomsModerateToHighRiskOfRelapseOrMentalDisorderNeeds24HourCare = TestContext.GetBoolean("PsychiatricSymptomsModerateToHighRiskOfRelapseOrMental");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            var dimension5ScoringStrategy = new Dimension5ScoringStrategy();
            var careLevel_III_5_Score = dimension5ScoringStrategy.
                CalculateCareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore (
                    helpfulnessOfTreatment,
                    possibleFutureRelapseCause,
                    strategyToPreventRelapse,
                    dimension2SeverityNumber,
                    dimension3SeverityNumber,
                    detoxificationRequiredMoreThanHourlyMonitoring,
                    feelLikelyToContinueSubstanceUseOrRelapse,
                    hasImminentSevereConsequences,
                    currentStrengthOfSubstanceUseDesire,
                    opioidRelapseLikelyIndicator,
                    addictionSymptomsIncreasedRecently,
                    livingArrangementAffectOnRecovery,
                    interviewerScoreOfAlcoholTreatmentNeed,
                    interviewerScoreOfDrugTreatmentNeed,
                    concernAboutEmploymentProblemsInPast30Days,
                    troubledByFamilyProblemsInPast30Days,
                    troubledBySocialProblemsInPast30Days,
                    severityOfCurrentLegalProblems,
                    highestCareLevelFailedFromInPast90Days,
                    patientNeedForPsychiatricPsychologicalTreatmentRating,
                    howTroubledByPsychologicalEmotionalProblemsLast30Days,
                    howDifficultProblemsForWorkHomeAndSocialInteraction,
                    howImportantPsychologicalEmotionalCounseling,
                    howEmotionalProblemsImpactRecoveryEfforts );

            Assert.AreEqual(noRecognitionOfRelapseHarmToSelfNeeds2HourCare, careLevel_III_5_Score.NoRecognitionOfRelapseHarmToSelfNeeds2HourCare, "NoRecognitionOfRelapseHarmToSelfNeeds2HourCare didn't match.");
            Assert.AreEqual(isStabilizingUnableToStopUseOrPsychiatricProblemsNeeds24HourCare, careLevel_III_5_Score.IsStabilizingUnableToStopUseOrPsychiatricProblemsNeeds24HourCare, "IsStabilizingUnableToStopUseOrPsychiatricProblemsNeeds24HourCare didn't match.");
            Assert.AreEqual(experiencingPsychiatricOrAddictionSymptomsHarmToSelfNeeds24HourCare, careLevel_III_5_Score.ExperiencingPsychiatricOrAddictionSymptomsHarmToSelfNeeds24HourCare, "ExperiencingPsychiatricOrAddictionSymptomsHarmToSelfNeeds24HourCare didn't match.");
            Assert.AreEqual(crisisSituationWithImminentDangerOfRelapseAndConsequences, careLevel_III_5_Score.CrisisSituationWithImminentDangerOfRelapseAndConsequences, "CrisisSituationWithImminentDangerOfRelapseAndConsequences didn't match.");
            Assert.AreEqual(activeParticipantLowerLevelCareContinuedUseOrPsychiatricProblemsInAbsenceOf24HourCare, careLevel_III_5_Score.ActiveParticipantLowerLevelCareContinuedUseOrPsychiatricProblemsInAbsenceOf24HourCare, "ActiveParticipantLowerLevelCareContinuedUseOrPsychiatricProblemsInAbsenceOf24HourCare didn't match.");
            Assert.AreEqual(psychiatricSymptomsModerateToHighRiskOfRelapseOrMentalDisorderNeeds24HourCare, careLevel_III_5_Score.PsychiatricSymptomsModerateToHighRiskOfRelapseOrMentalDisorderNeeds24HourCare, "PsychiatricSymptomsModerateToHighRiskOfRelapseOrMentalDisorderNeeds24HourCare didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_III_5_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_III_5_Score.IsMet, "careLevel_III_5_Score didn't match.");
        }


        [TestMethod]
        [DataSource("D5_CareLevel_III_7_MedicallyMonitoredIntensive")]
        public void D5_CalculateCareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScoreTests()
        {
            var likelihoodPreviousEnvironmentWillInduceSubstanceUse = TestContext.GetLookup<LikertScale>("LikelihoodPreviousEnvironmentWillInduceSubstanceUse");
            var strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers = TestContext.GetLookup<LikertScale>("StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggers");
            var currentStrengthOfSubstanceUseDesire = TestContext.GetLookup<LikertScale>("CurrentStrengthOfSubstanceUseDesire");
            var feelLikelyToContinueSubstanceUseOrRelapse = TestContext.GetLookup<SubstanceUseOrRelapseLikelihood>("FeelLikelyToContinueSubstanceUseOrRelapse");
            var interviewerScoreOfAlcoholTreatmentNeed = new ScaleOf0To9 (TestContext.GetUInt32("InterviewerScoreOfAlcoholTreatmentNeed"));
            var interviewerScoreOfDrugTreatmentNeed = new ScaleOf0To9 (TestContext.GetUInt32("InterviewerScoreOfDrugTreatmentNeed"));
            var hasImminentSevereConsequences = TestContext.GetBoolean("HasImminentSevereConsequences");
            var patientManifestingSeriousRelapseBehaviors = TestContext.GetBoolean("PatientManifestingSeriousRelapseBehaviors");
            var requiresMedicalMonitoringForReemergenceOfSymptoms = TestContext.GetBoolean("RequiresMedicalMonitoringForReemergenceOfSymptoms");
            var requiresTreatmentModeOnlyAvailableInCareLevel_III_7 = TestContext.GetBoolean("RequiresTreatmentModeOnlyAvailableInCareLevel_III_7");
            var psychiatricSymptomsModerateToHighRiskOfRelapseOrMentalDisorderNeeds24HourCare = TestContext.GetBoolean("PsychiatricSymptomsModerateToHighRiskOfRelapse");

            var experiencingAcutePsychiatricOrSubstanceCrisisWithIntensifiedSymptomsNeeds24HourCare = TestContext.GetBoolean("ExperiencingAcutePsychiatricOrSubstanceCrisisWithIntensified");
            var experiencingEscalationOfRelapseOrAcuteSymptomsImminentDangerNeeds24HourCare = TestContext.GetBoolean("ExperiencingEscalationOfRelapseOrAcuteSymptomsImminent");
            var treatmentMethodsRequireIntensiveLevelMedicallyManagedProgram = TestContext.GetBoolean("TreatmentMethodsRequireIntensiveLevelMedicallyManagedProgram");
            var psychiatricSymptomsModerateToHighRiskOfRelapseOrMentalDisordersAllLowerLevelsNotFeasible = TestContext.GetBoolean("PsychiatricSymptomsModerateToHighRiskOfRelapseOrMentalDisorders");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            var dimension5ScoringStrategy = new Dimension5ScoringStrategy();
            var careLevel_III_7_Score = dimension5ScoringStrategy.
                CalculateCareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScore (
                    likelihoodPreviousEnvironmentWillInduceSubstanceUse,
                    strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers,
                    currentStrengthOfSubstanceUseDesire,
                    feelLikelyToContinueSubstanceUseOrRelapse,
                    interviewerScoreOfAlcoholTreatmentNeed,
                    interviewerScoreOfDrugTreatmentNeed,
                    hasImminentSevereConsequences,
                    patientManifestingSeriousRelapseBehaviors,
                    requiresMedicalMonitoringForReemergenceOfSymptoms,
                    requiresTreatmentModeOnlyAvailableInCareLevel_III_7,
                    psychiatricSymptomsModerateToHighRiskOfRelapseOrMentalDisorderNeeds24HourCare );

            Assert.AreEqual(experiencingAcutePsychiatricOrSubstanceCrisisWithIntensifiedSymptomsNeeds24HourCare, careLevel_III_7_Score.ExperiencingAcutePsychiatricOrSubstanceCrisisWithIntensifiedSymptomsNeeds24HourCare, "ExperiencingAcutePsychiatricOrSubstanceCrisisWithIntensifiedSymptomsNeeds24HourCare didn't match.");
            Assert.AreEqual(experiencingEscalationOfRelapseOrAcuteSymptomsImminentDangerNeeds24HourCare, careLevel_III_7_Score.ExperiencingEscalationOfRelapseOrAcuteSymptomsImminentDangerNeeds24HourCare, "ExperiencingEscalationOfRelapseOrAcuteSymptomsImminentDangerNeeds24HourCare didn't match.");
            Assert.AreEqual(treatmentMethodsRequireIntensiveLevelMedicallyManagedProgram, careLevel_III_7_Score.TreatmentMethodsRequireIntensiveLevelMedicallyManagedProgram, "TreatmentMethodsRequireIntensiveLevelMedicallyManagedProgram didn't match.");
            Assert.AreEqual(psychiatricSymptomsModerateToHighRiskOfRelapseOrMentalDisordersAllLowerLevelsNotFeasible, careLevel_III_7_Score.PsychiatricSymptomsModerateToHighRiskOfRelapseOrMentalDisordersAllLowerLevelsNotFeasible, "PsychiatricSymptomsModerateToHighRiskOfRelapseOrMentalDisordersAllLowerLevelsNotFeasible didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_III_7_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_III_7_Score.IsMet, "CareLevel_III_7_Score didn't match.");
        }

        #endregion
    }
}
