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
    
    public partial class CajaSalida
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CajaSalida()
        {
            this.BalanceDiario = new HashSet<BalanceDiario>();
        }
    
        public int Id { get; set; }
        public int B_1000 { get; set; }
        public int B_500 { get; set; }
        public int B_200 { get; set; }
        public int B_100 { get; set; }
        public int B_50 { get; set; }
        public int B_20 { get; set; }
        public int M_20 { get; set; }
        public int M_10 { get; set; }
        public int M_5 { get; set; }
        public int M_2 { get; set; }
        public int M_1 { get; set; }
        public int C_50 { get; set; }
        public int C_20 { get; set; }
        public int C_10 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BalanceDiario> BalanceDiario { get; set; }
    }
}
