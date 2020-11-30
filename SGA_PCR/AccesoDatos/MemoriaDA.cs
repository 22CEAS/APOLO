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
    public class MemoriaDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public MemoriaDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarMemorias()
        {
            return objManager.MostrarTablaDatos("Select * from vista_maestro_memoria ;");
        }

        public DataTable ListarModelosMemoria()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_memoria_modelo ;");
        }

        public DataTable ListarMemoriaCapacidad()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_memoria_capacidad ;");
        }


        public DataTable ListarMemoriaTipo()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_memoria_categoria ;");
        }

        //public DataTable ListarProcesadorVelocidad()
        //{
        //    return objManager.MostrarTablaDatos("SELECT * FROM vista_memoria_categoria ;");
        //}

        public DataTable ListarMemoriaFrecuencia()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_memoria_frecuencia ;");
        }


        public int GuardarNuevaMemoria(Memoria memoria, string usuario)
        {
            //string sql = "Select * From memoria where idModelo=" + memoria.Modelo.IdModelo + " and idBusFrecuencia=" + memoria.IdBusFrecuencia + " and idTipo=" + memoria.IdTipo + " and idCapacidad=" + memoria.IdCapacidad + " ;" ;
            string sql = "Select * From memoria where idModelo=" + memoria.Modelo.IdModelo + " and idTipo=" + memoria.IdTipo + " and idCapacidad=" + memoria.IdCapacidad + " ;";
            MySqlDataReader reader;
            reader = objManager.MostrarInformacion(sql);

            if (!(reader.HasRows))
            {
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();

                parametrosEntrada = new MySqlParameter[12];
                parametrosEntrada[0] = new MySqlParameter("@_idModelo", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idBusFrecuencia", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_busFrecuencia", MySqlDbType.Double);
                parametrosEntrada[3] = new MySqlParameter("@_idCapacidad", MySqlDbType.Int32);
                parametrosEntrada[4] = new MySqlParameter("@_capacidad", MySqlDbType.Double);
                parametrosEntrada[5] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                parametrosEntrada[6] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 80);
                parametrosEntrada[7] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 255);
                parametrosEntrada[8] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
                parametrosEntrada[9] = new MySqlParameter("@_idTipo", MySqlDbType.Int32);
                parametrosEntrada[10] = new MySqlParameter("@_tipo", MySqlDbType.VarChar, 80);
                parametrosEntrada[11] = new MySqlParameter("@_idMemoria", MySqlDbType.Int32);

                parametrosEntrada[0].Value = memoria.Modelo.IdModelo;
                parametrosEntrada[1].Value = 1;
                parametrosEntrada[2].Value = 1333;
                parametrosEntrada[3].Value = memoria.IdCapacidad;
                parametrosEntrada[4].Value = memoria.Capacidad;
                parametrosEntrada[5].Value = memoria.Cantidad;
                parametrosEntrada[6].Value = memoria.Ubicacion;
                parametrosEntrada[7].Value = memoria.Observacion;
                parametrosEntrada[8].Value = usuario;
                parametrosEntrada[9].Value = memoria.IdTipo;
                parametrosEntrada[10].Value = memoria.Tipo;

                string[] datosSalida = new string[1];

                objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_memoria",
                    11, 12, out datosSalida, 1);

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

        public int ModificarMemoria(Memoria memoria, string usuario, int actualizarEstado)
        {
            string sql = "";
            //if (actualizarEstado == 1)
            //    sql = "Select * From memoria where idModelo=" + memoria.Modelo.IdModelo + " and idBusFrecuencia=" + memoria.IdBusFrecuencia + " and idTipo=" + memoria.IdTipo + " and idCapacidad=" + memoria.IdCapacidad + " and estado = " + memoria.Estado + " ;";
            //else
            //    sql = "Select * From memoria where idModelo=" + memoria.Modelo.IdModelo + " and idBusFrecuencia=" + memoria.IdBusFrecuencia + " and idTipo=" + memoria.IdTipo + " and idCapacidad=" + memoria.IdCapacidad + " ;" ;

            if (actualizarEstado == 1)
                sql = "Select * From memoria where idModelo=" + memoria.Modelo.IdModelo + " and idTipo=" + memoria.IdTipo + " and idCapacidad=" + memoria.IdCapacidad + " and estado = " + memoria.Estado + " ;";
            else
                sql = "Select * From memoria where idModelo=" + memoria.Modelo.IdModelo + " and idTipo=" + memoria.IdTipo + " and idCapacidad=" + memoria.IdCapacidad + " ;";


            MySqlDataReader reader;
            reader = objManager.MostrarInformacion(sql);

            if (!(reader.HasRows))
            {
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();

                parametrosEntrada = new MySqlParameter[10];
                parametrosEntrada[0] = new MySqlParameter("@_idModelo", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idBusFrecuencia", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_busFrecuencia", MySqlDbType.Double);
                parametrosEntrada[3] = new MySqlParameter("@_idCapacidad", MySqlDbType.Int32);
                parametrosEntrada[4] = new MySqlParameter("@_capacidad", MySqlDbType.Double);
                parametrosEntrada[5] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[6] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
                parametrosEntrada[7] = new MySqlParameter("@_idTipo", MySqlDbType.Int32);
                parametrosEntrada[8] = new MySqlParameter("@_tipo", MySqlDbType.VarChar, 80);
                parametrosEntrada[9] = new MySqlParameter("@_idMemoria", MySqlDbType.Int32);

                parametrosEntrada[0].Value = memoria.Modelo.IdModelo;
                parametrosEntrada[1].Value = 1;
                parametrosEntrada[2].Value = 1333;
                parametrosEntrada[3].Value = memoria.IdCapacidad;
                parametrosEntrada[4].Value = memoria.Capacidad;
                parametrosEntrada[5].Value = memoria.Estado;
                parametrosEntrada[6].Value = usuario;
                parametrosEntrada[7].Value = memoria.IdTipo;
                parametrosEntrada[8].Value = memoria.Tipo;
                parametrosEntrada[9].Value = memoria.IdMemoria;

                bool aux = objManager.EjecutarProcedure(parametrosEntrada, "update_memoria");
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
