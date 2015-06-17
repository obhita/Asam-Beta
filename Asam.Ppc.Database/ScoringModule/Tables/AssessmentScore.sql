CREATE TABLE [ScoringModule].[AssessmentScore] (
    [AssessmentScoreKey]                     BIGINT             NOT NULL,
    [Version]                                INT                NOT NULL,
    [AssessmentKey]                          BIGINT             NOT NULL,
    [UserName]                               NVARCHAR (100)     NULL,
    [CreatedTimestamp]                       DATETIMEOFFSET (7) NOT NULL,
    [CreatedSystemAccount]                   NVARCHAR (255)     NULL,
    [UpdatedTimestamp]                       DATETIMEOFFSET (7) NOT NULL,
    [UpdatedSystemAccount]                   NVARCHAR (255)     NULL,
    [DiagnosisResultsKey]                    BIGINT             NULL,
    [Dimension1WithdrawalScoresKey]          BIGINT             NULL,
    [Dimension2BiomedicalScoresKey]          BIGINT             NULL,
    [Dimension3EmotionalBehavioralScoresKey] BIGINT             NULL,
    [Dimension4ReadinessToChangeScoresKey]   BIGINT             NULL,
    [Dimension5RelapsePotentialScoresKey]    BIGINT             NULL,
    [Dimension6LivingEnvironmentScoresKey]   BIGINT             NULL,
    [DimensionalAdmissionCriteriaResultsKey] BIGINT             NULL,
    PRIMARY KEY CLUSTERED ([AssessmentScoreKey] ASC),
    CONSTRAINT [AssessmentScore_DiagnosisResults_FK] FOREIGN KEY ([DiagnosisResultsKey]) REFERENCES [ScoringModule].[DiagnosisResults] ([DiagnosisResultsKey]),
    CONSTRAINT [AssessmentScore_Dimension1WithdrawalScores_FK] FOREIGN KEY ([Dimension1WithdrawalScoresKey]) REFERENCES [ScoringModule].[Dimension1WithdrawalScores] ([Dimension1WithdrawalScoresKey]),
    CONSTRAINT [AssessmentScore_Dimension2BiomedicalScores_FK] FOREIGN KEY ([Dimension2BiomedicalScoresKey]) REFERENCES [ScoringModule].[Dimension2BiomedicalScores] ([Dimension2BiomedicalScoresKey]),
    CONSTRAINT [AssessmentScore_Dimension3EmotionalBehavioralScores_FK] FOREIGN KEY ([Dimension3EmotionalBehavioralScoresKey]) REFERENCES [ScoringModule].[Dimension3EmotionalBehavioralScores] ([Dimension3EmotionalBehavioralScoresKey]),
    CONSTRAINT [AssessmentScore_Dimension4ReadinessToChangeScores_FK] FOREIGN KEY ([Dimension4ReadinessToChangeScoresKey]) REFERENCES [ScoringModule].[Dimension4ReadinessToChangeScores] ([Dimension4ReadinessToChangeScoresKey]),
    CONSTRAINT [AssessmentScore_Dimension5RelapsePotentialScores_FK] FOREIGN KEY ([Dimension5RelapsePotentialScoresKey]) REFERENCES [ScoringModule].[Dimension5RelapsePotentialScores] ([Dimension5RelapsePotentialScoresKey]),
    CONSTRAINT [AssessmentScore_Dimension6LivingEnvironmentScores_FK] FOREIGN KEY ([Dimension6LivingEnvironmentScoresKey]) REFERENCES [ScoringModule].[Dimension6LivingEnvironmentScores] ([Dimension6LivingEnvironmentScoresKey]),
    CONSTRAINT [AssessmentScore_DimensionalAdmissionCriteriaResults_FK] FOREIGN KEY ([DimensionalAdmissionCriteriaResultsKey]) REFERENCES [ScoringModule].[DimensionalAdmissionCriteriaResults] ([DimensionalAdmissionCriteriaResultsKey]),
    UNIQUE NONCLUSTERED ([DiagnosisResultsKey] ASC),
    UNIQUE NONCLUSTERED ([Dimension1WithdrawalScoresKey] ASC),
    UNIQUE NONCLUSTERED ([Dimension2BiomedicalScoresKey] ASC),
    UNIQUE NONCLUSTERED ([Dimension3EmotionalBehavioralScoresKey] ASC),
    UNIQUE NONCLUSTERED ([Dimension4ReadinessToChangeScoresKey] ASC),
    UNIQUE NONCLUSTERED ([Dimension5RelapsePotentialScoresKey] ASC),
    UNIQUE NONCLUSTERED ([Dimension6LivingEnvironmentScoresKey] ASC),
    UNIQUE NONCLUSTERED ([DimensionalAdmissionCriteriaResultsKey] ASC)
);










GO
CREATE NONCLUSTERED INDEX [AssessmentScore_DimensionalAdmissionCriteriaResults_FK_IDX]
    ON [ScoringModule].[AssessmentScore]([DimensionalAdmissionCriteriaResultsKey] ASC);


GO
CREATE NONCLUSTERED INDEX [AssessmentScore_Dimension6LivingEnvironmentScores_FK_IDX]
    ON [ScoringModule].[AssessmentScore]([Dimension6LivingEnvironmentScoresKey] ASC);


GO
CREATE NONCLUSTERED INDEX [AssessmentScore_Dimension5RelapsePotentialScores_FK_IDX]
    ON [ScoringModule].[AssessmentScore]([Dimension5RelapsePotentialScoresKey] ASC);


GO
CREATE NONCLUSTERED INDEX [AssessmentScore_Dimension4ReadinessToChangeScores_FK_IDX]
    ON [ScoringModule].[AssessmentScore]([Dimension4ReadinessToChangeScoresKey] ASC);


GO
CREATE NONCLUSTERED INDEX [AssessmentScore_Dimension3EmotionalBehavioralScores_FK_IDX]
    ON [ScoringModule].[AssessmentScore]([Dimension3EmotionalBehavioralScoresKey] ASC);


GO
CREATE NONCLUSTERED INDEX [AssessmentScore_Dimension2BiomedicalScores_FK_IDX]
    ON [ScoringModule].[AssessmentScore]([Dimension2BiomedicalScoresKey] ASC);


GO
CREATE NONCLUSTERED INDEX [AssessmentScore_Dimension1WithdrawalScores_FK_IDX]
    ON [ScoringModule].[AssessmentScore]([Dimension1WithdrawalScoresKey] ASC);


GO
CREATE NONCLUSTERED INDEX [AssessmentScore_DiagnosisResults_FK_IDX]
    ON [ScoringModule].[AssessmentScore]([DiagnosisResultsKey] ASC);

