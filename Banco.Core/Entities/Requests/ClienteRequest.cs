namespace Banco.Core.Entities.Requests
{
    public class ClienteRequest : PersonaBase
    {
        public int IdCliente { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }
    }
}
