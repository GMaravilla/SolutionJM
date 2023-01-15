using Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class BaleroRepositorio : IRepositorioGenerico<Balero>
    {
        private readonly MvcPruebasContext _MvcContext;
        public BaleroRepositorio(MvcPruebasContext MvcContext) 
        {
            _MvcContext = MvcContext;
        }

        public async Task<bool> Actualizar(Balero model)
        {
            _MvcContext.Baleros.Add(model);
            await _MvcContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
           _MvcContext.Baleros.First(e => e.IdBaleros == id);
            await _MvcContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Balero model)
        {
            _MvcContext.Baleros.Add(model);
            await _MvcContext.SaveChangesAsync();
            return true;
        }

        public async Task<Balero> Obtener(int id)
        {
            return await _MvcContext.Baleros.FindAsync(id);
        }

        public async Task<IQueryable<Balero>> ObtenerTodos()
        {
           IQueryable<Balero> query = _MvcContext.Baleros;
            return query;
        }

        //faltaria el del datatable
    }
}
