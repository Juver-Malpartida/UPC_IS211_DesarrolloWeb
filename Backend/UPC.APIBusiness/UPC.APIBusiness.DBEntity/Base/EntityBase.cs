using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityBase
    {
        public bool Activo { get; set; }
        public string UsuarioCrea { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
