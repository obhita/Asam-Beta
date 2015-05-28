CREATE TABLE [ScoringModule].[DiagnosisResults] (
    [DiagnosisResultsKey]                                                                              BIGINT NOT NULL,
    [Version]                                                                                          INT    NOT NULL,
    [CommonScoresKey]                                                                                  BIGINT NULL,
    [DiagnosticStatisticalManualOfMentalDisorders_IV_ScoresKey]                                        BIGINT NULL,
    [DiagnosticStatisticalManualOfMentalDisorders_V_ScoresKey]                                         BIGINT NULL,
    [CareLevel_I_DetoxificationScoreIsLikelyDiagnosed]                                                 BIT    NULL,
    [CareLevel_I_DetoxificationScoreIsDiagnosed]                                                       BIT    NULL,
    [CareLevel_I_DetoxificationScoreIsMet]                                                             BIT    NULL,
    [CareLevel_II_DetoxificationScoreIsLikelyDiagnosed]                                                BIT    NULL,
    [CareLevel_II_DetoxificationScoreIsDiagnosed]                                                      BIT    NULL,
    [CareLevel_II_DetoxificationScoreIsMet]                                                            BIT    NULL,
    [CareLevel_III_2_DetoxificationScoreIsDiagnosed]                                                   BIT    NULL,
    [CareLevel_III_2_DetoxificationScoreIsMet]                                                         BIT    NULL,
    [CareLevel_III_7_DetoxificationScoreIsDiagnosed]                                                   BIT    NULL,
    [CareLevel_III_7_DetoxificationScoreIsMet]                                                         BIT    NULL,
    [CareLevel_IV_DetoxificationScoreIsDiagnosed]                                                      BIT    NULL,
    [CareLevel_IV_DetoxificationScoreIsMet]                                                            BIT    NULL,
    [CareLevel_0_5_EarlyInterventionScoreIsDiagnosed]                                                  BIT    NULL,
    [CareLevel_0_5_EarlyInterventionScoreIsMet]                                                        BIT    NULL,
    [CareLevel_I_OutpatientScoreIsLikelyDiagnosed]                                                     BIT    NULL,
    [CareLevel_I_OutpatientScoreIsDualDiagnosisCapable]                                                BIT    NULL,
    [CareLevel_I_OutpatientScoreIsDualDiagnosisEnhanced]                                               BIT    NULL,
    [CareLevel_I_OutpatientScoreIsDiagnosed]                                                           BIT    NULL,
    [CareLevel_I_OutpatientScoreIsMet]                                                                 BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreIsLikelyDiagnosed]                                          BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreIsDualDiagnosisCapable]                                     BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreIsDualDiagnosisEnhanced]                                    BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreIsDiagnosed]                                                BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreIsMet]                                                      BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreIsLikelyDiagnosed]                                         BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreIsDualDiagnosisCapable]                                    BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreIsDualDiagnosisEnhanced]                                   BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreIsDiagnosed]                                               BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreIsMet]                                                     BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreIsLikelyDiagnosed]                                      BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreIsDualDiagnosisCapable]                                 BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreIsDualDiagnosisEnhanced]                                BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreIsDiagnosed]                                            BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreIsMet]                                                  BIT    NULL,
    [CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScoreIsLikelyDiagnosed]          BIT    NULL,
    [CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScoreIsDualDiagnosisCapable]     BIT    NULL,
    [CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScoreIsDualDiagnosisEnhanced]    BIT    NULL,
    [CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScoreIsDiagnosed]                BIT    NULL,
    [CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScoreIsMet]                      BIT    NULL,
    [CareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScoreIsLikelyDiagnosed]       BIT    NULL,
    [CareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScoreIsDualDiagnosisCapable]  BIT    NULL,
    [CareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScoreIsDualDiagnosisEnhanced] BIT    NULL,
    [CareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScoreIsDiagnosed]             BIT    NULL,
    [CareLevel_III_3_ClinicallyManagedMediumIntensityResidentialTreatmentScoreIsMet]                   BIT    NULL,
    [CareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScoreIsLikelyDiagnosed]         BIT    NULL,
    [CareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScoreIsDualDiagnosisCapable]    BIT    NULL,
    [CareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScoreIsDualDiagnosisEnhanced]   BIT    NULL,
    [CareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScoreIsDiagnosed]               BIT    NULL,
    [CareLevel_III_5_ClinicallyManagedHighIntensityResidentialTreatmentScoreIsMet]                     BIT    NULL,
    [CareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScoreIsLikelyDiagnosed]              BIT    NULL,
    [CareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScoreIsDualDiagnosisCapable]         BIT    NULL,
    [CareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScoreIsDualDiagnosisEnhanced]        BIT    NULL,
    [CareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScoreIsDiagnosed]                    BIT    NULL,
    [CareLevel_III_7_MedicallyMonitoredIntensiveInpatientTreatmentScoreIsMet]                          BIT    NULL,
    [CareLevel_IV_MedicallyManagedIntensiveInpatientTreatmentScoreIsLikelyDiagnosed]                   BIT    NULL,
    [CareLevel_IV_MedicallyManagedIntensiveInpatientTreatmentScoreIsDualDiagnosisCapable]              BIT    NULL,
    [CareLevel_IV_MedicallyManagedIntensiveInpatientTreatmentScoreIsDualDiagnosisEnhanced]             BIT    NULL,
    [CareLevel_IV_MedicallyManagedIntensiveInpatientTreatmentScoreIsDiagnosed]                         BIT    NULL,
    [CareLevel_IV_MedicallyManagedIntensiveInpatientTreatmentScoreIsMet]                               BIT    NULL,
    PRIMARY KEY CLUSTERED ([DiagnosisResultsKey] ASC),
    CONSTRAINT [DiagnosisResults_CommonScores_FK] FOREIGN KEY ([CommonScoresKey]) REFERENCES [ScoringModule].[CommonScores] ([CommonScoresKey]),
    CONSTRAINT [DiagnosisResults_DiagnosticStatisticalManualOfMentalDisorders_IV_Scores_FK] FOREIGN KEY ([DiagnosticStatisticalManualOfMentalDisorders_IV_ScoresKey]) REFERENCES [ScoringModule].[DiagnosticStatisticalManualOfMentalDisorders_IV_Scores] ([DiagnosticStatisticalManualOfMentalDisorders_IV_ScoresKey]),
    CONSTRAINT [DiagnosisResults_DiagnosticStatisticalManualOfMentalDisorders_V_Scores_FK] FOREIGN KEY ([DiagnosticStatisticalManualOfMentalDisorders_V_ScoresKey]) REFERENCES [ScoringModule].[DiagnosticStatisticalManualOfMentalDisorders_V_Scores] ([DiagnosticStatisticalManualOfMentalDisorders_V_ScoresKey]),
    UNIQUE NONCLUSTERED ([CommonScoresKey] ASC),
    UNIQUE NONCLUSTERED ([DiagnosticStatisticalManualOfMentalDisorders_IV_ScoresKey] ASC)
);
















GO



GO
CREATE NONCLUSTERED INDEX [DiagnosisResults_DiagnosticStatisticalManualOfMentalDisorders_IV_Scores_FK_IDX]
    ON [ScoringModule].[DiagnosisResults]([DiagnosticStatisticalManualOfMentalDisorders_IV_ScoresKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DiagnosisResults_CommonScores_FK_IDX]
    ON [ScoringModule].[DiagnosisResults]([CommonScoresKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DiagnosisResults_DiagnosticStatisticalManualOfMentalDisorders_V_Scores_FK_IDX]
    ON [ScoringModule].[DiagnosisResults]([DiagnosticStatisticalManualOfMentalDisorders_V_ScoresKey] ASC);

