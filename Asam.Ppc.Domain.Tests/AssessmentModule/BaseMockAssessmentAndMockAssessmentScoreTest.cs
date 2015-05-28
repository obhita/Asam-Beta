using Asam.Ppc.Domain.Scoring.ScoringModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Asam.Ppc.Domain.Tests.AssessmentModule
{
    [TestClass]
    public class BaseMockAssessmentAndMockAssessmentScoreTest : BaseMockAssessmentTest
    {
        public Mock<AssessmentScore> AssessmentScoreMock { get; set; }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize (  );

            var assessmentScoreMock = new Mock<AssessmentScore>(It.IsAny<string>());
            AssessmentScoreMock = assessmentScoreMock;
        }
    }
}
