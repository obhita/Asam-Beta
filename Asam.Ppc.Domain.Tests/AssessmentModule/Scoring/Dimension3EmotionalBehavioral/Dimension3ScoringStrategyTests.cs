using Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups;
using Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory;
using Asam.Ppc.Domain.AssessmentModule.Legal;
using Asam.Ppc.Domain.AssessmentModule.Medical;
using Asam.Ppc.Domain.AssessmentModule.Psychological;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.Scoring.ScoringModule.Dimension3EmotionalBehavioral;
using Asam.Ppc.Domain.Tests.Extensions;
using Asam.Ppc.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asam.Ppc.Domain.Tests.AssessmentModule.Scoring.Dimension3EmotionalBehavioral
{
    [TestClass]
    public class Dimension3ScoringStrategyTests
    {
        #region Public Properties

        public TestContext TestContext { get; set; }

        #endregion
        
        #region Public Methods
        
        [TestMethod]
        [DataSource("D3_ImmediateMajorAndOtherDepressionDisorder")]
        public void D3_CalculateImmediateMajorAndOtherDepressionDisorderTests()
        {
            var significantPeriodOfSeriousDepressionInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodOfSeriousDepressionInLast24Hours");
            var inabilityToFeelPleasureFromActivitiesInLast24Hours = TestContext.GetLookup<LikertScale>("InabilityToFeelPleasureFromActivitiesInLast24Hours");
            var poorAppetiteOrOvereatingInLast24Hours = TestContext.GetLookup<LikertScale>("PoorAppetiteOrOvereatingInLast24Hours");
            var feelLikeFailureInLast24Hours = TestContext.GetLookup<LikertScale>("FeelLikeFailureInLast24Hours");
            var movingSpeakingSlowlyInLast24Hours = TestContext.GetLookup<LikertScale>("MovingSpeakingSlowlyInLast24Hours");
            var significantPeriodFidgetingInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodFidgetingInLast24Hours");
            var significantPeriodSleepDisorderInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodSleepDisorderInLast24Hours");
            var significantPeriodLethargyInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodLethargyInLast24Hours");
            var significantPeriodImpairedThoughtInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodImpairedThoughtInLast24Hours");
            var significantPeriodSuicidalThoughtsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodSuicidalThoughtsInLast24Hours");
            
            var dailyModeratelySymptomsCount = (int) TestContext.GetUInt32("DailyModeratelySymptomsCount");
            var hasImmediateMajorDepressionDisorder = TestContext.GetBoolean("HasImmediateMajorDepressionDisorder");
            var hasImmediateOtherDepressionDisorder = TestContext.GetBoolean("HasImmediateOtherDepressionDisorder");

            int dailyModeratelySymptomsCountScore;
            var dim3ScoringStrategy = new Dimension3ScoringStrategy ( );
            var hasImmediateMajorDepressionDisorderIndicator = dim3ScoringStrategy.CalculateHasImmediateMajorDepressionDisorder (
                    out dailyModeratelySymptomsCountScore,
                    significantPeriodOfSeriousDepressionInLast24Hours,
                    inabilityToFeelPleasureFromActivitiesInLast24Hours,
                    poorAppetiteOrOvereatingInLast24Hours,
                    feelLikeFailureInLast24Hours,
                    movingSpeakingSlowlyInLast24Hours,
                    significantPeriodFidgetingInLast24Hours,
                    significantPeriodSleepDisorderInLast24Hours,
                    significantPeriodLethargyInLast24Hours,
                    significantPeriodImpairedThoughtInLast24Hours,
                    significantPeriodSuicidalThoughtsInLast24Hours );


            var hasImmediateOtherDepressionDisorderIndicator = dim3ScoringStrategy.CalculateHasImmediateOtherDepressionDisorder (
                    dailyModeratelySymptomsCount,
                    significantPeriodOfSeriousDepressionInLast24Hours,
                    inabilityToFeelPleasureFromActivitiesInLast24Hours );

            Assert.AreEqual ( dailyModeratelySymptomsCount,
                              dailyModeratelySymptomsCountScore,
                              "Daily moderate symptoms count didn't match." );

            Assert.AreEqual ( hasImmediateMajorDepressionDisorder,
                              hasImmediateMajorDepressionDisorderIndicator,
                              "HasImmediateMajorDepressionDisorder didn't match." );

            Assert.AreEqual ( hasImmediateOtherDepressionDisorder,
                              hasImmediateOtherDepressionDisorderIndicator,
                              "HasImmediateOtherDepressionDisorder didn't match." );
        }

        [TestMethod]
        [DataSource("D3_CurrentMajorAndOtherDepressionDisorder")]
        public void D3_CalculateCurrentMajorAndOtherDepressionDisorderTests()
        {
            var significantPeriodOfSeriousDepressionInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodOfSeriousDepressionInLastMonth");
            var inabilityToFeelPleasureFromActivitiesInLastMonth = TestContext.GetLookup<LikertScale>("InabilityToFeelPleasureFromActivitiesInLastMonth");
            var poorAppetiteOrOvereatingInLastMonth = TestContext.GetLookup<LikertScale>("PoorAppetiteOrOvereatingInLastMonth");
            var feelLikeFailureInLastMonth = TestContext.GetLookup<LikertScale>("FeelLikeFailureInLastMonth");
            var movingSpeakingSlowlyInLastMonth = TestContext.GetLookup<LikertScale>("MovingSpeakingSlowlyInLastMonth");
            var significantPeriodFidgetingInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodFidgetingInLastMonth");
            var significantPeriodSleepDisorderInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodSleepDisorderInLastMonth");
            var significantPeriodLethargyInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodLethargyInLastMonth");
            var significantPeriodImpairedThoughtInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodImpairedThoughtInLastMonth");
            var significantPeriodSuicidalThoughtsInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodSuicidalThoughtsInLastMonth");


            var monthlyModerateSymptomsCount = (int)TestContext.GetUInt32("MonthlyModerateSymptomsCount");
            var hasCurrentMajorDepressionDisorder = TestContext.GetBoolean("HasCurrentMajorDepressionDisorder");
            var hasCurrentOtherDepressionDisorder = TestContext.GetBoolean("HasCurrentOtherDepressionDisorder");

            int monthlyModerateSymptomsCountScore;
            var dim3ScoringStrategy = new Dimension3ScoringStrategy();
            var hasCurrentMajorDepressionDisorderIndicator = dim3ScoringStrategy.CalculateHasCurrentMajorDepressionDisorder (
                    out monthlyModerateSymptomsCountScore,
                    significantPeriodOfSeriousDepressionInLastMonth,
                    inabilityToFeelPleasureFromActivitiesInLastMonth,
                    poorAppetiteOrOvereatingInLastMonth,
                    feelLikeFailureInLastMonth,
                    movingSpeakingSlowlyInLastMonth,
                    significantPeriodFidgetingInLastMonth,
                    significantPeriodSleepDisorderInLastMonth,
                    significantPeriodLethargyInLastMonth,
                    significantPeriodImpairedThoughtInLastMonth,
                    significantPeriodSuicidalThoughtsInLastMonth );

            var hasCurrentOtherDepressionDisorderIndicator = dim3ScoringStrategy.CalculateHasCurrentOtherMajorDepressionDisorder (
                    monthlyModerateSymptomsCountScore,
                    significantPeriodOfSeriousDepressionInLastMonth,
                    inabilityToFeelPleasureFromActivitiesInLastMonth );

            Assert.AreEqual(monthlyModerateSymptomsCount,
                              monthlyModerateSymptomsCountScore,
                              "Monthly moderate symptoms count didn't match.");

            Assert.AreEqual(hasCurrentMajorDepressionDisorder,
                              hasCurrentMajorDepressionDisorderIndicator,
                              "HasCurrentMajorDepressionDisorder didn't match.");

            Assert.AreEqual(hasCurrentOtherDepressionDisorder,
                              hasCurrentOtherDepressionDisorderIndicator,
                              "HasCurrentOtherDepressionDisorder didn't match.");
        }
        
        [TestMethod]
        [DataSource("D3_LifetimeMajorAndOtherDepressionDisorder")]
        public void D3_CalculateLifetimeMajorAndOtherDepressionDisorderTests()
        {
            var significantPeriodOfSeriousDepressionInLifetime = TestContext.GetLookup<LikertScale> ( "SignificantPeriodOfSeriousDepressionInLifetime" );
            var inabilityToFeelPleasureFromActivitiesInLifetime = TestContext.GetLookup<LikertScale>("InabilityToFeelPleasureFromActivitiesInLifetime");
            var poorAppetiteOrOvereatingInLifetime = TestContext.GetLookup<LikertScale>("PoorAppetiteOrOvereatingInLifetime");
            var feelLikeFailureInLifetime = TestContext.GetLookup<LikertScale>("FeelLikeFailureInLifetime");
            var movingSpeakingSlowlyInLifetime = TestContext.GetLookup<LikertScale>("MovingSpeakingSlowlyInLifetime");
            var significantPeriodFidgetingInLifetime = TestContext.GetLookup<LikertScale>("SignificantPeriodFidgetingInLifetime");
            var significantPeriodSleepDisorderInLifetime = TestContext.GetLookup<LikertScale>("SignificantPeriodSleepDisorderInLifetime");
            var significantPeriodLethargyInLifetime = TestContext.GetLookup<LikertScale>("SignificantPeriodLethargyInLifetime");
            var significantPeriodImpairedThoughtInLifetime = TestContext.GetLookup<LikertScale>("SignificantPeriodImpairedThoughtInLifetime");
            var significantPeriodSuicidalThoughtsInLifetime = TestContext.GetLookup<LikertScale>("SignificantPeriodSuicidalThoughtsInLifetime");


            var lifetimeModerateSymptomsCount = (int)TestContext.GetUInt32("LifetimeModerateSymptomsCount");
            var hasLifetimeMajorDepressionDisorder = TestContext.GetBoolean("HasLifetimeMajorDepressionDisorder");
            var hasLifetimeOtherDepressionDisorder = TestContext.GetBoolean("HasLifetimeOtherDepressionDisorder");

            int lifetimeModerateSymptomsCountScore;
            var dim3ScoringStrategy = new Dimension3ScoringStrategy();
            var hasLifetimeMajorDepressionDisorderIndicator = dim3ScoringStrategy.CalculateHasLifetimeMajorDepressionDisorder (
                    out lifetimeModerateSymptomsCountScore,
                    significantPeriodOfSeriousDepressionInLifetime,
                    inabilityToFeelPleasureFromActivitiesInLifetime,
                    poorAppetiteOrOvereatingInLifetime,
                    feelLikeFailureInLifetime,
                    movingSpeakingSlowlyInLifetime,
                    significantPeriodFidgetingInLifetime,
                    significantPeriodSleepDisorderInLifetime,
                    significantPeriodLethargyInLifetime,
                    significantPeriodImpairedThoughtInLifetime,
                    significantPeriodSuicidalThoughtsInLifetime );

            var hasLifetimeOtherDepressionDisorderIndicator = dim3ScoringStrategy.CalculateHasLifetimeOtherDepressionDisorder(
                    lifetimeModerateSymptomsCountScore,
                    significantPeriodOfSeriousDepressionInLifetime,
                    inabilityToFeelPleasureFromActivitiesInLifetime);

            Assert.AreEqual(lifetimeModerateSymptomsCount,
                              lifetimeModerateSymptomsCountScore,
                              "Lifetime moderate symptoms count didn't match.");

            Assert.AreEqual(hasLifetimeMajorDepressionDisorder,
                              hasLifetimeMajorDepressionDisorderIndicator,
                              "HasLifetimeMajorDepressionDisorder didn't match.");

            Assert.AreEqual(hasLifetimeOtherDepressionDisorder,
                              hasLifetimeOtherDepressionDisorderIndicator,
                              "HasLifetimeOtherDepressionDisorder didn't match.");
        }
        
        [TestMethod]
        [DataSource("D3_HasPanicSyndrome")]
        public void D3_CalculateHasPanicSyndromeTests()
        {
            var anxietyAttackPalpitationsInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyAttackPalpitationsInLastMonth");
            var anxietyAttackChestPainsInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyAttackChestPainsInLastMonth");
            var anxietyAttackShortnessBreathInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyAttackShortnessBreathInLastMonth");
            var anxietyAttackChokingInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyAttackChokingInLastMonth");
            var anxietyAttackSweatyInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyAttackSweatyInLastMonth");
            var anxietyAttackTremblingInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyAttackTremblingInLastMonth");
            var anxietyAttackNauseaDiarrheaInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyAttackNauseaDiarrheaInLastMonth");
            var anxietyAttackDizzinessFaintnessInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyAttackDizzinessFaintnessInLastMonth");
            var anxietyAttackDistortedRealityInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyAttackDistortedRealityInLastMonth");
            var anxietyAttackNumbnessInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyAttackNumbnessInLastMonth");
            var anxietyAttackChillsHotFlashesInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyAttackChillsHotFlashesInLastMonth");
            var anxietyAttackLoseControlInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyAttackLoseControlInLastMonth");
            var anxietyAttackDyingSensationInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyAttackDyingSensationInLastMonth");
            var anxietyAttackInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyAttackInLastMonth");
            var anxietyAttackMoreThanOnceInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyAttackMoreThanOnceInLastMonth");
            var anxietyAttackRandomInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyAttackRandomInLastMonth");
            var worriedAboutAnxietyAttackInLastMonth = TestContext.GetLookup<LikertScale>("worriedAboutAnxietyAttackInLastMonth");


            var monthlyModerateSymptomsCount = TestContext.GetInt32 ( "MonthlyModerateSymptomsCount" );
            var monthlySlightSymptomsCount = TestContext.GetInt32 ( "MonthlySlightSymptomsCount" );
            var hasPanicSyndrome = TestContext.GetBoolean("HasPanicSyndrome");

            var dim3ScoringStrategy = new Dimension3ScoringStrategy();
            var hasPanicSyndromeIndicator = dim3ScoringStrategy.CalculateHasPanicSyndrome (
                anxietyAttackPalpitationsInLastMonth,
                anxietyAttackChestPainsInLastMonth,
                anxietyAttackShortnessBreathInLastMonth,
                anxietyAttackChokingInLastMonth,
                anxietyAttackSweatyInLastMonth,
                anxietyAttackTremblingInLastMonth,
                anxietyAttackNauseaDiarrheaInLastMonth,
                anxietyAttackDizzinessFaintnessInLastMonth,
                anxietyAttackDistortedRealityInLastMonth,
                anxietyAttackNumbnessInLastMonth,
                anxietyAttackChillsHotFlashesInLastMonth,
                anxietyAttackLoseControlInLastMonth,
                anxietyAttackDyingSensationInLastMonth,
                anxietyAttackInLastMonth,
                anxietyAttackMoreThanOnceInLastMonth,
                anxietyAttackRandomInLastMonth,
                worriedAboutAnxietyAttackInLastMonth );

            Assert.AreEqual ( hasPanicSyndrome,
                              hasPanicSyndromeIndicator,
                              "HasPanicSyndrome didn't match." );
        }

        [TestMethod]
        [DataSource("D3_HasOtherAnxietySyndrome")]
        public void D3_CalculateHasOtherAnxietySyndromeTests()
        {
            var significantPeriodFidgetingInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodFidgetingInLastMonth");
            var significantPeriodSleepDisorderInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodSleepDisorderInLastMonth");
            var significantPeriodLethargyInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodLethargyInLastMonth");
            var significantPeriodMuscleTensionInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodMuscleTensionInLastMonth");
            var significantPeriodImpairedThoughtInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodImpairedThoughtInLastMonth");
            var significantPeriodIrritabilityInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodIrritabilityInLastMonth");
            var anxietyTensionWorryInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyTensionWorryInLastMonth");

            var hasOtherAnxietySyndrome = TestContext.GetBoolean("HasOtherAnxietySyndrome");

            var dim3ScoringStrategy = new Dimension3ScoringStrategy();
            var hasOtherAnxietySyndromeIndicator = dim3ScoringStrategy.CalculateHasOtherAnxietySyndrome (
                significantPeriodFidgetingInLastMonth,
                significantPeriodSleepDisorderInLastMonth,
                significantPeriodLethargyInLastMonth,
                significantPeriodMuscleTensionInLastMonth,
                significantPeriodImpairedThoughtInLastMonth,
                significantPeriodIrritabilityInLastMonth,
                anxietyTensionWorryInLastMonth );

            Assert.AreEqual ( hasOtherAnxietySyndrome,
                              hasOtherAnxietySyndromeIndicator,
                              "HasOtherAnxietySyndrome didn't match." );
        }
        
        [TestMethod]
        [DataSource("D3_HistoryOfHarmRiskToSelfOthers")]
        public void D3_CalculateHistoryOfHarmRiskToSelfOthersTests()
        {
            var significantPeriodCurbingViolentBehaviorInLifetime = TestContext.GetLookup<LikertScale> ( "SignificantPeriodCurbingViolentBehaviorInLifetime" );
            var significantPeriodAttemptedSuicideInLifetime = TestContext.GetLookup<LikertScale> ( "SignificantPeriodAttemptedSuicideInLifetime" );
            var numberOfTimesArrestedForAssault = TestContext.GetUInt32 ( "NumberOfTimesArrestedForAssault" );
            var numberOfTimesArrestedForArson = TestContext.GetUInt32 ( "NumberOfTimesArrestedForArson" );
            var numberOfTimesArrestedForRape = TestContext.GetUInt32 ( "NumberOfTimesArrestedForRape" );
            var numberOfTimesArrestedForHomicide = TestContext.GetUInt32 ( "NumberOfTimesArrestedForHomicide" );

            var historyOfHarmRiskToSelfOthers = TestContext.GetUInt32("HistoryOfHarmRiskToSelfOthers");

            var dim3ScoringStrategy = new Dimension3ScoringStrategy();
            var historyOfHarmRiskToSelfOthersIndicator = dim3ScoringStrategy.CalculateHistoryOfHarmRiskToSelfOthers (
                significantPeriodCurbingViolentBehaviorInLifetime,
                significantPeriodAttemptedSuicideInLifetime,
                numberOfTimesArrestedForAssault,
                numberOfTimesArrestedForArson,
                numberOfTimesArrestedForRape,
                numberOfTimesArrestedForHomicide );

            Assert.AreEqual(historyOfHarmRiskToSelfOthers,
                              historyOfHarmRiskToSelfOthersIndicator,
                              "HistoryOfHarmRiskToSelfOthers didn't match.");
        }

        [TestMethod]
        [DataSource("D3_CurrentHarmRiskToSelfOthers")]
        public void D3_CalculateCurrentHarmRiskToSelfOthersTests()
        {
            var hasSuicidalThoughts = new ScaleOf0To8 ( TestContext.GetUInt32 ( "HasSuicidalThoughts" ) );
            var demonstratingDangerToSelfOrOthers = new ScaleOf0To8 ( TestContext.GetUInt32 ( "DemonstratingDangerToSelfOrOthers" ) );
            var indicatingRiskOfHarmToOthers = new ScaleOf0To8 ( TestContext.GetUInt32 ( "IndicatingRiskOfHarmToOthers" ) );
            var indicatingRiskOfHarmToSelfOrVictimizationByOthers = new ScaleOf0To8 ( TestContext.GetUInt32 ( "IndicatingRiskOfHarmToSelfOrVictimizationByOthers" ) );
            var likelihoodOfRecurrenceOfPsychiatricDecompensation = new ScaleOf0To8 ( TestContext.GetUInt32 ( "LikelihoodOfRecurrenceOfPsychiatricDecompensation" ) );
            var hasRecentlyNeglectedOrAbusedFamilyMembers = TestContext.GetLookup<LikertScale> ( "HasRecentlyNeglectedOrAbusedFamilyMembers" );
            var familyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II = TestContext.GetLookup<LikertScale>("FamilyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel");
            
            var currentHarmRiskToSelfOthers = TestContext.GetUInt32("CurrentHarmRiskToSelfOthers");

            var dim3ScoringStrategy = new Dimension3ScoringStrategy();
            var currentHarmRiskToSelfOthersIndicator = dim3ScoringStrategy.CalculateCurrentHarmRiskToSelfOthers (
                hasSuicidalThoughts,
                demonstratingDangerToSelfOrOthers,
                indicatingRiskOfHarmToOthers,
                indicatingRiskOfHarmToSelfOrVictimizationByOthers,
                likelihoodOfRecurrenceOfPsychiatricDecompensation,
                hasRecentlyNeglectedOrAbusedFamilyMembers,
                familyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II );

            Assert.AreEqual(currentHarmRiskToSelfOthers,
                              currentHarmRiskToSelfOthersIndicator,
                              "CurrentHarmRiskToSelfOthers didn't match.");
        }

        [TestMethod]
        [DataSource("D3_HistoryOfWithdrawalRelatedSymptoms")]
        public void D3_CalculateHistoryOfWithdrawalRelatedSymptomsTests()
        {
            var anxietyAttackWithin24HoursRelatedToSubstanceUse = TestContext.GetLookup<RelationToSubstanceUse> ( "AnxietyAttackWithin24HoursRelatedToSubstanceUse" );
            var significantPeriodHallucinationsRelatedToSubstanceUse = TestContext.GetLookup<RelationToSubstanceUse> ( "SignificantPeriodHallucinationsRelatedToSubstanceUse" );
            var significantPeriodImpairedThoughtRelatedToSubstanceUse = TestContext.GetLookup<RelationToSubstanceUse> ( "SignificantPeriodImpairedThoughtRelatedToSubstanceUse" );
            var significantPeriodCurbingViolentBehaviorRelatedToSubstanceUse = TestContext.GetLookup<RelationToSubstanceUse> ( "SignificantPeriodCurbingViolentBehaviorRelatedToSubstanceUse" );
            var significantPeriodSuicidalThoughtsRelatedToSubstanceUse = TestContext.GetLookup<RelationToSubstanceUse> ( "SignificantPeriodSuicidalThoughtsRelatedToSubstanceUse" );
            var significantPeriodAttemptedSuicideRelatedToSubstanceUse = TestContext.GetLookup<RelationToSubstanceUse> ( "SignificantPeriodAttemptedSuicideRelatedToSubstanceUse" );

            var historyOfWithdrawalRelatedSymptoms = TestContext.GetBoolean("HistoryOfWithdrawalRelatedSymptoms");

            var dim3ScoringStrategy = new Dimension3ScoringStrategy();
            var historyOfWithdrawalRelatedSymptomsIndicator = dim3ScoringStrategy.CalculateHistoryOfWithdrawalRelatedSymptoms (
                    anxietyAttackWithin24HoursRelatedToSubstanceUse,
                    significantPeriodHallucinationsRelatedToSubstanceUse,
                    significantPeriodImpairedThoughtRelatedToSubstanceUse,
                    significantPeriodCurbingViolentBehaviorRelatedToSubstanceUse,
                    significantPeriodSuicidalThoughtsRelatedToSubstanceUse,
                    significantPeriodAttemptedSuicideRelatedToSubstanceUse );

            Assert.AreEqual(historyOfWithdrawalRelatedSymptoms,
                              historyOfWithdrawalRelatedSymptomsIndicator,
                              "HistoryOfWithdrawalRelatedSymptoms didn't match.");
        }
        
        [TestMethod]
        [DataSource("D3_CareLevel_0_5_EarlyInterventionScore")]
        public void D3_CalculateCareLevel_0_5_EarlyInterventionScoreTests()
         {
             var withdrawalSymptomsAndEmotionalBehavioralProblems = TestContext.GetBoolean ( "WithdrawalSymptomsAndEmotionalBehavioralProblems" );
             var doesPatientCarryPsychiatricDiagnosis = TestContext.GetLookup<PatientCarriesPsychiatricDiagnosis> ( "DoesPatientCarryPsychiatricDiagnosis" );
             var activePsychiatricDiagnosesOtherThanSubstanceAbuse = TestContext.GetLookups<PsychiatricDiagnosis> ( "ActivePsychiatricDiagnosesOtherThanSubstanceAbuse" );
             var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8 ( TestContext.GetUInt32 ( "PatientNeedForPsychiatricPsychologicalTreatmentRating" ));
             var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale> ("HowEmotionalProblemsImpactRecoveryEfforts" );
             var psychiatricEvaluationAndServicesAccessibleToPatient = TestContext.GetLookup<YesNoNotSure> ( "PsychiatricEvaluationAndServicesAccessibleToPatient" );
            var anyAddictionDiagnosisExceptNicotine = TestContext.GetBoolean ( "AnyAddictionDiagnosisExceptNicotine" );

             var hasNoInterferenceFromEmotionalAndBehavioralConditions = TestContext.GetBoolean("HasNoInterferenceFromEmotionalAndBehavioralConditions");
             var isMet = TestContext.GetBoolean("IsMet");

             var dim3ScoringStrategy = new Dimension3ScoringStrategy();
             var careLevel05Score = dim3ScoringStrategy.CalculateCareLevel_0_5_EarlyInterventionScore (
                 withdrawalSymptomsAndEmotionalBehavioralProblems,
                 doesPatientCarryPsychiatricDiagnosis,
                 activePsychiatricDiagnosesOtherThanSubstanceAbuse,
                 patientNeedForPsychiatricPsychologicalTreatmentRating,
                 howEmotionalProblemsImpactRecoveryEfforts,
                 psychiatricEvaluationAndServicesAccessibleToPatient,
                 anyAddictionDiagnosisExceptNicotine);

             Assert.AreEqual(
                 hasNoInterferenceFromEmotionalAndBehavioralConditions,
                 careLevel05Score.HasNoInterferenceFromEmotionalAndBehavioralConditions,
                 "hasNoInterferenceFromEmotionalAndBehavioralConditions didn't match.");

             Assert.AreEqual(
                 isMet,
                 careLevel05Score.IsMet,
                 "IsMet didn't match.");
         }
        
        [TestMethod]
        [DataSource("D3_CareLevel_I_OutpatientScore")]
        public void D3_CalculateCareLevel_I_OutpatientScoreTests()
        {
            var withdrawalSymptomsAndEmotionalBehavioralProblems = TestContext.GetBoolean("WithdrawalSymptomsAndEmotionalBehavioralProblems");
            var doesPatientCarryPsychiatricDiagnosis = TestContext.GetLookup<PatientCarriesPsychiatricDiagnosis>("DoesPatientCarryPsychiatricDiagnosis");
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = TestContext.GetLookups<PsychiatricDiagnosis>("ActivePsychiatricDiagnosesOtherThanSubstanceAbuse");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8 ( TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale>("HowEmotionalProblemsImpactRecoveryEfforts");
            var emotionalProblemsCorrelationWithSubstanceUse = TestContext.GetLookup<EmotionalProblemsCorrelationWithSubstanceUse>("EmotionalProblemsCorrelationWithSubstanceUse");
            var howImportantPsychologicalEmotionalCounseling = TestContext.GetLookup<PsychologicalEmotionalCounselingImportanceScale>("HowImportantPsychologicalEmotionalCounseling");
            var significantPeriodImpairedThoughtInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodImpairedThoughtInLast24Hours");
            var isPatientUnableToUnderstand = TestContext.GetLookup<YesNoNotSure>("IsPatientUnableToUnderstand");
            var interviewerObservationOfPatientSenseOfAwareness = TestContext.GetLookup<SenseOfAwareness>("InterviewerObservationOfPatientSenseOfAwareness");
            var appearanceOfParanoiaOrImpairedThinking = new ScaleOf0To8 ( TestContext.GetUInt32("AppearanceOfParanoiaOrImpairedThinking"));
            var appearanceOfLethargy = new ScaleOf0To8 ( TestContext.GetUInt32("AppearanceOfLethargy"));
            var appearanceOfFluctuatingOrientationInLast24Hours = new ScaleOf0To8 ( TestContext.GetUInt32("AppearanceOfFluctuatingOrientationInLast24Hours"));
            var limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers = new ScaleOf0To8 ( TestContext.GetUInt32("LimitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers"));
            var globalAssessmentOfFunctioningScore = TestContext.GetUInt32("GlobalAssessmentOfFunctioningScore");
            var significantPeriodCurbingViolentBehaviorInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodCurbingViolentBehaviorInLast24Hours");
            var significantPeriodViolentUrgesInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodViolentUrgesInLast24Hours");
            var significantPeriodSuicidalThoughtsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodSuicidalThoughtsInLast24Hours");
            var hasSuicidalThoughts = new ScaleOf0To8 ( TestContext.GetUInt32("HasSuicidalThoughts"));
            var demonstratingDangerToSelfOrOthers = new ScaleOf0To8 ( TestContext.GetUInt32("DemonstratingDangerToSelfOrOthers"));
            var indicatingRiskOfHarmToOthers = new ScaleOf0To8 ( TestContext.GetUInt32("IndicatingRiskOfHarmToOthers"));
            var indicatingRiskOfHarmToSelfOrVictimizationByOthers = new ScaleOf0To8 ( TestContext.GetUInt32("IndicatingRiskOfHarmToSelfOrVictimizationByOthers"));
            var hasRecentlyNeglectedOrAbusedFamilyMembers = TestContext.GetLookup<LikertScale>("HasRecentlyNeglectedOrAbusedFamilyMembers");
            var familyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II = TestContext.GetLookup<LikertScale>("FamilyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II");
            var currentBehaviorInconsistentWithSelfCare = TestContext.GetLookup<YesNoNotSure>("CurrentBehaviorInconsistentWithSelfCare");
            var currentProblemBehaviorsRequireContinuousInterventions = TestContext.GetLookup<YesNoNotSure>("CurrentProblemBehaviorsRequireContinuousInterventions");
            var patientRequires24HourControlledSupervisedEnvironment = TestContext.GetLookup<YesNoNotSure>("PatientRequires24HourControlledSupervisedEnvironment");
            var psychiatricEvaluationAndServicesAccessibleToPatient = TestContext.GetLookup<YesNoNotSure>("PsychiatricEvaluationAndServicesAccessibleToPatient");

            var hasNoInterferenceFromCoexistingMentalDisorder = TestContext.GetBoolean ( "HasNoInterferenceFromCoexistingMentalDisorder" );
            var hasMildSymptomsFromSubstanceUseOrCoexistingMentalDisorder = TestContext.GetBoolean ( "HasMildSymptomsFromSubstanceUseOrCoexistingMentalDisorder" );
            var mentalStatusAllowsUnderstandingAndParticipationInTreatment = TestContext.GetBoolean ( "MentalStatusAllowsUnderstandingAndParticipationInTreatment" );
            var willNotBeVictimizedAndPosesNoRiskOfHarmToSelfOrOthers = TestContext.GetBoolean ( "WillNotBeVictimizedAndPosesNoRiskOfHarmToSelfOrOthers" );
            var hasSevereMentalDisorderAndAbilityToAccessServices = TestContext.GetBoolean ( "HasSevereMentalDisorderAndAbilityToAccessServices" );
            var hasSevereMentalOrSubstanceInducedDisorder = TestContext.GetBoolean ( "HasSevereMentalOrSubstanceInducedDisorder" );
            var lacksAbilityToUnderstandAndParticipateInTreatment = TestContext.GetBoolean ( "LacksAbilityToUnderstandAndParticipateInTreatment" );
            var posesNoRiskOfHarmToSelfOrOthersAndWillNotBeVictimized = TestContext.GetBoolean ( "PosesNoRiskOfHarmToSelfOrOthersAndWillNotBeVictimized" );
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            var dimension3ScoringStrategy = new Dimension3ScoringStrategy ( );
            var careLevel_I_OutpatientScore = dimension3ScoringStrategy.CalculateCareLevel_I_OutpatientScore(
                withdrawalSymptomsAndEmotionalBehavioralProblems,
                doesPatientCarryPsychiatricDiagnosis,
                activePsychiatricDiagnosesOtherThanSubstanceAbuse,
                patientNeedForPsychiatricPsychologicalTreatmentRating,
                howEmotionalProblemsImpactRecoveryEfforts,
                emotionalProblemsCorrelationWithSubstanceUse,
                howImportantPsychologicalEmotionalCounseling,
                significantPeriodImpairedThoughtInLast24Hours,
                isPatientUnableToUnderstand,
                interviewerObservationOfPatientSenseOfAwareness,
                appearanceOfParanoiaOrImpairedThinking,
                appearanceOfLethargy,
                appearanceOfFluctuatingOrientationInLast24Hours,
                limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers,
                globalAssessmentOfFunctioningScore,
                significantPeriodCurbingViolentBehaviorInLast24Hours,
                significantPeriodViolentUrgesInLast24Hours,
                significantPeriodSuicidalThoughtsInLast24Hours,
                hasSuicidalThoughts,
                demonstratingDangerToSelfOrOthers,
                indicatingRiskOfHarmToOthers,
                indicatingRiskOfHarmToSelfOrVictimizationByOthers,
                hasRecentlyNeglectedOrAbusedFamilyMembers,
                familyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II,
                currentBehaviorInconsistentWithSelfCare,
                currentProblemBehaviorsRequireContinuousInterventions,
                patientRequires24HourControlledSupervisedEnvironment,
                psychiatricEvaluationAndServicesAccessibleToPatient);

            Assert.AreEqual(
              hasNoInterferenceFromCoexistingMentalDisorder,
              careLevel_I_OutpatientScore.HasNoInterferenceFromCoexistingMentalDisorder,
              "HasNoInterferenceFromCoexistingMentalDisorder didn't match.");

            Assert.AreEqual(
              hasMildSymptomsFromSubstanceUseOrCoexistingMentalDisorder,
              careLevel_I_OutpatientScore.HasMildSymptomsFromSubstanceUseOrCoexistingMentalDisorder,
              "HasMildSymptomsFromSubstanceUseOrCoexistingMentalDisorder didn't match.");

            Assert.AreEqual(
              mentalStatusAllowsUnderstandingAndParticipationInTreatment,
              careLevel_I_OutpatientScore.MentalStatusAllowsUnderstandingAndParticipationInTreatment,
              "MentalStatusAllowsUnderstandingAndParticipationInTreatment didn't match.");

            Assert.AreEqual(
              willNotBeVictimizedAndPosesNoRiskOfHarmToSelfOrOthers,
              careLevel_I_OutpatientScore.WillNotBeVictimizedAndPosesNoRiskOfHarmToSelfOrOthers,
              "WillNotBeVictimizedAndPosesNoRiskOfHarmToSelfOrOthers didn't match.");

            Assert.AreEqual(
              hasSevereMentalDisorderAndAbilityToAccessServices,
              careLevel_I_OutpatientScore.HasSevereMentalDisorderAndAbilityToAccessServices,
              "HasSevereMentalDisorderAndAbilityToAccessServices didn't match.");

            Assert.AreEqual(
              hasSevereMentalOrSubstanceInducedDisorder,
              careLevel_I_OutpatientScore.HasSevereMentalOrSubstanceInducedDisorder,
              "HasSevereMentalOrSubstanceInducedDisorder didn't match.");

            Assert.AreEqual(
              lacksAbilityToUnderstandAndParticipateInTreatment,
              careLevel_I_OutpatientScore.LacksAbilityToUnderstandAndParticipateInTreatment,
              "LacksAbilityToUnderstandAndParticipateInTreatment didn't match.");

            Assert.AreEqual(
              posesNoRiskOfHarmToSelfOrOthersAndWillNotBeVictimized,
              careLevel_I_OutpatientScore.PosesNoRiskOfHarmToSelfOrOthersAndWillNotBeVictimized,
              "PosesNoRiskOfHarmToSelfOrOthersAndWillNotBeVictimized didn't match.");

            Assert.AreEqual(isMet,
                             careLevel_I_OutpatientScore.IsMet,
                             "CareLevel_I_OutpatientScore didn't match.");

            Assert.AreEqual(isDualDiagnosisEnhanced,
                             careLevel_I_OutpatientScore.IsDualDiagnosisEnhanced,
                             "IsDualDiagnosisEnhanced didn't match.");
        }

        [TestMethod]
        [DataSource("D3_CareLevelOpioidMaintenanceTherapyScore")]
        public void D3_CalculateCareLevelOpioidMaintenanceTherapyScoreTests()
        {
            var emotionalBehavioralProblemsManageableAsOutpatient = TestContext.GetBoolean("EmotionalBehavioralProblemsManageableAsOutpatient");
            var doesPatientCarryPsychiatricDiagnosis = TestContext.GetLookup<PatientCarriesPsychiatricDiagnosis>("DoesPatientCarryPsychiatricDiagnosis");
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = TestContext.GetLookups<PsychiatricDiagnosis>("ActivePsychiatricDiagnosesOtherThanSubstanceAbuse");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale>("HowEmotionalProblemsImpactRecoveryEfforts");
            var hasRecentlyNeglectedOrAbusedFamilyMembers = TestContext.GetLookup<LikertScale>("HasRecentlyNeglectedOrAbusedFamilyMembers");
            var familyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II = TestContext.GetLookup<LikertScale>("FamilyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II");
            var howLikelyToCauseHarmNeglectOthers = TestContext.GetLookup<LikertScale>("HowLikelyToCauseHarmNeglectOthers");
            var significantPeriodCurbingViolentBehaviorInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodCurbingViolentBehaviorInLast24Hours");
            var significantPeriodViolentUrgesInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodViolentUrgesInLast24Hours");
            var significantPeriodSuicidalThoughtsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodSuicidalThoughtsInLast24Hours");
            var significantPeriodThoughtsOfSelfInjuryInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodThoughtsOfSelfInjuryInLast24Hours");
            var hasSuicidalThoughts = new ScaleOf0To8(TestContext.GetUInt32("HasSuicidalThoughts"));
            var demonstratingDangerToSelfOrOthers = new ScaleOf0To8(TestContext.GetUInt32("DemonstratingDangerToSelfOrOthers"));
            var indicatingRiskOfHarmToOthers = new ScaleOf0To8(TestContext.GetUInt32("IndicatingRiskOfHarmToOthers"));
            var indicatingRiskOfHarmToSelfOrVictimizationByOthers = new ScaleOf0To8(TestContext.GetUInt32("IndicatingRiskOfHarmToSelfOrVictimizationByOthers"));
            var limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers = new ScaleOf0To8(TestContext.GetUInt32("LimitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers"));
            var currentBehaviorInconsistentWithSelfCare = TestContext.GetLookup<YesNoNotSure>("CurrentBehaviorInconsistentWithSelfCare");
            var currentProblemBehaviorsRequireContinuousInterventions = TestContext.GetLookup<YesNoNotSure>("CurrentProblemBehaviorsRequireContinuousInterventions");
            var showsStabilityButNeedsMorePharmacotherapyToStopRelapse = TestContext.GetBoolean("ShowsStabilityButNeedsMorePharmacotherapyToStopRelapse");
            var anyOpioidAddictionDiagnosis = TestContext.GetBoolean("AnyOpioidAddictionDiagnosis");
           
            var abuseOrNeglectOfFamilyRequiresIntensiveOutpatientTreatment = TestContext.GetBoolean("AbuseOrNeglectOfFamilyRequiresIntensiveOutpatientTreatment");
            var requiresManagementForDiagnosedStableEmotionalProblems = TestContext.GetBoolean("RequiresManagementForDiagnosedStableEmotionalProblems");
            var needsOutpatientTreatmentDueToRiskOfHarmToSelfOrOthers = TestContext.GetBoolean("NeedsOutpatientTreatmentDueToRiskOfHarmToSelfOrOthers");
            var isMet = TestContext.GetBoolean("IsMet");

            var dimension3ScoringStrategy = new Dimension3ScoringStrategy ( );
            var careLevelOpioidMaintenanceTherapyScore = dimension3ScoringStrategy.
                CalculateCareLevelOpioidMaintenanceTherapyScore (
                    emotionalBehavioralProblemsManageableAsOutpatient,
                    doesPatientCarryPsychiatricDiagnosis,
                    activePsychiatricDiagnosesOtherThanSubstanceAbuse,
                    patientNeedForPsychiatricPsychologicalTreatmentRating,
                    howEmotionalProblemsImpactRecoveryEfforts,
                    hasRecentlyNeglectedOrAbusedFamilyMembers,
                    familyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II,
                    howLikelyToCauseHarmNeglectOthers,
                    significantPeriodCurbingViolentBehaviorInLast24Hours,
                    significantPeriodViolentUrgesInLast24Hours,
                    significantPeriodSuicidalThoughtsInLast24Hours,
                    significantPeriodThoughtsOfSelfInjuryInLast24Hours,
                    hasSuicidalThoughts,
                    demonstratingDangerToSelfOrOthers,
                    indicatingRiskOfHarmToOthers,
                    indicatingRiskOfHarmToSelfOrVictimizationByOthers,
                    limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers,
                    currentBehaviorInconsistentWithSelfCare,
                    currentProblemBehaviorsRequireContinuousInterventions,
                    showsStabilityButNeedsMorePharmacotherapyToStopRelapse,
                    anyOpioidAddictionDiagnosis);

            Assert.AreEqual(
              abuseOrNeglectOfFamilyRequiresIntensiveOutpatientTreatment,
              careLevelOpioidMaintenanceTherapyScore.AbuseOrNeglectOfFamilyRequiresIntensiveOutpatientTreatment,
              "AbuseOrNeglectOfFamilyRequiresIntensiveOutpatientTreatment didn't match.");

            Assert.AreEqual(
             requiresManagementForDiagnosedStableEmotionalProblems,
             careLevelOpioidMaintenanceTherapyScore.RequiresManagementForDiagnosedStableEmotionalProblems,
             "RequiresManagementForDiagnosedStableEmotionalProblems didn't match.");

            Assert.AreEqual(
             needsOutpatientTreatmentDueToRiskOfHarmToSelfOrOthers,
             careLevelOpioidMaintenanceTherapyScore.NeedsOutpatientTreatmentDueToRiskOfHarmToSelfOrOthers,
             "NeedsOutpatientTreatmentDueToRiskOfHarmToSelfOrOthers didn't match.");

            Assert.AreEqual(isMet,
                             careLevelOpioidMaintenanceTherapyScore.IsMet,
                             "careLevelOpioidMaintenanceTherapyScore didn't match.");
        }

        [TestMethod]
        [DataSource("D3_CareLevel_II_1_IntensiveOutpatientScore")]
        public void D3_CalculateCareLevel_II_1_IntensiveOutpatientScoreTests()
        {
            var withdrawalSymptomsAndEmotionalBehavioralProblems =
                TestContext.GetBoolean ( "WithdrawalSymptomsAndEmotionalBehavioralProblems" );
            var doesPatientCarryPsychiatricDiagnosis =
                TestContext.GetLookup<PatientCarriesPsychiatricDiagnosis> ( "DoesPatientCarryPsychiatricDiagnosis" );
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse =
                TestContext.GetLookups<PsychiatricDiagnosis>("ActivePsychiatricDiagnosesOtherThanSubstanceAbuse");
            var patientNeedForPsychiatricPsychologicalTreatmentRating =
                new ScaleOf0To8 ( TestContext.GetUInt32 ( "PatientNeedForPsychiatricPsychologicalTreatmentRating" ) );
            var abusesFamilyAndRequiresIntensiveOutpatientTreatment =
                TestContext.GetBoolean ( "AbusesFamilyAndRequiresIntensiveOutpatientTreatment" );
            var howEmotionalProblemsImpactRecoveryEfforts =
                TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale> (
                    "HowEmotionalProblemsImpactRecoveryEfforts" );
            var likelihoodOfRecurrenceOfPsychiatricDecompensation =
                new ScaleOf0To8 ( TestContext.GetUInt32 ( "LikelihoodOfRecurrenceOfPsychiatricDecompensation" ) );
            var levelOfSupervisionNeededForProtectionFromSelfHarm =
                new ScaleOf0To8 ( TestContext.GetUInt32 ( "LevelOfSupervisionNeededForProtectionFromSelfHarm" ) );
            var showsMildRiskOfHarmToSelfOrOthersOrProperty =
                TestContext.GetBoolean ( "ShowsMildRiskOfHarmToSelfOrOthersOrProperty" );
            var emotionalAbuseInPast30Days = TestContext.GetLookup<LikertScale> ( "EmotionalAbuseInPast30Days" );
            var physicalAbuseInPast30Days = TestContext.GetLookup<LikertScale> ( "PhysicalAbuseInPast30Days" );
            var sexualAbuseInPast30Days = TestContext.GetLookup<LikertScale> ( "SexualAbuseInPast30Days" );
            var riskPatientHarmedByOther = TestContext.GetLookup<LikertScale> ( "RiskPatientHarmedByOther" );
            var isAbleToLocateAndGetToCommunityResourcesSafely =
                TestContext.GetBoolean ( "IsAbleToLocateAndGetToCommunityResourcesSafely" );

            var hasNoNeedForEmotionalBehavioralServices =
                TestContext.GetBoolean ( "HasNoNeedForEmotionalBehavioralServices" );
            var requiresManagementForDiagnosedEmotionalProblems =
                TestContext.GetBoolean ( "RequiresManagementForDiagnosedEmotionalProblems" );
            var requiresStabilizationOfDiagnosedEmotionalDisorder =
                TestContext.GetBoolean ( "RequiresStabilizationOfDiagnosedEmotionalDisorder" );
            var showsSignificantRiskOfBeingVictimizedByOthers =
                TestContext.GetBoolean ( "ShowsSignificantRiskOfBeingVictimizedByOthers" );
            var isMet = TestContext.GetBoolean ( "IsMet" );
            var isDualDiagnosisCapable = TestContext.GetBoolean ( "IsDualDiagnosisCapable" );
            var isDualDiagnosisEnhanced = TestContext.GetBoolean ( "IsDualDiagnosisEnhanced" );

            var dimension3ScoringStrategy = new Dimension3ScoringStrategy ( );
            var careLevel_II_1_IntensiveOutpatientScore = dimension3ScoringStrategy.CalculateCareLevel_II_1_IntensiveOutpatientScore (
                    withdrawalSymptomsAndEmotionalBehavioralProblems,
                    doesPatientCarryPsychiatricDiagnosis,
                    activePsychiatricDiagnosesOtherThanSubstanceAbuse,
                    patientNeedForPsychiatricPsychologicalTreatmentRating,
                    abusesFamilyAndRequiresIntensiveOutpatientTreatment,
                    howEmotionalProblemsImpactRecoveryEfforts,
                    likelihoodOfRecurrenceOfPsychiatricDecompensation,
                    levelOfSupervisionNeededForProtectionFromSelfHarm,
                    showsMildRiskOfHarmToSelfOrOthersOrProperty,
                    emotionalAbuseInPast30Days,
                    physicalAbuseInPast30Days,
                    sexualAbuseInPast30Days,
                    riskPatientHarmedByOther,
                    isAbleToLocateAndGetToCommunityResourcesSafely );

            Assert.AreEqual (
                hasNoNeedForEmotionalBehavioralServices,
                careLevel_II_1_IntensiveOutpatientScore.HasNoNeedForEmotionalBehavioralServices,
                "HasNoNeedForEmotionalBehavioralServices didn't match." );

            Assert.AreEqual (
                requiresManagementForDiagnosedEmotionalProblems,
                careLevel_II_1_IntensiveOutpatientScore.RequiresManagementForDiagnosedEmotionalProblems,
                "RequiresManagementForDiagnosedEmotionalProblems didn't match." );

            Assert.AreEqual (
                requiresStabilizationOfDiagnosedEmotionalDisorder,
                careLevel_II_1_IntensiveOutpatientScore.RequiresStabilizationOfDiagnosedEmotionalDisorder,
                "RequiresStabilizationOfDiagnosedEmotionalDisorder didn't match." );

            Assert.AreEqual (
                showsSignificantRiskOfBeingVictimizedByOthers,
                careLevel_II_1_IntensiveOutpatientScore.ShowsSignificantRiskOfBeingVictimizedByOthers,
                "ShowsSignificantRiskOfBeingVictimizedByOthers didn't match." );

            Assert.AreEqual (
                isDualDiagnosisCapable,
                careLevel_II_1_IntensiveOutpatientScore.IsDualDiagnosisCapable,
                "IsDualDiagnosisCapable didn't match." );
            Assert.AreEqual (
                            isDualDiagnosisEnhanced,
                            careLevel_II_1_IntensiveOutpatientScore.IsDualDiagnosisEnhanced,
                            "IsDualDiagnosisEnhanced didn't match." );

            Assert.AreEqual ( isMet,
                              careLevel_II_1_IntensiveOutpatientScore.IsMet,
                              "careLevel_II_1_IntensiveOutpatientScore didn't match." );
        }

        [TestMethod]
        [DataSource("D3_CareLevel_II_5_PartialHospitalization")]
        public void D3_CalculateCareLevel_II_5_PartialHospitalizationScorTests()
        {
            var hasNoEmotionalBehavioralConditionsRequiringStabilization = TestContext.GetBoolean("HasNoEmotionalBehavioralConditionsRequiringStabilization");
            var significantPeriodParanoiaInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodParanoiaInLast24Hours");
            var significantPeriodParanoiaInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodParanoiaInLastMonth");
            var significantPeriodParanoiaInLifetime = TestContext.GetLookup<LikertScale>("SignificantPeriodParanoiaInLifetime");
            var significantPeriodParanoiaRelatedToSubstanceUse = TestContext.GetLookup<RelationToSubstanceUse>("SignificantPeriodParanoiaRelatedToSubstanceUse");
            var significantPeriodUntruePerceptionInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodUntruePerceptionInLast24Hours");
            var significantPeriodUntruePerceptionInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodUntruePerceptionInLastMonth");
            var significantPeriodUntruePerceptionInLifetime = TestContext.GetLookup<LikertScale>("SignificantPeriodUntruePerceptionInLifetime");
            var significantPeriodUntruePerceptionRelatedToSubstanceUse = TestContext.GetLookup<RelationToSubstanceUse>("SignificantPeriodUntruePerceptionRelatedToSubstanceUse");
            var significantPeriodHallucinationsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodHallucinationsInLast24Hours");
            var significantPeriodHallucinationsInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodHallucinationsInLastMonth");
            var significantPeriodHallucinationsInLifetime = TestContext.GetLookup<LikertScale>("SignificantPeriodHallucinationsInLifetime");
            var significantPeriodHallucinationsRelatedToSubstanceUse = TestContext.GetLookup<RelationToSubstanceUse>("SignificantPeriodHallucinationsRelatedToSubstanceUse");
            var likelihoodOfRecurrenceOfPsychiatricDecompensation = new ScaleOf0To8(TestContext.GetUInt32("LikelihoodOfRecurrenceOfPsychiatricDecompensation"));
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var freeTimeAffectOnRecovery = TestContext.GetLookup<FreeTimeAffectOnRecovery>("FreeTimeAffectOnRecovery");
            var dealsWithProblemsInFreeTimeThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse>("DealsWithProblemsInFreeTimeThatRiskRelapse");
            var dealsWithProblemsFromFriendsThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsFromFriendsThatRiskRelapse>("DealsWithProblemsFromFriendsThatRiskRelapse");
            var indicatingRiskOfHarmToSelfOrVictimizationByOthers = new ScaleOf0To8(TestContext.GetUInt32("IndicatingRiskOfHarmToSelfOrVictimizationByOthers"));
            var levelOfSupervisionNeededForProtectionFromSelfHarm = new ScaleOf0To8(TestContext.GetUInt32("LevelOfSupervisionNeededForProtectionFromSelfHarm"));
            var currentHarmRiskToSelfOthers = TestContext.GetUInt32("CurrentHarmRiskToSelfOthers");
            var strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers = TestContext.GetLookup<LikertScale>("StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggers");
            var doesPatientCarryPsychiatricDiagnosis = TestContext.GetLookup<PatientCarriesPsychiatricDiagnosis>("DoesPatientCarryPsychiatricDiagnosis");
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = TestContext.GetLookups<PsychiatricDiagnosis>("ActivePsychiatricDiagnosesOtherThanSubstanceAbuse");
            var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale>("HowEmotionalProblemsImpactRecoveryEfforts");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var hasLifetimeMajorDepressionDisorder = TestContext.GetBoolean("HasLifetimeMajorDepressionDisorder");
            var hasLifetimeOtherDepressionDisorder = TestContext.GetBoolean("HasLifetimeOtherDepressionDisorder");
            var significantPeriodOfSeriousDepressionInLifetime = TestContext.GetLookup<LikertScale>("SignificantPeriodOfSeriousDepressionInLifetime");
            var inabilityToFeelPleasureFromActivitiesInLifetime = TestContext.GetLookup<LikertScale>("InabilityToFeelPleasureFromActivitiesInLifetime");
            var depressionWithin24HoursRelatedToSubstanceUse = TestContext.GetLookup<RelationToSubstanceUse>("DepressionWithin24HoursRelatedToSubstanceUse");
            var inabilityToFeelPleasureFromActivitiesRelatedToSubstanceUse = TestContext.GetLookup<RelationToSubstanceUse>("InabilityToFeelPleasureFromActivitiesRelatedToSubstanceUse");
            var significantPeriodOfSeriousDepressionInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodOfSeriousDepressionInLast24Hours");
            var inabilityToFeelPleasureFromActivitiesInLast24Hours = TestContext.GetLookup<LikertScale>("InabilityToFeelPleasureFromActivitiesInLast24Hours");
            var significantPeriodSuicidalThoughtsInLifetime = TestContext.GetLookup<LikertScale>("SignificantPeriodSuicidalThoughtsInLifetime");
            var significantPeriodThoughtsOfSelfInjuryInLifetime = TestContext.GetLookup<LikertScale>("SignificantPeriodThoughtsOfSelfInjuryInLifetime");
            var significantPeriodAttemptedSuicideInLifetime = TestContext.GetLookup<LikertScale>("SignificantPeriodAttemptedSuicideInLifetime");
            
            //var hasNoEmotionalBehavioralConditionsRequiringStabilization = TestContext.GetBoolean("HasNoEmotionalBehavioralConditionsRequiringStabilization");
            var hasMildToModerateParanoiaOnDiscontinuingDrugOfAbuse = TestContext.GetBoolean("HasMildToModerateParanoiaOnDiscontinuingDrugOfAbuse");
            var hasProblemsButReceivesAdequateSupportFromFamily = TestContext.GetBoolean("HasProblemsButReceivesAdequateSupportFromFamily");
            var hasProblemsRequiringSupportiveEnvironmentWithLevelIII_1Care = TestContext.GetBoolean("HasProblemsRequiringSupportiveEnvironmentWithLevelIII_1Care");
            var cannotMaintainBahavioralStabilityOver48HourPeriod = TestContext.GetBoolean("CannotMaintainBahavioralStabilityOver48HourPeriod");
            var hasCurrentAndHistoricalModeratePsychiatricDecompensation = TestContext.GetBoolean("HasCurrentAndHistoricalModeratePsychiatricDecompensation");
            var lacksCopingSkillsToMaintainSafetyToSelfOthersOrProperty = TestContext.GetBoolean("LacksCopingSkillsToMaintainSafetyToSelfOthersOrProperty");
            var problemsSeverityIndicatorForPartialHospitalizationDualDiagnosisEnhanced = TestContext.GetBoolean("ProblemsSeverityIndicatorForPartialHospitalization"); 
            
            var requiresPartialHospitalizationOrOutPatientInConjunctionWithLevel3 = TestContext.GetBoolean("RequiresPartialHospitalizationOrOutPatientInConjunctionWith3");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisCapable = TestContext.GetBoolean("IsDualDiagnosisCapable");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            if (TestContext.GetBoolean("ForDebug"))
            {

            }

            var dimension3ScoringStrategy = new Dimension3ScoringStrategy();
            var careLevel_II_5_Score = dimension3ScoringStrategy.CalculateCareLevel_II_5_PartialHospitalizationScore (
                hasNoEmotionalBehavioralConditionsRequiringStabilization,
                significantPeriodParanoiaInLast24Hours,
                significantPeriodParanoiaInLastMonth,
                significantPeriodParanoiaInLifetime,
                significantPeriodParanoiaRelatedToSubstanceUse,
                significantPeriodUntruePerceptionInLast24Hours,
                significantPeriodUntruePerceptionInLastMonth,
                significantPeriodUntruePerceptionInLifetime,
                significantPeriodUntruePerceptionRelatedToSubstanceUse,
                significantPeriodHallucinationsInLast24Hours,
                significantPeriodHallucinationsInLastMonth,
                significantPeriodHallucinationsInLifetime,
                significantPeriodHallucinationsRelatedToSubstanceUse,
                likelihoodOfRecurrenceOfPsychiatricDecompensation,
                livingArrangementAffectOnRecovery,
                freeTimeAffectOnRecovery,
                dealsWithProblemsInFreeTimeThatRiskRelapse,
                dealsWithProblemsFromFriendsThatRiskRelapse,
                indicatingRiskOfHarmToSelfOrVictimizationByOthers,
                levelOfSupervisionNeededForProtectionFromSelfHarm,
                currentHarmRiskToSelfOthers,
                strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers,
                doesPatientCarryPsychiatricDiagnosis,
                activePsychiatricDiagnosesOtherThanSubstanceAbuse,
                howEmotionalProblemsImpactRecoveryEfforts,
                patientNeedForPsychiatricPsychologicalTreatmentRating,
                hasLifetimeMajorDepressionDisorder,
                hasLifetimeOtherDepressionDisorder,
                significantPeriodOfSeriousDepressionInLifetime,
                inabilityToFeelPleasureFromActivitiesInLifetime,
                depressionWithin24HoursRelatedToSubstanceUse,
                inabilityToFeelPleasureFromActivitiesRelatedToSubstanceUse,
                significantPeriodOfSeriousDepressionInLast24Hours,
                inabilityToFeelPleasureFromActivitiesInLast24Hours,
                significantPeriodSuicidalThoughtsInLifetime,
                significantPeriodThoughtsOfSelfInjuryInLifetime,
                significantPeriodAttemptedSuicideInLifetime );

            Assert.AreEqual(hasNoEmotionalBehavioralConditionsRequiringStabilization, careLevel_II_5_Score.HasNoEmotionalBehavioralConditionsRequiringStabilization, "HasNoEmotionalBehavioralConditionsRequiringStabilization didn't match.");
            Assert.AreEqual(hasMildToModerateParanoiaOnDiscontinuingDrugOfAbuse, careLevel_II_5_Score.HasMildToModerateParanoiaOnDiscontinuingDrugOfAbuse, "HasMildToModerateParanoiaOnDiscontinuingDrugOfAbuse didn't match.");
            Assert.AreEqual(hasProblemsButReceivesAdequateSupportFromFamily, careLevel_II_5_Score.HasProblemsButReceivesAdequateSupportFromFamily, "HasProblemsButReceivesAdequateSupportFromFamily didn't match.");
            Assert.AreEqual(hasProblemsRequiringSupportiveEnvironmentWithLevelIII_1Care, careLevel_II_5_Score.HasProblemsRequiringSupportiveEnvironmentWithLevelIII_1Care, "HasProblemsRequiringSupportiveEnvironmentWithLevelIII_1Care didn't match.");
            Assert.AreEqual(cannotMaintainBahavioralStabilityOver48HourPeriod, careLevel_II_5_Score.CannotMaintainBahavioralStabilityOver48HourPeriod, "CannotMaintainBahavioralStabilityOver48HourPeriod didn't match.");
            Assert.AreEqual(hasCurrentAndHistoricalModeratePsychiatricDecompensation, careLevel_II_5_Score.HasCurrentAndHistoricalModeratePsychiatricDecompensation, "HasCurrentAndHistoricalModeratePsychiatricDecompensation didn't match.");
            Assert.AreEqual(lacksCopingSkillsToMaintainSafetyToSelfOthersOrProperty, careLevel_II_5_Score.LacksCopingSkillsToMaintainSafetyToSelfOthersOrProperty, "LacksCopingSkillsToMaintainSafetyToSelfOthersOrProperty didn't match.");
            Assert.AreEqual(problemsSeverityIndicatorForPartialHospitalizationDualDiagnosisEnhanced, careLevel_II_5_Score.ProblemsSeverityIndicatorForPartialHospitalizationDualDiagnosisEnhanced, "ProblemsSeverityIndicatorForPartialHospitalizationDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(requiresPartialHospitalizationOrOutPatientInConjunctionWithLevel3, careLevel_II_5_Score.RequiresPartialHospitalizationOrOutPatientInConjunctionWithLevel3, "RequiresPartialHospitalizationOrOutPatientInConjunctionWithLevel3 didn't match.");
            Assert.AreEqual(isDualDiagnosisCapable, careLevel_II_5_Score.IsDualDiagnosisCapable, "IsDualDiagnosisCapable didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_II_5_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_II_5_Score.IsMet, "CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore didn't match.");
        }
       
        
        [TestMethod]
        [DataSource("D3_CareLevel_III_1_ClinicallyManaged")]
        public void D3_CalculateCareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScoreTests()
        {
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8 ( TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var levelOfSupervisionNeededForProtectionFromSelfHarm = new ScaleOf0To8 ( TestContext.GetUInt32("LevelOfSupervisionNeededForProtectionFromSelfHarm"));
            var significantPeriodCurbingViolentBehaviorInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodCurbingViolentBehaviorInLast24Hours");
            var significantPeriodViolentUrgesInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodViolentUrgesInLast24Hours");
            var freeTimeAffectOnRecovery = TestContext.GetLookup<FreeTimeAffectOnRecovery>("FreeTimeAffectOnRecovery");
            var dealsWithProblemsInFreeTimeThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse>("DealsWithProblemsInFreeTimeThatRiskRelapse");
            var dealsWithProblemsFromFriendsThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsFromFriendsThatRiskRelapse>("DealsWithProblemsFromFriendsThatRiskRelapse");
            var friendsAffectOnRecovery = TestContext.GetLookup<FriendsAffectOnRecovery>("FriendsAffectOnRecovery");
            var closestContactsNeedsAndWillingnessToHelpTreatment = TestContext.GetLookup<NeedsAndWillingnessToHelpTreatment>("ClosestContactsNeedsAndWillingnessToHelpTreatment");
            var hasOtherAnxietySyndrome = TestContext.GetBoolean("HasOtherAnxietySyndrome");
            var appearanceOfDepressionWithdrawal = new ScaleOf0To8 ( TestContext.GetUInt32("AppearanceOfDepressionWithdrawal"));
            var appearanceOfHostility = new ScaleOf0To8 ( TestContext.GetUInt32("AppearanceOfHostility"));
            var appearanceofAgitation = new ScaleOf0To8 ( TestContext.GetUInt32("AppearanceofAgitation"));
            var appearanceOfAnxietyNervousness = new ScaleOf0To8 ( TestContext.GetUInt32("AppearanceOfAnxietyNervousness"));
            var appearanceOfParanoiaOrImpairedThinking = new ScaleOf0To8 ( TestContext.GetUInt32("AppearanceOfParanoiaOrImpairedThinking"));
            var appearanceOfTroubleConcentratingOrRemembering = new ScaleOf0To8 ( TestContext.GetUInt32("AppearanceOfTroubleConcentratingOrRemembering"));
            var appearanceOfLethargy = new ScaleOf0To8 ( TestContext.GetUInt32("AppearanceOfLethargy"));
            var appearanceOfFluctuatingOrientationInLast24Hours = new ScaleOf0To8 ( TestContext.GetUInt32("AppearanceOfFluctuatingOrientationInLast24Hours"));
            var appearanceOfSpeechImpairmentBadPosture = new ScaleOf0To8 ( TestContext.GetUInt32("AppearanceOfSpeechImpairmentBadPosture"));
            var hasSuicidalThoughts = new ScaleOf0To8 ( TestContext.GetUInt32("HasSuicidalThoughts"));
            var demonstratingDangerToSelfOrOthers = new ScaleOf0To8 ( TestContext.GetUInt32("DemonstratingDangerToSelfOrOthers"));
            var limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers = new ScaleOf0To8 ( TestContext.GetUInt32("LimitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers"));
            var indicatingRiskOfHarmToOthers = new ScaleOf0To8 ( TestContext.GetUInt32("IndicatingRiskOfHarmToOthers"));
            var indicatingRiskOfHarmToSelfOrVictimizationByOthers = new ScaleOf0To8 ( TestContext.GetUInt32("IndicatingRiskOfHarmToSelfOrVictimizationByOthers"));
            var howDifficultProblemsForWorkHomeAndSocialInteraction = TestContext.GetLookup<ProblemsForWorkHomeAndSocialInteractionScale>("HowDifficultProblemsForWorkHomeAndSocialInteraction");
            var globalAssessmentOfFunctioningScore = TestContext.GetUInt32("GlobalAssessmentOfFunctioningScore");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var currentBehaviorInconsistentWithSelfCare = TestContext.GetLookup<YesNoNotSure>("CurrentBehaviorInconsistentWithSelfCare");
            var isReceivingNeededCare = TestContext.GetLookup<YesNoNotApplicable>("IsReceivingNeededCare");
            var psychiatricEvaluationAndServicesAccessibleToPatient = TestContext.GetLookup<YesNoNotSure>("PsychiatricEvaluationAndServicesAccessibleToPatient");
            var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale>("HowEmotionalProblemsImpactRecoveryEfforts");
            var acceptableLevelsOfCare = TestContext.GetLookups<CareLevel>("AcceptableLevelsOfCare");
            var careLevel_I_OutpatientScoreIsMet = TestContext.GetBoolean("CareLevel_I_OutpatientScoreIsMet");
            var currentProblemBehaviorsRequireContinuousInterventions = TestContext.GetLookup<YesNoNotSure>("CurrentProblemBehaviorsRequireContinuousInterventions");
            var doesPatientCarryPsychiatricDiagnosis = TestContext.GetLookup<PatientCarriesPsychiatricDiagnosis>("DoesPatientCarryPsychiatricDiagnosis");
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = TestContext.GetLookups<PsychiatricDiagnosis>("ActivePsychiatricDiagnosesOtherThanSubstanceAbuse");
            var likelihoodOfRecurrenceOfPsychiatricDecompensation = new ScaleOf0To8 ( TestContext.GetUInt32("LikelihoodOfRecurrenceOfPsychiatricDecompensation"));
            var howTroubledByPsychologicalEmotionalProblemsLast30Days = TestContext.GetLookup<LikertScale>("HowTroubledByPsychologicalEmotionalProblemsLast30Days");
            var howImportantPsychologicalEmotionalCounseling = TestContext.GetLookup<PsychologicalEmotionalCounselingImportanceScale>("HowImportantPsychologicalEmotionalCounseling");
            var patientAbleToSafelyAccessNeededResources = TestContext.GetBoolean("PatientAbleToSafelyAccessNeededResources");
        

            var hasStablePsychiatricConditionAndMinimalProblems = TestContext.GetBoolean("HasStablePsychiatricConditionAndMinimalProblems");
            var hasSymptomsInHomeEnvironmentRequiringResidentialTreatment = TestContext.GetBoolean("HasSymptomsInHomeEnvironmentRequiringResidentialTreatment");
            var hasInabilityToMaintain24HourStableBehaviorWithoutAllDaySupport = TestContext.GetBoolean("HasInabilityToMaintain24HourStableBehaviorWithoutAllDaySupport");
            var hasAppropriatePsychiatricCareForEmotionalBehavioralConditions = TestContext.GetBoolean("HasAppropriatePsychiatricCareForEmotionalBehavioralConditions");
            var hasStableMentalStatusToBenefitFromTreatmentAtThisLevel = TestContext.GetBoolean("HasStableMentalStatusToBenefitFromTreatmentAtThisLevel");
            var hasHistoryOfDisordersRequiringMonitoringOfTreatment = TestContext.GetBoolean("HasHistoryOfDisordersRequiringMonitoringOfTreatment");
            var mustMonitorPsychiatricSymptomsConcurrentWithAddictionTreatment = TestContext.GetBoolean("MustMonitorPsychiatricSymptomsConcurrentWithAddictionTreatment");
            var isAbleToSafelyAccessCommunityForWorkAndOtherResources = TestContext.GetBoolean("IsAbleToSafelyAccessCommunityForWorkAndOtherResources");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisCapable = TestContext.GetBoolean("IsDualDiagnosisCapable");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            if (TestContext.GetBoolean("ForDebug"))
            {
                
            }

            var dimension3ScoringStrategy = new Dimension3ScoringStrategy();
            var careLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore = dimension3ScoringStrategy.CalculateCareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore (
                    patientNeedForPsychiatricPsychologicalTreatmentRating,
                    levelOfSupervisionNeededForProtectionFromSelfHarm,
                    significantPeriodCurbingViolentBehaviorInLast24Hours,
                    significantPeriodViolentUrgesInLast24Hours,
                    freeTimeAffectOnRecovery,
                    dealsWithProblemsInFreeTimeThatRiskRelapse,
                    dealsWithProblemsFromFriendsThatRiskRelapse,
                    friendsAffectOnRecovery,
                    closestContactsNeedsAndWillingnessToHelpTreatment,
                    hasOtherAnxietySyndrome,
                    appearanceOfDepressionWithdrawal,
                    appearanceOfHostility,
                    appearanceofAgitation,
                    appearanceOfAnxietyNervousness,
                    appearanceOfParanoiaOrImpairedThinking,
                    appearanceOfTroubleConcentratingOrRemembering,
                    appearanceOfLethargy,
                    appearanceOfFluctuatingOrientationInLast24Hours,
                    appearanceOfSpeechImpairmentBadPosture,
                    hasSuicidalThoughts,
                    demonstratingDangerToSelfOrOthers,
                    limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers,
                    indicatingRiskOfHarmToOthers,
                    indicatingRiskOfHarmToSelfOrVictimizationByOthers,
                    howDifficultProblemsForWorkHomeAndSocialInteraction,
                    globalAssessmentOfFunctioningScore,
                    livingArrangementAffectOnRecovery,
                    currentBehaviorInconsistentWithSelfCare,
                    isReceivingNeededCare,
                    psychiatricEvaluationAndServicesAccessibleToPatient,
                    howEmotionalProblemsImpactRecoveryEfforts,
                    acceptableLevelsOfCare,
                    careLevel_I_OutpatientScoreIsMet,
                    currentProblemBehaviorsRequireContinuousInterventions,
                    doesPatientCarryPsychiatricDiagnosis,
                    activePsychiatricDiagnosesOtherThanSubstanceAbuse,
                    likelihoodOfRecurrenceOfPsychiatricDecompensation,
                    howTroubledByPsychologicalEmotionalProblemsLast30Days,
                    howImportantPsychologicalEmotionalCounseling,
                    patientAbleToSafelyAccessNeededResources );

            Assert.AreEqual(hasStablePsychiatricConditionAndMinimalProblems, careLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore.HasStablePsychiatricConditionAndMinimalProblems, "HasStablePsychiatricConditionAndMinimalProblems didn't match.");
            Assert.AreEqual(hasSymptomsInHomeEnvironmentRequiringResidentialTreatment, careLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore.HasSymptomsInHomeEnvironmentRequiringResidentialTreatment, "HasSymptomsInHomeEnvironmentRequiringResidentialTreatment didn't match.");
            Assert.AreEqual(hasInabilityToMaintain24HourStableBehaviorWithoutAllDaySupport, careLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore.HasInabilityToMaintain24HourStableBehaviorWithoutAllDaySupport, "HasInabilityToMaintain24HourStableBehaviorWithoutAllDaySupport didn't match.");
            Assert.AreEqual(hasAppropriatePsychiatricCareForEmotionalBehavioralConditions, careLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore.HasAppropriatePsychiatricCareForEmotionalBehavioralConditions, "HasAppropriatePsychiatricCareForEmotionalBehavioralConditions didn't match.");
            Assert.AreEqual(hasStableMentalStatusToBenefitFromTreatmentAtThisLevel, careLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore.HasStableMentalStatusToBenefitFromTreatmentAtThisLevel, "HasStableMentalStatusToBenefitFromTreatmentAtThisLevel didn't match.");
            Assert.AreEqual(hasHistoryOfDisordersRequiringMonitoringOfTreatment, careLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore.HasHistoryOfDisordersRequiringMonitoringOfTreatment, "HasHistoryOfDisordersRequiringMonitoringOfTreatment didn't match.");
            Assert.AreEqual(mustMonitorPsychiatricSymptomsConcurrentWithAddictionTreatment, careLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore.MustMonitorPsychiatricSymptomsConcurrentWithAddictionTreatment, "MustMonitorPsychiatricSymptomsConcurrentWithAddictionTreatment didn't match.");
            Assert.AreEqual(isAbleToSafelyAccessCommunityForWorkAndOtherResources, careLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore.IsAbleToSafelyAccessCommunityForWorkAndOtherResources, "IsAbleToSafelyAccessCommunityForWorkAndOtherResources didn't match.");
            Assert.AreEqual(isDualDiagnosisCapable, careLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore.IsDualDiagnosisCapable, "IsDualDiagnosisCapable didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore.IsMet, "CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore didn't match.");
       }


        [TestMethod]
        [DataSource("D3_CareLevel_III_3_ClinicallyManagedMediumIntensity")]
        public void D3_CalculateCareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScoreTests()
        {
            var withdrawalSymptomsAndEmotionalBehavioralProblems = TestContext.GetBoolean("WithdrawalSymptomsAndEmotionalBehavioralProblems");
            var doesPatientCarryPsychiatricDiagnosis = TestContext.GetLookup<PatientCarriesPsychiatricDiagnosis>("DoesPatientCarryPsychiatricDiagnosis");
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = TestContext.GetLookups<PsychiatricDiagnosis>("ActivePsychiatricDiagnosesOtherThanSubstanceAbuse");
            var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale>("HowEmotionalProblemsImpactRecoveryEfforts");
            var howImportantPsychologicalEmotionalCounseling = TestContext.GetLookup<PsychologicalEmotionalCounselingImportanceScale>("HowImportantPsychologicalEmotionalCounseling");
            var howDifficultProblemsForWorkHomeAndSocialInteraction = TestContext.GetLookup<ProblemsForWorkHomeAndSocialInteractionScale>("HowDifficultProblemsForWorkHomeAndSocialInteraction");
            var globalAssessmentOfFunctioningScore = TestContext.GetUInt32("GlobalAssessmentOfFunctioningScore");
            var currentHarmRiskToSelfOthers = TestContext.GetUInt32("CurrentHarmRiskToSelfOthers");
            var riskOfHarmToSelfOrOthersIsHigherWithSubstanceUse = TestContext.GetLookup<RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse>("RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse");
            var concernAboutEmploymentProblemsInPast30Days = TestContext.GetLookup<LikertScale>("ConcernAboutEmploymentProblemsInPast30Days");
            var troubledByFamilyProblemsInPast30Days = TestContext.GetLookup<LikertScale>("TroubledByFamilyProblemsInPast30Days");
            var troubledBySocialProblemsInPast30Days = TestContext.GetLookup<LikertScale>("TroubledBySocialProblemsInPast30Days");
            var pastPsychologicalOrEmotionalProblems = TestContext.GetLookups<PsychologicalOrEmotionalProblems>("PastPsychologicalOrEmotionalProblems");
            var significantPeriodTroubleWithAttitudeTowardOthersInLifetime = TestContext.GetLookup<LikertScale>("SignificantPeriodTroubleWithAttitudeTowardOthersInLifetime");
            var currentProblemBehaviorsRequireContinuousInterventions = TestContext.GetLookup<YesNoNotSure>("CurrentProblemBehaviorsRequireContinuousInterventions");
            var hasSymptomsInHomeEnvironmentRequiringResidentialTreatment = TestContext.GetBoolean("HasSymptomsInHomeEnvironmentRequiringResidentialTreatment");
            var strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers = TestContext.GetLookup<LikertScale>("StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggers");
            var levelOfSupervisionNeededForProtectionFromSelfHarm = new ScaleOf0To8(TestContext.GetUInt32("LevelOfSupervisionNeededForProtectionFromSelfHarm"));
            var acceptableLevelsOfCare = TestContext.GetLookups<CareLevel>("AcceptableLevelsOfCare");
            var careLevel_I_OutpatientScoreIsMet = TestContext.GetBoolean("CareLevel_I_OutpatientScoreIsMet");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var appearanceOfTroubleConcentratingOrRemembering = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfTroubleConcentratingOrRemembering"));
            var appearanceOfDepressionWithdrawal = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfDepressionWithdrawal"));
            var appearanceOfHostility = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfHostility"));
            var appearanceofAgitation = new ScaleOf0To8(TestContext.GetUInt32("AppearanceofAgitation"));
            var appearanceOfAnxietyNervousness = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfAnxietyNervousness"));
            var appearanceOfParanoiaOrImpairedThinking = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfParanoiaOrImpairedThinking"));
            var appearanceOfLethargy = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfLethargy"));
            var appearanceOfFluctuatingOrientationInLast24Hours = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfFluctuatingOrientationInLast24Hours"));
            var appearanceOfSpeechImpairmentBadPosture = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfSpeechImpairmentBadPosture"));
            var hasSuicidalThoughts = new ScaleOf0To8(TestContext.GetUInt32("HasSuicidalThoughts"));
            var demonstratingDangerToSelfOrOthers = new ScaleOf0To8(TestContext.GetUInt32("DemonstratingDangerToSelfOrOthers"));
            var indicatingRiskOfHarmToOthers = new ScaleOf0To8(TestContext.GetUInt32("IndicatingRiskOfHarmToOthers"));
            var indicatingRiskOfHarmToSelfOrVictimizationByOthers = new ScaleOf0To8(TestContext.GetUInt32("IndicatingRiskOfHarmToSelfOrVictimizationByOthers"));
            var likelihoodOfRecurrenceOfPsychiatricDecompensation = new ScaleOf0To8(TestContext.GetUInt32("LikelihoodOfRecurrenceOfPsychiatricDecompensation"));
            var limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers = new ScaleOf0To8(TestContext.GetUInt32("LimitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers"));
            var significantPeriodThoughtsOfSelfInjuryInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodThoughtsOfSelfInjuryInLast24Hours");
            var evidenceOfChronicOrganicMentalDisability = TestContext.GetLookup<YesNoNotSure>("EvidenceOfChronicOrganicMentalDisability");
            var currentBehaviorInconsistentWithSelfCare = TestContext.GetLookup<YesNoNotSure>("CurrentBehaviorInconsistentWithSelfCare");



            var hasDepressionOrOtherConditionAndNeeds24HourCare = TestContext.GetBoolean("HasDepressionOrOtherConditionAndNeeds24HourCare");
            var exhibitsViolentBehaviorOnIntoxicationAndIsDangerous = TestContext.GetBoolean("ExhibitsViolentBehaviorOnIntoxicationAndIsDangerous");
            var hasStressDueToRecentLossesThatImpairDailyActivities = TestContext.GetBoolean("HasStressDueToRecentLossesThatImpairDailyActivities");
            var hasSevereConcomitantPersonalityDisorders = TestContext.GetBoolean("HasSevereConcomitantPersonalityDisorders");
            var hasSevereFunctionalDeficitsRequiringResidentialTreatment = TestContext.GetBoolean("HasSevereFunctionalDeficitsRequiringResidentialTreatment");
            var needsLevelIII_3CareDueToMildHarmRiskAndImminentRelapse = TestContext.GetBoolean("NeedsLevelIII_3CareDueToMildHarmRiskAndImminentRelapse");
            var hasStableMentalStatusToPermitParticipationInTreatment = TestContext.GetBoolean("HasStableMentalStatusToPermitParticipationInTreatment");
            var needsStabilizationOfPsychiatricSymptomsAlongWithTreatment = TestContext.GetBoolean("NeedsStabilizationOfPsychiatricSymptomsAlongWithTreatment");
            var hasMildRiskOfHarmfulBehaviorsButNoActivePlan = TestContext.GetBoolean("HasMildRiskOfHarmfulBehaviorsButNoActivePlan");
            var hasSevereDysfunctionRequiringStabilization = TestContext.GetBoolean("HasSevereDysfunctionRequiringStabilization");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisCapable = TestContext.GetBoolean("IsDualDiagnosisCapable");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            if (TestContext.GetBoolean("ForDebug"))
            {
                
            }
            
            var dimension3ScoringStrategy = new Dimension3ScoringStrategy();
            var careLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore =
                dimension3ScoringStrategy.
                    CalculateCareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore (
                        withdrawalSymptomsAndEmotionalBehavioralProblems,
                        doesPatientCarryPsychiatricDiagnosis,
                        activePsychiatricDiagnosesOtherThanSubstanceAbuse,
                        howEmotionalProblemsImpactRecoveryEfforts,
                        howImportantPsychologicalEmotionalCounseling,
                        howDifficultProblemsForWorkHomeAndSocialInteraction,
                        globalAssessmentOfFunctioningScore,
                        currentHarmRiskToSelfOthers,
                        riskOfHarmToSelfOrOthersIsHigherWithSubstanceUse,
                        concernAboutEmploymentProblemsInPast30Days,
                        troubledByFamilyProblemsInPast30Days,
                        troubledBySocialProblemsInPast30Days,
                        pastPsychologicalOrEmotionalProblems,
                        significantPeriodTroubleWithAttitudeTowardOthersInLifetime,
                        currentProblemBehaviorsRequireContinuousInterventions,
                        hasSymptomsInHomeEnvironmentRequiringResidentialTreatment,
                        strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers,
                        levelOfSupervisionNeededForProtectionFromSelfHarm,
                        acceptableLevelsOfCare,
                        careLevel_I_OutpatientScoreIsMet,
                        patientNeedForPsychiatricPsychologicalTreatmentRating,
                        appearanceOfTroubleConcentratingOrRemembering,
                        appearanceOfDepressionWithdrawal,
                        appearanceOfHostility,
                        appearanceofAgitation,
                        appearanceOfAnxietyNervousness,
                        appearanceOfParanoiaOrImpairedThinking,
                        appearanceOfLethargy,
                        appearanceOfFluctuatingOrientationInLast24Hours,
                        appearanceOfSpeechImpairmentBadPosture,
                        hasSuicidalThoughts,
                        demonstratingDangerToSelfOrOthers,
                        indicatingRiskOfHarmToOthers,
                        indicatingRiskOfHarmToSelfOrVictimizationByOthers,
                        likelihoodOfRecurrenceOfPsychiatricDecompensation,
                        limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers,
                        significantPeriodThoughtsOfSelfInjuryInLast24Hours,
                        evidenceOfChronicOrganicMentalDisability,
                        currentBehaviorInconsistentWithSelfCare );

            Assert.AreEqual(hasDepressionOrOtherConditionAndNeeds24HourCare, careLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore.HasDepressionOrOtherConditionAndNeeds24HourCare, "HasDepressionOrOtherConditionAndNeeds24HourCare didn't match.");
            Assert.AreEqual(exhibitsViolentBehaviorOnIntoxicationAndIsDangerous, careLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore.ExhibitsViolentBehaviorOnIntoxicationAndIsDangerous, "ExhibitsViolentBehaviorOnIntoxicationAndIsDangerous didn't match.");
            Assert.AreEqual(hasStressDueToRecentLossesThatImpairDailyActivities, careLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore.HasStressDueToRecentLossesThatImpairDailyActivities, "HasStressDueToRecentLossesThatImpairDailyActivities didn't match.");
            Assert.AreEqual(hasSevereConcomitantPersonalityDisorders, careLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore.HasSevereConcomitantPersonalityDisorders, "HasSevereConcomitantPersonalityDisorders didn't match.");
            Assert.AreEqual(hasSevereFunctionalDeficitsRequiringResidentialTreatment, careLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore.HasSevereFunctionalDeficitsRequiringResidentialTreatment, "HasSevereFunctionalDeficitsRequiringResidentialTreatment didn't match.");
            Assert.AreEqual(needsLevelIII_3CareDueToMildHarmRiskAndImminentRelapse, careLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore.NeedsLevelIII_3CareDueToMildHarmRiskAndImminentRelapse, "NeedsLevelIII_3CareDueToMildHarmRiskAndImminentRelapse didn't match.");
            Assert.AreEqual(hasStableMentalStatusToPermitParticipationInTreatment, careLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore.HasStableMentalStatusToPermitParticipationInTreatment, "HasStableMentalStatusToPermitParticipationInTreatment didn't match.");
            Assert.AreEqual(needsStabilizationOfPsychiatricSymptomsAlongWithTreatment, careLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore.NeedsStabilizationOfPsychiatricSymptomsAlongWithTreatment, "NeedsStabilizationOfPsychiatricSymptomsAlongWithTreatment didn't match.");
            Assert.AreEqual(hasMildRiskOfHarmfulBehaviorsButNoActivePlan, careLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore.HasMildRiskOfHarmfulBehaviorsButNoActivePlan, "HasMildRiskOfHarmfulBehaviorsButNoActivePlan didn't match.");
            Assert.AreEqual(hasSevereDysfunctionRequiringStabilization, careLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore.HasSevereDysfunctionRequiringStabilization, "HasSevereDysfunctionRequiringStabilization didn't match.");
            Assert.AreEqual(isDualDiagnosisCapable, careLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore.IsDualDiagnosisCapable, "IsDualDiagnosisCapable didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore.IsMet, "CareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore didn't match.");
        }

        [TestMethod]
        [DataSource("D3_CareLevel_III_5_ClinicallyManagedHighIntensity")]
        public void D3_CalculateCareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScoreTests()
        {
            var currentHarmRiskToSelfOthers = TestContext.GetUInt32("CurrentHarmRiskToSelfOthers");
            var likelihoodPreviousEnvironmentWillInduceSubstanceUse = TestContext.GetLookup<LikertScale>("LikelihoodPreviousEnvironmentWillInduceSubstanceUse");
            var strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers = TestContext.GetLookup<LikertScale>("StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggers");
            var familyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II = TestContext.GetLookup<LikertScale>("FamilyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II");
            var levelOfSupervisionNeededForProtectionFromSelfHarm = new ScaleOf0To8(TestContext.GetUInt32("LevelOfSupervisionNeededForProtectionFromSelfHarm"));
            var numberOfTimesTreatedForAlcoholAbuseLifetime = TestContext.GetUInt32("NumberOfTimesTreatedForAlcoholAbuseLifetime");
            var numberOfTimesDrugTreatmentLifetime = TestContext.GetUInt32("NumberOfTimesDrugTreatmentLifetime");
            var historyOfHarmRiskToSelfOthers = TestContext.GetUInt32("HistoryOfHarmRiskToSelfOthers");
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
            var interviewerScoreOfAttitude =  new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfAttitude"));
            var desireAndExternalFactorsDrivingTreatment = TestContext.GetLookup<DesireAndExternalFactorsDrivingTreatment>("DesireAndExternalFactorsDrivingTreatment");
            var numberOfTimesArrestedForContemptOfCourt = TestContext.GetUInt32("NumberOfTimesArrestedForContemptOfCourt");
            var significantPeriodTroubleWithAttitudeTowardOthersInLifetime = TestContext.GetLookup<LikertScale>("SignificantPeriodTroubleWithAttitudeTowardOthersInLifetime");
            var howDifficultProblemsForWorkHomeAndSocialInteraction = TestContext.GetLookup<ProblemsForWorkHomeAndSocialInteractionScale>("HowDifficultProblemsForWorkHomeAndSocialInteraction");
            var globalAssessmentOfFunctioningScore = TestContext.GetUInt32("GlobalAssessmentOfFunctioningScore");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var freeTimeAffectOnRecovery = TestContext.GetLookup<FreeTimeAffectOnRecovery>("FreeTimeAffectOnRecovery");
            var dealsWithProblemsInFreeTimeThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsInFreeTimeThatRiskRelapse>("DealsWithProblemsInFreeTimeThatRiskRelapse");
            var friendsAffectOnRecovery = TestContext.GetLookup<FriendsAffectOnRecovery>("FriendsAffectOnRecovery");
            var dealsWithProblemsFromFriendsThatRiskRelapse = TestContext.GetLookup<StrategiesToDealWithProblemsFromFriendsThatRiskRelapse>("DealsWithProblemsFromFriendsThatRiskRelapse");
            var closestContactsNeedsAndWillingnessToHelpTreatment = TestContext.GetLookup<NeedsAndWillingnessToHelpTreatment>("ClosestContactsNeedsAndWillingnessToHelpTreatment");
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = TestContext.GetLookups<PsychiatricDiagnosis>("ActivePsychiatricDiagnosesOtherThanSubstanceAbuse");
            var currentProblemBehaviorsRequireContinuousInterventions = TestContext.GetLookup<YesNoNotSure>("CurrentProblemBehaviorsRequireContinuousInterventions");
            var acceptableLevelsOfCare = TestContext.GetLookups<CareLevel>("AcceptableLevelsOfCare");
            var careLevel_I_OutpatientScoreIsMet = TestContext.GetBoolean("CareLevel_I_OutpatientScoreIsMet");
            var significantPeriodOfSeriousDepressionInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodOfSeriousDepressionInLast24Hours");
            var inabilityToFeelPleasureFromActivitiesInLast24Hours = TestContext.GetLookup<LikertScale>("InabilityToFeelPleasureFromActivitiesInLast24Hours");
            var poorAppetiteOrOvereatingInLast24Hours = TestContext.GetLookup<LikertScale>("PoorAppetiteOrOvereatingInLast24Hours");
            var feelLikeFailureInLast24Hours = TestContext.GetLookup<LikertScale>("FeelLikeFailureInLast24Hours");
            var movingSpeakingSlowlyInLast24Hours = TestContext.GetLookup<LikertScale>("MovingSpeakingSlowlyInLast24Hours");
            var anxietyTensionWorryInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyTensionWorryInLast24Hours");
            var anxietyAttackInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackInLast24Hours");
            var anxietyAttackMoreThanOnceInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackMoreThanOnceInLast24Hours");
            var anxietyAttackRandomInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackRandomInLast24Hours");
            var worriedAboutAnxietyAttackInLast24Hours = TestContext.GetLookup<LikertScale>("WorriedAboutAnxietyAttackInLast24Hours");
            var anxietyAttackPalpitationsInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackPalpitationsInLast24Hours");
            var anxietyAttackChestPainsInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackChestPainsInLast24Hours");
            var anxietyAttackShortnessBreathInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackShortnessBreathInLast24Hours");
            var anxietyAttackChokingInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackChokingInLast24Hours");
            var anxietyAttackSweatyInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackSweatyInLast24Hours");
            var anxietyAttackTremblingInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackTremblingInLast24Hours");
            var anxietyAttackNauseaDiarrheaInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackNauseaDiarrheaInLast24Hours");
            var anxietyAttackDizzinessFaintnessInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackDizzinessFaintnessInLast24Hours");
            var anxietyAttackDistortedRealityInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackDistortedRealityInLast24Hours");
            var anxietyAttackNumbnessInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackNumbnessInLast24Hours");
            var anxietyAttackChillsHotFlashesInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackChillsHotFlashesInLast24Hours");
            var anxietyAttackLoseControlInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackLoseControlInLast24Hours");
            var anxietyAttackDyingSensationInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackDyingSensationInLast24Hours");
            var significantPeriodFidgetingInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodFidgetingInLast24Hours");
            var significantPeriodSleepDisorderInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodSleepDisorderInLast24Hours");
            var significantPeriodLethargyInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodLethargyInLast24Hours");
            var significantPeriodMuscleTensionInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodMuscleTensionInLast24Hours");
            var significantPeriodNegativeThoughtsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodNegativeThoughtsInLast24Hours");
            var significantPeriodExcessiveBehaviorInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodExcessiveBehaviorInLast24Hours");
            var significantPeriodParanoiaInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodParanoiaInLast24Hours");
            var significantPeriodUntruePerceptionInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodUntruePerceptionInLast24Hours");
            var significantPeriodHallucinationsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodHallucinationsInLast24Hours");
            var significantPeriodFlashbacksInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodFlashbacksInLast24Hours");
            var significantPeriodImpairedThoughtInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodImpairedThoughtInLast24Hours");
            var significantPeriodIrritabilityInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodIrritabilityInLast24Hours");
            var significantPeriodCurbingViolentBehaviorInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodCurbingViolentBehaviorInLast24Hours");
            var significantPeriodViolentUrgesInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodViolentUrgesInLast24Hours");
            var significantPeriodTroubleWithAttitudeTowardOthersInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodTroubleWithAttitudeTowardOthersInLast24Hours");
            var significantPeriodSuicidalThoughtsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodSuicidalThoughtsInLast24Hours");
            var limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers = new ScaleOf0To8(TestContext.GetUInt32("LimitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers"));


            var hasSevereDysfunctionAndCannotControlBehavior = TestContext.GetBoolean("HasSevereDysfunctionAndCannotControlBehavior");
            var cannotControlDrugUsageAndInImminentDangerOfRelapse = TestContext.GetBoolean("CannotControlDrugUsageAndInImminentDangerOfRelapse");
            var hasCriminalBehaviorAndLackOfRegardForAuthorityOrOthers = TestContext.GetBoolean("HasCriminalBehaviorAndLackOfRegardForAuthorityOrOthers");
            var hasSignificantDeficitsButLikelyResponsiveToResidentialTreatment = TestContext.GetBoolean("HasSignificantDeficitsButLikelyResponsiveToResidentialTreatment");
            var hasConcomitantDisordersRequiringContinuousBoundarySettingCare = TestContext.GetBoolean("HasConcomitantDisordersRequiringContinuousBoundarySettingCare");
            var hasStableMentalStatusPermittingParticipationinTreatment = TestContext.GetBoolean("HasStableMentalStatusPermittingParticipationinTreatment");
            var hasHarmRiskAndRequiresImpulseControlManagement = TestContext.GetBoolean("HasHarmRiskAndRequiresImpulseControlManagement");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisCapable = TestContext.GetBoolean("IsDualDiagnosisCapable");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            if(TestContext.GetBoolean ( "ForDebug" ))
            {

            }
            var dimension3ScoringStrategy = new Dimension3ScoringStrategy();
            var careLevel_III_5_Score = dimension3ScoringStrategy.
                CalculateCareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore (
                    currentHarmRiskToSelfOthers,
                    likelihoodPreviousEnvironmentWillInduceSubstanceUse,
                    strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers,
                    familyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II,
                    levelOfSupervisionNeededForProtectionFromSelfHarm,
                    numberOfTimesTreatedForAlcoholAbuseLifetime,
                    numberOfTimesDrugTreatmentLifetime,
                    historyOfHarmRiskToSelfOthers,
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
                    interviewerScoreOfAttitude,
                    desireAndExternalFactorsDrivingTreatment,
                    numberOfTimesArrestedForContemptOfCourt,
                    significantPeriodTroubleWithAttitudeTowardOthersInLifetime,
                    howDifficultProblemsForWorkHomeAndSocialInteraction,
                    globalAssessmentOfFunctioningScore,
                    livingArrangementAffectOnRecovery,
                    freeTimeAffectOnRecovery,
                    dealsWithProblemsInFreeTimeThatRiskRelapse,
                    friendsAffectOnRecovery,
                    dealsWithProblemsFromFriendsThatRiskRelapse,
                    closestContactsNeedsAndWillingnessToHelpTreatment,
                    activePsychiatricDiagnosesOtherThanSubstanceAbuse,
                    currentProblemBehaviorsRequireContinuousInterventions,
                    acceptableLevelsOfCare,
                    careLevel_I_OutpatientScoreIsMet,
                    significantPeriodOfSeriousDepressionInLast24Hours,
                    inabilityToFeelPleasureFromActivitiesInLast24Hours,
                    poorAppetiteOrOvereatingInLast24Hours,
                    feelLikeFailureInLast24Hours,
                    movingSpeakingSlowlyInLast24Hours,
                    anxietyTensionWorryInLast24Hours,
                    anxietyAttackInLast24Hours,
                    anxietyAttackMoreThanOnceInLast24Hours,
                    anxietyAttackRandomInLast24Hours,
                    worriedAboutAnxietyAttackInLast24Hours,
                    anxietyAttackPalpitationsInLast24Hours,
                    anxietyAttackChestPainsInLast24Hours,
                    anxietyAttackShortnessBreathInLast24Hours,
                    anxietyAttackChokingInLast24Hours,
                    anxietyAttackSweatyInLast24Hours,
                    anxietyAttackTremblingInLast24Hours,
                    anxietyAttackNauseaDiarrheaInLast24Hours,
                    anxietyAttackDizzinessFaintnessInLast24Hours,
                    anxietyAttackDistortedRealityInLast24Hours,
                    anxietyAttackNumbnessInLast24Hours,
                    anxietyAttackChillsHotFlashesInLast24Hours,
                    anxietyAttackLoseControlInLast24Hours,
                    anxietyAttackDyingSensationInLast24Hours,
                    significantPeriodFidgetingInLast24Hours,
                    significantPeriodSleepDisorderInLast24Hours,
                    significantPeriodLethargyInLast24Hours,
                    significantPeriodMuscleTensionInLast24Hours,
                    significantPeriodNegativeThoughtsInLast24Hours,
                    significantPeriodExcessiveBehaviorInLast24Hours,
                    significantPeriodParanoiaInLast24Hours,
                    significantPeriodUntruePerceptionInLast24Hours,
                    significantPeriodHallucinationsInLast24Hours,
                    significantPeriodFlashbacksInLast24Hours,
                    significantPeriodImpairedThoughtInLast24Hours,
                    significantPeriodIrritabilityInLast24Hours,
                    significantPeriodCurbingViolentBehaviorInLast24Hours,
                    significantPeriodViolentUrgesInLast24Hours,
                    significantPeriodTroubleWithAttitudeTowardOthersInLast24Hours,
                    significantPeriodSuicidalThoughtsInLast24Hours,
                    limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers );


            Assert.AreEqual(hasSevereDysfunctionAndCannotControlBehavior, careLevel_III_5_Score.HasSevereDysfunctionAndCannotControlBehavior, "HasSevereDysfunctionAndCannotControlBehavior didn't match.");
            Assert.AreEqual(cannotControlDrugUsageAndInImminentDangerOfRelapse, careLevel_III_5_Score.CannotControlDrugUsageAndInImminentDangerOfRelapse, "CannotControlDrugUsageAndInImminentDangerOfRelapse didn't match.");
            Assert.AreEqual(hasCriminalBehaviorAndLackOfRegardForAuthorityOrOthers, careLevel_III_5_Score.HasCriminalBehaviorAndLackOfRegardForAuthorityOrOthers, "HasCriminalBehaviorAndLackOfRegardForAuthorityOrOthers didn't match.");
            Assert.AreEqual(hasSignificantDeficitsButLikelyResponsiveToResidentialTreatment, careLevel_III_5_Score.HasSignificantDeficitsButLikelyResponsiveToResidentialTreatment, "HasSignificantDeficitsButLikelyResponsiveToResidentialTreatment didn't match.");
            Assert.AreEqual(hasConcomitantDisordersRequiringContinuousBoundarySettingCare, careLevel_III_5_Score.HasConcomitantDisordersRequiringContinuousBoundarySettingCare, "HasConcomitantDisordersRequiringContinuousBoundarySettingCare didn't match.");
            Assert.AreEqual(hasStableMentalStatusPermittingParticipationinTreatment, careLevel_III_5_Score.HasStableMentalStatusPermittingParticipationinTreatment, "HasStableMentalStatusPermittingParticipationinTreatment didn't match.");
            Assert.AreEqual(hasHarmRiskAndRequiresImpulseControlManagement, careLevel_III_5_Score.HasHarmRiskAndRequiresImpulseControlManagement, "HasHarmRiskAndRequiresImpulseControlManagement didn't match.");
            Assert.AreEqual(isDualDiagnosisCapable, careLevel_III_5_Score.IsDualDiagnosisCapable, "IsDualDiagnosisCapable didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_III_5_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_III_5_Score.IsMet, "CareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore didn't match.");
        }
        

        [TestMethod]
        [DataSource("D3_CareLevel_III_7_MedicallyMonitoredIntensive")]
        public void D3_CalculateCareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScorTests()
        {
            var withdrawalSymptomsAndEmotionalBehavioralProblems = TestContext.GetBoolean("WithdrawalSymptomsAndEmotionalBehavioralProblems");
            var doesPatientCarryPsychiatricDiagnosis = TestContext.GetLookup<PatientCarriesPsychiatricDiagnosis>("DoesPatientCarryPsychiatricDiagnosis");
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = TestContext.GetLookups<PsychiatricDiagnosis>("ActivePsychiatricDiagnosesOtherThanSubstanceAbuse");
            var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale>("HowEmotionalProblemsImpactRecoveryEfforts");
            var howImportantPsychologicalEmotionalCounseling = TestContext.GetLookup<PsychologicalEmotionalCounselingImportanceScale>("HowImportantPsychologicalEmotionalCounseling");
            var howDifficultProblemsForWorkHomeAndSocialInteraction = TestContext.GetLookup<ProblemsForWorkHomeAndSocialInteractionScale>("HowDifficultProblemsForWorkHomeAndSocialInteraction");
            var globalAssessmentOfFunctioningScore = TestContext.GetUInt32("GlobalAssessmentOfFunctioningScore");
            var significantPeriodThoughtsOfSelfInjuryInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodThoughtsOfSelfInjuryInLast24Hours");
            var likelihoodOfRecurrenceOfPsychiatricDecompensation = new ScaleOf0To8(TestContext.GetUInt32("LikelihoodOfRecurrenceOfPsychiatricDecompensation"));
            var concernAboutEmploymentProblemsInPast30Days = TestContext.GetLookup<LikertScale>("ConcernAboutEmploymentProblemsInPast30Days");
            var troubledByFamilyProblemsInPast30Days = TestContext.GetLookup<LikertScale>("TroubledByFamilyProblemsInPast30Days");
            var troubledBySocialProblemsInPast30Days = TestContext.GetLookup<LikertScale>("TroubledBySocialProblemsInPast30Days");
            var significantPeriodOfSeriousDepressionInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodOfSeriousDepressionInLast24Hours");
            var inabilityToFeelPleasureFromActivitiesInLast24Hours = TestContext.GetLookup<LikertScale>("InabilityToFeelPleasureFromActivitiesInLast24Hours");
            var poorAppetiteOrOvereatingInLast24Hours = TestContext.GetLookup<LikertScale>("PoorAppetiteOrOvereatingInLast24Hours");
            var feelLikeFailureInLast24Hours = TestContext.GetLookup<LikertScale>("FeelLikeFailureInLast24Hours");
            var movingSpeakingSlowlyInLast24Hours = TestContext.GetLookup<LikertScale>("MovingSpeakingSlowlyInLast24Hours");
            var anxietyTensionWorryInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyTensionWorryInLast24Hours");
            var anxietyAttackInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackInLast24Hours");
            var anxietyAttackMoreThanOnceInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackMoreThanOnceInLast24Hours");
            var anxietyAttackRandomInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackRandomInLast24Hours");
            var worriedAboutAnxietyAttackInLast24Hours = TestContext.GetLookup<LikertScale>("WorriedAboutAnxietyAttackInLast24Hours");
            var anxietyAttackPalpitationsInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackPalpitationsInLast24Hours");
            var anxietyAttackChestPainsInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackChestPainsInLast24Hours");
            var anxietyAttackShortnessBreathInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackShortnessBreathInLast24Hours");
            var anxietyAttackChokingInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackChokingInLast24Hours");
            var anxietyAttackSweatyInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackSweatyInLast24Hours");
            var anxietyAttackTremblingInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackTremblingInLast24Hours");
            var anxietyAttackNauseaDiarrheaInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackNauseaDiarrheaInLast24Hours");
            var anxietyAttackDizzinessFaintnessInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackDizzinessFaintnessInLast24Hours");
            var anxietyAttackDistortedRealityInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackDistortedRealityInLast24Hours");
            var anxietyAttackNumbnessInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackNumbnessInLast24Hours");
            var anxietyAttackChillsHotFlashesInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackChillsHotFlashesInLast24Hours");
            var anxietyAttackLoseControlInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackLoseControlInLast24Hours");
            var anxietyAttackDyingSensationInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyAttackDyingSensationInLast24Hours");
            var significantPeriodFidgetingInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodFidgetingInLast24Hours");
            var significantPeriodSleepDisorderInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodSleepDisorderInLast24Hours");
            var significantPeriodLethargyInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodLethargyInLast24Hours");
            var significantPeriodMuscleTensionInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodMuscleTensionInLast24Hours");
            var significantPeriodNegativeThoughtsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodNegativeThoughtsInLast24Hours");
            var significantPeriodExcessiveBehaviorInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodExcessiveBehaviorInLast24Hours");
            var significantPeriodParanoiaInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodParanoiaInLast24Hours");
            var significantPeriodUntruePerceptionInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodUntruePerceptionInLast24Hours");
            var significantPeriodHallucinationsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodHallucinationsInLast24Hours");
            var significantPeriodFlashbacksInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodFlashbacksInLast24Hours");
            var significantPeriodImpairedThoughtInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodImpairedThoughtInLast24Hours");
            var significantPeriodCurbingViolentBehaviorInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodCurbingViolentBehaviorInLast24Hours");
            var significantPeriodIrritabilityInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodIrritabilityInLast24Hours");
            var significantPeriodViolentUrgesInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodViolentUrgesInLast24Hours");
            var significantPeriodTroubleWithAttitudeTowardOthersInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodTroubleWithAttitudeTowardOthersInLast24Hours");
            var significantPeriodSuicidalThoughtsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodSuicidalThoughtsInLast24Hours");
            var currentHarmRiskToSelfOthers = TestContext.GetUInt32("CurrentHarmRiskToSelfOthers");
            var levelOfSupervisionNeededForProtectionFromSelfHarm = new ScaleOf0To8(TestContext.GetUInt32("LevelOfSupervisionNeededForProtectionFromSelfHarm"));
            var patientAbleToSafelyAccessNeededResources = TestContext.GetBoolean("PatientAbleToSafelyAccessNeededResources");
            var currentBehaviorInconsistentWithSelfCare = TestContext.GetLookup<YesNoNotSure>("CurrentBehaviorInconsistentWithSelfCare");
            var likelihoodPreviousEnvironmentWillInduceSubstanceUse = TestContext.GetLookup<LikertScale>("LikelihoodPreviousEnvironmentWillInduceSubstanceUse");
            var strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers = TestContext.GetLookup<LikertScale>("StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggers");
            var familyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II = TestContext.GetLookup<LikertScale>("FamilyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II");
            var riskOfHarmToSelfOrOthersIsHigherWithSubstanceUse = TestContext.GetLookup<RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse>("RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse");
            var historyOfHarmRiskToSelfOthers = TestContext.GetUInt32("HistoryOfHarmRiskToSelfOthers");
            var significantPeriodCurbingViolentBehaviorRelatedToSubstanceUse = TestContext.GetLookup<RelationToSubstanceUse>("SignificantPeriodCurbingViolentBehaviorRelatedToSubstanceUse");
            var significantPeriodViolentUrgesRelatedToSubstanceUse = TestContext.GetLookup<RelationToSubstanceUse>("SignificantPeriodViolentUrgesRelatedToSubstanceUse");
            var significantPeriodAttemptedSuicideRelatedToSubstanceUse = TestContext.GetLookup<RelationToSubstanceUse>("SignificantPeriodAttemptedSuicideRelatedToSubstanceUse");
            var signsOfIntoxicationExist = TestContext.GetLookup<YesNoNotSure>("SignsOfIntoxicationExist");
            var appearanceOfTroubleConcentratingOrRemembering = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfTroubleConcentratingOrRemembering"));
            var appearanceOfLethargy = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfLethargy"));
            var appearanceOfFluctuatingOrientationInLast24Hours = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfFluctuatingOrientationInLast24Hours"));
            var appearanceOfSpeechImpairmentBadPosture = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfSpeechImpairmentBadPosture"));
            var interviewerObservationOfPatientSenseOfAwareness = TestContext.GetLookup<SenseOfAwareness>("InterviewerObservationOfPatientSenseOfAwareness");
            var observedTactileDisturbances = TestContext.GetLookup<TactileDisturbancesObservation>("ObservedTactileDisturbances");
            var auditoryDisturbanceLevel = TestContext.GetLookup<AuditoryDisturbanceLevel>("AuditoryDisturbanceLevel");
            var visualDisturbanceLevel = TestContext.GetLookup<VisualDisturbanceLevel>("VisualDisturbanceLevel");
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var careLevel_I_OutpatientScoreIsMet = TestContext.GetBoolean("CareLevel_I_OutpatientScoreIsMet");
            var historyOfWithdrawalRelatedSymptoms = TestContext.GetBoolean("HistoryOfWithdrawalRelatedSymptoms");
            var hasAlcoholImminentWithdrawalPotential = TestContext.GetBoolean("HasAlcoholImminentWithdrawalPotential");
            var hasHeroinImminentWithdrawalPotential = TestContext.GetBoolean("HasHeroinImminentWithdrawalPotential");
            var hasMethadoneImminentWithdrawalPotential = TestContext.GetBoolean("HasMethadoneImminentWithdrawalPotential");
            var hasOtherOpiateImminentWithdrawalPotential = TestContext.GetBoolean("HasOtherOpiateImminentWithdrawalPotential");
            var hasBarbiturateImminentWithdrawalPotential = TestContext.GetBoolean("HasBarbiturateImminentWithdrawalPotential");
            var hasOtherSedativeHypnoticImminentWithdrawalPotential = TestContext.GetBoolean("HasOtherSedativeHypnoticImminentWithdrawalPotential");
            var hasCocaineImminentWithdrawalPotential = TestContext.GetBoolean("HasCocaineImminentWithdrawalPotential");
            var hasStimulantImminentWithdrawalPotential = TestContext.GetBoolean("HasStimulantImminentWithdrawalPotential");
            var hasCannabisImminentWithdrawalPotential = TestContext.GetBoolean("HasCannabisImminentWithdrawalPotential");
            var hasHallucinogenImminentWithdrawalPotential = TestContext.GetBoolean("HasHallucinogenImminentWithdrawalPotential");
            var hasInhalantImminentWithdrawalPotential = TestContext.GetBoolean("HasInhalantImminentWithdrawalPotential");
            var hasOtherSubstanceImminentWithdrawalPotential = TestContext.GetBoolean("HasOtherSubstanceImminentWithdrawalPotential");
            var appearanceOfDepressionWithdrawal = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfDepressionWithdrawal"));
            var hasSuicidalThoughts = new ScaleOf0To8(TestContext.GetUInt32("HasSuicidalThoughts"));
            var limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers = new ScaleOf0To8(TestContext.GetUInt32("LimitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers"));
            var howTroubledByPsychologicalEmotionalProblemsLast30Days = TestContext.GetLookup<LikertScale>("HowTroubledByPsychologicalEmotionalProblemsLast30Days");
            var appearanceOfHostility = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfHostility"));
            var appearanceofAgitation = new ScaleOf0To8(TestContext.GetUInt32("AppearanceofAgitation"));
            var appearanceOfAnxietyNervousness = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfAnxietyNervousness"));
            var appearanceOfParanoiaOrImpairedThinking = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfParanoiaOrImpairedThinking"));
            var demonstratingDangerToSelfOrOthers = new ScaleOf0To8(TestContext.GetUInt32("DemonstratingDangerToSelfOrOthers"));
            var indicatingRiskOfHarmToOthers = new ScaleOf0To8(TestContext.GetUInt32("IndicatingRiskOfHarmToOthers"));
            var indicatingRiskOfHarmToSelfOrVictimizationByOthers = new ScaleOf0To8(TestContext.GetUInt32("IndicatingRiskOfHarmToSelfOrVictimizationByOthers"));

            var hasUnstablePsychiatricStateThatInterferesWithRecovery = TestContext.GetBoolean("HasUnstablePsychiatricStateThatInterferesWithRecovery");
            var hasStressDependenceBehaviorRequiresSecureEnvironmentForSelfCare = TestContext.GetBoolean("HasStressDependenceBehaviorRequiresSecureEnvironmentForSelfCare");
            var requiresActivePsychiatricMonitoringForSignificantDeficits = TestContext.GetBoolean("RequiresActivePsychiatricMonitoringForSignificantDeficits");
            var hasModerateRiskOfHarmToSelfOtherAndPropertyAndRelapsePossible = TestContext.GetBoolean("HasModerateRiskOfHarmToSelfOtherAndPropertyAndRelapsePossible");
            var isActivelyIntoxicatedWithViolentBehaviorPosingImminentDanger = TestContext.GetBoolean("IsActivelyIntoxicatedWithViolentBehaviorPosingImminentDanger");
            var hasCognitiveProblemsRequiringStabilizationButNoMedicalManagement = TestContext.GetBoolean("HasCognitiveProblemsRequiringStabilizationButNoMedicalManagement");
            var hasHistoryOfAndNowHasModerateDecompensationFromStoppingDrugs = TestContext.GetBoolean("HasHistoryOfAndNowHasModerateDecompensationFromStoppingDrugs");
            var hasModerateToHighHarmRiskAndImminentRelapseDanger = TestContext.GetBoolean("HasModerateToHighHarmRiskAndImminentRelapseDanger");
            var hasSuicidalImpulsesAndPlanButDoesNotNeedOneOnOneSuicideWatch = TestContext.GetBoolean("HasSuicidalImpulsesAndPlanButDoesNotNeedOneOnOneSuicideWatch");
            var hasCoOccurringPsychiatricDisorderAndNeedsPsychotropicMeds = TestContext.GetBoolean("HasCoOccurringPsychiatricDisorderAndNeedsPsychotropicMeds");
            var hasSevereCoOccurringDisorderAndNeedsIntegratedDualTreatment = TestContext.GetBoolean("HasSevereCoOccurringDisorderAndNeedsIntegratedDualTreatment");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisCapable = TestContext.GetBoolean("IsDualDiagnosisCapable");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            if(TestContext.GetBoolean ( "ForDebug" ))
            {
                
            }

            var dimension3ScoringStrategy = new Dimension3ScoringStrategy();
            var careLevel_III_7_Score = dimension3ScoringStrategy.
                CalculateCareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScore (
                    withdrawalSymptomsAndEmotionalBehavioralProblems,
                    doesPatientCarryPsychiatricDiagnosis,
                    activePsychiatricDiagnosesOtherThanSubstanceAbuse,
                    howEmotionalProblemsImpactRecoveryEfforts,
                    howImportantPsychologicalEmotionalCounseling,
                    howDifficultProblemsForWorkHomeAndSocialInteraction,
                    globalAssessmentOfFunctioningScore,
                    significantPeriodThoughtsOfSelfInjuryInLast24Hours,
                    likelihoodOfRecurrenceOfPsychiatricDecompensation,
                    concernAboutEmploymentProblemsInPast30Days,
                    troubledByFamilyProblemsInPast30Days,
                    troubledBySocialProblemsInPast30Days,
                    significantPeriodOfSeriousDepressionInLast24Hours,
                    inabilityToFeelPleasureFromActivitiesInLast24Hours,
                    poorAppetiteOrOvereatingInLast24Hours,
                    feelLikeFailureInLast24Hours,
                    movingSpeakingSlowlyInLast24Hours,
                    anxietyTensionWorryInLast24Hours,
                    anxietyAttackInLast24Hours,
                    anxietyAttackMoreThanOnceInLast24Hours,
                    anxietyAttackRandomInLast24Hours,
                    worriedAboutAnxietyAttackInLast24Hours,
                    anxietyAttackPalpitationsInLast24Hours,
                    anxietyAttackChestPainsInLast24Hours,
                    anxietyAttackShortnessBreathInLast24Hours,
                    anxietyAttackChokingInLast24Hours,
                    anxietyAttackSweatyInLast24Hours,
                    anxietyAttackTremblingInLast24Hours,
                    anxietyAttackNauseaDiarrheaInLast24Hours,
                    anxietyAttackDizzinessFaintnessInLast24Hours,
                    anxietyAttackDistortedRealityInLast24Hours,
                    anxietyAttackNumbnessInLast24Hours,
                    anxietyAttackChillsHotFlashesInLast24Hours,
                    anxietyAttackLoseControlInLast24Hours,
                    anxietyAttackDyingSensationInLast24Hours,
                    significantPeriodFidgetingInLast24Hours,
                    significantPeriodSleepDisorderInLast24Hours,
                    significantPeriodLethargyInLast24Hours,
                    significantPeriodMuscleTensionInLast24Hours,
                    significantPeriodNegativeThoughtsInLast24Hours,
                    significantPeriodExcessiveBehaviorInLast24Hours,
                    significantPeriodParanoiaInLast24Hours,
                    significantPeriodUntruePerceptionInLast24Hours,
                    significantPeriodHallucinationsInLast24Hours,
                    significantPeriodFlashbacksInLast24Hours,
                    significantPeriodImpairedThoughtInLast24Hours,
                    significantPeriodCurbingViolentBehaviorInLast24Hours,
                    significantPeriodIrritabilityInLast24Hours,
                    significantPeriodViolentUrgesInLast24Hours,
                    significantPeriodTroubleWithAttitudeTowardOthersInLast24Hours,
                    significantPeriodSuicidalThoughtsInLast24Hours,
                    currentHarmRiskToSelfOthers,
                    levelOfSupervisionNeededForProtectionFromSelfHarm,
                    patientAbleToSafelyAccessNeededResources,
                    currentBehaviorInconsistentWithSelfCare,
                    likelihoodPreviousEnvironmentWillInduceSubstanceUse,
                    strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers,
                    familyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II,
                    riskOfHarmToSelfOrOthersIsHigherWithSubstanceUse,
                    historyOfHarmRiskToSelfOthers,
                    significantPeriodCurbingViolentBehaviorRelatedToSubstanceUse,
                    significantPeriodViolentUrgesRelatedToSubstanceUse,
                    significantPeriodAttemptedSuicideRelatedToSubstanceUse,
                    signsOfIntoxicationExist,
                    appearanceOfTroubleConcentratingOrRemembering,
                    appearanceOfLethargy,
                    appearanceOfFluctuatingOrientationInLast24Hours,
                    appearanceOfSpeechImpairmentBadPosture,
                    interviewerObservationOfPatientSenseOfAwareness,
                    observedTactileDisturbances,
                    auditoryDisturbanceLevel,
                    visualDisturbanceLevel,
                    patientNeedForPsychiatricPsychologicalTreatmentRating,
                    careLevel_I_OutpatientScoreIsMet,
                    historyOfWithdrawalRelatedSymptoms,
                    hasAlcoholImminentWithdrawalPotential,
                    hasHeroinImminentWithdrawalPotential,
                    hasMethadoneImminentWithdrawalPotential,
                    hasOtherOpiateImminentWithdrawalPotential,
                    hasBarbiturateImminentWithdrawalPotential,
                    hasOtherSedativeHypnoticImminentWithdrawalPotential,
                    hasCocaineImminentWithdrawalPotential,
                    hasStimulantImminentWithdrawalPotential,
                    hasCannabisImminentWithdrawalPotential,
                    hasHallucinogenImminentWithdrawalPotential,
                    hasInhalantImminentWithdrawalPotential,
                    hasOtherSubstanceImminentWithdrawalPotential,
                    appearanceOfDepressionWithdrawal,
                    hasSuicidalThoughts,
                    limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers,
                    howTroubledByPsychologicalEmotionalProblemsLast30Days,
                    appearanceOfHostility,
                    appearanceofAgitation,
                    appearanceOfAnxietyNervousness,
                    appearanceOfParanoiaOrImpairedThinking,
                    demonstratingDangerToSelfOrOthers,
                    indicatingRiskOfHarmToOthers,
                    indicatingRiskOfHarmToSelfOrVictimizationByOthers );


            Assert.AreEqual(hasUnstablePsychiatricStateThatInterferesWithRecovery, careLevel_III_7_Score.HasUnstablePsychiatricStateThatInterferesWithRecovery, "HasUnstablePsychiatricStateThatInterferesWithRecovery didn't match.");
            Assert.AreEqual(hasStressDependenceBehaviorRequiresSecureEnvironmentForSelfCare, careLevel_III_7_Score.HasStressDependenceBehaviorRequiresSecureEnvironmentForSelfCare, "HasStressDependenceBehaviorRequiresSecureEnvironmentForSelfCare didn't match.");
            Assert.AreEqual(requiresActivePsychiatricMonitoringForSignificantDeficits, careLevel_III_7_Score.RequiresActivePsychiatricMonitoringForSignificantDeficits, "RequiresActivePsychiatricMonitoringForSignificantDeficits didn't match.");
            Assert.AreEqual(hasModerateRiskOfHarmToSelfOtherAndPropertyAndRelapsePossible, careLevel_III_7_Score.HasModerateRiskOfHarmToSelfOtherAndPropertyAndRelapsePossible, "HasModerateRiskOfHarmToSelfOtherAndPropertyAndRelapsePossible didn't match.");
            Assert.AreEqual(isActivelyIntoxicatedWithViolentBehaviorPosingImminentDanger, careLevel_III_7_Score.IsActivelyIntoxicatedWithViolentBehaviorPosingImminentDanger, "IsActivelyIntoxicatedWithViolentBehaviorPosingImminentDanger didn't match.");
            Assert.AreEqual(hasCognitiveProblemsRequiringStabilizationButNoMedicalManagement, careLevel_III_7_Score.HasCognitiveProblemsRequiringStabilizationButNoMedicalManagement, "HasCognitiveProblemsRequiringStabilizationButNoMedicalManagement didn't match.");
            Assert.AreEqual(hasHistoryOfAndNowHasModerateDecompensationFromStoppingDrugs, careLevel_III_7_Score.HasHistoryOfAndNowHasModerateDecompensationFromStoppingDrugs, "HasHistoryOfAndNowHasModerateDecompensationFromStoppingDrugs didn't match.");
            Assert.AreEqual(hasModerateToHighHarmRiskAndImminentRelapseDanger, careLevel_III_7_Score.HasModerateToHighHarmRiskAndImminentRelapseDanger, "HasModerateToHighHarmRiskAndImminentRelapseDanger didn't match.");
            Assert.AreEqual(hasSuicidalImpulsesAndPlanButDoesNotNeedOneOnOneSuicideWatch, careLevel_III_7_Score.HasSuicidalImpulsesAndPlanButDoesNotNeedOneOnOneSuicideWatch, "HasSuicidalImpulsesAndPlanButDoesNotNeedOneOnOneSuicideWatch didn't match.");
            Assert.AreEqual(hasCoOccurringPsychiatricDisorderAndNeedsPsychotropicMeds, careLevel_III_7_Score.HasCoOccurringPsychiatricDisorderAndNeedsPsychotropicMeds, "HasCoOccurringPsychiatricDisorderAndNeedsPsychotropicMeds didn't match.");
            Assert.AreEqual(hasSevereCoOccurringDisorderAndNeedsIntegratedDualTreatment, careLevel_III_7_Score.HasSevereCoOccurringDisorderAndNeedsIntegratedDualTreatment, "HasSevereCoOccurringDisorderAndNeedsIntegratedDualTreatment didn't match.");
            Assert.AreEqual(isDualDiagnosisCapable, careLevel_III_7_Score.IsDualDiagnosisCapable, "IsDualDiagnosisCapable didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_III_7_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isMet, careLevel_III_7_Score.IsMet, "CareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore didn't match.");
        }


        [TestMethod]
        [DataSource("D3_CareLevel_IV_MedicallyManagedIntensiveInpatient")]
        public void D3_CalculatecareLevel_IV_ScoreTests()
        {
            var significantPeriodOfSeriousDepressionInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodOfSeriousDepressionInLast24Hours");
            var anxietyTensionWorryInLast24Hours = TestContext.GetLookup<LikertScale>("AnxietyTensionWorryInLast24Hours");
            var significantPeriodNegativeThoughtsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodNegativeThoughtsInLast24Hours");
            var significantPeriodParanoiaInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodParanoiaInLast24Hours");
            var significantPeriodUntruePerceptionInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodUntruePerceptionInLast24Hours");
            var significantPeriodHallucinationsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodHallucinationsInLast24Hours");
            var significantPeriodImpairedThoughtInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodImpairedThoughtInLast24Hours");
            var significantPeriodCurbingViolentBehaviorInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodCurbingViolentBehaviorInLast24Hours");
            var significantPeriodViolentUrgesInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodViolentUrgesInLast24Hours");
            var significantPeriodSuicidalThoughtsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodSuicidalThoughtsInLast24Hours");
            var significantPeriodAttemptedSuicideInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodAttemptedSuicideInLast24Hours");
            var significantPeriodThoughtsOfSelfInjuryInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodThoughtsOfSelfInjuryInLast24Hours");
            var howTroubledByPsychologicalEmotionalProblemsLast30Days = TestContext.GetLookup<LikertScale>("HowTroubledByPsychologicalEmotionalProblemsLast30Days");
            var howEmotionalProblemsImpactRecoveryEfforts = TestContext.GetLookup<EmotionalProblemsImpactRecoveryEffortsScale>("HowEmotionalProblemsImpactRecoveryEfforts");
            var appearanceOfDepressionWithdrawal = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfDepressionWithdrawal"));
            var appearanceOfHostility = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfHostility"));
            var appearanceofAgitation = new ScaleOf0To8(TestContext.GetUInt32("AppearanceofAgitation"));
            var appearanceOfAnxietyNervousness = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfAnxietyNervousness"));
            var appearanceOfParanoiaOrImpairedThinking = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfParanoiaOrImpairedThinking"));
            var appearanceOfTroubleConcentratingOrRemembering = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfTroubleConcentratingOrRemembering"));
            var appearanceOfLethargy = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfLethargy"));
            var appearanceOfFluctuatingOrientationInLast24Hours = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfFluctuatingOrientationInLast24Hours"));
            var appearanceOfSpeechImpairmentBadPosture = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfSpeechImpairmentBadPosture"));
            var hasSuicidalThoughts = new ScaleOf0To8(TestContext.GetUInt32("HasSuicidalThoughts"));
            var demonstratingDangerToSelfOrOthers = new ScaleOf0To8(TestContext.GetUInt32("DemonstratingDangerToSelfOrOthers"));
            var limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers = new ScaleOf0To8(TestContext.GetUInt32("LimitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers"));
            var indicatingRiskOfHarmToOthers = new ScaleOf0To8(TestContext.GetUInt32("IndicatingRiskOfHarmToOthers"));
            var indicatingRiskOfHarmToSelfOrVictimizationByOthers = new ScaleOf0To8(TestContext.GetUInt32("IndicatingRiskOfHarmToSelfOrVictimizationByOthers"));
            var likelihoodOfRecurrenceOfPsychiatricDecompensation = new ScaleOf0To8(TestContext.GetUInt32("LikelihoodOfRecurrenceOfPsychiatricDecompensation"));
            var levelOfSupervisionNeededForProtectionFromSelfHarm = new ScaleOf0To8(TestContext.GetUInt32("LevelOfSupervisionNeededForProtectionFromSelfHarm"));
            var patientNeedForPsychiatricPsychologicalTreatmentRating = new ScaleOf0To8(TestContext.GetUInt32("PatientNeedForPsychiatricPsychologicalTreatmentRating"));
            var detoxificationRequiredMoreThanHourlyMonitoring = TestContext.GetBoolean("DetoxificationRequiredMoreThanHourlyMonitoring");
            var acceptableLevelsOfCare = TestContext.GetLookups<CareLevel>("AcceptableLevelsOfCare");
            var currentHarmRiskToSelfOthers = TestContext.GetUInt32("CurrentHarmRiskToSelfOthers");
            var globalAssessmentOfFunctioningScore = TestContext.GetUInt32("GlobalAssessmentOfFunctioningScore");
            var isPatientUnableToUnderstand = TestContext.GetLookup<YesNoNotSure>("IsPatientUnableToUnderstand");
            var signsOfToxicPsychosisExist = TestContext.GetLookup<YesNoNotSure>("SignsOfToxicPsychosisExist");
            var sufferedHeadTraumaInPast48Hours = TestContext.GetLookup<YesNoNotSure>("SufferedHeadTraumaInPast48Hours");
            var interviewerObservationOfPatientSenseOfAwareness = TestContext.GetLookup<SenseOfAwareness>("InterviewerObservationOfPatientSenseOfAwareness");
            var hasImmediateMajorDepressionDisorder = TestContext.GetBoolean("HasImmediateMajorDepressionDisorder");
            var hasImmediateOtherDepressionDisorder = TestContext.GetBoolean("HasImmediateOtherDepressionDisorder");
            var doesPatientCarryPsychiatricDiagnosis = TestContext.GetLookup<PatientCarriesPsychiatricDiagnosis>("DoesPatientCarryPsychiatricDiagnosis");
            var activePsychiatricDiagnosesOtherThanSubstanceAbuse = TestContext.GetLookups<PsychiatricDiagnosis>("ActivePsychiatricDiagnosesOtherThanSubstanceAbuse");
            var hasEverUsedAlcohol = TestContext.GetBoolean("HasEverUsedAlcohol");
            var lastUsedAlcohol = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedAlcohol"));
            var alcoholUsedToIntoxication = TestContext.GetBoolean("AlcoholUsedToIntoxication");
            var lastUsedToIntoxification = new TimeMeasure ( UnitOfTime.Months, TestContext.GetUInt32("LastUsedToIntoxification"));
            var hasEverUsedHeroin = TestContext.GetBoolean("HasEverUsedHeroin");
            var lastUsedHeroin = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedHeroin"));
            var hasEverUsedMethadone = TestContext.GetBoolean("HasEverUsedMethadone");
            var lastUsedMehtadone = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedMehtadone"));
            var hasEverUsedOtherOpiate = TestContext.GetBoolean("HasEverUsedOtherOpiate");
            var lastUsedOtherOpiate = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedOtherOpiate"));
            var hasEverUsedBarbiturate = TestContext.GetBoolean("HasEverUsedBarbiturate");
            var lastUsedBarbiturate = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedBarbiturate"));
            var hasEverUsedOtherSedative = TestContext.GetBoolean("HasEverUsedOtherSedative");
            var lastUsedOtherSedative = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedOtherSedative"));
            var hasEverUsedCocaine = TestContext.GetBoolean("HasEverUsedCocaine");
            var lastUsedCocaine = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedCocaine"));
            var hasEverUsedStimulant = TestContext.GetBoolean("HasEverUsedStimulant");
            var lastUsedStimulant = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedStimulant"));
            var hasEverUsedCannabis = TestContext.GetBoolean("HasEverUsedCannabis");
            var lastUsedCannabis = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedCannabis"));
            var hasEverUsedHallucinogen = TestContext.GetBoolean("HasEverUsedHallucinogen");
            var lastUsedHallucinogen = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedHallucinogen"));
            var hasEverUsedSolventAndInhalant = TestContext.GetBoolean("HasEverUsedSolventAndInhalant");
            var lastUsedSolventAndInhalant = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedSolventAndInhalant"));
            var observedTactileDisturbances = TestContext.GetLookup<TactileDisturbancesObservation>("ObservedTactileDisturbances");
            var auditoryDisturbanceLevel = TestContext.GetLookup<AuditoryDisturbanceLevel>("AuditoryDisturbanceLevel");
            var visualDisturbanceLevel = TestContext.GetLookup<VisualDisturbanceLevel>("VisualDisturbanceLevel");


            var hasEmotionalBehavioralComplicationsOfAddictiveDisorder = TestContext.GetBoolean("HasEmotionalBehavioralComplicationsOfAddictiveDisorder");
            var hasConcurrentEmotionalBehavioralIllnessNeedingDailyStabilization = TestContext.GetBoolean("HasConcurrentEmotionalBehavioralIllnessNeedingDailyStabilization");
            var exhibitsBehaviorPosingImminentDangerToSelfOrOthers = TestContext.GetBoolean("ExhibitsBehaviorPosingImminentDangerToSelfOrOthers");
            var hasMentalConfusionPosingImminentDangerToSelfOrOthers = TestContext.GetBoolean("HasMentalConfusionPosingImminentDangerToSelfOrOthers");
            var hasCoexistingSeriousDisorderRequiringDifferentialDiagnosis = TestContext.GetBoolean("HasCoexistingSeriousDisorderRequiringDifferentialDiagnosis");
            var hasExtremeDepressionPosingImminentRiskToPersonalSafety = TestContext.GetBoolean("HasExtremeDepressionPosingImminentRiskToPersonalSafety");
            var hasImpairedThoughtAndDailyLifePosesRiskToPersonalSafety = TestContext.GetBoolean("HasImpairedThoughtAndDailyLifePosesRiskToPersonalSafety");
            var useOfAlcoholOrDrugsCausesComplicationsOfPreviousEmotionalProblems = TestContext.GetBoolean("UseOfAlcoholOrDrugsCausesComplicationsOfPreviousEmotional");
            var isExperiencingAlteredMentalStatus = TestContext.GetBoolean("IsExperiencingAlteredMentalStatus");
            //var isMet = TestContext.GetBoolean("IsMet");
            //var isDualDiagnosisCapable = TestContext.GetBoolean("IsDualDiagnosisCapable");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");


            if(TestContext.GetBoolean ( "ForDebug" ))
            {
                
            }

            var dimension3ScoringStrategy = new Dimension3ScoringStrategy();
            var careLevel_IV_Score = dimension3ScoringStrategy.CalculateCareLevel_IV_MedicallyManagedIntensiveInpatientTreatmentScore ( 
                    significantPeriodOfSeriousDepressionInLast24Hours,
                    anxietyTensionWorryInLast24Hours,
                    significantPeriodNegativeThoughtsInLast24Hours,
                    significantPeriodParanoiaInLast24Hours,
                    significantPeriodUntruePerceptionInLast24Hours,
                    significantPeriodHallucinationsInLast24Hours,
                    significantPeriodImpairedThoughtInLast24Hours,
                    significantPeriodCurbingViolentBehaviorInLast24Hours,
                    significantPeriodViolentUrgesInLast24Hours,
                    significantPeriodSuicidalThoughtsInLast24Hours,
                    significantPeriodAttemptedSuicideInLast24Hours,
                    significantPeriodThoughtsOfSelfInjuryInLast24Hours,
                    howTroubledByPsychologicalEmotionalProblemsLast30Days,
                    howEmotionalProblemsImpactRecoveryEfforts,
                    appearanceOfDepressionWithdrawal,
                    appearanceOfHostility,
                    appearanceofAgitation,
                    appearanceOfAnxietyNervousness,
                    appearanceOfParanoiaOrImpairedThinking,
                    appearanceOfTroubleConcentratingOrRemembering,
                    appearanceOfLethargy,
                    appearanceOfFluctuatingOrientationInLast24Hours,
                    appearanceOfSpeechImpairmentBadPosture,
                    hasSuicidalThoughts,
                    demonstratingDangerToSelfOrOthers,
                    limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers,
                    indicatingRiskOfHarmToOthers,
                    indicatingRiskOfHarmToSelfOrVictimizationByOthers,
                    likelihoodOfRecurrenceOfPsychiatricDecompensation,
                    levelOfSupervisionNeededForProtectionFromSelfHarm,
                    patientNeedForPsychiatricPsychologicalTreatmentRating,
                    detoxificationRequiredMoreThanHourlyMonitoring,
                    acceptableLevelsOfCare,
                    currentHarmRiskToSelfOthers,
                    globalAssessmentOfFunctioningScore,
                    isPatientUnableToUnderstand,
                    signsOfToxicPsychosisExist,
                    sufferedHeadTraumaInPast48Hours,
                    interviewerObservationOfPatientSenseOfAwareness,
                    hasImmediateMajorDepressionDisorder,
                    hasImmediateOtherDepressionDisorder,
                    doesPatientCarryPsychiatricDiagnosis,
                    activePsychiatricDiagnosesOtherThanSubstanceAbuse,
                    hasEverUsedAlcohol,
                    lastUsedAlcohol,
                    alcoholUsedToIntoxication,
                    lastUsedToIntoxification,
                    hasEverUsedHeroin,
                    lastUsedHeroin,
                    hasEverUsedMethadone,
                    lastUsedMehtadone,
                    hasEverUsedOtherOpiate,
                    lastUsedOtherOpiate,
                    hasEverUsedBarbiturate,
                    lastUsedBarbiturate,
                    hasEverUsedOtherSedative,
                    lastUsedOtherSedative,
                    hasEverUsedCocaine,
                    lastUsedCocaine,
                    hasEverUsedStimulant,
                    lastUsedStimulant,
                    hasEverUsedCannabis,
                    lastUsedCannabis,
                    hasEverUsedHallucinogen,
                    lastUsedHallucinogen,
                    hasEverUsedSolventAndInhalant,
                    lastUsedSolventAndInhalant,
                    observedTactileDisturbances,
                    auditoryDisturbanceLevel,
                    visualDisturbanceLevel );

            Assert.AreEqual(hasEmotionalBehavioralComplicationsOfAddictiveDisorder, careLevel_IV_Score.HasEmotionalBehavioralComplicationsOfAddictiveDisorder, "HasEmotionalBehavioralComplicationsOfAddictiveDisorder didn't match.");
            Assert.AreEqual(hasConcurrentEmotionalBehavioralIllnessNeedingDailyStabilization, careLevel_IV_Score.HasConcurrentEmotionalBehavioralIllnessNeedingDailyStabilization, "HasConcurrentEmotionalBehavioralIllnessNeedingDailyStabilization didn't match.");
            Assert.AreEqual(exhibitsBehaviorPosingImminentDangerToSelfOrOthers, careLevel_IV_Score.ExhibitsBehaviorPosingImminentDangerToSelfOrOthers, "ExhibitsBehaviorPosingImminentDangerToSelfOrOthers didn't match.");
            Assert.AreEqual(hasMentalConfusionPosingImminentDangerToSelfOrOthers, careLevel_IV_Score.HasMentalConfusionPosingImminentDangerToSelfOrOthers, "HasMentalConfusionPosingImminentDangerToSelfOrOthers didn't match.");
            Assert.AreEqual(hasCoexistingSeriousDisorderRequiringDifferentialDiagnosis, careLevel_IV_Score.HasCoexistingSeriousDisorderRequiringDifferentialDiagnosis, "HasCoexistingSeriousDisorderRequiringDifferentialDiagnosis didn't match.");
            Assert.AreEqual(hasExtremeDepressionPosingImminentRiskToPersonalSafety, careLevel_IV_Score.HasExtremeDepressionPosingImminentRiskToPersonalSafety, "HasExtremeDepressionPosingImminentRiskToPersonalSafety didn't match.");
            Assert.AreEqual(hasImpairedThoughtAndDailyLifePosesRiskToPersonalSafety, careLevel_IV_Score.HasImpairedThoughtAndDailyLifePosesRiskToPersonalSafety, "HasImpairedThoughtAndDailyLifePosesRiskToPersonalSafety didn't match.");
            Assert.AreEqual(useOfAlcoholOrDrugsCausesComplicationsOfPreviousEmotionalProblems, careLevel_IV_Score.UseOfAlcoholOrDrugsCausesComplicationsOfPreviousEmotionalProblems, "UseOfAlcoholOrDrugsCausesComplicationsOfPreviousEmotionalProblems didn't match.");
            Assert.AreEqual(isExperiencingAlteredMentalStatus, careLevel_IV_Score.IsExperiencingAlteredMentalStatus, "IsExperiencingAlteredMentalStatus didn't match.");
            //Assert.AreEqual(isDualDiagnosisCapable, careLevel_IV_Score.IsDualDiagnosisCapable, "IsDualDiagnosisCapable didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_IV_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            //Assert.AreEqual(isMet, careLevel_IV_Score.IsMet, "careLevel_IV_Score didn't match.");
        }

        #endregion
    }
}
