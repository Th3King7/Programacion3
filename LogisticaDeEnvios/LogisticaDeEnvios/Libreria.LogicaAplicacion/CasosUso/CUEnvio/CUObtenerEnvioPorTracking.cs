using LIbreria.DTOs.DTOs.DTOsEnvio;
using LIbreria.DTOs.Mappers;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using Libreria.LogicaNegocio.CustomExceptions.ExceptionsUsuario;
using Libreria.LogicaNegocio.CustomExceptions.ExceptionsEnvio;

namespace Libreria.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUObtenerEnvioPorTracking:ICUObtenerEnvioPorTracking
    {
        private IRepositorioEnvio _repositorioEnvio;

        public CUObtenerEnvioPorTracking(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }
        public DTOEnvio ObtenerEnvioPorTracking(string tracking)
        {
            Envio e = _repositorioEnvio.FindByTracking(tracking);
            if (e != null) {
                 DTOEnvio ret = MapperEnvio.FromEnvioToDtoEnvio(e);
            return ret;
            }
            else
            {
            throw new ExceptionNumeroDeTrackingNoValido("Tracking inválido, envio no encontrado");
            }
              
        }


    }
}
