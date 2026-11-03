using LIbreria.DTOs.DTOs.DTOsUsuario;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LogisticaDeEnvios.Models
{
    public class EditUsuarioViewModel
    {
        public DTOUsuario DtoEdit { get; set; }

        public List<SelectListItem> Agencia { get; set; } = new List<SelectListItem>();
    }
}
