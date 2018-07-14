CREATE PROCEDURE [dbo].[UpdateOrderQuantity]
	@Quantity int,
	@Id int
AS
	Update dbo.Orders set Quantity = @Quantity where Id = @Id 
RETURN 0
