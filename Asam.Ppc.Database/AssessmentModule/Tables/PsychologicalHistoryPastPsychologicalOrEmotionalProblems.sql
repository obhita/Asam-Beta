CREATE TABLE [AssessmentModule].[PsychologicalHistoryPastPsychologicalOrEmotionalProblems] (
    [PsychologicalHistoryKey] BIGINT         NOT NULL,
    [Code]                    NVARCHAR (200) NULL,
    [Name]                    NVARCHAR (200) NULL,
    [Value]                   INT            NULL,
    [IsDefault]               BIT            NULL,
    [SortOrder]               INT            NULL,
    CONSTRAINT [PsychologicalHistoryPastPsychologicalOrEmotionalProblems_PsychologicalHistory_FK] FOREIGN KEY ([PsychologicalHistoryKey]) REFERENCES [AssessmentModule].[PsychologicalHistory] ([PsychologicalHistoryKey])
);


GO
CREATE NONCLUSTERED INDEX [PsychologicalHistoryPastPsychologicalOrEmotionalProblems_PsychologicalHistory_FK_IDX]
    ON [AssessmentModule].[PsychologicalHistoryPastPsychologicalOrEmotionalProblems]([PsychologicalHistoryKey] ASC);

