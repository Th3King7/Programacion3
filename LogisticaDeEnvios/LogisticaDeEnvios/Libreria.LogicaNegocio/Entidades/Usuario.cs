using Libreria.LogicaNegocio.CustomExceptions.ExceptionsUsuario;
using Libreria.LogicaNegocio.Entidades.Enumerados.UsuarioEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{

    public class Usuario
    {
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Rol { get; set; }
        public List<Envio> Envios { get; set; }

        public int AgenciaId { get; set; }

        public Agencia? Agencia { get; set; }

        public Usuario(string? nombre, string? apellido, string? email, string password, Roles rol,Agencia agencia)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
            Rol = rol;
            Envios = new List<Envio>();
           Agencia = agencia;
        }
        public Usuario()
        {
            
        }
    }
}
