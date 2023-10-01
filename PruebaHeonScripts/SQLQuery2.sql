CREATE OR ALTER PROCEDURE Sp_QueryAdmin(
	@AdminId int = 0,
	@Username VARCHAR(40) = NULL,
	@Email VARCHAR(60)=NULL,
	@Password VARCHAR(70)=null,
	@CliId INT= 0,
	@AdminType VARCHAR =NULL
)
AS
BEGIN

	SELECT AdminId, Username, Email, Password, cli.CliNombres as Nombre, AdminType, Administrator.FechaCreacion
	FROM Administrator 
	INNER JOIN Clientes cli ON Administrator.CliId= cli.CliId
	WHERE (@AdminId = 0  OR AdminId = @AdminId)
	  and (@Username IS NULL OR Username = @Username)
	  and (@Email IS NULL or Email LIKE  @Email)
	  and (@Password IS NULL OR Password LIKE Password)
	  and (@CliId = 0 OR Administrator.CliId = @CliId)
	  and (@AdminType IS NULL OR AdminType= @AdminType)

END

EXEC Sp_QueryAdmin @Email= 'nicolasjaiquel@gmail.com'

SELECT * FROM Administrator



