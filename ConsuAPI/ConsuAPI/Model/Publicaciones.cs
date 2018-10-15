using System;
using System.Collections.Generic;
using System.Text;

namespace ConsuAPI.Model
{
    class Publicaciones
    {
        public string Usuario { get; set; }

        public string Descripcion { get; set; }

        public string FechaPublicacion { get; set; }

        public int Cantidad { get; set; }

        public int MeGusta { get; set; }

        public int MeDisgusta { get; set; }

        public int VecesCompartido { get; set; }

        public int EsPrivada { get; set; }
    }
}
