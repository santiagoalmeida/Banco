using Microsoft.AspNetCore.Mvc.Rendering;

namespace Banco.Web.Models
{
    public class CuentasViewModel
    {
        public IEnumerable<SelectListItem> SelectClientes { get; set; }
        public Cuenta cuenta { get; set; }
    }
}
