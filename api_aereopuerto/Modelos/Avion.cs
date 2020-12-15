using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_aereopuerto.Modelos
{
    public class Avion
    {
        public int AvionId { get; set; }
        public string Codigo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Capacidad { get; set; }
    }
}
