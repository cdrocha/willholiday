CREATE PROCEDURE [dbo].[InsertarUsuario]
	@Password NVARCHAR(500),
	@Email NVARCHAR(500)
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS(SELECT UsuarioID FROM Usuario WHERE UsuarioEmail = @Email)
	BEGIN
		SELECT -2 -- Existe el email.
	END
	ELSE
	BEGIN
		INSERT INTO [Usuario]
			   ([UsuarioEmail]
			   ,[UsuarioPassword]
			   ,[FechaAlta])
		VALUES
			   (@Email
			   ,@Password
			   ,GETDATE())
		
		SELECT SCOPE_IDENTITY() -- UsuarioID			   
     END
END
