using Aplicacion.Usuarios.ModelRequest;
using Dominio.Usuarios;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Usuarios
{
    public class CrearUsuario
    {


        public class Ejecuta : IRequest<UserData>
        {
            public string? NombreCompleto { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }

        }

        public class Manejador : IRequestHandler<Ejecuta, UserData>
        {
            private readonly BaseDeDatosSB _context;
            private readonly UserManager<User> _userManager;

            public Manejador(BaseDeDatosSB context, UserManager<User> userManager)
            {
                _context = context;
                _userManager = userManager;
            }
            public async Task<UserData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
       
               
                var email = await _context.Users.Where<User>(x => x.Email == request.Email).AnyAsync();
                if(email)
                {
                    throw new Exception("Este Email se encuentra en uso");
                } 


                var NewUser = new User()
                {   

                    Id = Guid.NewGuid().ToString(),
                    NombreCompleto = request.NombreCompleto,
                    Email = request.Email,
                    UserName = request.Email
             

                };

                var userNew =  await _userManager.CreateAsync(NewUser, request.Password);
             
                if (userNew.Succeeded)
                {
                    
                    return new UserData
                    {
                        IdUser = NewUser.Id,
                        NombreCompleto = NewUser.NombreCompleto,
                        password = NewUser.PasswordHash,
                        Email = NewUser.Email,
                       
                    };
                  
                } else
                {
                    throw new Exception("No se pudo Guardar");
                }
            }
        }
    } 
}
