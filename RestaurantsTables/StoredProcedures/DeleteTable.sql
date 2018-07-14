CREATE PROCEDURE [dbo].[DeleteTable]
	@restaurant nvarchar(50),
	@Id int
AS
	delete from dbo.RestTablesID where (RestaurantName = @restaurant) and (Id = @Id)
RETURN 0
