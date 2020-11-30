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
    public partial class frmConfiguracionPermisos : Form
    {

        DataTable tablaUsuario;
        DataTable tablaModulosPrincipales;
        DataTable tablaSubmodulos;
        DataTable tablaPermisosUsuario;


        Usuario usuario;
        UsuarioDA usuarioDA;

        ModulosPrincipales ModulosPrincipales;
        ModulosPrincipalesDA ModulosPrincipalesDA;

        Submodulo Submodulo;
        SubmoduloDA SubmoduloDA;

        Accesos_usuarios accesos_usuarios;
        AccesosUsuarioDA accesosusuariosda;

        public frmConfiguracionPermisos()
        {
            InitializeComponent();
            Inicializado();
        }

        public void Inicializado()
        {
            usuarioDA = new UsuarioDA();
            usuario = new Usuario();

            ModulosPrincipalesDA = new ModulosPrincipalesDA();
            ModulosPrincipales = new ModulosPrincipales();

            accesosusuariosda = new AccesosUsuarioDA();
            accesos_usuarios = new Accesos_usuarios();

            //COMBO BOX LISTADO DE USUARIOS
            tablaUsuario = usuarioDA.ListarUsuarios();
            cmbUsuarios.DataSource = tablaUsuario;
            cmbUsuarios.DisplayMember = "nombre";
            cmbUsuarios.ValueMember = "idUsuario";

            //COMBO BOX LISTADO DE MODULOS PRINCIALES
            
            tablaModulosPrincipales = ModulosPrincipalesDA.ListarModulosPrincipales();
            cmbModulosPrincipales.DataSource = tablaModulosPrincipales;
            cmbModulosPrincipales.DisplayMember = "descripcionModuloP";
            cmbModulosPrincipales.ValueMember = "idModuloP";

        }










        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dgvSubmodulos_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AGREGAR PERMISO
            GridRow aux = (GridRow)dgvSubmodulos.PrimaryGrid.ActiveRow;

            if (aux != null)
            {
                string idSubmodulo = ((GridCell)(((GridRow)dgvSubmodulos.PrimaryGrid.ActiveRow)[0])).Value.ToString();
                int idUsuario = Convert.ToInt32(cmbUsuarios.SelectedValue);

                int resultado = accesosusuariosda.GuardarPermisoNuevo(idSubmodulo, idUsuario);

                if (resultado == 0)
                {
                    MessageBox.Show("OCURRIO UN ERROR");
                }
                else
                {
                    //REFRESH DE TABLAS
                    MessageBox.Show("PERMISO GUARDADO CORRECAMENTE");
                    button3.PerformClick();
                }

            }
            else
            {
                MessageBox.Show("DEBE SELECCIONAR UN PERMISO", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ELIMINAR PERMISO
            GridRow aux = (GridRow)dgvPermisosUsuario.PrimaryGrid.ActiveRow;

            if (aux != null)
            {
                string idSubmodulo = ((GridCell)(((GridRow)dgvPermisosUsuario.PrimaryGrid.ActiveRow)[1])).Value.ToString();
                int idUsuario = Convert.ToInt32(cmbUsuarios.SelectedValue);

                int resultado = accesosusuariosda.EliminarPermiso(idSubmodulo, idUsuario);

                if (resultado == 0)
                {
                    MessageBox.Show("OCURRIO UN ERROR");
                }
                else
                {
                    //REFRESH DE TABLAS
                    MessageBox.Show("PERMISO ELIMINADO CORRECAMENTE");
                    button3.PerformClick();
                }

            }
            else
            {
                MessageBox.Show("DEBE SELECCIONAR UN PERMISO", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            //AQUI MOSTRAR LOS POSIBLES PERMISOS A DAR
            SubmoduloDA = new SubmoduloDA();
            Submodulo = new Submodulo();

            int idUsuario, idModuloP;

            idUsuario = Convert.ToInt32(cmbUsuarios.SelectedValue);
            idModuloP = Convert.ToInt32(cmbModulosPrincipales.SelectedValue);



            tablaSubmodulos = SubmoduloDA.ListarSubmodulosPermisos(idModuloP, idUsuario);
            dgvSubmodulos.PrimaryGrid.AutoGenerateColumns = false;
            dgvSubmodulos.PrimaryGrid.DataSource = tablaSubmodulos;

            //AQUI MOSTRAR LOS PERMISOS QUE YA TIENE EL USUARIO
            tablaPermisosUsuario = SubmoduloDA.ListarPermisosUsuario(idModuloP, idUsuario);
            dgvPermisosUsuario.PrimaryGrid.AutoGenerateColumns = true;
            dgvPermisosUsuario.PrimaryGrid.DataSource = tablaPermisosUsuario;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int filas = tablaSubmodulos.Rows.Count;
            int idUsuario = Convert.ToInt32(cmbUsuarios.SelectedValue);

            for (int i = 0; i < filas; i++)
            {
                string idSubmodulo = ((GridCell)(dgvSubmodulos.PrimaryGrid.GetCell(i,0))).Value.ToString();
                int resultado = accesosusuariosda.GuardarPermisoNuevo(idSubmodulo, idUsuario);
            }

            MessageBox.Show("PERMISOS GUARDADOS CORRECAMENTE");
            button3.PerformClick();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int filas = tablaPermisosUsuario.Rows.Count;
            int idUsuario = Convert.ToInt32(cmbUsuarios.SelectedValue);

            for (int i = 0; i < filas; i++)
            {
                string idSubmodulo = ((GridCell)(dgvPermisosUsuario.PrimaryGrid.GetCell(i, 1))).Value.ToString();
                int resultado = accesosusuariosda.EliminarPermiso(idSubmodulo, idUsuario);
            }

            MessageBox.Show("PERMISOS ELIMINADOS CORRECAMENTE");
            button3.PerformClick();
        }

        private void cmbModulosPrincipales_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void dgvPermisosUsuario_Click(object sender, EventArgs e)
        {

        }

        private void frmConfiguracionPermisos_Load(object sender, EventArgs e)
        {

        }
    }
}
