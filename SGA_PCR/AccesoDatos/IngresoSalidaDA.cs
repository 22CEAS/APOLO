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
    public class IngresoSalidaDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;


        public IngresoSalidaDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarLaptopsDisponiblesDanados()
        {
            return objManager.MostrarTablaDatos("Select * from vista_laptops_disponibles_danados;");
        }

        public DataTable ListarLaptopsPersonalPCR_Prestamo()
        {
            return objManager.MostrarTablaDatos("Select * from vista_laptops_personal_prestamo;");
        }

        public DataTable ListarEstadosSalida()
        {
            return objManager.MostrarTablaDatos("Select * from vista_estados_Venta_Personal_Prestamo;");
        }

        public DataTable ListarEstadosIngreso()
        {
            return objManager.MostrarTablaDatos("Select * from vista_estados_Disponible_Danado;");
        }

        public int InsertarProceso(IngresoSalida proceso, int flag,string usuario)
        {
            bool error = false;

            parametrosEntrada = new MySqlParameter[13];
            parametrosEntrada[0] = new MySqlParameter("@_idLC", MySqlDbType.Int32);
            parametrosEntrada[1] = new MySqlParameter("@_codigoLC", MySqlDbType.VarChar, 255);
            parametrosEntrada[2] = new MySqlParameter("@_estadoLCAnt", MySqlDbType.Int32);
            parametrosEntrada[3] = new MySqlParameter("@_estadoLCAct", MySqlDbType.Int32);
            parametrosEntrada[4] = new MySqlParameter("@_fechaIngresoSalida", MySqlDbType.Date);
            parametrosEntrada[5] = new MySqlParameter("@_documentoIdentidad", MySqlDbType.VarChar, 255);
            parametrosEntrada[6] = new MySqlParameter("@_nombrePersona", MySqlDbType.VarChar, 1000);
            parametrosEntrada[7] = new MySqlParameter("@_documentoReferencial", MySqlDbType.VarChar, 255);
            parametrosEntrada[8] = new MySqlParameter("@_estado", MySqlDbType.Int32);
            parametrosEntrada[9] = new MySqlParameter("@_usuario_ins", MySqlDbType.VarChar, 100);
            parametrosEntrada[10] = new MySqlParameter("@_ubicacion", MySqlDbType.VarChar, 1000);
            parametrosEntrada[11] = new MySqlParameter("@_tipoIngresoSalida", MySqlDbType.Int32);
            parametrosEntrada[12] = new MySqlParameter("@_idIngresoSalida", MySqlDbType.Int32);

            parametrosEntrada[0].Value = proceso.IdLC;
            parametrosEntrada[1].Value = proceso.CodigoLC;
            parametrosEntrada[2].Value = proceso.IdEstadoAnt;
            parametrosEntrada[3].Value = proceso.IdEstado;
            parametrosEntrada[4].Value = proceso.FechaIngresoSalida;
            parametrosEntrada[5].Value = proceso.NroIdentidad;
            parametrosEntrada[6].Value = proceso.NombreCliente;
            parametrosEntrada[7].Value = proceso.DocumentoReferencia;
            parametrosEntrada[8].Value = 1;
            parametrosEntrada[9].Value = usuario;
            parametrosEntrada[10].Value = (flag==1)?"ALMACEN": proceso.NombreCliente;
            parametrosEntrada[11].Value = flag;

            string[] datosSalida = new string[1];
            objManager.EjecutarProcedureConDatosDevueltos(parametrosEntrada, "insert_ingresos_salidas_internas",
                12, 13, out datosSalida, 1);

            if (datosSalida != null)
            {
                int idSalidaDet = Convert.ToInt32(datosSalida[0]);
                error = true;
                return 1;
            }
            else
            {
                return 0;
            }

        

            return 1;

        }

    }
}
