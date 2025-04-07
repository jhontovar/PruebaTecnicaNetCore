using core.Interfaces.Repository;
using core.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IProductoRepository _productoRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProductoRepository ProductoRepository =>
            _productoRepository ??= new ProductoRepository(_context);

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
