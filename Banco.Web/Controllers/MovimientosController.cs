using Banco.Web.Models;
using Banco.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banco.Web.Controllers
{
    public class MovimientosController : Controller
    {
        private  IServices<Movimiento> _movimientoSvc;
        public MovimientosController(IServices<Movimiento> movimientoSvc)
        {
            _movimientoSvc = movimientoSvc;
        }

        // GET: Movimientos
        public async Task<ActionResult> Index()
        {
            return View(await _movimientoSvc.GetAsync());
        }

        // GET: Movimientos/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _movimientoSvc.GetAsync(id));
        }

        // GET: Movimientos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movimientos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm]Movimiento movimiento)
        {
            try
            {
                await _movimientoSvc.PostAsync(movimiento);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Valor", ex.Message);
                return View(movimiento);
            }
        }

        // GET: Movimientos/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _movimientoSvc.GetAsync(id));
        }

        // POST: Movimientos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [FromForm] Movimiento movimiento)
        {
            try
            {
                await _movimientoSvc.PutAsync(movimiento);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Movimientos/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _movimientoSvc.GetAsync(id));
        }

        // POST: Movimientos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _movimientoSvc.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
