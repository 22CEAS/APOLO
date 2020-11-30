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
    public partial class frmArchivoCrearTarjetaVideo : Form
    {
        public enum TipoVista { Inicial, Nuevo, Modificar, Guardar, Vista, Limpiar, Duplicar, Anular }
        DataTable tablaVideo;
        DataTable tablaMarca;
        DataTable tablaModelo;
        DataTable tablaTipo;
        DataTable tablaCapacidad;
        Video video;
        Video videoOld;
        VideoDA videoDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";
        private string videoTipo = "VIDEO_TIPO";
        private string videoCapacidad = "VIDEO_CAPACIDAD";
        private int videoIdCategoria= 11;


        public frmArchivoCrearTarjetaVideo()
        {
            InitializeComponent();
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public frmArchivoCrearTarjetaVideo(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        public void Inicializado()
        {

            videoDA = new VideoDA();
            video = new Video();
            tablaVideo = videoDA.ListarVideos();

            dgvVideo.PrimaryGrid.AutoGenerateColumns = false;
            dgvVideo.PrimaryGrid.DataSource = tablaVideo;

            tablaCapacidad = videoDA.ListarCapacidadVideo();
            cmbCapacidad.DataSource = tablaCapacidad;
            cmbCapacidad.DisplayMember = "descripcion";
            cmbCapacidad.ValueMember = "idAuxiliar";

            tablaTipo = videoDA.ListarTipoVideo();
            cmbTipo.DataSource = tablaTipo;
            cmbTipo.DisplayMember = "descripcion";
            cmbTipo.ValueMember = "idAuxiliar";

            //tablaModelo = videoDA.ListarModeloVideo();
            //cmbModelo.DataSource = tablaModelo;
            //cmbModelo.DisplayMember = "NombreModelo";
            //cmbModelo.ValueMember = "IdModelo";

            tablaMarca = videoDA.ListarMarcaVideo();
            cmbMarca.DataSource = tablaMarca ;
            cmbMarca.DisplayMember = "nombre";
            cmbMarca.ValueMember = "idMarca";

            //cmbMarca.SelectedIndex = 0;
            //int i = cmbMarca.SelectedIndex;

            //if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
            //{
            //    int idMarca = Convert.ToInt32(cmbMarca.SelectedValue.ToString());
            //    tablaModelo = ingresoDA.ListarModelos(idMarca);
            //    cmbModelo.DataSource = tablaModelo;
            //    cmbModelo.DisplayMember = "nombre";
            //    cmbModelo.ValueMember = "idModelo";
            //    cmbModelo.SelectedIndex = 0;
            //}


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
                    cmbModelo.Enabled = false;
                    cmbTipo.Enabled = false;
                    cmbMarca.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    video = new Video();
                    break;
                case TipoVista.Nuevo: //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    cmbCapacidad.Enabled = true;
                    cmbModelo.Enabled = true;
                    cmbTipo.Enabled = true;
                    cmbMarca.Enabled = true;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    video = new Video();
                    break;
                case TipoVista.Guardar: //ya esta listo
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    cmbCapacidad.Enabled = false;
                    cmbModelo.Enabled = false;
                    cmbTipo.Enabled = false;
                    cmbMarca.Enabled = false;
                    chbActivo.Enabled = false;
                    video = new Video();
                    dgvVideo.PrimaryGrid.DataSource = null;
                    tablaVideo = videoDA.ListarVideos();
                    dgvVideo.PrimaryGrid.DataSource = tablaVideo;
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
                    cmbModelo.Enabled = true;
                    cmbTipo.Enabled = true;
                    cmbMarca.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    video = new Video();
                    break;
                case TipoVista.Vista:
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    cmbCapacidad.Enabled = false;
                    cmbModelo.Enabled = false;
                    cmbTipo.Enabled = false;
                    cmbMarca.Enabled = false;
                    chbActivo.Enabled = false;
                    //limpiarComponentes();
                    video = new Video();
                    break;
                case TipoVista.Limpiar: //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = false;
                    cmbCapacidad.Enabled = false;
                    cmbModelo.Enabled = false;
                    cmbTipo.Enabled = false;
                    cmbMarca.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    video = new Video();
                    break;
                case TipoVista.Duplicar:  //ya esta
                    //Inicializado(idUsuario, nombreUsuario);
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnEditar.Enabled = false;
                    cmbCapacidad.Enabled = true;
                    cmbModelo.Enabled = true;
                    cmbTipo.Enabled = true;
                    cmbMarca.Enabled = true;
                    chbActivo.Enabled = true;
                    limpiarComponentes();
                    video = new Video();
                    break;
                case TipoVista.Anular:  //ya esta
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnEditar.Enabled = true;
                    cmbCapacidad.Enabled = false;
                    cmbModelo.Enabled = false;
                    cmbTipo.Enabled = false;
                    cmbMarca.Enabled = false;
                    chbActivo.Enabled = false;
                    limpiarComponentes();
                    video = new Video();
                    break;
            }
        }
        public void limpiarComponentes()
        {
            cmbTipo.SelectedIndex = -1;
            cmbModelo.SelectedIndex = -1;
            cmbMarca.SelectedIndex = -1;
            cmbCapacidad.SelectedIndex = -1;
            chbActivo.Checked = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                GridRow aux = (GridRow)dgvVideo.PrimaryGrid.ActiveRow;
                if (aux != null)
                {
                    estadoComponentes(TipoVista.Modificar);
                    videoOld = new Video();

                    video.IdVideo = int.Parse(((GridCell)(((GridRow)dgvVideo.PrimaryGrid.ActiveRow)[10])).Value.ToString());
                    int idTipo = int.Parse(((GridCell)(((GridRow)dgvVideo.PrimaryGrid.ActiveRow)[8])).Value.ToString());
                    int idCapacidad = int.Parse(((GridCell)(((GridRow)dgvVideo.PrimaryGrid.ActiveRow)[9])).Value.ToString());
                    int idModelo = int.Parse(((GridCell)(((GridRow)dgvVideo.PrimaryGrid.ActiveRow)[6])).Value.ToString());
                    int idMarca = int.Parse(((GridCell)(((GridRow)dgvVideo.PrimaryGrid.ActiveRow)[7])).Value.ToString());
                    int activo = int.Parse(((GridCell)(((GridRow)dgvVideo.PrimaryGrid.ActiveRow)[5])).Value.ToString());
                    cmbTipo.SelectedValue = idTipo;
                    cmbCapacidad.SelectedValue = idCapacidad;
                    cmbMarca.SelectedValue = idMarca;

                    int i = cmbMarca.SelectedIndex;
                    if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
                    {
                        tablaModelo = videoDA.ListarModeloVideo(idMarca);
                        cmbModelo.DataSource = (tablaModelo.Rows.Count > 0) ? tablaModelo : null;
                        cmbModelo.DisplayMember = "NombreModelo";
                        cmbModelo.ValueMember = "IdModelo";
                        cmbModelo.SelectedIndex = (tablaModelo.Rows.Count > 0) ? 0 : -1;
                    }

                    cmbModelo.SelectedValue = idModelo;
                    chbActivo.Checked = (activo == 1) ? true : false;



                    int indice;
                    indice = cmbModelo.SelectedIndex;
                    videoOld.Modelo.IdModelo = int.Parse(cmbModelo.SelectedValue.ToString());
                    //videoOld.Modelo.NombreModelo = tablaModelo.Rows[indice]["NombreModelo"].ToString();

                    indice = cmbMarca.SelectedIndex;
                    videoOld.Modelo.IdMarca = int.Parse(cmbMarca.SelectedValue.ToString());
                    //videoOld.Modelo.NombreMarca = tablaMarca.Rows[indice]["nombre"].ToString();


                    indice = cmbTipo.SelectedIndex;
                    videoOld.IdTipo = int.Parse(cmbTipo.SelectedValue.ToString());
                    //videoOld.Tipo = tablaTipo.Rows[indice]["descripcion"].ToString();

                    indice = cmbCapacidad.SelectedIndex;
                    videoOld.IdCapacidad = int.Parse(cmbCapacidad.SelectedValue.ToString());
                    //videoOld.Capacidad = Convert.ToInt32(tablaCapacidad.Rows[indice]["descripcion"].ToString());

                    videoOld.Estado = activo;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+" Comunicarse con tu soporte", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
            int k = cmbModelo.SelectedIndex;
            int l = cmbMarca.SelectedIndex;

            if (!(i >= 0 && j >= 0 && k >= 0 && l >= 0)) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                MessageBox.Show("No se puede crear un video si no\ntiene todas sus características completas.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            llenar_Datos_Video();
            if (video.IdVideo == 0)
            {
                if (MessageBox.Show("¿Estás seguro deseas Crear este tipo de Video?", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idVideo = videoDA.GuardarNuevoVideo(video, this.nombreUsuario);

                    if (idVideo > 0)
                    {
                        MessageBox.Show("Se guardó exitosamente el video con Código: VID-" + idVideo, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idVideo == 0)
                        MessageBox.Show("Ya existe un video con las mismas características", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No se pudo guardar el video", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {

                video.Estado = (chbActivo.Checked) ? 1 : 0;
                if ((video.Modelo.IdModelo == videoOld.Modelo.IdModelo && 
                    video.Modelo.IdMarca == videoOld.Modelo.IdMarca && 
                    video.IdCapacidad == videoOld.IdCapacidad && 
                    video.IdTipo == videoOld.IdTipo && 
                    video.Estado == videoOld.Estado))
                //if (disco == discoOld)
                {
                    //MessageBox.Show("Son identicos", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (MessageBox.Show("¿Estás seguro que desea Guardar los cambios?", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int idVideo;

                    if ((video.Modelo.IdModelo == videoOld.Modelo.IdModelo && 
                    video.Modelo.IdMarca == videoOld.Modelo.IdMarca && 
                    video.IdCapacidad == videoOld.IdCapacidad && 
                    video.IdTipo == videoOld.IdTipo && 
                    video.Estado != videoOld.Estado))
                    //if(disco==discoOld)
                    {
                        idVideo = videoDA.ModificarVideo(video, this.nombreUsuario, 1);
                    }
                    else
                    {
                        idVideo = videoDA.ModificarVideo(video, this.nombreUsuario, 0);
                    }

                    if (idVideo > 0)
                    {
                        MessageBox.Show("Se Modificó el video con Código : VID-" + video.IdVideo + " con éxito", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        estadoComponentes(TipoVista.Guardar);
                    }
                    else if (idVideo == 0)
                        MessageBox.Show("Ya existe un video con las mismas características", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No se pudo guardar los cambios del video", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                }
            }

            Cursor.Current = Cursors.Default;

        }
        private void llenar_Datos_Video()
        {
            int indice;
            indice = cmbModelo.SelectedIndex;
            video.Modelo.IdModelo = int.Parse(cmbModelo.SelectedValue.ToString());
            video.Modelo.NombreModelo = tablaModelo.Rows[indice]["NombreModelo"].ToString();

            indice = cmbMarca.SelectedIndex;
            video.Modelo.IdMarca = int.Parse(cmbMarca.SelectedValue.ToString());
            video.Modelo.NombreMarca = tablaMarca.Rows[indice]["nombre"].ToString();


            indice = cmbTipo.SelectedIndex;
            video.IdTipo = int.Parse(cmbTipo.SelectedValue.ToString());
            video.Tipo = tablaTipo.Rows[indice]["descripcion"].ToString();

            indice = cmbCapacidad.SelectedIndex;
            video.IdCapacidad = int.Parse(cmbCapacidad.SelectedValue.ToString());
            video.Capacidad = Convert.ToInt32(tablaCapacidad.Rows[indice]["descripcion"].ToString());

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estadoComponentes(TipoVista.Anular);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea Imprimir la lista de Videos", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                MessageBox.Show("Se imprimio la lista de Videos");
            }
        }


        private void dgvVideo_Click(object sender, EventArgs e)
        {
            GridRow aux = (GridRow)dgvVideo.PrimaryGrid.ActiveRow;
            if (aux != null)
            {
                estadoComponentes(TipoVista.Vista);
                video.IdVideo = int.Parse(((GridCell)(((GridRow)dgvVideo.PrimaryGrid.ActiveRow)[10])).Value.ToString());
                int idTipo = int.Parse(((GridCell)(((GridRow)dgvVideo.PrimaryGrid.ActiveRow)[8])).Value.ToString());
                int idCapacidad = int.Parse(((GridCell)(((GridRow)dgvVideo.PrimaryGrid.ActiveRow)[9])).Value.ToString());
                int idModelo = int.Parse(((GridCell)(((GridRow)dgvVideo.PrimaryGrid.ActiveRow)[6])).Value.ToString());
                int idMarca = int.Parse(((GridCell)(((GridRow)dgvVideo.PrimaryGrid.ActiveRow)[7])).Value.ToString());
                int activo = int.Parse(((GridCell)(((GridRow)dgvVideo.PrimaryGrid.ActiveRow)[5])).Value.ToString());
                cmbTipo.SelectedValue = idTipo;
                cmbCapacidad.SelectedValue = idCapacidad;
                cmbMarca.SelectedValue = idMarca;

                int i = cmbMarca.SelectedIndex;
                if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
                {
                    tablaModelo = videoDA.ListarModeloVideo(idMarca);
                    cmbModelo.DataSource = (tablaModelo.Rows.Count > 0) ? tablaModelo : null;
                    cmbModelo.DisplayMember = "NombreModelo";
                    cmbModelo.ValueMember = "IdModelo";
                    cmbModelo.SelectedIndex = (tablaModelo.Rows.Count > 0) ? 0 : -1;
                }

                cmbModelo.SelectedValue = idModelo;
                chbActivo.Checked = (activo == 1) ? true : false;
            }
        }

        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbMarca.SelectedIndex;
            if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                int idMarca = Convert.ToInt32(tablaMarca.Rows[i]["idMarca"].ToString());
                tablaModelo = videoDA.ListarModeloVideo(idMarca);
                cmbModelo.DataSource = (tablaModelo.Rows.Count > 0) ? tablaModelo : null;
                cmbModelo.DisplayMember = "NombreModelo";
                cmbModelo.ValueMember = "IdModelo";
                cmbModelo.SelectedIndex = (tablaModelo.Rows.Count > 0) ? 0 : -1;
            }
        }

        private void btnAgregarCapacidadVideo_Click(object sender, EventArgs e)
        {
            frmArchivoAuxiliar frmBP = new frmArchivoAuxiliar(this.idUsuario, this.nombreUsuario, this.videoCapacidad);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
            }
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        private void btnAgregarTipoVideo_Click(object sender, EventArgs e)
        {
            frmArchivoAuxiliar frmBP = new frmArchivoAuxiliar(this.idUsuario, this.nombreUsuario, this.videoTipo);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
            }
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }

        private void btnAgregarModeloVideo_Click(object sender, EventArgs e)
        {
            frmArchivoModelo frmBP = new frmArchivoModelo(this.idUsuario, this.nombreUsuario, this.videoIdCategoria);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
            }
            Inicializado();
            estadoComponentes(TipoVista.Inicial);

        }

        private void btnAgregarMarcaVideo_Click(object sender, EventArgs e)
        {
            frmArchivoMarca frmBP = new frmArchivoMarca(this.idUsuario, this.nombreUsuario, this.videoIdCategoria);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
            }
            Inicializado();
            estadoComponentes(TipoVista.Inicial);
        }
    }
}
