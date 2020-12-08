using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace therexmecanic.Models
{
    public class Reparacion
    {
        public int IdReparacion { get; set; }
        public int Fecha_Ingreso { get; set; }
        public int Hora_Ingreso { get; set; }
        public string Motivo_Ingreso { get; set; }
        public Vehiculo Patente { get; set; }
        public int Hora_Salida { get; set; }
        public int Fecha_Salida { get; set; }
    }
}
