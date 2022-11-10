using Aplicacion.Contratos;
using Dominio.Usuarios;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Seguridad.Seguridad
{
    public class JwtGenerador : IJwtGenerador
    {
        public string GenerarToken(User user, List<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim (JwtRegisteredClaimNames.NameId, user.UserName)
            };

            if (roles != null)
            {
                foreach (var rol in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mi palabra secreta"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = credentials,

            };

            var tokenManejador = new JwtSecurityTokenHandler();
            var token = tokenManejador.CreateToken(tokenDescription);

            return tokenManejador.WriteToken(token);
        }
    }
}
