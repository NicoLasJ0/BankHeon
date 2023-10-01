CREATE OR ALTER PROCEDURE Sp_DeleteTransactions(
	@TrnsId INT
)
AS
BEGIN
	DELETE FROM Transaccion WHERE TrnsId= @TrnsId;
	SELECT @TrnsId;
END