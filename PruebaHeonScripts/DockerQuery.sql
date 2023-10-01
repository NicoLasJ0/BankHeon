CREATE OR ALTER PROCEDURE Sp_SaveOrUpdateClients(
	@CliId INT=0,
	@TpiId INT,
	@CliCodigo VARCHAR(25),
	@CliNombres VARCHAR(100),
	@CliApellidos VARCHAR(100),
	@CliEstadoActivo BIT
)AS
BEGIN 
	IF(@CliId= 0)
	BEGIN
		INSERT INTO Clientes(TpiId, CliCodigo, CliNombres, CliApellidos, CliEstadoActivo) VALUES(@CliId, @TpiId, @CliNombres, @CliApellidos, @CliEstadoActivo);
		EXEC Sp_GetClients SCOPE_IDENTITY;
	END
	ELSE
	BEGIN
		UPDATE Clientes 
		SET TpiId= @TpiId,
		CliCodigo= @CliCodigo,
		CliNombres= @CliNombres,
		CliApellidos= @CliApellidos,
		CliEstadoActivo= @CliEstadoActivo
		WHERE CliId= @CliId;
		EXEC Sp_GetClients @CliId;
	END

END