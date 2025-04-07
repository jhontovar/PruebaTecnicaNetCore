using core.Entities;
using core.Interfaces.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Repositories.ProductoRepository;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio de producto
    /// </summary>
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtener los productos
        /// </summary>
        /// <returns></returns>
        public async Task<List<Producto>> ObtenerTodos() =>
            await _context.Productos.ToListAsync();

        /// <summary>
        /// Obtener por id productos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Producto?> ObtenerPorId(int id) =>
            await _context.Productos.FindAsync(id);

        /// <summary>
        /// Crear producto
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public async Task<Producto> Crear(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        /// <summary>
        /// Actualizar producto
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public async Task<Producto?> Actualizar(Producto producto)
        {
            var existente = await _context.Productos.FindAsync(producto.Id);
            if (existente == null) return null;

            existente.Nombre = producto.Nombre;
            existente.Descripcion = producto.Descripcion;
            existente.Precio = producto.Precio;
            existente.Stock = producto.Stock;

            await _context.SaveChangesAsync();
            return existente;
        }

        /// <summary>
        /// Eliminar producto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Eliminar(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
