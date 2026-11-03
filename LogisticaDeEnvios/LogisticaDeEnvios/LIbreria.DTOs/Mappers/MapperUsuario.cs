using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Entidades.Enumerados.UsuarioEnums;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using Utilidades;

namespace LIbreria.DTOs.Mappers
{
    public class MapperUsuario
    {
        public static List<DTOUsuario> FromListUsuarioToListDtoUsuario(List<Usuario> usuarios)
        {
            List<DTOUsuario> ret= new List<DTOUsuario>();

            foreach(Usuario usuario in usuarios) {
                DTOUsuario dto = new DTOUsuario();
                dto.Id = usuario.Id;
                dto.Nombre = usuario.Nombre;
                dto.Apellido = usuario.Apellido;
                dto.Email = usuario.Email;
                dto.Rol = usuario.Rol.ToString();
                ret.Add(dto);
            }
            return ret;
        }

        public static DTOUsuario ToDtoUsuario(Usuario u)
        {
            return new DTOUsuario() { Id = u.Id, Nombre = u.Nombre, Apellido = u.Apellido, Email = u.Email, Rol = u.Rol.ToString(),AgenciaId=u.AgenciaId };
        }

        public static Usuario ToUsuario(DTOAltaUsuario dto)
        {

            var r = Roles.Funcionario;

         
            if (dto.Rol.Equals(0))
            {
                r = Roles.Administrador;
            }

            string passHashed = Crypto.HashPasswordConBcrypt(dto.Password, 12);


            Usuario ret = new Usuario(dto.Nombre, dto.Apellido, dto.Email,dto.Password=passHashed,(Roles)dto.Rol,null);

            return ret;

        }

      
    }
}
