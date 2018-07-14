CREATE PROCEDURE [dbo].[AddTable]
	@restaurant nvarchar(50),
	@tableid int
AS
	insert into dbo.RestTablesID values (@restaurant, @tableid)
RETURN 0
