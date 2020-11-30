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
    public partial class frmArchivoCrearMemoria : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }

        DataTable tablaMemorias;
        DataTable tablaTipo;
        DataTable tablaModelo;
        //DataTable tablaFrecuencia;
        DataTable tablaCapacidad;

        Memoria memoria;
        Memoria memoriaOld;

        MemoriaDA memoriaDA;

        private int idUsuario;
        private string nombreUsuario = "CEAS";

        private string memoriaCapacidad = "MEMORIA_CAPACIDAD";
        private string memoriaCategoria = "MEMORIA_CATEGORIA";
        private int idMemoriaCategoria = 8;

        public frmArchivoCrearMemoria()
        {
            InitializeComponent();
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public frmArchivoCrearMemoria(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public void Inicializado()
        {

            memoriaDA = new MemoriaDA();
            memoria = new Memoria();
            tablaMemorias = memoriaDA.ListarMemorias();

            dgvMemoria.PrimaryGrid.AutoGenerateColumns = false;
            dgvMemoria.PrimaryGrid.DataSource = tablaMemorias;

            tablaModelo = memoriaDA.ListarModelosMemoria();
            cmbModelo.DataSource = tablaModelo;
            cmbModelo.DisplayMember = "nombre";
            cmbModelo.ValueMember = "idModelo";

            //tablaFrecuencia = memoriaDA.ListarMemoriaFrecuencia();
            //cmbFrecuencia.DataSource = tablaFrecuencia;
            //cmbFrecuencia.DisplayMember = "descripcion";
            //cmbFrecuencia.ValueMember = "idAuxiliar";

            tablaCapacidad = memoriaDA.ListarMemoriaCapacidad();
            cmbCapacidad.DataSource = tablaCapacidad;
            cmbCapacidad.DisplayMember = "descripcion";
            cmbCapacidad.ValueMember = "idAuxiliar";

            tablaTipo = memoriaDA.ListarMemoriaTipo();
            cmbTipo.DataSource = tablaTipo;
            cmbTipo.DisplayMember = "descripcion";
            cmbTipo.ValueMember = "idAuxiliar";
        }

        public void estadoComponentes(TipoVista estado)
        {
            switch (estado)
            {
                case TipoVista.Inicial: //ya esta

                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    //cmbFrecuencia.Enabled = false;
                    cmbCapacidad.Enabled = false;
                    cmbModelo.Enabled = false;
                    cmbTipo.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    memoria = new Memoria();
                    break;
                case TipoVista.Nuevo: //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    //cmbFrecuencia.Enabled = true;
                    cmbCapacidad.Enabled = true;
                    cmbModelo.Enabled = true;
                    cmbTipo.Enabled = true;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    memoria = new Memoria();
                    break;
                case TipoVista.Guardar: //ya esta listo
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    //cmbFrecuencia.Enabled = false;
                    cmbCapacidad.Enabled = false;
                    cmbModelo.Enabled = false;
                    cmbTipo.Enabled = false;
                    chbActivo.Enabled = false;
                    memoria = new Memoria();
                    dgvMemoria.PrimaryGrid.DataSource = null;
                    tablaMemorias = memoriaDA.ListarMemorias();
                    dgvMemoria.PrimaryGrid.DataSource = tablaMemorias;
                    //limpiarComponentes();
                    break;
                case TipoVista.Modificar://ya esta
                                         //Inicializado(idUsuario, nombreUsuario);

                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    //cmbFrecuencia.Enabled = true;
                    cmbCapacidad.Enabled = true;
                    cmbModelo.Enabled = true;
                    cmbTipo.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    memoria = new Memoria();
                    break;
                case TipoVista.Vista:
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    //cmbFrecuencia.Enabled = false;
                    cmbCapacidad.Enabled = false;
                    cmbModelo.Enabled = false;
                    cmbTipo.Enabled = false;
                    chbActivo.Enabled = false;
                    //limpiarComponentes();
                    memoria = new Memoria();
                    break;
                case TipoVista.Limpiar: //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    //cmbFrecuencia.Enabled = false;
                    cmbCapacidad.Enabled = false;
                    cmbModelo.Enabled = false;
                    cmbTipo.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    memoria = new Memoria();
                    break;
                case TipoVista.Duplicar:  //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    //cmbFrecuencia.Enabled = true;
                    cmbCapacidad.Enabled = true;
                    cmbModelo.Enabled = true;
                    cmbTipo.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    memoria = new Memoria();
                    break;
                case TipoVista.Anular:  //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    //cmbFrecuencia.Enabled = false;
                    cmbCapacidad.Enabled = false;
                    cmbModelo.Enabled = false;
                    cmbTipo.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    memoria = new Memoria();
                    break;
            }
        }

        public void limpiarComponentes()
        {
            cmbModelo.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
            cmbCapacidad.SelectedIndex = -1;
            //cmbFrecuencia.SelectedIndex = -1;
            chbActivo.Checked = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Nuevo);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                GridRow aux = (GridRow)dgvMemoria.PrimaryGrid.ActiveRow;
                if (aux != null)
                {
                    estadoComponentes(TipoVista.Modificar);
                    memoriaOld = new Memoria();

                    memoria.IdMemoria = int.Parse(((GridCell)(((GridRow)dgvMemoria.PrimaryGrid.ActiveRow)[5])).Value.ToString());
                    int idModelo = int.Parse(((GridCell)(((GridRow)dgvMemoria.PrimaryGrid.ActiveRow)[6])).Value.ToString());
                    int idTipo = int.Parse(((GridCell)(((GridRow)dgvMemoria.PrimaryGrid.ActiveRow)[7])).Value.ToString());
                    //int idFrecuencia = int.Parse(((GridCell)(((GridRow)dgvMemoria.PrimaryGrid.ActiveRow)[8])).Value.ToString());
                    int idCapacidad = int.Parse(((GridCell)(((GridRow)dgvMemoria.PrimaryGrid.ActiveRow)[8])).Value.ToString());
                    int activo = int.Parse(((GridCell)(((GridRow)dgvMemoria.PrimaryGrid.ActiveRow)[4])).Value.ToString());
                    cmbModelo.SelectedValue = idModelo;
                    cmbTipo.SelectedValue = idTipo;
                    //cmbFrecuencia.SelectedValue = idFrecuencia;
                    cmbCapacidad.SelectedValue = idCapacidad;
                    chbActivo.Checked = (activo == 1) ? true : false;


                    int indice;
                    indice = cmbModelo.SelectedIndex;
                    memoriaOld.Modelo.IdModelo = int.Parse(cmbModelo.SelectedValue.ToString());
                    //memoriaOld.Modelo.NombreModelo = tablaModelo.Rows[indice]["nombre"].ToString();

                    indice = cmbTipo.SelectedIndex;
                    memoriaOld.IdTipo = int.Parse(cmbTipo.SelectedValue.ToString());
                    //memoriaOld.Tipo = tablaTipo.Rows[indice]["descripcion"].ToString();

                    //indice = cmbFrecuencia.SelectedIndex;
                    //memoriaOld.IdBusFrecuencia = int.Parse(cmbFrecuencia.SelectedValue.ToString());
                    //memoriaOld.BusFrecuencia = Convert.ToInt32(tablaFrecuencia.Rows[indice]["descripcion"].ToString());

                    indice = cmbCapacidad.SelectedIndex;
                    memoriaOld.IdCapacidad = int.Parse(cmbCapacidad.SelectedValue.ToString());
                    //memoriaOld.Capacidad = int.Parse(tablaCapacidad.Rows[indice]["descripcion"].ToString());

                    memoriaOld.Estado = activo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                estadoComponentes(TipoVista.Anular);
                return;
            }
            
        }

        private void llenar_Datos_Memorias()
        {
            int indice;
            indice = cmbModelo.SelectedIndex;
            memoria.Modelo.IdModelo = int.Parse(cmbModelo.SelectedValue.ToString());
            memoria.Modelo.NombreModelo = tablaModelo.Rows[indice]["nombre"].ToString();

            //indice = cmbFrecuencia.SelectedIndex;
            //memoria.IdBusFrecuencia = int.Parse(cmbFrecuencia.SelectedValue.ToString());
            //memoria.BusFrecuencia = Convert.ToInt32(tablaFrecuencia.Rows[indice]["descripcion"].ToString());

            indice = cmbCapacidad.SelectedIndex;
            memoria.IdCapacidad = int.Parse(cmbCapacidad.SelectedValue.ToString());
            memoria.Capacidad = int.Parse(tablaCapacidad.Rows[indice]["descripcion"].ToString());

            indice = cmbTipo.SelectedIndex;
            memoria.IdTipo = int.Parse(cmbTipo.SelectedValue.ToString());
            memoria.Tipo = tablaTipo.Rows[indice]["descripcion"].ToString();

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int i = cmbModelo.SelectedIndex;
            int j = cmbCapacidad.SelectedIndex;
            //int k = cmbFrecuencia.SelectedIndex;
            int l = cmbTipo.SelectedIndex;

            //if (!(i >= 0 && j >= 0 && k >= 0 && l >= 0)) //Esto verifica que se ha seleccionado algún item del comboBox
            if (!(i >= 0 && j >= 0 && l >= 0)) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                    MessageBox.Show("No se puede crear una memoria si no\ntiene todas sus características completas.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            llenar_Datos_Memorias();
            if (memoria.IdMemoria == 0)
            {
                if (MessageBox.Show("¿Estás seguro deseas Crear este tipo de Memoria?", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idMemoria = memoriaDA.GuardarNuevaMemoria(memoria, this.nombreUsuario);

                    if (idMemoria > 0)
                    {
                        MessageBox.Show("Se guardó exitosamente la memoria con Código: MEM-" + idMemoria, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idMemoria == 0)
                        MessageBox.Show("Ya existe una memoria con las mismas características", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No se pudo guardar la memoria", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {

                memoria.Estado = (chbActivo.Checked) ? 1 : 0;
                //if ((memoria.Modelo.IdModelo == memoriaOld.Modelo.IdModelo && memoria.Modelo.NombreModelo == memoriaOld.Modelo.NombreModelo &&
                //    memoria.IdCapacidad == memoriaOld.IdCapacidad && memoria.Capacidad == memoriaOld.Capacidad &&
                //    memoria.IdBusFrecuencia == memoriaOld.IdBusFrecuencia && memoria.BusFrecuencia == memoriaOld.BusFrecuencia &&
                //    memoria.IdTipo == memoriaOld.IdTipo && memoria.Tipo == memoriaOld.Tipo &&
                //    memoria.Estado == memoriaOld.Estado))
                if ((memoria.Modelo.IdModelo == memoriaOld.Modelo.IdModelo && 
                    memoria.IdCapacidad == memoriaOld.IdCapacidad && 
                    memoria.IdTipo == memoriaOld.IdTipo && 
                    memoria.Estado == memoriaOld.Estado))
                //if (disco == discoOld)
                {
                    //MessageBox.Show("Son identicos", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (MessageBox.Show("¿Estás seguro que desea Guardar los cambios?", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idMemoria;

                    //if ((memoria.Modelo.IdModelo == memoriaOld.Modelo.IdModelo && memoria.Modelo.NombreModelo == memoriaOld.Modelo.NombreModelo &&
                    //memoria.IdCapacidad == memoriaOld.IdCapacidad && memoria.Capacidad == memoriaOld.Capacidad &&
                    //memoria.IdBusFrecuencia == memoriaOld.IdBusFrecuencia && memoria.BusFrecuencia == memoriaOld.BusFrecuencia &&
                    //memoria.IdTipo == memoriaOld.IdTipo && memoria.Tipo == memoriaOld.Tipo &&
                    //memoria.Estado != memoriaOld.Estado))
                    if ((memoria.Modelo.IdModelo == memoriaOld.Modelo.IdModelo && 
                    memoria.IdCapacidad == memoriaOld.IdCapacidad && 
                    memoria.IdTipo == memoriaOld.IdTipo && 
                    memoria.Estado != memoriaOld.Estado))
                    //if(disco==discoOld)
                    {
                        idMemoria = memoriaDA.ModificarMemoria(memoria, this.nombreUsuario, 1);
                    }
                    else
                    {
                        idMemoria = memoriaDA.ModificarMemoria(memoria, this.nombreUsuario, 0);
                    }

                    if (idMemoria > 0)
                    {
                        MessageBox.Show("Se Modificó la memoria con Código : MEM-" + memoria.IdMemoria + " con éxito", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idMemoria == 0)
                        MessageBox.Show("Ya existe una memoria con las mismas características", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No se pudo guardar los cambios de la memoria", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Anular);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea Imprimir la lista de Memorias", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                MessageBox.Show("Se imprimio la lista de Memorias");
            }
        }

        private void dgvMemoria_Click(object sender, EventArgs e)
        {
            GridRow aux = (GridRow)dgvMemoria.PrimaryGrid.ActiveRow;
            if (aux != null)
            {
                estadoComponentes(TipoVista.Vista);
                memoria.IdMemoria = int.Parse(((GridCell)(((GridRow)dgvMemoria.PrimaryGrid.ActiveRow)[5])).Value.ToString());
                int idModelo = int.Parse(((GridCell)(((GridRow)dgvMemoria.PrimaryGrid.ActiveRow)[6])).Value.ToString());
                int idTipo = int.Parse(((GridCell)(((GridRow)dgvMemoria.PrimaryGrid.ActiveRow)[7])).Value.ToString());
                //int idFrecuencia = int.Parse(((GridCell)(((GridRow)dgvMemoria.PrimaryGrid.ActiveRow)[8])).Value.ToString());
                int idCapacidad = int.Parse(((GridCell)(((GridRow)dgvMemoria.PrimaryGrid.ActiveRow)[8])).Value.ToString());
                int activo = int.Parse(((GridCell)(((GridRow)dgvMemoria.PrimaryGrid.ActiveRow)[4])).Value.ToString());
                cmbModelo.SelectedValue = idModelo;
                cmbTipo.SelectedValue = idTipo;
                //cmbFrecuencia.SelectedValue = idFrecuencia;
                cmbCapacidad.SelectedValue = idCapacidad;
                chbActivo.Checked = (activo == 1) ? true : false;
            }
        }

        private void btnAgregarCapacidadMemoria_Click(object sender, EventArgs e)
        {
            frmArchivoAuxiliar frmBP = new frmArchivoAuxiliar(this.idUsuario, this.nombreUsuario, this.memoriaCapacidad);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
            }
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        private void btnAgregarTipoMemoria_Click(object sender, EventArgs e)
        {
            frmArchivoAuxiliar frmBP = new frmArchivoAuxiliar(this.idUsuario, this.nombreUsuario, this.memoriaCategoria);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
            }
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        private void btnAgregarModeloMemoria_Click(object sender, EventArgs e)
        {
            frmArchivoModelo frmBP = new frmArchivoModelo(this.idUsuario, this.nombreUsuario, this.idMemoriaCategoria);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
            }
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }
    }
}
