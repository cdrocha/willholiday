CREATE PROCEDURE CambioPassword

@UsuarioEmail nvarchar(200),
@PasswordActual nvarchar(500),
@PasswordNuevo nvarchar(500)

AS

UPDATE Usuario 
SET UsuarioPassword = @PasswordNuevo 
WHERE UsuarioEmail = @UsuarioEmail 
AND UsuarioPassword = @PasswordActual