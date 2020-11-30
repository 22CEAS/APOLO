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
    public partial class frmProcesoSalida : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaLaptopsIngreso;
        DataTable tablaLaptopsSalida;
        DataTable tablaEstadosIngreso;
        DataTable tablaEstadosSalida;
        IngresoSalida proceso;
        IngresoSalidaDA ingresoSalidaDA;

        DataTable tablaMemoria;
        DataTable tablaLicencia;

        LC artTemp;

        private int idUsuario;
        private string nombreUsuario = "CEAS";

        public frmProcesoSalida()
        {
            InitializeComponent();
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public frmProcesoSalida(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }


        public void Inicializado()
        {

            ingresoSalidaDA = new IngresoSalidaDA();

            artTemp = new LC();
            dtpFecIngreso.Value = DateTime.Now;
            dtpFecSalida.Value = DateTime.Now;


            tablaLaptopsIngreso = ingresoSalidaDA.ListarLaptopsPersonalPCR_Prestamo();//Danados y disponibles
            tablaLaptopsSalida = ingresoSalidaDA.ListarLaptopsDisponiblesDanados();//PersonalPCR o PRESTAMO
            tablaEstadosIngreso = ingresoSalidaDA.ListarEstadosIngreso();
            tablaEstadosSalida = ingresoSalidaDA.ListarEstadosSalida();

            cmbEquipoIngreso.DataSource = tablaLaptopsIngreso;
            cmbEquipoIngreso.DisplayMember = "codigo";
            cmbEquipoIngreso.ValueMember = "idLC";
            cmbEquipoIngreso.SelectedIndex = -1;


            cmbEquipoSalida.DataSource = tablaLaptopsSalida;
            cmbEquipoSalida.DisplayMember = "codigo";
            cmbEquipoSalida.ValueMember = "idLC";
            cmbEquipoSalida.SelectedIndex = -1;

            cmbEstadoIngreso.DataSource = tablaEstadosIngreso;
            cmbEstadoIngreso.DisplayMember = "nombreEstado";
            cmbEstadoIngreso.ValueMember = "idEstado";
            cmbEstadoIngreso.SelectedIndex = -1;

            cmbEstadoSalida.DataSource = tablaEstadosSalida;
            cmbEstadoSalida.DisplayMember = "nombreEstado";
            cmbEstadoSalida.ValueMember = "idEstado";
            cmbEstadoSalida.SelectedIndex = -1;

            proceso = new IngresoSalida();
            

        }

        public void ObtenerDatosAlquiler()
        {

            //proceso.IdCliente = Convert.ToInt32(cmbCliente.SelectedValue.ToString());
            //proceso.IdSucursal = Convert.ToInt32(cmbSucursal.SelectedValue.ToString());
            //proceso.FechaSalida = dtpFechaTraslado.Value;
            //proceso.FechaIniContrato = dtpIniPlazo.Value;
            //proceso.FechaFinContrato = dtpFinPlazo.Value;
            //string aux1 = "";
            //aux1 = txtNroContrato.Text;
            //proceso.NroContrato = aux1.Trim();
            //string aux2 = "";
            //aux2 = txtNroOC.Text;
            //proceso.NroOC = aux2.Trim();
            //string aux3 = "";
            //aux3 = txtNroDocumento.Text;
            //proceso.RucDni = aux3.Trim();

        }


        public void estadoComponentes(TipoVista estado)
        {
            switch (estado)
            {
                case TipoVista.Inicial:
                    cmbEstadoSalida.Enabled = false;
                    cmbEstadoIngreso.Enabled = false;
                    cmbEquipoSalida.Enabled = false;
                    cmbEquipoIngreso.Enabled = false;
                    txtClienteIngreso.Enabled = false;
                    txtClienteSalida.Enabled = false;
                    txtDocumentoIngreso.Enabled = false;
                    txtDocumentoSalida.Enabled = false;
                    txtDniIngreso.Enabled = false;
                    txtDniSalida.Enabled = false;
                    dtpFecIngreso.Enabled = false;
                    dtpFecSalida.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    limpiarComponentes();
                    proceso = new IngresoSalida();
                    break;
                case TipoVista.Nuevo:
                    cmbEstadoSalida.Enabled = true;
                    cmbEstadoIngreso.Enabled = true;
                    cmbEquipoSalida.Enabled = true;
                    cmbEquipoIngreso.Enabled = true;
                    txtClienteIngreso.Enabled = true;
                    txtClienteSalida.Enabled = true;
                    txtDocumentoIngreso.Enabled = true;
                    txtDocumentoSalida.Enabled = true;
                    txtDniIngreso.Enabled = true;
                    txtDniSalida.Enabled = true;
                    dtpFecIngreso.Enabled = true;
                    dtpFecSalida.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnGrabar.Enabled = true;
                    limpiarComponentes();
                    proceso = new IngresoSalida();
                    //ObtenerDatosRenovacion();
                    break;
                case TipoVista.Guardar:
                    cmbEstadoSalida.Enabled = false;
                    cmbEstadoIngreso.Enabled = false;
                    cmbEquipoSalida.Enabled = false;
                    cmbEquipoIngreso.Enabled = false;
                    txtClienteIngreso.Enabled = false;
                    txtClienteSalida.Enabled = false;
                    txtDocumentoIngreso.Enabled = false;
                    txtDocumentoSalida.Enabled = false;
                    txtDniIngreso.Enabled = false;
                    txtDniSalida.Enabled = false;
                    dtpFecIngreso.Enabled = false;
                    dtpFecSalida.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    break;
                case TipoVista.Modificar:
                    cmbEstadoSalida.Enabled = true;
                    cmbEstadoIngreso.Enabled = true;
                    cmbEquipoSalida.Enabled = true;
                    cmbEquipoIngreso.Enabled = true;
                    txtClienteIngreso.Enabled = true;
                    txtClienteSalida.Enabled = true;
                    txtDocumentoIngreso.Enabled = true;
                    txtDocumentoSalida.Enabled = true;
                    txtDniIngreso.Enabled = true;
                    txtDniSalida.Enabled = true;
                    dtpFecIngreso.Enabled = true;
                    dtpFecSalida.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnGrabar.Enabled = true;
                    break;
                case TipoVista.Vista:
                    cmbEstadoSalida.Enabled = false;
                    cmbEstadoIngreso.Enabled = false;
                    cmbEquipoSalida.Enabled = false;
                    cmbEquipoIngreso.Enabled = false;
                    txtClienteIngreso.Enabled = false;
                    txtClienteSalida.Enabled = false;
                    txtDocumentoIngreso.Enabled = false;
                    txtDocumentoSalida.Enabled = false;
                    txtDniIngreso.Enabled = false;
                    txtDniSalida.Enabled = false;
                    dtpFecIngreso.Enabled = false;
                    dtpFecSalida.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    proceso = new IngresoSalida();
                    break;
                case TipoVista.Limpiar:
                    cmbEstadoSalida.Enabled = false;
                    cmbEstadoIngreso.Enabled = false;
                    cmbEquipoSalida.Enabled = false;
                    cmbEquipoIngreso.Enabled = false;
                    txtClienteIngreso.Enabled = false;
                    txtClienteSalida.Enabled = false;
                    txtDocumentoIngreso.Enabled = false;
                    txtDocumentoSalida.Enabled = false;
                    txtDniIngreso.Enabled = false;
                    txtDniSalida.Enabled = false;
                    dtpFecIngreso.Enabled = false;
                    dtpFecSalida.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    limpiarComponentes();
                    proceso = new IngresoSalida();
                    break;
                case TipoVista.Duplicar:
                    cmbEstadoSalida.Enabled = false;
                    cmbEstadoIngreso.Enabled = false;
                    cmbEquipoSalida.Enabled = false;
                    cmbEquipoIngreso.Enabled = false;
                    txtClienteIngreso.Enabled = false;
                    txtClienteSalida.Enabled = false;
                    txtDocumentoIngreso.Enabled = false;
                    txtDocumentoSalida.Enabled = false;
                    txtDniIngreso.Enabled = false;
                    txtDniSalida.Enabled = false;
                    dtpFecIngreso.Enabled = false;
                    dtpFecSalida.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    limpiarComponentes();
                    proceso = new IngresoSalida();
                    break;
                case TipoVista.Anular:
                    cmbEstadoSalida.Enabled = false;
                    cmbEstadoIngreso.Enabled = false;
                    cmbEquipoSalida.Enabled = false;
                    cmbEquipoIngreso.Enabled = false;
                    txtClienteIngreso.Enabled = false;
                    txtClienteSalida.Enabled = false;
                    txtDocumentoIngreso.Enabled = false;
                    txtDocumentoSalida.Enabled = false;
                    txtDniIngreso.Enabled = false;
                    txtDniSalida.Enabled = false;
                    dtpFecIngreso.Enabled = false;
                    dtpFecSalida.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    break;
            }
        }

        public void limpiarComponentes()
        {

            tablaLaptopsIngreso.Rows.Clear();
            tablaLaptopsSalida.Rows.Clear();

            tablaLaptopsIngreso = ingresoSalidaDA.ListarLaptopsPersonalPCR_Prestamo();
            tablaLaptopsSalida = ingresoSalidaDA.ListarLaptopsDisponiblesDanados();


            cmbEquipoIngreso.DataSource = tablaLaptopsIngreso;
            cmbEquipoIngreso.DisplayMember = "codigo";
            cmbEquipoIngreso.ValueMember = "idLC";
            cmbEquipoIngreso.SelectedIndex = -1;

            cmbEquipoSalida.DataSource = tablaLaptopsSalida;
            cmbEquipoSalida.DisplayMember = "codigo";
            cmbEquipoSalida.ValueMember = "idLC";
            cmbEquipoSalida.SelectedIndex = -1;


            txtClienteIngreso.Text = "";
            txtClienteSalida.Text = "";
            txtDocumentoIngreso.Text = "";
            txtDocumentoSalida.Text = "";
            txtDniIngreso.Text = "";
            txtDniSalida.Text = "";
            //cmbEquipoIngreso.SelectedIndex = -1;
            //cmbEquipoSalida.SelectedIndex = -1;
            cmbEstadoIngreso.SelectedIndex = -1;
            cmbEstadoSalida.SelectedIndex = -1;
            dtpFecIngreso.Value = DateTime.Now;
            dtpFecSalida.Value = DateTime.Now;

            if (rbtnIngreso.Checked)
            {
                groupBoxIngreso.Enabled = true;
                groupBoxSalida.Enabled = false;
            }
            else
            {
                groupBoxSalida.Enabled = true;
                groupBoxIngreso.Enabled = false;
            }
        }

        public void ObtenerDatos()
        {
            if (rbtnIngreso.Checked)
            {
                proceso.NombreCliente = txtClienteIngreso.Text;
                proceso.NombreCliente = proceso.NombreCliente.Trim();
                proceso.NombreCliente = proceso.NombreCliente.ToUpper();

                proceso.NroIdentidad = txtDniIngreso.Text;
                proceso.NroIdentidad = proceso.NroIdentidad.Trim();

                proceso.DocumentoReferencia = txtDocumentoIngreso.Text;
                proceso.DocumentoReferencia = proceso.DocumentoReferencia.Trim();

                proceso.FechaIngresoSalida = dtpFecIngreso.Value;

                int i = cmbEquipoIngreso.SelectedIndex;
                if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
                {
                    
                    proceso.IdLC = Convert.ToInt32(tablaLaptopsIngreso.Rows[i]["idLC"].ToString());
                    proceso.CodigoLC = tablaLaptopsIngreso.Rows[i]["codigo"].ToString();
                    proceso.IdEstadoAnt = Convert.ToInt32(tablaLaptopsIngreso.Rows[i]["idEstado"].ToString());
                }
                else
                {
                    proceso.IdLC = 0;
                    proceso.CodigoLC = "";
                }

                i = cmbEstadoIngreso.SelectedIndex;
                if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
                {

                    proceso.IdEstado = Convert.ToInt32(tablaEstadosIngreso.Rows[i]["idEstado"].ToString());
                    proceso.NombreEstado = tablaEstadosIngreso.Rows[i]["nombreEstado"].ToString();
                }
                else
                {
                    proceso.IdEstado = 0;
                    proceso.NombreEstado = "";
                }
            }
            else
            {
                proceso.NombreCliente = txtClienteSalida.Text;
                proceso.NombreCliente = proceso.NombreCliente.Trim();
                proceso.NombreCliente = proceso.NombreCliente.ToUpper();

                proceso.NroIdentidad = txtDniSalida.Text;
                proceso.NroIdentidad = proceso.NroIdentidad.Trim();

                proceso.DocumentoReferencia = txtDocumentoSalida.Text;
                proceso.DocumentoReferencia = proceso.DocumentoReferencia.Trim();

                proceso.FechaIngresoSalida = dtpFecSalida.Value;

                int i = cmbEquipoSalida.SelectedIndex;
                if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
                {

                    proceso.IdLC = Convert.ToInt32(tablaLaptopsSalida.Rows[i]["idLC"].ToString());
                    proceso.CodigoLC = tablaLaptopsSalida.Rows[i]["codigo"].ToString();
                    proceso.IdEstadoAnt = Convert.ToInt32(tablaLaptopsSalida.Rows[i]["idEstado"].ToString());
                }
                else
                {
                    proceso.IdLC = 0;
                    proceso.CodigoLC = "";
                }

                i = cmbEstadoSalida.SelectedIndex;
                if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
                {

                    proceso.IdEstado = Convert.ToInt32(tablaEstadosSalida.Rows[i]["idEstado"].ToString());
                    proceso.NombreEstado = tablaEstadosSalida.Rows[i]["nombreEstado"].ToString();
                }
                else
                {
                    proceso.IdEstado = 0;
                    proceso.NombreEstado = "";
                }
            }
        }

        public bool validarDatos()
        {
            if (rbtnIngreso.Checked)
            {
                if (cmbEquipoIngreso.SelectedValue == null)
                {
                    MessageBox.Show("No se puede realizar el proceso\n si no se ha seleccionado una laptop correcta.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }
                if (cmbEstadoIngreso.SelectedValue == null)
                {
                    MessageBox.Show("No se puede realizar el proceso\n si no se ha seleccionado un estado correcto.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }

                string aux ="";
                aux = txtClienteIngreso.Text;
                aux = aux.Trim();

                if (aux.Length == 0)
                {
                    MessageBox.Show("No se puede realizar el proceso\n si no se a escrito el nombre de la persona.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }

                aux = txtDniIngreso.Text;
                aux = aux.Trim();

                if (aux.Length == 0)
                {
                    MessageBox.Show("No se puede realizar el proceso\n si no se a escrito el documento de identidad.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }

                aux = txtDocumentoIngreso.Text;
                aux = aux.Trim();

                if (aux.Length == 0)
                {
                    MessageBox.Show("No se puede realizar el proceso\n si no se a escrito el documento de referencia.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }

            }
            else
            {
                if (cmbEquipoSalida.SelectedValue == null)
                {
                    MessageBox.Show("No se puede realizar el proceso\n si no se ha seleccionado una laptop correcta.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }
                if (cmbEstadoSalida.SelectedValue == null)
                {
                    MessageBox.Show("No se puede realizar el proceso\n si no se ha seleccionado un estado correcto.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }
                string aux = "";
                aux = txtClienteSalida.Text;
                aux = aux.Trim();

                if (aux.Length == 0)
                {
                    MessageBox.Show("No se puede realizar el proceso\n si no se a escrito el nombre de la persona.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }

                aux = txtDniSalida.Text;
                aux = aux.Trim();

                if (aux.Length == 0)
                {
                    MessageBox.Show("No se puede realizar el proceso\n si no se a escrito el documento de identidad.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }

                aux = txtDocumentoSalida.Text;
                aux = aux.Trim();

                if (aux.Length == 0)
                {
                    MessageBox.Show("No se puede realizar el proceso\n si no se a escrito el documento de referencia.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Nuevo);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (validarDatos())
            {
                ObtenerDatos();
                if (MessageBox.Show("Estas seguro que deseas Guardar este proceso", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int aux = (rbtnIngreso.Checked) ? 1 : 2;
                    int error = 0;
                    error = ingresoSalidaDA.InsertarProceso(proceso, aux, this.nombreUsuario);

                    if (error == 0)
                    {
                        MessageBox.Show("Hubo error en el registro, comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    MessageBox.Show("Se guradó el proceso", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    
                    estadoComponentes(TipoVista.Guardar);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas cancelar el proceso", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                estadoComponentes(TipoVista.Limpiar);
                proceso = new IngresoSalida();
            }
        }

        private void rbtnIngreso_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnIngreso.Checked)
            {
                groupBoxIngreso.Enabled = true;
                txtClienteSalida.Text = "";
                txtDocumentoSalida.Text = "";
                txtDniSalida.Text = "";
                cmbEquipoSalida.SelectedIndex = -1;
                cmbEstadoSalida.SelectedIndex = -1;
                dtpFecSalida.Value = DateTime.Now;
            }
            else
            {
                groupBoxIngreso.Enabled = false;
            }
        }

        private void rbtnSalida_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSalida.Checked)
            {
                groupBoxSalida.Enabled = true;
                txtClienteIngreso.Text = "";
                txtDocumentoIngreso.Text = "";
                txtDniIngreso.Text = "";
                cmbEquipoIngreso.SelectedIndex = -1;
                cmbEstadoIngreso.SelectedIndex = -1;
                dtpFecIngreso.Value = DateTime.Now;
            }
            else
            {
                groupBoxSalida.Enabled = false;
            }
        }
    }
}
