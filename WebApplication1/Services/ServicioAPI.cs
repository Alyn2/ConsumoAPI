using Newtonsoft.Json;
using System.Collections.Specialized;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ServicioAPI : IServicioAPI
    {
        public string baseUrl = "http://localhost:8081/";
        public async Task<List<Documento>> ListaDocumentos(string estado)
        {
            List<Documento> documentos = new List<Documento>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseUrl);

            var get = "documentos";
            if (estado != null) {
                get += $"?estado={estado}";
            }

            var response = await cliente.GetAsync(get);

            if (response.IsSuccessStatusCode) {
                var jsonRespuesta = await response.Content.ReadAsStringAsync();
                documentos = JsonConvert.DeserializeObject<List<Documento>>(jsonRespuesta);
            }

            return documentos;
        }

        public async Task<List<Usuario>> ListaUsuarios(string estado)
        {
            List<Usuario> usuarios = new List<Usuario>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseUrl);

            var get = "usuarios";
            if (estado != null) 
            {
                get += $"?estado={estado}";
            }

            var response = await cliente.GetAsync(get);

            if (response.IsSuccessStatusCode)
            {
                var jsonRespuesta = await response.Content.ReadAsStringAsync();
                usuarios = JsonConvert.DeserializeObject<List<Usuario>>(jsonRespuesta);
            }

            return usuarios;
        }

        public async Task<Derivacion> GetDerivacion(int idDocumento)
        {
            Derivacion derivacion = new Derivacion();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseUrl);

            var response = await cliente.GetAsync($"documentos/{idDocumento}");

            if (response.IsSuccessStatusCode)
            {
                var jsonRespuesta = await response.Content.ReadAsStringAsync();
                derivacion = JsonConvert.DeserializeObject<Derivacion>(jsonRespuesta);
            }

            return derivacion;
        }

    }
}
