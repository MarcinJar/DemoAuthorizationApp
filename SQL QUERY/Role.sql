CREATE TABLE [Role] (
	DBKey		INT IDENTITY(1,1),
	RoleName	NVARCHAR(50),
	CONSTRAINT PK_Role PRIMARY KEY (DBKey)
)

--INSERT INTO Role (RoleName) VALUES('Admin');
--INSERT INTO Role (RoleName) VALUES('User');

--UPDATE Role SET RoleName = 'User' WHERE DBKey = 2; 

SELECT * FROM Role