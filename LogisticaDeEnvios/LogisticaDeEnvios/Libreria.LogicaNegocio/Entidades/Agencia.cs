using Libreria.LogicaNegocio.Entidades.VO.Agencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Agencia 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Ubicacion Ubicacion { get; set; }
        public List<Usuario> Usuarios { get; set; }

        public Agencia(string nombre, string direccion, Ubicacion ubicacion, List<Usuario> funcionarios)
        {
        Nombre = nombre;
        Direccion = direccion;  
        Ubicacion = ubicacion;
        Usuarios = funcionarios;
        
        }    
        public Agencia() { }

  
    }
}
