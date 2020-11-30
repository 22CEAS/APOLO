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
    public class DevolucionDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public DevolucionDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarEstados()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM estados ; ");
        }

        public DataTable ListarLaptopsClientesEstadoAlquilado(int idCliente)
        {
            return objManager.MostrarTablaDatos("Select * From vista_laptops_detalle_alquiler_cliente_estado_alquilado where idCliente=" +idCliente+ " ;");
        }

        public DataTable ListarDevolucion(string sql)
        {
            return objManager.MostrarTablaDatos("Select * from vista_lista_devoluciones v " + sql + " ;");
        }

        public int InsertarDevolucion(Devolucion devolucion, string usuario)
        {

            bool error = false;

            parametrosEntrada = new MySqlParameter[8];
            parametrosEntrada[0] = new MySqlParameter("@_idCliente", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_rucDni", MySqlDbType.VarChar, 11);
            parametrosEntrada[2] = new MySqlParameter("@_guiaDevolucion", MySqlDbType.VarChar, 50);
            parametrosEntrada[3] = new MySqlParameter("@_fechaDevolucion", MySqlDbType.DateTime);
            parametrosEntrada[4] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
            parametrosEntrada[5] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[6] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
            parametrosEntrada[7] = new MySqlParameter("@_idDevolucion", MySqlDbType.Int32);

            parametrosEntrada[0].Value = devolucion.IdCliente;
            parametrosEntrada[1].Value = devolucion.RucDni;
            parametrosEntrada[2].Value = devolucion.GuiaDevolucion;
            parametrosEntrada[3].Value = devolucion.FechaDevolucion;
            parametrosEntrada[4].Value = devolucion.Observacion;
            parametrosEntrada[5].Value = 1;
            parametrosEntrada[6].Value = usuario;

            string[] datosSalida = new string[1];

            objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_devolucion",
                7, 8, out datosSalida, 1);

            if (datosSalida != null)
            {
                devolucion.IdDevolucion = Convert.ToInt32(datosSalida[0]);
                error = InsertarDevolucionDetalle(devolucion, usuario);

                if (error)
                {
                    foreach (DevolucionDetalle det in devolucion.Detalles)
                    {
                        parametrosEntrada = new MySqlParameter[4];
                        parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                        parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                        parametrosEntrada[2] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 250);
                        parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                        parametrosEntrada[0].Value = det.IdLC;
                        parametrosEntrada[1].Value = det.EstadoLC;
                        parametrosEntrada[2].Value = "ALMACEN";
                        parametrosEntrada[3].Value = usuario;

                        objManager.EjecutarProcedure(parametrosEntrada, "update_laptop_disponibilidad");


                        parametrosEntrada = new MySqlParameter[3];
                        parametrosEntrada[0] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                        parametrosEntrada[1] = new MySqlParameter("@_fueDevuelto", MySqlDbType.Int32);
                        parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                        parametrosEntrada[0].Value = det.IdSalidaDetalle;
                        parametrosEntrada[1].Value = 1;
                        parametrosEntrada[2].Value = usuario;

                        objManager.EjecutarProcedure(parametrosEntrada, "update_salida_det_devuelto");


                        if (det.Cobrar == 1)
                        {
                            parametrosEntrada = new MySqlParameter[8];
                            parametrosEntrada[0] = new MySqlParameter("@_idCliente", MySqlDbType.Int32);
                            parametrosEntrada[1] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                            parametrosEntrada[2] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                            parametrosEntrada[3] = new MySqlParameter("@_idDevolucion", MySqlDbType.Int32);
                            parametrosEntrada[4] = new MySqlParameter("@_observacionDeuda", MySqlDbType.VarChar, 255);
                            parametrosEntrada[5] = new MySqlParameter("@_KAM", MySqlDbType.VarChar, 255);
                            parametrosEntrada[6] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                            parametrosEntrada[7] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);

                            parametrosEntrada[0].Value = devolucion.IdCliente;
                            parametrosEntrada[1].Value = det.IdLC;
                            parametrosEntrada[2].Value = det.IdSalidaDetalle;
                            parametrosEntrada[3].Value = devolucion.IdDevolucion;
                            parametrosEntrada[4].Value = det.Observacion;
                            parametrosEntrada[5].Value = usuario;
                            parametrosEntrada[6].Value = 1;
                            parametrosEntrada[7].Value = usuario;

                            objManager.EjecutarProcedure(parametrosEntrada, "insert_observacion_deudas");
                        }
                    }

                }

            }
            return devolucion.IdDevolucion;
        }

        public bool InsertarDevolucionDetalle(Devolucion devolucion, string usuario)
        {

            bool error = false;
            foreach (DevolucionDetalle det in devolucion.Detalles)
            {
                parametrosEntrada = new MySqlParameter[15];
                parametrosEntrada[0] = new MySqlParameter("@_idDevolucion", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_codigoLC", MySqlDbType.VarChar, 255);
                parametrosEntrada[3] = new MySqlParameter("@_marcaLC", MySqlDbType.VarChar, 255);
                parametrosEntrada[4] = new MySqlParameter("@_modeloLC", MySqlDbType.VarChar, 255);
                parametrosEntrada[5] = new MySqlParameter("@_pagaraCliente", MySqlDbType.Int32);
                parametrosEntrada[6] = new MySqlParameter("@_danoLC", MySqlDbType.Int32);
                parametrosEntrada[7] = new MySqlParameter("@_caracteristicas", MySqlDbType.VarChar, 255);
                parametrosEntrada[8] = new MySqlParameter("@_estadoLC", MySqlDbType.Int32);
                parametrosEntrada[9] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
                parametrosEntrada[10] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[11] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
                parametrosEntrada[12] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                parametrosEntrada[13] = new MySqlParameter("@_idSucursal", MySqlDbType.Int32);
                parametrosEntrada[14] = new MySqlParameter("@_idDevolucionDet", MySqlDbType.Int32);

                parametrosEntrada[0].Value = devolucion.IdDevolucion;
                parametrosEntrada[1].Value = det.IdLC;
                parametrosEntrada[2].Value = det.CodigoLC;
                parametrosEntrada[3].Value = det.MarcaLC;
                parametrosEntrada[4].Value = det.ModeloLC;
                parametrosEntrada[5].Value = det.Cobrar; ;
                parametrosEntrada[6].Value = det.Danado; ;
                parametrosEntrada[7].Value = det.Caracteristicas; ;
                parametrosEntrada[8].Value = det.EstadoLC; ;
                parametrosEntrada[9].Value = det.Observacion; ;
                parametrosEntrada[10].Value = 1;
                parametrosEntrada[11].Value = usuario;
                parametrosEntrada[12].Value = det.IdSalidaDetalle;
                parametrosEntrada[13].Value = det.IdSucursal;

                string[] datosSalida = new string[1];
                objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_devolucion_det",
                    14, 15, out datosSalida, 1);

                if (datosSalida != null)
                {
                    int idDevolucionDet = Convert.ToInt32(datosSalida[0]);
                    error = true;
                }
                else
                {
                    error = false;
                    return error;
                }
            }
            return error;
        }


        public Devolucion LlamarDevolucionModificable(int idDevolucion)
        {
            Devolucion devolucion = new Devolucion();
            MySqlDataReader reader;
            string sql = "";

            sql = "Select * From devolucion where idDevolucion=" + idDevolucion + " ;";
            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                devolucion.IdDevolucion = reader.GetInt32("idDevolucion");
                devolucion.IdCliente = reader.GetInt32("idCliente");
                devolucion.RucDni = reader.GetString("rucDni");
                devolucion.GuiaDevolucion = reader.GetString("guiaDevolucion");
                devolucion.FechaDevolucion = reader.GetDateTime("fechaDevolucion");
                devolucion.Observacion = reader.GetString("observacion");
                devolucion.Estado = reader.GetInt32("estado");
            }

            objManager.conexion.Close();
            objManager.conexion.Dispose();
            objManager.cmd.Dispose();


            sql = "Select * From devolucion_det where idDevolucion=" + idDevolucion + " ;";
            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                DevolucionDetalle det = new DevolucionDetalle();
                det.IdDetalle = reader.GetInt32("idDevolucionDet");
                det.IdDevolucion = reader.GetInt32("idDevolucion");
                det.IdSalidaDetalle = reader.GetInt32("idSalidaDet");
                det.IdSucursal = reader.GetInt32("idSucursal");
                det.IdLC = reader.GetInt32("idLC");
                det.CodigoLC = reader.GetString("codigoLC");
                det.MarcaLC = reader.GetString("marcaLC");
                det.ModeloLC = reader.GetString("modeloLC");
                det.Cobrar = reader.GetInt32("pagaraCliente");
                det.Danado = reader.GetInt32("danoLC");
                det.Caracteristicas = reader.GetString("caracteristicas");
                det.EstadoLC = reader.GetInt32("estadoLC");
                det.Observacion = reader.GetString("observacion");
                det.Estado = reader.GetInt32("estado");
                devolucion.Detalles.Add(det);
            }

            objManager.conexion.Close();
            objManager.conexion.Dispose();
            objManager.cmd.Dispose();


            return devolucion;
        }

        public bool ModificarDevolucion(Devolucion devolucion, string usuario)
        {

            bool error = false;

            parametrosEntrada = new MySqlParameter[8];
            parametrosEntrada[0] = new MySqlParameter("@_idCliente", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_rucDni", MySqlDbType.VarChar, 100);
            parametrosEntrada[2] = new MySqlParameter("@_guiaDevolucion", MySqlDbType.VarChar, 50);
            parametrosEntrada[3] = new MySqlParameter("@_fechaDevolucion", MySqlDbType.DateTime);
            parametrosEntrada[4] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
            parametrosEntrada[5] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[6] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
            parametrosEntrada[7] = new MySqlParameter("@_idDevolucion", MySqlDbType.Int32);

            parametrosEntrada[0].Value = devolucion.IdCliente;
            parametrosEntrada[1].Value = devolucion.RucDni;
            parametrosEntrada[2].Value = devolucion.GuiaDevolucion;
            parametrosEntrada[3].Value = devolucion.FechaDevolucion;
            parametrosEntrada[4].Value = devolucion.Observacion;
            parametrosEntrada[5].Value = 1;
            parametrosEntrada[6].Value = usuario;
            parametrosEntrada[7].Value = devolucion.IdDevolucion;

            bool okey = objManager.EjecutarProcedure(parametrosEntrada, "update_devolucion");

            if (okey)
            {

                parametrosEntrada = new MySqlParameter[1];
                parametrosEntrada[0] = new MySqlParameter("@_idDevolucion", MySqlDbType.Int32);

                parametrosEntrada[0].Value = devolucion.IdDevolucion;

                okey = objManager.EjecutarProcedure(parametrosEntrada, "delete_devolucion_detalle");

                if (okey)
                {
                    okey = InsertarDevolucionDetalle(devolucion, usuario);
                    if (okey)
                    {
                        foreach (DevolucionDetalle det in devolucion.Detalles)
                        {
                            parametrosEntrada = new MySqlParameter[4];
                            parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                            parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                            parametrosEntrada[2] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 250);
                            parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                            parametrosEntrada[0].Value = det.IdLC;
                            parametrosEntrada[1].Value = det.EstadoLC;
                            parametrosEntrada[2].Value = "ALMACEN";
                            parametrosEntrada[3].Value = usuario;

                            objManager.EjecutarProcedure(parametrosEntrada, "update_laptop_disponibilidad");


                            parametrosEntrada = new MySqlParameter[3];
                            parametrosEntrada[0] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                            parametrosEntrada[1] = new MySqlParameter("@_fueDevuelto", MySqlDbType.Int32);
                            parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                            parametrosEntrada[0].Value = det.IdSalidaDetalle;
                            parametrosEntrada[1].Value = 1;
                            parametrosEntrada[2].Value = usuario;

                            objManager.EjecutarProcedure(parametrosEntrada, "update_salida_det_devuelto");


                            if (det.Cobrar == 1)
                            {
                                parametrosEntrada = new MySqlParameter[8];
                                parametrosEntrada[0] = new MySqlParameter("@_idCliente", MySqlDbType.Int32);
                                parametrosEntrada[1] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                                parametrosEntrada[2] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                                parametrosEntrada[3] = new MySqlParameter("@_idDevolucion", MySqlDbType.Int32);
                                parametrosEntrada[4] = new MySqlParameter("@_observacionDeuda", MySqlDbType.VarChar, 255);
                                parametrosEntrada[5] = new MySqlParameter("@_KAM", MySqlDbType.VarChar, 255);
                                parametrosEntrada[6] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                                parametrosEntrada[7] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);

                                parametrosEntrada[0].Value = devolucion.IdCliente;
                                parametrosEntrada[1].Value = det.IdLC;
                                parametrosEntrada[2].Value = det.IdSalidaDetalle;
                                parametrosEntrada[3].Value = devolucion.IdDevolucion;
                                parametrosEntrada[4].Value = det.Observacion;
                                parametrosEntrada[5].Value = usuario;
                                parametrosEntrada[6].Value = 1;
                                parametrosEntrada[7].Value = usuario;

                                objManager.EjecutarProcedure(parametrosEntrada, "insert_observacion_deudas");
                            }
                        }

                    }
                }
            }
            return error;
        }


        public bool AnularDevolucion(Devolucion devolucion, string usuario)
        {

            bool error = false;

            parametrosEntrada = new MySqlParameter[4];
            parametrosEntrada[0] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
            parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
            parametrosEntrada[3] = new MySqlParameter("@_idDevolucion", MySqlDbType.Int32);

            parametrosEntrada[0].Value = devolucion.Observacion;
            parametrosEntrada[1].Value = 0;
            parametrosEntrada[2].Value = usuario;
            parametrosEntrada[3].Value = devolucion.IdDevolucion;

            bool okey = objManager.EjecutarProcedure(parametrosEntrada, "anular_devolucion");

            if (okey)
            {
                foreach (DevolucionDetalle det in devolucion.Detalles)
                {
                    parametrosEntrada = new MySqlParameter[4];
                    parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                    parametrosEntrada[2] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 250);
                    parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                    parametrosEntrada[0].Value = det.IdLC;
                    parametrosEntrada[1].Value = 4;
                    parametrosEntrada[2].Value = det.IdSucursal;
                    parametrosEntrada[3].Value = usuario;

                    objManager.EjecutarProcedure(parametrosEntrada, "update_laptop_disponibilidad");


                    parametrosEntrada = new MySqlParameter[3];
                    parametrosEntrada[0] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_fueDevuelto", MySqlDbType.Int32);
                    parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                    parametrosEntrada[0].Value = det.IdSalidaDetalle;
                    parametrosEntrada[1].Value = 0;
                    parametrosEntrada[2].Value = usuario;

                    objManager.EjecutarProcedure(parametrosEntrada, "update_salida_det_devuelto");


                    parametrosEntrada = new MySqlParameter[3];
                    parametrosEntrada[0] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
                    parametrosEntrada[2] = new MySqlParameter("@_idDevolucionDet", MySqlDbType.Int32);

                    parametrosEntrada[0].Value = 0;
                    parametrosEntrada[1].Value = usuario;
                    parametrosEntrada[2].Value = det.IdDetalle;

                    objManager.EjecutarProcedure(parametrosEntrada, "anular_devolucion_detalle");
                }

                parametrosEntrada = new MySqlParameter[1];
                parametrosEntrada[0] = new MySqlParameter("@_idDevolucion", MySqlDbType.Int32);

                parametrosEntrada[0].Value = devolucion.IdDevolucion;

                objManager.EjecutarProcedure(parametrosEntrada, "anular_devolucion_observacion_deudas");
            }
            return error;
        }


    }
}
 