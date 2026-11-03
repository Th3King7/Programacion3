using Libreria.LogicaNegocio.Entidades.Enumerados.Estado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class EnvioComun : Envio
    {

        public EnvioComun(string tracking, decimal peso,Usuario cliente,Usuario funcionario,Agencia destino) :base(tracking,peso,cliente,funcionario)
        {
            Destino = destino;
        }
        public EnvioComun() :base(){

        }
        public Agencia Destino { get; set; }

  
    }
}
