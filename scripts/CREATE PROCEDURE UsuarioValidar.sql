CREATE  PROCEDURE [dbo].[UsuarioValidar]
	@UsuarioEmail NVARCHAR(200),
	@UsuarioPassword NVARCHAR(500)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @UsuarioID INT, @LastLoginDate DATETIME
	
	SELECT @UsuarioID = UsuarioID, @LastLoginDate = LastLoginDate 
	FROM Usuario WHERE UsuarioEmail = @UsuarioEmail AND [UsuarioPassword] = @UsuarioPassword
	
	IF @UsuarioID IS NOT NULL
	BEGIN
		IF NOT EXISTS(SELECT UsuarioID FROM UsuarioActivacion WHERE UsuarioID = @UsuarioID)
		BEGIN
			UPDATE Usuario
			SET LastLoginDate =  GETDATE()
			WHERE UsuarioID = @UsuarioID
			SELECT @UsuarioID [UsuarioID] -- Usuario válido.
		END
		ELSE
		BEGIN
			SELECT -2 -- Usuario no activado.
		END
	END
	ELSE
	BEGIN
		SELECT -1 -- Usuario invalido.
	END
END