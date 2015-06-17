using Asam.Ppc.Domain.AssessmentModule.Completion;
using Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups;
using Asam.Ppc.Domain.AssessmentModule.EmploymentAndSupport;
using Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory;
using Asam.Ppc.Domain.AssessmentModule.Legal;
using Asam.Ppc.Domain.AssessmentModule.Psychological;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.Scoring.ScoringModule.Dimension6LivingEnvironment;
using Asam.Ppc.Domain.Tests.Extensions;
using Asam.Ppc.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asam.Ppc.Domain.Tests.AssessmentModule.Scoring.Dimension6LivingEnvironment
{
    [TestClass]
   public class Dimension6ScoringStrategyTests
    {
           
        #region Public Properties

        public TestContext TestContext { get; set; }

        #endregion

        #region Public Methods

        [TestMethod]
        [DataSource("D6_CareLevel_0_5_EarlyInterventionScore")]
        public void D6_CalculateCareLevel_0_5_EarlyInterventionScoreTests()
        {
            var freeTimeAffectOnRecovery = TestContext.GetLookup<FreeTimeAffectOnRecovery>("FreeTimeAffectOnRecovery");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var friendsAffectOnRecovery = TestContext.GetLookup<FriendsAffectOnRecovery>("FriendsAffectOnRecovery");
            var closestContactsNeedsAndWillingnessToHelpTreatment = TestContext.GetLookup<NeedsAndWillingnessToHelpTreatment>("ClosestContactsNeedsAndWillingnessToHelpTreatment");
            var dealsWithProblemsInFreeTimeThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse>("DealsWithProblemsInFreeTimeThatRiskRelapse");
            var anyAddictionDiagnosisExceptNicotine = TestContext.GetBoolean("AnyAddictionDiagnosisExceptNicotine");

            var hasSupportSystemThatPreventsThemFromMeetingObligations = TestContext.GetBoolean("HasSupportSystemThatPreventsThemFromMeetingObligations");
            var hasFamilyMembersCurrentlyAbusingAlcoholOrDrugs = TestContext.GetBoolean("HasFamilyMembersCurrentlyAbusingAlcoholOrDrugs");
            var hasSignificantOtherWithDrugOrAlcoholValuesConflict = TestContext.GetBoolean("HasSignificantOtherWithDrugOrAlcoholValuesConflict");
            var hasSignificantOtherWhoCondonesOrEncouragesAlcoholOrDrugUse = TestContext.GetBoolean("HasSignificantOtherWhoCondonesOrEncouragesAlcoholOrDrugUse");
            var isMet = TestContext.GetBoolean("IsMet");

            var dimension6ScoringStrategy = new Dimension6ScoringStrategy();
            var careLevel_0_5_Score = dimension6ScoringStrategy.CalculateCareLevel_0_5_EarlyInterventionScore(
                freeTimeAffectOnRecovery,	
                livingArrangementAffectOnRecovery,	
                friendsAffectOnRecovery	,
                closestContactsNeedsAndWillingnessToHelpTreatment,	
                dealsWithProblemsInFreeTimeThatRiskRelapse,
                anyAddictionDiagnosisExceptNicotine);

            Assert.AreEqual(hasSupportSystemThatPreventsThemFromMeetingObligations, careLevel_0_5_Score.HasSupportSystemThatPreventsThemFromMeetingObligations, "HasSupportSystemThatPreventsThemFromMeetingObligations didn't match.");
            Assert.AreEqual(hasFamilyMembersCurrentlyAbusingAlcoholOrDrugs, careLevel_0_5_Score.HasFamilyMembersCurrentlyAbusingAlcoholOrDrugs, "HasFamilyMembersCurrentlyAbusingAlcoholOrDrugs didn't match.");
            Assert.AreEqual(hasSignificantOtherWithDrugOrAlcoholValuesConflict, careLevel_0_5_Score.HasSignificantOtherWithDrugOrAlcoholValuesConflict, "HasSignificantOtherWithDrugOrAlcoholValuesConflict didn't match.");
            Assert.AreEqual(hasSignificantOtherWhoCondonesOrEncouragesAlcoholOrDrugUse, careLevel_0_5_Score.HasSignificantOtherWhoCondonesOrEncouragesAlcoholOrDrugUse, "HasSignificantOtherWhoCondonesOrEncouragesAlcoholOrDrugUse didn't match.");
            Assert.AreEqual(isMet, careLevel_0_5_Score.IsMet, "CareLevel_0_5_Score didn't match.");
        }

        [TestMethod]
        [DataSource("D6_CareLevel_I_OutpatientScore")]
        public void D6_CareLevel_I_OutpatientScoreTest()
        {
            var feelLikelyToContinueSubstanceUseOrRelapse = TestContext.GetLookup<SubstanceUseOrRelapseLikelihood>("FeelLikelyToContinueSubstanceUseOrRelapse");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var freeTimeAffectOnRecovery = TestContext.GetLookup<FreeTimeAffectOnRecovery>("FreeTimeAffectOnRecovery");
            var dealsWithProblemsInFreeTimeThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse>("DealsWithProblemsInFreeTimeThatRiskRelapse");
            var friendsAffectOnRecovery = TestContext.GetLookup<FriendsAffectOnRecovery>("FriendsAffectOnRecovery");
            var dealsWithProblemsFromFriendsThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsFromFriendsThatRiskRelapse>("DealsWithProblemsFromFriendsThatRiskRelapse");
            var closestContactsNeedsAndWillingnessToHelpTreatment = TestContext.GetLookup<NeedsAndWillingnessToHelpTreatment>("ClosestContactsNeedsAndWillingnessToHelpTreatment");
            var desireAndExternalFactorsDrivingTreatment = TestContext.GetLookup<DesireAndExternalFactorsDrivingTreatment>("DesireAndExternalFactorsDrivingTreatment");
            var isAbleToLocateAndGetToCommunityResourcesSafely = TestContext.GetBoolean("IsAbleToLocateAndGetToCommunityResourcesSafely");
            var mobilityProblemsMayAffectTreatmentAttendance = TestContext.GetLookup<YesNoNotSure>("MobilityProblemsMayAffectTreatmentAttendance");
            var concernsAboutPursuingTreatment = TestContext.GetLookup<ConcernsAboutPursuingTreatment>("ConcernsAboutPursuingTreatment");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var howDifficultProblemsForWorkHomeAndSocialInteraction = TestContext.GetLookup<ProblemsForWorkHomeAndSocialInteractionScale>("HowDifficultProblemsForWorkHomeAndSocialInteraction");
            var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale>("HowEmotionalProblemsImpactRecoveryEfforts");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8 ( TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));	
            var howImportantPsychologicalEmotionalCounseling = TestContext.GetLookup<PsychologicalEmotionalCounselingImportanceScale>("HowImportantPsychologicalEmotionalCounseling");
            var intensiveCaseManagementAccessibleToPatient = TestContext.GetLookup<YesNoNotSure>("IntensiveCaseManagementAccessibleToPatient");
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = TestContext.GetLookups<PsychiatricDiagnosis>("ActivePsychiatricDiagnosesOtherThanSubstanceAbuse");
            var withdrawalSymptomsAndEmotionalBehavioralProblems = TestContext.GetBoolean("WithdrawalSymptomsAndEmotionalBehavioralProblems");
            var hasImminentSevereConsequences = TestContext.GetBoolean("HasImminentSevereConsequences");

            var psychosocialEnvironmentSupportiveOutpatientTreatmentFeasible	 = TestContext.GetBoolean("PsychosocialEnvironmentSupportiveOutpatientTreatmentFeasible");
            var socialSupportNotAdequatePatientMotivatedToObtainSupportive	 = TestContext.GetBoolean("SocialSupportNotAdequatePatientMotivatedToObtainSupportive");
            var supportiveButRequireProfessionalInterventionsForRecovery = TestContext.GetBoolean("SupportiveButRequireProfessionalInterventionsForRecovery");
            var socialSupportNotAdequateAndMildImpairmentInAbilityToObtainOne	 = TestContext.GetBoolean("SocialSupportNotAdequateAndMildImpairmentInAbilityToObtainOne");
            var socialSupportRequiresActiveFamilyTherapyForSuccessAndRecovery	 = TestContext.GetBoolean("SocialSupportRequiresActiveFamilyTherapyForSuccessAndRecovery");
            var isChronicallyImpairedNoAdequateSupportButAccessToRecoveryEnvironment = TestContext.GetBoolean("IsChronicallyImpairedNoAdequateSupportButAccessToRecovery");
            var isMet = TestContext.GetBoolean ( "IsMet" );
            var isDualDiagnosisEnhanced = TestContext.GetBoolean ( "IsDualDiagnosisEnhanced" );

            if(TestContext.GetBoolean("ForDebug"))
            {
                
            }

            var dimension6ScoringStrategy = new Dimension6ScoringStrategy();
                var careLevel_I_OutpatientScore = dimension6ScoringStrategy.CalculateCareLevel_I_OutpatientScore(
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

            Assert.AreEqual(psychosocialEnvironmentSupportiveOutpatientTreatmentFeasible, careLevel_I_OutpatientScore.PsychosocialEnvironmentSupportiveOutpatientTreatmentFeasible, "PsychosocialEnvironmentSupportiveOutpatientTreatmentFeasible didn't match.");
            Assert.AreEqual(socialSupportNotAdequatePatientMotivatedToObtainSupportive, careLevel_I_OutpatientScore.SocialSupportNotAdequatePatientMotivatedToObtainSupportive, "SocialSupportNotAdequatePatientMotivatedToObtainSupportive didn't match.");
            Assert.AreEqual(supportiveButRequireProfessionalInterventionsForRecovery, careLevel_I_OutpatientScore.SupportiveButRequireProfessionalInterventionsForRecovery, "SupportiveButRequireProfessionalInterventionsForRecovery didn't match.");
            Assert.AreEqual(socialSupportNotAdequateAndMildImpairmentInAbilityToObtainOne, careLevel_I_OutpatientScore.SocialSupportNotAdequateAndMildImpairmentInAbilityToObtainOne, "SocialSupportNotAdequateAndMildImpairmentInAbilityToObtainOne didn't match.");
            Assert.AreEqual(socialSupportRequiresActiveFamilyTherapyForSuccessAndRecovery, careLevel_I_OutpatientScore.SocialSupportRequiresActiveFamilyTherapyForSuccessAndRecovery, "SocialSupportRequiresActiveFamilyTherapyForSuccessAndRecovery didn't match.");
            Assert.AreEqual(isChronicallyImpairedNoAdequateSupportButAccessToRecoveryEnvironment, careLevel_I_OutpatientScore.IsChronicallyImpairedNoAdequateSupportButAccessToRecoveryEnvironment, "IsChronicallyImpairedNoAdequateSupportButAccessToRecovery didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_I_OutpatientScore.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_I_OutpatientScore.IsMet, "CareLevel_I_Score didn't match.");
        }

        [TestMethod]
        [DataSource("D6_CareLevelOpioidMaintenanceTherapyScore")]
        public void D6_CalculateCareLevelOpioidMaintenanceTherapyScoreTests()
        {
            var feelLikelyToContinueSubstanceUseOrRelapse = TestContext.GetLookup<SubstanceUseOrRelapseLikelihood>("FeelLikelyToContinueSubstanceUseOrRelapse");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var freeTimeAffectOnRecovery = TestContext.GetLookup<FreeTimeAffectOnRecovery>("FreeTimeAffectOnRecovery");
            var dealsWithProblemsInFreeTimeThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse>("DealsWithProblemsInFreeTimeThatRiskRelapse");
            var friendsAffectOnRecovery = TestContext.GetLookup<FriendsAffectOnRecovery>("FriendsAffectOnRecovery");
            var dealsWithProblemsFromFriendsThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsFromFriendsThatRiskRelapse>("DealsWithProblemsFromFriendsThatRiskRelapse");
            var mobilityProblemsMayAffectTreatmentAttendance = TestContext.GetLookup<YesNoNotSure>("MobilityProblemsMayAffectTreatmentAttendance");
            var closestContactsNeedsAndWillingnessToHelpTreatment = TestContext.GetLookup<NeedsAndWillingnessToHelpTreatment>("ClosestContactsNeedsAndWillingnessToHelpTreatment");
            var concernsAboutPursuingTreatment = TestContext.GetLookup<ConcernsAboutPursuingTreatment>("ConcernsAboutPursuingTreatment");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var emotionalAbuseInPast30Days = TestContext.GetLookup<LikertScale>("EmotionalAbuseInPast30Days");
            var physicalAbuseInPast30Days = TestContext.GetLookup<LikertScale>("PhysicalAbuseInPast30Days");
            var sexualAbuseInPast30Days = TestContext.GetLookup<LikertScale>("SexualAbuseInPast30Days");
            var familyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II = TestContext.GetLookup<LikertScale>("FamilyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II");
            var riskPatientHarmedByOther = TestContext.GetLookup<LikertScale>("RiskPatientHarmedByOther");
            var wasVisitPromptedByCriminalJusticeSystem = TestContext.GetBoolean("WasVisitPromptedByCriminalJusticeSystem");
            var isOnProbationOrParole = TestContext.GetBoolean("IsOnProbationOrParole");
            var numberOfTimesArrestedForShopliftingVandalism = TestContext.GetUInt32("NumberOfTimesArrestedForShopliftingVandalism");
            var numberOfTimesArrestedForParoleProbationViolation = TestContext.GetUInt32("NumberOfTimesArrestedForParoleProbationViolation");
            var numberOfTimesArrestedForDrugCharges = TestContext.GetUInt32("NumberOfTimesArrestedForDrugCharges");
            var numberOfTimesArrestedForForgery = TestContext.GetUInt32("NumberOfTimesArrestedForForgery");
            var numberOfTimesArrestedForWeaponsOffense = TestContext.GetUInt32("NumberOfTimesArrestedForWeaponsOffense");
            var numberOfTimesArrestedForBurglaryLarceny = TestContext.GetUInt32("NumberOfTimesArrestedForBurglaryLarceny");
            var numberOfTimesArrestedForRobbery = TestContext.GetUInt32("NumberOfTimesArrestedForRobbery");
            var numberOfTimesArrestedForAssault = TestContext.GetUInt32("NumberOfTimesArrestedForAssault");
            var numberOfTimesArrestedForArson = TestContext.GetUInt32("NumberOfTimesArrestedForArson");
            var numberOfTimesArrestedForRape = TestContext.GetUInt32("NumberOfTimesArrestedForRape");
            var numberOfTimesArrestedForHomicide = TestContext.GetUInt32("NumberOfTimesArrestedForHomicide");
            var numberOfTimesArrestedForProstitution = TestContext.GetUInt32("NumberOfTimesArrestedForProstitution");
            var numberOfTimesArrestedForContemptOfCourt = TestContext.GetUInt32("NumberOfTimesArrestedForContemptOfCourt");
            var numberOfTimesArrestedForOtherArrest = TestContext.GetUInt32("NumberOfTimesArrestedForOtherArrest");
            var numberOfTimesConvicted = TestContext.GetUInt32("NumberOfTimesConvicted");
            var hasSuicidalThoughts = new ScaleOf0To8(TestContext.GetUInt32("HasSuicidalThoughts"));
            var demonstratingDangerToSelfOrOthers = new ScaleOf0To8(TestContext.GetUInt32("DemonstratingDangerToSelfOrOthers"));
            var limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers = new ScaleOf0To8(TestContext.GetUInt32("LimitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers"));
            var indicatingRiskOfHarmToOthers = new ScaleOf0To8(TestContext.GetUInt32("IndicatingRiskOfHarmToOthers"));
            var indicatingRiskOfHarmToSelfOrVictimizationByOthers = new ScaleOf0To8(TestContext.GetUInt32("IndicatingRiskOfHarmToSelfOrVictimizationByOthers"));
            var anyOpioidAddictionDiagnosis = TestContext.GetBoolean("AnyOpioidAddictionDiagnosis");

            var hasSupportivePsychosocialEnvironmentToRenderOpioidManintenanceFeasible = TestContext.GetBoolean("HasSupportivePsychosocialEnvironmentToRenderOpioidManintenance");
            var supportiveButRequireProfessionalInterventionsForTreatmentSuccess = TestContext.GetBoolean("SupportiveButRequireProfessionalInterventionsForTreatment");
            var noPositiveSocialSupportPatientMotivatedToObtainSupportSystem = TestContext.GetBoolean("NoPositiveSocialSupportPatientMotivatedToObtainSupportSystem");
            var hasExperiencedTraumaInRecoveryEnvironmentManageableAsOutpatient = TestContext.GetBoolean("HasExperiencedTraumaInRecoveryEnvironmentManageableAsOut");
            var isMet = TestContext.GetBoolean("IsMet");

            var dimension6ScoringStrategy = new Dimension6ScoringStrategy();
            var careLevel_OMT_Score = dimension6ScoringStrategy.CalculateCareLevelOpioidMaintenanceTherapyScore(
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

            Assert.AreEqual(hasSupportivePsychosocialEnvironmentToRenderOpioidManintenanceFeasible, careLevel_OMT_Score.HasSupportivePsychosocialEnvironmentToRenderOpioidManintenanceFeasible, "HasSupportivePsychosocialEnvironmentToRenderOpioidManintenance didn't match.");
            Assert.AreEqual(supportiveButRequireProfessionalInterventionsForTreatmentSuccess, careLevel_OMT_Score.SupportiveButRequireProfessionalInterventionsForTreatmentSuccess, "SupportiveButRequireProfessionalInterventionsForTreatment didn't match.");
            Assert.AreEqual(noPositiveSocialSupportPatientMotivatedToObtainSupportSystem, careLevel_OMT_Score.NoPositiveSocialSupportPatientMotivatedToObtainSupportSystem, "NoPositiveSocialSupportPatientMotivatedToObtainSupportSystem didn't match.");
            Assert.AreEqual(hasExperiencedTraumaInRecoveryEnvironmentManageableAsOutpatient, careLevel_OMT_Score.HasExperiencedTraumaInRecoveryEnvironmentManageableAsOutpatient, "HasExperiencedTraumaInRecoveryEnvironmentManageableAsOut didn't match.");
            Assert.AreEqual(isMet, careLevel_OMT_Score.IsMet, "CareLevel_OMT_Score didn't match.");
        }

        [TestMethod]
        [DataSource("D6_CareLevel_II_1_IntensiveOutpatientScore")]
        public void D6_CalculateCareLevel_II_1_IntensiveOutpatientScoreTests()
        {
            var workOrSchoolAffectOnRecovery = TestContext.GetLookup<WorkOrSchoolAffectOnRecovery>("WorkOrSchoolAffectOnRecovery");
            var feelLikelyToContinueSubstanceUseOrRelapse = TestContext.GetLookup<SubstanceUseOrRelapseLikelihood>("FeelLikelyToContinueSubstanceUseOrRelapse");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var freeTimeAffectOnRecovery = TestContext.GetLookup<FreeTimeAffectOnRecovery>("FreeTimeAffectOnRecovery");
            var concernsAboutPursuingTreatment = TestContext.GetLookup<ConcernsAboutPursuingTreatment>("ConcernsAboutPursuingTreatment");
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var dealsWithProblemsInFreeTimeThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse>("DealsWithProblemsInFreeTimeThatRiskRelapse");
            var spendsFreeTimeWith = TestContext.GetLookup<Companionship>("SpendsFreeTimeWith");
            var numberOfCloseFriends = TestContext.GetUInt32("NumberOfCloseFriends");
            var friendsAffectOnRecovery = TestContext.GetLookup<FriendsAffectOnRecovery>("FriendsAffectOnRecovery");
            var dealsWithProblemsFromFriendsThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsFromFriendsThatRiskRelapse>("DealsWithProblemsFromFriendsThatRiskRelapse");
            var closestContactsNeedsAndWillingnessToHelpTreatment = TestContext.GetLookup<NeedsAndWillingnessToHelpTreatment>("ClosestContactsNeedsAndWillingnessToHelpTreatment");
            var appearanceOfDepressionWithdrawal = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfDepressionWithdrawal"));
            var appearanceofAgitation = new ScaleOf0To8(TestContext.GetUInt32("AppearanceofAgitation"));
            var appearanceOfAnxietyNervousness = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfAnxietyNervousness"));
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var levelOfSupervisionNeededForProtectionFromSelfHarm = new ScaleOf0To8(TestContext.GetUInt32("LevelOfSupervisionNeededForProtectionFromSelfHarm"));

            var currentSchoolWorkLivingWillRenderRecoveryUnlikely = TestContext.GetBoolean("CurrentSchoolWorkLivingWillRenderRecoveryUnlikely");
            var insufficientOrInappropriateSocialContactsJeopardizeRecovery = TestContext.GetBoolean("InsufficientOrInappropriateSocialContactsJeopardizeRecovery");
            var hasInsufficientResourcesSupportiveOfGoodMentalFunctioning = TestContext.GetBoolean("HasInsufficientResourcesSupportiveOfGoodMentalFunctioning");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            var dimension6ScoringStrategy = new Dimension6ScoringStrategy();
            var careLevel_II_1_IntensiveOutpatientScore = dimension6ScoringStrategy.CalculateCareLevel_II_1_IntensiveOutpatientScore(
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
                    levelOfSupervisionNeededForProtectionFromSelfHarm );

            Assert.AreEqual(currentSchoolWorkLivingWillRenderRecoveryUnlikely, careLevel_II_1_IntensiveOutpatientScore.CurrentSchoolWorkLivingWillRenderRecoveryUnlikely, "CurrentSchoolWorkLivingWillRenderRecoveryUnlikely didn't match.");
            Assert.AreEqual(insufficientOrInappropriateSocialContactsJeopardizeRecovery, careLevel_II_1_IntensiveOutpatientScore.InsufficientOrInappropriateSocialContactsJeopardizeRecovery, "InsufficientOrInappropriateSocialContactsJeopardizeRecovery didn't match.");
            Assert.AreEqual(hasInsufficientResourcesSupportiveOfGoodMentalFunctioning, careLevel_II_1_IntensiveOutpatientScore.HasInsufficientResourcesSupportiveOfGoodMentalFunctioning, "HasInsufficientResourcesSupportiveOfGoodMentalFunctioning didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_II_1_IntensiveOutpatientScore.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_II_1_IntensiveOutpatientScore.IsMet, "CareLevel_II_1_Score didn't match.");
        }

        [TestMethod]
        [DataSource("D6_CareLevel_II_5_PartialHospitalizationScore")]
        public void D6_CalculateCareLevel_II_5_PartialHospitalizationScoreTests()
        {
            var workOrSchoolAffectOnRecovery = TestContext.GetLookup<WorkOrSchoolAffectOnRecovery>("WorkOrSchoolAffectOnRecovery");
            var feelLikelyToContinueSubstanceUseOrRelapse = TestContext.GetLookup<SubstanceUseOrRelapseLikelihood>("FeelLikelyToContinueSubstanceUseOrRelapse");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var freeTimeAffectOnRecovery = TestContext.GetLookup<FreeTimeAffectOnRecovery>("FreeTimeAffectOnRecovery");
            var concernsAboutPursuingTreatment = TestContext.GetLookup<ConcernsAboutPursuingTreatment>("ConcernsAboutPursuingTreatment");
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var dealsWithProblemsInFreeTimeThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse>("DealsWithProblemsInFreeTimeThatRiskRelapse");
            var closestContactsNeedsAndWillingnessToHelpTreatment = TestContext.GetLookup<NeedsAndWillingnessToHelpTreatment>("ClosestContactsNeedsAndWillingnessToHelpTreatment");
            var appearanceOfDepressionWithdrawal = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfDepressionWithdrawal"));
            var appearanceofAgitation = new ScaleOf0To8(TestContext.GetUInt32("AppearanceofAgitation"));
            var appearanceOfAnxietyNervousness = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfAnxietyNervousness"));
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var levelOfSupervisionNeededForProtectionFromSelfHarm = new ScaleOf0To8(TestContext.GetUInt32("LevelOfSupervisionNeededForProtectionFromSelfHarm"));

            var continuedExposureToCurrentSchoolWorkLivingWillRenderRecoveryUnlikely = TestContext.GetBoolean("ContinuedExposureToCurrentSchoolWorkLivingWillRenderRecovery");
            var areNotSupportiveOfRecoveryGoalsPassivelyOpposedToTreatment = TestContext.GetBoolean("AreNotSupportiveOfRecoveryGoalsPassivelyOpposedToTreatment");
            var hasInsufficientResourcesSupportiveOfGoodMentalFunctioning = TestContext.GetBoolean("HasInsufficientResourcesSupportiveOfGoodMentalFunctioning");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            var dimension6ScoringStrategy = new Dimension6ScoringStrategy();
            var careLevel_II_5_PartialHospitalizationScore = dimension6ScoringStrategy.CalculateCareLevel_II_5_PartialHospitalizationScore(
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

            Assert.AreEqual(continuedExposureToCurrentSchoolWorkLivingWillRenderRecoveryUnlikely, careLevel_II_5_PartialHospitalizationScore.ContinuedExposureToCurrentSchoolWorkLivingWillRenderRecoveryUnlikely, "ContinuedExposureToCurrentSchoolWorkLivingWillRenderRecovery didn't match.");
            Assert.AreEqual(areNotSupportiveOfRecoveryGoalsPassivelyOpposedToTreatment, careLevel_II_5_PartialHospitalizationScore.AreNotSupportiveOfRecoveryGoalsPassivelyOpposedToTreatment, "AreNotSupportiveOfRecoveryGoalsPassivelyOpposedToTreatment didn't match.");
            Assert.AreEqual(hasInsufficientResourcesSupportiveOfGoodMentalFunctioning, careLevel_II_5_PartialHospitalizationScore.HasInsufficientResourcesSupportiveOfGoodMentalFunctioning, "HasInsufficientResourcesSupportiveOfGoodMentalFunctioning didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_II_5_PartialHospitalizationScore.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_II_5_PartialHospitalizationScore.IsMet, "careLevel_II_5_PartialHospitalizationScore didn't match.");
        }

        [TestMethod]
        [DataSource("D6_CareLevel_III_1_ClinicallyManagedScore")]
        public void D6_CareLevel_III_1_ClinicallyManagedScoreTest()
        {
            var emotionalAbuseInPast30Days = TestContext.GetLookup<LikertScale>("EmotionalAbuseInPast30Days");
            var physicalAbuseInPast30Days = TestContext.GetLookup<LikertScale>("PhysicalAbuseInPast30Days");
            var sexualAbuseInPast30Days = TestContext.GetLookup<LikertScale>("SexualAbuseInPast30Days");
            var riskPatientHarmedByOther = TestContext.GetLookup<LikertScale>("RiskPatientHarmedByOther");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var friendsAffectOnRecovery = TestContext.GetLookup<FriendsAffectOnRecovery>("FriendsAffectOnRecovery");
            var dealsWithProblemsFromFriendsThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsFromFriendsThatRiskRelapse>("DealsWithProblemsFromFriendsThatRiskRelapse");
            var closestContactsNeedsAndWillingnessToHelpTreatment = TestContext.GetLookup<NeedsAndWillingnessToHelpTreatment>("ClosestContactsNeedsAndWillingnessToHelpTreatment");
            var spendsFreeTimeWith = TestContext.GetLookup<Companionship>("SpendsFreeTimeWith");
            var numberOfCloseFriends = TestContext.GetUInt32("NumberOfCloseFriends");
            var closestPersonalContactInPast4Months = TestContext.GetLookup<ContactPerson>("ClosestPersonalContactInPast4Months");
            var workOrSchoolAffectOnRecovery = TestContext.GetLookup<WorkOrSchoolAffectOnRecovery>("WorkOrSchoolAffectOnRecovery");
            var feelLikelyToContinueSubstanceUseOrRelapse = TestContext.GetLookup<SubstanceUseOrRelapseLikelihood>("FeelLikelyToContinueSubstanceUseOrRelapse");
            var freeTimeAffectOnRecovery = TestContext.GetLookup<FreeTimeAffectOnRecovery>("FreeTimeAffectOnRecovery");
            var concernsAboutPursuingTreatment = TestContext.GetLookup<ConcernsAboutPursuingTreatment>("ConcernsAboutPursuingTreatment");
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var dealsWithProblemsInFreeTimeThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse>("DealsWithProblemsInFreeTimeThatRiskRelapse");
            var isAbleToLocateAndGetToCommunityResourcesSafely = TestContext.GetBoolean("IsAbleToLocateAndGetToCommunityResourcesSafely");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var howImportantPsychologicalEmotionalCounseling = TestContext.GetLookup<PsychologicalEmotionalCounselingImportanceScale>("HowImportantPsychologicalEmotionalCounseling");
            var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale>("HowEmotionalProblemsImpactRecoveryEfforts");
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = TestContext.GetLookups<PsychiatricDiagnosis>("ActivePsychiatricDiagnosesOtherThanSubstanceAbuse");
            var withdrawalSymptomsAndEmotionalBehavioralProblems = TestContext.GetBoolean("WithdrawalSymptomsAndEmotionalBehavioralProblems");

            var livingInModeratelyHighRiskEnvironmentImpactToRecovery = TestContext.GetBoolean("LivingInModeratelyHighRiskEnvironmentImpactToRecovery");
            var insufficientOrInappropriateSocialContactsOrSocialIsolationImpactsRecovery = TestContext.GetBoolean("InsufficientOrInappropriateSocialContactsOrSocialIsolation");
            var continuedExposureToCurrentSchoolWorkLivingNeeds24HourSupport = TestContext.GetBoolean("ContinuedExposureToCurrentSchoolWorkLivingNeeds24HourSupport");
            var dangerOfVictimizationByAnotherRequires24HourSupervision = TestContext.GetBoolean("DangerOfVictimizationByAnotherRequires24HourSupervision");
            var ableToCopeLimitedPeriodsTimeOutside24HourStructure = TestContext.GetBoolean("AbleToCopeLimitedPeriodsTimeOutside24HourStructure");
            var hasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced = TestContext.GetBoolean("HasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosis");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            var dimension6ScoringStrategy = new Dimension6ScoringStrategy();
            var careLevel_III_1_Score = dimension6ScoringStrategy.CalculateCareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore(             
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

            Assert.AreEqual(livingInModeratelyHighRiskEnvironmentImpactToRecovery, careLevel_III_1_Score.LivingInModeratelyHighRiskEnvironmentImpactToRecovery, "LivingInModeratelyHighRiskEnvironmentImpactToRecovery didn't match.");
            Assert.AreEqual(insufficientOrInappropriateSocialContactsOrSocialIsolationImpactsRecovery, careLevel_III_1_Score.InsufficientOrInappropriateSocialContactsOrSocialIsolationImpactsRecovery, "InsufficientOrInappropriateSocialContactsOrSocialIsolation didn't match.");
            Assert.AreEqual(continuedExposureToCurrentSchoolWorkLivingNeeds24HourSupport, careLevel_III_1_Score.ContinuedExposureToCurrentSchoolWorkLivingNeeds24HourSupport, "ContinuedExposureToCurrentSchoolWorkLivingNeeds24HourSupport didn't match.");
            Assert.AreEqual(dangerOfVictimizationByAnotherRequires24HourSupervision, careLevel_III_1_Score.DangerOfVictimizationByAnotherRequires24HourSupervision, "DangerOfVictimizationByAnotherRequires24HourSupervision didn't match.");
            Assert.AreEqual(ableToCopeLimitedPeriodsTimeOutside24HourStructure, careLevel_III_1_Score.AbleToCopeLimitedPeriodsTimeOutside24HourStructure, "AbleToCopeLimitedPeriodsTimeOutside24HourStructure didn't match.");
            Assert.AreEqual(hasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced, careLevel_III_1_Score.HasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced, "HasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosis didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_III_1_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_III_1_Score.IsMet, "careLevel_III_1_Score didn't match.");
          }

        [TestMethod]
        [DataSource("D6_CareLevel_III_3_ClinicallyManagedMediumIntensityScore")]
        public void D6_CalculateCareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScoreTests()
        {
            var emotionalAbuseInPast30Days = TestContext.GetLookup<LikertScale>("EmotionalAbuseInPast30Days");
            var physicalAbuseInPast30Days = TestContext.GetLookup<LikertScale>("PhysicalAbuseInPast30Days");
            var sexualAbuseInPast30Days = TestContext.GetLookup<LikertScale>("SexualAbuseInPast30Days");
            var riskPatientHarmedByOther = TestContext.GetLookup<LikertScale>("RiskPatientHarmedByOther");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var appearanceOfTroubleConcentratingOrRemembering = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfTroubleConcentratingOrRemembering"));
            var evidenceOfChronicOrganicMentalDisability = TestContext.GetLookup<YesNoNotSure>("EvidenceOfChronicOrganicMentalDisability");
            var currentBehaviorInconsistentWithSelfCare = TestContext.GetLookup<YesNoNotSure>("CurrentBehaviorInconsistentWithSelfCare");
            var friendsAffectOnRecovery = TestContext.GetLookup<FriendsAffectOnRecovery>("FriendsAffectOnRecovery");
            var dealsWithProblemsFromFriendsThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsFromFriendsThatRiskRelapse>("DealsWithProblemsFromFriendsThatRiskRelapse");
            var closestContactsNeedsAndWillingnessToHelpTreatment = TestContext.GetLookup<NeedsAndWillingnessToHelpTreatment>("ClosestContactsNeedsAndWillingnessToHelpTreatment");
            var isAbleToLocateAndGetToCommunityResourcesSafely = TestContext.GetBoolean("IsAbleToLocateAndGetToCommunityResourcesSafely");
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = TestContext.GetLookups<PsychiatricDiagnosis>("ActivePsychiatricDiagnosesOtherThanSubstanceAbuse");
            var currentProblemBehaviorsRequireContinuousInterventions = TestContext.GetLookup<YesNoNotSure>("CurrentProblemBehaviorsRequireContinuousInterventions");
            var symptomsStabalizedDuringTreatmentDay = TestContext.GetBoolean("SymptomsStabalizedDuringTreatmentDay");
            var timingOfPositiveResponseToDetoxificationCare = TestContext.GetLookup<WithdrawalManagementCareResponseTiming>("TimingOfPositiveResponseToDetoxificationCare");
            var freeTimeAffectOnRecovery = TestContext.GetLookup<FreeTimeAffectOnRecovery>("FreeTimeAffectOnRecovery");
            var dealsWithProblemsInFreeTimeThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse>("DealsWithProblemsInFreeTimeThatRiskRelapse");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var howImportantPsychologicalEmotionalCounseling = TestContext.GetLookup<PsychologicalEmotionalCounselingImportanceScale>("HowImportantPsychologicalEmotionalCounseling");
            var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale>("HowEmotionalProblemsImpactRecoveryEfforts");
            var detoxificationRequiredMoreThanHourlyMonitoring = TestContext.GetBoolean("DetoxificationRequiredMoreThanHourlyMonitoring");
            var withdrawalSymptomsAndEmotionalBehavioralProblems = TestContext.GetBoolean("WithdrawalSymptomsAndEmotionalBehavioralProblems");
            var livingInModeratelyHighRiskEnvironmentImpactToRecovery = TestContext.GetBoolean("LivingInModeratelyHighRiskEnvironmentImpactToRecovery");
            var dimension2SeverityNumber = TestContext.GetInt32("Dimension2SeverityNumber");
            var dimension3SeverityNumber = TestContext.GetInt32("Dimension3SeverityNumber");

            var livingEnvironmentModerateHighRiskUnableToMaintainRecovery = TestContext.GetBoolean("LivingEnvironmentModerateHighRiskUnableToMaintainRecovery");
            var cognitiveImpairmentRequires24HourSupervisionToPreventVictimization = TestContext.GetBoolean("CognitiveImpairmentRequires24HourSupervisionToPrevent");
            var socialNetworkOrLivingWithAlcoholDrugUserImpactsRecovery = TestContext.GetBoolean("SocialNetworkOrLivingWithAlcoholDrugUserImpactsRecovery");
            var isUnableToCopeOutside24HourStructureProgram = TestContext.GetBoolean("IsUnableToCopeOutside24HourStructureProgram");
            var hasSeverePersistentMentalIllnessNeedsStructureOfLevel33DualDiagnosisEnhanced = TestContext.GetBoolean("HasSeverePersistentMentalIllnessNeedsStructureOfLevel33Dual");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            var dimension6ScoringStrategy = new Dimension6ScoringStrategy();
            var careLevel_III_3_Score = dimension6ScoringStrategy.CalculateCareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore(
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

            Assert.AreEqual(livingEnvironmentModerateHighRiskUnableToMaintainRecovery, careLevel_III_3_Score.LivingEnvironmentModerateHighRiskUnableToMaintainRecovery, "LivingEnvironmentModerateHighRiskUnableToMaintainRecovery didn't match.");
            Assert.AreEqual(cognitiveImpairmentRequires24HourSupervisionToPreventVictimization, careLevel_III_3_Score.CognitiveImpairmentRequires24HourSupervisionToPreventVictimization, "CognitiveImpairmentRequires24HourSupervisionToPrevent didn't match.");
            Assert.AreEqual(socialNetworkOrLivingWithAlcoholDrugUserImpactsRecovery, careLevel_III_3_Score.SocialNetworkOrLivingWithAlcoholDrugUserImpactsRecovery, "SocialNetworkOrLivingWithAlcoholDrugUserImpactsRecovery didn't match.");
            Assert.AreEqual(isUnableToCopeOutside24HourStructureProgram, careLevel_III_3_Score.IsUnableToCopeOutside24HourStructureProgram, "IsUnableToCopeOutside24HourStructureProgram didn't match.");
            Assert.AreEqual(hasSeverePersistentMentalIllnessNeedsStructureOfLevel33DualDiagnosisEnhanced, careLevel_III_3_Score.HasSeverePersistentMentalIllnessNeedsStructureOfLevel33DualDiagnosisEnhanced, "HasSeverePersistentMentalIllnessNeedsStructureOfLevel33Dual didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_III_3_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_III_3_Score.IsMet, "careLevel_III_3_Score didn't match.");
        }

        [TestMethod]
        [DataSource("D6_CareLevel_III_5_ClinicallyManagedHighIntensityScore")]
        public void D6_CalculateCareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScoreTests()
        {
            var emotionalAbuseInPast30Days = TestContext.GetLookup<LikertScale>("EmotionalAbuseInPast30Days");
            var physicalAbuseInPast30Days = TestContext.GetLookup<LikertScale>("PhysicalAbuseInPast30Days");
            var sexualAbuseInPast30Days = TestContext.GetLookup<LikertScale>("SexualAbuseInPast30Days");
            var riskPatientHarmedByOther = TestContext.GetLookup<LikertScale>("RiskPatientHarmedByOther");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var friendsAffectOnRecovery = TestContext.GetLookup<FriendsAffectOnRecovery>("FriendsAffectOnRecovery");
            var dealsWithProblemsFromFriendsThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsFromFriendsThatRiskRelapse>("DealsWithProblemsFromFriendsThatRiskRelapse");
            var closestContactsNeedsAndWillingnessToHelpTreatment = TestContext.GetLookup<NeedsAndWillingnessToHelpTreatment>("ClosestContactsNeedsAndWillingnessToHelpTreatment");
            var spendsFreeTimeWith = TestContext.GetLookup<Companionship>("SpendsFreeTimeWith");
            var numberOfCloseFriends = TestContext.GetUInt32("NumberOfCloseFriends");
            var closestPersonalContactInPast4Months = TestContext.GetLookup<ContactPerson>("ClosestPersonalContactInPast4Months");
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = TestContext.GetLookups<PsychiatricDiagnosis>("ActivePsychiatricDiagnosesOtherThanSubstanceAbuse");
            var currentProblemBehaviorsRequireContinuousInterventions = TestContext.GetLookup<YesNoNotSure>("CurrentProblemBehaviorsRequireContinuousInterventions");
            var symptomsStabalizedDuringTreatmentDay = TestContext.GetBoolean("SymptomsStabalizedDuringTreatmentDay");
            var timingOfPositiveResponseToDetoxificationCare = TestContext.GetLookup<WithdrawalManagementCareResponseTiming>("TimingOfPositiveResponseToDetoxificationCare");
            var dealsWithProblemsInFreeTimeThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse>("DealsWithProblemsInFreeTimeThatRiskRelapse");
            var numberOfTimesArrestedForShopliftingVandalism = TestContext.GetUInt32("NumberOfTimesArrestedForShopliftingVandalism");
            var numberOfTimesArrestedForParoleProbationViolation = TestContext.GetUInt32("NumberOfTimesArrestedForParoleProbationViolation");
            var numberOfTimesArrestedForDrugCharges = TestContext.GetUInt32("NumberOfTimesArrestedForDrugCharges");
            var numberOfTimesArrestedForForgery = TestContext.GetUInt32("NumberOfTimesArrestedForForgery");
            var numberOfTimesArrestedForWeaponsOffense = TestContext.GetUInt32("NumberOfTimesArrestedForWeaponsOffense");
            var numberOfTimesArrestedForBurglaryLarceny = TestContext.GetUInt32("NumberOfTimesArrestedForBurglaryLarceny");
            var numberOfTimesArrestedForRobbery = TestContext.GetUInt32("NumberOfTimesArrestedForRobbery");
            var numberOfTimesArrestedForAssault = TestContext.GetUInt32("NumberOfTimesArrestedForAssault");
            var numberOfTimesArrestedForArson = TestContext.GetUInt32("NumberOfTimesArrestedForArson");
            var numberOfTimesArrestedForRape = TestContext.GetUInt32("NumberOfTimesArrestedForRape");
            var numberOfTimesArrestedForHomicide = TestContext.GetUInt32("NumberOfTimesArrestedForHomicide");
            var numberOfTimesArrestedForProstitution = TestContext.GetUInt32("NumberOfTimesArrestedForProstitution");
            var numberOfTimesArrestedForContemptOfCourt = TestContext.GetUInt32("NumberOfTimesArrestedForContemptOfCourt");
            var numberOfTimesArrestedForOtherArrest = TestContext.GetUInt32("NumberOfTimesArrestedForOtherArrest");
            var isCurrentlyAwaitingChargesTrialSentence = TestContext.GetBoolean("IsCurrentlyAwaitingChargesTrialSentence");
            var numberOfDaysCommitingCrimesForProfitInPast30Days = TestContext.GetUInt32("NumberOfDaysCommitingCrimesForProfitInPast30Days");
            var detoxificationRequiredMoreThanHourlyMonitoring = TestContext.GetBoolean("DetoxificationRequiredMoreThanHourlyMonitoring");
            var dimension2SeverityNumber = TestContext.GetInt32("Dimension2SeverityNumber");
            var dimension3SeverityNumber = TestContext.GetInt32("Dimension3SeverityNumber");
            var anxietyAttackMoreThanOnceInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackMoreThanOnceInLast24Hours");
            var significantPeriodFidgetingInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodFidgetingInLast24Hours");
            var significantPeriodNegativeThoughtsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodNegativeThoughtsInLast24Hours");
            var significantPeriodExcessiveBehaviorInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodExcessiveBehaviorInLast24Hours");
            var significantPeriodParanoiaInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodParanoiaInLast24Hours");
            var significantPeriodFlashbacksInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodFlashbacksInLast24Hours");
            var significantPeriodCurbingViolentBehaviorInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodCurbingViolentBehaviorInLast24Hours");
            var significantPeriodViolentUrgesInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodViolentUrgesInLast24Hours");
            var significantPeriodSuicidalThoughtsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodSuicidalThoughtsInLast24Hours");
            var significantPeriodThoughtsOfSelfInjuryInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodThoughtsOfSelfInjuryInLast24Hours");
            var significantPeriodAttemptedSuicideInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodAttemptedSuicideInLast24Hours");
            var hasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced = TestContext.GetBoolean("HasSevereMentalIllnessNeedsStructureOfLevel31Dual");

            var livingEnvironmentModerateHighRiskAbuseNoRecoveryAtLowerLevelCare = TestContext.GetBoolean("LivingEnvironmentModerateHighRiskAbuseNoRecoveryAtLowerLevel");
            var socialNetworkOrLivingWithAlcoholDrugUserPreventsRecoveryAtLowerLevelOfCare = TestContext.GetBoolean("SocialNetworkOrLivingWithAlcoholDrugUserPreventsRecovery");
            var unableToCopeOutside24HourCareNeedsStaffMonitoring = TestContext.GetBoolean("UnableToCopeOutside24HourCareNeedsStaffMonitoring");
            var livingEnvironmentHasCriminalBehaviorAndOtherAntiSocialValues = TestContext.GetBoolean("LivingEnvironmentHasCriminalBehaviorAndOtherAntiSocialValues");
            var hasSeverePersistentMentalIllnessNeedsStructureOfLevel35DualDiagnosisEnhanced = TestContext.GetBoolean("HasSeverePersistentMentalIllnessNeedsStructureOfLevel35Dual");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");
            
            var dimension6ScoringStrategy = new Dimension6ScoringStrategy();
            var careLevel_III_5_Score = dimension6ScoringStrategy.CalculateCareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore(
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
                       
            Assert.AreEqual(livingEnvironmentModerateHighRiskAbuseNoRecoveryAtLowerLevelCare, careLevel_III_5_Score.LivingEnvironmentModerateHighRiskAbuseNoRecoveryAtLowerLevelCare, "LivingEnvironmentModerateHighRiskAbuseNoRecoveryAtLowerLevel didn't match.");
            Assert.AreEqual(socialNetworkOrLivingWithAlcoholDrugUserPreventsRecoveryAtLowerLevelOfCare, careLevel_III_5_Score.SocialNetworkOrLivingWithAlcoholDrugUserPreventsRecoveryAtLowerLevelOfCare, "SocialNetworkOrLivingWithAlcoholDrugUserPreventsRecovery didn't match.");
            Assert.AreEqual(unableToCopeOutside24HourCareNeedsStaffMonitoring, careLevel_III_5_Score.UnableToCopeOutside24HourCareNeedsStaffMonitoring, "UnableToCopeOutside24HourCareNeedsStaffMonitoring didn't match.");
            Assert.AreEqual(livingEnvironmentHasCriminalBehaviorAndOtherAntiSocialValues, careLevel_III_5_Score.LivingEnvironmentHasCriminalBehaviorAndOtherAntiSocialValues, "LivingEnvironmentHasCriminalBehaviorAndOtherAntiSocialValues didn't match.");
            Assert.AreEqual(hasSeverePersistentMentalIllnessNeedsStructureOfLevel35DualDiagnosisEnhanced, careLevel_III_5_Score.HasSeverePersistentMentalIllnessNeedsStructureOfLevel35DualDiagnosisEnhanced, "HasSeverePersistentMentalIllnessNeedsStructureOfLevel35Dual didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_III_5_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_III_5_Score.IsMet, "CareLevel_III_5_Score didn't match.");
        }

        [TestMethod]
        [DataSource("D6_CareLevel_III_7_MedicallyMonitoredIntensiveScore")]
        public void D6_CalculateCareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScoreTests()
        {
            var emotionalAbuseInPast30Days = TestContext.GetLookup<LikertScale>("EmotionalAbuseInPast30Days");
            var physicalAbuseInPast30Days = TestContext.GetLookup<LikertScale>("PhysicalAbuseInPast30Days");
            var sexualAbuseInPast30Days = TestContext.GetLookup<LikertScale>("SexualAbuseInPast30Days");
            var riskPatientHarmedByOther = TestContext.GetLookup<LikertScale>("RiskPatientHarmedByOther");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var detoxificationRequiredMoreThanHourlyMonitoring = TestContext.GetBoolean("DetoxificationRequiredMoreThanHourlyMonitoring");
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = TestContext.GetLookups<PsychiatricDiagnosis>("ActivePsychiatricDiagnosesOtherThanSubstanceAbuse");
            var currentProblemBehaviorsRequireContinuousInterventions = TestContext.GetLookup<YesNoNotSure>("CurrentProblemBehaviorsRequireContinuousInterventions");
            var timingOfPositiveResponseToDetoxificationCare = TestContext.GetLookup<WithdrawalManagementCareResponseTiming>("TimingOfPositiveResponseToDetoxificationCare");
            var anxietyAttackMoreThanOnceInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackMoreThanOnceInLast24Hours");
            var significantPeriodFidgetingInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodFidgetingInLast24Hours");
            var significantPeriodNegativeThoughtsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodNegativeThoughtsInLast24Hours");
            var significantPeriodExcessiveBehaviorInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodExcessiveBehaviorInLast24Hours");
            var significantPeriodParanoiaInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodParanoiaInLast24Hours");
            var significantPeriodFlashbacksInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodFlashbacksInLast24Hours");
            var significantPeriodCurbingViolentBehaviorInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodCurbingViolentBehaviorInLast24Hours");
            var significantPeriodViolentUrgesInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodViolentUrgesInLast24Hours");
            var significantPeriodSuicidalThoughtsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodSuicidalThoughtsInLast24Hours");
            var significantPeriodThoughtsOfSelfInjuryInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodThoughtsOfSelfInjuryInLast24Hours");
            var significantPeriodAttemptedSuicideInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodAttemptedSuicideInLast24Hours");
            var dimension2SeverityNumber = TestContext.GetInt32("Dimension2SeverityNumber");
            var dimension3SeverityNumber = TestContext.GetInt32("Dimension3SeverityNumber");
            var socialNetworkOrLivingWithAlcoholDrugUserImpactsRecovery = TestContext.GetBoolean("SocialNetworkOrLivingWithAlcoholDrugUserImpactsRecovery");
            var hasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced = TestContext.GetBoolean("HasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosis");

            var requiresContinuousMedicalMonitoringAddressPsychSubstance = TestContext.GetBoolean("RequiresContinuousMedicalMonitoringAddressPsychSubstance");
            var areNotSupportiveOfRecoveryGoalsActivelySabotagingTreatment = TestContext.GetBoolean("AreNotSupportiveOfRecoveryGoalsActivelySabotagingTreatment");
            var unableToCopeOutside24HourCareNeedsStaffMonitoring = TestContext.GetBoolean("UnableToCopeOutside24HourCareNeedsStaffMonitoring");
            var hasSeverePersistentMentalIllnessNeedsStructureOfLevel37DualDiagnosisEnhanced = TestContext.GetBoolean("HasSeverePersistentMentalIllnessNeedsStructureOfLevel37Dual");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            var dimension6ScoringStrategy = new Dimension6ScoringStrategy();
            var careLevel_III_7_Score = dimension6ScoringStrategy.CalculateCareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScore(
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

            Assert.AreEqual(requiresContinuousMedicalMonitoringAddressPsychSubstance, careLevel_III_7_Score.RequiresContinuousMedicalMonitoringAddressPsychSubstance, "RequiresContinuousMedicalMonitoringAddressPsychSubstance didn't match.");
            Assert.AreEqual(areNotSupportiveOfRecoveryGoalsActivelySabotagingTreatment, careLevel_III_7_Score.AreNotSupportiveOfRecoveryGoalsActivelySabotagingTreatment, "AreNotSupportiveOfRecoveryGoalsActivelySabotagingTreatment didn't match.");
            Assert.AreEqual(unableToCopeOutside24HourCareNeedsStaffMonitoring, careLevel_III_7_Score.UnableToCopeOutside24HourCareNeedsStaffMonitoring, "UnableToCopeOutside24HourCareNeedsStaffMonitoring didn't match.");
            Assert.AreEqual(hasSeverePersistentMentalIllnessNeedsStructureOfLevel37DualDiagnosisEnhanced, careLevel_III_7_Score.HasSeverePersistentMentalIllnessNeedsStructureOfLevel37DualDiagnosisEnhanced, "HasSeverePersistentMentalIllnessNeedsStructureOfLevel37Dual didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_III_7_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_III_7_Score.IsMet, "CareLevel_III_7_Score didn't match.");
        }

        #endregion
    }
}
