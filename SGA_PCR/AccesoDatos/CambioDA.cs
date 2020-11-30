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
    public class CambioDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public CambioDA()
        {
            objManager = new DBManager();
        }

        public DataTable DatosLaptopPorCambiar(string codigoLC)
        {
            return objManager.MostrarTablaDatos("Select * from vista_datos_laptop_por_cambiar where CodigoLCAntiguo='" + codigoLC + "' ;");
        }

        public DataTable ListarEstados()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM estados ; ");
        }

        public DataTable ListarCambio(string sql)
        {
            return objManager.MostrarTablaDatos("Select * from vista_lista_cambios v " + sql + " ;");
        }

        public bool InsertarAlquilerDetalle(Cambio cambio, string usuario)
        {
            bool error = false;
            parametrosEntrada = new MySqlParameter[23];
            parametrosEntrada[0] = new MySqlParameter("@_idSalida", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
            parametrosEntrada[2] = new MySqlParameter("@_idProcesador", MySqlDbType.Int32);
            parametrosEntrada[3] = new MySqlParameter("@_idVideo", MySqlDbType.Int32);
            parametrosEntrada[4] = new MySqlParameter("@_idDisco1", MySqlDbType.Int32);
            parametrosEntrada[5] = new MySqlParameter("@_cantidadDisco1", MySqlDbType.Int32);
            parametrosEntrada[6] = new MySqlParameter("@_idDisco2", MySqlDbType.Int32);
            parametrosEntrada[7] = new MySqlParameter("@_cantidadDisco2", MySqlDbType.Int32);
            parametrosEntrada[8] = new MySqlParameter("@_idMemoria1", MySqlDbType.Int32);
            parametrosEntrada[9] = new MySqlParameter("@_cantidadMemoria1", MySqlDbType.Int32);
            parametrosEntrada[10] = new MySqlParameter("@_idMemoria2", MySqlDbType.Int32);
            parametrosEntrada[11] = new MySqlParameter("@_cantidadMemoria2", MySqlDbType.Int32);
            parametrosEntrada[12] = new MySqlParameter("@_idWindows", MySqlDbType.Int32);
            parametrosEntrada[13] = new MySqlParameter("@_idOffice", MySqlDbType.Int32);
            parametrosEntrada[14] = new MySqlParameter("@_idAntivirus", MySqlDbType.Int32);
            parametrosEntrada[15] = new MySqlParameter("@_caracteristicas", MySqlDbType.VarChar, 100);
            parametrosEntrada[16] = new MySqlParameter("@_guiaSalida", MySqlDbType.VarChar, 100);
            parametrosEntrada[17] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
            parametrosEntrada[18] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[19] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
            parametrosEntrada[20] = new MySqlParameter("@_fecIniContrato", MySqlDbType.Datetime);
            parametrosEntrada[21] = new MySqlParameter("@_fecFinContrato", MySqlDbType.Datetime);
            parametrosEntrada[22] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);

            parametrosEntrada[0].Value = cambio.IdSalida;
            parametrosEntrada[1].Value = cambio.LaptopNuevo.IdLC;
            parametrosEntrada[2].Value = cambio.LaptopNuevo.Procesador.IdProcesador;
            parametrosEntrada[3].Value = cambio.LaptopNuevo.Video.IdVideo;
            parametrosEntrada[4].Value = 0;
            parametrosEntrada[5].Value = 0;
            parametrosEntrada[6].Value = 0;
            parametrosEntrada[7].Value = 0;
            parametrosEntrada[8].Value = 0;
            parametrosEntrada[9].Value = 0;
            parametrosEntrada[10].Value = 0;
            parametrosEntrada[11].Value = 0;
            parametrosEntrada[12].Value = 0;
            parametrosEntrada[13].Value = 0;
            parametrosEntrada[14].Value = 0;
            parametrosEntrada[15].Value = cambio.IdCambio;
            parametrosEntrada[16].Value = cambio.GuiaCambio;
            parametrosEntrada[17].Value = cambio.CodigoLCAntiguo;
            parametrosEntrada[18].Value = 4;
            parametrosEntrada[19].Value = usuario;
            parametrosEntrada[20].Value = cambio.FechaIniContrato;
            parametrosEntrada[21].Value = cambio.FechaFinContrato;

            string[] datosSalida = new string[1];
            objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_salida_det",
                22, 23, out datosSalida, 1);

            if (datosSalida != null)
            {
                int idSalidaDet = Convert.ToInt32(datosSalida[0]);
                parametrosEntrada = new MySqlParameter[4];
                parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 250);
                parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                parametrosEntrada[0].Value = cambio.LaptopNuevo.IdLC;
                parametrosEntrada[1].Value = 4;
                parametrosEntrada[2].Value = cambio.IdSucursal;
                parametrosEntrada[3].Value = usuario;

                objManager.EjecutarProcedure(parametrosEntrada, "update_laptop_disponibilidad");
                error = true;
            }
            else
            {
                error = false;
            }

            return error;
        }

        public int InsertarCambio(Cambio cambio, string usuario)
        {

            bool error = false;

            parametrosEntrada = new MySqlParameter[23];
            parametrosEntrada[0] = new MySqlParameter("@_idLCAntiguo", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_codigoLCAntiguo", MySqlDbType.VarChar, 80);
            parametrosEntrada[2] = new MySqlParameter("@_estadoLCAntiguo", MySqlDbType.Int32);
            parametrosEntrada[3] = new MySqlParameter("@_idCliente", MySqlDbType.Int32);
            parametrosEntrada[4] = new MySqlParameter("@_nombreCliente", MySqlDbType.VarChar, 255);
            parametrosEntrada[5] = new MySqlParameter("@_rucDni", MySqlDbType.VarChar, 11);
            parametrosEntrada[6] = new MySqlParameter("@_guiaCambio", MySqlDbType.VarChar, 50);
            parametrosEntrada[7] = new MySqlParameter("@_fechaCambio", MySqlDbType.DateTime);
            parametrosEntrada[8] = new MySqlParameter("@_ticketTecnico", MySqlDbType.VarChar, 255);
            parametrosEntrada[9] = new MySqlParameter("@_idLCNuevo", MySqlDbType.Int32);
            parametrosEntrada[10] = new MySqlParameter("@_codigoLCNuevo", MySqlDbType.VarChar, 80);
            parametrosEntrada[11] = new MySqlParameter("@_fueDevuelto", MySqlDbType.Int32);
            parametrosEntrada[12] = new MySqlParameter("@_pagaraCliente", MySqlDbType.Int32);
            parametrosEntrada[13] = new MySqlParameter("@_danoLC", MySqlDbType.Int32);
            parametrosEntrada[14] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
            parametrosEntrada[15] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[16] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
            parametrosEntrada[17] = new MySqlParameter("@_idSalida", MySqlDbType.Int32);
            parametrosEntrada[18] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
            parametrosEntrada[19] = new MySqlParameter("@_idSucursal", MySqlDbType.Int32);
            parametrosEntrada[20] = new MySqlParameter("@_fecIniContrato", MySqlDbType.DateTime);
            parametrosEntrada[21] = new MySqlParameter("@_fecFinContrato", MySqlDbType.DateTime);
            parametrosEntrada[22] = new MySqlParameter("@_idCambio", MySqlDbType.Int32);

            parametrosEntrada[0].Value = cambio.IdLCAntiguo;
            parametrosEntrada[1].Value = cambio.CodigoLCAntiguo;
            parametrosEntrada[2].Value = cambio.EstadoLCAntiguo;
            parametrosEntrada[3].Value = cambio.IdCliente;
            parametrosEntrada[4].Value = cambio.NombreCliente;
            parametrosEntrada[5].Value = cambio.RucDni;
            parametrosEntrada[6].Value = cambio.GuiaCambio;
            parametrosEntrada[7].Value = cambio.FechaCambio;
            parametrosEntrada[8].Value = cambio.TicketTecnico;
            parametrosEntrada[9].Value = cambio.LaptopNuevo.IdLC;
            parametrosEntrada[10].Value = cambio.LaptopNuevo.Codigo;
            parametrosEntrada[11].Value = cambio.FueDevuelto;
            parametrosEntrada[12].Value = cambio.PagaraCliente;
            parametrosEntrada[13].Value = cambio.DanoLC;
            parametrosEntrada[14].Value = cambio.Observacion;
            parametrosEntrada[15].Value = 1;
            parametrosEntrada[16].Value = usuario;
            parametrosEntrada[17].Value = cambio.IdSalida;
            parametrosEntrada[18].Value = cambio.IdSalidaDet;
            parametrosEntrada[19].Value = cambio.IdSucursal;
            parametrosEntrada[20].Value = cambio.FechaIniContrato;
            parametrosEntrada[21].Value = cambio.FechaFinContrato;

            string[] datosSalida = new string[1];

            objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_cambio",
                22, 23, out datosSalida, 1);

            if (datosSalida != null)
            {
                cambio.IdCambio = Convert.ToInt32(datosSalida[0]);

                bool aux=InsertarAlquilerDetalle(cambio,usuario);
                if (!aux) return-1;


                parametrosEntrada = new MySqlParameter[3];
                parametrosEntrada[0] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_estadoDet", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                parametrosEntrada[0].Value = cambio.IdSalidaDet;
                parametrosEntrada[1].Value = 9;
                parametrosEntrada[2].Value = usuario;

                objManager.EjecutarProcedure(parametrosEntrada, "update_salida_det_estado_cambiado");

                if (cambio.FueDevuelto == 1)
                {

                    parametrosEntrada = new MySqlParameter[4];
                    parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                    parametrosEntrada[2] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 250);
                    parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                    parametrosEntrada[0].Value = cambio.IdLCAntiguo;
                    parametrosEntrada[1].Value = cambio.EstadoLCAntiguo;
                    parametrosEntrada[2].Value = "ALMACEN";
                    parametrosEntrada[3].Value = usuario;

                    objManager.EjecutarProcedure(parametrosEntrada, "update_laptop_disponibilidad");


                    parametrosEntrada = new MySqlParameter[3];
                    parametrosEntrada[0] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_fueDevuelto", MySqlDbType.Int32);
                    parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                    parametrosEntrada[0].Value = cambio.IdSalidaDet;
                    parametrosEntrada[1].Value = 1;
                    parametrosEntrada[2].Value = usuario;

                    objManager.EjecutarProcedure(parametrosEntrada, "update_salida_det_devuelto");

                }
                else
                {

                    parametrosEntrada = new MySqlParameter[3];
                    parametrosEntrada[0] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_fueDevuelto", MySqlDbType.Int32);
                    parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                    parametrosEntrada[0].Value = cambio.IdSalidaDet;
                    parametrosEntrada[1].Value = 0;
                    parametrosEntrada[2].Value = usuario;

                    objManager.EjecutarProcedure(parametrosEntrada, "update_salida_det_devuelto");
                }

                if (cambio.PagaraCliente == 1)
                {
                    parametrosEntrada = new MySqlParameter[8];
                    parametrosEntrada[0] = new MySqlParameter("@_idCliente", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                    parametrosEntrada[2] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                    parametrosEntrada[3] = new MySqlParameter("@_idCambio", MySqlDbType.Int32);
                    parametrosEntrada[4] = new MySqlParameter("@_observacionDeuda", MySqlDbType.VarChar, 255);
                    parametrosEntrada[5] = new MySqlParameter("@_KAM", MySqlDbType.VarChar, 255);
                    parametrosEntrada[6] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                    parametrosEntrada[7] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);

                    parametrosEntrada[0].Value = cambio.IdCliente;
                    parametrosEntrada[1].Value = cambio.IdLCAntiguo;
                    parametrosEntrada[2].Value = cambio.IdSalidaDet;
                    parametrosEntrada[3].Value = cambio.IdCambio;
                    parametrosEntrada[4].Value = cambio.Observacion;
                    parametrosEntrada[5].Value = usuario;
                    parametrosEntrada[6].Value = 1;
                    parametrosEntrada[7].Value = usuario;

                    objManager.EjecutarProcedure(parametrosEntrada, "insert_observacion_deudas_cambio");
                }

                

            }
            return cambio.IdCambio;
        }


        public Cambio LlamarCambioModificable(int idCambio)
        {
            Cambio cambio = new Cambio();
            MySqlDataReader reader;
            string sql = "";

            sql = "Select * From cambio where idCambio=" + idCambio + " ;";
            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                cambio.IdCambio = reader.GetInt32("idCambio");
                cambio.IdSalida = reader.GetInt32("idSalida");
                cambio.IdSalidaDet = reader.GetInt32("idSalidaDet");
                cambio.IdLCAntiguo = reader.GetInt32("idLCAntiguo");
                cambio.CodigoLCAntiguo = reader.GetString("codigoLCAntiguo");
                cambio.EstadoLCAntiguo = reader.GetInt32("estadoLCAntiguo");
                cambio.IdCliente = reader.GetInt32("idCliente");
                cambio.IdSucursal = reader.GetInt32("idSucursal");
                cambio.NombreCliente = reader.GetString("nombreCliente");
                cambio.RucDni = reader.GetString("rucDni");
                cambio.GuiaCambio = reader.GetString("GuiaCambio");
                cambio.FechaCambio = reader.GetDateTime("fechaCambio");
                cambio.TicketTecnico = reader.GetString("ticketTecnico");
                cambio.LaptopNuevo.IdLC = reader.GetInt32("idLCNuevo");
                cambio.LaptopNuevo.Codigo = reader.GetString("codigoLCNuevo");
                cambio.FueDevuelto = reader.GetInt32("fueDevuelto");
                cambio.PagaraCliente = reader.GetInt32("pagaraCliente");
                cambio.DanoLC = reader.GetInt32("danoLC");
                cambio.Observacion = reader.GetString("observacion");
                cambio.Estado = reader.GetInt32("estado");
                cambio.FechaIniContrato = reader.GetDateTime("fecIniContrato");
                cambio.FechaFinContrato = reader.GetDateTime("fecFinContrato");
            }

            objManager.conexion.Close();  objManager.conexion.Dispose(); objManager.cmd.Dispose();

            sql = "";

            sql = "Select * From vista_maestro_laptops where idLC=" + cambio.LaptopNuevo.IdLC + " ;";
            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                cambio.LaptopNuevo.Video.IdVideo = reader.GetInt32("idVideo");
                cambio.LaptopNuevo.Procesador.IdProcesador = reader.GetInt32("idProcesador");
                cambio.LaptopNuevo.Modelo.NombreMarca = reader.GetString("marca");
                cambio.LaptopNuevo.Modelo.NombreModelo = reader.GetString("nombreModelo");
                cambio.LaptopNuevo.TamanoPantalla = reader.GetDouble("tamanoPantalla");

            }

            objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();

            sql = "";

            sql = "Select * From vista_maestro_procesador where idProcesador=" + cambio.LaptopNuevo.Procesador.IdProcesador + " ;";
            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                cambio.LaptopNuevo.Procesador.Modelo.NombreModelo = reader.GetString("tipo");
                cambio.LaptopNuevo.Procesador.Generacion = reader.GetInt32("generacion");
            }

            objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();

            sql = "";

            sql = "Select * From vista_maestro_video where idVideo=" + cambio.LaptopNuevo.Video.IdVideo + " ;";
            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                cambio.LaptopNuevo.Video.Modelo.NombreModelo = reader.GetString("nombreModelo");
                cambio.LaptopNuevo.Video.Capacidad = reader.GetInt32("capacidad");
            }

            objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();

            return cambio;
        }


        public bool ModificarCambio(Cambio cambio, string usuario, Cambio cambioOld)
        {

            bool error = false;

            parametrosEntrada = new MySqlParameter[1];
            parametrosEntrada[0] = new MySqlParameter("@_idCambio", MySqlDbType.Int32);

            parametrosEntrada[0].Value = cambioOld.IdCambio;

            error = objManager.EjecutarProcedure(parametrosEntrada, "delete_salida_detalle_idDetalle");


            parametrosEntrada = new MySqlParameter[3];
            parametrosEntrada[0] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_estadoDet", MySqlDbType.Int32);
            parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

            parametrosEntrada[0].Value = cambioOld.IdSalidaDet;
            parametrosEntrada[1].Value = 4;
            parametrosEntrada[2].Value = usuario;

            objManager.EjecutarProcedure(parametrosEntrada, "update_salida_det_estado_cambiado");


            parametrosEntrada = new MySqlParameter[4];
            parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[2] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 250);
            parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

            parametrosEntrada[0].Value = cambioOld.IdLCAntiguo;
            parametrosEntrada[1].Value = 4;
            parametrosEntrada[2].Value = cambioOld.IdSucursal;
            parametrosEntrada[3].Value = usuario;

            objManager.EjecutarProcedure(parametrosEntrada, "update_laptop_disponibilidad");


            parametrosEntrada = new MySqlParameter[3];
            parametrosEntrada[0] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_fueDevuelto", MySqlDbType.Int32);
            parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

            parametrosEntrada[0].Value = cambioOld.IdSalidaDet;
            parametrosEntrada[1].Value = 0;
            parametrosEntrada[2].Value = usuario;

            objManager.EjecutarProcedure(parametrosEntrada, "update_salida_det_devuelto");



            parametrosEntrada = new MySqlParameter[1];
            parametrosEntrada[0] = new MySqlParameter("@_idCambio", MySqlDbType.Int32);

            parametrosEntrada[0].Value = cambioOld.IdCambio;

            objManager.EjecutarProcedure(parametrosEntrada, "delete_observacion_deudas_cambio");

            
            parametrosEntrada = new MySqlParameter[23];
            parametrosEntrada[0] = new MySqlParameter("@_idLCAntiguo", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_codigoLCAntiguo", MySqlDbType.VarChar, 80);
            parametrosEntrada[2] = new MySqlParameter("@_estadoLCAntiguo", MySqlDbType.Int32);
            parametrosEntrada[3] = new MySqlParameter("@_idCliente", MySqlDbType.Int32);
            parametrosEntrada[4] = new MySqlParameter("@_nombreCliente", MySqlDbType.VarChar, 255);
            parametrosEntrada[5] = new MySqlParameter("@_rucDni", MySqlDbType.VarChar, 11);
            parametrosEntrada[6] = new MySqlParameter("@_guiaCambio", MySqlDbType.VarChar, 50);
            parametrosEntrada[7] = new MySqlParameter("@_fechaCambio", MySqlDbType.DateTime);
            parametrosEntrada[8] = new MySqlParameter("@_ticketTecnico", MySqlDbType.VarChar, 255);
            parametrosEntrada[9] = new MySqlParameter("@_idLCNuevo", MySqlDbType.Int32);
            parametrosEntrada[10] = new MySqlParameter("@_codigoLCNuevo", MySqlDbType.VarChar, 80);
            parametrosEntrada[11] = new MySqlParameter("@_fueDevuelto", MySqlDbType.Int32);
            parametrosEntrada[12] = new MySqlParameter("@_pagaraCliente", MySqlDbType.Int32);
            parametrosEntrada[13] = new MySqlParameter("@_danoLC", MySqlDbType.Int32);
            parametrosEntrada[14] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
            parametrosEntrada[15] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[16] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
            parametrosEntrada[17] = new MySqlParameter("@_idSalida", MySqlDbType.Int32);
            parametrosEntrada[18] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
            parametrosEntrada[19] = new MySqlParameter("@_idSucursal", MySqlDbType.Int32);
            parametrosEntrada[20] = new MySqlParameter("@_idCambio", MySqlDbType.Int32);
            parametrosEntrada[21] = new MySqlParameter("@_fecIniContrato", MySqlDbType.DateTime);
            parametrosEntrada[22] = new MySqlParameter("@_fecFinContrato", MySqlDbType.DateTime);

            parametrosEntrada[0].Value = cambio.IdLCAntiguo;
            parametrosEntrada[1].Value = cambio.CodigoLCAntiguo;
            parametrosEntrada[2].Value = cambio.EstadoLCAntiguo;
            parametrosEntrada[3].Value = cambio.IdCliente;
            parametrosEntrada[4].Value = cambio.NombreCliente;
            parametrosEntrada[5].Value = cambio.RucDni;
            parametrosEntrada[6].Value = cambio.GuiaCambio;
            parametrosEntrada[7].Value = cambio.FechaCambio;
            parametrosEntrada[8].Value = cambio.TicketTecnico;
            parametrosEntrada[9].Value = cambio.LaptopNuevo.IdLC;
            parametrosEntrada[10].Value = cambio.LaptopNuevo.Codigo;
            parametrosEntrada[11].Value = cambio.FueDevuelto;
            parametrosEntrada[12].Value = cambio.PagaraCliente;
            parametrosEntrada[13].Value = cambio.DanoLC;
            parametrosEntrada[14].Value = cambio.Observacion;
            parametrosEntrada[15].Value = 1;
            parametrosEntrada[16].Value = usuario;
            parametrosEntrada[17].Value = cambio.IdSalida;
            parametrosEntrada[18].Value = cambio.IdSalidaDet;
            parametrosEntrada[19].Value = cambio.IdSucursal;
            parametrosEntrada[20].Value = cambio.IdCambio;
            parametrosEntrada[21].Value = cambio.FechaIniContrato;
            parametrosEntrada[22].Value = cambio.FechaFinContrato;

            bool okey = objManager.EjecutarProcedure(parametrosEntrada, "update_cambio");

            if (okey)
            {
                

                bool aux = InsertarAlquilerDetalle(cambio, usuario);
                if (!aux) return aux;


                parametrosEntrada = new MySqlParameter[3];
                parametrosEntrada[0] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_estadoDet", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                parametrosEntrada[0].Value = cambio.IdSalidaDet;
                parametrosEntrada[1].Value = 9;
                parametrosEntrada[2].Value = usuario;

                objManager.EjecutarProcedure(parametrosEntrada, "update_salida_det_estado_cambiado");

                if (cambio.FueDevuelto == 1)
                {

                    parametrosEntrada = new MySqlParameter[4];
                    parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                    parametrosEntrada[2] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 250);
                    parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                    parametrosEntrada[0].Value = cambio.IdLCAntiguo;
                    parametrosEntrada[1].Value = cambio.EstadoLCAntiguo;
                    parametrosEntrada[2].Value = "ALMACEN";
                    parametrosEntrada[3].Value = usuario;

                    objManager.EjecutarProcedure(parametrosEntrada, "update_laptop_disponibilidad");


                    parametrosEntrada = new MySqlParameter[3];
                    parametrosEntrada[0] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_fueDevuelto", MySqlDbType.Int32);
                    parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                    parametrosEntrada[0].Value = cambio.IdSalidaDet;
                    parametrosEntrada[1].Value = 1;
                    parametrosEntrada[2].Value = usuario;

                    objManager.EjecutarProcedure(parametrosEntrada, "update_salida_det_devuelto");

                }
                else
                {

                    parametrosEntrada = new MySqlParameter[3];
                    parametrosEntrada[0] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_fueDevuelto", MySqlDbType.Int32);
                    parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                    parametrosEntrada[0].Value = cambio.IdSalidaDet;
                    parametrosEntrada[1].Value = 0;
                    parametrosEntrada[2].Value = usuario;

                    objManager.EjecutarProcedure(parametrosEntrada, "update_salida_det_devuelto");
                }

                if (cambio.PagaraCliente == 1)
                {
                    parametrosEntrada = new MySqlParameter[8];
                    parametrosEntrada[0] = new MySqlParameter("@_idCliente", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                    parametrosEntrada[2] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                    parametrosEntrada[3] = new MySqlParameter("@_idCambio", MySqlDbType.Int32);
                    parametrosEntrada[4] = new MySqlParameter("@_observacionDeuda", MySqlDbType.VarChar, 255);
                    parametrosEntrada[5] = new MySqlParameter("@_KAM", MySqlDbType.VarChar, 255);
                    parametrosEntrada[6] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                    parametrosEntrada[7] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);

                    parametrosEntrada[0].Value = cambio.IdCliente;
                    parametrosEntrada[1].Value = cambio.IdLCAntiguo;
                    parametrosEntrada[2].Value = cambio.IdSalidaDet;
                    parametrosEntrada[3].Value = cambio.IdCambio;
                    parametrosEntrada[4].Value = cambio.Observacion;
                    parametrosEntrada[5].Value = usuario;
                    parametrosEntrada[6].Value = 1;
                    parametrosEntrada[7].Value = usuario;

                    objManager.EjecutarProcedure(parametrosEntrada, "insert_observacion_deudas_cambio");
                }

            }
            return error;
        }

        public bool AnularCambio(Cambio cambio, string usuario)
        {

            bool error = false;

            parametrosEntrada = new MySqlParameter[4];
            parametrosEntrada[0] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
            parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
            parametrosEntrada[3] = new MySqlParameter("@_idCambio", MySqlDbType.Int32);

            parametrosEntrada[0].Value = cambio.Observacion;
            parametrosEntrada[1].Value = 0;
            parametrosEntrada[2].Value = usuario;
            parametrosEntrada[3].Value = cambio.IdCambio;

            bool okey = objManager.EjecutarProcedure(parametrosEntrada, "anular_cambio");

            if (okey)
            {

                parametrosEntrada = new MySqlParameter[1];
                parametrosEntrada[0] = new MySqlParameter("@_idCambio", MySqlDbType.Int32);

                parametrosEntrada[0].Value = cambio.IdCambio;

                error = objManager.EjecutarProcedure(parametrosEntrada, "delete_salida_detalle_idDetalle");


                parametrosEntrada = new MySqlParameter[3];
                parametrosEntrada[0] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_estadoDet", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                parametrosEntrada[0].Value = cambio.IdSalidaDet;
                parametrosEntrada[1].Value = 4;
                parametrosEntrada[2].Value = usuario;

                objManager.EjecutarProcedure(parametrosEntrada, "update_salida_det_estado_cambiado");


                parametrosEntrada = new MySqlParameter[4];
                parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 250);
                parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                parametrosEntrada[0].Value = cambio.IdLCAntiguo;
                parametrosEntrada[1].Value = 4;
                parametrosEntrada[2].Value = cambio.IdSucursal;
                parametrosEntrada[3].Value = usuario;

                objManager.EjecutarProcedure(parametrosEntrada, "update_laptop_disponibilidad");


                parametrosEntrada = new MySqlParameter[3];
                parametrosEntrada[0] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_fueDevuelto", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                parametrosEntrada[0].Value = cambio.IdSalidaDet;
                parametrosEntrada[1].Value = 0;
                parametrosEntrada[2].Value = usuario;

                objManager.EjecutarProcedure(parametrosEntrada, "update_salida_det_devuelto");



                parametrosEntrada = new MySqlParameter[1];
                parametrosEntrada[0] = new MySqlParameter("@_idCambio", MySqlDbType.Int32);

                parametrosEntrada[0].Value = cambio.IdCambio;

                objManager.EjecutarProcedure(parametrosEntrada, "delete_observacion_deudas_cambio");

            }
            return error;
        }


    }
}
