using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntitySolicitudCese : EntityBase
    {
        public int IdSolCese { get; set; }
        public int IdContrato { get; set; }
        public string MotivoCese { get; set; }
        public char Estado { get; set; }
        public DateTime FechaCese { get; set; }
    }
}
