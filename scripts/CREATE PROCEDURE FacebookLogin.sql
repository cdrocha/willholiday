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
	--Primero verifico si el usuario ya estaba registrado con facebook
	IF EXISTS(SELECT UsuarioID FROM Usuario WHERE FacebookID = @FacebookID)
	BEGIN
	--EN caso que estuviera registrado con facebook anteriormente, actualizo la fecha de su ultimo ingreso
		update Usuario set LastLoginDate = GETDATE() WHERE FacebookID = @FacebookID
		SELECT  UsuarioID FROM Usuario WHERE FacebookID = @FacebookID
	END
	--Si nunca se registro con facebook, me fijo si su email ya existe en nuestra base
	ELSE IF EXISTS(SELECT UsuarioID FROM Usuario WHERE UsuarioEmail = @Email)
	begin
	--si ya existe en nuestra BD es porque el mail con el que se registro es el que usa para facebook,
	--en este caso unifico los logins
	update Usuario set FacebookID = @FacebookID where UsuarioEmail = @Email
	SELECT  UsuarioID FROM Usuario WHERE UsuarioEmail = @Email
	end
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
