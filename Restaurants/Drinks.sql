CREATE TABLE [dbo].[Drinks]
(
	[Id] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Price] FLOAT NOT NULL, 
    [Volume] FLOAT NULL, 
    [Restaurant] NCHAR(10) NOT NULL
)
