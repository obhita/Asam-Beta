CREATE TABLE [AssessmentModule].[DrugConsequences] (
    [DrugConsequencesKey]                                      BIGINT          NOT NULL,
    [Version]                                                  INT             NOT NULL,
    [NumberOfDaysExperiencedSubstanceProblemsInPast30Days]     BIGINT          NULL,
    [IsVisited]                                                BIT             NOT NULL,
    [AmountOfMoneySpentOnDrugsInPast30DaysAmount]              DECIMAL (19, 5) NULL,
    [AmountOfMoneySpentOnDrugsInPast30DaysCurrencyCultureName] NVARCHAR (100)  NULL,
    [AmountOfMoneySpentOnDrugsInPast30DaysCurrencyCode]        NVARCHAR (200)  NULL,
    [AmountOfMoneySpentOnDrugsInPast30DaysCurrencyName]        NVARCHAR (200)  NULL,
    [AmountOfMoneySpentOnDrugsInPast30DaysCurrencyValue]       INT             NULL,
    [AmountOfMoneySpentOnDrugsInPast30DaysCurrencyIsDefault]   BIT             NULL,
    [AmountOfMoneySpentOnDrugsInPast30DaysCurrencySortOrder]   INT             NULL,
    [ImportanceOfTreatmentForSubstanceProblemCode]             NVARCHAR (200)  NULL,
    [ImportanceOfTreatmentForSubstanceProblemName]             NVARCHAR (200)  NULL,
    [ImportanceOfTreatmentForSubstanceProblemValue]            INT             NULL,
    [ImportanceOfTreatmentForSubstanceProblemIsDefault]        BIT             NULL,
    [ImportanceOfTreatmentForSubstanceProblemSortOrder]        INT             NULL,
    [TroubledInLast30DaysBySubstanceProblemsCode]              NVARCHAR (200)  NULL,
    [TroubledInLast30DaysBySubstanceProblemsName]              NVARCHAR (200)  NULL,
    [TroubledInLast30DaysBySubstanceProblemsValue]             INT             NULL,
    [TroubledInLast30DaysBySubstanceProblemsIsDefault]         BIT             NULL,
    [TroubledInLast30DaysBySubstanceProblemsSortOrder]         INT             NULL,
    PRIMARY KEY CLUSTERED ([DrugConsequencesKey] ASC)
);






















GO


