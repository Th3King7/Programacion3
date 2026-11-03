using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using LIbreria.DTOs.DTOs.DTOsEnvio;
using LIbreria.DTOs.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUListarEnvioUsuario : ICUListarEnvioUsuario
    {
        private IRepositorioEnvio _repositorioEnvio;

        public CUListarEnvioUsuario(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }
        public List<DTOEnvio> ListarEnviosUsuario(string email)
        {
            List<Envio> envios = _repositorioEnvio.FindbyEmail(email);

            List<DTOEnvio> listDtoParaRetornar = MapperEnvio.FromListEnvioListDtoEnvio(envios);

            return listDtoParaRetornar;
        }
    }
}
