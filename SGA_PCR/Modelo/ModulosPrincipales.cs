using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModulosPrincipales
    {
        private int idModuloP;
        private string descripcionModuloP;

        public ModulosPrincipales()
        {

        }

        public ModulosPrincipales(int idModuloP, string descripcionModuloP)
        {
            this.idModuloP = idModuloP;
            this.descripcionModuloP = descripcionModuloP;
        }

        public int IdModuloP { get => idModuloP; set => idModuloP = value; }
        public string DescripcionModuloP { get => descripcionModuloP; set => descripcionModuloP = value; }
    }
}
