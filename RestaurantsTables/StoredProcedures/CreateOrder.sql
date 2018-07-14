CREATE PROCEDURE [dbo].[CreateOrder]
	@TableId int,
	@Restaurant nvarchar(50),
	@OrderCategory nvarchar(50),
	@MealId int,
	@Quantity int,
	@Messege nvarchar(Max) = null
AS
	Insert into dbo.Orders values(@TableId, @Restaurant, @OrderCategory, @MealId, @Quantity, @Messege)
RETURN 0
