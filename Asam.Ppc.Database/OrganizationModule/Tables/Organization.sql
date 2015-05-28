CREATE TABLE [OrganizationModule].[Organization] (
    [OrganizationKey]      BIGINT             NOT NULL,
    [Version]              INT                NOT NULL,
    [Name]                 NVARCHAR (100)     NOT NULL,
    [EhrKey]               BIGINT             NOT NULL,
    [ApiKey]               NVARCHAR (255)     NULL,
    [CreatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [CreatedSystemAccount] NVARCHAR (255)     NULL,
    [UpdatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [UpdatedSystemAccount] NVARCHAR (255)     NULL,
    PRIMARY KEY CLUSTERED ([OrganizationKey] ASC),
    CONSTRAINT [Organization_Ehr_FK] FOREIGN KEY ([EhrKey]) REFERENCES [EhrModule].[Ehr] ([EhrKey])
);


GO
CREATE NONCLUSTERED INDEX [Organization_Ehr_FK_IDX]
    ON [OrganizationModule].[Organization]([EhrKey] ASC);

