using AccesoDatos;
using DevComponents.DotNetBar.SuperGrid;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apolo
{
    public partial class frmProcesoCorteAlquilerAgregarProducto : Form
    {
        DataTable tablaLaptops;
        CorteAlquiler detalle;
        BindingList<CorteAlquiler> detalles;
        BindingList<CorteAlquiler> auxiliares;
        CorteAlquilerDA renovacionDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";

        public frmProcesoCorteAlquilerAgregarProducto(int idCliente)
        {
            InitializeComponent();
            Inicializado(idCliente);
        }

        public frmProcesoCorteAlquilerAgregarProducto(int idUsuario, string nombreUsuario, int idCliente)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado(idCliente);
        }

        public void Inicializado(int idCliente)
        {

            renovacionDA = new CorteAlquilerDA();
            detalles = new BindingList<CorteAlquiler>();

            tablaLaptops = renovacionDA.ListarLaptopsClientesEstadoAlquilado(idCliente);
            auxiliares = new BindingList<CorteAlquiler>();
            int rec = 0;
            while (rec < tablaLaptops.Rows.Count)
            {
                CorteAlquiler auxiliar = new CorteAlquiler();
                auxiliar.IdSalida = Convert.ToInt32(tablaLaptops.Rows[rec]["IdSalida"].ToString());
                auxiliar.GuiaSalida = tablaLaptops.Rows[rec]["GuiaSalida"].ToString();
                auxiliar.IdLC = Convert.ToInt32(tablaLaptops.Rows[rec]["IdLC"].ToString());
                auxiliar.Codigo = tablaLaptops.Rows[rec]["Codigo"].ToString();
                auxiliar.CodigoAntiguo = tablaLaptops.Rows[rec]["CodigoAntiguo"].ToString();
                auxiliar.MarcaLC = tablaLaptops.Rows[rec]["MarcaLC"].ToString();
                auxiliar.NombreModeloLC = tablaLaptops.Rows[rec]["NombreModeloLC"].ToString();
                auxiliar.IdSalidaDetalle = Convert.ToInt32(tablaLaptops.Rows[rec]["IdSalidaDetalle"].ToString());
                auxiliar.IdSucursal = Convert.ToInt32(tablaLaptops.Rows[rec]["IdSucursal"].ToString());
                auxiliar.fecIniContrato = Convert.ToDateTime(tablaLaptops.Rows[rec]["fecIniContrato"].ToString());
                auxiliar.fecFinContrato = Convert.ToDateTime(tablaLaptops.Rows[rec]["fecFinContrato"].ToString());
                auxiliar.FechaIniContratoAntiguo = Convert.ToDateTime(tablaLaptops.Rows[rec]["fecIniContrato"].ToString());
                auxiliar.FechaFinContratoAntiguo = Convert.ToDateTime(tablaLaptops.Rows[rec]["fecFinContrato"].ToString());

                auxiliares.Add(auxiliar);
                rec++;
            }

            dgvRenovacionProductos.DataSource = auxiliares;
            vista.OptionsBehavior.AutoPopulateColumns = false;
            vista.OptionsSelection.MultiSelect = true;

        }

        public bool llenarListaLaptops()
        {
            bool flag = false;
            int filas = tablaLaptops.Rows.Count;
            vista.ClearColumnsFilter();
            for (int i = 0; i < filas; i++)
            {
                bool aux2 = bool.Parse(vista.GetRowCellValue(i, "Seleccion").ToString());
                if (aux2)
                {
                    detalle = new CorteAlquiler();
                    detalle.IdSalida = int.Parse(vista.GetRowCellValue(i, "IdSalida").ToString());
                    detalle.GuiaSalida = vista.GetRowCellValue(i, "GuiaSalida").ToString();
                    detalle.IdLC = int.Parse(vista.GetRowCellValue(i, "IdLC").ToString());
                    detalle.CodigoLC = vista.GetRowCellValue(i, "Codigo").ToString();
                    detalle.MarcaLC = vista.GetRowCellValue(i, "MarcaLC").ToString();
                    detalle.ModeloLC = vista.GetRowCellValue(i, "NombreModeloLC").ToString();
                    detalle.IdSalidaDetalle = int.Parse(vista.GetRowCellValue(i, "IdSalidaDetalle").ToString());
                    detalle.IdSucursal = int.Parse(vista.GetRowCellValue(i, "IdSucursal").ToString());
                    detalle.FechaIniContrato = DateTime.Parse(vista.GetRowCellValue(i, "fecIniContrato").ToString());
                    detalle.FechaFinContrato = DateTime.Parse(vista.GetRowCellValue(i, "fecFinContrato").ToString());
                    detalle.FechaIniContratoAntiguo = DateTime.Parse(vista.GetRowCellValue(i, "FechaIniContratoAntiguo").ToString());
                    detalle.FechaFinContratoAntiguo = DateTime.Parse(vista.GetRowCellValue(i, "FechaFinContratoAntiguo").ToString());
                    detalles.Add(detalle);
                    flag = true;
                }
            }
            return flag;
        }
        public BindingList<CorteAlquiler> DETALLES { get => detalles; set => detalles = value; }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (llenarListaLaptops())//Si entra es porque se ha seleccionado almenos solo
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnSeleccionarFilas_Click(object sender, EventArgs e)
        {
            int filas = vista.RowCount;
            for (int i = 0; i < filas; i++)
            {
                vista.SetRowCellValue(i, "Seleccion", true);
            }
        }

        private void btnDeseleccionarFilas_Click(object sender, EventArgs e)
        {
            int filas = vista.RowCount;
            for (int i = 0; i < filas; i++)
            {
                vista.SetRowCellValue(i, "Seleccion", false);
            }
        }

    }
}
