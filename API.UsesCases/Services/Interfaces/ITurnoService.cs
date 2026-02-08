using API.CoreBusiness;
using API.CoreBusiness.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.UsesCases.Services.Interfaces
{
    public interface ITurnoService
    {
        Turno NewTurno(Turno turno);
      
        IEnumerable<TurnoResponse> GetAllTurnos();
        TurnoResponse GetTurnoById(int id);
        bool UpdateTurno(int id, TurnoRequest request);
        bool DeleteTurno(int id);
    }
}
