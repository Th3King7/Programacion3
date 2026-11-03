using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.ExceptionsEnvio
{
    public class ExceptionSeguimientos:Exception
    {
        public ExceptionSeguimientos(string msg) : base(msg)
        {
        }
    }
}
