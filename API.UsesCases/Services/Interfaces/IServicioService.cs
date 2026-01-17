using API_CoreBusiness.Request;
using API_CoreBusiness.Response;
using System.Collections.Generic;

namespace API.UsesCases.Services.Interfaces
{
    public interface IServicioService
    {
        IEnumerable<ServicioResponse> GetAll();
        ServicioResponse GetById(int id);
        ServicioResponse Create(ServicioRequest request);
    }
}