using API.CoreBusiness.Entity;
using API.GenericCore.GenericRepository;
using API_CoreBusiness.DataContext;
using API_DataCore.Interfaces;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DataCore.Repository
{
    public class TurnoRepository : GenericRepository<Turno> , ITurnoRepository
    {


        public TurnoRepository(ApplicationDbContext options) : base(options)
        {
                
        }

        public IEnumerable<Turno> GetTurnosPorFecha(DateTime fecha, int? idUsuario = null)
        {
            var query = context.Turno.AsQueryable();

            
            query = query.Where(t => t.Fecha_Inicio.Date == fecha.Date && t.Status == true);

            if (idUsuario.HasValue)
            {
                query = query.Where(t => t.Id_Usuario == idUsuario.Value);
            }

            return query.ToList();
        }
    }
}
