using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Nodes;

namespace API.CoreBusiness.Entity
{
    [Table("Comercios")]
    public class Comercio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } 
        
        
        
        public string? Direccion { get; set; } 
        public int Id_Categoria { get; set; }
        public int Id_Cliente { get; set; } 
        
        
        public string? Dias { get; set; } 
        
       
        public DateTime? Horario_Inicio { get; set; } 
        public DateTime? Horario_Fin { get; set; } 
        
        public string? DatosAdicionales { get; set; } 
    }
}