CREATE PROCEDURE [dbo].[GetTables]
	@Restaurant nvarchar(50)
AS
	SELECT TableID from dbo.RestTablesID where RestaurantName = @Restaurant
RETURN 0
