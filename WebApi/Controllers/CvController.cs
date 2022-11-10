using Aplicacion.CV;
using Dominio.CV;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CvController : MiControllerBase
    {
        [HttpGet("{IdCvUsuario}")]
        public async Task<ActionResult<Cabecera>> CargarCabecera(string IdCvUsuario)
        {

            return await Mediator.Send(new ObtenerCabecera.Ejecuta{id = IdCvUsuario});
        }
    }
}
