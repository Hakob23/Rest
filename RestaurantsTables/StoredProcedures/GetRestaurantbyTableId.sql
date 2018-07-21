CREATE PROCEDURE [dbo].[GetRestaurantbyTableId]
	@TableId nvarchar(50)
AS
	Select * from dbo.RestTablesID where Id = @TableId
RETURN 0
