using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> rm-LN
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace API.CoreBusiness.Entity
{
    public class Servicio
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
    }
}
=======
namespace API_CoreBusiness.Entity
{
    public class Servicio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public decimal Precio { get; set; }
    }
}
>>>>>>> rm-LN
