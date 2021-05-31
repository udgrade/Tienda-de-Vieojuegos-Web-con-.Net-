--//----------BASIC_COMMANDS----------//--
--DB--------------------------------------
--C [CREATE DATABASE NAME]
--R [USE NAME]
--U [NO EXISTE UN COMANDO PARA RENOMBRAR UNA BASE DE DATOS]
--D [DROP DATABASE NAME]
--DB--------------------------------------
------------------------------------------------------------------------------------------------------------------
--TABLES----------------------------------
--C [CREATE TABLE NAME]
--R [NO EXISTE UN COMANDO PARA RENOMBRAR UNA BASE DE DATOS]
--U [ALTER TABLE Name.viejo RENAME Name.NEW]
--D [DROP TABLE NAME]
--tables
--//----------BASIC_COMMANDS----------//--
--CREAR_BASE_DE_DATOS.
CREATE DATABASE GameStoreDB;

--USAR_BASE_DE_DATOS.
USE GameStoreDB;
--//----------//----------//----------//----------//----------//----------//--
--//----------TABLA_CLIENTES----------//--
CREATE TABLE Usuarios(
	--llave_Primaria & Contraseña.
	Codi_User INT PRIMARY KEY NOT NULL,
	--Variables.
	Mail_User VARCHAR (100) NOT NULL, --//Correo
	Pass_User VARCHAR (20) NOT NULL, --//Contraseña
	Name_User VARCHAR (20) NOT NULL, --//Nick_Name.
	FNac_User DATE, --//Fecha_De_Nacimiento.
);
--//----------TABLA_CLIENTES----------//--
--//----------//----------//----------//----------//----------//----------//--
--//----------TABLA_PRODUCTOS----------//--

CREATE TABLE Productos(
	--llave_Primaria.
	Codi_Prod INT PRIMARY KEY NOT NULL,
	--Variables.
	Name_Prod VARCHAR (100) NOT NULL, --//Nombre
	Desp_Prod VARCHAR (800) NOT NULL, --//Descripción
	Pric_Prod FLOAT NOT NULL, --//Precio -922,337,203,685,477.5808 to 922,337,203,685,477.5807
	Genero varchar(200),
	Imgn_Prod VARCHAR (MAX) --//Imagen-https://docs.microsoft.com/es-es/sql/t-sql/data-types/ntext-text-and-image-transact-sql?view=sql-server-ver15
);


--//----------TABLA_PRODUCTOS----------//--
--//----------//----------//----------//----------//----------//----------//--
--//----------TABLA_FACTURAS----------//--
CREATE TABLE Facturas(
	--Llave_Primaria.
	Codi_Fact INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	--Llaves_Foraneas.
	Codi_UserUsuarios nvarchar(450) NOT NULL,
	Codi_ProdProductos INT NOT NULL,
	--Variables.
	Fech_Fact DATE NOT NULL, --//Fecha De La Compra
	Prec_Fact FLOAT NOT NULL, --//Precio final de factura
	--Invocar_llaves_Foraneas.
CONSTRAINT fk_UsuariosFact  FOREIGN KEY (Codi_UserUsuarios) REFERENCES AspNetUsers (Id),
CONSTRAINT fk_ProductosFact FOREIGN KEY (Codi_ProdProductos) REFERENCES Productos (Codi_Prod)
);
--//----------TABLA_FACTURAS----------//--
--//----------//----------//----------//----------//----------//----------//--
--//----------TABLA_REPORTES----------//--
CREATE TABLE Reportes(
	--Llave_Primaria.
	Codi_Repo INT PRIMARY KEY NOT NULL,
	--Llaves_Foraneas.
	Codi_UserUsuarios INT NOT NULL,
	Codi_ProdProductos INT NOT NULL,
	--Variables.
	Fech_Repo DATE NOT NULL, --//Fecha Del Reporte.
	Name_Repo VARCHAR (100) NOT NULL, --//Nombre
	Desp_Repo VARCHAR (800) NOT NULL, --//Descripción
	--Invocar_llaves_Foraneas.
CONSTRAINT fk_UsuariosRepo  FOREIGN KEY (Codi_UserUsuarios) REFERENCES Usuarios  (Codi_User),
CONSTRAINT fk_ProductosRepo FOREIGN KEY (Codi_ProdProductos) REFERENCES Productos (Codi_Prod)
);
--//----------TABLA_REPORTES----------//--
--//----------//----------//----------//----------//----------//----------//--
--//----------//-----Puntuacion----------//--
CREATE TABLE Puntuaciones(	
	--Llave_Primaria.
	Codi_Punt INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	--Llaves_Foraneas.
	Codi_UserUsuarios nvarchar(450) NOT NULL,
	Codi_ProdProductos INT NOT NULL,
	--Variables.
	Scor_Punt INT NOT NULL, --//Puntuación	
	--Invocar_llaves_Foraneas.
CONSTRAINT fk_UsuariosPunt  FOREIGN KEY (Codi_UserUsuarios) REFERENCES AspNetUsers (Id),
CONSTRAINT fk_ProductosPunt FOREIGN KEY (Codi_ProdProductos) REFERENCES Productos (Codi_Prod),
);
--//----------Puntuacion----------//--
--//----------//----------//----------//----------//----------//----------//--
--//----------//-----Comentarios----------//--
CREATE TABLE Comentarios(
	--Llave_Primaria.
	Codi_Come INT PRIMARY KEY NOT NULL,
	--Llaves_Foraneas.
	Codi_UserUsuarios INT NOT NULL,
	Codi_ProdProductos INT NOT NULL,
	--Variables.
	Come_Come VARCHAR (800) NOT NULL,
	--Invocar_llaves_Foraneas.
CONSTRAINT fk_UsuariosCome  FOREIGN KEY (Codi_UserUsuarios) REFERENCES Usuarios (Codi_User),
CONSTRAINT fk_ProductosCome FOREIGN KEY (Codi_ProdProductos) REFERENCES Productos (Codi_Prod)
);
--//----------Comentarios----------//--
--//----------//----------//----------//----------//----------//----------//--
--//Publicar datos para probar registros.
SELECT * FROM Productos;

