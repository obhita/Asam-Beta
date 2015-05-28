CREATE TABLE [ScoringModule].[DimensionalAdmissionCriteriaResults] (
    [DimensionalAdmissionCriteriaResultsKey]                                          BIGINT NOT NULL,
    [Version]                                                                         INT    NOT NULL,
    [CareLevel_I_DetoxificationScoreIsMet]                                            BIT    NULL,
    [CareLevel_II_DetoxificationScoreIsMet]                                           BIT    NULL,
    [CareLevel_III_2_DetoxificationScoreIsMet]                                        BIT    NULL,
    [CareLevel_III_7_DetoxificationScoreIsMet]                                        BIT    NULL,
    [CareLevel_IV_DetoxificationScoreIsMet]                                           BIT    NULL,
    [CareLevel_0_5_EarlyInterventionScoreIsMet]                                       BIT    NULL,
    [CareLevel_I_OutpatientScoreIsDualDiagnosisEnhanced]                              BIT    NULL,
    [CareLevel_I_OutpatientScoreIsMet]                                                BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreIsMet]                                     BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreIsDualDiagnosisEnhanced]                  BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreIsDualDiagnosisCapable]                   BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreIsMet]                                    BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreIsDualDiagnosisEnhanced]               BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreIsDualDiagnosisCapable]                BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreIsDualDiagnosisCapableAndLevel_III_1]  BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreIsDualDiagnosisEnhancedAndLevel_III_1] BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreIsMet]                                 BIT    NULL,
    [CareLevel_III_1_IsDualDiagnosisEnhanced]                                         BIT    NULL,
    [CareLevel_III_1_IsDualDiagnosisCapable]                                          BIT    NULL,
    [CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentBiomedical]     BIT    NULL,
    [CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentAndLevel_II_5]  BIT    NULL,
    [CareLevel_III_1_IsMet]                                                           BIT    NULL,
    [CareLevel_III_3_IsDualDiagnosisEnhanced]                                         BIT    NULL,
    [CareLevel_III_3_IsDualDiagnosisCapable]                                          BIT    NULL,
    [CareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentBiomedical]  BIT    NULL,
    [CareLevel_III_3_IsMet]                                                           BIT    NULL,
    [CareLevel_III_5_IsDualDiagnosisEnhanced]                                         BIT    NULL,
    [CareLevel_III_5_IsDualDiagnosisCapable]                                          BIT    NULL,
    [CareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentBiomedical]    BIT    NULL,
    [CareLevel_III_5_IsMet]                                                           BIT    NULL,
    [CareLevel_III_7_IsDualDiagnosisEnhanced]                                         BIT    NULL,
    [CareLevel_III_7_IsDualDiagnosisCapable]                                          BIT    NULL,
    [CareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentBiomedical]         BIT    NULL,
    [CareLevel_III_7_IsMet]                                                           BIT    NULL,
    [CareLevel_IV_IsDualDiagnosisEnhanced]                                            BIT    NULL,
    [CareLevel_IV_IsDualDiagnosisCapable]                                             BIT    NULL,
    [CareLevel_IV_IsMet]                                                              BIT    NULL,
    PRIMARY KEY CLUSTERED ([DimensionalAdmissionCriteriaResultsKey] ASC)
);






GO


