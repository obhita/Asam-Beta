CREATE TABLE [AssessmentModule].[OtherOpiateUse] (
    [OtherOpiateUseKey]                                BIGINT         NOT NULL,
    [Version]                                          INT            NOT NULL,
    [HasStrongUrges]                                   BIT            NULL,
    [DocumentedEvidenceOfOpioidDependenceAtLeast1Year] BIT            NULL,
    [EvidenceFromUrineScreenOfOpioidDependence]        BIT            NULL,
    [HasHealthCareProviderPrescribedUse]               BIT            NULL,
    [ReceivingOngoingMaintenanceTherapy]               BIT            NULL,
    [ExperiencesWithdrawalSickness]                    BIT            NULL,
    [FrequentlyHighAtHome]                             BIT            NULL,
    [FrequentlyHighAtSchool]                           BIT            NULL,
    [FrequentlyHighAtWork]                             BIT            NULL,
    [FrequentlyHighInDangerousSituations]              BIT            NULL,
    [HasUsedSubstanceKnowingProblemsWorsened]          BIT            NULL,
    [IncreasedDoseRequiredToGetSameEffect]             BIT            NULL,
    [NumberOfDaysUsedInPast30Days]                     BIGINT         NULL,
    [NumberOfMonthsUsedInLifetime]                     BIGINT         NULL,
    [SubstanceUseRecurrentProblemsWithEmotions]        BIT            NULL,
    [SubstanceUseRecurrentProblemsWithFamilyFriends]   BIT            NULL,
    [SubstanceUseRecurrentProblemsWithHealth]          BIT            NULL,
    [SubstanceUseRecurrentProblemsWithJob]             BIT            NULL,
    [SubstanceUseRecurrentProblemsWithLegalSystem]     BIT            NULL,
    [SubstanceUseReductionAttempted]                   BIT            NULL,
    [SubstanceUseReductionInOccupationalActivities]    BIT            NULL,
    [SubstanceUseReductionInRecreationalActivities]    BIT            NULL,
    [SubstanceUseReductionInSocialActivities]          BIT            NULL,
    [UnableToStopUsingSubstance]                       BIT            NULL,
    [UseOfSubstanceTakesUpALotOfTime]                  BIT            NULL,
    [UseSubstanceToPreventWithdrawalSickness]          BIT            NULL,
    [IsVisited]                                        BIT            NOT NULL,
    [OpioidRelapseLikelyIndicatorCode]                 NVARCHAR (200) NULL,
    [OpioidRelapseLikelyIndicatorName]                 NVARCHAR (200) NULL,
    [OpioidRelapseLikelyIndicatorValue]                INT            NULL,
    [OpioidRelapseLikelyIndicatorIsDefault]            BIT            NULL,
    [OpioidRelapseLikelyIndicatorSortOrder]            INT            NULL,
    [RouteOfIntakeCode]                                NVARCHAR (200) NULL,
    [RouteOfIntakeName]                                NVARCHAR (200) NULL,
    [RouteOfIntakeValue]                               INT            NULL,
    [RouteOfIntakeIsDefault]                           BIT            NULL,
    [RouteOfIntakeSortOrder]                           INT            NULL,
    [WasSubstanceTakenAsPrescribedCode]                NVARCHAR (200) NULL,
    [WasSubstanceTakenAsPrescribedName]                NVARCHAR (200) NULL,
    [WasSubstanceTakenAsPrescribedValue]               INT            NULL,
    [WasSubstanceTakenAsPrescribedIsDefault]           BIT            NULL,
    [WasSubstanceTakenAsPrescribedSortOrder]           INT            NULL,
    [LastUsedUnitOfTime]                               NVARCHAR (50)  NULL,
    [LastUsedValue]                                    BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([OtherOpiateUseKey] ASC)
);
























GO


