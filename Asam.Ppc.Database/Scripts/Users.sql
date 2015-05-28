CREATE USER [$(UserLogin)] FOR LOGIN [$(UserLogin)]

exec sp_addrolemember 'db_owner', [$(UserLogin)]