using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_aereopuerto.Modelos
{
    public class Piloto
    {
        public int PilotoId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public double HorasVuelo { get; set; }

    }
}
