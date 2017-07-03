CREATE PROCEDURE dbo.userLogin
    @pLoginName NVARCHAR(50),
    @pPassword VARCHAR(50),
    @responseMessage INT = 0 OUTPUT,
	@role NVARCHAR(50) = '' OUTPUT,
	@name NVARCHAR(200) = '' OUTPUT
AS
BEGIN

    SET NOCOUNT ON

    DECLARE @userID INT

    IF EXISTS (SELECT TOP 1 DBKey FROM [dbo].[User] WHERE [Login] = @pLoginName)
    BEGIN
       SET @userID = (SELECT TOP 1 DBKey FROM [dbo].[User] WHERE [Login] = @pLoginName AND [Password] = HASHBYTES('SHA2_512', @pPassword))
	   SET @role = (SELECT RoleName FROM [dbo].[Role] WHERE DBKey = @userID)
	   SET @name = (SELECT TOP 1 [Name] FROM [dbo].[User] WHERE DBKey = @userID)

       IF(@userID IS NULL)
           SET @responseMessage=0
       ELSE 
           SET @responseMessage=1
    END

END

-- <> TEST PROCEDURE <> --

--DECLARE @RESULT INT
--DECLARE @ROLEd NVARCHAR(50)
--DECLARE @name NVARCHAR(50)
--EXEC dbo.userLogin N'Admin', N'12345a', @RESULT OUT, @ROLEd OUT, @name OUT
--PRINT @RESULT
--PRINT @ROLEd
--PRINT @name
--IF @RESULT = 1
--BEGIN
--	PRINT 'OK'
--END
--ELSE
--BEGIN
--	PRINT 'NOT OK'
--END
