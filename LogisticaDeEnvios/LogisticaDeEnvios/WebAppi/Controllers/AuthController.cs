using Libreria.LogicaAplicacion.CasosUso.CULogin;
using Libreria.LogicaAplicacion.ICasosUso.ICULogin;
using Libreria.LogicaNegocio.CustomExceptions.ExceptionsUsuario;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using LIbreria.DTOs.DTOs.DTOsLogin;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAppi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private ICULogin _CULogin;

        public AuthController(ICULogin cuLogin)
        {
            _CULogin = cuLogin;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] DTOLogin dto)
        {


            try
            {
                DTOUsuario login = new DTOUsuario();
                login.Email = dto.Email;
                login.Password = dto.Password;
                DTOUsuario b = _CULogin.VerificarDatosParaLogin(login);
                var clave = "UTzl^7yPl$5xrT6&{7RZCSG&O42MEK89$CW1XXRrN(>XqIp{W4s2S5$>KT$6CG!2M]'ZlrqH-t%eI4.X9W~u#qO+oX£+[?7QDAa";
                var claveCodificada = new
               SymmetricSecurityKey(Encoding.UTF8.GetBytes(clave));
                List<Claim> claims = [
                 new Claim(ClaimTypes.Email, b.Email),
                 new Claim(ClaimTypes.Role, b.Rol)
                ];
                var credenciales = new SigningCredentials(claveCodificada,
               SecurityAlgorithms.HmacSha512Signature);
                var token = new JwtSecurityToken(claims: claims, expires:
               DateTime.Now.AddDays(1), signingCredentials: credenciales);
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { Token = jwt });
            }
            catch (ExeptionEmailNoValido e) { 
            return BadRequest(e.Message);
            }
            catch (ExceptionPasswordNoValido e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }
    }
}

