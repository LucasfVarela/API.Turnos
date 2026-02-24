namespace API.CoreBusiness.Request;

public class ComercioRequest
{
    public string Nombre { get; set; }
    public string? Direccion { get; set; }
    public int Id_Categoria { get; set; }
    public int Id_Cliente { get; set; } 
    public string? Dias { get; set; } 
    public string? Horario_Inicio { get; set; } 
    public string? Horario_Fin { get; set; }
    public string? DatosAdicionales { get; set; }
}