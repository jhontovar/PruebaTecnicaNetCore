using core.dto;
using core.Entities;
using core.Interfaces;
using core.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Productos.Controllers
{
    /// <summary>
    /// Controlador para productos
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : BaseController
    {
        private readonly IProductoService _service;

        public ProductoController(IProductoService repository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _service = repository;
        }

        /// <summary>
        /// Obtnener productos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                response.Data = await _service.ObtenerTodos();
                response.Mensaje = "Consulta generada correctamente.";
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }

            return response;
        }

        /// <summary>
        /// Obtener por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ResponseDto> GetById(int id)
        {

            try
            {
                var list = await _service.ObtenerPorId(id);
                response.Data = list;
                response.Mensaje = "Consulta generada correctamente.";
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }

            return response;
        }

       /// <summary>
       /// Guardar producto
       /// </summary>
       /// <param name="producto"></param>
       /// <returns></returns>
        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] Producto producto)
        {

            try
            {
                var creado = await _service.Crear(producto);
                response.Data = creado;
                response.Mensaje = "Guardado correctamente.";
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }

            return response;
        }

        /// <summary>
        /// Actualizar producto
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ResponseDto> Put([FromBody] Producto producto)
        {
            try
            {
                var actualizado = await _service.Actualizar(producto);

                response.Data = actualizado;
                response.Mensaje = "Modificado correctamente.";
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }

            return response;

        }

        /// <summary>
        /// Eliminar producto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                var eliminado = await _service.Eliminar(id);

                response.Data = eliminado;
                response.Mensaje = "Eliminado correctamente.";
            }
            catch (Exception ex)
            {
                ConstruirResponseError(ex);
            }

            return response;
        }
    }
}
