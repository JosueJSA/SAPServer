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
    
    public partial class OrdenAProveedor
    {
        public int CodigoPedidoProveedor { get; set; }
        public int CodigoInsumo { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    
        public virtual Insumo Insumo { get; set; }
        public virtual PedidoProveedor PedidoProveedor { get; set; }
    }
}
