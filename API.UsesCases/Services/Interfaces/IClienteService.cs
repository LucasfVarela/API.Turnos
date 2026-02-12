using API.CoreBusiness.Entity;
using API_CoreBusiness.Entity;
using API_CoreBusiness.Request;
using API_CoreBusiness.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.UsesCases.Services.Interfaces
{
    public interface IClienteService
    {
        ClienteResponse Login(string email, string password);
        ClienteResponse Registrar(ClienteRequest clienteRequest, string password);
        IEnumerable<Cliente> GetClientes();
        string GetToken(ClienteResponse usuarioResponse);
        ClienteResponse DeleteUsuario(int Id_Cliente);
    }
}
