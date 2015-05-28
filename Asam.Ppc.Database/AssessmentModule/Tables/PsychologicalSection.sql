CREATE TABLE [AssessmentModule].[PsychologicalSection] (
    [PsychologicalSectionKey] BIGINT NOT NULL,
    [Version]                 INT    NOT NULL,
    [IsVisited]               BIT    NOT NULL,
    [DepressionEvaluationKey] BIGINT NULL,
    [InterviewerRatingKey]    BIGINT NULL,
    [PsychologicalHistoryKey] BIGINT NULL,
    PRIMARY KEY CLUSTERED ([PsychologicalSectionKey] ASC),
    CONSTRAINT [PsychologicalSection_DepressionEvaluation_FK] FOREIGN KEY ([DepressionEvaluationKey]) REFERENCES [AssessmentModule].[DepressionEvaluation] ([DepressionEvaluationKey]),
    CONSTRAINT [PsychologicalSection_InterviewerRating_FK] FOREIGN KEY ([InterviewerRatingKey]) REFERENCES [AssessmentModule].[InterviewerRating] ([InterviewerRatingKey]),
    CONSTRAINT [PsychologicalSection_PsychologicalHistory_FK] FOREIGN KEY ([PsychologicalHistoryKey]) REFERENCES [AssessmentModule].[PsychologicalHistory] ([PsychologicalHistoryKey]),
    UNIQUE NONCLUSTERED ([DepressionEvaluationKey] ASC),
    UNIQUE NONCLUSTERED ([InterviewerRatingKey] ASC),
    UNIQUE NONCLUSTERED ([PsychologicalHistoryKey] ASC)
);
















GO



GO
CREATE NONCLUSTERED INDEX [PsychologicalSection_PsychologicalHistory_FK_IDX]
    ON [AssessmentModule].[PsychologicalSection]([PsychologicalHistoryKey] ASC);


GO
CREATE NONCLUSTERED INDEX [PsychologicalSection_InterviewerRating_FK_IDX]
    ON [AssessmentModule].[PsychologicalSection]([InterviewerRatingKey] ASC);


GO
CREATE NONCLUSTERED INDEX [PsychologicalSection_DepressionEvaluation_FK_IDX]
    ON [AssessmentModule].[PsychologicalSection]([DepressionEvaluationKey] ASC);

