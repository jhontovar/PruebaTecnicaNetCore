using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.dto
{
    public class ResponseDto
    {
        public bool Estado { get; set; }

        public int Codigo { get; set; }

        public string? Mensaje { get; set; }

        public object? Data { get; set; }

    }
}
