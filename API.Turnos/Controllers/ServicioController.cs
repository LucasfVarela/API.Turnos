using API.UsesCases.Services;
using API.UsesCases.Services.Interfaces;
using API_CoreBusiness.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Turnos.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _servicioService;

        public ServicioController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_servicioService.GetAll());
        }

        [HttpPost]
        public ActionResult Post([FromBody] ServicioRequest request)
        {
            var response = _servicioService.Create(request);
            return Ok(response);
        }
    }
}