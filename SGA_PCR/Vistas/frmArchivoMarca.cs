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
    public partial class frmArchivoMarca : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaMarca;
        DataView viewMarca;
        Marca marca;
        Marca marcaOld;
        MarcaDA marcaDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";
        private int idCategoria;

        public frmArchivoMarca()
        {
            InitializeComponent();
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public frmArchivoMarca(int idUsuario, string nombreUsuario, int idCategoria)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            this.idCategoria = idCategoria;
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public void Inicializado()
        {
            marcaDA = new MarcaDA();
            marca = new Marca();
            tablaMarca = marcaDA.ListarMarcas();
            viewMarca = new DataView(tablaMarca);

            viewMarca.RowFilter = "idCategoria = " + this.idCategoria ;

            dgvMarca.PrimaryGrid.AutoGenerateColumns = false;
            dgvMarca.PrimaryGrid.DataSource = viewMarca;

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
                    marca = new Marca();
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
                    marca = new Marca();
                    break;
                case TipoVista.Guardar: //ya esta listo
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    txtDescripcion.Enabled = false;
                    chbActivo.Enabled = false;
                    marca = new Marca();
                    dgvMarca.PrimaryGrid.DataSource = null;
                    tablaMarca = marcaDA.ListarMarcas();
                    viewMarca = new DataView(tablaMarca);
                    viewMarca.RowFilter = "idCategoria = " + this.idCategoria;
                    dgvMarca.PrimaryGrid.DataSource = viewMarca;
                    break;
                case TipoVista.Modificar:
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    txtDescripcion.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    marca = new Marca();
                    break;
                case TipoVista.Vista:
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    txtDescripcion.Enabled = false;
                    chbActivo.Enabled = false;
                    //limpiarComponentes();
                    marca = new Marca();
                    break;
                case TipoVista.Limpiar: //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    txtDescripcion.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    marca = new Marca();
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
                    marca = new Marca();
                    break;
                case TipoVista.Anular:  //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    txtDescripcion.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    marca = new Marca();
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
            GridRow aux = (GridRow)dgvMarca.PrimaryGrid.ActiveRow;
            if (aux != null)
            {
                estadoComponentes(TipoVista.Modificar);
                marcaOld = new Marca();

                marca.IdMarca = int.Parse(((GridCell)(((GridRow)dgvMarca.PrimaryGrid.ActiveRow)[3])).Value.ToString());
                string descripcion = ((GridCell)(((GridRow)dgvMarca.PrimaryGrid.ActiveRow)[0])).Value.ToString();
                int activo = int.Parse(((GridCell)(((GridRow)dgvMarca.PrimaryGrid.ActiveRow)[1])).Value.ToString());
                marca.IdCategoria = int.Parse(((GridCell)(((GridRow)dgvMarca.PrimaryGrid.ActiveRow)[2])).Value.ToString());
                chbActivo.Checked = (activo == 1) ? true : false;
                txtDescripcion.Text = descripcion;

                marcaOld.NombreMarca = descripcion.ToUpper();
                marcaOld.IdCategoria = idCategoria;
                marcaOld.Estado = activo;

            }
        }

        private void llenar_Marcas()
        {
            marca.IdCategoria = this.idCategoria;

            string aux = txtDescripcion.Text;
            aux = aux.Trim();
            aux = aux.ToUpper();
            marca.NombreMarca = aux;
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

            llenar_Marcas();
            if (marca.IdMarca == 0)
            {
                if (MessageBox.Show("¿Estás seguro que deseas Crear esta nueva descripción?", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idMarca = marcaDA.GuardarNuevaMarca(marca, this.nombreUsuario);

                    if (idMarca > 0)
                    {
                        MessageBox.Show("Se guardó con éxito la Descripción ", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idMarca == 0)
                        MessageBox.Show("Ya existe una Descripcion con las mismas características", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No se pudo guardar esta Descripción", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                marca.Estado = (chbActivo.Checked) ? 1 : 0;
                if ((marca.NombreMarca == marcaOld.NombreMarca &&
                    marca.Estado == marcaOld.Estado))
                {
                    //MessageBox.Show("Son identicos", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (MessageBox.Show("¿Estás seguro que desea Guardar los cambios?", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idMarca;

                    if ((marca.NombreMarca == marcaOld.NombreMarca &&
                    marca.Estado != marcaOld.Estado))
                    {
                        idMarca = marcaDA.ModificarMarca(marca, this.nombreUsuario, 1);
                    }
                    else
                    {
                        idMarca = marcaDA.ModificarMarca(marca, this.nombreUsuario, 0);
                    }

                    if (idMarca > 0)
                    {
                        MessageBox.Show("Se Modificó la descripción con éxito", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idMarca == 0)
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

        private void dgvMarca_Click(object sender, EventArgs e)
        {
            GridRow aux = (GridRow)dgvMarca.PrimaryGrid.ActiveRow;
            if (aux != null)
            {
                estadoComponentes(TipoVista.Vista);
                string descripcion = ((GridCell)(((GridRow)dgvMarca.PrimaryGrid.ActiveRow)[0])).Value.ToString();
                int activo = int.Parse(((GridCell)(((GridRow)dgvMarca.PrimaryGrid.ActiveRow)[1])).Value.ToString());
                marca.IdCategoria = int.Parse(((GridCell)(((GridRow)dgvMarca.PrimaryGrid.ActiveRow)[2])).Value.ToString());
                marca.IdMarca = int.Parse(((GridCell)(((GridRow)dgvMarca.PrimaryGrid.ActiveRow)[3])).Value.ToString());
                chbActivo.Checked = (activo == 1) ? true : false;
                txtDescripcion.Text = descripcion;
            }
        }
    }
}
