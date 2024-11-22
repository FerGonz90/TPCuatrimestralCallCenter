create procedure storedListarIncidencias as
Select i.IncidenciaId, c.Nombre, t.Descripcion as 'Tipo Incidencia', p.Descripcion as Prioridad, e.Descripcion as Estado, i.FechaCreacion
from Incidencias i, Clientes c, TiposIncidencia t, Prioridades p, Estados e
where    i.ClienteID = c.ClienteID
and	  i.TipoIncidenciaID = t.TipoIncidenciaID
and	  i.PrioridadID = p.PrioridadID
and   i.EstadoID = e.EstadoID;

create procedure storedInsertarIncidencia
@ClienteID INT,
@TipoID INT,
@PrioridadID INT,
@Problematica NVARCHAR(500),
@FechaCreacion DATETIME
AS
INSERT INTO Incidencias (ClienteID, TipoIncidenciaID, PrioridadID, EstadoID, Problematica, FechaCreacion)
VALUES (@ClienteID, @TipoID, @PrioridadID, 1, @Problematica, @FechaCreacion);

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
