CREATE TABLE [AssessmentModule].[InterviewerRatingActivePsychiatricDiagnosesOtherThanSubstanceAbuse] (
    [InterviewerRatingKey] BIGINT         NOT NULL,
    [Code]                 NVARCHAR (200) NULL,
    [Name]                 NVARCHAR (200) NULL,
    [Value]                INT            NULL,
    [IsDefault]            BIT            NULL,
    [SortOrder]            INT            NULL,
    CONSTRAINT [InterviewerRatingActivePsychiatricDiagnosesOtherThanSubstanceAbuse_InterviewerRating_FK] FOREIGN KEY ([InterviewerRatingKey]) REFERENCES [AssessmentModule].[InterviewerRating] ([InterviewerRatingKey])
);


GO
CREATE NONCLUSTERED INDEX [InterviewerRatingActivePsychiatricDiagnosesOtherThanSubstanceAbuse_InterviewerRating_FK_IDX]
    ON [AssessmentModule].[InterviewerRatingActivePsychiatricDiagnosesOtherThanSubstanceAbuse]([InterviewerRatingKey] ASC);

