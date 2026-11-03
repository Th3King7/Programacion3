using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using Libreria.LogicaNegocio.Entidades.Enumerados.Estado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvio:IRepositorioEnvio
    {
        private ApplicationDbContext _context;
        public RepositorioEnvio(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Envio nuevo)
        {
            _context.Envios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;

        }

        public List<Envio> FindAll()
        {
            return _context.Envios.Include(e  => e.Seguimientos).ThenInclude(s =>s.Funcionario).ToList();
                
        }

        public Envio FindById(int id)
        {
            return _context.Envios.Include(e => e.Cliente).Include(e => e.Funcionario).Include(e => e.Seguimientos).ThenInclude(s => s.Funcionario)
            .FirstOrDefault(e => e.Id == id);

        }

        public Envio FindByTracking(string tracking)
        {
            return _context.Envios.Include(e => e.Cliente).Include(e => e.Funcionario).Include(e => e.Seguimientos).ThenInclude(s => s.Funcionario).Where(e => e.Tracking == tracking).SingleOrDefault();
               
        }

        public List<Envio> FindbyEmail(string email) {

            return _context.Envios.Include(e => e.Cliente).Include(e=>e.Funcionario).Include(e=>e.Seguimientos).ThenInclude(s=>s.Funcionario).Where(c => c.Cliente.Email == email).OrderBy(e=>e.FechaCreacion).ToList();
        }

        public List<Envio> BuscarEnviosPorEmailYFiltro(string email, DateTime fechaInicio, DateTime fechaFin, string? estado)
        {
            if (estado == "-1") {
                return  _context.Envios.Include(e => e.Cliente).Include(e => e.Funcionario).Include(e => e.Seguimientos).ThenInclude(s => s.Funcionario)
                    .Where(e => e.Cliente.Email == email &&
                                e.FechaCreacion.Date >= fechaInicio.Date &&
                                e.FechaCreacion.Date <= fechaFin.Date)
                    .OrderBy(e => e.Tracking).ToList();
            }
            else
            {
     var query = _context.Envios.Include(e => e.Cliente).Include(e => e.Funcionario).Include(e => e.Seguimientos).ThenInclude(s => s.Funcionario)
                    .Where(e => e.Cliente.Email == email &&
                                e.FechaCreacion.Date >= fechaInicio.Date &&
                                e.FechaCreacion.Date <= fechaFin.Date);

            if (!string.IsNullOrEmpty(estado))
            {
                if (Enum.TryParse(estado, out Estado estadoEnum))
                {
                    query = query.Where(e => e.Estado == estadoEnum);
                }
            }
            return query.OrderBy(e => e.Tracking).ToList();

            }
           

        }

        public void Remove(Envio obj)
        {
            throw new NotImplementedException();
        }

        public int Update(Envio obj)
        {
            _context.Envios.Update(obj);
            return _context.SaveChanges();
        }

        public List<Envio> FindbyComentario(string email, string comentario)
        {
            return _context.Envios.Include(e => e.Cliente).Include(e => e.Funcionario).Include(e => e.Seguimientos).ThenInclude(s => s.Funcionario).Where(c => c.Cliente.Email == email && c.Seguimientos.Any(s => s.Comenterio.Contains(comentario))).OrderBy(e => e.FechaCreacion).ToList();

        }

        public Envio GetEnvio(int id, string email)
        {
            return _context.Envios.Include(e => e.Cliente).Include(e => e.Funcionario).Include(e => e.Seguimientos).ThenInclude(s => s.Funcionario).Where(c => c.Cliente.Email == email && c.Id==id).SingleOrDefault();
        }
    }
}
