using API.CoreBusiness.Request; // Importante para recibir los datos
using API.UsesCases.Services.Interfaces;
using API.UsesCases.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Turnos.Controllers
{
    [Route("API/")]
    [ApiController]
    public class ServicioController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IServicioService servicioService;

        public ServicioController(IUnitOfWork unitOfWork, IServicioService servicioService)
        {
            this.unitOfWork = unitOfWork;
            this.servicioService = servicioService;
        }

        [HttpGet("Servicio/GetByComercio/{id}")]
        public ActionResult GetByComercio(int id)
        {
            var response = servicioService.GetServiciosByComercio(id);
            if (response == null) return Ok(new List<object>()); 
            return Ok(response);
        }

        [HttpPost("Servicio")]
        public ActionResult Create([FromBody] ServicioRequest request)
        {
            // Validamos que venga la data mínima
            if (request == null) return BadRequest("Datos inválidos");

            var response = servicioService.CreateServicio(request);
            return Ok(response);
        }

        [HttpPut("Servicio/{id}")]
        public ActionResult Update(int id, [FromBody] ServicioRequest request)
        {
            var response = servicioService.UpdateServicio(id, request);
            
            if (response == null) 
                return NotFound("El servicio no existe o no se pudo actualizar.");

            return Ok(response);
        }

        [HttpDelete("Servicio/{id}")]
        public ActionResult Delete(int id)
        {
            var result = servicioService.DeleteServicio(id);
            
            if (!result) 
                return NotFound("No se encontró el servicio para eliminar.");

            return Ok(new { message = "Servicio eliminado correctamente" });
        }
    }
}