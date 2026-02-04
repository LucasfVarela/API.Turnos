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
    }
}
