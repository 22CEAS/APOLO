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
    public partial class frmProcesoAgregarGuia : Form
    {
        String nroGuia;
        public frmProcesoAgregarGuia()
        {
            InitializeComponent();
        }
        public string GuiaDevuelto { get => nroGuia; set => nroGuia = value; }
        private void btnAgregarGuia_Click(object sender, EventArgs e)
        {
            nroGuia = txtNroGuia.Text;
            nroGuia = nroGuia.Trim();
            if (nroGuia.Length>0)//Si entra es porque se ha seleccionado almenos solo
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        
    }
}
