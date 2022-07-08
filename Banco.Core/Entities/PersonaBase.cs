using Banco.Core.Constantes;

namespace Banco.Core.Entities
{
    public class PersonaBase
    {
        public string Nombres { get; set; }
        public Genero Genero { get; set; }
        public int Edad { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
