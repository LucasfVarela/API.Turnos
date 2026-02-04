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
    public class UsuarioRepository : GenericRepository<Usuarios>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext options) : base(options)
        {
            
        }

        public Usuarios? GetByEmail(string Email) => context.Usuario.FirstOrDefault(x => x.Email == Email);
        
        public bool ExisteUsuario(string email ) => context.Usuario.Any(x => x.Email == email);

        public UsuarioResponse SoftDelete(Usuarios usuarios )
        {
            //if (Id is null || Id == 0) throw new ArgumentNullException(nameof(Id));
            usuarios.Activo = false;
            usuarios.Fecha_Mod = DateTime.Now;
            context.Usuario.Update(usuarios);

            return new UsuarioResponse()
            {
                Nombre = usuarios.Nombre,
                EMail = usuarios.Email,
                Activo = true,
                Fecha_Mod = usuarios.Fecha_Mod

            };

        }

    }
}
