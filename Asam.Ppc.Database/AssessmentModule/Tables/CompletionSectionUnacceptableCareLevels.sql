CREATE TABLE [AssessmentModule].[CompletionSectionUnacceptableCareLevels] (
    [CompletionSectionKey] BIGINT         NOT NULL,
    [Code]                 NVARCHAR (200) NULL,
    [Name]                 NVARCHAR (200) NULL,
    [Value]                INT            NULL,
    [IsDefault]            BIT            NULL,
    [SortOrder]            INT            NULL,
    CONSTRAINT [CompletionSectionUnacceptableCareLevels_CompletionSection_FK] FOREIGN KEY ([CompletionSectionKey]) REFERENCES [AssessmentModule].[CompletionSection] ([CompletionSectionKey])
);


GO
CREATE NONCLUSTERED INDEX [CompletionSectionUnacceptableCareLevels_CompletionSection_FK_IDX]
    ON [AssessmentModule].[CompletionSectionUnacceptableCareLevels]([CompletionSectionKey] ASC);

