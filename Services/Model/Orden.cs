//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Orden
    {
        public int CodigoPedidoCliente { get; set; }
        public int CodigoProductoVenta { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    
        public virtual PedidoCliente PedidoCliente { get; set; }
        public virtual ProductoVenta ProductoVenta { get; set; }
    }
}