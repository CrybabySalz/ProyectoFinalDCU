create table Productos (
Id int identity(1,1) primary key,
Nombre varchar(30),
Precio varchar(30),
Stock int
);

insert into Productos(Nombre,Precio,Stock)
values ('Lapices de Colores','200',15),
('Set de Borras','150',12),
('Cuadernos','100',25)


create procedure SP_AgregarProducto
(
@nombre varchar(30),
@precio varchar(30),
@stock int
)
as
insert into Productos(Nombre,Precio,Stock)
values (@nombre,@precio,@stock)
select @@identity as id
return
go

create procedure SP_ObtenerProductos
as
select * from Productos

create procedure SP_ModificarProducto
(
@nombre varchar(30),
@precio varchar(30),
@stock int,
@Id int
)
as
update Productos
set Nombre=@nombre,Precio=@precio,Stock=@stock
where ID=@id
go

create procedure SP_EliminarProducto
(
@Id int
)
as
delete from Productos where Id=@Id
go

create procedure SP_BuscarPorNombre
(
@nombre varchar(30)
)
as
BEGIN
    SELECT * FROM Productos WHERE Nombre LIKE '%' + @nombre + '%'
END

create table Login (
Id int identity(1,1) primary key,
Usuario varchar(30),
Contrasena varchar(30)
)

CREATE PROCEDURE SP_VerificarCredenciales
    @usuario VARCHAR(50),
    @contrasena VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @esValido BIT;

    SELECT @esValido = CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END
    FROM Login
    WHERE Usuario = @usuario AND Contrasena = @contrasena;

    SELECT @esValido AS esValido;
END

insert into Login(Usuario,Contrasena)
values ('usuario','usuario')

select * from Login

create table Comprado (
Id int identity(1,1) primary key,
Nombre varchar(30),
Stock int
)

CREATE PROCEDURE SP_ActualizarStock
    @Nombre varchar(30),
    @Stock INT
AS
BEGIN
    UPDATE Productos SET Stock = Stock - @Stock WHERE Nombre = @Nombre
END

create procedure SP_RegistrarCompra
(
@nombre varchar(30),
@stock int
)
as
insert into Comprado(Nombre,Stock)
values (@nombre,@stock)
select @@identity as id
return
go

create procedure SP_ObtenerComprados
as
select * from Comprado


create procedure SP_RegistrarUsuario
(
@usuario varchar(30),
@contrasena varchar(30)
)
as
insert into Login(Usuario,Contrasena)
values (@usuario,@contrasena)
select @@identity as id
return
go


