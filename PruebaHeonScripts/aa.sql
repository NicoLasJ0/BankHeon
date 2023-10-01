CREATE OR ALTER PROCEDURE Sp_GetTipoIdentificacion

AS
BEGIN
	SELECT TpiId as TpiId, TpiDescripcion as TpiDescripcion, TpiAbreviacion as TpiAbreviacion,
	TpiEstadoActivo as TpiEstadoActivo, FechaCreacion as FechaCreacion FROM TipoIdentificacion
END

SELECT * FROM Clientes
