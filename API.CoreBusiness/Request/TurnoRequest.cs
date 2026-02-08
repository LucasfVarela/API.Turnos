using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CoreBusiness
{
    public class TurnoRequest
    {
        [Required]
        public int Id_Usuario { get; set; }
        [Required]
        public int Id_Cliente { get; set; }
        [Required]
        public int Id_Servicio { get; set; }

        public bool Status { get; set; } = true; // Por defecto activo

        [Required]
        public DateTime Fecha_Inicio { get; set; }
        [Required]
        public DateTime Fecha_Fin { get; set; }

        public string? Observaciones { get; set; }
    }
}
