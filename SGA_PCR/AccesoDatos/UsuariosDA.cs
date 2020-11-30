using Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesoDatos
{
    public class UsuariosDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public UsuariosDA()
        {
            objManager = new DBManager();
        }

        

        
    }
}
