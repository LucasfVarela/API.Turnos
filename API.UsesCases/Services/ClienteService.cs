using API.CoreBusiness.Entity;
using API.UsesCases.Services.Interfaces;
using API.UsesCases.UnitOfWork.Interfaces;
using API_CoreBusiness.DataContext;
using API_CoreBusiness.Entity;
using API_CoreBusiness.Request;
using API_CoreBusiness.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.UsesCases.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IConfiguration Configuration;


        public ClienteService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.UnitOfWork = unitOfWork;
            this.Configuration = configuration;
        }


        public ClienteResponse Login(string email, string password)
        {

            Cliente? Usuario = UnitOfWork.ClienteRepository.GetByEmail(email);

            if (Usuario is not null)
            {
                ClienteResponse response = new ClienteResponse();
                if (!ValidPassword(password, Usuario.PasswordSalt, Usuario.PasswordHash))
                    return null;

                response.Id = Usuario.Id;
                //response.Role = Usuario.Role;
                response.EMail = email;
                response.Nombre = Usuario.Nombre;
                response.Fecha_Add = Usuario.Fecha_Add;
                response.Fecha_Mod = Usuario.Fecha_Mod;
                return response;
            }
            return null;
        }

        public ClienteResponse Registrar(ClienteRequest clienteRequest, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            BuildPassword(password, out passwordHash, out passwordSalt);
            Cliente NewCliente = new Cliente();
            NewCliente.Nombre = clienteRequest.Nombre;
            NewCliente.Email = clienteRequest.Email;
            NewCliente.Fecha_Add = DateTime.Now;
            NewCliente.PasswordHash = passwordHash;
            NewCliente.PasswordSalt = passwordSalt;
            NewCliente.Activo = true;
            //Esto hay que definir que venga el roll desde el front
            //NewCliente.Role = Role.Cliente;

            UnitOfWork.ClienteRepository.Insert(NewCliente);
            UnitOfWork.Save();

            return new ClienteResponse()
            {
                Id = NewCliente.Id,
                //Role = NewCliente.Role,
                EMail = NewCliente.Email,
                Nombre = NewCliente.Nombre,
                Fecha_Add = DateTime.Now,
            };

        }

        public ClienteResponse DeleteUsuario(int Id_Cliente)
        {
            var cliente = UnitOfWork.ClienteRepository.Find(x => x.Id == Id_Cliente && x.Activo == true).FirstOrDefault();
          return  UnitOfWork.ClienteRepository.SoftDelete(cliente);
        }



        public string GetToken(ClienteResponse clienteResponse)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, clienteResponse.EMail),
                new Claim(JwtRegisteredClaimNames.NameId,clienteResponse.Id.ToString()),
                new Claim(ClaimTypes.Role, clienteResponse.Role.ToString()),
            };

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddMinutes(120),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Issuer = Configuration["Jwt:Issuing"],
                Audience = Configuration["Jwt:Audience"]
            };

            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return UnitOfWork.ClienteRepository.GetAll();
        }

        #region Private method
        private void BuildPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            HMACSHA512 hMac = new HMACSHA512();
            passwordSalt = hMac.Key;
            passwordHash = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        private bool ValidPassword(string password, byte[] passSalt, byte[] passHash)
        {

            HMACSHA512 hMac = new HMACSHA512(passSalt);
            byte[] hash = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));

            //Implemente branchless tengo que ser si me funciona , sino dejo el if normal

            int diff = 0;
            for (int i = 0; i < hash.Length; i++)
            {
                diff |= hash[i] ^ passHash[i];
            }
            return diff == 0;


            //for (int i = 0; i < hash.Length; i++)
            //{
            //    if (hash[i] != passHash[i]) return false;
            //}
            //return true
        }
        #endregion
    }

}
