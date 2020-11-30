using Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class PerfilDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public PerfilDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarPerfiles()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM perfil ; ");
        }
    }
}
