using core.Entities;
using core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Services
{
    public class ProductoService: IProductoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Producto>> ObtenerTodos()
        {
            return await _unitOfWork.ProductoRepository.ObtenerTodos();
        }
        
        public async Task<Producto> ObtenerPorId(int id)
        {
            return await _unitOfWork.ProductoRepository.ObtenerPorId(id);
        }

        public async Task<Producto> Crear(Producto producto)
        {
            await _unitOfWork.ProductoRepository.Crear(producto);
            await _unitOfWork.GuardarCambiosAsync();
            return producto;
        }

        public async Task<Producto?> Actualizar(Producto producto)
        {
            var actualizado = await _unitOfWork.ProductoRepository.Actualizar(producto);
            if (actualizado != null)
                await _unitOfWork.GuardarCambiosAsync();

            return actualizado;
        }

        public async Task<bool> Eliminar(int id)
        {
            var eliminado = await _unitOfWork.ProductoRepository.Eliminar(id);
            if (eliminado)
                await _unitOfWork.GuardarCambiosAsync();

            return eliminado;
        }
    }
}
