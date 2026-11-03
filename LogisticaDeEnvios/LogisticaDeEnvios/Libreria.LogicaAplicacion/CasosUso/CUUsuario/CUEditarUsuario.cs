using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
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
using Utilidades;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUEditarUsuario : ICUEditarUsuario
    {
      
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAuditoria;

        public CUEditarUsuario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }

        public void EditarUsuario(DTOUsuario dto)
        {
            Usuario buscado = _repoUsuario.FindByEmail(dto.Email);
            if (buscado != null && buscado.Id != dto.Id)
            {
                throw new ExceptionEmailYaExiste("EL email ya existe en otro usuario");
            }
            Usuario u = _repoUsuario.FindById(dto.Id);
            string passHashed = Crypto.HashPasswordConBcrypt(dto.Password, 12);
            u.Nombre = dto.Nombre;
            u.Apellido = dto.Apellido;
            u.Email = dto.Email;
            u.Password = passHashed;
            u.Rol = Enum.Parse<Roles>(dto.Rol);



            _repoUsuario.Update(u);

      

        }
    }
    }

