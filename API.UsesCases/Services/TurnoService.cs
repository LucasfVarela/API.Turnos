using API.CoreBusiness;
using API.CoreBusiness.Entity;
using API.UsesCases.Services.Interfaces;
using API.UsesCases.UnitOfWork;
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
            UnitOfWork.Save();
       
            return NewTurno;

            

            
        }

        public IEnumerable<TurnoResponse> GetAllTurnos()
        {
            var turnos = UnitOfWork.TurnoRepository.GetAll();
            return turnos.Select(MapToResponse);
        }

        public TurnoResponse GetTurnoById(int id)
        {
            var turno = UnitOfWork.TurnoRepository.GetById(id);
            return turno != null ? MapToResponse(turno) : null;
        }

        public bool UpdateTurno(int id, TurnoRequest request)
        {
            var entity = UnitOfWork.TurnoRepository.GetById(id);
            if (entity == null) return false;

            entity.Id_Usuario = request.Id_Usuario;
            entity.Id_Cliente = request.Id_Cliente;
            entity.Id_Servicio = request.Id_Servicio;
            entity.Status = request.Status;
            entity.Fecha_Inicio = request.Fecha_Inicio;
            entity.Fecha_Fin = request.Fecha_Fin;
            entity.Observaciones = request.Observaciones;

            UnitOfWork.TurnoRepository.Update(entity);
            UnitOfWork.Save();
            return true;
        }

        public bool DeleteTurno(int id)
        {
            var entity = UnitOfWork.TurnoRepository.GetById(id);
            if (entity == null) return false;

            UnitOfWork.TurnoRepository.Delete(id);
            UnitOfWork.Save();
            return true;
        }

        private TurnoResponse MapToResponse(Turno t)
        {
            return new TurnoResponse
            {
                Id = t.Id,
                Id_Usuario = t.Id_Usuario,
                Id_Cliente = t.Id_Cliente,
                Id_Servicio = t.Id_Servicio,
                Status = t.Status,
                Fecha_Inicio = t.Fecha_Inicio,
                Fecha_Fin = t.Fecha_Fin,
                Observaciones = t.Observaciones,
                
                NombreUsuario = t.Usuario?.Nombre
            };
        }

    }
}
