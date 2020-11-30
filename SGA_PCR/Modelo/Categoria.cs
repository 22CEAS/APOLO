using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Categoria
    {
        private int idCategoria;
        private string nombreCategoria;
        private string subCategoria;
        private BindingList<Marca> marcas;
        private int estado;

        public Categoria()
        {
            this.Marcas = new BindingList<Marca>();
        }
        public Categoria(int idCategoria, string nombreCategoria, string subCategoria, BindingList<Marca> marcas, int estado)
        {
            this.IdCategoria = idCategoria;
            this.NombreCategoria = nombreCategoria;
            this.SubCategoria = subCategoria;
            this.Marcas = marcas;
            this.Estado = estado;
        }

        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }
        public string SubCategoria { get => subCategoria; set => subCategoria = value; }
        public BindingList<Marca> Marcas { get => marcas; set => marcas = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
