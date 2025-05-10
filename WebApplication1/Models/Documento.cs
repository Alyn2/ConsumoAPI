
namespace WebApplication1.Models
{
    public class Documento
    {
        public long id { get; set; }
        public string tipo { get; set; }
        public string estado { get; set; }
        public string fecha { get; set; }
        public string requisitos { get; set; }
        public Tramite tramite { get; set; }
        public string venFecha { get; set; }
        public string descripcion { get; set; }
        public string base64 { get; set; }
        public string areaDirigida { get; set; }

        public static implicit operator List<object>(Documento v)
        {
            throw new NotImplementedException();
        }
    }
}
