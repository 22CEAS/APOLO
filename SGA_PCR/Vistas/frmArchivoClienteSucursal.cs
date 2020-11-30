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
    public partial class frmArchivoClienteSucursal : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaSucursalCliente;
        DataTable tablaCliente;
        ClienteSucursal sucursalCliente;
        ClienteDA clienteDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";

        public frmArchivoClienteSucursal()
        {
            InitializeComponent();
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public frmArchivoClienteSucursal(int idUsuario, string nombreUsuario)
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
            sucursalCliente = new ClienteSucursal();

            tablaCliente = clienteDA.ListarClientes();
            cmbCliente.DataSource = tablaCliente;
            cmbCliente.DisplayMember = "nombre_razonSocial";
            cmbCliente.ValueMember = "idCliente";
            cmbCliente.SelectedIndex = -1;
            dgvSucursalCliente.PrimaryGrid.DataSource = null;
            dgvSucursalCliente.PrimaryGrid.AutoGenerateColumns = false;

        }


        public void estadoComponentes(TipoVista estado)
        {
            switch (estado)
            {
                case TipoVista.Inicial: //ya esta

                    btnNuevo.Enabled = (cmbCliente.SelectedIndex != -1) ? true : false; 
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = (cmbCliente.SelectedIndex != -1) ? true : false; ;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = (cmbCliente.SelectedIndex != -1) ? true : false;
                    cmbCliente.Enabled = true;
                    txtNroDocumento.Enabled = false;
                    txtNombreContacto.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtDireccion.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    sucursalCliente = new ClienteSucursal();
                    break;
                case TipoVista.Nuevo: //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    cmbCliente.Enabled = false;
                    txtNroDocumento.Enabled = true;
                    txtNombreContacto.Enabled = true;
                    txtEmail.Enabled = true;
                    txtTelefono.Enabled = true;
                    txtDireccion.Enabled = true;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    sucursalCliente = new ClienteSucursal();
                    break;
                case TipoVista.Guardar: //ya esta listo
                    btnNuevo.Enabled = (cmbCliente.SelectedIndex != -1) ? true : false; 
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = (cmbCliente.SelectedIndex != -1) ? true : false; ;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = (cmbCliente.SelectedIndex != -1) ? true : false; 
                    cmbCliente.Enabled = true;
                    txtNroDocumento.Enabled = false;
                    txtNombreContacto.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtDireccion.Enabled = false;
                    chbActivo.Enabled = false;
                    sucursalCliente = new ClienteSucursal();
                    //limpiarComponentes();
                    break;
                case TipoVista.Modificar://ya esta
                                         //Inicializado(idUsuario, nombreUsuario);

                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    cmbCliente.Enabled = false;
                    txtNroDocumento.Enabled = true;
                    txtNombreContacto.Enabled = true;
                    txtEmail.Enabled = true;
                    txtTelefono.Enabled = true;
                    txtDireccion.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    sucursalCliente = new ClienteSucursal();
                    break;
                case TipoVista.Vista:
                    btnNuevo.Enabled = (cmbCliente.SelectedIndex != -1) ? true : false; 
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = (cmbCliente.SelectedIndex != -1) ? true : false; ;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = (cmbCliente.SelectedIndex != -1) ? true : false;
                    cmbCliente.Enabled = true;
                    txtNroDocumento.Enabled = false;
                    txtNombreContacto.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtDireccion.Enabled = false;
                    chbActivo.Enabled = false;
                    //limpiarComponentes();
                    sucursalCliente = new ClienteSucursal();
                    break;
                case TipoVista.Limpiar: //ya esta
                    btnNuevo.Enabled = (cmbCliente.SelectedIndex != -1) ? true : false; 
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    cmbCliente.Enabled = true;
                    txtNroDocumento.Enabled = false;
                    txtNombreContacto.Enabled = false;
                    txtEmail.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtTelefono.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    sucursalCliente = new ClienteSucursal();
                    break;
                case TipoVista.Duplicar:  //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    cmbCliente.Enabled = true;
                    txtNroDocumento.Enabled = true;
                    txtNombreContacto.Enabled = true;
                    txtEmail.Enabled = true;
                    txtTelefono.Enabled = true;
                    txtDireccion.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    sucursalCliente = new ClienteSucursal();
                    break;
                case TipoVista.Anular:  //ya esta
                    btnNuevo.Enabled = (cmbCliente.SelectedIndex != -1) ? true : false; 
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = (cmbCliente.SelectedIndex != -1) ? true : false; ;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = (cmbCliente.SelectedIndex != -1) ? true : false;
                    cmbCliente.Enabled = true;
                    txtNroDocumento.Enabled = false;
                    txtNombreContacto.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtDireccion.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    sucursalCliente = new ClienteSucursal();
                    break;
            }
        }

        public void limpiarComponentes()
        {
            txtNroDocumento.Text = "";
            txtNombreContacto.Text = "";
            txtDireccion.Text = "";
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
            GridRow aux = (GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow;
            if (aux != null)
            {
                estadoComponentes(TipoVista.Modificar);


                sucursalCliente.IdSucursal = int.Parse(((GridCell)(((GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow)[0])).Value.ToString());
                sucursalCliente.NroDocumento = ((GridCell)(((GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow)[1])).Value.ToString();
                sucursalCliente.NombreContacto = ((GridCell)(((GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow)[2])).Value.ToString();
                sucursalCliente.Direccion = ((GridCell)(((GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow)[3])).Value.ToString();
                sucursalCliente.Estado = int.Parse(((GridCell)(((GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow)[4])).Value.ToString());
                sucursalCliente.Telefono = ((GridCell)(((GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow)[5])).Value.ToString();
                sucursalCliente.Email = ((GridCell)(((GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow)[6])).Value.ToString();
                sucursalCliente.IdCliente = int.Parse(((GridCell)(((GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow)[7])).Value.ToString());

                cmbCliente.SelectedValue = sucursalCliente.IdCliente;
                txtNroDocumento.Text = sucursalCliente.NroDocumento;
                txtNombreContacto.Text = sucursalCliente.NombreContacto;
                txtEmail.Text = sucursalCliente.Email;
                txtTelefono.Text = sucursalCliente.Telefono;
                txtDireccion.Text = sucursalCliente.Direccion;
                chbActivo.Checked = (sucursalCliente.Estado == 1) ? true : false;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (validarCampos()) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                MessageBox.Show("No se puede crear una Sucursal si no\ntiene todos sus datos completos.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            llenar_Datos_Clientes();
            if (sucursalCliente.IdSucursal == 0)
            {
                if (MessageBox.Show("Estas seguro deseas Crear este Sucursal", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idSucursal = clienteDA.GuardarNuevoSucursal(sucursalCliente, this.nombreUsuario);

                    if (idSucursal > 0)
                    {
                        MessageBox.Show("Se guardó éxitosamente el Sucural con ID: " + idSucursal, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        dgvSucursalCliente.PrimaryGrid.DataSource = null;
                        tablaSucursalCliente = clienteDA.ListarSucursalCliente(sucursalCliente.IdCliente);
                        dgvSucursalCliente.PrimaryGrid.DataSource = tablaSucursalCliente;
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else
                        MessageBox.Show("No se pudo guardar el Sucursal", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                sucursalCliente.Estado = (chbActivo.Checked) ? 1 : 0;

                if (MessageBox.Show("Estas seguro que desea Guardar los cambios", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idSucursal = clienteDA.ModificarSucursal(sucursalCliente, this.nombreUsuario);

                    if (idSucursal > 0)
                    {
                        MessageBox.Show("Se Modificó la sucursal con ID : " + sucursalCliente.IdSucursal + " con exito", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dgvSucursalCliente.PrimaryGrid.DataSource = null;
                        tablaSucursalCliente = clienteDA.ListarSucursalCliente(sucursalCliente.IdCliente);
                        dgvSucursalCliente.PrimaryGrid.DataSource = tablaSucursalCliente;
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idSucursal == 0)
                        MessageBox.Show("Ya existe un Sucursal con las mismas características", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No se pudo guardar los cambios del Sucursal del Cliente", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        //VALIDACIONES CON EXPRESIONES REGULARES
        private bool validacionSoloNumeros(string numero) //PROBADO
        {
            return Regex.IsMatch(numero, "^[0-9]*$") ? true : false;
        }

        private bool validacionSoloLetras(string palabra) //PROBADO
        {
            return Regex.IsMatch(palabra, "^[a-zA-Z ]+$") ? true : false;

        }

        private bool validacionCorreoLeasein(string correo) //PROBADO
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            return Regex.IsMatch(correo, expresion) ? true : false;
        }


        public bool validarCampos()
        {
            bool isError = false;

            /*
            if (validacionCorreoLeasein(txtEmail.Text.Trim()) == false)
                isError=true;

            if (validacionSoloNumeros(txtTelefono.Text.Trim()) == false)
                isError = true;
            */


            if (txtNroDocumento.Text == "") isError = true;
            if (txtNombreContacto.Text == "") isError = true;
            if (txtDireccion.Text == "") isError = true;
            //if (txtEmail.Text == "") isError = true;
            //if (txtTelefono.Text == "") isError = true;
            if (cmbCliente.SelectedIndex == -1) isError = true;
            return isError;
        }


        private void llenar_Datos_Clientes()
        {
            sucursalCliente.IdCliente = int.Parse(cmbCliente.SelectedValue.ToString()); ;
            sucursalCliente.NroDocumento=txtNroDocumento.Text;
            sucursalCliente.NombreContacto=txtNombreContacto.Text ;
            sucursalCliente.Email= txtEmail.Text;
            sucursalCliente.Telefono= txtTelefono.Text;
            sucursalCliente.Direccion= txtDireccion.Text;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Anular);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea Imprimir la lista de Sucursal del cliente", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                MessageBox.Show("Se imprimio la lista de Sucursales del cliente");
            }

        }

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

        private void dgvSucursalCliente_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Vista);
            GridRow aux=(GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow;
            if (aux != null)
            {
                sucursalCliente.IdSucursal = int.Parse(((GridCell)(((GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow)[0])).Value.ToString());
                sucursalCliente.NroDocumento = ((GridCell)(((GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow)[1])).Value.ToString();
                sucursalCliente.NombreContacto = ((GridCell)(((GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow)[2])).Value.ToString();
                sucursalCliente.Direccion = ((GridCell)(((GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow)[3])).Value.ToString();
                sucursalCliente.Estado = int.Parse(((GridCell)(((GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow)[4])).Value.ToString());
                sucursalCliente.Telefono = ((GridCell)(((GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow)[5])).Value.ToString();
                sucursalCliente.Email = ((GridCell)(((GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow)[6])).Value.ToString();
                sucursalCliente.IdCliente = int.Parse(((GridCell)(((GridRow)dgvSucursalCliente.PrimaryGrid.ActiveRow)[7])).Value.ToString());

                cmbCliente.SelectedValue = sucursalCliente.IdCliente;
                txtNroDocumento.Text = sucursalCliente.NroDocumento;
                txtNombreContacto.Text = sucursalCliente.NombreContacto;
                txtEmail.Text = sucursalCliente.Email;
                txtTelefono.Text = sucursalCliente.Telefono;
                txtDireccion.Text = sucursalCliente.Direccion;
                chbActivo.Checked = (sucursalCliente.Estado == 1) ? true : false;
            }
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbCliente.SelectedIndex;
            if (cmbCliente.SelectedIndex != -1)
            {
                //MessageBox.Show(cmbCliente.SelectedValue.ToString());
                //int idCliente = int.Parse(cmbCliente.SelectedValue.ToString());
                int idCliente = Convert.ToInt32(tablaCliente.Rows[i]["idCliente"].ToString());

                tablaSucursalCliente = clienteDA.ListarSucursalCliente(idCliente);

                dgvSucursalCliente.PrimaryGrid.AutoGenerateColumns = false;
                dgvSucursalCliente.PrimaryGrid.DataSource = tablaSucursalCliente;

            }
            estadoComponentes(TipoVista.Inicial);
        }
    }
}
