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
    public partial class frmProcesoLevantamientoObservacionesAgregarObservacion : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaObservaciones;
        Observacion observacion;
        BindingList<Observacion> detalles;
        BindingList<Observacion> auxiliares;
        ObservacionDA observacionDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";


        public frmProcesoLevantamientoObservacionesAgregarObservacion(int idCliente)
        {
            InitializeComponent();
            Inicializado(idCliente);
        }

        public frmProcesoLevantamientoObservacionesAgregarObservacion(int idUsuario, string nombreUsuario, int idCliente)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado(idCliente);
        }

        public void Inicializado(int idCliente)
        {
            
            //! TABLA NORMAL    
            /*
            observacionDA = new ObservacionDA();

            tablaObservaciones = observacionDA.ListarObservaciones(idCliente);

            dgvObservaciones.PrimaryGrid.AutoGenerateColumns = false;
            dgvObservaciones.PrimaryGrid.DataSource = tablaObservaciones;
            /*
            //! TABLA DEV EXPRESS
            
            observacionDA = new ObservacionDA();
            tablaObservaciones = observacionDA.ListarObservaciones(idCliente);

            dgvObs.DataSource = tablaObservaciones;
            vista.OptionsBehavior.AutoPopulateColumns = false;
            vista.OptionsSelection.MultiSelect = true;
            */



            observacionDA = new ObservacionDA();
            detalles = new BindingList<Observacion>();

            tablaObservaciones = observacionDA.ListarObservaciones(idCliente);
            auxiliares = new BindingList<Observacion>();
            int rec = 0;
            while (rec < tablaObservaciones.Rows.Count)
            {
                Observacion auxiliar = new Observacion();
                auxiliar.CodigoLC = tablaObservaciones.Rows[rec]["CodigoLC"].ToString();
                auxiliar.ObservacionDeuda = tablaObservaciones.Rows[rec]["ObservacionDeuda"].ToString();
                auxiliar.IdLC = Convert.ToInt32(tablaObservaciones.Rows[rec]["IdLC"].ToString());
                auxiliar.IdObervacion = Convert.ToInt32(tablaObservaciones.Rows[rec]["IdObservacion"].ToString());
                auxiliares.Add(auxiliar);
                rec++;
            }

            dgvObs.DataSource = auxiliares;
            vista.OptionsBehavior.AutoPopulateColumns = false;
            vista.OptionsSelection.MultiSelect = true;
        }

        public int llenarListaObservaciones()
        {
            //! VERIFICAR CON LA NUEVA TABLA DE DEVEXPRESS
            /*
            int flag = 0;
            int filas = tablaObservaciones.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvObservaciones.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvObservaciones.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        observacion = new Observacion();
                        observacion.IdLC = int.Parse(((GridCell)(dgvObservaciones.PrimaryGrid.GetCell(i, 3))).Value.ToString());
                        observacion.CodigoLC = ((GridCell)(dgvObservaciones.PrimaryGrid.GetCell(i, 1))).Value.ToString();
                        observacion.ObservacionDeuda = ((GridCell)(dgvObservaciones.PrimaryGrid.GetCell(i, 2))).Value.ToString();
                        observacion.IdObervacion = int.Parse(((GridCell)(dgvObservaciones.PrimaryGrid.GetCell(i, 4))).Value.ToString());
                        flag++;
                    }
                }
            }
            return flag;
            */

            
            int flag = 0;
            int filas = tablaObservaciones.Rows.Count;
            vista.ClearColumnsFilter();
            for (int i = 0; i < filas; i++)
            {
                bool aux2 = bool.Parse(vista.GetRowCellValue(i, "Seleccion").ToString());
                //MessageBox.Show(aux2.ToString());
                if (aux2)
                {
                    observacion = new Observacion();
                    observacion.IdLC = int.Parse(vista.GetRowCellValue(i, "IdLC").ToString());
                    observacion.CodigoLC = vista.GetRowCellValue(i, "CodigoLC").ToString();
                    observacion.ObservacionDeuda = vista.GetRowCellValue(i, "ObservacionDeuda").ToString();
                    observacion.IdObervacion = int.Parse(vista.GetRowCellValue(i, "IdObervacion").ToString());
                    flag++;

                }
               
        }
        //MessageBox.Show("FIN CICLO");
            return flag;
             


        }

        public Observacion OBSERVACION { get => observacion; set => observacion = value; }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int cant = llenarListaObservaciones();
            if (cant == 1)//Si entra es porque se ha seleccionado almenos solo
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                if (cant == 0) MessageBox.Show("Tiene que seleccionar una observacion", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cant > 0) MessageBox.Show("No puedes seleccionar más de una observacion", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
