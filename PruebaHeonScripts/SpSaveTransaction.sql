CREATE OR ALTER PROCEDURE Sp_SaveOrUpdateTransactions(
	@TrnsId INT= 0,
	@CliId INT,
	@CubId INT,
	@TpoTrnsId INT,
	@FrmPgoId INT,
	@TrnsMonto DECIMAL,
	@TrnsEstadoActivo BIT
	
)
AS
BEGIN
	IF(@TrnsId= 0)
	BEGIN
		INSERT INTO Transaccion(CliId, CubId, TpoTrnsId, FrmPgoId, TrnsMonto, TrnsEstadoActivo) 
		SELECT @CliId, @CubId, @TpoTrnsId, @FrmPgoId, @TrnsMonto, @TrnsEstadoActivo;
		SET @TrnsId= SCOPE_IDENTITY();
	END

	ELSE
	BEGIN
		UPDATE Transaccion
		SET CliId= case when @CliId is null then CliId else @CliId end
		, CubId= case when @CubId is null then CubId else CubId end
		, TpoTrnsId= case when @TpoTrnsId is null then TpoTrnsId else @TpoTrnsId end
		, FrmPgoId= case when @FrmPgoId is null then FrmPgoId else @FrmPgoId end
		, TrnsMonto= case when @TrnsMonto is null then TrnsMonto else @TrnsMonto end
		, TrnsEstadoActivo= case when @TrnsEstadoActivo is null then TrnsEstadoActivo else @TrnsEstadoActivo end
		WHERE TrnsId= @TrnsId;
	END
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
