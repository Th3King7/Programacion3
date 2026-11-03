using HttpClienteLogisticaDeEnvios.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace HttpClienteLogisticaDeEnvios.Controllers
{
    public class UsuarioController : Controller
    {
        private HttpClient _httpClient;
        public UsuarioController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://webappigestiondeenvios-grakcxbkcqhjd7dq.brazilsouth-01.azurewebsites.net/");
        }
        public IActionResult CambiarPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CambiarPassword(string PasswordActual, string PasswordNueva)
        {
            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var dto = new DTOPassword
            {
                PasswordActual = PasswordActual,
                PasswordNueva = PasswordNueva
            };

            var content = new StringContent(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json"
            );
            var response = await _httpClient.PutAsync("/api/Usuario/cambiarPassword", content);

            if (response.IsSuccessStatusCode)
            {

                string msg = await response.Content.ReadAsStringAsync();
                ViewBag.Message = msg;
                return View();
            }
            else if ((int)response.StatusCode == 400)
            {
               
                ViewBag.Message = "La longitud de la contraseña debe estar entre 8 y 32 caracteres";
                return View();
            }
            else {
                string msg = await response.Content.ReadAsStringAsync();
                ViewBag.Message = msg;
                return View();
            }
        }

        
        }
}
