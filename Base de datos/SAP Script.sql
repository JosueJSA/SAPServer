--Created By Josue Alarcón

CREATE DATABASE SAP;
Go
USE SAP;

CREATE TABLE [Empleado] (
    [Clave] INT IDENTITY (1, 1) NOT NULL,
	[Email] NVARCHAR (500) NOT NULL,
    [Password] NVARCHAR (100) NOT NULL, 
    [Nombre] NVARCHAR (100) NOT NULL,
    [Apellidos] NVARCHAR (100) NOT NULL,
	[TipoUsuario] NVARCHAR (100) NOT NULL, -- Mesero | Contador	| Administrador | Empleado | Call taker
	[CodigoPostal] INT,
	[Status] NVARCHAR (100) NOT NULL, -- Activo | Dado de baja
	[Puesto] NVARCHAR (100) NOT NULL, -- Administrador | Contador
	[Salario] FLOAT,
	[Telefono] NVARCHAR (100) NOT NULL, 
	[Ciudad] NVARCHAR (100), 
	[Registro] DATETIME NOT NULL, 
	[Baja] DATETIME, 
    CONSTRAINT [PK_dbo.Personal] PRIMARY KEY CLUSTERED ([Clave] ASC)
);

CREATE TABLE [Empleado.Direccion] (
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[IdEmpleado] INT NOT NULL,
	[Calle] NVARCHAR (500) NOT NULL,
	[Numero] INT NOT NULL,
	CONSTRAINT [PK_dbo.Personal.Direccion] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [PK_dbo.Personal.Direccion.Personal] FOREIGN KEY ([IdEmpleado]) REFERENCES [dbo].[Empleado] ([Clave]) ON UPDATE CASCADE,
);

CREATE TABLE [Cliente] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Email] NVARCHAR (500),
	[CodigoPostal] INT NOT NULL,
    [Nombre] NVARCHAR (500) NOT NULL,
    [Apellido] NVARCHAR (500) NOT NULL,
    [Status] NVARCHAR (100) NOT NULL, -- Activo | Dado de baja
    [Telefono] NVARCHAR (100) NOT NULL,
    [Ciudad] NVARCHAR (100) NOT NULL,
    [Nacimiento] DATETIME NOT NULL,
    [Edad] INT NOT NULL,
    CONSTRAINT [PK_dbo.Cliente] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [Cliente.Direccion] (
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[IdCliente] INT NOT NULL,
	[Calle] NVARCHAR (500) NOT NULL,
	[Numero] INT NOT NULL,
	[Colonia] NVARCHAR (500) NOT NULL,
	CONSTRAINT [PK_dbo.Cliente.Direccion] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [PK_dbo.Cliente.Direccion.Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([Id]) ON UPDATE CASCADE,
);

CREATE TABLE [Insumo] (
    [Codigo] INT IDENTITY (1, 1) NOT NULL,
	[PrecioCompra] FLOAT NOT NULL,
	[Cantidad] FLOAT NOT NULL,
    [Nombre] NVARCHAR (100) NOT NULL,
    [Descripcion] NVARCHAR (500) NOT NULL,
    [Restricciones] NVARCHAR (500) NOT NULL,
    [Status] NVARCHAR (100) NOT NULL, -- Activo | Dado de baja
	[Registro] DATETIME NOT NULL,
	[UnidadMedida] NVARCHAR (50) NOT NULL,
	[ProveedorDeInsumo] NVARCHAR (100),
    CONSTRAINT [PK_dbo.Insumo] PRIMARY KEY CLUSTERED ([Codigo] ASC)
);

CREATE TABLE [Proveedor] (
	[Clave] INT IDENTITY (1, 1) NOT NULL,
    [Email] NVARCHAR (500),
    [Nombre] NVARCHAR (100) NOT NULL,
    [Rfc] NVARCHAR (100) NOT NULL,
    [CategoriaInsumo] NVARCHAR (500) NOT NULL,
    [Status] NVARCHAR (100) NOT NULL, -- Activo | Dado de baja
    [Telefono] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_dbo.Proveedor] PRIMARY KEY CLUSTERED ([Clave] ASC)
);

CREATE TABLE [Proveedor.Direccion] (
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[IdProveedor] INT NOT NULL,
	[Calle] NVARCHAR (500) NOT NULL,
	[Numero] INT NOT NULL,
	CONSTRAINT [PK_dbo.Proveedor.Direccion] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [PK_dbo.Proveedor.Direccion.Proveedor] FOREIGN KEY ([IdProveedor]) REFERENCES [dbo].[Proveedor] ([Clave]) ON UPDATE CASCADE,
);

CREATE TABLE [Receta] (
    [Clave] INT IDENTITY (1, 1) NOT NULL,
	[Descripcion] NVARCHAR (500) NOT NULL
    CONSTRAINT [PK_dbo.Receta] PRIMARY KEY CLUSTERED ([Clave] ASC)
);

CREATE TABLE [Ingrediente] (
	[ClaveReceta] INT NOT NULL,
	[CodigoInsumo] INT NOT NULL,
	[Cantidad] FLOAT NOT NULL,
	CONSTRAINT [PK_Ingrediente] PRIMARY KEY(ClaveReceta, CodigoInsumo),
	CONSTRAINT [PK_dbo.Ingrediente.Receta] FOREIGN KEY ([ClaveReceta]) REFERENCES [dbo].[Receta] ([Clave]) ON UPDATE CASCADE,
	CONSTRAINT [PK_dbo.Ingrediente.Insumo] FOREIGN KEY ([CodigoInsumo]) REFERENCES [dbo].[Insumo] ([Codigo]) ON UPDATE CASCADE
);

CREATE TABLE [ProductoVenta] (
	[Codigo] INT IDENTITY (1, 1) NOT NULL,
	[CodigoReceta] INT,
	[PrecioVenta] FLOAT NOT NULL,
	[PrecioCompra] FLOAT NOT NULL,
	[Cantidad] INT NOT NULL,
    [Nombre] NVARCHAR (100) NOT NULL,
    [Foto] NVARCHAR (500) NOT NULL,
    [Descripcion] NVARCHAR (500) NOT NULL,
    [Restricciones] NVARCHAR (500) NOT NULL,
    [Status] NVARCHAR (100) NOT NULL, -- Activo | Dado de baja
	[Registro] DATETIME NOT NULL,
	CONSTRAINT [PK_dbo.ProductoVenta] PRIMARY KEY CLUSTERED ([Codigo] ASC) 
);


--Abstract table
CREATE TABLE [Pedido] (
	[Codigo] INT IDENTITY (1, 1) NOT NULL,
	[CostoTotal] FLOAT NOT NULL,
	[Status] NVARCHAR (100) NOT NULL,
	[Solicitud] DATETIME NOT NULL,
	[Entrega] DATETIME,
	CONSTRAINT [PK_dbo.Pedido] PRIMARY KEY CLUSTERED ([Codigo] ASC)
);

CREATE TABLE [PedidoCliente] (
	[Codigo] INT NOT NULL,
	[IdCliente] INT,
	[Cantidad] FLOAT NOT NULL,
	[IdDireccion] INT,
	[TipoPedido] NVARCHAR (100) NOT NULL,
	CONSTRAINT [PK_dbo.PedidoCliente] PRIMARY KEY (Codigo),
	CONSTRAINT [PK_dbo.PedidoCliente.Pedido] FOREIGN KEY ([Codigo]) REFERENCES [dbo].[Pedido] ([Codigo]) ON UPDATE CASCADE,
	CONSTRAINT [PK_dbo.PedidoCliente.Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([Id]) ON UPDATE CASCADE 
);

CREATE TABLE [PedidoProveedor] (
	[Codigo] INT NOT NULL,
	[ClaveProveedor] INT NOT NULL,
	[Cantidad] FLOAT NOT NULL,
	[TipoPedido] NVARCHAR (100) NOT NULL, -- En establecimiento | A domicilio
	CONSTRAINT [PK_dbo.PedidoAProveedor] PRIMARY KEY (Codigo),
	CONSTRAINT [PK_dbo.PedidoAProveedor.Pedido] FOREIGN KEY ([Codigo]) REFERENCES [dbo].[Pedido] ([Codigo]) ON UPDATE CASCADE,
	CONSTRAINT [PK_dbo.PedidoAProveedor.Proveedor] FOREIGN KEY ([ClaveProveedor]) REFERENCES [dbo].[Proveedor] ([Clave]) ON UPDATE CASCADE
);

CREATE TABLE [Orden] (
	[CodigoPedido] INT NOT NULL,
	[CodigoProductoVenta] INT NOT NULL,
	[Cantidad] INT NOT NULL,
	[Precio] FLOAT NOT NULL,
	CONSTRAINT [PK_Orden] PRIMARY KEY(CodigoPedido, CodigoProductoVenta),
	CONSTRAINT [PK_dbo.Orden.PedidoCliente] FOREIGN KEY ([CodigoPedido]) REFERENCES [dbo].[PedidoCliente] ([Codigo]) ON UPDATE CASCADE,
	CONSTRAINT [PK_dbo.Orden.ProductoVenta] FOREIGN KEY ([CodigoProductoVenta]) REFERENCES [dbo].[ProductoVenta] ([Codigo]) ON UPDATE CASCADE
);

CREATE TABLE [OrdenAProveedor] (
	[CodigoPedidoProveedor] INT NOT NULL,
	[CodigoInsumo] INT NOT NULL,
	[Cantidad] INT NOT NULL,
	[Precio] FLOAT NOT NULL,
	CONSTRAINT [PK_OrdenAProveedor] PRIMARY KEY(CodigoPedidoProveedor, CodigoInsumo),
	CONSTRAINT [PK_dbo.Orden.PedidoAProveedor] FOREIGN KEY ([CodigoPedidoProveedor]) REFERENCES [dbo].[PedidoProveedor] ([Codigo]) ON UPDATE CASCADE,
	CONSTRAINT [PK_dbo.OrdenAProveedor.Insumo] FOREIGN KEY ([CodigoInsumo]) REFERENCES [dbo].[Insumo] ([Codigo]) ON UPDATE CASCADE
);

CREATE TABLE [CajaEntrada] (
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[B_1000] INT NOT NULL,
	[B_500] INT NOT NULL,
	[B_200] INT NOT NULL,
	[B_100] INT NOT NULL,
	[B_50] INT NOT NULL,
	[B_20] INT NOT NULL,
	[M_20] INT NOT NULL,
	[M_10] INT NOT NULL,
	[M_5] INT NOT NULL,
	[M_2] INT NOT NULL,
	[M_1] INT NOT NULL,
	[C_50] INT NOT NULL,
	[C_20] INT NOT NULL,
	[C_10] INT NOT NULL,
	CONSTRAINT [PK_dbo.CajaEntrada] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [CajaSalida] (
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[B_1000] INT NOT NULL,
	[B_500] INT NOT NULL,
	[B_200] INT NOT NULL,
	[B_100] INT NOT NULL,
	[B_50] INT NOT NULL,
	[B_20] INT NOT NULL,
	[M_20] INT NOT NULL,
	[M_10] INT NOT NULL,
	[M_5] INT NOT NULL,
	[M_2] INT NOT NULL,
	[M_1] INT NOT NULL,
	[C_50] INT NOT NULL,
	[C_20] INT NOT NULL,
	[C_10] INT NOT NULL,
	CONSTRAINT [PK_dbo.CajaSalida] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [BalanceDiario] (
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[IdPersonal] INT NOT NULL,
	[TiempoInicio] DATETIME NOT NULL,
	[TiempoFinal] DATETIME NOT NULL,
	[TotalSalidaCalculado] FLOAT NOT NULL,
	[TotalEntradaClaculado] FLOAT NOT NULL,
	[SalidaDeCaja] INT NOT NULL,
	[EntradaDeCaja] INT NOT NULL,
	[Ganancia] FLOAT NOT NULL,
	[CantidadEnCaja] FLOAT NOT NULL,
	CONSTRAINT [PK_dbo.BalanceDiario] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [PK_dbo.Balance.CajaEntrada] FOREIGN KEY ([EntradaDeCaja]) REFERENCES [dbo].[CajaEntrada] ([Id]) ON UPDATE CASCADE,
	CONSTRAINT [PK_dbo.Balance.CajaSalida] FOREIGN KEY ([SalidaDeCaja]) REFERENCES [dbo].[CajaSalida] ([Id]) ON UPDATE CASCADE
);

CREATE TABLE [SalidaExtraordinaria] (
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[IdBalance] INT NOT NULL,
	[Descripcion] NVARCHAR (500) NOT NULL,
	[UsuarioRegistrador] NVARCHAR (100) NOT NULL,
	[Importe] FLOAT NOT NULL,
	[Registro] DATETIME NOT NULL,
	CONSTRAINT [PK_dbo.Salida] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [PK_dbo.Salida.Balance] FOREIGN KEY ([IdBalance]) REFERENCES [dbo].[BalanceDiario] ([Id]) ON UPDATE CASCADE
);


USE SAP;
CREATE UNIQUE INDEX PK_dbo_Personal_Email ON [Empleado] ([Email]);
CREATE UNIQUE INDEX PK_dbo_Cliente_Email ON [Cliente] ([Email]);
CREATE UNIQUE INDEX PK_dbo_Insumo ON [Insumo] ([Nombre]);
CREATE UNIQUE INDEX PK_dbo_Proveedor ON [Proveedor] ([Nombre]);
CREATE UNIQUE INDEX PK_dbo_ProductoVenta ON [ProductoVenta] ([Nombre]);
