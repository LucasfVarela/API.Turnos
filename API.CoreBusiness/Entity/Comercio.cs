using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace API.CoreBusiness.Entity
{
    public class Comercio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Id_Categoria { get; set; }
        public char[] Dias { get; set; }
        public DateTime Horario_Inicio { get; set; }
        public DateTime Horario_Fin { get; set; }
        public JsonArray DatosAdicionales { get; set; }
    }
}
