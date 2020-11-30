using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class ProcesadorDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public ProcesadorDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarProcesadores()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_maestro_procesador ;");
        }
        public DataTable ListarTipoProcesadores()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_procesador_modelo ;");
        }
        //public DataTable ListarTipoProcesadores(int IdMarca)
        //{
        //    return objManager.MostrarTablaDatos("SELECT * FROM vista_procesador_modelo where idMarca=" + IdMarca + " ;");
        //}
        public DataTable ListarMarcaProcesadores()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_procesador_marca ;");
        }
        public DataTable ListarProcesadorGeneracion()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_procesador_generacion ;");
        }
        public DataTable ListarProcesadorVelocidad()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_procesador_velocidad ;");
        }
        public DataTable ListarProcesadorVelocidadMax()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_procesador_velocidad_maxima ;");
        }

        public int GuardarNuevoProcesador(Procesador procesador, string usuario)
        {
            //string sql = "Select * From procesador where idModelo=" + procesador.Modelo.IdModelo + " and idGeneracion=" + procesador.IdGeneracion + " and idVelocidad=" + procesador.IdVelocidad + " and idVelocidadMax=" + procesador.IdVelocidadMax + " ;";
            string sql = "Select * From procesador where idModelo=" + procesador.Modelo.IdModelo + " and idGeneracion=" + procesador.IdGeneracion + " ;";
            MySqlDataReader reader;
            reader = objManager.MostrarInformacion(sql);

            if (!(reader.HasRows))
            {
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();

                parametrosEntrada = new MySqlParameter[10];
                parametrosEntrada[0] = new MySqlParameter("@_idModelo", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idGeneracion", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_generacion", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_idVelocidad", MySqlDbType.Int32);
                parametrosEntrada[4] = new MySqlParameter("@_velocidad", MySqlDbType.VarChar, 20);
                parametrosEntrada[5] = new MySqlParameter("@_idVelocidadMax", MySqlDbType.Int32);
                parametrosEntrada[6] = new MySqlParameter("@_velocidadMax", MySqlDbType.Double);
                parametrosEntrada[7] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 255);
                parametrosEntrada[8] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 255);
                parametrosEntrada[9] = new MySqlParameter("@_idProcesador", MySqlDbType.Int32);

                parametrosEntrada[0].Value = procesador.Modelo.IdModelo;
                parametrosEntrada[1].Value = procesador.IdGeneracion;
                parametrosEntrada[2].Value = procesador.Generacion;
                parametrosEntrada[3].Value = 1;
                parametrosEntrada[4].Value = 1;
                parametrosEntrada[5].Value = 1;
                parametrosEntrada[6].Value = 1;
                parametrosEntrada[7].Value = procesador.Observacion;
                parametrosEntrada[8].Value = usuario;

                string[] datosSalida = new string[1];

                objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_procesador",
                    9, 10, out datosSalida, 1);

                if (datosSalida != null)
                {
                    int idProcesador = Convert.ToInt32(datosSalida[0]);
                    return idProcesador;
                }
                return -1;
            }
            else
            {
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();
                return 0;
            }
        }

        public int ModificarProcesador(Procesador procesador, string usuario, int actualizarEstado)
        {
            string sql = "";
            //if (actualizarEstado == 1)
            //    sql = "Select * From procesador where idModelo=" + procesador.Modelo.IdModelo + " and idGeneracion=" + procesador.IdGeneracion + " and idVelocidad=" + procesador.IdVelocidad + " and idVelocidadMax= " + procesador.IdVelocidadMax  + " and estado=" + procesador.Estado + " ;";
            //else
            //    sql = "Select * From procesador where idModelo=" + procesador.Modelo.IdModelo + " and idGeneracion=" + procesador.IdGeneracion + " and idVelocidad=" + procesador.IdVelocidad + " and idVelocidadMax=" + procesador.IdVelocidadMax + " ;";
            if (actualizarEstado == 1)
                sql = "Select * From procesador where idModelo=" + procesador.Modelo.IdModelo + " and idGeneracion=" + procesador.IdGeneracion + " and estado=" + procesador.Estado + " ;";
            else
                sql = "Select * From procesador where idModelo=" + procesador.Modelo.IdModelo + " and idGeneracion=" + procesador.IdGeneracion + " ;";

            MySqlDataReader reader;
            reader = objManager.MostrarInformacion(sql);

            if (!(reader.HasRows))
            {
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();

                parametrosEntrada = new MySqlParameter[10];
                parametrosEntrada[0] = new MySqlParameter("@_idModelo", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idGeneracion", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_generacion", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_idVelocidad", MySqlDbType.Int32);
                parametrosEntrada[4] = new MySqlParameter("@_velocidad", MySqlDbType.VarChar, 20);
                parametrosEntrada[5] = new MySqlParameter("@_idVelocidadMax", MySqlDbType.Int32);
                parametrosEntrada[6] = new MySqlParameter("@_velocidadMax", MySqlDbType.Double);
                parametrosEntrada[7] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[8] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 255);
                parametrosEntrada[9] = new MySqlParameter("@_idProcesador", MySqlDbType.Int32);

                parametrosEntrada[0].Value = procesador.Modelo.IdModelo;
                parametrosEntrada[1].Value = procesador.IdGeneracion;
                parametrosEntrada[2].Value = procesador.Generacion;
                parametrosEntrada[3].Value = 1;
                parametrosEntrada[4].Value = 1;
                parametrosEntrada[5].Value = 1;
                parametrosEntrada[6].Value = 1;
                parametrosEntrada[7].Value = procesador.Estado;
                parametrosEntrada[8].Value = usuario;
                parametrosEntrada[9].Value = procesador.IdProcesador;

                bool aux = objManager.EjecutarProcedure(parametrosEntrada, "update_procesador");
                return ((aux) ? 1 : -1);
            }
            else
            {
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();
                return 0;
            }
        }

    }
}
