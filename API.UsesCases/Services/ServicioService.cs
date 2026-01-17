using API.UsesCases.Services.Interfaces;
using API.UsesCases.UnitOfWork.Interfaces;
using API_CoreBusiness.Entity;
using API_CoreBusiness.Request;
using API_CoreBusiness.Response;
using System.Collections.Generic;
using System.Linq;

namespace API.UsesCases.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ServicioResponse> GetAll()
        {
            var servicios = _unitOfWork.ServicioRepository.GetAll();
            return servicios.Select(x => new ServicioResponse
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Precio = x.Precio
            });
        }

        public ServicioResponse GetById(int id)
        {
            var servicio = _unitOfWork.ServicioRepository.GetById(id);
            if (servicio == null) return null;

            return new ServicioResponse
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre,
                Precio = servicio.Precio
            };
        }

        public ServicioResponse Create(ServicioRequest request)
        {
            var newServicio = new Servicio
            {
                Nombre = request.Nombre,
                Precio = request.Precio
            };

            _unitOfWork.ServicioRepository.Insert(newServicio);
            _unitOfWork.Save();

            return new ServicioResponse
            {
                Id = newServicio.Id,
                Nombre = newServicio.Nombre,
                Precio = newServicio.Precio
            };
        }
    }

}