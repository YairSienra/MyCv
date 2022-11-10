using Aplicacion.Comentarios;
using Aplicacion.Comentarios.ModelRequest;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentarioController : MiControllerBase
    {
        [HttpPost("NuevoComentario")]
        public async Task<ComentarioModel> EnviarComentario(EnviarComentario.Ejecuta data)
        {
            return await Mediator.Send(data);
        }
    }
}
