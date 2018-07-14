CREATE TABLE [dbo].[Orders]
(
	[Id] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [TableId] INT NOT NULL, 
    [Restaurant] NVARCHAR(50) NOT NULL, 
    [OrderCategory] NVARCHAR(50) NOT NULL, 
    [MealId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [Messege] NVARCHAR(MAX) NULL
)
