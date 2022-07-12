using Banco.Web.Constantes;

namespace Banco.Web.Models
{
    public class Cuenta
    {
        public string numeroCuenta { get; set; }
        public int idCliente { get; set; }
        public TipoCuenta tipoCuenta {get; set;}
        public int saldoInicial {get; set;}
        public bool estado { get; set; } = true;

        public Cliente cliente { get; set; }
        public IEnumerable<Movimiento> movimientos { get; set; }
    }
}
