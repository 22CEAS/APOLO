using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuarios
    {
        private string idUsuario;
        private string claveUsuario;
        private int    idArea;
        private string nombreUsuario;
        private string apellidoUsuario;
        private string emailUsuario;

        public Usuarios()
        { 

        }

        public Usuarios(string idUsuario, string claveUsuario, int idArea, string nombreUsuario, string apellidoUsuario, string emailUsuario)
        {
            this.idUsuario = idUsuario;
            this.claveUsuario = claveUsuario;
            this.idArea = idArea;
            this.nombreUsuario = nombreUsuario;
            this.apellidoUsuario = apellidoUsuario;
            this.emailUsuario = emailUsuario;
        }

        public string IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string ClaveUsuario { get => claveUsuario; set => claveUsuario = value; }
        public int IdArea { get => idArea; set => idArea = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string ApellidoUsuario { get => apellidoUsuario; set => apellidoUsuario = value; }
        public string EmailUsuario { get => emailUsuario; set => emailUsuario = value; }
    }
}
