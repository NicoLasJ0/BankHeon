CREATE OR ALTER PROCEDURE Sp_SaveOrUpdateAdmin(
	@AdminId INT= 0,
	@Username VARCHAR(40)= NULL,
	@Email VARCHAR(60)= NULL,
	@Password VARCHAR(70)= NULL,
	@CliId INT= 0,
	@AdminType VARCHAR(30)= NULL
)AS
BEGIN
	IF(@AdminId = 0)
	BEGIN
		INSERT INTO Administrator(Username, Email, Password, CliId, AdminType) 
		SELECT @Username, @Email, @Password, @CliId, @AdminType;

		SELECT AdminId, Username, Email, Password, cli.CliNombres as Nombre, AdminType, Administrator.FechaCreacion
		FROM Administrator 
		INNER JOIN Clientes cli ON Administrator.CliId= cli.CliId
		WHERE AdminId= @AdminId;
	END

	ELSE
	BEGIN
		UPDATE Administrator SET
		Username= CASE WHEN @Username is null THEN Username ELSE @Username END,
		Email= CASE WHEN @Email is null THEN Email ELSE @Email END,
		Password= CASE WHEN @Password is null THEN Password ELSE @Password END,
		CliId= CASE WHEN @CliId is null THEN CliId ELSE @CliId END,
		AdminType= CASE WHEN @AdminType is null THEN AdminType ELSE @AdminType END
		WHERE AdminId= @AdminId;


	END
END

