using AccesoDatos;
using DevComponents.DotNetBar.SuperGrid;
using Modelo;
using SpreadsheetLight;
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
    public partial class frmProcesoAlquilerAgregarProducto : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaLaptops;
        LC laptop;
        BindingList<LC> laptops;
        AlquilerDA alquilerDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";


        public frmProcesoAlquilerAgregarProducto()
        {
            InitializeComponent();
            Inicializado();
            //estadoComponentes(TipoVista.Inicial);
        }

        public frmProcesoAlquilerAgregarProducto(int idUsuario, string nombreUsuario)
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
            laptops = new BindingList<LC>();
            tablaLaptops = alquilerDA.ListarLaptopsAlmacenSinMemoriaDisco();

            dgvLaptops.PrimaryGrid.AutoGenerateColumns = false;
            dgvLaptops.PrimaryGrid.DataSource = tablaLaptops; ;
        }

        public bool llenarListaLaptops()
        {
            bool flag = false;
            int filas = tablaLaptops.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                if(((GridCell)(dgvLaptops.PrimaryGrid.GetCell(i, 0))).Value != null)
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
                        laptops.Add(laptop);
                        flag = true;
                    }
                }
            }
            return flag;
        }
        public BindingList<LC> LAPTOPS { get => laptops; set => laptops = value; }
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

        private void btnSubirSeries_Click(object sender, EventArgs e)
        {
            try
            {
                string path;

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    //DE ESTA MANERA FILTRAMOS TODOS LOS ARCHIVOS EXCEL EN EL NAVEGADOR DE ARCHIVOS
                    Filter = "Excel | *.xls;*.xlsx;",

                    //AQUÍ INDICAMOS QUE NOMBRE TENDRÁ EL NAVEGADOR DE ARCHIVOS COMO TITULO
                    Title = "Seleccionar Archivo"
                };

                //EN CASO DE SELECCIONAR EL ARCHIVO, ENTONCES PROCEDEMOS A ABRIR EL ARCHIVO CORRESPONDIENTE
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DataTable miDataTable = new DataTable();
                    miDataTable.Columns.Add("CODIGO_LC");

                    path = openFileDialog.FileName;
                    SLDocument sl = new SLDocument(path);

                    int iRow = 2;
                    while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                    {
                        DataRow Renglon = miDataTable.NewRow();
                        Renglon["CODIGO_LC"] = sl.GetCellValueAsString(iRow, 1);
                        iRow++;
                        miDataTable.Rows.Add(Renglon);
                    }

                    //dgvSerieFabrica.DataSource = miDataTable;
                    //dgvSerieFabrica.AutoGenerateColumns = false;

                    int filasExcel = miDataTable.Rows.Count;
                    for (int i = 0; i < filasExcel; i++)
                    {
                        string codigo = miDataTable.Rows[i]["CODIGO_LC"].ToString();
                        int filasDgv = tablaLaptops.Rows.Count;
                        for (int j = 0; j < filasDgv; j++)
                        {
                            if (codigo == ((GridCell)(dgvLaptops.PrimaryGrid.GetCell(j, 1))).Value.ToString())
                            {
                                ((GridCell)(dgvLaptops.PrimaryGrid.GetCell(j, 0))).Value = true;
                                break;
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }


        }
    }
}
