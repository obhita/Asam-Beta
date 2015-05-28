CREATE TABLE [SecurityModule].[RoleSystemPermission] (
    [RoleSystemPermissionKey] BIGINT NOT NULL,
    [Version]                 INT    NOT NULL,
    [RoleKey]                 BIGINT NULL,
    [SystemPermissionKey]     BIGINT NULL,
    PRIMARY KEY CLUSTERED ([RoleSystemPermissionKey] ASC),
    CONSTRAINT [RoleSystemPermission_Role_FK] FOREIGN KEY ([RoleKey]) REFERENCES [SecurityModule].[Role] ([RoleKey]),
    CONSTRAINT [RoleSystemPermission_SystemPermission_FK] FOREIGN KEY ([SystemPermissionKey]) REFERENCES [SecurityModule].[SystemPermission] ([SystemPermissionKey])
);




GO
CREATE NONCLUSTERED INDEX [RoleSystemPermission_SystemPermission_FK_IDX]
    ON [SecurityModule].[RoleSystemPermission]([SystemPermissionKey] ASC);


GO
CREATE NONCLUSTERED INDEX [RoleSystemPermission_Role_FK_IDX]
    ON [SecurityModule].[RoleSystemPermission]([RoleKey] ASC);

