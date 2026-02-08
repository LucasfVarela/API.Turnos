using API.CoreBusiness;
using API.CoreBusiness.Entity;
using API.UsesCases.Services;
using API.UsesCases.Services.Interfaces;
using API.UsesCases.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Turnos.Controllers
{
    [Route("Turno/")]
    [ApiController]
    public class TurnoController : ControllerBase
    {


        private readonly IUnitOfWork unitOfWork;
        private readonly ITurnoService turnoService;


        public TurnoController(ITurnoService turnoService, IUnitOfWork unitOfWork)
        {
            this.turnoService = turnoService;
            this.unitOfWork = unitOfWork;
        }

        // POST: TurnoController/Create
        [HttpPost("Add")]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([FromBody] Turno turno)
        {
            try
            {
                var result = turnoService.NewTurno(turno);

                if (result != null)
                    return Ok(result);

                return BadRequest("Ha ocurrido un error al generar el turno");

            }
            catch(Exception ex) 
            {
                return BadRequest($"{ex}");
            }
        }

        [HttpGet("Listar")]
        public ActionResult Listar()
        {
            var result = turnoService.GetAllTurnos();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var result = turnoService.GetTurnoById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("Actualizar/{id}")]
        public ActionResult Actualizar(int id, [FromBody] TurnoRequest request)
        {
            var success = turnoService.UpdateTurno(id, request);
            if (!success) return NotFound();
            return Ok("Turno actualizado correctamente");
        }

        [HttpDelete("Eliminar/{id}")]
        public ActionResult Eliminar(int id)
        {
            var success = turnoService.DeleteTurno(id);
            if (!success) return NotFound();
            return Ok("Turno eliminado correctamente");
        }



    }
}
