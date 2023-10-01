ALTER PROCEDURE spUdpateClientes(
	@CliId int,
	@TpiId int = null,
	@CliCodigo varchar(25)=null,
	@CliNombres	varchar(100)=null,
	@CliApellidos varchar(100)=null,
	@CliEstadoActivo bit =null	
	

)
AS
BEGIN
	UPDATE Clientes
	SET 		
		TpiId	= 
		(@TpiId is null) then CliId else @TpiId end
		,CliCodigo = case when @CliCodigo is null then CliCodigo else @CliCodigo end
		,CliNombres	= case when @CliNombres is null then CliNombres else @CliNombres end
		,CliApellidos = case when @CliApellidos is null then CliApellidos else @CliApellidos end
		,CliEstadoActivo = case when @CliEstadoActivo is null then CliEstadoActivo else @CliEstadoActivo end		
	WHERE CliId = @CliId;

	SELECT* FROM Clientes WITH(NOLOCK)
	WHERE CliId = @CliId;

END

