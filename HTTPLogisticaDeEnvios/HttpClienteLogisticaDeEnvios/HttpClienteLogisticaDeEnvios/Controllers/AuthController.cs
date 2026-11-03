using HttpClienteLogisticaDeEnvios.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace HttpClienteLogisticaDeEnvios.Controllers
{
    public class AuthController : Controller
    {
        private HttpClient _httpClient;

        public AuthController() {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://webappigestiondeenvios-grakcxbkcqhjd7dq.brazilsouth-01.azurewebsites.net/");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(DTOLogin login)
        {
            var json = JsonSerializer.Serialize(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/auth/login", content);
            string v = response.StatusCode.ToString();
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                var tk = JsonSerializer.Deserialize<TokenResponse>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                HttpContext.Session.SetString("Token", tk.Token);
                return RedirectToAction("Index", "Home");



            }
            else if ((int)response.StatusCode == 401)
            {
                ViewBag.Message = "No autorizado";
                return View();
            }
            else
            {
                ViewBag.Message = "Usuario no encontrado.";
                return View();
            }


        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
