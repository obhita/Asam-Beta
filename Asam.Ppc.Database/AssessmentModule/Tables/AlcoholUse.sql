CREATE TABLE [AssessmentModule].[AlcoholUse] (
    [AlcoholUseKey]                                      BIGINT          NOT NULL,
    [Version]                                            INT             NOT NULL,
    [HasStrongUrges]                                     BIT             NULL,
    [AlcoholUsedToIntoxication]                          BIT             NULL,
    [HasHealthCareProviderPrescribedUse]                 BIT             NULL,
    [NumberOfDaysIntoxicatedInPast30Days]                BIGINT          NULL,
    [NumberOfDaysWithSubstanceProblemsInLast30Days]      BIGINT          NULL,
    [NumberOfMonthsAsAlcoholConsumerToIntoxication]      BIGINT          NULL,
    [NumberOfTimesWithdrawalCausedDeliriumTremens]       BIGINT          NULL,
    [NumberOfTimesWithdrawalCausedSeizures]              BIGINT          NULL,
    [ExperiencesWithdrawalSickness]                      BIT             NULL,
    [FrequentlyHighAtHome]                               BIT             NULL,
    [FrequentlyHighAtSchool]                             BIT             NULL,
    [FrequentlyHighAtWork]                               BIT             NULL,
    [FrequentlyHighInDangerousSituations]                BIT             NULL,
    [HasUsedSubstanceKnowingProblemsWorsened]            BIT             NULL,
    [IncreasedDoseRequiredToGetSameEffect]               BIT             NULL,
    [NumberOfDaysUsedInPast30Days]                       BIGINT          NULL,
    [NumberOfMonthsUsedInLifetime]                       BIGINT          NULL,
    [SubstanceUseRecurrentProblemsWithEmotions]          BIT             NULL,
    [SubstanceUseRecurrentProblemsWithFamilyFriends]     BIT             NULL,
    [SubstanceUseRecurrentProblemsWithHealth]            BIT             NULL,
    [SubstanceUseRecurrentProblemsWithJob]               BIT             NULL,
    [SubstanceUseRecurrentProblemsWithLegalSystem]       BIT             NULL,
    [SubstanceUseReductionAttempted]                     BIT             NULL,
    [SubstanceUseReductionInOccupationalActivities]      BIT             NULL,
    [SubstanceUseReductionInRecreationalActivities]      BIT             NULL,
    [SubstanceUseReductionInSocialActivities]            BIT             NULL,
    [UnableToStopUsingSubstance]                         BIT             NULL,
    [UseOfSubstanceTakesUpALotOfTime]                    BIT             NULL,
    [UseSubstanceToPreventWithdrawalSickness]            BIT             NULL,
    [IsVisited]                                          BIT             NOT NULL,
    [AlcoholRouteOfIntakeCode]                           NVARCHAR (200)  NULL,
    [AlcoholRouteOfIntakeName]                           NVARCHAR (200)  NULL,
    [AlcoholRouteOfIntakeValue]                          INT             NULL,
    [AlcoholRouteOfIntakeIsDefault]                      BIT             NULL,
    [AlcoholRouteOfIntakeSortOrder]                      INT             NULL,
    [AlcoholToIntoxicationRouteOfIntakeCode]             NVARCHAR (200)  NULL,
    [AlcoholToIntoxicationRouteOfIntakeName]             NVARCHAR (200)  NULL,
    [AlcoholToIntoxicationRouteOfIntakeValue]            INT             NULL,
    [AlcoholToIntoxicationRouteOfIntakeIsDefault]        BIT             NULL,
    [AlcoholToIntoxicationRouteOfIntakeSortOrder]        INT             NULL,
    [AmountOfMoneySpentInLast30DaysAmount]               DECIMAL (19, 5) NULL,
    [AmountOfMoneySpentInLast30DaysCurrencyCultureName]  NVARCHAR (100)  NULL,
    [AmountOfMoneySpentInLast30DaysCurrencyCode]         NVARCHAR (200)  NULL,
    [AmountOfMoneySpentInLast30DaysCurrencyName]         NVARCHAR (200)  NULL,
    [AmountOfMoneySpentInLast30DaysCurrencyValue]        INT             NULL,
    [AmountOfMoneySpentInLast30DaysCurrencyIsDefault]    BIT             NULL,
    [AmountOfMoneySpentInLast30DaysCurrencySortOrder]    INT             NULL,
    [ImportanceOfTreatmentForSubstanceProblemsCode]      NVARCHAR (200)  NULL,
    [ImportanceOfTreatmentForSubstanceProblemsName]      NVARCHAR (200)  NULL,
    [ImportanceOfTreatmentForSubstanceProblemsValue]     INT             NULL,
    [ImportanceOfTreatmentForSubstanceProblemsIsDefault] BIT             NULL,
    [ImportanceOfTreatmentForSubstanceProblemsSortOrder] INT             NULL,
    [LastUsedToIntoxificationUnitOfTime]                 NVARCHAR (50)   NULL,
    [LastUsedToIntoxificationValue]                      BIGINT          NULL,
    [TroubledInLast30DaysBySubstanceProblemsCode]        NVARCHAR (200)  NULL,
    [TroubledInLast30DaysBySubstanceProblemsName]        NVARCHAR (200)  NULL,
    [TroubledInLast30DaysBySubstanceProblemsValue]       INT             NULL,
    [TroubledInLast30DaysBySubstanceProblemsIsDefault]   BIT             NULL,
    [TroubledInLast30DaysBySubstanceProblemsSortOrder]   INT             NULL,
    [WasSubstanceTakenAsPrescribedCode]                  NVARCHAR (200)  NULL,
    [WasSubstanceTakenAsPrescribedName]                  NVARCHAR (200)  NULL,
    [WasSubstanceTakenAsPrescribedValue]                 INT             NULL,
    [WasSubstanceTakenAsPrescribedIsDefault]             BIT             NULL,
    [WasSubstanceTakenAsPrescribedSortOrder]             INT             NULL,
    [LastUsedUnitOfTime]                                 NVARCHAR (50)   NULL,
    [LastUsedValue]                                      BIGINT          NULL,
    PRIMARY KEY CLUSTERED ([AlcoholUseKey] ASC)
);




























GO


