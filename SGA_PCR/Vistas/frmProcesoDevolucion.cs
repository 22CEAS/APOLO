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
    public partial class frmProcesoDevolucion : Form
    {

        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaCliente;
        DataTable tablaLaptops;
        ClienteDA clienteDA;
        AlquilerDA alquilerDA;
        DevolucionDA devolucionDA;
        Devolucion devolucion;
        DevolucionDetalle detalleTemp;

        private int idUsuario;
        private string nombreUsuario = "CEAS";

        public frmProcesoDevolucion()
        {
            InitializeComponent();
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public frmProcesoDevolucion(int idUsuario, string nombreUsuario)
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
            alquilerDA = new AlquilerDA();
            devolucionDA = new DevolucionDA();
            devolucion = new Devolucion();

            detalleTemp = new DevolucionDetalle();
            dtpFechaIngreso.Value = DateTime.Now;

            tablaCliente = clienteDA.ListarClientes();
            cmbCliente.DataSource = tablaCliente;
            cmbCliente.DisplayMember = "nombre_razonSocial";
            cmbCliente.ValueMember = "idCliente";

            cmbCliente.SelectedIndex = 0;

            int i = cmbCliente.SelectedIndex;

            int idCliente = Convert.ToInt32(tablaCliente.Rows[i]["idCliente"].ToString());
            txtNroDocumento.Text = tablaCliente.Rows[i]["nroDocumento"].ToString();

            tablaLaptops = devolucionDA.ListarLaptopsClientesEstadoAlquilado(idCliente);

            ObtenerDatosDevolucion();
            devolucion.LlenarDatos(tablaLaptops);
            dgvLaptopsSeleccionados.PrimaryGrid.DataSource = tablaLaptops;
            dgvLaptopsSeleccionados.PrimaryGrid.AutoGenerateColumns = false;

        }

        public void ObtenerDatosDevolucion()
        {

            devolucion.IdCliente = Convert.ToInt32(cmbCliente.SelectedValue.ToString());
            devolucion.FechaDevolucion = dtpFechaIngreso.Value;
            string aux1 = "";
            aux1 = txtNroGuia.Text;
            devolucion.GuiaDevolucion = aux1.Trim();
            string aux2 = "";
            aux2 = txtNroDocumento.Text;
            devolucion.RucDni = aux2.Trim();

        }

        public void estadoComponentes(TipoVista estado)
        {
            switch (estado)
            {
                case TipoVista.Inicial:
                    cmbCliente.Enabled = false;
                    dtpFechaIngreso.Enabled = false;
                    txtNroGuia.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnObservacion.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnBuscar.Enabled = true;
                    btnAnular.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    limpiarComponentes();
                    devolucion = new Devolucion();
                    break;
                case TipoVista.Nuevo:
                    cmbCliente.Enabled = true;
                    dtpFechaIngreso.Enabled = true;
                    txtNroGuia.Enabled = true;
                    txtNroDocumento.Enabled = true;
                    dgvLaptopsSeleccionados.Enabled = true;
                    btnAgregarProducto.Enabled = true;
                    btnObservacion.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnAnular.Enabled = false;
                    btnBuscar.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    limpiarComponentes();
                    devolucion = new Devolucion();
                    ObtenerDatosDevolucion();
                    break;
                case TipoVista.Guardar:
                    cmbCliente.Enabled = false;
                    dtpFechaIngreso.Enabled = false;
                    txtNroGuia.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnObservacion.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnAnular.Enabled = true;
                    btnBuscar.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    //limpiarComponentes();
                    //alquiler = new Alquiler();
                    //limpiarComponentes();
                    break;
                case TipoVista.Modificar:
                    cmbCliente.Enabled = true;
                    dtpFechaIngreso.Enabled = true;
                    txtNroGuia.Enabled = true;
                    txtNroDocumento.Enabled = true;
                    dgvLaptopsSeleccionados.Enabled = true;
                    btnAgregarProducto.Enabled = true;
                    btnObservacion.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnAnular.Enabled = false;
                    btnBuscar.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    //limpiarComponentes();
                    //alquiler = new Alquiler();
                    break;
                case TipoVista.Vista:
                    cmbCliente.Enabled = false;
                    dtpFechaIngreso.Enabled = false;
                    txtNroGuia.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnObservacion.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnAnular.Enabled = true;
                    btnBuscar.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    //limpiarComponentes();
                    devolucion = new Devolucion();
                    break;
                case TipoVista.Limpiar:
                    cmbCliente.Enabled = false;
                    dtpFechaIngreso.Enabled = false;
                    txtNroGuia.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnObservacion.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnAnular.Enabled = false;
                    btnBuscar.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    limpiarComponentes();
                    devolucion = new Devolucion();
                    break;
                case TipoVista.Duplicar:
                    cmbCliente.Enabled = false;
                    dtpFechaIngreso.Enabled = false;
                    txtNroGuia.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnObservacion.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    limpiarComponentes();
                    devolucion = new Devolucion();
                    break;
                case TipoVista.Anular:
                    cmbCliente.Enabled = false;
                    dtpFechaIngreso.Enabled = false;
                    txtNroGuia.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnObservacion.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnBuscar.Enabled = true;
                    btnAnular.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    //limpiarComponentes();
                    //devolucion = new Devolucion();
                    break;
            }
        }

        public void limpiarComponentes()
        {
            cmbCliente.SelectedIndex = 0;
            txtNroDevolucion.Text = "";
            txtNroGuia.Text = "";
            dtpFechaIngreso.Value = DateTime.Now;
            dgvLaptopsSeleccionados.PrimaryGrid.DataSource = null;
        }
        
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

            int i = cmbCliente.SelectedIndex;
            if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                devolucion = new Devolucion();
                int idCliente = Convert.ToInt32(tablaCliente.Rows[i]["idCliente"].ToString());
                txtNroDocumento.Text = tablaCliente.Rows[i]["nroDocumento"].ToString();
                devolucion.IdCliente = idCliente;
                tablaLaptops = null;
                dgvLaptopsSeleccionados.PrimaryGrid.DataSource = null;
            }
            else
            {
                txtNroDocumento.Text = "";
            }

        }

        public void LlenarDatosDevolucion()
        {
            txtNroDevolucion.Text = devolucion.IdDevolucion.ToString();
            txtNroDocumento.Text = devolucion.RucDni;
            txtNroGuia.Text = devolucion.GuiaDevolucion.ToString();
            dtpFechaIngreso.Value = devolucion.FechaDevolucion;
            cmbCliente.SelectedValue = devolucion.IdCliente;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Nuevo);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas cancelar el proceso", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                estadoComponentes(TipoVista.Limpiar);
                devolucion = new Devolucion();
                dgvLaptopsSeleccionados.PrimaryGrid.DataSource = null;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            estadoComponentes(TipoVista.Vista);
            frmProcesoDevolucionBuscar frmBP = new frmProcesoDevolucionBuscar(this.idUsuario);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
                devolucion = frmBP.ObjSeleccionado;
                txtNroDevolucion.Text = devolucion.IdDevolucion.ToString();
                LlenarDatosDevolucion();
                devolucion = frmBP.ObjSeleccionado;
                dgvLaptopsSeleccionados.PrimaryGrid.DataSource = devolucion.Detalles;
            }
            else
            {
                estadoComponentes(TipoVista.Inicial);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea Modificar\n" + "la Devolución N° :" + txtNroDevolucion.Text, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                estadoComponentes(TipoVista.Modificar);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            string numDevolucion = txtNroDevolucion.Text;

            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("No se puede grabar una Devolucion si no\nha seleccionado un cliente correcto.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return;
            }

           

            ObtenerDatosDevolucion();

            if (devolucion.Detalles.Count == 0)
            {
                MessageBox.Show("No se puede grabar un Devolución si no\nseleccionas ninguna laptop.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                return;
            }

            if (devolucion.GuiaDevolucion.Length == 0)
            {
                MessageBox.Show("No se puede grabar esta Devolución\nnecesita ingresar una guia.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                return;
            }
            
            if (numDevolucion.Length == 0)
            {
                if (MessageBox.Show("Estas seguro que deseas guardar este proceso de Devolución", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idDevolucion=0;
                    idDevolucion = devolucionDA.InsertarDevolucion(devolucion, this.nombreUsuario);

                    if (idDevolucion == 0)
                    {
                        MessageBox.Show("Hubo error en Registrar la Devolución, comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    MessageBox.Show("Se guardó la devolución", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    devolucion.IdDevolucion = idDevolucion;
                    txtNroDevolucion.Text = idDevolucion.ToString();
                    estadoComponentes(TipoVista.Guardar);
                }
            }
            else
            {
                
                if (MessageBox.Show("Estas seguro que desea Guardar los cambios", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    devolucionDA.ModificarDevolucion(devolucion, this.nombreUsuario);
                    MessageBox.Show("Se Modifico la Devolución N° :" + txtNroDevolucion.Text + " con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    estadoComponentes(TipoVista.Guardar);
                }
            }


        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("No se puede agregar productos\n si no se ha seleccionado un cliente correcto.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return;
            }
            using (frmProcesoDevolucionAgregarProducto frm = new frmProcesoDevolucionAgregarProducto(devolucion.IdCliente))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindingList<DevolucionDetalle> auxiliares = new BindingList<DevolucionDetalle>();
                    foreach (DevolucionDetalle aux in devolucion.Detalles)
                    {
                        auxiliares.Add(aux);
                    }

                    foreach (DevolucionDetalle detalleTraido in frm.DETALLES)
                    {
                        DevolucionDetalle dp = new DevolucionDetalle();
                        dp.IdLC = detalleTraido.IdLC;
                        bool exists = auxiliares.Any(x => x.IdLC.Equals(dp.IdLC));
                        if (!(exists))
                        {
                            auxiliares.Add(detalleTraido);
                        }
                    }
                    devolucion.Detalles = auxiliares;
                }
            }

            dgvLaptopsSeleccionados.PrimaryGrid.DataSource = devolucion.Detalles;
            if (devolucion.Detalles.Count > 0)
            {
                btnObservacion.Enabled = true;
            }
        }

        private void btnObservacion_Click(object sender, EventArgs e)
        {

            if (dgvLaptopsSeleccionados.PrimaryGrid.Rows.Count > 0)
            {
                detalleTemp.IdLC = int.Parse(((GridCell)(((GridRow)dgvLaptopsSeleccionados.PrimaryGrid.ActiveRow)[4])).Value.ToString());

                int indice = 0;
                foreach (DevolucionDetalle detalle in devolucion.Detalles)
                {
                    if (detalle.IdLC == detalleTemp.IdLC)
                    {
                        break;
                    }
                    indice++;
                }
                int cobrar = devolucion.Detalles[indice].Cobrar;
                int dano = devolucion.Detalles[indice].Danado;
                string observacion = devolucion.Detalles[indice].Observacion;
                using (frmProcesoDevolucionEvaluarEquipo frm = new frmProcesoDevolucionEvaluarEquipo(cobrar, dano, observacion))
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        devolucion.Detalles[indice].Cobrar = frm.Cobrado;
                        devolucion.Detalles[indice].Danado = frm.Dano;
                        devolucion.Detalles[indice].EstadoLC = (frm.Dano == 1) ? 3 : 2;
                        devolucion.Detalles[indice].Observacion = frm.Observacion;
                        dgvLaptopsSeleccionados.PrimaryGrid.DataSource = devolucion.Detalles;
                    }
                }
            }

        }

        private void dgvLaptopsSeleccionados_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro deseas Eliminar esta laptop de tu detalle de Devolución", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                bool error;
                if (dgvLaptopsSeleccionados.PrimaryGrid.Rows.Count > 0)
                {
                    detalleTemp.IdLC = int.Parse(((GridCell)(((GridRow)dgvLaptopsSeleccionados.PrimaryGrid.ActiveRow)[4])).Value.ToString());

                    int indiceLC = 0;
                    foreach (DevolucionDetalle detalle in devolucion.Detalles)
                    {
                        if (detalle.IdLC == detalleTemp.IdLC)
                        {
                            break;
                        }
                        indiceLC++;
                    }

                    devolucion.Detalles.RemoveAt(indiceLC);

                    dgvLaptopsSeleccionados.PrimaryGrid.DataSource = devolucion.Detalles;
                }
            }

        }

        private void btnAnular_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            if (devolucion.Estado == 0)
            {
                MessageBox.Show("Esta devolucion ya se encuentra en estado Anulado", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBox.Show("Estas seguro que desea Anular esta devolucion", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    devolucion.Estado = 0;
                    devolucionDA.AnularDevolucion(devolucion, this.nombreUsuario);
                    MessageBox.Show("Se anulo la Devolución N° :" + devolucion.IdDevolucion);
                    estadoComponentes(TipoVista.Anular);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Estas seguro que desea Imprimir la Devolución", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {

                    SaveFileDialog fichero = new SaveFileDialog();
                    //fichero.Filter = "Excel (*.xls)|*.xls";
                    fichero.Filter = "Excel(*.xlsx) | *.xlsx";
                    fichero.FileName = "Devolucion_" + devolucion.IdDevolucion.ToString();
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        Excel.Application aplicacion;
                        Excel.Workbook libros_trabajo;
                        Excel.Worksheet hoja_pre_alquiler;

                        aplicacion = new Excel.Application();
                        libros_trabajo = (Excel.Workbook)aplicacion.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

                        hoja_pre_alquiler = (Excel.Worksheet)libros_trabajo.Worksheets.Add();
                        hoja_pre_alquiler.Name = "Devolución";
                        string cabecera = "Reporte de Devolución";
                        ExportarDataGridViewExcel(ref hoja_pre_alquiler, dgvLaptopsSeleccionados, cabecera);


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



        public void ExportarDataGridViewExcel(ref Excel.Worksheet hoja_trabajo, SuperGridControl grd, string nombreCabecera)
        {
            Excel.Range rango;
            int i = 0;
            //Recorremos el DataGridView rellenando la hoja de trabajo
            foreach (DevolucionDetalle det in devolucion.Detalles)
            {
                //int k = grd.Columns.Count + 64;
                int k = 6 + 64;
                char columF = (char)k;
                int fila2 = i + 8;
                string filaBorde = fila2.ToString();
                char columI = 'A';
                //Ponemos borde a las celdas
                rango = hoja_trabajo.Range[columI + fila2.ToString(), columF + fila2.ToString()];
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rango.Style.Font.Bold = false;

                hoja_trabajo.Cells[i + 8, 1] = "LAPTOP " + det.CodigoLC;
                hoja_trabajo.Cells[i + 8, 2] = det.MarcaLC;
                hoja_trabajo.Cells[i + 8, 3] = det.ModeloLC;
                hoja_trabajo.Cells[i + 8, 4] = det.Observacion;
                hoja_trabajo.Cells[i + 8, 5] = (det.Cobrar == 1) ? "Pagará Cliente" : "No Pagará Cliente"; 
                hoja_trabajo.Cells[i + 8, 6] = (det.Danado == 1) ? "Equipo Dañado" : "Equipo Sin Daño";
                i++;
            }
            montaCabeceras(1, ref hoja_trabajo, grd, nombreCabecera);
        }

        private void montaCabeceras(int fila, ref Excel.Worksheet hoja, SuperGridControl grd, string nombreCabecera)
        {
            try
            {
                Excel.Range rango;

                //** Montamos el título en la línea 1 **
                hoja.Cells[fila, 1] = nombreCabecera;
                hoja.Range[hoja.Cells[fila, 1], hoja.Cells[fila, 6]].Merge();
                hoja.Range[hoja.Cells[fila, 1], hoja.Cells[fila, 6]].Interior.Color = Color.Silver;
                hoja.Range[hoja.Cells[fila, 1], hoja.Cells[fila, 6]].Style.Font.Bold = true;
                //Centramos los textos
                rango = hoja.Rows[fila];
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //worksheet.Range[worksheet.Cells[rowNum, columnNum], worksheet.Cells[rowNum, columnNum]].Merge();
                int indice;

                hoja.Cells[fila + 2, 1] = "Devolución N°";
                hoja.Cells[fila + 2, 2] = txtNroDevolucion.Text;

                hoja.Cells[fila + 3, 1] = "Cliente°";
                indice = cmbCliente.SelectedIndex;
                hoja.Cells[fila + 3, 2] = tablaCliente.Rows[indice]["nombre_razonSocial"].ToString();
                hoja.Cells[fila + 4, 1] = "RUC";
                hoja.Cells[fila + 4, 2] = txtNroDocumento.Text;

                hoja.Cells[fila + 3, 5] = "Fecha Ingreso";
                hoja.Cells[fila + 3, 6] = dtpFechaIngreso.Value.ToString("yyyy/MM/dd");
                hoja.Cells[fila + 4, 5] = "Guia de Remisión";
                hoja.Cells[fila + 4, 6] = txtNroGuia.Text;

                hoja.Cells[fila + 6, 1] = "Equipo";
                hoja.Cells[fila + 6, 2] = "Marca";
                hoja.Cells[fila + 6, 3] = "Modelo";
                hoja.Cells[fila + 6, 4] = "Observación";
                hoja.Cells[fila + 6, 5] = "Cobrar a Cliente";
                hoja.Cells[fila + 6, 6] = "Daño en el Equipo";

                //int i = grd.Columns.Count + 64;
                int i = 6 + 64;
                char columF = (char)i;
                int fila2 = fila + 6;
                string filaBorde = fila2.ToString();
                char columI = 'A';
                //Ponemos borde a las celdas
                rango = hoja.Range[columI + fila2.ToString(), columF + fila2.ToString()];
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rango.Interior.Color = Color.Silver;
                rango.Style.Font.Bold = true;
                //Centramos los textos
                rango = hoja.Rows[fila2];
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //for (int j = 0; j < grd.Columns.Count; j++)
                for (int j = 0; j < 6; j++)
                {
                    rango = hoja.Columns[j + 1];
                    rango.ColumnWidth = 20;
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


    }
}
