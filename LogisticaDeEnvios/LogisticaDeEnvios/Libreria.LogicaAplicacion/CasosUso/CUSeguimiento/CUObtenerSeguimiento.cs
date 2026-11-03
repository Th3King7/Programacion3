using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Libreria.LogicaNegocio.CustomExceptions.ExceptionsEnvio;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using LIbreria.DTOs.DTOs.DTOsSeguimiento;
using LIbreria.DTOs.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUSeguimiento
{
    public class CUObtenerSeguimiento : ICUObtenerSeguimientos
    {
        private IRepositorioEnvio _repositorioEnvio;

        public CUObtenerSeguimiento(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }
        public List<DTOSeguimiento> ObtenerSeguimientosEnvio(int id, string email)
        {

            Envio e = _repositorioEnvio.GetEnvio(id, email);

            if (e.Seguimientos == null)
            {
                throw new ExceptionSeguimientos("Sin Seguimientos");
            }
            else
            {
            List<DTOSeguimiento> ret = MapperSeguimiento.FromListSeguimientoToListDtoSegumientos(e.Seguimientos);
            return ret;
            }

             
        }

    }

}

