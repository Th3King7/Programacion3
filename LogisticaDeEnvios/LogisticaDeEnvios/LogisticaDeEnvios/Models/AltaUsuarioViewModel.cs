using LIbreria.DTOs.DTOs.DTOsEnvio;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LogisticaDeEnvios.Models
{
    public class AltaUsuarioViewModel
    {
        public DTOAltaUsuario DtoAlta { get; set; }
        public List<SelectListItem> Agencia { get; set; } = new List<SelectListItem>();

    }
}
