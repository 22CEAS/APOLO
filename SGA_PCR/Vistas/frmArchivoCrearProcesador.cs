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
    public partial class frmArchivoCrearProcesador : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }

        DataTable tablaProcesador;
        DataTable tablaTipo;
        DataTable tablaMarca;
        DataTable tablaGeneracion;
        DataView viewTipo;
        //DataTable tablaVelocidad;
        //DataTable tablaVelocidadMax;

        Procesador procesador;
        Procesador procesadorOld;

        ProcesadorDA procesadorDA;

        private int idUsuario;
        private string nombreUsuario = "CEAS";

        private string procesadorGeneracion = "PROCESADOR_GENERACION";
        private int procesadorIdCategoria = 9;

        public frmArchivoCrearProcesador()
        {
            InitializeComponent();
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public frmArchivoCrearProcesador(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public void Inicializado()
        {

            procesadorDA = new ProcesadorDA();
            procesador = new Procesador();
            tablaProcesador = procesadorDA.ListarProcesadores();

            dgvProcesadores.PrimaryGrid.AutoGenerateColumns = false;
            dgvProcesadores.PrimaryGrid.DataSource = tablaProcesador;

            tablaMarca = procesadorDA.ListarMarcaProcesadores();
            cmbMarca.DataSource = tablaMarca;
            cmbMarca.DisplayMember = "Nombre";
            cmbMarca.ValueMember = "IdMarca";

            tablaTipo = procesadorDA.ListarTipoProcesadores();

            tablaGeneracion = procesadorDA.ListarProcesadorGeneracion();
            cmbGeneracion.DataSource = tablaGeneracion;
            cmbGeneracion.DisplayMember = "descripcion";
            cmbGeneracion.ValueMember = "idAuxiliar";

            //tablaVelocidad = procesadorDA.ListarProcesadorVelocidad();
            //cmbVelocidad.DataSource = tablaVelocidad;
            //cmbVelocidad.DisplayMember = "descripcion";
            //cmbVelocidad.ValueMember = "idAuxiliar";

            //tablaVelocidadMax = procesadorDA.ListarProcesadorVelocidadMax();
            //cmbVelocidadMax.DataSource = tablaVelocidadMax;
            //cmbVelocidadMax.DisplayMember = "descripcion";
            //cmbVelocidadMax.ValueMember = "idAuxiliar";
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
                    //cmbVelocidadMax.Enabled = false;
                    //cmbVelocidad.Enabled = false;
                    cmbGeneracion.Enabled = false;
                    cmbMarca.Enabled = false;
                    cmbTipo.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    procesador = new Procesador();
                    break;
                case TipoVista.Nuevo: //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    //cmbVelocidadMax.Enabled = true;
                    //cmbVelocidad.Enabled = true;
                    cmbGeneracion.Enabled = true;
                    cmbTipo.Enabled = true;
                    cmbMarca.Enabled = true;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    procesador = new Procesador();
                    break;
                case TipoVista.Guardar: //ya esta listo
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    //cmbVelocidadMax.Enabled = false;
                    //cmbVelocidad.Enabled = false;
                    cmbGeneracion.Enabled = false;
                    cmbTipo.Enabled = false;
                    cmbMarca.Enabled = false;
                    chbActivo.Enabled = false;
                    procesador = new Procesador();
                    dgvProcesadores.PrimaryGrid.DataSource = null;
                    tablaProcesador = procesadorDA.ListarProcesadores();
                    dgvProcesadores.PrimaryGrid.DataSource = tablaProcesador;
                    //limpiarComponentes();
                    break;
                case TipoVista.Modificar://ya esta
                                         //Inicializado(idUsuario, nombreUsuario);

                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    //cmbVelocidadMax.Enabled = true;
                    //cmbVelocidad.Enabled = true;
                    cmbGeneracion.Enabled = true;
                    cmbTipo.Enabled = true;
                    cmbMarca.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    procesador = new Procesador();
                    break;
                case TipoVista.Vista:
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    //cmbVelocidadMax.Enabled = false;
                    //cmbVelocidad.Enabled = false;
                    cmbGeneracion.Enabled = false;
                    cmbTipo.Enabled = false;
                    cmbMarca.Enabled = false;
                    chbActivo.Enabled = false;
                    //limpiarComponentes();
                    procesador = new Procesador();
                    break;
                case TipoVista.Limpiar: //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    //cmbVelocidadMax.Enabled = false;
                    //cmbVelocidad.Enabled = false;
                    cmbGeneracion.Enabled = false;
                    cmbTipo.Enabled = false;
                    cmbMarca.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    procesador = new Procesador();
                    break;
                case TipoVista.Duplicar:  //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    //cmbVelocidadMax.Enabled = true;
                    //cmbVelocidad.Enabled = true;
                    cmbGeneracion.Enabled = true;
                    cmbTipo.Enabled = true;
                    cmbMarca.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    procesador = new Procesador();
                    break;
                case TipoVista.Anular:  //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    //cmbVelocidadMax.Enabled = false;
                    //cmbVelocidad.Enabled = false;
                    cmbGeneracion.Enabled = false;
                    cmbTipo.Enabled = false;
                    cmbMarca.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    procesador = new Procesador();
                    break;
            }
        }

        public void limpiarComponentes()
        {
            cmbTipo.SelectedIndex = -1;
            cmbGeneracion.SelectedIndex = -1;
            cmbMarca.SelectedIndex = -1;
            //cmbVelocidad.SelectedIndex = -1;
            //cmbVelocidadMax.SelectedIndex = -1;
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
                GridRow aux = (GridRow)dgvProcesadores.PrimaryGrid.ActiveRow;
                if (aux != null)
                {
                    estadoComponentes(TipoVista.Modificar);
                    procesadorOld = new Procesador();


                    procesador.IdProcesador = int.Parse(((GridCell)(((GridRow)dgvProcesadores.PrimaryGrid.ActiveRow)[4])).Value.ToString());
                    int idTipo = int.Parse(((GridCell)(((GridRow)dgvProcesadores.PrimaryGrid.ActiveRow)[5])).Value.ToString());
                    int idMarca = int.Parse(((GridCell)(((GridRow)dgvProcesadores.PrimaryGrid.ActiveRow)[7])).Value.ToString());
                    //int idVelocidad = int.Parse(((GridCell)(((GridRow)dgvProcesadores.PrimaryGrid.ActiveRow)[8])).Value.ToString());
                    //int idVelocidadMax = int.Parse(((GridCell)(((GridRow)dgvProcesadores.PrimaryGrid.ActiveRow)[9])).Value.ToString());
                    int idGeneracion = int.Parse(((GridCell)(((GridRow)dgvProcesadores.PrimaryGrid.ActiveRow)[6])).Value.ToString());
                    int activo = int.Parse(((GridCell)(((GridRow)dgvProcesadores.PrimaryGrid.ActiveRow)[3])).Value.ToString());
                    cmbMarca.SelectedValue = idMarca;
                    int auxTry= int.Parse(cmbMarca.SelectedValue.ToString());
                    //cmbVelocidad.SelectedValue = idVelocidad;
                    //cmbVelocidadMax.SelectedValue = idVelocidadMax;
                    cmbGeneracion.SelectedValue = idGeneracion;
                    chbActivo.Checked = (activo == 1) ? true : false;

                    int i = cmbMarca.SelectedIndex;
                    if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
                    {
                        viewTipo = new DataView(tablaTipo);
                        viewTipo.RowFilter = "idMarca = " + idMarca.ToString();
                        cmbTipo.DataSource = (viewTipo.Count > 0) ? viewTipo : null;
                        cmbTipo.DisplayMember = "nombre";
                        cmbTipo.ValueMember = "idModelo";
                        cmbTipo.SelectedIndex = (viewTipo.Count > 0) ? 0 : -1;
                    }
                    cmbTipo.SelectedValue = idTipo;


                    int indice;
                    indice = cmbTipo.SelectedIndex;
                    procesadorOld.Modelo.IdModelo = int.Parse(cmbTipo.SelectedValue.ToString());
                    //procesadorOld.Modelo.NombreModelo = tablaTipo.Rows[indice]["nombre"].ToString();

                    indice = cmbGeneracion.SelectedIndex;
                    procesadorOld.IdGeneracion = int.Parse(cmbGeneracion.SelectedValue.ToString());
                    //procesadorOld.Generacion = Convert.ToInt32(tablaGeneracion.Rows[indice]["descripcion"].ToString());

                    //indice = cmbVelocidad.SelectedIndex;
                    //procesadorOld.IdVelocidad = int.Parse(cmbVelocidad.SelectedValue.ToString());
                    //procesadorOld.Velocidad = tablaVelocidad.Rows[indice]["descripcion"].ToString();

                    //indice = cmbVelocidadMax.SelectedIndex;
                    //procesadorOld.IdVelocidadMax = int.Parse(cmbVelocidadMax.SelectedValue.ToString());
                    //procesadorOld.VelocidadMax = Convert.ToDouble(tablaVelocidadMax.Rows[indice]["descripcion"].ToString());

                    procesadorOld.Estado = activo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                estadoComponentes(TipoVista.Anular);
                return;
            }
            
        }

        private void llenar_Datos_Procesador()
        {
            int indice;
            indice = cmbTipo.SelectedIndex;
            procesador.Modelo.IdModelo = int.Parse(cmbTipo.SelectedValue.ToString());
            procesador.Modelo.NombreModelo = tablaTipo.Rows[indice]["nombre"].ToString();

            indice = cmbGeneracion.SelectedIndex;
            procesador.IdGeneracion = int.Parse(cmbGeneracion.SelectedValue.ToString());
            procesador.Generacion = Convert.ToInt32(tablaGeneracion.Rows[indice]["descripcion"].ToString());

            indice = cmbMarca.SelectedIndex;
            procesador.Modelo.IdMarca = int.Parse(cmbMarca.SelectedValue.ToString());
            procesador.Modelo.NombreMarca = tablaMarca.Rows[indice]["nombre"].ToString();

            //indice = cmbVelocidad.SelectedIndex;
            //procesador.IdVelocidad = int.Parse(cmbVelocidad.SelectedValue.ToString());
            //procesador.Velocidad = tablaVelocidad.Rows[indice]["descripcion"].ToString();

            //indice = cmbVelocidadMax.SelectedIndex;
            //procesador.IdVelocidadMax = int.Parse(cmbVelocidadMax.SelectedValue.ToString());
            //procesador.VelocidadMax = Convert.ToDouble(tablaVelocidadMax.Rows[indice]["descripcion"].ToString());

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int i = cmbTipo.SelectedIndex;
            int j = cmbGeneracion.SelectedIndex;
            int z = cmbMarca.SelectedIndex;
            //int k = cmbVelocidad.SelectedIndex;
            //int l = cmbVelocidadMax.SelectedIndex;

            //if (!(i >= 0 && j >= 0 && k >= 0 && l >= 0)) //Esto verifica que se ha seleccionado algún item del comboBox
            if (!(i >= 0 && j >= 0 && z >= 0))
            {
                MessageBox.Show("No se puede crear un procesador si no\ntiene todas sus características completas.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            llenar_Datos_Procesador();
            if (procesador.IdProcesador == 0)
            {
                if (MessageBox.Show("¿Estás seguro que deseas Crear este tipo de Procesador?", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idProcesador = procesadorDA.GuardarNuevoProcesador(procesador, this.nombreUsuario);

                    if (idProcesador > 0)
                    {
                        MessageBox.Show("Se guardó exitosamente el procesador con Código: PRO-" + idProcesador, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idProcesador == 0)
                        MessageBox.Show("Ya existe un procesador con las mismas características", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No se pudo guardar el procesador", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {

                procesador.Estado = (chbActivo.Checked) ? 1 : 0;
                //if ((procesador.Modelo.IdModelo == procesadorOld.Modelo.IdModelo && procesador.Modelo.NombreModelo == procesadorOld.Modelo.NombreModelo &&
                //    procesador.IdGeneracion == procesadorOld.IdGeneracion && procesador.Generacion == procesadorOld.Generacion &&
                //    procesador.IdVelocidad == procesadorOld.IdVelocidad && procesador.Velocidad == procesadorOld.Velocidad &&
                //    procesador.IdVelocidadMax == procesadorOld.IdVelocidadMax && procesador.VelocidadMax == procesadorOld.VelocidadMax &&
                //    procesador.Estado == procesadorOld.Estado))
                if ((procesador.Modelo.IdModelo == procesadorOld.Modelo.IdModelo &&
                    procesador.IdGeneracion == procesadorOld.IdGeneracion &&
                    procesador.Estado == procesadorOld.Estado))
                //if (disco == discoOld)
                {
                    //MessageBox.Show("Son identicos", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (MessageBox.Show("¿Estás seguro que desea Guardar los cambios?", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idProcesador;

                    //if ((procesador.Modelo.IdModelo == procesadorOld.Modelo.IdModelo && procesador.Modelo.NombreModelo == procesadorOld.Modelo.NombreModelo &&
                    //procesador.IdGeneracion == procesadorOld.IdGeneracion && procesador.Generacion == procesadorOld.Generacion &&
                    //procesador.IdVelocidad == procesadorOld.IdVelocidad && procesador.Velocidad == procesadorOld.Velocidad &&
                    //procesador.IdVelocidadMax == procesadorOld.IdVelocidadMax && procesador.VelocidadMax == procesadorOld.VelocidadMax &&
                    //procesador.Estado != procesadorOld.Estado))
                    if ((procesador.Modelo.IdModelo == procesadorOld.Modelo.IdModelo &&
                        procesador.IdGeneracion == procesadorOld.IdGeneracion &&
                        procesador.Estado != procesadorOld.Estado))
                    //if(disco==discoOld)
                    {
                        idProcesador = procesadorDA.ModificarProcesador(procesador, this.nombreUsuario, 1);
                    }
                    else
                    {
                        idProcesador = procesadorDA.ModificarProcesador(procesador, this.nombreUsuario, 0);
                    }

                    if (idProcesador > 0)
                    {
                        MessageBox.Show("Se Modificó el procesador con Código : PRO-" + procesador.IdProcesador + " con éxito", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idProcesador == 0)
                        MessageBox.Show("Ya existe un procesador con las mismas características", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No se pudo guardar los cambios del procesador", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

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
            if (MessageBox.Show("Estas seguro que desea Imprimir la lista de Procesadores", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                MessageBox.Show("Se imprimió la lista de Procesadores");
            }
        }

        private void dgvProcesadores_Click(object sender, EventArgs e)
        {
            GridRow aux = (GridRow)dgvProcesadores.PrimaryGrid.ActiveRow;
            if (aux != null)
            {
                estadoComponentes(TipoVista.Vista);
                procesador.IdProcesador = int.Parse(((GridCell)(((GridRow)dgvProcesadores.PrimaryGrid.ActiveRow)[4])).Value.ToString());
                int idTipo = int.Parse(((GridCell)(((GridRow)dgvProcesadores.PrimaryGrid.ActiveRow)[5])).Value.ToString());
                int idMarca = int.Parse(((GridCell)(((GridRow)dgvProcesadores.PrimaryGrid.ActiveRow)[7])).Value.ToString());
                //int idVelocidad = int.Parse(((GridCell)(((GridRow)dgvProcesadores.PrimaryGrid.ActiveRow)[8])).Value.ToString());
                //int idVelocidadMax = int.Parse(((GridCell)(((GridRow)dgvProcesadores.PrimaryGrid.ActiveRow)[9])).Value.ToString());
                int idGeneracion = int.Parse(((GridCell)(((GridRow)dgvProcesadores.PrimaryGrid.ActiveRow)[6])).Value.ToString());
                int activo = int.Parse(((GridCell)(((GridRow)dgvProcesadores.PrimaryGrid.ActiveRow)[3])).Value.ToString());
                cmbMarca.SelectedValue = idMarca;
                cmbTipo.SelectedValue = idTipo;
                //cmbVelocidad.SelectedValue = idVelocidad;
                //cmbVelocidadMax.SelectedValue = idVelocidadMax;
                cmbGeneracion.SelectedValue = idGeneracion;
                chbActivo.Checked = (activo == 1) ? true : false;

                int i = cmbMarca.SelectedIndex;
                if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
                {
                    viewTipo = new DataView(tablaTipo);
                    viewTipo.RowFilter = "idMarca = " + idMarca.ToString();                    
                    cmbTipo.DataSource = (viewTipo.Count > 0) ? viewTipo : null;
                    cmbTipo.DisplayMember = "nombre";
                    cmbTipo.ValueMember = "idModelo";
                    cmbTipo.SelectedIndex = (viewTipo.Count > 0) ? 0 : -1;
                }
                cmbTipo.SelectedValue = idTipo;
            }
        }


        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbMarca.SelectedIndex;
            if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                int idMarca = Convert.ToInt32(tablaMarca.Rows[i]["idMarca"].ToString());
                viewTipo = new DataView(tablaTipo);
                viewTipo.RowFilter = "idMarca = " + idMarca.ToString();
                cmbTipo.DataSource = (viewTipo.Count > 0) ? viewTipo : null;
                cmbTipo.DisplayMember = "nombre";
                cmbTipo.ValueMember = "idModelo";
                cmbTipo.SelectedIndex = (viewTipo.Count > 0) ? 0 : -1;
            }
        }

        private void btnAgregarTipoProcesador_Click(object sender, EventArgs e)
        {
            frmArchivoModelo frmBP = new frmArchivoModelo(this.idUsuario, this.nombreUsuario, this.procesadorIdCategoria);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
            }
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        private void btnAgregarMarcaProcesador_Click(object sender, EventArgs e)
        {
            frmArchivoMarca frmBP = new frmArchivoMarca(this.idUsuario, this.nombreUsuario, this.procesadorIdCategoria);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
            }
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        private void btnAgregarGeneracionProcesador_Click(object sender, EventArgs e)
        {
            frmArchivoAuxiliar frmBP = new frmArchivoAuxiliar(this.idUsuario, this.nombreUsuario, this.procesadorGeneracion);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
            }
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }
    }
}
