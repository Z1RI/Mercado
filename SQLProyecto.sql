/*Base de datos provicional para el uso del proyecto*/
USE BDProyecto;
GO
/*Creacion de tablas*/
CREATE TABLE Rol(
Id_Rol Integer IDENTITY PRIMARY KEY,
descripcion_rol VARCHAR(200) NOT NULL,
fecha DATETIME DEFAULT getdate()
);
GO

CREATE TABLE Permiso(
Id_Permiso Integer IDENTITY PRIMARY KEY,
rol_Id INTEGER REFERENCES Rol(Id_Rol),
nombreMenu VARCHAR(200) NOT NULL,
fecha DATETIME DEFAULT getdate()
);
GO


CREATE TABLE Persona(
Id_Persona Integer IDENTITY PRIMARY KEY,
nombre VARCHAR (100) NOT NULL,
apellido VARCHAR (100) NOT NULL,
correo Varchar(50) NULL,
Telefono Varchar(20) NULL, 
ciudad_Origen Varchar(100) NOT NULL,
fecha DATETIME DEFAULT getdate()
);
GO


CREATE TABLE Cargo(
Id_Cargo Integer IDENTITY PRIMARY KEY,
nombre_Cargo VARCHAR(200) NOT NULL,
);
GO


CREATE TABLE Empleado(
Id_empleado Integer IDENTITY PRIMARY KEY,
persona_Id INTEGER REFERENCES Persona(Id_Persona),
cargo_Id INTEGER REFERENCES Cargo(Id_Cargo),
sucursal_no int not null
);
GO


CREATE TABLE Usuario(
Id_Usuario Integer IDENTITY PRIMARY KEY,
rol_Id INTEGER REFERENCES Rol(Id_Rol),
empleado_Id INTEGER REFERENCES Empleado(Id_empleado),
nombre_Usuario VARCHAR(50) NOT NULL,
clave VARCHAR(200) NOT NULL,
estado BIT,
fecha_Registro DATETIME DEFAULT getdate()
);
GO

/*Insertar datos Estandar*/

INSERT INTO Rol(descripcion_rol) VALUES('ADMIN');
INSERT INTO Rol(descripcion_rol) VALUES('CAJA');
GO

INSERT INTO Permiso(rol_Id,nombreMenu) VALUES
(1,'menuUsuario'),
(1,'menuMantenedor'),
(1,'menuVentas'),
(1,'menuCompras'),
(1,'menuClientes'),
(1,'menuProveedores'),
(1,'menuReportes'),
(1,'menuInfo')
GO

INSERT INTO Permiso(rol_Id,nombreMenu) VALUES
(2,'menuVentas'),
(2,'menuClientes'),
(2,'menuReportes'),
(2,'menuInfo')
GO

INSERT INTO Persona(nombre,apellido,correo,Telefono,ciudad_Origen) VALUES
('Juan','Martinez','juanmartinez@yahoo.com',99999999,'Tegucigalpa')
GO

INSERT INTO Cargo(nombre_Cargo) VALUES
('Gerente'),
('Caja'),
('Empaquetador')
GO

INSERT INTO Empleado(persona_Id,cargo_Id,sucursal_no) VALUES
(1,1,1)
GO

INSERT INTO Usuario(rol_Id,empleado_Id,nombre_Usuario,clave,estado) VALUES
(1,1,'admin','admin',1)
GO

/* Comandos para obtener datos usados en el sistema */

SELECT * FROM Rol;
SELECT * FROM Permiso; 
SELECT * FROM Cargo;
GO

SELECT * FROM Persona;
SELECT * FROM Empleado;
SELECT * FROM Usuario;
GO

SELECT p.Id_Persona,p.nombre, p.apellido, p.correo, p.Telefono, p.ciudad_Origen, e.Id_empleado,
e.persona_Id,e.cargo_Id,e.sucursal_no,u.Id_Usuario, u.rol_Id,u.empleado_Id ,u.nombre_Usuario, 
u.clave, u.estado, r.Id_Rol, r.descripcion_rol, c.nombre_Cargo, c.Id_Cargo FROM Usuario u
inner join Empleado e on e.Id_empleado = u.empleado_Id
inner join Persona p on p.Id_Persona = e.persona_Id
inner join rol r on r.Id_Rol = u.rol_Id
inner join Cargo c on c.Id_Cargo = e.cargo_Id
GO

/*Procedimientos almacenados*/

CREATE PROC SP_UsuarioNuevo(
@nombre VARCHAR (100) ,
@apellido VARCHAR (100),
@correo VARCHAR (100),
@telefono VARCHAR (20),
@ciudad_Origen VARCHAR (100),
@persona_Id int,
@cargo_Id int,
@sucursal_no int,
@rol_Id int,
@empleado_Id int,
@nombre_Usuario VARCHAR(50),
@clave VARCHAR(200),
@estado BIT,
@IdRegistrarResultado int output,
@Mensaje VARCHAR (500) output
)
as
begin

	set @IdRegistrarResultado = 0
	set @Mensaje = ''

	if not exists(SELECT * FROM Usuario where nombre_Usuario = @nombre_Usuario)
	begin
		insert into Persona(nombre,apellido,correo,Telefono,ciudad_Origen) values
		(@nombre, @apellido, @correo, @telefono, @ciudad_Origen)

		insert into Empleado(persona_Id,cargo_Id,sucursal_no) values
		(@persona_Id,@cargo_Id,@sucursal_no)

		insert into Usuario(rol_Id,empleado_Id,nombre_Usuario,clave,estado) values
		(@rol_Id,@empleado_Id,@nombre_Usuario,@clave,@estado)

		set @IdRegistrarResultado = SCOPE_IDENTITY()
		
	end
	else
		set @Mensaje = 'No se puede Repetir Usuario'

end
GO

/* 
DECLARE @idUsuarioGenerado int
DECLARE @mensaje VARCHAR(500)
exec SP_UsuarioNuevo 'Maria','Rodriguez','maria89@yahoo.com','99999999','Choluteca',3,2,8,2,3, 'maria21','admin',1,@idUsuarioGenerado output, @mensaje output 

select @idUsuarioGenerado
select @Mensaje
*/
Go

CREATE PROC SP_RolNuevo(
@descripcion_rol VARCHAR (200),
@IdRegistrarResultadoRol int output,
@Mensaje VARCHAR (500) output
)
as
begin

	set @IdRegistrarResultadoRol = 0
	set @Mensaje = ''

	if not exists(SELECT * FROM Rol where descripcion_rol = @descripcion_rol)
	begin
		insert into Rol(descripcion_rol) values
		(@descripcion_rol)
		set @IdRegistrarResultadoRol = SCOPE_IDENTITY()
		
	end
	else
		set @Mensaje = 'No se puede Repetir Rol'
end
GO
/*
DECLARE @idUsuarioGenerado int
DECLARE @mensaje VARCHAR(500)
exec SP_RolNuevo 'PROMOTOR',@idUsuarioGenerado output, @mensaje output 

select @idUsuarioGenerado
select @Mensaje
*/

CREATE PROC SP_DarPermisos(
@rol_Id int,
@nombreMenu VARCHAR(200),
@IdRegistrarResultadoPermiso int output,
@Mensaje VARCHAR (500) output
)
as
begin

	set @IdRegistrarResultadoPermiso = 0
	set @Mensaje = ''
	begin
		insert into Permiso(rol_Id,nombreMenu) values
		(@rol_Id,@nombreMenu)
		set @IdRegistrarResultadoPermiso = SCOPE_IDENTITY()
		set @Mensaje = 'Permiso Otorgado'
	end
end
GO
/*
DECLARE @IdRegistrarResultadoPermiso int
DECLARE @mensaje VARCHAR(500)
exec SP_DarPermisos 3,'menuInfo',@IdRegistrarResultadoPermiso output, @mensaje output 

select @IdRegistrarResultadoPermiso
select @Mensaje
*/

CREATE PROC SP_EditarUsuario(
@Id_Usuario int,
@nombre VARCHAR (100) ,
@apellido VARCHAR (100),
@correo VARCHAR (100),
@telefono VARCHAR (20),
@ciudad_Origen VARCHAR (100),
@persona_Id int,
@cargo_Id int,
@sucursal_no int,
@rol_Id int,
@empleado_Id int,
@nombre_Usuario VARCHAR(50),
@clave VARCHAR(200),
@estado BIT,
@Respuesta bit output,
@Mensaje VARCHAR (500) output
)
as
begin

	set @Respuesta = 0
	set @Mensaje = ''

	if exists(SELECT * FROM Usuario where Id_Usuario != @Id_Usuario and empleado_Id != @empleado_Id)
	begin
		if exists(SELECT * FROM Persona where Id_Persona != @persona_Id)
		begin

		UPDATE Persona set
		nombre = @nombre,
		apellido = @apellido,
		correo = @correo,
		Telefono = @telefono,
		ciudad_Origen = @ciudad_Origen
		where Id_Persona = @persona_Id

		UPDATE  Empleado set
		persona_Id = @persona_Id,
		cargo_Id = @cargo_Id,
		sucursal_no = @sucursal_no
		where Id_empleado = @empleado_Id

		UPDATE  Usuario set
		rol_Id = @rol_Id,
		empleado_Id = @empleado_Id,
		nombre_Usuario = @nombre_Usuario,
		clave = @clave,
		estado = @estado
		where Id_Usuario = @Id_Usuario


		set @Respuesta = 1
		end
	end
	else
		set @Mensaje = 'No se puede Repetir Usuario'
end
GO

/*
DECLARE @Respuesta bit
DECLARE @mensaje VARCHAR(500)
exec SP_EditarUsuario 3,'Mariana','Rodriguez','maria8988@yahoo.com','99999991','Choluteca valle',3,3,8,2,3, 'maria212','admin',1,@Respuesta output, @mensaje output 

select @Respuesta
select @Mensaje
*/
CREATE PROC SP_EditarRol(
@Id_Rol int,
@descripcion_rol VARCHAR (200),

@RespuestaRol bit output,
@Mensaje VARCHAR (500) output
)
as
begin

	set @RespuestaRol = 0
	set @Mensaje = ''

		if exists(SELECT * FROM Rol where Id_Rol != @Id_Rol)
		begin

		UPDATE Rol set
		descripcion_rol = @descripcion_rol
		where Id_Rol = @Id_Rol

		set @RespuestaRol = 1
		end
end
GO
/*
DECLARE @Respuesta bit
DECLARE @mensaje VARCHAR(500)
exec SP_EditarRol 4,PROOVEDORES,@Respuesta output, @mensaje output 

select @Respuesta
select @Mensaje
*/




/*Eliminacion de Usuario no Completado*/
/*
CREATE PROC SP_EliminarUsuario(
@Id_Usuario int,
@empleado_Id int,
@estado BIT,
@Respuesta bit output,
@Mensaje VARCHAR (500) output
)
as
begin
	set @Respuesta = 0
	set @Mensaje = ''
	declare @ReglasPass bit = 1

	IF not EXISTS (SELECT * FROM Usuario WHERE Id_Usuario = @Id_Usuario)
	BEGIN
		set @ReglasPass = 0
		set @Respuesta =0
		set @Mensaje = @Mensaje + 'No Existe usuario'
	END

	IF (@estado = 1)
	BEGIN
		set @ReglasPass = 0
		set @Respuesta =0
		set @Mensaje = @Mensaje + 'Error Usuario Activo'
	END

	IF(@ReglasPass =1)
	BEGIN
		DELETE FROM Empleado where Id_empleado = @empleado_Id
		DELETE FROM Usuario where Id_Usuario = @Id_Usuario
		SET @Respuesta = 1
	END
END

DECLARE @Respuesta bit
DECLARE @mensaje VARCHAR(500)
exec SP_EliminarUsuario 3,3,0,@Respuesta output, @mensaje output 
select @Respuesta
select @Mensaje
*/


