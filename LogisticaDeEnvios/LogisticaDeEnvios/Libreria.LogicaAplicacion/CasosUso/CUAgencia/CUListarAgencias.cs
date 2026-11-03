using Libreria.LogicaAplicacion.ICasosUso.ICUAgencia;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using LIbreria.DTOs.DTOs.DTOsAgencia;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using LIbreria.DTOs.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUAgencia
{
    public class CUListarAgencias : ICUListarAgencias
    {
        private IRepositorioAgencia _repositorioAgencia;

        public CUListarAgencias(IRepositorioAgencia repositorioAgencia)
        {
            _repositorioAgencia = repositorioAgencia;
        }
        public List<DTOAgencia> ListarAgencias()
        {
            
        {
            List<Agencia> agencias = _repositorioAgencia.FindAll();

            List<DTOAgencia> listDtoParaRetornar = MapperAgencia.FromListAgenciaToListDtoAgencia(agencias);
            return listDtoParaRetornar;
        }
    }
    }
}
