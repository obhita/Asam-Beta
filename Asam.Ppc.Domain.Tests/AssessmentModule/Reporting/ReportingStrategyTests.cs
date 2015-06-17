using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.Scoring.ReportModule;
using Asam.Ppc.Domain.Tests.Extensions;
using Asam.Ppc.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asam.Ppc.Domain.Tests.AssessmentModule.Reporting
{
    [TestClass]
    public class ReportingStrategyTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Rx_AccessToTreatmentIssuesSection")]
        public void Rx_CalculateAccessToTreatmentIssuesSectionTests()
        {
            var unsteadinessOrLossOfBalance = TestContext.GetLookup<YesNoNotSure>("UnsteadinessOrLossOfBalance");
            var mobilityProblemsMayAffectTreatmentAttendance = TestContext.GetLookup<YesNoNotSure>("MobilityProblemsMayAffectTreatmentAttendance");
            var hasValidDriversLicense = TestContext.GetBoolean("HasValidDriversLicense");
            var numberOfDependents = TestContext.GetUInt32("NumberOfDependents");
            var isOnProbationOrParole = TestContext.GetBoolean("IsOnProbationOrParole");
            var isCurrentlyAwaitingChargesTrialSentence = TestContext.GetBoolean("IsCurrentlyAwaitingChargesTrialSentence");
            var isAbleToLocateAndGetToCommunityResourcesSafely = TestContext.GetBoolean("IsAbleToLocateAndGetToCommunityResourcesSafely");
            var isPatientAvailableForFollowupFor7Days = TestContext.GetLookup<YesNoNotSure>("IsPatientAvailableForFollowupFor7Days");
            var isOutpatientMonitoringAvailable8To24Hours = TestContext.GetLookup<YesNoNotSure>("IsOutpatientMonitoringAvailable8To24Hours");
            var evidenceOfChronicOrganicMentalDisability = TestContext.GetLookup<YesNoNotSure>("EvidenceOfChronicOrganicMentalDisability");
            var currentBehaviorInconsistentWithSelfCare = TestContext.GetLookup<YesNoNotSure>("CurrentBehaviorInconsistentWithSelfCare");
            var psychiatricEvaluationAndServicesAccessibleToPatient = TestContext.GetLookup<YesNoNotSure>("PsychiatricEvaluationAndServicesAccessibleToPatient");
            var intensiveCaseManagementAccessibleToPatient = TestContext.GetLookup<YesNoNotSure>("IntensiveCaseManagementAccessibleToPatient");
            var isAbleToSelfAdministerMedication = TestContext.GetLookup<YesNoNotApplicable>("IsAbleToSelfAdministerMedication");

            var count = TestContext.GetInt32("Count");

            var reportingStrategy = new ReportingStrategy();
            reportingStrategy.ResourceWrapper =
                new ResourceWrapper ( new PronounProcessor ( new PersonName ( "Ms.", "Jane", "", "Jones", "" ),
                                                          Gender.Female ) );
            var accessToTreatmentIssuesSection = reportingStrategy.CalculateAccessToTreatmentIssuesSection(
                unsteadinessOrLossOfBalance,
                mobilityProblemsMayAffectTreatmentAttendance,
                hasValidDriversLicense,
                numberOfDependents,
                isOnProbationOrParole,
                isCurrentlyAwaitingChargesTrialSentence,
                isAbleToLocateAndGetToCommunityResourcesSafely,
                isPatientAvailableForFollowupFor7Days,
                isOutpatientMonitoringAvailable8To24Hours,
                evidenceOfChronicOrganicMentalDisability,
                currentBehaviorInconsistentWithSelfCare,
                psychiatricEvaluationAndServicesAccessibleToPatient,
                intensiveCaseManagementAccessibleToPatient,
                isAbleToSelfAdministerMedication);

            Assert.AreEqual(count, accessToTreatmentIssuesSection.AccessItems.Count, "AccessItems.Count didn't match.");
        }
    }
}
