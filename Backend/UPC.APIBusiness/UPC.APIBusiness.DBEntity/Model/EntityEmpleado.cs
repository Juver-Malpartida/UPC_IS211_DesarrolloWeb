using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityEmpleado : EntityBase
    {
        public int IdEmpleado { get; set; }
        public string Foto { get; set; }
        public string NombreEmpleado { get; set; }
        public int IdCargo { get; set; }
        public int IdArea { get; set; }
        public char Estado { get; set; }
    }
}
