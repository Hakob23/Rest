

CREATE PROCEDURE [dbo].[uspCreateUser]
	@userName nvarchar(50),
	@email varchar(100) = null,
	@password varchar(100),
	@phone varchar(50) = null,
	@isactive bit = 0,
	@IsEmailVerifyed bit = 0,
	@ActivationCode uniqueidentifier = null,
	@Role varchar(50)
AS
	if not exists (select Username from dbo.Users where Username = @username)
	if not exists (select Email from dbo.Users where Email = @email)
	insert into dbo.Users
		values (@username,@email,@password,@phone,@IsEmailVerifyed,@ActivationCode,@Role)

	return scope_identity()