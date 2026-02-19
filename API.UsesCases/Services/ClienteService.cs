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
                if (!ValidPassword(password, Usuario.PasswordSalt, Usuario.PasswordHash))
                    return null;

                return new ClienteResponse
                {
                    Id = Usuario.Id,
                    EMail = email,
                    Nombre = Usuario.Nombre,
                    Fecha_Add = Usuario.Fecha_Add,
                    Fecha_Mod = Usuario.Fecha_Mod
                };
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
            NewCliente.Fecha_Mod = DateTime.Now; 
            
            NewCliente.PasswordHash = passwordHash;
            NewCliente.PasswordSalt = passwordSalt;
            NewCliente.Activo = true;

            UnitOfWork.ClienteRepository.Insert(NewCliente);
            UnitOfWork.Save();

            return new ClienteResponse()
            {
                Id = NewCliente.Id,
                EMail = NewCliente.Email,
                Nombre = NewCliente.Nombre,
                Fecha_Add = NewCliente.Fecha_Add,
                Fecha_Mod = NewCliente.Fecha_Mod
            };
        }

        public ClienteResponse DeleteUsuario(int Id_Cliente)
        {
            var cliente = UnitOfWork.ClienteRepository.Find(x => x.Id == Id_Cliente && x.Activo == true).FirstOrDefault();
            if (cliente == null) return null;
            return UnitOfWork.ClienteRepository.SoftDelete(cliente);
        }

        public string GetToken(ClienteResponse clienteResponse)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, clienteResponse.EMail),
                new Claim(JwtRegisteredClaimNames.NameId, clienteResponse.Id.ToString()),
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

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return UnitOfWork.ClienteRepository.GetAll();
        }

        #region Private methods
        private void BuildPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hMac = new HMACSHA512())
            {
                passwordSalt = hMac.Key;
                passwordHash = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool ValidPassword(string password, byte[] passSalt, byte[] passHash)
        {
            using (var hMac = new HMACSHA512(passSalt))
            {
                byte[] hash = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));
                
                int diff = 0;
                if (hash.Length != passHash.Length) return false;
                for (int i = 0; i < hash.Length; i++)
                {
                    diff |= hash[i] ^ passHash[i];
                }
                return diff == 0;
            }
        }
        #endregion
    }
}