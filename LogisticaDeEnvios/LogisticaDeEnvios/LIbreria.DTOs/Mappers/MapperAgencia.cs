using Libreria.LogicaNegocio.Entidades;
using LIbreria.DTOs.DTOs.DTOsAgencia;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreria.DTOs.Mappers
{
    public class MapperAgencia
    {
        public static List<DTOAgencia> FromListAgenciaToListDtoAgencia(List<Agencia> agencias)
        {
            List<DTOAgencia> ret = new List<DTOAgencia>();

            foreach (Agencia agencia in agencias)
            {
                DTOAgencia dto = new DTOAgencia();
                dto.Id = agencia.Id;
                dto.Nombre = agencia.Nombre;
                dto.Direccion = agencia.Direccion;
                dto.Ubicacion = agencia.Ubicacion;
                ret.Add(dto);
            }
            return ret;
        }
    }
}
