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

    public partial class ECliente
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int CodigoPostal { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Status { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
        public System.DateTime Nacimiento { get; set; }
        public int Edad { get; set; }
        public List<EDireccion> Direcciones { get; set; }
    }
}
