using Banco.Web.Models;
using Banco.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Banco.Web.Controllers
{
    public class ReportesController : Controller
    {
        private IServices<Movimiento> _movimientoSvc;
        private IServices<Cliente> _clienteSvc;
        public ReportesController(IServices<Movimiento> movimientoSvc, IServices<Cliente> clienteSvc)
        {
            _clienteSvc = clienteSvc;
            _movimientoSvc = movimientoSvc;
        }
        public async Task<IActionResult> Movimientos()
        {
            IEnumerable<Cliente> clientes = await _clienteSvc.GetAsync();
            clientes.ToList().Insert(0, new Cliente { idCliente = 0, nombres = "Escoja el cliente" });
            ReporteMovimientosViewModel modl = new ReporteMovimientosViewModel
            {
                selectClientes = from cli in clientes
                                 select new SelectListItem
                                 {
                                     Value = cli.idCliente.ToString(),
                                     Text = cli.nombres.ToUpper()
                                 },
                consulta = new List<ConsultaMovimientos>(),
                parametros = new ParamsConsultaMovimientos
                {
                    IdCliente = 0,
                    Desde = DateTime.Now.Date,
                    Hasta = DateTime.Now.AddDays(1).Date
                }
            };
            return View(modl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Movimientos(ReporteMovimientosViewModel reporte)
        {
            IEnumerable<Cliente> clientes = await _clienteSvc.GetAsync();
            ReporteMovimientosViewModel modl = new ReporteMovimientosViewModel
            {
                selectClientes = from cli in clientes
                                 select new SelectListItem
                                 {
                                     Value = cli.idCliente.ToString(),
                                     Text = cli.nombres.ToUpper()
                                 },
                parametros = reporte.parametros,
                consulta = await _movimientoSvc.GetReporteMovimientosAsync(reporte.parametros)
            };
            return View(modl);
        }
    }
}
