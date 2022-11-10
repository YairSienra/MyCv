using Dominio.CV;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.CV
{
    public class ObtenerCabecera
    {

        public class Ejecuta : IRequest<Cabecera>
        {
            public string id { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, Cabecera>
        {
            private readonly BaseDeDatosSB _baseDeDatosSB;
            public Manejador(BaseDeDatosSB baseDeDatosSB)
            {
                _baseDeDatosSB = baseDeDatosSB;
            }

            public async Task<Cabecera> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var CvUser = await _baseDeDatosSB.Cabeceras.FindAsync(request.id);
                var ExpLaborals = _baseDeDatosSB.Exps.Where(x => x.IdCvUsuario == CvUser.IdCvUsuario);
                var skills = _baseDeDatosSB.Habilidades.ToList();
                var estudios = _baseDeDatosSB.Estudio.ToList();
                var idiomas = _baseDeDatosSB.Idioma.ToList();




                foreach (var s in skills)
                {
                    var image = DecodeBase64(s.ImageSkills);
                    var wCodeing = Convert.FromBase64String(s.ImageSkills);
                    s.imageByte = wCodeing;
                    _baseDeDatosSB.SaveChanges();
                }


                return new Cabecera()
                {
                    IdCvUsuario = CvUser.IdCvUsuario,
                    NombreCompleto = CvUser.NombreCompleto,
                    Subtitulo = CvUser.Subtitulo,
                    SobreMi = CvUser.SobreMi,
                    imagen = CvUser.imagen,
                    ExpLaborales = ExpLaborals.ToList(),
                    skills = skills.OrderBy(x => x.NameSkill),
                    Estudios = estudios,
                    Idiomas = idiomas,

                };
            }

            public static string DecodeBase64(string Code)
            {

                if (string.IsNullOrEmpty(Code))
                    return string.Empty;
                var valueBytes = Convert.FromBase64String(Code);
                return Encoding.UTF8.GetString(valueBytes);
            }
    
          
        }

       
    }
}
