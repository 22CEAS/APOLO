using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Estados
    {
        private int IdEstado;
        private string nombreEstado;
        private string descripcion;

        public Estados()
        {

        }

        public int IdEstado1 { get => IdEstado; set => IdEstado = value; }
        public string NombreEstado { get => nombreEstado; set => nombreEstado = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
