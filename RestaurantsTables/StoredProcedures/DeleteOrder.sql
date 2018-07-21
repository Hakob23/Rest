CREATE PROCEDURE [dbo].[DeleteOrder]
	@Id int
AS
	Delete from dbo.Orders where Id = @Id

