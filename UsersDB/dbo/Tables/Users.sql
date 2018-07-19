CREATE TABLE [dbo].[Users] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [UserName]   NVARCHAR (50) NOT NULL,
    [Email]      VARCHAR (100) NULL,
    [Password]   VARCHAR (100) NOT NULL,
    [Phone]      VARCHAR (50)  NULL,
    [IsEmailVerifyed] BIT NULL, 
    [ActivationCode] UNIQUEIDENTIFIER NULL, 
    [Role] VARCHAR(50) NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);



