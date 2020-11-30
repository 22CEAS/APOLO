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
    public partial class frmProcesoEditarDisco : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaDiscos;
        DiscoDuro disco;
        BindingList<DiscoDuro> discos;
        AlquilerDA alquilerDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";
        private int cantidadDiscos;
        private int maxCantidadDiscos;
        private int stock = 0;

        public frmProcesoEditarDisco(int cantidadDiscos, int maxCantidadDiscos)
        {
            this.cantidadDiscos = cantidadDiscos;
            this.maxCantidadDiscos = maxCantidadDiscos;
            InitializeComponent();
            Inicializado();
            //estadoComponentes(TipoVista.Inicial);
        }


        public frmProcesoEditarDisco(int cantidadDiscos, int maxCantidadDiscos,int descripcion)
        {
            this.cantidadDiscos = cantidadDiscos;
            this.maxCantidadDiscos = maxCantidadDiscos;
            this.stock=descripcion;
            InitializeComponent();
            Inicializado();
            //estadoComponentes(TipoVista.Inicial);
        }
        public frmProcesoEditarDisco(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
            //estadoComponentes(TipoVista.Inicial);
        }

        public void Inicializado()
        {

            alquilerDA = new AlquilerDA();
            //laptop = new LC();
            discos = new BindingList<DiscoDuro>();
            if(stock==0)
                tablaDiscos = alquilerDA.ListarDiscosConStock();
            else
                tablaDiscos = alquilerDA.ListarDiscosConSinStock();

            dgvDisco.PrimaryGrid.AutoGenerateColumns = false;
            dgvDisco.PrimaryGrid.DataSource = tablaDiscos; ;
        }

        public bool llenarListaDiscos()
        {
            bool flag = false;
            int filas = tablaDiscos.Rows.Count;
            int cantDisco = this.cantidadDiscos;
            for (int i = 0; i < filas; i++)
            {
                if (cantDisco < this.maxCantidadDiscos)
                {
                    if (((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 0))).Value != null)
                    {
                        if (Convert.ToBoolean(((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                        {
                            disco = new DiscoDuro();
                            disco.IdDisco = int.Parse(((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 4))).Value.ToString());
                            disco.TipoDisco = ((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 1))).Value.ToString();
                            disco.Capacidad = int.Parse(((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 2))).Value.ToString());
                            disco.Cantidad = int.Parse(((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 3))).Value.ToString());
                            discos.Add(disco);
                            cantidadDiscos++;
                            flag = true;
                        }
                    }
                }
            }
            return flag;
        }
        public BindingList<DiscoDuro> DISCOS { get => discos; set => discos = value; }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro deseas Agregar estos discos, los cambios son permanentes", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
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
