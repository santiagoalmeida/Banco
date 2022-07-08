using Banco.Core.Entities.DAO;
using Banco.Core.Entities.Requests;
using Banco.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Banco.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private ICuentasService _CuentasSvc;
        public CuentasController(ICuentasService CuentasSvc)
        {
            _CuentasSvc = CuentasSvc;
        }

        // GET: api/<CuentasController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuenta>>> Get() => Ok(await _CuentasSvc.GetAllAsync());

        // GET api/<CuentasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id) => Ok(await _CuentasSvc.GetByIdAsync(id));

        // POST api/<CuentasController>
        [HttpPost]
        public async void Post(CuentaRequest cuenta)
        {

            await _CuentasSvc.CreateAsync(new Cuenta
            {
                NumeroCuenta = cuenta.NumeroCuenta,
                IdCliente = cuenta.IdCliente,
                TipoCuenta = cuenta.TipoCuenta,
                SaldoInicial = cuenta.SaldoInicial,
                Estado = cuenta.Estado,
            });
        }

        // PUT api/<CuentasController>/5
        [HttpPut]
        public async Task Put(CuentaRequest cuenta)
        {
            await _CuentasSvc.UpdateAsync(new Cuenta
            {
                NumeroCuenta = cuenta.NumeroCuenta,
                IdCliente = cuenta.IdCliente,
                TipoCuenta = cuenta.TipoCuenta,
                SaldoInicial = cuenta.SaldoInicial,
                Estado = cuenta.Estado,
            });
        }

        // DELETE api/<CuentasController>/5
        [HttpDelete("{NumeroCuenta}")]
        public async void Delete(string NumeroCuenta) => await _CuentasSvc.CreateAsync(new Cuenta { NumeroCuenta = NumeroCuenta });
    }
}
