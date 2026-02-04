using API_CoreBusiness.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace API.CoreBusiness.Entity
{
    public class Turno 
    {
        public int Id { get; set; }

        public int Id_Usuario { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Servicio { get; set; }
        public bool Status { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public string? Observaciones { get; set; }

        public virtual Usuarios Usuario { get; set; } 

        public virtual Cliente Cliente { get; set; }
        
     
    }
    
}
