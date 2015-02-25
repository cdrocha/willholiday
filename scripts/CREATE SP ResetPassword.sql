CREATE PROCEDURE ResetPassword

@UsuarioEmail nvarchar(200),
@PasswordNuevo nvarchar(500)

AS

UPDATE Usuario 
SET UsuarioPassword = @PasswordNuevo 
WHERE UsuarioEmail = @UsuarioEmail 
