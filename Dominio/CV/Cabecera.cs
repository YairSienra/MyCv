using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.CV
{
    public class Cabecera
    {
        public string? IdCvUsuario { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Subtitulo { get; set; }
        public string? SobreMi { get; set; } 
        public byte[]? imagen { get; set; }
        public  ICollection<Estudios>? Estudios { get; set; }
        public  IEnumerable<Skills>? skills { get; set; }
        public  ICollection<Idiomas>? Idiomas { get; set; }
        public  ICollection<ExpLaboral>? ExpLaborales { get; set; }
       
    }
}
