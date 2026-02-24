using API.CoreBusiness;
using API.CoreBusiness.Entity;
using API.CoreBusiness.Request;
using API.CoreBusiness.Response;
using API.UsesCases.Services.Interfaces;
using API.UsesCases.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
            
            turno.Usuario = null;
            turno.Comercio = null; 
            turno.Servicio = null;

            UnitOfWork.TurnoRepository.Insert(turno);
            UnitOfWork.Save();
       
            return turno;
        }

        public IEnumerable<TurnoResponse> GetAllTurnos()
        {
           
            var turnos = UnitOfWork.TurnoRepository.GetAll(includeProperties: "Usuario,Comercio,Servicio");
            return turnos.Select(MapToResponse);
        }

        public TurnoResponse GetTurnoById(int id)
        {
            var turno = UnitOfWork.TurnoRepository
                        .GetAll(includeProperties: "Usuario,Comercio,Servicio")
                        .FirstOrDefault(t => t.Id == id);

            return turno != null ? MapToResponse(turno) : null;
        }

        public bool UpdateTurno(int id, TurnoRequest request)
        {
            var entity = UnitOfWork.TurnoRepository.GetById(id);
            if (entity == null) return false;

            entity.Id_Usuario = request.Id_Usuario;
            entity.Id_Comercio = request.Id_Comercio; 
            entity.Id_Servicio = request.Id_Servicio;
            entity.Status = request.Status;
            entity.Fecha_Inicio = request.Fecha_Inicio;
            entity.Fecha_Fin = request.Fecha_Fin;
            entity.Observaciones = request.Observaciones;

            UnitOfWork.TurnoRepository.Update(entity);
            UnitOfWork.Save();
            return true;
        }

        public IEnumerable<HorarioDisponibleResponse> GetDisponibilidad(DisponibilidadRequest request)
        {
            var listaResultados = new List<HorarioDisponibleResponse>();


            #region EN ESTA REGION TIENE QUE IR LA CONFIGURACION DEL SERVICIO Y LA DEL COMERCIO POR EL MOMENTO TOMA VALORES FIJOS
           
            int horaApertura = 9;  
            int horaCierre = 18;   

            
             
            int duracionMinutos = 20; 

            #endregion
            

            
            var turnosOcupados = UnitOfWork.TurnoRepository.GetTurnosPorFecha(request.Fecha, request.Id_Usuario);

            DateTime inicioJornada = request.Fecha.Date.AddHours(horaApertura);
            DateTime finJornada = request.Fecha.Date.AddHours(horaCierre);

   
            DateTime tiempoActual = inicioJornada;

            // GENERA LOS SLOTS
            while (tiempoActual.AddMinutes(duracionMinutos) <= finJornada)
            {
                DateTime tiempoFinTentativo = tiempoActual.AddMinutes(duracionMinutos);

             
                // VALIDO CON LOS EXISTENTES
                bool estaOcupado = turnosOcupados.Any(t =>
                    t.Fecha_Inicio < tiempoFinTentativo &&
                    t.Fecha_Fin > tiempoActual
                );

                if (!estaOcupado)
                {
                    listaResultados.Add(new HorarioDisponibleResponse
                    {
                        HoraInicio = tiempoActual,
                        HoraFin = tiempoFinTentativo,
                        Disponible = true
                    });
                }

                // AVANZA AL SIGUIENTE
                tiempoActual = tiempoActual.AddMinutes(duracionMinutos);

                
            }

            return listaResultados;
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
                Id_Comercio = t.Id_Comercio,
                Id_Servicio = t.Id_Servicio,
                Status = t.Status,
                Fecha_Inicio = t.Fecha_Inicio,
                Fecha_Fin = t.Fecha_Fin,
                Observaciones = t.Observaciones,
                NombreUsuario = t.Usuario?.Nombre ?? "Usuario N/A",
                NombreComercio = t.Comercio?.Nombre ?? "Negocio no encontrado", 
                DireccionComercio = t.Comercio?.Direccion ?? "Negocio no encontrado",
                NombreServicio = t.Servicio?.Nombre ?? "Servicio no encontrado"
            };
        }
        public bool CancelarTurno(int id)
        {
            var entity = UnitOfWork.TurnoRepository.GetById(id);
            if (entity == null) return false;

            entity.Status = false;

            UnitOfWork.TurnoRepository.Update(entity);
            UnitOfWork.Save();

            return true;
        }
    }
}