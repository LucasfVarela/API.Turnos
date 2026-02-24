using API.CoreBusiness;
using API.CoreBusiness.Entity;
using API.UsesCases.Services.Interfaces;
using API.UsesCases.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Turnos.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class TurnoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITurnoService _turnoService;

        public TurnoController(ITurnoService turnoService, IUnitOfWork unitOfWork)
        {
            _turnoService = turnoService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Listar")]
        public ActionResult Listar()
        {
            try
            {
                var turnos = _turnoService.GetAllTurnos(); 
                return Ok(turnos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al listar turnos: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var turno = _turnoService.GetTurnoById(id);
                if (turno == null) return NotFound("Turno no encontrado");
                return Ok(turno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public ActionResult Create([FromBody] Turno turno)
        {
            try
            {
                turno.Usuario = null;
                turno.Comercio = null; 
                turno.Servicio = null;

                var result = _turnoService.NewTurno(turno);

                if (result != null)
                    return Ok(result);

                return BadRequest("Ha ocurrido un error al generar el turno");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] TurnoRequest request)
        {
            try
            {
                var result = _turnoService.UpdateTurno(id, request);
                if (result) return Ok("Turno actualizado correctamente");
                return NotFound("No se encontró el turno para actualizar");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var deleted = _turnoService.DeleteTurno(id);

                if (deleted) return Ok(new { mensaje = "Turno eliminado correctamente" });

                return BadRequest(new { mensaje = "No se pudo eliminar el turno o no existe" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
        [HttpPut("Cancelar/{id}")]
        public ActionResult Cancelar(int id)
        {
            try
            {
                var cancelado = _turnoService.CancelarTurno(id);
                if (cancelado) return Ok(new { mensaje = "Turno cancelado correctamente" });
                return BadRequest(new { mensaje = "No se pudo cancelar el turno" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}