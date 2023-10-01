CREATE OR ALTER PROCEDURE Sp_GetCuentaBancaria(
	@CubId INT= 0
)AS
BEGIN
	IF(@CubId= 0)
	BEGIN
		SELECT CubId as Id
		, tpc.TpcDescripcion as TipoCuenta
		, bco.BcoNombre as BancoNombre
		, cli.CliNombres as Nombres
		, cli.CliApellidos as Apellidos
		, cub.CubCodigo as Codigo
		, CubDescripcion as Descripcion
		, CubEstadoActivo as EstadoActivo
		, cub.FechaCreacion as FechaCreacion
		FROM CuentaBancaria cub WITH(NOLOCK)
		INNER JOIN TipoCuenta tpc WITH(NOLOCK) ON cub.TpcId= tpc.TpcId
		INNER JOIN Bancos bco WITH(NOLOCK) ON cub.BcoId= bco.BcoId
		INNER JOIN Clientes cli WITH(NOLOCK) ON cub.CliId= cli.CliId
	END

	ELSE
	BEGIN
		SELECT CubId as Id
		, tpc.TpcDescripcion as TipoIdentificacion
		, bco.BcoNombre as BancoNombre
		, cli.CliNombres as Nombres
		, cli.CliApellidos as Apellidos
		, cub.CubCodigo as Codigo
		, CubDescripcion as Descripcion
		, CubEstadoActivo as EstadoActivo
		, cub.FechaCreacion as FechaCreacion
		FROM CuentaBancaria cub WITH(NOLOCK)
		INNER JOIN TipoCuenta tpc WITH(NOLOCK) ON cub.TpcId= tpc.TpcId
		INNER JOIN Bancos bco WITH(NOLOCK) ON cub.BcoId= bco.BcoId
		INNER JOIN Clientes cli WITH(NOLOCK) ON cub.CliId= cli.CliId
		WHERE CubId= @CubId;
	END
END