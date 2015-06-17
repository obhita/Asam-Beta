CREATE TABLE [AssessmentModule].[AdditionalAddictionAndTreatmentItems] (
    [AdditionalAddictionAndTreatmentItemsKey]                       BIGINT         NOT NULL,
    [Version]                                                       INT            NOT NULL,
    [NumberOfMonthsSinceAbstinenceEndFromSubstance]                 BIGINT         NULL,
    [NumberOfMonthsSinceLastVoluntaryAbstinenceFromSubstance]       BIGINT         NULL,
    [NumberOfTimesOverdosedOnDrugs]                                 BIGINT         NULL,
    [IsVisited]                                                     BIT            NOT NULL,
    [AddictionSymptomsIncreasedRecentlyCode]                        NVARCHAR (200) NULL,
    [AddictionSymptomsIncreasedRecentlyName]                        NVARCHAR (200) NULL,
    [AddictionSymptomsIncreasedRecentlyValue]                       INT            NULL,
    [AddictionSymptomsIncreasedRecentlyIsDefault]                   BIT            NULL,
    [AddictionSymptomsIncreasedRecentlySortOrder]                   INT            NULL,
    [ConcernsAboutPursuingTreatmentCode]                            NVARCHAR (200) NULL,
    [ConcernsAboutPursuingTreatmentName]                            NVARCHAR (200) NULL,
    [ConcernsAboutPursuingTreatmentValue]                           INT            NULL,
    [ConcernsAboutPursuingTreatmentIsDefault]                       BIT            NULL,
    [ConcernsAboutPursuingTreatmentSortOrder]                       INT            NULL,
    [CurrentStrengthOfSubstanceUseDesireCode]                       NVARCHAR (200) NULL,
    [CurrentStrengthOfSubstanceUseDesireName]                       NVARCHAR (200) NULL,
    [CurrentStrengthOfSubstanceUseDesireValue]                      INT            NULL,
    [CurrentStrengthOfSubstanceUseDesireIsDefault]                  BIT            NULL,
    [CurrentStrengthOfSubstanceUseDesireSortOrder]                  INT            NULL,
    [FeelLikelyToContinueSubstanceUseOrRelapseCode]                 NVARCHAR (200) NULL,
    [FeelLikelyToContinueSubstanceUseOrRelapseName]                 NVARCHAR (200) NULL,
    [FeelLikelyToContinueSubstanceUseOrRelapseValue]                INT            NULL,
    [FeelLikelyToContinueSubstanceUseOrRelapseIsDefault]            BIT            NULL,
    [FeelLikelyToContinueSubstanceUseOrRelapseSortOrder]            INT            NULL,
    [HelpfulnessOfTreatmentCode]                                    NVARCHAR (200) NULL,
    [HelpfulnessOfTreatmentName]                                    NVARCHAR (200) NULL,
    [HelpfulnessOfTreatmentValue]                                   INT            NULL,
    [HelpfulnessOfTreatmentIsDefault]                               BIT            NULL,
    [HelpfulnessOfTreatmentSortOrder]                               INT            NULL,
    [LikelihoodPreviousEnvironmentWillInduceSubstanceUseCode]       NVARCHAR (200) NULL,
    [LikelihoodPreviousEnvironmentWillInduceSubstanceUseName]       NVARCHAR (200) NULL,
    [LikelihoodPreviousEnvironmentWillInduceSubstanceUseValue]      INT            NULL,
    [LikelihoodPreviousEnvironmentWillInduceSubstanceUseIsDefault]  BIT            NULL,
    [LikelihoodPreviousEnvironmentWillInduceSubstanceUseSortOrder]  INT            NULL,
    [PossibleFutureRelapseCauseCode]                                NVARCHAR (200) NULL,
    [PossibleFutureRelapseCauseName]                                NVARCHAR (200) NULL,
    [PossibleFutureRelapseCauseValue]                               INT            NULL,
    [PossibleFutureRelapseCauseIsDefault]                           BIT            NULL,
    [PossibleFutureRelapseCauseSortOrder]                           INT            NULL,
    [StrategyToPreventRelapseCode]                                  NVARCHAR (200) NULL,
    [StrategyToPreventRelapseName]                                  NVARCHAR (200) NULL,
    [StrategyToPreventRelapseValue]                                 INT            NULL,
    [StrategyToPreventRelapseIsDefault]                             BIT            NULL,
    [StrategyToPreventRelapseSortOrder]                             INT            NULL,
    [StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggersCode]      NVARCHAR (200) NULL,
    [StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggersName]      NVARCHAR (200) NULL,
    [StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggersValue]     INT            NULL,
    [StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggersIsDefault] BIT            NULL,
    [StrengthOfSubstanceUseUrgeDueToEnvironmentalTriggersSortOrder] INT            NULL,
    [SubstanceOverdoseInPast24HoursCode]                            NVARCHAR (200) NULL,
    [SubstanceOverdoseInPast24HoursName]                            NVARCHAR (200) NULL,
    [SubstanceOverdoseInPast24HoursValue]                           INT            NULL,
    [SubstanceOverdoseInPast24HoursIsDefault]                       BIT            NULL,
    [SubstanceOverdoseInPast24HoursSortOrder]                       INT            NULL,
    [WhichSubstanceIsMajorProblemCode]                              NVARCHAR (200) NULL,
    [WhichSubstanceIsMajorProblemName]                              NVARCHAR (200) NULL,
    [WhichSubstanceIsMajorProblemValue]                             INT            NULL,
    [WhichSubstanceIsMajorProblemIsDefault]                         BIT            NULL,
    [WhichSubstanceIsMajorProblemSortOrder]                         INT            NULL,
    PRIMARY KEY CLUSTERED ([AdditionalAddictionAndTreatmentItemsKey] ASC)
);


















GO


