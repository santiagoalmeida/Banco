using Banco.Core.Entities.DAO;
using Banco.Core.Entities.Requests;
using Banco.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Banco.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private IMovimientosService _movimientosSvc;
        public MovimientosController(IMovimientosService movimientosSvc)
        {
            _movimientosSvc = movimientosSvc;
        }

        // GET: api/<MovimientosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimiento>>> Get() => Ok(await _movimientosSvc.GetAllAsync());

        // GET api/<MovimientosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id) => Ok(await _movimientosSvc.GetByIdAsync(new Movimiento { IdMovimiento = id }));

        // POST api/<MovimientosController>
        [HttpPost]
        public async Task<ActionResult> Post(MovimientoRequest movimiento)
        {
            try
            {
                await _movimientosSvc.CreateAsync(new Movimiento
                {
                    IdMovimiento = movimiento.IdMovimiento,
                    Fecha = movimiento.Fecha,
                    TipoMovimiento = movimiento.TipoMovimiento,
                    Valor = movimiento.Valor,
                    NumeroCuenta = movimiento.NumeroCuenta,
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MovimientosController>/5
        [HttpPut]
        public async Task Put(MovimientoRequest movimiento) =>
            await _movimientosSvc.UpdateAsync(new Movimiento
            {
                IdMovimiento = movimiento.IdMovimiento,
                Fecha = movimiento.Fecha,
                TipoMovimiento = movimiento.TipoMovimiento,
                Valor = movimiento.Valor,
                NumeroCuenta = movimiento.NumeroCuenta,
            });

        // DELETE api/<MovimientosController>/5
        [HttpDelete("{IdMovimiento}")]
        public async void Delete(int IdMovimiento) => await _movimientosSvc.DeleteAsync(new Movimiento { IdMovimiento = IdMovimiento });

        [HttpPost("Reportes")]
        public async Task<ActionResult<IEnumerable<Movimiento>>> GetConsultaMovimientos(ConsultaMovimientosRequest request) => 
            Ok(await _movimientosSvc.GetQueryMovimientosAsync(request));

    }
}
