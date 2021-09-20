using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityArea : EntityBase
    {
        public int IdArea { get; set; }
        public string Descripcion { get; set; }
        public int IdIprArea { get; set; }
        public char Estado { get; set; }
    }
}
