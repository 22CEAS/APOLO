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
    public class VideoDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public VideoDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarVideos()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_maestro_video ;");
        }
        public DataTable ListarTipoVideo()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_video_tipo ;");
        }
        public DataTable ListarCapacidadVideo()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_video_capacidad ;");
        }
        public DataTable ListarMarcaVideo()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_video_marca ;");
        }

        public DataTable ListarModeloVideo(int idMarca)
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_video_modelo where IdMarca=" + idMarca + " ;");
        }

        public int GuardarNuevoVideo(Video video, string usuario)
        {
            string sql = "Select * From video where idModelo=" + video.Modelo.IdModelo + " and idTipo=" + video.IdTipo + " and idCapacidad=" + video.IdCapacidad + " ;";
            MySqlDataReader reader;
            reader = objManager.MostrarInformacion(sql);

            if (!(reader.HasRows))
            {
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();

                parametrosEntrada = new MySqlParameter[10];
                parametrosEntrada[0] = new MySqlParameter("@_idModelo", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idTipo", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_tipo", MySqlDbType.VarChar, 20);
                parametrosEntrada[3] = new MySqlParameter("@_idCapacidad", MySqlDbType.Int32);
                parametrosEntrada[4] = new MySqlParameter("@_capacidad", MySqlDbType.Double);
                parametrosEntrada[5] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                parametrosEntrada[6] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 80);
                parametrosEntrada[7] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 255);
                parametrosEntrada[8] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 255);
                parametrosEntrada[9] = new MySqlParameter("@_idVideo", MySqlDbType.Int32);

                parametrosEntrada[0].Value = video.Modelo.IdModelo;
                parametrosEntrada[1].Value = video.IdTipo;
                parametrosEntrada[2].Value = video.Tipo;
                parametrosEntrada[3].Value = video.IdCapacidad;
                parametrosEntrada[4].Value = video.Capacidad;
                parametrosEntrada[5].Value = video.Cantidad;
                parametrosEntrada[6].Value = video.Ubicacion;
                parametrosEntrada[7].Value = video.Observacion;
                parametrosEntrada[8].Value = usuario;

                string[] datosSalida = new string[1];

                objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_video",
                    9, 10, out datosSalida, 1);

                if (datosSalida != null)
                {
                    int idDiscoDuro = Convert.ToInt32(datosSalida[0]);
                    return idDiscoDuro;
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
        public int ModificarVideo(Video video, string usuario, int actualizarEstado)
        {
            string sql = "";
            if (actualizarEstado == 1)
            {
                sql = "Select * From video where idModelo=" + video.Modelo.IdModelo + " and idTipo=" + video.IdTipo + " and idCapacidad=" + video.IdCapacidad + " and estado=" + video.Estado + " ;";
            }
            else
            {
                sql = "Select * From video where idModelo=" + video.Modelo.IdModelo + " and idTipo=" + video.IdTipo + " and idCapacidad=" + video.IdCapacidad + " ;";
            }

            MySqlDataReader reader;
            reader = objManager.MostrarInformacion(sql);

            if (!(reader.HasRows))
            {
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();

                parametrosEntrada = new MySqlParameter[8];
                parametrosEntrada[0] = new MySqlParameter("@_idVideo", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idModelo", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_idTipo", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_tipo", MySqlDbType.VarChar, 20);
                parametrosEntrada[4] = new MySqlParameter("@_idCapacidad", MySqlDbType.Int32);
                parametrosEntrada[5] = new MySqlParameter("@_capacidad", MySqlDbType.Double);
                parametrosEntrada[6] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[7] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                parametrosEntrada[0].Value = video.IdVideo;
                parametrosEntrada[1].Value = video.Modelo.IdModelo;
                parametrosEntrada[2].Value = video.IdTipo;
                parametrosEntrada[3].Value = video.Tipo;
                parametrosEntrada[4].Value = video.IdCapacidad;
                parametrosEntrada[5].Value = video.Capacidad;
                parametrosEntrada[6].Value = video.Estado;
                parametrosEntrada[7].Value = usuario;
                bool aux = objManager.EjecutarProcedure(parametrosEntrada, "update_video");
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
