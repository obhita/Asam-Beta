CREATE TABLE [ScoringModule].[CommonScores] (
    [CommonScoresKey]                                           BIGINT     NOT NULL,
    [Version]                                                   INT        NOT NULL,
    [MinimumDaysSinceLastUsedDrugExceptNicotine]                FLOAT (53) NOT NULL,
    [DaysSinceLastUsedNicotine]                                 FLOAT (53) NOT NULL,
    [NumberOfCuadScaleSumGreaterThanOneExceptNicotine]          INT        NOT NULL,
    [MaxCuadScaleSumForOneDrugExceptNicotine]                   INT        NOT NULL,
    [NicotineCuadScaleSum]                                      INT        NOT NULL,
    [WithdrawalSymptomsAndEmotionalBehavioralProblems]          BIT        NULL,
    [CiwaScore]                                                 INT        NOT NULL,
    [CinaScore]                                                 INT        NOT NULL,
    [WhichSubstenceEverUsedHasEverUsedAlcohol]                  BIT        NULL,
    [WhichSubstenceEverUsedHasEverUsedHeroin]                   BIT        NULL,
    [WhichSubstenceEverUsedHasEverUsedMethadone]                BIT        NULL,
    [WhichSubstenceEverUsedHasEverUsedOtherOpiate]              BIT        NULL,
    [WhichSubstenceEverUsedHasEverUsedBarbiturates]             BIT        NULL,
    [WhichSubstenceEverUsedHasEverUsedOtherSedatives]           BIT        NULL,
    [WhichSubstenceEverUsedHasEverUsedCocaine]                  BIT        NULL,
    [WhichSubstenceEverUsedHasEverUsedStimulate]                BIT        NULL,
    [WhichSubstenceEverUsedHasEverUsedCannabis]                 BIT        NULL,
    [WhichSubstenceEverUsedHasEverUsedHallucinogens]            BIT        NULL,
    [WhichSubstenceEverUsedHasEverUsedSolventInhalants]         BIT        NULL,
    [WhichSubstenceEverUsedHasEverUsedMultipleSubstancesPerDay] BIT        NULL,
    [WhichSubstenceEverUsedHasEverUsedNicotine]                 BIT        NULL,
    [WhichSubstenceEverUsedHasEverUsedOtherSubstance]           BIT        NULL,
    PRIMARY KEY CLUSTERED ([CommonScoresKey] ASC)
);










GO


