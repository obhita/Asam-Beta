CREATE TABLE [AssessmentModule].[NicotineUse] (
    [NicotineUseKey]                                 BIGINT         NOT NULL,
    [Version]                                        INT            NOT NULL,
    [HasStrongUrges]                                 BIT            NULL,
    [HasHealthCareProviderPrescribedUse]             BIT            NULL,
    [ExperiencesWithdrawalSickness]                  BIT            NULL,
    [FrequentlyHighAtHome]                           BIT            NULL,
    [FrequentlyHighAtSchool]                         BIT            NULL,
    [FrequentlyHighAtWork]                           BIT            NULL,
    [FrequentlyHighInDangerousSituations]            BIT            NULL,
    [HasUsedSubstanceKnowingProblemsWorsened]        BIT            NULL,
    [IncreasedDoseRequiredToGetSameEffect]           BIT            NULL,
    [NumberOfDaysUsedInPast30Days]                   BIGINT         NULL,
    [NumberOfMonthsUsedInLifetime]                   BIGINT         NULL,
    [SubstanceUseRecurrentProblemsWithEmotions]      BIT            NULL,
    [SubstanceUseRecurrentProblemsWithFamilyFriends] BIT            NULL,
    [SubstanceUseRecurrentProblemsWithHealth]        BIT            NULL,
    [SubstanceUseRecurrentProblemsWithJob]           BIT            NULL,
    [SubstanceUseRecurrentProblemsWithLegalSystem]   BIT            NULL,
    [SubstanceUseReductionAttempted]                 BIT            NULL,
    [SubstanceUseReductionInOccupationalActivities]  BIT            NULL,
    [SubstanceUseReductionInRecreationalActivities]  BIT            NULL,
    [SubstanceUseReductionInSocialActivities]        BIT            NULL,
    [UnableToStopUsingSubstance]                     BIT            NULL,
    [UseOfSubstanceTakesUpALotOfTime]                BIT            NULL,
    [UseSubstanceToPreventWithdrawalSickness]        BIT            NULL,
    [IsVisited]                                      BIT            NOT NULL,
    [NicotineRouteOfIntakeCode]                      NVARCHAR (200) NULL,
    [NicotineRouteOfIntakeName]                      NVARCHAR (200) NULL,
    [NicotineRouteOfIntakeValue]                     INT            NULL,
    [NicotineRouteOfIntakeIsDefault]                 BIT            NULL,
    [NicotineRouteOfIntakeSortOrder]                 INT            NULL,
    [WasSubstanceTakenAsPrescribedCode]              NVARCHAR (200) NULL,
    [WasSubstanceTakenAsPrescribedName]              NVARCHAR (200) NULL,
    [WasSubstanceTakenAsPrescribedValue]             INT            NULL,
    [WasSubstanceTakenAsPrescribedIsDefault]         BIT            NULL,
    [WasSubstanceTakenAsPrescribedSortOrder]         INT            NULL,
    [LastUsedUnitOfTime]                             NVARCHAR (50)  NULL,
    [LastUsedValue]                                  BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([NicotineUseKey] ASC)
);
























GO


