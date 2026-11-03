using Libreria.LogicaNegocio.Entidades;
using LIbreria.DTOs.DTOs.DTOsEnvio;
using LIbreria.DTOs.DTOs.DTOsSeguimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUEnvio
{
    public interface ICUObtenerSeguimientos
    {
        List<DTOSeguimiento> ObtenerSeguimientosEnvio(int id, string email);

    }
}
