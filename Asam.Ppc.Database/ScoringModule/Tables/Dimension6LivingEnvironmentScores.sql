﻿CREATE TABLE [ScoringModule].[Dimension6LivingEnvironmentScores] (
    [Dimension6LivingEnvironmentScoresKey]                                                                           BIGINT NOT NULL,
    [Version]                                                                                                        INT    NOT NULL,
    [CareLevel_0_5_EarlyInterventionScoreHasSupportSystemThatPreventsThemFromMeetingObligations]                     BIT    NULL,
    [CareLevel_0_5_EarlyInterventionScoreHasFamilyMembersCurrentlyAbusingAlcoholOrDrugs]                             BIT    NULL,
    [CareLevel_0_5_EarlyInterventionScoreHasSignificantOtherWithDrugOrAlcoholValuesConflict]                         BIT    NULL,
    [CareLevel_0_5_EarlyInterventionScoreHasSignificantOtherWhoCondonesOrEncouragesAlcoholOrDrugUse]                 BIT    NULL,
    [CareLevel_0_5_EarlyInterventionScoreIsMet]                                                                      BIT    NULL,
    [CareLevel_I_OutpatientScorePsychosocialEnvironmentSupportiveOutpatientTreatmentFeasible]                        BIT    NULL,
    [CareLevel_I_OutpatientScoreSocialSupportNotAdequatePatientMotivatedToObtainSupportive]                          BIT    NULL,
    [CareLevel_I_OutpatientScoreSupportiveButRequireProfessionalInterventionsForRecovery]                            BIT    NULL,
    [CareLevel_I_OutpatientScoreSocialSupportNotAdequateAndMildImpairmentInAbilityToObtainOne]                       BIT    NULL,
    [CareLevel_I_OutpatientScoreSocialSupportRequiresActiveFamilyTherapyForSuccessAndRecovery]                       BIT    NULL,
    [CareLevel_I_OutpatientScoreIsChronicallyImpairedNoAdequateSupportButAccessToRecoveryEnvironment]                BIT    NULL,
    [CareLevel_I_OutpatientScoreIsDualDiagnosisEnhanced]                                                             BIT    NULL,
    [CareLevel_I_OutpatientScoreIsMet]                                                                               BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreHasSupportivePsychosocialEnvironmentToRenderOpioidManintenanceFeasible]   BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreSupportiveButRequireProfessionalInterventionsForTreatmentSuccess]         BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreNoPositiveSocialSupportPatientMotivatedToObtainSupportSystem]             BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreHasExperiencedTraumaInRecoveryEnvironmentManageableAsOutpatient]          BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreIsMet]                                                                    BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreCurrentSchoolWorkLivingWillRenderRecoveryUnlikely]                       BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreInsufficientOrInappropriateSocialContactsJeopardizeRecovery]             BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreHasInsufficientResourcesSupportiveOfGoodMentalFunctioning]               BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreIsDualDiagnosisEnhanced]                                                 BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreIsMet]                                                                   BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreIsDualDiagnosisEnhanced]                                              BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreContinuedExposureToCurrentSchoolWorkLivingWillRenderRecoveryUnlikely] BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreAreNotSupportiveOfRecoveryGoalsPassivelyOpposedToTreatment]           BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreHasInsufficientResourcesSupportiveOfGoodMentalFunctioning]            BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreIsMet]                                                                BIT    NULL,
    [CareLevel_III_1_LivingInModeratelyHighRiskEnvironmentImpactToRecovery]                                          BIT    NULL,
    [CareLevel_III_1_InsufficientOrInappropriateSocialContactsOrSocialIsolationImpactsRecovery]                      BIT    NULL,
    [CareLevel_III_1_ContinuedExposureToCurrentSchoolWorkLivingNeeds24HourSupport]                                   BIT    NULL,
    [CareLevel_III_1_DangerOfVictimizationByAnotherRequires24HourSupervision]                                        BIT    NULL,
    [CareLevel_III_1_AbleToCopeLimitedPeriodsTimeOutside24HourStructure]                                             BIT    NULL,
    [CareLevel_III_1_HasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced]                             BIT    NULL,
    [CareLevel_III_1_IsDualDiagnosisEnhanced]                                                                        BIT    NULL,
    [CareLevel_III_1_IsMet]                                                                                          BIT    NULL,
    [CareLevel_III_3_IsDualDiagnosisEnhanced]                                                                        BIT    NULL,
    [CareLevel_III_3_LivingEnvironmentModerateHighRiskUnableToMaintainRecovery]                                      BIT    NULL,
    [CareLevel_III_3_CognitiveImpairmentRequires24HourSupervisionToPreventVictimization]                             BIT    NULL,
    [CareLevel_III_3_SocialNetworkOrLivingWithAlcoholDrugUserImpactsRecovery]                                        BIT    NULL,
    [CareLevel_III_3_IsUnableToCopeOutside24HourStructureProgram]                                                    BIT    NULL,
    [CareLevel_III_3_HasSeverePersistentMentalIllnessNeedsStructureOfLevel33DualDiagnosisEnhanced]                   BIT    NULL,
    [CareLevel_III_3_IsMet]                                                                                          BIT    NULL,
    [CareLevel_III_5_IsDualDiagnosisEnhanced]                                                                        BIT    NULL,
    [CareLevel_III_5_LivingEnvironmentModerateHighRiskAbuseNoRecoveryAtLowerLevelCare]                               BIT    NULL,
    [CareLevel_III_5_SocialNetworkOrLivingWithAlcoholDrugUserPreventsRecoveryAtLowerLevelOfCare]                     BIT    NULL,
    [CareLevel_III_5_UnableToCopeOutside24HourCareNeedsStaffMonitoring]                                              BIT    NULL,
    [CareLevel_III_5_LivingEnvironmentHasCriminalBehaviorAndOtherAntiSocialValues]                                   BIT    NULL,
    [CareLevel_III_5_HasSeverePersistentMentalIllnessNeedsStructureOfLevel35DualDiagnosisEnhanced]                   BIT    NULL,
    [CareLevel_III_5_IsMet]                                                                                          BIT    NULL,
    [CareLevel_III_7_IsDualDiagnosisEnhanced]                                                                        BIT    NULL,
    [CareLevel_III_7_RequiresContinuousMedicalMonitoringAddressPsychSubstance]                                       BIT    NULL,
    [CareLevel_III_7_AreNotSupportiveOfRecoveryGoalsActivelySabotagingTreatment]                                     BIT    NULL,
    [CareLevel_III_7_UnableToCopeOutside24HourCareNeedsStaffMonitoring]                                              BIT    NULL,
    [CareLevel_III_7_HasSeverePersistentMentalIllnessNeedsStructureOfLevel37DualDiagnosisEnhanced]                   BIT    NULL,
    [CareLevel_III_7_IsMet]                                                                                          BIT    NULL,
    [CareLevel_IV_IsMet]                                                                                             BIT    NULL,
    PRIMARY KEY CLUSTERED ([Dimension6LivingEnvironmentScoresKey] ASC)
);






GO


