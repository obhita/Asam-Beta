INSERT [SecurityModule].[SystemAccount] VALUES ( 2, 1, 'asamapiuser@feisystems.com', 0, null, GETDATE(), null, GETDATE(), null, null, null, 'asamapiuser@feisystems.com', null)

-- rolekey, version, name, roletype, createdtimestamp, createdsystemaccount, updatedtimestampt, updatedsystemaccount, organizationkey
INSERT [SecurityModule].[Role] VALUES ( 2, 1, 'ApiUser', 'UserDefined', GETDATE(), null, GETDATE(), null, null)

--systemaccountrolekey, version, rolekey, systemaccountkey
INSERT [SecurityModule].[SystemAccountRole] VALUES(2, 1, 2, 2)

-- rolesystempermissionkey, version, rolekey, systempermissionkey
INSERT [SecurityModule].[RoleSystemPermission] VALUES (20, 1, 2, 2) -- insert assessmentmodule/assessmentedit
INSERT [SecurityModule].[RoleSystemPermission] VALUES (21, 1, 2, 3) -- insert assessmentmodule/assessmentview
INSERT [SecurityModule].[RoleSystemPermission] VALUES (22, 1, 2, 20) -- insert singlesignonmodule/singlesignonview
INSERT [SecurityModule].[RoleSystemPermission] VALUES (23, 1, 2, 1) -- insert infrastructuremodule/accessuserinterface

