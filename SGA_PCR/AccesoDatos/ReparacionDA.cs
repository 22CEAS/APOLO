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
    public class ReparacionDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public ReparacionDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarLaptops()
        {
            return objManager.MostrarTablaDatos("Select * From vista_laptops_danados ;");
        }
        public DataTable ListarEstados()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM estados where idEstado=2 or idEstado=3 or idEstado=10; ");
        }


        public DataTable ListarTodosEstados()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM estados ; ");
        }

        public DataTable ListarResponsable()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM usuario ;");
        }

        public DataTable ListarCodigosLC()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_inventario_laptops ; ");
        }


        public DataTable ListarReparaciones(string sql)
        {
            return objManager.MostrarTablaDatos("Select * from vista_lista_reparaciones v " + sql + " ;");
        }


        public Reparacion LlamarReparacionModificable(int idReparacion)
        {
            Reparacion reparacion = new Reparacion();
            MySqlDataReader reader;
            string sql = "";

            sql = "Select * From reparacion where idReparacion=" + idReparacion + " ;";

            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                reparacion.IdReparacion = reader.GetInt32("idReparacion");
                reparacion.IdLC = reader.GetInt32("idLC");
                reparacion.CodigoLC = reader.GetString("codigoLC");
                reparacion.FechaReparacion = reader.GetDateTime("fechaReparacion");
                reparacion.EstadoLCAct = reader.GetInt32("estadoLCAct");
                reparacion.EstadoLCAnt = reader.GetInt32("estadoLCAnt");
                reparacion.ObservacionActual = reader.GetString("observacionActual");
                reparacion.ObservacionReparacion = reader.GetString("observacionReparacion");
                reparacion.Estado = reader.GetInt32("estado");
            }

            objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();

            return reparacion;
        }


        public bool AnularReparacion(Reparacion reparacion, string usuario)
        {

            bool error = false;

            parametrosEntrada = new MySqlParameter[4];
            parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[2] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 250);
            parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

            parametrosEntrada[0].Value = reparacion.IdLC;
            parametrosEntrada[1].Value = reparacion.EstadoLCAnt;
            parametrosEntrada[2].Value = "ALMACEN";
            parametrosEntrada[3].Value = usuario;

            error = objManager.EjecutarProcedure(parametrosEntrada, "update_laptop_disponibilidad");


            parametrosEntrada = new MySqlParameter[3];
            parametrosEntrada[0] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
            parametrosEntrada[2] = new MySqlParameter("@_idReparacion", MySqlDbType.Int32);

            parametrosEntrada[0].Value = reparacion.Estado;
            parametrosEntrada[1].Value = usuario;
            parametrosEntrada[2].Value = reparacion.IdReparacion;

            error = objManager.EjecutarProcedure(parametrosEntrada, "anular_reparacion");

            return error;
        }

        public int InsertarReparacion(Reparacion reparacion, string usuario)
        {

            bool error = false;

            parametrosEntrada = new MySqlParameter[10];
            parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_codigoLC", MySqlDbType.VarChar, 80);
            parametrosEntrada[2] = new MySqlParameter("@_fechaReparacion", MySqlDbType.DateTime);
            parametrosEntrada[3] = new MySqlParameter("@_estadoLCAct", MySqlDbType.Int32);
            parametrosEntrada[4] = new MySqlParameter("@_estadoLCAnt", MySqlDbType.Int32);
            parametrosEntrada[5] = new MySqlParameter("@_observacionActual", MySqlDbType.VarChar, 1000);
            parametrosEntrada[6] = new MySqlParameter("@_observacionReparacion", MySqlDbType.VarChar, 1000);
            parametrosEntrada[7] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[8] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
            parametrosEntrada[9] = new MySqlParameter("@_idReparacion", MySqlDbType.Int32);

            parametrosEntrada[0].Value = reparacion.IdLC;
            parametrosEntrada[1].Value = reparacion.CodigoLC;
            parametrosEntrada[2].Value = reparacion.FechaReparacion;
            parametrosEntrada[3].Value = reparacion.EstadoLCAct;
            parametrosEntrada[4].Value = reparacion.EstadoLCAnt;
            parametrosEntrada[5].Value = reparacion.ObservacionActual;
            parametrosEntrada[6].Value = reparacion.ObservacionReparacion;
            parametrosEntrada[7].Value = 1;
            parametrosEntrada[8].Value = usuario;

            string[] datosSalida = new string[1];

            objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_reparacion",
                9, 10, out datosSalida, 1);

            if (datosSalida != null)
            {
                reparacion.IdReparacion = Convert.ToInt32(datosSalida[0]);

                parametrosEntrada = new MySqlParameter[4];
                parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 250);
                parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                parametrosEntrada[0].Value = reparacion.IdLC;
                parametrosEntrada[1].Value = reparacion.EstadoLCAct;
                parametrosEntrada[2].Value = "ALMACEN";
                parametrosEntrada[3].Value = usuario;

                objManager.EjecutarProcedure(parametrosEntrada, "update_laptop_disponibilidad");

            }
            return reparacion.IdReparacion;
        }

        public bool ModificarReparacion(Reparacion reparacion, string usuario, Reparacion reparacionOld)
        {

            bool error = false;

            parametrosEntrada = new MySqlParameter[4];
            parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[2] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 250);
            parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

            parametrosEntrada[0].Value = reparacionOld.IdLC;
            parametrosEntrada[1].Value = reparacionOld.EstadoLCAnt;
            parametrosEntrada[2].Value = "ALMACEN";
            parametrosEntrada[3].Value = usuario;

            error=objManager.EjecutarProcedure(parametrosEntrada, "update_laptop_disponibilidad");

            if (error)
            {

                parametrosEntrada = new MySqlParameter[10];
                parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_codigoLC", MySqlDbType.VarChar, 80);
                parametrosEntrada[2] = new MySqlParameter("@_fechaReparacion", MySqlDbType.DateTime);
                parametrosEntrada[3] = new MySqlParameter("@_estadoLCAct", MySqlDbType.Int32);
                parametrosEntrada[4] = new MySqlParameter("@_estadoLCAnt", MySqlDbType.Int32);
                parametrosEntrada[5] = new MySqlParameter("@_observacionActual", MySqlDbType.VarChar, 1000);
                parametrosEntrada[6] = new MySqlParameter("@_observacionReparacion", MySqlDbType.VarChar, 1000);
                parametrosEntrada[7] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[8] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
                parametrosEntrada[9] = new MySqlParameter("@_idReparacion", MySqlDbType.Int32);

                parametrosEntrada[0].Value = reparacion.IdLC;
                parametrosEntrada[1].Value = reparacion.CodigoLC;
                parametrosEntrada[2].Value = reparacion.FechaReparacion;
                parametrosEntrada[3].Value = reparacion.EstadoLCAct;
                parametrosEntrada[4].Value = reparacion.EstadoLCAnt;
                parametrosEntrada[5].Value = reparacion.ObservacionActual;
                parametrosEntrada[6].Value = reparacion.ObservacionReparacion;
                parametrosEntrada[7].Value = 1;
                parametrosEntrada[8].Value = usuario;
                parametrosEntrada[9].Value = reparacion.IdReparacion;

                error = objManager.EjecutarProcedure(parametrosEntrada, "update_reparacion");

                if (error)
                {
                    parametrosEntrada = new MySqlParameter[4];
                    parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                    parametrosEntrada[2] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 250);
                    parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                    parametrosEntrada[0].Value = reparacion.IdLC;
                    parametrosEntrada[1].Value = reparacion.EstadoLCAct;
                    parametrosEntrada[2].Value = "ALMACEN";
                    parametrosEntrada[3].Value = usuario;

                    error = objManager.EjecutarProcedure(parametrosEntrada, "update_laptop_disponibilidad");
                    if (error)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }

    }
}
