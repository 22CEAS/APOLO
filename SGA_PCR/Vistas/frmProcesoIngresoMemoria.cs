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
    public partial class frmProcesoIngresoMemoria : Form
    {
        DataTable tablaMemorias;
        Memoria memoria;
        BindingList<Memoria> memorias;
        IngresoDA ingresoDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";

        public frmProcesoIngresoMemoria()
        {
            InitializeComponent();
            Inicializado();
        }
        public frmProcesoIngresoMemoria(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
        }

        public void Inicializado()
        {
            
            ingresoDA = new IngresoDA();
            memorias = new BindingList<Memoria>();
            tablaMemorias = ingresoDA.ListarMemorias();

            dgvMemoria.PrimaryGrid.AutoGenerateColumns = false;
            dgvMemoria.PrimaryGrid.DataSource = tablaMemorias; ;
        }

        public bool llenarListaMemorias()
        {
            bool flag = false;
            int filas = tablaMemorias.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        memoria = new Memoria();
                        memoria.IdMemoria = int.Parse(((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 5))).Value.ToString());
                        memoria.TipoMemoria = ((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 1))).Value.ToString();
                        memoria.Tipo = ((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 9))).Value.ToString();
                        memoria.Capacidad = int.Parse(((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 3))).Value.ToString());
                        memoria.Cantidad = 1;
                        memorias.Add(memoria);
                        flag = true;
                    }
                }
            }
            return flag;
        }
        public BindingList<Memoria> MEMORIAS { get => memorias; set => memorias = value; }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro deseas Agregar estas memorias", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (llenarListaMemorias())//Si entra es porque se ha seleccionado almenos solo
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
