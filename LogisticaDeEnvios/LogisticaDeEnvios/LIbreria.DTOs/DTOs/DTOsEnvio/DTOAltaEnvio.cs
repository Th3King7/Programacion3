using Libreria.LogicaNegocio.Entidades.Enumerados.Estado;
using Libreria.LogicaNegocio.Entidades.Enumerados.UsuarioEnums;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIbreria.DTOs.DTOs.DTOsAgencia;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using LIbreria.DTOs.DTOs.DTOsSeguimiento;
using System.ComponentModel.DataAnnotations;


namespace LIbreria.DTOs.DTOs.DTOsEnvio
{
    public class DTOAltaEnvio
    {
        public string TipoEnvio {  get; set; }
        string Tracking { get; set; }
        public int Id { get; set; }
        [Required]
        public decimal Peso { get; set; }
        public int Estado {  get; set; }
        [Required]
        public string ClienteEmail { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int? FuncionarioId { get; set; }
        public int? AgenciaId { get; set; }


        //Envio Comun
        public int? DestinoId { get; set; }


        //EnvioUrgente
        [Required]
        public string? DreccionDestino { get; set; }
        public bool? EntregaEficiente { get; set; }

       

    }


    }

