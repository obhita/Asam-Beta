CREATE TABLE [AssessmentModule].[AlcoholAndDrugInterviewerRating] (
    [AlcoholAndDrugInterviewerRatingKey]                    BIGINT          NOT NULL,
    [Version]                                               INT             NOT NULL,
    [InterviewerComments]                                   NVARCHAR (2000) NULL,
    [IsPatientMisrepresentingInformation]                   BIT             NULL,
    [IsPatientUnableToUnderstand]                           BIT             NULL,
    [MajorityOfInformationFromCollateralSource]             BIT             NULL,
    [PatientManifestingSeriousRelapseBehaviorDescription]   NVARCHAR (250)  NULL,
    [PatientManifestingSeriousRelapseBehaviors]             BIT             NULL,
    [IsVisited]                                             BIT             NOT NULL,
    [InterviewerScoreOfAlcoholTreatmentNeedValue]           BIGINT          NULL,
    [InterviewerScoreOfAlcoholTreatmentNeedMin]             BIGINT          NULL,
    [InterviewerScoreOfAlcoholTreatmentNeedMax]             BIGINT          NULL,
    [InterviewerScoreOfAttitudeValue]                       BIGINT          NULL,
    [InterviewerScoreOfAttitudeMin]                         BIGINT          NULL,
    [InterviewerScoreOfAttitudeMax]                         BIGINT          NULL,
    [InterviewerScoreOfDrugTreatmentNeedValue]              BIGINT          NULL,
    [InterviewerScoreOfDrugTreatmentNeedMin]                BIGINT          NULL,
    [InterviewerScoreOfDrugTreatmentNeedMax]                BIGINT          NULL,
    [InterviewerScoreOfReadinessValue]                      BIGINT          NULL,
    [InterviewerScoreOfReadinessMin]                        BIGINT          NULL,
    [InterviewerScoreOfReadinessMax]                        BIGINT          NULL,
    [IsPatientExperiencingWithdrawalSignsSymptomsCode]      NVARCHAR (200)  NULL,
    [IsPatientExperiencingWithdrawalSignsSymptomsName]      NVARCHAR (200)  NULL,
    [IsPatientExperiencingWithdrawalSignsSymptomsValue]     INT             NULL,
    [IsPatientExperiencingWithdrawalSignsSymptomsIsDefault] BIT             NULL,
    [IsPatientExperiencingWithdrawalSignsSymptomsSortOrder] INT             NULL,
    PRIMARY KEY CLUSTERED ([AlcoholAndDrugInterviewerRatingKey] ASC)
);




















GO


