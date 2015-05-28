INSERT [OrganizationModule].[Organization] VALUES ( 1, 1, 'Safe Harbor', 1, '7LL3KCGXVSJNFUZET35OZKNEU5FE6UHP7IADIQFS', GETDATE(), null, GETDATE(), null )

INSERT [OrganizationModule].[Staff] VALUES ( 1, 1, null, '123456', GetDate(), null, GetDate(), null, 1, 'leo.smith@safeharbor1x1.com', null, 'Leo', null, 'Smith', null, null)

INSERT [SecurityModule].[SystemAccount] VALUES ( 1, 1, 'leo.smith@safeharbor1x1.com', 0, null, GETDATE(), null, GETDATE(), null, 1, 1, 'leo.smith@safeharbor1x1.com', null)

INSERT [SecurityModule].[Role] VALUES ( 1, 1, 'OrganizationAdmin', 'UserDefined', GETDATE(), null, GETDATE(), null, 1)

INSERT [SecurityModule].[SystemAccountRole] VALUES( 1, 1, 1, 1)

INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 1 , 1, 1, 1 )
INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 2 , 1, 1, 2 )
INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 3 , 1, 1, 3 )
INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 4 , 1, 1, 4 )
INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 5 , 1, 1, 5 )
INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 6 , 1, 1, 6 )
INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 7 , 1, 1, 7 )
INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 8 , 1, 1, 8 )
INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 9 , 1, 1, 9 )
INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 10, 1, 1, 10)
INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 11, 1, 1, 11)
INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 12, 1, 1, 12)
INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 13, 1, 1, 13)
INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 14, 1, 1, 14)
INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 16, 1, 1, 16)
INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 17, 1, 1, 17)
INSERT [SecurityModule].[RoleSystemPermission] VALUES ( 19, 1, 1, 19)

