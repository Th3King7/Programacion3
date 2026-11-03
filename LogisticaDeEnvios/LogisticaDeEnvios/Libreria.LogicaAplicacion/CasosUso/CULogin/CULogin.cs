using Libreria.LogicaAplicacion.ICasosUso.ICULogin;
using Libreria.LogicaNegocio.CustomExceptions.ExceptionsUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Entidades.Enumerados.UsuarioEnums;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CULogin
{
    public class CULogin : ICULogin
    {
        private IRepositorioUsuario _repoUsuario;

        public CULogin(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }
        public DTOUsuario VerificarDatosParaLogin(DTOUsuario dto)
        {
            try
            {
                Usuario u = _repoUsuario.FindByEmail(dto.Email);
                if (u is null)
                {
                    throw new ExeptionEmailNoValido("Usuario no encontrado");
                }
                bool coincideElPassword = Utilidades.Crypto.VerifyPasswordConBcrypt(dto.Password, u.Password);

                if (coincideElPassword)
                {
                    DTOUsuario ret = new DTOUsuario();
                    ret.Id = u.Id;
                    ret.Email = dto.Email;
                    ret.Rol = u.Rol.ToString();
                    return ret;
                }
                else
                {

                    throw new ExceptionPasswordNoValido("Contraseña invalida");
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
