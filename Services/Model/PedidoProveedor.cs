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
    
    public partial class PedidoProveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PedidoProveedor()
        {
            this.OrdenAProveedor = new HashSet<OrdenAProveedor>();
        }
    
        public int Codigo { get; set; }
        public int ClaveProveedor { get; set; }
        public double Cantidad { get; set; }
        public string TipoPedido { get; set; }
        public string Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenAProveedor> OrdenAProveedor { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
