CREATE TABLE [OrganizationModule].[OrganizationAddress] (
    [OrganizationAddressKey]           BIGINT         NOT NULL,
    [Version]                          INT            NOT NULL,
    [IsPrimary]                        BIT            NOT NULL,
    [AddressCityName]                  NVARCHAR (100) NULL,
    [AddressFirstStreetAddress]        NVARCHAR (255) NULL,
    [AddressSecondStreetAddress]       NVARCHAR (255) NULL,
    [AddressStateProvinceCode]         NVARCHAR (200) NULL,
    [AddressStateProvinceName]         NVARCHAR (200) NULL,
    [AddressStateProvinceValue]        INT            NULL,
    [AddressStateProvinceIsDefault]    BIT            NULL,
    [AddressStateProvinceSortOrder]    INT            NULL,
    [AddressPostalCode]                NVARCHAR (10)  NULL,
    [OrganizationAddressTypeCode]      NVARCHAR (200) NULL,
    [OrganizationAddressTypeName]      NVARCHAR (200) NULL,
    [OrganizationAddressTypeValue]     INT            NULL,
    [OrganizationAddressTypeIsDefault] BIT            NULL,
    [OrganizationAddressTypeSortOrder] INT            NULL,
    [OrganizationKey]                  BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([OrganizationAddressKey] ASC),
    CONSTRAINT [OrganizationAddress_Organization_FK] FOREIGN KEY ([OrganizationKey]) REFERENCES [OrganizationModule].[Organization] ([OrganizationKey])
);


GO
CREATE NONCLUSTERED INDEX [OrganizationAddress_Organization_FK_IDX]
    ON [OrganizationModule].[OrganizationAddress]([OrganizationKey] ASC);

