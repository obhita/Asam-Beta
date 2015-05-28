CREATE TABLE [AssessmentModule].[UsedSubstancesSubstanceHasEverUsed] (
    [UsedSubstancesKey] BIGINT         NOT NULL,
    [Code]              NVARCHAR (200) NULL,
    [Name]              NVARCHAR (200) NULL,
    [Value]             INT            NULL,
    [IsDefault]         BIT            NULL,
    [SortOrder]         INT            NULL,
    CONSTRAINT [UsedSubstancesSubstanceHasEverUsed_UsedSubstances_FK] FOREIGN KEY ([UsedSubstancesKey]) REFERENCES [AssessmentModule].[UsedSubstances] ([UsedSubstancesKey])
);


GO
CREATE NONCLUSTERED INDEX [UsedSubstancesSubstanceHasEverUsed_UsedSubstances_FK_IDX]
    ON [AssessmentModule].[UsedSubstancesSubstanceHasEverUsed]([UsedSubstancesKey] ASC);

