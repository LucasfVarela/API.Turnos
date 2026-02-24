using System.ComponentModel.DataAnnotations.Schema;
using API_CoreBusiness.Entity;

namespace API.CoreBusiness.Entity
{
    public class Turno 
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Comercio { get; set; } 
        public int Id_Servicio { get; set; }
        public bool Status { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; } 
        public string? Observaciones { get; set; }

        [ForeignKey("Id_Usuario")]
        public virtual Usuarios? Usuario { get; set; } 

        [ForeignKey("Id_Comercio")]
        public virtual Comercio? Comercio { get; set; } 

        [ForeignKey("Id_Servicio")]
        public virtual Servicio? Servicio { get; set; }
    }
}