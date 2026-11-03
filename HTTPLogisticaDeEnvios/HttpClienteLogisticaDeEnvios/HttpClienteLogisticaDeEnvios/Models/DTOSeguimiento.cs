namespace HttpClienteLogisticaDeEnvios.Models
{
    public class DTOSeguimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public int Envio { get; set; }
        public int Funcionario { get; set; }
    }
}
