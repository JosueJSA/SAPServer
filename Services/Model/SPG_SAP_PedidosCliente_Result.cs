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
    
    public partial class SPG_SAP_PedidosCliente_Result
    {
        public int Codigo { get; set; }
        public double CostoTotal { get; set; }
        public string Status { get; set; }
        public System.DateTime Solicitud { get; set; }
        public Nullable<System.DateTime> Entrega { get; set; }
        public double Cantidad { get; set; }
        public string TipoPedido { get; set; }
        public Nullable<int> NumeroProductos { get; set; }
    }
}
