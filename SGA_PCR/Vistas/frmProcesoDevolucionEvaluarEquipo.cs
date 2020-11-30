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
    public partial class frmProcesoDevolucionEvaluarEquipo : Form
    {
        String observacion;
        int cobrado;
        int dano;
        public frmProcesoDevolucionEvaluarEquipo(int cobrado, int dano, string observacion)
        {
            InitializeComponent();
            if(cobrado == 1)
            {
                rbtnCobrarSi.Checked = true; rbtnCobrarNo.Checked = false;
            }
            else
            {
                rbtnCobrarSi.Checked = false; rbtnCobrarNo.Checked = true;
            }
            if (dano == 1)
            {
                rbtnDanoSi.Checked = true; rbtnDanoNo.Checked = false;
            }
            else
            {
                rbtnDanoSi.Checked = false; rbtnDanoNo.Checked = true;
            }
            txtObservacion.Text = observacion;
        }

        public string Observacion { get => observacion; set => observacion = value; }
        public int Cobrado { get => cobrado; set => cobrado = value; }
        public int Dano { get => dano; set => dano = value; }
        private void btnGrabarPreAlquiler_Click(object sender, EventArgs e)
        {
            this.observacion = txtObservacion.Text;
            this.observacion = this.observacion.Trim();
            if ((rbtnCobrarSi.Checked || rbtnDanoSi.Checked) && this.observacion.Length==0)//Si entra es porque se ha seleccionado almenos solo
            {
                MessageBox.Show("Debe escribir una referencia en el cuadro de observación", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rbtnCobrarSi.Checked) this.cobrado = 1;
            else this.cobrado = 0;
            if (rbtnDanoSi.Checked) this.dano = 1;
            else this.dano = 0;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
