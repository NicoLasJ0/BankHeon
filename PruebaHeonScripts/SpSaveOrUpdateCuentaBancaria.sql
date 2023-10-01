CREATE OR ALTER PROCEDURE Sp_SaveOrUpdateCuentaBancaria(
	@CubId INT= 0,	
	@TpcId INT= 0,
	@BcoId INT= 0,
	@CliId INT= 0,
	@CubCodigo VARCHAR(25)= NULL,
	@CubDescripcion VARCHAR(200)= NULL,
	@CubEstadoActivo BIT= NULL
)AS
BEGIN
	IF(@CubId= 0)
	BEGIN
		INSERT INTO CuentaBancaria(TpcId, BcoId, CliId, CubCodigo, CubDescripcion, CubEstadoActivo)
			VALUES( @TpcId, @BcoId, @CliId, @CubCodigo, @CubDescripcion, 1);
			SET @CubId= SCOPE_IDENTITY();
	END

	ELSE
	BEGIN
		UPDATE CuentaBancaria
		SET TpcId= case when @TpcId is null then TpcId else @TpcId end,
		BcoId= case when @BcoId is null then BcoId else @BcoId end,
		CliId= case when @CliId is null then CliId else @CliId end,
		CubCodigo= case when @CubCodigo is null then CubCodigo else @CubCodigo end,
		CubDescripcion= case when  @CubDescripcion is null then CubDescripcion else @CubDescripcion end,
		CubEstadoActivo= case when @CubEstadoActivo is null then CubEstadoActivo else @CubEstadoActivo end
		WHERE CubId= @CubId;
	END
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
		WHERE CubId= @CubId
END

EXEC Sp_SaveOrUpdateCuentaBancaria @CubId=0, @TpcId= 1, @BcoId= 2, @CliId= 3, @CubCodigo= '229900123', @CubDescripcion= 'asas',@CubEstadoActivo=  null


