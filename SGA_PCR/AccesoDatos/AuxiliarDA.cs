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
    public class AuxiliarDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public AuxiliarDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarAuxiliares()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM auxiliar; ");
        }

        public int GuardarNuevaDescripcion(Auxiliar auxiliar, string usuario)
        {
            string sql = "Select * From auxiliar where cod_tabla ='" + auxiliar.Cod_tabla + "' and descripcion= '" + auxiliar.Descripcion + "' ;";
            MySqlDataReader reader;
            reader = objManager.MostrarInformacion(sql);

            if (!(reader.HasRows))
            {
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();

                parametrosEntrada = new MySqlParameter[4];
                parametrosEntrada[0] = new MySqlParameter("@_cod_tabla", MySqlDbType.VarChar, 255);
                parametrosEntrada[1] = new MySqlParameter("@_descripcion", MySqlDbType.VarChar, 255);
                parametrosEntrada[2] = new MySqlParameter("@_activo", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_idAuxiliar", MySqlDbType.Int32);

                parametrosEntrada[0].Value = auxiliar.Cod_tabla;
                parametrosEntrada[1].Value = auxiliar.Descripcion;
                parametrosEntrada[2].Value = auxiliar.Activo;

                string[] datosSalida = new string[1];

                objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_auxiliar",
                    3, 4, out datosSalida, 1);

                if (datosSalida != null)
                {
                    int idAuxiliar = Convert.ToInt32(datosSalida[0]);
                    return idAuxiliar;
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
        public int ModificarAuxiliar(Auxiliar auxiliar, string usuario, int actualizarEstado)
        {
            string sql = "";
            if (actualizarEstado == 1)
            {
                sql = "Select * From auxiliar where cod_tabla ='" + auxiliar.Cod_tabla + "' and descripcion= '" + auxiliar.Descripcion + "' and activo=" + auxiliar.Activo + " ;";
            }
            else
            {
                sql = "Select * From auxiliar where cod_tabla ='" + auxiliar.Cod_tabla + "' and descripcion= '" + auxiliar.Descripcion + "' ;";
            }

            MySqlDataReader reader;
            reader = objManager.MostrarInformacion(sql);

            if (!(reader.HasRows))
            {
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();

                parametrosEntrada = new MySqlParameter[4];
                parametrosEntrada[0] = new MySqlParameter("@_cod_tabla", MySqlDbType.VarChar,255);
                parametrosEntrada[1] = new MySqlParameter("@_descripcion", MySqlDbType.VarChar, 255);
                parametrosEntrada[2] = new MySqlParameter("@_activo", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_idAuxiliar", MySqlDbType.Int32);

                parametrosEntrada[0].Value = auxiliar.Cod_tabla;
                parametrosEntrada[1].Value = auxiliar.Descripcion;
                parametrosEntrada[2].Value = auxiliar.Activo;
                parametrosEntrada[3].Value = auxiliar.IdAuxiliar;

                bool aux = objManager.EjecutarProcedure(parametrosEntrada, "update_auxiliar");
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
