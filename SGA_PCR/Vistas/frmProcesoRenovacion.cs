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
using Excel = Microsoft.Office.Interop.Excel;

namespace Apolo
{
    public partial class frmProcesoRenovacion : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaCliente;
        DataTable tablaLaptops;
        DataTable tablaSalidasTipos;
        ClienteDA clienteDA;
        AlquilerDA alquilerDA;
        RenovacionDA renovacionDA;
        BindingList<Renovacion> renovaciones;
        Renovacion renovacionTemp;

        int IdCliente;
        String DocumentoReferencia;
        String NumeroDniRuc;

        int IdSalidaTipo;
        String NombreSalidaTipo;

        private int idUsuario;
        private string nombreUsuario = "CEAS";
        private int idPalabra =3;


        public frmProcesoRenovacion()
        {
            InitializeComponent();
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public frmProcesoRenovacion(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public void Inicializado()
        {

            clienteDA = new ClienteDA();
            alquilerDA = new AlquilerDA();
            renovacionDA = new RenovacionDA();
            renovaciones = new BindingList<Renovacion>();

            renovacionTemp = new Renovacion();

            tablaCliente = clienteDA.ListarClientes();
            cmbCliente.DataSource = tablaCliente;
            cmbCliente.DisplayMember = "nombre_razonSocial";
            cmbCliente.ValueMember = "idCliente";
            cmbCliente.SelectedIndex = 0;
            int i = cmbCliente.SelectedIndex;

            int idCliente = Convert.ToInt32(tablaCliente.Rows[i]["idCliente"].ToString());
            txtNroDocumento.Text = tablaCliente.Rows[i]["nroDocumento"].ToString();

            tablaLaptops = renovacionDA.ListarLaptopsClientesEstadoAlquilado(idCliente);

            tablaSalidasTipos = renovacionDA.ListarSalidasTipo();
            cmbTipoSalida.DataSource = tablaSalidasTipos;
            cmbTipoSalida.DisplayMember = "descripcion";
            cmbTipoSalida.ValueMember = "idAuxiliar";

            ObtenerDatosRenovacion();
            dgvLaptopsSeleccionados.PrimaryGrid.AutoGenerateColumns = false;

        }

        public void ObtenerDatosRenovacion()
        {

            IdCliente = Convert.ToInt32(cmbCliente.SelectedValue.ToString());
            string aux1 = "";
            aux1 = txtReferencia.Text;
            DocumentoReferencia = aux1.Trim();
            string aux2 = "";
            aux2 = txtNroDocumento.Text;
            NumeroDniRuc = aux2.Trim();

            
            int i = cmbTipoSalida.SelectedIndex;
            if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                IdSalidaTipo = Convert.ToInt32(tablaSalidasTipos.Rows[i]["idAuxiliar"].ToString());
                NombreSalidaTipo = tablaSalidasTipos.Rows[i]["descripcion"].ToString();
            }
            else
            {
                NombreSalidaTipo = "";
            }

        }

        public void estadoComponentes(TipoVista estado)
        {
            switch (estado)
            {
                case TipoVista.Inicial:
                    cmbCliente.Enabled = false;
                    cmbTipoSalida.Enabled = false;
                    txtReferencia.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnBorrar.Enabled = false;
                    limpiarComponentes();
                    renovaciones = new BindingList<Renovacion>();
                    break;
                case TipoVista.Nuevo:
                    cmbCliente.Enabled = true;
                    cmbTipoSalida.Enabled = true;
                    txtReferencia.Enabled = true;
                    txtNroDocumento.Enabled = true;
                    dgvLaptopsSeleccionados.Enabled = true;
                    btnAgregarProducto.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnGrabar.Enabled = true;
                    btnBorrar.Enabled = true;
                    limpiarComponentes();
                    renovaciones = new BindingList<Renovacion>();
                    ObtenerDatosRenovacion();
                    break;
                case TipoVista.Guardar:
                    cmbCliente.Enabled = false;
                    cmbTipoSalida.Enabled = false;
                    txtReferencia.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnBorrar.Enabled = false;
                    break;
                case TipoVista.Modificar:
                    cmbCliente.Enabled = true;
                    cmbTipoSalida.Enabled = true;
                    txtReferencia.Enabled = true;
                    txtNroDocumento.Enabled = true;
                    dgvLaptopsSeleccionados.Enabled = true;
                    btnAgregarProducto.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnGrabar.Enabled = true;
                    btnBorrar.Enabled = true;
                    break;
                case TipoVista.Vista:
                    cmbCliente.Enabled = false;
                    cmbTipoSalida.Enabled = false;
                    txtReferencia.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnBorrar.Enabled = false;
                    renovaciones = new BindingList<Renovacion>();
                    break;
                case TipoVista.Limpiar:
                    cmbCliente.Enabled = false;
                    cmbTipoSalida.Enabled = false;
                    txtReferencia.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnBorrar.Enabled = false;
                    limpiarComponentes();
                    renovaciones = new BindingList<Renovacion>();
                    break;
                case TipoVista.Duplicar:
                    cmbCliente.Enabled = false;
                    cmbTipoSalida.Enabled = false;
                    txtReferencia.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnBorrar.Enabled = false;
                    limpiarComponentes();
                    renovaciones = new BindingList<Renovacion>();
                    break;
                case TipoVista.Anular:
                    cmbCliente.Enabled = false;
                    cmbTipoSalida.Enabled = false;
                    txtReferencia.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnBorrar.Enabled = false;
                    break;
            }
        }

        public void limpiarComponentes()
        {
            txtReferencia.Text = "";
            cmbCliente.SelectedIndex = 0;
            cmbTipoSalida.SelectedIndex = -1;
            dgvLaptopsSeleccionados.PrimaryGrid.DataSource = null;
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

            int i = cmbCliente.SelectedIndex;
            if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                renovaciones = new BindingList<Renovacion>();
                IdCliente = Convert.ToInt32(tablaCliente.Rows[i]["idCliente"].ToString());
                txtNroDocumento.Text = tablaCliente.Rows[i]["nroDocumento"].ToString();
                tablaLaptops = null;
                dgvLaptopsSeleccionados.PrimaryGrid.DataSource = null;
            }
            else
            {
                txtNroDocumento.Text = "";
            }

        }

        public void LlenarDatosDevolucion()
        {
            txtNroDocumento.Text = NumeroDniRuc;
            txtReferencia.Text = DocumentoReferencia;
            cmbCliente.SelectedValue = IdCliente;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Nuevo);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;            

            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("No se puede grabar una Renovacion si no\nha seleccionado un cliente correcto.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return;
            }

            ObtenerDatosRenovacion();

            foreach (Renovacion rev in renovaciones)
            {
                if (rev.FechaIniContrato > rev.FechaFinContrato)
                {
                    MessageBox.Show("No se puede grabar si hay una fecha Final de Plazo de Alquiler menor a la fecha inicial", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    return;
                }
            }


            if (renovaciones.Count == 0)
            {
                MessageBox.Show("No se puede grabar si no hay ninguna laptop.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                return;
            }

            
            if (cmbTipoSalida.SelectedValue == null)
            {
                MessageBox.Show("No se puede grabar una Renovacion si no\nha seleccionado un tipo de renovación.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return;
            }
            else if (Convert.ToInt32(cmbTipoSalida.SelectedValue.ToString()) != this.idPalabra && DocumentoReferencia.Length == 0)
            {
                MessageBox.Show("Si se ha seleccionado Orden de Compra o Contrato ingrese un documento", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return;
            }


            if (MessageBox.Show("Estas seguro que deseas Guardar este proceso de Renovación", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                int error = 0;
                error = renovacionDA.InsertarRenovaciones(renovaciones, this.nombreUsuario,DocumentoReferencia,IdSalidaTipo, NombreSalidaTipo);

                if (error == 0)
                {
                    MessageBox.Show("Hubo error en el registro, comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                MessageBox.Show("Se guradó las renovaciones", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                estadoComponentes(TipoVista.Guardar);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas cancelar el proceso", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                estadoComponentes(TipoVista.Limpiar);
                renovaciones = new BindingList<Renovacion>();
                dgvLaptopsSeleccionados.PrimaryGrid.DataSource = null;
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("No se puede agregar productos\n si no se ha seleccionado un cliente correcto.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return;
            }
            using (frmProcesoRenovacionAgregarProducto frm = new frmProcesoRenovacionAgregarProducto(IdCliente))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindingList<Renovacion> auxiliares = new BindingList<Renovacion>();
                    foreach (Renovacion aux in renovaciones)
                    {
                        auxiliares.Add(aux);
                    }

                    foreach (Renovacion detalleTraido in frm.DETALLES)
                    {
                        Renovacion dp = new Renovacion();
                        dp.IdLC = detalleTraido.IdLC;
                        bool exists = auxiliares.Any(x => x.IdLC.Equals(dp.IdLC));
                        if (!(exists))
                        {
                            auxiliares.Add(detalleTraido);
                        }
                    }
                    renovaciones = auxiliares;
                }
            }

            dgvLaptopsSeleccionados.PrimaryGrid.DataSource = renovaciones;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvLaptopsSeleccionados.PrimaryGrid.Rows.Count > 0)
            {
                if (MessageBox.Show("Estas seguro deseas Eliminar esta laptop de tu detalle", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    bool error;
                    renovacionTemp.IdLC = int.Parse(((GridCell)(((GridRow)dgvLaptopsSeleccionados.PrimaryGrid.ActiveRow)[5])).Value.ToString());

                    int indiceLC = 0;
                    foreach (Renovacion detalle in renovaciones)
                    {
                        if (detalle.IdLC == renovacionTemp.IdLC)
                        {
                            break;
                        }
                        indiceLC++;
                    }

                    renovaciones.RemoveAt(indiceLC);

                    dgvLaptopsSeleccionados.PrimaryGrid.DataSource = renovaciones;
                }
            }

        }
    }
}
