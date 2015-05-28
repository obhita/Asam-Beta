CREATE TABLE [OrganizationModule].[OrganizationApiKey] (
    [OrganizationApiKeyKey] BIGINT         NOT NULL,
    [Version]               INT            NOT NULL,
    [Name]                  NVARCHAR (100) NULL,
    [ApiKey]                NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([OrganizationApiKeyKey] ASC)
);

