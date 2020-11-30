using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Perfil
    {

        private int idPerfil;
        private string descripcion;
        private int estado;


        public Perfil()
        {
        }


        public int IdPerfil { get => idPerfil; set => idPerfil = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
