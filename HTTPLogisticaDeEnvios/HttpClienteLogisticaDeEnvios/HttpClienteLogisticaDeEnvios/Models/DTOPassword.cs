using System.ComponentModel.DataAnnotations;

namespace HttpClienteLogisticaDeEnvios.Models
{
    public class DTOPassword
    {
        [Required]
        public string PasswordActual { get; set; }
        [Required]
        public string PasswordNueva { get; set; }
    }
}
