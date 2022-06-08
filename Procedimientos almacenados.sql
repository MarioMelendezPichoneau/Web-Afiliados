go
use [AFILIADOS_{NOMBRE_CANDIDATO}]
go

--************************ PROCEDIMIENTOS PARA AFILIADOS ************************--

set dateformat dmy

go

create proc pro_registrar(
@nombre varchar(100),
@apellido varchar(100),
@fechaNacimento datetime,
@sexo varchar(50),
@cedula varchar(50),
@numeroSeguridadSocial varchar(50),
@fechaRegistro datetime,
@montoConsumido int,
@idestatus int,
@idplan int)
as 
begin
	insert into AFILIADOS(Nombres,Apellidos,Fecha_nacimineto,Sexo,Cedula,Numero_Seguridaad_Social,Fecha_Resgistro,Monto_Consumido,idEstatus,idPlan)
	values(
	@nombre,
	@apellido,
	@fechaNacimento,
	@sexo,
	@cedula,
	@numeroSeguridadSocial,
	@fechaRegistro,
	@montoConsumido,
	@idestatus,
	@idplan
	)
end

go

create proc pro_modificar(
@idafiliado int,
@nombre varchar(100),
@apellido varchar(100),
@fechaNacimento datetime,
@sexo varchar(50),
@cedula varchar(50),
@numeroSeguridadSocial varchar(50),
@fechaRegistro datetime,
@montoConsumido int,
@idestatus int,
@idplan int)
as
begin
	update AFILIADOS set 
	Nombres=@nombre,
	Apellidos=@apellido,
	Fecha_nacimineto=@fechaNacimento,
	Sexo=@sexo,
	Cedula=@cedula,
	Numero_Seguridaad_Social=@numeroSeguridadSocial,
	Fecha_Resgistro=@fechaRegistro,
	Monto_Consumido=@montoConsumido,
	idEstatus=@idestatus,
	idPlan=@idplan
	where id = @idafiliado
end


go


create proc actualzarMonto(
@id int,
@montoConsumido int
)
as 
begin
	select*from AFILIADOS
	where id=@id
	


end


go


update AFILIADOS set Monto_Consumido = 250


create procedure pro_listar
as
begin

select * from AFILIADOS
end

go

create proc pro_eliminar(
@idafiliado int
)
as 
begin
	delete from AFILIADOS where id = @idafiliado
end

go



select*from AFILIADOS
left join ESTATUS on Estatus.id = AFILIADOS.id
go


--************************ PROCEDIMIENTOS PARA PLANES ************************--


CREATE PROC planes_crear(
@plan varchar(1000),
@montoCobertura int,
@fechaRegistro datetime,
@estatus varchar(50)
)
as
begin
	insert into PLANES(Plann,Monto_Consumido,Fecha_Registro,Estatus) values(@plan,@montoCobertura,@fechaRegistro,@estatus)
end

go



CREATE PROC planes_actualizar(
@plan varchar(1000),
@montoCobertura int,
@fechaRegistro datetime,
@estatus varchar(50)
)
as
begin
	insert into PLANES(Plann,Monto_Consumido,Fecha_Registro,Estatus) values(@plan,@montoCobertura,@fechaRegistro,@estatus)
end

go