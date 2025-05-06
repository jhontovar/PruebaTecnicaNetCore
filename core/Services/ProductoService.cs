using core.dto;
using core.Entities;
using core.Interfaces;


namespace core.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMappingService _mapper;

        public ProductoService(IUnitOfWork unitOfWork, IMappingService mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductoDto>> ObtenerTodos()
        {
            var response = await _unitOfWork.ProductoRepository.ObtenerTodos();
            return _mapper.Map<List<ProductoDto>>(response);

        }

        public async Task<ProductoDto> ObtenerPorId(int id)
        {
            var response = await _unitOfWork.ProductoRepository.ObtenerPorId(id);
            return _mapper.Map<ProductoDto>(response);
        }

        public async Task<ProductoDto> Crear(ProductoDto producto)
        {
            var _producto = _mapper.Map<Producto>(producto); // Usa tu interfaz personalizada
            await _unitOfWork.ProductoRepository.Crear(_producto);
            await _unitOfWork.GuardarCambiosAsync();
            return _mapper.Map<ProductoDto>(_producto);
        }

        public async Task<ProductoDto?> Actualizar(ProductoDto producto)
        {
            var _producto = _mapper.Map<Producto>(producto); // Usa tu interfaz personalizada
            var actualizado = await _unitOfWork.ProductoRepository.Actualizar(_producto);
            if (actualizado != null)
                await _unitOfWork.GuardarCambiosAsync();

            return _mapper.Map<ProductoDto>(actualizado);

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
