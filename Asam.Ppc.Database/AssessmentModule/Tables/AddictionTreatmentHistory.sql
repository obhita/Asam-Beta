CREATE TABLE [AssessmentModule].[AddictionTreatmentHistory] (
    [AddictionTreatmentHistoryKey]                            BIGINT         NOT NULL,
    [Version]                                                 INT            NOT NULL,
    [NumberOfDaysOutpatientTreatmentInPast30Days]             BIGINT         NULL,
    [NumberOfTimesAlcoholTreatmentDetoxificationOnlyLifetime] BIGINT         NULL,
    [NumberOfTimesDrugTreatmentDetoxificationOnlyLifetime]    BIGINT         NULL,
    [NumberOfTimesDrugTreatmentLifetime]                      BIGINT         NULL,
    [NumberOfTimesTreatedForAlcoholAbuseLifetime]             BIGINT         NULL,
    [UsuallyEnteredContinuedTreatmentAfterDetoxification]     BIT            NULL,
    [UsuallyLeftDetoxificationBeforeAdvised]                  BIT            NULL,
    [IsVisited]                                               BIT            NOT NULL,
    [HighestCareLevelFailedFromInPast90DaysCode]              NVARCHAR (200) NULL,
    [HighestCareLevelFailedFromInPast90DaysName]              NVARCHAR (200) NULL,
    [HighestCareLevelFailedFromInPast90DaysValue]             INT            NULL,
    [HighestCareLevelFailedFromInPast90DaysIsDefault]         BIT            NULL,
    [HighestCareLevelFailedFromInPast90DaysSortOrder]         INT            NULL,
    [MostRecentCareLevelCompletedCode]                        NVARCHAR (200) NULL,
    [MostRecentCareLevelCompletedName]                        NVARCHAR (200) NULL,
    [MostRecentCareLevelCompletedValue]                       INT            NULL,
    [MostRecentCareLevelCompletedIsDefault]                   BIT            NULL,
    [MostRecentCareLevelCompletedSortOrder]                   INT            NULL,
    [PreviousSubstanceUseTreatmentCode]                       NVARCHAR (200) NULL,
    [PreviousSubstanceUseTreatmentName]                       NVARCHAR (200) NULL,
    [PreviousSubstanceUseTreatmentValue]                      INT            NULL,
    [PreviousSubstanceUseTreatmentIsDefault]                  BIT            NULL,
    [PreviousSubstanceUseTreatmentSortOrder]                  INT            NULL,
    PRIMARY KEY CLUSTERED ([AddictionTreatmentHistoryKey] ASC)
);


















GO


