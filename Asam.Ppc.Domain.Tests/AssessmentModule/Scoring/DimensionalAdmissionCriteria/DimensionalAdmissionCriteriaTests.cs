using Asam.Ppc.Domain.Scoring.ScoringModule.DimensionalAdmissionCriteria;
using Asam.Ppc.Domain.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asam.Ppc.Domain.Tests.AssessmentModule.Scoring.DimensionalAdmissionCriteria
{
    [TestClass]
    public class DimensionalAdmissionCriteriaTests
    {
        #region

        public TestContext TestContext { get; set; } 

        #endregion
        [TestMethod]
        [DataSource("DAC_CareLevel_I_DetoxificationScore")]
        public void DAC_CalculateCareLevel_I_DetoxificationScoreTests()
        {
            var dxResultsCareLevel_I_ScoreIsDiagnosed = TestContext.GetBoolean("DxResultsCareLevel_I_ScoreIsDiagnosed");
            var dxResultsCareLevel_I_ScoreIsLikelyDiagnosed = TestContext.GetBoolean("DxResultsCareLevel_I_ScoreIsLikelyDiagnosed");
            var d1CareLevel_I_ScoreIsMet = TestContext.GetBoolean("D1CareLevel_I_ScoreIsMet");

            var isMet = TestContext.GetBoolean("IsMet");

            var dimensionalAdmissionCriteriaScoringStrategy = new DimensionalAdmissionCriteriaScoringStrategy();
            var careLevel_I_D_Score = dimensionalAdmissionCriteriaScoringStrategy.CalculateCareLevel_I_DetoxificationScore(
                dxResultsCareLevel_I_ScoreIsDiagnosed,
                dxResultsCareLevel_I_ScoreIsLikelyDiagnosed,
                d1CareLevel_I_ScoreIsMet);

            Assert.AreEqual(isMet, careLevel_I_D_Score.IsMet, "IsMet didn't match.");
        }

        [TestMethod]
        [DataSource("DAC_CareLevel_II_DetoxificationScore")]
        public void DAC_CalculateCareLevel_II_DetoxificationScoreTests()
        {
            var dxResultsCareLevel_II_ScoreIsDiagnosed = TestContext.GetBoolean("DxResultsCareLevel_II_ScoreIsDiagnosed");
            var dxResultsCareLevel_II_ScoreIsLikelyDiagnosed = TestContext.GetBoolean("DxResultsCareLevel_II_ScoreIsLikelyDiagnosed");
            var d1CareLevel_II_ScoreIsMet = TestContext.GetBoolean("D1CareLevel_II_ScoreIsMet");

            var isMet = TestContext.GetBoolean("IsMet");

            var dimensionalAdmissionCriteriaScoringStrategy = new DimensionalAdmissionCriteriaScoringStrategy();
            var careLevel_II_D_Score = dimensionalAdmissionCriteriaScoringStrategy.CalculateCareLevel_II_DetoxificationScore(
                dxResultsCareLevel_II_ScoreIsDiagnosed,
                dxResultsCareLevel_II_ScoreIsLikelyDiagnosed,
                d1CareLevel_II_ScoreIsMet);
            
            Assert.AreEqual(isMet, careLevel_II_D_Score.IsMet, "IsMet didn't match.");
        }
 
        [TestMethod]
        [DataSource("DAC_CareLevel_III_2_DetoxificationScore")]
        public void DAC_CalculateCareLevel_III_2_DetoxificationScoreTests()
        {
            var dxResultsCareLevel_III_2_ScoreIsMet = TestContext.GetBoolean("DxResultsCareLevel_III_2_ScoreIsMet");
            var d1CareLevel_III_2_ScoreIsMet = TestContext.GetBoolean("D1CareLevel_III_2_ScoreIsMet");

            var isMet = TestContext.GetBoolean("IsMet");

            var dimensionalAdmissionCriteriaScoringStrategy = new DimensionalAdmissionCriteriaScoringStrategy();
            var careLevel_III_2D_Score = dimensionalAdmissionCriteriaScoringStrategy.CalculateCareLevel_III_2_DetoxificationScore(
                dxResultsCareLevel_III_2_ScoreIsMet,
                d1CareLevel_III_2_ScoreIsMet);

            Assert.AreEqual(isMet, careLevel_III_2D_Score.IsMet, "IsMet didn't match.");
        }

        [TestMethod]
        [DataSource("DAC_CareLevel_III_7_DetoxificationScore")]
        public void DAC_CalculateCareLevel_III_7_DetoxificationScoreTests()
        {
            var dxResultsCareLevel_III_7_ScoreIsMet = TestContext.GetBoolean("DxResultsCareLevel_III_7_ScoreIsMet");
            var d1CareLevel_III_7_ScoreIsMet = TestContext.GetBoolean("D1CareLevel_III_7_ScoreIsMet");

            var isMet = TestContext.GetBoolean("IsMet");

            var dimensionalAdmissionCriteriaScoringStrategy = new DimensionalAdmissionCriteriaScoringStrategy();
            var careLevel_III_7D_Score = dimensionalAdmissionCriteriaScoringStrategy.CalculateCareLevel_III_7_DetoxificationScore(
                dxResultsCareLevel_III_7_ScoreIsMet,
                d1CareLevel_III_7_ScoreIsMet);

            Assert.AreEqual(isMet, careLevel_III_7D_Score.IsMet, "IsMet didn't match.");
        }

        [TestMethod]
        [DataSource("DAC_CareLevel_IV_DetoxificationScore")]
        public void DAC_CalculateCareLevel_IV_DetoxificationScoreTests()
        {
            var dxResultsCareLevel_IV_ScoreIsMet = TestContext.GetBoolean("DxResultsCareLevel_IV_ScoreIsMet");
            var d1CareLevel_IV_ScoreIsMet = TestContext.GetBoolean("D1CareLevel_IV_ScoreIsMet");

            var isMet = TestContext.GetBoolean("IsMet");

            var dimensionalAdmissionCriteriaScoringStrategy = new DimensionalAdmissionCriteriaScoringStrategy();
            var careLevel_IV_D_Score = dimensionalAdmissionCriteriaScoringStrategy.CalculateCareLevel_IV_DetoxificationScore(
                dxResultsCareLevel_IV_ScoreIsMet,
                d1CareLevel_IV_ScoreIsMet);

            Assert.AreEqual(isMet, careLevel_IV_D_Score.IsMet, "IsMet didn't match.");
        }

        [TestMethod]
        [DataSource("DAC_CareLevel_0_5_EarlyInterventionScore")]
        public void DAC_CalculateCareLevel_0_5_EarlyInterventionScoreTests()
        {
            var dxResultsCareLevel_0_5_ScoreIsMet = TestContext.GetBoolean("DxResultsCareLevel_0_5_ScoreIsMet");
            var d1SeverityNumber = TestContext.GetInt32("D1SeverityNumber");
            var d2CareLevel_0_5_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_0_5_ScoreIsMet");
            var d3CareLevel_0_5_ScoreIsMet = TestContext.GetBoolean("D3CareLevel_0_5_ScoreIsMet");
            var d4CareLevel_0_5_ScoreIsMet = TestContext.GetBoolean("D4CareLevel_0_5_ScoreIsMet");
            var d5CareLevel_0_5_ScoreIsMet = TestContext.GetBoolean("D5CareLevel_0_5_ScoreIsMet");
            var d6CareLevel_0_5_ScoreIsMet = TestContext.GetBoolean("D6CareLevel_0_5_ScoreIsMet");

            var isMet = TestContext.GetBoolean("IsMet");

            var dimensionalAdmissionCriteriaScoringStrategy = new DimensionalAdmissionCriteriaScoringStrategy();
            var careLevel_0_5_Score = dimensionalAdmissionCriteriaScoringStrategy.CalculateCareLevel_0_5_EarlyInterventionScore(
                dxResultsCareLevel_0_5_ScoreIsMet,
                d1SeverityNumber,
                d2CareLevel_0_5_ScoreIsMet,
                d3CareLevel_0_5_ScoreIsMet,
                d4CareLevel_0_5_ScoreIsMet,
                d5CareLevel_0_5_ScoreIsMet,
                d6CareLevel_0_5_ScoreIsMet);

            Assert.AreEqual(isMet, careLevel_0_5_Score.IsMet, "IsMet didn't match.");
        }

        [TestMethod]
        [DataSource("DAC_CareLevel_I_OutpatientScore")]
        public void DAC_CalculateCareLevel_I_OutpatientScoreTests()
        {
            var dxResultsCareLevel_I_ScoreIsMet = TestContext.GetBoolean("DxResultsCareLevel_I_ScoreIsMet");
            var d1SeverityNumber = TestContext.GetInt32("D1SeverityNumber");
            var d2CareLevel_I_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_I_ScoreIsMet");
            var d3CareLevel_I_ScoreIsMet = TestContext.GetBoolean("D3CareLevel_I_ScoreIsMet");
            var d4CareLevel_I_ScoreIsMet = TestContext.GetBoolean("D4CareLevel_I_ScoreIsMet");
            var d5CareLevel_I_ScoreIsMet = TestContext.GetBoolean("D5CareLevel_I_ScoreIsMet");
            var d6CareLevel_I_ScoreIsMet = TestContext.GetBoolean("D6CareLevel_I_ScoreIsMet");
            var dxResultsCareLevel_I_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("DxResultsCareLevel_I_ScoreIsDualDiagnosisEnhanced");
            var d3CareLevel_I_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D3CareLevel_I_ScoreIsDualDiagnosisEnhanced");
            var d5CareLevel_I_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D5CareLevel_I_ScoreIsDualDiagnosisEnhanced");
            var d6CareLevel_I_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D6CareLevel_I_ScoreIsDualDiagnosisEnhanced");

            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            var dimensionalAdmissionCriteriaScoringStrategy = new DimensionalAdmissionCriteriaScoringStrategy();
            var careLevel_I_Score = dimensionalAdmissionCriteriaScoringStrategy.CalculateCareLevel_I_OutpatientScore(
                dxResultsCareLevel_I_ScoreIsMet,
                d1SeverityNumber,
                d2CareLevel_I_ScoreIsMet,
                d3CareLevel_I_ScoreIsMet,
                d4CareLevel_I_ScoreIsMet,
                d5CareLevel_I_ScoreIsMet,
                d6CareLevel_I_ScoreIsMet,
                dxResultsCareLevel_I_ScoreIsDualDiagnosisEnhanced,
                d3CareLevel_I_ScoreIsDualDiagnosisEnhanced,
                d5CareLevel_I_ScoreIsDualDiagnosisEnhanced,
                d6CareLevel_I_ScoreIsDualDiagnosisEnhanced);

            Assert.AreEqual(isMet, careLevel_I_Score.IsMet, "IsMet didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_I_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
        }

        [TestMethod]
        [DataSource("DAC_CareLevelOpioidMaintenanceTherapyScore")]
        public void DAC_CalculateCareLevelOpioidMaintenanceTherapyScoreTests()
        {
            var dxResultsCareLevel_OMT_ScoreIsMet = TestContext.GetBoolean("DxResultsCareLevel_OMT_ScoreIsMet");
            var d1CareLevel_OMT_ScoreIsMet = TestContext.GetBoolean("D1CareLevel_OMT_ScoreIsMet");
            var d2CareLevel_OMT_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_OMT_ScoreIsMet");
            var d3CareLevel_OMT_ScoreIsMet = TestContext.GetBoolean("D3CareLevel_OMT_ScoreIsMet");
            var d4CareLevel_OMT_ScoreIsMet = TestContext.GetBoolean("D4CareLevel_OMT_ScoreIsMet");
            var d5CareLevel_OMT_ScoreIsMet = TestContext.GetBoolean("D5CareLevel_OMT_ScoreIsMet");
            var d6CareLevel_OMT_ScoreIsMet = TestContext.GetBoolean("D6CareLevel_OMT_ScoreIsMet");

            var isMet = TestContext.GetBoolean("IsMet");

            var dimensionalAdmissionCriteriaScoringStrategy = new DimensionalAdmissionCriteriaScoringStrategy();
            var careLevel_OMT_Score = dimensionalAdmissionCriteriaScoringStrategy.CalculateCareLevelOpioidMaintenanceTherapyScore(
                dxResultsCareLevel_OMT_ScoreIsMet,
                d1CareLevel_OMT_ScoreIsMet,
                d2CareLevel_OMT_ScoreIsMet,
                d3CareLevel_OMT_ScoreIsMet,
                d4CareLevel_OMT_ScoreIsMet,
                d5CareLevel_OMT_ScoreIsMet,
                d6CareLevel_OMT_ScoreIsMet);

            Assert.AreEqual(isMet, careLevel_OMT_Score.IsMet, "IsMet didn't match.");
        }

        [TestMethod]
        [DataSource("DAC_CareLevel_II_1_IntensiveOutpatientScore")]
        public void DAC_CalculateCareLevel_II_1_IntensiveOutpatientScoreTests()
        {
            var dxResultsCareLevel_II_1_ScoreIsMet = TestContext.GetBoolean("DxResultsCareLevel_II_1_ScoreIsMet");
            var d1SeverityNumber = TestContext.GetInt32("D1SeverityNumber");
            var d2CareLevel_II_1_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_II_1_ScoreIsMet");
            var d3SeverityNumber = TestContext.GetInt32("D3SeverityNumber");
            var d4CareLevel_II_1_ScoreIsMet = TestContext.GetBoolean("D4CareLevel_II_1_ScoreIsMet");
            var d5CareLevel_II_1_ScoreIsMet = TestContext.GetBoolean("D5CareLevel_II_1_ScoreIsMet");
            var d6CareLevel_II_1_ScoreIsMet = TestContext.GetBoolean("D6CareLevel_II_1_ScoreIsMet");
            var d3CareLevel_II_1_ScoreIsDualDiagnosisCapable = TestContext.GetBoolean("D3CareLevel_II_1_ScoreIsDualDiagnosisCapable");
            var d4CareLevel_II_1_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D4CareLevel_II_1_ScoreIsDualDiagnosisEnhanced");
            var d5CareLevel_II_1_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D5CareLevel_II_1_ScoreIsDualDiagnosisEnhanced");
            var d6CareLevel_II_1_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D6CareLevel_II_1_ScoreIsDualDiagnosisEnhanced");
            var dxResultsCareLevel_II_1_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("DxResultsCareLevel_II_1_ScoreIsDualDiagnosisEnhanced");
            var d3CareLevel_II_1_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D3CareLevel_II_1_ScoreIsDualDiagnosisEnhanced");

            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisCapable = TestContext.GetBoolean("IsDualDiagnosisCapable");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            var dimensionalAdmissionCriteriaScoringStrategy = new DimensionalAdmissionCriteriaScoringStrategy();
            var careLevel_II_1_Score = dimensionalAdmissionCriteriaScoringStrategy.CalculateCareLevel_II_1_IntensiveOutpatientScore(
                dxResultsCareLevel_II_1_ScoreIsMet,
                d1SeverityNumber,
                d2CareLevel_II_1_ScoreIsMet,
                d3SeverityNumber,
                d4CareLevel_II_1_ScoreIsMet,
                d5CareLevel_II_1_ScoreIsMet,
                d6CareLevel_II_1_ScoreIsMet,
                d3CareLevel_II_1_ScoreIsDualDiagnosisCapable,
                d4CareLevel_II_1_ScoreIsDualDiagnosisEnhanced,
                d5CareLevel_II_1_ScoreIsDualDiagnosisEnhanced,
                d6CareLevel_II_1_ScoreIsDualDiagnosisEnhanced,
                dxResultsCareLevel_II_1_ScoreIsDualDiagnosisEnhanced,
                d3CareLevel_II_1_ScoreIsDualDiagnosisEnhanced);

            Assert.AreEqual(isMet, careLevel_II_1_Score.IsMet, "IsMet didn't match.");
            Assert.AreEqual(isDualDiagnosisCapable, careLevel_II_1_Score.IsDualDiagnosisCapable, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_II_1_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
        }

        [TestMethod]
        [DataSource("DAC_CareLevel_II_5_PartialHospitalizationScore")]
        public void DAC_CalculateCareLevel_II_5_PartialHospitalizationScoreTests()
        {
            var dxResultsCareLevel_II_5_ScoreIsMet = TestContext.GetBoolean("DxResultsCareLevel_II_5_ScoreIsMet");
            var d1SeverityNumber = TestContext.GetInt32("D1SeverityNumber");
            var d2CareLevel_II_5_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_II_5_ScoreIsMet");
            var d3SeverityNumber = TestContext.GetInt32("D3SeverityNumber");
            var d4CareLevel_II_5_ScoreIsMet = TestContext.GetBoolean("D4CareLevel_II_5_ScoreIsMet");
            var d5CareLevel_II_5_ScoreIsMet = TestContext.GetBoolean("D5CareLevel_II_5_ScoreIsMet");
            var d6CareLevel_II_5_ScoreIsMet = TestContext.GetBoolean("D6CareLevel_II_5_ScoreIsMet");
            var d3CareLevel_II_5_ScoreIsDualDiagnosisCapable = TestContext.GetBoolean("D3CareLevel_II_5_ScoreIsDualDiagnosisCapable");
            var dxResultsCareLevel_II_5_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("DxResultsCareLevel_II_5_ScoreIsDualDiagnosisEnhanced");
            var d3CareLevel_II_5_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D3CareLevel_II_5_ScoreIsDualDiagnosisEnhanced");
            var d4careLevel_II_5_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D4careLevel_II_5_ScoreIsDualDiagnosisEnhanced");
            var d5CareLevel_II_5_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D5CareLevel_II_5_ScoreIsDualDiagnosisEnhanced");
            var d6careLevel_II_5_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D6careLevel_II_5_ScoreIsDualDiagnosisEnhanced");
            var d3CareLevel_II_5_ScoreIsDualDiagnosisEnhanced_III_1 = TestContext.GetBoolean("D3CareLevel_II_5_ScoreIsDualDiagnosisEnhanced_III_1");
            var d3CareLevel_II_5_ScoreIsDualDiagnosisCapable_III_1 = TestContext.GetBoolean("D3CareLevel_II_5_ScoreIsDualDiagnosisCapable_III_1");
            
            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisCapable = TestContext.GetBoolean("IsDualDiagnosisCapable");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");
            var isDualDiagnosisEnhancedAndLevel_III_1 = TestContext.GetBoolean("IsDualDiagnosisEnhancedAndLevel_III_1");
            var isDualDiagnosisCapableAndLevel_III_1 = TestContext.GetBoolean("IsDualDiagnosisCapableAndLevel_III_1");

            var dimensionalAdmissionCriteriaScoringStrategy = new DimensionalAdmissionCriteriaScoringStrategy();
            var careLevel_II_5_Score = dimensionalAdmissionCriteriaScoringStrategy.CalculateCareLevel_II_5_PartialHospitalizationScore(
                dxResultsCareLevel_II_5_ScoreIsMet,
                d1SeverityNumber,
                d2CareLevel_II_5_ScoreIsMet,
                d3SeverityNumber,
                d4CareLevel_II_5_ScoreIsMet,
                d5CareLevel_II_5_ScoreIsMet,
                d6CareLevel_II_5_ScoreIsMet,
                d3CareLevel_II_5_ScoreIsDualDiagnosisCapable,
                dxResultsCareLevel_II_5_ScoreIsDualDiagnosisEnhanced,
                d3CareLevel_II_5_ScoreIsDualDiagnosisEnhanced,
                d4careLevel_II_5_ScoreIsDualDiagnosisEnhanced,
                d5CareLevel_II_5_ScoreIsDualDiagnosisEnhanced,
                d6careLevel_II_5_ScoreIsDualDiagnosisEnhanced,
                d3CareLevel_II_5_ScoreIsDualDiagnosisEnhanced_III_1,
                d3CareLevel_II_5_ScoreIsDualDiagnosisCapable_III_1);

            Assert.AreEqual(isMet, careLevel_II_5_Score.IsMet, "IsMet didn't match.");
            Assert.AreEqual(isDualDiagnosisCapable, careLevel_II_5_Score.IsDualDiagnosisCapable, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_II_5_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhancedAndLevel_III_1, careLevel_II_5_Score.IsDualDiagnosisEnhancedAndLevel_III_1, "IsDualDiagnosisEnhancedAndLevel_III_1 didn't match.");
            Assert.AreEqual(isDualDiagnosisCapableAndLevel_III_1, careLevel_II_5_Score.IsDualDiagnosisCapableAndLevel_III_1, "IsDualDiagnosisCapableAndLevel_III_1 didn't match.");
        }

        [TestMethod]
        [DataSource("DAC_CareLevel_III_1_ClinicallyManagedScore")]
        public void DAC_CalculateCareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScoreTests()
        {
            var dxResultsCareLevel_III_1_ScoreIsMet = TestContext.GetBoolean("DxResultsCareLevel_III_1_ScoreIsMet");
            var d1SeverityNumber = TestContext.GetInt32("D1SeverityNumber");
            var d2CareLevel_III_1_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_III_1_ScoreIsMet");
            var d3CareLevel_I_ScoreIsMet = TestContext.GetBoolean("D3CareLevel_I_ScoreIsMet");
            var d4CareLevel_III_1_ScoreIsMet = TestContext.GetBoolean("D4CareLevel_III_1_ScoreIsMet");
            var d5CareLevel_III_1_ScoreIsMet = TestContext.GetBoolean("D5CareLevel_III_1_ScoreIsMet");
            var d6CareLevel_III_1_ScoreIsMet = TestContext.GetBoolean("D6CareLevel_III_1_ScoreIsMet");
            var d3CareLevel_III_1_ScoreIsDualDiagnosisCapable = TestContext.GetBoolean("D3CareLevel_III_1_ScoreIsDualDiagnosisCapable");
            var d3CareLevel_III_3_ScoreIsDualDiagnosisCapable = TestContext.GetBoolean("D3CareLevel_III_3_ScoreIsDualDiagnosisCapable");
            var d3CareLevel_III_5_ScoreIsDualDiagnosisCapable = TestContext.GetBoolean("D3CareLevel_III_5_ScoreIsDualDiagnosisCapable");
            var d3CareLevel_III_7_ScoreIsDualDiagnosisCapable = TestContext.GetBoolean("D3CareLevel_III_7_ScoreIsDualDiagnosisCapable");
            var d3CareLevel_III_1_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D3CareLevel_III_1_ScoreIsDualDiagnosisEnhanced");
            var d3CareLevel_III_3_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D3CareLevel_III_3_ScoreIsDualDiagnosisEnhanced");
            var d3CareLevel_III_5_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D3CareLevel_III_5_ScoreIsDualDiagnosisEnhanced");
            var d3CareLevel_III_7_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D3CareLevel_III_7_ScoreIsDualDiagnosisEnhanced");
            var d2CareLevel_III_1_ScoreIsMetDim2Level3LowIntensity = TestContext.GetBoolean("D2CareLevel_III_1_ScoreIsMetDim2Level3LowIntensity");
            var d5CareLevel_III_1_ScoreIsMetDimFivePartialHospitalization = TestContext.GetBoolean("D5CareLevel_III_1_ScoreIsMetDimFivePartialHospitalization");

            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisCapable = TestContext.GetBoolean("IsDualDiagnosisCapable");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");
            var clinicallyManagedLowIntensityResidentialTreatmentBiomedical = TestContext.GetBoolean("ClinicallyManagedLowIntensityResidentialTreatmentBiomedical");
            var clinicallyManagedLowIntensityResidentialTreatmentAndLevel_II_5 = TestContext.GetBoolean("ClinicallyManagedLowIntensityResidentialTreatmentAndLevel_II_5");
            
            if(TestContext.GetBoolean ( "ForDebug" ))
            {
                
            }

            var dimensionalAdmissionCriteriaScoringStrategy = new DimensionalAdmissionCriteriaScoringStrategy();
            var careLevel_III_1_Score = dimensionalAdmissionCriteriaScoringStrategy.CalculateCareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore(
                dxResultsCareLevel_III_1_ScoreIsMet,
                d1SeverityNumber,
                d2CareLevel_III_1_ScoreIsMet,
                d3CareLevel_I_ScoreIsMet,
                d4CareLevel_III_1_ScoreIsMet,
                d5CareLevel_III_1_ScoreIsMet,
                d6CareLevel_III_1_ScoreIsMet,
                d3CareLevel_III_1_ScoreIsDualDiagnosisCapable,
                d3CareLevel_III_3_ScoreIsDualDiagnosisCapable,
                d3CareLevel_III_5_ScoreIsDualDiagnosisCapable,
                d3CareLevel_III_7_ScoreIsDualDiagnosisCapable,
                d3CareLevel_III_1_ScoreIsDualDiagnosisEnhanced,
                d3CareLevel_III_3_ScoreIsDualDiagnosisEnhanced,
                d3CareLevel_III_5_ScoreIsDualDiagnosisEnhanced,
                d3CareLevel_III_7_ScoreIsDualDiagnosisEnhanced,
                d2CareLevel_III_1_ScoreIsMetDim2Level3LowIntensity,
                d5CareLevel_III_1_ScoreIsMetDimFivePartialHospitalization);
                
            Assert.AreEqual(isMet, careLevel_III_1_Score.IsMet, "IsMet didn't match.");
            Assert.AreEqual(isDualDiagnosisCapable, careLevel_III_1_Score.IsDualDiagnosisCapable, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_III_1_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(clinicallyManagedLowIntensityResidentialTreatmentBiomedical, careLevel_III_1_Score.ClinicallyManagedLowIntensityResidentialTreatmentBiomedical, "ClinicallyManagedLowIntensityResidentialTreatmentBiomedical didn't match.");
            Assert.AreEqual(clinicallyManagedLowIntensityResidentialTreatmentAndLevel_II_5, careLevel_III_1_Score.ClinicallyManagedLowIntensityResidentialTreatmentAndLevel_II_5, "ClinicallyManagedLowIntensityResidentialTreatmentAndLevel_II_5 didn't match");
        }

        [TestMethod]
        [DataSource("DAC_CareLevel_III_3_ClinicallyManagedMediumIntensityScore")]
        public void DAC_CalculateCareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScoreTests()
        {
            var dxResultsCareLevel_III_3_ScoreIsMet = TestContext.GetBoolean("DxResultsCareLevel_III_3_ScoreIsMet");
            var d1SeverityNumber = TestContext.GetInt32("D1SeverityNumber");
            var d2CareLevel_III_3_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_III_3_ScoreIsMet");
            var d3CareLevel_I_ScoreIsMet = TestContext.GetBoolean("D3CareLevel_I_ScoreIsMet");
            var d4CareLevel_III_3_ScoreIsMet = TestContext.GetBoolean("D4CareLevel_III_3_ScoreIsMet");
            var d5CareLevel_III_3_ScoreIsMet = TestContext.GetBoolean("D5CareLevel_III_3_ScoreIsMet");
            var d6CareLevel_III_3_ScoreIsMet = TestContext.GetBoolean("D6CareLevel_III_3_ScoreIsMet");
            var dxResultsCareLevel_III_3_ScoreIsDualDiagnosisCapable = TestContext.GetBoolean("DxResultsCareLevel_III_3_ScoreIsDualDiagnosisCapable");
            var d3CareLevel_III_3_ScoreIsDualDiagnosisCapable = TestContext.GetBoolean("D3CareLevel_III_3_ScoreIsDualDiagnosisCapable");
            var dxResultsCareLevel_III_3_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("DxResultsCareLevel_III_3_ScoreIsDualDiagnosisEnhanced");
            var d3CareLevel_III_3_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D3CareLevel_III_3_ScoreIsDualDiagnosisEnhanced");
            var d4CareLevel_III_1_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D4CareLevel_III_1_ScoreIsDualDiagnosisEnhanced");
            var d5CareLevel_III_3_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D5CareLevel_III_3_ScoreIsDualDiagnosisEnhanced");
            var d6CareLevel_III_3_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D6CareLevel_III_3_ScoreIsDualDiagnosisEnhanced");
            var d2CareLevel_III_3_ScoreIsMetDim2Level3ModerateIntensity = TestContext.GetBoolean("D2CareLevel_III_3_ScoreIsMetDim2Level3ModerateIntensity");

            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisCapable = TestContext.GetBoolean("IsDualDiagnosisCapable");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");
            var clinicallyManagedLowIntensityResidentialTreatmentBiomedical = TestContext.GetBoolean("ClinicallyManagedMediumIntensityResidentialTreatmentBiomedical");

            var dimensionalAdmissionCriteriaScoringStrategy = new DimensionalAdmissionCriteriaScoringStrategy();
            var careLevel_III_3_Score = dimensionalAdmissionCriteriaScoringStrategy.CalculateCareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScore(
                dxResultsCareLevel_III_3_ScoreIsMet,
                d1SeverityNumber,
                d2CareLevel_III_3_ScoreIsMet,
                d3CareLevel_I_ScoreIsMet,
                d4CareLevel_III_3_ScoreIsMet,
                d5CareLevel_III_3_ScoreIsMet,
                d6CareLevel_III_3_ScoreIsMet,
                dxResultsCareLevel_III_3_ScoreIsDualDiagnosisCapable,
                d3CareLevel_III_3_ScoreIsDualDiagnosisCapable,
                dxResultsCareLevel_III_3_ScoreIsDualDiagnosisEnhanced,
                d3CareLevel_III_3_ScoreIsDualDiagnosisEnhanced,
                d4CareLevel_III_1_ScoreIsDualDiagnosisEnhanced,
                d5CareLevel_III_3_ScoreIsDualDiagnosisEnhanced,
                d6CareLevel_III_3_ScoreIsDualDiagnosisEnhanced,
                d2CareLevel_III_3_ScoreIsMetDim2Level3ModerateIntensity);

            Assert.AreEqual(isMet, careLevel_III_3_Score.IsMet, "IsMet didn't match.");
            Assert.AreEqual(isDualDiagnosisCapable, careLevel_III_3_Score.IsDualDiagnosisCapable, "IsDualDiagnosisCapable didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_III_3_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(clinicallyManagedLowIntensityResidentialTreatmentBiomedical, careLevel_III_3_Score.ClinicallyManagedMediumIntensityResidentialTreatmentBiomedical, "ClinicallyManagedLowIntensityResidentialTreatmentBiomedical didn't match.");
        }

        [TestMethod]
        [DataSource("DAC_CareLevel_III_5_ClinicallyManagedHighIntensityScore")]
        public void DAC_CalculateCareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScoreTests()
        {
            var dxResultsCareLevel_III_5_ScoreIsMet = TestContext.GetBoolean("DxResultsCareLevel_III_5_ScoreIsMet");
            var d1SeverityNumber = TestContext.GetInt32("D1SeverityNumber");
            var d2CareLevel_III_5_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_III_5_ScoreIsMet");
            var d3CareLevel_I_ScoreIsMet = TestContext.GetBoolean("D3CareLevel_I_ScoreIsMet");
            var d4CareLevel_III_5_ScoreIsMet = TestContext.GetBoolean("D4CareLevel_III_5_ScoreIsMet");
            var d5CareLevel_III_5_ScoreIsMet = TestContext.GetBoolean("D5CareLevel_III_5_ScoreIsMet");
            var d6CareLevel_III_5_ScoreIsMet = TestContext.GetBoolean("D6CareLevel_III_5_ScoreIsMet");
            var dxResultsCareLevel_III_5_ScoreIsDualDiagnosisCapable = TestContext.GetBoolean("DxResultsCareLevel_III_5_ScoreIsDualDiagnosisCapable");
            var d3CareLevel_III_5_ScoreIsDualDiagnosisCapable = TestContext.GetBoolean("D3CareLevel_III_5_ScoreIsDualDiagnosisCapable");
            var dxResultsCareLevel_III_5_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("DxResultsCareLevel_III_5_ScoreIsDualDiagnosisEnhanced");
            var d3CareLevel_III_5_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D3CareLevel_III_5_ScoreIsDualDiagnosisEnhanced");
            var d4CareLevel_III_5_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D4CareLevel_III_5_ScoreIsDualDiagnosisEnhanced");
            var d5CareLevel_III_5_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D5CareLevel_III_5_ScoreIsDualDiagnosisEnhanced");
            var d6CareLevel_III_5_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D6CareLevel_III_5_ScoreIsDualDiagnosisEnhanced");
            var d2CareLevel_III_5_ScoreIsMetDim2Level3HighIntensity = TestContext.GetBoolean("D2CareLevel_III_5_ScoreIsMetDim2Level3HighIntensity");

            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisCapable = TestContext.GetBoolean("IsDualDiagnosisCapable");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");
            var clinicallyManagedLowIntensityResidentialTreatmentBiomedical = TestContext.GetBoolean("ClinicallyManagedHighIntensityResidentialTreatmentBiomedical");

            var dimensionalAdmissionCriteriaScoringStrategy = new DimensionalAdmissionCriteriaScoringStrategy();
            var careLevel_III_5_Score = dimensionalAdmissionCriteriaScoringStrategy.CalculateCareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScore(
                dxResultsCareLevel_III_5_ScoreIsMet,
                d1SeverityNumber,
                d2CareLevel_III_5_ScoreIsMet,
                d3CareLevel_I_ScoreIsMet,
                d4CareLevel_III_5_ScoreIsMet,
                d5CareLevel_III_5_ScoreIsMet,
                d6CareLevel_III_5_ScoreIsMet,
                dxResultsCareLevel_III_5_ScoreIsDualDiagnosisCapable,
                d3CareLevel_III_5_ScoreIsDualDiagnosisCapable,
                dxResultsCareLevel_III_5_ScoreIsDualDiagnosisEnhanced,
                d3CareLevel_III_5_ScoreIsDualDiagnosisEnhanced, 
                d4CareLevel_III_5_ScoreIsDualDiagnosisEnhanced,
                d5CareLevel_III_5_ScoreIsDualDiagnosisEnhanced,
                d6CareLevel_III_5_ScoreIsDualDiagnosisEnhanced, 
                d2CareLevel_III_5_ScoreIsMetDim2Level3HighIntensity);

            Assert.AreEqual(isMet, careLevel_III_5_Score.IsMet, "IsMet didn't match.");
            Assert.AreEqual(isDualDiagnosisCapable, careLevel_III_5_Score.IsDualDiagnosisCapable, "IsDualDiagnosisCapable didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_III_5_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(clinicallyManagedLowIntensityResidentialTreatmentBiomedical, careLevel_III_5_Score.ClinicallyManagedHighIntensityResidentialTreatmentBiomedical, "ClinicallyManagedHighIntensityResidentialTreatmentBiomedical didn't match.");
        }

        [TestMethod]
        [DataSource("DAC_CareLevel_III_7_MedicallyMonitoredIntensiveScore")]
        public void DAC_CalculateCareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScoreTests()
        {
            var dxResultsCareLevel_III_7_ScoreIsMet = TestContext.GetBoolean("DxResultsCareLevel_III_7_ScoreIsMet");
            var d1CareLevel_III_7_ScoreIsMet = TestContext.GetBoolean("D1CareLevel_III_7_ScoreIsMet");
            var d2CareLevel_III_7_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_III_7_ScoreIsMet");
            var d3CareLevel_I_ScoreIsMet = TestContext.GetBoolean("D3CareLevel_I_ScoreIsMet");
            var d4CareLevel_III_7_ScoreIsMet = TestContext.GetBoolean("D4CareLevel_III_7_ScoreIsMet");
            var d5CareLevel_III_7_ScoreIsMet = TestContext.GetBoolean("D5CareLevel_III_7_ScoreIsMet");
            var d6CareLevel_III_7_ScoreIsMet = TestContext.GetBoolean("D6CareLevel_III_7_ScoreIsMet");
            var dxResultsCareLevel_III_7_ScoreIsDualDiagnosisCapable = TestContext.GetBoolean("DxResultsCareLevel_III_7_ScoreIsDualDiagnosisCapable");
            var d3CareLevel_III_7_ScoreIsDualDiagnosisCapable = TestContext.GetBoolean("D3CareLevel_III_7_ScoreIsDualDiagnosisCapable");
            var dxResultsCareLevel_III_7_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("DxResultsCareLevel_III_7_ScoreIsDualDiagnosisEnhanced");
            var d3CareLevel_III_7_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D3CareLevel_III_7_ScoreIsDualDiagnosisEnhanced");
            var d4CareLevel_III_7_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D4CareLevel_III_7_ScoreIsDualDiagnosisEnhanced");
            var d5CareLevel_III_7_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D5CareLevel_III_7_ScoreIsDualDiagnosisEnhanced");
            var d6CareLevel_III_7_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D6CareLevel_III_7_ScoreIsDualDiagnosisEnhanced");
            var d2CareLevel_III_7_ScoreIsMetDim2Level3MedicalMonitoring = TestContext.GetBoolean("D2CareLevel_III_7_ScoreIsMetDim2Level3MedicalMonitoring");

            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisCapable = TestContext.GetBoolean("IsDualDiagnosisCapable");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");
            var clinicallyManagedLowIntensityResidentialTreatmentBiomedical = TestContext.GetBoolean("MedicallyMonitoredIntensiveInpatientTreatmentBiomedical");

            var dimensionalAdmissionCriteriaScoringStrategy = new DimensionalAdmissionCriteriaScoringStrategy();
            var careLevel_III_7_Score = dimensionalAdmissionCriteriaScoringStrategy.CalculateCareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScore(
                dxResultsCareLevel_III_7_ScoreIsMet,
                d1CareLevel_III_7_ScoreIsMet,
                d2CareLevel_III_7_ScoreIsMet,
                d3CareLevel_I_ScoreIsMet,
                d4CareLevel_III_7_ScoreIsMet,
                d5CareLevel_III_7_ScoreIsMet,
                d6CareLevel_III_7_ScoreIsMet,
                dxResultsCareLevel_III_7_ScoreIsDualDiagnosisCapable,
                d3CareLevel_III_7_ScoreIsDualDiagnosisCapable,
                dxResultsCareLevel_III_7_ScoreIsDualDiagnosisEnhanced,
                d3CareLevel_III_7_ScoreIsDualDiagnosisEnhanced,
                d4CareLevel_III_7_ScoreIsDualDiagnosisEnhanced,
                d5CareLevel_III_7_ScoreIsDualDiagnosisEnhanced,
                d6CareLevel_III_7_ScoreIsDualDiagnosisEnhanced,
                d2CareLevel_III_7_ScoreIsMetDim2Level3MedicalMonitoring);

            Assert.AreEqual(isMet, careLevel_III_7_Score.IsMet, "IsMet didn't match.");
            Assert.AreEqual(isDualDiagnosisCapable, careLevel_III_7_Score.IsDualDiagnosisCapable, "IsDualDiagnosisCapable didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_III_7_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");
            Assert.AreEqual(clinicallyManagedLowIntensityResidentialTreatmentBiomedical, careLevel_III_7_Score.MedicallyMonitoredIntensiveInpatientTreatmentBiomedical, "MedicallyMonitoredIntensiveInpatientTreatmentBiomedical didn't match.");
        }

        [TestMethod]
        [DataSource("DAC_CareLevel_IV_MedicallyManagedIntensiveInpatient")]
        public void DAC_CalculateCareLevel_IV_MedicallyManagedIntensiveInpatientServicesScoreTests()
        {
            var dxResultsCareLevel_IV_ScoreIsMet = TestContext.GetBoolean("DxResultsCareLevel_IV_ScoreIsMet");
            var d1CareLevel_IV_ScoreIsMet = TestContext.GetBoolean("D1CareLevel_IV_ScoreIsMet");
            var d2CareLevel_IV_ScoreIsMet = TestContext.GetBoolean("D2CareLevel_IV_ScoreIsMet");
            var dxResultsCareLevel_IV_ScoreIsDualDiagnosisCapable = TestContext.GetBoolean("DxResultsCareLevel_IV_ScoreIsDualDiagnosisCapable");
            var dxResultsCareLevel_IV_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("DxResultsCareLevel_IV_ScoreIsDualDiagnosisEnhanced");
            var d3CareLevel_IV_ScoreIsDualDiagnosisEnhanced = TestContext.GetBoolean("D3CareLevel_IV_ScoreIsDualDiagnosisEnhanced");

            var isMet = TestContext.GetBoolean("IsMet");
            var isDualDiagnosisCapable = TestContext.GetBoolean("IsDualDiagnosisCapable");
            var isDualDiagnosisEnhanced = TestContext.GetBoolean("IsDualDiagnosisEnhanced");

            var dimensionalAdmissionCriteriaScoringStrategy = new DimensionalAdmissionCriteriaScoringStrategy();
            var careLevel_IV_Score = dimensionalAdmissionCriteriaScoringStrategy.CalculateCareLevel_IV_MedicallyManagedIntensiveInpatientServicesScore(
                dxResultsCareLevel_IV_ScoreIsMet,
                d1CareLevel_IV_ScoreIsMet,
                d2CareLevel_IV_ScoreIsMet,
                dxResultsCareLevel_IV_ScoreIsDualDiagnosisCapable,
                dxResultsCareLevel_IV_ScoreIsDualDiagnosisEnhanced,
                d3CareLevel_IV_ScoreIsDualDiagnosisEnhanced);

            Assert.AreEqual(isMet, careLevel_IV_Score.IsMet, "IsMet didn't match.");
            Assert.AreEqual(isDualDiagnosisCapable, careLevel_IV_Score.IsDualDiagnosisCapable, "IsDualDiagnosisCapable didn't match.");
            Assert.AreEqual(isDualDiagnosisEnhanced, careLevel_IV_Score.IsDualDiagnosisEnhanced, "IsDualDiagnosisEnhanced didn't match.");         
        }
    }
}
