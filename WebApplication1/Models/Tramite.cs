namespace WebApplication1.Models
{
    public class Tramite
    {
        public long id { get; set; }
        public string fechaRecepcion {  get; set; }
        public string observacion { get; set; }
        public Persona persona { get; set; }
        public int cantidadDias { get; set; }
        public string fechaTermino { get; set; }
        public string asunto { get; set; }
    }
}
