using Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups;
using Asam.Ppc.Domain.AssessmentModule.Legal;
using Asam.Ppc.Domain.AssessmentModule.Psychological;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.Scoring.ScoringModule.Dimension4ReadinessToChange;
using Asam.Ppc.Domain.Tests.Extensions;
using Asam.Ppc.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asam.Ppc.Domain.Tests.AssessmentModule.Scoring.Dimension4ReadinessToChange
{
    [TestClass]
    public class Dimension4ScoringStrategyTests
    {
        #region Public Properties

        public TestContext TestContext { get; set; }

        #endregion

        #region Public Methods

        [TestMethod]
        [DataSource("D4_CareLevel_0_5_EarlyIntervention")]
        public void D4_CalculateCareLevel_0_5_EarlyInterventionScoreTests()
        {
            var troubledInLast30DaysByAlcoholProblems = TestContext.GetLookup<LikertScale>("TroubledInLast30DaysByAlcoholProblems");
            var troubledInLast30DaysByDrugProblems = TestContext.GetLookup<LikertScale>("TroubledInLast30DaysByDrugProblems");
            var interviewerScoreOfAttitude = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfAttitude"));
            var interviewerScoreOfReadiness = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfReadiness"));
            var diagnosedWithAddictionOtherThanNicotine = TestContext.GetBoolean("DiagnosedWithAddictionOtherThanNicotine");

            var willingToGainUnderstandingOfSubstanceUseHarmfulness = TestContext.GetBoolean("WillingToGainUnderstandingOfSubstanceUseHarmfulness");

            var isMet = TestContext.GetBoolean("IsMet");

            var dim4ScoringStrategy = new Dimension4ScoringStrategy();
            var careLevel05Score = dim4ScoringStrategy.CalculateCareLevel_0_5_EarlyInterventionScore(
                troubledInLast30DaysByAlcoholProblems,
                troubledInLast30DaysByDrugProblems,
                interviewerScoreOfAttitude,
                interviewerScoreOfReadiness,
                diagnosedWithAddictionOtherThanNicotine);

            Assert.AreEqual(
                willingToGainUnderstandingOfSubstanceUseHarmfulness, 
                careLevel05Score.WillingToGainUnderstandingOfSubstanceUseHarmfulness,
                "WillingToGainUnderstandingOfSubstanceUseHarmfulness didn't match.");
            Assert.AreEqual(
                isMet, 
                careLevel05Score.IsMet,
                "IsMet didn't match.");
        }

        [TestMethod]
        [DataSource("D4_CareLevel_I_Outpatient")]
        public void D4_CalculateDimension4CareLevel_I_OutpatientScoreTests()
        {
            var interviewerScoreOfReadiness = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfReadiness"));
            var interviewerScoreOfAttitude = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfAttitude"));
            var concernsAboutPursuingTreatment = TestContext.GetLookup<ConcernsAboutPursuingTreatment>("ConcernsAboutPursuingTreatment");
            var troubledInLast30DaysByAlcoholProblems = TestContext.GetLookup<LikertScale>("TroubledInLast30DaysByAlcoholProblems");
            var troubledInLast30DaysByDrugProblems = TestContext.GetLookup<LikertScale>("TroubledInLast30DaysByDrugProblems");
            var importanceOfTreatmentForAlcoholProblems = TestContext.GetLookup<LikertScale>("ImportanceOfTreatmentForAlcoholProblems");
            var importanceOfTreatmentForDrugProblem = TestContext.GetLookup<LikertScale>("ImportanceOfTreatmentForDrugProblem");
            var howImportantPsychologicalEmotionalCounseling = TestContext.GetLookup<PsychologicalEmotionalCounselingImportanceScale>("HowImportantPsychologicalEmotionalCounseling");
            var desireAndExternalFactorsDrivingTreatment = TestContext.GetLookup<DesireAndExternalFactorsDrivingTreatment>("DesireAndExternalFactorsDrivingTreatment");

            var expressesWillingnessToParticipateInTreatment = TestContext.GetBoolean("ExpressesWillingnessToParticipateInTreatment");
            var acknowledgesProblemAndWantsHelp = TestContext.GetBoolean("AcknowledgesProblemAndWantsHelp");
            var ambivalentAboutProblemRequiresMonitoringInUnstructuredProgram = TestContext.GetBoolean("AmbivalentAboutProblemRequiresMonitoringInUnstructuredProgram");
            var doesNotRecognizeProblemRequiresMonitoringInUnstructuredProgram = TestContext.GetBoolean("DoesNotRecognizeProblemRequiresMonitoringInUnstructuredProgram");

            var isMet = TestContext.GetBoolean("IsMet");

            var dim4ScoringStrategy = new Dimension4ScoringStrategy();
            var careLevelIScore = dim4ScoringStrategy.CalculateDimension4CareLevel_I_OutpatientScore(
                interviewerScoreOfReadiness,
                interviewerScoreOfAttitude,
                concernsAboutPursuingTreatment,
                troubledInLast30DaysByAlcoholProblems,
                troubledInLast30DaysByDrugProblems,
                importanceOfTreatmentForAlcoholProblems,
                importanceOfTreatmentForDrugProblem,
                howImportantPsychologicalEmotionalCounseling,
                desireAndExternalFactorsDrivingTreatment);

            Assert.AreEqual(
                expressesWillingnessToParticipateInTreatment,
                careLevelIScore.ExpressesWillingnessToParticipateInTreatment,
                "ExpressesWillingnessToParticipateInTreatment didn't match.");
            Assert.AreEqual(
                acknowledgesProblemAndWantsHelp,
                careLevelIScore.AcknowledgesProblemAndWantsHelp,
                "AcknowledgesProblemAndWantsHelp didn't match.");
            Assert.AreEqual(
                ambivalentAboutProblemRequiresMonitoringInUnstructuredProgram,
                careLevelIScore.AmbivalentAboutProblemRequiresMonitoringInUnstructuredProgram,
                "AmbivalentAboutProblemRequiresMonitoringInUnstructuredProgram didn't match.");
            Assert.AreEqual(
                doesNotRecognizeProblemRequiresMonitoringInUnstructuredProgram,
                careLevelIScore.DoesNotRecognizeProblemRequiresMonitoringInUnstructuredProgram,
                "DoesNotRecognizeProblemRequiresMonitoringInUnstructuredProgram didn't match.");
            Assert.AreEqual(
                isMet,
                careLevelIScore.IsMet,
                "IsMet didn't match.");
        }

        [TestMethod]
        [DataSource("D4_CareLevelOpioidMaintenanceTherapy")]
        public void D4_CalculateCareLevelOpioidMaintenanceTherapyScoreTests()
        {
            var interviewScoreOfAttitude = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfAttitude"));
            var concernsAboutPursuingTreatment = TestContext.GetLookup<ConcernsAboutPursuingTreatment>("ConcernsAboutPursuingTreatment");
            var desireAndExternalFactorsDrivingTreatment = TestContext.GetLookup<DesireAndExternalFactorsDrivingTreatment>("DesireAndExternalFactorsDrivingTreatment");
            var interviewerScoreOfReadiness = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfReadiness"));
            
            var isMet = TestContext.GetBoolean("IsMet");

            var dim4ScoringStrategy = new Dimension4ScoringStrategy();
            var careLevelOpioidMaintenanceTherapyScore = dim4ScoringStrategy.CalculateCareLevelOpioidMaintenanceTherapyScore(
                interviewScoreOfAttitude,
                concernsAboutPursuingTreatment,
                desireAndExternalFactorsDrivingTreatment,
                interviewerScoreOfReadiness);

            Assert.AreEqual(
                isMet,
                careLevelOpioidMaintenanceTherapyScore.IsMet,
                "IsMet didn't match.");
        }

        [TestMethod]
        [DataSource("D4_CareLevel_II_1_IntensiveOutpatient")]
        public void D4_CalculateCareLevel_II_1_IntensiveOutpatientScoreTests()
        {
            var highestCareLevelFailedFromInPast90Days = TestContext.GetLookup<CareLevel>("HighestCareLevelFailedFromInPast90Days");
            var interviewerScoreOfReadiness = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfReadiness"));
            var interviewerScoreOfAttitude = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfAttitude"));
            var concernsAboutPursuingTreatment = TestContext.GetLookup<ConcernsAboutPursuingTreatment>("ConcernsAboutPursuingTreatment");
            var desireAndExternalFactorsDrivingTreatment = TestContext.GetLookup<DesireAndExternalFactorsDrivingTreatment>("DesireAndExternalFactorsDrivingTreatment");
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var withdrawalSymptomsAndEmotionalBehavioralProblems = TestContext.GetBoolean("WithdrawalSymptomsAndEmotionalBehavioralProblems");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var currentBehaviorInconsistentWithSelfCare = TestContext.GetLookup<YesNoNotSure>("CurrentBehaviorInconsistentWithSelfCare");
            var isPatientMisrepresentingInformation = TestContext.GetLookup<YesNoNotSure>("IsPatientMisrepresentingInformation");

            var dim4ScoringStrategy = new Dimension4ScoringStrategy();
            var calculateCareLevel_II_1_IntensiveOutpatientScore = dim4ScoringStrategy.
                CalculateCareLevel_II_1_IntensiveOutpatientScore(
                    highestCareLevelFailedFromInPast90Days,
                    interviewerScoreOfReadiness,
                    interviewerScoreOfAttitude,
                    concernsAboutPursuingTreatment,
                    desireAndExternalFactorsDrivingTreatment,
                    helpfulnessOfTreatment,
                    possibleFutureRelapseCause,
                    strategyToPreventRelapse,
                    withdrawalSymptomsAndEmotionalBehavioralProblems,
                    patientNeedForPsychiatricPsychologicalTreatmentRating,
                    currentBehaviorInconsistentWithSelfCare,
                    isPatientMisrepresentingInformation);

            var isMet = TestContext.GetBoolean("IsMet");
            var dualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            Assert.AreEqual(
                isMet,
                calculateCareLevel_II_1_IntensiveOutpatientScore.IsMet,
                "IsMet didn't match.");

            Assert.AreEqual(
                dualDiagnosisEnhanced,
                calculateCareLevel_II_1_IntensiveOutpatientScore.IsDualDiagnosisEnhanced,
                "Dual Diagnosis Enhanced did not match."
                );
        }

        [TestMethod]
        [DataSource("D4_CareLevel_II_5_PartialHospitalization")]
        public void D4_CalculateCareLevel_II_5_PartialHospitalizationScoreTests()
        {
            var highestCareLevelFailedFromInPast90Days = TestContext.GetLookup<CareLevel>("HighestCareLevelFailedFromInPast90Days");
            var interviewerScoreOfReadiness = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfReadiness"));
            var interviewerScoreOfAttitude = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfAttitude"));
            var concernsAboutPursuingTreatment = TestContext.GetLookup<ConcernsAboutPursuingTreatment>("ConcernsAboutPursuingTreatment");
            var desireAndExternalFactorsDrivingTreatment = TestContext.GetLookup<DesireAndExternalFactorsDrivingTreatment>("DesireAndExternalFactorsDrivingTreatment");
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var withdrawalSymptomsAndEmotionalBehavioralProblems = TestContext.GetBoolean("WithdrawalSymptomsAndEmotionalBehavioralProblems");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var currentBehaviorInconsistentWithSelfCare = TestContext.GetLookup<YesNoNotSure>("CurrentBehaviorInconsistentWithSelfCare");
            var isPatientMisrepresentingInformation = TestContext.GetLookup<YesNoNotSure>("IsPatientMisrepresentingInformation");

            var dim4ScoringStrategy = new Dimension4ScoringStrategy();
            var calculateCareLevel_II_5_PartialHospitalizationScore = dim4ScoringStrategy.
                CalculateCareLevel_II_5_PartialHospitalizationScore(
                    highestCareLevelFailedFromInPast90Days,
                    interviewerScoreOfReadiness,
                    interviewerScoreOfAttitude,
                    concernsAboutPursuingTreatment,
                    desireAndExternalFactorsDrivingTreatment,
                    helpfulnessOfTreatment,
                    possibleFutureRelapseCause,
                    strategyToPreventRelapse,
                    withdrawalSymptomsAndEmotionalBehavioralProblems,
                    patientNeedForPsychiatricPsychologicalTreatmentRating,
                    currentBehaviorInconsistentWithSelfCare,
                    isPatientMisrepresentingInformation);

            var isMet = TestContext.GetBoolean("IsMet");
            var dualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            Assert.AreEqual(
                isMet,
                calculateCareLevel_II_5_PartialHospitalizationScore.IsMet,
                "IsMet didn't match.");

            Assert.AreEqual(
                dualDiagnosisEnhanced,
                calculateCareLevel_II_5_PartialHospitalizationScore.IsDualDiagnosisEnhanced,
                "Dual Diagnosis Enhanced did not match."
                );
        }

        [TestMethod]
        [DataSource("D4_CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore")]
        public void D4_CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScoreTests()
        {
            var highestCareLevelFailedFromInPast90Days = TestContext.GetLookup<CareLevel>("HighestCareLevelFailedFromInPast90Days");
            var interviewerScoreOfReadiness = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfReadiness"));
            var interviewerScoreOfAttitude = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfAttitude"));
            var concernsAboutPursuingTreatment = TestContext.GetLookup<ConcernsAboutPursuingTreatment>("ConcernsAboutPursuingTreatment");
            var desireAndExternalFactorsDrivingTreatment = TestContext.GetLookup<DesireAndExternalFactorsDrivingTreatment>("DesireAndExternalFactorsDrivingTreatment");
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var withdrawalSymptomsAndEmotionalBehavioralProblems = TestContext.GetBoolean("WithdrawalSymptomsAndEmotionalBehavioralProblems");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var currentBehaviorInconsistentWithSelfCare = TestContext.GetLookup<YesNoNotSure>("CurrentBehaviorInconsistentWithSelfCare");
            var isPatientMisrepresentingInformation = TestContext.GetLookup<YesNoNotSure>("IsPatientMisrepresentingInformation");
            var meetsCareLevel_I_Outpatient = TestContext.GetBoolean("MeetsCareLevel_I_OP");
            var meetsCareLevel_II_1_IntensiveOutpatientTreatment = TestContext.GetBoolean("MeetsCareLevel_II_1_IOP");
            var meetsCareLevel_II_1_IntensiveOutpatientTreatmentDualDiagnosisCapable = TestContext.GetBoolean("MeetsCareLevel_II_1_IOPddc");
            var meetsCareLevel_II_1_IntensiveOutpatientTreatmentDualDiagnosisEnhanced =TestContext.GetBoolean("MeetsCareLevel_II_1_IOPdde");
            var meetsCareLevel_II_5_PartialHospitalization = TestContext.GetBoolean("MeetsCareLevel_II_5_PH");
            var meetsCareLevel_II_5_PartialHospitalizationDualDiagnosisCapable = TestContext.GetBoolean("MeetsCareLevel_II_5_PHddc");
            var meetsCareLevel_II_5_PartialHospitalizationDualDiagnosisEnhanced = TestContext.GetBoolean("MeetsCareLevel_II_5_PHdde");
            var isCurrentlyResidingInCareLevel_III_1 = TestContext.GetBoolean("IsCurrentlyResidingInCareLevel_III_1");


            var dim4ScoringStrategy = new Dimension4ScoringStrategy();
            var calculateCareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatementScore = dim4ScoringStrategy.
                CalculateCareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore(
                interviewerScoreOfAttitude,
                interviewerScoreOfReadiness,
                meetsCareLevel_I_Outpatient,
                meetsCareLevel_II_1_IntensiveOutpatientTreatment,
                meetsCareLevel_II_1_IntensiveOutpatientTreatmentDualDiagnosisCapable,
                meetsCareLevel_II_1_IntensiveOutpatientTreatmentDualDiagnosisEnhanced,
                meetsCareLevel_II_5_PartialHospitalization,
                meetsCareLevel_II_5_PartialHospitalizationDualDiagnosisCapable,
                meetsCareLevel_II_5_PartialHospitalizationDualDiagnosisEnhanced,
                isCurrentlyResidingInCareLevel_III_1,
                highestCareLevelFailedFromInPast90Days,
                concernsAboutPursuingTreatment,
                desireAndExternalFactorsDrivingTreatment,
                helpfulnessOfTreatment,
                possibleFutureRelapseCause,
                strategyToPreventRelapse,
                withdrawalSymptomsAndEmotionalBehavioralProblems,
                patientNeedForPsychiatricPsychologicalTreatmentRating,
                currentBehaviorInconsistentWithSelfCare,
                isPatientMisrepresentingInformation
                    );

            var isMet = TestContext.GetBoolean("IsMet");
            var dualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            Assert.AreEqual(
                isMet,
                calculateCareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatementScore.IsMet,
                "IsMet didn't match.");

            Assert.AreEqual(
                dualDiagnosisEnhanced,
                calculateCareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatementScore.IsDualDiagnosisEnhanced,
                "Dual Diagnosis Enhanced did not match."
                );
        }

        [TestMethod]
        [DataSource("D4_CareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore")]
        public void D4_CareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScoreTests()
        {
            var interviewerScoreOfReadiness = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfReadiness"));
            var interviewerScoreOfAttitude = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfAttitude"));
            var concernsAboutPursuingTreatment = TestContext.GetLookup<ConcernsAboutPursuingTreatment>("ConcernsAboutPursuingTreatment");
            var desireAndExternalFactorsDrivingTreatment = TestContext.GetLookup<DesireAndExternalFactorsDrivingTreatment>("DesireAndExternalFactorsDrivingTreatment");
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var withdrawalSymptomsAndEmotionalBehavioralProblems = TestContext.GetBoolean("WithdrawalSymptomsAndEmotionalBehavioralProblems");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var currentBehaviorInconsistentWithSelfCare = TestContext.GetLookup<YesNoNotSure>("CurrentBehaviorInconsistentWithSelfCare");
            var isPatientMisrepresentingInformation = TestContext.GetLookup<YesNoNotSure>("IsPatientMisrepresentingInformation");
            var howDifficultProblemsForWorkHomeAndSocialInteraction = TestContext.GetLookup<ProblemsForWorkHomeAndSocialInteractionScale> ("HowDifficultProblemsForWorkHomeAndSocialInteraction" );
            var globalAssessmentOfFunctioningScore = TestContext.GetUInt32 ( "GlobalAssessmentOfFunctioningScore" );
            var howImportantPsychologicalEmotionalCounseling = TestContext.GetLookup<PsychologicalEmotionalCounselingImportanceScale> ( "HowImportantPsychologicalEmotionalCounseling" );
            var isAbleToSelfAdministerMedication = TestContext.GetLookup<YesNoNotApplicable> ( "IsAbleToSelfAdministerMedication" );
            
            var dim4ScoringStrategy = new Dimension4ScoringStrategy();

            var calculateCareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatementScore = dim4ScoringStrategy
                .CalculateCareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore (
                    interviewerScoreOfAttitude,
                    interviewerScoreOfReadiness,
                    concernsAboutPursuingTreatment,
                    desireAndExternalFactorsDrivingTreatment,
                    helpfulnessOfTreatment,
                    possibleFutureRelapseCause,
                    strategyToPreventRelapse,
                    withdrawalSymptomsAndEmotionalBehavioralProblems,
                    patientNeedForPsychiatricPsychologicalTreatmentRating,
                    currentBehaviorInconsistentWithSelfCare,
                    isPatientMisrepresentingInformation,
                    howDifficultProblemsForWorkHomeAndSocialInteraction,
                    globalAssessmentOfFunctioningScore,
                    howImportantPsychologicalEmotionalCounseling,
                    isAbleToSelfAdministerMedication
                );

            var isMet = TestContext.GetBoolean("IsMet");
            var dualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            Assert.AreEqual(
                isMet,
                calculateCareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatementScore.IsMet,
                "IsMet didn't match.");

            Assert.AreEqual(
                dualDiagnosisEnhanced,
                calculateCareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatementScore.IsDualDiagnosisEnhanced,
                "Dual Diagnosis Enhanced did not match."
                );
        }


        [TestMethod]
        [DataSource("D4_CareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore")]
        public void D4_CareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScoreTests()
        {
            var interviewerScoreOfReadiness = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfReadiness"));
            var interviewerScoreOfAttitude = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfAttitude"));
            var concernsAboutPursuingTreatment = TestContext.GetLookup<ConcernsAboutPursuingTreatment>("ConcernsAboutPursuingTreatment");
            var desireAndExternalFactorsDrivingTreatment = TestContext.GetLookup<DesireAndExternalFactorsDrivingTreatment>("DesireAndExternalFactorsDrivingTreatment");
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var withdrawalSymptomsAndEmotionalBehavioralProblems = TestContext.GetBoolean("WithdrawalSymptomsAndEmotionalBehavioralProblems");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var currentBehaviorInconsistentWithSelfCare = TestContext.GetLookup<YesNoNotSure>("CurrentBehaviorInconsistentWithSelfCare");
            var isPatientMisrepresentingInformation = TestContext.GetLookup<YesNoNotSure>("IsPatientMisrepresentingInformation");
            var howDifficultProblemsForWorkHomeAndSocialInteraction = TestContext.GetLookup<ProblemsForWorkHomeAndSocialInteractionScale>("HowDifficultProblemsForWorkHomeAndSocialInteraction");
            var globalAssessmentOfFunctioningScore = TestContext.GetUInt32("GlobalAssessmentOfFunctioningScore");
            var howImportantPsychologicalEmotionalCounseling = TestContext.GetLookup<PsychologicalEmotionalCounselingImportanceScale>("HowImportantPsychologicalEmotionalCounseling");
            var isAbleToSelfAdministerMedication = TestContext.GetLookup<YesNoNotApplicable>("IsAbleToSelfAdministerMedication");
            var highestCareLevelFailedFromInPast90Days = TestContext.GetLookup<CareLevel>("HighestCareLevelFailedFromInPast90Days");
            
            var dim4ScoringStrategy = new Dimension4ScoringStrategy(); 
            
            var careLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore = dim4ScoringStrategy.CalculateCareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore ( 
                    interviewerScoreOfAttitude,
                    interviewerScoreOfReadiness,
                    concernsAboutPursuingTreatment,
                    desireAndExternalFactorsDrivingTreatment,
                    helpfulnessOfTreatment,
                    possibleFutureRelapseCause,
                    strategyToPreventRelapse,
                    withdrawalSymptomsAndEmotionalBehavioralProblems,
                    patientNeedForPsychiatricPsychologicalTreatmentRating,
                    currentBehaviorInconsistentWithSelfCare,
                    isPatientMisrepresentingInformation,
                    howDifficultProblemsForWorkHomeAndSocialInteraction,
                    globalAssessmentOfFunctioningScore,
                    howImportantPsychologicalEmotionalCounseling,
                    isAbleToSelfAdministerMedication,
                    highestCareLevelFailedFromInPast90Days
                );

            var isMet = TestContext.GetBoolean("IsMet");
            var dualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            Assert.AreEqual(
                isMet,
                careLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore.IsMet,
                "IsMet didn't match.");

            Assert.AreEqual(
                dualDiagnosisEnhanced,
                careLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore.IsDualDiagnosisEnhanced,
                "Dual Diagnosis Enhanced did not match."
                );
        }


        [TestMethod]
        [DataSource("D4_CareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScore")]
        public void D4_CareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScoreTests()
        {
            var interviewerScoreOfAttitude = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfAttitude"));
            var desireAndExternalFactorsDrivingTreatment = TestContext.GetLookup<DesireAndExternalFactorsDrivingTreatment>("DesireAndExternalFactorsDrivingTreatment");
            var withdrawalSymptomsAndEmotionalBehavioralProblems = TestContext.GetBoolean("WithdrawalSymptomsAndEmotionalBehavioralProblems");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var currentBehaviorInconsistentWithSelfCare = TestContext.GetLookup<YesNoNotSure>("CurrentBehaviorInconsistentWithSelfCare");
            var isPatientMisrepresentingInformation = TestContext.GetLookup<YesNoNotSure>("IsPatientMisrepresentingInformation");
            var howImportantPsychologicalEmotionalCounseling = TestContext.GetLookup<PsychologicalEmotionalCounselingImportanceScale>("HowImportantPsychologicalEmotionalCounseling");
            var isAbleToSelfAdministerMedication = TestContext.GetLookup<YesNoNotApplicable>("IsAbleToSelfAdministerMedication");
            var patientRequires24HourControlledSupervisedEnvironment = TestContext.GetLookup<YesNoNotSure>("PatientRequires24HourControlledSupervisedEnvironment");

            var dim4ScoringStrategy = new Dimension4ScoringStrategy();

            var careLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScore = dim4ScoringStrategy.CalculateCareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScore(
                interviewerScoreOfAttitude,
                desireAndExternalFactorsDrivingTreatment,
                withdrawalSymptomsAndEmotionalBehavioralProblems,
                patientNeedForPsychiatricPsychologicalTreatmentRating,
                currentBehaviorInconsistentWithSelfCare,
                isPatientMisrepresentingInformation,
                howImportantPsychologicalEmotionalCounseling,
                isAbleToSelfAdministerMedication,
                patientRequires24HourControlledSupervisedEnvironment
                );

            var isMet = TestContext.GetBoolean("IsMet");
            var dualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            Assert.AreEqual(
                isMet,
                careLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScore.IsMet,
                "IsMet didn't match.");

            Assert.AreEqual(
                dualDiagnosisEnhanced,
                careLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScore.IsDualDiagnosisEnhanced,
                "Dual Diagnosis Enhanced did not match."
                );
        }
        #endregion
    }
}