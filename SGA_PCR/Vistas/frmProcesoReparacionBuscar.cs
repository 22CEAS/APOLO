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
    public partial class frmProcesoReparacionBuscar : Form
    {
        private Reparacion objSeleccionado;
        private ReparacionDA reparacionDA;

        private DataTable tablaResponsable;
        private DataTable tablaCodigoLC;
        private DataTable tablaEstados;
        private DataTable tablaCambio;

        public frmProcesoReparacionBuscar(int idUsuario)
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
            reparacionDA = new ReparacionDA();

            dtpFecProceso.Value = DateTime.Now;

            tablaCodigoLC = reparacionDA.ListarCodigosLC();
            cmbCodigoLC.DataSource = tablaCodigoLC;
            cmbCodigoLC.DisplayMember = "codigo";
            cmbCodigoLC.ValueMember = "idLC";
            cmbCodigoLC.SelectedIndex = 0;

            tablaResponsable = reparacionDA.ListarResponsable();
            cmbResponsable.DataSource = tablaResponsable;
            cmbResponsable.DisplayMember = "nombre";
            cmbResponsable.ValueMember = "idUsuario";
            cmbResponsable.SelectedIndex = 0;

            tablaEstados = reparacionDA.ListarTodosEstados();
            cmbEstado.DataSource = tablaEstados;
            cmbEstado.DisplayMember = "nombreEstado";
            cmbEstado.ValueMember = "idEstado";
            cmbEstado.SelectedIndex = 0;

            if (rbtnNumReparacion.Checked) txtNumCambio.Enabled = true;
            else txtNumCambio.Enabled = false;
            if (chbEstado.Checked) cmbEstado.Enabled = true;
            else cmbEstado.Enabled = false;
            if (chbResponsable.Checked) cmbResponsable.Enabled = true;
            else cmbResponsable.Enabled = false;
            if (chbCodigoLC.Checked) cmbCodigoLC.Enabled = true;
            else cmbCodigoLC.Enabled = false;
            if (chbFecProceso.Checked) dtpFecProceso.Enabled = true;
            else dtpFecProceso.Enabled = false;
            dgvReparacion.PrimaryGrid.AutoGenerateColumns = false;
        }

        public Reparacion ObjSeleccionado { get => objSeleccionado; set => objSeleccionado = value; }

        public frmProcesoReparacionBuscar()
        {
            InitializeComponent();
        }

        private void cargarDataGridView()
        {

            String sql = "\0";
            DateTime fecha_proceso;


            if (rbtnFiltros.Checked)
            {
                sql = "Where v.idReparacion is not null ";
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
                if (chbCodigoLC.Checked)
                {
                    if (cmbCodigoLC.SelectedValue == null)
                    {
                        MessageBox.Show("No se puede buscar una Reparacion si no\nha seleccionado un codigo correcto.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                        return;
                    }

                    int idLC = Convert.ToInt32(cmbCodigoLC.SelectedValue.ToString());
                    sqlCli = " AND v.idLC = " + idLC;
                    sql = sql + sqlCli;
                }
                if (chbResponsable.Checked)
                {
                    if (cmbResponsable.SelectedValue == null)
                    {
                        MessageBox.Show("No se puede buscar una Reparacion si no\nha seleccionado un responsable correcto.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                        return;
                    }
                    int i = cmbResponsable.SelectedIndex;
                    string nombreResponsable = tablaResponsable.Rows[i]["usuario"].ToString();

                    sqlKam = " AND v.nombreResponsable = '" + nombreResponsable + "'";
                    sql = sql + sqlKam;
                }
                if (chbEstado.Checked)
                {
                    int idEstado = Convert.ToInt32(cmbEstado.SelectedValue.ToString());
                    sqlEst = " AND v.idEstado = " + idEstado;
                    sql = sql + sqlEst;
                }
            }
            else if (rbtnNumReparacion.Checked)
            {
                try
                {
                    sql = "\0";
                    sql = "Where v.idReparacion = " + Int32.Parse(txtNumCambio.Text);
                }
                catch
                {
                    MessageBox.Show("El numero de Reparacion no es valido", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            tablaCambio = reparacionDA.ListarReparaciones(sql);
            dgvReparacion.PrimaryGrid.DataSource = tablaCambio;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            dgvReparacion.PrimaryGrid.DataSource = null;
            dgvReparacion.PrimaryGrid.Rows.Clear();
            cargarDataGridView();
            Cursor.Current = Cursors.Default;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int i = dgvReparacion.PrimaryGrid.ActiveRow.Index;
                int idReparacion = int.Parse(((GridCell)(((GridRow)dgvReparacion.PrimaryGrid.ActiveRow)[0])).Value.ToString());
                int idEstado = int.Parse(((GridCell)(((GridRow)dgvReparacion.PrimaryGrid.ActiveRow)[5])).Value.ToString());
                if (!(i == -1))
                {
                    objSeleccionado = reparacionDA.LlamarReparacionModificable(idReparacion);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch
            {
                MessageBox.Show("No se ha seleccionado ninguna Reparacion", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void rbtnNumReparacion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNumReparacion.Checked)
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
                if (chbCodigoLC.Checked) cmbCodigoLC.Enabled = true;
                else cmbCodigoLC.Enabled = false;
                if (chbResponsable.Checked) cmbResponsable.Enabled = true;
                else cmbResponsable.Enabled = false;
                if (chbFecProceso.Checked) dtpFecProceso.Enabled = true;
                else dtpFecProceso.Enabled = false;
            }
            else
            {
                panelFiltros.Enabled = false;//cmbEstado.Enabled = false;
                if (chbEstado.Checked) cmbEstado.Enabled = true;
                else cmbEstado.Enabled = false;
                if (chbCodigoLC.Checked) cmbCodigoLC.Enabled = true;
                else cmbCodigoLC.Enabled = false;
                if (chbResponsable.Checked) cmbResponsable.Enabled = true;
                else cmbResponsable.Enabled = false;
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
            if (chbResponsable.Checked) cmbResponsable.Enabled = true;
            else cmbResponsable.Enabled = false;
        }
        private void chbCodigoLC_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCodigoLC.Checked) cmbCodigoLC.Enabled = true;
            else cmbCodigoLC.Enabled = false;

        }
        private void chbEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEstado.Checked) cmbEstado.Enabled = true;
            else cmbEstado.Enabled = false;

        }
    }
}
