using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Model
{
    public class Solicitud
    {
        public int id { get; set; }
        public int PersonaId { get; set; }
        public int EstadoId { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
