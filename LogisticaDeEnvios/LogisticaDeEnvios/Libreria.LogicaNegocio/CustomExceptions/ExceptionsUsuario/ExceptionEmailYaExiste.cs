using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.ExceptionsUsuario
{
    public class ExceptionEmailYaExiste : Exception
    {
        public ExceptionEmailYaExiste(string msg) : base(msg)
        {
        }
    
    }
}
