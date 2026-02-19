namespace API.CoreBusiness.Request;

public class ServicioRequest
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string? Descripcion { get; set; } 
    public decimal Precio { get; set; } 
    public int DuracionMinutos { get; set; } 
    public bool Activo { get; set; }
    public int Id_Comercio { get; set; }
}