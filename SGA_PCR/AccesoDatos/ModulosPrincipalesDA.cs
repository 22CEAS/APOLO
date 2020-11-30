using Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ModulosPrincipalesDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public ModulosPrincipalesDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarModulosPrincipales()
        {
            return objManager.MostrarTablaDatos("Select * from vista_modulos_principales;");
        }
    }
}
