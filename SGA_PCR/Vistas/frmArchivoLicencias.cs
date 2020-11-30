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

    public partial class frmArchivoLicencias : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaModelo;
        DataTable tablaMarca;
        DataView viewModelo;

        Marca marca;
        Modelo.Modelo modelo;
        Modelo.Modelo modeloOld;
        MarcaDA marcaDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";
        
        private int idCategoriaSO = 12;
        private int idCategoriaOffice = 13;
        private int idCategoriaAntivirus = 14;

        public frmArchivoLicencias()
        {
            InitializeComponent();
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public frmArchivoLicencias(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public void Inicializado()
        {
            marcaDA = new MarcaDA();
            modelo = new Modelo.Modelo();
            marca = new Marca();
            tablaModelo = marcaDA.ListarModelos();
            tablaMarca = marcaDA.ListarMarcas(this.idCategoriaSO, this.idCategoriaOffice, this.idCategoriaAntivirus);

            viewModelo = new DataView(tablaModelo);


            cmbMarca.DataSource = tablaMarca;
            cmbMarca.DisplayMember = "nombre";
            cmbMarca.ValueMember = "idMarca";
            cmbMarca.SelectedIndex = -1;

            dgvModelo.PrimaryGrid.DataSource = null;
            dgvModelo.PrimaryGrid.AutoGenerateColumns = false;
            
        }
        public void estadoComponentes(TipoVista estado)
        {
            switch (estado)
            {
                case TipoVista.Inicial: //ya esta

                    btnNuevo.Enabled = (cmbMarca.SelectedIndex != -1) ? true : false;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = (cmbMarca.SelectedIndex != -1) ? true : false;
                    txtDescripcion.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    modelo = new Modelo.Modelo();
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
                    modelo = new Modelo.Modelo();
                    break;
                case TipoVista.Guardar: //ya esta listo
                    btnNuevo.Enabled = (cmbMarca.SelectedIndex != -1) ? true : false;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = (cmbMarca.SelectedIndex != -1) ? true : false;
                    txtDescripcion.Enabled = false;
                    chbActivo.Enabled = false;
                    modelo = new Modelo.Modelo();
                    actualizarGrid();
                    break;
                case TipoVista.Modificar:
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    txtDescripcion.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    modelo = new Modelo.Modelo();
                    break;
                case TipoVista.Vista:
                    btnNuevo.Enabled = (cmbMarca.SelectedIndex != -1) ? true : false;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = (cmbMarca.SelectedIndex != -1) ? true : false;
                    txtDescripcion.Enabled = false;
                    chbActivo.Enabled = false;
                    //limpiarComponentes();
                    modelo = new Modelo.Modelo();
                    break;
                case TipoVista.Limpiar: //ya esta
                    btnNuevo.Enabled = (cmbMarca.SelectedIndex != -1) ? true : false;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    txtDescripcion.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    modelo = new Modelo.Modelo();
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
                    modelo = new Modelo.Modelo();
                    break;
                case TipoVista.Anular:  //ya esta
                    btnNuevo.Enabled = (cmbMarca.SelectedIndex != -1) ? true : false;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = (cmbMarca.SelectedIndex != -1) ? true : false;
                    txtDescripcion.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    modelo = new Modelo.Modelo();
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
            GridRow aux = (GridRow)dgvModelo.PrimaryGrid.ActiveRow;
            if (aux != null)
            {
                estadoComponentes(TipoVista.Modificar);
                modeloOld = new Modelo.Modelo();

                modelo.IdModelo = int.Parse(((GridCell)(((GridRow)dgvModelo.PrimaryGrid.ActiveRow)[3])).Value.ToString());
                string descripcion = ((GridCell)(((GridRow)dgvModelo.PrimaryGrid.ActiveRow)[0])).Value.ToString();
                int activo = int.Parse(((GridCell)(((GridRow)dgvModelo.PrimaryGrid.ActiveRow)[1])).Value.ToString());
                modelo.IdMarca = int.Parse(((GridCell)(((GridRow)dgvModelo.PrimaryGrid.ActiveRow)[2])).Value.ToString());
                chbActivo.Checked = (activo == 1) ? true : false;
                txtDescripcion.Text = descripcion;

                modeloOld.NombreModelo = descripcion.ToUpper();
                modeloOld.IdMarca = int.Parse(((GridCell)(((GridRow)dgvModelo.PrimaryGrid.ActiveRow)[2])).Value.ToString());
                modeloOld.Estado = activo;

            }
        }

        private void llenar_Modelos()
        {
            modelo.IdMarca = int.Parse(cmbMarca.SelectedValue.ToString());

            string aux = txtDescripcion.Text;
            aux = aux.Trim();
            aux = aux.ToUpper();
            modelo.NombreModelo = aux;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string aux = txtDescripcion.Text;
            aux = aux.Trim();
            if (aux.Length == 0)
            {
                MessageBox.Show("Rellene el campo vacio", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            llenar_Modelos();
            if (modelo.IdModelo == 0)
            {
                if (MessageBox.Show("¿Estás seguro que deseas Crear esta nueva descripción?", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idModelo = marcaDA.GuardarNuevoModelo(modelo, this.nombreUsuario);

                    if (idModelo > 0)
                    {
                        MessageBox.Show("Se guardó con éxito la Descripción ", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idModelo == 0)
                        MessageBox.Show("Ya existe una Descripcion con las mismas características", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No se pudo guardar esta Descripción", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                modelo.Estado = (chbActivo.Checked) ? 1 : 0;
                if ((modelo.NombreModelo == modeloOld.NombreModelo &&
                    modelo.Estado == modeloOld.Estado))
                {
                    //MessageBox.Show("Son identicos", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (MessageBox.Show("¿Estás seguro que desea Guardar los cambios?", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idModelo;

                    if ((modelo.NombreModelo == modeloOld.NombreModelo &&
                    modelo.Estado != modeloOld.Estado))
                    {
                        idModelo = marcaDA.ModificarModelo(modelo, this.nombreUsuario, 1);
                    }
                    else
                    {
                        idModelo = marcaDA.ModificarModelo(modelo, this.nombreUsuario, 0);
                    }

                    if (idModelo > 0)
                    {
                        MessageBox.Show("Se Modificó la descripción con éxito", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idModelo == 0)
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

        private void dgvModelo_Click(object sender, EventArgs e)
        {
            GridRow aux = (GridRow)dgvModelo.PrimaryGrid.ActiveRow;
            if (aux != null)
            {
                estadoComponentes(TipoVista.Vista);
                string descripcion = ((GridCell)(((GridRow)dgvModelo.PrimaryGrid.ActiveRow)[0])).Value.ToString();
                int activo = int.Parse(((GridCell)(((GridRow)dgvModelo.PrimaryGrid.ActiveRow)[1])).Value.ToString());
                modelo.IdMarca = int.Parse(((GridCell)(((GridRow)dgvModelo.PrimaryGrid.ActiveRow)[2])).Value.ToString());
                modelo.IdModelo = int.Parse(((GridCell)(((GridRow)dgvModelo.PrimaryGrid.ActiveRow)[3])).Value.ToString());
                chbActivo.Checked = (activo == 1) ? true : false;
                txtDescripcion.Text = descripcion;
            }
        }

        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbMarca.SelectedIndex;
            if (cmbMarca.SelectedIndex != -1)
            {
                //MessageBox.Show(cmbMarca.SelectedValue.ToString());
                //int idCliente = int.Parse(cmbMarca.SelectedValue.ToString());
                int idMarca = Convert.ToInt32(tablaMarca.Rows[i]["idMarca"].ToString());

                tablaModelo = marcaDA.ListarModelos();

                viewModelo = new DataView(tablaModelo);

                viewModelo.RowFilter = "idMarca = " + idMarca;
                dgvModelo.PrimaryGrid.AutoGenerateColumns = false;
                dgvModelo.PrimaryGrid.DataSource = viewModelo;

            }
            estadoComponentes(TipoVista.Inicial);
        }

        private void actualizarGrid()
        {
            int i = cmbMarca.SelectedIndex;
            if (cmbMarca.SelectedIndex != -1)
            {
                int idMatca = Convert.ToInt32(tablaMarca.Rows[i]["idMarca"].ToString());

                tablaModelo = marcaDA.ListarModelos();

                viewModelo = new DataView(tablaModelo);

                viewModelo.RowFilter = "idMarca = " + idMatca;
                dgvModelo.PrimaryGrid.AutoGenerateColumns = false;
                dgvModelo.PrimaryGrid.DataSource = viewModelo;

            }
            estadoComponentes(TipoVista.Inicial);
        }

    }
}
