CREATE TABLE [AssessmentModule].[CompletionSection] (
    [CompletionSectionKey]                                                BIGINT          NOT NULL,
    [Version]                                                             INT             NOT NULL,
    [DetoxificationRequiredMoreThanHourlyMonitoring]                      BIT             NULL,
    [IsCurrentlyResidingInCareLevel_III_1]                                BIT             NULL,
    [MedicalProblemsCausedBySubstanceUse]                                 BIT             NULL,
    [PrnHourlyMonitoringSufficientToDetermineDetoxServiceLevel]           BIT             NULL,
    [RequiresTreatmentModeOnlyAvailableInCareLevel_III_7]                 BIT             NULL,
    [RespondedPositivelyToEmotionalSupportDuringInterview]                BIT             NULL,
    [SymptomsStabalizedDuringTreatmentDay]                                BIT             NULL,
    [ClinicalSummaryNotes]                                                NVARCHAR (2000) NULL,
    [IsVisited]                                                           BIT             NOT NULL,
    [IsAbleToSelfAdministerMedicationCode]                                NVARCHAR (200)  NULL,
    [IsAbleToSelfAdministerMedicationName]                                NVARCHAR (200)  NULL,
    [IsAbleToSelfAdministerMedicationValue]                               INT             NULL,
    [IsAbleToSelfAdministerMedicationIsDefault]                           BIT             NULL,
    [IsAbleToSelfAdministerMedicationSortOrder]                           INT             NULL,
    [MedicalConditionEndangeredByContinuedSubstanceUseCode]               NVARCHAR (200)  NULL,
    [MedicalConditionEndangeredByContinuedSubstanceUseName]               NVARCHAR (200)  NULL,
    [MedicalConditionEndangeredByContinuedSubstanceUseValue]              INT             NULL,
    [MedicalConditionEndangeredByContinuedSubstanceUseIsDefault]          BIT             NULL,
    [MedicalConditionEndangeredByContinuedSubstanceUseSortOrder]          INT             NULL,
    [MedicalConditionExacerbatedByContinuedSubstanceUseCode]              NVARCHAR (200)  NULL,
    [MedicalConditionExacerbatedByContinuedSubstanceUseName]              NVARCHAR (200)  NULL,
    [MedicalConditionExacerbatedByContinuedSubstanceUseValue]             INT             NULL,
    [MedicalConditionExacerbatedByContinuedSubstanceUseIsDefault]         BIT             NULL,
    [MedicalConditionExacerbatedByContinuedSubstanceUseSortOrder]         INT             NULL,
    [MedicalConditionMakesAbstinenceVitalCode]                            NVARCHAR (200)  NULL,
    [MedicalConditionMakesAbstinenceVitalName]                            NVARCHAR (200)  NULL,
    [MedicalConditionMakesAbstinenceVitalValue]                           INT             NULL,
    [MedicalConditionMakesAbstinenceVitalIsDefault]                       BIT             NULL,
    [MedicalConditionMakesAbstinenceVitalSortOrder]                       INT             NULL,
    [MedicalConditionStabilizedInPast24HoursPermittingTreatmentCode]      NVARCHAR (200)  NULL,
    [MedicalConditionStabilizedInPast24HoursPermittingTreatmentName]      NVARCHAR (200)  NULL,
    [MedicalConditionStabilizedInPast24HoursPermittingTreatmentValue]     INT             NULL,
    [MedicalConditionStabilizedInPast24HoursPermittingTreatmentIsDefault] BIT             NULL,
    [MedicalConditionStabilizedInPast24HoursPermittingTreatmentSortOrder] INT             NULL,
    [RecommendedCareLevelSubCategoryCode]                                 NVARCHAR (200)  NULL,
    [RecommendedCareLevelSubCategoryName]                                 NVARCHAR (200)  NULL,
    [RecommendedCareLevelSubCategoryValue]                                INT             NULL,
    [RecommendedCareLevelSubCategoryIsDefault]                            BIT             NULL,
    [RecommendedCareLevelSubCategorySortOrder]                            INT             NULL,
    [SymptomsLifeThreateningBecauseOfSubstanceUseCode]                    NVARCHAR (200)  NULL,
    [SymptomsLifeThreateningBecauseOfSubstanceUseName]                    NVARCHAR (200)  NULL,
    [SymptomsLifeThreateningBecauseOfSubstanceUseValue]                   INT             NULL,
    [SymptomsLifeThreateningBecauseOfSubstanceUseIsDefault]               BIT             NULL,
    [SymptomsLifeThreateningBecauseOfSubstanceUseSortOrder]               INT             NULL,
    [TimingOfPositiveResponseToWithdrawalManagementCareCode]              NVARCHAR (200)  NULL,
    [TimingOfPositiveResponseToWithdrawalManagementCareName]              NVARCHAR (200)  NULL,
    [TimingOfPositiveResponseToWithdrawalManagementCareValue]             INT             NULL,
    [TimingOfPositiveResponseToWithdrawalManagementCareIsDefault]         BIT             NULL,
    [TimingOfPositiveResponseToWithdrawalManagementCareSortOrder]         INT             NULL,
    [WouldRecommendProgramToFriendCode]                                   NVARCHAR (200)  NULL,
    [WouldRecommendProgramToFriendName]                                   NVARCHAR (200)  NULL,
    [WouldRecommendProgramToFriendValue]                                  INT             NULL,
    [WouldRecommendProgramToFriendIsDefault]                              BIT             NULL,
    [WouldRecommendProgramToFriendSortOrder]                              INT             NULL,
    PRIMARY KEY CLUSTERED ([CompletionSectionKey] ASC)
);






















GO


