using API.UsesCases.Services.Interfaces;
using API.UsesCases.UnitOfWork.Interfaces;
using API_CoreBusiness.Request;
using API_CoreBusiness.Response;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.UsesCases.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IUnitOfWork UnitOfWork;

        public ServicioService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IEnumerable<ServicioResponse> GetServicios()
        {
            var servicios = UnitOfWork.ServicioRepository.GetAll();

            return servicios.Select(s => new ServicioResponse
            {
                Id = s.Id,
                Nombre = s.Nombre,
                Precio = s.Precio
            });
        }

        public ServicioResponse GetServicioById(int id)
        {
            var servicio = UnitOfWork.ServicioRepository.GetById(id);
            if (servicio == null) return null;

            return new ServicioResponse
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre,
                Precio = servicio.Precio
            };
        }
        public ServicioResponse Crear(ServicioRequest request)
        {
            var nuevoServicio = new API.CoreBusiness.Entity.Servicio
            {
                Nombre = request.Nombre,
                Precio = request.Precio
            };

            UnitOfWork.ServicioRepository.Insert(nuevoServicio);
            UnitOfWork.Save();

            return new ServicioResponse
            {
                Id = nuevoServicio.Id,
                Nombre = nuevoServicio.Nombre,
                Precio = nuevoServicio.Precio
            };
        }
    }
}
