using Libreria.LogicaAplicacion.CasosUso.CUEnvio;
using Libreria.LogicaAplicacion.CasosUso.CUSeguimiento;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Libreria.LogicaNegocio.CustomExceptions.ExceptionsEnvio;
using Libreria.LogicaNegocio.Entidades;
using LIbreria.DTOs.DTOs.DTOsEnvio;
using LIbreria.DTOs.DTOs.DTOsSeguimiento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAppi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private ICUObtenerEnvioPorTracking _cuObtenerEnvioPorTracking;
        private ICUListarEnvioUsuario _cuListarEnvioCliente;
        private ICUBuscarEnvioUsuario _cuBuscarEnvioUsuario;
        private ICUBuscarEnvioPorComentario _cUBuscarEnvioPorComentario;
        private ICUObtenerSeguimientos _cUObtenerSeguimiento;

        public EnvioController(ICUObtenerEnvioPorTracking obtenerEnvio, ICUListarEnvioUsuario cUListarEnvioCliente, ICUBuscarEnvioUsuario cuBuscarEnvioUsuario, ICUBuscarEnvioPorComentario cUBuscarEnvioPorComentario,ICUObtenerSeguimientos cUObtenerSeguimiento)
        {
            _cuObtenerEnvioPorTracking = obtenerEnvio;
            _cuListarEnvioCliente = cUListarEnvioCliente;
            _cuBuscarEnvioUsuario = cuBuscarEnvioUsuario;
            _cUBuscarEnvioPorComentario = cUBuscarEnvioPorComentario;
            _cUObtenerSeguimiento = cUObtenerSeguimiento;
        }
        [HttpGet("tracking")]
        public IActionResult GetByTracking(string tracking)
        {
            try
            {
                DTOEnvio dto = _cuObtenerEnvioPorTracking.ObtenerEnvioPorTracking(tracking);

                if (dto == null)
                {
                    return NotFound();
                }

                return Ok(dto);
            }
            catch (ExceptionNumeroDeTrackingNoValido e)
            {

                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("listarEnviosCliente")]
        [Authorize(Roles = "Cliente")]

        public IActionResult ListarEnvioCliente()
        {
            try
            {
                string EmailAscociadoAlToken = EmailUser();
                List<DTOEnvio> envios = _cuListarEnvioCliente.ListarEnviosUsuario(EmailAscociadoAlToken);

                if (envios == null)
                {
                    return NotFound();
                }
                return Ok(envios);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }

        [HttpGet("listarEnviosClienteFechas")]
        [Authorize(Roles = "Cliente")]
        public IActionResult BuscarEnviosPorFechasYEstado(DateTime fechaInicio, DateTime fechaFin, string estado)
        {
            try
            {
                string email = EmailUser();

                if (fechaInicio > fechaFin)
                {
                    return BadRequest("Fechas invalidas");

                }
                List<DTOEnvio> envios = _cuBuscarEnvioUsuario.BuscarEnviosUsuario(
                        email,
                        fechaInicio,
                        fechaFin,
                        estado
                    );
                if (envios == null)
                {
                    return NotFound();
                }
                return Ok(envios);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("listarSeguimientoDeEnvio")]
        [Authorize(Roles = "Cliente")]

        public IActionResult BuscarSeguimiento(int id)
        {

            try
            {
                string email = EmailUser();
               List<DTOSeguimiento> seg = _cUObtenerSeguimiento.ObtenerSeguimientosEnvio(id,email);

             

                return Ok(seg);


            }catch(ExceptionSeguimientos e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("listarEnviosClienteComentario")]
        [Authorize(Roles = "Cliente")]
        public IActionResult BuscarEnviosPorComentario(string comentario)
        {
            try
            {
                string email = EmailUser();

                List<DTOEnvio> envios = _cUBuscarEnvioPorComentario.BuscarEnviosUsuarioComentario(email, comentario);
                if (envios == null)
                {
                    return NotFound();
                }
                return Ok(envios);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private string EmailUser()
        {
            string email = null;
            // como obtener el email del token
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var emailClaim = claimsIdentity.Claims
                .FirstOrDefault(claim => claim.Type == ClaimTypes.Email);
                email = emailClaim.Value;
            }
            return email;
        }
    }
}
