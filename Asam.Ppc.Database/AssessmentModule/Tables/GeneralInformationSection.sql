CREATE TABLE [AssessmentModule].[GeneralInformationSection] (
    [GeneralInformationSectionKey]                      BIGINT          NOT NULL,
    [Version]                                           INT             NOT NULL,
    [InPenalOrChronicCareSettingRecently]               BIT             NULL,
    [IsResidenceOwnedByPatientOrFamily]                 BIT             NULL,
    [NumberOfDaysInControlledEnvironmentInPast30Days]   BIGINT          NULL,
    [NumberOfMonthsAtCurrentAddress]                    BIGINT          NULL,
    [ControlledEnvironmentOtherDescription]             NVARCHAR (250)  NULL,
    [IntakeNotes]                                       NVARCHAR (2000) NULL,
    [IsVisited]                                         BIT             NOT NULL,
    [AssessmentClassCode]                               NVARCHAR (200)  NULL,
    [AssessmentClassName]                               NVARCHAR (200)  NULL,
    [AssessmentClassValue]                              INT             NULL,
    [AssessmentClassIsDefault]                          BIT             NULL,
    [AssessmentClassSortOrder]                          INT             NULL,
    [PatientInControlledEnvironmentLast30DaysCode]      NVARCHAR (200)  NULL,
    [PatientInControlledEnvironmentLast30DaysName]      NVARCHAR (200)  NULL,
    [PatientInControlledEnvironmentLast30DaysValue]     INT             NULL,
    [PatientInControlledEnvironmentLast30DaysIsDefault] BIT             NULL,
    [PatientInControlledEnvironmentLast30DaysSortOrder] INT             NULL,
    [InterviewCircumstancesCode]                        NVARCHAR (200)  NULL,
    [InterviewCircumstancesName]                        NVARCHAR (200)  NULL,
    [InterviewCircumstancesValue]                       INT             NULL,
    [InterviewCircumstancesIsDefault]                   BIT             NULL,
    [InterviewCircumstancesSortOrder]                   INT             NULL,
    [InterviewMethodCode]                               NVARCHAR (200)  NULL,
    [InterviewMethodName]                               NVARCHAR (200)  NULL,
    [InterviewMethodValue]                              INT             NULL,
    [InterviewMethodIsDefault]                          BIT             NULL,
    [InterviewMethodSortOrder]                          INT             NULL,
    PRIMARY KEY CLUSTERED ([GeneralInformationSectionKey] ASC)
);






















GO


