CREATE PROCEDURE [dbo].[GetTables]
	@restaurant nvarchar(50)
AS
	SELECT TableID from dbo.RestTablesID where RestaurantName = @restaurant
RETURN 0
