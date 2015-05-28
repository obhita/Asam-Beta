CREATE TABLE [OrganizationModule].[Staff] (
    [StaffKey]             BIGINT             NOT NULL,
    [Version]              INT                NOT NULL,
    [Location]             NVARCHAR (255)     NULL,
    [NPI]                  NVARCHAR (255)     NULL,
    [CreatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [CreatedSystemAccount] NVARCHAR (255)     NULL,
    [UpdatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [UpdatedSystemAccount] NVARCHAR (255)     NULL,
    [OrganizationKey]      BIGINT             NOT NULL,
    [EmailAddress]         NVARCHAR (255)     NULL,
    [NamePrefix]           NVARCHAR (255)     NULL,
    [NameFirstName]        NVARCHAR (100)     NOT NULL,
    [NameMiddleName]       NVARCHAR (100)     NULL,
    [NameLastName]         NVARCHAR (100)     NOT NULL,
    [NameSuffix]           NVARCHAR (255)     NULL,
    [TeamKey]              BIGINT             NULL,
    PRIMARY KEY CLUSTERED ([StaffKey] ASC),
    CONSTRAINT [Staff_Organization_FK] FOREIGN KEY ([OrganizationKey]) REFERENCES [OrganizationModule].[Organization] ([OrganizationKey]),
    CONSTRAINT [Staff_Team_FK] FOREIGN KEY ([TeamKey]) REFERENCES [OrganizationModule].[Team] ([TeamKey])
);




GO
CREATE NONCLUSTERED INDEX [Staff_Team_FK_IDX]
    ON [OrganizationModule].[Staff]([TeamKey] ASC);


GO
CREATE NONCLUSTERED INDEX [Staff_Organization_FK_IDX]
    ON [OrganizationModule].[Staff]([OrganizationKey] ASC);

