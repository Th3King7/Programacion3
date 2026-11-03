using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades.VO.Agencia
{
    [ComplexType]
    public record Ubicacion
    {
        public double Longitud { get; set; }
        public double Latitud { get; set; }

    }
}
