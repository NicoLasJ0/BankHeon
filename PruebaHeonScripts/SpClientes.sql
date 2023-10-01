CREATE OR ALTER PROCEDURE Sp_GetClients(
	@CliId INT= 0

)AS
BEGIN
	IF(@CliId= 0)
	BEGIN
		SELECT CliId
		, tpi.TpiDescripcion as TipoIdentificacion
		, CliCodigo as Codigo
		, CliNombres as Nombres
		, CliApellidos as Apellidos
		, CliEstadoActivo as EstadoActivo
		, cli.FechaCreacion
		FROM Clientes cli
		INNER JOIN TipoIdentificacion tpi WITH(NOLOCK) ON cli.TpiId= tpi.TpiId;
	END

	ELSE
	BEGIN
		SELECT CliId
		, tpi.TpiDescripcion as TipoIdentificacion
		, CliCodigo as Codigo
		, CliNombres as Nombres
		, CliApellidos as Apellidos
		, CliEstadoActivo as EstadoActivo
		, cli.FechaCreacion
		FROM Clientes cli
		INNER JOIN TipoIdentificacion tpi WITH(NOLOCK) ON cli.TpiId= tpi.TpiId
		WHERE CliId= @CliId;
	END
END
