using Libreria.LogicaAplicacion.ICasosUso.ICUSeguimiento;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using LIbreria.DTOs.DTOs.DTOsEnvio;
using LIbreria.DTOs.DTOs.DTOsSeguimiento;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using LIbreria.DTOs.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUSeguimiento
{
    public class CUAltaSeguimiento : ICUAltaSeguimiento
    {
        private IRepositorioSeguimento _repoSeguimiento;
        private IRepositorioEnvio _repositorioEnvio;
        private IRepositorioUsuario _repositorioUsuario;
     

        public CUAltaSeguimiento(IRepositorioSeguimento repoSeguimiento,IRepositorioEnvio repoEnvio,IRepositorioUsuario repoUsuario)
        {
            _repoSeguimiento = repoSeguimiento;
            _repositorioEnvio = repoEnvio;
            _repositorioUsuario = repoUsuario;
        }

        public void AltaSeguimiento(DTOSeguimiento dto)

        {
            
            Seguimiento nuevo = MapperSeguimiento.ToSeguimiento(dto);
            nuevo.Envio = _repositorioEnvio.FindById(dto.Envio);
            nuevo.Funcionario = _repositorioUsuario.FindById(dto.Funcionario);
            nuevo.Envio.Seguimientos.Add(nuevo);
            int idEntidad = _repoSeguimiento.Add(nuevo);
        }
    }
}
