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
    
    public partial class EUsuario
    {
        public int Clave { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string TipoUsuario { get; set; }
        public string CodigoPostal { get; set; }
        public string Status { get; set; }
        public Nullable<double> Salario { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
        public System.DateTime Registro { get; set; }
        public Nullable<System.DateTime> Baja { get; set; }
    }
}
