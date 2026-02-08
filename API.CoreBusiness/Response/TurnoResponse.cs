using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CoreBusiness
{
    public  class TurnoResponse
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public string NombreUsuario { get; set; } 
        public int Id_Cliente { get; set; }
        public int Id_Servicio { get; set; }
        public bool Status { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public string? Observaciones { get; set; }
    }
}
