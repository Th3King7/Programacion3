using Libreria.LogicaAplicacion.ICasosUso.ICUAltaUsuario;
using Libreria.LogicaNegocio.CustomExceptions.ExceptionsUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using LIbreria.DTOs.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUAltaUsuario
{
    public class CUAltaUsuario : ICUAltaUsuario

    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAgencia _repositorioAgencia;
        private IRepositorioAuditoria _repoAuditoria;

        public CUAltaUsuario(IRepositorioUsuario repoUsuario, IRepositorioAgencia repoAgencia, IRepositorioAuditoria repoAuditoria)
        {
            _repoUsuario = repoUsuario;
            _repositorioAgencia = repoAgencia;
            _repoAuditoria = repoAuditoria;
        }


        public void AltaUsuario(DTOAltaUsuario dto)
        {
            try
            {
                Usuario buscado = _repoUsuario.FindByEmail(dto.Email);
                if (buscado != null)
                {
                    throw new ExceptionEmailYaExiste("EL email ya existe");
                }

                Agencia agencia = _repositorioAgencia.FindById((int)dto.AgenciaId);
                Usuario nuevo = MapperUsuario.ToUsuario(dto);
                nuevo.Agencia = agencia;
                int idEntidad = _repoUsuario.Add(nuevo);

               Auditoria aud = new Auditoria(dto.LogueadoId, "ALTA", nuevo.GetType().Name, idEntidad.ToString(), "Alta correcta" + JsonSerializer.Serialize(nuevo));

                _repoAuditoria.Auditar(aud);
            }
            catch (Exception e)
            {
                Auditoria aud = new Auditoria(dto.LogueadoId, "ALTA", "Usuario", null, "ERROR: " + e.Message);

                _repoAuditoria.Auditar(aud);
                throw e;
            }


        }
    }
}
