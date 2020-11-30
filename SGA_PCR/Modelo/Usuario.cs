using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {
        private int idUsuario;
        private string dni;
        private string nombre;
        private string user;
        private string password;
        private int idPerfil;
        private string email;
        private int estado;

        public Usuario()
        {

        }

        public Usuario(int idUsuario, string dni, string nombre, string user, string password, int idPerfil, string email, int estado)
        {
            this.IdUsuario = idUsuario;
            this.Dni = dni;
            this.Nombre = nombre;
            this.User = user;
            this.Password = password;
            this.IdPerfil = idPerfil;
            this.Email = email;
            this.Estado = estado;
        }

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public int IdPerfil { get => idPerfil; set => idPerfil = value; }
        public string Email { get => email; set => email = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
