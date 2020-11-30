using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Modelo
    {
        private int idModelo;
        private string nombreModelo;
        private int idMarca;
        private string nombreMarca;
        private int estado;

        public Modelo()
        {
            this.Estado = 1;
        }

        public Modelo(int idModelo, string nombreModelo, int idMarca, string nombreMarca, int estado)
        {
            this.IdModelo = idModelo;
            this.NombreModelo = nombreModelo;
            this.IdMarca = idMarca;
            this.NombreMarca = nombreMarca;
            this.Estado = estado;
        }

        public int IdModelo { get => idModelo; set => idModelo = value; }
        public string NombreModelo { get => nombreModelo; set => nombreModelo = value; }
        public int IdMarca { get => idMarca; set => idMarca = value; }
        public string NombreMarca { get => nombreMarca; set => nombreMarca = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
