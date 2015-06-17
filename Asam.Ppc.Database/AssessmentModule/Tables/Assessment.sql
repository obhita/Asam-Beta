CREATE TABLE [AssessmentModule].[Assessment] (
    [AssessmentKey]                    BIGINT             NOT NULL,
    [Version]                          INT                NOT NULL,
    [IsSubmitted]                      BIT                NOT NULL,
    [CompletedTimestamp]               DATETIMEOFFSET (7) NOT NULL,
    [CreatedTimestamp]                 DATETIMEOFFSET (7) NOT NULL,
    [CreatedSystemAccount]             NVARCHAR (255)     NULL,
    [UpdatedTimestamp]                 DATETIMEOFFSET (7) NOT NULL,
    [UpdatedSystemAccount]             NVARCHAR (255)     NULL,
    [CompletionSectionKey]             BIGINT             NULL,
    [DrugAndAlcoholSectionKey]         BIGINT             NULL,
    [EmploymentAndSupportSectionKey]   BIGINT             NULL,
    [FamilyAndSocialHistorySectionKey] BIGINT             NULL,
    [GeneralInformationSectionKey]     BIGINT             NULL,
    [LegalSectionKey]                  BIGINT             NULL,
    [MedicalSectionKey]                BIGINT             NULL,
    [PsychologicalSectionKey]          BIGINT             NULL,
    [PatientKey]                       BIGINT             NOT NULL,
    [ReviewSectionKey]                 BIGINT             NULL,
    PRIMARY KEY CLUSTERED ([AssessmentKey] ASC),
    CONSTRAINT [Assessment_CompletionSection_FK] FOREIGN KEY ([CompletionSectionKey]) REFERENCES [AssessmentModule].[CompletionSection] ([CompletionSectionKey]),
    CONSTRAINT [Assessment_DrugAndAlcoholSection_FK] FOREIGN KEY ([DrugAndAlcoholSectionKey]) REFERENCES [AssessmentModule].[DrugAndAlcoholSection] ([DrugAndAlcoholSectionKey]),
    CONSTRAINT [Assessment_EmploymentAndSupportSection_FK] FOREIGN KEY ([EmploymentAndSupportSectionKey]) REFERENCES [AssessmentModule].[EmploymentAndSupportSection] ([EmploymentAndSupportSectionKey]),
    CONSTRAINT [Assessment_FamilyAndSocialHistorySection_FK] FOREIGN KEY ([FamilyAndSocialHistorySectionKey]) REFERENCES [AssessmentModule].[FamilyAndSocialHistorySection] ([FamilyAndSocialHistorySectionKey]),
    CONSTRAINT [Assessment_GeneralInformationSection_FK] FOREIGN KEY ([GeneralInformationSectionKey]) REFERENCES [AssessmentModule].[GeneralInformationSection] ([GeneralInformationSectionKey]),
    CONSTRAINT [Assessment_LegalSection_FK] FOREIGN KEY ([LegalSectionKey]) REFERENCES [AssessmentModule].[LegalSection] ([LegalSectionKey]),
    CONSTRAINT [Assessment_MedicalSection_FK] FOREIGN KEY ([MedicalSectionKey]) REFERENCES [AssessmentModule].[MedicalSection] ([MedicalSectionKey]),
    CONSTRAINT [Assessment_Patient_FK] FOREIGN KEY ([PatientKey]) REFERENCES [PatientModule].[Patient] ([PatientKey]),
    CONSTRAINT [Assessment_PsychologicalSection_FK] FOREIGN KEY ([PsychologicalSectionKey]) REFERENCES [AssessmentModule].[PsychologicalSection] ([PsychologicalSectionKey]),
    CONSTRAINT [Assessment_ReviewSection_FK] FOREIGN KEY ([ReviewSectionKey]) REFERENCES [AssessmentModule].[ReviewSection] ([ReviewSectionKey]),
    UNIQUE NONCLUSTERED ([CompletionSectionKey] ASC),
    UNIQUE NONCLUSTERED ([DrugAndAlcoholSectionKey] ASC),
    UNIQUE NONCLUSTERED ([EmploymentAndSupportSectionKey] ASC),
    UNIQUE NONCLUSTERED ([FamilyAndSocialHistorySectionKey] ASC),
    UNIQUE NONCLUSTERED ([GeneralInformationSectionKey] ASC),
    UNIQUE NONCLUSTERED ([LegalSectionKey] ASC),
    UNIQUE NONCLUSTERED ([MedicalSectionKey] ASC),
    UNIQUE NONCLUSTERED ([PsychologicalSectionKey] ASC)
);












GO
CREATE NONCLUSTERED INDEX [Assessment_PsychologicalSection_FK_IDX]
    ON [AssessmentModule].[Assessment]([PsychologicalSectionKey] ASC);


GO
CREATE NONCLUSTERED INDEX [Assessment_Patient_FK_IDX]
    ON [AssessmentModule].[Assessment]([PatientKey] ASC);


GO
CREATE NONCLUSTERED INDEX [Assessment_MedicalSection_FK_IDX]
    ON [AssessmentModule].[Assessment]([MedicalSectionKey] ASC);


GO
CREATE NONCLUSTERED INDEX [Assessment_LegalSection_FK_IDX]
    ON [AssessmentModule].[Assessment]([LegalSectionKey] ASC);


GO
CREATE NONCLUSTERED INDEX [Assessment_GeneralInformationSection_FK_IDX]
    ON [AssessmentModule].[Assessment]([GeneralInformationSectionKey] ASC);


GO
CREATE NONCLUSTERED INDEX [Assessment_FamilyAndSocialHistorySection_FK_IDX]
    ON [AssessmentModule].[Assessment]([FamilyAndSocialHistorySectionKey] ASC);


GO
CREATE NONCLUSTERED INDEX [Assessment_EmploymentAndSupportSection_FK_IDX]
    ON [AssessmentModule].[Assessment]([EmploymentAndSupportSectionKey] ASC);


GO
CREATE NONCLUSTERED INDEX [Assessment_DrugAndAlcoholSection_FK_IDX]
    ON [AssessmentModule].[Assessment]([DrugAndAlcoholSectionKey] ASC);


GO
CREATE NONCLUSTERED INDEX [Assessment_CompletionSection_FK_IDX]
    ON [AssessmentModule].[Assessment]([CompletionSectionKey] ASC);


GO
CREATE NONCLUSTERED INDEX [Assessment_ReviewSection_FK_IDX]
    ON [AssessmentModule].[Assessment]([ReviewSectionKey] ASC);

