CREATE TABLE [AssessmentModule].[CiwaScale] (
    [CiwaScaleKey]                                BIGINT         NOT NULL,
    [Version]                                     INT            NOT NULL,
    [IsVisited]                                   BIT            NOT NULL,
    [ExperiencedNauseaOrVomitedRecentlyCode]      NVARCHAR (200) NULL,
    [ExperiencedNauseaOrVomitedRecentlyName]      NVARCHAR (200) NULL,
    [ExperiencedNauseaOrVomitedRecentlyValue]     INT            NULL,
    [ExperiencedNauseaOrVomitedRecentlyIsDefault] BIT            NULL,
    [ExperiencedNauseaOrVomitedRecentlySortOrder] INT            NULL,
    [HadDeliriumTremorsInPast24HoursCode]         NVARCHAR (200) NULL,
    [HadDeliriumTremorsInPast24HoursName]         NVARCHAR (200) NULL,
    [HadDeliriumTremorsInPast24HoursValue]        INT            NULL,
    [HadDeliriumTremorsInPast24HoursIsDefault]    BIT            NULL,
    [HadDeliriumTremorsInPast24HoursSortOrder]    INT            NULL,
    [HeadAcheOrFullnessSeverityCode]              NVARCHAR (200) NULL,
    [HeadAcheOrFullnessSeverityName]              NVARCHAR (200) NULL,
    [HeadAcheOrFullnessSeverityValue]             INT            NULL,
    [HeadAcheOrFullnessSeverityIsDefault]         BIT            NULL,
    [HeadAcheOrFullnessSeveritySortOrder]         INT            NULL,
    [ObservedNervousnessCode]                     NVARCHAR (200) NULL,
    [ObservedNervousnessName]                     NVARCHAR (200) NULL,
    [ObservedNervousnessValue]                    INT            NULL,
    [ObservedNervousnessIsDefault]                BIT            NULL,
    [ObservedNervousnessSortOrder]                INT            NULL,
    [ObservedSweatingCode]                        NVARCHAR (200) NULL,
    [ObservedSweatingName]                        NVARCHAR (200) NULL,
    [ObservedSweatingValue]                       INT            NULL,
    [ObservedSweatingIsDefault]                   BIT            NULL,
    [ObservedSweatingSortOrder]                   INT            NULL,
    [ObservedTactileDisturbancesCode]             NVARCHAR (200) NULL,
    [ObservedTactileDisturbancesName]             NVARCHAR (200) NULL,
    [ObservedTactileDisturbancesValue]            INT            NULL,
    [ObservedTactileDisturbancesIsDefault]        BIT            NULL,
    [ObservedTactileDisturbancesSortOrder]        INT            NULL,
    [ObservedTremorCode]                          NVARCHAR (200) NULL,
    [ObservedTremorName]                          NVARCHAR (200) NULL,
    [ObservedTremorValue]                         INT            NULL,
    [ObservedTremorIsDefault]                     BIT            NULL,
    [ObservedTremorSortOrder]                     INT            NULL,
    PRIMARY KEY CLUSTERED ([CiwaScaleKey] ASC)
);


















GO


