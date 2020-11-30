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
    public class EstadosDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public EstadosDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarEstados()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM estados where idEstado in (0,1); ");
        }
    }
}
