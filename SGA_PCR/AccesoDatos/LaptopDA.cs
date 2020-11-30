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
    public class LaptopDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public LaptopDA()
        {
            objManager = new DBManager();
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
            return objManager.MostrarTablaDatos("Select * from vista_licencia_lc_lista where idLC=" + idLC + " ;");
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
            foreach (Memoria mem in memorias)
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

                sql = "Select mlc.cantidad as Cantidad From memoria_lc mlc where mlc.IdMemoria=" + mem.IdMemoria + " and mlc.idLC=" + idLC + " ;";
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

        public bool ActualizarLaptopLicencia(int idLC, int idLicencia, string usuario, int flag)
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

        public LC DatosLaptopDisponibleSinMemoriaSinDisco(string codigo)
        {
            LC laptop = new LC();
            MySqlDataReader reader;
            string sql = "";

            sql = "Select * From vista_laptops_almacen_lista where codigo='" + codigo + "' ;";
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


        public LC DatosLaptopsSinMemoriaSinDiscoSinFiltros(string codigo)
        {
            LC laptop = new LC();
            MySqlDataReader reader;
            string sql = "";

            sql = "Select * From vista_laptops_almacen_lista_sin_filtro where codigo='" + codigo + "' ;";
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

        public bool ActualizarLaptopMemoriaSinAfectarCantidad(int idLC, BindingList<Memoria> memorias, string usuario)
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

                    error = objManager.EjecutarProcedure(parametrosEntrada, "insert_memoria_LC_SinAfectarCantidad");
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

        public bool InsertarLaptopMemoriasPrimeraVezSinAfectarCantidad(int idLC, BindingList<Memoria> memorias, string usuario)
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

                error = objManager.EjecutarProcedure(parametrosEntrada, "insert_memoria_LC_SinAfectarCantidad");
            }
            return error;
        }

        public bool ActualizarLaptopDiscoSinAfectarCantidad(int idLC, BindingList<DiscoDuro> discos, string usuario)
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

                    error = objManager.EjecutarProcedure(parametrosEntrada, "insert_disco_LC_SinAfectarCantidad");
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

        public bool InsertarLaptopDiscosPrimeraVezSinAfectarCantidad(int idLC, BindingList<DiscoDuro> discos, string usuario)
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

                error = objManager.EjecutarProcedure(parametrosEntrada, "insert_disco_LC_SinAfectarCantidad");
            }
            return error;
        }

    }
}
