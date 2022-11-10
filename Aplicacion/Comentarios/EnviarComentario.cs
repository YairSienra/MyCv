
using MediatR;
using Dominio.Comentarios;
using Persistencia;
using Aplicacion.Comentarios.ModelRequest;
using FluentValidation;


namespace Aplicacion.Comentarios
{
    public class EnviarComentario
    {
        public class Ejecuta: IRequest<ComentarioModel>
        {
            public string? NombreCompleto { get; set; }
            public string? Email { get; set; }
            public string? Texto { get; set; }
        }
        public class Validation : AbstractValidator<Ejecuta>
        {
            public Validation()
            {
                RuleFor(x => x.Email).NotEmpty().WithMessage("Debe incluir un Email para la comunicaion");
                RuleFor(x => x.NombreCompleto).NotEmpty().WithMessage("Es importante presentarse");
                RuleFor(x => x.Texto).NotEmpty().WithMessage("Debe escribir su comentario si es que piensa escribir algo");
            }
        }
        public class Manejador : IRequestHandler<Ejecuta, ComentarioModel>
        {  
            private readonly BaseDeDatosSB _baseDeDatos;

            public Manejador (BaseDeDatosSB baseDeDatosSB)
            {
                    _baseDeDatos = baseDeDatosSB;
            }
            public async Task<ComentarioModel> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                    

                var newComment = new Comentario()
                {
                    IdComentario = Guid.NewGuid().ToString(),
                    NombreCompleto = request.NombreCompleto,
                    Email = request.Email,
                    Texto = request.Texto,
                };

                    var agregar = await _baseDeDatos.Comentario.AddAsync(newComment);
                  
                    if(agregar != null)
                    {
                        var guardar = _baseDeDatos.SaveChangesAsync();

                        if (guardar != null)
                        {
                            EnviarEmail email = new  EnviarEmail();

                           email.SendEmail(newComment.Email, newComment.NombreCompleto , newComment.Texto);
                        }
                    }


                return new ComentarioModel()
                {
                    NombreCompleto = newComment.NombreCompleto,
                    Email = newComment.Email,
                    Texto = newComment.Texto,

                };

                
            }
        }
    }
}
