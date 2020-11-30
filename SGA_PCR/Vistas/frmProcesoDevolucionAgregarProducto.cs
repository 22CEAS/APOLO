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
    public partial class frmProcesoDevolucionAgregarProducto : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaLaptops;
        DevolucionDetalle detalle;
        BindingList<DevolucionDetalle> detalles;
        DevolucionDA devolucionDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";


        public frmProcesoDevolucionAgregarProducto(int idCliente)
        {
            InitializeComponent();
            Inicializado(idCliente);
            //estadoComponentes(TipoVista.Inicial);
        }

        public frmProcesoDevolucionAgregarProducto(int idUsuario, string nombreUsuario, int idCliente)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado(idCliente);
            //estadoComponentes(TipoVista.Inicial);
        }

        public void Inicializado(int idCliente)
        {

            devolucionDA = new DevolucionDA();
            //laptop = new LC();
            detalles = new BindingList<DevolucionDetalle>();
            tablaLaptops = devolucionDA.ListarLaptopsClientesEstadoAlquilado(idCliente);

            dgvLaptops.PrimaryGrid.DataSource = tablaLaptops;
            dgvLaptops.PrimaryGrid.AutoGenerateColumns = false;
        }

        public bool llenarListaLaptops()
        {
            bool flag = false;
            int filas = tablaLaptops.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        detalle = new DevolucionDetalle();
                        detalle.IdLC = int.Parse(((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 9))).Value.ToString());
                        detalle.CodigoLC = ((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 1))).Value.ToString();
                        detalle.MarcaLC = ((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 2))).Value.ToString();
                        detalle.ModeloLC = ((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 3))).Value.ToString();
                        detalle.IdSalidaDetalle = int.Parse(((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 12))).Value.ToString());
                        detalle.IdSucursal = int.Parse(((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 13))).Value.ToString());
                        detalles.Add(detalle);
                        flag = true;
                    }
                }
            }
            return flag;
        }
        public BindingList<DevolucionDetalle> DETALLES { get => detalles; set => detalles = value; }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (llenarListaLaptops())//Si entra es porque se ha seleccionado almenos solo
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
