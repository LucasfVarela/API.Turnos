using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.CoreBusiness.Entity;
using API.GenericCore.GenericRepository;
using API_CoreBusiness.DataContext;
using API_DataCore.Interfaces;

namespace API_DataCore.Repository
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
