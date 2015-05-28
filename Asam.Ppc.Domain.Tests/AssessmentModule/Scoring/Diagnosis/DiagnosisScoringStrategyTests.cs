using System;
using System.Linq;
using System.Text;
using Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol;
using Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups;
using Asam.Ppc.Domain.AssessmentModule.Medical;
using Asam.Ppc.Domain.AssessmentModule.Psychological;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.CommonModule.ValueObjects;
using Asam.Ppc.Domain.Scoring.ScoringModule;
using Asam.Ppc.Domain.Scoring.ScoringModule.Diagnosis;
using Asam.Ppc.Domain.Tests.Extensions;
using Asam.Ppc.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Asam.Ppc.Domain.Tests.AssessmentModule.Scoring.Diagnosis
{
    [TestClass]
    public class DiagnosisScoringStrategyTests : BaseMockAssessmentAndMockAssessmentScoreTest
    {
        #region Public Properties

        public TestContext TestContext { get; set; }

        #endregion

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Dx_CalculateChemicalUseAbuseAndDependenceScaleScoreSum_ShortArguments_ExpectException()
        {
            var cuadScales = new bool?[]
                {
                    null,
                    true,
                    false
                };
            SubstanceScoreCalculator.CalculateChemicalUseAbuseAndDependenceScaleScoreSum ( cuadScales );
        }

        [TestMethod]
        public void Dx_CalculateChemicalUseAbuseAndDependenceScaleScoreSum_ValidArguments_Match ()
        {
            var cuadScales = new bool?[]
                {
                    null, null, null, null, null, null, null,
                    true, true, true, true, true, true,
                    false, false, false, false, false, false
                };
            var result = SubstanceScoreCalculator.CalculateChemicalUseAbuseAndDependenceScaleScoreSum(cuadScales);

            Assert.AreEqual ( 6, result, "CUAD Score Sum didn't match. " );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Dx_CalculateMultipelPerDayUse_ShortArguments_ExpectException()
        {
            var substanceUses = new ISubstanceUse[]
                {
                    new NicotineUse ( ), 
                    new AlcoholUse ( ), 
                    new HeroinUse ( )
                };
            SubstanceScoreCalculator.CalculateMultipelPerDayUse(substanceUses);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Dx_CalculateMinimumDaysSinceLastUsedDrugExceptNicotine_ShortArguments_ExpectException()
        {
            var substanceUseHistorys = new []
                {
                    new SubstanceUseHistory(null, new TimeMeasure ( UnitOfTime.Days,  0))
                };
            SubstanceScoreCalculator.CalculateMinimumDaysSinceLastUsedDrugExceptNicotineInternal(substanceUseHistorys);
        }

        [TestMethod]
        public void Dx_CalculateMinimumDaysSinceLastUsedDrugExceptNicotine_ValidArguments_Match()
        {
            var substanceUseHistorys = new[]
                {
                    new SubstanceUseHistory ( null, new TimeMeasure ( UnitOfTime.Hours, 0 ) ),
                    new SubstanceUseHistory ( true, new TimeMeasure ( UnitOfTime.Months, 1 ) ),
                    new SubstanceUseHistory ( true, new TimeMeasure ( UnitOfTime.Days, 7 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( true, new TimeMeasure ( UnitOfTime.Years, 1 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) )
                };
            var result = SubstanceScoreCalculator.CalculateMinimumDaysSinceLastUsedDrugExceptNicotineInternal(substanceUseHistorys);

            Assert.AreEqual(7, result, "MinimumDaysSinceLastUsedDrugExceptNicotine didn't match.");
        }

        [TestMethod]
        public void Dx_CalculateMinimumDaysSinceLastUsedDrugExceptNicotine_NeverUsed_ReturnMaxValue()
        {
            var substanceUseHistorys = new[]
                {
                    new SubstanceUseHistory ( null, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 1 ) ),
                    new SubstanceUseHistory ( null, new TimeMeasure ( UnitOfTime.Days, 7 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 12 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) ),
                    new SubstanceUseHistory ( false, new TimeMeasure ( UnitOfTime.Months, 0 ) )
                };
            var result = SubstanceScoreCalculator.CalculateMinimumDaysSinceLastUsedDrugExceptNicotineInternal(substanceUseHistorys);

            Assert.AreEqual(double.MaxValue, result, "MinimumDaysSinceLastUsedDrugExceptNicotine didn't match.");
        }
        

        [TestMethod]
        public void Dx_CalculateWhichSubstanceEveUsedTests()
        {
            var usedSubstances = new[]
                {
                    SubstanceCategory.Alcohol,
                    SubstanceCategory.Nicotine,
                    SubstanceCategory.Hallucinogens
                };

            var whichSubstanceEverUsed = Utilities.CalculateWhichSubstanceEverUsed(usedSubstances);

            Assert.IsTrue(whichSubstanceEverUsed.HasEverUsedAlcohol);
            Assert.IsTrue(whichSubstanceEverUsed.HasEverUsedNicotine);
            Assert.IsTrue(whichSubstanceEverUsed.HasEverUsedHallucinogens);

            Assert.IsFalse(whichSubstanceEverUsed.HasEverUsedHeroin);
            Assert.IsFalse(whichSubstanceEverUsed.HasEverUsedMethadone);
            Assert.IsFalse(whichSubstanceEverUsed.HasEverUsedOtherOpiate);
            Assert.IsFalse(whichSubstanceEverUsed.HasEverUsedBarbiturates);
            Assert.IsFalse(whichSubstanceEverUsed.HasEverUsedOtherSedatives);
            Assert.IsFalse(whichSubstanceEverUsed.HasEverUsedCocaine);
            Assert.IsFalse(whichSubstanceEverUsed.HasEverUsedStimulate);
            Assert.IsFalse(whichSubstanceEverUsed.HasEverUsedCannabis);
            Assert.IsFalse(whichSubstanceEverUsed.HasEverUsedSolventInhalants);
            Assert.IsFalse(whichSubstanceEverUsed.HasEverUsedMultipleSubstancesPerDay);
            Assert.IsFalse(whichSubstanceEverUsed.HasEverUsedOtherSubstance);
        }

        [TestMethod]
        public void Dx_CalculateCommonScoresStages2_ValuesAreSet()
        {
            var assessmentMock = AssessmentMock;
            var dxCommonScores = new CommonScores ()
                {
                    WhichSubstenceEverUsed = new WhichSubstenceEverUsed ()
                };
            var diagnosisResults = new Mock<DiagnosisResults>();
            diagnosisResults.SetupGet(p => p.CommonScores).Returns(dxCommonScores);
            var assessmentScoreMock = AssessmentScoreMock;
            assessmentScoreMock.SetupGet(p => p.DiagnosisResults).Returns(diagnosisResults.Object);

            assessmentMock.SetupGet(p => p.DrugAndAlcoholSection).Returns(new DrugAndAlcoholSection());
            var intValue = new Random().Next(1, 100);
            
            var substanceScoreCalculatorMock = new Mock<ISubstanceScoreCalculator>();
            substanceScoreCalculatorMock.Setup(p => p.CalculateMinimumDaysSinceLastUsedDrugExceptNicotine(It.IsAny<SubstanceUseHistory[]>())).Returns(intValue);
            substanceScoreCalculatorMock.Setup(p => p.CalculateMaxCuadScaleSumForOneDrugExceptNicotine(It.IsAny<ISubstanceUse[]>())).Returns(intValue);
            substanceScoreCalculatorMock.Setup(p => p.CalculateNumberOfCuadScaleSumGreaterThanOneExceptNicotine(It.IsAny<ISubstanceUse[]>())).Returns(intValue);
            substanceScoreCalculatorMock.Setup(p => p.CalculateChemicalUseAbuseAndDependenceScaleScoreSum(It.IsAny<ISubstanceUse>())).Returns(intValue);

            var dxScoringStrategy = new DiagnosisScoringStrategy(substanceScoreCalculatorMock.Object);
            var commonScores = dxScoringStrategy.CalculateCommonScoresStage2(assessmentMock.Object, AssessmentScoreMock.Object);

            substanceScoreCalculatorMock.Verify(c => c.CalculateMinimumDaysSinceLastUsedDrugExceptNicotine(It.IsAny<SubstanceUseHistory[]>()), Times.Once());
            substanceScoreCalculatorMock.Verify(c => c.CalculateMaxCuadScaleSumForOneDrugExceptNicotine(It.IsAny<ISubstanceUse[]>()), Times.Once());
            substanceScoreCalculatorMock.Verify(c => c.CalculateNumberOfCuadScaleSumGreaterThanOneExceptNicotine(It.IsAny<ISubstanceUse[]>()), Times.Once());
            substanceScoreCalculatorMock.Verify(c => c.CalculateChemicalUseAbuseAndDependenceScaleScoreSum(It.IsAny<ISubstanceUse>()), Times.Once());

            Assert.AreEqual(intValue, commonScores.MinimumDaysSinceLastUsedDrugExceptNicotine, "MinimumDaysSinceLastUsedDrugExceptNicotine didn't match.");
            Assert.AreEqual(intValue, commonScores.MaxCuadScaleSumForOneDrugExceptNicotine, "MaxCuadScaleSumForOneDrugExceptNicotine didn't match.");
            Assert.AreEqual(intValue, commonScores.NumberOfCuadScaleSumGreaterThanOneExceptNicotine, "NumberOfCuadScaleSumGreaterThanOneExceptNicotine didn't match.");
            Assert.AreEqual(intValue, commonScores.NicotineCuadScaleSum, "NicotineCuadScaleSum didn't match.");
        }
        
        [TestMethod]
        [DataSource("Dx_WithdrawalSymptomsAndEmotionalBehavioralProblems")]
        public void Dx_CalculateWithdrawalSymptomsAndEmotionalBehavioralProblemsTests()
        {
            var significantPeriodNegativeThoughtsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodNegativeThoughtsInLast24Hours");
            var significantPeriodExcessiveBehaviorInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodExcessiveBehaviorInLast24Hours");
            var significantPeriodParanoiaInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodParanoiaInLast24Hours");
            var significantPeriodUntruePerceptionInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodUntruePerceptionInLast24Hours");
            var significantPeriodHallucinationsInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodHallucinationsInLast24Hours");
            var significantPeriodFlashbacksInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodFlashbacksInLast24Hours");
            var significantPeriodImpairedThoughtInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodImpairedThoughtInLast24Hours");
            var significantPeriodSuicidalThoughtsInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodSuicidalThoughtsInLastMonth");
            var significantPeriodAttemptedSuicideInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodAttemptedSuicideInLastMonth");

            var appearanceOfParanoiaOrImpairedThinking = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfParanoiaOrImpairedThinking"));
            var appearanceOfTroubleConcentratingOrRemembering = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfTroubleConcentratingOrRemembering"));
            var appearanceOfLethargy = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfLethargy"));
            var appearanceOfFluctuatingOrientationInLast24Hours = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfFluctuatingOrientationInLast24Hours"));
            var appearanceOfSpeechImpairmentBadPosture = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfSpeechImpairmentBadPosture"));
            var hasSuicidalThoughts = new ScaleOf0To8(TestContext.GetUInt32("HasSuicidalThoughts"));
            var demonstratingDangerToSelfOrOthers = new ScaleOf0To8(TestContext.GetUInt32("DemonstratingDangerToSelfOrOthers"));
            var limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers = new ScaleOf0To8(TestContext.GetUInt32("LimitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers"));

            var interviewerObservationOfPatientSenseOfAwareness = TestContext.GetLookup<SenseOfAwareness>("InterviewerObservationOfPatientSenseOfAwareness");
            var signsOfToxicPsychosisExist = TestContext.GetLookup<YesNoNotSure>("SignsOfToxicPsychosisExist");
            var auditoryDisturbanceLevel = TestContext.GetLookup<AuditoryDisturbanceLevel>("AuditoryDisturbanceLevel");
            var visualDisturbanceLevel = TestContext.GetLookup<VisualDisturbanceLevel>("VisualDisturbanceLevel");

            var hasImmediateMajorDepressionDisorder = TestContext.GetBoolean("HasImmediateMajorDepressionDisorder");
            var hasImmediateOtherDepressionDisorder = TestContext.GetBoolean("HasImmediateOtherDepressionDisorder");
            var hasPanicSyndrome = TestContext.GetBoolean("HasPanicSyndrome");
            var hasOtherAnxietySyndrome = TestContext.GetBoolean("HasOtherAnxietySyndrome");
            var historyOfHarmRiskToSelfOthers = TestContext.GetUInt32("HistoryOfHarmRiskToSelfOthers");
            var currentHarmRiskToSelfOthers = TestContext.GetUInt32("CurrentHarmRiskToSelfOthers");

            var withdrawalSymptomsAndEmotionalBehavioralProblem = TestContext.GetBoolean("WithdrawalSymptomsAndEmotionalBehavioralProblem");

            var diagnosisScoringStrategy = new DiagnosisScoringStrategy(new Mock<ISubstanceScoreCalculator>().Object);
            var withdrawalSymptomsAndEmotionalBehavioralProblemIndicator = diagnosisScoringStrategy.CalculateWithdrawalSymptomsAndEmotionalBehavioralProblems(
                    significantPeriodNegativeThoughtsInLast24Hours,
                    significantPeriodExcessiveBehaviorInLast24Hours,
                    significantPeriodParanoiaInLast24Hours,
                    significantPeriodUntruePerceptionInLast24Hours,
                    significantPeriodHallucinationsInLast24Hours,
                    significantPeriodFlashbacksInLast24Hours,
                    significantPeriodImpairedThoughtInLast24Hours,
                    significantPeriodSuicidalThoughtsInLastMonth,
                    significantPeriodAttemptedSuicideInLastMonth,
                    appearanceOfParanoiaOrImpairedThinking,
                    appearanceOfTroubleConcentratingOrRemembering,
                    appearanceOfLethargy,
                    appearanceOfFluctuatingOrientationInLast24Hours,
                    appearanceOfSpeechImpairmentBadPosture,
                    hasSuicidalThoughts,
                    demonstratingDangerToSelfOrOthers,
                    limitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers,
                    interviewerObservationOfPatientSenseOfAwareness,
                    signsOfToxicPsychosisExist,
                    auditoryDisturbanceLevel,
                    visualDisturbanceLevel,
                    hasImmediateMajorDepressionDisorder,
                    hasImmediateOtherDepressionDisorder,
                    hasPanicSyndrome,
                    hasOtherAnxietySyndrome,
                    historyOfHarmRiskToSelfOthers,
                    currentHarmRiskToSelfOthers
                );

            Assert.AreEqual(withdrawalSymptomsAndEmotionalBehavioralProblem,
                              withdrawalSymptomsAndEmotionalBehavioralProblemIndicator,
                              "WithdrawalSymptomsAndEmotionalBehavioralProblem didn't match.");
        }

        [TestMethod]
        public void Dx_CalculateDiagnosticStatisticalManualOfMentalDisorders_IV_Score_AreSet()
        {
            // Arrange
            var assessmentMock = AssessmentMock;
            assessmentMock.SetupGet(p => p.DrugAndAlcoholSection).Returns(new DrugAndAlcoholSection());

            // Set up more Stubs: assessmentScores.DiagnosisResults.CommonScores.WhichSubstenceEverUsed;
            var whichSubstenceEverUsed = new Mock<WhichSubstenceEverUsed>();
            var dxCommonScores = new Mock<CommonScores>();
            dxCommonScores.SetupGet(p => p.WhichSubstenceEverUsed).Returns(whichSubstenceEverUsed.Object);

            // Set up more Stubs: assessmentScores.DiagnosisResults.CommonScores.NumberOfCuadScaleSumGreaterThanOneExceptNicotine,
            dxCommonScores.SetupGet(p => p.NumberOfCuadScaleSumGreaterThanOneExceptNicotine).Returns(It.IsAny<int>());
            var diagnosisResults = new Mock<DiagnosisResults>();
            diagnosisResults.SetupGet(p => p.CommonScores).Returns(dxCommonScores.Object);
            
            var assessmentScoreMock = AssessmentScoreMock;
            assessmentScoreMock.SetupGet(p => p.DiagnosisResults).Returns(diagnosisResults.Object);

            var substanceScore = new Mock<SubstanceScore>().Object;

            var substanceScoreCalculatorMock = new Mock<ISubstanceScoreCalculator>();
            substanceScoreCalculatorMock.Setup(p => p.CalculateSubstanceScore(It.IsAny<bool>(), It.IsAny<ISubstanceUse>())).
                Returns(substanceScore);
            substanceScoreCalculatorMock.Setup(
                p => p.CalculateSubstanceScore(It.IsAny<bool?>(), It.IsAny<TimeMeasure>(), It.IsAny<int>(), It.IsAny<ProblemSubstance>(), It.IsAny<ISubstanceUse[]>())).
                Returns(substanceScore);
            var dxScoringStrategy = new DiagnosisScoringStrategy(substanceScoreCalculatorMock.Object);

            // Act
            var dsmScores = dxScoringStrategy.CalculateDiagnosticStatisticalManualOfMentalDisorders_IV_Scores(assessmentMock.Object, assessmentScoreMock.Object);

            // Assert
            // Make sure each of the substance score in DSM IV has been set and has been correctly set. (both state-based and interaction testing)
            substanceScoreCalculatorMock.Verify(c => c.CalculateSubstanceScore(It.IsAny<bool>(), It.IsAny<ISubstanceUse>()), Times.Exactly(13));
            substanceScoreCalculatorMock.Verify(c => c.CalculateSubstanceScore(It.IsAny<bool?>(), It.IsAny<TimeMeasure>(), It.IsAny<int>(), It.IsAny<ProblemSubstance>(), It.IsAny<ISubstanceUse[]>()), Times.Once());

            var errorMsg = new StringBuilder();
            var properties = typeof(DiagnosticStatisticalManualOfMentalDisorders_IV_Scores).GetProperties();
            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.PropertyType != typeof (SubstanceScore))
                {
                    continue;
                }
                var value = propertyInfo.GetValue(dsmScores);

                if (value != substanceScore)
                {
                    errorMsg.Append(string.Format("Substance score of '{0}' is not correctly set.{1}", propertyInfo.Name, Environment.NewLine));
                }
            }

            Assert.AreEqual(string.Empty, errorMsg.ToString());
        }

        [TestMethod]
        [DataSource("Dx_SubstanceScore")]
        public void Dx_CalculateSubstanceScoreTests()
        {
            var increasedDoseRequiredToGetSameEffect = TestContext.GetBoolean("IncreasedDoseRequiredToGetSameEffect");
            var experiencesWithdrawalSickness = TestContext.GetBoolean("ExperiencesWithdrawalSickness");
            var useSubstanceToPreventWithdrawalSickness = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSickness");
            var unableToStopUsingSubstance = TestContext.GetBoolean("UnableToStopUsingSubstance");
            var substanceUseReductionAttempted = TestContext.GetBoolean("SubstanceUseReductionAttempted");
            var useOfSubstanceTakesUpALotOfTime = TestContext.GetBoolean("UseOfSubstanceTakesUpALotOfTime");
            var substanceUseReductionInSocialActivities = TestContext.GetBoolean("SubstanceUseReductionInSocialActivities");
            var substanceUseReductionInOccupationalActivities = TestContext.GetBoolean("SubstanceUseReductionInOccupationalActivities");
            var substanceUseReductionInRecreationalActivities = TestContext.GetBoolean("SubstanceUseReductionInRecreationalActivities");
            var hasUsedSubstanceKnowingProblemsWorsened = TestContext.GetBoolean("HasUsedSubstanceKnowingProblemsWorsened");
            var frequentlyHighAtWork = TestContext.GetBoolean("FrequentlyHighAtWork");
            var frequentlyHighAtSchool = TestContext.GetBoolean("FrequentlyHighAtSchool");
            var frequentlyHighAtHome = TestContext.GetBoolean("FrequentlyHighAtHome");
            var frequentlyHighInDangerousSituations = TestContext.GetBoolean("FrequentlyHighInDangerousSituations");
            var substanceUseRecurrentProblemsWithLegalSystem = TestContext.GetBoolean("SubstanceUseRecurrentProblemsWithLegalSystem");
            var substanceUseRecurrentProblemsWithFamilyFriends = TestContext.GetBoolean("SubstanceUseRecurrentProblemsWithFamilyFriends");
            var substanceUseRecurrentProblemsWithJob = TestContext.GetBoolean("SubstanceUseRecurrentProblemsWithJob");
            var hasEverUsed = TestContext.GetBoolean("HasEverUsed");
            var lastUsed = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsed"));
            var numberOfDaysUsedInPast30Days = TestContext.GetUInt32 ( "NumberOfDaysUsedInPast30Days" );

            var isDependent = TestContext.GetBoolean("IsDependent");
            var isDependentWithPhysiologicalDependency = TestContext.GetBoolean("IsDependentWithPhysiologicalDependency");
            var isDependentWithOutPhysiologicalDependency = TestContext.GetBoolean("IsDependentWithOutPhysiologicalDependency");
            var isAbused = TestContext.GetBoolean("IsAbused");
            var hasImminentWithdrawalPotential = TestContext.GetBoolean("HasImminentWithdrawalPotential");

            if (TestContext.GetBoolean("ForDebug"))
            {

            }

            var substanceScore = SubstanceScoreCalculator.CalculateSubstanceScore(
                increasedDoseRequiredToGetSameEffect,
                experiencesWithdrawalSickness,
                useSubstanceToPreventWithdrawalSickness,
                unableToStopUsingSubstance,
                substanceUseReductionAttempted,
                useOfSubstanceTakesUpALotOfTime,
                substanceUseReductionInSocialActivities,
                substanceUseReductionInOccupationalActivities,
                substanceUseReductionInRecreationalActivities,
                hasUsedSubstanceKnowingProblemsWorsened,
                frequentlyHighAtWork,
                frequentlyHighAtSchool,
                frequentlyHighAtHome,
                frequentlyHighInDangerousSituations,
                substanceUseRecurrentProblemsWithLegalSystem,
                substanceUseRecurrentProblemsWithFamilyFriends,
                substanceUseRecurrentProblemsWithJob,
                hasEverUsed,
                lastUsed,
                numberOfDaysUsedInPast30Days);

            Assert.AreEqual(isDependent, substanceScore.IsDependent, "IsDependent didn't match.");
            Assert.AreEqual(isDependentWithPhysiologicalDependency, substanceScore.IsDependentWithPhysiologicalDependency, "IsDependentWithPhysiologicalDependency didn't match.");
            Assert.AreEqual(isDependentWithOutPhysiologicalDependency, substanceScore.IsDependentWithOutPhysiologicalDependency, "IsDependentWithOutPhysiologicalDependency didn't match.");
            Assert.AreEqual(isAbused, substanceScore.IsAbused, "IsAbused didn't match.");
            Assert.AreEqual(hasImminentWithdrawalPotential, substanceScore.HasImminentWithdrawalPotential, "HasImminentWithdrawalPotential didn't match.");
        }


        [TestMethod]
        [DataSource("Dx_AddictionSeverityIndexCompositeScores")]
        public void CalculateAddictionSeverityIndexCompositeScoresTests()
        {
            var numberOfDaysWithMedicalProblemsInPast30Days = TestContext.GetUInt32("NumberOfDaysWithMedicalProblemsInPast30Days");
            var levelOfConcernInPast30DaysAboutMedicalProblems = TestContext.GetLookup<LikertScale>("LevelOfConcernInPast30DaysAboutMedicalProblems");
            var importanceOfTreatmentForMedicalProblems = TestContext.GetLookup<LikertScale>("ImportanceOfTreatmentForMedicalProblems");
            var hasValidDriversLicense = TestContext.GetBoolean("HasValidDriversLicense");
            var hasAutomobileAvailableForUse = TestContext.GetBoolean("HasAutomobileAvailableForUse");
            var numberOfDaysWorkingInPast30Days = TestContext.GetUInt32("NumberOfDaysWorkingInPast30Days");
            var amountOfMoneyInPast30DaysFromEmployment =  new Money(Currency.UnitedStatesEnglish, TestContext.GetDecimal("AmountOfMoneyInPast30DaysFromEmployment"));
            var numberOfDaysUsedInPast30DaysAlcohol = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysAlcohol");
            var numberOfDaysIntoxicatedInPast30DaysAlcohol = TestContext.GetUInt32("NumberOfDaysIntoxicatedInPast30DaysAlcohol");
            var amountOfMoneySpentInLast30DaysAlcohol =  new Money(Currency.UnitedStatesEnglish, TestContext.GetDecimal("AmountOfMoneySpentInLast30DaysAlcohol"));
            var troubledInLast30DaysBySubstanceProblemsAlcohol = TestContext.GetLookup<LikertScale>("TroubledInLast30DaysBySubstanceProblemsAlcohol");
            var importanceOfTreatmentForSubstanceProblemsAlcohol = TestContext.GetLookup<LikertScale>("ImportanceOfTreatmentForSubstanceProblemsAlcohol");
            var numberOfDaysWithSubstanceProblemsInLast30DaysAlcohol = TestContext.GetUInt32("NumberOfDaysWithSubstanceProblemsInLast30DaysAlcohol");
            var numberOfDaysUsedInPast30DaysHeroin = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysHeroin");
            var numberOfDaysUsedInPast30DaysMethadone = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysMethadone");
            var numberOfDaysUsedInPast30DaysOtherOpiate = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysOtherOpiate");
            var numberOfDaysUsedInPast30DaysBarbiturate = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysBarbiturate");
            var numberOfDaysUsedInPast30DaysOtherSedative = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysOtherSedative");
            var numberOfDaysUsedInPast30DaysCocaine = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysCocaine");
            var numberOfDaysUsedInPast30DaysStimulant = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysStimulant");
            var numberOfDaysUsedInPast30DaysCannabis = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysCannabis");
            var numberOfDaysUsedInPast30DaysHallucinogen = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysHallucinogen");
            var numberOfDaysUsedInPast30Days = TestContext.GetUInt32("NumberOfDaysUsedInPast30Days");
            var numberOfDaysExperiencedSubstanceProblemsInPast30Days = TestContext.GetUInt32("NumberOfDaysExperiencedSubstanceProblemsInPast30Days");
            var troubledInLast30DaysBySubstanceProblems = TestContext.GetLookup<LikertScale>("TroubledInLast30DaysBySubstanceProblems");
            var importanceOfTreatmentForSubstanceProblem = TestContext.GetLookup<LikertScale>("ImportanceOfTreatmentForSubstanceProblem");
            var isCurrentlyAwaitingChargesTrialSentence = TestContext.GetBoolean("IsCurrentlyAwaitingChargesTrialSentence");
            var numberOfDaysCommitingCrimesForProfitInPast30Days = TestContext.GetUInt32("NumberOfDaysCommitingCrimesForProfitInPast30Days");
            var severityOfCurrentLegalProblems = TestContext.GetLookup<LikertScale>("SeverityOfCurrentLegalProblems");
            var importanceOfCounselingForCurrentLegalProblems = TestContext.GetLookup<LikertScale>("ImportanceOfCounselingForCurrentLegalProblems");
            var amountOfMoneyInPast30DaysFromIllegalMeans = new Money(Currency.UnitedStatesEnglish, TestContext.GetDecimal("AmountOfMoneyInPast30DaysFromIllegalMeans"));
            var hadProblemsInPastMonthWithMother = TestContext.GetLookup<YesNoNotApplicable>("HadProblemsInPastMonthWithMother");
            var hadProblemsInPastMonthWithFather = TestContext.GetLookup<YesNoNotApplicable>("HadProblemsInPastMonthWithFather");
            var hadProblemsInPastMonthWithSibling = TestContext.GetLookup<YesNoNotApplicable>("HadProblemsInPastMonthWithSibling");
            var hadProblemsInPastMonthWithSexPartner = TestContext.GetLookup<YesNoNotApplicable>("HadProblemsInPastMonthWithSexPartner");
            var hadProblemsInPastMonthWithChildren = TestContext.GetLookup<YesNoNotApplicable>("HadProblemsInPastMonthWithChildren");
            var hadProblemsInPastMonthWithOtherFamily = TestContext.GetLookup<YesNoNotApplicable>("HadProblemsInPastMonthWithOtherFamily");
            var hadProblemsInPastMonthWithCloseFriends = TestContext.GetLookup<YesNoNotApplicable>("HadProblemsInPastMonthWithCloseFriends");
            var hadProblemsInPastMonthWithNeighbors = TestContext.GetLookup<YesNoNotApplicable>("HadProblemsInPastMonthWithNeighbors");
            var hadProblemsInPastMonthWithCoworkers = TestContext.GetLookup<YesNoNotApplicable>("HadProblemsInPastMonthWithCoworkers");
            var satisfiedWithThisSituation = TestContext.GetLookup<YesNoIndifferent>("SatisfiedWithThisSituation");
            var seriousConflictsWithFamilyInPast30Days = TestContext.GetUInt32("SeriousConflictsWithFamilyInPast30Days");
            var troubledByFamilyProblemsInPast30Days = TestContext.GetLookup<LikertScale>("TroubledByFamilyProblemsInPast30Days");
            var importanceOfTreatmentForFamilyMembers = TestContext.GetLookup<LikertScale>("ImportanceOfTreatmentForFamilyMembers");
            var howTroubledByPsychologicalEmotionalProblemsLast30Days = TestContext.GetLookup<LikertScale>("HowTroubledByPsychologicalEmotionalProblemsLast30Days");
            var significantPeriodOfSeriousDepressionInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodOfSeriousDepressionInLastMonth");
            var anxietyTensionWorryInLastMonth = TestContext.GetLookup<LikertScale>("AnxietyTensionWorryInLastMonth");
            var significantPeriodHallucinationsInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodHallucinationsInLastMonth");
            var significantPeriodImpairedThoughtInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodImpairedThoughtInLastMonth");
            var significantPeriodCurbingViolentBehaviorInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodCurbingViolentBehaviorInLastMonth");
            var significantPeriodSuicidalThoughtsInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodSuicidalThoughtsInLastMonth");
            var significantPeriodAttemptedSuicideInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodAttemptedSuicideInLastMonth");
            var medicatedForPsychologicalEmotionalProblemInLastMonth = TestContext.GetBoolean("MedicatedForPsychologicalEmotionalProblemInLastMonth");
            var numberOfDaysExperiencedPsychologicalEmotionalProblemsInLast30Days = TestContext.GetUInt32("NumberOfDaysExperiencedPsychologicalEmotionalProblems");
            var howImportantPsychologicalEmotionalCounseling = TestContext.GetLookup<PsychologicalEmotionalCounselingImportanceScale>("HowImportantPsychologicalEmotionalCounseling");

            var medical = TestContext.GetDouble("Medical");
            var employment = TestContext.GetDouble("Employment");
            var alcohol = TestContext.GetDouble("Alcohol");
            var drug = TestContext.GetDouble("Drug");
            var legal = TestContext.GetDouble("Legal");
            var familyAndSocial = TestContext.GetDouble("FamilyAndSocial");
            var psychiatric = TestContext.GetDouble("Psychiatric");

            if (TestContext.GetBoolean("ForDebug"))
            {

            }
            
            var diagnosisScoringStrategy = new DiagnosisScoringStrategy(new SubstanceScoreCalculator (  ));
            var asiSores = diagnosisScoringStrategy.CalculateAddictionSeverityIndexCompositeScores (
                numberOfDaysWithMedicalProblemsInPast30Days,
                levelOfConcernInPast30DaysAboutMedicalProblems,
                importanceOfTreatmentForMedicalProblems,
                hasValidDriversLicense,
                hasAutomobileAvailableForUse,
                numberOfDaysWorkingInPast30Days,
                amountOfMoneyInPast30DaysFromEmployment,
                numberOfDaysUsedInPast30DaysAlcohol,
                numberOfDaysIntoxicatedInPast30DaysAlcohol,
                amountOfMoneySpentInLast30DaysAlcohol,
                troubledInLast30DaysBySubstanceProblemsAlcohol,
                importanceOfTreatmentForSubstanceProblemsAlcohol,
                numberOfDaysWithSubstanceProblemsInLast30DaysAlcohol,
                numberOfDaysUsedInPast30DaysHeroin,
                numberOfDaysUsedInPast30DaysMethadone,
                numberOfDaysUsedInPast30DaysOtherOpiate,
                numberOfDaysUsedInPast30DaysBarbiturate,
                numberOfDaysUsedInPast30DaysOtherSedative,
                numberOfDaysUsedInPast30DaysCocaine,
                numberOfDaysUsedInPast30DaysStimulant,
                numberOfDaysUsedInPast30DaysCannabis,
                numberOfDaysUsedInPast30DaysHallucinogen,
                numberOfDaysUsedInPast30Days,
                numberOfDaysExperiencedSubstanceProblemsInPast30Days,
                troubledInLast30DaysBySubstanceProblems,
                importanceOfTreatmentForSubstanceProblem,
                isCurrentlyAwaitingChargesTrialSentence,
                numberOfDaysCommitingCrimesForProfitInPast30Days,
                severityOfCurrentLegalProblems,
                importanceOfCounselingForCurrentLegalProblems,
                amountOfMoneyInPast30DaysFromIllegalMeans,
                hadProblemsInPastMonthWithMother,
                hadProblemsInPastMonthWithFather,
                hadProblemsInPastMonthWithSibling,
                hadProblemsInPastMonthWithSexPartner,
                hadProblemsInPastMonthWithChildren,
                hadProblemsInPastMonthWithOtherFamily,
                hadProblemsInPastMonthWithCloseFriends,
                hadProblemsInPastMonthWithNeighbors,
                hadProblemsInPastMonthWithCoworkers,
                satisfiedWithThisSituation,
                seriousConflictsWithFamilyInPast30Days,
                troubledByFamilyProblemsInPast30Days,
                importanceOfTreatmentForFamilyMembers,
                howTroubledByPsychologicalEmotionalProblemsLast30Days,
                significantPeriodOfSeriousDepressionInLastMonth,
                anxietyTensionWorryInLastMonth,
                significantPeriodHallucinationsInLastMonth,
                significantPeriodImpairedThoughtInLastMonth,
                significantPeriodCurbingViolentBehaviorInLastMonth,
                significantPeriodSuicidalThoughtsInLastMonth,
                significantPeriodAttemptedSuicideInLastMonth,
                medicatedForPsychologicalEmotionalProblemInLastMonth,
                numberOfDaysExperiencedPsychologicalEmotionalProblemsInLast30Days,
                howImportantPsychologicalEmotionalCounseling );

            var asiList = asiSores.ToList ( );
            Assert.AreEqual(medical, asiList[0].Score, "Medical didn't match.");
            Assert.AreEqual(employment, asiList[1].Score, "Employment didn't match.");
            Assert.AreEqual(alcohol, asiList[2].Score, "Alcohol didn't match.");
            Assert.AreEqual(drug, asiList[3].Score, "Drug didn't match.");
            Assert.AreEqual(legal, asiList[4].Score, "Legal didn't match.");
            Assert.AreEqual(familyAndSocial, asiList[5].Score, "FamilyAndSocial didn't match.");
            Assert.AreEqual(psychiatric, asiList[6].Score, "Psychiatric didn't match.");
        }


        [TestMethod]
        [DataSource("Dx_CiwaCinaAndWithdrawalSicknessIndicator")]
        public void Dx_CalculateCiwaCinaAndWithdrawalSicknessIndicatorTests()
        {
            var experiencedNauseaOrVomitedRecentlyCiwa = TestContext.GetLookup<ExperiencedNauseaOrVomitedRecently>("ExperiencedNauseaOrVomitedRecentlyCiwa");
            var observedTremorCiwa = TestContext.GetLookup<TremorObservation>("ObservedTremorCiwa");
            var observedSweatingCiwa = TestContext.GetLookup<SweatingObservation>("ObservedSweatingCiwa");
            var observedNervousness = TestContext.GetLookup<NervousnessObservation>("ObservedNervousness");
            var interviewerObservationOfPatientAgitationLevel = new ScaleOf0To7(TestContext.GetUInt32("InterviewerObservationOfPatientAgitationLevel"));
            var observedTactileDisturbances = TestContext.GetLookup<TactileDisturbancesObservation>("ObservedTactileDisturbances");
            var auditoryDisturbanceLevel = TestContext.GetLookup<AuditoryDisturbanceLevel>("AuditoryDisturbanceLevel");
            var visualDisturbanceLevel = TestContext.GetLookup<VisualDisturbanceLevel>("VisualDisturbanceLevel");
            var headAcheOrFullnessSeverity = TestContext.GetLookup<HeadAcheOrFullnessSeverity>("HeadAcheOrFullnessSeverity");
            var interviewerObservationOfPatientSenseOfAwareness = TestContext.GetLookup<SenseOfAwareness>("InterviewerObservationOfPatientSenseOfAwareness");
            var experiencedNauseaOrVomitedRecently = new ScaleOf0To9(TestContext.GetUInt32("ExperiencedNauseaOrVomitedRecently"));
            var observedGooseFlesh = TestContext.GetLookup<GooseFleshObservation>("ObservedGooseFlesh");
            var observedSweating = TestContext.GetLookup<SweatingObservation>("ObservedSweating");
            var observedRestlessness = TestContext.GetLookup<RestlessnessObservation>("ObservedRestlessness");
            var observedTremor = TestContext.GetLookup<TremorObservation>("ObservedTremor");
            var observedLacrimination = TestContext.GetLookup<LacriminationObservation>("ObservedLacrimination");
            var observedNasalCongestion = TestContext.GetLookup<NasalCongestionObservation>("ObservedNasalCongestion");
            var observedYawning = TestContext.GetLookup<YawningObservation>("ObservedYawning");
            var hasAbdominalPain = TestContext.GetLookup<AbdominalPainStatus>("HasAbdominalPain");
            var feelsHotOrCold = TestContext.GetLookup<BodyTemperatureStatus>("FeelsHotOrCold");
            var hasMuscleAches = TestContext.GetLookup<MuscleAcheStatus>("HasMuscleAches");
            var heartRate = new HeartRate(TestContext.GetUInt32("HeartRate"));
            var experiencesWithdrawalSicknessAlcohol = TestContext.GetBoolean("ExperiencesWithdrawalSicknessAlcohol");
            var experiencesWithdrawalSicknessHeroin = TestContext.GetBoolean("ExperiencesWithdrawalSicknessHeroin");
            var experiencesWithdrawalSicknessMethadone = TestContext.GetBoolean("ExperiencesWithdrawalSicknessMethadone");
            var experiencesWithdrawalSicknessOtherOpiate = TestContext.GetBoolean("ExperiencesWithdrawalSicknessOtherOpiate");
            var experiencesWithdrawalSicknessBarbiturate = TestContext.GetBoolean("ExperiencesWithdrawalSicknessBarbiturate");
            var experiencesWithdrawalSicknessOtherSedative = TestContext.GetBoolean("ExperiencesWithdrawalSicknessOtherSedative");
            var experiencesWithdrawalSicknessCocaine = TestContext.GetBoolean("ExperiencesWithdrawalSicknessCocaine");
            var experiencesWithdrawalSicknessStimulant = TestContext.GetBoolean("ExperiencesWithdrawalSicknessStimulant");
            var experiencesWithdrawalSicknessCannabis = TestContext.GetBoolean("ExperiencesWithdrawalSicknessCannabis");
            var experiencesWithdrawalSicknessHallucinogen = TestContext.GetBoolean("ExperiencesWithdrawalSicknessHallucinogen");
            var experiencesWithdrawalSicknessSolventAndInhalant = TestContext.GetBoolean("ExperiencesWithdrawalSicknessSolventAndInhalant");
            var experiencesWithdrawalSicknessOtherSubstance = TestContext.GetBoolean("ExperiencesWithdrawalSicknessOtherSubstance");
            var useSubstanceToPreventWithdrawalSicknessAlcohol = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessAlcohol");
            var useSubstanceToPreventWithdrawalSicknessHeroin = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessHeroin");
            var useSubstanceToPreventWithdrawalSicknessMethadone = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessMethadone");
            var useSubstanceToPreventWithdrawalSicknessOtherOpiate = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessOtherOpiate");
            var useSubstanceToPreventWithdrawalSicknessBarbiturate = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessBarbiturate");
            var useSubstanceToPreventWithdrawalSicknessOtherSedative = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessOtherSedative");
            var useSubstanceToPreventWithdrawalSicknessCocaine = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessCocaine");
            var useSubstanceToPreventWithdrawalSicknessStimulant = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessStimulant");
            var useSubstanceToPreventWithdrawalSicknessCannabis = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessCannabis");
            var useSubstanceToPreventWithdrawalSicknessHallucinogen = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessHallucinogen");
            var useSubstanceToPreventWithdrawalSicknessSolventAndInhalant = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessSolventAndInhalant");
            var useSubstanceToPreventWithdrawalSicknessOtherSubstance = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessOtherSubstance");

            var ciwaCinaAndWithdrawalSicknessIndicator = TestContext.GetBoolean ( "CiwaCinaAndWithdrawalSicknessIndicator" );

            if(TestContext.GetBoolean ( "ForDebug" ))
            {
                
            }
            var ciwaCinaAndWithdrawalSicknessIndicatorResult =
                DiagnosisScoringStrategy.CalculateCiwaCinaAndWithdrawalSicknessIndicator (
                    experiencedNauseaOrVomitedRecentlyCiwa,
                    observedTremorCiwa,
                    observedSweatingCiwa,
                    observedNervousness,
                    interviewerObservationOfPatientAgitationLevel,
                    observedTactileDisturbances,
                    auditoryDisturbanceLevel,
                    visualDisturbanceLevel,
                    headAcheOrFullnessSeverity,
                    interviewerObservationOfPatientSenseOfAwareness,
                    experiencedNauseaOrVomitedRecently,
                    observedGooseFlesh,
                    observedSweating,
                    observedRestlessness,
                    observedTremor,
                    observedLacrimination,
                    observedNasalCongestion,
                    observedYawning,
                    hasAbdominalPain,
                    feelsHotOrCold,
                    hasMuscleAches,
                    heartRate,
                    experiencesWithdrawalSicknessAlcohol,
                    experiencesWithdrawalSicknessHeroin,
                    experiencesWithdrawalSicknessMethadone,
                    experiencesWithdrawalSicknessOtherOpiate,
                    experiencesWithdrawalSicknessBarbiturate,
                    experiencesWithdrawalSicknessOtherSedative,
                    experiencesWithdrawalSicknessCocaine,
                    experiencesWithdrawalSicknessStimulant,
                    experiencesWithdrawalSicknessCannabis,
                    experiencesWithdrawalSicknessHallucinogen,
                    experiencesWithdrawalSicknessSolventAndInhalant,
                    experiencesWithdrawalSicknessOtherSubstance,
                    useSubstanceToPreventWithdrawalSicknessAlcohol,
                    useSubstanceToPreventWithdrawalSicknessHeroin,
                    useSubstanceToPreventWithdrawalSicknessMethadone,
                    useSubstanceToPreventWithdrawalSicknessOtherOpiate,
                    useSubstanceToPreventWithdrawalSicknessBarbiturate,
                    useSubstanceToPreventWithdrawalSicknessOtherSedative,
                    useSubstanceToPreventWithdrawalSicknessCocaine,
                    useSubstanceToPreventWithdrawalSicknessStimulant,
                    useSubstanceToPreventWithdrawalSicknessCannabis,
                    useSubstanceToPreventWithdrawalSicknessHallucinogen,
                    useSubstanceToPreventWithdrawalSicknessSolventAndInhalant,
                    useSubstanceToPreventWithdrawalSicknessOtherSubstance );

            Assert.AreEqual(ciwaCinaAndWithdrawalSicknessIndicator, ciwaCinaAndWithdrawalSicknessIndicatorResult, "ciwaCinaAndWithdrawalSicknessIndicator didn't match.");
        }

        [TestMethod]
        [DataSource("Dx_CareLevel_I_DetoxificationScore")]
        public void Dx_CalculateCareLevel_I_DetoxificationScoreTests()
        {
            var ciwaCinaAndWithdrawalSicknessIndicator = TestContext.GetBoolean("CiwaCinaAndWithdrawalSicknessIndicator");
            var minimumDaysSinceLastUsedDrugExceptNicotine = TestContext.GetDouble("MinimumDaysSinceLastUsedDrugExceptNicotine");
            var daysSinceLastUsedNicotine = TestContext.GetDouble("DaysSinceLastUsedNicotine");
            var signsOfIntoxicationExist = TestContext.GetLookup<YesNoNotSure>("SignsOfIntoxicationExist");
            var majorityOfInformationFromCollateralSource = TestContext.GetBoolean("MajorityOfInformationFromCollateralSource");
            var maxCuadScaleSumForOneDrugExceptNicotine = TestContext.GetInt32("MaxCuadScaleSumForOneDrugExceptNicotine");
            var nicotineCuadScaleSum = TestContext.GetInt32("NicotineCuadScaleSum");
            var anyAddictionDiagnosis = TestContext.GetBoolean("AnyAddictionDiagnosis");

            var isDiagnosed = TestContext.GetBoolean("IsDiagnosed");
            var isLikelyDiagnosed = TestContext.GetBoolean("IsLikelyDiagnosed");

            var diagnosisScoringStrategy = new DiagnosisScoringStrategy(new SubstanceScoreCalculator (  ));
            var careLevel_I_DetoxificationScore = diagnosisScoringStrategy.CalculateCareLevel_I_DetoxificationScore (
                ciwaCinaAndWithdrawalSicknessIndicator,
                minimumDaysSinceLastUsedDrugExceptNicotine,
                daysSinceLastUsedNicotine,
                signsOfIntoxicationExist,
                majorityOfInformationFromCollateralSource,
                maxCuadScaleSumForOneDrugExceptNicotine,
                nicotineCuadScaleSum,
                anyAddictionDiagnosis );

            Assert.AreEqual (isDiagnosed, careLevel_I_DetoxificationScore.IsDiagnosed, "IsDiagnose didn't match."  );
            Assert.AreEqual ( isLikelyDiagnosed, careLevel_I_DetoxificationScore.IsLikelyDiagnosed,"IsLikelyDiagnosed didn't match." );
        }


        [TestMethod]
        [DataSource("Dx_CareLevel_II_DetoxificationScore")]
        public void Dx_CalculateCareLevel_II_DetoxificationScoreTests()
        {
            var ciwaCinaAndWithdrawalSicknessIndicator = TestContext.GetBoolean("CiwaCinaAndWithdrawalSicknessIndicator");
            var minimumDaysSinceLastUsedDrugExceptNicotine = TestContext.GetDouble("MinimumDaysSinceLastUsedDrugExceptNicotine");
            var daysSinceLastUsedNicotine = TestContext.GetDouble("DaysSinceLastUsedNicotine");
            var signsOfIntoxicationExist = TestContext.GetLookup<YesNoNotSure>("SignsOfIntoxicationExist");
            var majorityOfInformationFromCollateralSource = TestContext.GetBoolean("MajorityOfInformationFromCollateralSource");
            var maxCuadScaleSumForOneDrugExceptNicotine = TestContext.GetInt32("MaxCuadScaleSumForOneDrugExceptNicotine");
            var anyAddictionDiagnosis = TestContext.GetBoolean("AnyAddictionDiagnosis");

            var isDiagnosed = TestContext.GetBoolean("IsDiagnosed");
            var isLikelyDiagnosed = TestContext.GetBoolean("IsLikelyDiagnosed");

            var diagnosisScoringStrategy = new DiagnosisScoringStrategy(new SubstanceScoreCalculator (  ));
            var careLevel_II_DetoxificationScore = diagnosisScoringStrategy.CalculateCareLevel_II_DetoxificationScore (
                ciwaCinaAndWithdrawalSicknessIndicator,
                minimumDaysSinceLastUsedDrugExceptNicotine,
                daysSinceLastUsedNicotine,
                signsOfIntoxicationExist,
                majorityOfInformationFromCollateralSource,
                maxCuadScaleSumForOneDrugExceptNicotine,
                anyAddictionDiagnosis );

            Assert.AreEqual (isDiagnosed, careLevel_II_DetoxificationScore.IsDiagnosed, "IsDiagnose didn't match."  );
            Assert.AreEqual ( isLikelyDiagnosed, careLevel_II_DetoxificationScore.IsLikelyDiagnosed,"IsLikelyDiagnosed didn't match." );
        }


        [TestMethod]
        [DataSource("Dx_CareLevel_0_5_EarlyInterventionScore")]
        public void Dx_CalculateCareLevel_0_5_EarlyInterventionScoreTests()
        {
            var diagnosisxResultsCareLevel_I_OutpatientScoreIsMet = TestContext.GetBoolean("DiagnosisxResultsCareLevel_I_OutpatientScoreIsMet");
            var maxCuadScaleSumForOneDrugExceptNicotine = TestContext.GetInt32("MaxCuadScaleSumForOneDrugExceptNicotine");
            var nicotineCuadScaleSum = TestContext.GetInt32("NicotineCuadScaleSum");
            var anyAddictionDiagnosisExceptNicotine = TestContext.GetBoolean("AnyAddictionDiagnosisExceptNicotine");

            var isMet = TestContext.GetBoolean("IsMet");

            var diagnosisScoringStrategy = new DiagnosisScoringStrategy(new SubstanceScoreCalculator (  ));
            var careLevel_II_DetoxificationScore = diagnosisScoringStrategy.
                CalculateCareLevel_0_5_EarlyInterventionScore (
                    diagnosisxResultsCareLevel_I_OutpatientScoreIsMet,
                    maxCuadScaleSumForOneDrugExceptNicotine,
                    nicotineCuadScaleSum,
                    anyAddictionDiagnosisExceptNicotine );

            Assert.AreEqual (isMet, careLevel_II_DetoxificationScore.IsMet, "IsMet didn't match."  );
        }

        [TestMethod]
        [DataSource("Dx_CareLevel_I_OutpatientScore")]
        public void Dx_CalculateCareLevel_I_OutpatientScoreTests()
        {
            var ciwaCinaAndWithdrawalSicknessIndicator = TestContext.GetBoolean("CiwaCinaAndWithdrawalSicknessIndicator");
            var minimumDaysSinceLastUsedDrugExceptNicotine = TestContext.GetDouble("MinimumDaysSinceLastUsedDrugExceptNicotine");
            var daysSinceLastUsedNicotine = TestContext.GetDouble("DaysSinceLastUsedNicotine");
            var signsOfIntoxicationExist = TestContext.GetLookup<YesNoNotSure>("SignsOfIntoxicationExist");
            var majorityOfInformationFromCollateralSource = TestContext.GetBoolean("MajorityOfInformationFromCollateralSource");
            var maxCuadScaleSumForOneDrugExceptNicotine = TestContext.GetInt32("MaxCuadScaleSumForOneDrugExceptNicotine");
            var nicotineCuadScaleSum = TestContext.GetInt32("NicotineCuadScaleSum");
            var anyAddictionDiagnosis = TestContext.GetBoolean("AnyAddictionDiagnosis");
            var anyAddictionDiagnosisExceptNicotine = TestContext.GetBoolean("AnyAddictionDiagnosisExceptNicotine");
            var numberOfTimesTreatedForAlcoholAbuseLifetime = TestContext.GetUInt32("NumberOfTimesTreatedForAlcoholAbuseLifetime");
            var numberOfTimesDrugTreatmentLifetime = TestContext.GetUInt32("NumberOfTimesDrugTreatmentLifetime");
            var interviewerScoreOfAlcoholTreatmentNeed = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfAlcoholTreatmentNeed"));
            var interviewerScoreOfDrugTreatmentNeed = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfDrugTreatmentNeed"));
            var doesPatientCarryPsychiatricDiagnosis = TestContext.GetLookup<PatientCarriesPsychiatricDiagnosis>("DoesPatientCarryPsychiatricDiagnosis");
            var withdrawalSymptomsAndEmotionalBehavioralProblems = TestContext.GetBoolean("WithdrawalSymptomsAndEmotionalBehavioralProblems");
            var nicotineTobaccoIsDependentWithPhysiologicalDependency = TestContext.GetBoolean("NicotineTobaccoIsDependentWithPhysiologicalDependency");

            var isDiagnosed = TestContext.GetBoolean("IsDiagnosed");
            var isLikelyDiagnosed = TestContext.GetBoolean("IsLikelyDiagnosed");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisCapable = TestContext.GetBoolean("IsDualDiagnosisCapable");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            if(TestContext.GetBoolean ( "ForDebug" ))
            {
                
            }

            var diagnosisScoringStrategy = new DiagnosisScoringStrategy(new SubstanceScoreCalculator());
            var careLevel_I_Score =
                diagnosisScoringStrategy.CalculateCareLevel_I_OutpatientScore ( ciwaCinaAndWithdrawalSicknessIndicator,
                                                                                minimumDaysSinceLastUsedDrugExceptNicotine,
                                                                                daysSinceLastUsedNicotine,
                                                                                signsOfIntoxicationExist,
                                                                                majorityOfInformationFromCollateralSource,
                                                                                maxCuadScaleSumForOneDrugExceptNicotine,
                                                                                nicotineCuadScaleSum,
                                                                                anyAddictionDiagnosis,
                                                                                anyAddictionDiagnosisExceptNicotine,
                                                                                numberOfTimesTreatedForAlcoholAbuseLifetime,
                                                                                numberOfTimesDrugTreatmentLifetime,
                                                                                interviewerScoreOfAlcoholTreatmentNeed,
                                                                                interviewerScoreOfDrugTreatmentNeed,
                                                                                doesPatientCarryPsychiatricDiagnosis,
                                                                                withdrawalSymptomsAndEmotionalBehavioralProblems,
                                                                                nicotineTobaccoIsDependentWithPhysiologicalDependency );

            Assert.AreEqual(isDiagnosed, careLevel_I_Score.IsDiagnosed, "IsDiagnose didn't match.");
            Assert.AreEqual(isLikelyDiagnosed, careLevel_I_Score.IsLikelyDiagnosed, "IsLikelyDiagnosed didn't match.");
            Assert.AreEqual(isMet, careLevel_I_Score.IsMet, "IsMet didn't match.");
            Assert.AreEqual(isDualDiagnosisCapable, careLevel_I_Score.IsDualDiagnosisCapable, "isDualDiagnosisCapable didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_I_Score.IsDualDiagnosisEnhanced, "isDualDiagnosisEnhanced didn't match.");
        }


        [TestMethod]
        [DataSource("Dx_CareLevelOpioidMaintenanceTherapyScore")]
        public void Dx_CalculateCareLevelOpioidMaintenanceTherapyScoreTests()
        {
            var ciwaCinaAndWithdrawalSicknessIndicator = TestContext.GetBoolean("CiwaCinaAndWithdrawalSicknessIndicator");
            var minimumDaysSinceLastUsedDrugExceptNicotine = TestContext.GetDouble("MinimumDaysSinceLastUsedDrugExceptNicotine");
            var signsOfIntoxicationExist = TestContext.GetLookup<YesNoNotSure>("SignsOfIntoxicationExist");
            var majorityOfInformationFromCollateralSource = TestContext.GetBoolean("MajorityOfInformationFromCollateralSource");
            var maxCuadScaleSumForOneDrugExceptNicotine = TestContext.GetInt32("MaxCuadScaleSumForOneDrugExceptNicotine");
            var anyAddictionDiagnosisExceptNicotine = TestContext.GetBoolean("AnyAddictionDiagnosisExceptNicotine");
            var numberOfTimesTreatedForAlcoholAbuseLifetime = TestContext.GetUInt32("NumberOfTimesTreatedForAlcoholAbuseLifetime");
            var numberOfTimesDrugTreatmentLifetime = TestContext.GetUInt32("NumberOfTimesDrugTreatmentLifetime");
            var interviewerScoreOfAlcoholTreatmentNeed = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfAlcoholTreatmentNeed"));
            var interviewerScoreOfDrugTreatmentNeed = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfDrugTreatmentNeed"));
            var withdrawalSymptomsAndEmotionalBehavioralProblems = TestContext.GetBoolean("WithdrawalSymptomsAndEmotionalBehavioralProblems");
            var doesPatientCarryPsychiatricDiagnosis = TestContext.GetLookup<PatientCarriesPsychiatricDiagnosis>("DoesPatientCarryPsychiatricDiagnosis");

            var isDiagnosed = TestContext.GetBoolean("IsDiagnosed");
            var isLikelyDiagnosed = TestContext.GetBoolean("IsLikelyDiagnosed");
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisCapable = TestContext.GetBoolean("IsDualDiagnosisCapable");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            var diagnosisScoringStrategy = new DiagnosisScoringStrategy(new SubstanceScoreCalculator());
            var careLevel_OMT_Score =
                diagnosisScoringStrategy.CalculateCareLevelOpioidMaintenanceTherapyScore (
                    ciwaCinaAndWithdrawalSicknessIndicator,
                    minimumDaysSinceLastUsedDrugExceptNicotine,
                    signsOfIntoxicationExist,
                    majorityOfInformationFromCollateralSource,
                    maxCuadScaleSumForOneDrugExceptNicotine,
                    anyAddictionDiagnosisExceptNicotine,
                    numberOfTimesTreatedForAlcoholAbuseLifetime,
                    numberOfTimesDrugTreatmentLifetime,
                    interviewerScoreOfAlcoholTreatmentNeed,
                    interviewerScoreOfDrugTreatmentNeed,
                    withdrawalSymptomsAndEmotionalBehavioralProblems,
                    doesPatientCarryPsychiatricDiagnosis );

            Assert.AreEqual(isDiagnosed, careLevel_OMT_Score.IsDiagnosed, "IsDiagnose didn't match.");
            Assert.AreEqual(isLikelyDiagnosed, careLevel_OMT_Score.IsLikelyDiagnosed, "IsLikelyDiagnosed didn't match.");
            Assert.AreEqual(isMet, careLevel_OMT_Score.IsMet, "IsDiagnose didn't match.");
            Assert.AreEqual(isDualDiagnosisCapable, careLevel_OMT_Score.IsDualDiagnosisCapable, "isDualDiagnosisCapable didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_OMT_Score.IsDualDiagnosisEnhanced, "isDualDiagnosisEnhanced didn't match.");
        }
    }
}