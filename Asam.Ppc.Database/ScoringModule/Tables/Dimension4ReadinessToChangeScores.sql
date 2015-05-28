CREATE TABLE [ScoringModule].[Dimension4ReadinessToChangeScores] (
    [Dimension4ReadinessToChangeScoresKey]                                                                      BIGINT NOT NULL,
    [Version]                                                                                                   INT    NOT NULL,
    [CareLevel_0_5_EarlyInterventionScoreWillingToGainUnderstandingOfSubstanceUseHarmfulness]                   BIT    NULL,
    [CareLevel_0_5_EarlyInterventionScoreIsMet]                                                                 BIT    NULL,
    [CareLevel_I_OutpatientScoreAcknowledgesProblemAndWantsHelp]                                                BIT    NULL,
    [CareLevel_I_OutpatientScoreAmbivalentAboutProblemRequiresMonitoringInUnstructuredProgram]                  BIT    NULL,
    [CareLevel_I_OutpatientScoreDoesNotRecognizeProblemRequiresMonitoringInUnstructuredProgram]                 BIT    NULL,
    [CareLevel_I_OutpatientScoreExpressesWillingnessToParticipateInTreatment]                                   BIT    NULL,
    [CareLevel_I_OutpatientScoreIsMet]                                                                          BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreRequiresStructuredTherapyForRecovery]                                BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreAttributesSubstanceProblemsToOthersOrEvents]                         BIT    NULL,
    [CareLevelOpioidMaintenanceTherapyScoreIsMet]                                                               BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreIsDualDiagnosisEnhanced]                                            BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreRequiresMoreThanLevelOPTherapySinceOtherCareLevelFailed]            BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreRequiresRepeatedInterventionButWillingToParticipate]                BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreAmbivalentOrInconsistentOrUnawareOfNecessaryTreatment]              BIT    NULL,
    [CareLevel_II_1_IntensiveOutpatientScoreIsMet]                                                              BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreIsDualDiagnosisEnhanced]                                         BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreRequiresMoreThanLevelIOPTherapySinceOtherCareLevelFailed]        BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreInabilityToChangeWithoutStructureButWillingToParticipate]        BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScorePoorAwarenessOfDisorderOrFollowThruInTreatmentOrHarmfulImpulses] BIT    NULL,
    [CareLevel_II_5_PartialHospitalizationScoreIsMet]                                                           BIT    NULL,
    [CareLevel_III_1_IsDualDiagnosisEnhanced]                                                                   BIT    NULL,
    [CareLevel_III_1_AcknowlegesProblemRecognizesConsequencesAndIsCooperative]                                  BIT    NULL,
    [CareLevel_III_1_InTreatmentAtThisndLowerLevelAndNeedsMotivationStrategy]                                   BIT    NULL,
    [CareLevel_III_1_Requires24HourCarePreviouslyFailedTreatment]                                               BIT    NULL,
    [CareLevel_III_1_PerspectiveImpairsCareWithoutStructuredEnvironment]                                        BIT    NULL,
    [CareLevel_III_1_AmbivalentOrPoorFollowThruRequiresExternalInterventions]                                   BIT    NULL,
    [CareLevel_III_1_IsMet]                                                                                     BIT    NULL,
    [CareLevel_III_3_IsDualDiagnosisEnhanced]                                                                   BIT    NULL,
    [CareLevel_III_3_LittleAwarenessOfNeedForTreatmentAndLimitedReadinessToChange]                              BIT    NULL,
    [CareLevel_III_3_DifficultyUnderstandingRelationOfSubstanceAbuseAndFunctionalLevel]                         BIT    NULL,
    [CareLevel_III_3_PosesPersonalDangerOfHarmWithNoAwarenessOfNeedForTreatment]                                BIT    NULL,
    [CareLevel_III_3_CognitiveDeficitsRequireImpatientTreatmentToChangeBehavior]                                BIT    NULL,
    [CareLevel_III_3_AmbivalentOrReluctantToAddressCoexistingMentalHealthProblem]                               BIT    NULL,
    [CareLevel_III_3_IsMet]                                                                                     BIT    NULL,
    [CareLevel_III_5_IsDualDiagnosisEnhanced]                                                                   BIT    NULL,
    [CareLevel_III_5_LittleAcuityOfNeedForTreatmentAndLimitedReadinessToChange]                                 BIT    NULL,
    [CareLevel_III_5_DifficultyComprehendingRelationOfSubstanceAbuseAndFunctionalLevel]                         BIT    NULL,
    [CareLevel_III_5_PosesPersonalDangerOfHarmWithOppositionToAddressProblems]                                  BIT    NULL,
    [CareLevel_III_5_PreviousFailedInterventionsIndicateCareRequiredAtThisLevel]                                BIT    NULL,
    [CareLevel_III_5_AttributesProblemsToExternalCausesAndNeeds24HourCare]                                      BIT    NULL,
    [CareLevel_III_5_WillNotCommitToChangeOrAddressCoexistingMentalHealthProblem]                               BIT    NULL,
    [CareLevel_III_5_IsMet]                                                                                     BIT    NULL,
    [CareLevel_III_7_IsDualDiagnosisEnhanced]                                                                   BIT    NULL,
    [CareLevel_III_7_DoesNotAcceptOrRelateAddictiveDisordersToSevereProblems]                                   BIT    NULL,
    [CareLevel_III_7_NeedsIntensiveCareOnlyAvailableIn24HourMedicalSetting]                                     BIT    NULL,
    [CareLevel_III_7_Needs24HourPsychiatricMonitoringToComplyWithMedications]                                   BIT    NULL,
    [CareLevel_III_7_RefusesToAddressCoexistingMentalHealthProblemOrCommitToChange]                             BIT    NULL,
    [CareLevel_III_7_IsMet]                                                                                     BIT    NULL,
    [CareLevel_IV_IsMet]                                                                                        BIT    NULL,
    PRIMARY KEY CLUSTERED ([Dimension4ReadinessToChangeScoresKey] ASC)
);






GO


