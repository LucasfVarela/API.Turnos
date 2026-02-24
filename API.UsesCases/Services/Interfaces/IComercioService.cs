using API.CoreBusiness.Response;
using API.CoreBusiness.Request;
using System.Collections.Generic;

namespace API.UsesCases.Services.Interfaces
{
    public interface IComercioService
    {
        IEnumerable<ComercioResponse> GetComercios();
        ComercioResponse CrearComercio(ComercioRequest request);
        ComercioResponse? GetComercioPorCliente(int idCliente);
        ComercioResponse ActualizarComercio(int id, ComercioRequest request);
    }
}