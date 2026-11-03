using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.InterfaceRepositorio
{
    public interface IRepositorioEnvio:IRepositorio<Envio>
    {
        List<Envio> FindbyEmail(string email);
        Envio GetEnvio(int id,string email);
        Envio FindByTracking(string tracking);
        List<Envio> BuscarEnviosPorEmailYFiltro(string email, DateTime fechaInicio, DateTime fechaFin, string? estado);
        List<Envio> FindbyComentario(string email, string comentario);
    }
}
