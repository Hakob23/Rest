CREATE PROCEDURE [dbo].[GetTables]
	@restaurant nvarchar(50)
AS
	SELECT * from dbo.RestTablesID where RestaurantName = @restaurant
RETURN 0
