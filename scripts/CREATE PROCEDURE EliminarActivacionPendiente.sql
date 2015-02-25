CREATE PROCEDURE EliminarActivacionPendiente
@CodigoActivacion uniqueidentifier

AS

DELETE FROM UsuarioActivacion
WHERE 
 @CodigoActivacion = CodigoActivacion