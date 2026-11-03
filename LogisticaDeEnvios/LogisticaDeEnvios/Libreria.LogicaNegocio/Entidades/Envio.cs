using Libreria.LogicaNegocio.Entidades.Enumerados.Estado;
using Libreria.LogicaNegocio.Entidades.Enumerados.UsuarioEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{

    public class Envio 
    {
        public int Id { get; set; }
        public string Tracking { get; set; }
        public decimal Peso { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public Estado Estado { get; set; }
        public int ClienteId { get; set; }
        public Usuario Cliente { get; set; }
        public int FuncionarioId { get; set; }
        public Usuario Funcionario { get; set; }
        public List<Seguimiento> Seguimientos { get; set; }

        public Envio(string traking, decimal peso, Usuario cliente, Usuario funcionario) {
            Tracking = traking;
            Peso = peso;
            FechaCreacion = DateTime.Now;
            FechaEntrega = null;
            Estado = 0;
            Cliente = cliente;
            Funcionario = funcionario;
            Seguimientos = new List<Seguimiento>();

        }

        public Envio() { }

   
    }
}
