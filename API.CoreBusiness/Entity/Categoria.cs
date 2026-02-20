using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.CoreBusiness.Entity
{
    [Table("Categorias")]
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

    }
}
