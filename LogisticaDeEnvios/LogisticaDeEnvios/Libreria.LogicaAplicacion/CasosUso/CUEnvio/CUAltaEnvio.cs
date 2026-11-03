using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Libreria.LogicaNegocio.CustomExceptions.ExceptionsUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using LIbreria.DTOs.DTOs.DTOsEnvio;
using LIbreria.DTOs.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUAltaEnvio : ICUAltaEnvio
    {
        private IRepositorioEnvio _repoEnvio;
        private IRepositorioUsuario _repositorioUsuario;
        private IRepositorioAgencia _repositorioAgencia;

        public CUAltaEnvio(IRepositorioEnvio repoEnvio, IRepositorioUsuario repositorioUsuario, IRepositorioAgencia repositorioAgencia)
        {
            _repoEnvio = repoEnvio;
            _repositorioUsuario = repositorioUsuario;
            _repositorioAgencia = repositorioAgencia;
        }
        public void AltaEnvioComun(DTOAltaEnvio dto)
        {
            try
            {
                Usuario cliente = _repositorioUsuario.FindByEmail(dto.ClienteEmail);
                if (cliente == null)
                {
                    throw new ExeptionEmailNoValido("Usuario cliente no encontrado");
                }
                Usuario funcionario = _repositorioUsuario.FindById((int)dto.FuncionarioId);
                Agencia agenciaDestino = _repositorioAgencia.FindById((int)dto.AgenciaId);

                Envio envio = MapperEnvio.FromDtoAltaEnvioComunToEnvio(dto, agenciaDestino);
                
                envio.Cliente = cliente;
                envio.Funcionario = funcionario;
                int idInsert = _repoEnvio.Add(envio);


            }
            catch (Exception e)
            {
              

                throw e;
            }

        }

        public void AltaEnvioUrgente(DTOAltaEnvio dto)
        {

            try
            {
                Usuario cliente = _repositorioUsuario.FindByEmail(dto.ClienteEmail);
                if (cliente == null)
                {
                    throw new ExeptionEmailNoValido("Usuario cliente no encontrado");
                }
                Usuario funcionario = _repositorioUsuario.FindById((int)dto.FuncionarioId);

                Envio envio = MapperEnvio.FromDtoAltaEnvioUrgenteToEnvio(dto);
                envio.Cliente = cliente;
                envio.Funcionario= funcionario;
                int idInsert = _repoEnvio.Add(envio);



            }
            catch (Exception e)
            {


                throw e;
            }



        }

    }
}
