using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAccesoDatos.Repositorios
{
    public class RepositorioSeguimiento : IRepositorioSeguimento
    {
        private ApplicationDbContext _context;
        public RepositorioSeguimiento(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Seguimiento nuevo)
        {
            _context.Seguimientos.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<Seguimiento> FindAll()
        {
            throw new NotImplementedException();
        }

        public Seguimiento FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Seguimiento FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Seguimiento obj)
        {
            throw new NotImplementedException();
        }

        public int Update(Seguimiento obj)
        {
            throw new NotImplementedException();
        }
    }
}
