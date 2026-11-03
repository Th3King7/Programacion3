using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
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

namespace Libreria.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUObtenerEnvio : ICUObtenerEnvio
    {
        private IRepositorioEnvio _repositorioEnvio;

        public CUObtenerEnvio(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }
        public DTOEnvio ObtenerEnvio(int id)
        {
            Envio e = _repositorioEnvio.FindById(id);
            DTOEnvio ret = MapperEnvio.ToDtoEnvio(e);
            return ret;
        }

    }
}
