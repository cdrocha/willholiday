CREATE PROCEDURE UsuarioExisteEmail

@UsuarioEmail nvarchar(200)

AS

SELECT * FROM Usuario 
WHERE UsuarioEmail = @UsuarioEmail