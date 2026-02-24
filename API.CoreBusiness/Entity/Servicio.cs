using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.CoreBusiness.Entity
{
    [Table("Servicios")]
    public class Servicio
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(500)]
        public string? Descripcion { get; set; } 

        
        public int DuracionMinutos { get; set; } 

        
        [Column(TypeName = "decimal(18,2)")] 
        public decimal Precio { get; set; }

        public bool Activo { get; set; } = true; 

        
        public int Id_Comercio { get; set; }
        
        
        [ForeignKey("Id_Comercio")]
        public virtual Comercio? Comercio { get; set; } 
    }
}