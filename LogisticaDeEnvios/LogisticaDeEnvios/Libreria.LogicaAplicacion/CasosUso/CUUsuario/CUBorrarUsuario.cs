using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.Entidades.Enumerados.UsuarioEnums;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIbreria.DTOs.DTOs.DTOsUsuario;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUBorrarUsuario : ICUBorrarUsuario
    {
    
          private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAuditoria;

        public CUBorrarUsuario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }

    

        public void EliminarUsuario(DTOUsuario dto)
        {
            Usuario u = _repoUsuario.FindById(dto.Id);

            _repoUsuario.Remove(u);
        }
    }
}
        
   

