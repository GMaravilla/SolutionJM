using Data.DataContext;
using Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class BaleroSerivicio : IBaleroService
    {
        private readonly IRepositorioGenerico<Balero> _BaleroRepo;

        public BaleroSerivicio(IRepositorioGenerico<Balero> BaleroRepo)
        {
            _BaleroRepo= BaleroRepo;
        }

        public async Task<bool> Actualizar(Balero model)
        {
            return await _BaleroRepo.Actualizar(model);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _BaleroRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Balero model)
        {
            return await _BaleroRepo.Insertar(model);
        }

        public async Task<Balero> Obtener(int id)
        {
           return await _BaleroRepo.Obtener(id);
        }

        public async Task<IQueryable<Balero>> ObtenerTodos()
        {
            return await _BaleroRepo.ObtenerTodos();
        }

        //falta el del datatable
    }
}
