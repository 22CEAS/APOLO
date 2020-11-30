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
    public class ObservacionDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public ObservacionDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarObservaciones(int idCliente)
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_lista_observaciones where IdCliente = " + idCliente + " and IdEstado = "+1+" ;");
        }


        public DataTable ListarObservacionesABuscar(string sql)
        {
            return objManager.MostrarTablaDatos("Select * from vista_lista_observaciones v " + sql + " ;");
        }


        public Observacion LlamarObservacionModificable(int idObservacion)
        {
            Observacion observacion = new Observacion();
            MySqlDataReader reader;
            string sql = "";

            sql = "Select * From vista_lista_observaciones where IdObservacion=" + idObservacion + " ;";
            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                observacion.IdObervacion = reader.GetInt32("IdObservacion");
                observacion.IdCliente = reader.GetInt32("IdCliente");
                observacion.Cliente = reader.GetString("Cliente");
                observacion.RUC = reader.GetString("RUC");
                observacion.IdLC = reader.GetInt32("IdLC");
                observacion.CodigoLC = reader.GetString("CodigoLC");
                observacion.IdDevolucion = reader.GetInt32("IdDevolucion");
                observacion.IdCambio = reader.GetInt32("IdCambio");
                observacion.ObservacionDeuda = reader.GetString("ObservacionDeuda");
                observacion.GuiaLevantamiento = reader.GetString("GuiaLevantamiento");
                observacion.ObservacionLevantamiento = reader.GetString("ObservacionLevantamiento");
                observacion.FechaLevantamiento = reader.GetDateTime("FechaLevantamiento");
                observacion.IdEstado = reader.GetInt32("IdEstado");
                observacion.Estado = reader.GetString("Estado");
            }

            objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();
            
            return observacion;
        }


        public int GrabarLevantamiento(Observacion observacion, string usuario)
        {
            parametrosEntrada = new MySqlParameter[6];
            parametrosEntrada[0] = new MySqlParameter("@_guiaLevantamiento", MySqlDbType.VarChar, 80);
            parametrosEntrada[1] = new MySqlParameter("@_observacionLevantamiento", MySqlDbType.VarChar, 1000);
            parametrosEntrada[2] = new MySqlParameter("@_fechaLevantamiento", MySqlDbType.DateTime);
            parametrosEntrada[3] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[4] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
            parametrosEntrada[5] = new MySqlParameter("@_idObservacionDeudas", MySqlDbType.Int32);

            parametrosEntrada[0].Value = observacion.GuiaLevantamiento;
            parametrosEntrada[1].Value = observacion.ObservacionLevantamiento;
            parametrosEntrada[2].Value = observacion.FechaLevantamiento;
            parametrosEntrada[3].Value = observacion.IdEstado;
            parametrosEntrada[4].Value = usuario;
            parametrosEntrada[5].Value = observacion.IdObervacion;

            bool okey = objManager.EjecutarProcedure(parametrosEntrada, "update_observacion");
            if (!okey) return 0;
                

            return 1;
        }

        public int AnularLevantamiento(Observacion observacion, string usuario)
        {
            bool error = false;

            parametrosEntrada = new MySqlParameter[6];
            parametrosEntrada[0] = new MySqlParameter("@_guiaLevantamiento", MySqlDbType.VarChar, 80);
            parametrosEntrada[1] = new MySqlParameter("@_observacionLevantamiento", MySqlDbType.VarChar, 1000);
            parametrosEntrada[2] = new MySqlParameter("@_fechaLevantamiento", MySqlDbType.DateTime);
            parametrosEntrada[3] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[4] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
            parametrosEntrada[5] = new MySqlParameter("@_idObservacionDeudas", MySqlDbType.Int32);

            parametrosEntrada[0].Value = "";
            parametrosEntrada[1].Value = "";
            parametrosEntrada[2].Value = null;
            parametrosEntrada[3].Value = observacion.IdEstado;
            parametrosEntrada[4].Value = usuario;
            parametrosEntrada[5].Value = observacion.IdObervacion;

            bool okey = objManager.EjecutarProcedure(parametrosEntrada, "update_observacion");
            if (!okey) return 0;


            return 1;
        }

    }
}
