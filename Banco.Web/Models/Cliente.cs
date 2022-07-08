using Banco.Web.Constantes;
using System.ComponentModel.DataAnnotations;

namespace Banco.Web.Models
{
    public class Cliente
    {
        [Key]
        [Display(Name ="Codigo")]
        public int idCliente { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name ="Nombres")]
        public string nombres { get; set; }
        [Required]
        [Display(Name ="Genero")]
        public Genero genero { get; set; }
        [Required]
        [Display(Name ="Edad")]
        public int edad { get; set; }
        [Required]
        [MaxLength(15)]
        [Display(Name ="Identificación")]
        public string identificacion { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name ="Dirección")]
        public string direccion { get; set; }
        [Required]
        [Display(Name ="Teléfono")]
        public string telefono { get; set; }
        [Required]
        [MaxLength(16)]
        [Display(Name ="Contraseña")]
        public string contrasena { get; set; }
        [Display(Name ="Activo")]
        public bool estado { get; set; }

        public IEnumerable<Cuenta> Cuentas { get; set; }
    }
}
