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
    public class RenovacionDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public RenovacionDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarLaptopsClientesEstadoAlquilado(int idCliente)
        {
            return objManager.MostrarTablaDatos("Select * From vista_laptops_detalle_alquiler_plazo_alquiler where idCliente=" + idCliente + " ;");
        }


        public DataTable ListarSalidasTipo()
        {
            return objManager.MostrarTablaDatos("Select * From vista_salida_tipo ;");
        }

        public int InsertarRenovaciones(BindingList<Renovacion> renovaciones, string usuario,string documentoReferencia,
            int idSalidaTipo, string nombreSalidaTipo )
        {
            bool error = false;

            foreach (Renovacion renovacion in renovaciones)
            {
                parametrosEntrada = new MySqlParameter[7];
                parametrosEntrada[0] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_fecIniContrato", MySqlDbType.DateTime);
                parametrosEntrada[2] = new MySqlParameter("@_fecFinContrato", MySqlDbType.DateTime);
                parametrosEntrada[3] = new MySqlParameter("@_idSalidaTipo", MySqlDbType.Int32);
                parametrosEntrada[4] = new MySqlParameter("@_nombreSalidaTipo", MySqlDbType.VarChar, 255);
                parametrosEntrada[5] = new MySqlParameter("@_documentoRenovacion", MySqlDbType.VarChar, 255);
                parametrosEntrada[6] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                parametrosEntrada[0].Value = renovacion.IdSalidaDetalle;
                parametrosEntrada[1].Value = renovacion.FechaIniContrato;
                parametrosEntrada[2].Value = renovacion.FechaFinContrato;
                parametrosEntrada[3].Value = idSalidaTipo;
                parametrosEntrada[4].Value = nombreSalidaTipo;
                parametrosEntrada[5].Value = documentoReferencia;
                parametrosEntrada[6].Value = usuario;
                bool okey = objManager.EjecutarProcedure(parametrosEntrada, "update_salida_det_renovacion");
                if (!okey) return 0;


                parametrosEntrada = new MySqlParameter[13];
                parametrosEntrada[0] = new MySqlParameter("@_idSalida", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_guiaSalida", MySqlDbType.VarChar, 255);
                parametrosEntrada[4] = new MySqlParameter("@_fecIniContratoAnt", MySqlDbType.Date);
                parametrosEntrada[5] = new MySqlParameter("@_fecFinContratoAnt", MySqlDbType.Date);
                parametrosEntrada[6] = new MySqlParameter("@_fecIniContratoNew", MySqlDbType.Date);
                parametrosEntrada[7] = new MySqlParameter("@_fecFinContratoNew", MySqlDbType.Date);
                parametrosEntrada[8] = new MySqlParameter("@_idSalidaTipo", MySqlDbType.Int32);
                parametrosEntrada[9] = new MySqlParameter("@_nombreSalidaTipo", MySqlDbType.VarChar, 255);
                parametrosEntrada[10] = new MySqlParameter("@_documentoSalidaTipo", MySqlDbType.VarChar, 255);
                parametrosEntrada[11] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
                parametrosEntrada[12] = new MySqlParameter("@_idRenovacion", MySqlDbType.Int32);

                parametrosEntrada[0].Value = renovacion.IdSalida;
                parametrosEntrada[1].Value = renovacion.IdSalidaDetalle;
                parametrosEntrada[2].Value = renovacion.IdLC;
                parametrosEntrada[3].Value = renovacion.GuiaSalida;
                parametrosEntrada[4].Value = renovacion.FechaIniContratoAntiguo;
                parametrosEntrada[5].Value = renovacion.FechaFinContratoAntiguo;
                parametrosEntrada[6].Value = renovacion.FechaIniContrato;
                parametrosEntrada[7].Value = renovacion.FechaFinContrato;
                parametrosEntrada[8].Value = idSalidaTipo;
                parametrosEntrada[9].Value = nombreSalidaTipo;
                parametrosEntrada[10].Value = documentoReferencia;
                parametrosEntrada[11].Value = usuario;

                string[] datosSalida = new string[1];
                objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_log_renovaciones",
                    12, 13, out datosSalida, 1);

                if (datosSalida != null)
                {
                    int idSalidaDet = Convert.ToInt32(datosSalida[0]);
                    error = true;
                }
                else
                {
                    return 0;
                }

            }

            return 1;

        }
    }
}
