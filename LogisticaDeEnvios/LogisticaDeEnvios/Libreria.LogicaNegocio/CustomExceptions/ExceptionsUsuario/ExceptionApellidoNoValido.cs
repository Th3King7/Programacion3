using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.ExceptionsUsuario
{
    public class ExceptionApellidoNoValido : Exception
    {
        public ExceptionApellidoNoValido(string msg) : base(msg)
        {
        }
    
    }
}
