CREATE PROCEDURE [dbo].[AddTable]
	@restaurant nvarchar(50)
AS
	insert into dbo.RestTablesID(RestaurantName) values (@restaurant)
