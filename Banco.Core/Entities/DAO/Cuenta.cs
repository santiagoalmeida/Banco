using Banco.Core.Constantes;

namespace Banco.Core.Entities.DAO
{
    public class Cuenta
    {
        public string NumeroCuenta { get; set; }
        public int IdCliente { get; set; }
        public TipoCuenta TipoCuenta {get; set;}
        public int SaldoInicial {get; set;}
        public bool Estado {get; set;}

        public Cliente Cliente { get; set; }
        public IEnumerable<Movimiento> Movimientos { get; set; }
    }
}
