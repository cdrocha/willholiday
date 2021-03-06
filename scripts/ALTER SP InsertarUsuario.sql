
ALTER PROCEDURE [dbo].[InsertarUsuario]
	@Password NVARCHAR(500),
	@Email NVARCHAR(500)
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS(SELECT UsuarioID FROM Usuario WHERE UsuarioEmail = @Email and FacebookID is null)
	BEGIN
		SELECT -2 -- Existe el email y no ingresó con facebook.
	END
	-- Si existe el email porque ya se registró con facebook, actualizo el password y la fecha de ultimo ingreso.
	ELSE IF EXISTS(SELECT UsuarioID FROM Usuario WHERE UsuarioEmail = @Email and FacebookID is not null)
	BEGIN
		update Usuario set LastLoginDate = GETDATE() WHERE UsuarioEmail = @Email
		-- Actualizo el password solo si el login anterior fue mediante facebook.
		update Usuario set UsuarioPassword = @Password WHERE UsuarioEmail = @Email and UsuarioPassword is null
		SELECT  UsuarioID FROM Usuario WHERE UsuarioEmail = @Email -- Devuelvo el id del usuario.
	END
	ELSE
	-- El email no existe en la base, asi que creo el usuario.
	BEGIN
		INSERT INTO [Usuario]
			   ([UsuarioEmail]
			   ,[UsuarioPassword]
			   ,[FechaAlta]
			   ,[LastLoginDate])
		VALUES
			   (@Email
			   ,@Password
			   ,GETDATE()
			   ,GETDATE()
			   )
		
		SELECT SCOPE_IDENTITY() -- UsuarioID			   
		
		
		-- Falta crear el perfil del usuario. Hay que definir como manejamos los campos obligatorios y de donde vienen los datos.
     END
END
