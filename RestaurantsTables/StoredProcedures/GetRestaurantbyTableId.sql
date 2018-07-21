CREATE PROCEDURE [dbo].[GetRestaurantbyTableId]
	@TableId nvarchar(50)
AS
	Select RestaurantName from dbo.RestTablesID where TableID = @TableId
RETURN 0
