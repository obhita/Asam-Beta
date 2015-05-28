CREATE TABLE [AssessmentModule].[AssessmentMetaData] (
    [AssessmentMetaDataKey] BIGINT             NOT NULL,
    [Version]               INT                NOT NULL,
    [AssessmentKey]         BIGINT             NOT NULL,
    [MetaDataKey]           NVARCHAR (255)     NOT NULL,
    [MetaDataValue]         NVARCHAR (50)      NOT NULL,
    [CreatedTimestamp]      DATETIMEOFFSET (7) NOT NULL,
    [CreatedSystemAccount]  NVARCHAR (255)     NULL,
    [UpdatedTimestamp]      DATETIMEOFFSET (7) NOT NULL,
    [UpdatedSystemAccount]  NVARCHAR (255)     NULL,
    PRIMARY KEY CLUSTERED ([AssessmentMetaDataKey] ASC)
);

