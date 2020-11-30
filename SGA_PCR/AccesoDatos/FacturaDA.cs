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
    public class FacturaDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public FacturaDA()
        {
            objManager = new DBManager();
        }
        public DataTable ListarCV()
        {
            return objManager.MostrarTablaDatos("Select * from vista_factura_CV ;");
        }
        public int InsertarFacturas(BindingList<Factura> facturas, string usuario)
        {

            foreach (Factura factura in facturas)
            {
                MySqlDataReader reader;
                string sql = "";
                sql = "SELECT DISTINCT s.idSalida FROM salida s INNER JOIN salida_det d ON s.idSalida = d.idSalida WHERE d.guiaSalida = '" + factura.NumeroDocRef + "' ;";
                reader = objManager.MostrarInformacion(sql);

                while (reader.Read())
                {
                    factura.IdSalida = reader.GetInt32("idSalida");
                }

                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();


                parametrosEntrada = new MySqlParameter[12];
                parametrosEntrada[0] = new MySqlParameter("@_idSalida", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_numFactura", MySqlDbType.VarChar, 255);
                parametrosEntrada[2] = new MySqlParameter("@_fecIniPago", MySqlDbType.DateTime);
                parametrosEntrada[3] = new MySqlParameter("@_fecFinPago", MySqlDbType.DateTime);
                parametrosEntrada[4] = new MySqlParameter("@_fecEmisiom", MySqlDbType.DateTime);
                parametrosEntrada[5] = new MySqlParameter("@_ruc", MySqlDbType.VarChar, 11);
                parametrosEntrada[6] = new MySqlParameter("@_codigoLC", MySqlDbType.VarChar, 255);
                parametrosEntrada[7] = new MySqlParameter("@_guiaSalida", MySqlDbType.VarChar, 255);
                parametrosEntrada[8] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
                parametrosEntrada[9] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[10] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
                parametrosEntrada[11] = new MySqlParameter("@_idFactura", MySqlDbType.Int32);

                parametrosEntrada[0].Value = factura.IdSalida;
                parametrosEntrada[1].Value = factura.NumeroFactura;
                parametrosEntrada[2].Value = factura.FechaIniPago;
                parametrosEntrada[3].Value = factura.FechaFinPago;
                parametrosEntrada[4].Value = factura.FechaPago;
                parametrosEntrada[5].Value = factura.RucDni;
                parametrosEntrada[6].Value = factura.CodigoLC;
                parametrosEntrada[7].Value = factura.NumeroDocRef;
                parametrosEntrada[8].Value = "";
                parametrosEntrada[9].Value = 1;
                parametrosEntrada[10].Value = usuario;

                string[] datosSalida = new string[1];

                objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_factura",
                    11, 12, out datosSalida, 1);

                if (datosSalida != null)
                {
                    factura.IdFactura = Convert.ToInt32(datosSalida[0]);
                }

            }

            return 1;
        }

        public int InsertarFactura(Factura factura, string usuario, int idLCAct, int idLCAnt, string codigoActCV)
        {

            MySqlDataReader reader;
            string sql = "";
            sql = "SELECT DISTINCT s.idSalida FROM salida s INNER JOIN salida_det d ON s.idSalida = d.idSalida WHERE d.guiaSalida = '" + factura.NumeroDocRef + "' ;";
            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                factura.IdSalida = reader.GetInt32("idSalida");
            }

            objManager.conexion.Close();
            objManager.conexion.Dispose();
            objManager.cmd.Dispose();


            parametrosEntrada = new MySqlParameter[16];
            parametrosEntrada[0] = new MySqlParameter("@_idSalida", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_numFactura", MySqlDbType.VarChar, 255);
            parametrosEntrada[2] = new MySqlParameter("@_fecIniPago", MySqlDbType.DateTime);
            parametrosEntrada[3] = new MySqlParameter("@_fecFinPago", MySqlDbType.DateTime);
            parametrosEntrada[4] = new MySqlParameter("@_fecEmisiom", MySqlDbType.DateTime);
            parametrosEntrada[5] = new MySqlParameter("@_ruc", MySqlDbType.VarChar, 11);
            parametrosEntrada[6] = new MySqlParameter("@_codigoLC", MySqlDbType.VarChar, 255);
            parametrosEntrada[7] = new MySqlParameter("@_guiaSalida", MySqlDbType.VarChar, 255);
            parametrosEntrada[8] = new MySqlParameter("@_totalSoles", MySqlDbType.Double);
            parametrosEntrada[9] = new MySqlParameter("@_totalDolares", MySqlDbType.Double);
            parametrosEntrada[10] = new MySqlParameter("@_costoSoles", MySqlDbType.Double);
            parametrosEntrada[11] = new MySqlParameter("@_costoDolares", MySqlDbType.Double);
            parametrosEntrada[12] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
            parametrosEntrada[13] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[14] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
            parametrosEntrada[15] = new MySqlParameter("@_idFactura", MySqlDbType.Int32);

            parametrosEntrada[0].Value = factura.IdSalida;
            parametrosEntrada[1].Value = factura.NumeroFactura;
            parametrosEntrada[2].Value = factura.FechaIniPago;
            parametrosEntrada[3].Value = factura.FechaFinPago;
            parametrosEntrada[4].Value = factura.FechaPago;
            parametrosEntrada[5].Value = factura.RucDni;
            parametrosEntrada[6].Value = factura.CodigoLC;
            parametrosEntrada[7].Value = factura.NumeroDocRef;
            parametrosEntrada[8].Value = factura.TotalSoles;
            parametrosEntrada[9].Value = factura.TotalDolares;
            parametrosEntrada[10].Value = factura.CostoSoles;
            parametrosEntrada[11].Value = factura.CostoDolares;
            parametrosEntrada[12].Value = "";
            parametrosEntrada[13].Value = 1;
            parametrosEntrada[14].Value = usuario;

            string[] datosSalida = new string[1];

            objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_factura",
                15, 16, out datosSalida, 1);

            if (datosSalida != null)
            {
                factura.IdFactura = Convert.ToInt32(datosSalida[0]);
            }

            sql = "Select * from laptop_cpu where codigo='" + factura.CodigoLC + "' ;";
            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                factura.IdLC = reader.GetInt32("idLC");
            }

            objManager.conexion.Close();
            objManager.conexion.Dispose();
            objManager.cmd.Dispose();


            parametrosEntrada = new MySqlParameter[2];
            parametrosEntrada[0] = new MySqlParameter("@_idSalida", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_idLC", MySqlDbType.Int32);

            parametrosEntrada[0].Value = factura.IdSalida;
            parametrosEntrada[1].Value = idLCAct;

            bool okey = objManager.EjecutarProcedure(parametrosEntrada, "delete_cuota");

            parametrosEntrada = new MySqlParameter[2];
            parametrosEntrada[0] = new MySqlParameter("@_idSalida", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_idLC", MySqlDbType.Int32);

            parametrosEntrada[0].Value = factura.IdSalida;
            parametrosEntrada[1].Value = idLCAnt;

            okey = objManager.EjecutarProcedure(parametrosEntrada, "delete_cuota");


            parametrosEntrada = new MySqlParameter[16];
            parametrosEntrada[0] = new MySqlParameter("@_idFactura", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_idSalida", MySqlDbType.Int32);
            parametrosEntrada[2] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
            parametrosEntrada[3] = new MySqlParameter("@_numFactura", MySqlDbType.VarChar, 255);
            parametrosEntrada[4] = new MySqlParameter("@_fecInicioPago", MySqlDbType.DateTime);
            parametrosEntrada[5] = new MySqlParameter("@_fecFinPago", MySqlDbType.DateTime);
            parametrosEntrada[6] = new MySqlParameter("@_fecEmisiom", MySqlDbType.DateTime);
            parametrosEntrada[7] = new MySqlParameter("@_ruc", MySqlDbType.VarChar, 11);
            parametrosEntrada[8] = new MySqlParameter("@_codigoLC", MySqlDbType.VarChar, 255);
            parametrosEntrada[9] = new MySqlParameter("@_guiaSalida", MySqlDbType.VarChar, 255);
            parametrosEntrada[10] = new MySqlParameter("@_totalSoles", MySqlDbType.Double);
            parametrosEntrada[11] = new MySqlParameter("@_totalDolares", MySqlDbType.Double);
            parametrosEntrada[12] = new MySqlParameter("@_costoSoles", MySqlDbType.Double);
            parametrosEntrada[13] = new MySqlParameter("@_costoDolares", MySqlDbType.Double);
            parametrosEntrada[14] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
            parametrosEntrada[15] = new MySqlParameter("@_estado", MySqlDbType.Int32);

            parametrosEntrada[0].Value = factura.IdFactura;
            parametrosEntrada[1].Value = factura.IdSalida;
            parametrosEntrada[2].Value = idLCAct;
            parametrosEntrada[3].Value = factura.NumeroFactura;
            parametrosEntrada[4].Value = factura.FechaIniPago;
            parametrosEntrada[5].Value = factura.FechaFinPago;
            parametrosEntrada[6].Value = factura.FechaPago;
            parametrosEntrada[7].Value = factura.RucDni;
            parametrosEntrada[8].Value = codigoActCV;
            parametrosEntrada[9].Value = factura.NumeroDocRef;
            parametrosEntrada[10].Value = factura.TotalSoles;
            parametrosEntrada[11].Value = factura.TotalDolares;
            parametrosEntrada[12].Value = factura.CostoSoles;
            parametrosEntrada[13].Value = factura.CostoDolares;
            parametrosEntrada[14].Value = "";
            parametrosEntrada[15].Value = 1;

            okey = objManager.EjecutarProcedure(parametrosEntrada, "insert_cuota");

            return 1;
        }

        public void ActualizarPlazoFinal(Factura factura, string usuario, int IdSalidaDetActual, int IdSalidaDetAntigua)
        {
            factura.NumeroOC = factura.NumeroOC.Trim();
            factura.NumeroOC = (factura.NumeroOC.Length > 0) ? factura.NumeroOC : "";

            parametrosEntrada = new MySqlParameter[4];
            parametrosEntrada[0] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_fecFinContrato", MySqlDbType.DateTime);
            parametrosEntrada[2] = new MySqlParameter("@_documentoRenovacion", MySqlDbType.VarChar, 255);
            parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

            parametrosEntrada[0].Value = IdSalidaDetActual;
            parametrosEntrada[1].Value = factura.FechaFinPago;
            parametrosEntrada[2].Value = factura.NumeroOC;
            parametrosEntrada[3].Value = usuario;
            bool okey = objManager.EjecutarProcedure(parametrosEntrada, "update_salida_det_fechaFinalPlazo");

            parametrosEntrada = new MySqlParameter[4];
            parametrosEntrada[0] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_fecFinContrato", MySqlDbType.DateTime);
            parametrosEntrada[2] = new MySqlParameter("@_documentoRenovacion", MySqlDbType.VarChar, 255);
            parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

            parametrosEntrada[0].Value = IdSalidaDetAntigua;
            parametrosEntrada[1].Value = factura.FechaFinPago;
            parametrosEntrada[2].Value = factura.NumeroOC;
            parametrosEntrada[3].Value = usuario;
            okey = objManager.EjecutarProcedure(parametrosEntrada, "update_salida_det_fechaFinalPlazo");
        }
    }
}
