using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAccesoDatos.Repositorios
{
    public class RepositorioAgencia : IRepositorioAgencia
    {
        private ApplicationDbContext _context;
        public RepositorioAgencia(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Agencia nuevo)
        {
            throw new NotImplementedException();
        }

        public List<Agencia> FindAll()
        {
 
            return _context.Agencias.ToList();
        }


        public Agencia FindById(int id)
        {
            return _context.Agencias.Where(x => x.Id == id).SingleOrDefault();
        }

        public void Remove(Agencia obj)
        {
            throw new NotImplementedException();
        }

        public int Update(Agencia obj)
        {
            throw new NotImplementedException();
        }
    }
}
