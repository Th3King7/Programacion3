using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.ExceptionsUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{

    public class CUEditarPassword : ICUEditarPassword
    {
        private IRepositorioUsuario _repoUsuario;

        public CUEditarPassword(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public void EditarPassword(string PasswordActual, string PasswordNueva, string email)
        {
            Usuario buscado = _repoUsuario.FindByEmail(email);

            if (Crypto.VerifyPasswordConBcrypt(PasswordActual, buscado.Password))
            {
                string passHashedNueva = Crypto.HashPasswordConBcrypt(PasswordNueva,12);
                buscado.Password = passHashedNueva;
                _repoUsuario.Update(buscado);
            }
            else
            {
                throw new ExceptionPasswordNoValido("Contraseña actual no coicide");
            }
        }
    }
}
