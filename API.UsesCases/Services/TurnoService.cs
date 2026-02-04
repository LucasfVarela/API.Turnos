using API.CoreBusiness.Entity;
using API.UsesCases.Services.Interfaces;
using API.UsesCases.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.UsesCases.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly IUnitOfWork UnitOfWork;
        public TurnoService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public Turno NewTurno(Turno turno)
        {

            Turno NewTurno = new Turno();
            NewTurno.Id_Usuario = turno.Id_Usuario;
            NewTurno.Id_Cliente = turno.Id_Cliente;
            NewTurno.Id_Servicio = turno.Id_Servicio;
            NewTurno.Status = turno.Status;
            NewTurno.Fecha_Inicio = turno.Fecha_Inicio;
            NewTurno.Fecha_Fin = turno.Fecha_Fin;
            NewTurno.Observaciones = turno.Observaciones;

            UnitOfWork.TurnoRepository.Insert(NewTurno);

       
            return NewTurno;

            //return new Turno()
            //{
            //    Id_Usuario = turno.Id_Usuario,
            //    Id_Cliente = turno.Id_Cliente,
            //    Id_Servicio = turno.Id_Servicio,
            //    Status = turno.Status,
            //    Fecha_Inicio = turno.Fecha_Inicio,
            //    Fecha_Fin = turno.Fecha_Fin,
            //    Observaciones = turno.Observaciones,

            //};
        }

    }
}
