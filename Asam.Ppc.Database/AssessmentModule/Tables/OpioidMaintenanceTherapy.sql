CREATE TABLE [AssessmentModule].[OpioidMaintenanceTherapy] (
    [OpioidMaintenanceTherapyKey]                               BIGINT         NOT NULL,
    [Version]                                                   INT            NOT NULL,
    [CompletedAtLeast6MonthOpioidMaintenanceTherapyVoluntarily] BIT            NULL,
    [DetoxificationEndedLessThanOrEqual2YearsAgo]               BIT            NULL,
    [GraduallyDetoxedFromOpioidMaintenanceTherapy]              BIT            NULL,
    [OpioidMaintenanceTherapyReadmissionMedicallyIndicated]     BIT            NULL,
    [PhysicianReasonsForOpioidMaintenanceTherapyReadmission]    NVARCHAR (255) NULL,
    [IsVisited]                                                 BIT            NOT NULL,
    [ToBePrescribedOpioidDetoxificationProtocolCode]            NVARCHAR (200) NULL,
    [ToBePrescribedOpioidDetoxificationProtocolName]            NVARCHAR (200) NULL,
    [ToBePrescribedOpioidDetoxificationProtocolValue]           INT            NULL,
    [ToBePrescribedOpioidDetoxificationProtocolIsDefault]       BIT            NULL,
    [ToBePrescribedOpioidDetoxificationProtocolSortOrder]       INT            NULL,
    PRIMARY KEY CLUSTERED ([OpioidMaintenanceTherapyKey] ASC)
);


















GO


