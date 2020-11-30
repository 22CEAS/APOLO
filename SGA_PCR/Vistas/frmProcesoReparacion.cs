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
using Excel = Microsoft.Office.Interop.Excel;

namespace Apolo
{
    public partial class frmProcesoReparacion : Form
    {

        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }

        ClienteDA clienteDA;
        ReparacionDA reparacionDA;
        Reparacion reparacion;
        Reparacion reparacionOld;
        LC artTemp;
        DataTable tablaDatosLaptop;
        DataTable tablaEstados;

        private int idUsuario;
        private string nombreUsuario = "CEAS";
        private int flagModificar = 0;

        public frmProcesoReparacion()
        {
            InitializeComponent();
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public frmProcesoReparacion(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public void Inicializado()
        {

            clienteDA = new ClienteDA();
            reparacionDA = new ReparacionDA();

            artTemp = new LC();
            dtpFecReparacion.Value = DateTime.Now;

            reparacion = new Reparacion();
            reparacionOld = new Reparacion();

            tablaEstados = reparacionDA.ListarEstados();
            cmbEstado.DataSource = tablaEstados;
            cmbEstado.DisplayMember = "nombreEstado";
            cmbEstado.ValueMember = "idEstado";
            cmbEstado.SelectedIndex = 0;

            tablaDatosLaptop = reparacionDA.ListarLaptops();
            cmbEquipo.DataSource = tablaDatosLaptop;
            cmbEquipo.DisplayMember = "codigo";
            cmbEquipo.ValueMember = "idLC";
            cmbEquipo.SelectedIndex = tablaDatosLaptop.Rows.Count>0?0:-1;

            ObtenerDatosReparacion();

        }

        public void ObtenerDatosReparacion()
        {
            reparacion.FechaReparacion = dtpFecReparacion.Value;
            string aux1 = txtDescripcion.Text;
            reparacion.ObservacionReparacion = aux1.Trim();
            string aux2 = txtObservacion.Text;
            reparacion.ObservacionActual = aux2.Trim();

            int i = cmbEquipo.SelectedIndex;
            if (i >= 0)
            {
                reparacion.IdLC = Convert.ToInt32(tablaDatosLaptop.Rows[i]["idLC"].ToString());
                reparacion.CodigoLC = tablaDatosLaptop.Rows[i]["codigo"].ToString();
                reparacion.EstadoLCAnt = Convert.ToInt32(tablaDatosLaptop.Rows[i]["idEstado"].ToString());
            }
            i = cmbEstado.SelectedIndex;
            if (i >= 0)
            {
                reparacion.EstadoLCAct = Convert.ToInt32(tablaEstados.Rows[i]["idEstado"].ToString());
            }
        }

        public void estadoComponentes(TipoVista estado)
        {
            switch (estado)
            {
                case TipoVista.Inicial:
                    cmbEquipo.Enabled = false;
                    cmbEstado.Enabled = false;
                    dtpFecReparacion.Enabled = false;
                    txtObservacion.Enabled = false;
                    txtDescripcion.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnBuscar.Enabled = true;
                    btnAnular.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    limpiarComponentes();
                    reparacion = new Reparacion();
                    break;
                case TipoVista.Nuevo:
                    cmbEquipo.Enabled = true;
                    cmbEstado.Enabled = true;
                    dtpFecReparacion.Enabled = true;
                    txtObservacion.Enabled = true;
                    txtDescripcion.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnAnular.Enabled = false;
                    btnBuscar.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    limpiarComponentes();
                    reparacion = new Reparacion();
                    break;
                case TipoVista.Guardar:
                    cmbEquipo.Enabled = false;
                    cmbEstado.Enabled = false;
                    dtpFecReparacion.Enabled = false;
                    txtObservacion.Enabled = false;
                    txtDescripcion.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnAnular.Enabled = true;
                    btnBuscar.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    break;
                case TipoVista.Modificar:
                    cmbEquipo.Enabled = true;
                    cmbEstado.Enabled = true;
                    dtpFecReparacion.Enabled = true;
                    txtObservacion.Enabled = true;
                    txtDescripcion.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnAnular.Enabled = false;
                    btnBuscar.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    break;
                case TipoVista.Vista:
                    cmbEquipo.Enabled = false;
                    cmbEstado.Enabled = false;
                    dtpFecReparacion.Enabled = false;
                    txtObservacion.Enabled = false;
                    txtDescripcion.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnAnular.Enabled = true;
                    btnBuscar.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    reparacion = new Reparacion();
                    break;
                case TipoVista.Limpiar:
                    cmbEquipo.Enabled = false;
                    cmbEstado.Enabled = false;
                    dtpFecReparacion.Enabled = false;
                    txtObservacion.Enabled = false;
                    txtDescripcion.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnAnular.Enabled = false;
                    btnBuscar.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    limpiarComponentes();
                    reparacion = new Reparacion();
                    break;
                case TipoVista.Duplicar:
                    cmbEquipo.Enabled = false;
                    cmbEstado.Enabled = false;
                    dtpFecReparacion.Enabled = false;
                    txtObservacion.Enabled = false;
                    txtDescripcion.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    limpiarComponentes();
                    reparacion = new Reparacion();
                    break;
                case TipoVista.Anular:
                    cmbEquipo.Enabled = false;
                    cmbEstado.Enabled = false;
                    dtpFecReparacion.Enabled = false;
                    txtObservacion.Enabled = false;
                    txtDescripcion.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnBuscar.Enabled = true;
                    btnAnular.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    break;
            }
        }

        public void limpiarComponentes()
        {
            txtObservacion.Text = "";
            txtDescripcion.Text = "";
            txtNroReparacion.Text = "";
            dtpFecReparacion.Value = DateTime.Now;

            tablaEstados = reparacionDA.ListarEstados();
            cmbEstado.DataSource = tablaEstados;
            cmbEstado.DisplayMember = "nombre";
            cmbEstado.ValueMember = "idEstado";
            cmbEstado.SelectedIndex = tablaEstados.Rows.Count > 0 ? -1 : -1;

            tablaDatosLaptop.Rows.Clear();
            cmbEquipo.DataSource= tablaDatosLaptop;
            tablaDatosLaptop = reparacionDA.ListarLaptops();
            cmbEquipo.DataSource = tablaDatosLaptop;
            cmbEquipo.DisplayMember = "codigo";
            cmbEquipo.ValueMember = "idLC";
            cmbEquipo.SelectedIndex = tablaDatosLaptop.Rows.Count > 0 ? -1 : -1;
        }



        private void btnGrabar_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            string numReparacion = txtNroReparacion.Text;

            if (cmbEquipo.SelectedValue == null)
            {
                MessageBox.Show("No se puede grabar una Reparacion si no\nha seleccionado una laptop correcto.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return;
            }
            if (cmbEstado.SelectedValue == null)
            {
                MessageBox.Show("No se puede grabar una Reparacion si no\nha seleccionado una estado correcto.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return;
            }
            string observacion = txtObservacion.Text;
            observacion = observacion.Trim();

            if (observacion.Length == 0)
            {
                MessageBox.Show("No se puede grabar una Reparacion si no\nllena el campo de observacion.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                return;
            }

            string descripcion = txtDescripcion.Text;
            descripcion = descripcion.Trim();
            if (descripcion.Length == 0)
            {
                MessageBox.Show("No se puede grabar una Reparacion si no\nllena el campo de descripcion.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                return;
            }

            ObtenerDatosReparacion();

            if (numReparacion.Length == 0)
            {
                if (MessageBox.Show("Estas seguro que deseas Guardar este proceso de Reparacion", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idReparacion = reparacionDA.InsertarReparacion(reparacion, this.nombreUsuario);
                    if (idReparacion == 0)
                    {
                        MessageBox.Show("Hubo error en Registrar la Reparacion, comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    MessageBox.Show("Se guardó la Reparacion", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    reparacion.IdReparacion = idReparacion;
                    reparacionOld = new Reparacion(reparacion);
                    txtNroReparacion.Text = idReparacion.ToString();
                    estadoComponentes(TipoVista.Guardar);
                }
            }
            else
            {
                if (MessageBox.Show("Estas seguro que desea Guardar los cambios", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    bool okey=reparacionDA.ModificarReparacion(reparacion, this.nombreUsuario, reparacionOld);
                    if (okey)
                        MessageBox.Show("Se Modifico la Reparacion N° :" + txtNroReparacion.Text + " con exito", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    else
                        MessageBox.Show("No se Modifico la Reparacion N° :" + txtNroReparacion.Text + ", comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    estadoComponentes(TipoVista.Guardar);
                }
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (reparacion.Estado == 0)//
            {
                MessageBox.Show("Esta reparacion ya no se puede modificar", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBox.Show("Estas seguro que desea Modificar\n" + "la Reparacion N° :" + txtNroReparacion.Text, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    estadoComponentes(TipoVista.Modificar);
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Nuevo);
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            if (reparacion.Estado == 0)
            {
                MessageBox.Show("Esta reparacion ya se encuentra en estado Anulado", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBox.Show("Estas seguro que desea Anular esta reaparacion", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    reparacion.Estado = 0;
                    reparacionDA.AnularReparacion(reparacion, this.nombreUsuario);
                    MessageBox.Show("Se anulo la Reparacion N° :" + reparacion.IdReparacion, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estadoComponentes(TipoVista.Anular);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas cancelar el proceso", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                estadoComponentes(TipoVista.Limpiar);
                reparacion = new Reparacion();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Estas seguro que desea Imprimir la Reparacion", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {

                    SaveFileDialog fichero = new SaveFileDialog();
                    //fichero.Filter = "Excel (*.xls)|*.xls";
                    fichero.Filter = "Excel(*.xlsx) | *.xlsx";
                    fichero.FileName = "Reparacion_" + reparacion.IdReparacion.ToString();
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        Excel.Application aplicacion;
                        Excel.Workbook libros_trabajo;
                        Excel.Worksheet hoja_pre_alquiler;

                        aplicacion = new Excel.Application();
                        libros_trabajo = (Excel.Workbook)aplicacion.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

                        hoja_pre_alquiler = (Excel.Worksheet)libros_trabajo.Worksheets.Add();
                        hoja_pre_alquiler.Name = "Reparacion";
                        string cabecera = "Reporte de Reparacion";
                        ExportarDataGridViewExcel(ref hoja_pre_alquiler,  cabecera);


                        ((Excel.Worksheet)aplicacion.ActiveWorkbook.Sheets["Hoja1"]).Delete();

                        //libros_trabajo.SaveAs(fichero.FileName, Excel.XlFileFormat.xlWorkbookNormal);
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
            int i = 0;
            //Recorremos el DataGridView rellenando la hoja de trabajo

            int k = 5 + 64;
            char columF = (char)k;
            int fila2 = i + 8;
            string filaBorde = fila2.ToString();
            char columI = 'A';
            //Ponemos borde a las celdas
            rango = hoja_trabajo.Range[columI + fila2.ToString(), columF + fila2.ToString()];
            rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            rango.Style.Font.Bold = false;

            hoja_trabajo.Cells[8, 1] = reparacion.ObservacionActual;

            fila2 = i + 11;

            rango = hoja_trabajo.Range[columI + fila2.ToString(), columF + fila2.ToString()];
            rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            rango.Style.Font.Bold = false;

            hoja_trabajo.Cells[11, 2] = reparacion.ObservacionReparacion;

            montaCabeceras(1, ref hoja_trabajo, nombreCabecera);
        }

        private void montaCabeceras(int fila, ref Excel.Worksheet hoja,  string nombreCabecera)
        {
            try
            {
                Excel.Range rango;

                //** Montamos el título en la línea 1 **
                hoja.Cells[fila, 1] = nombreCabecera;
                hoja.Range[hoja.Cells[fila, 1], hoja.Cells[fila, 5]].Merge();
                hoja.Range[hoja.Cells[fila, 1], hoja.Cells[fila, 5]].Interior.Color = Color.Silver;
                hoja.Range[hoja.Cells[fila, 1], hoja.Cells[fila, 5]].Style.Font.Bold = true;
                //Centramos los textos
                rango = hoja.Rows[fila];
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //worksheet.Range[worksheet.Cells[rowNum, columnNum], worksheet.Cells[rowNum, columnNum]].Merge();
                //int indice;

                string estado="";
                int i = cmbEstado.SelectedIndex;
                if (i >= 0)
                {
                    estado = tablaEstados.Rows[i]["nombreEstado"].ToString();
                }


                hoja.Cells[fila + 2, 1] = "Reparacion N°";
                hoja.Cells[fila + 2, 2] = txtNroReparacion.Text;

                hoja.Cells[fila + 3, 1] = "Codigo LC";
                hoja.Cells[fila + 3, 2] = reparacion.CodigoLC;

                hoja.Cells[fila + 2, 4] = "Fecha Reparacion";
                hoja.Cells[fila + 2, 5] = dtpFecReparacion.Value.ToString("yyyy/MM/dd");

                hoja.Cells[fila + 3, 4] = "Estado";
                hoja.Cells[fila + 3, 5] = estado;



                hoja.Cells[fila + 6, 1] = "Observación Actual del Equipo";
                hoja.Range[hoja.Cells[fila + 7, 1], hoja.Cells[fila + 7, 5]].Merge();
                hoja.Cells[fila + 9, 1] = "Descripcion de la Reparacion";
                hoja.Range[hoja.Cells[fila + 10, 1], hoja.Cells[fila + 10, 5]].Merge();


                hoja.Range[hoja.Cells[fila + 6, 1], hoja.Cells[fila + 6, 5]].Merge();
                hoja.Range[hoja.Cells[fila + 6, 1], hoja.Cells[fila + 6, 5]].Style.Font.Bold = true;

                hoja.Range[hoja.Cells[fila + 9, 1], hoja.Cells[fila + 9, 5]].Merge();
                hoja.Range[hoja.Cells[fila + 9, 1], hoja.Cells[fila + 9, 5]].Style.Font.Bold = true;

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


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Vista);
            frmProcesoReparacionBuscar frmBP = new frmProcesoReparacionBuscar(this.idUsuario);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
                flagModificar = 1;
                reparacion = frmBP.ObjSeleccionado;
                reparacionOld = new Reparacion(reparacion);
                txtNroReparacion.Text = reparacion.IdReparacion.ToString();
                LlenarDatosReparacion();
                reparacion = frmBP.ObjSeleccionado;
            }
            else
            {
                estadoComponentes(TipoVista.Inicial);
            }
        }

        public void LlenarDatosReparacion()
        {
            txtNroReparacion.Text = reparacion.IdReparacion.ToString();
            txtObservacion.Text = reparacion.ObservacionActual;
            txtDescripcion.Text = reparacion.ObservacionReparacion;
            cmbEstado.SelectedValue = reparacion.EstadoLCAct;

            DataRow newRow = tablaDatosLaptop.NewRow();
            newRow["idLC"] = reparacion.IdLC;
            newRow["codigo"] = reparacion.CodigoLC;
            newRow["idEstado"] = reparacion.EstadoLCAnt;
            tablaDatosLaptop.Rows.Add(newRow);

            cmbEquipo.DataSource = tablaDatosLaptop;
            cmbEquipo.DisplayMember = "codigo";
            cmbEquipo.ValueMember = "idLC";

            cmbEquipo.SelectedValue = reparacion.IdLC;
            dtpFecReparacion.Value = reparacion.FechaReparacion;
        }

        private void frmProcesoReparacion_Load(object sender, EventArgs e)
        {

        }
    }
}
