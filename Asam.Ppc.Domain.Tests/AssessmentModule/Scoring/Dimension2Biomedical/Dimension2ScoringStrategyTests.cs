using Asam.Ppc.Domain.AssessmentModule.Medical;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.Scoring.ScoringModule.Dimension2Biomedical;
using Asam.Ppc.Domain.Tests.Extensions;
using Asam.Ppc.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asam.Ppc.Domain.Tests.AssessmentModule.Scoring.Dimension2Biomedical
{
    [TestClass]
    public class Dimension2ScoringStrategyTests
    {
        #region Public Properties

        public TestContext TestContext { get; set; }

        #endregion
        

        #region Public Methods
        
        [TestMethod]
        [DataSource("D2_CareLevel_0_5_And_I_Score")]
        public void D2_CalculateCareLevel_0_5_And_CareLevel_I_ScoreTests()
        {
            var sufferedHeadTraumaInPast48Hours = TestContext.GetLookup<YesNoNotSure>("SufferedHeadTraumaInPast48Hours");
            var lostConsciousnessFromHeadTraumaInPast24Hours = TestContext.GetLookup<YesNoNotSure>("LostConsciousnessFromHeadTraumaInPast24Hours");
            var sufferedSeriousImpairmentFromOverdoseInPast24Hours = TestContext.GetLookup<YesNoNotSure>("SufferedSeriousImpairmentFromOverdoseInPast24Hours");
            var feverOf102DegreesOrMoreInPast24Hours = TestContext.GetLookup<YesNoNotSure>("FeverOf102DegreesOrMoreInPast24Hours");
            var substanceOverdoseInPast24Hours = TestContext.GetLookup<YesNoNotSure>("SubstanceOverdoseInPast24Hours");
            var needForMedicalOrPhysicalRehabilitation = TestContext.GetLookup<TreatmentNeedLevel>("NeedForMedicalOrPhysicalRehabilitation");
            var physicalHealthsEffectOnSubstanceProblems = TestContext.GetLookup<PhysicalHealthsEffectOnSubstanceProblems>("PhysicalHealthsEffectOnSubstanceProblems");
            var interviewerRatingOfPatientNeedForMedicalTreatment = new ScaleOf0To8(TestContext.GetUInt32("InterviewerRatingOfPatientNeedForMedicalTreatment"));
            var anyAddictionDiagnosisExceptNicotine = TestContext.GetBoolean("AnyAddictionDiagnosisExceptNicotine");
            
            var showsBiomedicalStabilityOrProblemsBeingAddressed = TestContext.GetBoolean("ShowsBiomedicalStabilityOrProblemsBeingAddressed");
            var isMet = TestContext.GetBoolean("IsMet");
            var showsBiomedicalStabilityCanParticipateInOutpatientTreatment = TestContext.GetBoolean("ShowsBiomedicalStabilityCanParticipateInOutpatientTreatment");
            var level_I_IsMet = TestContext.GetBoolean("Level_I_IsMet");

            var dim2ScoringStrategy = new Dimension2ScoringStrategy ( );
            var careLevel_05_Score = dim2ScoringStrategy.CalculateCareLevel_0_5_EarlyInterventionScore (
                sufferedHeadTraumaInPast48Hours, 
                lostConsciousnessFromHeadTraumaInPast24Hours, 
                sufferedSeriousImpairmentFromOverdoseInPast24Hours, 
                feverOf102DegreesOrMoreInPast24Hours,
                substanceOverdoseInPast24Hours,
                needForMedicalOrPhysicalRehabilitation,
                physicalHealthsEffectOnSubstanceProblems,
                interviewerRatingOfPatientNeedForMedicalTreatment,
                anyAddictionDiagnosisExceptNicotine );

            var careLevel_I_Score = dim2ScoringStrategy.CalculateCareLevel_I_OutpatientScore(
                sufferedHeadTraumaInPast48Hours, 
                lostConsciousnessFromHeadTraumaInPast24Hours, 
                sufferedSeriousImpairmentFromOverdoseInPast24Hours, 
                feverOf102DegreesOrMoreInPast24Hours,
                substanceOverdoseInPast24Hours,
                needForMedicalOrPhysicalRehabilitation,
                physicalHealthsEffectOnSubstanceProblems,
                interviewerRatingOfPatientNeedForMedicalTreatment,
                anyAddictionDiagnosisExceptNicotine);


            Assert.AreEqual ( showsBiomedicalStabilityOrProblemsBeingAddressed,
                              careLevel_05_Score.ShowsBiomedicalStabilityOrProblemsBeingAddressed,
                              "showsBiomedicalStabilityOrProblemsBeingAddressed didn't match." );
            Assert.AreEqual ( isMet, careLevel_05_Score.IsMet, "IsMet didn't match." );

            Assert.AreEqual ( showsBiomedicalStabilityCanParticipateInOutpatientTreatment,
                              careLevel_I_Score.ShowsBiomedicalStabilityCanParticipateInPutpatientTreatment,
                              "ShowsBiomedicalStabilityCanParticipateInOutpatientTreatment didn't match." );
            Assert.AreEqual(level_I_IsMet, careLevel_I_Score.IsMet, "IsMet didn't match.");
         }

        [TestMethod]
        [DataSource("D2_CareLevelOpioidMaintenanceTherapyScore")]
        public void D2_CalculateCareLevelOpioidMaintenanceTherapyScoreTests()
        {
            var physiologicallyDependentOpiateDrugAtLeast1YearBeforeMethadoneAdmission = TestContext.GetBoolean("PhysiologicallyDependentOpiateDrugAtLeast1Year");
            var currentPhysiologicalDependenceIsConfirmed = TestContext.GetBoolean("CurrentPhysiologicalDependenceIsConfirmed");
            var sufferedHeadTraumaInPast48Hours = TestContext.GetLookup<YesNoNotSure>("SufferedHeadTraumaInPast48Hours");
            var lostConsciousnessFromHeadTraumaInPast24Hours = TestContext.GetLookup<YesNoNotSure>("LostConsciousnessFromHeadTraumaInPast24Hours");
            var sufferedSeriousImpairmentFromOverdoseInPast24Hours = TestContext.GetLookup<YesNoNotSure>("SufferedSeriousImpairmentFromOverdoseInPast24Hours");
            var feverOf102DegreesOrMoreInPast24Hours = TestContext.GetLookup<YesNoNotSure>("FeverOf102DegreesOrMoreInPast24Hours");
            var substanceOverdoseInPast24Hours =  TestContext.GetLookup<YesNoNotSure>("SubstanceOverdoseInPast24Hours");
            var needForMedicalOrPhysicalRehabilitation = TestContext.GetLookup<TreatmentNeedLevel>("NeedForMedicalOrPhysicalRehabilitation");
            var interviewerRatingOfPatientNeedForMedicalTreatment = new ScaleOf0To8(TestContext.GetUInt32("InterviewerRatingOfPatientNeedForMedicalTreatment"));
            var pregnantStatus = TestContext.GetLookup<YesNoNotSure>("PregnantStatus");
            var highRiskPregnancyStatus = TestContext.GetLookup<HighRiskPregnancyStatus>("HighRiskPregnancyStatus");
            var hivAidsMedicalTreatmentStatus = TestContext.GetLookup<YesNoNotApplicableNotSure>("HivAidsMedicalTreatmentStatus");
            var sexuallyTransmittedDiseaseStatus = TestContext.GetLookup<YesNoNotSure>("SexuallyTransmittedDiseaseStatus");
            var multipleSeizuresInPast24Hours = TestContext.GetLookup<YesNoNotSure>("MultipleSeizuresInPast24Hours");
            var hadDeliriumTremorsInPast24Hours = TestContext.GetLookup<YesNoNotSure>("HadDeliriumTremorsInPast24Hours");
            var requiresInpatientCardiacMonitoring = TestContext.GetLookup<YesNoNotSure>("RequiresInpatientCardiacMonitoring");
            var mayRequireInpatientLiverTreatment = TestContext.GetLookup<YesNoNotSure>("MayRequireInpatientLiverTreatment");
            var mayRequireInpatientGastrointestinalBleedingTreatment = TestContext.GetLookup<YesNoNotSure>("MayRequireInpatientGastrointestinalBleedingTreatment");
            var mayRequireInpatientAcutePancreatitisTreatment = TestContext.GetLookup<YesNoNotSure>("MayRequireInpatientAcutePancreatitisTreatment");
            var tuberculosisInfectionStatus = TestContext.GetLookup<TuberculosisInfectionStatus>("TuberculosisInfectionStatus");
            var anyOpioidAddictionDiagnosis = TestContext.GetBoolean("AnyOpioidAddictionDiagnosis");

            var meetsBiomedicalCriteriaForOpiateDependenceRequiresOutpatientMonitoring = TestContext.GetBoolean("MeetsBiomedicalCriteriaForOpiateDependenceRequires");
            var biomedicalProblemTreatedOutpatientMinimalDailyMonitoring = TestContext.GetBoolean("BiomedicalProblemTreatedOutpatientMinimalDailyMonitoring");
            var hasBiomedicalProblemsManagedOutpatientSpecificDiseases = TestContext.GetBoolean("HasBiomedicalProblemsManagedOutpatientSpecificDiseases");
            var isMet = TestContext.GetBoolean("IsMet");

            var dimension2ScoringStrategy = new Dimension2ScoringStrategy();
            var score = dimension2ScoringStrategy.CalculateCareLevelOpioidMaintenanceTherapyScore (
                physiologicallyDependentOpiateDrugAtLeast1YearBeforeMethadoneAdmission,
                currentPhysiologicalDependenceIsConfirmed,
                sufferedHeadTraumaInPast48Hours,
                lostConsciousnessFromHeadTraumaInPast24Hours,
                sufferedSeriousImpairmentFromOverdoseInPast24Hours,
                feverOf102DegreesOrMoreInPast24Hours,
                substanceOverdoseInPast24Hours,
                needForMedicalOrPhysicalRehabilitation,
                interviewerRatingOfPatientNeedForMedicalTreatment,
                pregnantStatus,
                highRiskPregnancyStatus,
                hivAidsMedicalTreatmentStatus,
                sexuallyTransmittedDiseaseStatus,
                multipleSeizuresInPast24Hours,
                hadDeliriumTremorsInPast24Hours,
                requiresInpatientCardiacMonitoring,
                mayRequireInpatientLiverTreatment,
                mayRequireInpatientGastrointestinalBleedingTreatment,
                mayRequireInpatientAcutePancreatitisTreatment,
                tuberculosisInfectionStatus,
                anyOpioidAddictionDiagnosis);

            Assert.AreEqual(meetsBiomedicalCriteriaForOpiateDependenceRequiresOutpatientMonitoring, score.MeetsBiomedicalCriteriaForOpiateDependenceRequiresOutpatientMonitoring, "MeetsBiomedicalCriteriaForOpiateDependenceRequiresOutpatientMonitoring didn't match.");
            Assert.AreEqual(biomedicalProblemTreatedOutpatientMinimalDailyMonitoring, score.BiomedicalProblemTreatedOutpatientMinimalDailyMonitoring, "BiomedicalProblemTreatedOutpatientMinimalDailyMonitoring didn't match.");
            Assert.AreEqual(hasBiomedicalProblemsManagedOutpatientSpecificDiseases, score.HasBiomedicalProblemsManagedOutpatientSpecificDiseases, "HasBiomedicalProblemsManagedOutpatientSpecificDiseases didn't match.");
            Assert.AreEqual(isMet, score.IsMet, "CareLevelOpioidMaintenanceTherapyScore didn't match.");
        }


        [TestMethod]
        [DataSource("D2_CareLevel_II_1_And_5_Score")]
        public void D2_CalculateCareLevel_II_1_And_5_ScoreTests()
        {
            var sufferedHeadTraumaInPast48Hours = TestContext.GetLookup<YesNoNotSure>("SufferedHeadTraumaInPast48Hours");
            var lostConsciousnessFromHeadTraumaInPast24Hours = TestContext.GetLookup<YesNoNotSure>("LostConsciousnessFromHeadTraumaInPast24Hours");
            var sufferedSeriousImpairmentFromOverdoseInPast24Hours = TestContext.GetLookup<YesNoNotSure>("SufferedSeriousImpairmentFromOverdoseInPast24Hours");
            var feverOf102DegreesOrMoreInPast24Hours = TestContext.GetLookup<YesNoNotSure>("FeverOf102DegreesOrMoreInPast24Hours");
            var interviewerRatingOfPatientNeedForMedicalTreatment = new ScaleOf0To8(TestContext.GetUInt32("InterviewerRatingOfPatientNeedForMedicalTreatment"));
            var needForMedicalOrPhysicalRehabilitation = TestContext.GetLookup<TreatmentNeedLevel>("NeedForMedicalOrPhysicalRehabilitation");
            var physicalHealthsEffectOnSubstanceProblems = TestContext.GetLookup<PhysicalHealthsEffectOnSubstanceProblems>("PhysicalHealthsEffectOnSubstanceProblems");
            var pregnantStatus = TestContext.GetLookup<YesNoNotSure>("PregnantStatus");
            var highRiskPregnancyStatus = TestContext.GetLookup<HighRiskPregnancyStatus>("HighRiskPregnancyStatus");

            var biomedicalStabilityOrAddressedConcurrentlyNotInterfereTreatment = TestContext.GetBoolean("BiomedicalStabilityOrAddressedConcurrentlyNotInterfere");
            var problemsNotSufficientInterfereTreatmentSeverityDistractsRecovery = TestContext.GetBoolean("ProblemsNotSufficientInterfereTreatmentSeverity");
            var isMet = TestContext.GetBoolean("IsMet");
            var level_II_5_IsMet = TestContext.GetBoolean("Level_II_5_IsMet");

            var dimension2ScoringStrategy = new Dimension2ScoringStrategy();
            var careLevel_II_1_Score = dimension2ScoringStrategy.CalculateCareLevel_II_1_IntensiveOutpatientScore(sufferedHeadTraumaInPast48Hours,
                lostConsciousnessFromHeadTraumaInPast24Hours,
                sufferedSeriousImpairmentFromOverdoseInPast24Hours,
                feverOf102DegreesOrMoreInPast24Hours,
                interviewerRatingOfPatientNeedForMedicalTreatment,
                needForMedicalOrPhysicalRehabilitation,
                physicalHealthsEffectOnSubstanceProblems);

            var careLevel_II_5_Score = dimension2ScoringStrategy.CalculateCareLevel_II_5_PartialHospitalizationScore(sufferedHeadTraumaInPast48Hours,
                lostConsciousnessFromHeadTraumaInPast24Hours,
                sufferedSeriousImpairmentFromOverdoseInPast24Hours,
                feverOf102DegreesOrMoreInPast24Hours,
                interviewerRatingOfPatientNeedForMedicalTreatment,
                needForMedicalOrPhysicalRehabilitation,
                physicalHealthsEffectOnSubstanceProblems,
                pregnantStatus,
                highRiskPregnancyStatus);

            Assert.AreEqual(biomedicalStabilityOrAddressedConcurrentlyNotInterfereTreatment, careLevel_II_1_Score.BiomedicalStabilityOrAddressedConcurrentlyNotInterfereTreatment, "BiomedicalStabilityOrAddressedConcurrentlyNotInterfereTreatment didn't match.");
            Assert.AreEqual(isMet, careLevel_II_1_Score.IsMet, "CareLevel_II_1_IntensiveOutpatientScore didn't match.");
            
            Assert.AreEqual(problemsNotSufficientInterfereTreatmentSeverityDistractsRecovery, careLevel_II_5_Score.ProblemsNotSufficientInterfereTreatmentSeverityDistractsRecovery, "ProblemsNotSufficientInterfereTreatmentSeverityDistractsRecovery didn't match.");
            Assert.AreEqual(level_II_5_IsMet, careLevel_II_5_Score.IsMet, "CareLevel_II_5_PartialHospitalizationScore didn't match.");
        }


        [TestMethod]
        [DataSource("D2_CareLevel_III_1_3_5_ResidentialTreatmentScore")]
        public void D2_CalculateCareLevel_III_1_3_5_ClinicallyManagedResidentialTreatmentScorTests()
        {
            var sufferedHeadTraumaInPast48Hours = TestContext.GetLookup<YesNoNotSure>("SufferedHeadTraumaInPast48Hours");
            var lostConsciousnessFromHeadTraumaInPast24Hours = TestContext.GetLookup<YesNoNotSure>("LostConsciousnessFromHeadTraumaInPast24Hours");
            var sufferedSeriousImpairmentFromOverdoseInPast24Hours = TestContext.GetLookup<YesNoNotSure>("SufferedSeriousImpairmentFromOverdoseInPast24Hours");
            var feverOf102DegreesOrMoreInPast24Hours = TestContext.GetLookup<YesNoNotSure>("FeverOf102DegreesOrMoreInPast24Hours");
            var interviewerRatingOfPatientNeedForMedicalTreatment = new ScaleOf0To8(TestContext.GetUInt32("InterviewerRatingOfPatientNeedForMedicalTreatment"));
            var needForMedicalOrPhysicalRehabilitation = TestContext.GetLookup<TreatmentNeedLevel>("NeedForMedicalOrPhysicalRehabilitation");
            var isAbleToSelfAdministerMedication = TestContext.GetLookup<YesNoNotApplicable>("IsAbleToSelfAdministerMedication");
            var physicalHealthsEffectOnSubstanceProblems = TestContext.GetLookup<PhysicalHealthsEffectOnSubstanceProblems>("PhysicalHealthsEffectOnSubstanceProblems");
            var sexuallyTransmittedDiseaseStatus = TestContext.GetLookup<YesNoNotSure>("SexuallyTransmittedDiseaseStatus");
            var unsteadinessOrLossOfBalance = TestContext.GetLookup<YesNoNotSure>("UnsteadinessOrLossOfBalance");
            var mobilityProblemsMayAffectTreatmentAttendance = TestContext.GetLookup<YesNoNotSure>("MobilityProblemsMayAffectTreatmentAttendance");

            var biomedicalStabilityNoMedicalNurseMonitoring = TestContext.GetBoolean("BiomedicalStabilityNoMedicalNurseMonitoring");
            var biomedicalSeverityNotWarrantInpatientTreatmentSufficientDistractRecovery = TestContext.GetBoolean("BiomedicalSeverityNotWarrantInpatientTreatmentSufficient");
            var biomedicalProblemWarrantsEnhancedStaffAttention = TestContext.GetBoolean("BiomedicalProblemWarrantsEnhancedStaffAttention");
            var isMet = TestContext.GetBoolean("IsMet");
            var isMetDim2Level3LowIntensity = TestContext.GetBoolean("IsMetDim2Level3LowIntensity");

            var dimension2ScoringStrategy = new Dimension2ScoringStrategy();
            var careLevel_III_1_Score = dimension2ScoringStrategy.
                CalculateCareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore (
                    sufferedHeadTraumaInPast48Hours,
                    lostConsciousnessFromHeadTraumaInPast24Hours,
                    sufferedSeriousImpairmentFromOverdoseInPast24Hours,
                    feverOf102DegreesOrMoreInPast24Hours,
                    interviewerRatingOfPatientNeedForMedicalTreatment,
                    needForMedicalOrPhysicalRehabilitation,
                    isAbleToSelfAdministerMedication,
                    physicalHealthsEffectOnSubstanceProblems,
                    sexuallyTransmittedDiseaseStatus,
                    unsteadinessOrLossOfBalance,
                    mobilityProblemsMayAffectTreatmentAttendance );

            Assert.AreEqual(biomedicalStabilityNoMedicalNurseMonitoring, careLevel_III_1_Score.BiomedicalStabilityNoMedicalNurseMonitoring, "BiomedicalStabilityNoMedicalNurseMonitoring didn't match.");
            Assert.AreEqual(biomedicalSeverityNotWarrantInpatientTreatmentSufficientDistractRecovery, careLevel_III_1_Score.BiomedicalSeverityNotWarrantInpatientTreatmentSufficientDistractRecovery, "BiomedicalSeverityNotWarrantInpatientTreatmentSufficientDistractRecovery didn't match.");
            Assert.AreEqual(biomedicalProblemWarrantsEnhancedStaffAttention, careLevel_III_1_Score.BiomedicalProblemWarrantsEnhancedStaffAttention, "BiomedicalProblemWarrantsEnhancedStaffAttention didn't match.");
            Assert.AreEqual(isMetDim2Level3LowIntensity, careLevel_III_1_Score.IsMetDim2Level3LowIntensity, "IsMetDim2Level3LowIntensity didn't match.");
            Assert.AreEqual(isMet, careLevel_III_1_Score.IsMet, "CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore didn't match.");
        }

        [TestMethod]
        [DataSource("D2_CareLevel_III_7_MedicallyMonitoredTreatmentScore")]
        public void D2_CalculateCareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScoreTests()
        {
            var interviewerRatingOfPatientNeedForMedicalTreatment = new ScaleOf0To8(TestContext.GetUInt32("InterviewerRatingOfPatientNeedForMedicalTreatment"));
            var highRiskPregnancyStatus = TestContext.GetLookup<HighRiskPregnancyStatus>("HighRiskPregnancyStatus");
            var medicalProblemThatWouldComplicateDetoxificationStatus = TestContext.GetLookup<YesNoNotSure>("MedicalProblemThatWouldComplicateDetoxificationStatus");
            var medicalConditionExacerbatedByContinuedSubstanceUse = TestContext.GetLookup<YesNoNotSure>("MedicalConditionExacerbatedByContinuedSubstanceUse");
            var needForMedicalOrPhysicalRehabilitation = TestContext.GetLookup<TreatmentNeedLevel>("NeedForMedicalOrPhysicalRehabilitation");
            var isAbleToSelfAdministerMedication = TestContext.GetLookup<YesNoNotApplicable>("IsAbleToSelfAdministerMedication");
            var unsteadinessOrLossOfBalance = TestContext.GetLookup<YesNoNotSure>("UnsteadinessOrLossOfBalance");
            var mobilityProblemsMayAffectTreatmentAttendance = TestContext.GetLookup<YesNoNotSure>("MobilityProblemsMayAffectTreatmentAttendance");


            var interactionOfDrugAlcoholAndBiomedicalSeriousDamageToPhysicalHealth = TestContext.GetBoolean("InteractionOfDrugAlcoholAndBiomedicalSeriousDamage");
            var biomedicalRequiresMedicalMonitoringNotFullResourcesOfAcuteHospital = TestContext.GetBoolean("BiomedicalRequiresMedicalMonitoringNotFullResources");
            var requiresDegreeStaffAttentionNotAvailableInOtherLevel7Programs = TestContext.GetBoolean("RequiresDegreeStaffAttentionNotAvailableInOtherLevel7Programs");
            var isMet = TestContext.GetBoolean("IsMet");
            var isMetDim2Level3MedicalMonitoring = TestContext.GetBoolean("IsMetDim2Level3MedicalMonitoring");
           
            var dimension2ScoringStrategy = new Dimension2ScoringStrategy();
            var careLevel_III_7_Score = dimension2ScoringStrategy.
                CalculateCareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScore (
                    interviewerRatingOfPatientNeedForMedicalTreatment,
                    highRiskPregnancyStatus,
                    medicalProblemThatWouldComplicateDetoxificationStatus,
                    medicalConditionExacerbatedByContinuedSubstanceUse,
                    needForMedicalOrPhysicalRehabilitation,
                    isAbleToSelfAdministerMedication,
                    unsteadinessOrLossOfBalance,
                    mobilityProblemsMayAffectTreatmentAttendance );

            Assert.AreEqual(interactionOfDrugAlcoholAndBiomedicalSeriousDamageToPhysicalHealth, careLevel_III_7_Score.InteractionOfDrugAlcoholAndBiomedicalSeriousDamageToPhysicalHealth, "InteractionOfDrugAlcoholAndBiomedicalSeriousDamageToPhysicalHealth didn't match.");
            Assert.AreEqual(biomedicalRequiresMedicalMonitoringNotFullResourcesOfAcuteHospital, careLevel_III_7_Score.BiomedicalRequiresMedicalMonitoringNotFullResourcesOfAcuteHospital, "BiomedicalRequiresMedicalMonitoringNotFullResourcesOfAcuteHospital didn't match.");
            Assert.AreEqual(requiresDegreeStaffAttentionNotAvailableInOtherLevel7Programs, careLevel_III_7_Score.RequiresDegreeStaffAttentionNotAvailableInOtherLevel7Programs, "RequiresDegreeStaffAttentionNotAvailableInOtherLevel7Programs didn't match.");
            Assert.AreEqual(isMetDim2Level3MedicalMonitoring, careLevel_III_7_Score.IsMetDim2Level3MedicalMonitoring, "IsMetDim2Level3MedicalMonitoring didn't match.");
            Assert.AreEqual(isMet, careLevel_III_7_Score.IsMet, "CareLevel_III_7_Score didn't match.");
        }



        [TestMethod]
        [DataSource("D2_CareLevel_IV_MedicallyManagedIntensiveInpatientTreatmentScore")]
        public void D2_CalculateCareLevel_IV_MedicallyManagedIntensiveInpatientTreatmentScoreTests()
        {
            var needForMedicalOrPhysicalRehabilitation = TestContext.GetLookup<TreatmentNeedLevel>("NeedForMedicalOrPhysicalRehabilitation");
            var interviewerRatingOfPatientNeedForMedicalTreatment = new ScaleOf0To8(TestContext.GetUInt32("InterviewerRatingOfPatientNeedForMedicalTreatment"));
            var highRiskPregnancyStatus = TestContext.GetLookup<HighRiskPregnancyStatus>("HighRiskPregnancyStatus");
            var medicalProblemThatWouldComplicateDetoxificationStatus = TestContext.GetLookup<YesNoNotSure>("MedicalProblemThatWouldComplicateDetoxificationStatus");
            var hasAlcoholImminentWithdrawalPotential = TestContext.GetBoolean("HasAlcoholImminentWithdrawalPotential");
            var hasHeroinImminentWithdrawalPotential = TestContext.GetBoolean("HasHeroinImminentWithdrawalPotential");
            var hasMethadoneImminentWithdrawalPotential = TestContext.GetBoolean("HasMethadoneImminentWithdrawalPotential");
            var hasOtherOpiateImminentWithdrawalPotential = TestContext.GetBoolean("HasOtherOpiateImminentWithdrawalPotential");
            var hasBarbiturateImminentWithdrawalPotential = TestContext.GetBoolean("HasBarbiturateImminentWithdrawalPotential");
            var hasOtherSedativeHypnoticImminentWithdrawalPotential = TestContext.GetBoolean("HasOtherSedativeHypnoticImminentWithdrawalPotential");
            var hasCocaineImminentWithdrawalPotential = TestContext.GetBoolean("HasCocaineImminentWithdrawalPotential");
            var hasStimulantImminentWithdrawalPotential = TestContext.GetBoolean("HasStimulantImminentWithdrawalPotential");
            var sufferedHeadTraumaInPast48Hours = TestContext.GetLookup<YesNoNotSure>("SufferedHeadTraumaInPast48Hours");
            var lostConsciousnessFromHeadTraumaInPast24Hours = TestContext.GetLookup<YesNoNotSure>("LostConsciousnessFromHeadTraumaInPast24Hours");
            var multipleSeizuresInPast24Hours = TestContext.GetLookup<YesNoNotSure>("MultipleSeizuresInPast24Hours");
            var requiresInpatientCardiacMonitoring = TestContext.GetLookup<YesNoNotSure>("RequiresInpatientCardiacMonitoring");
            var mayRequireInpatientGastrointestinalBleedingTreatment = TestContext.GetLookup<YesNoNotSure>("MayRequireInpatientGastrointestinalBleedingTreatment");
            var mayRequireInpatientAcutePancreatitisTreatment = TestContext.GetLookup<YesNoNotSure>("MayRequireInpatientAcutePancreatitisTreatment");
            var symptomsLifeThreateningBecauseOfSubstanceUse = TestContext.GetLookup<YesNoNotSure>("SymptomsLifeThreateningBecauseOfSubstanceUse");
            var medicalConditionExacerbatedByContinuedSubstanceUse = TestContext.GetLookup<YesNoNotSure>("MedicalConditionExacerbatedByContinuedSubstanceUse");
            var experiencedAcuteAlcoholDisulfiramReactionInPast24HoursStatus = TestContext.GetLookup<YesNoNotSure>("ExperiencedAcuteAlcoholDisulfiramReactionInPast24HoursStatus");
            var signsOfToxicPsychosisExist = TestContext.GetLookup<YesNoNotSure>("SignsOfToxicPsychosisExist");
            var hadDeliriumTremorsInPast24Hours = TestContext.GetLookup<YesNoNotSure>("HadDeliriumTremorsInPast24Hours");
            var mayRequireInpatientLiverTreatment = TestContext.GetLookup<YesNoNotSure>("MayRequireInpatientLiverTreatment");
            var sufferedSeriousImpairmentFromOverdoseInPast24Hours = TestContext.GetLookup<YesNoNotSure>("SufferedSeriousImpairmentFromOverdoseInPast24Hours");


            var biomedicalComplicationsAddictiveDisorderRequiresMedicalManagement = TestContext.GetBoolean("BiomedicalComplicationsAddictiveDisorderRequiresMedical");
            var continuedUseSeriousDamageToPhysicalHealthOr24HourObservation = TestContext.GetBoolean("ContinuedUseSeriousDamageToPhysicalHealthOr24HourObs");
            var isMet = TestContext.GetBoolean("IsMet");


            var dimension2ScoringStrategy = new Dimension2ScoringStrategy();
            var careLevel_III_7_Score = dimension2ScoringStrategy.CalculateCareLevel_IV_MedicallyManagedIntensiveInpatientTreatmentScore(
                needForMedicalOrPhysicalRehabilitation,
                interviewerRatingOfPatientNeedForMedicalTreatment,
                highRiskPregnancyStatus,
                medicalProblemThatWouldComplicateDetoxificationStatus,
                hasAlcoholImminentWithdrawalPotential,
                hasHeroinImminentWithdrawalPotential,
                hasMethadoneImminentWithdrawalPotential,
                hasOtherOpiateImminentWithdrawalPotential,
                hasBarbiturateImminentWithdrawalPotential,
                hasOtherSedativeHypnoticImminentWithdrawalPotential,
                hasCocaineImminentWithdrawalPotential,
                hasStimulantImminentWithdrawalPotential,
                sufferedHeadTraumaInPast48Hours,
                lostConsciousnessFromHeadTraumaInPast24Hours,
                multipleSeizuresInPast24Hours,
                requiresInpatientCardiacMonitoring,
                mayRequireInpatientGastrointestinalBleedingTreatment,
                mayRequireInpatientAcutePancreatitisTreatment,
                symptomsLifeThreateningBecauseOfSubstanceUse,
                medicalConditionExacerbatedByContinuedSubstanceUse,
                experiencedAcuteAlcoholDisulfiramReactionInPast24HoursStatus,
                signsOfToxicPsychosisExist,
                hadDeliriumTremorsInPast24Hours,
                mayRequireInpatientLiverTreatment,
                sufferedSeriousImpairmentFromOverdoseInPast24Hours);

            Assert.AreEqual(biomedicalComplicationsAddictiveDisorderRequiresMedicalManagement, careLevel_III_7_Score.BiomedicalComplicationsAddictiveDisorderRequiresMedicalManagement, "BiomedicalComplicationsAddictiveDisorderRequiresMedicalManagement didn't match.");
            Assert.AreEqual(continuedUseSeriousDamageToPhysicalHealthOr24HourObservation, careLevel_III_7_Score.ContinuedUseSeriousDamageToPhysicalHealthOr24HourObservation, "ContinuedUseSeriousDamageToPhysicalHealthOr24HourObservation didn't match.");
            Assert.AreEqual(isMet, careLevel_III_7_Score.IsMet, "CareLevel_III_7_Score didn't match.");
        }

        #endregion
    }
}
