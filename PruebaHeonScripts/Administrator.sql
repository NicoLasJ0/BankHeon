/*
	DROP TABLE Administrator;
*/
CREATE TABLE Administrator(
	AdminId INT IDENTITY,
	Username VARCHAR(40),
	Email VARCHAR(60),
	Password VARCHAR(70),
	CliId INT,
	AdminType VARCHAR(30),
	FechaCreacion DATETIME
	CONSTRAINT [PK_Administrator] PRIMARY KEY(AdminId)
);
ALTER TABLE Administrator ADD CONSTRAINT [DF_Administrator_FechaCreacion] DEFAULT GETDATE() FOR FechaCreacion;
ALTER TABLE Administrator ADD CONSTRAINT [FK_Administrator_Clientes] FOREIGN KEY(CliId) REFERENCES Clientes(CliId);
SELECT AdminId, Username, Email, Password, cli.CliNombres as Nombre, AdminType, Administrator.FechaCreacion
FROM Administrator 
INNER JOIN Clientes cli ON Administrator.CliId= cli.CliId;
INSERT INTO Administrator(Username, Email, Password, CliId, AdminType) SELECT 'nicxlasj', 'nicolasjaiquel@gmail.com', 'abc123', 1, 'admin';

UPDATE Administrator SET CliId= 2 WHERE AdminId= 1