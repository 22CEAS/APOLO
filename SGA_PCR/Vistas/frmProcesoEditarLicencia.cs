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
    public partial class frmProcesoEditarLicencia : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaLicencias;
        Licencia licencia;
        BindingList<Licencia> licencias;
        AlquilerDA alquilerDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";

        public frmProcesoEditarLicencia()
        {
            InitializeComponent();
            Inicializado();
            //estadoComponentes(TipoVista.Inicial);
        }

        public frmProcesoEditarLicencia(int idUsuario, string nombreUsuario)
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
            licencias = new BindingList<Licencia>();
            tablaLicencias = alquilerDA.ListarLicenciasConStock();

            dgvLicencia.PrimaryGrid.AutoGenerateColumns = false;
            dgvLicencia.PrimaryGrid.DataSource = tablaLicencias; ;
        }

        public bool llenarListaLicencia()
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
                        licencia.IdLicencia = int.Parse(((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 6))).Value.ToString());
                        licencia.Categoria = ((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 1))).Value.ToString();
                        licencia.Marca = ((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 3))).Value.ToString();
                        licencia.Version = ((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 4))).Value.ToString();
                        licencia.Clave = ((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 5))).Value.ToString();
                        bool exists = licencias.Any(x => x.Categoria.Equals(licencia.Categoria));
                        if (!(exists))
                        {
                            licencias.Add(licencia);
                            flag = true;
                        }
                    }
                }
            }
            return flag;
        }
        public BindingList<Licencia> LICENCIAS { get => licencias; set => licencias = value; }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro deseas Agregar estas Licencias, los cambios son permanentes", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (llenarListaLicencia())//Si entra es porque se ha seleccionado almenos solo
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }

            }
        }
    }
}
