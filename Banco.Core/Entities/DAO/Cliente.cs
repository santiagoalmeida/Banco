namespace Banco.Core.Entities.DAO
{
    public class Cliente : PersonaBase
    {
        public int IdCliente { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }
        public IEnumerable<Cuenta> Cuentas { get; set; }
    }
}
