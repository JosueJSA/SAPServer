﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Services.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SAPContext : DbContext
    {
        public SAPContext()
            : base("name=SAPContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BalanceDiario> BalanceDiario { get; set; }
        public virtual DbSet<CajaEntrada> CajaEntrada { get; set; }
        public virtual DbSet<CajaSalida> CajaSalida { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Cliente_Direccion> Cliente_Direccion { get; set; }
        public virtual DbSet<Ingrediente> Ingrediente { get; set; }
        public virtual DbSet<Insumo> Insumo { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<OrdenAProveedor> OrdenAProveedor { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<PedidoCliente> PedidoCliente { get; set; }
        public virtual DbSet<PedidoProveedor> PedidoProveedor { get; set; }
        public virtual DbSet<ProductoVenta> ProductoVenta { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Proveedor_Direccion> Proveedor_Direccion { get; set; }
        public virtual DbSet<Receta> Receta { get; set; }
        public virtual DbSet<SalidaExtraordinaria> SalidaExtraordinaria { get; set; }
        public virtual DbSet<Ingredientes> Ingredientes { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
    
        public virtual int SPChangeStatusInsumo(Nullable<int> codigo, string status, ObjectParameter key, ObjectParameter message)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(int));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPChangeStatusInsumo", codigoParameter, statusParameter, key, message);
        }
    
        public virtual int SPChangeStatusProducto(Nullable<int> codigo, string status, ObjectParameter key, ObjectParameter message)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(int));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPChangeStatusProducto", codigoParameter, statusParameter, key, message);
        }
    
        public virtual int SPChangeStatusPedidoCliente(Nullable<int> idPedidoCliente, string status, ObjectParameter key, ObjectParameter message)
        {
            var idPedidoClienteParameter = idPedidoCliente.HasValue ?
                new ObjectParameter("IdPedidoCliente", idPedidoCliente) :
                new ObjectParameter("IdPedidoCliente", typeof(int));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPChangeStatusPedidoCliente", idPedidoClienteParameter, statusParameter, key, message);
        }
    
        public virtual ObjectResult<ECliente> SPGCliente(Nullable<int> idCliente)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ECliente>("SPGCliente", idClienteParameter);
        }
    
        public virtual ObjectResult<EDireccion> SPGDirecciones(Nullable<int> idCliente)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EDireccion>("SPGDirecciones", idClienteParameter);
        }
    
        public virtual ObjectResult<EIngrediente> SPGIngredientes(Nullable<int> iDReceta)
        {
            var iDRecetaParameter = iDReceta.HasValue ?
                new ObjectParameter("IDReceta", iDReceta) :
                new ObjectParameter("IDReceta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EIngrediente>("SPGIngredientes", iDRecetaParameter);
        }
    
        public virtual ObjectResult<EInsumo> SPGInsumos(string criterio, string valor, Nullable<System.DateTime> fecha, string status)
        {
            var criterioParameter = criterio != null ?
                new ObjectParameter("Criterio", criterio) :
                new ObjectParameter("Criterio", typeof(string));
    
            var valorParameter = valor != null ?
                new ObjectParameter("Valor", valor) :
                new ObjectParameter("Valor", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EInsumo>("SPGInsumos", criterioParameter, valorParameter, fechaParameter, statusParameter);
        }
    
        public virtual ObjectResult<EPedidoCliente> SPGPedidosComunes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EPedidoCliente>("SPGPedidosComunes");
        }
    
        public virtual ObjectResult<EProductoComprado> SPGProductosComprados(Nullable<int> iDPedido)
        {
            var iDPedidoParameter = iDPedido.HasValue ?
                new ObjectParameter("IDPedido", iDPedido) :
                new ObjectParameter("IDPedido", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EProductoComprado>("SPGProductosComprados", iDPedidoParameter);
        }
    
        public virtual ObjectResult<EProducto> SPGProductos(string criterio, string valor, Nullable<System.DateTime> fecha, string status)
        {
            var criterioParameter = criterio != null ?
                new ObjectParameter("Criterio", criterio) :
                new ObjectParameter("Criterio", typeof(string));
    
            var valorParameter = valor != null ?
                new ObjectParameter("Valor", valor) :
                new ObjectParameter("Valor", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EProducto>("SPGProductos", criterioParameter, valorParameter, fechaParameter, statusParameter);
        }
    
        public virtual ObjectResult<EProducto> SPGProductoUnico(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EProducto>("SPGProductoUnico", idParameter);
        }
    
        public virtual int SPICliente(string nombre, string apellido, Nullable<int> codigoPostal, string telefono, string ciudad, Nullable<System.DateTime> nacimiento, string email, ObjectParameter key, ObjectParameter message)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var codigoPostalParameter = codigoPostal.HasValue ?
                new ObjectParameter("CodigoPostal", codigoPostal) :
                new ObjectParameter("CodigoPostal", typeof(int));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            var nacimientoParameter = nacimiento.HasValue ?
                new ObjectParameter("Nacimiento", nacimiento) :
                new ObjectParameter("Nacimiento", typeof(System.DateTime));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPICliente", nombreParameter, apellidoParameter, codigoPostalParameter, telefonoParameter, ciudadParameter, nacimientoParameter, emailParameter, key, message);
        }
    
        public virtual int SPIInsumo(Nullable<double> precioCompra, Nullable<double> cantidad, string nombre, string descripcion, string restricciones, string unidadMedida, string proveedorDeInsumo, ObjectParameter key, ObjectParameter message)
        {
            var precioCompraParameter = precioCompra.HasValue ?
                new ObjectParameter("PrecioCompra", precioCompra) :
                new ObjectParameter("PrecioCompra", typeof(double));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(double));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var restriccionesParameter = restricciones != null ?
                new ObjectParameter("Restricciones", restricciones) :
                new ObjectParameter("Restricciones", typeof(string));
    
            var unidadMedidaParameter = unidadMedida != null ?
                new ObjectParameter("UnidadMedida", unidadMedida) :
                new ObjectParameter("UnidadMedida", typeof(string));
    
            var proveedorDeInsumoParameter = proveedorDeInsumo != null ?
                new ObjectParameter("ProveedorDeInsumo", proveedorDeInsumo) :
                new ObjectParameter("ProveedorDeInsumo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPIInsumo", precioCompraParameter, cantidadParameter, nombreParameter, descripcionParameter, restriccionesParameter, unidadMedidaParameter, proveedorDeInsumoParameter, key, message);
        }
    
        public virtual int SPIPedidoCliente(Nullable<double> costoTotal, Nullable<int> cantidad, string tipoPedido, Nullable<int> idCliente, Nullable<int> idDireccion, ObjectParameter key, ObjectParameter message)
        {
            var costoTotalParameter = costoTotal.HasValue ?
                new ObjectParameter("CostoTotal", costoTotal) :
                new ObjectParameter("CostoTotal", typeof(double));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(int));
    
            var tipoPedidoParameter = tipoPedido != null ?
                new ObjectParameter("TipoPedido", tipoPedido) :
                new ObjectParameter("TipoPedido", typeof(string));
    
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            var idDireccionParameter = idDireccion.HasValue ?
                new ObjectParameter("IdDireccion", idDireccion) :
                new ObjectParameter("IdDireccion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPIPedidoCliente", costoTotalParameter, cantidadParameter, tipoPedidoParameter, idClienteParameter, idDireccionParameter, key, message);
        }
    
        public virtual int SPIProducto(Nullable<int> codigoReceta, Nullable<double> precioVenta, Nullable<double> precioCompra, Nullable<int> cantidad, string nombre, string foto, string descripcion, string restricciones, ObjectParameter key, ObjectParameter message)
        {
            var codigoRecetaParameter = codigoReceta.HasValue ?
                new ObjectParameter("CodigoReceta", codigoReceta) :
                new ObjectParameter("CodigoReceta", typeof(int));
    
            var precioVentaParameter = precioVenta.HasValue ?
                new ObjectParameter("PrecioVenta", precioVenta) :
                new ObjectParameter("PrecioVenta", typeof(double));
    
            var precioCompraParameter = precioCompra.HasValue ?
                new ObjectParameter("PrecioCompra", precioCompra) :
                new ObjectParameter("PrecioCompra", typeof(double));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var fotoParameter = foto != null ?
                new ObjectParameter("Foto", foto) :
                new ObjectParameter("Foto", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var restriccionesParameter = restricciones != null ?
                new ObjectParameter("Restricciones", restricciones) :
                new ObjectParameter("Restricciones", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPIProducto", codigoRecetaParameter, precioVentaParameter, precioCompraParameter, cantidadParameter, nombreParameter, fotoParameter, descripcionParameter, restriccionesParameter, key, message);
        }
    
        public virtual int SPUCantidadInsumo(Nullable<int> idInsumo, Nullable<int> cantidadProducto, Nullable<int> idReceta, ObjectParameter key, ObjectParameter message)
        {
            var idInsumoParameter = idInsumo.HasValue ?
                new ObjectParameter("IdInsumo", idInsumo) :
                new ObjectParameter("IdInsumo", typeof(int));
    
            var cantidadProductoParameter = cantidadProducto.HasValue ?
                new ObjectParameter("CantidadProducto", cantidadProducto) :
                new ObjectParameter("CantidadProducto", typeof(int));
    
            var idRecetaParameter = idReceta.HasValue ?
                new ObjectParameter("IdReceta", idReceta) :
                new ObjectParameter("IdReceta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPUCantidadInsumo", idInsumoParameter, cantidadProductoParameter, idRecetaParameter, key, message);
        }
    
        public virtual int SPUCliente(Nullable<int> id, string nombre, string apellido, Nullable<int> codigoPostal, string telefono, string ciudad, Nullable<System.DateTime> nacimiento, string email, ObjectParameter key, ObjectParameter message)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var codigoPostalParameter = codigoPostal.HasValue ?
                new ObjectParameter("CodigoPostal", codigoPostal) :
                new ObjectParameter("CodigoPostal", typeof(int));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            var nacimientoParameter = nacimiento.HasValue ?
                new ObjectParameter("Nacimiento", nacimiento) :
                new ObjectParameter("Nacimiento", typeof(System.DateTime));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPUCliente", idParameter, nombreParameter, apellidoParameter, codigoPostalParameter, telefonoParameter, ciudadParameter, nacimientoParameter, emailParameter, key, message);
        }
    
        public virtual int SPUInsumo(Nullable<int> codigo, Nullable<double> precioCompra, Nullable<double> cantidad, string nombre, string descripcion, string restricciones, string unidadMedida, string proveedorDeInsumo, ObjectParameter key, ObjectParameter message)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(int));
    
            var precioCompraParameter = precioCompra.HasValue ?
                new ObjectParameter("PrecioCompra", precioCompra) :
                new ObjectParameter("PrecioCompra", typeof(double));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(double));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var restriccionesParameter = restricciones != null ?
                new ObjectParameter("Restricciones", restricciones) :
                new ObjectParameter("Restricciones", typeof(string));
    
            var unidadMedidaParameter = unidadMedida != null ?
                new ObjectParameter("UnidadMedida", unidadMedida) :
                new ObjectParameter("UnidadMedida", typeof(string));
    
            var proveedorDeInsumoParameter = proveedorDeInsumo != null ?
                new ObjectParameter("ProveedorDeInsumo", proveedorDeInsumo) :
                new ObjectParameter("ProveedorDeInsumo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPUInsumo", codigoParameter, precioCompraParameter, cantidadParameter, nombreParameter, descripcionParameter, restriccionesParameter, unidadMedidaParameter, proveedorDeInsumoParameter, key, message);
        }
    
        public virtual int SPUProducto(Nullable<int> codigo, Nullable<int> codigoReceta, Nullable<double> precioVenta, Nullable<double> precioCompra, Nullable<int> cantidad, string nombre, string foto, string descripcion, string restricciones, ObjectParameter key, ObjectParameter message)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(int));
    
            var codigoRecetaParameter = codigoReceta.HasValue ?
                new ObjectParameter("CodigoReceta", codigoReceta) :
                new ObjectParameter("CodigoReceta", typeof(int));
    
            var precioVentaParameter = precioVenta.HasValue ?
                new ObjectParameter("PrecioVenta", precioVenta) :
                new ObjectParameter("PrecioVenta", typeof(double));
    
            var precioCompraParameter = precioCompra.HasValue ?
                new ObjectParameter("PrecioCompra", precioCompra) :
                new ObjectParameter("PrecioCompra", typeof(double));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var fotoParameter = foto != null ?
                new ObjectParameter("Foto", foto) :
                new ObjectParameter("Foto", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var restriccionesParameter = restricciones != null ?
                new ObjectParameter("Restricciones", restricciones) :
                new ObjectParameter("Restricciones", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPUProducto", codigoParameter, codigoRecetaParameter, precioVentaParameter, precioCompraParameter, cantidadParameter, nombreParameter, fotoParameter, descripcionParameter, restriccionesParameter, key, message);
        }
    
        public virtual int SPUCantidadInsumoCancelacion(Nullable<int> idInsumo, Nullable<int> cantidad, ObjectParameter key, ObjectParameter message)
        {
            var idInsumoParameter = idInsumo.HasValue ?
                new ObjectParameter("IdInsumo", idInsumo) :
                new ObjectParameter("IdInsumo", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPUCantidadInsumoCancelacion", idInsumoParameter, cantidadParameter, key, message);
        }
    
        public virtual ObjectResult<EPedidoClienteDetallado> SPGPedidoClienteDetallado(Nullable<int> codigoPedido)
        {
            var codigoPedidoParameter = codigoPedido.HasValue ?
                new ObjectParameter("CodigoPedido", codigoPedido) :
                new ObjectParameter("CodigoPedido", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EPedidoClienteDetallado>("SPGPedidoClienteDetallado", codigoPedidoParameter);
        }
    
        public virtual ObjectResult<EPedidoCliente> SPGPedidosClientes(Nullable<int> codigo, Nullable<System.DateTime> fecha)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(int));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EPedidoCliente>("SPGPedidosClientes", codigoParameter, fechaParameter);
        }
    
        public virtual ObjectResult<ECliente> SPG_SAP_Cliente(Nullable<int> idCliente)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ECliente>("SPG_SAP_Cliente", idClienteParameter);
        }
    
        public virtual ObjectResult<SPG_SAP_Usuario_Result> SPG_SAP_Usuario(string valor, string status)
        {
            var valorParameter = valor != null ?
                new ObjectParameter("Valor", valor) :
                new ObjectParameter("Valor", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPG_SAP_Usuario_Result>("SPG_SAP_Usuario", valorParameter, statusParameter);
        }
    
        public virtual ObjectResult<EUsuario> SPGUsuario(string valor, string status)
        {
            var valorParameter = valor != null ?
                new ObjectParameter("Valor", valor) :
                new ObjectParameter("Valor", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EUsuario>("SPGUsuario", valorParameter, statusParameter);
        }
    
        public virtual int SPUsuario(string email, string password, string nombre, string apellido, string tipoUsuario, string codigoPostal, string status, Nullable<double> salario, string telefono, string ciudad, ObjectParameter key, ObjectParameter message)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var tipoUsuarioParameter = tipoUsuario != null ?
                new ObjectParameter("TipoUsuario", tipoUsuario) :
                new ObjectParameter("TipoUsuario", typeof(string));
    
            var codigoPostalParameter = codigoPostal != null ?
                new ObjectParameter("CodigoPostal", codigoPostal) :
                new ObjectParameter("CodigoPostal", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var salarioParameter = salario.HasValue ?
                new ObjectParameter("Salario", salario) :
                new ObjectParameter("Salario", typeof(double));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPUsuario", emailParameter, passwordParameter, nombreParameter, apellidoParameter, tipoUsuarioParameter, codigoPostalParameter, statusParameter, salarioParameter, telefonoParameter, ciudadParameter, key, message);
        }
    
        public virtual int SPUUsuario(Nullable<int> clave, string email, string password, string nombre, string apellido, string tipoUsuario, string codigoPostal, string status, Nullable<double> salario, string telefono, string ciudad, ObjectParameter key, ObjectParameter message)
        {
            var claveParameter = clave.HasValue ?
                new ObjectParameter("Clave", clave) :
                new ObjectParameter("Clave", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var tipoUsuarioParameter = tipoUsuario != null ?
                new ObjectParameter("TipoUsuario", tipoUsuario) :
                new ObjectParameter("TipoUsuario", typeof(string));
    
            var codigoPostalParameter = codigoPostal != null ?
                new ObjectParameter("CodigoPostal", codigoPostal) :
                new ObjectParameter("CodigoPostal", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var salarioParameter = salario.HasValue ?
                new ObjectParameter("Salario", salario) :
                new ObjectParameter("Salario", typeof(double));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPUUsuario", claveParameter, emailParameter, passwordParameter, nombreParameter, apellidoParameter, tipoUsuarioParameter, codigoPostalParameter, statusParameter, salarioParameter, telefonoParameter, ciudadParameter, key, message);
        }
    
        public virtual int SPIUsuario(string email, string password, string nombre, string apellido, string tipoUsuario, string codigoPostal, string status, Nullable<double> salario, string telefono, string ciudad, ObjectParameter key, ObjectParameter message)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var tipoUsuarioParameter = tipoUsuario != null ?
                new ObjectParameter("TipoUsuario", tipoUsuario) :
                new ObjectParameter("TipoUsuario", typeof(string));
    
            var codigoPostalParameter = codigoPostal != null ?
                new ObjectParameter("CodigoPostal", codigoPostal) :
                new ObjectParameter("CodigoPostal", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var salarioParameter = salario.HasValue ?
                new ObjectParameter("Salario", salario) :
                new ObjectParameter("Salario", typeof(double));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPIUsuario", emailParameter, passwordParameter, nombreParameter, apellidoParameter, tipoUsuarioParameter, codigoPostalParameter, statusParameter, salarioParameter, telefonoParameter, ciudadParameter, key, message);
        }
    
        public virtual int SPChangeStatus_SAP_Usuario(Nullable<int> codigo, string status, ObjectParameter key, ObjectParameter message)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(int));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPChangeStatus_SAP_Usuario", codigoParameter, statusParameter, key, message);
        }
    
        public virtual ObjectResult<SPG_SAP_UsuarioEmail_Result> SPG_SAP_UsuarioEmail(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPG_SAP_UsuarioEmail_Result>("SPG_SAP_UsuarioEmail", emailParameter, passwordParameter);
        }
    
        public virtual int SPChangeStatusUsuario(Nullable<int> codigo, string status, ObjectParameter key, ObjectParameter message)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(int));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPChangeStatusUsuario", codigoParameter, statusParameter, key, message);
        }
    
        public virtual ObjectResult<EUsuario> SPGUsuarioEmail(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EUsuario>("SPGUsuarioEmail", emailParameter, passwordParameter);
        }
    }
}
