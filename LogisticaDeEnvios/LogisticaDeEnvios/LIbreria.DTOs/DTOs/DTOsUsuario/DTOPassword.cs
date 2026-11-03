using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreria.DTOs.DTOs.DTOsUsuario
{
    public class DTOPassword
    {
        [Required]
        public string PasswordActual { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "La longitud debe estar entre 8 y 32 caracteres")]
        public string PasswordNueva { get; set; }
    }
}
