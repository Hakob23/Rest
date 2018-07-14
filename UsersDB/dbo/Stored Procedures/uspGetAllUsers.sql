
CREATE PROCEDURE [dbo].[uspGetAllUsers]
AS
	SELECT Username,Email,Phone
			from dbo.Users
RETURN 0