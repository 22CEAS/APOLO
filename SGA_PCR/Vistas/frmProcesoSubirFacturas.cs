using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpreadsheetLight;
using AccesoDatos;

namespace Apolo
{
    public partial class frmProcesoSubirFacturas : Form
    {
        BindingList<Factura> facturas;
        FacturaDA facturaDA;
        DataTable cuadroVencimiento;

        private int idUsuario;
        private string nombreUsuario = "CEAS";
        private int maxNumDias=3;
        private int minNumDias=-1;

        public frmProcesoSubirFacturas()
        {
            InitializeComponent();
            Inicializado();
        }

        public frmProcesoSubirFacturas(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
        }

        public void Inicializado()
        {
            //dgvFacturas.PrimaryGrid.AutoGenerateColumns = false;
            facturas = new BindingList<Factura>();
            facturaDA = new FacturaDA();
        }

     
        private void btnSubirFactura_Click(object sender, EventArgs e)
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
                    facturas = new BindingList<Factura>();

                    path = openFileDialog.FileName;
                    SLDocument sl = new SLDocument(path);

                    int iRow = 2;
                    while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                    {
                        string tipoPago = sl.GetCellValueAsString(iRow, 2);
                        if ((tipoPago == "RENOVACION") || (tipoPago == "ALQUILER"))
                        {
                            Factura fact = new Factura();
                            fact.FechaPago = sl.GetCellValueAsDateTime(iRow, 1);
                            fact.TipoPago = sl.GetCellValueAsString(iRow, 2);
                            fact.CodigoLC = sl.GetCellValueAsString(iRow, 3);
                            fact.Descripcion = sl.GetCellValueAsString(iRow, 4);
                            fact.FechaIniPago = sl.GetCellValueAsDateTime(iRow, 5);
                            fact.FechaFinPago = sl.GetCellValueAsDateTime(iRow, 6);
                            fact.RucDni = sl.GetCellValueAsString(iRow, 7);
                            fact.RazonSocial = sl.GetCellValueAsString(iRow, 8);
                            fact.NumeroOC = sl.GetCellValueAsString(iRow, 9);
                            fact.NumeroDocRef = sl.GetCellValueAsString(iRow, 10);
                            fact.NumeroFactura = sl.GetCellValueAsString(iRow, 11);
                            fact.TotalSoles = sl.GetCellValueAsDouble(iRow, 12);
                            fact.TotalDolares = sl.GetCellValueAsDouble(iRow, 13);
                            fact.TipoCambio = sl.GetCellValueAsDouble(iRow, 14);
                            fact.VentaSoles = sl.GetCellValueAsDouble(iRow, 15);
                            fact.Proveedor = sl.GetCellValueAsString(iRow, 16);
                            fact.CostoSoles = sl.GetCellValueAsDouble(iRow, 17);
                            fact.CostoDolares = sl.GetCellValueAsDouble(iRow, 18);
                            fact.UtilidadSoles = sl.GetCellValueAsDouble(iRow, 19);
                            fact.UtilidadDolares = sl.GetCellValueAsDouble(iRow, 20);
                            fact.CostoTotalSolesSinIGV = 0;
                            fact.UtilidadTotalSolesSinIGV = 0;

                            facturas.Add(fact);
                        }
                        iRow++;

                    }
                    //dgvFacturas.PrimaryGrid.DataSource = facturas;

                    dgvLaptops.DataSource = facturas;
                    vista.OptionsBehavior.AutoPopulateColumns = false;
                    vista.OptionsSelection.MultiSelect = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        public bool GrabarFactura()
        {
            Validar(2);
            MessageBox.Show("Se guardó las listas de facturas", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return true;
        }

        private async void btnGrabar_Click(object sender, EventArgs e)
        {
            if (facturas.Count > 0)
            {
                if (MessageBox.Show("Estas seguro que desea Guardar las facturas", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    giftCarga.Enabled = true;
                    giftCarga.Visible = true;
                    //facturaDA.InsertarFacturas(facturas, this.nombreUsuario);
                    Task<bool> task = new Task<bool>(GrabarFactura);
                    task.Start();
                    giftCarga.Image = Image.FromFile(@".\progress.gif");
                    giftCarga.SizeMode = PictureBoxSizeMode.StretchImage;
                    btnGrabar.Enabled = false;
                    btnSubirFactura.Enabled = false;
                    btnValidar.Enabled = false;
                    bool resultado = await task; //MIENTRAS CARGA
                    giftCarga.Enabled = false;
                    giftCarga.Visible = false;
                    btnGrabar.Enabled = true;
                    btnSubirFactura.Enabled = true;
                    btnValidar.Enabled = true;
                }
            }
        }

        private void Validar(int flag)
        {
            cuadroVencimiento = facturaDA.ListarCV();
            foreach (Factura f in facturas)
            {
                f.ObservacionXLevantar = "Esta laptop no se encuentra en el CV, o el código de la laptop o guia no coincide con ninguna del CV.";
                    
                String concatCodActCV = "", facturaCV = "", guiaSalidaCV = "";
                DateTime fecFinFacCV;
                DateTime fecIniContrato, fecFinContrato;
                String concatCodAntCV = "", facturaAntCV = "", guiaSalidaAntCV = "";
                String codigoActCV = "";
                DateTime fecFinFacAntCV;
                int idLcAntigua=0, idLcActual=0;
                int IdSalidaDetActual = 0, IdSalidaDetAntigua = 0;
                String concatCodSis = f.RucDni + "-" + f.CodigoLC;
                for (int i = 0; i < cuadroVencimiento.Rows.Count; i++)
                {
                    concatCodActCV = cuadroVencimiento.Rows[i]["concatCodActCV"].ToString();
                    codigoActCV = cuadroVencimiento.Rows[i]["codigo"].ToString();
                    facturaCV = cuadroVencimiento.Rows[i]["numFactura"].ToString();
                    guiaSalidaCV = cuadroVencimiento.Rows[i]["guiaActual"].ToString();
                    fecFinFacCV = DateTime.Parse(cuadroVencimiento.Rows[i]["fecFinPago"].ToString());
                    idLcActual = int.Parse(cuadroVencimiento.Rows[i]["IdLCActual"].ToString());
                    fecIniContrato = DateTime.Parse(cuadroVencimiento.Rows[i]["fecIniContrato"].ToString());
                    fecIniContrato = DateTime.Parse(fecIniContrato.ToShortDateString());
                    fecFinContrato = DateTime.Parse(cuadroVencimiento.Rows[i]["fecFinContrato"].ToString());
                    fecFinContrato = DateTime.Parse(fecFinContrato.ToShortDateString());

                    concatCodAntCV = cuadroVencimiento.Rows[i]["concatCodAntCV"].ToString();
                    facturaAntCV = cuadroVencimiento.Rows[i]["numFacturaAntigua"].ToString();
                    guiaSalidaAntCV = cuadroVencimiento.Rows[i]["guiaAntigua"].ToString();
                    fecFinFacAntCV = DateTime.Parse(cuadroVencimiento.Rows[i]["fecFinPagoAntigua"].ToString());
                    string aux = cuadroVencimiento.Rows[i]["IdLCAntigua"].ToString();
                    idLcAntigua = aux.Length == 0 ? 0:int.Parse(cuadroVencimiento.Rows[i]["IdLCAntigua"].ToString());
                    IdSalidaDetActual = int.Parse(cuadroVencimiento.Rows[i]["IdSalidaDetActual"].ToString());
                    IdSalidaDetAntigua = int.Parse(cuadroVencimiento.Rows[i]["IdSalidaDetAntigua"].ToString());

                    if ((concatCodSis == concatCodActCV && f.NumeroDocRef == guiaSalidaCV) || (concatCodSis == concatCodAntCV && f.NumeroDocRef == guiaSalidaAntCV))
                    {
                        if (f.FechaIniPago <= f.FechaFinPago)
                        {
                            if (f.NumeroFactura.Length != 0)
                            {
                                if (guiaSalidaAntCV.Length == 0)//no ha habido cambio
                                {
                                    if (facturaCV != f.NumeroFactura)
                                    {
                                        if (facturaCV.Length == 0)
                                        {
                                            TimeSpan tSpan = f.FechaIniPago - fecIniContrato;
                                            int numDiasTrans = tSpan.Days;
                                            //if (numDiasTrans != 0)
                                            //{
                                            if (numDiasTrans > this.maxNumDias || numDiasTrans < this.minNumDias)
                                            {
                                                f.ObservacionXLevantar = "Esta factura tiene errores en la fecha. Hay un Salto de fechas de " + numDiasTrans + " dias entre la fecha Inicio del Plazo de Alquiler y la fecha inicial de la factura.";
                                                break;
                                            }
                                            else
                                            {
                                                if (flag == 2)//2 es grabar
                                                {
                                                    facturaDA.InsertarFactura(f, this.nombreUsuario, idLcActual, idLcAntigua, codigoActCV);
                                                    f.ObservacionXLevantar = "Se grabo correctamente la factura.";
                                                    //if (fecFinContrato < f.FechaFinPago)
                                                    if (fecFinContrato != f.FechaFinPago)//&& tipoContrato==Palabra
                                                    {
                                                        facturaDA.ActualizarPlazoFinal(f, this.nombreUsuario, IdSalidaDetActual, IdSalidaDetAntigua);
                                                        f.ObservacionXLevantar = f.ObservacionXLevantar + " Se actualizó el Plazo";
                                                    }

                                                }
                                                else
                                                {
                                                    f.ObservacionXLevantar = "Todo Bien, es la primera factura, no hay factura anterior.";
                                                    if (fecFinContrato < f.FechaFinPago)
                                                    {
                                                        f.ObservacionXLevantar = f.ObservacionXLevantar + " Se actualizará el Plazo";
                                                    }
                                                }

                                                break;
                                            }
                                        }
                                        if (fecFinFacCV < f.FechaIniPago)
                                        {
                                            if (fecFinFacCV.ToString() == "31/12/1999 00:00:00")//es su primer ingreso
                                            {
                                                TimeSpan tSpan = f.FechaIniPago - fecIniContrato;
                                                int numDiasTrans = tSpan.Days;
                                                //if (numDiasTrans != 0)
                                                if (numDiasTrans > this.maxNumDias || numDiasTrans < this.minNumDias)
                                                {
                                                    f.ObservacionXLevantar = "Esta factura tiene errores en la fecha. Hay un Salto de fechas de " + numDiasTrans + " dias entre la fecha Inicio del Plazo de Alquiler y la fecha inicial de la factura.";
                                                    break;
                                                }
                                                else
                                                {
                                                    if (flag == 2)//2 es grabar
                                                    {
                                                        facturaDA.InsertarFactura(f, this.nombreUsuario, idLcActual, idLcAntigua, codigoActCV);
                                                        f.ObservacionXLevantar = "Se grabo correctamente la factura.";
                                                        //if (fecFinContrato < f.FechaFinPago)
                                                        if (fecFinContrato != f.FechaFinPago)//&& tipoContrato==Palabra
                                                        {
                                                            facturaDA.ActualizarPlazoFinal(f, this.nombreUsuario, IdSalidaDetActual, IdSalidaDetAntigua);
                                                            f.ObservacionXLevantar = f.ObservacionXLevantar + " Se actualizó el Plazo";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        f.ObservacionXLevantar = "Todo Bien, es la primera factura, no hay factura anterior.";
                                                        if (fecFinContrato < f.FechaFinPago)
                                                        {
                                                            f.ObservacionXLevantar = f.ObservacionXLevantar + " Se actualizará el Plazo";
                                                        }
                                                    }

                                                    break;
                                                }
                                            }
                                            else//verifica que las fechas sean consecutivas
                                            {
                                                TimeSpan tSpan = f.FechaIniPago - fecFinFacCV;
                                                int numDiasTrans = tSpan.Days;
                                                if (numDiasTrans != 1)
                                                {
                                                    f.ObservacionXLevantar = "Esta factura tiene errores en la fecha. Hay un Salto de fechas de " + numDiasTrans + " dias.";
                                                    break;
                                                }
                                                else
                                                {
                                                    if (flag == 2)//2 es grabar
                                                    {
                                                        facturaDA.InsertarFactura(f, this.nombreUsuario, idLcActual, idLcAntigua, codigoActCV);
                                                        f.ObservacionXLevantar = "Se grabo correctamente la factura.";
                                                        if (fecFinContrato < f.FechaFinPago)
                                                        {
                                                            facturaDA.ActualizarPlazoFinal(f, this.nombreUsuario, IdSalidaDetActual, IdSalidaDetAntigua);
                                                            f.ObservacionXLevantar = f.ObservacionXLevantar + " Se actualizó el Plazo";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        f.ObservacionXLevantar = "Todo Bien.";
                                                        if (fecFinContrato < f.FechaFinPago)
                                                        {
                                                            f.ObservacionXLevantar = f.ObservacionXLevantar + " Se actualizará el Plazo";
                                                        }
                                                    }

                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            f.ObservacionXLevantar = "Error en la fechas, la fecha final de la ultima factura pagada es mayor o igual a la fecha inicio de esta nueva factura";
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        f.ObservacionXLevantar = "Esta factura ya esta registrada";
                                        break;
                                    }
                                }
                                else //esto es en el caso de que si ha habido un cambio
                                {
                                    if (facturaCV.Length == 0)//no se ha grabado nada con la laptop actual
                                    {
                                        if (facturaAntCV.Length == 0)//no se grabo nada con la laptop antigua
                                        {
                                            TimeSpan tSpan = f.FechaIniPago - fecIniContrato;
                                            int numDiasTrans = tSpan.Days;
                                            //if (numDiasTrans != 0)
                                            if (numDiasTrans > this.maxNumDias || numDiasTrans < this.minNumDias)
                                            {
                                                f.ObservacionXLevantar = "Esta factura tiene errores en la fecha. Hay un Salto de fechas de " + numDiasTrans + " dias entre la fecha Inicio del Plazo de Alquiler y la fecha inicial de la factura.";
                                                break;
                                            }
                                            else
                                            {
                                                if (flag == 2)//2 es grabar
                                                {
                                                    facturaDA.InsertarFactura(f, this.nombreUsuario, idLcActual, idLcAntigua, codigoActCV);
                                                    f.ObservacionXLevantar = "Se grabo correctamente la factura.";
                                                    //if (fecFinContrato < f.FechaFinPago)
                                                    if (fecFinContrato != f.FechaFinPago)//&& tipoContrato==Palabra
                                                    {
                                                        facturaDA.ActualizarPlazoFinal(f, this.nombreUsuario, IdSalidaDetActual, IdSalidaDetAntigua);
                                                        f.ObservacionXLevantar = f.ObservacionXLevantar + " Se actualizó el Plazo";
                                                    }
                                                }
                                                else
                                                {
                                                    f.ObservacionXLevantar = "Todo Bien, es la primera factura, no hay factura anterior.";
                                                    if (fecFinContrato < f.FechaFinPago)
                                                    {
                                                        f.ObservacionXLevantar = f.ObservacionXLevantar + " Se actualizará el Plazo";
                                                    }
                                                }

                                                break;
                                            }
                                        }
                                        else //si se grabo nada con la laptop antigua
                                        {
                                            if (facturaAntCV != f.NumeroFactura)
                                            {
                                                if (fecFinFacAntCV < f.FechaIniPago)
                                                {
                                                    TimeSpan tSpan = f.FechaIniPago - fecFinFacAntCV;
                                                    int numDiasTrans = tSpan.Days;
                                                    if (numDiasTrans != 1)
                                                    {
                                                        f.ObservacionXLevantar = "Esta factura tiene errores en la fecha. Hay un Salto de fechas de " + numDiasTrans + " dias.";
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        if (flag == 2)//2 es grabar
                                                        {
                                                            facturaDA.InsertarFactura(f, this.nombreUsuario, idLcActual, idLcAntigua, codigoActCV);
                                                            f.ObservacionXLevantar = "Se grabo correctamente la factura.";
                                                            if (fecFinContrato < f.FechaFinPago)
                                                            {
                                                                facturaDA.ActualizarPlazoFinal(f, this.nombreUsuario, IdSalidaDetActual, IdSalidaDetAntigua);
                                                                f.ObservacionXLevantar = f.ObservacionXLevantar + " Se actualizó el Plazo";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            f.ObservacionXLevantar = "Todo Bien.";
                                                            if (fecFinContrato < f.FechaFinPago)
                                                            {
                                                                f.ObservacionXLevantar = f.ObservacionXLevantar + " Se actualizará el Plazo";
                                                            }
                                                        }

                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    f.ObservacionXLevantar = "Error en la fechas, la fecha final de la ultima factura pagada es mayor o igual a la fecha inicio de esta nueva factura";
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                f.ObservacionXLevantar = "Esta factura ya esta registrada";
                                                break;
                                            }
                                        }

                                    }
                                    else //si se grabo con la la laptop actual
                                    {
                                        if (facturaCV != f.NumeroFactura)
                                        {
                                            if (fecFinFacCV < f.FechaIniPago)
                                            {
                                                TimeSpan tSpan = f.FechaIniPago - fecFinFacCV;
                                                int numDiasTrans = tSpan.Days;
                                                if (numDiasTrans != 1)
                                                {
                                                    f.ObservacionXLevantar = "Esta factura tiene errores en la fecha. Hay un Salto de fechas de " + numDiasTrans + " dias.";
                                                    break;
                                                }
                                                else
                                                {
                                                    if (flag == 2)//2 es grabar
                                                    {
                                                        facturaDA.InsertarFactura(f, this.nombreUsuario, idLcActual, idLcAntigua, codigoActCV);
                                                        f.ObservacionXLevantar = "Se grabo correctamente la factura.";
                                                        if (fecFinContrato < f.FechaFinPago)
                                                        {
                                                            facturaDA.ActualizarPlazoFinal(f, this.nombreUsuario, IdSalidaDetActual, IdSalidaDetAntigua);
                                                            f.ObservacionXLevantar = f.ObservacionXLevantar + " Se actualizó el Plazo";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        f.ObservacionXLevantar = "Todo Bien.";
                                                        if (fecFinContrato < f.FechaFinPago)
                                                        {
                                                            f.ObservacionXLevantar = f.ObservacionXLevantar + " Se actualizará el Plazo";
                                                        }
                                                    }

                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                f.ObservacionXLevantar = "Error en la fechas, la fecha final de la ultima factura pagada es mayor o igual a la fecha inicio de esta nueva factura";
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            f.ObservacionXLevantar = "Esta factura ya esta registrada";
                                            break;
                                        }
                                    }
                                }

                            }
                            else
                            {
                                f.ObservacionXLevantar = "Error en la factura, el numero de la factura está vacio";
                                break;
                            }
                        }
                        else
                        {
                            f.ObservacionXLevantar = "Error en las fechas, la fecha final de la factura de Sisgeco es menor o igual a la fecha inicial de la factura de Sisgeco";
                            break;
                        }
                    }
                }
                //dgvFacturas.PrimaryGrid.DataSource = facturas;

                dgvLaptops.DataSource = facturas;
                vista.OptionsBehavior.AutoPopulateColumns = false;
                vista.OptionsSelection.MultiSelect = true;
            }
        }

        private async void btnValidar_Click(object sender, EventArgs e)
        {
            giftCarga.Enabled = true;
            giftCarga.Visible = true;
            Task<bool> task = new Task<bool>(ValidarFactura);
            task.Start();
            giftCarga.Image = Image.FromFile(@".\progress.gif");
            giftCarga.SizeMode = PictureBoxSizeMode.StretchImage;

            btnSubirFactura.Enabled = false;
            btnGrabar.Enabled = false;
            btnValidar.Enabled = false;

            bool resultado = await task; //MIENTRAS CARGA

            giftCarga.Enabled = false;
            giftCarga.Visible = false;

            btnSubirFactura.Enabled = true;
            btnGrabar.Enabled = true;
            btnValidar.Enabled = true;
        }

        public bool ValidarFactura()
        {
            Validar(1);
            MessageBox.Show("Se terminó la validación", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return true;
        }

        private void frmProcesoSubirFacturas_Load(object sender, EventArgs e)
        {
            giftCarga.Enabled = false;
            giftCarga.Visible = false;
        }
    }
}
