using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.UsesCases.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Turnos.Controllers
{
    // CAMBIO CLAVE AQUÍ ABAJO: Le decimos que use "api/NombreDelControlador"
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        [HttpGet("GetCategorias")]
        public ActionResult GetCategorias()
        {
            var response = categoriaService.GetCategorias();

            if (response == null)
            {
                return NotFound("No se encontraron categorías.");
            }

            return Ok(response);
        }
    }
}