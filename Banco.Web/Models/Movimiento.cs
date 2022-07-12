using Banco.Web.Constantes;

namespace Banco.Web.Models
{
    public class Movimiento
    {
        public int idMovimiento { get; set; }
        public DateTime fecha { get; set; }
        public TipoMovimiento tipoMovimiento { get; set; }
        public int valor { get; set; }
        public string numeroCuenta { get; set; }
        public Cuenta cuenta { get; set; }
    }
}
