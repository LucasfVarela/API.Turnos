using API.CoreBusiness.Entity;
using API_CoreBusiness.DataContext;
using API_DataCore.Interfaces;
using API.GenericCore.GenericRepository;

namespace API_DataCore.Repository
{
    public class ComercioRepository : GenericRepository<Comercio>, IComercioRepository
    {
        private readonly ApplicationDbContext _context;

        public ComercioRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}