using API.CoreBusiness.Entity;
using API.UsesCases.Services.Interfaces;
using API.UsesCases.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Turnos.Controllers
{
    [Route("Turno/")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        //// GET: TurnoController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: TurnoController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: TurnoController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        private readonly IUnitOfWork unitOfWork;
        private readonly ITurnoService turnoService;


        public TurnoController(ITurnoService turnoService, IUnitOfWork unitOfWork)
        {
            this.turnoService = turnoService;
            this.unitOfWork = unitOfWork;
        }

        // POST: TurnoController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([FromBody] Turno turno)
        {
               var result = turnoService.NewTurno(turno);
                return Ok(result);
            try
            {
            }
            catch
            {
                //return View();
            }
        }

        //// GET: TurnoController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TurnoController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TurnoController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: TurnoController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
