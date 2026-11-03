using Libreria.LogicaNegocio.Entidades.Enumerados.UsuarioEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Seguimiento 
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Comenterio { get; set; }
        public int EnvioId { get; set; }
        public Envio Envio { get; set; }
        public Usuario Funcionario { get; set; }


        public Seguimiento(string Comentario,Envio envio,Usuario funcionario) { 
            Fecha = DateTime.Now;
            Comenterio = Comentario;
            Envio=envio;
            Funcionario = funcionario;
        
        }

        public Seguimiento() { }

 
    }
}
