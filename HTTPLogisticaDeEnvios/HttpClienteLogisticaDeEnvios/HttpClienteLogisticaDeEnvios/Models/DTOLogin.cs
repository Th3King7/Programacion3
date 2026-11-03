using System.ComponentModel.DataAnnotations;

namespace HttpClienteLogisticaDeEnvios.Models
{
    public class DTOLogin
    {
        [Required]
        [EmailAddress]      
        public string? Email { get; set; } 
        [Required]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "La longitud debe estar entre 8 y 32 caracteres")]
        public string? Password { get; set; }
    }
}
