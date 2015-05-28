CREATE TABLE [BillingModule].[BillingTransaction] (
    [BillingTransactionKey] BIGINT             NOT NULL,
    [Version]               INT                NOT NULL,
    [EhrKey]                BIGINT             NOT NULL,
    [OrganizationKey]       BIGINT             NOT NULL,
    [UserName]              NVARCHAR (100)     NULL,
    [UserEmail]             NVARCHAR (255)     NULL,
    [MethodName]            NVARCHAR (100)     NULL,
    [Parameters]            NVARCHAR (4000)    NULL,
    [CreatedTimestamp]      DATETIMEOFFSET (7) NOT NULL,
    [CreatedSystemAccount]  NVARCHAR (255)     NULL,
    [UpdatedTimestamp]      DATETIMEOFFSET (7) NOT NULL,
    [UpdatedSystemAccount]  NVARCHAR (255)     NULL,
    PRIMARY KEY CLUSTERED ([BillingTransactionKey] ASC)
);









