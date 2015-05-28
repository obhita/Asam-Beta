INSERT [EhrModule].[Ehr]
  	( [EhrKey]
	  ,[Version]
      ,[Name]
      ,[EmailAddress]
      ,[SystemAccountKey]
      ,[SigningCertName]
      ,[DeactivatedDate]
      ,[CreatedTimestamp]
      ,[CreatedSystemAccount]
      ,[UpdatedTimestamp]
      ,[UpdatedSystemAccount])
   VALUES (1, 1, 'EhrTest', 'email@email.com', NULL, 'IdentityTKStsCert', NULL, GETDATE(), NULL, GETDATE(), NULL)
