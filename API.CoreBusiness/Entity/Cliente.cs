using API_CoreBusiness.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CoreBusiness.Entity
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Nombre { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool Activo { get; set; }
        [NotMapped]
        ///public int Id_Categoria { get; set; }
        public DateTime Fecha_Add { get; set; }
        public DateTime Fecha_Mod { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
