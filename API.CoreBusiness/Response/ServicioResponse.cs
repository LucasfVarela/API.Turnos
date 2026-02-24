namespace API.CoreBusiness.Response;

public class ServicioResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Id_Comercio { get; set; }
    public decimal Precio { get; set; }         
    public int DuracionMinutos { get; set; }    
    public string? Descripcion { get; set; }    
    public bool Activo { get; set; }            
    
}