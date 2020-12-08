using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace therexmecanic.Models
{
    public class Mecanico
    {
        public int IdMecanico { get; set; }
        public Gerencia IdGerencia { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Observaciones { get; set; }
    }
}
