using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_CoreBusiness.Request
{
    public class ServicioRequest
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
    }
}
