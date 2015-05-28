CREATE TABLE [AssessmentModule].[MedicalSectionMedicalProblems] (
    [MedicalSectionKey] BIGINT         NOT NULL,
    [Code]              NVARCHAR (200) NULL,
    [Name]              NVARCHAR (200) NULL,
    [Value]             INT            NULL,
    [IsDefault]         BIT            NULL,
    [SortOrder]         INT            NULL,
    CONSTRAINT [MedicalSectionMedicalProblems_MedicalSection_FK] FOREIGN KEY ([MedicalSectionKey]) REFERENCES [AssessmentModule].[MedicalSection] ([MedicalSectionKey])
);


GO
CREATE NONCLUSTERED INDEX [MedicalSectionMedicalProblems_MedicalSection_FK_IDX]
    ON [AssessmentModule].[MedicalSectionMedicalProblems]([MedicalSectionKey] ASC);

