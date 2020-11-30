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
    public partial class frmProcesoIngresoLicencia : Form
    {
        DataTable tablaLicencias;
        Licencia licencia;
        BindingList<Licencia> licencias;
        IngresoDA ingresoDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";

        public frmProcesoIngresoLicencia()
        {
            InitializeComponent();
            Inicializado();
        }
        public frmProcesoIngresoLicencia(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
        }

        public void Inicializado()
        {

            ingresoDA = new IngresoDA();
            licencias = new BindingList<Licencia>();
            tablaLicencias = ingresoDA.ListarLicencias();

            dgvLicencia.PrimaryGrid.AutoGenerateColumns = false;
            dgvLicencia.PrimaryGrid.DataSource = tablaLicencias; ;
        }

        public bool llenarListaLicencias()
        {
            bool flag = false;
            int filas = tablaLicencias.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        licencia = new Licencia();
                        licencia.IdCategoria = int.Parse(((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 4))).Value.ToString());
                        licencia.Categoria = ((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 1))).Value.ToString();
                        licencia.Marca = ((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 2))).Value.ToString();
                        licencia.Version = ((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 3))).Value.ToString();
                        licencia.IdModelo = int.Parse(((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 6))).Value.ToString());
                        licencia.Cantidad = 1;
                        licencias.Add(licencia);
                        flag = true;
                    }
                }
            }
            return flag;
        }
        public BindingList<Licencia> LICENCIAS { get => licencias; set => licencias = value; }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro deseas Agregar estas licencias", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (llenarListaLicencias())//Si entra es porque se ha seleccionado almenos solo
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
