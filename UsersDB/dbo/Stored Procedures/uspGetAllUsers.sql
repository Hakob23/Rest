
CREATE PROCEDURE [dbo].[uspGetAllUsers]
AS
	SELECT UserName,Email,Phone
			from dbo.Users
RETURN 0