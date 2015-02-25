CREATE PROCEDURE GuardarActivacionPendiente
@UsuarioID int,
@CodigoActivacion uniqueidentifier

AS

INSERT INTO UsuarioActivacion
 VALUES(@UsuarioID, @CodigoActivacion)
