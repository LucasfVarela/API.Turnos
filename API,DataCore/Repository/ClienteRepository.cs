using API.CoreBusiness.Entity;
using API.GenericCore.GenericRepository;
using API_CoreBusiness.DataContext;
using API_CoreBusiness.Entity;
using API_CoreBusiness.Response;
using API_DataCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace API_DataCore.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext options) : base(options)
        {
            
        }

        public Cliente? GetByEmail(string Email) => context.Cliente.FirstOrDefault(x => x.Email == Email);
        
        public bool ExisteUsuario(string email ) => context.Cliente.Any(x => x.Email == email);

        public ClienteResponse SoftDelete(Cliente cliente )
        {
            //if (Id is null || Id == 0) throw new ArgumentNullException(nameof(Id));
            cliente.Activo = false;
            cliente.Fecha_Mod = DateTime.Now;
            context.Cliente.Update(cliente);

            return new ClienteResponse()
            {
                Nombre = cliente.Nombre,
                EMail = cliente.Email,
                Activo = true,
                Fecha_Mod = cliente.Fecha_Mod

            };

        }

    }
}
