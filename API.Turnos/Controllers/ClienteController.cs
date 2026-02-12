using API.UsesCases.Services.Interfaces;
using API.UsesCases.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Turnos.Controllers
{
    [Route("API/")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IClienteService clienteService;


        public ClienteController(IUnitOfWork unitOfWork, IClienteService clienteService)
        {
            this.unitOfWork = unitOfWork;
            this.clienteService = clienteService;
        }

        [HttpGet("GetClientes")]
        public ActionResult GetClientes()
        {
            var response = clienteService.GetClientes();
            if (response is null) { return BadRequest("NOT FOUND"); }
            return Ok(response);
        }


        [HttpGet("DesactivarCliente")]
        public ActionResult DesactivarCliente(int Id_Usuario)
        {
            var response = clienteService.DeleteUsuario(Id_Usuario);
            if (response is null) { return BadRequest("NOT FOUND"); }
            return Ok(response);
        }
    }
}
