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
    public class ReporteDA
    {
        DBManager objManager;
        MySqlParameter[] parametrosEntrada = null;

        public ReporteDA()
        {
            objManager = new DBManager();
        }

        public DataTable ListarCuadroVencimiento()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_laptops_cuadro_vencimiento ;");
        }

        public DataTable ListarLaptopsPorVencer()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_laptops_por_vencer ;");
        }

        public DataTable ListarLaptopsPorVencerPRONOSTICADOR()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_pronosticador ;");
        }

        public DataTable ListarLaptopsPorFacturar()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_productos_por_facturar ;");
        }

        public DataTable ListarLaptopsPorFacturarDASH()
        {
            //return objManager.MostrarTablaDatos("SELECT * FROM vista_productos_por_facturar_dash ;");
            return objManager.MostrarTablaDatos("select cliente as cliente,max(diasVencidos) as maxDiasVencidos,round(sum(PendienteFacturarSoles),2) as PendienteFacturarSoles from vista_productos_por_facturar_dash group by cliente; ");
        }

        public DataTable ListarLaptopsPorFacturarDASH_segun_dias()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_productos_por_facturar_dash ;");
        }


        public DataTable VerMontoFacturadoMes()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_monto_facturado_total_mes ;");
        }

        public DataTable ListarLaptopsFacturasPorVencer()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_facturas_por_vencer ;");
        }

        public DataTable ListarLaptopsPorRecoger()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_productos_por_recoger ;");
        }

        public DataTable ListarLaptopsPorRecogerDASH()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_pendiente_recoger_dash ;");
        }

        public DataTable ListarLaptopsInventario()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_inventario_laptops ;");
        }

        public DataTable ListarLaptopsInventarioPronosticador()
        {
            return objManager.MostrarTablaDatos("SELECT * FROM vista_inventario_pronosticador ;");
        }

        public DataTable ListarLaptopDisco(int idLC)
        {
            return objManager.MostrarTablaDatos("Select * from vista_laptops_discos where idLC=" + idLC + " ;");
        }

        public DataTable ListarLaptopDisco()
        {
            return objManager.MostrarTablaDatos("Select * from vista_laptops_discos ;");
        }
        public DataTable ListarLaptopMemoria(int idLC)
        {
            return objManager.MostrarTablaDatos("Select * from vista_laptops_memorias where idLC=" + idLC + " ;");
        }
        public DataTable ListarLaptopMemoria()
        {
            return objManager.MostrarTablaDatos("Select * from vista_laptops_memorias ;");
        }
        public DataTable ListarLaptopLicencia(int idLC)
        {
            return objManager.MostrarTablaDatos("Select * from vista_licencia_lc_lista where idLC=" + idLC + " ;");
        }
        public DataTable ListarLaptopLicencia()
        {
            return objManager.MostrarTablaDatos("Select * from vista_licencia_lc_lista ;");
        }


        public DataTable ListarMemorias()
        {
            return objManager.MostrarTablaDatos("Select * from vista_inventario_memoria;");
        }
        public DataTable ListarDiscos()
        {
            return objManager.MostrarTablaDatos("Select * from vista_inventario_discos;");
        }
        public DataTable ListarLicencias()
        {
            return objManager.MostrarTablaDatos("Select * from vista_stockDisponible_licencia_libre;");
        }

        public DataTable ListarObservaciones()
        {
            return objManager.MostrarTablaDatos("Select * from vista_lista_observaciones ;");
        }

        public DataTable ListarObservacionesConKAM() //! ACTUALIZACION DE REPORTE CON KAM
        {
            return objManager.MostrarTablaDatos("Select * from vista_lista_observaciones ;");
        }

        public DataTable ListarReparaciones()
        {
            return objManager.MostrarTablaDatos("Select * from vista_lista_reparaciones v ;");
        }

        public DataTable ListarLicenciasCompletas()
        {
            return objManager.MostrarTablaDatos("Select * from vista_licencia_lista;");
        }

        public DataTable tablaProcesadoresModelos(int id)
        {
            return objManager.MostrarTablaDatos("Select mo.* From modelo mo inner join marca ma on mo.idMarca=ma.idMarca where ma.idCategoria="+ id+" ; ");
        }
        public DataTable tablaProcesadoresGeneracion(string descripcion)
        {
            return objManager.MostrarTablaDatos("Select * From auxiliar where cod_tabla = '"+ descripcion+"' order by (0 + descripcion);");
        }

    }
}
