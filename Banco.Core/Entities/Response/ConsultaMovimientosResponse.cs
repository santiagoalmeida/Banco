using Banco.Core.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Core.Entities.Response
{
    public class ConsultaMovimientosResponse
    {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string NumeroCuenta { get; set; }
        public TipoCuenta Tipo { get; set; }
        public int SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public int Movimiento { get; set; }
        public int SaldoDisponible { get; set; }
    }
}
