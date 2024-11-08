CREATE DATABASE CallCenterDB;
GO

USE CallCenterDB;
GO

CREATE TABLE Roles(
    RolID INT PRIMARY key IDENTITY(1,1),
    RolNombre NVARCHAR(50) not null
)

CREATE TABLE Usuarios(
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(100) NOT NULL UNIQUE,
    RolID INT FOREIGN key REFERENCES Roles(RolID)
)

CREATE TABLE Clientes(
    ClienteID INT PRIMARY KEY IDENTITY (1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(100) NOT NULL UNIQUE,
    Telefono NVARCHAR(20)
)

CREATE TABLE TiposIncidencia(
    TipoIncidenciaID INT PRIMARY KEY IDENTITY (1,1),
    Descripcion NVARCHAR(200) NOT NULL,
)

CREATE TABLE Prioridades (
    PrioridadID INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(50) NOT NULL
)

CREATE TABLE Estados(
    EstadoID INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(50) NOT NULL
)

CREATE TABLE Incidencias(
    IncidenciaID INT PRIMARY KEY IDENTITY(1,1),
    ClienteID INT FOREIGN KEY REFERENCES Clientes(ClienteID),
    TipoIncidenciaID INT FOREIGN KEY REFERENCES TiposIncidencia(TipoIncidenciaID),
    PrioridadID INT FOREIGN KEY REFERENCES Prioridades(PrioridadID),
    EstadoID INT FOREIGN KEY REFERENCES Estados(EstadoID),
    Problematica NVARCHAR(500) NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    UsuarioCreadorID INT FOREIGN KEY REFERENCES Usuarios(UsuarioID),
    UsuarioAsignadoID INT FOREIGN KEY REFERENCES Usuarios(UsuarioID),
    ComentarioCierre NVARCHAR(500) NULL
)

INSERT INTO Roles (RolNombre) VALUES ('Administrador'), ('Telefonista'), ('Supervisor');

INSERT INTO Estados (Descripcion) VALUES ('Abierto'), ('Asignado'), ('En Análisis'), ('Resuelto'), ('Cerrado'), ('Reabierto');

INSERT INTO Clientes (Nombre, Correo, Telefono)
VALUES 
    ('Goku', 'goku@kamehouse.com', '123-456-789'),
    ('Vegeta', 'vegeta@capsulecorp.com', '987-654-321'),
    ('Piccolo', 'piccolo@nameless.com', '456-123-789'),
    ('Bulma', 'bulma@capsulecorp.com', '321-987-654'),
    ('Krillin', 'krillin@kamehouse.com', '789-456-123'),
    ('Gohan', 'gohan@earth.com', '123-789-456'),
    ('Trunks', 'trunks@capsulecorp.com', '654-321-987'),
    ('Roshi', 'roshi@kamehouse.com', '789-123-456'),
    ('Tien', 'tien@earth.com', '987-123-654'),
    ('Yamcha', 'yamcha@earth.com', '321-654-987');

INSERT INTO TiposIncidencia (Descripcion)
VALUES 
    ('Problema con la facturación'),
    ('Consulta técnica sobre el servicio'),
    ('Reclamo por demora en la entrega'),
    ('Error en la plataforma online');

INSERT INTO Prioridades (Descripcion)
VALUES 
    ('Alta'),
    ('Media'),
    ('Baja');

INSERT INTO Usuarios (Nombre, Correo, RolID)
VALUES 
    ('Admin1', 'admin1@callcenter.com', (SELECT RolID FROM Roles WHERE RolNombre = 'Administrador')),
    ('Telefonista1', 'telefonista1@callcenter.com', (SELECT RolID FROM Roles WHERE RolNombre = 'Telefonista')),
    ('Telefonista2', 'telefonista2@callcenter.com', (SELECT RolID FROM Roles WHERE RolNombre = 'Telefonista')),
    ('Supervisor1', 'supervisor1@callcenter.com', (SELECT RolID FROM Roles WHERE RolNombre = 'Supervisor')),
    ('Telefonista3', 'telefonista3@callcenter.com', (SELECT RolID FROM Roles WHERE RolNombre = 'Telefonista')),
    ('Telefonista4', 'telefonista4@callcenter.com', (SELECT RolID FROM Roles WHERE RolNombre = 'Telefonista')),
    ('Telefonista5', 'telefonista5@callcenter.com', (SELECT RolID FROM Roles WHERE RolNombre = 'Telefonista')),
    ('Telefonista6', 'telefonista6@callcenter.com', (SELECT RolID FROM Roles WHERE RolNombre = 'Telefonista')),
    ('Telefonista7', 'telefonista7@callcenter.com', (SELECT RolID FROM Roles WHERE RolNombre = 'Telefonista')),
    ('Telefonista8', 'telefonista8@callcenter.com', (SELECT RolID FROM Roles WHERE RolNombre = 'Telefonista'));

INSERT INTO Incidencias (ClienteID, TipoIncidenciaID, PrioridadID, EstadoID, Problematica, UsuarioCreadorID, UsuarioAsignadoID)
VALUES 
    (1, 1, 1, (SELECT EstadoID FROM Estados WHERE Descripcion = 'Abierto'), 'Problema de facturación en el servicio premium', 2, 2),
    (2, 2, 2, (SELECT EstadoID FROM Estados WHERE Descripcion = 'Abierto'), 'Consulta técnica sobre rendimiento', 3, 3),
    (3, 3, 3, (SELECT EstadoID FROM Estados WHERE Descripcion = 'Abierto'), 'Demora en la entrega del producto solicitado', 2, 2),
    (4, 4, 1, (SELECT EstadoID FROM Estados WHERE Descripcion = 'Abierto'), 'Error en la plataforma de pagos', 4, 4),
    (5, 2, 1, (SELECT EstadoID FROM Estados WHERE Descripcion = 'Abierto'), 'Consulta sobre el plan de datos', 5, 5),
    (6, 1, 2, (SELECT EstadoID FROM Estados WHERE Descripcion = 'Abierto'), 'Factura duplicada', 6, 6),
    (7, 3, 3, (SELECT EstadoID FROM Estados WHERE Descripcion = 'Abierto'), 'Pedido incompleto recibido', 7, 7),
    (8, 4, 1, (SELECT EstadoID FROM Estados WHERE Descripcion = 'Abierto'), 'Problemas para acceder a su cuenta', 8, 8),
    (9, 1, 2, (SELECT EstadoID FROM Estados WHERE Descripcion = 'Abierto'), 'Consulta sobre saldo pendiente', 9, 9),
    (10, 2, 1, (SELECT EstadoID FROM Estados WHERE Descripcion = 'Abierto'), 'Dudas sobre el servicio contratado', 10, 10);