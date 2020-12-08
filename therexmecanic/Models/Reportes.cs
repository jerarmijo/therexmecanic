using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace therexmecanic.Models
{
    public class Reportes
    {
        public int IdReportes { get; set; }
        public Cliente CodCliente { get; set; }
        public Vehiculo Patente { get; set; }
        public string Reparacion { get; set; }
        public Mecanico IdMecanico { get; set; }
    }
}
