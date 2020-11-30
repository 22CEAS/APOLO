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
    public partial class frmArchivoAuxiliar : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaAuxiliar;
        DataView viewAuxiliar;
        Auxiliar auxiliar;
        Auxiliar auxiliarOld;
        AuxiliarDA auxiliarDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";
        private string cod_tabla = "";

        public frmArchivoAuxiliar()
        {
            InitializeComponent();
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public frmArchivoAuxiliar(int idUsuario, string nombreUsuario, string cod_tabla)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            this.cod_tabla = cod_tabla;
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public void Inicializado()
        {
            auxiliarDA = new AuxiliarDA();
            auxiliar = new Auxiliar();
            tablaAuxiliar = auxiliarDA.ListarAuxiliares();
            viewAuxiliar = new DataView(tablaAuxiliar);

            viewAuxiliar.RowFilter = "cod_tabla = '" + cod_tabla+"'";

            dgvAuxiliar.PrimaryGrid.AutoGenerateColumns = false;
            dgvAuxiliar.PrimaryGrid.DataSource = viewAuxiliar;

        }
        public void estadoComponentes(TipoVista estado)
        {
            switch (estado)
            {
                case TipoVista.Inicial: //ya esta

                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    txtDescripcion.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    auxiliar = new Auxiliar();
                    break;
                case TipoVista.Nuevo: //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    txtDescripcion.Enabled = true;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    auxiliar = new Auxiliar();
                    break;
                case TipoVista.Guardar: //ya esta listo
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    txtDescripcion.Enabled = false;
                    chbActivo.Enabled = false;
                    auxiliar = new Auxiliar();
                    dgvAuxiliar.PrimaryGrid.DataSource = null;
                    tablaAuxiliar = auxiliarDA.ListarAuxiliares();
                    viewAuxiliar = new DataView(tablaAuxiliar);
                    viewAuxiliar.RowFilter = "cod_tabla = '" + cod_tabla+  "'";
                    dgvAuxiliar.PrimaryGrid.DataSource = viewAuxiliar;
                    break;
                case TipoVista.Modificar:
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    txtDescripcion.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    auxiliar = new Auxiliar();
                    break;
                case TipoVista.Vista:
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    txtDescripcion.Enabled = false;
                    chbActivo.Enabled = false;
                    //limpiarComponentes();
                    auxiliar = new Auxiliar();
                    break;
                case TipoVista.Limpiar: //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    txtDescripcion.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    auxiliar = new Auxiliar();
                    break;
                case TipoVista.Duplicar:  //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    txtDescripcion.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    auxiliar = new Auxiliar();
                    break;
                case TipoVista.Anular:  //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    txtDescripcion.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    auxiliar = new Auxiliar();
                    break;
            }
        }
        public void limpiarComponentes()
        {
            txtDescripcion.Text = "";
            chbActivo.Checked = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Nuevo);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GridRow aux = (GridRow)dgvAuxiliar.PrimaryGrid.ActiveRow;
            if (aux != null)
            {
                estadoComponentes(TipoVista.Modificar);
                auxiliarOld = new Auxiliar();

                auxiliar.IdAuxiliar = int.Parse(((GridCell)(((GridRow)dgvAuxiliar.PrimaryGrid.ActiveRow)[3])).Value.ToString());
                string descripcion = ((GridCell)(((GridRow)dgvAuxiliar.PrimaryGrid.ActiveRow)[0])).Value.ToString();
                int activo = int.Parse(((GridCell)(((GridRow)dgvAuxiliar.PrimaryGrid.ActiveRow)[1])).Value.ToString());
                string codTabla = ((GridCell)(((GridRow)dgvAuxiliar.PrimaryGrid.ActiveRow)[2])).Value.ToString();
                chbActivo.Checked = (activo == 1) ? true : false;
                txtDescripcion.Text = descripcion;

                auxiliarOld.Descripcion = descripcion.ToUpper();
                auxiliarOld.Cod_tabla = codTabla;
                auxiliarOld.Activo = activo;

            }
        }

        private void llenar_Auxiliares()
        {
            auxiliar.Cod_tabla = this.cod_tabla;

            string aux = txtDescripcion.Text;
            aux = aux.Trim();
            aux = aux.ToUpper();
            auxiliar.Descripcion = aux;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string aux = txtDescripcion.Text;
            aux = aux.Trim();
            if (aux.Length==0) 
            {
                MessageBox.Show("Rellene el campo vacio", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            llenar_Auxiliares();
            if (auxiliar.IdAuxiliar == 0)
            {
                if (MessageBox.Show("¿Estás seguro que deseas Crear esta nueva descripción?", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idAuxiliar = auxiliarDA.GuardarNuevaDescripcion(auxiliar, this.nombreUsuario);

                    if (idAuxiliar > 0)
                    {
                        MessageBox.Show("Se guardó con éxito la Descripción ", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idAuxiliar == 0)
                        MessageBox.Show("Ya existe una Descripcion con las mismas características", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No se pudo guardar esta Descripción", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                auxiliar.Activo = (chbActivo.Checked) ? 1 : 0;
                if ((auxiliar.Descripcion == auxiliarOld.Descripcion &&
                    auxiliar.Activo == auxiliarOld.Activo))
                {
                    //MessageBox.Show("Son identicos", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (MessageBox.Show("¿Estás seguro que desea Guardar los cambios?", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idAuxiliar;

                    if ((auxiliar.Descripcion == auxiliarOld.Descripcion &&
                    auxiliar.Activo != auxiliarOld.Activo))
                    {
                        idAuxiliar = auxiliarDA.ModificarAuxiliar(auxiliar, this.nombreUsuario, 1);
                    }
                    else
                    {
                        idAuxiliar = auxiliarDA.ModificarAuxiliar(auxiliar, this.nombreUsuario, 0);
                    }

                    if (idAuxiliar > 0)
                    {
                        MessageBox.Show("Se Modificó la descripción con éxito", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idAuxiliar == 0)
                        MessageBox.Show("Ya existe uno con la misma descripción", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No se pudo guardar los cambios", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Anular);
        }

        private void dgvAuxiliar_Click(object sender, EventArgs e)
        {
            GridRow aux = (GridRow)dgvAuxiliar.PrimaryGrid.ActiveRow;
            if (aux != null)
            {
                estadoComponentes(TipoVista.Vista);
                string descripcion = ((GridCell)(((GridRow)dgvAuxiliar.PrimaryGrid.ActiveRow)[0])).Value.ToString();
                int activo = int.Parse(((GridCell)(((GridRow)dgvAuxiliar.PrimaryGrid.ActiveRow)[1])).Value.ToString());
                string codTabla = ((GridCell)(((GridRow)dgvAuxiliar.PrimaryGrid.ActiveRow)[2])).Value.ToString();
                auxiliar.IdAuxiliar = int.Parse(((GridCell)(((GridRow)dgvAuxiliar.PrimaryGrid.ActiveRow)[3])).Value.ToString());
                chbActivo.Checked = (activo == 1) ? true : false;
                txtDescripcion.Text = descripcion;
            }
        }
    }
}
