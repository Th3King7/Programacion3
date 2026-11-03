using Libreria.LogicaAplicacion.ICasosUso;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaNegocio.Entidades.Enumerados.UsuarioEnums;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades;
using LIbreria.DTOs.DTOs.DTOsEnvio;
using Libreria.LogicaNegocio.Entidades.Enumerados.Estado;
using Libreria.LogicaNegocio.CustomExceptions.ExceptionsUsuario;

namespace Libreria.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUFinalizarEnvio : ICUFinalizarEnvio
    {

        private IRepositorioEnvio _repoEnvio;

        public CUFinalizarEnvio(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }

        public void FinalizarEnvio(DTOEnvio dto)
        {
            

                Envio e = _repoEnvio.FindById(dto.Id);
                e.Estado = Estado.Finalizado;
                e.FechaEntrega = DateTime.Now;

                if (e is EnvioUrgente envioUrgente)
                {
                    TimeSpan diferencia = e.FechaEntrega.Value - e.FechaCreacion;
                    bool dentroDe24Horas = diferencia.TotalHours <= 24;

                    envioUrgente.EntregaEficiente = dentroDe24Horas;
                }
                    _repoEnvio.Update(e);
           
            

        }
    }
}
