using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using LIbreria.DTOs.DTOs.DTOsEnvio;
using LIbreria.DTOs.Mappers;
using System;
using System.Collections.Generic;

namespace Libreria.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUBuscarEnvioUsuario : ICUBuscarEnvioUsuario
    {
        private readonly IRepositorioEnvio _repositorioEnvio;

        public CUBuscarEnvioUsuario(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }

        public List<DTOEnvio> BuscarEnviosUsuario(string email, DateTime fechaInicio, DateTime fechaFin, string? estado)
        {
            var enviosFiltrados = _repositorioEnvio.BuscarEnviosPorEmailYFiltro(email, fechaInicio, fechaFin, estado);

            return MapperEnvio.FromListEnvioListDtoEnvio(enviosFiltrados);
        }
    }
}
