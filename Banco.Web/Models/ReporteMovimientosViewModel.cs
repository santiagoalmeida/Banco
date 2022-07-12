using Banco.Web.Constantes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Banco.Web.Models
{
    public class ReporteMovimientosViewModel
    {
        public ParamsConsultaMovimientos parametros { get; set; }
        public IEnumerable<ConsultaMovimientos> consulta { get; set; }
        public IEnumerable<SelectListItem> selectClientes { get; set; }

    }

    public class ParamsConsultaMovimientos
    {
        [Required]
        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }
        [Required]
        [Display(Name = "Fecha de inicio")]
        public DateTime Desde { get; set; }
        [Required]
        [Display(Name = "Fecha de fin")] 
        public DateTime Hasta { get; set; }
    }

    public class ConsultaMovimientos
    {
        [Display(Name ="Fecha")]
        public DateTime fecha { get; set; }
        [Display(Name ="Cliente")]
        public string cliente { get; set; }
        [Display(Name ="Numero de cuenta")]
        public string numeroCuenta { get; set; }
        [Display(Name ="Tipo de cuenta")]
        public TipoCuenta tipo { get; set; }
        [Display(Name ="Saldo inicial")]
        public int saldoInicial { get; set; }
        [Display(Name ="Estado")]
        public bool estado { get; set; }
        [Display(Name ="Movimiento")]
        public int movimiento { get; set; }
        [Display(Name ="Saldo disponible")]
        public int saldoDisponible { get; set; }
    }
}
