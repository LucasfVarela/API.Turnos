using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.CoreBusiness.Entity;
using API.UsesCases.Services.Interfaces;
using API.UsesCases.UnitOfWork.Interfaces;
using System.Collections.Generic;

namespace API.UsesCases.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoriaService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return unitOfWork.CategoriaRepository.GetAll();
        }
    }
}
