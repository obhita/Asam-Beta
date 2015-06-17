CREATE TABLE [AssessmentModule].[OpiatesInControlledEnvironment] (
    [OpiatesInControlledEnvironmentKey]                      BIGINT NOT NULL,
    [Version]                                                INT    NOT NULL,
    [ExperiencesWithdrawalSickness]                          BIT    NULL,
    [IncreasedDoseRequiredToGetSameEffect]                   BIT    NULL,
    [TakenNaltrexoneOrNaloxoneDuringWithdrawalInPast48Hours] BIT    NULL,
    [UseSubstanceToPreventWithdrawalSickness]                BIT    NULL,
    [IsVisited]                                              BIT    NOT NULL,
    PRIMARY KEY CLUSTERED ([OpiatesInControlledEnvironmentKey] ASC)
);














GO


