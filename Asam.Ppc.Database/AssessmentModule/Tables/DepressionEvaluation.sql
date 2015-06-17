CREATE TABLE [AssessmentModule].[DepressionEvaluation] (
    [DepressionEvaluationKey]                         BIGINT         NOT NULL,
    [Version]                                         INT            NOT NULL,
    [IsVisited]                                       BIT            NOT NULL,
    [ObservedRetardationOfThoughtOrSpeechCode]        NVARCHAR (200) NULL,
    [ObservedRetardationOfThoughtOrSpeechName]        NVARCHAR (200) NULL,
    [ObservedRetardationOfThoughtOrSpeechValue]       INT            NULL,
    [ObservedRetardationOfThoughtOrSpeechIsDefault]   BIT            NULL,
    [ObservedRetardationOfThoughtOrSpeechSortOrder]   INT            NULL,
    [RangeOfEnergyInPastWeekCode]                     NVARCHAR (200) NULL,
    [RangeOfEnergyInPastWeekName]                     NVARCHAR (200) NULL,
    [RangeOfEnergyInPastWeekValue]                    INT            NULL,
    [RangeOfEnergyInPastWeekIsDefault]                BIT            NULL,
    [RangeOfEnergyInPastWeekSortOrder]                INT            NULL,
    [RangeOfGuiltInPastWeekCode]                      NVARCHAR (200) NULL,
    [RangeOfGuiltInPastWeekName]                      NVARCHAR (200) NULL,
    [RangeOfGuiltInPastWeekValue]                     INT            NULL,
    [RangeOfGuiltInPastWeekIsDefault]                 BIT            NULL,
    [RangeOfGuiltInPastWeekSortOrder]                 INT            NULL,
    [RangeOfInterestInDoingThingsInPastWeekCode]      NVARCHAR (200) NULL,
    [RangeOfInterestInDoingThingsInPastWeekName]      NVARCHAR (200) NULL,
    [RangeOfInterestInDoingThingsInPastWeekValue]     INT            NULL,
    [RangeOfInterestInDoingThingsInPastWeekIsDefault] BIT            NULL,
    [RangeOfInterestInDoingThingsInPastWeekSortOrder] INT            NULL,
    [RangeOfIrritabilityInPastWeekCode]               NVARCHAR (200) NULL,
    [RangeOfIrritabilityInPastWeekName]               NVARCHAR (200) NULL,
    [RangeOfIrritabilityInPastWeekValue]              INT            NULL,
    [RangeOfIrritabilityInPastWeekIsDefault]          BIT            NULL,
    [RangeOfIrritabilityInPastWeekSortOrder]          INT            NULL,
    [RangeOfMoodInPastWeekCode]                       NVARCHAR (200) NULL,
    [RangeOfMoodInPastWeekName]                       NVARCHAR (200) NULL,
    [RangeOfMoodInPastWeekValue]                      INT            NULL,
    [RangeOfMoodInPastWeekIsDefault]                  BIT            NULL,
    [RangeOfMoodInPastWeekSortOrder]                  INT            NULL,
    PRIMARY KEY CLUSTERED ([DepressionEvaluationKey] ASC)
);


















GO


