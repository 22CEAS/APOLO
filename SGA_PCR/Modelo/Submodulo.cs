using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Submodulo
    {
        private string idSubmodulo;
        private string descripcionSubmodulo;
        private int idModuloP;

        public Submodulo()
        {

        }

        public Submodulo(string idSubmodulo, string descripcionSubmodulo, int idModuloP)
        {
            this.idSubmodulo = idSubmodulo;
            this.descripcionSubmodulo = descripcionSubmodulo;
            this.idModuloP = idModuloP;
        }

        public string IdSubmodulo { get => idSubmodulo; set => idSubmodulo = value; }
        public string DescripcionSubmodulo { get => descripcionSubmodulo; set => descripcionSubmodulo = value; }
        public int IdModuloP { get => idModuloP; set => idModuloP = value; }
    }
}
