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
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<Personal_Direccion> Personal_Direccion { get; set; }
        public virtual DbSet<ProductoVenta> ProductoVenta { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Proveedor_Direccion> Proveedor_Direccion { get; set; }
        public virtual DbSet<Receta> Receta { get; set; }
        public virtual DbSet<SalidaExtraordinaria> SalidaExtraordinaria { get; set; }
    
        public virtual int SPIInsumo(Nullable<double> precioCompra, Nullable<int> cantidad, string nombre, string descripcion, string restricciones, string unidadMedida, string proveedorDeInsumo, ObjectParameter key, ObjectParameter message)
        {
            var precioCompraParameter = precioCompra.HasValue ?
                new ObjectParameter("PrecioCompra", precioCompra) :
                new ObjectParameter("PrecioCompra", typeof(double));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(int));
    
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
    
        public virtual int SPUInsumo(Nullable<int> codigo, Nullable<double> precioCompra, Nullable<int> cantidad, string nombre, string descripcion, string restricciones, string unidadMedida, string proveedorDeInsumo, ObjectParameter key, ObjectParameter message)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(int));
    
            var precioCompraParameter = precioCompra.HasValue ?
                new ObjectParameter("PrecioCompra", precioCompra) :
                new ObjectParameter("PrecioCompra", typeof(double));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(int));
    
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
    }
}
