using Libreria.LogicaAplicacion.CasosUso.CUEnvio;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.ExceptionsUsuario;
using LIbreria.DTOs.DTOs.DTOsEnvio;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAppi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private ICUEditarPassword _cuEditarPassword;


        public UsuarioController( ICUEditarPassword cuEditarPassword)
        {
            _cuEditarPassword = cuEditarPassword;
        }
    

        [HttpPut("cambiarPassword")]
        [Authorize(Roles = "Cliente")]
        public IActionResult CambiarPassword([FromBody]DTOPassword dto) {

            try
            {
                if (dto.PasswordActual != dto.PasswordNueva) { 
                string EmailAscociadoAlToken = EmailUser();
                _cuEditarPassword.EditarPassword(dto.PasswordActual, dto.PasswordNueva, EmailAscociadoAlToken);
                return Ok("Se cambió la contraseña correctamente");
                }
                else
                {
                    return BadRequest("La contraseña nueva no puede ser igual a la anterior ");
                }
                

            } catch (ExceptionPasswordNoValido e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e) {
                return StatusCode(500);
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
