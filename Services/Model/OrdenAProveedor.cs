//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
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
