using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public string Rol { get; set; } = "User"; // "Admin" o "User"
    }
}
