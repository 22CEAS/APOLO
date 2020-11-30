using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Marca
    {
        private int idMarca;
        private string nombreMarca;
        private int idCategoria;
        private BindingList<Modelo> modelos;
        private int estado;

        public Marca()
        {
            this.Estado = 1;
            this.Modelos= new BindingList<Modelo>();
        }
        public Marca(int idMarca, string nombreMarca, int idCategoria, BindingList<Modelo> modelos, int estado)
        {
            this.IdMarca = idMarca;
            this.NombreMarca = nombreMarca;
            this.IdCategoria = idCategoria;
            this.Modelos = modelos;
            this.Estado = estado;
        }

        public int IdMarca { get => idMarca; set => idMarca = value; }
        public string NombreMarca { get => nombreMarca; set => nombreMarca = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public BindingList<Modelo> Modelos { get => modelos; set => modelos = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
