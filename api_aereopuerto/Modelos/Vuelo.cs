using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_aereopuerto.Modelos
{
    public class Vuelo
    {
        public int VueloId { get; set; }
        public string Codigo { get; set; }
        public string fechaSalida  { get; set; }
        public string fechaLlegada { get; set; }
        public string ciudadOrigen { get; set; }
        public string ciudadDestino { get; set; }
        public int PilotoId { get; set; }
        public Piloto Pilotos { get; set; }
        public int AvionId { get; set; }
        public Avion Aviones { get; set; }


    }
}
