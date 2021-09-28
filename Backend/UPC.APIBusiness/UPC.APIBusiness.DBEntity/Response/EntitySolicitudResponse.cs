using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntitySolicitudResponse
    {
        public string NumeroContrato { get; set; }
        public string EstadoSolicitud { get; set; }
        public string NombresEmpleado { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int IdSolCese { get; set; }
        public DateTime FechaCese { get; set; }
    }
}
