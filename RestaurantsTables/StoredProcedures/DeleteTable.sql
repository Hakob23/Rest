CREATE PROCEDURE [dbo].[DeleteTable]
	@Id int
AS
	delete from dbo.RestTablesID where (Id = @Id)
RETURN 0
