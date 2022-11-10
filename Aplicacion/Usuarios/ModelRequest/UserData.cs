using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Usuarios.ModelRequest
{
    public class UserData
    {   
        public string? IdUser { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Email { get; set; }
        public string? password { get; set; }
        public byte[]? imagen { get; set; }
        public string? Token { get; set; }
    }
}
