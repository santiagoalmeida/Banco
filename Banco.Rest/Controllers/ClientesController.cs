using Banco.Core.Constantes;
using Banco.Core.Entities.DAO;
using Banco.Core.Entities.Requests;
using Banco.Core.Interfaces.Services;
using Banco.Core.utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Banco.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClientesService _clientesSvc;
        public ClientesController(IClientesService clientesSvc)
        {
            _clientesSvc = clientesSvc;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var clients = await _clientesSvc.GetAllAsync();
            return Ok(clients);
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id) => Ok(await _clientesSvc.GetByIdAsync(id));

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<ActionResult> Post(ClienteRequest cliente)
        {
            await _clientesSvc.CreateAsync(new Cliente
            {
                Nombres = cliente.Nombres,
                Genero = cliente.Genero,
                Edad = cliente.Edad,
                Identificacion = cliente.Identificacion,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                Contrasena = cliente.Contrasena,
                Estado = true,
            });
            return Ok();
        }

        // PUT api/<ClientesController>/5
        [HttpPut]
        public async Task<ActionResult> Put(ClienteRequest cliente)
        {
            Cliente cli = await _clientesSvc.GetByIdAsync(cliente.IdCliente);
            cli.Nombres = cliente.Nombres;
            cli.Genero = cliente.Genero;
            cli.Edad = cliente.Edad;
            cli.Identificacion = cliente.Identificacion;
            cli.Direccion = cliente.Direccion;
            cli.Telefono = cliente.Telefono;
            cli.Contrasena = cliente.Contrasena;
            cli.Estado = cliente.Estado;
            await _clientesSvc.UpdateAsync(cli);
            return Ok();
        }
        // DELETE api/<ClientesController>/5
        [HttpDelete("{IdCliente}")]
        public async Task<ActionResult> Delete(int IdCliente)
        {
            await _clientesSvc.DeleteAsync(new Cliente { IdCliente = IdCliente });
            return Ok();
        }
    }
}
