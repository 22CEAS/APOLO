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
    public class MarcaDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public MarcaDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarMarcas()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM marca; ");
        }

        public int GuardarNuevaMarca(Marca marca, string usuario)
        {
            string sql = "Select * From marca where idCategoria ='" + marca.IdCategoria + "' and nombre= '" + marca.NombreMarca + "' ;";
            MySqlDataReader reader;
            reader = objManager.MostrarInformacion(sql);

            if (!(reader.HasRows))
            {
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();

                parametrosEntrada = new MySqlParameter[5];
                parametrosEntrada[0] = new MySqlParameter("@_idCategoria", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_nombre", MySqlDbType.VarChar, 255);
                parametrosEntrada[2] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
                parametrosEntrada[4] = new MySqlParameter("@_idMarca", MySqlDbType.Int32);

                parametrosEntrada[0].Value = marca.IdCategoria;
                parametrosEntrada[1].Value = marca.NombreMarca;
                parametrosEntrada[2].Value = marca.Estado;
                parametrosEntrada[3].Value = usuario;

                string[] datosSalida = new string[1];

                objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_marca",
                    4, 5, out datosSalida, 1);

                if (datosSalida != null)
                {
                    int idMarca = Convert.ToInt32(datosSalida[0]);
                    return idMarca;
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
        public int ModificarMarca(Marca marca, string usuario, int actualizarEstado)
        {
            string sql = "";
            if (actualizarEstado == 1)
            {
                sql = "Select * From marca where idCategoria ='" + marca.IdCategoria + "' and nombre= '" + marca.NombreMarca + "' and estado=" + marca.Estado + " ;";
            }
            else
            {
                sql = "Select * From marca where idCategoria ='" + marca.IdCategoria + "' and nombre= '" + marca.NombreMarca + "' ;";
            }

            MySqlDataReader reader;
            reader = objManager.MostrarInformacion(sql);

            if (!(reader.HasRows))
            {
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();

                parametrosEntrada = new MySqlParameter[5];
                parametrosEntrada[0] = new MySqlParameter("@_idCategoria", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_nombre", MySqlDbType.VarChar, 255);
                parametrosEntrada[2] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
                parametrosEntrada[4] = new MySqlParameter("@_idMarca", MySqlDbType.Int32);

                parametrosEntrada[0].Value = marca.IdCategoria;
                parametrosEntrada[1].Value = marca.NombreMarca;
                parametrosEntrada[2].Value = marca.Estado;
                parametrosEntrada[3].Value = usuario;
                parametrosEntrada[4].Value = marca.IdMarca;

                bool aux = objManager.EjecutarProcedure(parametrosEntrada, "update_marca");
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



        public DataTable ListarModelos()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM modelo; ");
        }

        public DataTable ListarMarcas(int idCategoria)
        {
            return objManager.MostrarTablaDatos("SELECT * FROM marca where idCategoria=" + idCategoria + " ; ");
        }

        public DataTable ListarMarcas(int idCategoriaSO, int idCategoriaOffice, int idCategoriaAntivirus)
        {
            return objManager.MostrarTablaDatos("SELECT * FROM marca where idCategoria=" + idCategoriaSO+ " or idCategoria=" + idCategoriaOffice + " or idCategoria=" + idCategoriaAntivirus + " ; ");
        }

        public int GuardarNuevoModelo(Modelo.Modelo modelo, string usuario)
        {
            string sql = "Select * From modelo where idMarca ='" + modelo.IdMarca + "' and nombre= '" + modelo.NombreModelo + "' ;";
            MySqlDataReader reader;
            reader = objManager.MostrarInformacion(sql);

            if (!(reader.HasRows))
            {
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();

                parametrosEntrada = new MySqlParameter[5];
                parametrosEntrada[0] = new MySqlParameter("@_idMarca", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_nombre", MySqlDbType.VarChar, 255);
                parametrosEntrada[2] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
                parametrosEntrada[4] = new MySqlParameter("@_idModelo", MySqlDbType.Int32);

                parametrosEntrada[0].Value = modelo.IdMarca;
                parametrosEntrada[1].Value = modelo.NombreModelo;
                parametrosEntrada[2].Value = modelo.Estado;
                parametrosEntrada[3].Value = usuario;

                string[] datosSalida = new string[1];

                objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_modelo",
                    4, 5, out datosSalida, 1);

                if (datosSalida != null)
                {
                    int idModelo = Convert.ToInt32(datosSalida[0]);
                    return idModelo;
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
        public int ModificarModelo(Modelo.Modelo modelo, string usuario, int actualizarEstado)
        {
            string sql = "";
            if (actualizarEstado == 1)
            {
                sql = "Select * From modelo where idMarca ='" + modelo.IdMarca + "' and nombre= '" + modelo.NombreModelo + "' and estado=" + modelo.Estado + " ;";
            }
            else
            {
                sql = "Select * From modelo where idMarca ='" + modelo.IdMarca + "' and nombre= '" + modelo.NombreModelo + "' ;";
            }

            MySqlDataReader reader;
            reader = objManager.MostrarInformacion(sql);

            if (!(reader.HasRows))
            {
                objManager.conexion.Close();
                objManager.conexion.Dispose();
                objManager.cmd.Dispose();

                parametrosEntrada = new MySqlParameter[5];
                parametrosEntrada[0] = new MySqlParameter("@_idMarca", MySqlDbType.Int32);
                parametrosEntrada[1] = new MySqlParameter("@_nombre", MySqlDbType.VarChar, 255);
                parametrosEntrada[2] = new MySqlParameter("@_estado", MySqlDbType.Int32);
                parametrosEntrada[3] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);
                parametrosEntrada[4] = new MySqlParameter("@_idModelo", MySqlDbType.Int32);

                parametrosEntrada[0].Value = modelo.IdMarca;
                parametrosEntrada[1].Value = modelo.NombreModelo;
                parametrosEntrada[2].Value = modelo.Estado;
                parametrosEntrada[3].Value = usuario;
                parametrosEntrada[4].Value = modelo.IdModelo;

                bool aux = objManager.EjecutarProcedure(parametrosEntrada, "update_modelo");
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
