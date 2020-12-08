using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace therexmecanic.Models
{
    public class Reportes
    {
        public Cliente Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public string Reparacion { get; set; }
        public Mecanico Nombre { get; set; }
    }
}
