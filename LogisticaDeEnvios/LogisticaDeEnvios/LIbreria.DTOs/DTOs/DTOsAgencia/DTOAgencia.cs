using Libreria.LogicaNegocio.Entidades.VO.Agencia;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIbreria.DTOs.DTOs.DTOsUsuario;

namespace LIbreria.DTOs.DTOs.DTOsAgencia
{
    public class DTOAgencia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Ubicacion Ubicacion { get; set; }
        public List<DTOUsuario> Usuarios { get; set; }
    }
}
