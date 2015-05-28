CREATE TABLE [EhrModule].[Ehr] (
    [EhrKey]               BIGINT             NOT NULL,
    [Version]              INT                NOT NULL,
    [Name]                 NVARCHAR (100)     NOT NULL,
    [SigningCertName]      NVARCHAR (100)     NOT NULL,
    [EmailAddress]         NVARCHAR (255)     NOT NULL,
    [SystemAccountKey]     BIGINT             NULL,
    [DeactivatedDate]      DATE               NULL,
    [CreatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [CreatedSystemAccount] NVARCHAR (255)     NULL,
    [UpdatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [UpdatedSystemAccount] NVARCHAR (255)     NULL,
    PRIMARY KEY CLUSTERED ([EhrKey] ASC)
);






