using API_CoreBusiness.DataContext;
using API_DataCore.Interfaces;
using API.CoreBusiness.Entity;
using API.GenericCore.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace API_DataCore.Repository
{
    public class ServicioRepository : GenericRepository<Servicio>, IServicioRepository
    {
        private readonly ApplicationDbContext _context;

        public ServicioRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void SoftDelete(Servicio servicio)
        {
            
            servicio.Activo = false;
            
           
            _context.Entry(servicio).State = EntityState.Modified;
        }
    }
}