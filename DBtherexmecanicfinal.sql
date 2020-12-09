CREATE TABLE [Cliente] (
  [CodCliente] integer not null identity (1,1) PRIMARY KEY,
  [Nombre] nvarchar (255) NOT NULL,
  [Apellido] nvarchar (255) NOT NULL,
  [Edad] integer NOT NULL,
  [Email] nvarchar (255) NOT NULL,
  [Domicilio] nvarchar (255) NOT NULL,
  [Telefono] integer NOT NULL
)
GO

CREATE TABLE [Mecanico] (
  [IdMecanico] integer not null identity (1,1) PRIMARY KEY,
  [IdGerencia] int NOT NULL,
  [Nombre] nvarchar (255) NOT NULL,
  [Apellido] nvarchar (255) NOT NULL,
  [Observacines] nvarchar (255) NOT NULL
)
GO

CREATE TABLE [Vehiculo] (
  [Patente] nvarchar (255) PRIMARY KEY,
  [CodCliente] integer NOT NULL,
  [Marca] nvarchar (255) NOT NULL,
  [Modelo] nvarchar (255) NOT NULL,
  [Anno] integer NOT NULL,
  [Color] nvarchar (255) NOT NULL
)
GO

CREATE TABLE [Reparacion] (
  [IdReparacion] integer not null identity (1,1) PRIMARY KEY,
  [Fecha_Ingreso] nvarchar (255) NOT NULL,
  [Hora_ingreso] nvarchar (255) NOT NULL,
  [Motivo_ingreso] nvarchar (255) NOT NULL,
  [Patente] nvarchar (255) NOT NULL,
  [Hora_salida] nvarchar (255) NOT NULL,
  [Fecha_salida] nvarchar (255) NOT NULL
)
GO

CREATE TABLE [Reportes] (
  [IdReportes] integer not null identity (1,1) PRIMARY KEY,
  [CodCliente] int NOT NULL,
  [Patente] nvarchar (255) NOT NULL,
  [Reparacion] nvarchar (255) NOT NULL,
  [IdMecanico] int NOT NULL
)
GO

CREATE TABLE [Gerencia] (
  [IdGerencia] integer not null identity (1,1) PRIMARY KEY,
  [Direccion] nvarchar (255) NOT NULL
)
GO



ALTER TABLE [Vehiculo] ADD FOREIGN KEY ([CodCliente]) REFERENCES [Cliente] ([CodCliente])
GO

ALTER TABLE [Reparacion] ADD FOREIGN KEY ([Patente]) REFERENCES [Vehiculo] ([Patente])
GO

ALTER TABLE [Reportes] ADD FOREIGN KEY ([CodCliente]) REFERENCES [Cliente] ([CodCliente])
GO

ALTER TABLE [Reportes] ADD FOREIGN KEY ([Patente]) REFERENCES [Vehiculo] ([Patente])
GO

ALTER TABLE [Reportes] ADD FOREIGN KEY ([IdMecanico]) REFERENCES [Mecanico] ([IdMecanico])
GO

ALTER TABLE [Mecanico] ADD FOREIGN KEY ([IdGerencia]) REFERENCES [Gerencia] ([IdGerencia])
GO



---POBLACION DE TABLAS

INSERT INTO Cliente VALUES ('jERSON','ARMIJO','26','JERSONARMIJO4@GMAIL.COM','CALLE LOCAL #2240','984534952');
INSERT INTO Cliente VALUES ('NATHAN','BANDA','20','NATHANBANDA@GMAIL.COM','BANDA LOCAL #0202','902020202');

INSERT INTO Vehiculo VALUES ('JAXD26','1','SUZUKI','MARUTI','2000','ROJO');
INSERT INTO Vehiculo VALUES ('NBXD21','2','SUZUKI','MARUTI','2006','AZUL');

INSERT INTO Reparacion VALUES ('20/03/2020','15:30','FALLA MOTOR','JAXD26','18:00','25/03/2020');
INSERT INTO Reparacion VALUES ('25/03/2020','12:30','FALLA RADIADOR','NBXD21','12:00','30/03/2020');

INSERT INTO Gerencia VALUES ('CALLE LOS XD COMUNA DE UWU');
INSERT INTO Gerencia VALUES ('CALLE LOS UWU COMUNA DE XD');

INSERT INTO Mecanico VALUES ('1','MAESTRO','CHASQUILLA','MECANICO GENERAL');
INSERT INTO Mecanico VALUES ('2','BOMBA','CUATRO','MECANICO MOTOR');

INSERT INTO Reportes VALUES ('1','NBXD21','REPARACION DE MOTOR','2');
INSERT INTO Reportes VALUES ('2','NBXD21','REPARACION DE MOTOR','2');