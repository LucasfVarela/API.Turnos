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
        
    }
}