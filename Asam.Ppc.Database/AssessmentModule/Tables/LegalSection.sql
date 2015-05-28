CREATE TABLE [AssessmentModule].[LegalSection] (
    [LegalSectionKey]                                               BIGINT          NOT NULL,
    [Version]                                                       INT             NOT NULL,
    [InterviewerComments]                                           NVARCHAR (2000) NULL,
    [IsCurrentlyAwaitingChargesTrialSentence]                       BIT             NULL,
    [IsOnProbationOrParole]                                         BIT             NULL,
    [IsPatientMisrepresentingInformation]                           BIT             NULL,
    [IsPatientUnableToUnderstand]                                   BIT             NULL,
    [LengthInMonthsOfLastIncarceration]                             BIGINT          NULL,
    [NumberOfDaysCommitingCrimesForProfitInPast30Days]              BIGINT          NULL,
    [NumberOfDaysIncarceratedInPast30Days]                          BIGINT          NULL,
    [NumberOfMonthsIncarceratedInLife]                              BIGINT          NULL,
    [NumberOfTimesArrestedForArson]                                 BIGINT          NULL,
    [NumberOfTimesArrestedForAssault]                               BIGINT          NULL,
    [NumberOfTimesArrestedForBurglaryLarceny]                       BIGINT          NULL,
    [NumberOfTimesArrestedForContemptOfCourt]                       BIGINT          NULL,
    [NumberOfTimesArrestedForDrugCharges]                           BIGINT          NULL,
    [NumberOfTimesArrestedForForgery]                               BIGINT          NULL,
    [NumberOfTimesArrestedForHomicide]                              BIGINT          NULL,
    [NumberOfTimesArrestedForOtherArrest]                           BIGINT          NULL,
    [NumberOfTimesArrestedForParoleProbationViolation]              BIGINT          NULL,
    [NumberOfTimesArrestedForProstitution]                          BIGINT          NULL,
    [NumberOfTimesArrestedForRape]                                  BIGINT          NULL,
    [NumberOfTimesArrestedForRobbery]                               BIGINT          NULL,
    [NumberOfTimesArrestedForShopliftingVandalism]                  BIGINT          NULL,
    [NumberOfTimesArrestedForWeaponsOffense]                        BIGINT          NULL,
    [NumberOfTimesChargedWithDisorderlyConductVagrancyIntoxication] BIGINT          NULL,
    [NumberOfTimesChargedWithDrivingWhileIntoxicated]               BIGINT          NULL,
    [NumberOfTimesChargedWithMajorDrivingViolations]                BIGINT          NULL,
    [NumberOfTimesConvicted]                                        BIGINT          NULL,
    [WasVisitPromptedByCriminalJusticeSystem]                       BIT             NULL,
    [IsVisited]                                                     BIT             NOT NULL,
    [CurrentlyAwaitingChargesTrialSentenceForLegalChargeCode]       NVARCHAR (200)  NULL,
    [CurrentlyAwaitingChargesTrialSentenceForLegalChargeName]       NVARCHAR (200)  NULL,
    [CurrentlyAwaitingChargesTrialSentenceForLegalChargeValue]      INT             NULL,
    [CurrentlyAwaitingChargesTrialSentenceForLegalChargeIsDefault]  BIT             NULL,
    [CurrentlyAwaitingChargesTrialSentenceForLegalChargeSortOrder]  INT             NULL,
    [DesireAndExternalFactorsDrivingTreatmentCode]                  NVARCHAR (200)  NULL,
    [DesireAndExternalFactorsDrivingTreatmentName]                  NVARCHAR (200)  NULL,
    [DesireAndExternalFactorsDrivingTreatmentValue]                 INT             NULL,
    [DesireAndExternalFactorsDrivingTreatmentIsDefault]             BIT             NULL,
    [DesireAndExternalFactorsDrivingTreatmentSortOrder]             INT             NULL,
    [ImportanceOfCounselingForCurrentLegalProblemsCode]             NVARCHAR (200)  NULL,
    [ImportanceOfCounselingForCurrentLegalProblemsName]             NVARCHAR (200)  NULL,
    [ImportanceOfCounselingForCurrentLegalProblemsValue]            INT             NULL,
    [ImportanceOfCounselingForCurrentLegalProblemsIsDefault]        BIT             NULL,
    [ImportanceOfCounselingForCurrentLegalProblemsSortOrder]        INT             NULL,
    [InterviewerRatingPatientNeedForLegalServiceCounselingValue]    BIGINT          NULL,
    [InterviewerRatingPatientNeedForLegalServiceCounselingMin]      BIGINT          NULL,
    [InterviewerRatingPatientNeedForLegalServiceCounselingMax]      BIGINT          NULL,
    [LastIncarcerationReasonCode]                                   NVARCHAR (200)  NULL,
    [LastIncarcerationReasonName]                                   NVARCHAR (200)  NULL,
    [LastIncarcerationReasonValue]                                  INT             NULL,
    [LastIncarcerationReasonIsDefault]                              BIT             NULL,
    [LastIncarcerationReasonSortOrder]                              INT             NULL,
    [SeverityOfCurrentLegalProblemsCode]                            NVARCHAR (200)  NULL,
    [SeverityOfCurrentLegalProblemsName]                            NVARCHAR (200)  NULL,
    [SeverityOfCurrentLegalProblemsValue]                           INT             NULL,
    [SeverityOfCurrentLegalProblemsIsDefault]                       BIT             NULL,
    [SeverityOfCurrentLegalProblemsSortOrder]                       INT             NULL,
    PRIMARY KEY CLUSTERED ([LegalSectionKey] ASC)
);




















GO


