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
    public class AlquilerDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        private string licenciaCategoriaSO = "S.O";
        private string licenciaCategoriaOffice = "OFFICE";
        private string licenciaCategoriaAntivirus = "ANTIVIRUS";

        public AlquilerDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarLaptopsAlmacenSinMemoriaDisco()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_laptops_almacen_lista ;");
        }
        public DataTable ListarMemoriasConStock()
        {
            return objManager.MostrarTablaDatos("Select * from vista_stockDisponible_memoria_libre;");
        }
        public DataTable ListarMemoriasConSinStock()
        {
            return objManager.MostrarTablaDatos("Select * from vista_ConSinstockDisponible_memoria_libre;");
        }
        public DataTable ListarDiscosConStock()
        {
            return objManager.MostrarTablaDatos("Select * from vista_stockDisponible_disco_libre;");
        }
        public DataTable ListarDiscosConSinStock()
        {
            return objManager.MostrarTablaDatos("Select * from vista_ConSinstockDisponible_disco_libre;");
        }
        public DataTable ListarLicenciasConStock()
        {
            return objManager.MostrarTablaDatos("Select * from vista_stockDisponible_licencia_libre;");
        }
        public DataTable ListarLaptopDisco(int idLC)
        {
            return objManager.MostrarTablaDatos("Select * from vista_laptops_discos where idLC=" + idLC + " ;");
        }
        public DataTable ListarLaptopMemoria(int idLC)
        {
            return objManager.MostrarTablaDatos("Select * from vista_laptops_memorias where idLC=" + idLC + " ;");
        }
        public DataTable ListarLaptopLicencia(int idLC)
        {
            return objManager.MostrarTablaDatos("Select * from vista_licencia_lc_lista where idLC=" + idLC+" ;");
        }

        public DataTable ListarEstados()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM estados ; ");
        }

        public DataTable ListarAlquiler(string sql)
        {
            return objManager.MostrarTablaDatos("Select * from vista_lista_alquileres v " + sql + " ;");
        }

        public bool ActualizarLaptopMemoria(int idLC, BindingList<Memoria> memorias, string usuario)
        {
            string sql = "SET autocommit=0;";
            bool commit = objManager.EjecutarNonQuery(sql);
            objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();
            bool error = false;

            if (commit)
            {

                sql = "Select * From memoria_LC where idLC=" + idLC + " ;";
                MySqlDataReader reader;
                reader = objManager.MostrarInformacion(sql);
                BindingList<Memoria> memoriasAux = new BindingList<Memoria>();
                while (reader.Read())
                {
                    Memoria memoria = new Memoria();
                    memoria.IdMemoria = reader.GetInt32("idMemoria");
                    memoria.Cantidad = reader.GetInt32("cantidad");
                    memoriasAux.Add(memoria);
                }
                if ((reader.HasRows))
                {
                    parametrosEntrada = new MySqlParameter[1];
                    parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                    parametrosEntrada[0].Value = idLC;
                    error = objManager.EjecutarProcedure(parametrosEntrada, "delete_memoria_LC");
                    if (!error)
                    {
                        sql = "ROLLBACk;";
                        commit = objManager.EjecutarNonQuery(sql);
                        objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();
                        return error;
                    }
                    foreach (Memoria m in memoriasAux)
                    {
                        int _idMemoria = m.IdMemoria;
                        int _cantidad = m.Cantidad;

                        parametrosEntrada = new MySqlParameter[2];
                        parametrosEntrada[0] = new MySqlParameter("@_idMemoria", MySqlDbType.Int32);
                        parametrosEntrada[1] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                        parametrosEntrada[0].Value = _idMemoria;
                        parametrosEntrada[1].Value = _cantidad;
                        error = objManager.EjecutarProcedure(parametrosEntrada, "update_memoria_cantidad");
                        if (!error)
                        {
                            sql = "ROLLBACk;";
                            commit = objManager.EjecutarNonQuery(sql);
                            objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();
                            return error;
                        }
                    }
                }
                objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();

                foreach (Memoria m in memorias)
                {
                    parametrosEntrada = new MySqlParameter[4];
                    parametrosEntrada[0] = new MySqlParameter("@_idMemoria", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                    parametrosEntrada[2] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                    parametrosEntrada[3] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);

                    parametrosEntrada[0].Value = m.IdMemoria;
                    parametrosEntrada[1].Value = idLC;
                    parametrosEntrada[2].Value = m.Cantidad;
                    parametrosEntrada[3].Value = usuario;

                    error = objManager.EjecutarProcedure(parametrosEntrada, "insert_memoria_LC");
                    if (!error)
                    {
                        sql = "ROLLBACk;";
                        commit = objManager.EjecutarNonQuery(sql);
                        objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();
                        return error;
                    }
                }
            }
            sql = "COMMIT; SET autocommit=1;";
            commit = objManager.EjecutarNonQuery(sql);
            objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();
            return true;
        }
        
        public int ValidarCantidadLaptopMemoria(int idLC, BindingList<Memoria> memorias)
        {
            foreach(Memoria mem in memorias)
            {
                int sumaCant = 0;
                string sql = "";

                sql = "Select me.cantidad as Cantidad From memoria me where me.idMemoria=" + mem.IdMemoria + " ;";
                MySqlDataReader reader;
                reader = objManager.MostrarInformacion(sql);
                while (reader.Read())
                {
                    sumaCant += reader.GetInt32("Cantidad");
                }

                sql = "Select mlc.cantidad as Cantidad From memoria_lc mlc where mlc.IdMemoria=" + mem.IdMemoria + " and mlc.idLC=" + idLC+ " ;";
                reader = objManager.MostrarInformacion(sql);
                while (reader.Read())
                {
                    sumaCant += reader.GetInt32("Cantidad");
                }
                if (mem.Cantidad > sumaCant) return -1;
            }
            return 0;
        }
        
        public bool InsertarLaptopMemoriasPrimeraVez(int idLC, BindingList<Memoria> memorias, string usuario)
        {

            bool error = false;

            foreach (Memoria m in memorias)
            {
                parametrosEntrada = new MySqlParameter[4];
                parametrosEntrada[0] = new MySqlParameter("@_idMemoria", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);

                parametrosEntrada[0].Value = m.IdMemoria;
                parametrosEntrada[1].Value = idLC;
                parametrosEntrada[2].Value = m.Cantidad;
                parametrosEntrada[3].Value = usuario;

                error = objManager.EjecutarProcedure(parametrosEntrada, "insert_memoria_LC");
            }
            return error;
        }

        public bool ActualizarLaptopDisco(int idLC, BindingList<DiscoDuro> discos, string usuario)
        {
            string sql = "SET autocommit=0;";
            bool commit = objManager.EjecutarNonQuery(sql);
            objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();
            bool error = false;

            if (commit)
            {

                sql = "Select * From disco_LC where idLC=" + idLC + " ;";
                MySqlDataReader reader;
                reader = objManager.MostrarInformacion(sql);
                BindingList<DiscoDuro> discosAux = new BindingList<DiscoDuro>();
                while (reader.Read())
                {
                    DiscoDuro disco = new DiscoDuro();
                    disco.IdDisco = reader.GetInt32("idDisco");
                    disco.Cantidad = reader.GetInt32("cantidad");
                    discosAux.Add(disco);
                }
                if ((reader.HasRows))
                {
                    parametrosEntrada = new MySqlParameter[1];
                    parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                    parametrosEntrada[0].Value = idLC;
                    error = objManager.EjecutarProcedure(parametrosEntrada, "delete_disco_LC");
                    if (!error)
                    {
                        sql = "ROLLBACk;";
                        commit = objManager.EjecutarNonQuery(sql);
                        objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();
                        return error;
                    }
                    foreach (DiscoDuro d in discosAux)
                    {
                        int _idDisco = d.IdDisco;
                        int _cantidad = d.Cantidad;

                        parametrosEntrada = new MySqlParameter[2];
                        parametrosEntrada[0] = new MySqlParameter("@_idDisco", MySqlDbType.Int32);
                        parametrosEntrada[1] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                        parametrosEntrada[0].Value = _idDisco;
                        parametrosEntrada[1].Value = _cantidad;
                        error = objManager.EjecutarProcedure(parametrosEntrada, "update_disco_cantidad");
                        if (!error)
                        {
                            sql = "ROLLBACk;";
                            commit = objManager.EjecutarNonQuery(sql);
                            objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();
                            return error;
                        }
                    }
                }
                objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();

                foreach (DiscoDuro d in discos)
                {
                    parametrosEntrada = new MySqlParameter[4];
                    parametrosEntrada[0] = new MySqlParameter("@_idDisco", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                    parametrosEntrada[2] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                    parametrosEntrada[3] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);

                    parametrosEntrada[0].Value = d.IdDisco;
                    parametrosEntrada[1].Value = idLC;
                    parametrosEntrada[2].Value = d.Cantidad;
                    parametrosEntrada[3].Value = usuario;

                    error = objManager.EjecutarProcedure(parametrosEntrada, "insert_disco_LC");
                    if (!error)
                    {
                        sql = "ROLLBACk;";
                        commit = objManager.EjecutarNonQuery(sql);
                        objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();
                        return error;
                    }
                }
            }
            sql = "COMMIT; SET autocommit=1;";
            commit = objManager.EjecutarNonQuery(sql);
            objManager.conexion.Close(); objManager.conexion.Dispose(); objManager.cmd.Dispose();
            return true;
        }

        public int ValidarCantidadLaptopDiscos(int idLC, BindingList<DiscoDuro> discos)
        {
            foreach (DiscoDuro dis in discos)
            {
                int sumaCant = 0;
                string sql = "";

                sql = "Select dis.cantidad as Cantidad From disco_duro dis where dis.idDisco=" + dis.IdDisco + " ;";
                MySqlDataReader reader;
                reader = objManager.MostrarInformacion(sql);
                while (reader.Read())
                {
                    sumaCant += reader.GetInt32("Cantidad");
                }

                sql = "Select dlc.cantidad as Cantidad From disco_lc dlc where dlc.idDisco=" + dis.IdDisco + " and dlc.idLC=" + idLC + " ;";
                reader = objManager.MostrarInformacion(sql);
                while (reader.Read())
                {
                    sumaCant += reader.GetInt32("Cantidad");
                }
                if (dis.Cantidad > sumaCant) return -1;
            }
            return 0;
        }

        public bool InsertarLaptopDiscosPrimeraVez(int idLC, BindingList<DiscoDuro> discos, string usuario)
        {

            bool error = false;

            foreach (DiscoDuro d in discos)
            {
                parametrosEntrada = new MySqlParameter[4];
                parametrosEntrada[0] = new MySqlParameter("@_idDisco", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_cantidad", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);

                parametrosEntrada[0].Value = d.IdDisco;
                parametrosEntrada[1].Value = idLC;
                parametrosEntrada[2].Value = d.Cantidad;
                parametrosEntrada[3].Value = usuario;

                error = objManager.EjecutarProcedure(parametrosEntrada, "insert_disco_LC");
            }
            return error;
        }

        public bool InsertarLaptopLicenciaPrimeraVez(int idLC, BindingList<Licencia> licencias, string usuario)
        {

            bool error = false;

            foreach (Licencia l in licencias)
            {
                parametrosEntrada = new MySqlParameter[3];
                parametrosEntrada[0] = new MySqlParameter("@_idLicencia", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                parametrosEntrada[0].Value = l.IdLicencia;
                parametrosEntrada[1].Value = idLC;
                parametrosEntrada[2].Value = usuario;

                error = objManager.EjecutarProcedure(parametrosEntrada, "insert_licencia_LC");
            }
            return error;
        }

        public bool ActualizarLaptopLicencia(int idLC, int idLicencia, string usuario,int flag)
        {
            bool error = false;
            if (flag == 1)//Entra en esto si se ha equivocado en agregar esta licencia a la laptop y quiere corregirlo
            {
                parametrosEntrada = new MySqlParameter[2];
                parametrosEntrada[0] = new MySqlParameter("@_idLicencia", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                parametrosEntrada[0].Value = idLicencia;
                parametrosEntrada[1].Value = usuario;

                error = objManager.EjecutarProcedure(parametrosEntrada, "update_licencia_LC");
            }
            else//entra en eta parte si ya ha caducado la licencia
            {
                parametrosEntrada = new MySqlParameter[2];
                parametrosEntrada[0] = new MySqlParameter("@_idLicencia", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                parametrosEntrada[0].Value = idLicencia;
                parametrosEntrada[1].Value = usuario;

                error = objManager.EjecutarProcedure(parametrosEntrada, "delete_licencia_LC");
            }

            return error;
        }

        public int InsertarPreAlquiler(Alquiler alquiler, string usuario)
        {

            bool error = false;

            parametrosEntrada = new MySqlParameter[13];
            parametrosEntrada[0] = new MySqlParameter("@_idCliente", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_idSucursal", MySqlDbType.Int32);
            parametrosEntrada[2] = new MySqlParameter("@_rucDni", MySqlDbType.VarChar, 100);
            parametrosEntrada[3] = new MySqlParameter("@_nroContrato", MySqlDbType.VarChar, 100);
            parametrosEntrada[4] = new MySqlParameter("@_nroOC", MySqlDbType.VarChar, 100);
            parametrosEntrada[5] = new MySqlParameter("@_idPedido", MySqlDbType.Int32);
            parametrosEntrada[6] = new MySqlParameter("@_fecSalida", MySqlDbType.DateTime);
            parametrosEntrada[7] = new MySqlParameter("@_fecIniContrato", MySqlDbType.DateTime);
            parametrosEntrada[8] = new MySqlParameter("@_fecFinContrato", MySqlDbType.DateTime);
            parametrosEntrada[9] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
            parametrosEntrada[10] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[11] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
            parametrosEntrada[12] = new MySqlParameter("@_idSalida", MySqlDbType.Int32);

            parametrosEntrada[0].Value = alquiler.IdCliente;
            parametrosEntrada[1].Value = alquiler.IdSucursal;
            parametrosEntrada[2].Value = alquiler.RucDni;
            parametrosEntrada[3].Value = alquiler.NroContrato;
            parametrosEntrada[4].Value = alquiler.NroOC;
            parametrosEntrada[5].Value = 0;
            parametrosEntrada[6].Value = alquiler.FechaSalida;
            parametrosEntrada[7].Value = alquiler.FechaIniContrato;
            parametrosEntrada[8].Value = alquiler.FechaFinContrato;
            parametrosEntrada[9].Value = alquiler.Observacion;
            parametrosEntrada[10].Value = 6;
            parametrosEntrada[11].Value = usuario;
            
            string[] datosSalida = new string[1];

            objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_pre_salida",
                12, 13, out datosSalida, 1);

            if (datosSalida != null)
            {
                alquiler.IdAlquiler = Convert.ToInt32(datosSalida[0]);
                error=InsertarDetallePreAlquiler(alquiler, usuario);
                if (error)
                {
                    foreach (AlquilerDetalle det in alquiler.Detalles)
                    {
                        parametrosEntrada = new MySqlParameter[4];
                        parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                        parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                        parametrosEntrada[2] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 250);
                        parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                        parametrosEntrada[0].Value = det.Laptop.IdLC;
                        parametrosEntrada[1].Value = alquiler.Estado;
                        parametrosEntrada[2].Value = alquiler.IdSucursal;
                        parametrosEntrada[3].Value = usuario;

                        objManager.EjecutarProcedure(parametrosEntrada, "update_laptop_disponibilidad");

                    }

                }
            }
            return alquiler.IdAlquiler;
        }

        public bool InsertarDetallePreAlquiler(Alquiler alquiler, string usuario)
        {

            bool error = false;
            foreach (AlquilerDetalle det in alquiler.Detalles)
            {
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
                parametrosEntrada[20] = new MySqlParameter("@_fecIniContrato", MySqlDbType.DateTime);
                parametrosEntrada[21] = new MySqlParameter("@_fecFinContrato", MySqlDbType.DateTime);
                parametrosEntrada[22] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);

                int idDisco1 =0; int cantDisco1 = 0; int idDisco2 = 0; int cantDisco2 = 0;
                int idMemoria1 = 0; int cantMemoria1 = 0; int idMemoria2 = 0; int cantMemoria2 = 0;
                int idWindows = 0; int idOffice = 0; int idAntivirus = 0;

                Licencia windows = null; Licencia office = null;  Licencia antivirus = null;

                if(det.Laptop.Discos.Count > 0)
                {
                    if (det.Laptop.Discos.Count == 1)
                    {
                        idDisco1 = det.Laptop.Discos[0].IdDisco;
                        cantDisco1 = det.Laptop.Discos[0].Cantidad;
                    }
                    else if (det.Laptop.Discos.Count >= 2)
                    {
                        idDisco1 = det.Laptop.Discos[0].IdDisco;
                        cantDisco1 = det.Laptop.Discos[0].Cantidad;
                        idDisco2 = det.Laptop.Discos[1].IdDisco;
                        cantDisco2 = det.Laptop.Discos[1].Cantidad;
                    }
                }

                if (det.Laptop.Memorias.Count > 0)
                {
                    if (det.Laptop.Memorias.Count == 1)
                    {
                        idMemoria1 = det.Laptop.Memorias[0].IdMemoria;
                        cantMemoria1 = det.Laptop.Memorias[0].Cantidad;
                    }
                    else if (det.Laptop.Memorias.Count >= 2)
                    {
                        idMemoria1 = det.Laptop.Memorias[0].IdMemoria;
                        cantMemoria1 = det.Laptop.Memorias[0].Cantidad;
                        idMemoria2 = det.Laptop.Memorias[1].IdMemoria;
                        cantMemoria2 = det.Laptop.Memorias[1].Cantidad;
                    }
                }
                if (det.Laptop.Licencias.Count > 0)
                {
                        windows = det.Laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaSO);
                        office = det.Laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaOffice);
                        antivirus = det.Laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaAntivirus);
                    
                }
                idWindows = (windows != null) ? windows.IdLicencia : 0;
                idOffice = (office != null) ? office.IdLicencia : 0;
                idAntivirus = (antivirus != null) ? antivirus.IdLicencia : 0;

                parametrosEntrada[0].Value = alquiler.IdAlquiler;
                parametrosEntrada[1].Value = det.Laptop.IdLC;
                parametrosEntrada[2].Value = det.Laptop.Procesador.IdProcesador;
                parametrosEntrada[3].Value = det.Laptop.Video.IdVideo;
                parametrosEntrada[4].Value = idDisco1;
                parametrosEntrada[5].Value = cantDisco1;
                parametrosEntrada[6].Value = idDisco2;
                parametrosEntrada[7].Value = cantDisco2;
                parametrosEntrada[8].Value = idMemoria1;
                parametrosEntrada[9].Value = cantMemoria1;
                parametrosEntrada[10].Value = idMemoria2;
                parametrosEntrada[11].Value = cantMemoria2;
                parametrosEntrada[12].Value = idWindows;
                parametrosEntrada[13].Value = idOffice;
                parametrosEntrada[14].Value = idAntivirus;
                parametrosEntrada[15].Value = det.Caracteristica;
                parametrosEntrada[16].Value = det.GuiaSalida;
                parametrosEntrada[17].Value = det.Observacion;
                parametrosEntrada[18].Value = alquiler.Estado;
                parametrosEntrada[19].Value = usuario;
                parametrosEntrada[20].Value = alquiler.FechaIniContrato;
                parametrosEntrada[21].Value = alquiler.FechaFinContrato;

                string[] datosSalida = new string[1];
                objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_salida_det",
                    22, 23, out datosSalida, 1);

                if (datosSalida != null)
                {
                    int idSalidaDet = Convert.ToInt32(datosSalida[0]);
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
              
        public Alquiler LlamarAlquilerModificable(int idAlquiler)
        {
            Alquiler alquilerDevuelto = new Alquiler();
            MySqlDataReader reader;
            string sql = "";

            sql = "Select * From salida where idSalida=" + idAlquiler + " ;";
            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                alquilerDevuelto.IdAlquiler = reader.GetInt32("idSalida");
                alquilerDevuelto.IdCliente = reader.GetInt32("idCliente");
                alquilerDevuelto.IdSucursal = reader.GetInt32("idSucursal");
                alquilerDevuelto.RucDni = reader.GetString("rucDni");
                alquilerDevuelto.NroContrato = reader.GetString("nroContrato");
                alquilerDevuelto.NroOC = reader.GetString("nroOC");
                alquilerDevuelto.FechaSalida = reader.GetDateTime("fecSalida");
                alquilerDevuelto.FechaIniContrato = reader.GetDateTime("fecIniContrato");
                alquilerDevuelto.FechaFinContrato = reader.GetDateTime("fecFinContrato");
                alquilerDevuelto.Observacion = reader.GetString("observacion");
                alquilerDevuelto.Estado = reader.GetInt32("estado");
                alquilerDevuelto.UsuarioRegistro.Nombre = reader.GetString("usuario_ins");
            }

            objManager.conexion.Close();
            objManager.conexion.Dispose();
            objManager.cmd.Dispose();


            sql = "Select * From salida_det where idSalida=" + idAlquiler + " ;";
            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                AlquilerDetalle det = new AlquilerDetalle();
                det.IdAlquilerDetalle = reader.GetInt32("idSalidaDet");
                det.Laptop.IdLC = reader.GetInt32("idLC");
                det.Caracteristica = reader.GetString("caracteristicas");
                det.GuiaSalida = reader.GetString("guiaSalida");
                det.MotivoNoRecojo = reader.GetString("motivoNoRecojo");
                det.Observacion = reader.GetString("observacion");
                det.Estado = reader.GetInt32("estado");
                det.FechaIniContrato = reader.GetDateTime("fecIniContrato");
                det.FechaFinContrato = reader.GetDateTime("fecFinContrato");
                alquilerDevuelto.Detalles.Add(det);
            }

            objManager.conexion.Close();
            objManager.conexion.Dispose();
            objManager.cmd.Dispose();


            return alquilerDevuelto;
        }

        public bool ModificarAlquiler(Alquiler alquiler, string usuario)
        {

            bool error = false;

            parametrosEntrada = new MySqlParameter[13];
            parametrosEntrada[0] = new MySqlParameter("@_idCliente", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_idSucursal", MySqlDbType.Int32);
            parametrosEntrada[2] = new MySqlParameter("@_rucDni", MySqlDbType.VarChar, 100);
            parametrosEntrada[3] = new MySqlParameter("@_nroContrato", MySqlDbType.VarChar, 100);
            parametrosEntrada[4] = new MySqlParameter("@_nroOC", MySqlDbType.VarChar, 100);
            parametrosEntrada[5] = new MySqlParameter("@_idPedido", MySqlDbType.Int32);
            parametrosEntrada[6] = new MySqlParameter("@_fecSalida", MySqlDbType.DateTime);
            parametrosEntrada[7] = new MySqlParameter("@_fecIniContrato", MySqlDbType.DateTime);
            parametrosEntrada[8] = new MySqlParameter("@_fecFinContrato", MySqlDbType.DateTime);
            parametrosEntrada[9] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
            parametrosEntrada[10] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[11] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
            parametrosEntrada[12] = new MySqlParameter("@_idSalida", MySqlDbType.Int32);

            parametrosEntrada[0].Value = alquiler.IdCliente;
            parametrosEntrada[1].Value = alquiler.IdSucursal;
            parametrosEntrada[2].Value = alquiler.RucDni;
            parametrosEntrada[3].Value = alquiler.NroContrato;
            parametrosEntrada[4].Value = alquiler.NroOC;
            parametrosEntrada[5].Value = 0;
            parametrosEntrada[6].Value = alquiler.FechaSalida;
            parametrosEntrada[7].Value = alquiler.FechaIniContrato;
            parametrosEntrada[8].Value = alquiler.FechaFinContrato;
            parametrosEntrada[9].Value = alquiler.Observacion;
            parametrosEntrada[10].Value = alquiler.Estado;
            parametrosEntrada[11].Value = usuario;
            parametrosEntrada[12].Value = alquiler.IdAlquiler;

            bool okey=objManager.EjecutarProcedure(parametrosEntrada, "update_salida");

            if (okey)
            {

                parametrosEntrada = new MySqlParameter[1];
                parametrosEntrada[0] = new MySqlParameter("@_idSalida", MySqlDbType.Int32);

                parametrosEntrada[0].Value = alquiler.IdAlquiler;

                okey = objManager.EjecutarProcedure(parametrosEntrada, "delete_salida_detalle");

                if (okey)
                {
                    okey=InsertarDetallePreAlquiler(alquiler, usuario);
                    if (okey)
                    {
                        foreach (AlquilerDetalle det in alquiler.Detalles)
                        {
                            parametrosEntrada = new MySqlParameter[4];
                            parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                            parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                            parametrosEntrada[2] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 250);
                            parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                            parametrosEntrada[0].Value = det.Laptop.IdLC;
                            parametrosEntrada[1].Value = alquiler.Estado;
                            parametrosEntrada[2].Value = alquiler.IdSucursal;
                            parametrosEntrada[3].Value = usuario;

                            objManager.EjecutarProcedure(parametrosEntrada, "update_laptop_disponibilidad");

                        }
                    }
                }
            }
            return error;
        }

        public LC LlenarDetalleDeUnaLaptop(int idLC)
        {
            LC laptop = new LC();
            MySqlDataReader reader;
            string sql = "";

            sql = "Select * From vista_laptops_almacen_lista_sin_filtro where idLC=" + idLC + " ;";
            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                laptop.IdLC = reader.GetInt32("idLC");
                laptop.Codigo = reader.GetString("codigo");
                laptop.Modelo.NombreMarca = reader.GetString("marcaLC");
                laptop.Modelo.NombreModelo = reader.GetString("nombreModeloLC");
                laptop.TamanoPantalla = reader.GetDouble("tamanoPantalla");
                laptop.Procesador.Modelo.NombreModelo = reader.GetString("tipoProcesador");
                laptop.Procesador.Generacion = reader.GetInt32("generacionProcesador");
                laptop.Video.Modelo.NombreModelo = reader.GetString("nombreModeloVideo");
                laptop.Video.Capacidad = reader.GetInt32("capacidadVideo");
                laptop.Procesador.IdProcesador = reader.GetInt32("idProcesador");
                laptop.Video.IdVideo = reader.GetInt32("idVideo");
                
            }

            objManager.conexion.Close();
            objManager.conexion.Dispose();
            objManager.cmd.Dispose();

            
            return laptop;
        }

        public bool AnularAlquiler(Alquiler alquiler, string usuario)
        {

            bool error = false;

            parametrosEntrada = new MySqlParameter[4];
            parametrosEntrada[0] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 100);
            parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[2] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
            parametrosEntrada[3] = new MySqlParameter("@_idSalida", MySqlDbType.Int32);

            parametrosEntrada[0].Value = alquiler.Observacion;
            parametrosEntrada[1].Value = alquiler.Estado; //0
            parametrosEntrada[2].Value = usuario;
            parametrosEntrada[3].Value = alquiler.IdAlquiler;

            bool okey = objManager.EjecutarProcedure(parametrosEntrada, "anular_salida");

            if (okey)
            {
                foreach (AlquilerDetalle det in alquiler.Detalles)
                {
                    parametrosEntrada = new MySqlParameter[4];
                    parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                    parametrosEntrada[2] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 250);
                    parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

                    parametrosEntrada[0].Value = det.Laptop.IdLC;
                    parametrosEntrada[1].Value = 2;
                    parametrosEntrada[2].Value = "ALMACEN";
                    parametrosEntrada[3].Value = usuario;

                    objManager.EjecutarProcedure(parametrosEntrada, "update_laptop_disponibilidad");


                    parametrosEntrada = new MySqlParameter[3];
                    parametrosEntrada[0] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                    parametrosEntrada[1] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
                    parametrosEntrada[2] = new MySqlParameter("@_idSalidaDet", MySqlDbType.Int32);

                    parametrosEntrada[0].Value = 0;
                    parametrosEntrada[1].Value = usuario;
                    parametrosEntrada[2].Value = det.IdAlquilerDetalle;

                    objManager.EjecutarProcedure(parametrosEntrada, "anular_salida_detalle");

                }
            }
            return error;
        }

        public LC LlenarDetalleDeUnaLaptopDesdeMismoAlquilerDetalle(AlquilerDetalle detalle)
        {
            LC laptop = new LC();
            MySqlDataReader reader;
            string sql = "";

            sql = "Select * From vista_laptops_almacen_lista_sin_filtro where idLC=" + detalle.Laptop.IdLC + " ;";
            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                laptop.IdLC = reader.GetInt32("idLC");
                laptop.Codigo = reader.GetString("codigo");
                laptop.Modelo.NombreMarca = reader.GetString("marcaLC");
                laptop.Modelo.NombreModelo = reader.GetString("nombreModeloLC");
                laptop.TamanoPantalla = reader.GetDouble("tamanoPantalla");
                laptop.Procesador.Modelo.NombreModelo = reader.GetString("tipoProcesador");
                laptop.Procesador.Generacion = reader.GetInt32("generacionProcesador");
                laptop.Video.Modelo.NombreModelo = reader.GetString("nombreModeloVideo");
                laptop.Video.Capacidad = reader.GetInt32("capacidadVideo");
                laptop.Procesador.IdProcesador = reader.GetInt32("idProcesador");
                laptop.Video.IdVideo = reader.GetInt32("idVideo");

            }

            objManager.conexion.Close();
            objManager.conexion.Dispose();
            objManager.cmd.Dispose();

            sql = "";

            sql = "Select * from salida_det WHERE idSalidaDet=" + detalle.IdAlquilerDetalle + " ;";
            reader = objManager.MostrarInformacion(sql);

            while (reader.Read())
            {
                DiscoDuro disco1 = new DiscoDuro();
                disco1.IdDisco= reader.GetInt32("idDisco1");
                disco1.Cantidad = reader.GetInt32("cantidadDisco1");
                DiscoDuro disco2 = new DiscoDuro();
                disco2.IdDisco = reader.GetInt32("idDisco2");
                disco2.Cantidad = reader.GetInt32("cantidadDisco2");
                if(disco1.IdDisco!=0) laptop.Discos.Add(disco1);
                if (disco2.IdDisco != 0) laptop.Discos.Add(disco2);

                Memoria memoria1 = new Memoria();
                memoria1.IdMemoria = reader.GetInt32("idMemoria1");
                memoria1.Cantidad = reader.GetInt32("cantidadDisco1");
                Memoria memoria2 = new Memoria();
                memoria2.IdMemoria = reader.GetInt32("idMemoria2");
                memoria2.Cantidad = reader.GetInt32("cantidadDisco2");
                if (memoria1.IdMemoria != 0) laptop.Memorias.Add(memoria1);
                if (memoria2.IdMemoria != 0) laptop.Memorias.Add(memoria2);


                Licencia windows = new Licencia();
                Licencia office = new Licencia();
                Licencia antivirus = new Licencia();

                windows.IdLicencia = reader.GetInt32("idWindows");
                office.IdLicencia = reader.GetInt32("idOffice");
                antivirus.IdLicencia = reader.GetInt32("idAntivirus");
                if (windows.IdLicencia != 0) laptop.Licencias.Add(windows);
                if (office.IdLicencia != 0) laptop.Licencias.Add(office);
                if (antivirus.IdLicencia != 0) laptop.Licencias.Add(antivirus);

            }

            objManager.conexion.Close();
            objManager.conexion.Dispose();
            objManager.cmd.Dispose();

            for (int i=0;i<laptop.Discos.Count;i++)
            {
                sql = "";

                sql = "Select * From vista_maestro_disco d where d.idDisco=" + laptop.Discos[i].IdDisco + " ;";
                reader = objManager.MostrarInformacion(sql);
                while (reader.Read())
                {
                    laptop.Discos[i].Tipo.NombreModelo = reader.GetString("tipo");
                    laptop.Discos[i].Tamano = reader.GetString("tamano");
                    laptop.Discos[i].Capacidad = reader.GetInt32("capacidad");
                }
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();
            }

            for (int i = 0; i < laptop.Memorias.Count; i++)
            {
                sql = "";

                sql = "Select * From vista_maestro_memoria m where m.idMemoria=" + laptop.Memorias[i].IdMemoria + " ;";
                reader = objManager.MostrarInformacion(sql);
                while (reader.Read())
                {
                    laptop.Memorias[i].Modelo.NombreModelo = reader.GetString("tipo");
                    laptop.Memorias[i].Capacidad = reader.GetInt32("capacidad");
                }
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();
            }

            for (int i = 0; i < laptop.Licencias.Count; i++)
            {
                sql = "";

                sql = "Select * From vista_licencia_lista l where l.IdLicencia=" + laptop.Licencias[i].IdLicencia + " ;";
                reader = objManager.MostrarInformacion(sql);
                while (reader.Read())
                {
                    laptop.Licencias[i].IdCategoria = reader.GetInt32("IdCategoria");
                    laptop.Licencias[i].Categoria = reader.GetString("Categoria");
                    laptop.Licencias[i].Modelo.IdMarca = reader.GetInt32("IdMarca");
                    laptop.Licencias[i].Modelo.NombreMarca = reader.GetString("Marca");
                    laptop.Licencias[i].Modelo.IdModelo = reader.GetInt32("IdModelo");
                    laptop.Licencias[i].Modelo.NombreModelo = reader.GetString("Version");
                    laptop.Licencias[i].Clave = reader.GetString("Clave");
                    laptop.Licencias[i].Ubicacion = reader.GetString("Ubicacion");
                }
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();
            }



            return laptop;
        }

    }
}
