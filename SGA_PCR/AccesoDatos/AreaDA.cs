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
    public class AreaDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public AreaDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarAreas()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM areas; ");
        }

       

    }
}
