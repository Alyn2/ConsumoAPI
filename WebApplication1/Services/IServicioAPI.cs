using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IServicioAPI
    {
        Task<List<Documento>> ListaDocumentos(string estado);
        Task<List<Usuario>> ListaUsuarios(string estado);
        Task<Derivacion> GetDerivacion(int idDocumento);
    }
}
