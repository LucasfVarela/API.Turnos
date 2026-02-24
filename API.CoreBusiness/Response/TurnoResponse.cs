namespace API.CoreBusiness
{
    public class TurnoResponse
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public string? NombreUsuario { get; set; }
        
        public int Id_Comercio { get; set; } 
        public string? NombreComercio { get; set; }
        
        public string? DireccionComercio { get; set; }
        
        public int Id_Servicio { get; set; }
        public string? NombreServicio { get; set; }
        
        public bool Status { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public string? Observaciones { get; set; }
    }
}