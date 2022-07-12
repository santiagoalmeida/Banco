using Banco.Core.Constantes;

namespace Banco.Core.Entities.DAO
{
    public class MovimientoRequest
    {
        public int IdMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public int Valor { get; set; }
        public string NumeroCuenta { get; set; }
    }
}
