using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_aereopuerto.Modelos
{
    public class BaseDatos : DbContext
    {
        public BaseDatos(DbContextOptions opciones) : base(opciones)
        {
        }
        public DbSet<Avion> Aviones { get; set; }
        public DbSet<Piloto> Pilotos { get; set; }
        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Base> Bases { get; set; }
        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Tripulacion> Tripulaciones { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }





    }
}
