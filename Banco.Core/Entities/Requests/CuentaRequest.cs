using Banco.Core.Constantes;

namespace Banco.Core.Entities.Requests
{
    public class CuentaRequest
    {

        public string NumeroCuenta { get; set; }
        public int IdCliente { get; set; }
        public TipoCuenta TipoCuenta {get; set;}
        public int SaldoInicial {get; set;}
        public bool Estado {get; set;}
    }
}
