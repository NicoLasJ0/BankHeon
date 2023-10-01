CREATE OR ALTER PROCEDURE Sp_SaveOrUpdateClients(
	@CliId INT= 0,
	@TpiId INT= NULL,
	@CliCodigo VARCHAR(25)= NULL,
	@CliNombres VARCHAR(100)= NULL,
	@CliApellidos VARCHAR(100)= NULL,
	@CliEstadoActivo BIT= NULL
)AS
BEGIN
	IF(@CliId= 0)
		BEGIN
			INSERT INTO Clientes(TpiId, CliCodigo, CliNombres, CliApellidos, CliEstadoActivo) 
				SELECT @TpiId, @CliCodigo, @CliNombres, @CliApellidos, @CliEstadoActivo;
				SET @CliId= SCOPE_IDENTITY();
		END
	ELSE
		BEGIN
			UPDATE Clientes
			SET 		
			TpiId	= case when @TpiId is null then TpiId else @TpiId end
			,CliCodigo = case when @CliCodigo is null then CliCodigo else @CliCodigo end
			,CliNombres	= case when @CliNombres is null then CliNombres else @CliNombres end
			,CliApellidos = case when @CliApellidos is null then CliApellidos else @CliApellidos end
			,CliEstadoActivo = case when @CliEstadoActivo is null then CliEstadoActivo else @CliEstadoActivo end		
			WHERE CliId = @CliId;
		END
	SELECT CliId
		, tpi.TpiDescripcion as TipoIdentificacion
		, CliCodigo as Codigo
		, CliNombres as Nombres
		, CliApellidos as Apellidos
		, CliEstadoActivo as EstadoActivo
		, cli.FechaCreacion
		FROM Clientes cli
		INNER JOIN TipoIdentificacion tpi WITH(NOLOCK) ON cli.TpiId= tpi.TpiId WHERE CliId= @CliId;

END

EXEC Sp_SaveOrUpdateClients @TpiId= 2, @CliCodigo= '1234567890', @CliNombres= 'Nicoo', @CliApellidos= 'Jaikel', @CliEstadoActivo= 1;