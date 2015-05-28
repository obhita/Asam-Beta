CREATE TABLE [SecurityModule].[Role] (
    [RoleKey]              BIGINT             NOT NULL,
    [Version]              INT                NOT NULL,
    [Name]                 NVARCHAR (100)     NOT NULL,
    [RoleType]             NVARCHAR (50)      NOT NULL,
    [CreatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [CreatedSystemAccount] NVARCHAR (255)     NULL,
    [UpdatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [UpdatedSystemAccount] NVARCHAR (255)     NULL,
    [OrganizationKey]      BIGINT             NULL,
    PRIMARY KEY CLUSTERED ([RoleKey] ASC),
    CONSTRAINT [Role_Organization_FK] FOREIGN KEY ([OrganizationKey]) REFERENCES [OrganizationModule].[Organization] ([OrganizationKey])
);








GO



GO
CREATE NONCLUSTERED INDEX [Role_Organization_FK_IDX]
    ON [SecurityModule].[Role]([OrganizationKey] ASC);

