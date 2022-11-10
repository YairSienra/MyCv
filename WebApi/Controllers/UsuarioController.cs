using Aplicacion.Roles;
using Aplicacion.Roles.NuevoRol;
using Aplicacion.Usuarios;
using Aplicacion.Usuarios.ModelRequest;
using Dominio.Usuarios;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Seguridad;

namespace WebApi.Controllers
{
     public class UsuarioController : MiControllerBase
     {
        [HttpPost("login")]
        public async Task<ActionResult<UserData>> Loguearse(Login.Ejecuta Data)
        {
            return await Mediator.Send(Data);
        }
        [HttpPost("registro")]
        public async Task<ActionResult<UserData>> registrar([FromBody] CrearUsuario.Ejecuta body)
        {
            return await Mediator.Send(body);
        }

        [HttpPost("nuevoRol")]
        public async Task<ActionResult<IdentityRole>> NuevoRol(NuevoRol.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [Authorize(Roles = "Fundador")]
        [HttpPost("agregarRol")]
        public async Task<ActionResult<Unit>> AgregarRol(AgregarRolUsuario.Ejecuta data)
        {
            return await Mediator.Send(data);
        }
    }
}
