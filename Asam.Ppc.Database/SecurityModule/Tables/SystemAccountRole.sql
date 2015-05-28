CREATE TABLE [SecurityModule].[SystemAccountRole] (
    [SystemAccountRoleKey] BIGINT NOT NULL,
    [Version]              INT    NOT NULL,
    [RoleKey]              BIGINT NULL,
    [SystemAccountKey]     BIGINT NULL,
    PRIMARY KEY CLUSTERED ([SystemAccountRoleKey] ASC),
    CONSTRAINT [SystemAccountRole_Role_FK] FOREIGN KEY ([RoleKey]) REFERENCES [SecurityModule].[Role] ([RoleKey]),
    CONSTRAINT [SystemAccountRole_SystemAccount_FK] FOREIGN KEY ([SystemAccountKey]) REFERENCES [SecurityModule].[SystemAccount] ([SystemAccountKey])
);




GO
CREATE NONCLUSTERED INDEX [SystemAccountRole_SystemAccount_FK_IDX]
    ON [SecurityModule].[SystemAccountRole]([SystemAccountKey] ASC);


GO
CREATE NONCLUSTERED INDEX [SystemAccountRole_Role_FK_IDX]
    ON [SecurityModule].[SystemAccountRole]([RoleKey] ASC);

