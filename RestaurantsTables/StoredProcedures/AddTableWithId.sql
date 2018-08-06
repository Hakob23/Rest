CREATE PROCEDURE [dbo].[AddTableWithId]
	@Id int,
	@RestName nvarchar(Max)
AS
	insert into dbo.RestTablesID values (@Id, @RestName)
RETURN 0
