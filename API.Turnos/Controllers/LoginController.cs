using API.UsesCases.Services;
using API.UsesCases.Services.Interfaces;
using API.UsesCases.UnitOfWork.Interfaces;
using API_CoreBusiness.Request;
using API_CoreBusiness.Response;
using API_DataCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Turnos.Controllers
{
    [Route("auth/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUsuarioService usuarioService;
        private readonly IClienteService clienteService;
       


        public LoginController(IUnitOfWork unitOfWork ,IUsuarioService usuarioService, IClienteService clienteService)
        {
            this.unitOfWork = unitOfWork;
            this.usuarioService = usuarioService;
            this.clienteService = clienteService;
        }

        [HttpPost("Login/Usuario")]
        public ActionResult Login([FromBody] UsuarioRequest request)
        {
            var response = usuarioService.Login(request.Email, request.Password);
            if (response is null)
            {
                return BadRequest(new { mensaje = "Contraseña incorrecta" });
            }
            var token = usuarioService.GetToken(response);
            return Ok(new
            {
                token = token,
                usuario = response,
            });
        }

        [HttpPost("Registrar/Usuario")]
        public ActionResult Registrar([FromBody] UsuarioRequest request)
        {
            if (unitOfWork.UsuarioRepository.ExisteUsuario(request.Email.ToLower())) return BadRequest("");
            UsuarioResponse response = usuarioService.Registrar(request,request.Password);
            return Ok(response);
        }


        [HttpPost("Login/Cliente")]
        public ActionResult LoginCliente([FromBody] ClienteRequest request)
        {
            var response = clienteService.Login(request.Email, request.Password);
            if (response is null)
            {
                return BadRequest(new { mensaje = "Contraseña incorrecta" });
            }
            var token = clienteService.GetToken(response);
            return Ok(new
            {
                token = token,
                usuario = response,
            });
        }

        [HttpPost("Registrar/Cliente")]
        public ActionResult RegistrarCliente([FromBody] ClienteRequest request)
        {
            if (unitOfWork.ClienteRepository.ExisteUsuario(request.Email.ToLower())) return BadRequest("");
            ClienteResponse response = clienteService.Registrar(request, request.Password);
            return Ok(response);
        }
    }
}

