using core.Entities;
using core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Interfaces
{
    public interface IUnitOfWork
    {
        IProductoRepository ProductoRepository { get; }
        Task<int> GuardarCambiosAsync();

    }
}
