using API.CoreBusiness.Entity;
using API.GenericCore.GenericRepository.Interfaces;
using API_CoreBusiness.Entity;
using API_CoreBusiness.Response;
using API_DataCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DataCore.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        ClienteResponse SoftDelete(Cliente cliente);
        Cliente? GetByEmail(string Email);
        bool ExisteUsuario(string email);

    }
}
