CREATE TABLE [PatientModule].[Patient] (
    [PatientKey]           BIGINT             NOT NULL,
    [Version]              INT                NOT NULL,
    [DateOfBirth]          DATETIME           NULL,
    [CreatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [CreatedSystemAccount] NVARCHAR (255)     NULL,
    [UpdatedTimestamp]     DATETIMEOFFSET (7) NOT NULL,
    [UpdatedSystemAccount] NVARCHAR (255)     NULL,
    [OrganizationKey]      BIGINT             NOT NULL,
    [NamePrefix]           NVARCHAR (255)     NULL,
    [NameFirstName]        NVARCHAR (100)     NOT NULL,
    [NameMiddleName]       NVARCHAR (100)     NULL,
    [NameLastName]         NVARCHAR (100)     NOT NULL,
    [NameSuffix]           NVARCHAR (255)     NULL,
    [GenderCode]           NVARCHAR (200)     NOT NULL,
    [GenderName]           NVARCHAR (200)     NOT NULL,
    [GenderValue]          INT                NOT NULL,
    [GenderIsDefault]      BIT                NOT NULL,
    [GenderSortOrder]      INT                NULL,
    [ReligionCode]         NVARCHAR (200)     NULL,
    [ReligionName]         NVARCHAR (200)     NULL,
    [ReligionValue]        INT                NULL,
    [ReligionIsDefault]    BIT                NULL,
    [ReligionSortOrder]    INT                NULL,
    [EthnicityCode]        NVARCHAR (200)     NULL,
    [EthnicityName]        NVARCHAR (200)     NULL,
    [EthnicityValue]       INT                NULL,
    [EthnicityIsDefault]   BIT                NULL,
    [EthnicitySortOrder]   INT                NULL,
    [TeamKey]              BIGINT             NULL,
    PRIMARY KEY CLUSTERED ([PatientKey] ASC),
    CONSTRAINT [Patient_Organization_FK] FOREIGN KEY ([OrganizationKey]) REFERENCES [OrganizationModule].[Organization] ([OrganizationKey]),
    CONSTRAINT [Patient_Team_FK] FOREIGN KEY ([TeamKey]) REFERENCES [OrganizationModule].[Team] ([TeamKey])
);
















GO
CREATE NONCLUSTERED INDEX [Patient_Team_FK_IDX]
    ON [PatientModule].[Patient]([TeamKey] ASC);


GO
CREATE NONCLUSTERED INDEX [Patient_Organization_FK_IDX]
    ON [PatientModule].[Patient]([OrganizationKey] ASC);

