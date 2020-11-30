using AccesoDatos;
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
using System.Runtime.InteropServices;
using DevComponents.DotNetBar.SuperGrid;

namespace Apolo
{
    public partial class frmProcesoIngresoBuscar : Form
    {
        private Ingreso objSeleccionado;
        private IngresoDA ingresoDA;
        private ProveedorDA proveedorDA;
        private UsuarioDA usuarioDA;
        private DataTable tablaUsuario;
        private DataTable tablaProveedor;
        private DataTable tablaEstados;
        private DataTable tablaAlquiler;

        public frmProcesoIngresoBuscar(int idUsuario)
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
            ingresoDA = new IngresoDA();
            proveedorDA = new ProveedorDA();
            usuarioDA = new UsuarioDA();

            dtpFecProceso.Value = DateTime.Now;

            tablaProveedor = proveedorDA.ListarProveedores();
            cmbProveedor.DataSource = tablaProveedor;
            cmbProveedor.DisplayMember = "razonSocial";
            cmbProveedor.ValueMember = "idProveedor";
            cmbProveedor.SelectedIndex = 0;

            tablaUsuario = usuarioDA.ListarUsuario();
            cmbUsuario.DataSource = tablaUsuario;
            cmbUsuario.DisplayMember = "nombre";
            cmbUsuario.ValueMember = "idUsuario";
            cmbUsuario.SelectedIndex = 0;

            tablaEstados = ingresoDA.ListarEstados();
            cmbEstado.DataSource = tablaEstados;
            cmbEstado.DisplayMember = "nombreEstado";
            cmbEstado.ValueMember = "idEstado";
            cmbEstado.SelectedIndex = 0;

            if (rbtnNumAlquiler.Checked) txtNumIngreso.Enabled = true;
            else txtNumIngreso.Enabled = false;
            if (chbEstado.Checked) cmbEstado.Enabled = true;
            else cmbEstado.Enabled = false;
            if (chbUsuario.Checked) cmbUsuario.Enabled = true;
            else cmbUsuario.Enabled = false;
            if (chbProveedor.Checked) cmbProveedor.Enabled = true;
            else cmbProveedor.Enabled = false;
            if (chbFecProceso.Checked) dtpFecProceso.Enabled = true;
            else dtpFecProceso.Enabled = false;

            dgvIngreso.PrimaryGrid.AutoGenerateColumns = false;
        }

        public Ingreso ObjSeleccionado { get => objSeleccionado; set => objSeleccionado = value; }

        public void inicializarFiltros()
        {
            InitializeComponent();
        }
        private void cargarDataGridView()
        {

            String sql = "\0";
            DateTime fecha_proceso;


            if (rbtnFiltros.Checked)
            {
                sql = "Where v.idIngreso is not null ";
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
                if (chbProveedor.Checked)
                {
                    if (cmbProveedor.SelectedValue == null)
                    {
                        MessageBox.Show("No se puede buscar un Ingreso si no\nha seleccionado un proveedor correcto.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                        return;
                    }

                    int idProveedor = Convert.ToInt32(cmbProveedor.SelectedValue.ToString());
                    sqlCli = " AND v.idProveedor = " + idProveedor;
                    sql = sql + sqlCli;
                }
                if (chbUsuario.Checked)
                {
                    if (cmbUsuario.SelectedValue == null)
                    {
                        MessageBox.Show("No se puede buscar un Ingreso si no\nha seleccionado un usuario correcto.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                        return;
                    }
                    int i = cmbUsuario.SelectedIndex;
                    string nombreKam = tablaUsuario.Rows[i]["usuario"].ToString();

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
            else if (rbtnNumAlquiler.Checked)
            {
                try
                {
                    sql = "\0";
                    sql = "Where v.idIngreso = " + Int32.Parse(txtNumIngreso.Text);
                }
                catch
                {
                    MessageBox.Show("El numero de ingreso no es valido", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            tablaAlquiler = ingresoDA.ListarIngreso(sql);
            dgvIngreso.PrimaryGrid.DataSource = tablaAlquiler;

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvIngreso.PrimaryGrid.DataSource = null;
            dgvIngreso.PrimaryGrid.Rows.Clear();
            cargarDataGridView();
            Cursor.Current = Cursors.Default;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int i = dgvIngreso.PrimaryGrid.ActiveRow.Index;
                int idIngreso = int.Parse(((GridCell)(((GridRow)dgvIngreso.PrimaryGrid.ActiveRow)[0])).Value.ToString());
                int idEstado = int.Parse(((GridCell)(((GridRow)dgvIngreso.PrimaryGrid.ActiveRow)[5])).Value.ToString());
                if (!(i == -1))
                {
                    objSeleccionado = ingresoDA.LlamarIngresoModificable(idIngreso);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch
            {
                MessageBox.Show("No se ha seleccionado ningun ingreso", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Cursor.Current = Cursors.Default;
        }


        private void rbtnNumAlquiler_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNumAlquiler.Checked)
            {
                panelNumOP.Enabled = true;
                txtNumIngreso.Enabled = true;
            }
            else
            {
                panelNumOP.Enabled = false;
                txtNumIngreso.Enabled = false;
                txtNumIngreso.Text = "";
            }
        }

        private void rbtnFiltros_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnFiltros.Checked)
            {
                panelFiltros.Enabled = true;//cmbEstado.Enabled = true;
                if (chbEstado.Checked) cmbEstado.Enabled = true;
                else cmbEstado.Enabled = false;
                if (chbProveedor.Checked) cmbProveedor.Enabled = true;
                else cmbProveedor.Enabled = false;
                if (chbUsuario.Checked) cmbUsuario.Enabled = true;
                else cmbUsuario.Enabled = false;
                if (chbFecProceso.Checked) dtpFecProceso.Enabled = true;
                else dtpFecProceso.Enabled = false;
            }
            else
            {
                panelFiltros.Enabled = false;//cmbEstado.Enabled = false;
                if (chbEstado.Checked) cmbEstado.Enabled = true;
                else cmbEstado.Enabled = false;
                if (chbProveedor.Checked) cmbProveedor.Enabled = true;
                else cmbProveedor.Enabled = false;
                if (chbUsuario.Checked) cmbUsuario.Enabled = true;
                else cmbUsuario.Enabled = false;
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
            if (chbUsuario.Checked) cmbUsuario.Enabled = true;
            else cmbUsuario.Enabled = false;
        }
        private void chbCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chbProveedor.Checked) cmbProveedor.Enabled = true;
            else cmbProveedor.Enabled = false;

        }
        private void chbEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEstado.Checked) cmbEstado.Enabled = true;
            else cmbEstado.Enabled = false;

        }

        private void txtNumIngreso_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
