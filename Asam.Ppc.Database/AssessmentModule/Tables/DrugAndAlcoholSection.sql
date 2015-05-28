CREATE TABLE [AssessmentModule].[DrugAndAlcoholSection] (
    [DrugAndAlcoholSectionKey]                BIGINT NOT NULL,
    [Version]                                 INT    NOT NULL,
    [IsVisited]                               BIT    NOT NULL,
    [AddictionTreatmentHistoryKey]            BIGINT NULL,
    [AdditionalAddictionAndTreatmentItemsKey] BIGINT NULL,
    [AlcoholAndDrugInterviewerRatingKey]      BIGINT NULL,
    [AlcoholUseKey]                           BIGINT NULL,
    [BarbiturateUseKey]                       BIGINT NULL,
    [CannabisUseKey]                          BIGINT NULL,
    [CinaScaleKey]                            BIGINT NULL,
    [CiwaScaleKey]                            BIGINT NULL,
    [CocaineUseKey]                           BIGINT NULL,
    [DrugConsequencesKey]                     BIGINT NULL,
    [HallucinogenUseKey]                      BIGINT NULL,
    [HeroinUseKey]                            BIGINT NULL,
    [InterviewerEvaluationKey]                BIGINT NULL,
    [MethadoneUseKey]                         BIGINT NULL,
    [MultipleSubstanceUsePerDayKey]           BIGINT NULL,
    [NicotineUseKey]                          BIGINT NULL,
    [OpiatesInControlledEnvironmentKey]       BIGINT NULL,
    [OpioidMaintenanceTherapyKey]             BIGINT NULL,
    [OtherOpiateUseKey]                       BIGINT NULL,
    [OtherSedativeUseKey]                     BIGINT NULL,
    [OtherSubstanceUseKey]                    BIGINT NULL,
    [SolventAndInhalantUseKey]                BIGINT NULL,
    [StimulantUseKey]                         BIGINT NULL,
    [UsedSubstancesKey]                       BIGINT NULL,
    PRIMARY KEY CLUSTERED ([DrugAndAlcoholSectionKey] ASC),
    CONSTRAINT [DrugAndAlcoholSection_AddictionTreatmentHistory_FK] FOREIGN KEY ([AddictionTreatmentHistoryKey]) REFERENCES [AssessmentModule].[AddictionTreatmentHistory] ([AddictionTreatmentHistoryKey]),
    CONSTRAINT [DrugAndAlcoholSection_AdditionalAddictionAndTreatmentItems_FK] FOREIGN KEY ([AdditionalAddictionAndTreatmentItemsKey]) REFERENCES [AssessmentModule].[AdditionalAddictionAndTreatmentItems] ([AdditionalAddictionAndTreatmentItemsKey]),
    CONSTRAINT [DrugAndAlcoholSection_AlcoholAndDrugInterviewerRating_FK] FOREIGN KEY ([AlcoholAndDrugInterviewerRatingKey]) REFERENCES [AssessmentModule].[AlcoholAndDrugInterviewerRating] ([AlcoholAndDrugInterviewerRatingKey]),
    CONSTRAINT [DrugAndAlcoholSection_AlcoholUse_FK] FOREIGN KEY ([AlcoholUseKey]) REFERENCES [AssessmentModule].[AlcoholUse] ([AlcoholUseKey]),
    CONSTRAINT [DrugAndAlcoholSection_BarbiturateUse_FK] FOREIGN KEY ([BarbiturateUseKey]) REFERENCES [AssessmentModule].[BarbiturateUse] ([BarbiturateUseKey]),
    CONSTRAINT [DrugAndAlcoholSection_CannabisUse_FK] FOREIGN KEY ([CannabisUseKey]) REFERENCES [AssessmentModule].[CannabisUse] ([CannabisUseKey]),
    CONSTRAINT [DrugAndAlcoholSection_CinaScale_FK] FOREIGN KEY ([CinaScaleKey]) REFERENCES [AssessmentModule].[CinaScale] ([CinaScaleKey]),
    CONSTRAINT [DrugAndAlcoholSection_CiwaScale_FK] FOREIGN KEY ([CiwaScaleKey]) REFERENCES [AssessmentModule].[CiwaScale] ([CiwaScaleKey]),
    CONSTRAINT [DrugAndAlcoholSection_CocaineUse_FK] FOREIGN KEY ([CocaineUseKey]) REFERENCES [AssessmentModule].[CocaineUse] ([CocaineUseKey]),
    CONSTRAINT [DrugAndAlcoholSection_DrugConsequences_FK] FOREIGN KEY ([DrugConsequencesKey]) REFERENCES [AssessmentModule].[DrugConsequences] ([DrugConsequencesKey]),
    CONSTRAINT [DrugAndAlcoholSection_HallucinogenUse_FK] FOREIGN KEY ([HallucinogenUseKey]) REFERENCES [AssessmentModule].[HallucinogenUse] ([HallucinogenUseKey]),
    CONSTRAINT [DrugAndAlcoholSection_HeroinUse_FK] FOREIGN KEY ([HeroinUseKey]) REFERENCES [AssessmentModule].[HeroinUse] ([HeroinUseKey]),
    CONSTRAINT [DrugAndAlcoholSection_InterviewerEvaluation_FK] FOREIGN KEY ([InterviewerEvaluationKey]) REFERENCES [AssessmentModule].[InterviewerEvaluation] ([InterviewerEvaluationKey]),
    CONSTRAINT [DrugAndAlcoholSection_MethadoneUse_FK] FOREIGN KEY ([MethadoneUseKey]) REFERENCES [AssessmentModule].[MethadoneUse] ([MethadoneUseKey]),
    CONSTRAINT [DrugAndAlcoholSection_MultipleSubstanceUsePerDay_FK] FOREIGN KEY ([MultipleSubstanceUsePerDayKey]) REFERENCES [AssessmentModule].[MultipleSubstanceUsePerDay] ([MultipleSubstanceUsePerDayKey]),
    CONSTRAINT [DrugAndAlcoholSection_NicotineUse_FK] FOREIGN KEY ([NicotineUseKey]) REFERENCES [AssessmentModule].[NicotineUse] ([NicotineUseKey]),
    CONSTRAINT [DrugAndAlcoholSection_OpiatesInControlledEnvironment_FK] FOREIGN KEY ([OpiatesInControlledEnvironmentKey]) REFERENCES [AssessmentModule].[OpiatesInControlledEnvironment] ([OpiatesInControlledEnvironmentKey]),
    CONSTRAINT [DrugAndAlcoholSection_OpioidMaintenanceTherapy_FK] FOREIGN KEY ([OpioidMaintenanceTherapyKey]) REFERENCES [AssessmentModule].[OpioidMaintenanceTherapy] ([OpioidMaintenanceTherapyKey]),
    CONSTRAINT [DrugAndAlcoholSection_OtherOpiateUse_FK] FOREIGN KEY ([OtherOpiateUseKey]) REFERENCES [AssessmentModule].[OtherOpiateUse] ([OtherOpiateUseKey]),
    CONSTRAINT [DrugAndAlcoholSection_OtherSedativeUse_FK] FOREIGN KEY ([OtherSedativeUseKey]) REFERENCES [AssessmentModule].[OtherSedativeUse] ([OtherSedativeUseKey]),
    CONSTRAINT [DrugAndAlcoholSection_OtherSubstanceUse_FK] FOREIGN KEY ([OtherSubstanceUseKey]) REFERENCES [AssessmentModule].[OtherSubstanceUse] ([OtherSubstanceUseKey]),
    CONSTRAINT [DrugAndAlcoholSection_SolventAndInhalantUse_FK] FOREIGN KEY ([SolventAndInhalantUseKey]) REFERENCES [AssessmentModule].[SolventAndInhalantUse] ([SolventAndInhalantUseKey]),
    CONSTRAINT [DrugAndAlcoholSection_StimulantUse_FK] FOREIGN KEY ([StimulantUseKey]) REFERENCES [AssessmentModule].[StimulantUse] ([StimulantUseKey]),
    CONSTRAINT [DrugAndAlcoholSection_UsedSubstances_FK] FOREIGN KEY ([UsedSubstancesKey]) REFERENCES [AssessmentModule].[UsedSubstances] ([UsedSubstancesKey]),
    UNIQUE NONCLUSTERED ([AddictionTreatmentHistoryKey] ASC),
    UNIQUE NONCLUSTERED ([AdditionalAddictionAndTreatmentItemsKey] ASC),
    UNIQUE NONCLUSTERED ([AlcoholAndDrugInterviewerRatingKey] ASC),
    UNIQUE NONCLUSTERED ([AlcoholUseKey] ASC),
    UNIQUE NONCLUSTERED ([BarbiturateUseKey] ASC),
    UNIQUE NONCLUSTERED ([CannabisUseKey] ASC),
    UNIQUE NONCLUSTERED ([CinaScaleKey] ASC),
    UNIQUE NONCLUSTERED ([CiwaScaleKey] ASC),
    UNIQUE NONCLUSTERED ([CocaineUseKey] ASC),
    UNIQUE NONCLUSTERED ([DrugConsequencesKey] ASC),
    UNIQUE NONCLUSTERED ([HallucinogenUseKey] ASC),
    UNIQUE NONCLUSTERED ([HeroinUseKey] ASC),
    UNIQUE NONCLUSTERED ([InterviewerEvaluationKey] ASC),
    UNIQUE NONCLUSTERED ([MethadoneUseKey] ASC),
    UNIQUE NONCLUSTERED ([MultipleSubstanceUsePerDayKey] ASC),
    UNIQUE NONCLUSTERED ([NicotineUseKey] ASC),
    UNIQUE NONCLUSTERED ([OpiatesInControlledEnvironmentKey] ASC),
    UNIQUE NONCLUSTERED ([OpioidMaintenanceTherapyKey] ASC),
    UNIQUE NONCLUSTERED ([OtherOpiateUseKey] ASC),
    UNIQUE NONCLUSTERED ([OtherSedativeUseKey] ASC),
    UNIQUE NONCLUSTERED ([OtherSubstanceUseKey] ASC),
    UNIQUE NONCLUSTERED ([SolventAndInhalantUseKey] ASC),
    UNIQUE NONCLUSTERED ([StimulantUseKey] ASC),
    UNIQUE NONCLUSTERED ([UsedSubstancesKey] ASC)
);
















GO



GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_StimulantUse_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([StimulantUseKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_SolventAndInhalantUse_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([SolventAndInhalantUseKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_OtherSubstanceUse_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([OtherSubstanceUseKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_OtherSedativeUse_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([OtherSedativeUseKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_OpioidMaintenanceTherapy_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([OpioidMaintenanceTherapyKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_OpiatesInControlledEnvironment_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([OpiatesInControlledEnvironmentKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_OtherOpiateUse_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([OtherOpiateUseKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_NicotineUse_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([NicotineUseKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_MultipleSubstanceUsePerDay_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([MultipleSubstanceUsePerDayKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_MethadoneUse_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([MethadoneUseKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_InterviewerEvaluation_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([InterviewerEvaluationKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_HeroinUse_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([HeroinUseKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_HallucinogenUse_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([HallucinogenUseKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_DrugConsequences_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([DrugConsequencesKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_CocaineUse_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([CocaineUseKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_CiwaScale_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([CiwaScaleKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_CinaScale_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([CinaScaleKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_CannabisUse_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([CannabisUseKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_BarbiturateUse_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([BarbiturateUseKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_AlcoholUse_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([AlcoholUseKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_AlcoholAndDrugInterviewerRating_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([AlcoholAndDrugInterviewerRatingKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_AdditionalAddictionAndTreatmentItems_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([AdditionalAddictionAndTreatmentItemsKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_AddictionTreatmentHistory_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([AddictionTreatmentHistoryKey] ASC);


GO
CREATE NONCLUSTERED INDEX [DrugAndAlcoholSection_UsedSubstances_FK_IDX]
    ON [AssessmentModule].[DrugAndAlcoholSection]([UsedSubstancesKey] ASC);

