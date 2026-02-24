using System;

namespace API.CoreBusiness.Response
{
    public class ComercioResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Id_Categoria { get; set; }
        public int Id_Cliente { get; set; }

        // ¡AGREGAMOS ESTO PARA QUE LLEGUE A ANGULAR!
        public string? Dias { get; set; }
        public DateTime? Horario_Inicio { get; set; }
        public DateTime? Horario_Fin { get; set; }
        public string? DatosAdicionales { get; set; }

    }

}