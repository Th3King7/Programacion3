using LIbreria.DTOs.DTOs.DTOsEnvio;
using LIbreria.DTOs.DTOs.DTOsSeguimiento;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUSeguimiento
{
    public interface ICUAltaSeguimiento
    {
        void AltaSeguimiento(DTOSeguimiento dto);
    }
}
