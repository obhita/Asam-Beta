using System.Collections;
using System.Linq;
using Asam.Ppc.Domain.AssessmentModule.Completion;
using Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups;
using Asam.Ppc.Domain.AssessmentModule.EmploymentAndSupport;
using Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory;
using Asam.Ppc.Domain.AssessmentModule.Legal;
using Asam.Ppc.Domain.AssessmentModule.Psychological;
using Asam.Ppc.Domain.Common.Lookups;
using Asam.Ppc.Primitives;
using System;
using System.Collections.Generic;


namespace Asam.Ppc.Domain.AssessmentModule.Scoring.Dimension6LivingEnvironment
{ 
    public class Dimension6ScoringStrategy : IDimension6ScoringStrategy
    {
        #region Public methods

        #region Helper Methods
        private static bool IsBtw(int value, int lowerRange, int upperRange)
        {
            return value >= lowerRange && value <= upperRange;
        }

        private static bool IsBtw(uint value, uint lowerRange, uint upperRange)
        {
            return value >= lowerRange && value <= upperRange;
        }
        private static bool MoreImmedPsychD6 (uint nLimitParam, params LikertScale[] likertScales )
        {
            var offsets = new[] {0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0};
            if (offsets.Where((t, i) => likertScales[i] >= (nLimitParam + t)).Any())
            {
                return true;
            }
            return false;
        }
        #endregion 

        public CareLevel_0_5_EarlyInterventionScore CalculateCareLevel_0_5_EarlyInterventionScore( Assessment assessment )
        {
            var freeTimeAffectOnRecovery = assessment.FamilyAndSocialHistorySection.FreeTimeAffectOnRecovery;
            var livingArrangementAffectOnRecovery = assessment.FamilyAndSocialHistorySection.LivingArrangementAffectOnRecovery;
            var friendsAffectOnRecovery = assessment.FamilyAndSocialHistorySection.FriendsAffectOnRecovery;
            var closestContactsNeedsAndWillingnessToHelpTreatment = assessment.FamilyAndSocialHistorySection.ClosestContactsNeedsAndWillingnessToHelpTreatment;
            var dealsWithProblemsInFreeTimeThatRiskRelapse = assessment.FamilyAndSocialHistorySection.DealsWithProblemsInFreeTimeThatRiskRelapse;
            var anyAddictionDiagnosisExceptNicotine = assessment.AssessmentScores.DiagnosisResults.AnyAddictionDiagnosisExceptNicotine;

            return CalculateCareLevel_0_5_EarlyInterventionScore (
                freeTimeAffectOnRecovery, 
                livingArrangementAffectOnRecovery, 
                friendsAffectOnRecovery,
                closestContactsNeedsAndWillingnessToHelpTreatment,
                dealsWithProblemsInFreeTimeThatRiskRelapse,
                anyAddictionDiagnosisExceptNicotine);
        }

        public CareLevel_I_OutpatientScore CalculateCareLevel_I_OutpatientScore(Assessment assessment)
        {
            var feelLikelyToContinueSubstanceUseOrRelapse = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.FeelLikelyToContinueSubstanceUseOrRelapse;
            var livingArrangementAffectOnRecovery = assessment.FamilyAndSocialHistorySection.LivingArrangementAffectOnRecovery;
            var freeTimeAffectOnRecovery = assessment.FamilyAndSocialHistorySection.FreeTimeAffectOnRecovery;
            var dealsWithProblemsInFreeTimeThatRiskRelapse = assessment.FamilyAndSocialHistorySection.DealsWithProblemsInFreeTimeThatRiskRelapse;
            var friendsAffectOnRecovery = assessment.FamilyAndSocialHistorySection.FriendsAffectOnRecovery;
            var dealsWithProblemsFromFriendsThatRiskRelapse = assessment.FamilyAndSocialHistorySection.DealsWithProblemsFromFriendsThatRiskRelapse;
            var closestContactsNeedsAndWillingnessToHelpTreatment = assessment.FamilyAndSocialHistorySection.ClosestContactsNeedsAndWillingnessToHelpTreatment;
            var desireAndExternalFactorsDrivingTreatment = assessment.LegalSection.DesireAndExternalFactorsDrivingTreatment;
            var isAbleToLocateAndGetToCommunityResourcesSafely = assessment.FamilyAndSocialHistorySection.IsAbleToLocateAndGetToCommunityResourcesSafely;
            var mobilityProblemsMayAffectTreatmentAttendance = assessment.MedicalSection.MobilityProblemsMayAffectTreatmentAttendance;
            var concernsAboutPursuingTreatment = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.ConcernsAboutPursuingTreatment;
            var strategyToPreventRelapse = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.StrategyToPreventRelapse;          
            var howDifficultProblemsForWorkHomeAndSocialInteraction = assessment.PsychologicalSection.PsychologicalHistory.HowDifficultProblemsForWorkHomeAndSocialInteraction;
            var howEmotionalProblemsImpactRecoveryEfforts = assessment.PsychologicalSection.PsychologicalHistory.HowEmotionalProblemsImpactRecoveryEfforts;
            var patientNeedForPsychiatricPsychologicalTreatmentRating = assessment.PsychologicalSection.InterviewerRating.PatientNeedForPsychiatricPsychologicalTreatmentRating;
            var howImportantPsychologicalEmotionalCounseling = assessment.PsychologicalSection.PsychologicalHistory.HowImportantPsychologicalEmotionalCounseling;
            var intensiveCaseManagementAccessibleToPatient = assessment.PsychologicalSection.InterviewerRating.IntensiveCaseManagementAccessibleToPatient;
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = assessment.PsychologicalSection.InterviewerRating.ActivePsychiatricDiagnosesOtherThanSubstanceAbuse;
            var withdrawalSymptomsAndEmotionalBehavioralProblems = assessment.AssessmentScores.Dimension3EmotionalBehavioralScores.CommonScores. WithdrawalSymptomsAndEmotionalBehavioralProblems;
            var hasImminentSevereConsequences = assessment.AssessmentScores.Dimension5RelapsePotentialScores.HasImminentSevereConsequences;

            return CalculateCareLevel_I_OutpatientScore(
                feelLikelyToContinueSubstanceUseOrRelapse,
                livingArrangementAffectOnRecovery,
                freeTimeAffectOnRecovery,
                dealsWithProblemsInFreeTimeThatRiskRelapse,
                friendsAffectOnRecovery,
                dealsWithProblemsFromFriendsThatRiskRelapse,
                closestContactsNeedsAndWillingnessToHelpTreatment,
                desireAndExternalFactorsDrivingTreatment,
                isAbleToLocateAndGetToCommunityResourcesSafely,
                mobilityProblemsMayAffectTreatmentAttendance,
                concernsAboutPursuingTreatment,
                strategyToPreventRelapse,
                howDifficultProblemsForWorkHomeAndSocialInteraction,
                howEmotionalProblemsImpactRecoveryEfforts,
                patientNeedForPsychiatricPsychologicalTreatmentRating,
                howImportantPsychologicalEmotionalCounseling,
                intensiveCaseManagementAccessibleToPatient,
                activePsychiatricDiagnosesOtherThanSubstanceAbuse,
                withdrawalSymptomsAndEmotionalBehavioralProblems,
                hasImminentSevereConsequences);
        }

        public CareLevelOpioidMaintenanceTherapyScore CalculateCareLevelOpioidMaintenanceTherapyScore(Assessment assessment)
        {
            var feelLikelyToContinueSubstanceUseOrRelapse = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.FeelLikelyToContinueSubstanceUseOrRelapse;
            var livingArrangementAffectOnRecovery = assessment.FamilyAndSocialHistorySection.LivingArrangementAffectOnRecovery;
            var freeTimeAffectOnRecovery = assessment.FamilyAndSocialHistorySection.FreeTimeAffectOnRecovery;
            var dealsWithProblemsInFreeTimeThatRiskRelapse = assessment.FamilyAndSocialHistorySection.DealsWithProblemsInFreeTimeThatRiskRelapse;
            var friendsAffectOnRecovery = assessment.FamilyAndSocialHistorySection.FriendsAffectOnRecovery;
            var dealsWithProblemsFromFriendsThatRiskRelapse = assessment.FamilyAndSocialHistorySection.DealsWithProblemsFromFriendsThatRiskRelapse;
            var mobilityProblemsMayAffectTreatmentAttendance = assessment.MedicalSection.MobilityProblemsMayAffectTreatmentAttendance;
            var closestContactsNeedsAndWillingnessToHelpTreatment = assessment.FamilyAndSocialHistorySection.ClosestContactsNeedsAndWillingnessToHelpTreatment;
            var concernsAboutPursuingTreatment = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.ConcernsAboutPursuingTreatment;
            var strategyToPreventRelapse = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.StrategyToPreventRelapse;
            var emotionalAbuseInPast30Days = assessment.FamilyAndSocialHistorySection.EmotionalAbuseInPast30Days;
            var physicalAbuseInPast30Days = assessment.FamilyAndSocialHistorySection.PhysicalAbuseInPast30Days;
            var sexualAbuseInPast30Days = assessment.FamilyAndSocialHistorySection.SexualAbuseInPast30Days;
            var familyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II = assessment.FamilyAndSocialHistorySection.FamilyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II;
            var riskPatientHarmedByOther = assessment.FamilyAndSocialHistorySection.RiskPatientHarmedByOther;
            var wasVisitPromptedByCriminalJusticeSystem = assessment.LegalSection.WasVisitPromptedByCriminalJusticeSystem;
            var isOnProbationOrParole = assessment.LegalSection.IsOnProbationOrParole;
            var numberOfTimesArrestedForShopliftingVandalism = assessment.LegalSection.NumberOfTimesArrestedForShopliftingVandalism;
            var numberOfTimesArrestedForParoleProbationViolation = assessment.LegalSection.NumberOfTimesArrestedForParoleProbationViolation;
            var numberOfTimesArrestedForDrugCharges = assessment.LegalSection.NumberOfTimesArrestedForDrugCharges;
            var numberOfTimesArrestedForForgery = assessment.LegalSection.NumberOfTimesArrestedForForgery;
            var numberOfTimesArrestedForWeaponsOffense = assessment.LegalSection.NumberOfTimesArrestedForWeaponsOffense;
            var numberOfTimesArrestedForBurglaryLarceny = assessment.LegalSection.NumberOfTimesArrestedForBurglaryLarceny;
            var numberOfTimesArrestedForRobbery = assessment.LegalSection.NumberOfTimesArrestedForRobbery;
            var numberOfTimesArrestedForAssault = assessment.LegalSection.NumberOfTimesArrestedForAssault;
            var numberOfTimesArrestedForArson = assessment.LegalSection.NumberOfTimesArrestedForArson;
            var numberOfTimesArrestedForRape = assessment.LegalSection.NumberOfTimesArrestedForRape;
            var numberOfTimesArrestedForHomicide = assessment.LegalSection.NumberOfTimesArrestedForHomicide;
            var numberOfTimesArrestedForProstitution = assessment.LegalSection.NumberOfTimesArrestedForProstitution;
            var numberOfTimesArrestedForContemptOfCourt = assessment.LegalSection.NumberOfTimesArrestedForContemptOfCourt;
            var numberOfTimesArrestedForOtherArrest = assessment.LegalSection.NumberOfTimesArrestedForOtherArrest;
            var numberOfTimesConvicted = assessment.LegalSection.NumberOfTimesConvicted;
            var hasSuicidalThoughts = assessment.PsychologicalSection.InterviewerRating.HasSuicidalThoughts;
            var demonstratingDangerToSelfOrOthers = assessment.PsychologicalSection.InterviewerRating.DemonstratingDangerToSelfOrOthers;
            var limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers = assessment.PsychologicalSection.InterviewerRating.LimitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers;
            var indicatingRiskOfHarmToOthers = assessment.PsychologicalSection.InterviewerRating.IndicatingRiskOfHarmToOthers;
            var indicatingRiskOfHarmToSelfOrVictimizationByOthers = assessment.PsychologicalSection.InterviewerRating.IndicatingRiskOfHarmToSelfOrVictimizationByOthers;
            var anyOpioidAddictionDiagnosis = assessment.AssessmentScores.DiagnosisResults.AnyOpioidAddictionDiagnosis;

            return CalculateCareLevelOpioidMaintenanceTherapyScore(
                feelLikelyToContinueSubstanceUseOrRelapse,
                livingArrangementAffectOnRecovery,
                freeTimeAffectOnRecovery,
                dealsWithProblemsInFreeTimeThatRiskRelapse,
                friendsAffectOnRecovery,
                dealsWithProblemsFromFriendsThatRiskRelapse,            
                mobilityProblemsMayAffectTreatmentAttendance,
                closestContactsNeedsAndWillingnessToHelpTreatment,
                concernsAboutPursuingTreatment,
                strategyToPreventRelapse,
                emotionalAbuseInPast30Days,
                physicalAbuseInPast30Days,
                sexualAbuseInPast30Days,
                familyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II,
                riskPatientHarmedByOther,
                wasVisitPromptedByCriminalJusticeSystem,
                isOnProbationOrParole,
                numberOfTimesArrestedForShopliftingVandalism,
                numberOfTimesArrestedForParoleProbationViolation,
                numberOfTimesArrestedForDrugCharges,
                numberOfTimesArrestedForForgery,
                numberOfTimesArrestedForWeaponsOffense,
                numberOfTimesArrestedForBurglaryLarceny,
                numberOfTimesArrestedForRobbery,
                numberOfTimesArrestedForAssault,
                numberOfTimesArrestedForArson,
                numberOfTimesArrestedForRape,
                numberOfTimesArrestedForHomicide,
                numberOfTimesArrestedForProstitution,
                numberOfTimesArrestedForContemptOfCourt,
                numberOfTimesArrestedForOtherArrest,
                numberOfTimesConvicted,
                hasSuicidalThoughts,
                demonstratingDangerToSelfOrOthers,
                limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers,
                indicatingRiskOfHarmToOthers,
                indicatingRiskOfHarmToSelfOrVictimizationByOthers,
                anyOpioidAddictionDiagnosis);
         }

         public CareLevel_II_1_IntensiveOutpatientScore CalculateCareLevel_II_1_IntensiveOutpatientScore(Assessment assessment)
         {
            var workOrSchoolAffectOnRecovery = assessment.EmploymentAndSupportSection.WorkOrSchoolAffectOnRecovery;
            var feelLikelyToContinueSubstanceUseOrRelapse = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.FeelLikelyToContinueSubstanceUseOrRelapse;
            var livingArrangementAffectOnRecovery = assessment.FamilyAndSocialHistorySection.LivingArrangementAffectOnRecovery;
            var freeTimeAffectOnRecovery = assessment.FamilyAndSocialHistorySection.FreeTimeAffectOnRecovery;
            var concernsAboutPursuingTreatment = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.ConcernsAboutPursuingTreatment;
            var helpfulnessOfTreatment = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.HelpfulnessOfTreatment;
            var possibleFutureRelapseCause = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.PossibleFutureRelapseCause;
            var strategyToPreventRelapse = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.StrategyToPreventRelapse;
            var dealsWithProblemsInFreeTimeThatRiskRelapse = assessment.FamilyAndSocialHistorySection.DealsWithProblemsInFreeTimeThatRiskRelapse;
            var spendsFreeTimeWith = assessment.FamilyAndSocialHistorySection.SpendsFreeTimeWith;
            var numberOfCloseFriends = assessment.FamilyAndSocialHistorySection.NumberOfCloseFriends;
            var friendsAffectOnRecovery = assessment.FamilyAndSocialHistorySection.FriendsAffectOnRecovery;
            var dealsWithProblemsFromFriendsThatRiskRelapse = assessment.FamilyAndSocialHistorySection.DealsWithProblemsFromFriendsThatRiskRelapse;
            var closestContactsNeedsAndWillingnessToHelpTreatment = assessment.FamilyAndSocialHistorySection.ClosestContactsNeedsAndWillingnessToHelpTreatment;
            var appearanceOfDepressionWithdrawal = assessment.PsychologicalSection.InterviewerRating.AppearanceOfDepressionWithdrawal;
            var appearanceofAgitation = assessment.PsychologicalSection.InterviewerRating.AppearanceofAgitation;
            var appearanceOfAnxietyNervousness = assessment.PsychologicalSection.InterviewerRating.AppearanceOfAnxietyNervousness;
            var patientNeedForPsychiatricPsychologicalTreatmentRating = assessment.PsychologicalSection.InterviewerRating.PatientNeedForPsychiatricPsychologicalTreatmentRating;
            var levelOfSupervisionNeededForProtectionFromSelfHarm = assessment.PsychologicalSection.InterviewerRating.LevelOfSupervisionNeededForProtectionFromSelfHarm;

             return CalculateCareLevel_II_1_IntensiveOutpatientScore(
                workOrSchoolAffectOnRecovery,
                feelLikelyToContinueSubstanceUseOrRelapse,
                livingArrangementAffectOnRecovery,
                freeTimeAffectOnRecovery,
                concernsAboutPursuingTreatment,
                helpfulnessOfTreatment,
                possibleFutureRelapseCause,
                strategyToPreventRelapse,
                dealsWithProblemsInFreeTimeThatRiskRelapse,
                spendsFreeTimeWith,
                numberOfCloseFriends,
                friendsAffectOnRecovery,
                dealsWithProblemsFromFriendsThatRiskRelapse,
                closestContactsNeedsAndWillingnessToHelpTreatment,
                appearanceOfDepressionWithdrawal,
                appearanceofAgitation,
                appearanceOfAnxietyNervousness,
                patientNeedForPsychiatricPsychologicalTreatmentRating,
                levelOfSupervisionNeededForProtectionFromSelfHarm);
         }

        public CareLevel_II_5_PartialHospitalizationScore CalculateCareLevel_II_5_PartialHospitalizationScore(Assessment assessment)
        {
            var workOrSchoolAffectOnRecovery = assessment.EmploymentAndSupportSection.WorkOrSchoolAffectOnRecovery;
            var feelLikelyToContinueSubstanceUseOrRelapse = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.FeelLikelyToContinueSubstanceUseOrRelapse;
            var livingArrangementAffectOnRecovery = assessment.FamilyAndSocialHistorySection.LivingArrangementAffectOnRecovery;
            var freeTimeAffectOnRecovery = assessment.FamilyAndSocialHistorySection.FreeTimeAffectOnRecovery;
            var concernsAboutPursuingTreatment = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.ConcernsAboutPursuingTreatment;
            var helpfulnessOfTreatment = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.HelpfulnessOfTreatment;
            var possibleFutureRelapseCause = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.PossibleFutureRelapseCause;
            var strategyToPreventRelapse = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.StrategyToPreventRelapse;
            var dealsWithProblemsInFreeTimeThatRiskRelapse = assessment.FamilyAndSocialHistorySection.DealsWithProblemsInFreeTimeThatRiskRelapse;
            var closestContactsNeedsAndWillingnessToHelpTreatment = assessment.FamilyAndSocialHistorySection.ClosestContactsNeedsAndWillingnessToHelpTreatment;
            var appearanceOfDepressionWithdrawal = assessment.PsychologicalSection.InterviewerRating.AppearanceOfDepressionWithdrawal;
            var appearanceofAgitation = assessment.PsychologicalSection.InterviewerRating.AppearanceofAgitation;
            var appearanceOfAnxietyNervousness = assessment.PsychologicalSection.InterviewerRating.AppearanceOfAnxietyNervousness;
            var patientNeedForPsychiatricPsychologicalTreatmentRating = assessment.PsychologicalSection.InterviewerRating.PatientNeedForPsychiatricPsychologicalTreatmentRating;
            var levelOfSupervisionNeededForProtectionFromSelfHarm = assessment.PsychologicalSection.InterviewerRating.LevelOfSupervisionNeededForProtectionFromSelfHarm;

            return CalculateCareLevel_II_5_PartialHospitalizationScore(
               workOrSchoolAffectOnRecovery,
               feelLikelyToContinueSubstanceUseOrRelapse,
               livingArrangementAffectOnRecovery,
               freeTimeAffectOnRecovery,
               concernsAboutPursuingTreatment,
               helpfulnessOfTreatment,
               possibleFutureRelapseCause,
               strategyToPreventRelapse,
               dealsWithProblemsInFreeTimeThatRiskRelapse,
               closestContactsNeedsAndWillingnessToHelpTreatment,
               appearanceOfDepressionWithdrawal,
               appearanceofAgitation,
               appearanceOfAnxietyNervousness,
               patientNeedForPsychiatricPsychologicalTreatmentRating,
               levelOfSupervisionNeededForProtectionFromSelfHarm);
        }

        public CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore CalculateCareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore(Assessment assessment)
        {
            var emotionalAbuseInPast30Days = assessment.FamilyAndSocialHistorySection.EmotionalAbuseInPast30Days;
            var physicalAbuseInPast30Days = assessment.FamilyAndSocialHistorySection.PhysicalAbuseInPast30Days;
            var sexualAbuseInPast30Days = assessment.FamilyAndSocialHistorySection.SexualAbuseInPast30Days;
            var riskPatientHarmedByOther = assessment.FamilyAndSocialHistorySection.RiskPatientHarmedByOther;
            var livingArrangementAffectOnRecovery = assessment.FamilyAndSocialHistorySection.LivingArrangementAffectOnRecovery;
            var friendsAffectOnRecovery = assessment.FamilyAndSocialHistorySection.FriendsAffectOnRecovery;
            var dealsWithProblemsFromFriendsThatRiskRelapse = assessment.FamilyAndSocialHistorySection.DealsWithProblemsFromFriendsThatRiskRelapse;
            var closestContactsNeedsAndWillingnessToHelpTreatment = assessment.FamilyAndSocialHistorySection.ClosestContactsNeedsAndWillingnessToHelpTreatment;
            var spendsFreeTimeWith = assessment.FamilyAndSocialHistorySection.SpendsFreeTimeWith;
            var numberOfCloseFriends = assessment.FamilyAndSocialHistorySection.NumberOfCloseFriends;
            var closestPersonalContactInPast4Months = assessment.FamilyAndSocialHistorySection.ClosestPersonalContactInPast4Months;           
            var workOrSchoolAffectOnRecovery = assessment.EmploymentAndSupportSection.WorkOrSchoolAffectOnRecovery;
            var feelLikelyToContinueSubstanceUseOrRelapse = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.FeelLikelyToContinueSubstanceUseOrRelapse;
            var freeTimeAffectOnRecovery = assessment.FamilyAndSocialHistorySection.FreeTimeAffectOnRecovery;
            var concernsAboutPursuingTreatment = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.ConcernsAboutPursuingTreatment;
            var helpfulnessOfTreatment = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.HelpfulnessOfTreatment;
            var possibleFutureRelapseCause = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.PossibleFutureRelapseCause;
            var strategyToPreventRelapse = assessment.DrugAndAlcoholSection.AdditionalAddictionAndTreatmentItems.StrategyToPreventRelapse;
            var dealsWithProblemsInFreeTimeThatRiskRelapse = assessment.FamilyAndSocialHistorySection.DealsWithProblemsInFreeTimeThatRiskRelapse;
            var isAbleToLocateAndGetToCommunityResourcesSafely = assessment.FamilyAndSocialHistorySection.IsAbleToLocateAndGetToCommunityResourcesSafely;          
            var patientNeedForPsychiatricPsychologicalTreatmentRating = assessment.PsychologicalSection.InterviewerRating.PatientNeedForPsychiatricPsychologicalTreatmentRating;
            var howImportantPsychologicalEmotionalCounseling = assessment.PsychologicalSection.PsychologicalHistory.HowImportantPsychologicalEmotionalCounseling;
            var howEmotionalProblemsImpactRecoveryEfforts = assessment.PsychologicalSection.PsychologicalHistory.HowEmotionalProblemsImpactRecoveryEfforts;
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = assessment.PsychologicalSection.InterviewerRating.ActivePsychiatricDiagnosesOtherThanSubstanceAbuse;
            var withdrawalSymptomsAndEmotionalBehavioralProblems = assessment.AssessmentScores.Dimension3EmotionalBehavioralScores.CommonScores.WithdrawalSymptomsAndEmotionalBehavioralProblems;

            return CalculateCareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore(
               emotionalAbuseInPast30Days,
               physicalAbuseInPast30Days,
               sexualAbuseInPast30Days,
               riskPatientHarmedByOther,
               livingArrangementAffectOnRecovery,
               friendsAffectOnRecovery,
               dealsWithProblemsFromFriendsThatRiskRelapse,
               closestContactsNeedsAndWillingnessToHelpTreatment,
               spendsFreeTimeWith,
               numberOfCloseFriends,
               closestPersonalContactInPast4Months,
               workOrSchoolAffectOnRecovery,
               feelLikelyToContinueSubstanceUseOrRelapse,
               freeTimeAffectOnRecovery,
               concernsAboutPursuingTreatment,
               helpfulnessOfTreatment,
               possibleFutureRelapseCause,
               strategyToPreventRelapse,
               dealsWithProblemsInFreeTimeThatRiskRelapse,
               isAbleToLocateAndGetToCommunityResourcesSafely,
               patientNeedForPsychiatricPsychologicalTreatmentRating,
               howImportantPsychologicalEmotionalCounseling,
               howEmotionalProblemsImpactRecoveryEfforts,
               activePsychiatricDiagnosesOtherThanSubstanceAbuse,
               withdrawalSymptomsAndEmotionalBehavioralProblems);
        }

        public CareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore CalculateCareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore(Assessment assessment)
        {
            var emotionalAbuseInPast30Days = assessment.FamilyAndSocialHistorySection.EmotionalAbuseInPast30Days;
            var physicalAbuseInPast30Days = assessment.FamilyAndSocialHistorySection.PhysicalAbuseInPast30Days;
            var sexualAbuseInPast30Days = assessment.FamilyAndSocialHistorySection.SexualAbuseInPast30Days;
            var riskPatientHarmedByOther = assessment.FamilyAndSocialHistorySection.RiskPatientHarmedByOther;
            var livingArrangementAffectOnRecovery = assessment.FamilyAndSocialHistorySection.LivingArrangementAffectOnRecovery;
            var appearanceOfTroubleConcentratingOrRemembering = assessment.PsychologicalSection.InterviewerRating.AppearanceOfTroubleConcentratingOrRemembering;
            var evidenceOfChronicOrganicMentalDisability = assessment.PsychologicalSection.InterviewerRating.EvidenceOfChronicOrganicMentalDisability;
            var currentBehaviorInconsistentWithSelfCare = assessment.PsychologicalSection.InterviewerRating.CurrentBehaviorInconsistentWithSelfCare;
            var friendsAffectOnRecovery = assessment.FamilyAndSocialHistorySection.FriendsAffectOnRecovery;
            var dealsWithProblemsFromFriendsThatRiskRelapse = assessment.FamilyAndSocialHistorySection.DealsWithProblemsFromFriendsThatRiskRelapse;
            var closestContactsNeedsAndWillingnessToHelpTreatment = assessment.FamilyAndSocialHistorySection.ClosestContactsNeedsAndWillingnessToHelpTreatment;
            var isAbleToLocateAndGetToCommunityResourcesSafely = assessment.FamilyAndSocialHistorySection.IsAbleToLocateAndGetToCommunityResourcesSafely;
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = assessment.PsychologicalSection.InterviewerRating.ActivePsychiatricDiagnosesOtherThanSubstanceAbuse;
            var currentProblemBehaviorsRequireContinuousInterventions = assessment.PsychologicalSection.InterviewerRating.CurrentProblemBehaviorsRequireContinuousInterventions;
            var symptomsStabalizedDuringTreatmentDay = assessment.CompletionSection.SymptomsStabalizedDuringTreatmentDay;
            var timingOfPositiveResponseToDetoxificationCare = assessment.CompletionSection.TimingOfPositiveResponseToDetoxificationCare;
            var freeTimeAffectOnRecovery = assessment.FamilyAndSocialHistorySection.FreeTimeAffectOnRecovery;
            var dealsWithProblemsInFreeTimeThatRiskRelapse = assessment.FamilyAndSocialHistorySection.DealsWithProblemsInFreeTimeThatRiskRelapse;
            var patientNeedForPsychiatricPsychologicalTreatmentRating = assessment.PsychologicalSection.InterviewerRating.PatientNeedForPsychiatricPsychologicalTreatmentRating;
            var howImportantPsychologicalEmotionalCounseling = assessment.PsychologicalSection.PsychologicalHistory.HowImportantPsychologicalEmotionalCounseling;
            var howEmotionalProblemsImpactRecoveryEfforts = assessment.PsychologicalSection.PsychologicalHistory.HowEmotionalProblemsImpactRecoveryEfforts;
            var detoxificationRequiredMoreThanHourlyMonitoring = assessment.CompletionSection.DetoxificationRequiredMoreThanHourlyMonitoring;
            var withdrawalSymptomsAndEmotionalBehavioralProblems = assessment.AssessmentScores.Dimension3EmotionalBehavioralScores.CommonScores.WithdrawalSymptomsAndEmotionalBehavioralProblems;
            var dimension2SeverityNumber = assessment.AssessmentScores.Dimension2BiomedicalScores.SeverityNumber;
            var dimension3SeverityNumber = assessment.AssessmentScores.Dimension3EmotionalBehavioralScores.SeverityNumber;
            var livingInModeratelyHighRiskEnvironmentImpactToRecovery = assessment.AssessmentScores.Dimension6LivingEnvironmentScores.CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore.LivingInModeratelyHighRiskEnvironmentImpactToRecovery;
             
            return CalculateCareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore(
               emotionalAbuseInPast30Days,
               physicalAbuseInPast30Days,
               sexualAbuseInPast30Days,
               riskPatientHarmedByOther,
               livingArrangementAffectOnRecovery,
               appearanceOfTroubleConcentratingOrRemembering,
               evidenceOfChronicOrganicMentalDisability,
               currentBehaviorInconsistentWithSelfCare,
               friendsAffectOnRecovery,
               dealsWithProblemsFromFriendsThatRiskRelapse,
               closestContactsNeedsAndWillingnessToHelpTreatment,
               isAbleToLocateAndGetToCommunityResourcesSafely,
               activePsychiatricDiagnosesOtherThanSubstanceAbuse,
               currentProblemBehaviorsRequireContinuousInterventions,
               symptomsStabalizedDuringTreatmentDay,
               timingOfPositiveResponseToDetoxificationCare,
               freeTimeAffectOnRecovery,
               dealsWithProblemsInFreeTimeThatRiskRelapse,
               patientNeedForPsychiatricPsychologicalTreatmentRating,
               howImportantPsychologicalEmotionalCounseling,
               howEmotionalProblemsImpactRecoveryEfforts,
               detoxificationRequiredMoreThanHourlyMonitoring,
               withdrawalSymptomsAndEmotionalBehavioralProblems,
               livingInModeratelyHighRiskEnvironmentImpactToRecovery,
               dimension2SeverityNumber,
               dimension3SeverityNumber);
        }

        public CareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore CalculateCareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore(Assessment assessment)
        {
            var emotionalAbuseInPast30Days = assessment.FamilyAndSocialHistorySection.EmotionalAbuseInPast30Days;
            var physicalAbuseInPast30Days = assessment.FamilyAndSocialHistorySection.PhysicalAbuseInPast30Days;
            var sexualAbuseInPast30Days = assessment.FamilyAndSocialHistorySection.SexualAbuseInPast30Days;
            var riskPatientHarmedByOther = assessment.FamilyAndSocialHistorySection.RiskPatientHarmedByOther;
            var livingArrangementAffectOnRecovery = assessment.FamilyAndSocialHistorySection.LivingArrangementAffectOnRecovery;
            var friendsAffectOnRecovery = assessment.FamilyAndSocialHistorySection.FriendsAffectOnRecovery;
            var dealsWithProblemsFromFriendsThatRiskRelapse = assessment.FamilyAndSocialHistorySection.DealsWithProblemsFromFriendsThatRiskRelapse;
            var closestContactsNeedsAndWillingnessToHelpTreatment = assessment.FamilyAndSocialHistorySection.ClosestContactsNeedsAndWillingnessToHelpTreatment;
            var spendsFreeTimeWith = assessment.FamilyAndSocialHistorySection.SpendsFreeTimeWith;
            var numberOfCloseFriends = assessment.FamilyAndSocialHistorySection.NumberOfCloseFriends;
            var closestPersonalContactInPast4Months = assessment.FamilyAndSocialHistorySection.ClosestPersonalContactInPast4Months;
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = assessment.PsychologicalSection.InterviewerRating.ActivePsychiatricDiagnosesOtherThanSubstanceAbuse;
            var currentProblemBehaviorsRequireContinuousInterventions = assessment.PsychologicalSection.InterviewerRating.CurrentProblemBehaviorsRequireContinuousInterventions;
            var symptomsStabalizedDuringTreatmentDay = assessment.CompletionSection.SymptomsStabalizedDuringTreatmentDay;
            var timingOfPositiveResponseToDetoxificationCare = assessment.CompletionSection.TimingOfPositiveResponseToDetoxificationCare;
            var dealsWithProblemsInFreeTimeThatRiskRelapse = assessment.FamilyAndSocialHistorySection.DealsWithProblemsInFreeTimeThatRiskRelapse;
            var numberOfTimesArrestedForShopliftingVandalism = assessment.LegalSection.NumberOfTimesArrestedForShopliftingVandalism;
            var numberOfTimesArrestedForParoleProbationViolation = assessment.LegalSection.NumberOfTimesArrestedForParoleProbationViolation;
            var numberOfTimesArrestedForDrugCharges = assessment.LegalSection.NumberOfTimesArrestedForDrugCharges;
            var numberOfTimesArrestedForForgery = assessment.LegalSection.NumberOfTimesArrestedForForgery;
            var numberOfTimesArrestedForWeaponsOffense = assessment.LegalSection.NumberOfTimesArrestedForWeaponsOffense;
            var numberOfTimesArrestedForBurglaryLarceny = assessment.LegalSection.NumberOfTimesArrestedForBurglaryLarceny;
            var numberOfTimesArrestedForRobbery = assessment.LegalSection.NumberOfTimesArrestedForRobbery;
            var numberOfTimesArrestedForAssault = assessment.LegalSection.NumberOfTimesArrestedForAssault;
            var numberOfTimesArrestedForArson = assessment.LegalSection.NumberOfTimesArrestedForArson;
            var numberOfTimesArrestedForRape = assessment.LegalSection.NumberOfTimesArrestedForRape;
            var numberOfTimesArrestedForHomicide = assessment.LegalSection.NumberOfTimesArrestedForHomicide;
            var numberOfTimesArrestedForProstitution = assessment.LegalSection.NumberOfTimesArrestedForProstitution;
            var numberOfTimesArrestedForContemptOfCourt = assessment.LegalSection.NumberOfTimesArrestedForContemptOfCourt;
            var numberOfTimesArrestedForOtherArrest = assessment.LegalSection.NumberOfTimesArrestedForOtherArrest;
            var isCurrentlyAwaitingChargesTrialSentence = assessment.LegalSection.IsCurrentlyAwaitingChargesTrialSentence;
            var numberOfDaysCommitingCrimesForProfitInPast30Days = assessment.LegalSection.NumberOfDaysCommitingCrimesForProfitInPast30Days;
            var detoxificationRequiredMoreThanHourlyMonitoring = assessment.CompletionSection.DetoxificationRequiredMoreThanHourlyMonitoring;
            var dimension2SeverityNumber = assessment.AssessmentScores.Dimension2BiomedicalScores.SeverityNumber;
            var dimension3SeverityNumber = assessment.AssessmentScores.Dimension3EmotionalBehavioralScores.SeverityNumber;
            var anxietyAttackMoreThanOnceInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.AnxietyAttackMoreThanOnceInLast24Hours;
            var significantPeriodFidgetingInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodFidgetingInLast24Hours;
            var significantPeriodNegativeThoughtsInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodNegativeThoughtsInLast24Hours;
            var significantPeriodExcessiveBehaviorInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodExcessiveBehaviorInLast24Hours;
            var significantPeriodParanoiaInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodParanoiaInLast24Hours;
            var significantPeriodFlashbacksInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodFlashbacksInLast24Hours;
            var significantPeriodCurbingViolentBehaviorInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodCurbingViolentBehaviorInLast24Hours;
            var significantPeriodViolentUrgesInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodViolentUrgesInLast24Hours;
            var significantPeriodSuicidalThoughtsInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodSuicidalThoughtsInLast24Hours;
            var significantPeriodThoughtsOfSelfInjuryInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodThoughtsOfSelfInjuryInLast24Hours;
            var significantPeriodAttemptedSuicideInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodAttemptedSuicideInLast24Hours;
            var hasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced = assessment.AssessmentScores.Dimension6LivingEnvironmentScores.CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore.HasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced;
                                       
            return CalculateCareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore(
               emotionalAbuseInPast30Days,
               physicalAbuseInPast30Days,
               sexualAbuseInPast30Days,
               riskPatientHarmedByOther,
               livingArrangementAffectOnRecovery,
               friendsAffectOnRecovery,
               dealsWithProblemsFromFriendsThatRiskRelapse,
               closestContactsNeedsAndWillingnessToHelpTreatment,
               spendsFreeTimeWith,
               numberOfCloseFriends,
               closestPersonalContactInPast4Months,
               activePsychiatricDiagnosesOtherThanSubstanceAbuse,
               currentProblemBehaviorsRequireContinuousInterventions,
               symptomsStabalizedDuringTreatmentDay,
               timingOfPositiveResponseToDetoxificationCare,
               dealsWithProblemsInFreeTimeThatRiskRelapse,
               numberOfTimesArrestedForShopliftingVandalism,
               numberOfTimesArrestedForParoleProbationViolation,
               numberOfTimesArrestedForDrugCharges,
               numberOfTimesArrestedForForgery,
               numberOfTimesArrestedForWeaponsOffense,
               numberOfTimesArrestedForBurglaryLarceny,
               numberOfTimesArrestedForRobbery,
               numberOfTimesArrestedForAssault,
               numberOfTimesArrestedForArson,
               numberOfTimesArrestedForRape,
               numberOfTimesArrestedForHomicide,
               numberOfTimesArrestedForProstitution,
               numberOfTimesArrestedForContemptOfCourt,
               numberOfTimesArrestedForOtherArrest,
               isCurrentlyAwaitingChargesTrialSentence,
               numberOfDaysCommitingCrimesForProfitInPast30Days,
               detoxificationRequiredMoreThanHourlyMonitoring,
               dimension2SeverityNumber,
               dimension3SeverityNumber,
               anxietyAttackMoreThanOnceInLast24Hours,
               significantPeriodFidgetingInLast24Hours,
               significantPeriodNegativeThoughtsInLast24Hours,
               significantPeriodExcessiveBehaviorInLast24Hours,
               significantPeriodParanoiaInLast24Hours,
               significantPeriodFlashbacksInLast24Hours,
               significantPeriodCurbingViolentBehaviorInLast24Hours,
               significantPeriodViolentUrgesInLast24Hours,
               significantPeriodSuicidalThoughtsInLast24Hours,
               significantPeriodThoughtsOfSelfInjuryInLast24Hours,
               significantPeriodAttemptedSuicideInLast24Hours,
               hasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced);
        }

        public CareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScore CalculateCareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScore(Assessment assessment)
        {
            var emotionalAbuseInPast30Days = assessment.FamilyAndSocialHistorySection.EmotionalAbuseInPast30Days;
            var physicalAbuseInPast30Days = assessment.FamilyAndSocialHistorySection.PhysicalAbuseInPast30Days;
            var sexualAbuseInPast30Days = assessment.FamilyAndSocialHistorySection.SexualAbuseInPast30Days;
            var riskPatientHarmedByOther = assessment.FamilyAndSocialHistorySection.RiskPatientHarmedByOther;
            var livingArrangementAffectOnRecovery = assessment.FamilyAndSocialHistorySection.LivingArrangementAffectOnRecovery;
            var detoxificationRequiredMoreThanHourlyMonitoring = assessment.CompletionSection.DetoxificationRequiredMoreThanHourlyMonitoring;
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = assessment.PsychologicalSection.InterviewerRating.ActivePsychiatricDiagnosesOtherThanSubstanceAbuse;
            var currentProblemBehaviorsRequireContinuousInterventions = assessment.PsychologicalSection.InterviewerRating.CurrentProblemBehaviorsRequireContinuousInterventions;
            var timingOfPositiveResponseToDetoxificationCare = assessment.CompletionSection.TimingOfPositiveResponseToDetoxificationCare;
            var anxietyAttackMoreThanOnceInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.AnxietyAttackMoreThanOnceInLast24Hours;
            var significantPeriodFidgetingInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodFidgetingInLast24Hours;
            var significantPeriodNegativeThoughtsInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodNegativeThoughtsInLast24Hours;
            var significantPeriodExcessiveBehaviorInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodExcessiveBehaviorInLast24Hours;
            var significantPeriodParanoiaInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodParanoiaInLast24Hours;
            var significantPeriodFlashbacksInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodFlashbacksInLast24Hours;
            var significantPeriodCurbingViolentBehaviorInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodCurbingViolentBehaviorInLast24Hours;
            var significantPeriodViolentUrgesInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodViolentUrgesInLast24Hours;
            var significantPeriodSuicidalThoughtsInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodSuicidalThoughtsInLast24Hours;
            var significantPeriodThoughtsOfSelfInjuryInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodThoughtsOfSelfInjuryInLast24Hours;
            var significantPeriodAttemptedSuicideInLast24Hours = assessment.PsychologicalSection.PsychologicalHistory.SignificantPeriodAttemptedSuicideInLast24Hours;
            var dimension2SeverityNumber = assessment.AssessmentScores.Dimension2BiomedicalScores.SeverityNumber;
            var dimension3SeverityNumber = assessment.AssessmentScores.Dimension3EmotionalBehavioralScores.SeverityNumber;
            var socialNetworkOrLivingWithAlcoholDrugUserImpactsRecovery = assessment.AssessmentScores.Dimension6LivingEnvironmentScores.CareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore.SocialNetworkOrLivingWithAlcoholDrugUserImpactsRecovery;
            var hasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced = assessment.AssessmentScores.Dimension6LivingEnvironmentScores.CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore.HasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced;
            
            return CalculateCareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScore(
               emotionalAbuseInPast30Days,
               physicalAbuseInPast30Days,
               sexualAbuseInPast30Days,
               riskPatientHarmedByOther,
               livingArrangementAffectOnRecovery,
               detoxificationRequiredMoreThanHourlyMonitoring,
               activePsychiatricDiagnosesOtherThanSubstanceAbuse,
               currentProblemBehaviorsRequireContinuousInterventions,
               timingOfPositiveResponseToDetoxificationCare,
               anxietyAttackMoreThanOnceInLast24Hours,
               significantPeriodFidgetingInLast24Hours,
               significantPeriodNegativeThoughtsInLast24Hours,
               significantPeriodExcessiveBehaviorInLast24Hours,
               significantPeriodParanoiaInLast24Hours,
               significantPeriodFlashbacksInLast24Hours,
               significantPeriodCurbingViolentBehaviorInLast24Hours,
               significantPeriodViolentUrgesInLast24Hours,
               significantPeriodSuicidalThoughtsInLast24Hours,
               significantPeriodThoughtsOfSelfInjuryInLast24Hours,
               significantPeriodAttemptedSuicideInLast24Hours,
               dimension2SeverityNumber,
               dimension3SeverityNumber,
               socialNetworkOrLivingWithAlcoholDrugUserImpactsRecovery,
               hasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced);
        }

        public CareLevel_IV_MedicallyManagedIntensiveInpatientTreatmentScore CalculateCareLevel_IV_MedicallyManagedIntensiveInpatientTreatmentScore(Assessment assessment)
        {
            var careLevel_IV_Score = new CareLevel_IV_MedicallyManagedIntensiveInpatientTreatmentScore();
            careLevel_IV_Score.IsMet = false;
            return careLevel_IV_Score;
        }

        #endregion


        #region Internal Methods

        internal CareLevel_0_5_EarlyInterventionScore CalculateCareLevel_0_5_EarlyInterventionScore(
            FreeTimeAffectOnRecovery freeTimeAffectOnRecovery, //ASIf8a
            LivingArrangementAffectOnRecovery livingArrangementAffectOnRecovery, //ASIf6a
            FriendsAffectOnRecovery friendsAffectOnRecovery, //ASIf9a
            NeedsAndWillingnessToHelpTreatment closestContactsNeedsAndWillingnessToHelpTreatment, //ASIf19h
            StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse dealsWithProblemsInFreeTimeThatRiskRelapse,
            bool anyAddictionDiagnosisExceptNicotine) //ASIf8b
        {
            var careLevel_0_5_Score = new CareLevel_0_5_EarlyInterventionScore();

            // David Gastfriends Original PseudoCode:
            // D6L0.5-a OB_D6L05_a := (ASIf8a > 2);
            // 
            // Current Delphi Code
            // OB_D6L05_a := (ASIf8a > 2);
            careLevel_0_5_Score.HasSupportSystemThatPreventsThemFromMeetingObligations =
                freeTimeAffectOnRecovery > FreeTimeAffectOnRecovery.WillPermitRecoveryIfSufficientlyMotivated;

            // David GastFriends Original PseudoCode:
            //  D6L0.5-b OB_D6L05_b := (ASIf6a > 2);
            // 
            // Current Delphi Code
            // OB_D6L05_b := (ASIf6a > 2);
            careLevel_0_5_Score.HasFamilyMembersCurrentlyAbusingAlcoholOrDrugs =
                livingArrangementAffectOnRecovery >
                LivingArrangementAffectOnRecovery.WillPermitRecoveryIfSufficientlyMotivated;

            // David GastFriends Original PseudoCode:
            // D6L0.5-c OB_D6L05_c := (ASIf9a > 2);
            // 
            // Current Delphi Code
            // OB_D6L05_c := (ASIf9a > 2);
            careLevel_0_5_Score.HasSignificantOtherWithDrugOrAlcoholValuesConflict =
                friendsAffectOnRecovery > FriendsAffectOnRecovery.WillPermitRecovery;

            // David GastFriends Original PseudoCode:
            // D6L0.5-d  OB_D6L05_d := (ASIf19h = 4);
            // 
            // Current Delphi Code
            // OB_D6L05_d := (ASIf19h = 4);
            careLevel_0_5_Score.HasSignificantOtherWhoCondonesOrEncouragesAlcoholOrDrugUse =
                closestContactsNeedsAndWillingnessToHelpTreatment ==
                NeedsAndWillingnessToHelpTreatment.SeriousConflictsAndNotAmenableToFamilyTreatment;

            // David Gastfriends Original PseudoCode:
            // D6L0.5  OB_D6L05 := ((ASIf6a > 2) or (ASIf8a > 2) or (ASIf8b > 2) or (ASIf9a > 2) 
            // or (ASIf19h = 4)) and (not AnyDxExceptNico);
            // 
            // Current Delphi Code
            // -a,b,c OR d = TRUE If (Any of ASIf: 6a,8a,8b,9a >2) or 19h =4
            // OB_D6L05 := ((ASIf6a > 2) or (ASIf8a > 2) or (ASIf8b > 2) or (ASIf9a > 2) or (ASIf19h = 4)) and 
            // (not AnyDxExceptNico);
            careLevel_0_5_Score.IsMet =
                (livingArrangementAffectOnRecovery >
                LivingArrangementAffectOnRecovery.WillPermitRecoveryIfSufficientlyMotivated ||
                freeTimeAffectOnRecovery > FreeTimeAffectOnRecovery.WillPermitRecoveryIfSufficientlyMotivated ||
                dealsWithProblemsInFreeTimeThatRiskRelapse >
                StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse.MinimalIdeasForIncreasingAndorMaintainingSafety ||
                friendsAffectOnRecovery > FriendsAffectOnRecovery.WillPermitRecovery ||
                closestContactsNeedsAndWillingnessToHelpTreatment ==
                NeedsAndWillingnessToHelpTreatment.SeriousConflictsAndNotAmenableToFamilyTreatment)
                &&
                !(anyAddictionDiagnosisExceptNicotine);
                         
            return careLevel_0_5_Score;
        }

        internal CareLevel_I_OutpatientScore CalculateCareLevel_I_OutpatientScore(
            SubstanceUseOrRelapseLikelihood feelLikelyToContinueSubstanceUseOrRelapse, //ASId22k
            LivingArrangementAffectOnRecovery livingArrangementAffectOnRecovery, //ASIf6a
            FreeTimeAffectOnRecovery freeTimeAffectOnRecovery, //ASIf8a
            StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse dealsWithProblemsInFreeTimeThatRiskRelapse, //ASIf8b
            FriendsAffectOnRecovery friendsAffectOnRecovery, //ASIf9a
            StrategiesToDealWithProblemsFromFriendsThatRiskRelapse dealsWithProblemsFromFriendsThatRiskRelapse, //ASIf9b
            NeedsAndWillingnessToHelpTreatment closestContactsNeedsAndWillingnessToHelpTreatment, //ASIf19h
            DesireAndExternalFactorsDrivingTreatment desireAndExternalFactorsDrivingTreatment, //ASIl1x
            bool? isAbleToLocateAndGetToCommunityResourcesSafely, //ASIf19l
            YesNoNotSure mobilityProblemsMayAffectTreatmentAttendance, //ASIm6j
            ConcernsAboutPursuingTreatment concernsAboutPursuingTreatment, //ASId24w
            RelapsePreventionStrategies strategyToPreventRelapse, //ASId24z
            ProblemsForWorkHomeAndSocialInteractionScale howDifficultProblemsForWorkHomeAndSocialInteraction, //ASIp12b
            EmotionalProblemsImpactRecoveryEffortsScale howEmotionalProblemsImpactRecoveryEfforts, //ASIp13a
            ScaleOf0To8 patientNeedForPsychiatricPsychologicalTreatmentRating, //ASIp20
            PsychologicalEmotionalCounselingImportanceScale howImportantPsychologicalEmotionalCounseling, //ASIp13
            YesNoNotSure intensiveCaseManagementAccessibleToPatient, //ASIp20e
            IEnumerable<PsychiatricDiagnosis> activePsychiatricDiagnosesOtherThanSubstanceAbuse, //ASIp19j 
            bool? withdrawalSymptomsAndEmotionalBehavioralProblems, //OB_Dim3Px
            bool? hasImminentSevereConsequences) //OB_ImSevCon
        {
            var careLevel_I_Score = new CareLevel_I_OutpatientScore();

            // David Gastfriends Original PseudoCode:
            // D6LI-a = TRUE If mean ASI: [d22k,f6a,f8a,f8b,f9a,f9b,f19h,l1x] <=2 & Post9≠2 & ASIf19l=1 & ASIm6j=0	
            // 
            // Current Delphi Code
			// OB_D6LIa  = TRUE If mean ASI: [d22k,f6a,f8a,f8b,f9a,f9b,f19h,l1x] <=2
            // & ASIf19l=1 & ASIm6j=0
            // x := (ASId22k + ASIf6a + ASIf8a + ASIf8b + ASIf9a + ASIf9b + ASIf19h + ASIl1x)/8.0;
            // OB_D6LIa := (x <= 2.0) and (ASIf19l = 1) and (ASIm6j = 0);
            //TODO: Post9 != 2 is only in the PseudoCode
            var avg = Utilities.Average( feelLikelyToContinueSubstanceUseOrRelapse,
                                         livingArrangementAffectOnRecovery,
                                         freeTimeAffectOnRecovery,
                                         dealsWithProblemsInFreeTimeThatRiskRelapse,
                                         friendsAffectOnRecovery,
                                         dealsWithProblemsFromFriendsThatRiskRelapse,
                                         closestContactsNeedsAndWillingnessToHelpTreatment,
                                         desireAndExternalFactorsDrivingTreatment );

            careLevel_I_Score.PsychosocialEnvironmentSupportiveOutpatientTreatmentFeasible =
                avg <= 2  
                && 
                (isAbleToLocateAndGetToCommunityResourcesSafely ?? false) 
                &&
                mobilityProblemsMayAffectTreatmentAttendance == YesNoNotSure.No;

            // David Gastfriends Original PseudoCode:
            // D6LI-b = TRUE If [(mean ASI: f6a,8a,9a,19h >2) & (mean ASI: d24w,d24z,f9b <=2)]	
            // 
			// Current Delphi Code
			// OB_D6LIb = TRUE If [(mean ASI: f6a,8a,9a,19h >2) & (mean ASI: d24w,d24z,f9b <=2)]
            // x := (ASIf6a + ASIf8a + ASIf9a + ASIf19h)/4.0; 
            // y := (ASId24w + ASId24z + ASIf9b)/3.0; 
            // OB_D6LIb := (x > 2) and (y <= 2);
            var x = Utilities.Average( livingArrangementAffectOnRecovery,
                                       freeTimeAffectOnRecovery,
                                       friendsAffectOnRecovery,
                                       closestContactsNeedsAndWillingnessToHelpTreatment );

            var y = Utilities.Average( concernsAboutPursuingTreatment,
                                       strategyToPreventRelapse,
                                       dealsWithProblemsFromFriendsThatRiskRelapse );

            careLevel_I_Score. SocialSupportNotAdequatePatientMotivatedToObtainSupportive = 
                x > 2  &&  y <= 2 ;

            // David Gastfriends Original PseudoCode:
            // D6LI-c = TRUE If mean ASIf: [6a,19h] <=2	
            // 
            // Current Delphi Code
			// OB_D6LIc = TRUE If mean ASIf: [6a,19h] <=2
            // OB_D6LIc := (((ASIf6a + ASIf19h)/2) <= 2); 
            var avgSupport = Utilities.Average( livingArrangementAffectOnRecovery, 
                                                closestContactsNeedsAndWillingnessToHelpTreatment );

            careLevel_I_Score.SupportiveButRequireProfessionalInterventionsForRecovery =
                avgSupport <= 2 ;

            // David Gastfriends Original PseudoCode:
            // D6LIdde-a = TRUE If [mean ASI: f6a,8a,9a,19h >2] & [ASIp12b=2 or P13a=2to3]	
            // 
            // Current Delphi Code
			// OB_D6LIdde_a = TRUE If [mean ASI: f6a,8a,9a,19h >2] & [ASIp12b=2 or P13a=2to3]
            // x := (ASIf6a + ASIf8a + ASIf9a + ASIf19h)/4.0; 
            // OB_D6LIdde_a := (x > 2) and ((ASIp12b = 2) or IsBtw(ASIp13a, 2, 3));
            var avgSocialSupport = Utilities.Average( livingArrangementAffectOnRecovery,
                                                      freeTimeAffectOnRecovery,
                                                      friendsAffectOnRecovery,
                                                      closestContactsNeedsAndWillingnessToHelpTreatment );

            careLevel_I_Score.SocialSupportNotAdequateAndMildImpairmentInAbilityToObtainOne =
                avgSocialSupport > 2
                &&
                (howDifficultProblemsForWorkHomeAndSocialInteraction ==
                ProblemsForWorkHomeAndSocialInteractionScale.Moderately 
                ||
                IsBtw(howEmotionalProblemsImpactRecoveryEfforts, 
                EmotionalProblemsImpactRecoveryEffortsScale.SomewhatDistractingFromRecovery,
                EmotionalProblemsImpactRecoveryEffortsScale.WillHinderTreatmentRecoveryParticipation));

            // David Gastfriends Original PseudoCode:
			// D6LIdde-b = TRUE If [ASIf19h=2]	
            // 
            // Current Delphi Code
			// OB_D6LIdde_b = TRUE If [ASIf19h=2]
            // OB_D6LIdde_b := (ASIf19h = 2);
            careLevel_I_Score.SocialSupportRequiresActiveFamilyTherapyForSuccessAndRecovery =
                closestContactsNeedsAndWillingnessToHelpTreatment == 
                NeedsAndWillingnessToHelpTreatment.NeedsCouplesOrFamilyCounselingOrTherapyAndWillParticipate;
       
			// David Gastfriends Original PseudoCode:
			// D6LIdde-c = TRUE If [Dim3Px=1 or ASIp19j>0] & [ASIp20=3to5 or ASIp13=2to3] & 
            // [(mean of ASIf: 6a,8a,8b,9a,9b & f19h>2) or p13a>1] & ImSevCon=0 & ASIp20e=2	
            // 
            // Current Delphi Code
		    // OB_D6LIdde_c = TRUE If [Dim3Px=1 or ASIp19j>0] & [ASIp20=3to5 or ASIp13=2to3]
            // & [(mean of ASIf: 6a,8a,8b,9a,9b & f19h>2) or p13a>1] & ImSevCon=0 & ASIp20e=2
            // x := (ASIf6a + ASIf8a + ASIf8b + ASIf9a + ASIf9b + ASIf19h)/6.0; 
            // OB_D6LIdde_c := (OB_Dim3Px and (ASIp19jMax > 0)) and 
            // (IsBtw(ASIp20, 3, 5) or IsBtw(ASIp13, 2, 3)) and
            // ((x > 2) or (ASIp13a > 1)) and
            // OB_ImSevCon and (ASIp20e = 2);
            // TODO: In PseudoCode  [Dim3Px=1 or ASIp19j>0] however in the delphi code (OB_Dim3Px and (ASIp19jMax > 0))
            // TODO: ImSevcon = 0 in PseudoCode but ImSevcon = true in delphi code
            var avgChronicallyImpaired = Utilities.Average( livingArrangementAffectOnRecovery, 
                                                            freeTimeAffectOnRecovery,
                                                            dealsWithProblemsInFreeTimeThatRiskRelapse,
                                                            friendsAffectOnRecovery,
                                                            dealsWithProblemsFromFriendsThatRiskRelapse,
                                                            closestContactsNeedsAndWillingnessToHelpTreatment );

            careLevel_I_Score.IsChronicallyImpairedNoAdequateSupportButAccessToRecoveryEnvironment =
                ((withdrawalSymptomsAndEmotionalBehavioralProblems ?? false) &&
                activePsychiatricDiagnosesOtherThanSubstanceAbuse.Max(p => p.Value) > PsychiatricDiagnosis.None) 
                &&
                (IsBtw(patientNeedForPsychiatricPsychologicalTreatmentRating, 3, 5) ||
                IsBtw(howImportantPsychologicalEmotionalCounseling, 
                PsychologicalEmotionalCounselingImportanceScale.ModeratelyImportant,
                PsychologicalEmotionalCounselingImportanceScale.ConsiderablyImportant))  
                &&      
                (avgChronicallyImpaired > 2 || howEmotionalProblemsImpactRecoveryEfforts > EmotionalProblemsImpactRecoveryEffortsScale.ProblemsWontInterfere) 
                &&
                (hasImminentSevereConsequences ?? false) && intensiveCaseManagementAccessibleToPatient == YesNoNotSure.Yes;

            // David Gastfriends Original PseudoCode:
            // D6LI = TRUE If D6LI -a, -b, OR -c
            // 
            // Current Delphi Code
            // D6LI = TRUE If D6LI -a, -b, OR -c
            // OB_D6LI := OB_D6LIa or OB_D6LIb or OB_D6LIc;
            careLevel_I_Score.IsMet =
                careLevel_I_Score.PsychosocialEnvironmentSupportiveOutpatientTreatmentFeasible.Value ||
                careLevel_I_Score.SocialSupportNotAdequatePatientMotivatedToObtainSupportive.Value ||
                careLevel_I_Score.SupportiveButRequireProfessionalInterventionsForRecovery.Value ;

            // David Gastfriends Original PseudoCode:
			// D6LIdde = TRUE If D6LI & D6LIdde (-a or -b or -c)	
            // 
            // Current Delphi Code
			// D6LIdde = TRUE If D6LI & D6LIdde (-a or -b or -c)
            // OB_D6LIdde := OB_D6LI and (OB_D6LIdde_a or OB_D6LIdde_b or OB_D6LIdde_c);
            careLevel_I_Score.IsDualDiagnosisEnhanced = careLevel_I_Score.IsMet.Value &&
                (careLevel_I_Score.SocialSupportNotAdequateAndMildImpairmentInAbilityToObtainOne.Value ||
                careLevel_I_Score.SocialSupportRequiresActiveFamilyTherapyForSuccessAndRecovery.Value ||
                careLevel_I_Score.IsChronicallyImpairedNoAdequateSupportButAccessToRecoveryEnvironment.Value);

            return careLevel_I_Score;
        }

        internal CareLevelOpioidMaintenanceTherapyScore CalculateCareLevelOpioidMaintenanceTherapyScore(
            SubstanceUseOrRelapseLikelihood feelLikelyToContinueSubstanceUseOrRelapse, //ASId22k
            LivingArrangementAffectOnRecovery livingArrangementAffectOnRecovery, //ASIf6a
            FreeTimeAffectOnRecovery freeTimeAffectOnRecovery, //ASIf8a
            StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse dealsWithProblemsInFreeTimeThatRiskRelapse, //ASIf8b
            FriendsAffectOnRecovery friendsAffectOnRecovery, //ASIf9a
            StrategiesToDealWithProblemsFromFriendsThatRiskRelapse dealsWithProblemsFromFriendsThatRiskRelapse, //ASIf9b              
            YesNoNotSure mobilityProblemsMayAffectTreatmentAttendance, //ASIm6j
            NeedsAndWillingnessToHelpTreatment closestContactsNeedsAndWillingnessToHelpTreatment, //ASIf19h          
            ConcernsAboutPursuingTreatment concernsAboutPursuingTreatment, //ASId24w
            RelapsePreventionStrategies strategyToPreventRelapse, //ASId24z        
            LikertScale emotionalAbuseInPast30Days, //ASIf19a
            LikertScale physicalAbuseInPast30Days, //ASIf19b
            LikertScale sexualAbuseInPast30Days, //ASIf19c
            LikertScale familyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II, //ASIf19f
            LikertScale riskPatientHarmedByOther, //ASIf19j
            bool? wasVisitPromptedByCriminalJusticeSystem, //ASIl1
            bool? isOnProbationOrParole,   // ASIl2
            uint? numberOfTimesArrestedForShopliftingVandalism,   // ASIl3
            uint? numberOfTimesArrestedForParoleProbationViolation,   // ASIl4
            uint? numberOfTimesArrestedForDrugCharges,   // ASIl5
            uint? numberOfTimesArrestedForForgery,   // ASIl6
            uint? numberOfTimesArrestedForWeaponsOffense,   // ASIl7
            uint? numberOfTimesArrestedForBurglaryLarceny,   // ASIl8
            uint? numberOfTimesArrestedForRobbery,   // ASIl9
            uint? numberOfTimesArrestedForAssault,   // ASIl10
            uint? numberOfTimesArrestedForArson,   // ASIl11
            uint? numberOfTimesArrestedForRape,   // ASIl12
            uint? numberOfTimesArrestedForHomicide,   // ASIl13
            uint? numberOfTimesArrestedForProstitution,   // ASIl14a
            uint? numberOfTimesArrestedForContemptOfCourt,   // ASIl14b
            uint? numberOfTimesArrestedForOtherArrest,   // ASIl14c
            uint? numberOfTimesConvicted,   // ASIl15
            ScaleOf0To8 hasSuicidalThoughts,   // ASIp19
            ScaleOf0To8 demonstratingDangerToSelfOrOthers,   // ASIp19a
            ScaleOf0To8 limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers,   // ASIp19b
            ScaleOf0To8 indicatingRiskOfHarmToOthers,   // ASIp19c
            ScaleOf0To8 indicatingRiskOfHarmToSelfOrVictimizationByOthers,
            bool anyOpioidAddictionDiagnosis)   // ASIp19d
        {
            var careLevel_OMT_Score = new CareLevelOpioidMaintenanceTherapyScore ( );

            // David Gastfriends Original PseudoCode:
			// D6LM-a = TRUE If mean of ASI: [d22k,f6a,f8a,f8b,f9a,f9b,f19h]<=2 & Post9≠2 & ASIm6j=0	
            // 
            // Current Delphi Code
			// OB_D6LMa = TRUE If mean of ASI: [d22k,f6a,f8a,f8b,f9a,f9b,f19h]<=2 & Post9<>2 & ASIm6j=0
			// x := (ASId22k + ASIf6a + ASIf8a + ASIf8b + ASIf9a + ASIf9b + ASIf19h)/7.0;
            // OB_D6LMa := (x <= 2) and (ASIm6j = 0);
            // TODO: Where is the Post9 parameter in Delphi Code?
            var avg = Utilities.Average( feelLikelyToContinueSubstanceUseOrRelapse,
                                         livingArrangementAffectOnRecovery,
                                         freeTimeAffectOnRecovery,
                                         dealsWithProblemsInFreeTimeThatRiskRelapse,
                                         friendsAffectOnRecovery,
                                         dealsWithProblemsFromFriendsThatRiskRelapse,
                                         closestContactsNeedsAndWillingnessToHelpTreatment );

            careLevel_OMT_Score.HasSupportivePsychosocialEnvironmentToRenderOpioidManintenanceFeasible =
                avg <= 2 && mobilityProblemsMayAffectTreatmentAttendance == YesNoNotSure.No;
         
            // David Gastfriends Original PseudoCode:
           	// D6LM-b = TRUE If ASIf: 6a<3 & 19h<3	
            // 
			// Current Delphi Code
			// OB_D6LMb = TRUE If ASIf: 6a<3 & 19h<3
            // OB_D6LMb := (ASIf6a < 3) and (ASIf19h < 3);
            careLevel_OMT_Score.SupportiveButRequireProfessionalInterventionsForTreatmentSuccess =
                livingArrangementAffectOnRecovery < LivingArrangementAffectOnRecovery.WillDiscourageOrHinderTreatment &&
                closestContactsNeedsAndWillingnessToHelpTreatment < NeedsAndWillingnessToHelpTreatment.NotClearIfWillHelpOrNoOneAvailable;
        
            // David Gastfriends Original PseudoCode:
            // D6LM-c = TRUE If [(mean ASI: f6a,8a,9a,19h >2) & (mean ASI: d24w,d24z <2) & ASIf9b<3]	
            // x := (ASIf6a + ASIf8a + ASIf9a + ASIf19h)/4.0;
            // Current Delphi Code		
			// OB_D6LMc = TRUE If [(mean ASI: f6a,8a,9a,19h >2) & (mean ASI: d24w,d24z <2) & ASIf9b<3]
            // OB_D6LMc := (x > 2) and (((ASId24w + ASId24z)/2.0) < 2) and (ASIf9b < 3); 
            var x = Utilities.Average( livingArrangementAffectOnRecovery,
                                       freeTimeAffectOnRecovery,
                                       friendsAffectOnRecovery,
                                       closestContactsNeedsAndWillingnessToHelpTreatment );

            var avgPositiveSupport = Utilities.Average( concernsAboutPursuingTreatment,
                                                        strategyToPreventRelapse );

            careLevel_OMT_Score.NoPositiveSocialSupportPatientMotivatedToObtainSupportSystem =
                x > 2 
                && 
                avgPositiveSupport < 2 
                &&
                dealsWithProblemsFromFriendsThatRiskRelapse < 
                StrategiesToDealWithProblemsFromFriendsThatRiskRelapse.PassiveAboutDevelopingProtectiveRelationships;

            // David Gastfriends Original PseudoCode:
            // D6LM-d = TRUE If [Any of ASIf19 a,b or c =1to2 & ASIf 19f=0 & 19j=0] or 
			// [(Sum of ASIl: 2,3,4,5,6,7,8,9,10,11,12,13,14a,b,c,15 >1) & (All of ASIp 19,19a,19b,19c,19d <3)] 	
            // 
            // Current Delphi Code
			// OB_D6LMd = TRUE If [Any of ASIf19 a,b or c =1to2 & ASIf 19f=0 & 19j=0]
            // or [(Sum of ASIl: 2,3,4,5,6,7,8,9,10,11,12,13,14a,b,c,15 >1)
            // & (All of ASIp 19,19a,19b,19c,19d <3)]
            // OB_D6LMd := (IsBtw(ASIf19a, 1, 2) or IsBtw(ASIf19b, 1, 2) or IsBtw(ASIf19c, 1, 2) and
			// (ASIf19f = 0) and (ASIf19j = 0)) or
			// (((ASIl1  + ASIl2  + ASIl3  + ASIl4  + ASIl5 + ASIl6 + ASIl7 + ASIl8 + 
			// ASIl9  + ASIl10 + ASIl11 + ASIl12 + ASIl13 + ASIl14a + ASIl14b + ASIl14c + ASIl15) > 1) and
			// ((ASIp19 < 3) and (ASIp19a < 3) and (ASIp19b < 3) and (ASIp19c < 3) and (ASIp19d < 3)));
            var numberOfArrests = new[]
                                      {
                                          ((wasVisitPromptedByCriminalJusticeSystem ?? false) ? 1U : 0U),
                                          ((isOnProbationOrParole ?? false) ? 1U : 0U),
                                          numberOfTimesArrestedForShopliftingVandalism,
                                          numberOfTimesArrestedForParoleProbationViolation,
                                          numberOfTimesArrestedForDrugCharges,
                                          numberOfTimesArrestedForForgery,
                                          numberOfTimesArrestedForWeaponsOffense,
                                          numberOfTimesArrestedForBurglaryLarceny,
                                          numberOfTimesArrestedForRobbery,
                                          numberOfTimesArrestedForAssault,
                                          numberOfTimesArrestedForArson,
                                          numberOfTimesArrestedForRape,
                                          numberOfTimesArrestedForHomicide,
                                          numberOfTimesArrestedForProstitution,
                                          numberOfTimesArrestedForContemptOfCourt,
                                          numberOfTimesArrestedForOtherArrest,
                                          numberOfTimesConvicted,
                                      };
            var hasBeenConvictedOfACrime = numberOfArrests.Sum(v => v) > 1;

            careLevel_OMT_Score.HasExperiencedTraumaInRecoveryEnvironmentManageableAsOutpatient =
                ((IsBtw(emotionalAbuseInPast30Days, LikertScale.Slightly, LikertScale.Moderately) ||
                IsBtw(physicalAbuseInPast30Days, LikertScale.Slightly, LikertScale.Moderately) ||
                IsBtw(sexualAbuseInPast30Days, LikertScale.Slightly, LikertScale.Moderately))
                && (familyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II == LikertScale.NotAtAll &&
                riskPatientHarmedByOther == LikertScale.NotAtAll))
                ||
                (hasBeenConvictedOfACrime &&
                riskPatientHarmedByOther == LikertScale.NotAtAll &&
                hasSuicidalThoughts < 3 &&
                demonstratingDangerToSelfOrOthers < 3 &&
                limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers < 3 &&
                indicatingRiskOfHarmToOthers < 3 &&
                indicatingRiskOfHarmToSelfOrVictimizationByOthers < 3);
             
            // David Gastfriends Original PseudoCode:
            // D6LM = TRUE If D6LM -a, -b, -c OR -d	
            // 
            // Current Delphi Code
            // D6LM = TRUE If D6LM -a, -b, -c OR -d
            // OB_D6LM := (OB_D6LMa or OB_D6LMb or OB_D6LMc or OB_D6LMd) and AnyOpioidDx;
            // TODO: AnyOpioidDx only exists in Delphi code.
            careLevel_OMT_Score.IsMet = (careLevel_OMT_Score.HasSupportivePsychosocialEnvironmentToRenderOpioidManintenanceFeasible.Value ||
                                        careLevel_OMT_Score.SupportiveButRequireProfessionalInterventionsForTreatmentSuccess.Value ||
                                        careLevel_OMT_Score.NoPositiveSocialSupportPatientMotivatedToObtainSupportSystem.Value ||
                                        careLevel_OMT_Score.HasExperiencedTraumaInRecoveryEnvironmentManageableAsOutpatient.Value) && 
                                        anyOpioidAddictionDiagnosis ;

            return careLevel_OMT_Score;
        }

        internal CareLevel_II_1_IntensiveOutpatientScore CalculateCareLevel_II_1_IntensiveOutpatientScore(
            WorkOrSchoolAffectOnRecovery workOrSchoolAffectOnRecovery, // ASIe7a
            SubstanceUseOrRelapseLikelihood feelLikelyToContinueSubstanceUseOrRelapse, // ASId22k
            LivingArrangementAffectOnRecovery livingArrangementAffectOnRecovery, // ASIf6a
            FreeTimeAffectOnRecovery freeTimeAffectOnRecovery, // ASIf8a
            ConcernsAboutPursuingTreatment concernsAboutPursuingTreatment, // ASId24w
            HelpfulnessOfTreatment helpfulnessOfTreatment, // ASId24x
            RelapseCause possibleFutureRelapseCause, // ASId24y
            RelapsePreventionStrategies strategyToPreventRelapse, // ASId24z
            StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse dealsWithProblemsInFreeTimeThatRiskRelapse, // ASIf8b             
            Companionship spendsFreeTimeWith, // ASIf7
            uint? numberOfCloseFriends, // ASIf9
            FriendsAffectOnRecovery friendsAffectOnRecovery, // ASIf9a
            StrategiesToDealWithProblemsFromFriendsThatRiskRelapse dealsWithProblemsFromFriendsThatRiskRelapse,// ASIf9b
            NeedsAndWillingnessToHelpTreatment closestContactsNeedsAndWillingnessToHelpTreatment, // ASIf19h
            ScaleOf0To8 appearanceOfDepressionWithdrawal, // ASIp14
            ScaleOf0To8 appearanceofAgitation, // ASIp15a
            ScaleOf0To8 appearanceOfAnxietyNervousness, // ASIp16
            ScaleOf0To8 patientNeedForPsychiatricPsychologicalTreatmentRating, // ASIp20
            ScaleOf0To8 levelOfSupervisionNeededForProtectionFromSelfHarm) // ASIp19g        
        {
            var careLevel_II_1_Score = new CareLevel_II_1_IntensiveOutpatientScore();

            // David Gastfriends Original PseudoCode:
            // D6LII.1-a = TRUE If [mean of ASI: e7a,d22k,f6a,f8a >2 & <=3] & [mean of ASI: d24w,d24x,d24y,d24z,f8b >1&<=2]	
            // 
            // Current Delphi Code
            // OB_D6LII1a = TRUE If [mean of ASI: e7a,d22k,f6a,f8a >2 & <=3]
            //   & [mean of ASI: d24w,d24x,d24y,d24z,f8b >1&<=2]
            // x := (ASIe7a + ASId22k + ASIf6a + ASIf8a)/4.0; 
            // y := (ASId24w + ASId24x + ASId24y +ASId24z + ASIf8b)/5.0;
            // OB_D6LII1a := IsBtw(x, 2.001, 3) and IsBtw(y, 1.001, 2);
            var x = Utilities.Average( workOrSchoolAffectOnRecovery,
                                       feelLikelyToContinueSubstanceUseOrRelapse,
                                       livingArrangementAffectOnRecovery,
                                       freeTimeAffectOnRecovery );

            var y = Utilities.Average( concernsAboutPursuingTreatment,
                                       helpfulnessOfTreatment,
                                       possibleFutureRelapseCause,
                                       strategyToPreventRelapse,
                                       dealsWithProblemsInFreeTimeThatRiskRelapse );

            careLevel_II_1_Score.CurrentSchoolWorkLivingWillRenderRecoveryUnlikely =
                (x > 2 && x <= 3) && (y > 1 && y <= 2);

            // David Gastfriends Original PseudoCode:
            // D6LII.1-b = TRUE If [f7=3 or f9=0 or f9a>2] & [f9b=2to3 or f19h=2to3]	
            // 
            // Current Delphi Code
            // OB_D6LII1b = TRUE If [f7=3 or f9=0 or f9a>2] & [f9b=2to3 or f19h=2to3]
            // OB_D6LII1b := ((ASIf7 = 3) or (ASIf9 = 0) or (ASIf9a > 2)) and
            // (IsBtw(ASIf9b, 2, 3) or IsBtw(ASIf19h, 2, 3));
            careLevel_II_1_Score.InsufficientOrInappropriateSocialContactsJeopardizeRecovery =
                (spendsFreeTimeWith == Companionship.Alone ||
                numberOfCloseFriends == 0 ||
                friendsAffectOnRecovery > FriendsAffectOnRecovery.WillPermitRecovery)
                &&
                (IsBtw(dealsWithProblemsFromFriendsThatRiskRelapse, StrategiesToDealWithProblemsFromFriendsThatRiskRelapse.SomePlansToUseRecoverySupports ,
                StrategiesToDealWithProblemsFromFriendsThatRiskRelapse.PassiveAboutDevelopingProtectiveRelationships) ||
                IsBtw(closestContactsNeedsAndWillingnessToHelpTreatment, NeedsAndWillingnessToHelpTreatment.NeedsCouplesOrFamilyCounselingOrTherapyAndWillParticipate,
                NeedsAndWillingnessToHelpTreatment.NotClearIfWillHelpOrNoOneAvailable));

            // David Gastfriends Original PseudoCode:
            // D6LII.1dde = TRUE If [Any of ASIp 14,15a,16 or 20 =2to4] & ASIp19g=5to6	
            //  
            // Current Delphi Code
            // D6LII.1dde = TRUE If [Any of ASIp 14,15a,16 or 20 =2to4] & ASIp19g=5to6
            // OB_D6LII1dde := (IsBtw(ASIp14, 2, 4) or IsBtw(ASIp15a, 2, 4) or 
            // IsBtw(ASIp16, 2, 4) or IsBtw(ASIp20, 2, 4)) and 
            // IsBtw(ASIp19g, 5, 6);
            careLevel_II_1_Score.HasInsufficientResourcesSupportiveOfGoodMentalFunctioning =
                (IsBtw(appearanceOfDepressionWithdrawal, 2, 4 )||
                IsBtw(appearanceofAgitation, 2, 4) ||
                IsBtw(appearanceOfAnxietyNervousness, 2, 4)|| 
                IsBtw(patientNeedForPsychiatricPsychologicalTreatmentRating, 2, 4)) 
                &&
                IsBtw(levelOfSupervisionNeededForProtectionFromSelfHarm, 5, 6);

            // David Gastfriends Original PseudoCode:
			// D6LII.1 = TRUE If -a OR -b	
            //
            // Current Delphi Code
			// D6LII.1 = TRUE If -a or b
            // OB_D6LII1 := OB_D6LII1a or OB_D6LII1b;	
            careLevel_II_1_Score.IsMet =
                careLevel_II_1_Score.CurrentSchoolWorkLivingWillRenderRecoveryUnlikely.Value ||
                careLevel_II_1_Score.InsufficientOrInappropriateSocialContactsJeopardizeRecovery.Value;

            // David Gastfriends Original PseudoCode:
		    // D6LII.1dde = TRUE If D6LII.1 & D6LII.1dde	
            //
            // Current Delphi Code
			// D6LII.1dde = TRUE If D6LII.1 & D6LII.1dde
            // OB_D6LII1dde := OB_D6LII1 and OB_D6LII1dde;			
            careLevel_II_1_Score.IsDualDiagnosisEnhanced =
                careLevel_II_1_Score.IsMet.Value &&
                careLevel_II_1_Score.HasInsufficientResourcesSupportiveOfGoodMentalFunctioning.Value;

            return careLevel_II_1_Score;
        }

        internal CareLevel_II_5_PartialHospitalizationScore CalculateCareLevel_II_5_PartialHospitalizationScore(
                WorkOrSchoolAffectOnRecovery workOrSchoolAffectOnRecovery, // ASIe7a
                SubstanceUseOrRelapseLikelihood feelLikelyToContinueSubstanceUseOrRelapse, // ASId22k
                LivingArrangementAffectOnRecovery livingArrangementAffectOnRecovery, // ASIf6a
                FreeTimeAffectOnRecovery freeTimeAffectOnRecovery, // ASIf8a
                ConcernsAboutPursuingTreatment concernsAboutPursuingTreatment, // ASId24w
                HelpfulnessOfTreatment helpfulnessOfTreatment, // ASId24x
                RelapseCause possibleFutureRelapseCause, // ASId24y
                RelapsePreventionStrategies strategyToPreventRelapse, // ASId24z
                StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse dealsWithProblemsInFreeTimeThatRiskRelapse, // ASIf8b
                NeedsAndWillingnessToHelpTreatment closestContactsNeedsAndWillingnessToHelpTreatment, // ASIf19h
                ScaleOf0To8 appearanceOfDepressionWithdrawal, // ASIp14
                ScaleOf0To8 appearanceofAgitation, // ASIp15a
                ScaleOf0To8 appearanceOfAnxietyNervousness, // ASIp16
                ScaleOf0To8 patientNeedForPsychiatricPsychologicalTreatmentRating, // ASIp20
                ScaleOf0To8 levelOfSupervisionNeededForProtectionFromSelfHarm)  // ASIp19g
        {
            var careLevel_II_5_Score = new CareLevel_II_5_PartialHospitalizationScore();

            // David Gastfriends Original PseudoCode:
			// D6LII.5-a = TRUE If [mean of ASI: e7a,d22k,f6a,f8a >2 & <=3] & [mean of ASI: d24w,d24x,d24y,d24z,f8b >2&<=3]	
            //
            // Current Delphi Code
			// x := (ASIe7a + ASId22k + ASIf6a + ASIf8a)/4.0;
            // y := (ASId24w + ASId24x + ASId24y +ASId24z + ASIf8b)/5.0;
			// OB_D6LII5a = TRUE If [mean of ASI: e7a,d22k,f6a,f8a >2 & <=3]
            // & [mean of ASI: d24w,d24x,d24y,d24z,f8b >2&<=3]
            // OB_D6LII5a := IsBtw(x, 2.001, 3) and IsBtw(y, 2.001, 3);
            var x = Utilities.Average( workOrSchoolAffectOnRecovery, 
                                       feelLikelyToContinueSubstanceUseOrRelapse,
                                       livingArrangementAffectOnRecovery,
                                       freeTimeAffectOnRecovery );

            var y = Utilities.Average( concernsAboutPursuingTreatment,
                                       helpfulnessOfTreatment,
                                       possibleFutureRelapseCause,
                                       strategyToPreventRelapse,
                                       dealsWithProblemsInFreeTimeThatRiskRelapse );

            careLevel_II_5_Score.ContinuedExposureToCurrentSchoolWorkLivingWillRenderRecoveryUnlikely =
                (x > 2 && x <= 3) && (y > 2 && y <= 3);

            // David Gastfriends Original PseudoCode:
            // D6LII.5-b = TRUE If mean ASIf: 6a,8a,19h >2, <=3	
            //
            // Current Delphi Code		
            // OB_D6LII5b = TRUE If mean ASIf: 6a,8a,19h >2, <=3
            // OB_D6LII5b := IsBtw(((ASIf6a + ASIf8a + ASIf19h)/3.0), 2.001, 3);
            var avg = Utilities.Average( livingArrangementAffectOnRecovery, 
                                         freeTimeAffectOnRecovery,
                                         closestContactsNeedsAndWillingnessToHelpTreatment );

            careLevel_II_5_Score.AreNotSupportiveOfRecoveryGoalsPassivelyOpposedToTreatment =
                avg > 2 && avg <= 3;

            // David Gastfriends Original PseudoCode:
            // D6LII.5dde = TRUE If [Any of ASIp 14,15a,16 or 20 =5to7] & ASIp19g=5to6	
            //
            // Current Delphi Code
            // D6LII.5dde = TRUE If [Any of ASIp 14,15a,16 or 20 =5to7] & ASIp19g=5to6
            // OB_D6LII5dde := (IsBtw(ASIp14, 5, 7) or IsBtw(ASIp15a, 5, 7) or
            // IsBtw(ASIp16, 5, 7) or IsBtw(ASIp20, 5, 7)) and 
            // IsBtw(ASIp19g, 5, 6);
            careLevel_II_5_Score.HasInsufficientResourcesSupportiveOfGoodMentalFunctioning =
                (IsBtw(appearanceOfDepressionWithdrawal, 5, 7) ||
                IsBtw(appearanceofAgitation, 5, 7) ||
                IsBtw(appearanceOfAnxietyNervousness, 5, 7) ||
                IsBtw(patientNeedForPsychiatricPsychologicalTreatmentRating, 5, 7)) 
                &&
                IsBtw(levelOfSupervisionNeededForProtectionFromSelfHarm, 5, 6);

            // David Gastfriends Original PseudoCode:
            // D6LII.5 = TRUE If D6LII.5-a OR -b	
            //
            // Current Delphi Code
            // D6LII.5 = TRUE If D6LII.5-a OR -b
            // OB_D6LII5 := OB_D6LII5a or OB_D6LII5b;
            careLevel_II_5_Score.IsMet =
                careLevel_II_5_Score.ContinuedExposureToCurrentSchoolWorkLivingWillRenderRecoveryUnlikely.Value ||
                careLevel_II_5_Score.AreNotSupportiveOfRecoveryGoalsPassivelyOpposedToTreatment.Value;

            // David Gastfriends Original PseudoCode:
            // D6LII.5dde = TRUE If D6LII.5 & D6LII.5dde	
            //
            // Current Delphi Code
            // D6LII.5dde = TRUE If D6LII.5 & D6LII.5dde
            // OB_D6LII5dde := OB_D6LII5 and OB_D6LII5dde;
            careLevel_II_5_Score.IsDualDiagnosisEnhanced =
                careLevel_II_5_Score.IsMet.Value &&
                careLevel_II_5_Score.HasInsufficientResourcesSupportiveOfGoodMentalFunctioning.Value;

            return careLevel_II_5_Score;
        }

        internal CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore CalculateCareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore (      
                LikertScale emotionalAbuseInPast30Days,   // ASIf19a
                LikertScale physicalAbuseInPast30Days,   // ASIf19b
                LikertScale sexualAbuseInPast30Days,   // ASIf19c
                LikertScale riskPatientHarmedByOther,   // ASIf19j
                LivingArrangementAffectOnRecovery livingArrangementAffectOnRecovery,   // ASIf6a
                FriendsAffectOnRecovery friendsAffectOnRecovery,   // ASIf9a
                StrategiesToDealWithProblemsFromFriendsThatRiskRelapse dealsWithProblemsFromFriendsThatRiskRelapse,   // ASIf9b
                NeedsAndWillingnessToHelpTreatment closestContactsNeedsAndWillingnessToHelpTreatment,   // ASIf19h
                Companionship spendsFreeTimeWith,   // ASIf7
                uint? numberOfCloseFriends,   // ASIf9
                ContactPerson closestPersonalContactInPast4Months,   // ASIf19g
                WorkOrSchoolAffectOnRecovery workOrSchoolAffectOnRecovery,   // ASIe7a
                SubstanceUseOrRelapseLikelihood feelLikelyToContinueSubstanceUseOrRelapse,   // ASId22k
                FreeTimeAffectOnRecovery freeTimeAffectOnRecovery,   // ASIf8a
                ConcernsAboutPursuingTreatment concernsAboutPursuingTreatment,   // ASId24w
                HelpfulnessOfTreatment helpfulnessOfTreatment,   // ASId24x
                RelapseCause possibleFutureRelapseCause,   // ASId24y
                RelapsePreventionStrategies strategyToPreventRelapse,   // ASId24z
                StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse dealsWithProblemsInFreeTimeThatRiskRelapse,   // ASIf8b
                bool? isAbleToLocateAndGetToCommunityResourcesSafely,   // ASIf19l
                ScaleOf0To8 patientNeedForPsychiatricPsychologicalTreatmentRating,   // ASIp20
                PsychologicalEmotionalCounselingImportanceScale howImportantPsychologicalEmotionalCounseling,   // ASIp13
                EmotionalProblemsImpactRecoveryEffortsScale howEmotionalProblemsImpactRecoveryEfforts,   // ASIp13a  
                IEnumerable<PsychiatricDiagnosis> activePsychiatricDiagnosesOtherThanSubstanceAbuse, //ASIp19j 
                bool? withdrawalSymptomsAndEmotionalBehavioralProblems) //OB_Dim3Px
        {
            var careLevel_III_1_Score = new CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore();

            // David Gastfriends Original PseudoCode:
            // D6LIII.1-a, 3-a, & 5-a = TRUE If [(any of ASIf: 19a,b,c >1) & ASIf19j>1] or [ASIf6a=4]	
            // 
            // Current Delphi Code
            // OB_D6LIII1a, 3-a, & 5-a = TRUE If [(any of ASIf: 19a,b,c >1) & ASIf19j>1] or [ASIf6a=4]
            // OB_D6LIII1a := (((ASIf19a > 1) or (ASIf19b > 1) or (ASIf19c > 1)) and (ASIf19j > 1)) or 
            // (ASIf6a = 4);
            careLevel_III_1_Score.LivingInModeratelyHighRiskEnvironmentImpactToRecovery =
                ((emotionalAbuseInPast30Days > LikertScale.Slightly ||
                physicalAbuseInPast30Days > LikertScale.Slightly ||
                sexualAbuseInPast30Days > LikertScale.Slightly) &&
                riskPatientHarmedByOther > LikertScale.Slightly) 
                ||
                livingArrangementAffectOnRecovery == LivingArrangementAffectOnRecovery.WillOftenExposeToSubstanceUse;

            // David Gastfriends Original PseudoCode:
            // D6LIII.1-bc = TRUE If [any of ASIf: f7,f9,f19g=0 & f9b=4] or [mean of ASIf 6a,9a,9b,19h =>3]	
            //
            // Current Delphi Code
            // OB_D6LIII1bc = TRUE If [any of ASIf: f7,f9,f19g=0 & f9b=4] or [mean of ASIf 6a,9a,9b,19h =>3]
            // Corrected DRG f7=0, alone is f7=3
            // z := (ASIf6a + ASIf9a + ASIf9b + ASIf19h)/4.0;  
            // OB_D6LIII1bc := ((ASIf7 = 3) or (ASIf9 = 0) or (ASIf19g = 0) and (ASIf9b = 4)) or 
            // (z >= 3);
            // TODO: Pseudo code logic '[any of ASIf: f7,f9,f19g=0 & f9b=4]" is ambiguous. Does it mean '[(any of ASIf: f7,f9,f19g=0) & f9b=4]'?
            var z = Utilities.Average( livingArrangementAffectOnRecovery, 
                                       friendsAffectOnRecovery,
                                       dealsWithProblemsFromFriendsThatRiskRelapse,
                                       closestContactsNeedsAndWillingnessToHelpTreatment );

            careLevel_III_1_Score.InsufficientOrInappropriateSocialContactsOrSocialIsolationImpactsRecovery =
                ((spendsFreeTimeWith == Companionship.Alone || 
                numberOfCloseFriends == 0 ||
                closestPersonalContactInPast4Months == ContactPerson.Mother)
                &&
                dealsWithProblemsFromFriendsThatRiskRelapse ==
                StrategiesToDealWithProblemsFromFriendsThatRiskRelapse.ReclusiveOrDrawnToHighRiskSocialContacts)
                ||
                (z >= 3);

            // David Gastfriends Original PseudoCode:
            // D6LIII.1-d = TRUE If [mean of ASI: e7a,d22k,f6a,f8a >2 & <=3] & [mean of ASI: d24w,d24x,d24y,d24z,f8b >3]	
            //
            // Current Delphi Code
            // x := (ASIe7a + ASId22k + ASIf6a + ASIf8a)/4.0; 
            // y := (ASId24w + ASId24x + ASId24y +ASId24z + ASIf8b)/5.0; 
            // OB_D6LIII1d = TRUE If [mean of ASI: e7a,d22k,f6a,f8a >2 & <=3]
            // & [mean of ASI: d24w,d24x,d24y,d24z,f8b >3]
            // OB_D6LIII1d := IsBtw(x, 2.001, 3) and (y > 3);
            var x = Utilities.Average( workOrSchoolAffectOnRecovery,
                                       feelLikelyToContinueSubstanceUseOrRelapse,
                                       livingArrangementAffectOnRecovery,
                                       freeTimeAffectOnRecovery );

            var y = Utilities.Average( concernsAboutPursuingTreatment,
                                       helpfulnessOfTreatment,
                                       possibleFutureRelapseCause,
                                       strategyToPreventRelapse,
                                       dealsWithProblemsInFreeTimeThatRiskRelapse );

            careLevel_III_1_Score.ContinuedExposureToCurrentSchoolWorkLivingNeeds24HourSupport =
                (x > 2 && x <= 3) && (y > 3);

            // David Gastfriends Original PseudoCode:
            // D6LIII.1-e = TRUE If ASIf19j>2	
            //
            // Current Delphi Code
            // OB_D6LIII1e = TRUE If ASIf19j>2
            // OB_D6LIII1e := (ASIf19j > 2);
             
            careLevel_III_1_Score.DangerOfVictimizationByAnotherRequires24HourSupervision =
                riskPatientHarmedByOther > LikertScale.Moderately;

            // David Gastfriends Original PseudoCode:
            // D6LIII.1-f = TRUE If ASIf19l=1 & ASIe7a<3	
            //
            // Current Delphi Code
            // ser? my spsht has D6LIII.1-f = TRUE If ASIf19l=1 & ASIe7a<3
            // OB_D6LIII1f = TRUE If ASIf19l=0 & ASIe7a<3
            // OB_D6LIII1f := (ASIf19l = 0) and (ASIe7a < 3);
            // TODO: Pseudo code has ASIF191 = 1 and delphi code has ASIF191 = 0
            careLevel_III_1_Score.AbleToCopeLimitedPeriodsTimeOutside24HourStructure =
                !(isAbleToLocateAndGetToCommunityResourcesSafely ?? true) &&
                workOrSchoolAffectOnRecovery < WorkOrSchoolAffectOnRecovery.WillDiscourageOrHinderRecovery;

            // David Gastfriends Original PseudoCode:
			// D6LIII.1, III.3, & III.5 -dde = TRUE If [Dim3Px=1 or ASIp19j>0] & [ASIp20=3to7 or ASIp13=2to4]
			// & [(mean of ASIf: 6a,8a,8b,9a,9b & f19h>2) or p13a>1]
            // x := (ASIf6a + ASIf8a + ASIf8b + ASIf9a + ASIf9b + ASIf19h)/6.0;
            //
            // Current Delphi Code
			// OB_D6LIII1dde := (OB_Dim3Px and (ASIp19jMax > 0)) and 
            // (IsBtw(ASIp20, 3, 8) or IsBtw(ASIp13, 2, 4)) and
            // ((x > 2) or (ASIp13a > 1));
            // TODO: ASIp20 = 3 to 7 in Pseudo code and ASIp20 IsBtw 3 to 8 in Delphi code
            var avg = Utilities.Average( livingArrangementAffectOnRecovery,
                                         freeTimeAffectOnRecovery,
                                         dealsWithProblemsInFreeTimeThatRiskRelapse,
                                         friendsAffectOnRecovery,
                                         dealsWithProblemsFromFriendsThatRiskRelapse,
                                         closestContactsNeedsAndWillingnessToHelpTreatment );

            var activeDxMax = activePsychiatricDiagnosesOtherThanSubstanceAbuse.Max().Value; 

            careLevel_III_1_Score.HasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced =
                ((withdrawalSymptomsAndEmotionalBehavioralProblems ?? false) &&
                activeDxMax > PsychiatricDiagnosis.None) 
                &&
                (IsBtw(patientNeedForPsychiatricPsychologicalTreatmentRating, 3, 8) ||
                IsBtw(howImportantPsychologicalEmotionalCounseling,
                PsychologicalEmotionalCounselingImportanceScale.ModeratelyImportant, 
                PsychologicalEmotionalCounselingImportanceScale.ExtremelyImportant)) 
                &&
                (avg > 2 || howEmotionalProblemsImpactRecoveryEfforts >
                EmotionalProblemsImpactRecoveryEffortsScale.ProblemsWontInterfere);

            // David Gastfriends Original PseudoCode:
            // D6LIII.1 = TRUE If (Any of: D6LIII.1 -a, -b, -c, -d, OR -e) & -f	
            //
            // Current Delphi Code
            // OB_D6LIII1 := (OB_D6LIII1a or OB_D6LIII1bc or OB_D6LIII1d or OB_D6LIII1e) and OB_D6LIII1f;
            careLevel_III_1_Score.IsMet =
                (careLevel_III_1_Score.LivingInModeratelyHighRiskEnvironmentImpactToRecovery.Value ||
                careLevel_III_1_Score.InsufficientOrInappropriateSocialContactsOrSocialIsolationImpactsRecovery.Value ||
                careLevel_III_1_Score.ContinuedExposureToCurrentSchoolWorkLivingNeeds24HourSupport.Value ||
                careLevel_III_1_Score.DangerOfVictimizationByAnotherRequires24HourSupervision.Value) &&
                careLevel_III_1_Score.AbleToCopeLimitedPeriodsTimeOutside24HourStructure.Value;

            // David Gastfriends Original PseudoCode:
            // D6LIII.1dde = TRUE If D6LIII.1 & D6LIII.1dde	
            //
            // Current Delphi Code
            // OB_D6LIII1dde := OB_D6LIII1 and OB_D6LIII1dde;
            careLevel_III_1_Score.IsDualDiagnosisEnhanced =
                careLevel_III_1_Score.IsMet.Value &&
                careLevel_III_1_Score.HasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced.Value;
	
            return careLevel_III_1_Score;
        }

        internal CareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore CalculateCareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore(
            LikertScale emotionalAbuseInPast30Days,   // ASIf19a
            LikertScale physicalAbuseInPast30Days,   // ASIf19b
            LikertScale sexualAbuseInPast30Days,   // ASIf19c
            LikertScale riskPatientHarmedByOther,   // ASIf19j
            LivingArrangementAffectOnRecovery livingArrangementAffectOnRecovery,   // ASIf6a
            ScaleOf0To8 appearanceOfTroubleConcentratingOrRemembering,   // ASIp18
            YesNoNotSure evidenceOfChronicOrganicMentalDisability,   // ASIp19k
            YesNoNotSure currentBehaviorInconsistentWithSelfCare,   // ASIp20a
            FriendsAffectOnRecovery friendsAffectOnRecovery,   // ASIf9a
            StrategiesToDealWithProblemsFromFriendsThatRiskRelapse dealsWithProblemsFromFriendsThatRiskRelapse,   // ASIf9b
            NeedsAndWillingnessToHelpTreatment closestContactsNeedsAndWillingnessToHelpTreatment,   // ASIf19h
            bool? isAbleToLocateAndGetToCommunityResourcesSafely,   // ASIf19l
            IEnumerable<PsychiatricDiagnosis> activePsychiatricDiagnosesOtherThanSubstanceAbuse,   // ASIp19j
            YesNoNotSure currentProblemBehaviorsRequireContinuousInterventions,   // ASIp20b
            bool? symptomsStabalizedDuringTreatmentDay,   // Post2
            DetoxificationCareResponseTiming timingOfPositiveResponseToDetoxificationCare,   // Post3
            FreeTimeAffectOnRecovery freeTimeAffectOnRecovery,   // ASIf8a
            StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse dealsWithProblemsInFreeTimeThatRiskRelapse,   // ASIf8b
            ScaleOf0To8 patientNeedForPsychiatricPsychologicalTreatmentRating,   // ASIp20
            PsychologicalEmotionalCounselingImportanceScale howImportantPsychologicalEmotionalCounseling,   // ASIp13
            EmotionalProblemsImpactRecoveryEffortsScale howEmotionalProblemsImpactRecoveryEfforts,   // ASIp13a
            bool? detoxificationRequiredMoreThanHourlyMonitoring,  // Post4
            bool? withdrawalSymptomsAndEmotionalBehavioralProblems, //OB_Dim3Px
            bool? livingInModeratelyHighRiskEnvironmentImpactToRecovery, //OB_D6LIII1a
            int dimension2SeverityNumber,   // OI_D2Severity
            int dimension3SeverityNumber)  // OI_D3Severity
        {
            var careLevel_III_3_Score = new CareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore();
            // David Gastfriends Original PseudoCode:
            // D6LIII.1-a, 3-a, & 5-a = TRUE If [(any of ASIf: 19a,b,c >1) & ASIf19j>1] or [ASIf6a=4]	
            //
            // Current Delphi Code
            // OB_D6LIII3a, 3-a, & 5-a = TRUE If [(any of ASIf: 19a,b,c >1) & ASIf19j>1] or [ASIf6a=4]
            // OB_D6LIII3a := (((ASIf19a > 1) or (ASIf19b > 1) or (ASIf19c > 1)) and (ASIf19j > 1)) or 
            //  (ASIf6a = 4);
            careLevel_III_3_Score.LivingEnvironmentModerateHighRiskUnableToMaintainRecovery =
                ((emotionalAbuseInPast30Days > LikertScale.Slightly ||
                physicalAbuseInPast30Days > LikertScale.Slightly ||
                sexualAbuseInPast30Days > LikertScale.Slightly) &&
                riskPatientHarmedByOther > LikertScale.Slightly)
                ||
                livingArrangementAffectOnRecovery == LivingArrangementAffectOnRecovery.WillOftenExposeToSubstanceUse;

            // David Gastfriends Original PseudoCode:
            // D6LIII.3-b & -e = TRUE If [(any of ASIf: 19a,b,c >1) & ASIf19j>1] or [ASIf6a=4] & [ASIp 18>4 or 19k=2 or or 20a=2] 	
            //
            // Current Delphi Code
            // OB_D6LIII3be = TRUE If [(any of ASIf: 19a,b,c >1) & ASIf19j>1] or [ASIf6a=4]
            // & [ASIp 18>4 or 19k=2 or or 20a=2]
            //  OB_D6LIII3be := OB_D6LIII1a and ((ASIp18 > 4) or (ASIp19k = 2) or (ASIp20a = 2));
            careLevel_III_3_Score.CognitiveImpairmentRequires24HourSupervisionToPreventVictimization =
                livingInModeratelyHighRiskEnvironmentImpactToRecovery.Value 
                &&
                (appearanceOfTroubleConcentratingOrRemembering > 4 ||
                evidenceOfChronicOrganicMentalDisability == YesNoNotSure.Yes ||
                currentBehaviorInconsistentWithSelfCare == YesNoNotSure.Yes);

            // David Gastfriends Original PseudoCode:
            // D6LIII.3-c & -d = TRUE If mean of ASIf 6a,9a,9b,19h =>3	
            //
            // Current Delphi Code
            // z := (ASIf6a + ASIf9a + ASIf9b + ASIf19h)/4.0; 
            // D6LIII.3-c & -d = TRUE If mean of ASIf 6a,9a,9b,19h =>3
            // OB_D6LIII3cd := (z >= 3);
            var z = Utilities.Average( livingArrangementAffectOnRecovery,
                                       friendsAffectOnRecovery,
                                       dealsWithProblemsFromFriendsThatRiskRelapse,
                                       closestContactsNeedsAndWillingnessToHelpTreatment );

            careLevel_III_3_Score.SocialNetworkOrLivingWithAlcoholDrugUserImpactsRecovery =
                z >= 3;

            // David Gastfriends Original PseudoCode:
            // D6LIII.3-f = TRUE If ASIf19l=0 or p19j>6 or p20b=2 or Post2=0 or Post3=4	
            //
            // Current Delphi Code
            // OB_D6LIII3f = TRUE If ASIf19l=0 or p19j>6 or p20b=2 or Post2=0 or Post3=4
            // The list of diagnoses for this should be:
            // Mania or Bipolar Disorder 9
            // Schizophrenia, Psychotic or Thought Disorder 10
            // OB_D6LIII3f := (ASIf19l = 0) or ArrayContains(ASIp19j, 9) or ArrayContains(ASIp19j, 10) or 
            // (ASIp20b = 2) or (Post2 <> 1) or (Post3 = 4);
            careLevel_III_3_Score.IsUnableToCopeOutside24HourStructureProgram =
                !(isAbleToLocateAndGetToCommunityResourcesSafely ?? true) ||
                activePsychiatricDiagnosesOtherThanSubstanceAbuse.Contains(PsychiatricDiagnosis.ManiaOrBipolarDisorder) ||
                activePsychiatricDiagnosesOtherThanSubstanceAbuse.Contains(PsychiatricDiagnosis.SchizophreniaPsychoticOrThoughtDisorder) ||
                currentProblemBehaviorsRequireContinuousInterventions == YesNoNotSure.Yes ||
                !(symptomsStabalizedDuringTreatmentDay ?? true) ||
                timingOfPositiveResponseToDetoxificationCare == DetoxificationCareResponseTiming.MoreThan24Hours;

            // David Gastfriends Original PseudoCode:
            // D6LIII.1, III.3, & III.5 -dde = TRUE If [Dim3Px=1 or ASIp19j>0] & [ASIp20=3to7 or ASIp13=2to4] 
            // & [(mean of ASIf: 6a,8a,8b,9a,9b & f19h>2) or p13a>1]	
            //
            // Current Delphi Code
            // x := (ASIf6a + ASIf8a + ASIf8b + ASIf9a + ASIf9b + ASIf19h)/6.0;
            // D6LIII.1, III.3, & III.5 -dde = TRUE If [Dim3Px=1 or ASIp19j>0]
            // & [ASIp20=3to7 or ASIp13=2to4] & [(mean of ASIf: 6a,8a,8b,9a,9b & f19h>2) or p13a>1]
            // OB_D6LIII1dde := (OB_Dim3Px and (ASIp19jMax > 0)) and
            // (IsBtw(ASIp20, 3, 8) or IsBtw(ASIp13, 2, 4)) and
            // ((x > 2) or (ASIp13a > 1));
	        // TODO: ASIp20 = 3 to 7 in PseudoCode ASIp20 = 3 to 8 in DelphiCode
            var x = Utilities.Average( livingArrangementAffectOnRecovery,
                                       freeTimeAffectOnRecovery,
                                       dealsWithProblemsInFreeTimeThatRiskRelapse,
                                       friendsAffectOnRecovery,
                                       dealsWithProblemsFromFriendsThatRiskRelapse,
                                       closestContactsNeedsAndWillingnessToHelpTreatment );

            careLevel_III_3_Score.HasSeverePersistentMentalIllnessNeedsStructureOfLevel33DualDiagnosisEnhanced =
                ((withdrawalSymptomsAndEmotionalBehavioralProblems ?? false) &&
                activePsychiatricDiagnosesOtherThanSubstanceAbuse.Max(p => p.Value) > PsychiatricDiagnosis.None)
                &&
                (IsBtw(patientNeedForPsychiatricPsychologicalTreatmentRating, 3, 8) ||
                IsBtw(howImportantPsychologicalEmotionalCounseling,
                PsychologicalEmotionalCounselingImportanceScale.ModeratelyImportant,
                PsychologicalEmotionalCounselingImportanceScale.ExtremelyImportant))
                &&
                (x > 2 || howEmotionalProblemsImpactRecoveryEfforts >
                EmotionalProblemsImpactRecoveryEffortsScale.ProblemsWontInterfere);

            // David Gastfriends Original PseudoCode:
            // D6LIII.3 = TRUE If D6LIII.3 -a, -b, -c, -d, -e, OR -f	
            //
            // Current Delphi Code
            // ser spsht does not have second term. same situation in others below.
            // D6LIII.3 = TRUE If D6LIII.3 -a, -b, -c, -d, -e, or -f
            // OB_D6LIII3 := (OB_D6LIII3a or OB_D6LIII3be or OB_D6LIII3cd or OB_D6LIII3f) and
            // ((OI_D2Severity > 5) or (OI_D3Severity > 5) or (Post4 > 0));
            // TODO: and (OI_D2Severity > 5) or (OI_D3Severity > 5) or (Post4 > 0)) is not in PseudoCode
            careLevel_III_3_Score.IsMet =
                (careLevel_III_3_Score.LivingEnvironmentModerateHighRiskUnableToMaintainRecovery.Value ||
                careLevel_III_3_Score.CognitiveImpairmentRequires24HourSupervisionToPreventVictimization.Value ||
                careLevel_III_3_Score.SocialNetworkOrLivingWithAlcoholDrugUserImpactsRecovery.Value ||
                careLevel_III_3_Score.IsUnableToCopeOutside24HourStructureProgram.Value) 
                &&
                (dimension2SeverityNumber > 5 || dimension3SeverityNumber > 5 ||
                (detoxificationRequiredMoreThanHourlyMonitoring ?? false));

            // David Gastfriends Original PseudoCode:
            // D6LIII.3dde = TRUE If D6LIII.3 & D6LIII.3dde	
            //
            // Current Delphi Code
            // D6LIII.3dde = TRUE If D6LIII.3 & D6LIII.3dde
            // OB_D6LIII3dde := OB_D6LIII3 and OB_D6LIII3dde;
            careLevel_III_3_Score.IsDualDiagnosisEnhanced =
                careLevel_III_3_Score.IsMet.Value && 
                careLevel_III_3_Score.HasSeverePersistentMentalIllnessNeedsStructureOfLevel33DualDiagnosisEnhanced.Value;
		
            return careLevel_III_3_Score;
        }

        internal CareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore CalculateCareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore(
            LikertScale emotionalAbuseInPast30Days,   // ASIf19a
            LikertScale physicalAbuseInPast30Days,   // ASIf19b
            LikertScale sexualAbuseInPast30Days,   // ASIf19c
            LikertScale riskPatientHarmedByOther,   // ASIf19j
            LivingArrangementAffectOnRecovery livingArrangementAffectOnRecovery,   // ASIf6a
            FriendsAffectOnRecovery friendsAffectOnRecovery,   // ASIf9a
            StrategiesToDealWithProblemsFromFriendsThatRiskRelapse dealsWithProblemsFromFriendsThatRiskRelapse,   // ASIf9b
            NeedsAndWillingnessToHelpTreatment closestContactsNeedsAndWillingnessToHelpTreatment,   // ASIf19h
            Companionship spendsFreeTimeWith,   // ASIf7
            uint? numberOfCloseFriends,   // ASIf9
            ContactPerson closestPersonalContactInPast4Months,   // ASIf19g
            IEnumerable<PsychiatricDiagnosis> activePsychiatricDiagnosesOtherThanSubstanceAbuse,   // ASIp19j
            YesNoNotSure currentProblemBehaviorsRequireContinuousInterventions,   // ASIp20b
            bool? symptomsStabalizedDuringTreatmentDay,   // Post2
            DetoxificationCareResponseTiming timingOfPositiveResponseToDetoxificationCare,   // Post3
            StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse dealsWithProblemsInFreeTimeThatRiskRelapse,   // ASIf8b
            uint? numberOfTimesArrestedForShopliftingVandalism,   // ASIl3
            uint? numberOfTimesArrestedForParoleProbationViolation,   // ASIl4
            uint? numberOfTimesArrestedForDrugCharges,   // ASIl5
            uint? numberOfTimesArrestedForForgery,   // ASIl6
            uint? numberOfTimesArrestedForWeaponsOffense,   // ASIl7
            uint? numberOfTimesArrestedForBurglaryLarceny,   // ASIl8
            uint? numberOfTimesArrestedForRobbery,   // ASIl9
            uint? numberOfTimesArrestedForAssault,   // ASIl10
            uint? numberOfTimesArrestedForArson,   // ASIl11
            uint? numberOfTimesArrestedForRape,   // ASIl12
            uint? numberOfTimesArrestedForHomicide,   // ASIl13
            uint? numberOfTimesArrestedForProstitution,   // ASIl14a
            uint? numberOfTimesArrestedForContemptOfCourt,   // ASIl14b
            uint? numberOfTimesArrestedForOtherArrest,   // ASIl14c
            bool? isCurrentlyAwaitingChargesTrialSentence,   // ASIl22
            uint? numberOfDaysCommitingCrimesForProfitInPast30Days,   // ASIl25
            bool? detoxificationRequiredMoreThanHourlyMonitoring,  // Post4
            int dimension2SeverityNumber,   // OI_D2Severity
            int dimension3SeverityNumber,  // OI_D3Severity 
            LikertScale anxietyAttackMoreThanOnceInLast24Hours,   // ASIp4bD
            LikertScale significantPeriodFidgetingInLast24Hours,   // ASIp4rD
            LikertScale significantPeriodNegativeThoughtsInLast24Hours,   // ASIp4vD
            LikertScale significantPeriodExcessiveBehaviorInLast24Hours,   // ASIp4wD
            LikertScale significantPeriodParanoiaInLast24Hours,   // ASIp4xD
            LikertScale significantPeriodFlashbacksInLast24Hours,   // ASIp5aD
            LikertScale significantPeriodCurbingViolentBehaviorInLast24Hours,   // ASIp7D
            LikertScale significantPeriodViolentUrgesInLast24Hours,   // ASIp7bD
            LikertScale significantPeriodSuicidalThoughtsInLast24Hours,   // ASIp8D
            LikertScale significantPeriodThoughtsOfSelfInjuryInLast24Hours,   // ASIp8aD
            LikertScale significantPeriodAttemptedSuicideInLast24Hours, // ASIp9D
            bool? hasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced)//OB_D6LIII1dde
        {
            var careLevel_III_5_Score = new CareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore();

            // David Gastfriends Original PseudoCode:
            // D6LIII.1-a, 3-a, & 5-a = TRUE If [(any of ASIf: 19a,b,c >1) & ASIf19j>1] or [ASIf6a=4]	
            //
            // Current Delphi Code
            // OB_D6LIII5a := OB_D6LIII1a;
            // OB_D6LIII1a, 3-a, & 5-a = TRUE If [(any of ASIf: 19a,b,c >1) & ASIf19j>1] or [ASIf6a=4]
            // OB_D6LIII1a := (((ASIf19a > 1) or (ASIf19b > 1) or (ASIf19c > 1)) and (ASIf19j > 1)) or 
            // (ASIf6a = 4);
            careLevel_III_5_Score.LivingEnvironmentModerateHighRiskAbuseNoRecoveryAtLowerLevelCare =
                ((emotionalAbuseInPast30Days > LikertScale.Slightly ||
                physicalAbuseInPast30Days > LikertScale.Slightly ||
                sexualAbuseInPast30Days > LikertScale.Slightly) &&
                riskPatientHarmedByOther > LikertScale.Slightly)
                ||
                livingArrangementAffectOnRecovery == LivingArrangementAffectOnRecovery.WillOftenExposeToSubstanceUse;

            // David Gastfriends Original PseudoCode:
            // D6LIII.5-b, -c, & -d = TRUE If [any of ASIf: f7,f9,f19g=0 & f9b=4] or
            // [mean of ASIf 6a,9a,9b,19h =>3]	
            //
            // Current Delphi Code
            // z := (ASIf6a + ASIf9a + ASIf9b + ASIf19h)/4.0; 
            // D6LIII.5-b, -c, & -d = TRUE If [any of ASIf: f7,f9,f19g=0 & f9b=4] or [mean of ASIf 6a,9a,9b,19h =>3] 
            // Corrected DRG alone is f7=3
            //  OB_D6LIII5bcd := ((ASIf7 = 3) or (ASIf9 = 0) or (ASIf19g = 0) and (ASIf9b = 4)) or (z >= 3);
            // TODO: Pseudo code logic '[any of ASIf: f7,f9,f19g=0 & f9b=4]" is ambiguous. Does it mean '[(any of ASIf: f7,f9,f19g=0) & f9b=4]'?
            var z = Utilities.Average( livingArrangementAffectOnRecovery,
                                       friendsAffectOnRecovery,
                                       dealsWithProblemsFromFriendsThatRiskRelapse,
                                       closestContactsNeedsAndWillingnessToHelpTreatment );

            careLevel_III_5_Score.SocialNetworkOrLivingWithAlcoholDrugUserPreventsRecoveryAtLowerLevelOfCare =
                ((spendsFreeTimeWith == Companionship.Alone || numberOfCloseFriends == 0 ||
                closestPersonalContactInPast4Months == ContactPerson.Mother) &&
                dealsWithProblemsFromFriendsThatRiskRelapse ==
                StrategiesToDealWithProblemsFromFriendsThatRiskRelapse.ReclusiveOrDrawnToHighRiskSocialContacts)
                ||
                z >= 3;
     
            // David Gastfriends Original PseudoCode:
            // D6LIII.5-e = TRUE If ASIf19l=0 or p19j>6 or p20b=2 or Post2=0 or Post3=4	
            //
            // Current Delphi Code
            // ser? my spsht has D6LIII.5-e = TRUE If ASIf19l=0 or p19j>6 or p20b=2 or Post2=0 or Post3=4
            // OB_D6LIII5e = TRUE If p19j>6 or p20b=2 or Post2=0 or Post3=4
            // OB_D6LIII5e := ArrayContains(ASIp19j, 9) or ArrayContains(ASIp19j, 10) or (ASIp20b = 2) or (Post2 <> 1) or (Post3 = 4);
            careLevel_III_5_Score.UnableToCopeOutside24HourCareNeedsStaffMonitoring =
                activePsychiatricDiagnosesOtherThanSubstanceAbuse.Contains(PsychiatricDiagnosis.ManiaOrBipolarDisorder) ||
                activePsychiatricDiagnosesOtherThanSubstanceAbuse.Contains(PsychiatricDiagnosis.SchizophreniaPsychoticOrThoughtDisorder) ||
                currentProblemBehaviorsRequireContinuousInterventions == YesNoNotSure.Yes ||
                !(symptomsStabalizedDuringTreatmentDay ?? true) ||
                timingOfPositiveResponseToDetoxificationCare == DetoxificationCareResponseTiming.MoreThan24Hours;

            // David Gastfriends Original PseudoCode:
            // D6LIII.5-f = TRUE If [Any of ASIf 6a,8b,9a,or 9b=4] & [(Sum of ASIl3thru14a,b,c >1)
            // or ASIl22=1 or ASIl25>5]	
            //
            // Current Delphi Code
            // OB_D6LIII5f = TRUE If [Any of ASIf 6a,8b,9a,or 9b=4] &
            // [(Sum of ASIl3thru14a,b,c >1) or ASIl22=1 or ASIl25>5]
            // OB_D6LIII5f := ((ASIf6a = 4) or (ASIf8b = 4) or (ASIf9a = 4) or (ASIf9b = 4)) and
            // (((ASIl3 + ASIl4 + ASIl5 + ASIl6 + ASIl7 + ASIl8 + ASIl9 + 
            // ASIl10 + ASIl11 + ASIl12 + ASIl13 + ASIl14a + ASIl14b + ASIl14c) > 1) or
            // (ASIl22 = 1) or (ASIl25 > 5));
            var hasBeenConvictedOfCrime = new List<uint?>
                                              {
                                                  numberOfTimesArrestedForShopliftingVandalism,
                                                  numberOfTimesArrestedForParoleProbationViolation,
                                                  numberOfTimesArrestedForDrugCharges,
                                                  numberOfTimesArrestedForForgery,
                                                  numberOfTimesArrestedForWeaponsOffense,
                                                  numberOfTimesArrestedForBurglaryLarceny,
                                                  numberOfTimesArrestedForRobbery,
                                                  numberOfTimesArrestedForAssault,
                                                  numberOfTimesArrestedForArson,
                                                  numberOfTimesArrestedForRape,
                                                  numberOfTimesArrestedForHomicide,
                                                  numberOfTimesArrestedForProstitution,
                                                  numberOfTimesArrestedForContemptOfCourt,
                                                  numberOfTimesArrestedForOtherArrest
                                              }.Sum(p=> p.HasValue ? p.Value : 0) > 1;
                                                                   
            careLevel_III_5_Score.LivingEnvironmentHasCriminalBehaviorAndOtherAntiSocialValues =
                (livingArrangementAffectOnRecovery == LivingArrangementAffectOnRecovery.WillOftenExposeToSubstanceUse ||
                dealsWithProblemsInFreeTimeThatRiskRelapse ==
                StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse.PreferenceIsForHighRiskHobbies ||
                friendsAffectOnRecovery == FriendsAffectOnRecovery.WillOftenExposePatientToSubstanceUse ||
                dealsWithProblemsFromFriendsThatRiskRelapse ==
                StrategiesToDealWithProblemsFromFriendsThatRiskRelapse.ReclusiveOrDrawnToHighRiskSocialContacts) 
                &&
                (hasBeenConvictedOfCrime || isCurrentlyAwaitingChargesTrialSentence == true ||
                numberOfDaysCommitingCrimesForProfitInPast30Days > 5);

            // David Gastfriends Original PseudoCode:
            // D6LIII.1, III.3, & III.5 -dde = TRUE If [Dim3Px=1 or ASIp19j>0] &
            // [ASIp20=3to7 or ASIp13=2to4] & [(mean of ASIf: 6a,8a,8b,9a,9b & f19h>2) or p13a>1]	
            //
            // Current Delphi Code
            // nLimitParam := 2;
            // OB_D6LIII5dde := OB_D6LIII1dde and MoreImmedPsychD6(nLimitParam);
            var moreImmedPsychD6 = MoreImmedPsychD6(2,
                                                    anxietyAttackMoreThanOnceInLast24Hours,
                                                    significantPeriodFidgetingInLast24Hours,
                                                    significantPeriodNegativeThoughtsInLast24Hours,
                                                    significantPeriodExcessiveBehaviorInLast24Hours,
                                                    significantPeriodParanoiaInLast24Hours,
                                                    significantPeriodFlashbacksInLast24Hours,
                                                    significantPeriodCurbingViolentBehaviorInLast24Hours,
                                                    significantPeriodViolentUrgesInLast24Hours,
                                                    significantPeriodSuicidalThoughtsInLast24Hours,
                                                    significantPeriodThoughtsOfSelfInjuryInLast24Hours,
                                                    significantPeriodAttemptedSuicideInLast24Hours);

            careLevel_III_5_Score.HasSeverePersistentMentalIllnessNeedsStructureOfLevel35DualDiagnosisEnhanced =
                hasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced.Value && moreImmedPsychD6;
                
            // David Gastfriends Original PseudoCode:
            // D6LIII.5 = TRUE If D6LIII.5 -a, -b, -c, -d, -e, OR -f	
            //
            // Current Delphi Code
            // D6LIII.5 = TRUE If D6LIII.5 -a, -b, -c, -d, -e, OR -f
            // OB_D6LIII5 := (OB_D6LIII5a or OB_D6LIII5bcd or OB_D6LIII5e or OB_D6LIII5f) and
            // ((OI_D2Severity > 6) or (OI_D3Severity > 6) or (Post4 > 0));
            careLevel_III_5_Score.IsMet =
                (careLevel_III_5_Score.LivingEnvironmentModerateHighRiskAbuseNoRecoveryAtLowerLevelCare.Value ||
                careLevel_III_5_Score.SocialNetworkOrLivingWithAlcoholDrugUserPreventsRecoveryAtLowerLevelOfCare.Value ||
                careLevel_III_5_Score.UnableToCopeOutside24HourCareNeedsStaffMonitoring.Value ||
                careLevel_III_5_Score.LivingEnvironmentHasCriminalBehaviorAndOtherAntiSocialValues.Value) 
                &&
                (dimension2SeverityNumber > 6 || dimension3SeverityNumber > 6 ||
                (detoxificationRequiredMoreThanHourlyMonitoring ?? false));

            // David Gastfriends Original PseudoCode:
            // D6LIII.5dde = TRUE If D6LIII.5 & D6LIII.5dde	
            //
            // Current Delphi Code
            // D6LIII.5dde = TRUE If D6LIII.5 & D6LIII.5dde
            // OB_D6LIII5dde := OB_D6LIII5 and OB_D6LIII5dde;
            careLevel_III_5_Score.IsDualDiagnosisEnhanced =
                careLevel_III_5_Score.IsMet.Value &&
                careLevel_III_5_Score.HasSeverePersistentMentalIllnessNeedsStructureOfLevel35DualDiagnosisEnhanced.Value;

            return careLevel_III_5_Score;
        }

        internal CareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScore CalculateCareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScore(
            LikertScale emotionalAbuseInPast30Days,   // ASIf19a
            LikertScale physicalAbuseInPast30Days,   // ASIf19b
            LikertScale sexualAbuseInPast30Days,   // ASIf19c
            LikertScale riskPatientHarmedByOther,   // ASIf19j
            LivingArrangementAffectOnRecovery livingArrangementAffectOnRecovery,   // ASIf6a
            bool? detoxificationRequiredMoreThanHourlyMonitoring,   // Post4
            IEnumerable<PsychiatricDiagnosis> activePsychiatricDiagnosesOtherThanSubstanceAbuse,   // ASIp19j
            YesNoNotSure currentProblemBehaviorsRequireContinuousInterventions,   // ASIp20b
            DetoxificationCareResponseTiming timingOfPositiveResponseToDetoxificationCare,  // Post3
            LikertScale anxietyAttackMoreThanOnceInLast24Hours,   // ASIp4bD
            LikertScale significantPeriodFidgetingInLast24Hours,   // ASIp4rD
            LikertScale significantPeriodNegativeThoughtsInLast24Hours,   // ASIp4vD
            LikertScale significantPeriodExcessiveBehaviorInLast24Hours,   // ASIp4wD
            LikertScale significantPeriodParanoiaInLast24Hours,   // ASIp4xD
            LikertScale significantPeriodFlashbacksInLast24Hours,   // ASIp5aD
            LikertScale significantPeriodCurbingViolentBehaviorInLast24Hours,   // ASIp7D
            LikertScale significantPeriodViolentUrgesInLast24Hours,   // ASIp7bD
            LikertScale significantPeriodSuicidalThoughtsInLast24Hours,   // ASIp8D
            LikertScale significantPeriodThoughtsOfSelfInjuryInLast24Hours,   // ASIp8aD
            LikertScale significantPeriodAttemptedSuicideInLast24Hours, // ASIp9D
            int dimension2SeverityNumber,   // OI_D2Severity
            int dimension3SeverityNumber, // OI_D3Severity 
            bool? socialNetworkOrLivingWithAlcoholDrugUserImpactsRecovery, //OB_D6LIII3cd
            bool? hasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced) //OB_D6LIII1dde 
        {
            var careLevel_III_7_Score = new CareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScore();

            // David Gastfriends Original PseudoCode:
            // D6LIII.7-a = TRUE If [{(any of ASIf: 19a,b,c >1) & ASIf19j>1} or {ASIf6a=4}] & Post4=1	
            //
            // Current Delphi Code
            // OB_D6LIII7a = TRUE If [{(any of ASIf: 19a,b,c >1) & ASIf19j>1} or {ASIf6a=4}] & Post4=1
            // OB_D6LIII7a := ((((ASIf19a > 1) or (ASIf19b > 1) or (ASIf19c > 1)) and (ASIf19j > 1)) or (ASIf6a = 4)) and
            // (Post4 = 1);
            careLevel_III_7_Score.RequiresContinuousMedicalMonitoringAddressPsychSubstance =
                (((emotionalAbuseInPast30Days > LikertScale.Slightly ||
                physicalAbuseInPast30Days > LikertScale.Slightly ||
                sexualAbuseInPast30Days > LikertScale.Slightly) &&
                riskPatientHarmedByOther > LikertScale.Slightly) ||
                livingArrangementAffectOnRecovery == LivingArrangementAffectOnRecovery.WillOftenExposeToSubstanceUse) 
                &&
                (detoxificationRequiredMoreThanHourlyMonitoring ?? false);

            // David Gastfriends Original PseudoCode:
            // D6LIII.7-b = TRUE If mean of ASIf 6a,9a,9b,19h =>3	
            //
            // Current Delphi Code
            // OB_D6LIII7b = TRUE If mean of ASIf 6a,9a,9b,19h =>3
            // OB_D6LIII7b := OB_D6LIII3cd;
            careLevel_III_7_Score.AreNotSupportiveOfRecoveryGoalsActivelySabotagingTreatment =
                (socialNetworkOrLivingWithAlcoholDrugUserImpactsRecovery ?? false);


            // David Gastfriends Original PseudoCode:
            // D6LIII.7-c = TRUE If ASIf19l=0 or p19j>6 or p20b=2 or Post2=0 or Post3=4	
            //
            // Current Delphi Code
            // ser? my spsht has D6LIII.7-c = TRUE If ASIf19l=0 or p19j>6 or p20b=2 or Post2=0 or Post3=4
            // OB_D6LIII7c = TRUE If p19j>6 or p20b=2 or Post2=0 or Post3=4
            // OB_D6LIII7c := ArrayContains(ASIp19j, 9) or ArrayContains(ASIp19j, 10) or (ASIp20b = 2) or (Post3 = 4);
            careLevel_III_7_Score.UnableToCopeOutside24HourCareNeedsStaffMonitoring =
                activePsychiatricDiagnosesOtherThanSubstanceAbuse.Contains(PsychiatricDiagnosis.ManiaOrBipolarDisorder) ||
                activePsychiatricDiagnosesOtherThanSubstanceAbuse.Contains(PsychiatricDiagnosis.SchizophreniaPsychoticOrThoughtDisorder) ||
                currentProblemBehaviorsRequireContinuousInterventions == YesNoNotSure.Yes ||
                timingOfPositiveResponseToDetoxificationCare == DetoxificationCareResponseTiming.MoreThan24Hours;

            // David Gastfriends Original PseudoCode:
            // D6LIII.7dde = TRUE If [Dim3Px=1 or ASIp19j>0] & 
            // [ASIp20=3to7 or ASIp13=2to4] & [(mean of ASIf: 6a,8a,8b,9a,9b & f19h>2) or p13a>1]	
            //
            // Current Delphi Code
            // D6LIII.7dde = TRUE If [Dim3Px=1 or ASIp19j>0] & [ASIp20=3to7 or ASIp13=2to4]
            // & [(mean of ASIf: 6a,8a,8b,9a,9b & f19h>2) or p13a>1]
            // nLimitParam := 3;
            // OB_D6LIII7dde := OB_D6LIII1dde and MoreImmedPsychD6(nLimitParam);
            var moreImmedPsychD6 = MoreImmedPsychD6(3,
                                                    anxietyAttackMoreThanOnceInLast24Hours,
                                                    significantPeriodFidgetingInLast24Hours,
                                                    significantPeriodNegativeThoughtsInLast24Hours,
                                                    significantPeriodExcessiveBehaviorInLast24Hours,
                                                    significantPeriodParanoiaInLast24Hours,
                                                    significantPeriodFlashbacksInLast24Hours,
                                                    significantPeriodCurbingViolentBehaviorInLast24Hours,
                                                    significantPeriodViolentUrgesInLast24Hours,
                                                    significantPeriodSuicidalThoughtsInLast24Hours,
                                                    significantPeriodThoughtsOfSelfInjuryInLast24Hours,
                                                    significantPeriodAttemptedSuicideInLast24Hours);

            careLevel_III_7_Score.HasSeverePersistentMentalIllnessNeedsStructureOfLevel37DualDiagnosisEnhanced =
                (hasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced ?? false) && moreImmedPsychD6;
               
            // David Gastfriends Original PseudoCode:
            // D6LIII.7 = TRUE If D6LIII.7 -a, -b, OR -c	
            //
            // Current Delphi Code
            // OB_D6LIII7 := (OB_D6LIII7a or OB_D6LIII7b or OB_D6LIII7c) and
            // ((OI_D2Severity > 6) or (OI_D3Severity > 6) or (Post4 > 0)); 
            careLevel_III_7_Score.IsMet =
                (careLevel_III_7_Score.RequiresContinuousMedicalMonitoringAddressPsychSubstance.Value ||
                careLevel_III_7_Score.AreNotSupportiveOfRecoveryGoalsActivelySabotagingTreatment.Value ||
                careLevel_III_7_Score.UnableToCopeOutside24HourCareNeedsStaffMonitoring.Value) 
                &&
                (dimension2SeverityNumber > 6 || dimension3SeverityNumber > 6 ||
                (detoxificationRequiredMoreThanHourlyMonitoring ?? false));

            // David Gastfriends Original PseudoCode:
            // D6LIII.7dde = TRUE If D6LIII.7 & D6LIII.7dde	
            //
            // Current Delphi Code
            // D6LIII.7dde = TRUE If D6LIII.7 & D6LIII.7dde
            // OB_D6LIII7dde := OB_D6LIII7 and OB_D6LIII7dde;
            careLevel_III_7_Score.IsDualDiagnosisEnhanced =
                careLevel_III_7_Score.IsMet.Value &&
                careLevel_III_7_Score.HasSeverePersistentMentalIllnessNeedsStructureOfLevel37DualDiagnosisEnhanced.Value;

            return careLevel_III_7_Score;
        }
        #endregion   
    }
}



