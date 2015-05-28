CREATE TABLE [OrganizationModule].[OrganizationPhone] (
    [OrganizationPhoneKey]           BIGINT         NOT NULL,
    [Version]                        INT            NOT NULL,
    [IsPrimary]                      BIT            NOT NULL,
    [OrganizationPhoneTypeCode]      NVARCHAR (200) NULL,
    [OrganizationPhoneTypeName]      NVARCHAR (200) NULL,
    [OrganizationPhoneTypeValue]     INT            NULL,
    [OrganizationPhoneTypeIsDefault] BIT            NULL,
    [OrganizationPhoneTypeSortOrder] INT            NULL,
    [PhoneExtension]                 NVARCHAR (255) NULL,
    [PhoneNumber]                    NVARCHAR (20)  NULL,
    [OrganizationKey]                BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([OrganizationPhoneKey] ASC),
    CONSTRAINT [OrganizationPhone_Organization_FK] FOREIGN KEY ([OrganizationKey]) REFERENCES [OrganizationModule].[Organization] ([OrganizationKey])
);




GO
CREATE NONCLUSTERED INDEX [OrganizationPhone_Organization_FK_IDX]
    ON [OrganizationModule].[OrganizationPhone]([OrganizationKey] ASC);

