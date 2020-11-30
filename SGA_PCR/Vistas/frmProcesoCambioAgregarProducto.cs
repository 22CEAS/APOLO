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
    public partial class frmProcesoCambioAgregarProducto : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaLaptops;
        LC laptop;
        AlquilerDA alquilerDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";


        public frmProcesoCambioAgregarProducto()
        {
            InitializeComponent();
            Inicializado();
        }

        public frmProcesoCambioAgregarProducto(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
        }

        public void Inicializado()
        {

            alquilerDA = new AlquilerDA();

            tablaLaptops = alquilerDA.ListarLaptopsAlmacenSinMemoriaDisco();

            dgvLaptops.PrimaryGrid.AutoGenerateColumns = false;
            dgvLaptops.PrimaryGrid.DataSource = tablaLaptops; ;
        }

        public int llenarListaLaptops()
        {
            int flag = 0;
            int filas = tablaLaptops.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        laptop = new LC();
                        laptop.IdLC = int.Parse(((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 9))).Value.ToString());
                        laptop.Codigo = ((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 1))).Value.ToString();
                        laptop.Modelo.NombreMarca = ((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 2))).Value.ToString();
                        laptop.Modelo.NombreModelo = ((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 3))).Value.ToString();
                        laptop.TamanoPantalla = Double.Parse(((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 4))).Value.ToString());
                        laptop.Procesador.Modelo.NombreModelo = ((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 5))).Value.ToString();
                        laptop.Procesador.Generacion = int.Parse(((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 6))).Value.ToString());
                        laptop.Video.IdVideo = int.Parse(((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 10))).Value.ToString());
                        laptop.Video.Modelo.NombreModelo = ((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 7))).Value.ToString();
                        laptop.Video.Capacidad = int.Parse(((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 8))).Value.ToString());
                        laptop.Procesador.IdProcesador = int.Parse(((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 11))).Value.ToString());
                        flag++;
                    }
                }
            }
            return flag;
        }
        public LC LAPTOP { get => laptop; set => laptop = value; }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int cant = llenarListaLaptops();
            if (cant == 1)//Si entra es porque se ha seleccionado almenos solo
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                if (cant == 0) MessageBox.Show("Tiene que seleccionar una laptop", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cant > 0) MessageBox.Show("No puedes seleccionar más de una laptop", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
