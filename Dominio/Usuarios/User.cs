
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Usuarios
{
    public class User : IdentityUser
    {
      public string? NombreCompleto {get; set;}   
      public string? Email { get; set; } 
      public string? Password { get; set; }
      public byte[]? imagen { get; set; }
    }
}
