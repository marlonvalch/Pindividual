//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pindividual.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Paises_Destino_Aeropuerto
    {
        public int id { get; set; }
        public int id_vuelo { get; set; }
        public string Paises { get; set; }
        public string Destino { get; set; }
        public string Aeropuerto { get; set; }
        public double Tarifa { get; set; }
    
        public virtual Vuelos Vuelos { get; set; }
    }
}