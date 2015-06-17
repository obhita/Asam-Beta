using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.Scoring;
using Asam.Ppc.Domain.Scoring.ReportModule;
using Asam.Ppc.Domain.Scoring.ReportModule.AccessToTreatmentIssues;
using Asam.Ppc.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Asam.Ppc.Domain.Tests.AssessmentModule.Reporting
{
    [TestClass]
    public class ReportingEngineTests : BaseMockAssessmentTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void GenerateDocumentUsingAsamDocGenerator ( )
        {
            var reportingStrategy = new Mock<IReportingStrategy>().Object;
            var assessmentNullPropertyIntitializer = new Mock<IAssessmentNullPropertyInitializer>().Object;
            var reportingEngine = new ReportingEngine(reportingStrategy, assessmentNullPropertyIntitializer );
            var doc = reportingEngine.GenerateDocumentUsingAsamDocGenerator(ReportingEngineTestData.GetDataContext(), ".");
            var result = ReportingEngine.WriteOutputToFile(ReportingEngine.DocumentOutputFile, ReportingEngine.DocumentTemplate, doc);

            Assert.AreEqual("Generation succeeded for template(AsamDocumentTemplate.docx) --> AsamDocumentReport.docx", result);
        }
        
        [TestMethod]
        public void Rx_UtilGetResourcesTest()
        {
            var accessToTreatmentIssuesSection = new AccessToTreatmentIssuesSection ( );
            var resourceUtil = new ResourceWrapper ( new PronounProcessor ( new Mock<PersonName> ( ).Object, new Mock<Gender> ( ).Object ) );
            accessToTreatmentIssuesSection = resourceUtil.GetResources ( accessToTreatmentIssuesSection );
            Assert.IsFalse ( accessToTreatmentIssuesSection.AccessSummary == string.Empty );
        }
    }
}
