

CREATE PROCEDURE [dbo].[uspUpdateUser]
	@userId int,
	@email varchar(100),
	@password varchar(100),
	@phone varchar(50)
AS
	if @email != null
		update dbo.Users set Email = @email
	if @password != null
		update dbo.Users set Password = @password
	if @phone != null
		update dbo.Users set Phone = @phone

RETURN 0