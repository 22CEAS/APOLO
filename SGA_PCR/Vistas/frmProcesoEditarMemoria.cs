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
    public partial class frmProcesoEditarMemoria : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaMemorias;
        Memoria memoria;
        BindingList<Memoria> memorias;
        AlquilerDA alquilerDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";
        private int stock = 0;

        public frmProcesoEditarMemoria()
        {
            InitializeComponent();
            Inicializado();
            //estadoComponentes(TipoVista.Inicial);
        }

        public frmProcesoEditarMemoria(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
            //estadoComponentes(TipoVista.Inicial);
        }


        public frmProcesoEditarMemoria(int idUsuario, string nombreUsuario, int descripcion)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            this.stock = descripcion;
            Inicializado();
        }

        public void Inicializado()
        {

            alquilerDA = new AlquilerDA();
            //laptop = new LC();
            memorias = new BindingList<Memoria>();
            if(stock==0)
                tablaMemorias = alquilerDA.ListarMemoriasConStock();
            else
                tablaMemorias = alquilerDA.ListarMemoriasConSinStock();

            dgvMemorias.PrimaryGrid.AutoGenerateColumns = false;
            dgvMemorias.PrimaryGrid.DataSource = tablaMemorias; ;
        }

        public bool llenarListaMemorias()
        {
            bool flag = false;
            int filas = tablaMemorias.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        memoria = new Memoria();
                        memoria.IdMemoria = int.Parse(((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 4))).Value.ToString());
                        memoria.TipoMemoria = ((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 1))).Value.ToString();
                        memoria.Capacidad = int.Parse(((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 2))).Value.ToString());
                        memoria.Cantidad = int.Parse(((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 3))).Value.ToString());
                        memoria.Tipo = ((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 5))).Value.ToString();
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
            if (MessageBox.Show("Estas seguro deseas Agregar estas memorias, los cambios son permanentes", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
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
