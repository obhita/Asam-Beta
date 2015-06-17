CREATE TABLE [OrganizationModule].[Organization] (
    [OrganizationKey]      BIGINT             NOT NULL,
    [Version]              INT                NOT NULL,
    [Name]                 NVARCHAR (100)     NOT NULL,
    [CreatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [CreatedSystemAccount] NVARCHAR (255)     NULL,
    [UpdatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [UpdatedSystemAccount] NVARCHAR (255)     NULL,
    PRIMARY KEY CLUSTERED ([OrganizationKey] ASC)
);

