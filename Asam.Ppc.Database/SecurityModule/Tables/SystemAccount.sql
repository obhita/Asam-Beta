CREATE TABLE [SecurityModule].[SystemAccount] (
    [SystemAccountKey]     BIGINT             NOT NULL,
    [Version]              INT                NOT NULL,
    [Identifier]           NVARCHAR (255)     NOT NULL,
    [IsSystemAdmin]        BIT                NOT NULL,
    [LastLogin]            DATETIME           NULL,
    [CreatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [CreatedSystemAccount] NVARCHAR (255)     NULL,
    [UpdatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [UpdatedSystemAccount] NVARCHAR (255)     NULL,
    [OrganizationKey]      BIGINT             NULL,
    [StaffKey]             BIGINT             NULL,
    [EmailAddress]         NVARCHAR (255)     NULL,
    [EulaAgreeDate] DATETIME NULL, 
    PRIMARY KEY CLUSTERED ([SystemAccountKey] ASC),
    CONSTRAINT [SystemAccount_Organization_FK] FOREIGN KEY ([OrganizationKey]) REFERENCES [OrganizationModule].[Organization] ([OrganizationKey]),
    CONSTRAINT [SystemAccount_Staff_FK] FOREIGN KEY ([StaffKey]) REFERENCES [OrganizationModule].[Staff] ([StaffKey])
);










GO
CREATE NONCLUSTERED INDEX [SystemAccount_Staff_FK_IDX]
    ON [SecurityModule].[SystemAccount]([StaffKey] ASC);


GO
CREATE NONCLUSTERED INDEX [SystemAccount_Organization_FK_IDX]
    ON [SecurityModule].[SystemAccount]([OrganizationKey] ASC);

