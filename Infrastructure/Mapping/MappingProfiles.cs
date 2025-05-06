using AutoMapper;
using core.dto;
using core.Entities;

namespace Infrastructure.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductoDto, Producto>();
            CreateMap<Producto, ProductoDto>();
        }
    }
}
