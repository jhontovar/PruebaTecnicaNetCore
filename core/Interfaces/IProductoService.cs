using core.dto;

namespace core.Interfaces
{
    public interface IProductoService
    {
        Task<List<ProductoDto>> ObtenerTodos();
        Task<ProductoDto> ObtenerPorId(int id);
        Task<ProductoDto> Crear(ProductoDto producto);
        Task<ProductoDto> Actualizar(ProductoDto producto);
        Task<bool> Eliminar(int id);
    }
}
