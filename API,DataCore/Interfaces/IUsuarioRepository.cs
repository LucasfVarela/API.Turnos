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
    public interface IUsuarioRepository : IGenericRepository<Usuarios>
    {
        UsuarioResponse SoftDelete(Usuarios usuarios);
        Usuarios? GetByEmail(string Email);
        bool ExisteUsuario(string email);

    }
}
