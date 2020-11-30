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
    public partial class frmProcesoRenovacionAgregarProducto : Form
    {
        DataTable tablaLaptops;
        Renovacion detalle;
        BindingList<Renovacion> detalles;
        BindingList<Renovacion> auxiliares;
        RenovacionDA renovacionDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";

        public frmProcesoRenovacionAgregarProducto(int idCliente)
        {
            InitializeComponent();
            Inicializado(idCliente);
        }

        public frmProcesoRenovacionAgregarProducto(int idUsuario, string nombreUsuario, int idCliente)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado(idCliente);
        }

        public void Inicializado(int idCliente)
        {

            renovacionDA = new RenovacionDA();
            detalles = new BindingList<Renovacion>();

            tablaLaptops = renovacionDA.ListarLaptopsClientesEstadoAlquilado(idCliente);
            auxiliares = new BindingList<Renovacion>();
            int rec = 0;
            while (rec < tablaLaptops.Rows.Count)
            {
                Renovacion auxiliar = new Renovacion();
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
                    detalle = new Renovacion();
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
        public BindingList<Renovacion> DETALLES { get => detalles; set => detalles = value; }
        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnAgregarMeses_Click(object sender, EventArgs e)
        {
            //string visibe = (vista.IsRowVisible(i).ToString());
            vista.ClearColumnsFilter();
            int filas = tablaLaptops.Rows.Count;
            string mes = txtCantMeses.Text;
            mes = mes.Trim();

            if (mes.Length > 0)
            {
                for (int i = 0; i < filas; i++)
                {
                    bool aux2 = bool.Parse(vista.GetRowCellValue(i, "Seleccion").ToString());
                    if (aux2)
                    {
                        detalle = new Renovacion();
                        int aux;
                        mes = mes.TrimStart('0');
                        if (mes.Length > 0)
                        {
                            aux = int.Parse(mes);
                            if (aux < 0) mes = "1";
                        }
                        else mes = "1";
                        int meses;
                        meses = mes.Length > 0 ? int.Parse(mes) : 1;

                        detalle.FechaFinContrato = DateTime.Parse(vista.GetRowCellValue(i, "fecFinContrato").ToString());
                        vista.SetRowCellValue(i, "fecFinContrato", detalle.FechaFinContrato.AddMonths(meses));

                    }
                }
                MessageBox.Show("Meses agregados", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tiene que ingresar un número", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtCantMeses_TextChanged(object sender, EventArgs e)
        {
            string myStr = txtCantMeses.Text;
            myStr = myStr.TrimStart('0');
            txtCantMeses.Text = myStr.Length > 0 ? myStr : "1";
        }

        private void txtCantMeses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
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
