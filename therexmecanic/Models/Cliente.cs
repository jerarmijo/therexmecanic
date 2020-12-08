using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace therexmecanic.Models
{
    public class Cliente
    {
        public int CodCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        public string Domicilio { get; set; }
        public int Telefono { get; set; }
        
    }
}
