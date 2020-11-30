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
    public partial class frmProcesoIngresoDisco : Form
    {
        DataTable tablaDiscos;
        DiscoDuro disco;
        BindingList<DiscoDuro> discos;
        IngresoDA ingresoDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";

        public frmProcesoIngresoDisco()
        {
            InitializeComponent();
            Inicializado();
        }
        public frmProcesoIngresoDisco(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
        }

        public void Inicializado()
        {

            ingresoDA = new IngresoDA();
            discos = new BindingList<DiscoDuro>();
            tablaDiscos = ingresoDA.ListarDiscosDuros();

            dgvDiscoDuro.PrimaryGrid.AutoGenerateColumns = false;
            dgvDiscoDuro.PrimaryGrid.DataSource = tablaDiscos; ;
        }

        public bool llenarListaDiscos()
        {
            bool flag = false;
            int filas = tablaDiscos.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        disco = new DiscoDuro();
                        disco.IdDisco = int.Parse(((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 5))).Value.ToString());
                        disco.TipoDisco = ((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 1))).Value.ToString();
                        disco.Tamano = ((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 2))).Value.ToString();
                        disco.Capacidad = int.Parse(((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 3))).Value.ToString());
                        disco.Cantidad = 1;
                        discos.Add(disco);
                        flag = true;
                    }
                }
            }
            return flag;
        }
        public BindingList<DiscoDuro> DISCOS { get => discos; set => discos = value; }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro deseas Agregar estos discos", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (llenarListaDiscos())//Si entra es porque se ha seleccionado almenos solo
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
