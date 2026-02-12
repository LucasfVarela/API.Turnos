using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.UsesCases.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Turnos.Controllers
{
    [Route("API/")] // O [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : Controller
    {
        private readonly IServicioService servicioService;

        public ServicioController(IServicioService servicioService)
        {
            this.servicioService = servicioService;
        }

        [HttpGet("GetServicios")]
        public ActionResult GetServicios()
        {
            var response = servicioService.GetServicios();
            // Si la lista está vacía igual devuelve 200 OK con lista vacía, 
            // o 404 si prefieres esa lógica.
            return Ok(response);
        }

        [HttpGet("GetServicio/{id}")]
        public ActionResult GetServicio(int id)
        {
            var response = servicioService.GetServicioById(id);
            if (response == null) { return BadRequest("NOT FOUND"); }
            return Ok(response);
        }
        [HttpPost("CrearServicio")]
        public ActionResult CrearServicio([FromBody] API_CoreBusiness.Request.ServicioRequest request)
        {
            var response = servicioService.Crear(request);
            return Ok(response);
        }
    }
}
