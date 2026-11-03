using LIbreria.DTOs.DTOs.DTOsEnvio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUEnvio
{
    public interface ICUAltaEnvio
    {
        void AltaEnvioComun(DTOAltaEnvio dto);
        void AltaEnvioUrgente(DTOAltaEnvio dto);

    }
}
