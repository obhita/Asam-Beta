CREATE TABLE [SecurityModule].[SystemPermission] (
    [SystemPermissionKey] BIGINT         NOT NULL,
    [Version]             INT            NOT NULL,
    [WellKnownName]       NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([SystemPermissionKey] ASC)
);




GO


