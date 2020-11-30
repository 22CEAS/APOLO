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
    public class IngresoDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;
        MySqlParameter[] parametrosEntrada_aux = null;
        MySqlParameter[] parametrosEntrada_aux_2 = null;
        int IdCategoriaWindows = 12;
        int IdCategoriaOffice = 13;
        int IdCategoriaAntivirus = 14;

        private int idMarcaApple = 1;

        public IngresoDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarEstados()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM estados ; ");
        }

        public DataTable ListarDiscosDuros()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_maestro_disco ;");
        }

        public DataTable ListarProcesadores()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_maestro_procesador ;");
        }

        public DataTable ListarMemorias()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_maestro_memoria ;");
        }

        public DataTable ListarTarjetaVideos()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_maestro_video ;");
        }

        public DataTable ListarLicencias()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_maestro_licencias ;");
        }

        public DataTable ListarMarcas()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_laptops_marca ;");
        }

        public DataTable ListarModelos(int idMarca)
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_laptops_modelo where idMarca=" + idMarca + " ;");
        }

        public DataTable ListarDestinos()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_maestro_disco ;");
        }

        public DataTable ListarProveedores()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_proveedor_lista ;");
        }

        public DataTable ListarIngresoTipo()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_ingreso_tipo ;");
        }

        public DataTable ListarMonedaTipo()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_moneda_tipo ;");
        }

        public DataTable ListarIngreso(string sql)
        {
            return objManager.MostrarTablaDatos("Select * from vista_lista_ingresos v " + sql + " ;");
        }

        public int IngresosDetallesYAccesorios(Ingreso ingreso, string usuario, int idProveedor)
        {

            bool error = false;


            string[] datosSalida = new string[1];
            string[] codigoArrendamientoExistente = new string[1];
            int idLC = 0;



            if (ingreso.Detalles.Count > 0)
            {
                error = InsertarDetalleIngreso(ingreso, usuario);
                if (error) return -1;

                foreach (IngresoDetalle det in ingreso.Detalles)
                {
                    for (int i = 0; i < det.Cantidad; i++)
                    {

                        //SI EXISTE EL CODIGO, BORRAR TODOS LOS REGISTROS Y QUE LUEGO SIGA CON EL FLUJO NORMAL
                        string[] cantidadArrendamiento = new string[1];

                        parametrosEntrada_aux_2 = new MySqlParameter[3];
                        parametrosEntrada_aux_2[0] = new MySqlParameter("@_codigoLapArrendamiento", MySqlDbType.VarChar, 255);
                        parametrosEntrada_aux_2[1] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                        parametrosEntrada_aux_2[2] = new MySqlParameter("@_idLC", MySqlDbType.Int32);

                        parametrosEntrada_aux_2[0].Value = det.Series[i];


                        //! VERIFICAR DEVOLUCION DE DATOS
                        objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada_aux_2, "verificarArrendamiento",
                                            1, 3, out cantidadArrendamiento, 2);
                        int cantidadDeArrendamientos = int.Parse(cantidadArrendamiento[0]); //VERIFICA SI EXISTE EL CODIGO
                        int idLCarrendamiento = int.Parse(cantidadArrendamiento[1]); //CODIGO LC EXISTENTE
                        //MessageBox.Show(cantidadDeArrendamientos.ToString());
                        //MessageBox.Show(idLCarrendamiento.ToString());

                        string aux = "";
                        string aux2 = "";
                        int codigoCorr = 0;

                        if (ingreso.TipoIngreso == "COMPRA")
                        {
                            //SI ES COMPRA
                            //LOGICA CORRELATIVO
                            string[] codigoSiguiente = new string[2];


                            parametrosEntrada_aux = new MySqlParameter[4];
                            parametrosEntrada_aux[0] = new MySqlParameter("@_marcaLap", MySqlDbType.VarChar, 80);
                            parametrosEntrada_aux[1] = new MySqlParameter("@_idProveedor", MySqlDbType.Int32);
                            parametrosEntrada_aux[2] = new MySqlParameter("@_proximoCodigo", MySqlDbType.Int32);
                            parametrosEntrada_aux[3] = new MySqlParameter("@_prefijo", MySqlDbType.VarChar, 80);


                            //! VALIDAR SI ES UNA LAP NORMAL O UNA MAC
                            if (det.LaptopIdMarca == this.idMarcaApple) //APPLE  
                            {
                                parametrosEntrada_aux[0].Value = "PCR-MAC";
                            }
                            else
                            {
                                parametrosEntrada_aux[0].Value = "PCR-LAP";
                            }

                            parametrosEntrada_aux[1].Value = idProveedor;
                            //MessageBox.Show("ID DEL PROVEEDOR: "+idProveedor.ToString());



                            objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada_aux, "obtener_codigo_correlativo",
                                            2, 4, out codigoSiguiente, 2);

                            aux = codigoSiguiente[0]; //CODIGO
                            aux2 = codigoSiguiente[1]; //PREFIJO

                            //MessageBox.Show($"El siguiente codigo es el: {aux} {aux2}");


                            codigoCorr = int.Parse(aux);

                            if (codigoSiguiente != null)
                            {
                                //VERIFICACION
                                //MessageBox.Show("El proximo codigo es el: "+(codigoCorr+1));
                                //MessageBox.Show("El proximo prefijo es el: " + aux2);
                            }
                            //FIN LOGICA CORRELATIVO

                        }

                        //AQUI PONER PROCEDURE DE CODIGO CORRELATIVO
                        parametrosEntrada = new MySqlParameter[18];
                        parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
                        parametrosEntrada[1] = new MySqlParameter("@_idIngresoDet", MySqlDbType.Int32);
                        parametrosEntrada[2] = new MySqlParameter("@_idModelo", MySqlDbType.Int32);
                        parametrosEntrada[3] = new MySqlParameter("@_descripcion", MySqlDbType.VarChar, 250);
                        parametrosEntrada[4] = new MySqlParameter("@_tamanoPantalla", MySqlDbType.Double);
                        parametrosEntrada[5] = new MySqlParameter("@_idProcesador", MySqlDbType.Int32);
                        parametrosEntrada[6] = new MySqlParameter("@_idVideo", MySqlDbType.Int32);
                        parametrosEntrada[7] = new MySqlParameter("@_partNumber", MySqlDbType.VarChar, 80);
                        parametrosEntrada[8] = new MySqlParameter("@_serieFabrica", MySqlDbType.VarChar, 80);
                        parametrosEntrada[9] = new MySqlParameter("@_garantia", MySqlDbType.Int32);
                        parametrosEntrada[10] = new MySqlParameter("@_fecInicioSeguro", MySqlDbType.DateTime);
                        parametrosEntrada[11] = new MySqlParameter("@_fecFinSeguro", MySqlDbType.DateTime);
                        parametrosEntrada[12] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 80);
                        parametrosEntrada[13] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 255);
                        parametrosEntrada[14] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
                        parametrosEntrada[15] = new MySqlParameter("@_compraSubarriendo", MySqlDbType.Int16);
                        parametrosEntrada[16] = new MySqlParameter("@_codigo", MySqlDbType.VarChar, 80);
                        parametrosEntrada[17] = new MySqlParameter("@_idLC", MySqlDbType.Int32);

                        parametrosEntrada[0].Value = ingreso.IdIngreso;
                        parametrosEntrada[1].Value = det.IdIngresoDetalle;
                        parametrosEntrada[2].Value = det.LaptopIdModelo;
                        parametrosEntrada[3].Value = "";
                        parametrosEntrada[4].Value = det.LaptopTamanoPantalla;
                        parametrosEntrada[5].Value = det.Laptop.Procesador.IdProcesador;
                        if (det.Laptop.Video.IdVideo == 0)
                        {
                            parametrosEntrada[6].Value = null;
                        }
                        else
                        {
                            parametrosEntrada[6].Value = det.Laptop.Video.IdVideo;
                        }
                        parametrosEntrada[7].Value = det.Laptop.PartNumber;
                        parametrosEntrada[8].Value = det.Series[i];
                        parametrosEntrada[9].Value = det.Laptop.Garantia;
                        parametrosEntrada[10].Value = null;
                        parametrosEntrada[11].Value = null;
                        parametrosEntrada[12].Value = "ALMACEN";
                        parametrosEntrada[13].Value = det.Laptop.Observacion;
                        parametrosEntrada[14].Value = usuario;
                        parametrosEntrada[15].Value = ingreso.IdTipoIngreso;
                        if (ingreso.TipoIngreso == "COMPRA") //SI ES COMPRA
                        {
                            parametrosEntrada[16].Value = aux2 + (codigoCorr + 1).ToString("000");
                        }
                        else //SI ES ARRENDAMIENTO GUARDA LO QUE ELLOS HAN INGRESADO
                        {
                            //MessageBox.Show(det.Series[i]);
                            parametrosEntrada[16].Value = det.Series[i];
                        }


                        datosSalida = new string[1];



                        //cantidadDeArrendamientos
                        if (ingreso.TipoIngreso == "COMPRA")
                        {
                            objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_laptop_cpu",
                                17, 18, out datosSalida, 1);
                            idLC = Convert.ToInt32(datosSalida[0]);
                        }
                        else
                        {
                            if (cantidadDeArrendamientos == 0)
                            {
                                objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_laptop_cpu",
                                17, 18, out datosSalida, 1);
                                idLC = Convert.ToInt32(datosSalida[0]);
                            }
                            else
                            {
                                idLC = idLCarrendamiento;
                            }
                        }



                        if (datosSalida != null)
                        {

                            foreach (Memoria mem in det.Laptop.Memorias)
                            {
                                parametrosEntrada = new MySqlParameter[5];
                                parametrosEntrada[0] = new MySqlParameter("@_idMemoria", MySqlDbType.Int32);
                                parametrosEntrada[1] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                                parametrosEntrada[2] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                                parametrosEntrada[3] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
                                parametrosEntrada[4] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);

                                parametrosEntrada[0].Value = mem.IdMemoria;
                                parametrosEntrada[1].Value = idLC;
                                parametrosEntrada[2].Value = mem.Cantidad;
                                parametrosEntrada[3].Value = ingreso.IdIngreso;
                                parametrosEntrada[4].Value = usuario;

                                bool okey = objManager.EjecutarProcedure(parametrosEntrada, "insert_memoria_LC_ingreso");
                            }

                            foreach (DiscoDuro disco in det.Laptop.Discos)
                            {
                                parametrosEntrada = new MySqlParameter[5];
                                parametrosEntrada[0] = new MySqlParameter("@_idDisco", MySqlDbType.Int32);
                                parametrosEntrada[1] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                                parametrosEntrada[2] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                                parametrosEntrada[3] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
                                parametrosEntrada[4] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);

                                parametrosEntrada[0].Value = disco.IdDisco;
                                parametrosEntrada[1].Value = idLC;
                                parametrosEntrada[2].Value = disco.Cantidad;
                                parametrosEntrada[3].Value = ingreso.IdIngreso;
                                parametrosEntrada[4].Value = usuario;

                                bool okey = objManager.EjecutarProcedure(parametrosEntrada, "insert_disco_LC_ingreso");
                            }


                            foreach (Licencia licencia in det.Laptop.Licencias)
                            {
                                parametrosEntrada = new MySqlParameter[9];
                                parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
                                parametrosEntrada[1] = new MySqlParameter("@_idIngresoDet", MySqlDbType.Int32);
                                parametrosEntrada[2] = new MySqlParameter("@_idModelo", MySqlDbType.Int32);
                                parametrosEntrada[3] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                                parametrosEntrada[4] = new MySqlParameter("@_clave", MySqlDbType.VarChar, 80);
                                parametrosEntrada[5] = new MySqlParameter("@_fechaActivacion", MySqlDbType.DateTime);
                                parametrosEntrada[6] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 80);
                                parametrosEntrada[7] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 80);
                                parametrosEntrada[8] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 80);

                                parametrosEntrada[0].Value = ingreso.IdIngreso;
                                parametrosEntrada[1].Value = 1;//Id=1 es idIngresoDet Id=2 es idIngresoDetAccesorios
                                parametrosEntrada[2].Value = licencia.IdModelo;
                                parametrosEntrada[3].Value = idLC;
                                if (licencia.IdCategoria == IdCategoriaWindows)
                                {
                                    parametrosEntrada[4].Value = det.Windows[i];
                                }
                                else if (licencia.IdCategoria == IdCategoriaOffice)
                                {
                                    parametrosEntrada[4].Value = det.Office[i];
                                }
                                else if (licencia.IdCategoria == IdCategoriaAntivirus)
                                {
                                    parametrosEntrada[4].Value = det.Antivirus[i];
                                }

                                parametrosEntrada[5].Value = ingreso.FechaIngreso;
                                parametrosEntrada[6].Value = "ALMACEN";
                                parametrosEntrada[7].Value = licencia.Observacion;
                                parametrosEntrada[8].Value = usuario;

                                bool okey = objManager.EjecutarProcedure(parametrosEntrada, "insert_licencia_det");

                            }
                        }
                    }
                }

            }
            if (ingreso.Discos.Count > 0 || ingreso.Memorias.Count > 0 || ingreso.Licencias.Count > 0)
            {
                error = InsertarDetalleAccesoriosIngreso(ingreso, usuario);
                if (error) return -1;

                foreach (DiscoDuro disco in ingreso.Discos)
                {
                    parametrosEntrada = new MySqlParameter[2];
                    parametrosEntrada[0] = new MySqlParameter("@_idDisco", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);

                    parametrosEntrada[0].Value = disco.IdDisco;
                    parametrosEntrada[1].Value = disco.Cantidad;

                    bool okey = objManager.EjecutarProcedure(parametrosEntrada, "update_disco_cantidad");
                }

                foreach (Memoria memoria in ingreso.Memorias)
                {
                    parametrosEntrada = new MySqlParameter[2];
                    parametrosEntrada[0] = new MySqlParameter("@_idMemoria", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);

                    parametrosEntrada[0].Value = memoria.IdMemoria;
                    parametrosEntrada[1].Value = memoria.Cantidad;

                    bool okey = objManager.EjecutarProcedure(parametrosEntrada, "update_memoria_cantidad");
                }

                foreach (Licencia licencia in ingreso.Licencias)
                {
                    for (int i = 0; i < licencia.Cantidad; i++)
                    {
                        parametrosEntrada = new MySqlParameter[9];
                        parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
                        parametrosEntrada[1] = new MySqlParameter("@_idIngresoDetAccesorios", MySqlDbType.Int32);
                        parametrosEntrada[2] = new MySqlParameter("@_idModelo", MySqlDbType.Int32);
                        parametrosEntrada[3] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                        parametrosEntrada[4] = new MySqlParameter("@_clave", MySqlDbType.VarChar, 80);
                        parametrosEntrada[5] = new MySqlParameter("@_fechaActivacion", MySqlDbType.DateTime);
                        parametrosEntrada[6] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 80);
                        parametrosEntrada[7] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 80);
                        parametrosEntrada[8] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 80);

                        parametrosEntrada[0].Value = ingreso.IdIngreso;
                        parametrosEntrada[1].Value = 2;//Id=1 es idIngresoDet Id=2 es idIngresoDetAccesorios
                        parametrosEntrada[2].Value = licencia.IdModelo;
                        parametrosEntrada[3].Value = null;
                        parametrosEntrada[4].Value = licencia.Clave;
                        parametrosEntrada[5].Value = null;
                        parametrosEntrada[6].Value = "ALMACEN";
                        parametrosEntrada[7].Value = licencia.Observacion;
                        parametrosEntrada[8].Value = usuario;

                        bool okey = objManager.EjecutarProcedure(parametrosEntrada, "insert_licencia_det_accesorios");
                    }
                }
            }

            return 0;
        }

        public int InsertarIngreso(Ingreso ingreso, string usuario)
        {

            bool error = false;

            parametrosEntrada = new MySqlParameter[17];
            parametrosEntrada[0] = new MySqlParameter("@_idOC", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_idTipoIngreso", MySqlDbType.Int32);
            parametrosEntrada[2] = new MySqlParameter("@_tipoIngreso", MySqlDbType.VarChar, 255);
            parametrosEntrada[3] = new MySqlParameter("@_idProveedor", MySqlDbType.Int32);
            parametrosEntrada[4] = new MySqlParameter("@_razonSocial", MySqlDbType.VarChar, 255);
            parametrosEntrada[5] = new MySqlParameter("@_ruc", MySqlDbType.VarChar, 11);
            parametrosEntrada[6] = new MySqlParameter("@_facturaIngreso", MySqlDbType.VarChar, 255);
            parametrosEntrada[7] = new MySqlParameter("@_guiaIngreso", MySqlDbType.VarChar, 255);
            parametrosEntrada[8] = new MySqlParameter("@_fecIngresa", MySqlDbType.DateTime);
            parametrosEntrada[9] = new MySqlParameter("@_idTipoMoneda", MySqlDbType.Int32);
            parametrosEntrada[10] = new MySqlParameter("@_tipoMoneda", MySqlDbType.VarChar, 255);
            parametrosEntrada[11] = new MySqlParameter("@_montoCambio", MySqlDbType.Double);
            parametrosEntrada[12] = new MySqlParameter("@_total", MySqlDbType.Double);
            parametrosEntrada[13] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
            parametrosEntrada[14] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[15] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
            parametrosEntrada[16] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);

            parametrosEntrada[0].Value = 0;
            parametrosEntrada[1].Value = ingreso.IdTipoIngreso;
            parametrosEntrada[2].Value = ingreso.TipoIngreso;
            parametrosEntrada[3].Value = ingreso.IdProveedor;
            parametrosEntrada[4].Value = ingreso.RazonSocial;
            parametrosEntrada[5].Value = ingreso.Ruc;
            parametrosEntrada[6].Value = ingreso.Factura;
            parametrosEntrada[7].Value = ingreso.Guia;
            parametrosEntrada[8].Value = ingreso.FechaIngreso;
            parametrosEntrada[9].Value = ingreso.IdMonedaTipo;
            parametrosEntrada[10].Value = ingreso.MonedaTipo;
            parametrosEntrada[11].Value = ingreso.MontoCambio;
            parametrosEntrada[12].Value = ingreso.Total;
            parametrosEntrada[13].Value = ingreso.Observacion;
            parametrosEntrada[14].Value = ingreso.Estado;
            parametrosEntrada[15].Value = usuario;

            string[] datosSalida = new string[1];

            objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_ingreso",
                16, 17, out datosSalida, 1);

            if (datosSalida != null)
            {
                ingreso.IdIngreso = Convert.ToInt32(datosSalida[0]);

                //Aqui ira la recursividad

                //! AQUI PASAR TAMBIEN SI EL PCR-LAP O MAC
                if (IngresosDetallesYAccesorios(ingreso, usuario, ingreso.IdProveedor) == -1) return -1;
            }
            return ingreso.IdIngreso;
        }

        public bool InsertarDetalleIngreso(Ingreso ingreso, string usuario)
        {
            foreach (IngresoDetalle det in ingreso.Detalles)
            {
                parametrosEntrada = new MySqlParameter[28];
                parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idMarcaLC", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_idModeloLC", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_partNumber", MySqlDbType.VarChar, 255);
                parametrosEntrada[4] = new MySqlParameter("@_pantalla", MySqlDbType.Double);
                parametrosEntrada[5] = new MySqlParameter("@_garantia", MySqlDbType.Int32);
                parametrosEntrada[6] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                parametrosEntrada[7] = new MySqlParameter("@_subTotal", MySqlDbType.Double);
                parametrosEntrada[8] = new MySqlParameter("@_idProcesador", MySqlDbType.Int32);
                parametrosEntrada[9] = new MySqlParameter("@_idVideo", MySqlDbType.Int32);
                parametrosEntrada[10] = new MySqlParameter("@_idDisco1", MySqlDbType.Int32);
                parametrosEntrada[11] = new MySqlParameter("@_cantidadDisco1", MySqlDbType.Int32);
                parametrosEntrada[12] = new MySqlParameter("@_idDisco2", MySqlDbType.Int32);
                parametrosEntrada[13] = new MySqlParameter("@_cantidadDisco2", MySqlDbType.Int32);
                parametrosEntrada[14] = new MySqlParameter("@_idMemoria1", MySqlDbType.Int32);
                parametrosEntrada[15] = new MySqlParameter("@_cantidadMemoria1", MySqlDbType.Int32);
                parametrosEntrada[16] = new MySqlParameter("@_idMemoria2", MySqlDbType.Int32);
                parametrosEntrada[17] = new MySqlParameter("@_cantidadMemoria2", MySqlDbType.Int32);
                parametrosEntrada[18] = new MySqlParameter("@_idMemoria3", MySqlDbType.Int32);
                parametrosEntrada[19] = new MySqlParameter("@_cantidadMemoria3", MySqlDbType.Int32);
                parametrosEntrada[20] = new MySqlParameter("@_idModeloWindows", MySqlDbType.Int32);
                parametrosEntrada[21] = new MySqlParameter("@_idModeloOffice", MySqlDbType.Int32);
                parametrosEntrada[22] = new MySqlParameter("@_idModeloAntivirus", MySqlDbType.Int32);
                parametrosEntrada[23] = new MySqlParameter("@_caracteristicas", MySqlDbType.VarChar, 100);
                parametrosEntrada[24] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
                parametrosEntrada[25] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[26] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
                parametrosEntrada[27] = new MySqlParameter("@_idIngresoDet", MySqlDbType.Int32);


                parametrosEntrada[0].Value = ingreso.IdIngreso;
                parametrosEntrada[1].Value = det.LaptopIdMarca; //MessageBox.Show(parametrosEntrada[1].Value.ToString());
                parametrosEntrada[2].Value = det.LaptopIdModelo;
                parametrosEntrada[3].Value = det.Laptop.PartNumber;
                parametrosEntrada[4].Value = det.LaptopTamanoPantalla;
                parametrosEntrada[5].Value = det.Laptop.Garantia;
                parametrosEntrada[6].Value = det.Cantidad;
                parametrosEntrada[7].Value = det.Precio;
                parametrosEntrada[8].Value = det.Laptop.IdProcesador;
                parametrosEntrada[9].Value = det.Laptop.IdVideo;
                int cantDiscos = det.Laptop.Discos.Count;
                if (cantDiscos == 1)
                {
                    parametrosEntrada[10].Value = det.Laptop.Discos[0].IdDisco;
                    parametrosEntrada[11].Value = det.Laptop.Discos[0].Cantidad;
                    parametrosEntrada[12].Value = 0;
                    parametrosEntrada[13].Value = 0;
                }
                else if (cantDiscos == 2)
                {
                    parametrosEntrada[10].Value = det.Laptop.Discos[0].IdDisco;
                    parametrosEntrada[11].Value = det.Laptop.Discos[0].Cantidad;
                    parametrosEntrada[12].Value = det.Laptop.Discos[1].IdDisco;
                    parametrosEntrada[13].Value = det.Laptop.Discos[1].Cantidad;
                }

                int cantMemorias = det.Laptop.Memorias.Count;
                if (cantMemorias == 1)
                {
                    parametrosEntrada[14].Value = det.Laptop.Memorias[0].IdMemoria;
                    parametrosEntrada[15].Value = det.Laptop.Memorias[0].Cantidad;
                    parametrosEntrada[16].Value = 0;
                    parametrosEntrada[17].Value = 0;
                    parametrosEntrada[18].Value = 0;
                    parametrosEntrada[19].Value = 0;
                }
                else if (cantMemorias == 2)
                {
                    parametrosEntrada[14].Value = det.Laptop.Memorias[0].IdMemoria;
                    parametrosEntrada[15].Value = det.Laptop.Memorias[0].Cantidad;
                    parametrosEntrada[16].Value = det.Laptop.Memorias[1].IdMemoria;
                    parametrosEntrada[17].Value = det.Laptop.Memorias[1].Cantidad;
                    parametrosEntrada[18].Value = 0;
                    parametrosEntrada[19].Value = 0;
                }
                else if (cantMemorias == 3)
                {
                    parametrosEntrada[14].Value = det.Laptop.Memorias[0].IdMemoria;
                    parametrosEntrada[15].Value = det.Laptop.Memorias[0].Cantidad;
                    parametrosEntrada[16].Value = det.Laptop.Memorias[1].IdMemoria;
                    parametrosEntrada[17].Value = det.Laptop.Memorias[1].Cantidad;
                    parametrosEntrada[18].Value = det.Laptop.Memorias[2].IdMemoria;
                    parametrosEntrada[19].Value = det.Laptop.Memorias[2].Cantidad;
                }
                int idWin = -1;
                int idOff = -1;
                int idAnt = -1;
                for (int i = 0; i < det.Laptop.Licencias.Count; i++)
                {
                    if (det.Laptop.Licencias[i].IdCategoria == IdCategoriaWindows)
                        idWin = det.Laptop.Licencias[i].IdModelo;
                    else if (det.Laptop.Licencias[i].IdCategoria == IdCategoriaOffice)
                        idOff = det.Laptop.Licencias[i].IdModelo;
                    else if (det.Laptop.Licencias[i].IdCategoria == IdCategoriaAntivirus)
                        idAnt = det.Laptop.Licencias[i].IdModelo;
                }
                parametrosEntrada[20].Value = (idWin == -1) ? 0 : idWin;
                parametrosEntrada[21].Value = (idOff == -1) ? 0 : idOff;
                parametrosEntrada[22].Value = (idAnt == -1) ? 0 : idAnt;
                parametrosEntrada[23].Value = det.Caracteristica;
                parametrosEntrada[24].Value = det.Observacion;
                parametrosEntrada[25].Value = det.Estado;
                parametrosEntrada[26].Value = usuario;

                string[] datosSalida = new string[1];

                objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_ingreso_det",
                27, 28, out datosSalida, 1);
                if (datosSalida == null)
                {
                    return true;
                }
                det.IdIngresoDetalle = Convert.ToInt32(datosSalida[0]);
            }
            return false;
        }

        public bool InsertarDetalleAccesoriosIngreso(Ingreso ingreso, string usuario)
        {
            foreach (Licencia det in ingreso.Licencias)
            {
                parametrosEntrada = new MySqlParameter[12];
                parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idCategoria", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_idModeloLicencia", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_clave", MySqlDbType.VarChar, 255);
                parametrosEntrada[4] = new MySqlParameter("@_idDisco", MySqlDbType.Int32);
                parametrosEntrada[5] = new MySqlParameter("@_idMemoria", MySqlDbType.Int32);
                parametrosEntrada[6] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                parametrosEntrada[7] = new MySqlParameter("@_subTotal", MySqlDbType.Double);
                parametrosEntrada[8] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
                parametrosEntrada[9] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[10] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
                parametrosEntrada[11] = new MySqlParameter("@_idIngresoDetAccesorios", MySqlDbType.Int32);


                parametrosEntrada[0].Value = ingreso.IdIngreso;
                parametrosEntrada[1].Value = det.IdCategoria;
                parametrosEntrada[2].Value = det.IdModelo;
                parametrosEntrada[3].Value = det.Clave;
                parametrosEntrada[4].Value = 0;
                parametrosEntrada[5].Value = 0;
                parametrosEntrada[6].Value = det.Cantidad;
                parametrosEntrada[7].Value = det.Precio;
                parametrosEntrada[8].Value = det.Observacion;
                parametrosEntrada[9].Value = 1;
                parametrosEntrada[10].Value = usuario;

                string[] datosSalida = new string[1];

                objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_ingreso_det_accesorios",
                11, 12, out datosSalida, 1);
                if (datosSalida == null)
                {
                    return true;
                }
            }

            foreach (DiscoDuro det in ingreso.Discos)
            {
                parametrosEntrada = new MySqlParameter[12];
                parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idCategoria", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_idModeloLicencia", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_clave", MySqlDbType.VarChar, 255);
                parametrosEntrada[4] = new MySqlParameter("@_idDisco", MySqlDbType.Int32);
                parametrosEntrada[5] = new MySqlParameter("@_idMemoria", MySqlDbType.Int32);
                parametrosEntrada[6] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                parametrosEntrada[7] = new MySqlParameter("@_subTotal", MySqlDbType.Double);
                parametrosEntrada[8] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
                parametrosEntrada[9] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[10] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
                parametrosEntrada[11] = new MySqlParameter("@_idIngresoDetAccesorios", MySqlDbType.Int32);


                parametrosEntrada[0].Value = ingreso.IdIngreso;
                parametrosEntrada[1].Value = 0;
                parametrosEntrada[2].Value = 0;
                parametrosEntrada[3].Value = "";
                parametrosEntrada[4].Value = det.IdDisco;
                parametrosEntrada[5].Value = 0;
                parametrosEntrada[6].Value = det.Cantidad;
                parametrosEntrada[7].Value = det.Precio;
                parametrosEntrada[8].Value = det.Observacion;
                parametrosEntrada[9].Value = 1;
                parametrosEntrada[10].Value = usuario;

                string[] datosSalida = new string[1];

                objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_ingreso_det_accesorios",
                11, 12, out datosSalida, 1);
                if (datosSalida == null)
                {
                    return true;
                }
            }

            foreach (Memoria det in ingreso.Memorias)
            {
                parametrosEntrada = new MySqlParameter[12];
                parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idCategoria", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_idModeloLicencia", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_clave", MySqlDbType.VarChar, 255);
                parametrosEntrada[4] = new MySqlParameter("@_idDisco", MySqlDbType.Int32);
                parametrosEntrada[5] = new MySqlParameter("@_idMemoria", MySqlDbType.Int32);
                parametrosEntrada[6] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                parametrosEntrada[7] = new MySqlParameter("@_subTotal", MySqlDbType.Double);
                parametrosEntrada[8] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
                parametrosEntrada[9] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[10] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
                parametrosEntrada[11] = new MySqlParameter("@_idIngresoDetAccesorios", MySqlDbType.Int32);


                parametrosEntrada[0].Value = ingreso.IdIngreso;
                parametrosEntrada[1].Value = 0;
                parametrosEntrada[2].Value = 0;
                parametrosEntrada[3].Value = "";
                parametrosEntrada[4].Value = 0;
                parametrosEntrada[5].Value = det.IdMemoria;
                parametrosEntrada[6].Value = det.Cantidad;
                parametrosEntrada[7].Value = det.Precio;
                parametrosEntrada[8].Value = det.Observacion;
                parametrosEntrada[9].Value = 1;
                parametrosEntrada[10].Value = usuario;

                string[] datosSalida = new string[1];

                objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_ingreso_det_accesorios",
                11, 12, out datosSalida, 1);
                if (datosSalida == null)
                {
                    return true;
                }
            }
            return false;
        }

        public int ModificarIngreso(Ingreso ingreso, string usuario)
        {
            bool okey;
            //========================Todo lo que tiene que ver con la tabla ingreso detalle===================
            parametrosEntrada = new MySqlParameter[1];
            parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
            parametrosEntrada[0].Value = ingreso.IdIngreso;
            okey = objManager.EjecutarProcedure(parametrosEntrada, "delete_disco_LC_ingreso");


            parametrosEntrada = new MySqlParameter[1];
            parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
            parametrosEntrada[0].Value = ingreso.IdIngreso;
            okey = objManager.EjecutarProcedure(parametrosEntrada, "delete_memoria_LC_ingreso");


            parametrosEntrada = new MySqlParameter[1];
            parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
            parametrosEntrada[0].Value = ingreso.IdIngreso;
            okey = objManager.EjecutarProcedure(parametrosEntrada, "delete_licencia_LC_ingreso");


            parametrosEntrada = new MySqlParameter[1];
            parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
            parametrosEntrada[0].Value = ingreso.IdIngreso;
            okey = objManager.EjecutarProcedure(parametrosEntrada, "delete_LC_ingreso");


            parametrosEntrada = new MySqlParameter[1];
            parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
            parametrosEntrada[0].Value = ingreso.IdIngreso;
            okey = objManager.EjecutarProcedure(parametrosEntrada, "delete_det_ingreso");

            //=================Todo lo que tiene que ver con la tabla ingreso detalle accesorio===================

            foreach (Memoria mem in ingreso.Memorias)
            {
                parametrosEntrada = new MySqlParameter[2];
                parametrosEntrada[0] = new MySqlParameter("@_idMemoria", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                parametrosEntrada[0].Value = mem.IdMemoria;
                parametrosEntrada[1].Value = mem.Cantidad;
                okey = objManager.EjecutarProcedure(parametrosEntrada, "update_memoria_cantidad_menos");
            }

            foreach (DiscoDuro disco in ingreso.Discos)
            {
                parametrosEntrada = new MySqlParameter[2];
                parametrosEntrada[0] = new MySqlParameter("@_idDisco", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                parametrosEntrada[0].Value = disco.IdDisco;
                parametrosEntrada[1].Value = disco.Cantidad;
                okey = objManager.EjecutarProcedure(parametrosEntrada, "update_disco_cantidad_menos");
            }

            parametrosEntrada = new MySqlParameter[1];
            parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
            parametrosEntrada[0].Value = ingreso.IdIngreso;
            okey = objManager.EjecutarProcedure(parametrosEntrada, "delete_det_accesorios_ingreso");


            //========================Se modificara el ingreso=========================


            parametrosEntrada = new MySqlParameter[17];
            parametrosEntrada[0] = new MySqlParameter("@_idOC", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_idTipoIngreso", MySqlDbType.Int32);
            parametrosEntrada[2] = new MySqlParameter("@_tipoIngreso", MySqlDbType.VarChar, 255);
            parametrosEntrada[3] = new MySqlParameter("@_idProveedor", MySqlDbType.Int32);
            parametrosEntrada[4] = new MySqlParameter("@_razonSocial", MySqlDbType.VarChar, 255);
            parametrosEntrada[5] = new MySqlParameter("@_ruc", MySqlDbType.VarChar, 11);
            parametrosEntrada[6] = new MySqlParameter("@_facturaIngreso", MySqlDbType.VarChar, 255);
            parametrosEntrada[7] = new MySqlParameter("@_guiaIngreso", MySqlDbType.VarChar, 255);
            parametrosEntrada[8] = new MySqlParameter("@_fecIngresa", MySqlDbType.DateTime);
            parametrosEntrada[9] = new MySqlParameter("@_idTipoMoneda", MySqlDbType.Int32);
            parametrosEntrada[10] = new MySqlParameter("@_tipoMoneda", MySqlDbType.VarChar, 255);
            parametrosEntrada[11] = new MySqlParameter("@_montoCambio", MySqlDbType.Double);
            parametrosEntrada[12] = new MySqlParameter("@_total", MySqlDbType.Double);
            parametrosEntrada[13] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
            parametrosEntrada[14] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[15] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
            parametrosEntrada[16] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);

            parametrosEntrada[0].Value = 0;
            parametrosEntrada[1].Value = ingreso.IdTipoIngreso;
            parametrosEntrada[2].Value = ingreso.TipoIngreso;
            parametrosEntrada[3].Value = ingreso.IdProveedor;
            parametrosEntrada[4].Value = ingreso.RazonSocial;
            parametrosEntrada[5].Value = ingreso.Ruc;
            parametrosEntrada[6].Value = ingreso.Factura;
            parametrosEntrada[7].Value = ingreso.Guia;
            parametrosEntrada[8].Value = ingreso.FechaIngreso;
            parametrosEntrada[9].Value = ingreso.IdMonedaTipo;
            parametrosEntrada[10].Value = ingreso.MonedaTipo;
            parametrosEntrada[11].Value = ingreso.MontoCambio;
            parametrosEntrada[12].Value = ingreso.Total;
            parametrosEntrada[13].Value = ingreso.Observacion;
            parametrosEntrada[14].Value = ingreso.Estado;
            parametrosEntrada[15].Value = usuario;
            parametrosEntrada[16].Value = ingreso.IdIngreso;

            okey = objManager.EjecutarProcedure(parametrosEntrada, "update_ingreso");

            //Aqui ira la recursividad
            if (IngresosDetallesYAccesorios(ingreso, usuario, ingreso.IdProveedor) == -1) return -1;

            return 0;
        }

        public int AnularIngreso(Ingreso ingreso, string usuario)
        {
            bool okey;

            parametrosEntrada = new MySqlParameter[4];
            parametrosEntrada[0] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
            parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
            parametrosEntrada[3] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);

            parametrosEntrada[0].Value = ingreso.Observacion;
            parametrosEntrada[1].Value = ingreso.Estado;
            parametrosEntrada[2].Value = usuario;
            parametrosEntrada[3].Value = ingreso.IdIngreso;
            okey = objManager.EjecutarProcedure(parametrosEntrada, "anular_ingreso");
            if (!okey) return -1;

            //========================Todo lo que tiene que ver con la tabla ingreso detalle===================

            parametrosEntrada = new MySqlParameter[1];
            parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
            parametrosEntrada[0].Value = ingreso.IdIngreso;
            okey = objManager.EjecutarProcedure(parametrosEntrada, "delete_disco_LC_ingreso");
            if (!okey) return -1;


            parametrosEntrada = new MySqlParameter[1];
            parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
            parametrosEntrada[0].Value = ingreso.IdIngreso;
            okey = objManager.EjecutarProcedure(parametrosEntrada, "delete_memoria_LC_ingreso");
            if (!okey) return -1;


            parametrosEntrada = new MySqlParameter[1];
            parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
            parametrosEntrada[0].Value = ingreso.IdIngreso;
            okey = objManager.EjecutarProcedure(parametrosEntrada, "delete_licencia_LC_ingreso");
            if (!okey) return -1;


            parametrosEntrada = new MySqlParameter[1];
            parametrosEntrada[0] = new MySqlParameter("@_idIngreso", MySqlDbType.Int32);
            parametrosEntrada[0].Value = ingreso.IdIngreso;
            okey = objManager.EjecutarProcedure(parametrosEntrada, "delete_LC_ingreso");
            if (!okey) return -1;


            //=================Todo lo que tiene que ver con la tabla ingreso detalle accesorio===================

            foreach (Memoria mem in ingreso.Memorias)
            {
                parametrosEntrada = new MySqlParameter[2];
                parametrosEntrada[0] = new MySqlParameter("@_idMemoria", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                parametrosEntrada[0].Value = mem.IdMemoria;
                parametrosEntrada[1].Value = mem.Cantidad;
                okey = objManager.EjecutarProcedure(parametrosEntrada, "update_memoria_cantidad_menos");
                if (!okey) return -1;
            }

            foreach (DiscoDuro disco in ingreso.Discos)
            {
                parametrosEntrada = new MySqlParameter[2];
                parametrosEntrada[0] = new MySqlParameter("@_idDisco", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                parametrosEntrada[0].Value = disco.IdDisco;
                parametrosEntrada[1].Value = disco.Cantidad;
                okey = objManager.EjecutarProcedure(parametrosEntrada, "update_disco_cantidad_menos");
                if (!okey) return -1;
            }

            return 0;
        }

        public Ingreso LlamarIngresoModificable(int idIngreso)
        {
            Ingreso ingresoDevuelto = new Ingreso();
            MySqlDataReader reader;
            string sql = "";
            MySqlDataReader reader2;
            string sql2 = "";

            //==========================Este bloque es para llenar solo ingreso=================================

            sql = "Select * From ingreso where idIngreso=" + idIngreso + " ;";
            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                ingresoDevuelto.IdIngreso = reader.GetInt32("idIngreso");
                ingresoDevuelto.IdTipoIngreso = reader.GetInt32("idTipoIngreso");
                ingresoDevuelto.TipoIngreso = reader.GetString("tipoIngreso");
                ingresoDevuelto.IdProveedor = reader.GetInt32("idProveedor");
                ingresoDevuelto.Ruc = reader.GetString("ruc");
                ingresoDevuelto.RazonSocial = reader.GetString("razonSocial");
                ingresoDevuelto.Factura = reader.GetString("facturaIngreso");
                ingresoDevuelto.Guia = reader.GetString("guiaIngreso");
                ingresoDevuelto.FechaIngreso = reader.GetDateTime("fecIngresa");
                ingresoDevuelto.IdMonedaTipo = reader.GetInt32("idTipoMoneda");
                ingresoDevuelto.MonedaTipo = reader.GetString("tipoMoneda");
                ingresoDevuelto.MontoCambio = reader.GetDouble("montoCambio");
                ingresoDevuelto.Total = reader.GetDouble("total");
                ingresoDevuelto.Observacion = reader.GetString("observacion");
                ingresoDevuelto.Estado = reader.GetInt32("estado");
                ingresoDevuelto.UsuarioRegistro.Nombre = reader.GetString("usuario_ins");
            }

            objManager.conexion.Close();
            objManager.conexion.Dispose();
            objManager.cmd.Dispose();

            //==========================Este bloque es para llenar lo que es detalle de ingreso====================

            sql = "SELECT * FROM vista_ingresos_detalles_modificable where idIngreso = " + idIngreso + " ;";
            reader = objManager.MostrarInformacion(sql);


            int idDetallesIngresos = 1;
            while (reader.Read())
            {
                IngresoDetalle det = new IngresoDetalle();

                det.LaptopMarcaLC = reader.GetString("nombreMarca");
                det.LaptopNombreModeloLC = reader.GetString("nombreModelo");
                det.LaptopTipoProcesador = reader.GetString("tipoProcesador");
                det.Laptop.Procesador.Generacion = reader.GetInt32("generacionProcesador");

                det.IdIngresoDetalle = reader.GetInt32("idIngresoDet");
                det.Laptop.IdMarca = reader.GetInt32("idMarcaLC");
                det.Laptop.IdModelo = reader.GetInt32("idModeloLC");
                det.Laptop.PartNumber = reader.GetString("partNumber");
                det.Laptop.TamanoPantalla = reader.GetDouble("pantalla");
                det.Laptop.Garantia = reader.GetInt32("garantia");
                det.Cantidad = reader.GetInt32("cantidad");
                det.Precio = reader.GetInt32("subTotal");
                det.Laptop.Procesador.IdProcesador = reader.GetInt32("idProcesador");
                if (reader.GetInt32("idVideo") != 0)
                {
                    det.Laptop.Video.IdVideo = reader.GetInt32("idVideo");
                    det.LaptopNombreModeloVideo = reader.GetString("modeloVideo");
                    det.Laptop.Video.Capacidad = reader.GetInt32("capacidadVideo");
                }
                if (reader.GetInt32("idDisco1") != 0)
                {
                    DiscoDuro disco = new DiscoDuro();
                    disco.IdDisco = reader.GetInt32("idDisco1");
                    disco.Cantidad = reader.GetInt32("cantidadDisco1");
                    disco.Capacidad = reader.GetInt32("CapacidadDisco1");
                    disco.TipoDisco = reader.GetString("TipoDisco1");
                    disco.Tamano = reader.GetString("TamanoDisco1");
                    det.Laptop.Discos.Add(disco);
                }
                if (reader.GetInt32("idDisco2") != 0)
                {
                    DiscoDuro disco = new DiscoDuro();
                    disco.IdDisco = reader.GetInt32("idDisco2");
                    disco.Cantidad = reader.GetInt32("cantidadDisco2");
                    disco.Capacidad = reader.GetInt32("CapacidadDisco2");
                    disco.TipoDisco = reader.GetString("TipoDisco2");
                    disco.Tamano = reader.GetString("TamanoDisco2");
                    det.Laptop.Discos.Add(disco);
                }
                if (reader.GetInt32("idMemoria1") != 0)
                {
                    Memoria memoria = new Memoria();
                    memoria.IdMemoria = reader.GetInt32("idMemoria1");
                    memoria.Cantidad = reader.GetInt32("cantidadMemoria1");
                    memoria.Capacidad = reader.GetInt32("CapacidadMemoria1");
                    memoria.TipoMemoria = reader.GetString("TipoMemoria1");
                    memoria.Tipo = reader.GetString("Tipo2Memoria1");
                    det.Laptop.Memorias.Add(memoria);
                }
                if (reader.GetInt32("idMemoria2") != 0)
                {
                    Memoria memoria = new Memoria();
                    memoria.IdMemoria = reader.GetInt32("idMemoria2");
                    memoria.Cantidad = reader.GetInt32("cantidadMemoria2");
                    memoria.Capacidad = reader.GetInt32("CapacidadMemoria2");
                    memoria.TipoMemoria = reader.GetString("TipoMemoria2");
                    memoria.Tipo = reader.GetString("Tipo2Memoria2");
                    det.Laptop.Memorias.Add(memoria);
                }
                if (reader.GetInt32("idMemoria3") != 0)
                {
                    Memoria memoria = new Memoria();
                    memoria.IdMemoria = reader.GetInt32("idMemoria3");
                    memoria.Cantidad = reader.GetInt32("cantidadMemoria3");
                    memoria.Capacidad = reader.GetInt32("CapacidadMemoria3");
                    memoria.TipoMemoria = reader.GetString("TipoMemoria3");
                    memoria.Tipo = reader.GetString("Tipo2Memoria3");
                    det.Laptop.Memorias.Add(memoria);
                }

                if (reader.GetInt32("idModeloWindows") != 0)
                {
                    Licencia licencia = new Licencia();
                    licencia.IdCategoria = IdCategoriaWindows;
                    licencia.IdModelo = reader.GetInt32("idModeloWindows");
                    licencia.Version = reader.GetString("ModeloWindows");
                    licencia.Categoria = reader.GetString("CategoriaWindows");
                    det.Laptop.Licencias.Add(licencia);
                }
                if (reader.GetInt32("idModeloOffice") != 0)
                {
                    Licencia licencia = new Licencia();
                    licencia.IdCategoria = IdCategoriaOffice;
                    licencia.IdModelo = reader.GetInt32("idModeloOffice");
                    licencia.Version = reader.GetString("ModeloOffice");
                    licencia.Categoria = reader.GetString("CategoriaOffice");
                    det.Laptop.Licencias.Add(licencia);
                }
                if (reader.GetInt32("idModeloAntivirus") != 0)
                {
                    Licencia licencia = new Licencia();
                    licencia.IdCategoria = IdCategoriaAntivirus;
                    licencia.IdModelo = reader.GetInt32("idModeloAntivirus");
                    licencia.Version = reader.GetString("ModeloAntivirus");
                    licencia.Categoria = reader.GetString("CategoriaAntivirus");
                    det.Laptop.Licencias.Add(licencia);
                }
                det.Caracteristica = reader.GetString("caracteristicas");
                det.Observacion = reader.GetString("observacion");
                det.Estado = reader.GetInt32("estado");


                sql2 = "Select * From laptop_cpu where idIngreso=" + ingresoDevuelto.IdIngreso + " and  idIngresoDet=" + det.IdIngresoDetalle + " ;";
                reader2 = objManager.MostrarInformacion(sql2);

                BindingList<LC> listaLaptops = new BindingList<LC>();

                while (reader2.Read())
                {
                    LC lap = new LC();
                    String serieFabrica = reader2.GetString("serieFabrica");
                    lap.IdLC = reader2.GetInt32("idLC");
                    listaLaptops.Add(lap);
                    det.Series.Add(serieFabrica);
                }

                foreach (LC lap in listaLaptops)
                {
                    sql2 = "Select * From vista_licencia_ingresos where idIngreso=" + ingresoDevuelto.IdIngreso + " and  idIngresoDet=1 and  idLC=" + lap.IdLC + " ;";
                    reader2 = objManager.MostrarInformacion(sql2);

                    while (reader2.Read())
                    {
                        if (reader2.GetInt32("IdCategoria") == IdCategoriaWindows)
                        {
                            String window = reader2.GetString("Clave");
                            det.Windows.Add(window);
                        }
                        if (reader2.GetInt32("IdCategoria") == IdCategoriaOffice)
                        {
                            String office = reader2.GetString("Clave");
                            det.Office.Add(office);
                        }
                        if (reader2.GetInt32("IdCategoria") == IdCategoriaAntivirus)
                        {
                            String antivirus = reader2.GetString("Clave");
                            det.Antivirus.Add(antivirus);
                        }
                    }
                }
                det.IdIngresoDetalle = idDetallesIngresos;
                idDetallesIngresos++;
                ingresoDevuelto.Detalles.Add(det);
            }

            objManager.conexion.Close();
            objManager.conexion.Dispose();
            objManager.cmd.Dispose();

            //==========================Este bloque es para llenar lo que es detalle accesorio de ingreso====================


            sql = "SELECT * FROM vista_ingresos_detalles_accesorios_modificable WHERE idIngreso = " + idIngreso + " ;";
            reader = objManager.MostrarInformacion(sql);

            int idLicencias = 1;
            while (reader.Read())
            {
                Licencia licenciaIndependiente = new Licencia();
                DiscoDuro discoIndependiente = new DiscoDuro();
                Memoria memoriaIndependiente = new Memoria();

                if (reader.GetInt32("idModeloLicencia") != 0)
                {
                    licenciaIndependiente.IdModelo = reader.GetInt32("idModeloLicencia");
                    licenciaIndependiente.Clave = reader.GetString("clave");
                    licenciaIndependiente.Cantidad = reader.GetInt32("cantidad");
                    licenciaIndependiente.Precio = reader.GetDouble("subTotal");
                    licenciaIndependiente.IdCategoria = reader.GetInt32("IdCategoriaLicencia");
                    licenciaIndependiente.Categoria = reader.GetString("Categoria");
                    licenciaIndependiente.Marca = reader.GetString("Marca");
                    licenciaIndependiente.Version = reader.GetString("Version");
                    licenciaIndependiente.IdLicencia = idLicencias;
                    idLicencias++;
                    ingresoDevuelto.Licencias.Add(licenciaIndependiente);
                }
                else if (reader.GetInt32("idDisco") != 0)
                {
                    discoIndependiente.IdDisco = reader.GetInt32("idDisco");
                    discoIndependiente.Cantidad = reader.GetInt32("cantidad");
                    discoIndependiente.Precio = reader.GetDouble("subTotal");
                    discoIndependiente.TipoDisco = reader.GetString("TipoDisco");
                    discoIndependiente.Tamano = reader.GetString("TamanoDisco");
                    discoIndependiente.Capacidad = reader.GetInt32("CapacidadDisco");
                    ingresoDevuelto.Discos.Add(discoIndependiente);
                }
                else if (reader.GetInt32("idMemoria") != 0)
                {
                    memoriaIndependiente.IdMemoria = reader.GetInt32("idMemoria");
                    memoriaIndependiente.Cantidad = reader.GetInt32("cantidad");
                    memoriaIndependiente.Precio = reader.GetDouble("subTotal");
                    memoriaIndependiente.TipoMemoria = reader.GetString("TipoMemoria");
                    memoriaIndependiente.Tipo = reader.GetString("Tipo2");
                    memoriaIndependiente.Capacidad = reader.GetInt32("CapacidadMemoria");
                    ingresoDevuelto.Memorias.Add(memoriaIndependiente);
                }

            }

            return ingresoDevuelto;
        }

    }
}
