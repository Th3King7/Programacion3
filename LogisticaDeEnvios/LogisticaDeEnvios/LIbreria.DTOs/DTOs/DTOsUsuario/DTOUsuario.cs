using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Entidades.Enumerados.UsuarioEnums;
using LIbreria.DTOs.DTOs.DTOsEnvio;

namespace LIbreria.DTOs.DTOs.DTOsUsuario
{
    public class DTOUsuario
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "La longitud debe estar entre 8 y 32 caracteres")]

        public string? Password { get; set; }

        public int Id { get; set; }
        [Required]

        public string? Nombre { get; set; }
        [Required]

        public string? Apellido { get; set; }
        [Required]

        public int? AgenciaId { get; set; }
        [Required]

        public string? Rol { get; set; }
        public List<DTOEnvio>? Envios { get; set; }

    }
}
