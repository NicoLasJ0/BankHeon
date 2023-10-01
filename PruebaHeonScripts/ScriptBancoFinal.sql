	/*
	DROP TABLE CuentaBancaria;
	DROP TABLE Clientes;
	DROP TABLE TipoIdentificacion;
	DROP TABLE Bancos;
	DROP TABLE TipoCuenta;
	DROP TABLE FormaPago;
	DROP TABLE TipoTransaccion;
	DROP TABLE Transaccion;
*/


CREATE TABLE TipoIdentificacion(
	TpiId INT,
	TpiDescripcion VARCHAR(100) NOT NULL,
	TpiAbreviacion VARCHAR(2), 
	TpiEstadoActivo BIT,
	FechaCreacion DATETIME,
	CONSTRAINT [PK_TipoIdentificacion] PRIMARY KEY (TpiId)
);

ALTER TABLE TipoIdentificacion ADD CONSTRAINT [DF_TipoIdentificacion_FechaCreacion] DEFAULT GETDATE() FOR FechaCreacion;
ALTER TABLE TipoIdentificacion ADD CONSTRAINT [DF_TipoIdentificacion_TpiEstadoActivo] DEFAULT 1 FOR TpiEstadoActivo;

INSERT INTO TipoIdentificacion(TpiId,TpiDescripcion,TpiAbreviacion) SELECT 1, 'Registro Civil','RC';
INSERT INTO TipoIdentificacion(TpiId,TpiDescripcion,TpiAbreviacion) SELECT 2, 'Cedula de Ciudadania','CC';
INSERT INTO TipoIdentificacion(TpiId,TpiDescripcion,TpiAbreviacion) SELECT 3, 'Tarjeta de Identidad','TI';


CREATE TABLE Clientes(
	CliId INT IDENTITY,
	TpiId INT NOT NULL,
	CliCodigo VARCHAR(25),
	CliNombres VARCHAR(100),
	CliApellidos VARCHAR(100),
	CliEstadoActivo BIT,
	FechaCreacion DATETIME,
	CONSTRAINT [PK_Clientes] PRIMARY KEY (CliId)
);

ALTER TABLE Clientes ADD CONSTRAINT [DF_Clientes_FechaCreacion] DEFAULT GETDATE() FOR FechaCreacion;
ALTER TABLE Clientes ADD CONSTRAINT [DF_Clientes_TpiEstadoActivo] DEFAULT 1 FOR CliEstadoActivo;
ALTER TABLE Clientes ADD CONSTRAINT [FK_Clientes_TpiEstadoActivo] FOREIGN KEY (TpiId) REFERENCES TipoIdentificacion(TpiId);
ALTER TABLE Clientes ADD CONSTRAINT [UQ_Clientes_TpiId_CliCodigo] UNIQUE (TpiId,CliCodigo);

INSERT INTO Clientes(TpiId,CliCodigo,CliNombres,CliApellidos) SELECT 2, '11222014','EDWIN ALEXANDER','JAIQUEL GONGORA';
INSERT INTO Clientes(TpiId,CliCodigo,CliNombres,CliApellidos) SELECT 3, '1019990889','NICOLAS','JAIQUEL RUBIO';




CREATE TABLE Bancos(
	BcoId INT,	
	BcoNombre VARCHAR(100),	
	BcoEstadoActivo BIT,
	FechaCreacion DATETIME,
	CONSTRAINT [PK_Bancos] PRIMARY KEY (BcoId)
);

ALTER TABLE Bancos ADD CONSTRAINT [DF_Bancos_FechaCreacion] DEFAULT GETDATE() FOR FechaCreacion;
ALTER TABLE Bancos ADD CONSTRAINT [DF_Bancos_BcoEstadoActivo] DEFAULT 1 FOR BcoEstadoActivo;

INSERT INTO Bancos(BcoId,BcoNombre) SELECT 1, 'BANCOLOMBIA';
INSERT INTO Bancos(BcoId,BcoNombre) SELECT 2, 'BANCO DE BOGOTA';


CREATE TABLE TipoCuenta(
	TpcId INT,
	TpcDescripcion VARCHAR(100),	
	TpcEstadoActivo BIT,
	FechaCreacion DATETIME,
	CONSTRAINT [PK_TipoCuenta] PRIMARY KEY (TpcId)
);

ALTER TABLE TipoCuenta ADD CONSTRAINT [DF_TipoCuenta_FechaCreacion] DEFAULT GETDATE() FOR FechaCreacion;
ALTER TABLE TipoCuenta ADD CONSTRAINT [DF_TipoCuenta_TpcEstadoActivo] DEFAULT 1 FOR TpcEstadoActivo;

INSERT INTO TipoCuenta(TpcId,TpcDescripcion) SELECT 1,'Ahorros';
INSERT INTO TipoCuenta(TpcId,TpcDescripcion) SELECT 2,'Corriente';



CREATE TABLE CuentaBancaria(
	CubId INT IDENTITY,	
	TpcId INT NOT NULL,
	BcoId INT NOT NULL,
	CliId INT NOT NULL,
	CubCodigo VARCHAR(25),
	CubDescripcion VARCHAR(200),
	CubEstadoActivo BIT,
	FechaCreacion DATETIME,
	CONSTRAINT [PK_CuentaBancaria] PRIMARY KEY (CubId)
);

ALTER TABLE CuentaBancaria ADD CONSTRAINT [DF_CuentaBancaria_FechaCreacion] DEFAULT GETDATE() FOR FechaCreacion;
ALTER TABLE CuentaBancaria ADD CONSTRAINT [DF_CuentaBancaria_CubEstadoActivo] DEFAULT 1 FOR CubEstadoActivo;
ALTER TABLE CuentaBancaria ADD CONSTRAINT [FK_CuentaBancaria_TipoCuenta] FOREIGN KEY (TpcId) REFERENCES TipoCuenta(TpcId);
ALTER TABLE CuentaBancaria ADD CONSTRAINT [FK_CuentaBancaria_Bancos] FOREIGN KEY (BcoId) REFERENCES Bancos(BcoId);
ALTER TABLE CuentaBancaria ADD CONSTRAINT [FK_CuentaBancaria_Clientes] FOREIGN KEY (CliId) REFERENCES Clientes(CliId);
ALTER TABLE CuentaBancaria ADD CONSTRAINT [UQ_CuentaBancaria_TpcId_CubCodigo] UNIQUE (TpcId,CubCodigo);

INSERT INTO CuentaBancaria(TpcId,BcoId,CliId,CubCodigo,CubDescripcion) SELECT 1,1,1,'205020738','Ahorro programado compra casa flandes';
INSERT INTO CuentaBancaria(TpcId,BcoId,CliId,CubCodigo,CubDescripcion) SELECT 1,1,2,'402568456','Ahorro para ocio';

CREATE TABLE FormaPago(
	FrmPgoId INT,
	FrmPgoDescripcion VARCHAR(50),
	FrmEstadoActivo BIT,
	FechaCreacion DATETIME
	CONSTRAINT [PK_FormaPago] PRIMARY KEY(FrmPgoId)
);

ALTER TABLE FormaPago ADD CONSTRAINT [DF_FormaPago_FechaCreacion] DEFAULT GETDATE() FOR FechaCreacion;
ALTER TABLE FormaPago ADD CONSTRAINT [DF_FormaPago_FrmEstadoActivo] DEFAULT 1 FOR FrmEstadoActivo;

INSERT INTO FormaPago(FrmPgoId, FrmPgoDescripcion) SELECT 1, 'Cheque';
INSERT INTO FormaPago(FrmPgoId, FrmPgoDescripcion) SELECT 2, 'Efectivo';

CREATE TABLE TipoTransaccion(
	TpoTrnsId INT,
	TpoTrnsDescripcion VARCHAR(50),
	TpoTrnsEstadoActivo BIT,
	FechaCreacion DATETIME
	CONSTRAINT [PK_TipoTransaccion] PRIMARY KEY(TpoTrnsId)
);

ALTER TABLE TipoTransaccion ADD CONSTRAINT [DF_TipoTransaccion_FechaCreacion] DEFAULT GETDATE() FOR FechaCreacion;
ALTER TABLE TipoTransaccion ADD CONSTRAINT [DF_TipoTransaccion_TpoTrnsEstadoActivo] DEFAULT 1 FOR TpoTrnsEstadoActivo;

INSERT INTO TipoTransaccion(TpoTrnsId, TpoTrnsDescripcion) SELECT 1, 'Consignacion';
INSERT INTO TipoTransaccion(TpoTrnsId, TpoTrnsDescripcion) SELECT 2, 'Retiro';

CREATE TABLE Transaccion(
	TrnsId INT IDENTITY,
	CliId INT NOT NULL,
	CubId INT NOT NULL,
	TpoTrnsId INT NOT NULL,
	FrmPgoId INT NOT NULL,
	TrnsMonto DECIMAL NOT NULL,
	TrnsEstadoActivo BIT,
	FechaCreacion DATETIME
	CONSTRAINT [PK_Transaccion] PRIMARY KEY(TrnsId)
);

ALTER TABLE Transaccion ADD CONSTRAINT [DF_Transaccion_FechaCreacion] DEFAULT GETDATE() FOR FechaCreacion;
ALTER TABLE Transaccion ADD CONSTRAINT [DF_Transaccion_TrnsEstadoActivo] DEFAULT 1 FOR TrnsEstadoActivo;
ALTER TABLE Transaccion ADD CONSTRAINT [FK_Transaccion_Clientes] FOREIGN KEY(CliId) REFERENCES Clientes(CliId);
ALTER TABLE Transaccion ADD CONSTRAINT [FK_Transaccion_CuentaBancaria] FOREIGN KEY(CubId) REFERENCES CuentaBancaria(CubId);	
ALTER TABLE Transaccion ADD CONSTRAINT [FK_Transaccion_TipoTransaccion] FOREIGN KEY(TpoTrnsId) REFERENCES TipoTransaccion(TpoTrnsId);	
ALTER TABLE Transaccion ADD CONSTRAINT [FK_Transaccion_FormaPago] FOREIGN KEY(FrmPgoId) REFERENCES FormaPago(FrmPgoId);	

INSERT INTO Transaccion(CliId, CubId, TpoTrnsId, FrmPgoId, TrnsMonto) SELECT 1, 1, 1, 2, 5000
INSERT INTO Transaccion(CliId, CubId, TpoTrnsId, FrmPgoId, TrnsMonto) SELECT 2, 2, 1, 1, 500

/*SELECT
	c.CliNombres as nombres
	,c.CliApellidos as apellidos
	,tp.TpiDescripcion as tipoIdentificacion
	,tp.TpiAbreviacion as abreviatura
	,c.CliCodigo as identificacion
	,cb.CubCodigo as codigoCuenta
	,tc.TpcDescripcion as tipoCuenta	
FROM Clientes c WITH(NOLOCK)
	INNER JOIN TipoIdentificacion tp WITH(NOLOCK) ON tp.TpiId = c.TpiId
	INNER JOIN CuentaBancaria cb WITH(NOLOCK) ON cb.CliId = c.CliId
	INNER JOIN TipoCuenta tc WITH(NOLOCK) ON tc.TpcId = cb.TpcId*/

	SELECT  
	c.CliCodigo as CodigoIdentificacion
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
	;

SELECT * FROM Clientes

DELETE FROM Clientes WHERE CliApellidos= 'Jaikel'
SELECT * FROM CuentaBancaria
SELECT * FROM TipoIdentificacion



