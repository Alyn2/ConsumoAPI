namespace WebApplication1.Models
{
    public class Usuario
    {
        public long id { get; set; }
        public Persona persona { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public Rol rol { get; set; }
        public string estado { get; set; }
    }
}
