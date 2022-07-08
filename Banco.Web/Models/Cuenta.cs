using Banco.Web.Constantes;

namespace Banco.Web.Models
{
    public class Cuenta
    {
        public string NumeroCuenta { get; set; }
        public int IdCliente { get; set; }
        public TipoCuenta TipoCuenta {get; set;}
        public int SaldoInicial {get; set;}
        public bool Estado { get; set; } = true;

        public Cliente cliente { get; set; }
        public IEnumerable<Movimiento> Movimientos { get; set; }
    }
}
