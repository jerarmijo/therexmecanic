using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace therexmecanic.Models
{
    public class Vehiculo
    {
        public Cliente cliente { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anno { get; set; }
        public string Color { get; set; }

    }
}
