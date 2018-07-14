CREATE PROCEDURE [dbo].[uspUpdateIsActivated]
	@id uniqueidentifier
AS
	update Users 
	set IsEmailVerifyed = 1
	where ActivationCode = @id
RETURN 0
