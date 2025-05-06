using AutoMapper;
using core.Interfaces;

namespace Infrastructure.Services
{
    public class MappingService : IMappingService
    {
        private readonly IMapper _autoMapper;

        public MappingService(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            return _autoMapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _autoMapper.Map<TSource, TDestination>(source);
        }
    }
}
