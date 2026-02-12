using API.GenericCore.GenericRepository;
using API_CoreBusiness.DataContext;
using API_CoreBusiness.Entity;
using API_DataCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DataCore.Repository
{
    public class ServicioRepository : GenericRepository<Servicio>, IServicioRepository
    {
        public ServicioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
