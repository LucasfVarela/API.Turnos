using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CoreBusiness.Response
{
    public class HorarioDisponibleResponse
    {
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public bool Disponible { get; set; }
    }
}
