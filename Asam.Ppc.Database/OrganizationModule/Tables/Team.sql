CREATE TABLE [OrganizationModule].[Team] (
    [TeamKey]              BIGINT             NOT NULL,
    [Version]              INT                NOT NULL,
    [Name]                 NVARCHAR (100)     NOT NULL,
    [CreatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [CreatedSystemAccount] NVARCHAR (255)     NULL,
    [UpdatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [UpdatedSystemAccount] NVARCHAR (255)     NULL,
    [OrganizationKey]      BIGINT             NOT NULL,
    PRIMARY KEY CLUSTERED ([TeamKey] ASC),
    CONSTRAINT [Team_Organization_FK] FOREIGN KEY ([OrganizationKey]) REFERENCES [OrganizationModule].[Organization] ([OrganizationKey])
);


GO
CREATE NONCLUSTERED INDEX [Team_Organization_FK_IDX]
    ON [OrganizationModule].[Team]([OrganizationKey] ASC);

