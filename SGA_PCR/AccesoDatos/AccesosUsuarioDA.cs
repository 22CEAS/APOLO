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
    public class AccesosUsuarioDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public AccesosUsuarioDA()
        {
            objManager = new DBManager();
        }

        public string permisos(string idUsuario)
        {

            MySqlDataReader reader;
            string sql = "";
            string clave = "";

            sql = $"Select * From usuarios where idUsuario='{idUsuario}';";

            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                clave = reader.GetString("claveUsuario");
            }

            objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();

            return clave;
        }

        public List<string> Obtener_accessos(string idUsuario,int idModuloP)
        {

            List<string> lista = new List<string>();

            MySqlDataReader reader;
            string sql = "";
            string idSubmodulo = "";

            sql = $"select * from accesos_usuarios " +
                $"where 1 = 1 " +
                $"and idUsuario = '{idUsuario}' " +
                $"and idSubmodulo in (select idSubmodulo " +
                $"                    from submodulos " +
                $"                    where 1 = 1 " +
                $"                    and idModuloP = {idModuloP})";

            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                idSubmodulo = reader.GetString("idSubmodulo");
                lista.Add(idSubmodulo);
            }

            return lista;

        }



        public int GuardarPermisoNuevo(string idSubmodulo, int idUsuario)
        {
                parametrosEntrada = new MySqlParameter[2];
                
                parametrosEntrada[0] = new MySqlParameter("@_idUsuario", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idSubmodulo", MySqlDbType.VarChar, 255);
                

                parametrosEntrada[0].Value = idUsuario;
                parametrosEntrada[1].Value = idSubmodulo;



                bool x = objManager.EjecutarProcedure(parametrosEntrada,"insert_permiso");

            if (!x)
            {
                MessageBox.Show("ERROR!");
            }

                objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();

                //MessageBox.Show("PERMISO GUARDADO CORRECAMENTE");

            return 1;
        }

        public int EliminarPermiso(string idSubmodulo, int idUsuario)
        {
            parametrosEntrada = new MySqlParameter[2];

            parametrosEntrada[0] = new MySqlParameter("@_idUsuario", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_idSubmodulo", MySqlDbType.VarChar, 255);


            parametrosEntrada[0].Value = idUsuario;
            parametrosEntrada[1].Value = idSubmodulo;



            bool x = objManager.EjecutarProcedure(parametrosEntrada, "delete_permiso");

            if (!x)
            {
                MessageBox.Show("ERROR!");
            }

            objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();

            //MessageBox.Show("PERMISO ELIMINADO CORRECAMENTE");

            return 1;
        }
    }
}
