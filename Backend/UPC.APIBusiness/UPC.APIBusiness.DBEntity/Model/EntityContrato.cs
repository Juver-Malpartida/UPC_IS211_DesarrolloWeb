using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityContrato : EntityBase
    {
        public int IdContrato { get; set; }
        public string NumeroContrato { get; set; }
        public DateTime FechaInicioCont { get; set; }
        public DateTime FechaFinCont { get; set; }
        public DateTime FechaRegistroCont { get; set; }
        public Decimal SueldoActual { get; set; }
        public string MonedaPago { get; set; }
        public int IdEmpleado { get; set; }
        public char Estado { get; set; }
    }
}
