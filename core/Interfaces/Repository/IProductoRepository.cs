using core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Interfaces.Repository
{
    public interface IProductoRepository
    {
        Task<List<Producto>> ObtenerTodos();
        Task<Producto?> ObtenerPorId(int id);
        Task<Producto> Crear(Producto producto);
        Task<Producto?> Actualizar(Producto producto);
        Task<bool> Eliminar(int id);
    }
}
