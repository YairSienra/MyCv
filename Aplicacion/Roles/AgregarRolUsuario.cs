using Dominio.Usuarios;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Roles
{
    public class AgregarRolUsuario
    {
        public class Ejecuta : IRequest 
        {
            public string UserName { get; set; }
            public string RolNombre { get; set; }

        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public Manejador(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var rol = await _roleManager.FindByNameAsync(request.RolNombre);
                if(rol == null)
                {
                    throw new Exception("Este rol no existe");
                }

                var user = await _userManager.FindByNameAsync(request.UserName);
                if(user == null)
                {
                    throw new Exception("Este usuario no existe");
                }

                var agregarRol = await _userManager.AddToRoleAsync(user, request.RolNombre);


                if (agregarRol.Succeeded)
                {
                    return Unit.Value;

                } else
                {
                  throw new Exception("No se pudo agregar este rol a ese usuario");
                }
                
            }
        }
    }
}
