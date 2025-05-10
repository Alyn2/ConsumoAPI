using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicioAPI _servicioAPI;

        public HomeController(IServicioAPI servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Documentos(string estado)
        {
            List<Documento> documentos = await _servicioAPI.ListaDocumentos(estado);
            return View(documentos);
        }

        public async Task<IActionResult> Usuarios(string estado)
        {
            List<Usuario> usuarios = await _servicioAPI.ListaUsuarios(estado);
            return View(usuarios);
        }

        public async Task<IActionResult> Derivacion(int idDocumento)
        {
            Derivacion derivacion = new Derivacion();

            if (idDocumento != 0) { 
                derivacion = await _servicioAPI.GetDerivacion(idDocumento);
            }

            return View(derivacion);
        }

        public IActionResult DescargarBase64(string base64Texto)
        {
            // Eliminar caracteres no válidos
            base64Texto = LimpiarBase64(base64Texto);

            // Verificar si la cadena Base64 es válida
            if (IsValidBase64String(base64Texto))
            {
                try
                {
                    // Convertir la cadena Base64 a bytes
                    byte[] archivoBytes = Convert.FromBase64String(base64Texto);
                    var extension = ObtenerExtensionDesdeBytes(archivoBytes);
                    Console.Write(extension);

                    // Devolver el archivo
                    return File(archivoBytes, "application/octet-stream", $"archivo.{extension}");
                }
                catch (FormatException ex)
                {
                    // Manejar la excepción si ocurre un problema durante la conversión
                    return BadRequest($"Error al convertir Base64: {ex.Message}");
                }
            }
            else
            {
                // Manejar el caso en que la cadena no es válida
                return BadRequest("La cadena Base64 no es válida.");
            }
        }

        private bool IsValidBase64String(string s)
        {
            try
            {
                Convert.FromBase64String(s);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private string LimpiarBase64(string s)
        {
            // Eliminar caracteres no válidos
            return s.Replace("\r", "").Replace("\n", "");
        }

        private string ObtenerExtensionDesdeBytes(byte[] bytes)
        {
            try
            {
                // Verificar la firma o contenido para determinar la extensión
                if (bytes.Take(4).SequenceEqual(Encoding.UTF8.GetBytes("%PDF")))
                {
                    return "pdf";
                }
                else if (bytes.Take(2).SequenceEqual(Encoding.UTF8.GetBytes("PK")))
                {
                    return "docx";
                }
                // Puedes agregar más lógica para otros tipos de archivo según sea necesario

                // Si no se puede determinar, devuelve una extensión genérica
                return "bin";
            }
            catch (Exception)
            {
                // En caso de error, devuelve una extensión genérica
                return "bin";
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
