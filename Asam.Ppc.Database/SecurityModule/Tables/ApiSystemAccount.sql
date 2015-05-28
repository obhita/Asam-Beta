CREATE TABLE [SecurityModule].[ApiSystemAccount] (
    [ApiSystemAccountKey]     BIGINT             NOT NULL,
    [Version]              INT                NOT NULL,
    [CreatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [CreatedSystemAccount] NVARCHAR (255)     NULL,
    [UpdatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [UpdatedSystemAccount] NVARCHAR (255)     NULL,
    [EhrId]             BIGINT             NULL,
    [OrganizationKey]      BIGINT             NULL,
    [UserId]         NVARCHAR (255)     NULL,
    [UserName] NVARCHAR(255) NULL, 
    [UserEmail] NVARCHAR(255) NULL, 
    [EulaAgreeDate] DATETIME NULL 
    PRIMARY KEY CLUSTERED ([ApiSystemAccountKey] ASC),
    CONSTRAINT [ApiSystemAccount_Organization_FK] FOREIGN KEY ([OrganizationKey]) REFERENCES [OrganizationModule].[Organization] ([OrganizationKey]),
);










