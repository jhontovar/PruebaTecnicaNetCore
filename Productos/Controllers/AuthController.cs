using core.Entities;
using core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Productos.Controllers
{
    /// <summary>
    /// Controlador para autenticacion
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _authService = authService;
        }

        /// <summary>
        /// Login de usuario para generar token: FAKE
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            var token = _authService.GenerarToken(usuario);
            return Ok(new { token });
        }
    }
}
