using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Area
    {
        private int idArea;
        private string descripcionArea;

        public Area()
        { 

        }

        public Area(int idArea, string descripcionArea)
        {
            this.idArea = idArea;
            this.descripcionArea = descripcionArea;
        }

        public int IdArea { get => idArea; set => idArea = value; }
        public string DescripcionArea { get => descripcionArea; set => descripcionArea = value; }
    }
}
