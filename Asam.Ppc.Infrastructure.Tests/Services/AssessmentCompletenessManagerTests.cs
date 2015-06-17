using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asam.Ppc.Infrastructure.Tests.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure.Services;
    using Moq;
    using Pillar.FluentRuleEngine;
    using Ppc.Domain.AssessmentModule;
    using Ppc.Domain.AssessmentModule.GeneralInformation;
    using Ppc.Domain.PatientModule;

    [TestClass]
    public class AssessmentCompletenessManagerTests
    {
        [TestMethod]
        public void GetAsssessmentCompletenessMetadata_ValidRuleCollection_MetadataContainsCompletenessMetadata()
        {
            var ruleCollection = new TestCompletenessRuleCollection();
            var mockCompletenessRuleCollectionFactory = new Mock<ICompletenessRuleCollectionFactory>();
            mockCompletenessRuleCollectionFactory.Setup(f => f.GetCompletnessRuleCollections<Assessment>())
                                                 .Returns(new List<ICompletenessRuleCollection<Assessment>> { ruleCollection });
            var assessmentCompletenessManager = new AssessmentCompletenessManager(mockCompletenessRuleCollectionFactory.Object, new Mock<IRuleEngineFactory>().Object);
            var metadataDto = assessmentCompletenessManager.GetAsssessmentCompletenessMetadata<Assessment>();

            Assert.IsTrue(metadataDto.ChildMetadataExists("GeneralInformationSection") &&
                            metadataDto.GetChildMetadata("GeneralInformationSection").ChildMetadataExists("AssessmentClass") &&
                            metadataDto.GetChildMetadata("GeneralInformationSection")
                                       .GetChildMetadata("AssessmentClass")
                                       .FindMetadataItem<RequiredForCompletenessMetadataItemDto>() != null);
            Assert.AreEqual(metadataDto.GetChildMetadata("GeneralInformationSection")
                                       .GetChildMetadata("AssessmentClass")
                                       .FindMetadataItem<RequiredForCompletenessMetadataItemDto>().CompletenessCategory, ruleCollection.CompletenessCategory);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetAsssessmentCompletenessMetadata_MultipleRuleCollectionWithSameCompletenessCategory_ThrowsInvalidOperationException()
        {
            var ruleCollection = new TestCompletenessRuleCollection();
            var mockCompletenessRuleCollectionFactory = new Mock<ICompletenessRuleCollectionFactory>();
            mockCompletenessRuleCollectionFactory.Setup(f => f.GetCompletnessRuleCollections<Assessment>())
                                                 .Returns(new List<ICompletenessRuleCollection<Assessment>> { ruleCollection, ruleCollection });
            var assessmentCompletenessManager = new AssessmentCompletenessManager(mockCompletenessRuleCollectionFactory.Object, new Mock<IRuleEngineFactory>().Object);
            assessmentCompletenessManager.GetAsssessmentCompletenessMetadata<Assessment>();
        }

        [TestMethod]
        public void GetAsssessmentCompletenessMetadata_NoRuleCollection_EmptyMetadataDto()
        {
            var mockCompletenessRuleCollectionFactory = new Mock<ICompletenessRuleCollectionFactory>();
            mockCompletenessRuleCollectionFactory.Setup(f => f.GetCompletnessRuleCollections<Assessment>())
                                                 .Returns(Enumerable.Empty<ICompletenessRuleCollection<Assessment>>);
            var assessmentCompletenessManager = new AssessmentCompletenessManager(mockCompletenessRuleCollectionFactory.Object, new Mock<IRuleEngineFactory>().Object);
            var metadataDto = assessmentCompletenessManager.GetAsssessmentCompletenessMetadata<Assessment>();

            Assert.IsTrue(metadataDto.Children.Count == 0 && metadataDto.MetadataItemDtos.Count == 0);
        }

        [TestMethod]
        public void ExecuteCompleteness_IncompleteAssessment_ResultCorrect()
        {
            var ruleCollection = new TestCompletenessRuleCollection();
            var mockCompletenessRuleCollectionFactory = new Mock<ICompletenessRuleCollectionFactory>();
            mockCompletenessRuleCollectionFactory.Setup(f => f.GetCompletenessRuleCollection<Assessment>( It.IsAny<string> ()))
                                                 .Returns(ruleCollection);
            var ruleEngine = new RuleEngine<Assessment>(ruleCollection);
            var mockRuleEngineFactory = new Mock<IRuleEngineFactory>();
            mockRuleEngineFactory.Setup(f => f.CreateRuleEngine(It.IsAny<Assessment>(), It.IsAny<IRuleCollection<Assessment>>()))
                .Returns(ruleEngine);
            var assessmentCompletenessManager = new AssessmentCompletenessManager(mockCompletenessRuleCollectionFactory.Object, mockRuleEngineFactory.Object);

            var assessmentMock = new Mock<Assessment> ();
            assessmentMock.SetupGet ( a => a.GeneralInformationSection ).Returns ( new Mock<GeneralInformationSection> ().Object );

            var result = assessmentCompletenessManager.ExecuteCompleteness ( "Test", assessmentMock.Object );

            Assert.IsTrue ( result.NumberInComplete > 0 );
        }

        [TestMethod]
        public void ExecuteCompleteness_CompleteAssessment_ResultCorrect()
        {
            var ruleCollection = new TestCompletenessRuleCollection();
            var mockCompletenessRuleCollectionFactory = new Mock<ICompletenessRuleCollectionFactory>();
            mockCompletenessRuleCollectionFactory.Setup(f => f.GetCompletenessRuleCollection<Assessment>(It.IsAny<string>()))
                                                 .Returns(ruleCollection);
            var ruleEngine = new RuleEngine<Assessment>(ruleCollection);
            var mockRuleEngineFactory = new Mock<IRuleEngineFactory>();
            mockRuleEngineFactory.Setup(f => f.CreateRuleEngine(It.IsAny<Assessment>(), It.IsAny<IRuleCollection<Assessment>>()))
                .Returns(ruleEngine);
            var assessmentCompletenessManager = new AssessmentCompletenessManager(mockCompletenessRuleCollectionFactory.Object, mockRuleEngineFactory.Object);

            var generalInformationMock = new Mock<GeneralInformationSection> ();
            generalInformationMock.SetupGet ( gi => gi.AssessmentClass ).Returns ( new AssessmentClass () );

            var assessmentMock = new Mock<Assessment>();
            assessmentMock.SetupGet(a => a.GeneralInformationSection).Returns(generalInformationMock.Object);

            var result = assessmentCompletenessManager.ExecuteCompleteness("Test", assessmentMock.Object);

            Assert.IsTrue(result.NumberInComplete == 0);
        }
    }
}
