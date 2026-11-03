using Libreria.LogicaNegocio.Entidades.Enumerados.UsuarioEnums;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIbreria.DTOs.DTOs.DTOsEnvio;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using System.ComponentModel.DataAnnotations;

namespace LIbreria.DTOs.DTOs.DTOsSeguimiento
{
    public class DTOSeguimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [Required]
        public string Comentario { get; set; }
        public int Envio { get; set; }
        public int Funcionario { get; set; }
    }
}
