using API.UsesCases.Services.Interfaces;
using API.UsesCases.UnitOfWork.Interfaces;
using API.CoreBusiness.Request; 
using Microsoft.AspNetCore.Mvc;

namespace API.Turnos.Controllers
{
    [Route("API/")]
    [ApiController]
    public class ComercioController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IComercioService comercioService;

        public ComercioController(IUnitOfWork unitOfWork, IComercioService comercioService)
        {
            this.unitOfWork = unitOfWork;
            this.comercioService = comercioService;
        }

        // GET: API/GetComercios
        [HttpGet("GetComercios")]
        public ActionResult GetComercios()
        {
            var response = comercioService.GetComercios();
            
            if (response == null) { return BadRequest("NOT FOUND"); }
            
            return Ok(response);
        }


        [HttpPost("CrearComercio")]
        public ActionResult CrearComercio([FromBody] ComercioRequest request)
        {
            var response = comercioService.CrearComercio(request);

            if (response == null) 
            { 
                return BadRequest("No se pudo crear el comercio. Verifique los datos o el ID del dueño."); 
            }

            return Ok(response);
        }

        [HttpGet("GetComercio/{idCliente}")]
        public ActionResult GetComercioPorCliente(int idCliente)
        {
            var response = comercioService.GetComercioPorCliente(idCliente);



            return Ok(response);
        }
    }
}