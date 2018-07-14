CREATE TABLE [dbo].[AlcoholDrinks]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Price] FLOAT NOT NULL, 
    [Alcohol] FLOAT NOT NULL, 
    [Volume] FLOAT NOT NULL, 
    [Restaurant] NVARCHAR(50) NOT NULL
)
