CREATE TABLE [dbo].[Pizzas]
(
	[Id] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Price] FLOAT NOT NULL, 
    [[Content]]] NVARCHAR(MAX) NULL, 
    [Diametr] INT NULL, 
    [Restaurant] NVARCHAR(50) NOT NULL
)
