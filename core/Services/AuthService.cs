using core.Entities;
using core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace core.Services
{
    /// <summary>
    /// Clase para generar token
    /// </summary>
    public class AuthService : IAuthService
    {

        private readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {

            _config = config;
        }
    
        /// <summary>
        /// generar token de usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public string GenerarToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                new Claim(ClaimTypes.Role, usuario.Rol)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
