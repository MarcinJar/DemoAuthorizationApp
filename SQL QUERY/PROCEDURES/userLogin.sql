CREATE PROCEDURE dbo.userLogin
    @pLoginName NVARCHAR(50),
    @pPassword VARCHAR(50),
    @responseMessage INT = 0 OUTPUT
AS
BEGIN

    SET NOCOUNT ON

    DECLARE @userID INT

    IF EXISTS (SELECT TOP 1 DBKey FROM [dbo].[User] WHERE [Login] = @pLoginName)
    BEGIN
       SET @userID=(SELECT TOP 1 DBKey FROM [dbo].[User] WHERE [Login] = @pLoginName AND [Password] = HASHBYTES('SHA2_512', @pPassword))

       IF(@userID IS NULL)
           SET @responseMessage=0
       ELSE 
           SET @responseMessage=1
    END

END

-- <> TEST PROCEDURE <> --

--DECLARE @RESULT INT
--EXEC dbo.userLogin N'Admin', N'12345a', @RESULT OUT
--PRINT @RESULT
--IF @RESULT = 1
--BEGIN
--	PRINT 'OK'
--END
--ELSE
--BEGIN
--	PRINT 'NOT OK'
--END
