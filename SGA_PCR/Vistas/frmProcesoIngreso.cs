using AccesoDatos;
using DevComponents.DotNetBar.SuperGrid;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Apolo
{
    public partial class frmProcesoIngreso : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaIngresoTipo;
        DataTable tablaMonedaTipo;
        DataTable tablaProveedor;

        Ingreso ingreso;
        IngresoDA ingresoDA;

        Boolean permitir = true;

        private int idUsuario;
        private string nombreUsuario = "CEAS";
        //private string lap_mac=

        private string licenciaCategoriaSO = "S.O";
        private string licenciaCategoriaOffice = "OFFICE";
        private string licenciaCategoriaAntivirus = "ANTIVIRUS";

        public frmProcesoIngreso()
        {
            InitializeComponent();
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public frmProcesoIngreso(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }
        public void Inicializado()
        {

            ingresoDA = new IngresoDA();
            ingreso = new Ingreso();
            dtpFechaIngreso.Value = DateTime.Now;



            tablaProveedor = ingresoDA.ListarProveedores();
            cmbProveedor.DataSource = tablaProveedor;
            cmbProveedor.DisplayMember = "razonSocial";
            cmbProveedor.ValueMember = "idProveedor";
            cmbProveedor.SelectedIndex = 0;
            int i = cmbProveedor.SelectedIndex;

            if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                txtRUC.Text = tablaProveedor.Rows[i]["ruc"].ToString();
            }

            tablaIngresoTipo = ingresoDA.ListarIngresoTipo();
            cmbTipoIngreso.DataSource = tablaIngresoTipo;
            cmbTipoIngreso.DisplayMember = "descripcion";
            cmbTipoIngreso.ValueMember = "idAuxiliar";

            tablaMonedaTipo = ingresoDA.ListarMonedaTipo();
            cmbMonedaTipo.DataSource = tablaMonedaTipo;
            cmbMonedaTipo.DisplayMember = "descripcion";
            cmbMonedaTipo.ValueMember = "idAuxiliar";

            ingreso = new Ingreso();
            ingreso.Detalles = new BindingList<IngresoDetalle>();
            ObtenerDatosIngreso();
            dgvLaptopsSeleccionados.PrimaryGrid.DataSource = ingreso.Detalles;
            dgvLaptopsSeleccionados.PrimaryGrid.AutoGenerateColumns = false;
            dgvMemorias.PrimaryGrid.DataSource = ingreso.Memorias;
            dgvMemorias.PrimaryGrid.AutoGenerateColumns = false;
            dgvDisco.PrimaryGrid.DataSource = ingreso.Discos;
            dgvDisco.PrimaryGrid.AutoGenerateColumns = false;
            dgvLicencia.PrimaryGrid.DataSource = ingreso.Licencias;
            dgvLicencia.PrimaryGrid.AutoGenerateColumns = false;

        }

        public void ObtenerDatosIngreso()
        {
            Cursor.Current = Cursors.WaitCursor;
            ingreso.IdProveedor = Convert.ToInt32(cmbProveedor.SelectedValue.ToString());
            ingreso.IdTipoIngreso = Convert.ToInt32(cmbTipoIngreso.SelectedValue.ToString());
            ingreso.IdMonedaTipo = Convert.ToInt32(cmbMonedaTipo.SelectedValue.ToString());

            int i = cmbProveedor.SelectedIndex;
            if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                ingreso.Ruc = tablaProveedor.Rows[i]["ruc"].ToString();
                ingreso.RazonSocial = tablaProveedor.Rows[i]["razonSocial"].ToString();
            }

            i = cmbTipoIngreso.SelectedIndex;
            if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                ingreso.TipoIngreso = tablaIngresoTipo.Rows[i]["descripcion"].ToString();
            }

            i = cmbMonedaTipo.SelectedIndex;
            if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                ingreso.MonedaTipo = tablaMonedaTipo.Rows[i]["descripcion"].ToString();
            }

            ingreso.FechaIngreso = dtpFechaIngreso.Value;
            ingreso.Factura = txtFactura.Text;
            ingreso.Guia = txtGuia.Text;
            string aux = txtMontoCambio.Text;
            aux = aux.Trim();
            ingreso.MontoCambio = (aux.Length == 0) ? 0 : Double.Parse(aux);

            //Aqui se va a hacer la suma de todo el Total
            ingreso.Total = 0;
            foreach (IngresoDetalle d in ingreso.Detalles)
            {
                ingreso.Total += d.Precio * d.Cantidad;
            }
            foreach (Licencia d in ingreso.Licencias)
            {
                ingreso.Total += d.Precio * d.Cantidad;
            }
            foreach (DiscoDuro d in ingreso.Discos)
            {
                ingreso.Total += d.Precio * d.Cantidad;
            }
            foreach (Memoria d in ingreso.Memorias)
            {
                ingreso.Total += d.Precio * d.Cantidad;
            }



        }

        public bool ValidarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (ingreso.MonedaTipo == "DOLARES" && ingreso.MontoCambio == 0)
            {
                MessageBox.Show("No se puede grabar un Ingreso si no\nespecifica cuanto es el tipo de cambio.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                return true;
            }

            if (ingreso.Detalles.Count == 0 && ingreso.Discos.Count == 0 && ingreso.Memorias.Count == 0 && ingreso.Licencias.Count == 0)
            {
                MessageBox.Show("No se puede grabar un Ingreso si no\nexisten laptops, memorias, disco o licencias seleccionadas.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                return true;
            }

            if (ingreso.Factura.Length == 0)
            {
                MessageBox.Show("No se puede grabar un Ingreso si\nel número de factura está vacia.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                return true;
            }

            for (int i = 0; i < ingreso.Discos.Count; i++)
            {
                if (ingreso.Discos[i].Precio == 0.00)
                {
                    MessageBox.Show("No se puede grabar un Ingreso si uno de los precios de los Discos es 0", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    return true;
                }
            }


            for (int i = 0; i < ingreso.Memorias.Count; i++)
            {
                if (ingreso.Memorias[i].Precio == 0.00)
                {
                    MessageBox.Show("No se puede grabar un Ingreso si uno de los precios de las Memorias es 0", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    return true;
                }
            }


            for (int i = 0; i < ingreso.Licencias.Count; i++)
            {
                if (ingreso.Licencias[i].Precio == 0.00)
                {
                    MessageBox.Show("No se puede grabar un Ingreso si uno de los precios de las Licencias es 0", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    return true;
                }
                if (ingreso.Licencias[i].Clave.Length == 0)
                {
                    MessageBox.Show("No se puede grabar un Ingreso si una de las claves de las Licencias está vacía.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    return true;
                }
            }


            return false;

        }

        public void estadoComponentes(TipoVista estado)
        {
            switch (estado)
            {
                case TipoVista.Inicial:
                    cmbProveedor.Enabled = false;
                    cmbTipoIngreso.Enabled = false;
                    cmbMonedaTipo.Enabled = false;
                    txtMontoCambio.Enabled = false;
                    txtFactura.Enabled = false;
                    txtGuia.Enabled = false;
                    dtpFechaIngreso.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    dgvDisco.Enabled = false;
                    dgvMemorias.Enabled = false;
                    dgvLicencia.Enabled = false;
                    btnAgregarDisco.Enabled = false;
                    btnAgregarMemoria.Enabled = false;
                    btnAgregarLicencia.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnVisualizar.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnBuscar.Enabled = true;
                    btnAnular.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnEditar.Enabled = false;
                    btnGrabar.Enabled = false;
                    limpiarComponentes();
                    ingreso = new Ingreso();
                    break;
                case TipoVista.Nuevo:
                    cmbProveedor.Enabled = true;
                    cmbTipoIngreso.Enabled = true;
                    cmbMonedaTipo.Enabled = true;
                    txtMontoCambio.Enabled = true;
                    txtFactura.Enabled = true;
                    txtGuia.Enabled = true;
                    dtpFechaIngreso.Enabled = true;
                    dgvLaptopsSeleccionados.Enabled = true;
                    dgvDisco.Enabled = true;
                    dgvMemorias.Enabled = true;
                    dgvLicencia.Enabled = true;
                    btnAgregarDisco.Enabled = true;
                    btnAgregarMemoria.Enabled = true;
                    btnAgregarLicencia.Enabled = true;
                    btnAgregarProducto.Enabled = true;
                    btnVisualizar.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnAnular.Enabled = false;
                    btnBuscar.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnEditar.Enabled = false;
                    btnGrabar.Enabled = true;
                    limpiarComponentes();
                    ingreso = new Ingreso();
                    break;
                case TipoVista.Guardar:
                    cmbProveedor.Enabled = false;
                    cmbTipoIngreso.Enabled = false;
                    cmbMonedaTipo.Enabled = false;
                    txtMontoCambio.Enabled = false;
                    txtFactura.Enabled = false;
                    txtGuia.Enabled = false;
                    dtpFechaIngreso.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    dgvDisco.Enabled = false;
                    dgvMemorias.Enabled = false;
                    dgvLicencia.Enabled = false;
                    btnAgregarDisco.Enabled = false;
                    btnAgregarMemoria.Enabled = false;
                    btnAgregarLicencia.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnVisualizar.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnAnular.Enabled = true;
                    btnBuscar.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnEditar.Enabled = true;
                    btnGrabar.Enabled = false;
                    break;
                case TipoVista.Modificar:
                    cmbProveedor.Enabled = true;
                    cmbTipoIngreso.Enabled = true;
                    cmbMonedaTipo.Enabled = true;
                    txtMontoCambio.Enabled = true;
                    txtFactura.Enabled = true;
                    txtGuia.Enabled = true;
                    dtpFechaIngreso.Enabled = true;
                    dgvLaptopsSeleccionados.Enabled = true;
                    dgvDisco.Enabled = true;
                    dgvMemorias.Enabled = true;
                    dgvLicencia.Enabled = true;
                    btnAgregarDisco.Enabled = true;
                    btnAgregarMemoria.Enabled = true;
                    btnAgregarLicencia.Enabled = true;
                    btnAgregarProducto.Enabled = true;
                    btnVisualizar.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnAnular.Enabled = false;
                    btnBuscar.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnEditar.Enabled = false;
                    btnGrabar.Enabled = true;
                    break;
                case TipoVista.Vista:
                    cmbProveedor.Enabled = false;
                    cmbTipoIngreso.Enabled = false;
                    cmbMonedaTipo.Enabled = false;
                    txtMontoCambio.Enabled = false;
                    txtFactura.Enabled = false;
                    txtGuia.Enabled = false;
                    dtpFechaIngreso.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    dgvDisco.Enabled = false;
                    dgvMemorias.Enabled = false;
                    dgvLicencia.Enabled = false;
                    btnAgregarDisco.Enabled = false;
                    btnAgregarMemoria.Enabled = false;
                    btnAgregarLicencia.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnVisualizar.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnAnular.Enabled = true;
                    btnBuscar.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnEditar.Enabled = true;
                    btnGrabar.Enabled = false;
                    //limpiarComponentes();
                    ingreso = new Ingreso();
                    break;
                case TipoVista.Limpiar:
                    cmbProveedor.Enabled = false;
                    cmbTipoIngreso.Enabled = false;
                    cmbMonedaTipo.Enabled = false;
                    txtMontoCambio.Enabled = false;
                    txtFactura.Enabled = false;
                    txtGuia.Enabled = false;
                    dtpFechaIngreso.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    dgvDisco.Enabled = false;
                    dgvMemorias.Enabled = false;
                    dgvLicencia.Enabled = false;
                    btnAgregarDisco.Enabled = false;
                    btnAgregarMemoria.Enabled = false;
                    btnAgregarLicencia.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnVisualizar.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnAnular.Enabled = false;
                    btnBuscar.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnEditar.Enabled = false;
                    btnGrabar.Enabled = false;
                    limpiarComponentes();
                    ingreso = new Ingreso();
                    break;
                case TipoVista.Duplicar:
                    cmbProveedor.Enabled = false;
                    cmbTipoIngreso.Enabled = false;
                    cmbMonedaTipo.Enabled = false;
                    txtMontoCambio.Enabled = false;
                    txtFactura.Enabled = false;
                    txtGuia.Enabled = false;
                    dtpFechaIngreso.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    dgvDisco.Enabled = false;
                    dgvMemorias.Enabled = false;
                    dgvLicencia.Enabled = false;
                    btnAgregarDisco.Enabled = false;
                    btnAgregarMemoria.Enabled = false;
                    btnAgregarLicencia.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnVisualizar.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnEditar.Enabled = true;
                    btnGrabar.Enabled = false;
                    limpiarComponentes();
                    ingreso = new Ingreso();
                    break;
                case TipoVista.Anular:
                    cmbProveedor.Enabled = false;
                    cmbTipoIngreso.Enabled = false;
                    cmbMonedaTipo.Enabled = false;
                    txtMontoCambio.Enabled = false;
                    txtFactura.Enabled = false;
                    txtGuia.Enabled = false;
                    dtpFechaIngreso.Enabled = false;
                    dgvLaptopsSeleccionados.Enabled = false;
                    dgvDisco.Enabled = false;
                    dgvMemorias.Enabled = false;
                    dgvLicencia.Enabled = false;
                    btnAgregarDisco.Enabled = false;
                    btnAgregarMemoria.Enabled = false;
                    btnAgregarLicencia.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    btnVisualizar.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnBuscar.Enabled = true;
                    btnAnular.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnEditar.Enabled = false;
                    btnGrabar.Enabled = false;
                    break;
            }
        }


        public void limpiarComponentes()
        {
            cmbTipoIngreso.SelectedIndex = -1;
            cmbProveedor.SelectedIndex = -1;
            cmbMonedaTipo.SelectedIndex = -1;

            txtNroIngreso.Text = "";
            txtRUC.Text = "";
            txtGuia.Text = "";
            txtFactura.Text = "";
            txtMontoCambio.Text = "";
            dtpFechaIngreso.Value = DateTime.Now;
            dgvDisco.PrimaryGrid.DataSource = null;
            dgvMemorias.PrimaryGrid.DataSource = null;
            dgvLicencia.PrimaryGrid.DataSource = null;
            dgvLaptopsSeleccionados.PrimaryGrid.DataSource = null;
        }


        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cmbTipoIngreso.SelectedIndex != -1)
            {
                //! 0 -> COMPRA
                //! 1 -> SUBARRIENDO
                string tipo = cmbTipoIngreso.SelectedIndex.ToString();

                try
                {
                    IngresoDetalle detalle = new IngresoDetalle();
                    using (frmProcesoIngresoLaptopCpu frm = new frmProcesoIngresoLaptopCpu(tipo))
                    {
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            BindingList<IngresoDetalle> auxiliares = new BindingList<IngresoDetalle>();
                            foreach (IngresoDetalle aux in ingreso.Detalles)
                            {
                                auxiliares.Add(aux);
                            }
                            detalle = frm.DETALLE;
                            detalle.IdIngresoDetalle = ingreso.Detalles.Count + 1;
                            auxiliares.Add(detalle);
                            ingreso.Detalles = auxiliares;
                            //ingreso.Detalles.Add(detalle);
                            dgvLaptopsSeleccionados.PrimaryGrid.DataSource = ingreso.Detalles;
                        }
                    }
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("Seleccione el tipo de ingreso");
            }

        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbProveedor.SelectedIndex;
            if (i >= 0)
            {
                ingreso.Ruc = tablaProveedor.Rows[i]["ruc"].ToString();
                txtRUC.Text = tablaProveedor.Rows[i]["ruc"].ToString();
                ingreso.RazonSocial = tablaProveedor.Rows[i]["razonSocial"].ToString();
            }
        }

        private void btnAgregarMemoria_Click(object sender, EventArgs e)
        {
            using (frmProcesoIngresoMemoria frm = new frmProcesoIngresoMemoria())
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindingList<Memoria> auxiliares = new BindingList<Memoria>();
                    foreach (Memoria aux in ingreso.Memorias)
                    {
                        auxiliares.Add(aux);
                    }
                    foreach (Memoria memoriaTraido in frm.MEMORIAS)
                    {
                        Memoria memTemp = new Memoria();
                        memTemp.IdMemoria = memoriaTraido.IdMemoria;
                        bool exists = auxiliares.Any(x => x.IdMemoria.Equals(memTemp.IdMemoria));
                        if (!(exists))
                        {
                            memTemp.TipoMemoria = memoriaTraido.TipoMemoria;
                            memTemp.Tipo = memoriaTraido.Tipo;
                            memTemp.Capacidad = memoriaTraido.Capacidad;
                            memTemp.Cantidad = 1;
                            memTemp.Precio = 0.00;
                            auxiliares.Add(memTemp);
                        }
                    }
                    ingreso.Memorias = auxiliares;
                    dgvMemorias.PrimaryGrid.DataSource = ingreso.Memorias;
                }
            }

        }

        private void dgvMemorias_DoubleClick(object sender, EventArgs e)
        {

            if (MessageBox.Show("Estas seguro deseas Eliminar esta memoria", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (dgvMemorias.PrimaryGrid.Rows.Count > 0)
                {
                    BindingList<Memoria> memorias = new BindingList<Memoria>();
                    for (int i = 0; i < dgvMemorias.PrimaryGrid.Rows.Count; i++)
                    {
                        Memoria memoria = new Memoria();
                        int memoriaID = int.Parse(((GridCell)(((GridRow)dgvMemorias.PrimaryGrid.ActiveRow)[3])).Value.ToString());
                        memoria.IdMemoria = int.Parse(((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 3))).Value.ToString());
                        if (memoriaID != memoria.IdMemoria)
                        {
                            memoria.TipoMemoria = ((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 0))).Value.ToString();
                            memoria.Tipo = ((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 4))).Value.ToString();
                            memoria.Capacidad = int.Parse(((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 1))).Value.ToString());
                            memoria.Cantidad = int.Parse(((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 2))).Value.ToString());
                            memoria.Precio = Double.Parse(((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 5))).Value.ToString());
                            memorias.Add(memoria);
                        }
                    }
                    ingreso.Memorias = memorias;
                    dgvMemorias.PrimaryGrid.DataSource = ingreso.Memorias;
                }
            }
        }

        private void btnAgregarDisco_Click(object sender, EventArgs e)
        {
            using (frmProcesoIngresoDisco frm = new frmProcesoIngresoDisco())
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindingList<DiscoDuro> auxiliares = new BindingList<DiscoDuro>();
                    foreach (DiscoDuro aux in ingreso.Discos)
                    {
                        auxiliares.Add(aux);
                    }

                    foreach (DiscoDuro discoTraido in frm.DISCOS)
                    {
                        DiscoDuro disTemp = new DiscoDuro();
                        disTemp.IdDisco = discoTraido.IdDisco;
                        bool exists = auxiliares.Any(x => x.IdDisco.Equals(disTemp.IdDisco));
                        if (!(exists))
                        {
                            disTemp.TipoDisco = discoTraido.TipoDisco;
                            disTemp.Capacidad = discoTraido.Capacidad;
                            disTemp.Tamano = discoTraido.Tamano;
                            disTemp.Cantidad = 1;
                            disTemp.Precio = 0.00;
                            auxiliares.Add(disTemp);
                        }
                    }
                    ingreso.Discos = auxiliares;
                    dgvDisco.PrimaryGrid.DataSource = ingreso.Discos;
                }
            }

        }

        private void dgvDisco_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro deseas Eliminar este disco", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (dgvDisco.PrimaryGrid.Rows.Count > 0)
                {
                    BindingList<DiscoDuro> discos = new BindingList<DiscoDuro>();
                    for (int i = 0; i < dgvDisco.PrimaryGrid.Rows.Count; i++)
                    {
                        DiscoDuro disco = new DiscoDuro();
                        int discoID = int.Parse(((GridCell)(((GridRow)dgvDisco.PrimaryGrid.ActiveRow)[3])).Value.ToString());
                        disco.IdDisco = int.Parse(((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 3))).Value.ToString());
                        if (discoID != disco.IdDisco)
                        {
                            disco.TipoDisco = ((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 0))).Value.ToString();
                            disco.Tamano = ((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 4))).Value.ToString();
                            disco.Capacidad = int.Parse(((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 1))).Value.ToString());
                            disco.Cantidad = int.Parse(((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 2))).Value.ToString());
                            disco.Precio = Double.Parse(((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 5))).Value.ToString());
                            discos.Add(disco);
                        }
                    }
                    ingreso.Discos = discos;
                    dgvDisco.PrimaryGrid.DataSource = ingreso.Discos;
                }
            }
        }

        private void btnAgregarLicencia_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmProcesoIngresoLicencia frm = new frmProcesoIngresoLicencia())
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BindingList<Licencia> auxiliares = new BindingList<Licencia>();
                        foreach (Licencia aux in ingreso.Licencias)
                        {
                            auxiliares.Add(aux);
                        }

                        foreach (Licencia licenciaTraido in frm.LICENCIAS)
                        {
                            Licencia licTemp = new Licencia();
                            licTemp.IdModelo = licenciaTraido.IdModelo;
                            //bool exists = ingreso.Licencias.Any(x => x.IdModelo.Equals(licTemp.IdModelo));
                            bool exists = false;
                            if (!(exists))
                            {

                                licTemp.IdLicencia = ingreso.Licencias.Count + 1;
                                licTemp.Categoria = licenciaTraido.Categoria;
                                licTemp.IdModelo = licenciaTraido.IdModelo;
                                licTemp.Marca = licenciaTraido.Marca;
                                licTemp.Version = licenciaTraido.Version;
                                licTemp.Clave = licenciaTraido.Clave;
                                licTemp.Cantidad = licenciaTraido.Cantidad;
                                licTemp.Precio = 0.00;

                                auxiliares.Add(licTemp);
                            }
                        }
                        ingreso.Licencias = auxiliares;
                        dgvLicencia.PrimaryGrid.DataSource = ingreso.Licencias;
                    }
                }
            }
            catch
            {

            }

        }

        private void dgvLicencia_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Estas seguro deseas Eliminar esta licencia", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int detTempId;
                    if (dgvLicencia.PrimaryGrid.Rows.Count > 0)
                    {
                        detTempId = int.Parse(((GridCell)(((GridRow)dgvLicencia.PrimaryGrid.ActiveRow)[7])).Value.ToString());

                        int indiceLC = 0;
                        foreach (Licencia licencia in ingreso.Licencias)
                        {
                            if (licencia.IdLicencia == detTempId)
                            {
                                break;
                            }
                            indiceLC++;
                        }
                        ingreso.Licencias.RemoveAt(indiceLC);

                        for (int i = 0; i < ingreso.Licencias.Count; i++)
                        {
                            ingreso.Licencias[i].IdLicencia = i + 1;
                        }

                        dgvLicencia.PrimaryGrid.DataSource = ingreso.Licencias;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Entro al try cath1");
            }

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas cancelar el proceso", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                estadoComponentes(TipoVista.Limpiar);
                ingreso = new Ingreso();
                dgvDisco.PrimaryGrid.DataSource = null;
                dgvMemorias.PrimaryGrid.DataSource = null;
                dgvLicencia.PrimaryGrid.DataSource = null;
                dgvLaptopsSeleccionados.PrimaryGrid.DataSource = null;
            }
        }

        public void LlenarDatosIngreso()
        {
            cmbProveedor.SelectedValue = ingreso.IdProveedor;
            cmbTipoIngreso.SelectedValue = ingreso.IdTipoIngreso;
            cmbMonedaTipo.SelectedValue = ingreso.IdMonedaTipo;
            txtRUC.Text = ingreso.Ruc;
            dtpFechaIngreso.Value = ingreso.FechaIngreso;
            txtFactura.Text = ingreso.Factura;
            txtGuia.Text = ingreso.Guia;
            txtNroIngreso.Text = ingreso.IdIngreso.ToString();
            txtMontoCambio.Text = (ingreso.MontoCambio == 0) ? "" : ingreso.MontoCambio.ToString();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Vista);
            frmProcesoIngresoBuscar frmBP = new frmProcesoIngresoBuscar(this.idUsuario);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
                ingreso = frmBP.ObjSeleccionado;
                txtNroIngreso.Text = ingreso.IdIngreso.ToString();
                LlenarDatosIngreso();
                dgvLaptopsSeleccionados.PrimaryGrid.DataSource = ingreso.Detalles;
                dgvLicencia.PrimaryGrid.DataSource = ingreso.Licencias;
                dgvDisco.PrimaryGrid.DataSource = ingreso.Discos;
                dgvMemorias.PrimaryGrid.DataSource = ingreso.Memorias;
            }
            else
            {
                estadoComponentes(TipoVista.Inicial);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Nuevo);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (ingreso.Estado == 7 || ingreso.Estado == 0)//en teoría 7 debería ser finalizado
            {
                MessageBox.Show("Este ingreso ya no se puede modificar", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBox.Show("Estas seguro que desea Modificar\n" + "el Ingreso N° :" + txtNroIngreso.Text, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {

                    estadoComponentes(TipoVista.Modificar);

                }

            }
        }

        private void dgvLaptopsSeleccionados_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro deseas Eliminar esta detalle de Ingreso", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                int detTempId;
                if (dgvLaptopsSeleccionados.PrimaryGrid.Rows.Count > 0)
                {
                    detTempId = int.Parse(((GridCell)(((GridRow)dgvLaptopsSeleccionados.PrimaryGrid.ActiveRow)[6])).Value.ToString());

                    int indiceLC = 0;
                    foreach (IngresoDetalle detalle in ingreso.Detalles)
                    {
                        if (detalle.IdIngresoDetalle == detTempId)
                        {
                            break;
                        }
                        indiceLC++;
                    }

                    ingreso.Detalles.RemoveAt(indiceLC);
                    for (int i = 0; i < ingreso.Detalles.Count; i++)
                    {
                        ingreso.Detalles[i].IdIngresoDetalle = i + 1;
                    }

                    dgvLaptopsSeleccionados.PrimaryGrid.DataSource = ingreso.Detalles;
                }
            }

        }

        private void btnAnular_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            if (ingreso.Estado == 0)
            {
                MessageBox.Show("Este ingreso ya se encuentra en estado Anulado", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (ingreso.Estado == 8 || ingreso.Estado == 9)//los estados de aqui todavía están por definir
            {
                MessageBox.Show("Este ingreso no se puede anular", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBox.Show("Estas seguro que desea Anular este ingreso", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ingreso.Estado = 0;
                    int error = ingresoDA.AnularIngreso(ingreso, this.nombreUsuario);
                    if (error == 0)
                    {
                        MessageBox.Show("Se anulo el Ingreso N° :" + ingreso.IdIngreso, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Este ingreso no se puede anular. Contactese con el área de soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    estadoComponentes(TipoVista.Anular);
                }
            }
            Cursor.Current = Cursors.Default;
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea Imprimir el Ingreso", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {

                    SaveFileDialog fichero = new SaveFileDialog();
                    //fichero.Filter = "Excel (*.xls)|*.xls";
                    fichero.Filter = "Excel(*.xlsx) | *.xlsx";
                    fichero.FileName = "Ingreso_" + ingreso.IdIngreso.ToString();
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        Excel.Application aplicacion;
                        Excel.Workbook libros_trabajo;
                        Excel.Worksheet hoja_ingreso;

                        aplicacion = new Excel.Application();
                        libros_trabajo = (Excel.Workbook)aplicacion.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

                        hoja_ingreso = (Excel.Worksheet)libros_trabajo.Worksheets.Add();
                        hoja_ingreso.Name = "Ingreso";
                        string cabecera = "Reporte de Ingreso";
                        ExportarDataGridViewExcel(ref hoja_ingreso, dgvLaptopsSeleccionados, cabecera);


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

            Cursor.Current = Cursors.WaitCursor;
            Excel.Range rango;
            int i = 0;

            int inicio = 10;
            int filaDetalle = inicio;
            int filaMemoria = inicio + ingreso.Detalles.Count + 4;
            int filaDisco = inicio + ingreso.Detalles.Count + 4 + ingreso.Memorias.Count + 4;
            int filaLicencia = inicio + ingreso.Detalles.Count + 4 + ingreso.Memorias.Count + 4 + ingreso.Discos.Count + 4;

            if (ingreso.Detalles.Count > 0)
            {
                if (ingreso.Memorias.Count > 0)
                {
                    if (ingreso.Discos.Count > 0)
                    {
                        filaDetalle = inicio;
                        filaMemoria = inicio + ingreso.Detalles.Count + 4;
                        filaDisco = inicio + ingreso.Detalles.Count + 4 + ingreso.Memorias.Count + 4;
                        filaLicencia = inicio + ingreso.Detalles.Count + 4 + ingreso.Memorias.Count + 4 + ingreso.Discos.Count + 4;
                    }
                    else
                    {
                        filaDetalle = inicio;
                        filaMemoria = inicio + ingreso.Detalles.Count + 4;
                        filaLicencia = inicio + ingreso.Detalles.Count + 4 + ingreso.Memorias.Count + 4;
                    }
                }
                else
                {
                    if (ingreso.Discos.Count > 0)
                    {
                        filaDetalle = inicio;
                        filaDisco = inicio + ingreso.Detalles.Count + 4;
                        filaLicencia = inicio + ingreso.Detalles.Count + 4 + ingreso.Discos.Count + 4;
                    }
                    else
                    {
                        filaDetalle = inicio;
                        filaLicencia = inicio + ingreso.Detalles.Count + 4;
                    }

                }
            }
            else
            {
                if (ingreso.Memorias.Count > 0)
                {
                    if (ingreso.Discos.Count > 0)
                    {
                        filaMemoria = inicio;
                        filaDisco = inicio + ingreso.Memorias.Count + 4;
                        filaLicencia = inicio + ingreso.Memorias.Count + 4 + ingreso.Discos.Count + 4;
                    }
                    else
                    {
                        filaMemoria = inicio;
                        filaLicencia = inicio + ingreso.Memorias.Count + 4;
                    }
                }
                else
                {
                    if (ingreso.Discos.Count > 0)
                    {
                        filaDisco = inicio;
                        filaLicencia = inicio + ingreso.Discos.Count + 4;
                    }
                    else
                    {
                        filaLicencia = inicio;
                    }

                }
            }

            //Recorremos el DataGridView rellenando la hoja de trabajo
            foreach (IngresoDetalle det in ingreso.Detalles)
            {
                //int k = grd.Columns.Count + 64;
                int k = 15 + 64;
                char columF = (char)k;
                int fila2 = i + filaDetalle;
                string filaBorde = fila2.ToString();
                char columI = 'A';
                //Ponemos borde a las celdas
                rango = hoja_trabajo.Range[columI + fila2.ToString(), columF + fila2.ToString()];
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rango.Style.Font.Bold = false;

                hoja_trabajo.Cells[i + filaDetalle, 1] = det.LaptopMarcaLC;
                hoja_trabajo.Cells[i + filaDetalle, 2] = det.LaptopNombreModeloLC;
                hoja_trabajo.Cells[i + filaDetalle, 3] = det.Laptop.PartNumber;
                hoja_trabajo.Cells[i + filaDetalle, 4] = det.LaptopTamanoPantalla.ToString();
                hoja_trabajo.Cells[i + filaDetalle, 5] = (det.Laptop.Garantia == 1) ? "Si" : "No";
                hoja_trabajo.Cells[i + filaDetalle, 6] = det.Precio.ToString();
                hoja_trabajo.Cells[i + filaDetalle, 7] = det.Cantidad.ToString();
                string aux = "";
                aux = det.Laptop.Procesador.Modelo.NombreModelo + "/GEN" + det.Laptop.Procesador.Generacion.ToString();
                hoja_trabajo.Cells[i + filaDetalle, 8] = aux;
                hoja_trabajo.Cells[i + filaDetalle, 9] = det.Laptop.Video.Capacidad.ToString() + " GB";

                string tipoDisco1 = ""; int capDisco1 = 0; string tipoDisco2 = ""; int capDisco2 = 0;
                if (det.Laptop.Discos.Count > 0)
                {
                    if (det.Laptop.Discos.Count == 1)
                    {
                        tipoDisco1 = det.Laptop.Discos[0].TipoDisco;
                        capDisco1 = det.Laptop.Discos[0].Cantidad * det.Laptop.Discos[0].Capacidad;
                    }
                    else if (det.Laptop.Discos.Count >= 2)
                    {
                        tipoDisco1 = det.Laptop.Discos[0].TipoDisco;
                        capDisco1 = det.Laptop.Discos[0].Cantidad * det.Laptop.Discos[0].Capacidad;

                        tipoDisco2 = det.Laptop.Discos[1].TipoDisco;
                        capDisco2 = det.Laptop.Discos[1].Cantidad * det.Laptop.Discos[1].Capacidad;
                    }
                }

                hoja_trabajo.Cells[i + filaDetalle, 10] = (tipoDisco1.Length > 0) ? tipoDisco1 + " - " + capDisco1.ToString() + " GB" : "";
                hoja_trabajo.Cells[i + filaDetalle, 11] = (tipoDisco2.Length > 0) ? tipoDisco2 + " - " + capDisco2.ToString() + " GB" : "";

                int capacidadMem = 0;
                foreach (Memoria mem in det.Laptop.Memorias)
                {
                    capacidadMem += mem.Capacidad * mem.Cantidad;
                }
                hoja_trabajo.Cells[i + filaDetalle, 12] = capacidadMem.ToString() + " GB";

                Licencia windows = null; Licencia office = null; Licencia antivirus = null;

                if (det.Laptop.Licencias.Count > 0)
                {
                    windows = det.Laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaSO);
                    office = det.Laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaOffice);
                    antivirus = det.Laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaAntivirus);

                }

                hoja_trabajo.Cells[i + filaDetalle, 13] = (windows != null) ? windows.Version : "";
                hoja_trabajo.Cells[i + filaDetalle, 14] = (office != null) ? office.Version : "";
                hoja_trabajo.Cells[i + filaDetalle, 15] = (antivirus != null) ? antivirus.Version : "";


                i++;
            }


            i = 0;
            foreach (Memoria det in ingreso.Memorias)
            {
                //int k = grd.Columns.Count + 64;
                int k = 5 + 64;
                char columF = (char)k;
                int fila2 = i + filaMemoria;
                string filaBorde = fila2.ToString();
                char columI = 'A';
                //Ponemos borde a las celdas
                rango = hoja_trabajo.Range[columI + fila2.ToString(), columF + fila2.ToString()];
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rango.Style.Font.Bold = false;

                hoja_trabajo.Cells[i + filaMemoria, 1] = det.TipoMemoria;
                hoja_trabajo.Cells[i + filaMemoria, 2] = det.Tipo;
                hoja_trabajo.Cells[i + filaMemoria, 3] = det.Capacidad;
                hoja_trabajo.Cells[i + filaMemoria, 4] = det.Cantidad;
                hoja_trabajo.Cells[i + filaMemoria, 5] = det.Precio.ToString();

                i++;
            }

            i = 0;
            foreach (DiscoDuro det in ingreso.Discos)
            {
                //int k = grd.Columns.Count + 64;
                int k = 5 + 64;
                char columF = (char)k;
                int fila2 = i + filaDisco;
                string filaBorde = fila2.ToString();
                char columI = 'A';
                //Ponemos borde a las celdas
                rango = hoja_trabajo.Range[columI + fila2.ToString(), columF + fila2.ToString()];
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rango.Style.Font.Bold = false;

                hoja_trabajo.Cells[i + filaDisco, 1] = det.TipoDisco;
                hoja_trabajo.Cells[i + filaDisco, 2] = det.Tamano;
                hoja_trabajo.Cells[i + filaDisco, 3] = det.Capacidad;
                hoja_trabajo.Cells[i + filaDisco, 4] = det.Cantidad;
                hoja_trabajo.Cells[i + filaDisco, 5] = det.Precio.ToString();

                i++;
            }

            i = 0;
            foreach (Licencia det in ingreso.Licencias)
            {
                //int k = grd.Columns.Count + 64;
                int k = 6 + 64;
                char columF = (char)k;
                int fila2 = i + filaLicencia;
                string filaBorde = fila2.ToString();
                char columI = 'A';
                //Ponemos borde a las celdas
                rango = hoja_trabajo.Range[columI + fila2.ToString(), columF + fila2.ToString()];
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rango.Style.Font.Bold = false;

                hoja_trabajo.Cells[i + filaLicencia, 1] = det.Categoria;
                hoja_trabajo.Cells[i + filaLicencia, 2] = det.Marca;
                hoja_trabajo.Cells[i + filaLicencia, 3] = det.Version;
                hoja_trabajo.Cells[i + filaLicencia, 4] = det.Clave;
                hoja_trabajo.Cells[i + filaLicencia, 5] = det.Cantidad;
                hoja_trabajo.Cells[i + filaLicencia, 6] = det.Precio.ToString();

                i++;
            }


            montaCabeceras(1, ref hoja_trabajo, grd, nombreCabecera, filaDetalle, filaMemoria, filaDisco, filaLicencia);
        }

        private void montaCabeceras(int fila, ref Excel.Worksheet hoja, SuperGridControl grd, string nombreCabecera,
                                    int filaDetalle, int filaMemoria, int filaDisco, int filaLicencia)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Excel.Range rango;

                //** Montamos el título en la línea 1 **
                hoja.Cells[fila, 1] = nombreCabecera;
                hoja.Range[hoja.Cells[fila, 1], hoja.Cells[fila, 15]].Merge();
                hoja.Range[hoja.Cells[fila, 1], hoja.Cells[fila, 15]].Interior.Color = Color.Silver;
                hoja.Range[hoja.Cells[fila, 1], hoja.Cells[fila, 15]].Style.Font.Bold = true;
                //Centramos los textos
                rango = hoja.Rows[fila];
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //worksheet.Range[worksheet.Cells[rowNum, columnNum], worksheet.Cells[rowNum, columnNum]].Merge();
                int indice;

                hoja.Cells[fila + 1, 1] = "Ingreso N°";
                hoja.Cells[fila + 1, 2] = txtNroIngreso.Text;

                hoja.Cells[fila + 2, 1] = "Proveedor";
                hoja.Cells[fila + 2, 2] = ingreso.RazonSocial;
                hoja.Cells[fila + 3, 1] = "RUC";
                hoja.Cells[fila + 3, 2] = ingreso.Ruc;
                hoja.Cells[fila + 4, 1] = "Tipo Ingreso";
                hoja.Cells[fila + 4, 2] = ingreso.TipoIngreso;

                hoja.Cells[fila + 2, 5] = "Tipo Moneda";
                hoja.Cells[fila + 2, 6] = ingreso.MonedaTipo;
                hoja.Cells[fila + 3, 5] = "Monto Cambio";
                hoja.Cells[fila + 3, 6] = (ingreso.MontoCambio == 0) ? "" : ingreso.MontoCambio.ToString();
                hoja.Cells[fila + 4, 5] = "Monto Total";
                hoja.Cells[fila + 4, 6] = ingreso.Total.ToString();

                hoja.Cells[fila + 2, 8] = "Fecha Ingreso";
                hoja.Cells[fila + 2, 9] = ingreso.FechaIngreso.ToString("yyyy/MM/dd");
                hoja.Cells[fila + 3, 8] = "N° Factura";
                hoja.Cells[fila + 3, 9] = txtFactura.Text;
                hoja.Cells[fila + 4, 8] = "N° Guia";
                hoja.Cells[fila + 4, 9] = txtGuia.Text;


                if (ingreso.Detalles.Count > 0)
                {
                    hoja.Cells[filaDetalle - 2, 1] = "Laptops";
                    hoja.Cells[filaDetalle - 1, 1] = "Marca";
                    hoja.Cells[filaDetalle - 1, 2] = "Modelo";
                    hoja.Cells[filaDetalle - 1, 3] = "Part Number";
                    hoja.Cells[filaDetalle - 1, 4] = "Pantalla";
                    hoja.Cells[filaDetalle - 1, 5] = "Garantía";
                    hoja.Cells[filaDetalle - 1, 6] = "Precio";
                    hoja.Cells[filaDetalle - 1, 7] = "Cantidad";
                    hoja.Cells[filaDetalle - 1, 8] = "Procesador";
                    hoja.Cells[filaDetalle - 1, 9] = "Video";
                    hoja.Cells[filaDetalle - 1, 10] = "Disco 1";
                    hoja.Cells[filaDetalle - 1, 11] = "Disco 2";
                    hoja.Cells[filaDetalle - 1, 12] = "Memoria";
                    hoja.Cells[filaDetalle - 1, 13] = "S.O";
                    hoja.Cells[filaDetalle - 1, 14] = "Office";
                    hoja.Cells[filaDetalle - 1, 15] = "Antivirus";

                    //int i = grd.Columns.Count + 64;
                    int i = 15 + 64;
                    char columF = (char)i;
                    int fila2 = filaDetalle - 1;
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
                    for (int j = 0; j < 15; j++)
                    {
                        rango = hoja.Columns[j + 1];
                        rango.ColumnWidth = 13;
                    }
                }
                if (ingreso.Memorias.Count > 0)
                {
                    hoja.Cells[filaMemoria - 2, 1] = "Memorias";
                    hoja.Cells[filaMemoria - 1, 1] = "Modelo";
                    hoja.Cells[filaMemoria - 1, 2] = "Tipo";
                    hoja.Cells[filaMemoria - 1, 3] = "Capacidad";
                    hoja.Cells[filaMemoria - 1, 4] = "Cantidad";
                    hoja.Cells[filaMemoria - 1, 5] = "Precio";

                    //int i = grd.Columns.Count + 64;
                    int i = 5 + 64;
                    char columF = (char)i;
                    int fila2 = filaMemoria - 1;
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

                    for (int j = 0; j < 5; j++)
                    {
                        rango = hoja.Columns[j + 1];
                        rango.ColumnWidth = 13;
                    }
                }

                if (ingreso.Discos.Count > 0)
                {
                    hoja.Cells[filaDisco - 2, 1] = "Discos";
                    hoja.Cells[filaDisco - 1, 1] = "Tipo";
                    hoja.Cells[filaDisco - 1, 2] = "Tamaño";
                    hoja.Cells[filaDisco - 1, 3] = "Capacidad";
                    hoja.Cells[filaDisco - 1, 4] = "Cantidad";
                    hoja.Cells[filaDisco - 1, 5] = "Precio";

                    //int i = grd.Columns.Count + 64;
                    int i = 5 + 64;
                    char columF = (char)i;
                    int fila2 = filaDisco - 1;
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

                    for (int j = 0; j < 5; j++)
                    {
                        rango = hoja.Columns[j + 1];
                        rango.ColumnWidth = 13;
                    }
                }

                if (ingreso.Licencias.Count > 0)
                {
                    hoja.Cells[filaLicencia - 2, 1] = "Licencias";
                    hoja.Cells[filaLicencia - 1, 1] = "Categoria";
                    hoja.Cells[filaLicencia - 1, 2] = "Marca";
                    hoja.Cells[filaLicencia - 1, 3] = "Version";
                    hoja.Cells[filaLicencia - 1, 4] = "Clave";
                    hoja.Cells[filaLicencia - 1, 5] = "Cantidad";
                    hoja.Cells[filaLicencia - 1, 6] = "Precio";

                    //int i = grd.Columns.Count + 64;
                    int i = 6 + 64;
                    char columF = (char)i;
                    int fila2 = filaLicencia - 1;
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

                    for (int j = 0; j < 6; j++)
                    {
                        rango = hoja.Columns[j + 1];
                        rango.ColumnWidth = 13;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de redondeo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void releaseObject(object obj)
        {
            Cursor.Current = Cursors.WaitCursor;
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


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string numIngreso = txtNroIngreso.Text;
            if (cmbProveedor.SelectedValue == null)
            {
                MessageBox.Show("No se puede grabar un Ingreso si no\nha seleccionado un proveedor correcto.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return;
            }

            if (cmbTipoIngreso.SelectedIndex == -1)
            {
                MessageBox.Show("No se puede grabar un Ingreso si no\nespecifica el tipo de ingreso.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                return;
            }

            if (cmbMonedaTipo.SelectedIndex == -1)
            {
                MessageBox.Show("No se puede grabar un Ingreso si no\nespecifica el tipo de moneda.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                return;
            }
            ObtenerDatosIngreso();
            if (ValidarDatos())
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;


            //VALIDAR SI ES COMPRA (0)  O ARRENDAMIENTO (1)
            //! 0 -> COMPRA
            //! 1 -> SUBARRIENDO


            if (numIngreso.Length == 0)
            {
                if (MessageBox.Show("Estas seguro que deseas Guardar este proceso de Ingreso", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {

                    int idIngreso = ingresoDA.InsertarIngreso(ingreso, this.nombreUsuario);

                    if (idIngreso == -1)
                    {
                        MessageBox.Show("Hubo error en Registrar el Ingreso, comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    for (int i = 0; i < ingreso.Detalles.Count; i++)
                    {
                        ingreso.Detalles[i].IdIngresoDetalle = i + 1;
                    }
                    dgvLaptopsSeleccionados.PrimaryGrid.DataSource = ingreso.Detalles;

                    MessageBox.Show("Se guardó el Ingreso", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ingreso.IdIngreso = idIngreso;
                    txtNroIngreso.Text = idIngreso.ToString();
                    estadoComponentes(TipoVista.Guardar);
                }
            }
            else
            {
                if (MessageBox.Show("Estas seguro que desea Guardar los cambios", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ingresoDA.ModificarIngreso(ingreso, this.nombreUsuario);
                    for (int i = 0; i < ingreso.Detalles.Count; i++)
                    {
                        ingreso.Detalles[i].IdIngresoDetalle = i + 1;
                    }
                    dgvLaptopsSeleccionados.PrimaryGrid.DataSource = ingreso.Detalles;
                    MessageBox.Show("Se Modifico el Ingreso N° :" + txtNroIngreso.Text + " con exito", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    estadoComponentes(TipoVista.Guardar);
                }
            }
        }

        private void dgvMemorias_CellValueChanged(object sender, GridCellValueChangedEventArgs e)
        {
            int i = dgvMemorias.PrimaryGrid.ActiveRow.Index;
            int memoriaId;
            int aux;
            double auxDouble;
            double precio;
            int cantidadMemoria;
            string myStr;
            if (!(i == -1))
            {
                myStr = ((GridCell)(((GridRow)dgvMemorias.PrimaryGrid.ActiveRow)[2])).Value.ToString();
                myStr = myStr.TrimStart('0');

                if (myStr.Length > 0)
                {
                    aux = int.Parse(myStr);
                    if (aux < 0) myStr = "1";
                }
                else myStr = "1";
                cantidadMemoria = myStr.Length > 0 ? int.Parse(myStr) : 1;
                ((GridCell)(((GridRow)dgvMemorias.PrimaryGrid.ActiveRow)[2])).Value = cantidadMemoria;

                myStr = ((GridCell)(((GridRow)dgvMemorias.PrimaryGrid.ActiveRow)[5])).Value.ToString();
                myStr = myStr.TrimStart('0');

                if (myStr.Length > 0)
                {
                    auxDouble = double.Parse(myStr);
                    if (auxDouble < 0) myStr = "0.00";
                }
                else myStr = "0";
                precio = myStr.Length > 0 ? double.Parse(myStr) : 0.00;
                ((GridCell)(((GridRow)dgvMemorias.PrimaryGrid.ActiveRow)[5])).Value = precio;

                memoriaId = int.Parse(((GridCell)(((GridRow)dgvMemorias.PrimaryGrid.ActiveRow)[3])).Value.ToString());

                for (int j = 0; j < ingreso.Memorias.Count; j++)
                {
                    if (memoriaId == ingreso.Memorias[j].IdMemoria)
                    {
                        ingreso.Memorias[j].Cantidad = cantidadMemoria;
                        ingreso.Memorias[j].Precio = precio;
                    }
                }
            }

        }

        private void dgvDisco_CellValueChanged(object sender, GridCellValueChangedEventArgs e)
        {
            int i = dgvDisco.PrimaryGrid.ActiveRow.Index;
            int discoId;
            int aux;
            double auxDouble;
            double precio;
            int cantidadDisco;
            string myStr;
            if (!(i == -1))
            {
                myStr = ((GridCell)(((GridRow)dgvDisco.PrimaryGrid.ActiveRow)[2])).Value.ToString();
                myStr = myStr.TrimStart('0');

                if (myStr.Length > 0)
                {
                    aux = int.Parse(myStr);
                    if (aux < 0) myStr = "1";
                }
                else myStr = "1";
                cantidadDisco = myStr.Length > 0 ? int.Parse(myStr) : 1;
                ((GridCell)(((GridRow)dgvDisco.PrimaryGrid.ActiveRow)[2])).Value = cantidadDisco;


                myStr = ((GridCell)(((GridRow)dgvDisco.PrimaryGrid.ActiveRow)[5])).Value.ToString();
                myStr = myStr.TrimStart('0');

                if (myStr.Length > 0)
                {
                    auxDouble = double.Parse(myStr);
                    if (auxDouble < 0) myStr = "0.00";
                }
                else myStr = "0";
                precio = myStr.Length > 0 ? double.Parse(myStr) : 0.00;
                ((GridCell)(((GridRow)dgvDisco.PrimaryGrid.ActiveRow)[5])).Value = precio;


                discoId = int.Parse(((GridCell)(((GridRow)dgvDisco.PrimaryGrid.ActiveRow)[3])).Value.ToString());

                for (int j = 0; j < ingreso.Discos.Count; j++)
                {
                    if (discoId == ingreso.Discos[j].IdDisco)
                    {
                        ingreso.Discos[j].Cantidad = cantidadDisco;
                        ingreso.Discos[j].Precio = precio;
                    }
                }
            }

        }

        private void dgvLicencia_CellValueChanged(object sender, GridCellValueChangedEventArgs e)
        {
            try
            {

                int i = dgvLicencia.PrimaryGrid.ActiveRow.Index;
                int licenciaId;
                int aux;
                int cantidadLicencia;
                double auxDouble;
                double precio;
                string myStr;
                string clave = "";
                if (!(i == -1))
                {
                    myStr = ((GridCell)(((GridRow)dgvLicencia.PrimaryGrid.ActiveRow)[4])).Value.ToString();
                    myStr = myStr.TrimStart('0');

                    if (myStr.Length > 0)
                    {
                        aux = int.Parse(myStr);
                        if (aux < 0) myStr = "1";
                    }
                    else myStr = "1";
                    cantidadLicencia = myStr.Length > 0 ? int.Parse(myStr) : 1;
                    ((GridCell)(((GridRow)dgvLicencia.PrimaryGrid.ActiveRow)[4])).Value = cantidadLicencia;


                    if (((GridCell)(((GridRow)dgvLicencia.PrimaryGrid.ActiveRow)[3])).Value != null)
                    {
                        clave = ((GridCell)(((GridRow)dgvLicencia.PrimaryGrid.ActiveRow)[3])).Value.ToString();
                        clave = clave.Trim();
                    }
                    ((GridCell)(((GridRow)dgvLicencia.PrimaryGrid.ActiveRow)[3])).Value = clave;


                    myStr = ((GridCell)(((GridRow)dgvLicencia.PrimaryGrid.ActiveRow)[8])).Value.ToString();
                    myStr = myStr.TrimStart('0');

                    if (myStr.Length > 0)
                    {
                        auxDouble = double.Parse(myStr);
                        if (auxDouble < 0) myStr = "0.00";
                    }
                    else myStr = "0";
                    precio = myStr.Length > 0 ? double.Parse(myStr) : 0.00;
                    ((GridCell)(((GridRow)dgvLicencia.PrimaryGrid.ActiveRow)[8])).Value = precio;


                    licenciaId = int.Parse(((GridCell)(((GridRow)dgvLicencia.PrimaryGrid.ActiveRow)[7])).Value.ToString());

                    for (int j = 0; j < ingreso.Licencias.Count; j++)
                    {
                        if (licenciaId == ingreso.Licencias[j].IdLicencia)
                        {
                            ingreso.Licencias[j].Cantidad = cantidadLicencia;
                            ingreso.Licencias[j].Clave = clave;
                            ingreso.Licencias[j].Precio = precio;
                            break;
                        }
                    }
                }


            }
            catch
            {
                MessageBox.Show("Entro al try cath2");
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            int detTempId;
            IngresoDetalle det = new IngresoDetalle();
            int indiceLC = 0;

            if (dgvLaptopsSeleccionados.PrimaryGrid.Rows.Count == 0) return;
            if (dgvLaptopsSeleccionados.PrimaryGrid.Rows.Count > 0)
            {
                detTempId = int.Parse(((GridCell)(((GridRow)dgvLaptopsSeleccionados.PrimaryGrid.ActiveRow)[6])).Value.ToString());

                foreach (IngresoDetalle detalle in ingreso.Detalles)
                {
                    if (detalle.IdIngresoDetalle == detTempId)
                        break;
                    indiceLC++;
                }
            }

            using (frmProcesoIngresoLaptopCpu frm = new frmProcesoIngresoLaptopCpu(ingreso.Detalles[indiceLC]))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (dgvLaptopsSeleccionados.PrimaryGrid.Rows.Count > 0)
                    {
                        detTempId = int.Parse(((GridCell)(((GridRow)dgvLaptopsSeleccionados.PrimaryGrid.ActiveRow)[6])).Value.ToString());

                        int indiceLC2 = 0;
                        foreach (IngresoDetalle detalle in ingreso.Detalles)
                        {
                            if (detalle.IdIngresoDetalle == detTempId)
                            {
                                break;
                            }
                            indiceLC2++;
                        }

                        ingreso.Detalles.RemoveAt(indiceLC2);
                        for (int i = 0; i < ingreso.Detalles.Count; i++)
                        {
                            ingreso.Detalles[i].IdIngresoDetalle = i + 1;
                        }

                        dgvLaptopsSeleccionados.PrimaryGrid.DataSource = ingreso.Detalles;
                    }

                    det = frm.DETALLE;
                    det.IdIngresoDetalle = ingreso.Detalles.Count + 1;
                    ingreso.Detalles.Add(det);
                    dgvLaptopsSeleccionados.PrimaryGrid.DataSource = ingreso.Detalles;
                }
            }
        }

        private void txtMontoCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = solonumeros(Convert.ToInt32(e.KeyChar));
        }
        public bool solonumeros(int code)
        {
            bool resultado;

            if (code == 46 && txtMontoCambio.Text.Contains("."))//se evalua si es punto y si es punto se rebiza si ya existe en el textbox
            {
                resultado = true;
            }
            else if ((((code >= 48) && (code <= 57)) || (code == 8) || code == 46)) //se evaluan las teclas validas
            {
                resultado = false;
            }
            else if (!permitir)
            {
                resultado = permitir;
            }
            else
            {
                resultado = true;
            }

            return resultado;

        }

        private void txtMontoCambio_KeyDown(object sender, KeyEventArgs e)
        {
            //bool paste = (Convert.ToInt32(e.KeyData) == (Convert.ToInt32(Keys.Control) | Convert.ToInt32(Keys.V)));
            //bool copy = (Convert.ToInt32(e.KeyData) == (Convert.ToInt32(Keys.Control) | Convert.ToInt32(Keys.C)));
            //if (paste || copy)permitir = false;
            //else permitir = true;
        }

        private void dgvLaptopsSeleccionados_SortChanged(object sender, GridEventArgs e)
        {
            //MessageBox.Show("Entro aqui");
            //int aux = ingreso.Detalles.Count;
        }

        private void frmProcesoIngreso_Load(object sender, EventArgs e)
        {

        }

        private void dgvLaptopsSeleccionados_Click(object sender, EventArgs e)
        {

        }
    }
}
