using LIbreria.DTOs.DTOs.DTOsEnvio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LogisticaDeEnvios.Models
{
    public class AltaEnvioUrgenteViewModel
    {
        public DTOAltaEnvio Dto { get; set; }

        public List<SelectListItem> Cliente { get; set; } = new List<SelectListItem>();
    }
}
