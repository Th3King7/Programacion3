using Libreria.LogicaNegocio.Entidades;
using LIbreria.DTOs.DTOs.DTOsEnvio;
using LIbreria.DTOs.DTOs.DTOsSeguimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreria.DTOs.Mappers
{
    public class MapperSeguimiento
    {
        public static Seguimiento ToSeguimiento(DTOSeguimiento s)
        {
            return new Seguimiento() { Id = s.Id, Comenterio = s.Comentario, Fecha = DateTime.Now, Envio = null, Funcionario = null };
        }
        public static List<DTOSeguimiento> FromListSeguimientoToListDtoSegumientos(List<Seguimiento> seguimientos)
        {

            List<DTOSeguimiento> ret = new List<DTOSeguimiento>();

            foreach (Seguimiento seguimiento in seguimientos)
            {

                DTOSeguimiento dto = new DTOSeguimiento();
                dto.Id = seguimiento.Id;
                dto.Fecha = seguimiento.Fecha;
                dto.Comentario = seguimiento.Comenterio;
                dto.Envio = seguimiento.Envio.Id;
              
                ret.Add(dto);
            }
            return ret;

        }


    }
}

