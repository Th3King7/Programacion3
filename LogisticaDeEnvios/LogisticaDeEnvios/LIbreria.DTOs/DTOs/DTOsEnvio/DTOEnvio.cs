using Libreria.LogicaNegocio.Entidades.Enumerados.Estado;
using LIbreria.DTOs.DTOs.DTOsAgencia;
using LIbreria.DTOs.DTOs.DTOsSeguimiento;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreria.DTOs.DTOs.DTOsEnvio
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


        public DTOEnvio(string tipoEnvio,string tracking, int id, decimal peso,string estado, int clienteId,DateTime fechaCreacion ,int funcionarioId, List<DTOSeguimiento> seguimientos, int? destinoId, string? direccionDestino, bool? entregaEficiente)
        {
            TipoEnvio = tipoEnvio;
            Tracking = tracking;
            Id = id;
            Peso = peso;
            Estado = estado;
            ClienteId = clienteId;
            FechaCreacion = fechaCreacion;
            FuncionarioId = funcionarioId;
            Seguimientos = seguimientos;
            FechaEntrega = null;
            DestinoId = destinoId;
            DireccionDestino = direccionDestino;
            EntregaEficiente = entregaEficiente;
           
        }

        public DTOEnvio()
        {

        }

    }
}
