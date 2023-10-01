CREATE OR ALTER PROCEDURE Sp_GetTransactions(
	@TrnsId INT= 0
)
AS
BEGIN
	IF(@TrnsId= 0)
	BEGIN
		SELECT
		TrnsId as Id
		, c.CliCodigo as CodigoIdentificacion
		, c.CliNombres as Nombres
		, c.CliApellidos as Apellidos
		, trns.TrnsMonto as Monto
		, cub.CubCodigo as CuentaBancariaCodigo
		, tpotrns.TpoTrnsDescripcion as TipoTransaccion
		, frmpgo.FrmPgoDescripcion as FormaPago
		, tpoid.TpiDescripcion as TipoIdentificacion
		, trns.FechaCreacion as FechaConsignacion

		FROM Transaccion trns WITH(NOLOCK)
		INNER JOIN Clientes c WITH(NOLOCK) ON trns.CliId= c.CliId
		INNER JOIN TipoIdentificacion tpoid ON c.TpiId = tpoid.TpiId
		INNER JOIN CuentaBancaria cub WITH(NOLOCK) ON trns.CubId= cub.CubId
		INNER JOIN TipoTransaccion tpotrns WITH(NOLOCK) ON trns.TpoTrnsId= tpotrns.TpoTrnsId
		INNER JOIN FormaPago frmpgo WITH(NOLOCK) ON trns.FrmPgoId= frmpgo.FrmPgoId;
	END

	ELSE
	BEGIN
		SELECT
		  TrnsId as Id
		, c.CliCodigo as CodigoIdentificacion
		, c.CliNombres as Nombres
		, c.CliApellidos as Apellidos
		, trns.TrnsMonto as Monto
		, cub.CubCodigo as CuentaBancariaCodigo
		, tpotrns.TpoTrnsDescripcion as TipoTransaccion
		, frmpgo.FrmPgoDescripcion as FormaPago
		, tpoid.TpiDescripcion as TipoIdentificacion
		, trns.FechaCreacion as FechaConsignacion

		FROM Transaccion trns WITH(NOLOCK)
		INNER JOIN Clientes c WITH(NOLOCK) ON trns.CliId= c.CliId
		INNER JOIN TipoIdentificacion tpoid ON c.TpiId = tpoid.TpiId
		INNER JOIN CuentaBancaria cub WITH(NOLOCK) ON trns.CubId= cub.CubId
		INNER JOIN TipoTransaccion tpotrns WITH(NOLOCK) ON trns.TpoTrnsId= tpotrns.TpoTrnsId
		INNER JOIN FormaPago frmpgo WITH(NOLOCK) ON trns.FrmPgoId= frmpgo.FrmPgoId
		WHERE TrnsId= @TrnsId;
	END	
END