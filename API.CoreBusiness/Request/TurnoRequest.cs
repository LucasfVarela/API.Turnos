namespace API.CoreBusiness
{
    public class TurnoRequest
    {
        public int Id_Usuario { get; set; }
        public int Id_Comercio { get; set; } 
        public int Id_Servicio { get; set; }
        public bool Status { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; } 
        public string? Observaciones { get; set; }
    }
}