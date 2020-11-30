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
    public partial class frmArchivoCrearDiscoDuro : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaDisco;
        DataTable tablaCapacidad;
        DataTable tablaTamano;
        DataTable tablaTipo;
        DiscoDuro disco;
        DiscoDuro discoOld;
        DiscoDuroDA discoDA;
        private int idUsuario;
        private string nombreUsuario="CEAS";

        private string discoTamano = "DISCO_TAMANO";
        private string discoCapacidad = "DISCO_CAPACIDAD";
        private int idCategoriaDisco = 10;


        public frmArchivoCrearDiscoDuro()
        {
            InitializeComponent();
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public frmArchivoCrearDiscoDuro(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public void Inicializado()
        {

            discoDA = new DiscoDuroDA();
            disco = new DiscoDuro();
            tablaDisco = discoDA.ListarDiscosDuros();

            dgvDiscoDuro.PrimaryGrid.AutoGenerateColumns = false;
            dgvDiscoDuro.PrimaryGrid.DataSource = tablaDisco;

            tablaCapacidad = discoDA.ListarCapacidadDuros();
            cmbCapacidad.DataSource = tablaCapacidad;
            cmbCapacidad.DisplayMember = "descripcion";
            cmbCapacidad.ValueMember = "idAuxiliar";

            tablaTamano = discoDA.ListarTamanoDisco();
            cmbTamano.DataSource = tablaTamano;
            cmbTamano.DisplayMember = "descripcion";
            cmbTamano.ValueMember = "idAuxiliar";

            tablaTipo = discoDA.ListarTipoDisco();
            cmbTipo.DataSource = tablaTipo;
            cmbTipo.DisplayMember = "nombre";
            cmbTipo.ValueMember = "idModelo";
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
                    cmbCapacidad.Enabled = false;
                    cmbTamano.Enabled = false;
                    cmbTipo.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    disco = new DiscoDuro();
                    break;
                case TipoVista.Nuevo: //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    cmbCapacidad.Enabled = true;
                    cmbTamano.Enabled = true;
                    cmbTipo.Enabled = true;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    disco = new DiscoDuro();
                    break;
                case TipoVista.Guardar: //ya esta listo
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    cmbCapacidad.Enabled = false;
                    cmbTamano.Enabled = false;
                    cmbTipo.Enabled = false;
                    chbActivo.Enabled = false;
                    disco = new DiscoDuro();
                    dgvDiscoDuro.PrimaryGrid.DataSource = null;
                    tablaDisco = discoDA.ListarDiscosDuros();
                    dgvDiscoDuro.PrimaryGrid.DataSource = tablaDisco;
                    //limpiarComponentes();
                    break;
                case TipoVista.Modificar://ya esta
                                         //Inicializado(idUsuario, nombreUsuario);

                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    cmbCapacidad.Enabled = true;
                    cmbTamano.Enabled = true;
                    cmbTipo.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    disco = new DiscoDuro();
                    break;
                case TipoVista.Vista:
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    cmbCapacidad.Enabled = false;
                    cmbTamano.Enabled = false;
                    cmbTipo.Enabled = false;
                    chbActivo.Enabled = false;
                    //limpiarComponentes();
                    disco = new DiscoDuro();
                    break;
                case TipoVista.Limpiar: //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    cmbCapacidad.Enabled = false;
                    cmbTamano.Enabled = false;
                    cmbTipo.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    disco = new DiscoDuro();
                    break;
                case TipoVista.Duplicar:  //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    cmbCapacidad.Enabled = true;
                    cmbTamano.Enabled = true;
                    cmbTipo.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    disco = new DiscoDuro();
                    break;
                case TipoVista.Anular:  //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    cmbCapacidad.Enabled = false;
                    cmbTamano.Enabled = false;
                    cmbTipo.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    disco = new DiscoDuro();
                    break;
            }
        }

        public void limpiarComponentes()
        {
            cmbTipo.SelectedIndex = -1;
            cmbTamano.SelectedIndex = -1;
            cmbCapacidad.SelectedIndex = -1;
            chbActivo.Checked = false;
        }
        
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                GridRow aux = (GridRow)dgvDiscoDuro.PrimaryGrid.ActiveRow;
                if (aux != null)
                {
                    estadoComponentes(TipoVista.Modificar);
                    discoOld = new DiscoDuro();

                    disco.IdDisco = int.Parse(((GridCell)(((GridRow)dgvDiscoDuro.PrimaryGrid.ActiveRow)[8])).Value.ToString());
                    int idTipo = int.Parse(((GridCell)(((GridRow)dgvDiscoDuro.PrimaryGrid.ActiveRow)[5])).Value.ToString());
                    int idCapacidad = int.Parse(((GridCell)(((GridRow)dgvDiscoDuro.PrimaryGrid.ActiveRow)[6])).Value.ToString());
                    int idTamano = int.Parse(((GridCell)(((GridRow)dgvDiscoDuro.PrimaryGrid.ActiveRow)[7])).Value.ToString());
                    int activo = int.Parse(((GridCell)(((GridRow)dgvDiscoDuro.PrimaryGrid.ActiveRow)[4])).Value.ToString());
                    cmbTipo.SelectedValue = idTipo;
                    cmbCapacidad.SelectedValue = idCapacidad;
                    cmbTamano.SelectedValue = idTamano;
                    chbActivo.Checked = (activo == 1) ? true : false;


                    discoOld.Tipo.IdModelo = int.Parse(cmbTipo.SelectedValue.ToString());
                    discoOld.IdTamano = int.Parse(cmbTamano.SelectedValue.ToString());
                    discoOld.IdCapacidad = int.Parse(cmbCapacidad.SelectedValue.ToString());

                    discoOld.Tipo.IdModelo = idTipo;
                    //discoOld.Tipo.NombreModelo = ((GridCell)(((GridRow)dgvDiscoDuro.PrimaryGrid.ActiveRow)[1])).Value.ToString();
                    discoOld.IdTamano = idTamano;
                    //discoOld.Tamano = ((GridCell)(((GridRow)dgvDiscoDuro.PrimaryGrid.ActiveRow)[2])).Value.ToString();
                    discoOld.IdCapacidad = idCapacidad;
                    //discoOld.Capacidad = int.Parse(((GridCell)(((GridRow)dgvDiscoDuro.PrimaryGrid.ActiveRow)[3])).Value.ToString());
                    discoOld.Estado = activo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                estadoComponentes(TipoVista.Anular);
                return;
            }
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Nuevo);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int i = cmbTipo.SelectedIndex;
            int j = cmbCapacidad.SelectedIndex;
            int k = cmbTamano.SelectedIndex;

            if (!(i >= 0 && j >= 0 && k >= 0)) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                MessageBox.Show("No se puede crear un disco si no\ntiene todas sus características completas.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            llenar_Datos_Disco();
            if (disco.IdDisco == 0)
            {
                if (MessageBox.Show("¿Estás seguro que deseas Crear este tipo de Disco?", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idDisco = discoDA.GuardarNuevoDiscoDuro(disco, this.nombreUsuario);

                    if (idDisco > 0)
                    {
                        MessageBox.Show("Se guardó exitosamente el disco con Código: DIS-" + idDisco, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idDisco == 0)
                        MessageBox.Show("Ya existe un disco con las mismas características", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No se pudo guardar el disco", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {

                disco.Estado = (chbActivo.Checked) ? 1 : 0;
                if ((disco.Tipo.IdModelo==discoOld.Tipo.IdModelo && 
                    disco.IdTamano== discoOld.IdTamano && 
                    disco.IdCapacidad== discoOld.IdCapacidad && 
                    disco.Estado == discoOld.Estado))
                //if (disco == discoOld)
                {
                    //MessageBox.Show("Son identicos", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (MessageBox.Show("¿Estás seguro que desea Guardar los cambios?", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idDisco;

                    if ((disco.Tipo.IdModelo == discoOld.Tipo.IdModelo && 
                    disco.IdTamano == discoOld.IdTamano && 
                    disco.IdCapacidad == discoOld.IdCapacidad && 
                    disco.Estado != discoOld.Estado))
                    //if(disco==discoOld)
                    {
                        idDisco = discoDA.ModificarDiscoDuro(disco, this.nombreUsuario,1);
                    }
                    else
                    {
                        idDisco = discoDA.ModificarDiscoDuro(disco, this.nombreUsuario,0);
                    }

                    if (idDisco > 0)
                    {
                        MessageBox.Show("Se Modificó el disco con Código : DIS-" + disco.IdDisco + " con éxito", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idDisco == 0)
                        MessageBox.Show("Ya existe un disco con las mismas características", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No se pudo guardar los cambios del disco", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    
                }
            }

            Cursor.Current = Cursors.Default;

        }

        private void llenar_Datos_Disco()
        {
            int indice;
            indice = cmbTipo.SelectedIndex;
            disco.Tipo.IdModelo = int.Parse(cmbTipo.SelectedValue.ToString());
            disco.Tipo.NombreModelo = tablaTipo.Rows[indice]["nombre"].ToString();

            indice = cmbTamano.SelectedIndex;
            disco.IdTamano = int.Parse(cmbTamano.SelectedValue.ToString());
            disco.Tamano = tablaTamano.Rows[indice]["descripcion"].ToString();

            indice = cmbCapacidad.SelectedIndex;
            disco.IdCapacidad = int.Parse(cmbCapacidad.SelectedValue.ToString());
            disco.Capacidad = Convert.ToInt32(tablaCapacidad.Rows[indice]["descripcion"].ToString());

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Anular);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro que desea Imprimir la lista de Discos?", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                MessageBox.Show("Se imprimió la lista de Discos");
            }
        }
        
        private void dgvDiscoDuro_Click(object sender, EventArgs e)
        {
            GridRow aux = (GridRow)dgvDiscoDuro.PrimaryGrid.ActiveRow;
            if (aux != null)
            {
                estadoComponentes(TipoVista.Vista);
                disco.IdDisco = int.Parse(((GridCell)(((GridRow)dgvDiscoDuro.PrimaryGrid.ActiveRow)[8])).Value.ToString());
                int idTipo = int.Parse(((GridCell)(((GridRow)dgvDiscoDuro.PrimaryGrid.ActiveRow)[5])).Value.ToString());
                int idCapacidad = int.Parse(((GridCell)(((GridRow)dgvDiscoDuro.PrimaryGrid.ActiveRow)[6])).Value.ToString());
                int idTamano = int.Parse(((GridCell)(((GridRow)dgvDiscoDuro.PrimaryGrid.ActiveRow)[7])).Value.ToString());
                int activo = int.Parse(((GridCell)(((GridRow)dgvDiscoDuro.PrimaryGrid.ActiveRow)[4])).Value.ToString());
                cmbTipo.SelectedValue = idTipo;
                cmbCapacidad.SelectedValue = idCapacidad;
                cmbTamano.SelectedValue = idTamano;
                chbActivo.Checked = (activo == 1) ? true : false;
            }
        }

        private void btnAgregarTamanoDisco_Click(object sender, EventArgs e)
        {
            frmArchivoAuxiliar frmBP = new frmArchivoAuxiliar(this.idUsuario,this.nombreUsuario, this.discoTamano);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
            }
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        private void btnAgregarCapacidadDisco_Click(object sender, EventArgs e)
        {
            frmArchivoAuxiliar frmBP = new frmArchivoAuxiliar(this.idUsuario, this.nombreUsuario, this.discoCapacidad);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
            }
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        private void btnAgregarTipoDisco_Click(object sender, EventArgs e)
        {
            frmArchivoModelo frmBP = new frmArchivoModelo(this.idUsuario, this.nombreUsuario, this.idCategoriaDisco);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
            }
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }
    }
}
