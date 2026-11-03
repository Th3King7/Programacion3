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
    public class CUBuscarEnvioPorComentario : ICUBuscarEnvioPorComentario
    {
        private readonly IRepositorioEnvio _repositorioEnvio;

        public CUBuscarEnvioPorComentario(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }
        public List<DTOEnvio> BuscarEnviosUsuarioComentario(string email, string comentario)
        {
            List<Envio> envios = _repositorioEnvio.FindbyComentario(email,comentario);

            List<DTOEnvio> listDtoParaRetornar = MapperEnvio.FromListEnvioListDtoEnvio(envios);

            return listDtoParaRetornar;
        }
    }
}
