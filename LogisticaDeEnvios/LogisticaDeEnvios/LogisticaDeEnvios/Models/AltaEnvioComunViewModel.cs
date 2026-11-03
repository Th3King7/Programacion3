using LIbreria.DTOs.DTOs.DTOsEnvio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LogisticaDeEnvios.Models
{
    public class AltaEnvioComunViewModel
    {
        public DTOAltaEnvio Dto { get; set; }

        public List<SelectListItem> Agencia { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Cliente { get; set; } = new List<SelectListItem>();
    }
}
