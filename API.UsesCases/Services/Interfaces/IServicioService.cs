using API.CoreBusiness.Entity;
using API.CoreBusiness.Request;
using API.CoreBusiness.Response;

namespace API.UsesCases.Services.Interfaces;

public interface IServicioService
{
    IEnumerable<ServicioResponse> GetServiciosByComercio(int idComercio);

    ServicioResponse GetServicioById(int id);

    ServicioResponse CreateServicio(ServicioRequest request);

    ServicioResponse UpdateServicio(int id, ServicioRequest request);

    bool DeleteServicio(int id);
}