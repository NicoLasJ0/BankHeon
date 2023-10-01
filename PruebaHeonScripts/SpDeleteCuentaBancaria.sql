CREATE OR ALTER PROCEDURE Sp_DeleteCuentaBancaria(
	@CubId INT
)AS
BEGIN
	DELETE FROM CuentaBancaria WHERE CubId= @CubId;
	SELECT @CubId 
END
