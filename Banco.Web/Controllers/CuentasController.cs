using Banco.Web.Models;
using Banco.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Banco.Web.Controllers
{
    public class CuentasController : Controller
    {
        private  IServices<Cuenta> _cuentaSvc;
        private  IServices<Cliente> _clienteSvc;

        public CuentasController(IServices<Cuenta> cuentaSvc, IServices<Cliente> clienteSvc)
        {
            _cuentaSvc = cuentaSvc;
            _clienteSvc = clienteSvc;
        }

        // GET: Cuentas
        public async Task<ActionResult> Index()
        {
            return View(await _cuentaSvc.GetAsync());
        }

        // GET: Cuentas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _cuentaSvc.GetAsync(id));
        }

        // GET: Cuentas/Create
        public async Task<ActionResult> Create()
        {
            IEnumerable<Cliente> clientes = await _clienteSvc.GetAsync();
            CuentasViewModel cuenta = new CuentasViewModel
            {
                SelectClientes = from cli in clientes
                                 select new SelectListItem
                                 {
                                     Value = cli.idCliente.ToString(),
                                     Text = cli.nombres.ToUpper()
                                 }
            };
            
            return View(cuenta);
        }

        // POST: Cuentas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm]Cuenta cuenta)
        {
            try
            {
                await _cuentaSvc.PostAsync(cuenta);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuentas/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            IEnumerable<Cliente> clientes = await _clienteSvc.GetAsync();
            CuentasViewModel cuenta = new CuentasViewModel
            {
                cuenta = await _cuentaSvc.GetAsync(id),
                SelectClientes = from cli in clientes
                                 select new SelectListItem
                                 {
                                     Value = cli.idCliente.ToString(),
                                     Text = cli.nombres.ToUpper()
                                 }
            };
            return View(cuenta);
        }

        // POST: Cuentas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [FromForm] Cuenta cuenta)
        {
            try
            {
                await _cuentaSvc.PutAsync(cuenta);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuentas/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _cuentaSvc.GetAsync(id));
        }

        // POST: Cuentas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _cuentaSvc.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
