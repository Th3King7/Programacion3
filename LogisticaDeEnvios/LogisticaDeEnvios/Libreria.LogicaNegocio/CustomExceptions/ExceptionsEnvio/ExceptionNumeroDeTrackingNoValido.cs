using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.ExceptionsEnvio
{
    public class ExceptionNumeroDeTrackingNoValido:Exception
    {
        public ExceptionNumeroDeTrackingNoValido(string msg) : base(msg)
        {
        }
    }
}
