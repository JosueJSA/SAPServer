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

    public partial class EReceta
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public List<EIngrediente> Ingredientes { get; set; }    
    }
}
