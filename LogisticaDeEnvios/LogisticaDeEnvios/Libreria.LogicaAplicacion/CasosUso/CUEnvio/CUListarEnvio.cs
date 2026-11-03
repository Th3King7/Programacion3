using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using LIbreria.DTOs.DTOs.DTOsAgencia;
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
    public class CUListarEnvio : ICUListarEnvio
    {
       
        
        private IRepositorioEnvio _repositorioEnvio;

        public CUListarEnvio(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }
       public List<DTOEnvio> ListarEnvios()
        {

            List<Envio> envios = _repositorioEnvio.FindAll();

                List<DTOEnvio> listDtoParaRetornar = MapperEnvio.FromListEnvioListDtoEnvio(envios);

                return listDtoParaRetornar;


        }
    }
    }

