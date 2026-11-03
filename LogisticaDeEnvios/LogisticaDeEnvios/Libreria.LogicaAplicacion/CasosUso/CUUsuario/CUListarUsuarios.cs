using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using LIbreria.DTOs.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUListarUsuarios : ICUListarUsuarios
    {
        private IRepositorioUsuario _repositorioUsuario;

        public CUListarUsuarios (IRepositorioUsuario repositorioUsuario){
            _repositorioUsuario = repositorioUsuario;
            }
        public List<DTOUsuario> ListarUsuario()
        {
            List<Usuario> usuarios = _repositorioUsuario.FindAll();

            List<DTOUsuario> listDtoParaRetornar = MapperUsuario.FromListUsuarioToListDtoUsuario(usuarios);
            return listDtoParaRetornar;
        }
       
    }
}
