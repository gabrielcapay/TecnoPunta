
CREATE TABLE Carrito (
    DNI_Vendedor INT NOT NULL,
    Total DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (DNI_Vendedor)
);

CREATE TABLE CarritoDetalle (
    id_CarritoDetalle INT IDENTITY(1,1) NOT NULL,
    Cantidad INT NOT NULL,
    SubTotal DECIMAL(10, 2) NOT NULL,
    DNI_Vendedor INT NOT NULL,
    FechaUltimaModificacion DATETIME NOT NULL,
    Producto VARCHAR(100) NOT NULL,
    PRIMARY KEY (id_CarritoDetalle)
);

CREATE TABLE Clientes (
    DNI_Cliente INT NOT NULL,
    Nombre_Cliente VARCHAR(100) NOT NULL,
    Apellido_Cliente VARCHAR(100) NOT NULL,
    Telefono_Cliente VARCHAR(20) NOT NULL,
    Correo_Cliente VARCHAR(150) NOT NULL,
    Direccion_Cliente VARCHAR(150) NOT NULL,
    Estado_Cliente VARCHAR(10),
    Id_Sexo INT,
    fechaCreacion DATETIME,
    genero VARCHAR(10),
    PRIMARY KEY (DNI_Cliente)
);

CREATE TABLE Condicion (
    Id_Condicion INT IDENTITY(1,1) NOT NULL,
    Descripcion_Estado VARCHAR(100) NOT NULL,
    PRIMARY KEY (Id_Condicion)
);

CREATE TABLE Estado (
    Id_Estado INT NOT NULL,
    Descripcion_Estado VARCHAR(50) NOT NULL,
    PRIMARY KEY (Id_Estado)
);

CREATE TABLE Marcas (
    Id_Marca INT IDENTITY(1,1) NOT NULL,
    Nombre_Marca VARCHAR(100) NOT NULL,
    PRIMARY KEY (Id_Marca)
);

CREATE TABLE MetodoDePago (
    Id_MetodoDePago INT IDENTITY(1,1) NOT NULL,
    Descripcion_MetodoDePago VARCHAR(100) NOT NULL,
    PRIMARY KEY (Id_MetodoDePago)
);

CREATE TABLE Productos (
    Modelo_Producto VARCHAR(100) NOT NULL,
    Nombre_Producto VARCHAR(100) NOT NULL,
    SistemaOperativo_Producto VARCHAR(100) NOT NULL,
    Almacenamiento_Producto VARCHAR(100) NOT NULL,
    Ram_Producto VARCHAR(100) NOT NULL,
    Stock_Producto INT NOT NULL,
    Precio_Producto DECIMAL(10, 2) NOT NULL,
    Id_Marca INT,
    Id_Condicion INT,
    PRIMARY KEY (Modelo_Producto)
);

CREATE TABLE Roles (
    Id_Rol INT NOT NULL,
    Descripcion_Rol VARCHAR(50) NOT NULL,
    PRIMARY KEY (Id_Rol)
);

CREATE TABLE Sexo (
    Id_Sexo INT NOT NULL,
    Descripcion_Sexo VARCHAR(50) NOT NULL,
    PRIMARY KEY (Id_Sexo)
);

CREATE TABLE Usuarios (
    DNI_Usuario INT NOT NULL,
    Usuario VARCHAR(100) NOT NULL,
    Nombre_Usuario VARCHAR(100) NOT NULL,
    Apellido_Usuario VARCHAR(100) NOT NULL,
    Correo_Usuario VARCHAR(150) NOT NULL,
    Sueldo_Usuario DECIMAL(10, 2) NOT NULL,
    Telefono_Usuario VARCHAR(100) NOT NULL,
    Contraseña VARCHAR(100) NOT NULL,
    Sexo_Usuario INT NOT NULL,
    Rol_Usuario INT NOT NULL,
    fechaDeRegistro DATETIME NOT NULL,
    Estado_Usuarios VARCHAR(10),
    PRIMARY KEY (DNI_Usuario)
);

CREATE TABLE Venta (
    idVenta INT IDENTITY(1,1) NOT NULL,
    DNI_Vendedor INT NOT NULL,
    DNI_Cliente INT NOT NULL,
    Id_MetodoDePago INT NOT NULL,
    Total DECIMAL(10, 2) NOT NULL,
    FechaVenta DATETIME NOT NULL,
    PRIMARY KEY (idVenta)
);

CREATE TABLE VentaDetalle (
    idVenta INT NOT NULL,
    Cantidad INT NOT NULL,
    SubTotal DECIMAL(10, 2) NOT NULL,
    Producto VARCHAR(100) NOT NULL
);
