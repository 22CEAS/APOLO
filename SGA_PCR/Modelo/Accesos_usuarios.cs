using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Accesos_usuarios
    {
        private int idAccesos;
        private string idUsuario;
        private string idSubmodulo;

        public Accesos_usuarios()
        {

        }

        public Accesos_usuarios(int idAccesos, string idUsuario, string idSubmodulo)
        {
            this.idAccesos = idAccesos;
            this.idUsuario = idUsuario;
            this.idSubmodulo = idSubmodulo;
        }

        public int IdAccesos { get => idAccesos; set => idAccesos = value; }
        public string IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string IdSubmodulo { get => idSubmodulo; set => idSubmodulo = value; }
    }

    


}
