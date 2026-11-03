using HttpClienteLogisticaDeEnvios.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace HttpClienteLogisticaDeEnvios.Controllers
{
    public class EnvioController : Controller
    {
        private HttpClient _httpClient;

        public EnvioController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://webappigestiondeenvios-grakcxbkcqhjd7dq.brazilsouth-01.azurewebsites.net/");
        }
        public IActionResult EnvioTracking()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EnvioTrackingAsync(string tracking)
        {


            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await _httpClient.GetAsync($"/api/Envio/tracking?tracking={tracking}");

            if (response.IsSuccessStatusCode)
            {

                string content = await response.Content.ReadAsStringAsync();



                var envio = JsonSerializer.Deserialize<DTOEnvio>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(envio);
            }
            else
            {
                string msg = await response.Content.ReadAsStringAsync();
                ViewBag.Message = msg;
                return View();
            }


        }
    
        public async Task<IActionResult> MisEnviosAsync()
        {


            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await _httpClient.GetAsync("/api/Envio/listarEnviosCliente");

            if (response.IsSuccessStatusCode)
            {

                string content = await response.Content.ReadAsStringAsync();



                var listaEnvios = JsonSerializer.Deserialize<List<DTOEnvio>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(listaEnvios);
            }
            else
            {
                return null;
            }


        }
        public async Task<IActionResult> SeguimientosAsync(int id)
        {
            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await _httpClient.GetAsync($"/api/Envio/listarSeguimientoDeEnvio?id={id}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                var seguimientos = JsonSerializer.Deserialize<List<DTOSeguimiento>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });


                if (seguimientos != null) { 
                  return View(seguimientos);
                }
                else
                {
                    string msg = await response.Content.ReadAsStringAsync();
                    ViewBag.Message = msg;
                    return View();

                }

            }
            else
            {
                string msg = await response.Content.ReadAsStringAsync();
                ViewBag.Message = msg;
                return View();
            }
        }



        public IActionResult FiltroFechas()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> FiltroFechasAsync(DateTime f1, DateTime f2, string estado)
        {
            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string f1Str = f1.ToString("yyyy-MM-dd");
            string f2Str = f2.ToString("yyyy-MM-dd");
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/Envio/listarEnviosClienteFechas?fechaInicio={f1Str}&fechafin={f2Str}&estado={estado}");

            if (response.IsSuccessStatusCode)
            {

                string content = await response.Content.ReadAsStringAsync();



                var listaEnvios = JsonSerializer.Deserialize<List<DTOEnvio>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(listaEnvios);
            }
            else
            {
                string msg = await response.Content.ReadAsStringAsync();
                ViewBag.Message = msg;
                return View();
            }

        }
        public IActionResult FiltroComentario()
        {

            return View();
        }

        [HttpPost]
            public async Task<IActionResult> FiltroComentarioAsync(string comentario)
            {
                string token = HttpContext.Session.GetString("Token");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await _httpClient.GetAsync($"/api/Envio/listarEnviosClienteComentario?comentario={comentario}");

                if (response.IsSuccessStatusCode)
                {

                    string content = await response.Content.ReadAsStringAsync();



                    var listaEnvios = JsonSerializer.Deserialize<List<DTOEnvio>>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return View(listaEnvios);
                }
                else
                {
                string msg = await response.Content.ReadAsStringAsync();
                ViewBag.Message = msg;
                return View();
                }


            }
    }
}
