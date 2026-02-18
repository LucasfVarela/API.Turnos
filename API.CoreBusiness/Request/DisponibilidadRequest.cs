using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CoreBusiness.Request
{
    public class DisponibilidadRequest
    {
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int Id_Servicio { get; set; }

        public int? Id_Usuario { get; set; }
    }
}
