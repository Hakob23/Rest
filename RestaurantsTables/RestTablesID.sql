CREATE TABLE [dbo].[RestTablesID]
(
	[Id] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [RestaurantName] NVARCHAR(50) NOT NULL, 
    [TableID] INT NOT NULL unique
)
