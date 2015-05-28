CREATE TABLE [AssessmentModule].[EmploymentAndSupportSection] (
    [EmploymentAndSupportSectionKey]                                    BIGINT          NOT NULL,
    [Version]                                                           INT             NOT NULL,
    [EducationInMonths]                                                 BIGINT          NULL,
    [HasAutomobileAvailableForUse]                                      BIT             NULL,
    [HasProfessionalTradeOrSkill]                                       BIT             NULL,
    [HasValidDriversLicense]                                            BIT             NULL,
    [InterviewerComments]                                               NVARCHAR (2000) NULL,
    [IsPatientMisrepresentingInformation]                               BIT             NULL,
    [IsPatientUnableToUnderstand]                                       BIT             NULL,
    [LongestTimeWithoutJobInMonths]                                     BIGINT          NULL,
    [NumberOfDaysWithEmploymentProblemsInPast30Days]                    BIGINT          NULL,
    [NumberOfDaysWorkingInPast30Days]                                   BIGINT          NULL,
    [NumberOfDependents]                                                BIGINT          NULL,
    [ProfessionalTradeOrSkillDescription]                               NVARCHAR (250)  NULL,
    [ReceivesFinancialSupportFromOtherPerson]                           BIT             NULL,
    [ReceivesMajorityOfFinancialSupportFromOtherPerson]                 BIT             NULL,
    [TrainingOrTechnicalEducationInMonths]                              BIGINT          NULL,
    [UsualOrLastOccupationDescription]                                  NVARCHAR (250)  NULL,
    [IsVisited]                                                         BIT             NOT NULL,
    [AmountOfMoneyInPast30DaysFromEmploymentAmount]                     DECIMAL (19, 5) NULL,
    [AmountOfMoneyInPast30DaysFromEmploymentCurrencyCultureName]        NVARCHAR (100)  NULL,
    [AmountOfMoneyInPast30DaysFromEmploymentCurrencyCode]               NVARCHAR (200)  NULL,
    [AmountOfMoneyInPast30DaysFromEmploymentCurrencyName]               NVARCHAR (200)  NULL,
    [AmountOfMoneyInPast30DaysFromEmploymentCurrencyValue]              INT             NULL,
    [AmountOfMoneyInPast30DaysFromEmploymentCurrencyIsDefault]          BIT             NULL,
    [AmountOfMoneyInPast30DaysFromEmploymentCurrencySortOrder]          INT             NULL,
    [AmountOfMoneyInPast30DaysFromIllegalMeansAmount]                   DECIMAL (19, 5) NULL,
    [AmountOfMoneyInPast30DaysFromIllegalMeansCurrencyCultureName]      NVARCHAR (100)  NULL,
    [AmountOfMoneyInPast30DaysFromIllegalMeansCurrencyCode]             NVARCHAR (200)  NULL,
    [AmountOfMoneyInPast30DaysFromIllegalMeansCurrencyName]             NVARCHAR (200)  NULL,
    [AmountOfMoneyInPast30DaysFromIllegalMeansCurrencyValue]            INT             NULL,
    [AmountOfMoneyInPast30DaysFromIllegalMeansCurrencyIsDefault]        BIT             NULL,
    [AmountOfMoneyInPast30DaysFromIllegalMeansCurrencySortOrder]        INT             NULL,
    [AmountOfMoneyInPast30DaysFromMateFamilyFriendsAmount]              DECIMAL (19, 5) NULL,
    [AmountOfMoneyInPast30DaysFromMateFamilyFriendsCurrencyCultureName] NVARCHAR (100)  NULL,
    [AmountOfMoneyInPast30DaysFromMateFamilyFriendsCurrencyCode]        NVARCHAR (200)  NULL,
    [AmountOfMoneyInPast30DaysFromMateFamilyFriendsCurrencyName]        NVARCHAR (200)  NULL,
    [AmountOfMoneyInPast30DaysFromMateFamilyFriendsCurrencyValue]       INT             NULL,
    [AmountOfMoneyInPast30DaysFromMateFamilyFriendsCurrencyIsDefault]   BIT             NULL,
    [AmountOfMoneyInPast30DaysFromMateFamilyFriendsCurrencySortOrder]   INT             NULL,
    [AmountOfMoneyInPast30DaysFromPensionOrBenefitsAmount]              DECIMAL (19, 5) NULL,
    [AmountOfMoneyInPast30DaysFromPensionOrBenefitsCurrencyCultureName] NVARCHAR (100)  NULL,
    [AmountOfMoneyInPast30DaysFromPensionOrBenefitsCurrencyCode]        NVARCHAR (200)  NULL,
    [AmountOfMoneyInPast30DaysFromPensionOrBenefitsCurrencyName]        NVARCHAR (200)  NULL,
    [AmountOfMoneyInPast30DaysFromPensionOrBenefitsCurrencyValue]       INT             NULL,
    [AmountOfMoneyInPast30DaysFromPensionOrBenefitsCurrencyIsDefault]   BIT             NULL,
    [AmountOfMoneyInPast30DaysFromPensionOrBenefitsCurrencySortOrder]   INT             NULL,
    [AmountOfMoneyInPast30DaysFromPublicAssistanceAmount]               DECIMAL (19, 5) NULL,
    [AmountOfMoneyInPast30DaysFromPublicAssistanceCurrencyCultureName]  NVARCHAR (100)  NULL,
    [AmountOfMoneyInPast30DaysFromPublicAssistanceCurrencyCode]         NVARCHAR (200)  NULL,
    [AmountOfMoneyInPast30DaysFromPublicAssistanceCurrencyName]         NVARCHAR (200)  NULL,
    [AmountOfMoneyInPast30DaysFromPublicAssistanceCurrencyValue]        INT             NULL,
    [AmountOfMoneyInPast30DaysFromPublicAssistanceCurrencyIsDefault]    BIT             NULL,
    [AmountOfMoneyInPast30DaysFromPublicAssistanceCurrencySortOrder]    INT             NULL,
    [AmountOfMoneyInPast30DaysFromUnemploymentAmount]                   DECIMAL (19, 5) NULL,
    [AmountOfMoneyInPast30DaysFromUnemploymentCurrencyCultureName]      NVARCHAR (100)  NULL,
    [AmountOfMoneyInPast30DaysFromUnemploymentCurrencyCode]             NVARCHAR (200)  NULL,
    [AmountOfMoneyInPast30DaysFromUnemploymentCurrencyName]             NVARCHAR (200)  NULL,
    [AmountOfMoneyInPast30DaysFromUnemploymentCurrencyValue]            INT             NULL,
    [AmountOfMoneyInPast30DaysFromUnemploymentCurrencyIsDefault]        BIT             NULL,
    [AmountOfMoneyInPast30DaysFromUnemploymentCurrencySortOrder]        INT             NULL,
    [ConcernAboutEmploymentProblemsInPast30DaysCode]                    NVARCHAR (200)  NULL,
    [ConcernAboutEmploymentProblemsInPast30DaysName]                    NVARCHAR (200)  NULL,
    [ConcernAboutEmploymentProblemsInPast30DaysValue]                   INT             NULL,
    [ConcernAboutEmploymentProblemsInPast30DaysIsDefault]               BIT             NULL,
    [ConcernAboutEmploymentProblemsInPast30DaysSortOrder]               INT             NULL,
    [EmploymentPatternInPast3YearsCode]                                 NVARCHAR (200)  NULL,
    [EmploymentPatternInPast3YearsName]                                 NVARCHAR (200)  NULL,
    [EmploymentPatternInPast3YearsValue]                                INT             NULL,
    [EmploymentPatternInPast3YearsIsDefault]                            BIT             NULL,
    [EmploymentPatternInPast3YearsSortOrder]                            INT             NULL,
    [ImportanceOfCounselingForEmploymentProblemsCode]                   NVARCHAR (200)  NULL,
    [ImportanceOfCounselingForEmploymentProblemsName]                   NVARCHAR (200)  NULL,
    [ImportanceOfCounselingForEmploymentProblemsValue]                  INT             NULL,
    [ImportanceOfCounselingForEmploymentProblemsIsDefault]              BIT             NULL,
    [ImportanceOfCounselingForEmploymentProblemsSortOrder]              INT             NULL,
    [InterviewerRatingPatientNeedForEmploymentCounselingValue]          BIGINT          NULL,
    [InterviewerRatingPatientNeedForEmploymentCounselingMin]            BIGINT          NULL,
    [InterviewerRatingPatientNeedForEmploymentCounselingMax]            BIGINT          NULL,
    [WorkOrSchoolAffectOnRecoveryCode]                                  NVARCHAR (200)  NULL,
    [WorkOrSchoolAffectOnRecoveryName]                                  NVARCHAR (200)  NULL,
    [WorkOrSchoolAffectOnRecoveryValue]                                 INT             NULL,
    [WorkOrSchoolAffectOnRecoveryIsDefault]                             BIT             NULL,
    [WorkOrSchoolAffectOnRecoverySortOrder]                             INT             NULL,
    PRIMARY KEY CLUSTERED ([EmploymentAndSupportSectionKey] ASC)
);
























GO


