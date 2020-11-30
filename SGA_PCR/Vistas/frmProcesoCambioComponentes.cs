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
    public partial class frmProcesoCambioComponentes : Form
    {
        
        DataTable tablaDisco;
        DataTable tablaMemoria;
        DataTable tablaLicencia;
        DataTable tablaLaptop;
        LaptopDA laptopDA;
        LC laptop;

        private int idUsuario;
        private string nombreUsuario = "CEAS";
        private int maxCantidadDiscos = 2;

        public frmProcesoCambioComponentes()
        {
            InitializeComponent();
            Inicializado();
        }

        public frmProcesoCambioComponentes(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
        }

        public void Inicializado()
        {

            laptopDA = new LaptopDA();
            laptop = new LC();

            dgvMemorias.PrimaryGrid.AutoGenerateColumns = false;
            dgvDisco.PrimaryGrid.AutoGenerateColumns = false;
            dgvLicencia.PrimaryGrid.AutoGenerateColumns = false;

        }

        public void LlenarDatosLaptop()
        {
            
            txtMarca.Text = laptop.MarcaLC;
            txtModelo.Text = laptop.NombreModeloLC;
            txtPantalla.Text = (laptop.TamanoPantalla!=0)?laptop.TamanoPantalla.ToString():"";
            txtProcesador.Text = laptop.TipoProcesador;
            txtProcesadorGeneracion.Text = (laptop.GeneracionProcesador != 0) ? laptop.GeneracionProcesador.ToString():"";
            txtVideo.Text = laptop.NombreModeloVideo;
            txtVideoCapacidad.Text = (laptop.CapacidadVideo != 0) ? laptop.CapacidadVideo.ToString():"";

            tablaDisco = laptopDA.ListarLaptopDisco(laptop.IdLC);
            tablaMemoria = laptopDA.ListarLaptopMemoria(laptop.IdLC);
            tablaLicencia = laptopDA.ListarLaptopLicencia(laptop.IdLC);

            laptop.SetDisco(tablaDisco);
            laptop.SetMemoria(tablaMemoria);
            laptop.SetLicencia(tablaLicencia);

            dgvMemorias.PrimaryGrid.DataSource = tablaMemoria;
            dgvDisco.PrimaryGrid.DataSource = tablaDisco;
            dgvLicencia.PrimaryGrid.DataSource = tablaLicencia;
        }


        private void btnEditarMemoria_Click(object sender, EventArgs e)
        {
            dgvMemorias.PrimaryGrid.Columns[2].AllowEdit = true;
        }

        private void btnEditarDisco_Click(object sender, EventArgs e)
        {
            dgvDisco.PrimaryGrid.Columns[2].AllowEdit = true;
        }


        private void btnAgregarMemoria_Click(object sender, EventArgs e)
        {
            
            if (laptop.IdLC!=0)
            {
                using (frmProcesoEditarMemoria frm = new frmProcesoEditarMemoria())
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        

                        foreach (Memoria memoriaTraido in frm.MEMORIAS)
                        {
                            Memoria memTemp = new Memoria();
                            memTemp.IdMemoria = memoriaTraido.IdMemoria;
                            bool exists = laptop.Memorias.Any(x => x.IdMemoria.Equals(memTemp.IdMemoria));
                            if (!(exists))
                            {
                                memTemp.TipoMemoria = memoriaTraido.TipoMemoria;
                                memTemp.Capacidad = memoriaTraido.Capacidad;
                                memTemp.Tipo = memoriaTraido.Tipo;
                                memTemp.Cantidad = 1;
                                laptop.Memorias.Add(memTemp);
                            }
                        }

                        bool error;
                        if (dgvMemorias.PrimaryGrid.Rows.Count > 0)
                        {
                            error = laptopDA.ActualizarLaptopMemoria(laptop.IdLC, laptop.Memorias, this.nombreUsuario);
                        }
                        else
                        {
                            error = laptopDA.InsertarLaptopMemoriasPrimeraVez(laptop.IdLC, laptop.Memorias, this.nombreUsuario);
                        }

                        if (!error)
                        {
                            MessageBox.Show("Hubo error en agregar las memorias seleccionadas, comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        MessageBox.Show("Se realizó el cambio de piezas", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        tablaMemoria = laptopDA.ListarLaptopMemoria(laptop.IdLC);
                        dgvMemorias.PrimaryGrid.DataSource = tablaMemoria;
                    }
                }
            }

        }

        private void btnGuardarMemoria_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Estas seguro deseas Guardar los cambios hechos en tus memorias actuales", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                bool error;
                if (dgvMemorias.PrimaryGrid.Rows.Count > 0)
                {
                    BindingList<Memoria> memorias = new BindingList<Memoria>();
                    for (int i = 0; i < dgvMemorias.PrimaryGrid.Rows.Count; i++)
                    {
                        Memoria memoria = new Memoria();
                        memoria.IdMemoria = int.Parse(((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 3))).Value.ToString());
                        memoria.TipoMemoria = ((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 0))).Value.ToString();
                        memoria.Tipo = ((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 4))).Value.ToString();
                        memoria.Capacidad = int.Parse(((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 1))).Value.ToString());
                        memoria.Cantidad = int.Parse(((GridCell)(dgvMemorias.PrimaryGrid.GetCell(i, 2))).Value.ToString());
                        memorias.Add(memoria);
                    }
                    int maxCant = laptopDA.ValidarCantidadLaptopMemoria(laptop.IdLC, memorias);
                    if (maxCant == -1)
                    {
                        MessageBox.Show("Uno de las memorias tiene una cantidad mayor al stock actual", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    error = laptopDA.ActualizarLaptopMemoria(laptop.IdLC, memorias, this.nombreUsuario);
                    if (!error)
                    {
                        MessageBox.Show("Hubo error en el cambio de piezas, comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    laptop.Memorias = memorias;
                    MessageBox.Show("Se realizó el cambio de piezas", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void dgvMemorias_DoubleClick(object sender, EventArgs e)
        {

            if (MessageBox.Show("Estas seguro deseas Eliminar esta memoria", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                bool error;
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
                            memorias.Add(memoria);

                        }
                    }
                    error = laptopDA.ActualizarLaptopMemoria(laptop.IdLC, memorias, this.nombreUsuario);
                    if (!error)
                    {
                        MessageBox.Show("Hubo error, no se pudo eliminar esta memoria, comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    laptop.Memorias = memorias;
                    MessageBox.Show("Se eliminó la pieza seleccionada", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    tablaMemoria = laptopDA.ListarLaptopMemoria(laptop.IdLC);
                    dgvMemorias.PrimaryGrid.DataSource = tablaMemoria;
                }
            }
        }

        private void btnAgregarDisco_Click(object sender, EventArgs e)
        {
            
            if (laptop.IdLC!=0)
            {
                int cantidadDiscos = dgvDisco.PrimaryGrid.Rows.Count;
                if (cantidadDiscos < this.maxCantidadDiscos)
                {
                    using (frmProcesoEditarDisco frm = new frmProcesoEditarDisco(cantidadDiscos, this.maxCantidadDiscos))
                    {
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            foreach (DiscoDuro discoTraido in frm.DISCOS)
                            {
                                DiscoDuro disTemp = new DiscoDuro();
                                disTemp.IdDisco = discoTraido.IdDisco;
                                bool exists = laptop.Discos.Any(x => x.IdDisco.Equals(disTemp.IdDisco));
                                if (!(exists))
                                {
                                    disTemp.TipoDisco = discoTraido.TipoDisco;
                                    disTemp.Capacidad = discoTraido.Capacidad;
                                    disTemp.Cantidad = 1;
                                    laptop.Discos.Add(disTemp);
                                }
                            }

                            bool error;
                            if (dgvDisco.PrimaryGrid.Rows.Count > 0)
                            {
                                error = laptopDA.ActualizarLaptopDisco(laptop.IdLC, laptop.Discos, this.nombreUsuario);
                            }
                            else
                            {
                                error = laptopDA.InsertarLaptopDiscosPrimeraVez(laptop.IdLC, laptop.Discos, this.nombreUsuario);
                            }

                            if (!error)
                            {
                                MessageBox.Show("Hubo error en agregar los discos seleccionados, comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                return;
                            }


                            MessageBox.Show("Se realizó el cambio de piezas", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            tablaDisco = laptopDA.ListarLaptopDisco(laptop.IdLC);
                            dgvDisco.PrimaryGrid.DataSource = tablaDisco;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No puedes agregar más de " + this.maxCantidadDiscos + " discos duros", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }

        }

        private void dgvDisco_DoubleClick(object sender, EventArgs e)
        {

            if (MessageBox.Show("Estas seguro deseas Eliminar este disco", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                bool error;
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
                            disco.Capacidad = int.Parse(((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 1))).Value.ToString());
                            disco.Cantidad = int.Parse(((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 2))).Value.ToString());
                            discos.Add(disco);

                        }
                    }
                    error = laptopDA.ActualizarLaptopDisco(laptop.IdLC, discos, this.nombreUsuario);
                    if (!error)
                    {
                        MessageBox.Show("Hubo error, no se pudo eliminar este disco, comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    laptop.Discos = discos;
                    MessageBox.Show("Se eliminó la pieza seleccionada", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    tablaDisco = laptopDA.ListarLaptopDisco(laptop.IdLC);
                    dgvDisco.PrimaryGrid.DataSource = tablaDisco;
                }
            }
        }

        private void btnGuardarDisco_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Estas seguro deseas Guardar los cambios hechos en tus discos actuales", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                bool error;
                if (dgvDisco.PrimaryGrid.Rows.Count > 0)
                {
                    BindingList<DiscoDuro> discos = new BindingList<DiscoDuro>();
                    for (int i = 0; i < dgvDisco.PrimaryGrid.Rows.Count; i++)
                    {
                        DiscoDuro disco = new DiscoDuro();
                        disco.IdDisco = int.Parse(((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 3))).Value.ToString());
                        disco.TipoDisco = ((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 0))).Value.ToString();
                        disco.Capacidad = int.Parse(((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 1))).Value.ToString());
                        disco.Cantidad = int.Parse(((GridCell)(dgvDisco.PrimaryGrid.GetCell(i, 2))).Value.ToString());
                        discos.Add(disco);
                    }
                    int maxCant = laptopDA.ValidarCantidadLaptopDiscos(laptop.IdLC, discos);
                    if (maxCant == -1)
                    {
                        MessageBox.Show("Uno de los discos tiene una cantidad mayor al stock actual", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    error = laptopDA.ActualizarLaptopDisco(laptop.IdLC, discos, this.nombreUsuario);
                    if (!error)
                    {
                        MessageBox.Show("Hubo error en el cambio de piezas, comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    laptop.Discos = discos;
                    MessageBox.Show("Se realizó el cambio de piezas", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnAgregarLicencia_Click(object sender, EventArgs e)
        {
            if (laptop.IdLC!=0)
            {
                using (frmProcesoEditarLicencia frm = new frmProcesoEditarLicencia())
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BindingList<Licencia> licenciaAux = new BindingList<Licencia>();
                        foreach (Licencia licenciaTraido in frm.LICENCIAS)
                        {
                            Licencia licTemp = new Licencia();
                            licTemp.IdLicencia = licenciaTraido.IdLicencia;
                            licTemp.Categoria = licenciaTraido.Categoria;
                            bool exists = laptop.Licencias.Any(x => x.Categoria.Equals(licTemp.Categoria));
                            if (!(exists))
                            {
                                licTemp.Categoria = licenciaTraido.Categoria;
                                licTemp.Marca = licenciaTraido.Marca;
                                licTemp.Version = licenciaTraido.Version;
                                licTemp.Clave = licenciaTraido.Clave;

                                licenciaAux.Add(licTemp);
                            }
                        }

                        bool error = true;

                        if (licenciaAux.Count > 0)
                            error = laptopDA.InsertarLaptopLicenciaPrimeraVez(laptop.IdLC, licenciaAux, this.nombreUsuario);
                        else return;

                        if (!error)
                        {
                            MessageBox.Show("Hubo error en agregar las licencias seleccionadas, comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        foreach (Licencia licenciaTraido in licenciaAux)
                        {
                            laptop.Licencias.Add(licenciaTraido);
                        }

                        MessageBox.Show("Se realizó el cambio de piezas", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        tablaLicencia = laptopDA.ListarLaptopLicencia(laptop.IdLC);
                        dgvLicencia.PrimaryGrid.DataSource = tablaLicencia;
                    }
                }
            }

        }

        private void btnCaducidadLicencia_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Estas seguro deseas Poner en caducidad esta licencia", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                bool error;
                if (dgvLicencia.PrimaryGrid.Rows.Count > 0)
                {
                    int licTempId = int.Parse(((GridCell)(((GridRow)dgvLicencia.PrimaryGrid.ActiveRow)[4])).Value.ToString());

                    error = laptopDA.ActualizarLaptopLicencia(laptop.IdLC, licTempId, this.nombreUsuario, 0);
                    if (!error)
                    {
                        MessageBox.Show("Hubo error en poner en caducidad esta licencia, comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    //Hasta aqui ya se encontro la licencia del ID y el indice de donde se ubica en el detalle

                    int indiceLic = 0;
                    foreach (Licencia licencia in laptop.Licencias)
                    {
                        if (licencia.IdLicencia == licTempId)
                        {
                            break;
                        }
                        indiceLic++;
                    }

                    laptop.Licencias.RemoveAt(indiceLic);

                    MessageBox.Show("Se eliminó la pieza seleccionada", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    tablaLicencia = laptopDA.ListarLaptopLicencia(laptop.IdLC);
                    dgvLicencia.PrimaryGrid.DataSource = tablaLicencia;
                }
            }
        }

        private void btnEliminarLicencia_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Estas seguro deseas Eliminar esta licencia", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                bool error;
                if (dgvLicencia.PrimaryGrid.Rows.Count > 0)
                {
                    int licTempId = int.Parse(((GridCell)(((GridRow)dgvLicencia.PrimaryGrid.ActiveRow)[4])).Value.ToString());

                    error = laptopDA.ActualizarLaptopLicencia(laptop.IdLC, licTempId, this.nombreUsuario, 1);
                    if (!error)
                    {
                        MessageBox.Show("Hubo error en eliminar esta licencia, comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    //Hasta aqui ya se encontro la licencia del ID y el indice de donde se ubica en el detalle

                    int indiceLic = 0;
                    foreach (Licencia licencia in laptop.Licencias)
                    {
                        if (licencia.IdLicencia == licTempId)
                        {
                            break;
                        }
                        indiceLic++;
                    }

                    laptop.Licencias.RemoveAt(indiceLic);

                    MessageBox.Show("Se eliminó la pieza seleccionada", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    tablaLicencia = laptopDA.ListarLaptopLicencia(laptop.IdLC);
                    dgvLicencia.PrimaryGrid.DataSource = tablaLicencia;
                }
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            codigo = codigo.Trim();
            //laptop = laptopDA.DatosLaptopDisponibleSinMemoriaSinDisco(codigo);
            laptop = laptopDA.DatosLaptopsSinMemoriaSinDiscoSinFiltros(codigo);
            LlenarDatosLaptop();
        }

        private void dgvMemorias_CellValueChanged(object sender, GridCellValueChangedEventArgs e)
        {
            int i = dgvMemorias.PrimaryGrid.ActiveRow.Index;
            int aux;
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
            }
        }

        private void dgvDisco_CellValueChanged(object sender, GridCellValueChangedEventArgs e)
        {
            int i = dgvDisco.PrimaryGrid.ActiveRow.Index;
            int aux;
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
            }
        }
    }
}
