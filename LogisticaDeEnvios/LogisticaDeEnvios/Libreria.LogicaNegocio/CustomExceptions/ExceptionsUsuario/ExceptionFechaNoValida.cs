using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.ExceptionsUsuario
{
    public class ExceptionFechaNoValida : Exception
    {
        public ExceptionFechaNoValida(string msg) : base(msg)
        {

        }
    
    }
}
