namespace HttpClienteLogisticaDeEnvios.Models
{
    public class DTOEnvio
    {
        public string TipoEnvio { get; set; }
        public string Tracking { get; set; }
        public int Id { get; set; }
        public decimal Peso { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int ClienteId { get; set; }
        public int FuncionarioId { get; set; }
        public List<DTOSeguimiento> Seguimientos { get; set; }
        public DateTime? FechaEntrega { get; set; }
        //Envio Comun
        public int? DestinoId { get; set; }

        //Envio Urgente

        public string? DireccionDestino { get; set; }
        public bool? EntregaEficiente { get; set; }


    }
}
