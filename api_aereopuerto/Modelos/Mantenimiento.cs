using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_aereopuerto.Modelos
{
    public class Mantenimiento
    {
        public int MantenimientoId { get; set; }
        public string Fecha { get; set; }
        public string Detalle { get; set; }
        public int BaseId { get; set; }
        public Base Bases { get; set; }
        public int AvionId { get; set; }
        public Avion Aviones { get; set; }
    }
}
