using Aplicacion.Contratos;
using Aplicacion.Usuarios.ModelRequest;
using Dominio.Usuarios;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistencia;


namespace Seguridad
{
    public class Login
    {
        public class Ejecuta : IRequest<UserData>
        {
            public string? Email { get; set; }
            public string? Password { get; set; } 
        }

        public class Manejador : IRequestHandler<Ejecuta, UserData>
        {
            private readonly BaseDeDatosSB _baseDeDatosSB;
            private readonly UserManager<User> _userManager;
            private readonly IJwtGenerador _jwtGenerador;
            private readonly SignInManager<User> _signInManager;
            public Manejador (BaseDeDatosSB baseDeDatos, UserManager<User> userManager, IJwtGenerador jwtGenerador, SignInManager<User> signInManager)
            {
                _baseDeDatosSB = baseDeDatos;
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
                _signInManager = signInManager;
            }

            public async Task<UserData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {   
                var UserData = new UserData();

                var Email = await _userManager.FindByNameAsync(request.Email);
               

                if (Email == null)
                {
                    return null;
                } 

                if(Email != null)
                {
                    var Logueo = await _signInManager.CheckPasswordSignInAsync(Email, request.Password, false);

                    if (Logueo == SignInResult.Failed)
                    {
                        return null;
                    }

                    var ListRoles = await _userManager.GetRolesAsync(Email);
                    var RolesEncontrados = new List<string>(ListRoles);

                    if (Logueo.Succeeded)
                    {
                        return new UserData
                        {
                            NombreCompleto = Email.NombreCompleto,
                            Email = Email.Email,
                            imagen = Email.imagen,
                            password = Email.PasswordHash,
                            Token = _jwtGenerador.GenerarToken(Email, RolesEncontrados)

                        };
                        
                    } else
                    {
                        throw new Exception("No log");
                    }
                    return UserData;
                }

                throw new Exception("Ocurrio un error");
                
            }   
        }       
    }
}
