--El login de facebook devuelve siempre los datos del usuario. Este script verifica si ya existe en nuestra BD. Si existe devuelve el id nuestro y sino lo crea
if(exists(select 1 from sys.objects where name = 'FacebookLogin'))
begin
drop procedure FacebookLogin
end
go


CREATE PROCEDURE FacebookLogin
	@FacebookID NVARCHAR(255),
	@Email NVARCHAR(200),
	@PerfilNombre nvarchar(50),
	@PerfilApellido nvarchar(50),
	@PerfilSexo nchar(1),
	@PerfilFoto nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS(SELECT UsuarioID FROM Usuario WHERE FacebookID = @FacebookID)
	BEGIN
		update Usuario set LastLoginDate = GETDATE() WHERE FacebookID = @FacebookID
		SELECT  UsuarioID FROM Usuario WHERE FacebookID = @FacebookID
	END
	ELSE
	BEGIN
	--en este caso es la primera vez que el usuario se loguea con facebook, así que lo agrego
	declare @UsuarioNuevoId int;
	
		INSERT INTO [Usuario]
			   ([UsuarioEmail]
			   ,FacebookID
			   ,FechaAlta
			   ,LastLoginDate)
		VALUES
			   (@Email
			   ,@FacebookID
			   ,GETDATE()
			   ,GETDATE())
		
		set @UsuarioNuevoId = SCOPE_IDENTITY() -- UsuarioID
		
		
		insert into Perfil(UsuarioID,PerfilFoto,PerfilNombre,PerfilApellido,PerfilSexo,PerfilDeseoRecibirEmails,FechaAlta)
		values(@UsuarioNuevoId,@PerfilFoto,@PerfilNombre,@PerfilApellido,@PerfilSexo,0,GETDATE())
		
		select @UsuarioNuevoId
		--Ahora creo los datos de perfil con lo que obtuve de facebook
		--Esto queda para despues ya que no esta claro como se va a manejar el perfil
		--insert into Perfil(UsuarioID,PerfilFoto,PerfilNombre,PerfilApellido,PerfilSexo,PerfilDeseoRecibirEmails,FechaAlta)
     END
END
