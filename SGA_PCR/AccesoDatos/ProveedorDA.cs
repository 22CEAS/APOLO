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
    public class ProveedorDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;
        public ProveedorDA()
        {
            objManager = new DBManager();
        }
        public DataTable ListarProveedores()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_proveedor_lista ;");
        }
        
         
        public int GuardarNuevoProveedor(Proveedor proveedor,string usuario)
        {
            parametrosEntrada = new MySqlParameter[14];
            parametrosEntrada[0] = new MySqlParameter("@_ruc", MySqlDbType.VarChar, 11);
            parametrosEntrada[1] = new MySqlParameter("@_razonSocial", MySqlDbType.VarChar, 255);
            parametrosEntrada[2] = new MySqlParameter("@_nombreComercial", MySqlDbType.VarChar, 255);
            parametrosEntrada[3] = new MySqlParameter("@_abreviacion", MySqlDbType.VarChar, 11);
            parametrosEntrada[4] = new MySqlParameter("@_direccion", MySqlDbType.VarChar, 255);
            parametrosEntrada[5] = new MySqlParameter("@_telefono", MySqlDbType.VarChar, 20);
            parametrosEntrada[6] = new MySqlParameter("@_fax", MySqlDbType.VarChar, 20);
            parametrosEntrada[7] = new MySqlParameter("@_email", MySqlDbType.VarChar, 255);
            parametrosEntrada[8] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 255);
            parametrosEntrada[9] = new MySqlParameter("@_nombreContacto", MySqlDbType.VarChar, 255);
            parametrosEntrada[10] = new MySqlParameter("@_telefonoContacto", MySqlDbType.VarChar, 255);
            parametrosEntrada[11] = new MySqlParameter("@_emailContacto", MySqlDbType.VarChar, 255);
            parametrosEntrada[12] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
            parametrosEntrada[13] = new MySqlParameter("@_idProveedor", MySqlDbType.Int32);

            parametrosEntrada[0].Value = proveedor.Ruc;
            parametrosEntrada[1].Value = proveedor.RazonSocial;
            parametrosEntrada[2].Value = proveedor.NombreComercial;
            parametrosEntrada[3].Value = proveedor.Abreviacion;
            parametrosEntrada[4].Value = proveedor.Direccion;
            parametrosEntrada[5].Value = proveedor.Telefono;
            parametrosEntrada[6].Value = proveedor.Fax;
            parametrosEntrada[7].Value = proveedor.Email;
            parametrosEntrada[8].Value = proveedor.Observacion;
            parametrosEntrada[9].Value = proveedor.NombreContacto;
            parametrosEntrada[10].Value = proveedor.TelefonoContacto;
            parametrosEntrada[11].Value = proveedor.EmailContacto;
            parametrosEntrada[12].Value = usuario;

            string[] datosSalida = new string[1];

            objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_proveedor",
                13, 14, out datosSalida, 1);

            if (datosSalida != null)
            {
                int idProveedor = Convert.ToInt32(datosSalida[0]);
                return idProveedor;
            }
            return -1;
            
        }
        public int ModificarProveedor(Proveedor proveedor, string usuario)
        {
            parametrosEntrada = new MySqlParameter[15];
            parametrosEntrada[0] = new MySqlParameter("@_idProveedor", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_ruc", MySqlDbType.VarChar, 11);
            parametrosEntrada[2] = new MySqlParameter("@_razonSocial", MySqlDbType.VarChar, 255);
            parametrosEntrada[3] = new MySqlParameter("@_nombreComercial", MySqlDbType.VarChar, 255);
            parametrosEntrada[4] = new MySqlParameter("@_abreviacion", MySqlDbType.VarChar, 11);
            parametrosEntrada[5] = new MySqlParameter("@_direccion", MySqlDbType.VarChar, 255);
            parametrosEntrada[6] = new MySqlParameter("@_telefono", MySqlDbType.VarChar, 20);
            parametrosEntrada[7] = new MySqlParameter("@_fax", MySqlDbType.VarChar, 20);
            parametrosEntrada[8] = new MySqlParameter("@_email", MySqlDbType.VarChar, 255);
            parametrosEntrada[9] = new MySqlParameter("@_observacion", MySqlDbType.VarChar, 255);
            parametrosEntrada[10] = new MySqlParameter("@_nombreContacto", MySqlDbType.VarChar, 255);
            parametrosEntrada[11] = new MySqlParameter("@_telefonoContacto", MySqlDbType.VarChar, 255);
            parametrosEntrada[12] = new MySqlParameter("@_emailContacto", MySqlDbType.VarChar, 255);
            parametrosEntrada[13] = new MySqlParameter("@_estado", MySqlDbType.VarChar, 255);
            parametrosEntrada[14] = new MySqlParameter("@_usuario_mod", MySqlDbType.VarChar, 100);

            parametrosEntrada[0].Value = proveedor.IdProveedor;
            parametrosEntrada[1].Value = proveedor.Ruc;
            parametrosEntrada[2].Value = proveedor.RazonSocial;
            parametrosEntrada[3].Value = proveedor.NombreComercial;
            parametrosEntrada[4].Value = proveedor.Abreviacion;
            parametrosEntrada[5].Value = proveedor.Direccion;
            parametrosEntrada[6].Value = proveedor.Telefono;
            parametrosEntrada[7].Value = proveedor.Fax;
            parametrosEntrada[8].Value = proveedor.Email;
            parametrosEntrada[9].Value = proveedor.Observacion;
            parametrosEntrada[10].Value = proveedor.NombreContacto;
            parametrosEntrada[11].Value = proveedor.TelefonoContacto;
            parametrosEntrada[12].Value = proveedor.EmailContacto;
            parametrosEntrada[13].Value = proveedor.Estado;
            parametrosEntrada[14].Value = usuario;
            bool aux=objManager.EjecutarProcedure(parametrosEntrada, "update_proveedor");
            return ((aux) ? 1 : -1);
            
        }
    }
}
