CREATE PROCEDURE [dbo].[CreateOrder]
	@TableId int,
	@Restaurant nvarchar(50),
	@OrderCategory nvarchar(50),
	@MealId int,
	@Quantity int,
	@Messege nvarchar(Max) = null,
	@Address nvarchar(Max) = null,
	@Price	int
AS
	Insert into dbo.Orders values(@TableId, @Restaurant, @OrderCategory, @MealId, @Quantity, @Messege, @Address,@Price)
RETURN 0
