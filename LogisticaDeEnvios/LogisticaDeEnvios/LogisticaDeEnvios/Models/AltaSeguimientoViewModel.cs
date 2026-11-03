using LIbreria.DTOs.DTOs.DTOsEnvio;
using LIbreria.DTOs.DTOs.DTOsSeguimiento;
using LIbreria.DTOs.DTOs.DTOsUsuario;

namespace LogisticaDeEnvios.Models
{
    public class AltaSeguimientoViewModel
    {
        public DTOSeguimiento Dto { get; set; }
        public DTOEnvio Envio { get; set; }


    }
}
