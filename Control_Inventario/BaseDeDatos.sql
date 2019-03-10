create database Inventario;
go

use Inventario;
go

------------------tabla producto----------------
create table Productos 
(
Id int identity (1,1) primary key,
Nombre nvarchar (100),
Descripcion nvarchar (100),
Marca nvarchar (100),
Precio float,
Stock int
)
go 

--------------insertamos productos---------------
insert into Productos 
values
('Gaseosa','3 Litros','coca cola',7.5,24),
('Chocolate','100 gramos','iberica',12.5,36)
go

-----procedimiento para mostrar los productos-----
create proc MostrarProductos
as
Select *from Productos;
go

-----procedimiento para Insertar Productos-----
create proc InsetarProductos
@nombre nvarchar (100),
@descrip nvarchar (100),
@marca nvarchar (100),
@precio float,
@stock int
as
insert into Productos values (@nombre,@descrip,@marca,@precio,@stock)
go

-----procedimiento para Editar Productos-----
create proc EditarProductos
@nombre nvarchar (100),
@descrip nvarchar (100),
@marca nvarchar (100),
@precio float,
@stock int,
@id int
as
update Productos set Nombre=@nombre, Descripcion=@descrip, Marca=@marca, Precio=@precio, Stock=@stock where Id=@id
go

-----procedimiento para Eliminar productos-----
create proc EliminarProducto
@idpro int
as
delete from Productos where Id=@idpro
go


Select *from Productos;