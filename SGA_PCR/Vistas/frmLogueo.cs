using AccesoDatos;
using DevExpress.Utils.Win;
using DevExpress.XtraRichEdit.Model;
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
    public partial class frmLogueo : Form
    {

        Usuarios usuario;
        UsuarioDA usuarioDA;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect, // x-coordinate of upper-left corner
        int nTopRect, // y-coordinate of upper-left corner
        int nRightRect, // x-coordinate of lower-right corner
        int nBottomRect, // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
        );


        public frmLogueo()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 478, Height, 20, 20));
            
            InitializeComponent();
            Inicializado();
            btnLogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 20, 20));
            btnSalir.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSalir.Width, btnSalir.Height, 20, 20));

        }

        public void Inicializado()
        {
            usuarioDA = new UsuarioDA();
            usuario = new Usuarios();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (txtUsername.Text.Trim().Length == 0 || txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("EL USUARIO Y CONTRASEÑA NO PUEDEN SER VACIOS", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if (txtPassword.Text.Trim() == usuarioDA.Obtener_clave_usuario(txtUsername.Text))
                {
                    IngresarSistema();
                }
                else
                {
                    MessageBox.Show("USUARIO O CONTRASEÑA ERRONEOS", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                        
        }
        private void IngresarSistema()
        {

            int idUsuario = int.Parse(usuarioDA.Obtener_idUsuario(txtUsername.Text));

            TEST_MENU_PRINCIPAL frm = new TEST_MENU_PRINCIPAL(idUsuario,txtUsername.Text);
            //frmPrincipal frm = new frmPrincipal(); 


            //CORRER QUERY PARA SABER EL ID
            frm.usuario.Text = txtUsername.Text;
            frm.lblUser.Text = txtUsername.Text;
            //frm.usuarioConectado.Text = usuarioDA.Obtener_idUsuario(txtUsername.Text);



            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVerContraseña_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';
            btnVerContraseña.Visible = false;
            btnOcultarContraseña.Visible = true;
        }

        private void btnOcultarContraseña_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            btnOcultarContraseña.Visible = false;
            btnVerContraseña.Visible = true;
        }
    }
}
