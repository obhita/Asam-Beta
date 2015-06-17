using Asam.Ppc.Domain.AssessmentModule.Completion;
using Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups;
using Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory;
using Asam.Ppc.Domain.AssessmentModule.Legal;
using Asam.Ppc.Domain.AssessmentModule.Medical;
using Asam.Ppc.Domain.AssessmentModule.Psychological;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.CommonModule.ValueObjects;
using Asam.Ppc.Domain.Scoring.ScoringModule.Dimension1Withdrawal;
using Asam.Ppc.Domain.Tests.Extensions;
using Asam.Ppc.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asam.Ppc.Domain.Tests.AssessmentModule.Scoring.Dimension1Withdrawal
{
    [TestClass]
    public class Dimension1ScoringStrategyTests
    {
        #region Public Properties

        public TestContext TestContext { get; set; }

        #endregion

        [TestMethod]
        [DataSource("D1_CommonScores")]
        public void D1_CalculateCommonScoresTests()
        {
            //var hasEverUsedAlcohol = TestContext.GetBoolean("HasEverUsedAlcohol");
            //var lastUsedAlcohol = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedAlcohol"));
            //var numberOfDaysUsedInPast30DaysAlcohol = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysAlcohol");
            //var alcoholUsedToIntoxicationAlcohol = TestContext.GetBoolean("AlcoholUsedToIntoxicationAlcohol");
            //var numberOfMonthsSinceLastAlcoholIntoxication = TestContext.GetUInt32("NumberOfMonthsSinceLastAlcoholIntoxication");
            //var numberOfDaysIntoxicatedInPast30DaysAlcohol = TestContext.GetUInt32("NumberOfDaysIntoxicatedInPast30DaysAlcohol");
            //var increasedDoseRequiredToGetSameEffectAlcohol = TestContext.GetBoolean("IncreasedDoseRequiredToGetSameEffectAlcohol");
            //var experiencesWithdrawalSicknessAlcohol = TestContext.GetBoolean("ExperiencesWithdrawalSicknessAlcohol");
            //var useSubstanceToPreventWithdrawalSicknessAlcohol = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessAlcohol");
            //var hasEverUsedHeroin = TestContext.GetBoolean("HasEverUsedHeroin");
            //var lastUsedHeroin = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedHeroin"));
            //var numberOfDaysUsedInPast30DaysHeroin = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysHeroin");
            //var increasedDoseRequiredToGetSameEffectHeroin = TestContext.GetBoolean("IncreasedDoseRequiredToGetSameEffectHeroin");
            //var experiencesWithdrawalSicknessHeroin = TestContext.GetBoolean("ExperiencesWithdrawalSicknessHeroin");
            //var useSubstanceToPreventWithdrawalSicknessHeroin = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessHeroin");
            //var hasEverUsedMethadone = TestContext.GetBoolean("HasEverUsedMethadone");
            //var lastUsedMethadone = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedMethadone"));
            //var numberOfDaysUsedInPast30DaysMethadone = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysMethadone");
            //var increasedDoseRequiredToGetSameEffectMethadone = TestContext.GetBoolean("IncreasedDoseRequiredToGetSameEffectMethadone");
            //var experiencesWithdrawalSicknessMethadone = TestContext.GetBoolean("ExperiencesWithdrawalSicknessMethadone");
            //var useSubstanceToPreventWithdrawalSicknessMethadone = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessMethadone");
            //var hasEverUsedOtherOpiate = TestContext.GetBoolean("HasEverUsedOtherOpiate");
            //var lastUsedOtherOpiate = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedOtherOpiate"));
            //var numberOfDaysUsedInPast30DaysOtherOpiate = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysOtherOpiate");
            //var increasedDoseRequiredToGetSameEffectOtherOpiate = TestContext.GetBoolean("IncreasedDoseRequiredToGetSameEffectOtherOpiate");
            //var experiencesWithdrawalSicknessOtherOpiate = TestContext.GetBoolean("ExperiencesWithdrawalSicknessOtherOpiate");
            //var useSubstanceToPreventWithdrawalSicknessOtherOpiate = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessOtherOpiate");
            //var hasEverUsedBarbiturate = TestContext.GetBoolean("HasEverUsedBarbiturate");
            //var lastUsedBarbiturate = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedBarbiturate"));
            //var numberOfDaysUsedInPast30DaysBarbiturate = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysBarbiturate");
            //var increasedDoseRequiredToGetSameEffectBarbiturate = TestContext.GetBoolean("IncreasedDoseRequiredToGetSameEffectBarbiturate");
            //var experiencesWithdrawalSicknessBarbiturate = TestContext.GetBoolean("ExperiencesWithdrawalSicknessBarbiturate");
            //var useSubstanceToPreventWithdrawalSicknessBarbiturate = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessBarbiturate");
            //var hasEverUsedOtherSedative = TestContext.GetBoolean("HasEverUsedOtherSedative");
            //var lastUsedOtherSedative = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedOtherSedative"));
            //var numberOfDaysUsedInPast30DaysOtherSedative = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysOtherSedative");
            //var experiencesWithdrawalSicknessOtherSedative = TestContext.GetBoolean("ExperiencesWithdrawalSicknessOtherSedative");
            //var useSubstanceToPreventWithdrawalSicknessOtherSedative = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessOtherSedative");
            //var unableToStopUsingSubstanceOtherSedative = TestContext.GetBoolean("UnableToStopUsingSubstanceOtherSedative");
            //var hasEverUsedCocaine = TestContext.GetBoolean("HasEverUsedCocaine");
            //var lastUsedCocaine = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedCocaine"));
            //var numberOfDaysUsedInPast30DaysCocaine = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysCocaine");
            //var increasedDoseRequiredToGetSameEffectCocaine = TestContext.GetBoolean("IncreasedDoseRequiredToGetSameEffectCocaine");
            //var experiencesWithdrawalSicknessCocaine = TestContext.GetBoolean("ExperiencesWithdrawalSicknessCocaine");
            //var useSubstanceToPreventWithdrawalSicknessCocaine = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessCocaine");
            //var hasEverUsedStimulant = TestContext.GetBoolean("HasEverUsedStimulant");
            //var lastUsedStimulant = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedStimulant"));
            //var numberOfDaysUsedInPast30DaysStimulant = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysStimulant");
            //var increasedDoseRequiredToGetSameEffectStimulant = TestContext.GetBoolean("IncreasedDoseRequiredToGetSameEffectStimulant");
            //var experiencesWithdrawalSicknessStimulant = TestContext.GetBoolean("ExperiencesWithdrawalSicknessStimulant");
            //var useSubstanceToPreventWithdrawalSicknessStimulant = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessStimulant");
            //var hasEverUsedCannabis = TestContext.GetBoolean("HasEverUsedCannabis");
            //var lastUsedCannabis = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedCannabis"));
            //var numberOfDaysUsedInPast30DaysCannabis = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysCannabis");
            //var increasedDoseRequiredToGetSameEffectCannabis = TestContext.GetBoolean("IncreasedDoseRequiredToGetSameEffectCannabis");
            //var experiencesWithdrawalSicknessCannabis = TestContext.GetBoolean("ExperiencesWithdrawalSicknessCannabis");
            //var useSubstanceToPreventWithdrawalSicknessCannabis = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessCannabis");
            //var hasEverUsedHallucinogen = TestContext.GetBoolean("HasEverUsedHallucinogen");
            //var lastUsedHallucinogen = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedHallucinogen"));
            //var numberOfDaysUsedInPast30DaysHallucinogen = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysHallucinogen");
            //var increasedDoseRequiredToGetSameEffectHallucinogen = TestContext.GetBoolean("IncreasedDoseRequiredToGetSameEffectHallucinogen");
            //var experiencesWithdrawalSicknessHallucinogen = TestContext.GetBoolean("ExperiencesWithdrawalSicknessHallucinogen");
            //var useSubstanceToPreventWithdrawalSicknessHallucinogen = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessHallucinogen");
            //var hasEverUsedSolventAndInhalant = TestContext.GetBoolean("HasEverUsedSolventAndInhalant");
            //var lastUsedSolventAndInhalant = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedSolventAndInhalant"));
            //var numberOfDaysUsedInPast30DaysSolventAndInhalant = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysSolventAndInhalant");
            //var experiencesWithdrawalSicknessSolventAndInhalant = TestContext.GetBoolean("ExperiencesWithdrawalSicknessSolventAndInhalant");
            //var useSubstanceToPreventWithdrawalSicknessSolventAndInhalant = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessSolventAndInhalant");
            //var unableToStopUsingSubstanceSolventAndInhalant = TestContext.GetBoolean("UnableToStopUsingSubstanceSolventAndInhalant");
            //var hasEverUsedOtherSubstance = TestContext.GetBoolean("HasEverUsedOtherSubstance");
            //var lastUsedOtherSubstance = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedOtherSubstance"));
            //var numberOfDaysUsedInPast30DaysOtherSubstance = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysOtherSubstance");
            //var increasedDoseRequiredToGetSameEffectOtherSubstance = TestContext.GetBoolean("IncreasedDoseRequiredToGetSameEffectOtherSubstance");
            //var experiencesWithdrawalSicknessOtherSubstance = TestContext.GetBoolean("ExperiencesWithdrawalSicknessOtherSubstance");
            //var useSubstanceToPreventWithdrawalSicknessOtherSubstance = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessOtherSubstance");
            
            //var hasAlcoholImminentWithdrawalPotential = TestContext.GetBoolean ( "HasAlcoholImminentWithdrawalPotential" );
            //var hasHeroinImminentWithdrawalPotential = TestContext.GetBoolean("HasHeroinImminentWithdrawalPotential");
            //var hasMethadoneImminentWithdrawalPotential = TestContext.GetBoolean("HasMethadoneImminentWithdrawalPotential");
            //var hasOtherOpiateImminentWithdrawalPotential = TestContext.GetBoolean("HasOtherOpiateImminentWithdrawalPotential");
            //var hasBarbiturateImminentWithdrawalPotential = TestContext.GetBoolean("HasBarbiturateImminentWithdrawalPotential");
            //var hasOtherSedativeImminentWithdrawalPotential = TestContext.GetBoolean("HasOtherSedativeImminentWithdrawalPotential");
            //var hasCocaineImminentWithdrawalPotential = TestContext.GetBoolean("HasCocaineImminentWithdrawalPotential");
            //var hasStimulantImminentWithdrawalPotential = TestContext.GetBoolean("HasStimulantImminentWithdrawalPotential");
            //var hasCannabisImminentWithdrawalPotential = TestContext.GetBoolean("HasCannabisImminentWithdrawalPotential");
            //var hasHallucinogenImminentWithdrawalPotential = TestContext.GetBoolean("HasHallucinogenImminentWithdrawalPotential");
            //var hasInhalantImminentWithdrawalPotential = TestContext.GetBoolean("HasInhalantImminentWithdrawalPotential");
            //var hasOtherSubstanceImminentWithdrawalPotential = TestContext.GetBoolean("HasOtherSubstanceImminentWithdrawalPotential");

            //var dimension1ScoringStrategy = new Dimension1ScoringStrategy();
            //var commonScores = dimension1ScoringStrategy.CalculateCommonScores (
            //    hasEverUsedAlcohol,
            //    lastUsedAlcohol,
            //    numberOfDaysUsedInPast30DaysAlcohol,
            //    alcoholUsedToIntoxicationAlcohol,
            //    numberOfMonthsSinceLastAlcoholIntoxication,
            //    numberOfDaysIntoxicatedInPast30DaysAlcohol,
            //    increasedDoseRequiredToGetSameEffectAlcohol,
            //    experiencesWithdrawalSicknessAlcohol,
            //    useSubstanceToPreventWithdrawalSicknessAlcohol,
            //    hasEverUsedHeroin,
            //    lastUsedHeroin,
            //    numberOfDaysUsedInPast30DaysHeroin,
            //    increasedDoseRequiredToGetSameEffectHeroin,
            //    experiencesWithdrawalSicknessHeroin,
            //    useSubstanceToPreventWithdrawalSicknessHeroin,
            //    hasEverUsedMethadone,
            //    lastUsedMethadone,
            //    numberOfDaysUsedInPast30DaysMethadone,
            //    increasedDoseRequiredToGetSameEffectMethadone,
            //    experiencesWithdrawalSicknessMethadone,
            //    useSubstanceToPreventWithdrawalSicknessMethadone,
            //    hasEverUsedOtherOpiate,
            //    lastUsedOtherOpiate,
            //    numberOfDaysUsedInPast30DaysOtherOpiate,
            //    increasedDoseRequiredToGetSameEffectOtherOpiate,
            //    experiencesWithdrawalSicknessOtherOpiate,
            //    useSubstanceToPreventWithdrawalSicknessOtherOpiate,
            //    hasEverUsedBarbiturate,
            //    lastUsedBarbiturate,
            //    numberOfDaysUsedInPast30DaysBarbiturate,
            //    increasedDoseRequiredToGetSameEffectBarbiturate,
            //    experiencesWithdrawalSicknessBarbiturate,
            //    useSubstanceToPreventWithdrawalSicknessBarbiturate,
            //    hasEverUsedOtherSedative,
            //    lastUsedOtherSedative,
            //    numberOfDaysUsedInPast30DaysOtherSedative,
            //    experiencesWithdrawalSicknessOtherSedative,
            //    useSubstanceToPreventWithdrawalSicknessOtherSedative,
            //    unableToStopUsingSubstanceOtherSedative,
            //    hasEverUsedCocaine,
            //    lastUsedCocaine,
            //    numberOfDaysUsedInPast30DaysCocaine,
            //    increasedDoseRequiredToGetSameEffectCocaine,
            //    experiencesWithdrawalSicknessCocaine,
            //    useSubstanceToPreventWithdrawalSicknessCocaine,
            //    hasEverUsedStimulant,
            //    lastUsedStimulant,
            //    numberOfDaysUsedInPast30DaysStimulant,
            //    increasedDoseRequiredToGetSameEffectStimulant,
            //    experiencesWithdrawalSicknessStimulant,
            //    useSubstanceToPreventWithdrawalSicknessStimulant,
            //    hasEverUsedCannabis,
            //    lastUsedCannabis,
            //    numberOfDaysUsedInPast30DaysCannabis,
            //    increasedDoseRequiredToGetSameEffectCannabis,
            //    experiencesWithdrawalSicknessCannabis,
            //    useSubstanceToPreventWithdrawalSicknessCannabis,
            //    hasEverUsedHallucinogen,
            //    lastUsedHallucinogen,
            //    numberOfDaysUsedInPast30DaysHallucinogen,
            //    increasedDoseRequiredToGetSameEffectHallucinogen,
            //    experiencesWithdrawalSicknessHallucinogen,
            //    useSubstanceToPreventWithdrawalSicknessHallucinogen,
            //    hasEverUsedSolventAndInhalant,
            //    lastUsedSolventAndInhalant,
            //    numberOfDaysUsedInPast30DaysSolventAndInhalant,
            //    experiencesWithdrawalSicknessSolventAndInhalant,
            //    useSubstanceToPreventWithdrawalSicknessSolventAndInhalant,
            //    unableToStopUsingSubstanceSolventAndInhalant,
            //    hasEverUsedOtherSubstance,
            //    lastUsedOtherSubstance,
            //    numberOfDaysUsedInPast30DaysOtherSubstance,
            //    increasedDoseRequiredToGetSameEffectOtherSubstance,
            //    experiencesWithdrawalSicknessOtherSubstance,
            //    useSubstanceToPreventWithdrawalSicknessOtherSubstance );

            //Assert.AreEqual(hasAlcoholImminentWithdrawalPotential, commonScores.HasAlcoholImminentWithdrawalPotential, "HasAlcoholImminentWithdrawalPotential didn't match.");
            //Assert.AreEqual(hasHeroinImminentWithdrawalPotential, commonScores.HasHeroinImminentWithdrawalPotential, "HasHeroinImminentWithdrawalPotential didn't match.");
            //Assert.AreEqual(hasMethadoneImminentWithdrawalPotential, commonScores.HasMethadoneImminentWithdrawalPotential, "HasMethadoneImminentWithdrawalPotential didn't match.");
            //Assert.AreEqual(hasOtherOpiateImminentWithdrawalPotential, commonScores.HasOtherOpiateImminentWithdrawalPotential, "HasOtherOpiateImminentWithdrawalPotential didn't match.");
            //Assert.AreEqual(hasBarbiturateImminentWithdrawalPotential, commonScores.HasBarbiturateImminentWithdrawalPotential, "HasBarbiturateImminentWithdrawalPotential didn't match.");
            //Assert.AreEqual(hasOtherSedativeImminentWithdrawalPotential, commonScores.HasOtherSedativeHypnoticImminentWithdrawalPotential, "HasOtherSedativeImminentWithdrawalPotential didn't match.");
            //Assert.AreEqual(hasCocaineImminentWithdrawalPotential, commonScores.HasCocaineImminentWithdrawalPotential, "HasCocaineImminentWithdrawalPotential didn't match.");
            //Assert.AreEqual(hasStimulantImminentWithdrawalPotential, commonScores.HasStimulantImminentWithdrawalPotential, "HasStimulantImminentWithdrawalPotential didn't match.");
            //Assert.AreEqual(hasCannabisImminentWithdrawalPotential, commonScores.HasCannabisImminentWithdrawalPotential, "HasCannabisImminentWithdrawalPotential didn't match.");
            //Assert.AreEqual(hasOtherSubstanceImminentWithdrawalPotential, commonScores.HasOtherSubstanceImminentWithdrawalPotential, "HasOtherSubstanceImminentWithdrawalPotential didn't match.");
            //Assert.AreEqual(hasInhalantImminentWithdrawalPotential, commonScores.HasInhalantImminentWithdrawalPotential, "HasInhalantImminentWithdrawalPotential didn't match.");
            //Assert.AreEqual(hasHallucinogenImminentWithdrawalPotential, commonScores.HasHallucinogenImminentWithdrawalPotential, "HasHallucinogenImminentWithdrawalPotential didn't match.");
        }


        [TestMethod]
        [DataSource("D1_CareLevel_I_DetoxificationScore")]
        public void D1_CalculateCareLevel_I_DetoxificationScoreTests()
        {
            var hasEverUsedAlcohol = TestContext.GetBoolean("HasEverUsedAlcohol");
            var lastUsedAlcohol =  new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedAlcohol"));
            var alcoholUsedToIntoxication = TestContext.GetBoolean("AlcoholUsedToIntoxication");
            var lastUsedToIntoxification = new TimeMeasure(UnitOfTime.Months, TestContext.GetUInt32("lastUsedToIntoxification"));
            var numberOfDaysUsedInPast30DaysAlcohol = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysAlcohol");
            var numberOfDaysIntoxicatedInPast30Days = TestContext.GetUInt32("NumberOfDaysIntoxicatedInPast30Days");
            var numberOfTimesWithdrawalCausedDeliriumTremens = TestContext.GetUInt32("NumberOfTimesWithdrawalCausedDeliriumTremens");
            var numberOfTimesWithdrawalCausedSeizures = TestContext.GetUInt32("NumberOfTimesWithdrawalCausedSeizures");
            var substanceOverdoseInPast24Hours = TestContext.GetLookup<YesNoNotSure>("SubstanceOverdoseInPast24Hours");
            var experiencesWithdrawalSicknessAlcohol = TestContext.GetBoolean("ExperiencesWithdrawalSicknessAlcohol");
            var useSubstanceToPreventWithdrawalSicknessAlcohol = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessAlcohol");
            var experiencedNauseaOrVomitedRecentlyCiwa = TestContext.GetLookup<ExperiencedNauseaOrVomitedRecently>("ExperiencedNauseaOrVomitedRecentlyCiwa");
            var observedTremorCiwa = TestContext.GetLookup<TremorObservation>("ObservedTremorCiwa");
            var observedSweatingCiwa = TestContext.GetLookup<SweatingObservation>("ObservedSweatingCiwa");
            var observedNervousness = TestContext.GetLookup<NervousnessObservation>("ObservedNervousness");
            var interviewerObservationOfPatientAgitationLevel = new ScaleOf0To7 ( TestContext.GetUInt32("InterviewerObservationOfPatientAgitationLevel"));
            var observedTactileDisturbances = TestContext.GetLookup<TactileDisturbancesObservation>("ObservedTactileDisturbances");
            var auditoryDisturbanceLevel = TestContext.GetLookup<AuditoryDisturbanceLevel>("AuditoryDisturbanceLevel");
            var visualDisturbanceLevel = TestContext.GetLookup<VisualDisturbanceLevel>("VisualDisturbanceLevel");
            var headAcheOrFullnessSeverity = TestContext.GetLookup<HeadAcheOrFullnessSeverity>("HeadAcheOrFullnessSeverity");
            var interviewerObservationOfPatientSenseOfAwareness = TestContext.GetLookup<SenseOfAwareness>("InterviewerObservationOfPatientSenseOfAwareness");
            var hasHealthCareProviderPrescribedUseBarbiturate = TestContext.GetBoolean("HasHealthCareProviderPrescribedUseBarbiturate");
            var wasSubstanceTakenAsPrescribedBarbiturate = TestContext.GetLookup<SubstanceTakenAsPrescribed>("WasSubstanceTakenAsPrescribedBarbiturate");
            var hasHealthCareProviderPrescribedUseOtherSedative = TestContext.GetBoolean("HasHealthCareProviderPrescribedUseOtherSedative");
            var wasSubstanceTakenAsPrescribedOtherSedative = TestContext.GetLookup<SubstanceTakenAsPrescribed>("WasSubstanceTakenAsPrescribedOtherSedative");
            var hasEverUsedBarbiturate = TestContext.GetBoolean("HasEverUsedBarbiturate");
            var lastUsedBarbiturate =  new TimeMeasure(UnitOfTime.Days,TestContext.GetUInt32("LastUsedBarbiturate"));
            var numberOfDaysUsedInPast30DaysBarbiturate = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysBarbiturate");
            var hasEverUsedOtherSedative = TestContext.GetBoolean("HasEverUsedOtherSedative");
            var lastUsedOtherSedative =  new TimeMeasure(UnitOfTime.Days,TestContext.GetUInt32("LastUsedOtherSedative"));
            var numberOfDaysUsedInPast30DaysOtherSedative = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysOtherSedative");
            var noNonSedativeDiagnosis = TestContext.GetBoolean("NoNonSedativeDiagnosis");
            var timingOfPositiveResponseToDetoxificationCare = TestContext.GetLookup<WithdrawalManagementCareResponseTiming>("TimingOfPositiveResponseToDetoxificationCare");
            var hasEverUsedHeroin = TestContext.GetBoolean("HasEverUsedHeroin");
            var lastUsedHeroin =  new TimeMeasure(UnitOfTime.Days,TestContext.GetUInt32("LastUsedHeroin"));
            var hasEverUsedMethadone = TestContext.GetBoolean("HasEverUsedMethadone");
            var lastUsedMethadone =  new TimeMeasure(UnitOfTime.Days,TestContext.GetUInt32("LastUsedMethadone"));
            var hasEverUsedOtherOpiate = TestContext.GetBoolean("HasEverUsedOtherOpiate");
            var lastUsedOtherOpiate =  new TimeMeasure(UnitOfTime.Days,TestContext.GetUInt32("LastUsedOtherOpiate"));
            var numberOfDaysUsedInPast30DaysHeroin = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysHeroin");
            var numberOfDaysUsedInPast30DaysMethadone = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysMethadone");
            var numberOfDaysUsedInPast30DaysOtherOpiate = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysOtherOpiate");
            var toBePrescribedOpioidDetoxificationProtocol = TestContext.GetLookup<OpioidDetoxificationProtocol>("ToBePrescribedOpioidDetoxificationProtocol");
            var wasSubstanceTakenAsPrescribedMethadone = TestContext.GetLookup<SubstanceTakenAsPrescribed>("WasSubstanceTakenAsPrescribedMethadone");
            var wasSubstanceTakenAsPrescribedOtherOpiate = TestContext.GetLookup<SubstanceTakenAsPrescribed>("WasSubstanceTakenAsPrescribedOtherOpiate");
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
            var heartRate = new HeartRate( TestContext.GetUInt32("HeartRate"));
            var graduallyDetoxedFromOpioidMaintenanceTherapy = TestContext.GetBoolean("GraduallyDetoxedFromOpioidMaintenanceTherapy");
            var hasEverUsedCocaine = TestContext.GetBoolean("HasEverUsedCocaine");
            var lastUsedCocaine =  new TimeMeasure(UnitOfTime.Days,TestContext.GetUInt32("LastUsedCocaine"));
            var hasEverUsedStimulant = TestContext.GetBoolean("HasEverUsedStimulant");
            var lastUsedStimulant =  new TimeMeasure(UnitOfTime.Days,TestContext.GetUInt32("LastUsedStimulant"));
            var numberOfDaysUsedInPast30DaysCocaine = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysCocaine");
            var numberOfDaysUsedInPast30DaysStimulant = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysStimulant");
            var rangeOfMoodInPastWeek = TestContext.GetLookup<RangeOfMood>("RangeOfMoodInPastWeek");
            var observedRetardationOfThoughtOrSpeech = TestContext.GetLookup<RetardationOfThoughtOrSpeech>("ObservedRetardationOfThoughtOrSpeech");
            var appearanceOfDepressionWithdrawal = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfDepressionWithdrawal"));
            var appearanceOfHostility = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfHostility"));
            var appearanceOfAnxietyNervousness = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfAnxietyNervousness"));
            var appearanceOfParanoiaOrImpairedThinking = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfParanoiaOrImpairedThinking"));
            var appearanceOfTroubleConcentratingOrRemembering = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfTroubleConcentratingOrRemembering"));
            var hasSuicidalThoughts = new ScaleOf0To8(TestContext.GetUInt32("HasSuicidalThoughts"));
            var numberOfDaysExperiencedSubstanceProblemsInPast30Days = TestContext.GetUInt32("NumberOfDaysExperiencedSubstanceProblemsInPast30Days");
            var strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers = TestContext.GetLookup<LikertScale>("StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggers");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var hasEverUsedNicotine = TestContext.GetBoolean("HasEverUsedNicotine");
            var lastUsedNicotine =  new TimeMeasure(UnitOfTime.Days,TestContext.GetUInt32("LastUsedNicotine"));
            var numberOfDaysUsedInPast30DaysNicotine = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysNicotine");
            var experiencesWithdrawalSicknessNicotine = TestContext.GetBoolean("ExperiencesWithdrawalSicknessNicotine");
            var useSubstanceToPreventWithdrawalSicknessNicotine = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessNicotine");
            var unableToStopUsingSubstanceNicotine = TestContext.GetBoolean("UnableToStopUsingSubstanceNicotine");
            var substanceUseReductionAttempted = TestContext.GetBoolean("SubstanceUseReductionAttempted");
            var hasUsedSubstanceKnowingProblemsWorsened = TestContext.GetBoolean("HasUsedSubstanceKnowingProblemsWorsened");
            var isPatientExperiencingWithdrawalSignsSymptoms = TestContext.GetLookup<SignsOfWithdrawal>("IsPatientExperiencingWithdrawalSignsSymptoms");
            var interviewerScoreOfReadiness = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfReadiness"));
            var concernsAboutPursuingTreatment = TestContext.GetLookup<ConcernsAboutPursuingTreatment>("ConcernsAboutPursuingTreatment");
            var desireAndExternalFactorsDrivingTreatment = TestContext.GetLookup<DesireAndExternalFactorsDrivingTreatment>("DesireAndExternalFactorsDrivingTreatment");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var closestContactsNeedsAndWillingnessToHelpTreatment = TestContext.GetLookup<NeedsAndWillingnessToHelpTreatment>("ClosestContactsNeedsAndWillingnessToHelpTreatment");
            var isSupportPersonAvailableFor7Days = TestContext.GetLookup<YesNoNotSure>("IsSupportPersonAvailableFor7Days");
            var isOutpatientMonitoringAvailable8To24Hours = TestContext.GetLookup<YesNoNotSure>("IsOutpatientMonitoringAvailable8To24Hours");
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var respondedPositivelyToEmotionalSupportDuringInterview = TestContext.GetBoolean("RespondedPositivelyToEmotionalSupportDuringInterview");
            var significantPeriodImpairedThoughtInLast24Hours = TestContext.GetLookup<LikertScale>("SignificantPeriodImpairedThoughtInLast24Hours");
            
            var minimumRiskSevereWithdrawalSyndromeCanSafelyManage = TestContext.GetBoolean("MinimumRiskSevereWithdrawalSyndromeCanSafelyManage");
            var mildToModerateAlcoholWithdrawalCIWALessThan10 = TestContext.GetBoolean("MildToModerateAlcoholWithdrawalCIWALessThan8");
            var recentSedativeUseNotComplicatedByAlcoholUseToProduceWithdrawal = TestContext.GetBoolean("RecentSedativeUseNotComplicatedByAlcoholUseToProduceWithdrawal");
            var reliableHistoryWithdrawingFromTherapeuticSedativeDoses = TestContext.GetBoolean("ReliableHistoryWithdrawingFromTherapeuticSedativeDoses");
            var useOfHighPotencyOpiatesNotBeenDailyForMoreThan2Weeks = TestContext.GetBoolean("UseOfHighPotencyOpiatesNotBeenDailyForMoreThan2Weeks");
            var isBeingOpiateDetoxedGraduallyOrTreatedForMildWithdrawal = TestContext.GetBoolean("IsBeingOpiateDetoxedGraduallyOrTreatedForMildWithdrawal");
            var isExperiencingStimulantsWithdrawalButGoodImpulseControl = TestContext.GetBoolean("IsExperiencingStimulantsWithdrawalButGoodImpulseControl");
            var isExperiencingNicotineWithdrawalRequiresSymptomaticTreatment = TestContext.GetBoolean("IsExperiencingNicotineWithdrawalRequiresSymptomaticTreatment");
            var hasWithdrawalSymptomsMinimalRiskCanCompleteNeededDetox = TestContext.GetBoolean("HasWithdrawalSymptomsMinimalRiskCanCompleteNeededDetox");
            var hasAndRespondsToEmotionalSupportAndComfort = TestContext.GetBoolean("HasAndRespondsToEmotionalSupportAndComfort");
            var isMet = TestContext.GetBoolean("IsMet");

            if(TestContext.GetBoolean ( "ForDebug" ))
            {
                
            }

            var dimension1ScoringStrategy = new Dimension1ScoringStrategy();
            var careLevel_I_DetoxificationScore = dimension1ScoringStrategy.CalculateCareLevel_I_DetoxificationScore (
                hasEverUsedAlcohol,
                lastUsedAlcohol,
                alcoholUsedToIntoxication,
                lastUsedToIntoxification,
                numberOfDaysUsedInPast30DaysAlcohol,
                numberOfDaysIntoxicatedInPast30Days,
                numberOfTimesWithdrawalCausedDeliriumTremens,
                numberOfTimesWithdrawalCausedSeizures,
                substanceOverdoseInPast24Hours,
                experiencesWithdrawalSicknessAlcohol,
                useSubstanceToPreventWithdrawalSicknessAlcohol,
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
                hasHealthCareProviderPrescribedUseBarbiturate,
                wasSubstanceTakenAsPrescribedBarbiturate,
                hasHealthCareProviderPrescribedUseOtherSedative,
                wasSubstanceTakenAsPrescribedOtherSedative,
                hasEverUsedBarbiturate,
                lastUsedBarbiturate,
                numberOfDaysUsedInPast30DaysBarbiturate,
                hasEverUsedOtherSedative,
                lastUsedOtherSedative,
                numberOfDaysUsedInPast30DaysOtherSedative,
                noNonSedativeDiagnosis,
                timingOfPositiveResponseToDetoxificationCare,
                hasEverUsedHeroin,
                lastUsedHeroin,
                hasEverUsedMethadone,
                lastUsedMethadone,
                hasEverUsedOtherOpiate,
                lastUsedOtherOpiate,
                numberOfDaysUsedInPast30DaysHeroin,
                numberOfDaysUsedInPast30DaysMethadone,
                numberOfDaysUsedInPast30DaysOtherOpiate,
                toBePrescribedOpioidDetoxificationProtocol,
                wasSubstanceTakenAsPrescribedMethadone,
                wasSubstanceTakenAsPrescribedOtherOpiate,
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
                graduallyDetoxedFromOpioidMaintenanceTherapy,
                hasEverUsedCocaine,
                lastUsedCocaine,
                hasEverUsedStimulant,
                lastUsedStimulant,
                numberOfDaysUsedInPast30DaysCocaine,
                numberOfDaysUsedInPast30DaysStimulant,
                rangeOfMoodInPastWeek,
                observedRetardationOfThoughtOrSpeech,
                appearanceOfDepressionWithdrawal,
                appearanceOfHostility,
                appearanceOfAnxietyNervousness,
                appearanceOfParanoiaOrImpairedThinking,
                appearanceOfTroubleConcentratingOrRemembering,
                hasSuicidalThoughts,
                numberOfDaysExperiencedSubstanceProblemsInPast30Days,
                strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers,
                strategyToPreventRelapse,
                hasEverUsedNicotine,
                lastUsedNicotine,
                numberOfDaysUsedInPast30DaysNicotine,
                experiencesWithdrawalSicknessNicotine,
                useSubstanceToPreventWithdrawalSicknessNicotine,
                unableToStopUsingSubstanceNicotine,
                substanceUseReductionAttempted,
                hasUsedSubstanceKnowingProblemsWorsened,
                isPatientExperiencingWithdrawalSignsSymptoms,
                interviewerScoreOfReadiness,
                concernsAboutPursuingTreatment,
                desireAndExternalFactorsDrivingTreatment,
                livingArrangementAffectOnRecovery,
                closestContactsNeedsAndWillingnessToHelpTreatment,
                isSupportPersonAvailableFor7Days,
                isOutpatientMonitoringAvailable8To24Hours,
                helpfulnessOfTreatment,
                respondedPositivelyToEmotionalSupportDuringInterview,
                significantPeriodImpairedThoughtInLast24Hours );


            Assert.AreEqual(minimumRiskSevereWithdrawalSyndromeCanSafelyManage, careLevel_I_DetoxificationScore.MinimumRiskSevereWithdrawalSyndromeCanSafelyManage, "MinimumRiskSevereWithdrawalSyndromeCanSafelyManage didn't match.");
            Assert.AreEqual(mildToModerateAlcoholWithdrawalCIWALessThan10, careLevel_I_DetoxificationScore.MildToModerateAlcoholWithdrawalCIWALessThan10, "MildToModerateAlcoholWithdrawalCIWALessThan8 didn't match.");
            Assert.AreEqual(recentSedativeUseNotComplicatedByAlcoholUseToProduceWithdrawal, careLevel_I_DetoxificationScore.RecentSedativeUseNotComplicatedByAlcoholUseToProduceWithdrawal, "RecentSedativeUseNotComplicatedByAlcoholUseToProduceWithdrawal didn't match.");
            Assert.AreEqual(reliableHistoryWithdrawingFromTherapeuticSedativeDoses, careLevel_I_DetoxificationScore.ReliableHistoryWithdrawingFromTherapeuticSedativeDoses, "ReliableHistoryWithdrawingFromTherapeuticSedativeDoses didn't match.");
            Assert.AreEqual(useOfHighPotencyOpiatesNotBeenDailyForMoreThan2Weeks, careLevel_I_DetoxificationScore.UseOfHighPotencyOpiatesNotBeenDailyForMoreThan2Weeks, "UseOfHighPotencyOpiatesNotBeenDailyForMoreThan2Weeks didn't match.");
            Assert.AreEqual(isBeingOpiateDetoxedGraduallyOrTreatedForMildWithdrawal, careLevel_I_DetoxificationScore.IsBeingOpiateDetoxedGraduallyOrTreatedForMildWithdrawal, "IsBeingOpiateDetoxedGraduallyOrTreatedForMildWithdrawal didn't match.");
            Assert.AreEqual(isExperiencingStimulantsWithdrawalButGoodImpulseControl, careLevel_I_DetoxificationScore.IsExperiencingStimulantsWithdrawalButGoodImpulseControl, "IsExperiencingStimulantsWithdrawalButGoodImpulseControl didn't match.");
            Assert.AreEqual(isExperiencingNicotineWithdrawalRequiresSymptomaticTreatment, careLevel_I_DetoxificationScore.IsExperiencingNicotineWithdrawalRequiresSymptomaticTreatment, "IsExperiencingNicotineWithdrawalRequiresSymptomaticTreatment didn't match.");
            Assert.AreEqual(hasWithdrawalSymptomsMinimalRiskCanCompleteNeededDetox, careLevel_I_DetoxificationScore.HasWithdrawalSymptomsMinimalRiskCanCompleteNeededDetox, "HasWithdrawalSymptomsMinimalRiskCanCompleteNeededDetox didn't match.");
            Assert.AreEqual(hasAndRespondsToEmotionalSupportAndComfort, careLevel_I_DetoxificationScore.HasAndRespondsToEmotionalSupportAndComfort, "HasAndRespondsToEmotionalSupportAndComfort didn't match.");
            Assert.AreEqual(isMet, careLevel_I_DetoxificationScore.IsMet, "careLevel_I_DetoxificationScore didn't match.");
        }


        [TestMethod]
        [DataSource("D1_CareLevel_II_DetoxificationScore")]
        public void D1_CalculateCareLevel_II_DetoxificationScoreTests()
        {
            var hasEverUsedAlcohol = TestContext.GetBoolean("HasEverUsedAlcohol");
            var lastUsedAlcohol = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedAlcohol"));
            var alcoholUsedToIntoxication = TestContext.GetBoolean("AlcoholUsedToIntoxication");
            var lastUsedToIntoxification = new TimeMeasure(UnitOfTime.Months, TestContext.GetUInt32("LastUsedToIntoxification"));
            var numberOfDaysUsedInPast30DaysAlcohol = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysAlcohol");
            var numberOfDaysIntoxicatedInPast30Days = TestContext.GetUInt32("NumberOfDaysIntoxicatedInPast30Days");
            var numberOfTimesWithdrawalCausedDeliriumTremensAlcohol = TestContext.GetUInt32("NumberOfTimesWithdrawalCausedDeliriumTremensAlcohol");
            var numberOfTimesWithdrawalCausedSeizuresAlcohol = TestContext.GetUInt32("NumberOfTimesWithdrawalCausedSeizuresAlcohol");
            var substanceOverdoseInPast24HoursAlcohol = TestContext.GetLookup<YesNoNotSure>("SubstanceOverdoseInPast24HoursAlcohol");
            var experiencesWithdrawalSicknessAlcohol = TestContext.GetBoolean("ExperiencesWithdrawalSicknessAlcohol");
            var useSubstanceToPreventWithdrawalSicknessAlcohol = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessAlcohol");
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
            var d2CareLevel_II_1_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_II_1_ScoreIsMet");
            var d3CareLevel_II_1_ScoreIsMet = TestContext.GetBoolean("D3CareLevel_II_1_ScoreIsMet");
            var d2CareLevel_II_5_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_II_5_ScoreIsMet");
            var d3CareLevel_II_5_ScoreIsMet = TestContext.GetBoolean("D3CareLevel_II_5_ScoreIsMet");
            var hasEverUsedBarbiturate = TestContext.GetBoolean("HasEverUsedBarbiturate");
            var lastUsedBarbiturate = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedBarbiturate"));
            var numberOfDaysUsedInPast30DaysBarbiturate = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysBarbiturate");
            var increasedDoseRequiredToGetSameEffectBarbiturate = TestContext.GetBoolean("IncreasedDoseRequiredToGetSameEffectBarbiturate");
            var experiencesWithdrawalSicknessBarbiturate = TestContext.GetBoolean("ExperiencesWithdrawalSicknessBarbiturate");
            var useSubstanceToPreventWithdrawalSicknessBarbiturate = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessBarbiturate");
            var hasEverUsedOtherSedative = TestContext.GetBoolean("HasEverUsedOtherSedative");
            var lastUsedOtherSedative = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedOtherSedative"));
            var numberOfDaysUsedInPast30DaysOtherSedative = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysOtherSedative");
            var experiencesWithdrawalSicknessOtherSedative = TestContext.GetBoolean("ExperiencesWithdrawalSicknessOtherSedative");
            var useSubstanceToPreventWithdrawalSicknessOtherSedative = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessOtherSedative");
            var unableToStopUsingSubstanceOtherSedative = TestContext.GetBoolean("UnableToStopUsingSubstanceOtherSedative");
            var noNonSedativeDiagnosis = TestContext.GetBoolean("NoNonSedativeDiagnosis");
            var timingOfPositiveResponseToDetoxificationCare = TestContext.GetLookup<WithdrawalManagementCareResponseTiming>("TimingOfPositiveResponseToDetoxificationCare");
            var wasSubstanceTakenAsPrescribedBarbiturate = TestContext.GetLookup<SubstanceTakenAsPrescribed>("WasSubstanceTakenAsPrescribedBarbiturate");
            var wasSubstanceTakenAsPrescribedOtherSedative = TestContext.GetLookup<SubstanceTakenAsPrescribed>("WasSubstanceTakenAsPrescribedOtherSedative");
            var d2CareLevel_0_5_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_0_5_ScoreIsMet");
            var d2CareLevel_III_1_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_III_1_ScoreIsMet");
            var d2CareLevel_I_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_I_ScoreIsMet");
            var d2CareLevel_III_1_ScoreIsMetDim2Level3LowIntensity = TestContext.GetBoolean("D2CareLevel_III_1_ScoreIsMetDim2Level3LowIntensity");
            var d2CareLevel_III_3_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_III_3_ScoreIsMet");
            var d2CareLevel_III_3_ScoreIsMetDim2Level3ModerateIntensity = TestContext.GetBoolean("D2CareLevel_III_3_ScoreIsMetDim2Level3ModerateIntensity");
            var d2CareLevel_III_5_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_III_5_ScoreIsMet");
            var d2CareLevel_III_5_ScoreIsMetDim2Level3HighIntensity = TestContext.GetBoolean("D2CareLevel_III_5_ScoreIsMetDim2Level3HighIntensity");
            var d2CareLevel_III_7_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_III_7_ScoreIsMet");
            var d2CareLevel_III_7_ScoreIsMetDim2Level3MedicalMonitoring = TestContext.GetBoolean("D2CareLevel_III_7_ScoreIsMetDim2Level3MedicalMonitoring");
            var d2CareLevel_IV_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_IV_ScoreIsMet");
            var d3CareLevel_IV_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D3CareLevel_IV_ScoreIsDualDiagnosisEnhanced");
            var numberOfMonthsUsedInLifetimeBarbiturate = TestContext.GetUInt32("NumberOfMonthsUsedInLifetimeBarbiturate");
            var numberOfMonthsUsedInLifetimeOtherSedative = TestContext.GetUInt32("NumberOfMonthsUsedInLifetimeOtherSedative");
            var symptomsLifeThreateningBecauseOfSubstanceUse = TestContext.GetLookup<YesNoNotSure>("SymptomsLifeThreateningBecauseOfSubstanceUse");
            var rangeOfMoodInPastWeek = TestContext.GetLookup<RangeOfMood>("RangeOfMoodInPastWeek");
            var rangeOfGuiltInPastWeek = TestContext.GetLookup<RangeOfGuilt>("RangeOfGuiltInPastWeek");
            var rangeOfInterestInDoingThingsInPastWeek = TestContext.GetLookup<RangeOfInterestInDoingThings>("RangeOfInterestInDoingThingsInPastWeek");
            var rangeOfEnergyInPastWeek = TestContext.GetLookup<RangeOfEnergy>("RangeOfEnergyInPastWeek");
            var rangeOfIrritabilityInPastWeek = TestContext.GetLookup<RangeOfIrritability>("RangeOfIrritabilityInPastWeek");
            var observedRetardationOfThoughtOrSpeech = TestContext.GetLookup<RetardationOfThoughtOrSpeech>("ObservedRetardationOfThoughtOrSpeech");
            var prnHourlyMonitoringSufficientToDetermineDetoxServiceLevel = TestContext.GetBoolean("PrnHourlyMonitoringSufficientToDetermineDetoxServiceLevel");
            var numberOfDaysUsedInPast30DaysHeroin = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysHeroin");
            var numberOfDaysUsedInPast30DaysMethadone = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysMethadone");
            var numberOfDaysUsedInPast30DaysOtherOpiate = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysOtherOpiate");
            var hasEverUsedHeroin = TestContext.GetBoolean("HasEverUsedHeroin");
            var lastUsedHeroin = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedHeroin"));
            var hasEverUsedMethadone = TestContext.GetBoolean("HasEverUsedMethadone");
            var lastUsedMethadone = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedMethadone"));
            var hasEverUsedOtherOpiate = TestContext.GetBoolean("HasEverUsedOtherOpiate");
            var lastUsedOtherOpiate = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedOtherOpiate"));
            var toBePrescribedOpioidDetoxificationProtocol = TestContext.GetLookup<OpioidDetoxificationProtocol>("ToBePrescribedOpioidDetoxificationProtocol");
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
            var hasEverUsedCocaine = TestContext.GetBoolean("HasEverUsedCocaine");
            var lastUsedCocaine = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedCocaine"));
            var hasEverUsedStimulant = TestContext.GetBoolean("HasEverUsedStimulant");
            var lastUsedStimulant = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedStimulant"));
            var numberOfDaysUsedInPast30DaysCocaine = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysCocaine");
            var numberOfDaysUsedInPast30DaysStimulant = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysStimulant");
            var appearanceOfDepressionWithdrawal = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfDepressionWithdrawal"));
            var appearanceOfHostility = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfHostility"));
            var appearanceOfAnxietyNervousness = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfAnxietyNervousness"));
            var appearanceOfParanoiaOrImpairedThinking = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfParanoiaOrImpairedThinking"));
            var appearanceOfTroubleConcentratingOrRemembering = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfTroubleConcentratingOrRemembering"));
            var hasSuicidalThoughts = new ScaleOf0To8(TestContext.GetUInt32("HasSuicidalThoughts"));
            var numberOfDaysExperiencedSubstanceProblemsInPast30Days = TestContext.GetUInt32("NumberOfDaysExperiencedSubstanceProblemsInPast30Days");
            var strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers = TestContext.GetLookup<LikertScale>("StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggers");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var isPatientExperiencingWithdrawalSignsSymptoms = TestContext.GetLookup<SignsOfWithdrawal>("IsPatientExperiencingWithdrawalSignsSymptoms");
            var significantPeriodImpairedThoughtInLastMonth = TestContext.GetLookup<LikertScale>("SignificantPeriodImpairedThoughtInLastMonth");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var closestContactsNeedsAndWillingnessToHelpTreatment = TestContext.GetLookup<NeedsAndWillingnessToHelpTreatment>("ClosestContactsNeedsAndWillingnessToHelpTreatment");
            var isSupportPersonAvailableFor7Days = TestContext.GetLookup<YesNoNotSure>("IsSupportPersonAvailableFor7Days");
            var isOutpatientMonitoringAvailable8To24Hours = TestContext.GetLookup<YesNoNotSure>("IsOutpatientMonitoringAvailable8To24Hours");
            var interviewerScoreOfReadiness = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfReadiness"));
            var concernsAboutPursuingTreatment = TestContext.GetLookup<ConcernsAboutPursuingTreatment>("ConcernsAboutPursuingTreatment");
            var desireAndExternalFactorsDrivingTreatment = TestContext.GetLookup<DesireAndExternalFactorsDrivingTreatment>("DesireAndExternalFactorsDrivingTreatment");
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");


            var moderateRiskOfSevereWithdrawalOutsideProgramSetting = TestContext.GetBoolean("ModerateRiskOfSevereWithdrawalOutsideProgramSetting");
            var alcoholCIWAScore10To18 = TestContext.GetBoolean("AlcoholCIWAScore8To15");
            var historyOfWithdrawalFromSedativesOtherDrugDependenceRespondedTo = TestContext.GetBoolean("HistoryOfWithdrawalFromSedativesOtherDrugDependenceRespondedTo");
            var hasIngestedSedativesExcessTherapeuticLevelAtLeast4WeeksMinimalRisk = TestContext.GetBoolean("HasInjectedSedativesExcessTherapeuticLevelAtLeast4WeeksMinimal");
            var hasIngestedSedativesTherapeuticLevelAtLeast6MonthsSymptomMinimalRisk = TestContext.GetBoolean("HasInjectedSedativesTherapeuticLevelAtLeast6MonthsSymptomMinimal");
            var abstinenceSyndromeCanBeStabilizedAtHomeWithAppropriateSupervision = TestContext.GetBoolean("AbstinenceSyndromeCanBeStabilizedAtHomeWithAppropriate");
            var withdrawalFromOpiatesSymptomsSeverityWarrantsExtendedMonitoring = TestContext.GetBoolean("WithdrawalFromOpiatesSymptomsSeverityWarrantsExtendedMonitoring");
            var stimulantsWithdrawalReadinessForAmbulatoryOrClinicallyManagedLevels = TestContext.GetBoolean("StimulantsWithdrawalReadinessForAmbulatoryOrClinicallyManaged");
            var likelyToCompleteDetoxEnterContinuedTreatmentOrSelfHelpRecovery = TestContext.GetBoolean("LikelyToCompleteDetoxEnterContinuedTreatmentOrSelfHelpRecovery");
            var isMet = TestContext.GetBoolean("IsMet");

            if(TestContext.GetBoolean ( "ForDebug" ))
            {
                
            }

            var dimension1ScoringStrategy = new Dimension1ScoringStrategy();
            var careLevel_II_Detox_Score = dimension1ScoringStrategy.CalculateCareLevel_II_DetoxificationScore (
                hasEverUsedAlcohol,
                lastUsedAlcohol,
                alcoholUsedToIntoxication,
                lastUsedToIntoxification,
                numberOfDaysUsedInPast30DaysAlcohol,
                numberOfDaysIntoxicatedInPast30Days,
                numberOfTimesWithdrawalCausedDeliriumTremensAlcohol,
                numberOfTimesWithdrawalCausedSeizuresAlcohol,
                substanceOverdoseInPast24HoursAlcohol,
                experiencesWithdrawalSicknessAlcohol,
                useSubstanceToPreventWithdrawalSicknessAlcohol,
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
                d2CareLevel_II_1_ScoreIsMet,
                d3CareLevel_II_1_ScoreIsMet,
                d2CareLevel_II_5_ScoreIsMet,
                d3CareLevel_II_5_ScoreIsMet,
                hasEverUsedBarbiturate,
                lastUsedBarbiturate,
                numberOfDaysUsedInPast30DaysBarbiturate,
                increasedDoseRequiredToGetSameEffectBarbiturate,
                experiencesWithdrawalSicknessBarbiturate,
                useSubstanceToPreventWithdrawalSicknessBarbiturate,
                hasEverUsedOtherSedative,
                lastUsedOtherSedative,
                numberOfDaysUsedInPast30DaysOtherSedative,
                experiencesWithdrawalSicknessOtherSedative,
                useSubstanceToPreventWithdrawalSicknessOtherSedative,
                unableToStopUsingSubstanceOtherSedative,
                noNonSedativeDiagnosis,
                timingOfPositiveResponseToDetoxificationCare,
                wasSubstanceTakenAsPrescribedBarbiturate,
                wasSubstanceTakenAsPrescribedOtherSedative,
                d2CareLevel_0_5_ScoreIsMet,
                d2CareLevel_III_1_ScoreIsMet,
                d2CareLevel_I_ScoreIsMet,
                d2CareLevel_III_1_ScoreIsMetDim2Level3LowIntensity,
                d2CareLevel_III_3_ScoreIsMet,
                d2CareLevel_III_3_ScoreIsMetDim2Level3ModerateIntensity,
                d2CareLevel_III_5_ScoreIsMet,
                d2CareLevel_III_5_ScoreIsMetDim2Level3HighIntensity,
                d2CareLevel_III_7_ScoreIsMet,
                d2CareLevel_III_7_ScoreIsMetDim2Level3MedicalMonitoring,
                d2CareLevel_IV_ScoreIsMet,
                d3CareLevel_IV_ScoreIsDualDiagnosisEnhanced,
                numberOfMonthsUsedInLifetimeBarbiturate,
                numberOfMonthsUsedInLifetimeOtherSedative,
                symptomsLifeThreateningBecauseOfSubstanceUse,
                rangeOfMoodInPastWeek,
                rangeOfGuiltInPastWeek,
                rangeOfInterestInDoingThingsInPastWeek,
                rangeOfEnergyInPastWeek,
                rangeOfIrritabilityInPastWeek,
                observedRetardationOfThoughtOrSpeech,
                prnHourlyMonitoringSufficientToDetermineDetoxServiceLevel,
                numberOfDaysUsedInPast30DaysHeroin,
                numberOfDaysUsedInPast30DaysMethadone,
                numberOfDaysUsedInPast30DaysOtherOpiate,
                hasEverUsedHeroin,
                lastUsedHeroin,
                hasEverUsedMethadone,
                lastUsedMethadone,
                hasEverUsedOtherOpiate,
                lastUsedOtherOpiate,
                toBePrescribedOpioidDetoxificationProtocol,
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
                hasEverUsedCocaine,
                lastUsedCocaine,
                hasEverUsedStimulant,
                lastUsedStimulant,
                numberOfDaysUsedInPast30DaysCocaine,
                numberOfDaysUsedInPast30DaysStimulant,
                appearanceOfDepressionWithdrawal,
                appearanceOfHostility,
                appearanceOfAnxietyNervousness,
                appearanceOfParanoiaOrImpairedThinking,
                appearanceOfTroubleConcentratingOrRemembering,
                hasSuicidalThoughts,
                numberOfDaysExperiencedSubstanceProblemsInPast30Days,
                strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers,
                strategyToPreventRelapse,
                isPatientExperiencingWithdrawalSignsSymptoms,
                significantPeriodImpairedThoughtInLastMonth,
                livingArrangementAffectOnRecovery,
                closestContactsNeedsAndWillingnessToHelpTreatment,
                isSupportPersonAvailableFor7Days,
                isOutpatientMonitoringAvailable8To24Hours,
                interviewerScoreOfReadiness,
                concernsAboutPursuingTreatment,
                desireAndExternalFactorsDrivingTreatment,
                helpfulnessOfTreatment,
                possibleFutureRelapseCause );

            Assert.AreEqual(moderateRiskOfSevereWithdrawalOutsideProgramSetting, careLevel_II_Detox_Score.ModerateRiskOfSevereWithdrawalOutsideProgramSetting, "ModerateRiskOfSevereWithdrawalOutsideProgramSetting didn't match.");
            Assert.AreEqual(alcoholCIWAScore10To18, careLevel_II_Detox_Score.AlcoholCIWAScore10To18, "AlcoholCIWAScore8To15 didn't match.");
            Assert.AreEqual(hasIngestedSedativesTherapeuticLevelAtLeast6MonthsSymptomMinimalRisk, careLevel_II_Detox_Score.HasIngestedSedativesTherapeuticLevelAtLeast6MonthsSymptomMinimalRisk, "HasInjectedSedativesTherapeuticLevelAtLeast6MonthsSymptomMinimalRisk didn't match.");
            Assert.AreEqual(historyOfWithdrawalFromSedativesOtherDrugDependenceRespondedTo, careLevel_II_Detox_Score.HistoryOfWithdrawalFromSedativesOtherDrugDependenceRespondedTo, "HistoryOfWithdrawalFromSedativesOtherDrugDependenceRespondedTo didn't match.");
            Assert.AreEqual(hasIngestedSedativesExcessTherapeuticLevelAtLeast4WeeksMinimalRisk, careLevel_II_Detox_Score.HasIngestedSedativesExcessTherapeuticLevelAtLeast4WeeksMinimalRisk, "HasInjectedSedativesExcessTherapeuticLevelAtLeast4WeeksMinimalRisk didn't match.");
            Assert.AreEqual(abstinenceSyndromeCanBeStabilizedAtHomeWithAppropriateSupervision, careLevel_II_Detox_Score.AbstinenceSyndromeCanBeStabilizedAtHomeWithAppropriateSupervision, "AbstinenceSyndromeCanBeStabilizedAtHomeWithAppropriateSupervision didn't match.");
            Assert.AreEqual(withdrawalFromOpiatesSymptomsSeverityWarrantsExtendedMonitoring, careLevel_II_Detox_Score.WithdrawalFromOpiatesSymptomsSeverityWarrantsExtendedMonitoring, "WithdrawalFromOpiatesSymptomsSeverityWarrantsExtendedMonitoring didn't match.");
            Assert.AreEqual(stimulantsWithdrawalReadinessForAmbulatoryOrClinicallyManagedLevels, careLevel_II_Detox_Score.StimulantsWithdrawalReadinessForAmbulatoryOrClinicallyManagedLevels, "StimulantsWithdrawalReadinessForAmbulatoryOrClinicallyManagedLevels didn't match.");
            Assert.AreEqual(likelyToCompleteDetoxEnterContinuedTreatmentOrSelfHelpRecovery, careLevel_II_Detox_Score.LikelyToCompleteDetoxEnterContinuedTreatmentOrSelfHelpRecovery, "LikelyToCompleteDetoxEnterContinuedTreatmentOrSelfHelpRecovery didn't match.");
            Assert.AreEqual(isMet, careLevel_II_Detox_Score.IsMet, "careLevel_II_Detox_Score didn't match.");
        }
        
        [TestMethod]
        [DataSource("D1_CareLevel_III_2_DetoxificationScore")]
        public void D1_CalculateCareLevel_III_2_DetoxificationScoreTests()
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
            var prnHourlyMonitoringSufficientToDetermineDetoxServiceLevel = TestContext.GetBoolean("PrnHourlyMonitoringSufficientToDetermineDetoxServiceLevel");
            var hasEverUsedHeroin = TestContext.GetBoolean("HasEverUsedHeroin");
            var lastUsedHeroin = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedHeroin"));
            var hasEverUsedMethadone = TestContext.GetBoolean("HasEverUsedMethadone");
            var lastUsedMethadone = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedMethadone"));
            var hasEverUsedOtherOpiate = TestContext.GetBoolean("HasEverUsedOtherOpiate");
            var lastUsedOtherOpiate = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedOtherOpiate"));
            var numberOfDaysUsedInPast30DaysHeroin = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysHeroin");
            var numberOfDaysUsedInPast30DaysMethadone = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysMethadone");
            var numberOfDaysUsedInPast30DaysOtherOpiate = TestContext.GetUInt32("NumberOfDaysUsedInPast30Days");
            var toBePrescribedOpioidDetoxificationProtocol = TestContext.GetLookup<OpioidDetoxificationProtocol>("ToBePrescribedOpioidDetoxificationProtocol");
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
            var timingOfPositiveResponseToDetoxificationCare = TestContext.GetLookup<WithdrawalManagementCareResponseTiming>("TimingOfPositiveResponseToDetoxificationCare");
            var amountOfMoneySpentInLast30DaysAlcohol = new Money(Currency.UnitedStatesEnglish,TestContext.GetDecimal("AmountOfMoneySpentInLast30DaysAlcohol"));
            var numberOfDaysExperiencedSubstanceProblemsInPast30Days = TestContext.GetUInt32("NumberOfDaysExperiencedSubstanceProblemsInPast30Days");
            var strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers = TestContext.GetLookup<LikertScale>("StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggers");
            var currentStrengthOfSubstanceUseDesire = TestContext.GetLookup<LikertScale>("CurrentStrengthOfSubstanceUseDesire");
            var hasEverUsedCocaine = TestContext.GetBoolean("HasEverUsedCocaine");
            var lastUsedCocaine = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedCocaine"));
            var hasEverUsedStimulant = TestContext.GetBoolean("HasEverUsedStimulant");
            var lastUsedStimulant = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedStimulant"));
            var numberOfDaysUsedInPast30DaysCocaine = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysCocaine");
            var numberOfDaysUsedInPast30DaysStimulant = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysStimulant");
            var rangeOfGuiltInPastWeek = TestContext.GetLookup<RangeOfGuilt>("RangeOfGuiltInPastWeek");
            var observedRetardationOfThoughtOrSpeech = TestContext.GetLookup<RetardationOfThoughtOrSpeech>("ObservedRetardationOfThoughtOrSpeech");
            var appearanceOfDepressionWithdrawal = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfDepressionWithdrawal"));
            var appearanceOfParanoiaOrImpairedThinking = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfParanoiaOrImpairedThinking"));
            var isPatientExperiencingWithdrawalSignsSymptoms = TestContext.GetLookup<SignsOfWithdrawal>("IsPatientExperiencingWithdrawalSignsSymptoms");
            var livingArrangementAffectOnRecovery = TestContext.GetLookup<LivingArrangementAffectOnRecovery>("LivingArrangementAffectOnRecovery");
            var friendsAffectOnRecovery = TestContext.GetLookup<FriendsAffectOnRecovery>("FriendsAffectOnRecovery");
            var closestContactNeedsAndWillingToHelpTreatment = TestContext.GetLookup<NeedsAndWillingnessToHelpTreatment>("ClosestContactsNeedsAndWillingnessToHelpTreatment");
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var isSupportPersonAvailableFor7Days = TestContext.GetLookup<YesNoNotSure>("IsSupportPersonAvailableFor7Days");
            var usuallyLeftDetoxificationBeforeAdvised = TestContext.GetBoolean("UsuallyLeftDetoxificationBeforeAdvised");
            var previousSubstanceUseTreatment = TestContext.GetLookup<SubstanceTreatmentType>("PreviousSubstanceUseTreatment");
            var usuallyEnteredContinuedTreatmentAfterDetoxification = TestContext.GetBoolean("UsuallyEnteredContinuedTreatmentAfterDetoxification");
            var highestCareLevelFailedFromInPast90Days = TestContext.GetLookup<CareLevel>("HighestCareLevelFailedFromInPast90Days");
            var mildToModerateAlcoholWithdrawalCIWALessThan8 = TestContext.GetBoolean("MildToModerateAlcoholWithdrawalCIWALessThan8");

            var isExperiencingWithdrawalNotAtRiskOfSevereWithdrawalSafelyManageable = TestContext.GetBoolean("IsExperiencingWithdrawalNotAtRiskOfSevereWithdrawalSafelyManagea");
            var isIntoxicatedOrWithdrawingFromAlcoholMonitorToKeepCIWALessThan8 = TestContext.GetBoolean("IsIntoxicatedOrWithdrawingFromAlcoholMonitorToKeepCIWALessThan8");
            var withdrawalDistressingNoMedicationRequiredPatientImpulsive = TestContext.GetBoolean("WithdrawalDistressingNoMedicationRequiredPatientImpulsive");
            var isExperiencingMildPsychoticSymptomsDueToStimulantWithdrawal = TestContext.GetBoolean("IsExperiencingMildPsychoticSymptomsDueToStimulantWithdrawal");
            var requiresLevelOfServiceToCompleteDetoxWithContinuedTreatmentNoHomeSupervision = TestContext.GetBoolean("RequiresLevelOfServiceToCompleteDetoxWithContinuedTreatmentNoHom");
            var isMet = TestContext.GetBoolean("IsMet");

            var dimension1ScoringStrategy = new Dimension1ScoringStrategy();
            var careLevel_III_2_DetoxScore = dimension1ScoringStrategy.CalculateCareLevel_III_2_DetoxificationScore(
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
                    prnHourlyMonitoringSufficientToDetermineDetoxServiceLevel,
                    heartRate,
                    hasEverUsedHeroin,
                    lastUsedHeroin,
                    hasEverUsedMethadone,
                    lastUsedMethadone,
                    hasEverUsedOtherOpiate,
                    lastUsedOtherOpiate,
                    numberOfDaysUsedInPast30DaysHeroin,
                    numberOfDaysUsedInPast30DaysMethadone,
                    numberOfDaysUsedInPast30DaysOtherOpiate,
                    toBePrescribedOpioidDetoxificationProtocol,
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
                    timingOfPositiveResponseToDetoxificationCare,
                    amountOfMoneySpentInLast30DaysAlcohol,
                    numberOfDaysExperiencedSubstanceProblemsInPast30Days,
                    strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers,
                    currentStrengthOfSubstanceUseDesire,
                    hasEverUsedCocaine,
                    lastUsedCocaine,
                    hasEverUsedStimulant,
                    lastUsedStimulant,
                    numberOfDaysUsedInPast30DaysCocaine,
                    numberOfDaysUsedInPast30DaysStimulant,
                    rangeOfGuiltInPastWeek,
                    observedRetardationOfThoughtOrSpeech,
                    appearanceOfDepressionWithdrawal,
                    appearanceOfParanoiaOrImpairedThinking,
                    isPatientExperiencingWithdrawalSignsSymptoms,
                    livingArrangementAffectOnRecovery,
                    friendsAffectOnRecovery,
                    closestContactNeedsAndWillingToHelpTreatment,
                    helpfulnessOfTreatment,
                    possibleFutureRelapseCause,
                    strategyToPreventRelapse,
                    isSupportPersonAvailableFor7Days,
                    usuallyLeftDetoxificationBeforeAdvised,
                    previousSubstanceUseTreatment,
                    usuallyEnteredContinuedTreatmentAfterDetoxification,
                    highestCareLevelFailedFromInPast90Days,
                    mildToModerateAlcoholWithdrawalCIWALessThan8
                );

           Assert.AreEqual(isExperiencingWithdrawalNotAtRiskOfSevereWithdrawalSafelyManageable, careLevel_III_2_DetoxScore.IsExperiencingWithdrawalNotAtRiskOfSevereWithdrawalSafelyManageable, "IsExperiencingWithdrawalNotAtRiskOfSevereWithdrawalSafelyManageable didn't match.");
           Assert.AreEqual(isIntoxicatedOrWithdrawingFromAlcoholMonitorToKeepCIWALessThan8, careLevel_III_2_DetoxScore.IsIntoxicatedOrWithdrawingFromAlcoholMonitorToKeepCIWALessThan8, "IsIntoxicatedOrWithdrawingFromAlcoholMonitorToKeepCIWALessThan8 didn't match.");
           Assert.AreEqual(withdrawalDistressingNoMedicationRequiredPatientImpulsive, careLevel_III_2_DetoxScore.WithdrawalDistressingNoMedicationRequiredPatientImpulsive, "WithdrawalDistressingNoMedicationRequiredPatientImpulsive didn't match.");
           Assert.AreEqual(isExperiencingMildPsychoticSymptomsDueToStimulantWithdrawal, careLevel_III_2_DetoxScore.IsExperiencingMildPsychoticSymptomsDueToStimulantWithdrawal, "IsExperiencingMildPsychoticSymptomsDueToStimulantWithdrawal didn't match.");
           Assert.AreEqual(requiresLevelOfServiceToCompleteDetoxWithContinuedTreatmentNoHomeSupervision, careLevel_III_2_DetoxScore.RequiresLevelOfServiceToCompleteDetoxWithContinuedTreatmentNoHomeSupervision, "RequiresLevelOfServiceToCompleteDetoxWithContinuedTreatmentNoHomeSupervision didn't match.");
           Assert.AreEqual(isMet, careLevel_III_2_DetoxScore.IsMet, "CareLevel_III_2_DetoxScore didn't match.");
        }
        
        [TestMethod]
        [DataSource("D1_CareLevel_III_7_DetoxificationScore")]
        public void D1_CalculateCareLevel_III_7_DetoxificationScoreTests()
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
            var timingOfPositiveResponseToDetoxificationCare = TestContext.GetLookup<WithdrawalManagementCareResponseTiming>("TimingOfPositiveResponseToDetoxificationCare");
            var numberOfDaysUsedInPast30DaysBarbiturate = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysBarbiturate");
            var wasSubstanceTakenAsPrescribedBarbiturate = TestContext.GetLookup<SubstanceTakenAsPrescribed>("WasSubstanceTakenAsPrescribedBarbiturate");
            var numberOfDaysUsedInPast30DaysOtherSeditive = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysSeditive");
            var wasSubstanceTakenAsPrescribedOtherSeditive = TestContext.GetLookup<SubstanceTakenAsPrescribed>("WasSubstanceTakenAsPrescribedSeditive");
            var hasMaintainedBarbituatesDoseAtTherapeuticLevels = TestContext.GetBoolean("HasMaintainedBarbituatesDoseAtTherapeuticLevels");
            var hasMaintainedSedativeDoseAtTherapeuticLevels = TestContext.GetBoolean("HasMaintainedSedativeDoseAtTherapeuticLevels");
            var numberOfDaysUsedInPast30DaysAlcohol = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysALcohol");
            var numberOfDaysIntoxicatedInPast30DaysAlcohol = TestContext.GetUInt32("NumberOfDaysIntoxicatedInPast30DaysAlcohol");
            var numberOfDaysUsedInPast30DaysHeroin = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysHeroin");
            var numberOfDaysUsedInPast30DaysMethadone = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysMethadone");
            var numberOfDaysUsedInPast30DaysOtherOpiate = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysOtherOpiate");
            var numberOfDaysUsedInPast30DaysCocaine = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysCocaine");
            var numberOfDaysUsedInPast30DaysStimulant = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysStimulant");
            var numberOfDaysUsedInPast30DaysHallucinogen = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysHallucinogen");
            var numberOfDaysUsedInPast30DaysSolventAndInhalant =TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysSolventAndInhalant");
            var signsOfIntoxicationExist = TestContext.GetLookup<YesNoNotSure>("SignsOfIntoxicationExist");
            var observedRetardationOfThoughtOrSpeech = TestContext.GetLookup<RetardationOfThoughtOrSpeech>("ObservedRetardationOfThoughtOrSpeech");
            var numberOfTimesWithdrawalCausedDeliriumTremensAlcohol = TestContext.GetUInt32("NumberOfTimesWithdrawalCausedDeliriumTremensAlcohol");
            var substanceOverdoseInPast24Hours = TestContext.GetLookup<YesNoNotSure>("SubstanceOverdoseInPast24Hours");
            var appearanceOfTroubleConcentratingOrRemembering = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfTroubleConcentratingOrRemembering"));
            var hasEverUsedHeroin = TestContext.GetBoolean("HasEverUsedHeroin");
            var lastUsedHeroin = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedHeroin"));
            var hasEverUsedMethadone = TestContext.GetBoolean("HasEverUsedMethadone");
            var lastUsedMethadone = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedMethadone"));
            var hasEverUsedOtherOpiate =TestContext.GetBoolean("HasEverUsedOtherOpiate");
            var lastUsedOtherOpiate = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedOtherOpiate"));
            var toBePrescribedOpioidDetoxificationProtocol = TestContext.GetLookup<OpioidDetoxificationProtocol>("ToBePrescribedOpioidDetoxificationProtocol");
            var routeOfIntakeHeroin = TestContext.GetLookup<RouteOfIntake>("RouteOfIntakeHeroine");
            var routeOfIntakeMethadone = TestContext.GetLookup<RouteOfIntake>("RouteOfIntakeMethadone");
            var routeOfIntakeOtherOpiate = TestContext.GetLookup<RouteOfIntake>("RouteOfIntakeOtherOpiate");
            var highestCareLevelFailedFromInPast90Days = TestContext.GetLookup<CareLevel>("HighestCareLevelFailedFromInPast90Days");
            var hasEverUsedCocaine = TestContext.GetBoolean("HasEverUsedCocaine");
            var lastUsedCocaine = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedCocaine"));
            var hasEverUsedStimulant = TestContext.GetBoolean("HasEverUsedStimulant");
            var lastUsedStimulant = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedStimulant"));
            var rangeOfMoodInPastWeek = TestContext.GetLookup<RangeOfMood>("RangeOfMoodInPastWeek");
            var rangeOfGuiltInPastWeek = TestContext.GetLookup<RangeOfGuilt>("RangeOfGuiltInPastWeek");
            var appearanceOfDepressionWithdrawal = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfDepressionWithdrawal"));
            var appearanceOfHostility = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfHostility"));
            var appearanceOfParanoiaOrImpairedThinking = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfParanoiaOrImpairedThinking"));
            var hasSuicidalThoughts =new ScaleOf0To8(TestContext.GetUInt32("HasSuicidalThoughts"));
            var numberOfDaysExperiencedSubstanceProblemsInPast30Days = TestContext.GetUInt32("NumberOfDaysExperiencedSubstanceProblemsInPast30Days");
            var strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers = TestContext.GetLookup<LikertScale>("StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggers");
            var strategyToPreventRelapse = TestContext.GetLookup<RelapsePreventionStrategies>("StrategyToPreventRelapse");
            var isPatientExperiencingWithdrawalSignsSymptoms = TestContext.GetLookup<SignsOfWithdrawal>("IsPatientExperiencingWithdrawalSignsSymptoms");
            var experiencedNauseaOrVomitedRecently = new ScaleOf0To9(TestContext.GetUInt32("ExperiencedNauseaOrVomitedRecently"));
            var observedGooseFlesh = TestContext.GetLookup<GooseFleshObservation>("ObservedGooseFlesh");
            var observedSweating = TestContext.GetLookup<SweatingObservation>("ObservedSweating");
            var observedRestlessness = TestContext.GetLookup<RestlessnessObservation>("ObservedRestlessness");
            var observedTremor = TestContext.GetLookup<TremorObservation>("ObservedTremor");
            var observedLacrimination =TestContext.GetLookup<LacriminationObservation>("ObservedLacrimination");
            var observedNasalCongestion = TestContext.GetLookup<NasalCongestionObservation>("ObservedNasalCongestion");
            var observedYawning = TestContext.GetLookup<YawningObservation>("ObservedYawning");
            var hasAbdominalPain = TestContext.GetLookup<AbdominalPainStatus>("HasAbdominalPain");
            var feelsHotOrCold =TestContext.GetLookup<BodyTemperatureStatus>("FeelsHotOrCold");
            var hasMuscleAches = TestContext.GetLookup<MuscleAcheStatus>("HasMuscleAches");
            var heartRate = new HeartRate(TestContext.GetUInt32("HeartRate"));
            var usuallyLeftDetoxificationBeforeAdvised = TestContext.GetBoolean("UsuallyLeftDetoxificationBeforeAdvised");
            var previousSubstanceUseTreatment = TestContext.GetLookup<SubstanceTreatmentType>("PreviousSubstanceUseTreatment");
            var usuallyEnteredContinuedTreatmentAfterDetoxification = TestContext.GetBoolean("UsuallyEnteredContinuedTreatmentAfterDetoxification");
            var interviewerScoreOfAttitude = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfAttitude"));
            var interviewerScoreOfReadiness = new ScaleOf0To9(TestContext.GetUInt32("InterviewerScoreOfReadiness"));
            var helpfulnessOfTreatment = TestContext.GetLookup<HelpfulnessOfTreatment>("HelpfulnessOfTreatment");
            var possibleFutureRelapseCause = TestContext.GetLookup<RelapseCause>("PossibleFutureRelapseCause");
            var hasAlcoholImminentWithdrawalPotential = TestContext.GetBoolean ( "HasAlcoholImminentWithdrawalPotential" );
            var hasHeroinImminentWithdrawalPotential = TestContext.GetBoolean("HasHeroinImminentWithdrawalPotential" );
            var hasMethadoneImminentWithdrawalPotential = TestContext.GetBoolean("HasMethadoneImminentWithdrawalPotential" );
            var hasOtherOpiateImminentWithdrawalPotential = TestContext.GetBoolean("HasOtherOpiateImminentWithdrawalPotential" ); 
            var hasBarbiturateImminentWithdrawalPotential = TestContext.GetBoolean("HasBarbiturateImminentWithdrawalPotential" );
            var hasOtherSedativeHypnoticImminentWithdrawalPotential = TestContext.GetBoolean("HasOtherSedativeHypnoticImminentWithdrawalPotential" );

            var isExperiencingSevereWithdrawalManageableAtLevelOfService = TestContext.GetBoolean("IsExperiencingSevereWithdrawalManageableAtLevelOfService");
            var isWithdrawingFromAlcoholCIWA10OrGreaterAtThisLevel = TestContext.GetBoolean("IsWithdrawingFromAlcoholCIWA10OrGreaterAtThisLevel");
            var hasIngestedSeditivesMoreThanTherapeuticLevelsDailyMoreThan4Weeks = TestContext.GetBoolean("HasIngestedSeditivesMoreThanTherapeuticLevelsDailyMoreThan4Weeks");
            var hasIngestedSeditivesMoreThanTherapeuticLevelsMoreThan4WeeksWithAlcoholCombination = TestContext.GetBoolean("HasIngestedSeditivesMoreThanTherapeuticLevelsMoreThan4WeeksWAlco");
            var hasLethargyWithAlcoholDrugsHistorySevereWithdrawalOrNotStabilizedAtLevel = TestContext.GetBoolean("HasLethargyWithAlcoholDrugsHistorySevereWithdrawalOrNotStabalize");
            var hasUsedInjectableOpiatesDailyMoreThan2WeeksNeedsMedicationToComplete = TestContext.GetBoolean("HasUsedInjectableOpiatesDailyMoreThan2WeeksNeedsMedicationToComp");
            var antagonistMedicationUsedInWithdrawalBriefButIntensiveDetox = TestContext.GetBoolean("AntagonistMedicationUsedInWithdrawalBriefButIntensiveDetox");
            var isExperiencingStimulantsWithdrawalPoorImpulseControlOrCopingSkills = TestContext.GetBoolean("IsExperiencingStimulantsWithdrawalPoorImpulseControlOrCopingSkil");
            var isLikelyPatientNeedingMedicationWillNotCompleteDetoxDifferentLevel = TestContext.GetBoolean("IsLikelyPatientNeedingMedicationWillNotCompleteDetoxDifferentLev");
            var isMet = TestContext.GetBoolean("IsMet");

            var dimension1ScoringStrategy = new Dimension1ScoringStrategy();
            var careLevel_III_7_DetoxificationScore = dimension1ScoringStrategy.CalculateCareLevel_III_7_DetoxificationScore (
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
                timingOfPositiveResponseToDetoxificationCare,
                numberOfDaysUsedInPast30DaysBarbiturate,
                wasSubstanceTakenAsPrescribedBarbiturate,
                numberOfDaysUsedInPast30DaysOtherSeditive,
                wasSubstanceTakenAsPrescribedOtherSeditive,
                hasMaintainedBarbituatesDoseAtTherapeuticLevels,
                hasMaintainedSedativeDoseAtTherapeuticLevels,
                numberOfDaysUsedInPast30DaysAlcohol,
                numberOfDaysIntoxicatedInPast30DaysAlcohol,
                numberOfDaysUsedInPast30DaysHeroin,
                numberOfDaysUsedInPast30DaysMethadone,
                numberOfDaysUsedInPast30DaysOtherOpiate,
                numberOfDaysUsedInPast30DaysCocaine,
                numberOfDaysUsedInPast30DaysStimulant,
                numberOfDaysUsedInPast30DaysHallucinogen,
                numberOfDaysUsedInPast30DaysSolventAndInhalant,
                signsOfIntoxicationExist,
                observedRetardationOfThoughtOrSpeech,
                numberOfTimesWithdrawalCausedDeliriumTremensAlcohol,
                substanceOverdoseInPast24Hours,
                appearanceOfTroubleConcentratingOrRemembering,
                hasEverUsedHeroin,
                lastUsedHeroin,
                hasEverUsedMethadone,
                lastUsedMethadone,
                hasEverUsedOtherOpiate,
                lastUsedOtherOpiate,
                toBePrescribedOpioidDetoxificationProtocol,
                routeOfIntakeHeroin,
                routeOfIntakeMethadone,
                routeOfIntakeOtherOpiate,
                highestCareLevelFailedFromInPast90Days,
                hasEverUsedCocaine,
                lastUsedCocaine,
                hasEverUsedStimulant,
                lastUsedStimulant,
                rangeOfMoodInPastWeek,
                rangeOfGuiltInPastWeek,
                appearanceOfDepressionWithdrawal,
                appearanceOfHostility,
                appearanceOfParanoiaOrImpairedThinking,
                hasSuicidalThoughts,
                numberOfDaysExperiencedSubstanceProblemsInPast30Days,
                strengthOfSubstanceUseUrgeDueToEnvironmentalTriggers,
                strategyToPreventRelapse,
                isPatientExperiencingWithdrawalSignsSymptoms,
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
                usuallyLeftDetoxificationBeforeAdvised,
                previousSubstanceUseTreatment,
                usuallyEnteredContinuedTreatmentAfterDetoxification,
                interviewerScoreOfAttitude,
                interviewerScoreOfReadiness,
                helpfulnessOfTreatment,
                possibleFutureRelapseCause,
                hasAlcoholImminentWithdrawalPotential,
                hasHeroinImminentWithdrawalPotential,
                hasMethadoneImminentWithdrawalPotential,
                hasOtherOpiateImminentWithdrawalPotential,
                hasBarbiturateImminentWithdrawalPotential,
                hasOtherSedativeHypnoticImminentWithdrawalPotential);

           Assert.AreEqual(isExperiencingSevereWithdrawalManageableAtLevelOfService, careLevel_III_7_DetoxificationScore.IsExperiencingSevereWithdrawalManageableAtLevelOfService, "IsExperiencingSevereWithdrawalManageableAtLevelOfService didn't match.");
           Assert.AreEqual(isWithdrawingFromAlcoholCIWA10OrGreaterAtThisLevel, careLevel_III_7_DetoxificationScore.IsWithdrawingFromAlcoholCIWA19OrGreaterAtThisLevel, "IsWithdrawingFromAlcoholCIWA10OrGreaterAtThisLevel didn't match.");
           Assert.AreEqual(hasIngestedSeditivesMoreThanTherapeuticLevelsDailyMoreThan4Weeks, careLevel_III_7_DetoxificationScore.HasIngestedSeditivesMoreThanTherapeuticLevelsDailyMoreThan4Weeks, "HasIngestedSeditivesMoreThanTherapeuticLevelsDailyMoreThan4Weeks didn't match.");
           Assert.AreEqual(hasIngestedSeditivesMoreThanTherapeuticLevelsMoreThan4WeeksWithAlcoholCombination, careLevel_III_7_DetoxificationScore.HasIngestedSeditivesMoreThanTherapeuticLevelsMoreThan4WeeksWithAlcoholCombination, "HasIngestedSeditivesMoreThanTherapeuticLevelsMoreThan4WeeksWithAlcoholCombination didn't match.");
           Assert.AreEqual(hasLethargyWithAlcoholDrugsHistorySevereWithdrawalOrNotStabilizedAtLevel, careLevel_III_7_DetoxificationScore.HasLethargyWithAlcoholDrugsHistorySevereWithdrawalOrNotStabilizedAtLevel, "HasLethargyWithAlcoholDrugsHistorySevereWithdrawalOrNotStabilizedAtLevel didn't match.");
           Assert.AreEqual(hasUsedInjectableOpiatesDailyMoreThan2WeeksNeedsMedicationToComplete, careLevel_III_7_DetoxificationScore.HasUsedInjectableOpiatesDailyMoreThan2WeeksNeedsMedicationToComplete, "HasUsedInjectableOpiatesDailyMoreThan2WeeksNeedsMedicationToComplete didn't match.");
           Assert.AreEqual(antagonistMedicationUsedInWithdrawalBriefButIntensiveDetox, careLevel_III_7_DetoxificationScore.AntagonistMedicationUsedInWithdrawalBriefButIntensiveDetox, "AntagonistMedicationUsedInWithdrawalBriefButIntensiveDetox didn't match.");
           Assert.AreEqual(isExperiencingStimulantsWithdrawalPoorImpulseControlOrCopingSkills, careLevel_III_7_DetoxificationScore.IsExperiencingStimulantsWithdrawalPoorImpulseControlOrCopingSkills, "IsExperiencingStimulantsWithdrawalPoorImpulseControlOrCopingSkills didn't match.");
           Assert.AreEqual(isLikelyPatientNeedingMedicationWillNotCompleteDetoxDifferentLevel, careLevel_III_7_DetoxificationScore.IsLikelyPatientNeedingMedicationWillNotCompleteDetoxDifferentLevel, "IsLikelyPatientNeedingMedicationWillNotCompleteDetoxDifferentLevel didn't match.");
           Assert.AreEqual(isMet, careLevel_III_7_DetoxificationScore.IsMet, "CareLevel_III_7_DetoxScore didn't match.");
        }

        [TestMethod]
        [DataSource("D1_CareLevel_IV_DetoxificationScore")]
        public void D1_CalculateCareLevel_IV_DetoxificationScoreTests()
        {
            var hasAlcoholImminentWithdrawalPotential = TestContext.GetBoolean("HasAlcoholImminentWithdrawalPotential");
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
            var heartRate = new HeartRate(TestContext.GetUInt32("HeartRate"));
            var bloodPressure = TestContext.GetBloodPressure ( "BloodPressure" );
            var requiresInpatientCardiacMonitoring = TestContext.GetLookup<YesNoNotSure>("RequiresInpatientCardiacMonitoring");
            var mayRequireInpatientLiverTreatment = TestContext.GetLookup<YesNoNotSure>("MayRequireInpatientLiverTreatment");
            var mayRequireInpatientGastrointestinalBleedingTreatment = TestContext.GetLookup<YesNoNotSure>("MayRequireInpatientGastrointestinalBleedingTreatment");
            var mayRequireInpatientAcutePancreatitisTreatment = TestContext.GetLookup<YesNoNotSure>("MayRequireInpatientAcutePancreatitisTreatment");
            var multipleSeriousMedicalProblemsExist = TestContext.GetLookup<YesNoNotSure>("MultipleSeriousMedicalProblemsExist");
            var symptomsLifeThreateningBecauseOfSubstanceUse = TestContext.GetLookup<YesNoNotSure>("SymptomsLifeThreateningBecauseOfSubstanceUse");
            var appearanceOfHostility = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfHostility"));
            var appearanceOfParanoiaOrImpairedThinking = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfParanoiaOrImpairedThinking"));
            var appearanceOfTroubleConcentratingOrRemembering = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfTroubleConcentratingOrRemembering"));
            var hasSuicidalThoughts = new ScaleOf0To8(TestContext.GetUInt32("HasSuicidalThoughts"));
            var hasEverUsedAlcohol = TestContext.GetBoolean("HasEverUsedAlcohol");
            var lastUsedAlcohol = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedAlcohol"));
            var alcoholUsedToIntoxicationAlcohol = TestContext.GetBoolean("AlcoholUsedToIntoxicationAlcohol");
            var lastUsedToIntoxification = new TimeMeasure ( UnitOfTime.Months, TestContext.GetUInt32("LastUsedToIntoxification"));
            var hasEverUsedBarbiturate = TestContext.GetBoolean("HasEverUsedBarbiturate");
            var lastUsedBarbiturate = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedBarbiturate"));
            var lastUsedOtherSedative = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedOtherSedative"));
            var seizureInPast24Hours = TestContext.GetLookup<YesNoNotSure>("SeizureInPast24Hours");
            var multipleSeizuresInPast24Hours = TestContext.GetLookup<YesNoNotSure>("MultipleSeizuresInPast24Hours");
            var hadDeliriumTremorsInPast24Hours = TestContext.GetLookup<YesNoNotSure>("HadDeliriumTremorsInPast24Hours");
            var feverOf102DegreesOrMoreInPast24Hours = TestContext.GetLookup<YesNoNotSure>("FeverOf102DegreesOrMoreInPast24Hours");
            var rangeOfGuiltInPastWeek = TestContext.GetLookup<RangeOfGuilt>("RangeOfGuiltInPastWeek");
            var observedRetardationOfThoughtOrSpeech = TestContext.GetLookup<RetardationOfThoughtOrSpeech>("ObservedRetardationOfThoughtOrSpeech");
            var numberOfDaysUsedInPast30DaysBarbiturate = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysBarbiturate");
            var wasSubstanceTakenAsPrescribedBarbiturate = TestContext.GetLookup<SubstanceTakenAsPrescribed>("WasSubstanceTakenAsPrescribedBarbiturate");
            var numberOfDaysUsedInPast30DaysOtherSedative = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysOtherSedative");
            var wasSubstanceTakenAsPrescribedOtherSedative = TestContext.GetLookup<SubstanceTakenAsPrescribed>("WasSubstanceTakenAsPrescribedOtherSedative");
            var medicalProblemThatWouldComplicateDetoxificationStatus = TestContext.GetLookup<YesNoNotSure>("MedicalProblemThatWouldComplicateDetoxificationStatus");
            var numberOfMonthsUsedInLifetimeBarbiturate = TestContext.GetUInt32("NumberOfMonthsUsedInLifetimeBarbiturate");
            var numberOfMonthsUsedInLifetimeOtherSedative = TestContext.GetUInt32("NumberOfMonthsUsedInLifetimeOtherSedative");
            var hasEverUsedOtherSedative = TestContext.GetBoolean("HasEverUsedOtherSedative");
            var numberOfDaysUsedInPast30DaysAlcohol = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysAlcohol");
            var numberOfDaysIntoxicatedInPast30DaysAlcohol = TestContext.GetUInt32("NumberOfDaysIntoxicatedInPast30DaysAlcohol");
            var numberOfDaysUsedInPast30DaysHeroin = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysHeroin");
            var numberOfDaysUsedInPast30DaysMethadone = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysMethadone");
            var numberOfDaysUsedInPast30DaysOtherOpiate = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysOtherOpiate");
            var hasEverUsedHeroin = TestContext.GetBoolean("HasEverUsedHeroin");
            var lastUsedHeroin = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedHeroin"));
            var hasEverUsedMethadone = TestContext.GetBoolean("HasEverUsedMethadone");
            var lastUsedMethadone = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedMethadone"));
            var hasEverUsedOtherOpiate = TestContext.GetBoolean("HasEverUsedOtherOpiate");
            var lastUsedOtherOpiate = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedOtherOpiate"));
            var experiencedNauseaOrVomitedRecently = new ScaleOf0To9 ( TestContext.GetUInt32("ExperiencedNauseaOrVomitedRecently"));
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
            var toBePrescribedOpioidDetoxificationProtocol = TestContext.GetLookup<OpioidDetoxificationProtocol>("ToBePrescribedOpioidDetoxificationProtocol");
            var hasEverUsedCocaine = TestContext.GetBoolean("HasEverUsedCocaine");
            var lastUsedCocaine = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedCocaine"));
            var hasEverUsedStimulant = TestContext.GetBoolean("HasEverUsedStimulant");
            var lastUsedStimulant = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedStimulant"));
            var appearanceOfDepressionWithdrawal = new ScaleOf0To8(TestContext.GetUInt32("AppearanceOfDepressionWithdrawal"));
            var signsOfToxicPsychosisExist = TestContext.GetLookup<YesNoNotSure>("SignsOfToxicPsychosisExist");
            var sufferedHeadTraumaInPast48Hours = TestContext.GetLookup<YesNoNotSure>("SufferedHeadTraumaInPast48Hours");
            var lostConciousnessFromHeadTraumaInPast24Hours = TestContext.GetLookup<YesNoNotSure>("LostConciousnessFromHeadTraumaInPast24Hours");
            var sufferedSeriousImpairmentFromOverdoseInPast24Hours = TestContext.GetLookup<YesNoNotSure>("SufferedSeriousImpairmentFromOverdoseInPast24Hours");
            var detoxificationRequiredMoreThanHourlyMonitoring = TestContext.GetBoolean("DetoxificationRequiredMoreThanHourlyMonitoring");
            var signsOfIntoxicationExist = TestContext.GetLookup<YesNoNotSure>("SignsOfIntoxicationExist");
            var oB_ImminentWD03 = TestContext.GetBoolean("OB_ImminentWD03");
            var oB_ImminentWD04 = TestContext.GetBoolean("OB_ImminentWD04");
            var oB_ImminentWD05 = TestContext.GetBoolean("OB_ImminentWD05");
            var oB_ImminentWD06 = TestContext.GetBoolean("OB_ImminentWD06");
            var oB_ImminentWD07 = TestContext.GetBoolean("OB_ImminentWD07");
            var isPatientExperiencingWithdrawalSignsSymptoms = TestContext.GetLookup<SignsOfWithdrawal>("IsPatientExperiencingWithdrawalSignsSymptoms");
            var pregnantStatus = TestContext.GetLookup<YesNoNotSure>("PregnantStatus");
            var highRiskPregnancyStatus = TestContext.GetLookup<HighRiskPregnancyStatus>("HighRiskPregnancyStatus");
            var d1CareLevel_I_DetoxScoreIMet = TestContext.GetBoolean("D1CareLevel_I_DetoxScoreIMet");
            var d1CareLevel_II_DetoxScoreIMet = TestContext.GetBoolean("D1CareLevel_II_DetoxScoreIMet");
            var d1CareLevel_III_2_DetoxScoreIMet = TestContext.GetBoolean("D1CareLevel_III_2_DetoxScoreIMet");
            var d1CareLevel_III_7_DetoxScoreIMet = TestContext.GetBoolean("D1CareLevel_III_7_DetoxScoreIMet");
            var gender = TestContext.GetLookup<Gender>("Gender");


            var isExperiencingSevereWithdrawalManageableAtLevelOfService = TestContext.GetBoolean("IsExperiencingSevereWithdrawalManageableAtLevelOfService");
            var isWithdrawingFromAlcoholCIWA19OrGreaterMonitoringMoreThanHourly = TestContext.GetBoolean("IsWithdrawingFromAlcoholCIWA10OrGreaterMonitoringMoreThanHourly");
            var isExperiencingSeizuresDeliriumOrSeverePersistentHallucinations = TestContext.GetBoolean("IsExperiencingSeizuresDeliriumOrSeverePersistentHallucinations");
            var hasIngestedSedativesHigherTherapeuticLevelsDailyMoreThan4WeeksWithAcuteDisorders = TestContext.GetBoolean("HasIngestedSedativesHigherTherapeuticLevelsDailyMoreThan4Weeks");
            var hasIngestedSedativesDailyAtLeast6MonthsWithAcuteDisorders = TestContext.GetBoolean("HasIngestedSedativesDailyAtLeast6MonthsWithAcuteDisorders");
            var isExperiencingSevereOpiateWithdrawalNotStabilizedAtLessThanIntensiveLevel = TestContext.GetBoolean("IsExperiencingSevereOpiateWithdrawalNotStabilizedAtLessThan");
            var antagonistMedicationIsToBeUsedInRapidWithdrawal = TestContext.GetBoolean("AntagonistMedicationIsToBeUsedInRapidWithdrawal");
            var requiresPsychiatricOrMedicalMonitoringPsychoticImpulsiveBehavior = TestContext.GetBoolean("RequiresPsychiatricOrMedicalMonitoringPsychoticImpulsiveBehavior");
            var needToCloselyObserveAtLeastHourlyMentalStatusOrNeurologicalChanges = TestContext.GetBoolean("NeedToCloselyObserveAtLeastHourlyMentalStatusOrNeurological");
            var mentalStatusCardiacFunctionOrOtherVitalsCompromisedDrugOverdoseOrIntoxication = TestContext.GetBoolean("MentalStatusCardiacFunctionOrOtherVitalsCompromisedDrugOverdose");
            var hasAcuteBiomedicalDisorderPosesSeriousRiskDuringWithdrawal = TestContext.GetBoolean("HasAcuteBiomedicalDisorderPosesSeriousRiskDuringWithdrawal");
            var detoxificationRegimenRequiringMonitoringMoreFrequentlyThanHourly = TestContext.GetBoolean("DetoxificationRegimenRequiringMonitoringMoreFrequentlyThanHourly");
            var needForDetoxOrStabilizationWhilePregnantUntilSafelyTreatedAtLowerLevel = TestContext.GetBoolean("NeedForDetoxOrStabilizationWhilePregnantUntilSafelyTreated");
            var isMet = TestContext.GetBoolean("IsMet");

            
            if(TestContext.GetBoolean ( "ForDebug" ))
            {
                
            }

            var dimension1ScoringStrategy = new Dimension1ScoringStrategy();
            var careLevel_IV_DetoxScore = dimension1ScoringStrategy.CalculateCareLevel_IV_DetoxificationScore (
                hasAlcoholImminentWithdrawalPotential,
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
                heartRate,
                bloodPressure,
                requiresInpatientCardiacMonitoring,
                mayRequireInpatientLiverTreatment,
                mayRequireInpatientGastrointestinalBleedingTreatment,
                mayRequireInpatientAcutePancreatitisTreatment,
                multipleSeriousMedicalProblemsExist,
                symptomsLifeThreateningBecauseOfSubstanceUse,
                appearanceOfHostility,
                appearanceOfParanoiaOrImpairedThinking,
                appearanceOfTroubleConcentratingOrRemembering,
                hasSuicidalThoughts,
                hasEverUsedAlcohol,
                lastUsedAlcohol,
                alcoholUsedToIntoxicationAlcohol,
                lastUsedToIntoxification,
                hasEverUsedBarbiturate,
                lastUsedBarbiturate,
                lastUsedOtherSedative,
                seizureInPast24Hours,
                multipleSeizuresInPast24Hours,
                hadDeliriumTremorsInPast24Hours,
                feverOf102DegreesOrMoreInPast24Hours,
                rangeOfGuiltInPastWeek,
                observedRetardationOfThoughtOrSpeech,
                numberOfDaysUsedInPast30DaysBarbiturate,
                wasSubstanceTakenAsPrescribedBarbiturate,
                numberOfDaysUsedInPast30DaysOtherSedative,
                wasSubstanceTakenAsPrescribedOtherSedative,
                medicalProblemThatWouldComplicateDetoxificationStatus,
                numberOfMonthsUsedInLifetimeBarbiturate,
                numberOfMonthsUsedInLifetimeOtherSedative,
                hasEverUsedOtherSedative,
                numberOfDaysUsedInPast30DaysAlcohol,
                numberOfDaysIntoxicatedInPast30DaysAlcohol,
                numberOfDaysUsedInPast30DaysHeroin,
                numberOfDaysUsedInPast30DaysMethadone,
                numberOfDaysUsedInPast30DaysOtherOpiate,
                hasEverUsedHeroin,
                lastUsedHeroin,
                hasEverUsedMethadone,
                lastUsedMethadone,
                hasEverUsedOtherOpiate,
                lastUsedOtherOpiate,
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
                toBePrescribedOpioidDetoxificationProtocol,
                hasEverUsedCocaine,
                lastUsedCocaine,
                hasEverUsedStimulant,
                lastUsedStimulant,
                appearanceOfDepressionWithdrawal,
                signsOfToxicPsychosisExist,
                sufferedHeadTraumaInPast48Hours,
                lostConciousnessFromHeadTraumaInPast24Hours,
                sufferedSeriousImpairmentFromOverdoseInPast24Hours,
                detoxificationRequiredMoreThanHourlyMonitoring,
                signsOfIntoxicationExist,
                oB_ImminentWD03,
                oB_ImminentWD04,
                oB_ImminentWD05,
                oB_ImminentWD06,
                oB_ImminentWD07,
                isPatientExperiencingWithdrawalSignsSymptoms,
                pregnantStatus,
                highRiskPregnancyStatus,
                d1CareLevel_I_DetoxScoreIMet,
                d1CareLevel_II_DetoxScoreIMet,
                d1CareLevel_III_2_DetoxScoreIMet,
                d1CareLevel_III_7_DetoxScoreIMet,
                gender );

            Assert.AreEqual(isExperiencingSevereWithdrawalManageableAtLevelOfService, careLevel_IV_DetoxScore.IsExperiencingSevereWithdrawalManageableAtLevelOfService, "IsExperiencingSevereWithdrawalManageableAtLevelOfService didn't match.");
            Assert.AreEqual(isWithdrawingFromAlcoholCIWA19OrGreaterMonitoringMoreThanHourly, careLevel_IV_DetoxScore.IsWithdrawingFromAlcoholCIWA19OrGreaterMonitoringMoreThanHourly, "IsWithdrawingFromAlcoholCIWA19OrGreaterMonitoringMoreThanHourly didn't match.");
            Assert.AreEqual(isExperiencingSeizuresDeliriumOrSeverePersistentHallucinations, careLevel_IV_DetoxScore.IsExperiencingSeizuresDeliriumOrSeverePersistentHallucinations, "IsExperiencingSeizuresDeliriumOrSeverePersistentHallucinations didn't match.");
            Assert.AreEqual(hasIngestedSedativesHigherTherapeuticLevelsDailyMoreThan4WeeksWithAcuteDisorders, careLevel_IV_DetoxScore.HasIngestedSedativesHigherTherapeuticLevelsDailyMoreThan4WeeksWithAcuteDisorders, "HasIngestedSedativesHigherTherapeuticLevelsDailyMoreThan4WeeksWithAcuteDisorders didn't match.");
            Assert.AreEqual(hasIngestedSedativesDailyAtLeast6MonthsWithAcuteDisorders, careLevel_IV_DetoxScore.HasIngestedSedativesDailyAtLeast6MonthsWithAcuteDisorders, "HasIngestedSedativesDailyAtLeast6MonthsWithAcuteDisorders didn't match.");
            Assert.AreEqual(isExperiencingSevereOpiateWithdrawalNotStabilizedAtLessThanIntensiveLevel, careLevel_IV_DetoxScore.IsExperiencingSevereOpiateWithdrawalNotStabilizedAtLessThanIntensiveLevel, "IsExperiencingSevereOpiateWithdrawalNotStabilizedAtLessThanIntensiveLevel didn't match.");
            Assert.AreEqual(antagonistMedicationIsToBeUsedInRapidWithdrawal, careLevel_IV_DetoxScore.AntagonistMedicationIsToBeUsedInRapidWithdrawal, "AntagonistMedicationIsToBeUsedInRapidWithdrawal didn't match.");
            Assert.AreEqual(requiresPsychiatricOrMedicalMonitoringPsychoticImpulsiveBehavior, careLevel_IV_DetoxScore.RequiresPsychiatricOrMedicalMonitoringPsychoticImpulsiveBehavior, "RequiresPsychiatricOrMedicalMonitoringPsychoticImpulsiveBehavior didn't match.");
            Assert.AreEqual(needToCloselyObserveAtLeastHourlyMentalStatusOrNeurologicalChanges, careLevel_IV_DetoxScore.NeedToCloselyObserveAtLeastHourlyMentalStatusOrNeurologicalChanges, "NeedToCloselyObserveAtLeastHourlyMentalStatusOrNeurologicalChanges didn't match.");
            Assert.AreEqual(mentalStatusCardiacFunctionOrOtherVitalsCompromisedDrugOverdoseOrIntoxication, careLevel_IV_DetoxScore.MentalStatusCardiacFunctionOrOtherVitalsCompromisedDrugOverdoseOrIntoxication, "MentalStatusCardiacFunctionOrOtherVitalsCompromisedDrugOverdoseOrIntoxication didn't match.");
            Assert.AreEqual(hasAcuteBiomedicalDisorderPosesSeriousRiskDuringWithdrawal, careLevel_IV_DetoxScore.HasAcuteBiomedicalDisorderPosesSeriousRiskDuringWithdrawal, "HasAcuteBiomedicalDisorderPosesSeriousRiskDuringWithdrawal didn't match.");
            Assert.AreEqual(detoxificationRegimenRequiringMonitoringMoreFrequentlyThanHourly, careLevel_IV_DetoxScore.DetoxificationRegimenRequiringMonitoringMoreFrequentlyThanHourly, "DetoxificationRegimenRequiringMonitoringMoreFrequentlyThanHourly didn't match.");
            Assert.AreEqual(needForDetoxOrStabilizationWhilePregnantUntilSafelyTreatedAtLowerLevel, careLevel_IV_DetoxScore.NeedForDetoxOrStabilizationWhilePregnantUntilSafelyTreatedAtLowerLevel, "NeedForDetoxOrStabilizationWhilePregnantUntilSafelyTreatedAtLowerLevel didn't match.");
            Assert.AreEqual(isMet, careLevel_IV_DetoxScore.IsMet, "CareLevel_IV_DetoxScore didn't match.");
        }

        [TestMethod]
        [DataSource("D1_CareLevelOpioidMaintenanceTherapy")]
        public void D1_CalculateCareLevelOpioidMaintenanceTherapyScoreTests()
        {
            var dxCareLevel_OMT_ScoreIsMet = TestContext.GetBoolean("dxCareLevel_OMT_ScoreIsMet");
            var increasedDoseRequiredToGetSameEffectHeroin = TestContext.GetBoolean("IncreasedDoseRequiredToGetSameEffectHeroin");
            var experiencesWithdrawalSicknessHeroin = TestContext.GetBoolean("ExperiencesWithdrawalSicknessHeroin");
            var useSubstanceToPreventWithdrawalSicknessHeroin = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessHeroin");
            var increasedDoseRequiredToGetSameEffectMethadone = TestContext.GetBoolean("IncreasedDoseRequiredToGetSameEffectMethadone");
            var experiencesWithdrawalSicknessMethadone = TestContext.GetBoolean("ExperiencesWithdrawalSicknessMethadone");
            var useSubstanceToPreventWithdrawalSicknessMethadone = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessMethadone");
            var increasedDoseRequiredToGetSameEffectOtherOpiate = TestContext.GetBoolean("IncreasedDoseRequiredToGetSameEffectOtherOpiate");
            var experiencesWithdrawalSicknessOtherOpiate = TestContext.GetBoolean("ExperiencesWithdrawalSicknessOtherOpiate");
            var useSubstanceToPreventWithdrawalSicknessOtherOpiate = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSicknessOtherOpiate");
            var numberOfDaysUsedInPast30DaysHeroin = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysHeroin");
            var numberOfDaysUsedInPast30DaysMethadone = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysMethadone");
            var numberOfDaysUsedInPast30DaysOtherOpiate = TestContext.GetUInt32("NumberOfDaysUsedInPast30DaysOtherOpiate");
            var numberOfMonthsUsedInLifetimeHeroin = TestContext.GetUInt32("NumberOfMonthsUsedInLifetimeHeroin");
            var numberOfMonthsUsedInLifetimeMethadone = TestContext.GetUInt32("NumberOfMonthsUsedInLifetimeMethadone");
            var numberOfMonthsUsedInLifetimeOtherOpiate = TestContext.GetUInt32("NumberOfMonthsUsedInLifetimeOtherOpiate");
            var heartRate = new HeartRate(TestContext.GetUInt32("HeartRate"));
            var bloodPressure = TestContext.GetBloodPressure("BloodPressure");
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
            var evidenceFromUrineScreenOfOpioidDependenceOtherOpiate = TestContext.GetBoolean("EvidenceFromUrineScreenOfOpioidDependenceOtherOpiate");
            var documentedEvidenceOfOpioidDependenceAtLeast1YearOtherOpiate = TestContext.GetBoolean("DocumentedEvidenceOfOpioidDependenceAtLeast1YearOtherOpiate");
            var increasedDoseRequiredToGetSameEffect = TestContext.GetBoolean("IncreasedDoseRequiredToGetSameEffect");
            var experiencesWithdrawalSickness = TestContext.GetBoolean("ExperiencesWithdrawalSickness");
            var useSubstanceToPreventWithdrawalSickness = TestContext.GetBoolean("UseSubstanceToPreventWithdrawalSickness");
            var inPenalOrChronicCareSettingRecently = TestContext.GetBoolean("InPenalOrChronicCareSettingRecently");
            var pregnantStatus = TestContext.GetLookup<YesNoNotSure>("PregnantStatus");
            var isDependentHeroin = TestContext.GetBoolean("IsDependentHeroin");
            var isDependentMethadone = TestContext.GetBoolean("IsDependentMethadone");
            var isDependentOterOpiate = TestContext.GetBoolean("IsDependentOterOpiate");
            var hasEverUsedHeroin = TestContext.GetBoolean("HasEverUsedHeroin");
            var lastUsedHeroin = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedHeroin"));
            var hasEverUsedMethadone = TestContext.GetBoolean("HasEverUsedMethadone");
            var lastUsedMethadone = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedMethadone"));
            var hasEverUsedOtherOpiate = TestContext.GetBoolean("HasEverUsedOtherOpiate");
            var lastUsedOtherOpiate = new TimeMeasure(UnitOfTime.Days, TestContext.GetUInt32("LastUsedOtherOpiate"));
            var toBePrescribedOpioidDetoxificationProtocol = TestContext.GetLookup<OpioidDetoxificationProtocol>("ToBePrescribedOpioidDetoxificationProtocol");
            var completedAtLeast6MonthOpioidMaintenanceTherapyVoluntarily = TestContext.GetBoolean("CompletedAtLeast6MonthOpioidMaintenanceTherapyVoluntarily");
            var detoxificationEndedLessThanOrEqual2YearsAgo = TestContext.GetBoolean("DetoxificationEndedLessThanOrEqual2YearsAgo");
            var opioidMaintenanceTherapyReadmissionMedicallyIndicated = TestContext.GetBoolean("OpioidMaintenanceTherapyReadmissionMedicallyIndicated");
            var anyOpioidAddictionDiagnosis = TestContext.GetBoolean("AnyOpioidAddictionDiagnosis");

            var physiologicallyDependentOpiateDrugAtLeast1YearBeforeMethadoneAdmission = TestContext.GetBoolean("PhysiologicallyDependentOpiateDrugAtLeast1YearBeforeMethadone");
            var currentPhysiologicalDependenceIsConfirmed = TestContext.GetBoolean("CurrentPhysiologicalDependenceIsConfirmed");
            var canBeAdmittedFromCriminalJusticeSettingWithin14DaysOfRelease = TestContext.GetBoolean("CanBeAdmittedFromCriminalJusticeSettingWithin14DaysOfRelease");
            var isPregnantWithHistoryOfOpiateDependenceTreatmentMedicallyJustified = TestContext.GetBoolean("IsPregnantWithHistoryOfOpiateDependenceTreatmentMedically");
            var isPreviouslyTreatedVoluntarilyDetoxedFromMethadoneWithin2Years = TestContext.GetBoolean("IsPreviouslyTreatedVoluntarilyDetoxedFromMethadoneWithin2Years");
            var isMet = TestContext.GetBoolean("IsMet");

            if(TestContext.GetBoolean ( "ForDebug" ) )
            {
                
            }

            var dimension1ScoringStrategy = new Dimension1ScoringStrategy();
            var careLevel_OMT_Score = dimension1ScoringStrategy.CalculateCareLevelOpioidMaintenanceTherapyScore(
                dxCareLevel_OMT_ScoreIsMet,
                increasedDoseRequiredToGetSameEffectHeroin,
                experiencesWithdrawalSicknessHeroin,
                useSubstanceToPreventWithdrawalSicknessHeroin,
                increasedDoseRequiredToGetSameEffectMethadone,
                experiencesWithdrawalSicknessMethadone,
                useSubstanceToPreventWithdrawalSicknessMethadone,
                increasedDoseRequiredToGetSameEffectOtherOpiate,
                experiencesWithdrawalSicknessOtherOpiate,
                useSubstanceToPreventWithdrawalSicknessOtherOpiate,
                numberOfDaysUsedInPast30DaysHeroin,
                numberOfDaysUsedInPast30DaysMethadone,
                numberOfDaysUsedInPast30DaysOtherOpiate,
                numberOfMonthsUsedInLifetimeHeroin,
                numberOfMonthsUsedInLifetimeMethadone,
                numberOfMonthsUsedInLifetimeOtherOpiate,
                heartRate,
                bloodPressure,
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
                evidenceFromUrineScreenOfOpioidDependenceOtherOpiate,
                documentedEvidenceOfOpioidDependenceAtLeast1YearOtherOpiate,
                increasedDoseRequiredToGetSameEffect,
                experiencesWithdrawalSickness,
                useSubstanceToPreventWithdrawalSickness,
                inPenalOrChronicCareSettingRecently,
                pregnantStatus,
                isDependentHeroin,
                isDependentMethadone,
                isDependentOterOpiate,
                hasEverUsedHeroin,
                lastUsedHeroin,
                hasEverUsedMethadone,
                lastUsedMethadone,
                hasEverUsedOtherOpiate,
                lastUsedOtherOpiate,
                toBePrescribedOpioidDetoxificationProtocol,
                completedAtLeast6MonthOpioidMaintenanceTherapyVoluntarily,
                detoxificationEndedLessThanOrEqual2YearsAgo,
                opioidMaintenanceTherapyReadmissionMedicallyIndicated,
                anyOpioidAddictionDiagnosis );

           
            Assert.AreEqual(physiologicallyDependentOpiateDrugAtLeast1YearBeforeMethadoneAdmission, careLevel_OMT_Score.PhysiologicallyDependentOpiateDrugAtLeast1YearBeforeMethadoneAdmission, "PhysiologicallyDependentOpiateDrugAtLeast1YearBeforeMethadoneAdmission didn't match.");
            Assert.AreEqual(currentPhysiologicalDependenceIsConfirmed, careLevel_OMT_Score.CurrentPhysiologicalDependenceIsConfirmed, "CurrentPhysiologicalDependenceIsConfirmed didn't match.");
            Assert.AreEqual(canBeAdmittedFromCriminalJusticeSettingWithin14DaysOfRelease, careLevel_OMT_Score.CanBeAdmittedFromCriminalJusticeSettingWithin14DaysOfRelease, "CanBeAdmittedFromCriminalJusticeSettingWithin14DaysOfRelease didn't match.");
            Assert.AreEqual(isPregnantWithHistoryOfOpiateDependenceTreatmentMedicallyJustified, careLevel_OMT_Score.IsPregnantWithHistoryOfOpiateDependenceTreatmentMedicallyJustified, "IsPregnantWithHistoryOfOpiateDependenceTreatmentMedicallyJustified didn't match.");
            Assert.AreEqual(isPreviouslyTreatedVoluntarilyDetoxedFromMethadoneWithin2Years, careLevel_OMT_Score.IsPreviouslyTreatedVoluntarilyDetoxedFromMethadoneWithin2Years, "IsPreviouslyTreatedVoluntarilyDetoxedFromMethadoneWithin2Years didn't match.");
            Assert.AreEqual(isMet, careLevel_OMT_Score.IsMet, "CareLevel_OMT_Score didn't match.");
        }
    }
}
