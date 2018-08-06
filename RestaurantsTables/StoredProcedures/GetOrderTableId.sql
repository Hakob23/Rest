CREATE PROCEDURE [dbo].[GetOrderTableId]
	@TableId int
AS
	SELECT * from dbo.Orders Where TableId = @TableId
RETURN 0
