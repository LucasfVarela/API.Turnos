using API_CoreBusiness.Request;
using API_CoreBusiness.Response;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.UsesCases.Services.Interfaces
{
    public interface IServicioService
    {
        IEnumerable<ServicioResponse> GetServicios();
        ServicioResponse GetServicioById(int id);
        ServicioResponse Crear(ServicioRequest request);
    }
}
