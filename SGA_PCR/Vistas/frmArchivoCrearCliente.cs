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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apolo
{
    public partial class frmArchivoCrearCliente : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaCliente;
        DataTable tablaKAM;
        DataTable tablaTipoDocumento;
        Cliente cliente;
        Cliente clienteOld;
        ClienteDA clienteDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";

        public frmArchivoCrearCliente()
        {
            InitializeComponent();
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public frmArchivoCrearCliente(int idUsuario, string nombreUsuario)
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
            cliente = new Cliente();
            tablaCliente = clienteDA.ListarClientes();

            dgvCliente.PrimaryGrid.AutoGenerateColumns = false;
            dgvCliente.PrimaryGrid.DataSource = tablaCliente;
            

            tablaTipoDocumento = clienteDA.ListarTipoDocumento();
            cmbTipoDocumento.DataSource = tablaTipoDocumento;
            cmbTipoDocumento.DisplayMember = "descripcion";
            cmbTipoDocumento.ValueMember = "idAuxiliar";

            tablaKAM = clienteDA.ListarKams();
            cmbKam.DataSource = tablaKAM;
            cmbKam.DisplayMember = "nombre";
            cmbKam.ValueMember = "idUsuario";
            
        }


        public void estadoComponentes(TipoVista estado)
        {
            switch (estado)
            {
                case TipoVista.Inicial: //ya esta

                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    cmbKam.Enabled = false;
                    cmbTipoDocumento.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTelefono.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    cliente = new Cliente();
                    break;
                case TipoVista.Nuevo: //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    cmbKam.Enabled = true;
                    cmbTipoDocumento.Enabled = true;
                    txtNroDocumento.Enabled = true;
                    txtRazonSocial.Enabled = true;
                    txtEmail.Enabled = true;
                    txtTelefono.Enabled = true;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    cliente = new Cliente();
                    break;
                case TipoVista.Guardar: //ya esta listo
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    cmbKam.Enabled = false;
                    cmbTipoDocumento.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTelefono.Enabled = false;
                    chbActivo.Enabled = false;
                    cliente = new Cliente();
                    dgvCliente.PrimaryGrid.DataSource = null;
                    tablaCliente = clienteDA.ListarClientes();
                    dgvCliente.PrimaryGrid.DataSource = tablaCliente;
                    //limpiarComponentes();
                    break;
                case TipoVista.Modificar://ya esta
                                         //Inicializado(idUsuario, nombreUsuario);

                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    cmbKam.Enabled = true;
                    cmbTipoDocumento.Enabled = true;
                    txtNroDocumento.Enabled = true;
                    txtRazonSocial.Enabled = true;
                    txtEmail.Enabled = true;
                    txtTelefono.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    cliente = new Cliente();
                    break;
                case TipoVista.Vista:
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    cmbKam.Enabled = false;
                    cmbTipoDocumento.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTelefono.Enabled = false;
                    chbActivo.Enabled = false;
                    //limpiarComponentes();
                    cliente = new Cliente();
                    break;
                case TipoVista.Limpiar: //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    cmbKam.Enabled = false;
                    cmbTipoDocumento.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTelefono.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    cliente = new Cliente();
                    break;
                case TipoVista.Duplicar:  //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    cmbKam.Enabled = true;
                    cmbTipoDocumento.Enabled = true;
                    txtNroDocumento.Enabled = true;
                    txtRazonSocial.Enabled = true;
                    txtEmail.Enabled = true;
                    txtTelefono.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    cliente = new Cliente();
                    break;
                case TipoVista.Anular:  //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    cmbKam.Enabled = false;
                    cmbTipoDocumento.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTelefono.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    cliente = new Cliente();
                    break;
            }
        }

        public void limpiarComponentes()
        {
            cmbKam.SelectedIndex = -1;
            cmbTipoDocumento.SelectedIndex = -1;
            txtNroDocumento.Text = "";
            txtRazonSocial.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            chbActivo.Checked = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Nuevo);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GridRow aux = (GridRow)dgvCliente.PrimaryGrid.ActiveRow;
            if (aux != null)
            {
                estadoComponentes(TipoVista.Modificar);
                clienteOld = new Cliente();


                cliente.IdCliente = int.Parse(((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[0])).Value.ToString());
                string nroDocumento = ((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[1])).Value.ToString();
                string nombre = ((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[2])).Value.ToString();
                string nombreKam = ((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[3])).Value.ToString();
                int estado = int.Parse(((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[4])).Value.ToString());
                int tipoDocumento = int.Parse(((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[5])).Value.ToString());
                string telefono = ((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[6])).Value.ToString();
                string email = ((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[7])).Value.ToString();
                int idKam = int.Parse(((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[8])).Value.ToString());
                string nombreTipoDoc = ((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[9])).Value.ToString();

                cmbKam.SelectedValue = idKam;
                cmbTipoDocumento.SelectedValue = tipoDocumento;
                txtNroDocumento.Text = nroDocumento;
                txtRazonSocial.Text = nombre;
                txtEmail.Text = email;
                txtTelefono.Text = telefono;
                chbActivo.Checked = (estado == 1) ? true : false;

                clienteOld.TipoDocumento = tipoDocumento;
                clienteOld.NroDocumento = nroDocumento;
                clienteOld.Nombre_razonSocial = nombre;
                clienteOld.Telefono = telefono;
                clienteOld.Email = email;
                clienteOld.Kam.IdUsuario = idKam;
                clienteOld.Kam.Nombre = nombreKam;
                clienteOld.Estado = estado;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (validarCampos()) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                MessageBox.Show("No se puede crear un Cliente si no\ntiene todos sus datos completos.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            llenar_Datos_Clientes();
            if (cliente.IdCliente == 0)
            {
                if (MessageBox.Show("Estas seguro deseas Crear este Cliente", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idCliente = clienteDA.GuardarNuevoCliente(cliente, this.nombreUsuario);

                    if (idCliente > 0)
                    {
                        MessageBox.Show("Se guardó éxitosamente el Cliente con ID: " + idCliente, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else
                        MessageBox.Show("No se pudo guardar el Cliente", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {

                cliente.Estado = (chbActivo.Checked) ? 1 : 0;


                if (MessageBox.Show("Estas seguro que desea Guardar los cambios", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idCliente;

                    
                    idCliente = clienteDA.ModificarCliente(cliente, this.nombreUsuario);

                    if (idCliente > 0)
                    {
                        MessageBox.Show("Se Modificó el cliente con ID : " + cliente.IdCliente + " con exito", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idCliente == 0)
                        MessageBox.Show("Ya existe un Cliente con las mismas características", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No se pudo guardar los cambios del Cliente", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                }
            }

            Cursor.Current = Cursors.Default;

        }

        //EXPRESIONES REGULARES PARA LAS VALIDACIONES
        private bool validacionSoloNumeros(string numero) //PROBADO
        {
            return Regex.IsMatch(numero, "^[0-9]*$") ? true : false;
        }

        private bool validacionCorreoLeasein(string correo) //PROBADO
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            return Regex.IsMatch(correo, expresion) ? true : false;
        }

        private bool validacionRuc(string documento)
        {
            return documento.Substring(0, 2) == "10" || documento.Substring(0, 2) == "20" ? true : false;
        }

        public bool validarCampos()
        {
            bool isError = false;

            //VALIDACION DOCUMENTO
            if (cmbTipoDocumento.SelectedIndex == -1)
                isError = true;
            else
            {
                if (cmbTipoDocumento.SelectedIndex == 0) //DNI
                {
                    if (validacionSoloNumeros(txtNroDocumento.Text.Trim()) == false || txtNroDocumento.Text.Trim().Length != 8)
                    {
                        //MessageBox.Show("REVISAR EL DNI");
                        isError = true;
                    }
                }
                else if (cmbTipoDocumento.SelectedIndex == 1) //RUC
                {
                    if (validacionSoloNumeros(txtNroDocumento.Text.Trim()) == false || txtNroDocumento.Text.Trim().Length != 11 || validacionRuc(txtNroDocumento.Text.Trim())==false)
                    {
                        //MessageBox.Show("REVISAR EL RUC");
                        isError = true;
                    }
                }
                else //CE
                {
                    if (txtNroDocumento.Text.Trim().Length > 12)
                    {
                        //MessageBox.Show("REVISAR EL CE");
                        isError = true;
                    }
                }

            }

            /*
            if (validacionCorreoLeasein(txtEmail.Text.Trim()) == false)
            {
                //MessageBox.Show("REVISAR EL CORREO");
                isError = true;
            }


            if (validacionSoloNumeros(txtTelefono.Text.Trim()) == false)
            {
                //MessageBox.Show("REVISAR EL TELEFONO");
                isError = true;
            }
            */

            if (txtNroDocumento.Text == "") isError = true;
            if (txtRazonSocial.Text == "") isError = true;
            if (cmbTipoDocumento.SelectedIndex == -1) isError = true;
            if (cmbKam.SelectedIndex == -1) isError = true;
            return isError;
        }


        private void llenar_Datos_Clientes()
        {
            int indice;
            indice = cmbKam.SelectedIndex;
            cliente.Kam.IdUsuario = int.Parse(cmbKam.SelectedValue.ToString());
            cliente.Kam.Nombre = tablaKAM.Rows[indice]["nombre"].ToString();

            indice = cmbTipoDocumento.SelectedIndex;
            cliente.TipoDocumento = int.Parse(cmbTipoDocumento.SelectedValue.ToString());
            
            cliente.NroDocumento = txtNroDocumento.Text;
            cliente.Nombre_razonSocial = txtRazonSocial.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Email = txtEmail.Text;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Anular);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea Imprimir la lista de Clientes", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                MessageBox.Show("Se imprimio la lista de Clientes");
            }

        }

        private void dgvCliente_Click(object sender, EventArgs e)
        {
            GridRow aux = (GridRow)dgvCliente.PrimaryGrid.ActiveRow;
            if (aux != null)
            {
                estadoComponentes(TipoVista.Vista);
                cliente.IdCliente = int.Parse(((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[0])).Value.ToString());
                string nroDocumento = ((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[1])).Value.ToString();
                string nombre = ((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[2])).Value.ToString();
                string nombreKam = ((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[3])).Value.ToString();
                int estado = int.Parse(((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[4])).Value.ToString());
                int tipoDocumento = int.Parse(((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[5])).Value.ToString());
                string telefono = ((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[6])).Value.ToString();
                string email = ((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[7])).Value.ToString();
                int idKam = int.Parse(((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[8])).Value.ToString());
                string nombreTipoDoc = ((GridCell)(((GridRow)dgvCliente.PrimaryGrid.ActiveRow)[9])).Value.ToString();

                cmbKam.SelectedValue = idKam;
                cmbTipoDocumento.SelectedValue = tipoDocumento;
                txtNroDocumento.Text = nroDocumento;
                txtRazonSocial.Text = nombre;
                txtEmail.Text = email;
                txtTelefono.Text = telefono;
                chbActivo.Checked = (estado == 1) ? true : false;
            }

        }

        /*
        private void txtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
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
        */

        private void txtNroDocumento_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
