using AccesoDatos;
using DevComponents.DotNetBar.SuperGrid;
using DevExpress.Export;
using DevExpress.Printing.ExportHelpers;
using DevExpress.XtraPrinting;
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
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;

namespace Apolo
{
    public partial class frmReporteStocksLaptops : Form
    {

        DataTable tablaLaptops;
        ReporteDA reporteDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";
        DataTable tablaDisco;
        DataTable tablaMemoria;
        DataTable tablaLicencia;

        private string licenciaCategoriaSO = "S.O";
        private string licenciaCategoriaOffice = "OFFICE";
        private string licenciaCategoriaAntivirus = "ANTIVIRUS";

        DataTable tablaProcesadoresModelos;
        DataTable tablaProcesadoresGeneracion;

        private BindingList<LC> laptops;

        private int estadoDisponible = 2;
        private int idMarcaAppleLC = 1;
        private int idMarcaApplePC = 8;
        private int idCategoriaProcesador = 9;
        private string codTablaProcesadorGeneracion = "PROCESADOR_GENERACION";
        private int cantGeneraciones;
        private int cantModeloProcesador;
        private int[][] arregloLCGeneral;
        private int[][] arregloLCApple;


        public frmReporteStocksLaptops()
        {
            InitializeComponent();
            Inicializado();
        }

        public frmReporteStocksLaptops(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
        }

        public void Inicializado()
        {

            //
        }


        void options_CustomizeSheetHeader(DevExpress.Export.ContextEventArgs e)
        {
            // Create a new row.
            CellObject row = new CellObject();
            XlFormattingObject rowFormatting = new XlFormattingObject();
            // Specify row values.
            row.Value = "INVENTARIOS LAPTOPS";
            rowFormatting.Font = new XlCellFont { Bold = true, Size = 14 };
            rowFormatting.BackColor = Color.Orange;
            rowFormatting.Alignment = new DevExpress.Export.Xl.XlCellAlignment { HorizontalAlignment = DevExpress.Export.Xl.XlHorizontalAlignment.Center, VerticalAlignment = DevExpress.Export.Xl.XlVerticalAlignment.Top };
            row.Formatting = rowFormatting;
            // Add the created row to the output document.
            e.ExportContext.AddRow(new[] { row });
            // Add an empty row to the output document.
            e.ExportContext.AddRow();
            // Merge cells of two new rows. 
            e.ExportContext.MergeCells(new DevExpress.Export.Xl.XlCellRange(new DevExpress.Export.Xl.XlCellPosition(0, 0), new DevExpress.Export.Xl.XlCellPosition(15, 1)));
        }



        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea Exportar el reporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    DevExpress.Export.ExportSettings.DefaultExportType = ExportType.DataAware;
                    XlsxExportOptionsEx options = new XlsxExportOptionsEx();
                    options.CustomizeSheetHeader += options_CustomizeSheetHeader;
                    //options.CustomizeCell += op_CustomizeCell;
                    string file = "INVENTARIOS LAPTOPS.xlsx";
                    dgvLaptops.ExportToXlsx(file, options);
                    System.Diagnostics.Process.Start(file);
                    //btnExportar2_Click();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString(), "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                Cursor.Current = Cursors.Default;

            }
        }

        private void btnExportar2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Estas seguro que desea Exportar el reporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {

                    SaveFileDialog fichero = new SaveFileDialog();
                    //fichero.Filter = "Excel (*.xls)|*.xls";
                    fichero.Filter = "Excel(*.xlsx) | *.xlsx";
                    fichero.FileName = "Laptops";
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        Excel.Application aplicacion;
                        Excel.Workbook libros_trabajo;
                        Excel.Worksheet hoja_pre_alquiler;

                        aplicacion = new Excel.Application();
                        libros_trabajo = (Excel.Workbook)aplicacion.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

                        hoja_pre_alquiler = (Excel.Worksheet)libros_trabajo.Worksheets.Add();
                        hoja_pre_alquiler.Name = "Laptops";
                        string cabecera = "Equipos Disponibles";
                        ExportarDataGridViewExcel(ref hoja_pre_alquiler, cabecera);


                        ((Excel.Worksheet)aplicacion.ActiveWorkbook.Sheets["Hoja1"]).Delete();

                        libros_trabajo.SaveAs(fichero.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook);
                        libros_trabajo.Close(true);
                        releaseObject(libros_trabajo);
                        aplicacion.Quit();
                        releaseObject(aplicacion);
                        MessageBox.Show("Se generó el reporte con éxito", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString(), "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        public void ExportarDataGridViewExcel(ref Excel.Worksheet hoja_trabajo, string nombreCabecera)
        {
            Excel.Range rango;

            int cantColumnas = tablaProcesadoresGeneracion.Rows.Count + 3; //
            int filas = vista.RowCount;

            int k = cantColumnas - 1 + 64;
            char columF = (char)k;
            int fila2 = 12; //! ORIGINAL 3
            string filaBorde = fila2.ToString();
            char columI = 'A';
            //Ponemos borde a las celdas


            rango = hoja_trabajo.Range[columI + fila2.ToString(), columF + fila2.ToString()];
            rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            rango.Style.Font.Bold = false;

            

            for (int i = 1; i <= this.cantModeloProcesador * 2 + 4; i++)
            {
                rango = hoja_trabajo.Range[columI + (i + 9).ToString(), columF + (i + 9).ToString()];
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }

            //CANTIDAD DE LAPTOP/MAC POR GENERACION
            for (int i = 0; i < this.cantGeneraciones; i++)
            {
                int cantGenLCGeneral = 0;
                int cantGenLCApple = 0;
                for (int j = 0; j < this.cantModeloProcesador; j++)
                {
                    string generacion = tablaProcesadoresGeneracion.Rows[i]["descripcion"].ToString();
                    string nombreProcesador = tablaProcesadoresModelos.Rows[j]["nombre"].ToString();

                    hoja_trabajo.Cells[fila2 + 1 + j, i + 2] = arregloLCGeneral[i][j];

                    hoja_trabajo.Cells[fila2 + 1 + cantModeloProcesador + 1 + j, i + 2] = arregloLCApple[i][j];

                    cantGenLCGeneral += arregloLCGeneral[i][j];
                    cantGenLCApple += arregloLCApple[i][j];
                }
                hoja_trabajo.Cells[fila2, i + 2] = cantGenLCGeneral;
                hoja_trabajo.Cells[fila2 + cantModeloProcesador + 1, i + 2] = cantGenLCApple;
                
            }

            
            //CANTIDAD DE LAPTOP POR PROCESADOR -> LAP Y MAC
            for (int j = 0; j < this.cantModeloProcesador; j++)
            {
                int cantProLCGeneral = 0;
                int cantProLCApple = 0;
                for (int i = 0; i < this.cantGeneraciones; i++)
                {
                    cantProLCGeneral += arregloLCGeneral[i][j];
                    cantProLCApple += arregloLCApple[i][j];
                }
                hoja_trabajo.Cells[fila2 + 1 + j, cantGeneraciones + 2] = cantProLCGeneral;
                hoja_trabajo.Cells[fila2 + cantModeloProcesador + 1 + 1 + j, cantGeneraciones + 2] = cantProLCApple;

                
            }

            

            var cantidadLCGeneral = new BindingList<LC>(laptops.Where(p => p.IdMarca != this.idMarcaAppleLC && p.IdMarca != this.idMarcaApplePC && p.Estado == this.estadoDisponible).ToList());
            var cantidadLCApple = new BindingList<LC>(laptops.Where(p => p.IdMarca == this.idMarcaAppleLC && p.IdMarca != this.idMarcaApplePC && p.Estado == this.estadoDisponible).ToList());
            

            hoja_trabajo.Cells[fila2, cantGeneraciones + 2] = cantidadLCGeneral.Count;
            hoja_trabajo.Cells[fila2 + cantModeloProcesador + 1, cantGeneraciones + 2] = cantidadLCApple.Count;

            montaCabeceras(10, ref hoja_trabajo, nombreCabecera); //ORIGINAL:1
        }

        private void montaCabeceras(int fila, ref Excel.Worksheet hoja, string nombreCabecera)
        {
            try
            {
                Excel.Range rango;
                int cantColumnas = tablaProcesadoresGeneracion.Rows.Count + 2;

                //** Montamos el título en la línea 1 **
                hoja.Cells[fila, 1] = nombreCabecera;
                hoja.Range[hoja.Cells[fila, 1], hoja.Cells[fila, cantColumnas]].Merge();
                hoja.Range[hoja.Cells[fila, 1], hoja.Cells[fila, cantColumnas]].Interior.Color = Color.FromArgb(218, 152, 36);//FromArgb(255, 132, 0)
                hoja.Range[hoja.Cells[fila, 1], hoja.Cells[fila, cantColumnas]].Style.Font.Bold = true;

                hoja.Range[hoja.Cells[fila + 1, 1], hoja.Cells[fila + 1, cantColumnas - 1]].Interior.Color = Color.FromArgb(218, 152, 36);
                hoja.Range[hoja.Cells[fila + 1, cantColumnas], hoja.Cells[fila + 1, cantColumnas]].Interior.Color = Color.FromArgb(218, 152, 36);

                hoja.Range[hoja.Cells[fila + 2, 1], hoja.Cells[fila + 2, cantColumnas]].Interior.Color = Color.FromArgb(252, 228, 215);
                hoja.Range[hoja.Cells[fila + 3 + cantModeloProcesador, 1], hoja.Cells[fila + 3 + cantModeloProcesador, cantColumnas]].Interior.Color = Color.FromArgb(252, 228, 215);

                //Centramos los textos
                rango = hoja.Rows[fila];
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                for (int k = 0; k < cantGeneraciones; k++)
                {
                    string genPro = tablaProcesadoresGeneracion.Rows[k]["descripcion"].ToString();
                    hoja.Cells[fila + 1, k + 2] = genPro;
                }

                hoja.Cells[fila + 1, cantGeneraciones + 2] = "Total en Almacen";
                hoja.Cells[fila + 1, 1] = "Generación";
                hoja.Cells[fila + 2, 1] = "LAPTOP";


                //REPORTE SEGUN ESTADO

                hoja.Cells[1, 1] = "DISPONIBLES";
                hoja.Cells[1, 1].Interior.Color = Color.FromArgb(231, 177, 80);//FromArgb(255, 132, 0)
                hoja.Cells[1, 2] = txtDisponibles.Text;

                hoja.Cells[2, 1] = "ALQUILADOS";
                hoja.Cells[2, 1].Interior.Color = Color.FromArgb(231, 177, 80);//FromArgb(255, 132, 0)
                hoja.Cells[2, 2] = txtAlquilados.Text;

                hoja.Cells[3, 1] = "INUTILIZABLES";
                hoja.Cells[3, 1].Interior.Color = Color.FromArgb(231, 177, 80);//FromArgb(255, 132, 0)
                hoja.Cells[3, 2] = txtInutilizables.Text;

                hoja.Cells[4, 1] = "PERSONAL PCR";
                hoja.Cells[4, 1].Interior.Color = Color.FromArgb(231, 177, 80);//FromArgb(255, 132, 0)
                hoja.Cells[4, 2] = txtPersonales.Text;

                hoja.Cells[5, 1] = "DAÑADO";
                hoja.Cells[5, 1].Interior.Color = Color.FromArgb(231, 177, 80);//FromArgb(255, 132, 0)
                hoja.Cells[5, 2] = txtDanados.Text;

                hoja.Cells[6, 1] = "TOTAL";
                hoja.Cells[6, 1].Interior.Color = Color.FromArgb(218, 152, 36);//FromArgb(255, 132, 0)
                hoja.Cells[6, 2] = txtTotalLaptops.Text;



                for (int k = 0; k < cantModeloProcesador; k++)
                {
                    string modPro = tablaProcesadoresModelos.Rows[k]["nombre"].ToString();
                    hoja.Cells[fila + 3 + k, 1] = modPro;
                }

                hoja.Cells[fila + 3 + cantModeloProcesador, 1] = "MACKBOOK";

                for (int k = 0; k < cantModeloProcesador; k++)
                {
                    string modPro = tablaProcesadoresModelos.Rows[k]["nombre"].ToString();
                    hoja.Cells[fila + 3 + cantModeloProcesador + 1 + k, 1] = modPro;
                }

                int fila2 = fila + 2;
                rango = hoja.Rows[fila2];
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                for (int j = 0; j < cantColumnas + 2; j++)
                {
                    rango = hoja.Columns[j + 1];
                    rango.ColumnWidth = 15;
                }

                rango = hoja.Rows[fila + 3 + cantModeloProcesador];
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                for (int j = 0; j < cantColumnas + 2; j++)
                {
                    rango = hoja.Columns[j + 1];
                    rango.ColumnWidth = 15;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de redondeo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Error mientras liberaba objecto " + ex.ToString(), "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void verResumen_Click(object sender, EventArgs e)
        {

            //label1.Text = $"CANTIDAD FILTRADA: {vista.RowCount.ToString()}";
            txtCantidadFiltrada.Text = vista.RowCount.ToString();

        }

        public void verReporte()
        {
            int contador = 0;

            //DISPONIBLE
            vista.ActiveFilterString = "[EstadoNombre] like '%DISPONIBLE%'";
            int canDisponibles = vista.RowCount;
            contador = contador + canDisponibles;
            //lblDisponible.Text = $"DISPONIBLES: {cantidadReporte.ToString()}";
            txtDisponibles.Text = canDisponibles.ToString();

            //ALQUILADO/PRE ALQUILADO
            vista.ActiveFilterString = "[EstadoNombre] like '%ALQUILADO%'";
            int cantidadAlquilado = vista.RowCount;
            int cantidadPreAlquilado;
            vista.ActiveFilterString = "[EstadoNombre] like '%PRE-ALQUILER%'";
            cantidadPreAlquilado = vista.RowCount;
            contador = contador + cantidadAlquilado + cantidadPreAlquilado;
            //lblAlquilados.Text = $"ALQUILADOS: {(cantidadReporte + aux).ToString()}";
            txtAlquilados.Text = (cantidadAlquilado + cantidadPreAlquilado).ToString();

            //INUTILIZABLES
            vista.ActiveFilterString = "[EstadoNombre] like '%INUTILIZABLE%'";
            int canInutilizable = vista.RowCount;
            contador = contador + canInutilizable;
            //lblInutilizables.Text = $"INUTILIZABLES: {cantidadReporte.ToString()}";
            txtInutilizables.Text = canInutilizable.ToString();

            //PERSONAL
            vista.ActiveFilterString = "[EstadoNombre] like '%PERSONALPCR%'";
            int canPersonalPCR = vista.RowCount;
            contador = contador + canPersonalPCR;
            //lblPersonal.Text = $"PERSONAL PCR: {cantidadReporte.ToString()}";
            txtPersonales.Text = canPersonalPCR.ToString();

            //DAÑADO
            vista.ActiveFilterString = "[EstadoNombre] like '%DAÑADO%'";
            int canDanado = vista.RowCount;
            contador = contador + canDanado;
            //lblDanado.Text = $"DAÑADO: {cantidadReporte.ToString()}";
            txtDanados.Text = canDanado.ToString();


            //TOTAL
            //lblTotalLaptops.Text = $"TOTAL LAPTOPS: {(contador-cantidadReporte).ToString()}";
            txtTotalLaptops.Text = (canDisponibles + cantidadAlquilado + cantidadPreAlquilado + canInutilizable + canPersonalPCR + canDanado).ToString();
            vista.ActiveFilterString = "[EstadoNombre] null";
        }


        private async void cargarData_Click(object sender, EventArgs e)
        {
            //label1.Text = $"CANTIDAD FILTRADA: ";
            Task<bool> task = new Task<bool>(cargarDataTabla);
            task.Start();
            giftCarga.Image = Image.FromFile(@".\progress.gif");
            giftCarga.SizeMode = PictureBoxSizeMode.StretchImage;
            bool resultado = await task;
            giftCarga.Enabled = false;
            giftCarga.Visible = false;
            cargarData.Text = "DATA CARGADA";
            //label1.Text = $"CANTIDAD FILTRADA: {vista.RowCount.ToString()}";
            txtCantidadFiltrada.Text = vista.RowCount.ToString();
            cargarData.Visible = false;
            verReporte();
        }

        public bool cargarDataTabla()
        {
            try
            {
                reporteDA = new ReporteDA();
                tablaLaptops = reporteDA.ListarLaptopsInventario();
                tablaProcesadoresModelos = reporteDA.tablaProcesadoresModelos(idCategoriaProcesador);
                tablaProcesadoresGeneracion = reporteDA.tablaProcesadoresGeneracion(codTablaProcesadorGeneracion);

                laptops = new BindingList<LC>();
                tablaDisco = reporteDA.ListarLaptopDisco();
                tablaMemoria = reporteDA.ListarLaptopMemoria();
                tablaLicencia = reporteDA.ListarLaptopLicencia();
                DataView viewDisco = new DataView(tablaDisco);
                DataView viewMemoria = new DataView(tablaMemoria);
                DataView viewLicencia = new DataView(tablaLicencia);
                int rec = 0;
                while (rec < tablaLaptops.Rows.Count)
                {
                    LC laptop = new LC();
                    laptop.IdLC = Convert.ToInt32(tablaLaptops.Rows[rec]["idLC"].ToString());
                    laptop.Codigo = tablaLaptops.Rows[rec]["codigo"].ToString();
                    laptop.IdMarca = int.Parse(tablaLaptops.Rows[rec]["idMarca"].ToString());
                    laptop.MarcaLC = tablaLaptops.Rows[rec]["marcaLC"].ToString();
                    laptop.NombreModeloLC = tablaLaptops.Rows[rec]["nombreModeloLC"].ToString();
                    laptop.TipoProcesador = tablaLaptops.Rows[rec]["tipoProcesador"].ToString();
                    laptop.IdGeneracionProcesador = int.Parse(tablaLaptops.Rows[rec]["idGeneracionProcesador"].ToString());
                    laptop.GeneracionProcesador = int.Parse(tablaLaptops.Rows[rec]["generacionProcesador"].ToString());
                    laptop.IdTipoProcesador = int.Parse(tablaLaptops.Rows[rec]["idTipoProcesador"].ToString());
                    laptop.NombreModeloVideo = tablaLaptops.Rows[rec]["nombreModeloVideo"].ToString().Length > 0 ? tablaLaptops.Rows[rec]["nombreModeloVideo"].ToString() : "";
                    laptop.CapacidadVideo = Convert.ToInt32(tablaLaptops.Rows[rec]["capacidadVideo"].ToString());
                    laptop.EstadoNombre = tablaLaptops.Rows[rec]["estado"].ToString();
                    laptop.Estado = int.Parse(tablaLaptops.Rows[rec]["idEstado"].ToString());
                    laptop.Cliente = tablaLaptops.Rows[rec]["cliente"].ToString();
                    laptop.RucCliente = tablaLaptops.Rows[rec]["rucCliente"].ToString();
                    laptop.Ubicacion = tablaLaptops.Rows[rec]["ubicacion"].ToString();
                    laptop.SerieFabrica = tablaLaptops.Rows[rec]["serieFabrica"].ToString();

                    viewDisco.RowFilter = "idLC = " + laptop.IdLC.ToString();
                    viewMemoria.RowFilter = "idLC = " + laptop.IdLC.ToString();
                    viewLicencia.RowFilter = "idLC = " + laptop.IdLC.ToString();
                    laptop.SetDisco(viewDisco);
                    laptop.SetMemoria(viewMemoria);
                    laptop.SetLicencia(viewLicencia);

                    if (laptop.Discos.Count > 0)
                    {
                        if (laptop.Discos.Count == 1)
                        {
                            laptop.Disco1 = laptop.Discos[0].TipoDisco;
                            laptop.CapacidadDisco1 = (laptop.Discos[0].Cantidad * laptop.Discos[0].Capacidad).ToString() + " GB";
                            laptop.Disco2 = "";
                            laptop.CapacidadDisco2 = "";
                        }
                        else if (laptop.Discos.Count >= 2)
                        {
                            laptop.Disco1 = laptop.Discos[0].TipoDisco;
                            laptop.CapacidadDisco1 = (laptop.Discos[0].Cantidad * laptop.Discos[0].Capacidad).ToString() + " GB";

                            laptop.Disco2 = laptop.Discos[1].TipoDisco;
                            laptop.CapacidadDisco2 = (laptop.Discos[1].Cantidad * laptop.Discos[1].Capacidad).ToString() + " GB";
                        }
                    }
                    else if (laptop.Discos.Count == 0)
                    {
                        laptop.Disco1 = "";
                        laptop.CapacidadDisco1 = "";
                        laptop.Disco2 = "";
                        laptop.CapacidadDisco2 = "";
                    }

                    int capacidadMem = 0;
                    foreach (Memoria mem in laptop.Memorias)
                    {
                        capacidadMem += mem.Capacidad * mem.Cantidad;
                    }
                    laptop.CapacidadMemoria = capacidadMem.ToString() + " GB";

                    Licencia windows = null; Licencia office = null; Licencia antivirus = null;

                    if (laptop.Licencias.Count > 0)
                    {
                        windows = laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaSO);
                        office = laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaOffice);
                        antivirus = laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaAntivirus);

                    }

                    laptop.LicenciaWindows = (windows != null) ? windows.Version : "";
                    laptop.LicenciaOffice = (office != null) ? office.Version : "";
                    laptop.LicenciaAntivirus = (antivirus != null) ? antivirus.Version : "";

                    laptop.Licencias = null;
                    laptop.Discos = null;
                    laptop.Memorias = null;

                    laptop.IdSalida = tablaLaptops.Rows[rec]["idSalida"].ToString();

                    laptops.Add(laptop);
                    rec++;
                }

                this.cantGeneraciones = tablaProcesadoresGeneracion.Rows.Count;
                this.cantModeloProcesador = tablaProcesadoresModelos.Rows.Count;

                this.arregloLCGeneral = new int[cantGeneraciones][];
                this.arregloLCApple = new int[cantGeneraciones][];

                for (int i = 0; i < this.cantGeneraciones; i++)
                {
                    this.arregloLCGeneral[i] = new int[this.cantModeloProcesador];
                    this.arregloLCApple[i] = new int[this.cantModeloProcesador];

                    for (int j = 0; j < this.cantModeloProcesador; j++)
                    {
                        int idGen = int.Parse(tablaProcesadoresGeneracion.Rows[i]["idAuxiliar"].ToString());
                        int idModPro = int.Parse(tablaProcesadoresModelos.Rows[j]["idModelo"].ToString());
                        var cantidad = new BindingList<LC>(laptops.Where(p => p.IdMarca != this.idMarcaAppleLC && p.IdGeneracionProcesador == idGen && p.IdTipoProcesador == idModPro && p.IdMarca != this.idMarcaApplePC && p.Estado == this.estadoDisponible).ToList());
                        this.arregloLCGeneral[i][j] = cantidad.Count;
                        cantidad = new BindingList<LC>(laptops.Where(p => p.IdMarca == this.idMarcaAppleLC && p.IdGeneracionProcesador == idGen && p.IdTipoProcesador == idModPro && p.IdMarca != this.idMarcaApplePC && p.Estado == this.estadoDisponible).ToList());
                        this.arregloLCApple[i][j] = cantidad.Count;
                    }
                }


                dgvLaptops.DataSource = laptops;
                vista.OptionsBehavior.AutoPopulateColumns = false;
                vista.OptionsSelection.MultiSelect = true;

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message); OMITIMOS EL MENSAJE
            }


            return true;
        }

        private void frmReporteStocksLaptops_Load(object sender, EventArgs e)
        {

            cargarData.PerformClick();

        }

        private void dgvLaptops_MouseHover(object sender, EventArgs e)
        {
            //label1.Text = $"CANTIDAD FILTRADA:";
            txtCantidadFiltrada.Text = vista.RowCount.ToString();
        }

        private void dgvLaptops_MouseLeave(object sender, EventArgs e)
        {
            //label1.Text = $"CANTIDAD FILTRADA:";
            txtCantidadFiltrada.Text = vista.RowCount.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAlquilados_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInutilizables_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPersonales_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtActivos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDanados_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDesactivos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVendido_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
