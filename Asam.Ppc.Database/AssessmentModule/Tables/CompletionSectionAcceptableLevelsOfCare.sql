CREATE TABLE [AssessmentModule].[CompletionSectionAcceptableLevelsOfCare] (
    [CompletionSectionKey] BIGINT         NOT NULL,
    [Code]                 NVARCHAR (200) NULL,
    [Name]                 NVARCHAR (200) NULL,
    [Value]                INT            NULL,
    [IsDefault]            BIT            NULL,
    [SortOrder]            INT            NULL,
    CONSTRAINT [CompletionSectionAcceptableLevelsOfCare_CompletionSection_FK] FOREIGN KEY ([CompletionSectionKey]) REFERENCES [AssessmentModule].[CompletionSection] ([CompletionSectionKey])
);


GO
CREATE NONCLUSTERED INDEX [CompletionSectionAcceptableLevelsOfCare_CompletionSection_FK_IDX]
    ON [AssessmentModule].[CompletionSectionAcceptableLevelsOfCare]([CompletionSectionKey] ASC);

