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
    public partial class frmArchivoCrearProveedor : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaProveedor;
        Proveedor proveedor;
        Proveedor proveedorOld;
        ProveedorDA proveedorDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";

        public frmArchivoCrearProveedor()
        {
            InitializeComponent();
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public frmArchivoCrearProveedor(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public void Inicializado()
        {
            proveedorDA = new ProveedorDA();
            proveedor = new Proveedor();
            tablaProveedor = proveedorDA.ListarProveedores();

            dgvProveedor.PrimaryGrid.AutoGenerateColumns = false;
            dgvProveedor.PrimaryGrid.DataSource = tablaProveedor;
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
                    txtRuc.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    txtAbreviacion.Enabled = false;
                    txtNombreComercial.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtEmail.Enabled = false;
                    txtNombreContacto.Enabled = false;
                    txtTelContacto.Enabled = false;
                    txtEmailContacto.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    proveedor = new Proveedor();
                    break;
                case TipoVista.Nuevo: //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    txtRuc.Enabled = true;
                    txtRazonSocial.Enabled = true;
                    txtAbreviacion.Enabled = true;
                    txtNombreComercial.Enabled = true;
                    txtTelefono.Enabled = true;
                    txtDireccion.Enabled = true;
                    txtEmail.Enabled = true;
                    txtNombreContacto.Enabled = true;
                    txtTelContacto.Enabled = true;
                    txtEmailContacto.Enabled = true;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    proveedor = new Proveedor();
                    break;
                case TipoVista.Guardar: //ya esta listo
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    txtRuc.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    txtAbreviacion.Enabled = false;
                    txtNombreComercial.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtEmail.Enabled = false;
                    txtNombreContacto.Enabled = false;
                    txtTelContacto.Enabled = false;
                    txtEmailContacto.Enabled = false;
                    chbActivo.Enabled = false;
                    proveedor = new Proveedor();
                    dgvProveedor.PrimaryGrid.DataSource = null;
                    tablaProveedor = proveedorDA.ListarProveedores();
                    dgvProveedor.PrimaryGrid.DataSource = tablaProveedor;
                    //limpiarComponentes();
                    break;
                case TipoVista.Modificar://ya esta
                                         //Inicializado(idUsuario, nombreUsuario);

                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    txtRuc.Enabled = true;
                    txtRazonSocial.Enabled = true;
                    txtAbreviacion.Enabled = true;
                    txtNombreComercial.Enabled = true;
                    txtTelefono.Enabled = true;
                    txtDireccion.Enabled = true;
                    txtEmail.Enabled = true;
                    txtNombreContacto.Enabled = true;
                    txtTelContacto.Enabled = true;
                    txtEmailContacto.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    proveedor = new Proveedor();
                    break;
                case TipoVista.Vista:
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    txtRuc.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    txtAbreviacion.Enabled = false;
                    txtNombreComercial.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtEmail.Enabled = false;
                    txtNombreContacto.Enabled = false;
                    txtTelContacto.Enabled = false;
                    txtEmailContacto.Enabled = false;
                    chbActivo.Enabled = false;
                    //limpiarComponentes();
                    proveedor = new Proveedor();
                    break;
                case TipoVista.Limpiar: //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    txtRuc.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    txtAbreviacion.Enabled = false;
                    txtNombreComercial.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtEmail.Enabled = false;
                    txtNombreContacto.Enabled = false;
                    txtTelContacto.Enabled = false;
                    txtEmailContacto.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    proveedor = new Proveedor();
                    break;
                case TipoVista.Duplicar:  //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    txtRuc.Enabled = true;
                    txtRazonSocial.Enabled = true;
                    txtAbreviacion.Enabled = true;
                    txtNombreComercial.Enabled = true;
                    txtTelefono.Enabled = true;
                    txtDireccion.Enabled = true;
                    txtEmail.Enabled = true;
                    txtNombreContacto.Enabled = true;
                    txtTelContacto.Enabled = true;
                    txtEmailContacto.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    proveedor = new Proveedor();
                    break;
                case TipoVista.Anular:  //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    txtRuc.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    txtAbreviacion.Enabled = false;
                    txtNombreComercial.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtEmail.Enabled = false;
                    txtNombreContacto.Enabled = false;
                    txtTelContacto.Enabled = false;
                    txtEmailContacto.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    proveedor = new Proveedor();
                    break;
            }
        }
        public void limpiarComponentes()
        {
            txtRuc.Text = "";
            txtRazonSocial.Text = "";
            txtAbreviacion.Text = "";
            txtNombreComercial.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtNombreContacto.Text = "";
            txtTelContacto.Text = "";
            txtEmailContacto.Text = "";
            chbActivo.Checked = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Modificar);
            proveedorOld = new Proveedor();


            proveedor.IdProveedor = int.Parse(((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[0])).Value.ToString());
            string ruc = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[1])).Value.ToString();
            string razonSocial = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[2])).Value.ToString();
            string nombreComercial = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[5])).Value.ToString();
            string abreviacion = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[3])).Value.ToString();
            string direccion = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[6])).Value.ToString();
            string telefono = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[7])).Value.ToString();
            string fax = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[8])).Value.ToString();
            string email = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[9])).Value.ToString();
            string observacion = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[10])).Value.ToString();
            string nombreContacto = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[11])).Value.ToString();
            string telefonoContacto = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[12])).Value.ToString();
            string emailContacto = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[13])).Value.ToString();
            int estado = int.Parse(((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[4])).Value.ToString());


            txtRuc.Text = ruc;
            txtRazonSocial.Text = razonSocial;
            txtAbreviacion.Text = abreviacion;
            txtNombreComercial.Text = nombreComercial;
            txtTelefono.Text = telefono;
            txtDireccion.Text = direccion;
            txtEmail.Text = email;
            txtNombreContacto.Text = nombreContacto;
            txtTelContacto.Text = telefonoContacto;
            txtEmailContacto.Text = emailContacto;
            chbActivo.Checked = (estado == 1) ? true : false;

            
            proveedorOld.Ruc = ruc;
            proveedorOld.RazonSocial = razonSocial;
            proveedorOld.NombreComercial = nombreComercial;
            proveedorOld.Abreviacion = abreviacion;
            proveedorOld.Direccion = direccion;
            proveedorOld.Telefono = telefono;
            proveedorOld.Fax = fax;
            proveedorOld.Email = email;
            proveedorOld.Observacion = observacion;
            proveedorOld.NombreContacto = nombreContacto;
            proveedorOld.TelefonoContacto = telefonoContacto;
            proveedorOld.EmailContacto = emailContacto;
            proveedorOld.Estado = estado;

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Nuevo);
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (validarCampos()) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                MessageBox.Show("No se puede crear un proveedor si no\ntiene todos sus datos completos.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            llenar_Datos_Proveedor();
            if (proveedor.IdProveedor == 0)
            {
                if (MessageBox.Show("Estas seguro deseas Crear este Proveedor", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idProveedor = proveedorDA.GuardarNuevoProveedor(proveedor, this.nombreUsuario);

                    if (idProveedor > 0)
                    {
                        MessageBox.Show("Se guardó éxitosamente el Proveedor con ID: " + idProveedor, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idProveedor == 0)
                        MessageBox.Show("Ya existe un Proveedor con las mismas características", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No se pudo guardar el Proveedor", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {

                proveedor.Estado = (chbActivo.Checked) ? 1 : 0;
                

                if (MessageBox.Show("Estas seguro que desea Guardar los cambios", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idProveedor;
                 
                    idProveedor = proveedorDA.ModificarProveedor(proveedor, this.nombreUsuario);

                    if (idProveedor > 0)
                    {
                        MessageBox.Show("Se Modificó el proveedor con ID : " + proveedor.IdProveedor + " con exito", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idProveedor == 0)
                        MessageBox.Show("Ya existe un Proveedor con las mismas características", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No se pudo guardar los cambios del Proveedor", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

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

            if (txtRuc.Text == "") isError = true;
            if (txtRuc.Text.Trim().Length==0) isError = true;
            if (txtRazonSocial.Text == "") isError = true;

            if (txtRuc.Text.Trim().Length == 0 || validacionRuc(txtRuc.Text.Trim()) == false || validacionSoloNumeros(txtRuc.Text.Trim())==false || txtRuc.Text.Trim().Length!=11)
                isError = true;

            

            if(txtTelefono.Text.Trim().Length!=0)
            { 
                if (validacionSoloNumeros(txtTelefono.Text.Trim()) == false)
                    isError = true;
            }

            if(txtTelContacto.Text.Trim().Length != 0)
            { 
                if ( validacionSoloNumeros(txtTelContacto.Text.Trim()) == false)
                    isError = true;
            }

            if (txtEmail.Text.Trim().Length != 0)
            { 
                if (validacionCorreoLeasein(txtEmail.Text.Trim()) == false)
                isError = true;
            }

            if (txtEmailContacto.Text.Trim().Length != 0)
            {
                if (validacionCorreoLeasein(txtEmailContacto.Text.Trim()) == false)
                    isError = true;
            }

            if (validacionSoloNumeros(txtAbreviacion.Text.Trim()) == false)
                isError = true;


            if (txtNombreComercial.Text == "") isError = true;
            if (txtDireccion.Text == "") isError = true;
            if (txtAbreviacion.Text == "") isError = true;
            if (txtAbreviacion.Text.Trim().Length == 0) isError = true;

            /*if (txtAbreviacion.Text == "") isError = true;
            if (txtTelefono.Text == "") isError = true;
            if (txtEmail.Text == "") isError = true;
            if (txtNombreContacto.Text == "") isError = true;
            if (txtTelContacto.Text == "") isError = true;
            if (txtEmailContacto.Text == "") isError = true;*/
            return isError;
        }

        private void llenar_Datos_Proveedor()
        {
            proveedor.Ruc = txtRuc.Text;
            proveedor.RazonSocial = txtRazonSocial.Text;
            proveedor.NombreComercial = txtNombreComercial.Text;
            proveedor.Abreviacion = txtAbreviacion.Text;
            proveedor.Direccion = txtDireccion.Text;
            proveedor.Telefono = txtTelefono.Text;
            proveedor.Email = txtEmail.Text;
            proveedor.NombreContacto = txtNombreContacto.Text;
            proveedor.TelefonoContacto = txtTelContacto.Text;
            proveedor.EmailContacto = txtEmailContacto.Text;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Anular);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea Imprimir la lista de Proveedores", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                MessageBox.Show("Se imprimio la lista de Proveedores");
            }
        }

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvProveedor_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Vista);
            proveedor.IdProveedor = int.Parse(((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[0])).Value.ToString());
            string ruc = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[1])).Value.ToString();
            string razonSocial = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[2])).Value.ToString();
            string nombreComercial = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[5])).Value.ToString();
            string abreviacion = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[3])).Value.ToString();
            string direccion = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[6])).Value.ToString();
            string telefono = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[7])).Value.ToString();
            string fax = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[8])).Value.ToString();
            string email = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[9])).Value.ToString();
            string observacion = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[10])).Value.ToString();
            string nombreContacto = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[11])).Value.ToString();
            string telefonoContacto = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[12])).Value.ToString();
            string emailContacto = ((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[13])).Value.ToString();
            int estado = int.Parse(((GridCell)(((GridRow)dgvProveedor.PrimaryGrid.ActiveRow)[4])).Value.ToString());


            txtRuc.Text = ruc;
            txtRazonSocial.Text = razonSocial;
            txtAbreviacion.Text = abreviacion;
            txtNombreComercial.Text = nombreComercial;
            txtTelefono.Text = telefono;
            txtDireccion.Text = direccion;
            txtEmail.Text = email;
            txtNombreContacto.Text = nombreContacto;
            txtTelContacto.Text = telefonoContacto;
            txtEmailContacto.Text = emailContacto;
            chbActivo.Checked = (estado == 1) ? true : false;
        }

        private void txtAbreviacion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
