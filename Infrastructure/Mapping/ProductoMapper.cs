using core.dto;
using core.Entities;

namespace Infrastructure.Mapping
{
    public static class ProductoMapper
    {
        public static Producto ToEntity(ProductoDto dto) => new Producto
        {
            Id = dto.Id,
            Descripcion = dto.Descripcion,
            Nombre = dto.Nombre,
            Precio = dto.Precio,
            Stock = dto.Stock

        };

        public static ProductoDto ToDto(Producto user) => new ProductoDto
        {
            Id = user.Id,
            Descripcion = user.Descripcion,
            Nombre = user.Nombre,
            Precio = user.Precio,
            Stock = user.Stock
        };
    }
}
