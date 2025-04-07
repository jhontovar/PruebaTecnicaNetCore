using core.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Net;
using System.Runtime.InteropServices;

namespace Productos.Controllers
{
    /// <summary>
    /// Controller Base
    /// </summary>
    [ApiController]
    public class BaseController : ControllerBase
    {
        #region Atributos y Propiedades
        protected ResponseDto response;
        protected readonly ResponseDto responseError;
        /// <summary>
        /// Usuario para registro de auditoria capturado del Token JWT
        /// </summary>
        protected string UsuarioAuditoria { get; }
        #endregion

        #region Constructor
        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            response = new ResponseDto()
            {
                Estado = true,
                Codigo = HttpStatusCode.OK.GetHashCode()
            };
            responseError = new ResponseDto()
            {
                Estado = false,
                Codigo = HttpStatusCode.InternalServerError.GetHashCode(),
            };
        }
        #endregion

        #region Métodos y Funciones
        /// <summary>
        /// Descripción: Método que permite construir el response de error.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="incluirInnerException"></param>
        protected void ConstruirResponseError(Exception ex, bool incluirInnerException = false)
        {
            var errorNegocio = typeof(ExternalException) == ex.GetType();
            if (!errorNegocio)
            {
                Serilog.Log.Error(ex, string.Format("Api - {0}", ex.Message));
            }
            responseError.Mensaje = !errorNegocio ? "Error Api " : ex.Message;
            if (incluirInnerException && ex.InnerException != null)
                responseError.Data = ex.InnerException.Message;
            response = responseError;
        }
        #endregion
    }
}
