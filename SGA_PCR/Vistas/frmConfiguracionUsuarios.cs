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
    public partial class frmConfiguracionUsuarios : Form
    {

        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular , Cancelar}

        DataTable tablaAreas;
        DataTable tablaPerfiles;
        DataTable tablaEstados;
        DataTable tablaUsuarios;

        Area area;
        AreaDA areaDA;

        Perfil perfil;
        PerfilDA perfilDA;

        Estados estados;
        EstadosDA estadosDA;

        Usuario usuario;
        UsuarioDA usuarioDA;

        public frmConfiguracionUsuarios()
        {
            InitializeComponent();
            estadoComponentes(TipoVista.Inicial);
            Inicializando();
        }


        public void Inicializando()
        {
            areaDA = new AreaDA();
            area = new Area();

            perfilDA = new PerfilDA();
            perfil = new Perfil();

            estadosDA= new EstadosDA();
            estados = new Estados();

            usuarioDA = new UsuarioDA();
            usuario = new Usuario();

            //! AREA
            tablaAreas = areaDA.ListarAreas();
            cmbArea.DataSource = tablaAreas;
            cmbArea.DisplayMember = "descripcionArea";
            cmbArea.ValueMember = "idArea";

            //! PERFIL
            tablaPerfiles = perfilDA.ListarPerfiles();
            cmbPerfil.DataSource = tablaPerfiles;
            cmbPerfil.DisplayMember = "descripcion";
            cmbPerfil.ValueMember = "idPerfil";


            //! ESTADO
            tablaEstados = estadosDA.ListarEstados();
            cmbEstado.DataSource = tablaEstados;
            cmbEstado.DisplayMember = "nombreEstado";
            cmbEstado.ValueMember = "idEstado";


            cmbArea.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbPerfil.SelectedIndex = -1;

            llenadoTablaUsuarios();
        }

        public void llenadoTablaUsuarios()
        {
            //RELLENAR TABLA DE USUARIOS
            tablaUsuarios = usuarioDA.ListarUsuario();
            dgvUsuarios.PrimaryGrid.AutoGenerateColumns = false;
            dgvUsuarios.PrimaryGrid.DataSource = tablaUsuarios;
        }


        public void estadoComponentes(TipoVista estado)
        {
            switch (estado)
            {
                case TipoVista.Inicial: //ya esta

                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;

                    txtDni.Enabled = false;
                    txtNombre.Enabled = false;
                    txtUsuario.Enabled = false;
                    txtClaveUsuario.Enabled = false;
                    txtEmail.Enabled = false;
                    cmbArea.Enabled = false;
                    cmbEstado.Enabled = false;
                    cmbPerfil.Enabled = false;

                    dgvUsuarios.Enabled = true;
                    break;
                case TipoVista.Nuevo: //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    limpiar_componentes();
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;

                    txtDni.Enabled = true;
                    txtNombre.Enabled = true;
                    txtUsuario.Enabled = true;
                    txtClaveUsuario.Enabled = true;
                    txtEmail.Enabled = true;
                    cmbArea.Enabled = true;
                    cmbEstado.Enabled = true;
                    cmbPerfil.Enabled = true;
                    dgvUsuarios.Enabled = false;
                    break;
                case TipoVista.Guardar: //ya esta listo
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    dgvUsuarios.Enabled = false;
                    break;
                case TipoVista.Modificar://ya esta //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    dgvUsuarios.Enabled = false;

                    txtDni.Enabled = false;
                    txtNombre.Enabled = true;
                    txtUsuario.Enabled = false;
                    txtClaveUsuario.Enabled = true;
                    txtEmail.Enabled = true;
                    cmbArea.Enabled = true;
                    cmbEstado.Enabled = true;
                    cmbPerfil.Enabled = true;
                    dgvUsuarios.Enabled = false;
                    break;
                case TipoVista.Cancelar://ya esta //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;

                    txtDni.Enabled = false;
                    txtNombre.Enabled = false;
                    txtUsuario.Enabled = false;
                    txtClaveUsuario.Enabled = false;
                    txtEmail.Enabled = false;
                    cmbArea.Enabled = false;
                    cmbEstado.Enabled = false;
                    cmbPerfil.Enabled = false;
                    dgvUsuarios.Enabled = true;
                    limpiar_componentes();
                    break;
                case TipoVista.Limpiar: //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    break;

            }
        }

        private void limpiar_componentes()
        {
            txtDni.Text = "";
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtClaveUsuario.Text = "";
            txtEmail.Text = "";
            cmbArea.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbPerfil.SelectedIndex = -1;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmConfiguracionUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Nuevo);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seguro?");
            estadoComponentes(TipoVista.Cancelar);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtDni.Text.Trim().Length ==8 && validacionSoloNumeros(txtDni.Text.Trim()) == true) //VALIDACION DNI
            {
                if (txtNombre.Text.Trim().Length > 0 && validacionSoloLetras(txtNombre.Text.Trim()) == true)
                {
                    if (txtUsuario.Text.Trim().Length > 0)
                    {
                        if (txtClaveUsuario.Text.Trim().Length >4)
                        {
                            if (txtEmail.Text.Trim().Length > 0 && validacionCorreoLeasein(txtEmail.Text.Trim())==true)
                            {
                                //VALIDACION DE COMBOBOXS
                                if (cmbArea.SelectedIndex != -1)
                                {
                                    if (cmbPerfil.SelectedIndex != -1)
                                    {
                                        if (cmbEstado.SelectedIndex != -1)
                                        {
                                            //INSERTAR CON PROCEDURE -> RECUPERAMOS LOS ELEMENTOS

                                            string dni = txtDni.Text.Trim();
                                            string nombre = txtNombre.Text.Trim();
                                            string usuario = txtUsuario.Text.Trim();
                                            string claveUsuario = txtClaveUsuario.Text.Trim();
                                            string email = txtEmail.Text.Trim();
                                            int idArea = Convert.ToInt32(cmbArea.SelectedValue);
                                            int idPerfil = Convert.ToInt32(cmbPerfil.SelectedValue);
                                            int idEstado = Convert.ToInt32(cmbEstado.SelectedValue);


                                            int resultado = usuarioDA.InsertarNuevoUsuario(dni, nombre, usuario, claveUsuario, email, idArea, idPerfil, idEstado); //orUpdate
                                            if (resultado == 0)
                                            {
                                                MessageBox.Show("OCURRIO UN ERROR AL GUARDAR/MODIFICAR EL NUEVO USUARIO");
                                            }
                                            else
                                            {

                                                MessageBox.Show("NUEVO USUARIO GUARDADO/MODIFICADO CORRECTAMENTE");
                                                llenadoTablaUsuarios(); //ACTUALIZA LA TABLA
                                                limpiar_componentes();
                                                estadoComponentes(TipoVista.Inicial);

                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("DEBES SELECCIONAR UN ESTADO", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("DEBES SELECCIONAR UN PERFIL", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("DEBES SELECCIONAR UN AREA", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("REVISE EL CORREO", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("LA CONTRASEÑA DEBE TENER UNA LONGITUD MINIMA DE 5", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("REVISE EL USUARIO", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("REVISE EL NOMBRE", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("REVISE EL DNI", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //VER PRIMERO SI HAY UN REGISTOR SELECCIONADO
            GridRow aux = (GridRow)dgvUsuarios.PrimaryGrid.ActiveRow;

            if (aux != null)
            {
                
                string dni = ((GridCell)(((GridRow)dgvUsuarios.PrimaryGrid.ActiveRow)[1])).Value.ToString();
                txtDni.Text = dni;

                string nombre = ((GridCell)(((GridRow)dgvUsuarios.PrimaryGrid.ActiveRow)[2])).Value.ToString();
                txtNombre.Text = nombre;

                string usuario = ((GridCell)(((GridRow)dgvUsuarios.PrimaryGrid.ActiveRow)[3])).Value.ToString();
                txtUsuario.Text = usuario;

                string claveUsuario = ((GridCell)(((GridRow)dgvUsuarios.PrimaryGrid.ActiveRow)[4])).Value.ToString();
                txtClaveUsuario.Text = claveUsuario;

                string email = ((GridCell)(((GridRow)dgvUsuarios.PrimaryGrid.ActiveRow)[7])).Value.ToString();
                txtEmail.Text=email;

                string idArea = ((GridCell)(((GridRow)dgvUsuarios.PrimaryGrid.ActiveRow)[14])).Value.ToString();
                cmbArea.SelectedValue = idArea;

                string idPerfil = ((GridCell)(((GridRow)dgvUsuarios.PrimaryGrid.ActiveRow)[5])).Value.ToString();
                cmbPerfil.SelectedValue = idPerfil;

                string idEstado = ((GridCell)(((GridRow)dgvUsuarios.PrimaryGrid.ActiveRow)[8])).Value.ToString();
                cmbEstado.SelectedValue = idEstado;


            }
            estadoComponentes(TipoVista.Modificar);
        }

        private void dgvUsuarios_Click(object sender, EventArgs e)
        {
         
            
            GridRow aux = (GridRow)dgvUsuarios.PrimaryGrid.ActiveRow;
            
            
            if (aux != null)
            {

                txtDni.Text = ((GridCell)(((GridRow)dgvUsuarios.PrimaryGrid.ActiveRow)[1])).Value.ToString();
                txtNombre.Text = ((GridCell)(((GridRow)dgvUsuarios.PrimaryGrid.ActiveRow)[2])).Value.ToString();
                txtUsuario.Text = ((GridCell)(((GridRow)dgvUsuarios.PrimaryGrid.ActiveRow)[3])).Value.ToString();
                txtClaveUsuario.Text = ((GridCell)(((GridRow)dgvUsuarios.PrimaryGrid.ActiveRow)[4])).Value.ToString();
                txtEmail.Text = ((GridCell)(((GridRow)dgvUsuarios.PrimaryGrid.ActiveRow)[7])).Value.ToString();
                cmbArea.SelectedIndex= int.Parse(((GridCell)(((GridRow)dgvUsuarios.PrimaryGrid.ActiveRow)[14])).Value.ToString())-1;

                cmbEstado.SelectedIndex = int.Parse(((GridCell)(((GridRow)dgvUsuarios.PrimaryGrid.ActiveRow)[8])).Value.ToString());
                cmbPerfil.SelectedIndex = int.Parse(((GridCell)(((GridRow)dgvUsuarios.PrimaryGrid.ActiveRow)[5])).Value.ToString())-1;
            }
            
        }
    }
}
