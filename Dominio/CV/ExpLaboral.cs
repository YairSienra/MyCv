using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.CV
{
    public class ExpLaboral
    {
        public string? IdExpLaboral { get; set; }
        public string? NombreEmpresa { get; set; }
        public string? Puesto { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaEgreso { get; set; }
        public string? texto { get; set; }
        public string? IdCvUsuario { get; set; } 
        
    }
}
