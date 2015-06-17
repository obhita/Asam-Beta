using System;
using System.Collections.Generic;
using System.Linq;
using Asam.Ppc.Domain.AssessmentModule;
using Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.PatientModule;
using Asam.Ppc.Mvc.Infrastructure.Service;
using Asam.Ppc.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pillar.Common.Utility;

namespace Asam.Ppc.Mvc.Infrastructure.Tests.Service
{
    using Domain.OrganizationModule;

    [TestClass]
    public class AsamRouteNavigationServiceTests
    {
        const long assessmentId = 1;

        private static Assessment CreateAssessment()
        {
            var mockPatient = new Mock<Patient> ();
            mockPatient.SetupGet ( p => p.Organization ).Returns ( new Organization ( "Test" ) );
            mockPatient.SetupGet ( p => p.Name ).Returns ( new PersonName ( "John", "Smith" ) );
            mockPatient.SetupGet ( p => p.DateOfBirth ).Returns ( DateTime.Now );
            mockPatient.SetupGet ( p => p.Gender ).Returns ( Gender.Male );
            return
                new Assessment(mockPatient.Object);
        }
        
        [TestMethod]
        public void LoadAssessment_NoUsedSubstances_NoUsedSubstanceSectionRoutesCreated()
        {
            var assessment = CreateAssessment ();

            var mockAssessmentRepository = new Mock<IAssessmentRepository> ();
            mockAssessmentRepository.Setup ( r => r.GetByKey( It.IsAny<long> () ) ).Returns ( assessment );

            var asamRouteNavigationService = new AsamRouteNavigationService (mockAssessmentRepository.Object);

            asamRouteNavigationService.LoadAssessment ( assessmentId );

            Assert.IsFalse (
                            asamRouteNavigationService.OrderedRouteInfoList.Any (
                                                                                 route =>
                                                                                 route.Section ==
                                                                                 "DrugAndAlcoholSection" &&
                                                                                 route.SubSection != "UsedSubstances" ) );
        }

        [TestMethod]
        public void LoadAssessment_WithAlcohol_HasAlcoholSubstanceRelatedSectionRoutesCreated()
        {
            

            var assessment = CreateAssessment();

            assessment.DrugAndAlcoholSection.UsedSubstances.ReviseProperty ( assessmentId,
                                                              PropertyUtil.ExtractPropertyName ( () => assessment.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed ),
                                                              new List<SubstanceCategory>
                                                                  {
                                                                      SubstanceCategory.Alcohol
                                                                  } );

            

            var mockAssessmentRepository = new Mock<IAssessmentRepository>();
            mockAssessmentRepository.Setup(r => r.GetByKey(It.IsAny<long>())).Returns(assessment);

            var asamRouteNavigationService = new AsamRouteNavigationService(mockAssessmentRepository.Object);

            asamRouteNavigationService.LoadAssessment(assessmentId);

            var expectedSubSections = new List<string>
                {
                    "AlcoholUse",
                    "CiwaScale",
                    "AddictionTreatmentHistory",
                    "AdditionalAddictionAndTreatmentItems",
                    "AlcoholAndDrugInterviewerRating"
                };

            var sectionsCount =
                asamRouteNavigationService.OrderedRouteInfoList.Count (
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     expectedSubSections.Contains ( route.SubSection ));
            var hasOtherSections =
                asamRouteNavigationService.OrderedRouteInfoList.Any(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     route.SubSection != "UsedSubstances" &&
                                                                     !expectedSubSections.Contains(route.SubSection));

            Assert.IsTrue( sectionsCount == expectedSubSections.Count && !hasOtherSections );
        }

        [TestMethod]
        public void LoadAssessment_WithHeroin_HasHeroinSubstanceRelatedSectionRoutesCreated()
        {
            
            var assessment = CreateAssessment();

            assessment.DrugAndAlcoholSection.UsedSubstances.ReviseProperty(assessmentId,
                                                              PropertyUtil.ExtractPropertyName(() => assessment.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed),
                                                              new List<SubstanceCategory>
                                                                  {
                                                                      SubstanceCategory.Heroin
                                                                  });

            

            var mockAssessmentRepository = new Mock<IAssessmentRepository>();
            mockAssessmentRepository.Setup(r => r.GetByKey(It.IsAny<long>())).Returns(assessment);

            var asamRouteNavigationService = new AsamRouteNavigationService(mockAssessmentRepository.Object);

            asamRouteNavigationService.LoadAssessment(assessmentId);

            var expectedSubSections = new List<string>
                {
                    "HeroinUse",
                    "DrugConsequences",
                    "CinaScale",
                    "AddictionTreatmentHistory",
                    "AdditionalAddictionAndTreatmentItems",
                    "AlcoholAndDrugInterviewerRating",
                    "OpiatesInControlledEnvironment",
                    "OpioidMaintenanceTherapy"
                };

            var sectionsCount =
                asamRouteNavigationService.OrderedRouteInfoList.Count(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     expectedSubSections.Contains(route.SubSection));
            var hasOtherSections =
                asamRouteNavigationService.OrderedRouteInfoList.Any(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     route.SubSection != "UsedSubstances" &&
                                                                     !expectedSubSections.Contains(route.SubSection));

            Assert.IsTrue(sectionsCount == expectedSubSections.Count && !hasOtherSections);
        }

        [TestMethod]
        public void LoadAssessment_WithMethadone_HasMethadoneSubstanceRelatedSectionRoutesCreated()
        {
            

            var assessment = CreateAssessment();

            assessment.DrugAndAlcoholSection.UsedSubstances.ReviseProperty(assessmentId,
                                                              PropertyUtil.ExtractPropertyName(() => assessment.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed),
                                                              new List<SubstanceCategory>
                                                                  {
                                                                      SubstanceCategory.Methadone
                                                                  });

            

            var mockAssessmentRepository = new Mock<IAssessmentRepository>();
            mockAssessmentRepository.Setup(r => r.GetByKey(It.IsAny<long>())).Returns(assessment);

            var asamRouteNavigationService = new AsamRouteNavigationService(mockAssessmentRepository.Object);

            asamRouteNavigationService.LoadAssessment(assessmentId);

            var expectedSubSections = new List<string>
                {
                    "MethadoneUse",
                    "DrugConsequences",
                    "CinaScale",
                    "OpiatesInControlledEnvironment",
                    "OpioidMaintenanceTherapy",
                    "AddictionTreatmentHistory",
                    "AdditionalAddictionAndTreatmentItems",
                    "AlcoholAndDrugInterviewerRating"
                };

            var sectionsExpectedFound =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     expectedSubSections.Contains(route.SubSection));
            var otherSections =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     route.SubSection != "UsedSubstances" &&
                                                                     !expectedSubSections.Contains(route.SubSection));

            Assert.IsTrue( sectionsExpectedFound.Count() == expectedSubSections.Count && !otherSections.Any());
        }

        [TestMethod]
        public void LoadAssessment_WithOtherOpiate_HasOtherOpiateSubstanceRelatedSectionRoutesCreated()
        {
            

            var assessment = CreateAssessment();

            assessment.DrugAndAlcoholSection.UsedSubstances.ReviseProperty(assessmentId,
                                                              PropertyUtil.ExtractPropertyName(() => assessment.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed),
                                                              new List<SubstanceCategory>
                                                                  {
                                                                      SubstanceCategory.OtherOpiate
                                                                  });

            

            var mockAssessmentRepository = new Mock<IAssessmentRepository>();
            mockAssessmentRepository.Setup(r => r.GetByKey(It.IsAny<long>())).Returns(assessment);

            var asamRouteNavigationService = new AsamRouteNavigationService(mockAssessmentRepository.Object);

            asamRouteNavigationService.LoadAssessment(assessmentId);

            var expectedSubSections = new List<string>
                {
                    "OtherOpiateUse",
                    "DrugConsequences",
                    "CinaScale",
                    "OpiatesInControlledEnvironment",
                    "OpioidMaintenanceTherapy",
                    "AddictionTreatmentHistory",
                    "AdditionalAddictionAndTreatmentItems",
                    "AlcoholAndDrugInterviewerRating"
                };

            var sectionsExpectedFound =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     expectedSubSections.Contains(route.SubSection));
            var otherSections =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     route.SubSection != "UsedSubstances" &&
                                                                     !expectedSubSections.Contains(route.SubSection));

            Assert.IsTrue(sectionsExpectedFound.Count() == expectedSubSections.Count && !otherSections.Any());
        }

        [TestMethod]
        public void LoadAssessment_WithBarbiturates_HasBarbituratesSubstanceRelatedSectionRoutesCreated()
        {
            

            var assessment = CreateAssessment();

            assessment.DrugAndAlcoholSection.UsedSubstances.ReviseProperty(assessmentId,
                                                              PropertyUtil.ExtractPropertyName(() => assessment.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed),
                                                              new List<SubstanceCategory>
                                                                  {
                                                                      SubstanceCategory.Barbiturates
                                                                  });

            

            var mockAssessmentRepository = new Mock<IAssessmentRepository>();
            mockAssessmentRepository.Setup(r => r.GetByKey(It.IsAny<long>())).Returns(assessment);

            var asamRouteNavigationService = new AsamRouteNavigationService(mockAssessmentRepository.Object);

            asamRouteNavigationService.LoadAssessment(assessmentId);

            var expectedSubSections = new List<string>
                {
                    "BarbiturateUse",
                    "DrugConsequences",
                    "CiwaScale",
                    "AddictionTreatmentHistory",
                    "AdditionalAddictionAndTreatmentItems",
                    "AlcoholAndDrugInterviewerRating"
                };

            var sectionsExpectedFound =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     expectedSubSections.Contains(route.SubSection));
            var otherSections =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     route.SubSection != "UsedSubstances" &&
                                                                     !expectedSubSections.Contains(route.SubSection));

            Assert.IsTrue(sectionsExpectedFound.Count() == expectedSubSections.Count && !otherSections.Any());
        }

        [TestMethod]
        public void LoadAssessment_WithOtherSedatives_HasOtherSedativesSubstanceRelatedSectionRoutesCreated()
        {
            

            var assessment = CreateAssessment();

            assessment.DrugAndAlcoholSection.UsedSubstances.ReviseProperty(assessmentId,
                                                              PropertyUtil.ExtractPropertyName(() => assessment.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed),
                                                              new List<SubstanceCategory>
                                                                  {
                                                                      SubstanceCategory.OtherSedatives
                                                                  });

            

            var mockAssessmentRepository = new Mock<IAssessmentRepository>();
            mockAssessmentRepository.Setup(r => r.GetByKey(It.IsAny<long>())).Returns(assessment);

            var asamRouteNavigationService = new AsamRouteNavigationService(mockAssessmentRepository.Object);

            asamRouteNavigationService.LoadAssessment(assessmentId);

            var expectedSubSections = new List<string>
                {
                    "OtherSedativeUse",
                    "DrugConsequences",
                    "CiwaScale",
                    "AddictionTreatmentHistory",
                    "AdditionalAddictionAndTreatmentItems",
                    "AlcoholAndDrugInterviewerRating"
                };

            var sectionsExpectedFound =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     expectedSubSections.Contains(route.SubSection));
            var otherSections =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     route.SubSection != "UsedSubstances" &&
                                                                     !expectedSubSections.Contains(route.SubSection));

            Assert.IsTrue(sectionsExpectedFound.Count() == expectedSubSections.Count && !otherSections.Any());
        }

        [TestMethod]
        public void LoadAssessment_WithCocaine_HasCocaineSubstanceRelatedSectionRoutesCreated()
        {
            

            var assessment = CreateAssessment();

            assessment.DrugAndAlcoholSection.UsedSubstances.ReviseProperty(assessmentId,
                                                              PropertyUtil.ExtractPropertyName(() => assessment.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed),
                                                              new List<SubstanceCategory>
                                                                  {
                                                                      SubstanceCategory.Cocaine
                                                                  });

            

            var mockAssessmentRepository = new Mock<IAssessmentRepository>();
            mockAssessmentRepository.Setup(r => r.GetByKey(It.IsAny<long>())).Returns(assessment);

            var asamRouteNavigationService = new AsamRouteNavigationService(mockAssessmentRepository.Object);

            asamRouteNavigationService.LoadAssessment(assessmentId);

            var expectedSubSections = new List<string>
                {
                    "CocaineUse",
                    "DrugConsequences",
                    "AddictionTreatmentHistory",
                    "AdditionalAddictionAndTreatmentItems",
                    "AlcoholAndDrugInterviewerRating"
                };

            var sectionsExpectedFound =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     expectedSubSections.Contains(route.SubSection));
            var otherSections =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     route.SubSection != "UsedSubstances" &&
                                                                     !expectedSubSections.Contains(route.SubSection));

            Assert.IsTrue(sectionsExpectedFound.Count() == expectedSubSections.Count && !otherSections.Any());
        }

        [TestMethod]
        public void LoadAssessment_WithStimulant_HasStimulantSubstanceRelatedSectionRoutesCreated()
        {
            

            var assessment = CreateAssessment();

            assessment.DrugAndAlcoholSection.UsedSubstances.ReviseProperty(assessmentId,
                                                              PropertyUtil.ExtractPropertyName(() => assessment.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed),
                                                              new List<SubstanceCategory>
                                                                  {
                                                                      SubstanceCategory.Stimulants
                                                                  });

            

            var mockAssessmentRepository = new Mock<IAssessmentRepository>();
            mockAssessmentRepository.Setup(r => r.GetByKey(It.IsAny<long>())).Returns(assessment);

            var asamRouteNavigationService = new AsamRouteNavigationService(mockAssessmentRepository.Object);

            asamRouteNavigationService.LoadAssessment(assessmentId);

            var expectedSubSections = new List<string>
                {
                    "StimulantUse",
                    "DrugConsequences",
                    "AddictionTreatmentHistory",
                    "AdditionalAddictionAndTreatmentItems",
                    "AlcoholAndDrugInterviewerRating"
                };

            var sectionsExpectedFound =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     expectedSubSections.Contains(route.SubSection));
            var otherSections =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     route.SubSection != "UsedSubstances" &&
                                                                     !expectedSubSections.Contains(route.SubSection));

            Assert.IsTrue(sectionsExpectedFound.Count() == expectedSubSections.Count && !otherSections.Any());
        }

        [TestMethod]
        public void LoadAssessment_WithCannabis_HasCannabisSubstanceRelatedSectionRoutesCreated()
        {
            

            var assessment = CreateAssessment();

            assessment.DrugAndAlcoholSection.UsedSubstances.ReviseProperty(assessmentId,
                                                              PropertyUtil.ExtractPropertyName(() => assessment.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed),
                                                              new List<SubstanceCategory>
                                                                  {
                                                                      SubstanceCategory.Cannabis
                                                                  });

            

            var mockAssessmentRepository = new Mock<IAssessmentRepository>();
            mockAssessmentRepository.Setup(r => r.GetByKey(It.IsAny<long>())).Returns(assessment);

            var asamRouteNavigationService = new AsamRouteNavigationService(mockAssessmentRepository.Object);

            asamRouteNavigationService.LoadAssessment(assessmentId);

            var expectedSubSections = new List<string>
                {
                    "CannabisUse",
                    "DrugConsequences",
                    "AddictionTreatmentHistory",
                    "AdditionalAddictionAndTreatmentItems",
                    "AlcoholAndDrugInterviewerRating"
                };

            var sectionsExpectedFound =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     expectedSubSections.Contains(route.SubSection));
            var otherSections =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     route.SubSection != "UsedSubstances" &&
                                                                     !expectedSubSections.Contains(route.SubSection));

            Assert.IsTrue(sectionsExpectedFound.Count() == expectedSubSections.Count && !otherSections.Any());
        }

        [TestMethod]
        public void LoadAssessment_WithHallucinogen_HasHallucinogenSubstanceRelatedSectionRoutesCreated()
        {
            

            var assessment = CreateAssessment();

            assessment.DrugAndAlcoholSection.UsedSubstances.ReviseProperty(assessmentId,
                                                              PropertyUtil.ExtractPropertyName(() => assessment.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed),
                                                              new List<SubstanceCategory>
                                                                  {
                                                                      SubstanceCategory.Hallucinogens
                                                                  });

            

            var mockAssessmentRepository = new Mock<IAssessmentRepository>();
            mockAssessmentRepository.Setup(r => r.GetByKey(It.IsAny<long>())).Returns(assessment);

            var asamRouteNavigationService = new AsamRouteNavigationService(mockAssessmentRepository.Object);

            asamRouteNavigationService.LoadAssessment(assessmentId);

            var expectedSubSections = new List<string>
                {
                    "HallucinogenUse",
                    "DrugConsequences",
                    "AddictionTreatmentHistory",
                    "AdditionalAddictionAndTreatmentItems",
                    "AlcoholAndDrugInterviewerRating"
                };

            var sectionsExpectedFound =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     expectedSubSections.Contains(route.SubSection));
            var otherSections =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     route.SubSection != "UsedSubstances" &&
                                                                     !expectedSubSections.Contains(route.SubSection));

            Assert.IsTrue(sectionsExpectedFound.Count() == expectedSubSections.Count && !otherSections.Any());
        }

        [TestMethod]
        public void LoadAssessment_WithSolventInhalant_HasSolventInhalantSubstanceRelatedSectionRoutesCreated()
        {
            

            var assessment = CreateAssessment();

            assessment.DrugAndAlcoholSection.UsedSubstances.ReviseProperty(assessmentId,
                                                              PropertyUtil.ExtractPropertyName(() => assessment.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed),
                                                              new List<SubstanceCategory>
                                                                  {
                                                                      SubstanceCategory.SolventInhalants
                                                                  });

            

            var mockAssessmentRepository = new Mock<IAssessmentRepository>();
            mockAssessmentRepository.Setup(r => r.GetByKey(It.IsAny<long>())).Returns(assessment);

            var asamRouteNavigationService = new AsamRouteNavigationService(mockAssessmentRepository.Object);

            asamRouteNavigationService.LoadAssessment(assessmentId);

            var expectedSubSections = new List<string>
                {
                    "SolventAndInhalantUse",
                    "DrugConsequences",
                    "AddictionTreatmentHistory",
                    "AdditionalAddictionAndTreatmentItems",
                    "AlcoholAndDrugInterviewerRating"
                };

            var sectionsExpectedFound =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     expectedSubSections.Contains(route.SubSection));
            var otherSections =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     route.SubSection != "UsedSubstances" &&
                                                                     !expectedSubSections.Contains(route.SubSection));

            Assert.IsTrue(sectionsExpectedFound.Count() == expectedSubSections.Count && !otherSections.Any());
        }

        [TestMethod]
        public void LoadAssessment_WithMultipleSubstanceUsePerDay_HasMultipleSubstanceUsePerDaySubstanceRelatedSectionRoutesCreated()
        {
            

            var assessment = CreateAssessment();

            assessment.DrugAndAlcoholSection.UsedSubstances.ReviseProperty(assessmentId,
                                                              PropertyUtil.ExtractPropertyName(() => assessment.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed),
                                                              new List<SubstanceCategory>
                                                                  {
                                                                      SubstanceCategory.MultiplePerDay
                                                                  });

            

            var mockAssessmentRepository = new Mock<IAssessmentRepository>();
            mockAssessmentRepository.Setup(r => r.GetByKey(It.IsAny<long>())).Returns(assessment);

            var asamRouteNavigationService = new AsamRouteNavigationService(mockAssessmentRepository.Object);

            asamRouteNavigationService.LoadAssessment(assessmentId);

            var expectedSubSections = new List<string>
                {
                    "MultipleSubstanceUsePerDay",
                    "DrugConsequences",
                    "AddictionTreatmentHistory",
                    "AdditionalAddictionAndTreatmentItems",
                    "AlcoholAndDrugInterviewerRating"
                };

            var sectionsExpectedFound =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     expectedSubSections.Contains(route.SubSection));
            var otherSections =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     route.SubSection != "UsedSubstances" &&
                                                                     !expectedSubSections.Contains(route.SubSection));

            Assert.IsTrue(sectionsExpectedFound.Count() == expectedSubSections.Count && !otherSections.Any());
        }

        [TestMethod]
        public void LoadAssessment_WithNicotine_HasNicotineSubstanceRelatedSectionRoutesCreated()
        {
            

            var assessment = CreateAssessment();

            assessment.DrugAndAlcoholSection.UsedSubstances.ReviseProperty(assessmentId,
                                                              PropertyUtil.ExtractPropertyName(() => assessment.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed),
                                                              new List<SubstanceCategory>
                                                                  {
                                                                      SubstanceCategory.Nicotine
                                                                  });

            

            var mockAssessmentRepository = new Mock<IAssessmentRepository>();
            mockAssessmentRepository.Setup(r => r.GetByKey(It.IsAny<long>())).Returns(assessment);

            var asamRouteNavigationService = new AsamRouteNavigationService(mockAssessmentRepository.Object);

            asamRouteNavigationService.LoadAssessment(assessmentId);

            var expectedSubSections = new List<string>
                {
                    "NicotineUse",
                    "DrugConsequences",
                    "AddictionTreatmentHistory",
                    "AdditionalAddictionAndTreatmentItems",
                    "AlcoholAndDrugInterviewerRating"
                };

            var sectionsExpectedFound =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     expectedSubSections.Contains(route.SubSection));
            var otherSections =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     route.SubSection != "UsedSubstances" &&
                                                                     !expectedSubSections.Contains(route.SubSection));

            Assert.IsTrue(sectionsExpectedFound.Count() == expectedSubSections.Count && !otherSections.Any());
        }

        [TestMethod]
        public void LoadAssessment_WithOtherSubstance_HasOtherSubstanceSubstanceRelatedSectionRoutesCreated()
        {
            

            var assessment = CreateAssessment();

            assessment.DrugAndAlcoholSection.UsedSubstances.ReviseProperty(assessmentId,
                                                              PropertyUtil.ExtractPropertyName(() => assessment.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed),
                                                              new List<SubstanceCategory>
                                                                  {
                                                                      SubstanceCategory.OtherSubstance
                                                                  });

            

            var mockAssessmentRepository = new Mock<IAssessmentRepository>();
            mockAssessmentRepository.Setup(r => r.GetByKey(It.IsAny<long>())).Returns(assessment);

            var asamRouteNavigationService = new AsamRouteNavigationService(mockAssessmentRepository.Object);

            asamRouteNavigationService.LoadAssessment(assessmentId);

            var expectedSubSections = new List<string>
                {
                    "OtherSubstanceUse",
                    "DrugConsequences",
                    "AddictionTreatmentHistory",
                    "AdditionalAddictionAndTreatmentItems",
                    "AlcoholAndDrugInterviewerRating"
                };

            var sectionsExpectedFound =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     expectedSubSections.Contains(route.SubSection));
            var otherSections =
                asamRouteNavigationService.OrderedRouteInfoList.Where(
                                                                     route =>
                                                                     route.Section == "DrugAndAlcoholSection" &&
                                                                     route.SubSection != "UsedSubstances" &&
                                                                     !expectedSubSections.Contains(route.SubSection));

            Assert.IsTrue(sectionsExpectedFound.Count() == expectedSubSections.Count && !otherSections.Any());
        }
    }
}
