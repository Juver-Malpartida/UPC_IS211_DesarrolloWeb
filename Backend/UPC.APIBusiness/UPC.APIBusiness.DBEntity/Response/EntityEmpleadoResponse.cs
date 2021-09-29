using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityEmpleadoResponse : EntityEmpleado
    {
        public string DescCargo { get; set; }
        public string DescArea { get; set; }
        public int IdContrato { get; set; }
        public DateTime FechaInicioCont { get; set; }
        public DateTime FechaFinCont { get; set; }
    }
}
