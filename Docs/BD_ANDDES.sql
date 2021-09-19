CREATE DATABASE Anddes
-----
USE  Anddes
----------
CREATE TABLE T_Cargo(
IdCargo Int Primary Key,
Descripcion Varchar(250),
Estado Char(1),
UsuarioModificacion Varchar(20),
FechaModificacion DateTime)
-----------
CREATE TABLE T_TipoArea(
IdTipArea Int Primary Key,
Descripcion Varchar(250),
Estado Char(1),
UsuarioModificacion Varchar(20),
FechaModificacion DateTime)
----------
CREATE TABLE T_Area(
IdArea Int Primary Key,
Descripcion Varchar(250),
IdIprArea int Foreign Key References T_TipoArea(IdTipArea),
Estado Char(1),
UsuarioModificacion Varchar(20),
FechaModificacion DateTime)
----------
CREATE TABLE T_Item(
IdItem Int Primary Key,
Descripcion Varchar(250),
UnidadMedida Char(2),
Moneda Char(2),
Imagen Varchar(max),
AfectoImpuesto Char(1),
PrecioUnitarioDolares Money,
PrecioUnitarioLocal Money,
IdArea int Foreign Key References T_Area(IdArea),
Estado Char(1),
UsuarioModificacion Varchar(20),
FechaModificacion DateTime)
----------
CREATE TABLE T_Empleado(
IdEmpleado Int Primary Key,
Foto Varchar(max),
NombreEmpleado Varchar(100),
IdCargo int Foreign Key References T_Cargo(IdCargo),
IdArea int Foreign Key References T_Area(IdArea),
Estado Char(1),
UsuarioModificacion Varchar(20),
FechaModificacion DateTime)
-------
CREATE TABLE T_EmpleadoItem(
IdEmpItem Int Primary Key,
IdEmpleado int Foreign Key References T_Empleado(IdEmpleado),
IdItem int Foreign Key References T_Item(IdItem),
Estado Char(1),
UsuarioModificacion Varchar(20),
FechaModificacion DateTime)
--------
CREATE TABLE T_Contrato(
IdContrato Int Primary Key,
NumeroContrato Varchar(10),
FechaInicioCont Datetime,
FechaFinCont Datetime,
FechaRegistroCont DateTime,
SueldoActual Money,
MonedaPago Char(2),
IdEmpleado int Foreign Key References T_Empleado(IdEmpleado),
Estado Char(1),
UsuarioModificacion Varchar(20),
FechaModificacion DateTime)
----------
CREATE TABLE T_SolicitudSede(
IdSolCese Int Primary Key,
IdContrato int Foreign Key References T_Contrato(IdContrato),
MotivoCese Varchar(250),
Estado Char(1),
UsuarioModificacion Varchar(20),
FechaModificacion DateTime)
--------
CREATE TABLE T_SolicitudSedeDetalle(
IdSolCese Int ,
Secuencia Int,
IdEmpItem int,
Monto Money,
Estado Char(1),
UsuarioModificacion Varchar(20),
FechaModificacion DateTime,
primary key(IdSolCese,secuencia),
Constraint fk_SocitudDetalle Foreign Key(IdSolCese) references T_SolicitudSede(IdSolCese),
Constraint fk_SocitudEmpl Foreign Key(IdEmpItem) references T_EmpleadoItem(IdEmpItem))
--------