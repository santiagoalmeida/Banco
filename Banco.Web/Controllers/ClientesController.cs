using Banco.Web.Models;
using Banco.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banco.Web.Controllers
{
    public class ClientesController : Controller
    {
        private  IServices<Cliente> _clienteSvc;
        public ClientesController(IServices<Cliente> clienteSvc)
        {
            _clienteSvc = clienteSvc;
        }

        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            return View(await _clienteSvc.GetAsync());
        }

        // GET: Clientes/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _clienteSvc.GetAsync(id));
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm]Cliente cliente)
        {
            try
            {
                await _clienteSvc.PostAsync(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _clienteSvc.GetAsync(id));
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [FromForm] Cliente cliente)
        {
            try
            {
                await _clienteSvc.PutAsync(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _clienteSvc.GetAsync(id));
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _clienteSvc.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
