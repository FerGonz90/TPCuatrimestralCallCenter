﻿create procedure storedListarIncidencias as
Select i.IncidenciaId, c.Nombre, t.Descripcion as 'Tipo Incidencia', p.Descripcion as Prioridad, 
e.Descripcion as Estado, u.Nombre as 'Usuario Asignado', u.RolID, i.UsuarioAsignadoID
from Incidencias i, Clientes c, TiposIncidencia t, Prioridades p, Estados e, Usuarios u
where    i.ClienteID = c.ClienteID
and	  i.TipoIncidenciaID = t.TipoIncidenciaID
and	  i.PrioridadID = p.PrioridadID
and   i.EstadoID = e.EstadoID
and   i.UsuarioAsignadoID = u.UsuarioID

create procedure storedInsertarIncidencia
@ClienteID INT,
@TipoID INT,
@PrioridadID INT,
@Problematica NVARCHAR(500),
@UsuarioCreadorID int,
@UsuarioAsignadoID int,
@FechaCreacion DATETIME
AS
INSERT INTO Incidencias (ClienteID, TipoIncidenciaID, PrioridadID, EstadoID, Problematica, UsuarioCreadorID, UsuarioAsignadoID, FechaCreacion)
VALUES (@ClienteID, @TipoID, @PrioridadID, 1, @Problematica, @UsuarioCreadorID, @UsuarioAsignadoID, @FechaCreacion);

create procedure storedInsertarCliente
@Nombre nvarchar(100), 
@Correo nvarchar(100), 
@Telefono nvarchar(20)
as
Insert into Clientes (Nombre, Correo, Telefono)
Values(@Nombre, @Correo, @Telefono);

create procedure storedModClien 
@Nombre nvarchar(100), 
@Correo nvarchar(100), 
@Telefono nvarchar(20),
@Id int
as
Update Clientes 
SET  
Nombre = @Nombre,
Correo = @Correo,
Telefono = @Telefono
WHERE ClienteID = @Id;

create procedure storedInsertarUsuario
@Nombre nvarchar(100),
@Correo nvarchar(100),
@RolID int,
@Contraseña nvarchar(255)
as
insert into Usuarios (Nombre, Correo, RolID, Contraseña)
values (@Nombre, @Correo, @RolID, @Contraseña);

create procedure storedlistarUsuarioConSp
as
Select UsuarioID, Nombre, Correo, RolID 
from Usuarios;

create procedure storedListarIncidenciaPropias
@UsuarioAsignadoID int
as
Select i.IncidenciaId, c.Nombre, t.Descripcion as 'Tipo Incidencia', p.Descripcion as Prioridad, 
e.Descripcion as Estado, u.Nombre as 'Usuario Asignado', u.RolID, i.UsuarioAsignadoID
from Incidencias i, Clientes c, TiposIncidencia t, Prioridades p, Estados e, Usuarios u
where    i.ClienteID = c.ClienteID
and	  i.TipoIncidenciaID = t.TipoIncidenciaID
and	  i.PrioridadID = p.PrioridadID
and   i.EstadoID = e.EstadoID
and   i.UsuarioAsignadoID = u.UsuarioID
and   i.UsuarioAsignadoID = @UsuarioAsignadoID;

create procedure storedReasignar
@IdUsuario int,
@IdIncidencia int
as
Update Incidencias 
set UsuarioAsignadoID = @IdUsuario,
     EstadoID = 2
where IncidenciaID = @IdIncidencia

create procedure storedListarInciPorId
@Id int
as
SELECT  i.IncidenciaID, c.Nombre, t.Descripcion as 'Tipo', p.Descripcion as 'Prioridad', e.Descripcion as 'Estado', 
i.Problematica, i.FechaCreacion, uc.Nombre as 'Creador', ua.Nombre as 'Asignado', i.ComentarioCierre, c.ClienteID
FROM Incidencias i, Clientes c, TiposIncidencia t, Prioridades p, Estados e, Usuarios uc, Usuarios ua
where i.IncidenciaID = @Id
and i.ClienteID = c.ClienteID
and i.TipoIncidenciaID = t.TipoIncidenciaID
and i.PrioridadID = p.PrioridadID
and i.EstadoID = e.EstadoID
and i.UsuarioCreadorID = uc.UsuarioID
and i.UsuarioAsignadoID = ua.UsuarioID;

create procedure storedModInci
@Id INT,
@Problematica nvarchar(500),
@Estado int
as
UPDATE Incidencias
SET EstadoID = @Estado,
Problematica = @Problematica
where IncidenciaID = @Id

create procedure storedCerrarInci
@Id int,
@ComCierre nvarchar(500)
as
update Incidencias
SET EstadoID = 5,
ComentarioCierre = @ComCierre
where IncidenciaID = @Id;

create procedure storedReabrirInci
@Id int,
@IdAdmin int
as
UPDATE Incidencias
SET EstadoID = 6,
UsuarioAsignadoID = @IdAdmin
where IncidenciaID = @Id;


