using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.CoreBusiness.Entity;
using System.Collections.Generic;

namespace API.UsesCases.Services.Interfaces
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetCategorias();
    }
}
