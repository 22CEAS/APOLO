using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace AccesoDatos
{
    public class DBManager
    {
        //string conex = "User Id=custom;password=h1808;server=" + servidor + ";database=" + basedatos + ";Convert Zero Datetime=True;persist security info=True;use procedure bodies=False;Connection Timeout=9000000 ; pooling=true; Max Pool Size=900000";

        //public static string cadena = "server=quilla.lab.inf.pucp.edu.pe; user=inf282g2; password=UInag9; database=inf282g2; SslMode=None";

        //public static string cadena = "server=localhost; user=root; password=; database=bd_leasein; SslMode=None;Connect Timeout=300000";

        //public static MySqlConnection conexion = null;

        public static string servidor = ConfigurationManager.AppSettings["ServidorMySql"].ToString();
        public static string basedatos = ConfigurationManager.AppSettings["BaseDatosMySql"].ToString();

        public static string cadena = "server=" + "209.45.53.41" + "; user=root; password=root; database=" + "bd_leasein_test" + "; SslMode=None;Connect Timeout=300000";
        //public static string cadena = "server="+ servidor + "; user=root; password=; database="+ basedatos + "; SslMode=None;Connect Timeout=300000";
        //public static string cadena = "server=" + "localhost" + "; user=root; password=root; database=" + "bd_leasein" + "; SslMode=None;Connect Timeout=300000";

        //PRUEBAS SERVIDOR 16gb
        //public static string cadena = "server=" + "154.16.171.82" + "; user=root; password=leasein1; port=16258; database=" + "leasein_16gb" + "; SslMode=None;Connect Timeout=300000";

        //public static string cadena = "server=" + "209.45.53.41" + "; user=root; password=root; database=" + "bd_leasein" + "; SslMode=None;Connect Timeout=300000";
        public MySqlConnection conexion = null;
        public MySqlCommand cmd = null;
        private MySqlDataAdapter adaptador = null;
        private DataTable tabla = null;
        private MySqlDataReader leer = null;

        public bool EjecutarProcedure(MySqlParameter[] parametrosEntrada, string nombProcedimiento)
        {
            try
            {
                conexion = new MySqlConnection(cadena);
                conexion.Open();
                cmd = new MySqlCommand(nombProcedimiento, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parametrosEntrada);
                cmd.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            finally
            {
                conexion.Dispose();
                cmd.Dispose();
            }
        }

        public void EjecutarProcedureConDatosDevueltos(MySqlParameter[] parametrosEntrada, string nombProcedimiento,
            int index, int n, out string[] datosSalida, int m)
        {
            datosSalida = null;
            if (m == 0) return; //Cantidad de datos a devolver
            try
            {
                conexion = new MySqlConnection(cadena);
                conexion.Open();
                cmd = new MySqlCommand(nombProcedimiento, conexion);
                cmd.CommandTimeout = 3000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parametrosEntrada);
                for (int i = index; i < n; i++)
                {
                    cmd.Parameters[parametrosEntrada[i].ParameterName].Direction = ParameterDirection.Output;
                }
                cmd.ExecuteNonQuery();
                conexion.Close();
                datosSalida = new string[m];
                for (int i = 0, j = index; j < n; i++, j++)
                {
                    datosSalida[i] = parametrosEntrada[j].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                conexion.Dispose();
                cmd.Dispose();
            }
        }

        public bool EjecutarProcedureDatosSalida(ref MySqlParameter[] parametros, string nombProcedimiento,
            int index)
        {
            int n = parametros.Length;
            if (index < 0) return false; //Cantidad de datos a devolver
            try
            {
                conexion = new MySqlConnection(cadena);
                conexion.Open();
                cmd = new MySqlCommand(nombProcedimiento, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parametros);
                for (int i = index; i < n; i++)
                {
                    cmd.Parameters[parametros[i].ParameterName].Direction = ParameterDirection.Output;
                }
                cmd.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            finally
            {
                conexion.Dispose();
                cmd.Dispose();
            }
        }

        public DataTable MostrarTablaDatos(string comando) //SELECT * FROM TABLA
        {
            try
            {
                conexion = new MySqlConnection(cadena);
                conexion.Open();
                tabla = new DataTable();
                adaptador = new MySqlDataAdapter(comando, conexion);
                adaptador.Fill(tabla);
                conexion.Close();
                return tabla;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                MessageBox.Show(ex.Message, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return null;
            }
            finally
            {
                conexion.Dispose();
                //adaptador.Dispose();
            }
        }

        public MySqlDataReader MostrarInformacion(string datos)
        {
            try
            {
                conexion = new MySqlConnection(cadena);
                conexion.Open();
                cmd = new MySqlCommand(datos, conexion);
                leer = cmd.ExecuteReader();
                //conexion.Close();
                return leer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return null;
            }
            finally
            {
                //conexion.Dispose();
                //cmd.Dispose();
            }
        }

        public DataTable MostrarTablaDatos(MySqlParameter[] parametrosEntrada, string nombProcedimiento)
        {
            try
            {
                conexion = new MySqlConnection(cadena);
                conexion.Open();
                cmd = new MySqlCommand(nombProcedimiento, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametrosEntrada != null)
                    cmd.Parameters.AddRange(parametrosEntrada);
                cmd.ExecuteNonQuery();
                tabla = new DataTable();
                adaptador = new MySqlDataAdapter(cmd);
                adaptador.Fill(tabla);
                conexion.Close();
                return tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return tabla;
            }
            finally
            {
                conexion.Dispose();
                cmd.Dispose();
                adaptador.Dispose();
            }
        }
        public bool EjecutarNonQuery(string sql)
        {
            try
            {
                conexion = new MySqlConnection(cadena);
                conexion.Open();
                cmd = new MySqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            finally
            {
            }
        }
    }
}
