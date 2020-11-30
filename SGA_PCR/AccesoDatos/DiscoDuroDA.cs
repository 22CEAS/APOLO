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
    public class DiscoDuroDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public DiscoDuroDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarDiscosDuros()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_maestro_disco ;");
        }
        public DataTable ListarTipoDisco()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_disco_modelo ;");
        }
        public DataTable ListarTamanoDisco()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_disco_tamano ;");
        }
        public DataTable ListarCapacidadDuros()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_disco_capacidad ;");
        }

        public int GuardarNuevoDiscoDuro(DiscoDuro disco,string usuario)
        {
            string sql = "Select * From disco_duro where idModelo=" + disco.Tipo.IdModelo + " and idTamano=" + disco.IdTamano + " and idCapacidad=" + disco.IdCapacidad + " ;";
            MySqlDataReader reader;
            reader=objManager.MostrarInformacion(sql);

            if (!(reader.HasRows))
            {
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();

                parametrosEntrada = new MySqlParameter[10];
                parametrosEntrada[0] = new MySqlParameter("@_idModelo", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idTamano", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_tamano", MySqlDbType.VarChar, 80);
                parametrosEntrada[3] = new MySqlParameter("@_idCapacidad", MySqlDbType.Int32);
                parametrosEntrada[4] = new MySqlParameter("@_capacidad", MySqlDbType.Double);
                parametrosEntrada[5] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                parametrosEntrada[6] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 80);
                parametrosEntrada[7] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 255);
                parametrosEntrada[8] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 255);
                parametrosEntrada[9] = new MySqlParameter("@_idDiscoDuro", MySqlDbType.Int32);

                parametrosEntrada[0].Value = disco.Tipo.IdModelo;
                parametrosEntrada[1].Value = disco.IdTamano;
                parametrosEntrada[2].Value = disco.Tamano;
                parametrosEntrada[3].Value = disco.IdCapacidad;
                parametrosEntrada[4].Value = disco.Capacidad;
                parametrosEntrada[5].Value = disco.Cantidad;
                parametrosEntrada[6].Value = disco.Ubicacion;
                parametrosEntrada[7].Value = disco.Observacion;
                parametrosEntrada[8].Value = usuario;

                string[] datosSalida = new string[1];

                objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_disco_duro",
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
        public int ModificarDiscoDuro(DiscoDuro disco, string usuario,int actualizarEstado)
        {
            string sql = "";
            if (actualizarEstado == 1)
            {
                sql = "Select * From disco_duro where idModelo=" + disco.Tipo.IdModelo + " and idTamano=" + disco.IdTamano + " and idCapacidad=" + disco.IdCapacidad + " and estado=" + disco.Estado + " ;";
            }
            else
            {
                sql = "Select * From disco_duro where idModelo=" + disco.Tipo.IdModelo + " and idTamano=" + disco.IdTamano + " and idCapacidad=" + disco.IdCapacidad +  " ;";
            }
            
            MySqlDataReader reader;
            reader = objManager.MostrarInformacion(sql);

            if (!(reader.HasRows))
            {
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();

                parametrosEntrada = new MySqlParameter[8];
                parametrosEntrada[0] = new MySqlParameter("@_idDisco", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idModelo", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_idTamano", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_tamano", MySqlDbType.VarChar, 80);
                parametrosEntrada[4] = new MySqlParameter("@_idCapacidad", MySqlDbType.Int32);
                parametrosEntrada[5] = new MySqlParameter("@_capacidad", MySqlDbType.Double);
                parametrosEntrada[6] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[7] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                parametrosEntrada[0].Value = disco.IdDisco;
                parametrosEntrada[1].Value = disco.Tipo.IdModelo;
                parametrosEntrada[2].Value = disco.IdTamano;
                parametrosEntrada[3].Value = disco.Tamano;
                parametrosEntrada[4].Value = disco.IdCapacidad;
                parametrosEntrada[5].Value = disco.Capacidad;
                parametrosEntrada[6].Value = disco.Estado;
                parametrosEntrada[7].Value = usuario;
                bool aux=objManager.EjecutarProcedure(parametrosEntrada, "update_disco_duro");
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
