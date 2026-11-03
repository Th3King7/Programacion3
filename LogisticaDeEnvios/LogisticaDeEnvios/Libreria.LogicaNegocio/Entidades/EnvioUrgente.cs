using Libreria.LogicaNegocio.Entidades.Enumerados.Estado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class EnvioUrgente : Envio
    {

        public EnvioUrgente(string tracking, decimal peso, Usuario cliente, Usuario funcionario,string direccionDestino,bool entregaEficiente) : base(tracking, peso, cliente, funcionario)
        {
            DireccionDestino = direccionDestino;
            EntregaEficiente = entregaEficiente;
        }
        public EnvioUrgente() : base() {
        }
        public string DireccionDestino { get; set; }
        public bool EntregaEficiente { get; set; }

  
    }
}
