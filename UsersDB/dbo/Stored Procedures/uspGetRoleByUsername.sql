CREATE PROCEDURE [dbo].[uspGetRoleByUsername]
	@username nvarchar(50)
AS
	SELECT Role From dbo.Users Where UserName = @username
RETURN 0
