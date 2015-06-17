CREATE TABLE [ScoringModule].[Dimension2BiomedicalScores] (
    [Dimension2BiomedicalScoresKey]                                                                                BIGINT NOT NULL,
    [Version]                                                                                                      INT    NOT NULL,
    [CareLevel_0_5_EarlyInterventionScoreShowsBiomedicalStabilityOrProblemsBeingAddressed]                         BIT    NULL,
    [CareLevel_0_5_EarlyInterventionScoreIsMet]                                                                    BIT    NULL,
    [CareLevel_I_OutpatientScoreShowsBiomedicalStabilityCanParticipateInPutpatientTreatment]                       BIT    NULL,
    [CareLevel_I_OutpatientScoreIsMet]                                                                             BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreMeetsBiomedicalCriteriaForOpiateDependenceRequiresOutpatientMonitoring] BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreBiomedicalProblemTreatedOutpatientMinimalDailyMonitoring]               BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreHasBiomedicalProblemsManagedOutpatientSpecificDiseases]                 BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreIsMet]                                                                  BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreBiomedicalStabilityOrAddressedConcurrentlyNotInterfereTreatment]       BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreIsMet]                                                                 BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreProblemsNotSufficientInterfereTreatmentSeverityDistractsRecovery]   BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreIsMet]                                                              BIT    NULL,
    [CareLevel_III_1_BiomedicalStabilityNoMedicalNurseMonitoring]                                                  BIT    NULL,
    [CareLevel_III_1_BiomedicalSeverityNotWarrantInpatientTreatmentSufficientDistractRecovery]                     BIT    NULL,
    [CareLevel_III_1_BiomedicalProblemWarrantsEnhancedStaffAttention]                                              BIT    NULL,
    [CareLevel_III_1_IsMetDim2Level3LowIntensity]                                                                  BIT    NULL,
    [CareLevel_III_1_IsMet]                                                                                        BIT    NULL,
    [CareLevel_III_3_BiomedicalNotWarrantMedicalNurseMonitoringSelfAdministerMeds]                                 BIT    NULL,
    [CareLevel_III_3_BiomedicalNotWarrantInpatientTreatmentButRequiresMedicalMirt]                                 BIT    NULL,
    [CareLevel_III_3_BiomedicalProblemRequiresEnhancedStaffAttentionMonitoringMeds]                                BIT    NULL,
    [CareLevel_III_3_IsMetDim2Level3ModerateIntensity]                                                             BIT    NULL,
    [CareLevel_III_3_IsMet]                                                                                        BIT    NULL,
    [CareLevel_III_5_BiomedicalStabilityNotRequire24HourMedicalNurse]                                              BIT    NULL,
    [CareLevel_III_5_BiomedicalNotWarrantInpatientTreatmentButRequiresMedicalHirt]                                 BIT    NULL,
    [CareLevel_III_5_RequiresDegreeStaffAttentionNotAvailableInOtherLevel5Programs]                                BIT    NULL,
    [CareLevel_III_5_IsMetDim2Level3HighIntensity]                                                                 BIT    NULL,
    [CareLevel_III_5_IsMet]                                                                                        BIT    NULL,
    [CareLevel_III_7_InteractionOfDrugAlcoholAndBiomedicalSeriousDamageToPhysicalHealth]                           BIT    NULL,
    [CareLevel_III_7_BiomedicalRequiresMedicalMonitoringNotFullResourcesOfAcuteHospital]                           BIT    NULL,
    [CareLevel_III_7_RequiresDegreeStaffAttentionNotAvailableInOtherLevel7Programs]                                BIT    NULL,
    [CareLevel_III_7_IsMetDim2Level3MedicalMonitoring]                                                             BIT    NULL,
    [CareLevel_III_7_IsMet]                                                                                        BIT    NULL,
    [CareLevel_IV_BiomedicalComplicationsAddictiveDisorderRequiresMedicalManagement]                               BIT    NULL,
    [CareLevel_IV_ContinuedUseSeriousDamageToPhysicalHealthOr24HourObservation]                                    BIT    NULL,
    [CareLevel_IV_IsMet]                                                                                           BIT    NULL,
    PRIMARY KEY CLUSTERED ([Dimension2BiomedicalScoresKey] ASC)
);






GO


