using Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public interface IBaleroService
    {
        Task<bool> Insertar(Balero model);
        Task<bool> Actualizar(Balero model);
        Task<bool> Eliminar(int id);
        Task<Balero> Obtener(int id);
        Task<IQueryable<Balero>> ObtenerTodos();

            //falta el task para el datatable

    }
}
