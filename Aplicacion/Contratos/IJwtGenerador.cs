using Dominio.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Contratos
{
    public interface IJwtGenerador
    {
        public string GenerarToken(User user, List<string> roles);
    }
}
