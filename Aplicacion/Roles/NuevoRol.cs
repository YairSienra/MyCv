using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Roles.NuevoRol
{
    public class NuevoRol
    {
        public class Ejecuta : IRequest<IdentityRole>
        {
            public string Nombre { get; set; }

        }

        public class Manejador : IRequestHandler<Ejecuta, IdentityRole>
        {
            private readonly RoleManager<IdentityRole> _rolManager;

            public Manejador(RoleManager<IdentityRole> roleManager)
            {
                _rolManager = roleManager;
            }

            public async Task<IdentityRole> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var ExisteRol = await _rolManager.FindByNameAsync(request.Nombre);

                if (ExisteRol != null)
                {
                    throw new Exception("Ya existe este rol");
                }else
                {
                 var crear = await _rolManager.CreateAsync(new IdentityRole(request.Nombre));
                 var rolGuardado = await _rolManager.FindByNameAsync(request.Nombre);
                    if (crear.Succeeded)
                    {
                        return new IdentityRole
                        {
                            Name = rolGuardado.Name,
                            NormalizedName = rolGuardado.NormalizedName,
                        };
                    }
                }
                
                throw new Exception("Rol Creado con Exito");

            }
        }
    }
}