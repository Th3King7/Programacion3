using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.ExceptionsUsuario
{
    public class ExeptionEmailNoValido : Exception
    {
        public ExeptionEmailNoValido(string msg) : base(msg)
        { 
  
        }

    }
}
