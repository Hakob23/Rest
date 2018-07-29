CREATE PROCEDURE [dbo].[uspGetAllRestaurants]
AS
	SELECT UserName  From dbo.Users Where Role = 'restaurant'
RETURN 0
