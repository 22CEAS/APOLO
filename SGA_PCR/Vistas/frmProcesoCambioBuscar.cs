using AccesoDatos;
using DevComponents.DotNetBar.SuperGrid;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apolo
{
    public partial class frmProcesoCambioBuscar : Form
    {
        private Cambio objSeleccionado;
        private CambioDA cambioDA;
        private ClienteDA clienteDA;
        private DataTable tablaKam;
        private DataTable tablaCliente;
        private DataTable tablaEstados;
        private DataTable tablaCambio;

        public frmProcesoCambioBuscar(int idUsuario)
        {
            InitializeComponent();

            inicializarFiltros(idUsuario);

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void inicializarFiltros(int idUsuario)
        {
            cambioDA = new CambioDA();
            clienteDA = new ClienteDA();

            dtpFecProceso.Value = DateTime.Now;

            tablaCliente = clienteDA.ListarClientes();
            cmbCliente.DataSource = tablaCliente;
            cmbCliente.DisplayMember = "nombre_razonSocial";
            cmbCliente.ValueMember = "idCliente";
            cmbCliente.SelectedIndex = 0;

            tablaKam = clienteDA.ListarKams();
            cmbKam.DataSource = tablaKam;
            cmbKam.DisplayMember = "nombre";
            cmbKam.ValueMember = "idUsuario";
            cmbKam.SelectedIndex = 0;

            tablaEstados = cambioDA.ListarEstados();
            cmbEstado.DataSource = tablaEstados;
            cmbEstado.DisplayMember = "nombreEstado";
            cmbEstado.ValueMember = "idEstado";
            cmbEstado.SelectedIndex = 0;

            if (rbtnNumCambio.Checked) txtNumCambio.Enabled = true;
            else txtNumCambio.Enabled = false;
            if (chbEstado.Checked) cmbEstado.Enabled = true;
            else cmbEstado.Enabled = false;
            if (chbKam.Checked) cmbKam.Enabled = true;
            else cmbKam.Enabled = false;
            if (chbCliente.Checked) cmbCliente.Enabled = true;
            else cmbCliente.Enabled = false;
            if (chbFecProceso.Checked) dtpFecProceso.Enabled = true;
            else dtpFecProceso.Enabled = false;
            dgvCambio.PrimaryGrid.AutoGenerateColumns = false;
        }

        public Cambio ObjSeleccionado { get => objSeleccionado; set => objSeleccionado = value; }

        public frmProcesoCambioBuscar()
        {
            InitializeComponent();
        }
        private void cargarDataGridView()
        {

            String sql = "\0";
            DateTime fecha_proceso;


            if (rbtnFiltros.Checked)
            {
                sql = "Where v.idCambio is not null ";
                String sqlFec = ""; String sqlKam = ""; String sqlCli = ""; String sqlEst = "";
                if (chbFecProceso.Checked)
                {

                    fecha_proceso = dtpFecProceso.Value;
                    String dia = fecha_proceso.Day.ToString();
                    String mes = fecha_proceso.Month.ToString();
                    String anho = fecha_proceso.Year.ToString();

                    sqlFec = " AND Cast(v.fechaProceso as DATE) = '" + anho + "-" + mes + "-" + dia + "'";
                    sql = sql + sqlFec;
                }
                if (chbCliente.Checked)
                {
                    if (cmbCliente.SelectedValue == null)
                    {
                        MessageBox.Show("No se puede buscar un Cambio si no\nha seleccionado un Cliente correcto.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                        return;
                    }
                    int idCliente = Convert.ToInt32(cmbCliente.SelectedValue.ToString());
                    sqlCli = " AND v.idCliente = " + idCliente;
                    sql = sql + sqlCli;
                }
                if (chbKam.Checked)
                {
                    if (cmbKam.SelectedValue == null)
                    {
                        MessageBox.Show("No se puede buscar un Cambio si no\nha seleccionado un KAM correcto.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                        return;
                    }
                    int i = cmbKam.SelectedIndex;
                    string nombreKam = tablaKam.Rows[i]["nombre"].ToString();

                    sqlKam = " AND v.nombreKam = '" + nombreKam + "'";
                    sql = sql + sqlKam;
                }
                if (chbEstado.Checked)
                {
                    int idEstado = Convert.ToInt32(cmbEstado.SelectedValue.ToString());
                    sqlEst = " AND v.idEstado = " + idEstado;
                    sql = sql + sqlEst;
                }
            }
            else if (rbtnNumCambio.Checked)
            {
                try
                {
                    sql = "\0";
                    sql = "Where v.idCambio = " + Int32.Parse(txtNumCambio.Text);
                }
                catch
                {
                    MessageBox.Show("El numero de Cambio no es valido", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            tablaCambio = cambioDA.ListarCambio(sql);
            dgvCambio.PrimaryGrid.DataSource = tablaCambio;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            dgvCambio.PrimaryGrid.DataSource = null;
            dgvCambio.PrimaryGrid.Rows.Clear();
            cargarDataGridView();
            Cursor.Current = Cursors.Default;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int i = dgvCambio.PrimaryGrid.ActiveRow.Index;
                int idCambio = int.Parse(((GridCell)(((GridRow)dgvCambio.PrimaryGrid.ActiveRow)[0])).Value.ToString());
                int idEstado = int.Parse(((GridCell)(((GridRow)dgvCambio.PrimaryGrid.ActiveRow)[5])).Value.ToString());
                if (!(i == -1))
                {
                    objSeleccionado = cambioDA.LlamarCambioModificable(idCambio);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch
            {
                MessageBox.Show("No se ha seleccionado ningun Cambio", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Cursor.Current = Cursors.Default;
        }

        private void txtNumCambio_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }

        }

        private void rbtnNumCambio_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNumCambio.Checked)
            {
                panelNumOP.Enabled = true;
                txtNumCambio.Enabled = true;
            }
            else
            {
                panelNumOP.Enabled = false;
                txtNumCambio.Enabled = false;
                txtNumCambio.Text = "";
            }
        }

        private void rbtnFiltros_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnFiltros.Checked)
            {
                panelFiltros.Enabled = true;//cmbEstado.Enabled = true;
                if (chbEstado.Checked) cmbEstado.Enabled = true;
                else cmbEstado.Enabled = false;
                if (chbCliente.Checked) cmbCliente.Enabled = true;
                else cmbCliente.Enabled = false;
                if (chbKam.Checked) cmbKam.Enabled = true;
                else cmbKam.Enabled = false;
                if (chbFecProceso.Checked) dtpFecProceso.Enabled = true;
                else dtpFecProceso.Enabled = false;
            }
            else
            {
                panelFiltros.Enabled = false;//cmbEstado.Enabled = false;
                if (chbEstado.Checked) cmbEstado.Enabled = true;
                else cmbEstado.Enabled = false;
                if (chbCliente.Checked) cmbCliente.Enabled = true;
                else cmbCliente.Enabled = false;
                if (chbKam.Checked) cmbKam.Enabled = true;
                else cmbKam.Enabled = false;
                if (chbFecProceso.Checked) dtpFecProceso.Enabled = true;
                else dtpFecProceso.Enabled = false;
            }

        }
        private void chbFecProceso_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFecProceso.Checked) dtpFecProceso.Enabled = true;
            else dtpFecProceso.Enabled = false;
        }
        private void chbKam_CheckedChanged(object sender, EventArgs e)
        {
            if (chbKam.Checked) cmbKam.Enabled = true;
            else cmbKam.Enabled = false;
        }
        private void chbCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCliente.Checked) cmbCliente.Enabled = true;
            else cmbCliente.Enabled = false;

        }
        private void chbEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEstado.Checked) cmbEstado.Enabled = true;
            else cmbEstado.Enabled = false;

        }
    }
}
