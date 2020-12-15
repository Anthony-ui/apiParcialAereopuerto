using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_aereopuerto.Modelos
{
    public class Tripulacion
    {
        public int TripulacionId { get; set; }
        public int MiembroId { get; set; }
        public Miembro Miembros { get; set; }
        public int VueloId { get; set; }
        public Vuelo Vuelos { get; set; }
    }
}
