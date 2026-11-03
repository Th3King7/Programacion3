using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Entidades.Enumerados.Estado;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using LIbreria.DTOs.DTOs.DTOsAgencia;
using LIbreria.DTOs.DTOs.DTOsEnvio;
using LIbreria.DTOs.DTOs.DTOsSeguimiento;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbreria.DTOs.Mappers
{
    public class MapperEnvio
    {
  
        public static Envio FromDtoAltaEnvioComunToEnvio(DTOAltaEnvio dto,Agencia destino)
        {
            Envio envioNuevo;

            string tracking = "TRK-" + Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("+", "").Replace("/", "").Replace("=", "").Substring(0, 10).ToUpper();

            envioNuevo = new EnvioComun (tracking, dto.Peso, null,null,destino);
            

            return envioNuevo;


        }
        public static Envio FromDtoAltaEnvioUrgenteToEnvio(DTOAltaEnvio dto)
        {
            Envio envioNuevo;

            string tracking = "TRK-" + Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("+", "").Replace("/", "").Replace("=", "").Substring(0, 10).ToUpper();
            envioNuevo = new EnvioUrgente (tracking, dto.Peso, null,null,dto.DreccionDestino,false);


            return envioNuevo;
        }

        public static DTOEnvio ToDtoEnvio(Envio e)
        {
            List<DTOSeguimiento> lds = new List<DTOSeguimiento>();
            foreach (Seguimiento s in e.Seguimientos)
            {
                lds.Add(ToDTOSeguimiento(s));
            }
            return new DTOEnvio() { Id = e.Id, Tracking = e.Tracking, Peso = e.Peso,Estado=e.Estado.ToString(), ClienteId = e.ClienteId, FuncionarioId = e.FuncionarioId ,Seguimientos = lds,
                FechaCreacion =e.FechaCreacion };
        }

        private static DTOSeguimiento ToDTOSeguimiento(Seguimiento s)
        {
            DTOSeguimiento dto = new DTOSeguimiento();
            dto.Id = s.Id;
            dto.Fecha  = s.Fecha;
            dto.Comentario = s.Comenterio;

            return dto;
        }

        public static DTOEnvio FromEnvioToDtoEnvio(Envio envio)
        {
            if (envio.Seguimientos != null)
            {
                List<DTOSeguimiento> dtoSeguimiento = MapperSeguimiento.FromListSeguimientoToListDtoSegumientos(envio.Seguimientos);

                DTOEnvio dto;
                if (envio is EnvioComun comun)
                {


                    dto = new DTOEnvio(comun.GetType().Name, comun.Tracking, comun.Id, comun.Peso, comun.Estado.ToString(), comun.ClienteId,comun.FechaCreacion, comun.FuncionarioId, dtoSeguimiento,null, null,null);
                }
                else
                {
                    EnvioUrgente urgente = envio as EnvioUrgente;
                    dto = new DTOEnvio(urgente.GetType().Name, urgente.Tracking, urgente.Id, urgente.Peso, urgente.Estado.ToString(), urgente.ClienteId,urgente.FechaCreacion, urgente.FuncionarioId, dtoSeguimiento, null, urgente.DireccionDestino, urgente.EntregaEficiente);

                }
                return dto;
            }
            else
            {
                DTOEnvio dto;
                if (envio is EnvioComun comun)
                {


                    dto = new DTOEnvio(comun.GetType().Name, comun.Tracking, comun.Id, comun.Peso, comun.Estado.ToString(), comun.ClienteId, comun.FechaCreacion, comun.FuncionarioId, null,null, null, null);
                }
                else
                {
                    EnvioUrgente urgente = envio as EnvioUrgente;
                    dto = new DTOEnvio(urgente.GetType().Name, urgente.Tracking, urgente.Id, urgente.Peso, urgente.Estado.ToString(), urgente.ClienteId, urgente.FechaCreacion, urgente.FuncionarioId, null, null, urgente.DireccionDestino, urgente.EntregaEficiente);

                }
                return dto;
            }
        }


        public static List<DTOEnvio> FromListEnvioListDtoEnvio(List<Envio> Envios)
        {
            List<DTOEnvio> ret = new List<DTOEnvio>();

            foreach (Envio envio in Envios)
            {
                if (envio.Estado == 0) 
                { 
                    ret.Add(FromEnvioToDtoEnvio(envio));
                }
            }

            return ret;
        }

    }
}
