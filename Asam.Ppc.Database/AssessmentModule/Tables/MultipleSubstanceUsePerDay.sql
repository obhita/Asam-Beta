CREATE TABLE [AssessmentModule].[MultipleSubstanceUsePerDay] (
    [MultipleSubstanceUsePerDayKey]          BIGINT         NOT NULL,
    [Version]                                INT            NOT NULL,
    [HasHealthCareProviderPrescribedUse]     BIT            NULL,
    [NumberOfDaysUsedInPast30Days]           BIGINT         NULL,
    [NumberOfMonthsUsedInLifetime]           BIGINT         NULL,
    [IsVisited]                              BIT            NOT NULL,
    [LastUsedUnitOfTime]                     NVARCHAR (50)  NULL,
    [LastUsedValue]                          BIGINT         NULL,
    [WasSubstanceTakenAsPrescribedCode]      NVARCHAR (200) NULL,
    [WasSubstanceTakenAsPrescribedName]      NVARCHAR (200) NULL,
    [WasSubstanceTakenAsPrescribedValue]     INT            NULL,
    [WasSubstanceTakenAsPrescribedIsDefault] BIT            NULL,
    [WasSubstanceTakenAsPrescribedSortOrder] INT            NULL,
    PRIMARY KEY CLUSTERED ([MultipleSubstanceUsePerDayKey] ASC)
);




















GO


