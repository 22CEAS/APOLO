using AccesoDatos;
using DevComponents.DotNetBar.SuperGrid;
using Modelo;
using SpreadsheetLight;
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
    public partial class frmProcesoIngresoLaptopCpu : Form
    {
        DataTable tablaMarca;
        DataTable tablaModelo;
        DataTable tablaDestino;
        DataTable tablaProcesador;
        DataTable tablaMemoria;
        DataTable tablaDisco;
        DataTable tablaVideo;
        DataTable tablaLicencia;
        IngresoDetalle detalle;

        IngresoDA ingresoDA;
        LC laptop;
        Procesador procesador;
        Video video;
        DiscoDuro disco;
        Memoria memoria;
        Licencia licencia;

        Boolean permitir = true;

        private int idUsuario;
        private string nombreUsuario = "CEAS";

        private string LicenciaSO = "S.O";

        private int laptopIdCategoria = 1;

        public frmProcesoIngresoLaptopCpu(string tipoIngreso)
        {
            InitializeComponent();
            Inicializado();

            if (tipoIngreso == "1")
            {
                dgvSerieFabrica.Columns[1].HeaderText = "Codigo Laptop";              
            }
        }

        public frmProcesoIngresoLaptopCpu(IngresoDetalle detalleTraido)
        {
            InitializeComponent();
            Inicializado();
            
            ObtenerListaLaptops(detalleTraido);
        }


        public void Inicializado()
        {
            ingresoDA = new IngresoDA();
            laptop = new LC();
            detalle = new IngresoDetalle();

            txtCantidad.Text = "1";

            tablaProcesador = ingresoDA.ListarProcesadores();
            dgvProcesador.PrimaryGrid.AutoGenerateColumns = false;
            dgvProcesador.PrimaryGrid.DataSource = tablaProcesador;

            tablaMemoria = ingresoDA.ListarMemorias();
            dgvMemoria.PrimaryGrid.AutoGenerateColumns = false;
            dgvMemoria.PrimaryGrid.DataSource = tablaMemoria;

            tablaDisco = ingresoDA.ListarDiscosDuros();
            dgvDiscoDuro.PrimaryGrid.AutoGenerateColumns = false;
            dgvDiscoDuro.PrimaryGrid.DataSource = tablaDisco;

            tablaVideo = ingresoDA.ListarTarjetaVideos();
            dgvVideo.PrimaryGrid.AutoGenerateColumns = false;
            dgvVideo.PrimaryGrid.DataSource = tablaVideo;

            tablaLicencia = ingresoDA.ListarLicencias();
            dgvLicencia.PrimaryGrid.AutoGenerateColumns = false;
            dgvLicencia.PrimaryGrid.DataSource = tablaLicencia;

            tablaMarca = ingresoDA.ListarMarcas();
            cmbMarca.DataSource = tablaMarca;
            cmbMarca.DisplayMember = "nombre";
            cmbMarca.ValueMember = "idMarca";
            cmbMarca.SelectedIndex = 0;
            int i = cmbMarca.SelectedIndex;

            if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                int idMarca = Convert.ToInt32(cmbMarca.SelectedValue.ToString());
                tablaModelo = ingresoDA.ListarModelos(idMarca);
                cmbModelo.DataSource = tablaModelo;
                cmbModelo.DisplayMember = "nombre";
                cmbModelo.ValueMember = "idModelo";
                cmbModelo.SelectedIndex = 0;
            }
            //tablaDestino = ingresoDA.ListarDestinos();
            //cmbDestino.DataSource = tablaDestino;
            //cmbDestino.DisplayMember = "nombre";
            //cmbDestino.ValueMember = "idDestino";


            

        }


        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbMarca.SelectedIndex;
            if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                int idMarca = Convert.ToInt32(tablaMarca.Rows[i]["idMarca"].ToString());
                tablaModelo = ingresoDA.ListarModelos(idMarca);
                cmbModelo.DataSource = (tablaModelo.Rows.Count > 0) ? tablaModelo : null;
                cmbModelo.DisplayMember = "nombre";
                cmbModelo.ValueMember = "idModelo";
                cmbModelo.SelectedIndex = (tablaModelo.Rows.Count > 0) ? 0 : -1;
            }

        }

        public void ObtenerListaLaptops(IngresoDetalle detalleTraido)
        {

            tabControl1.SelectedTab = tabProcesador;
            tabControl1.SelectedTab = tabMemoria;
            tabControl1.SelectedTab = tabVideo;
            tabControl1.SelectedTab = tabDiscoDuro;
            tabControl1.SelectedTab = tabLicencia;
            tabControl1.SelectedTab = tabClavesLicencias;
            tabControl1.SelectedTab = tabDetalle;

            cmbMarca.SelectedValue = detalleTraido.LaptopIdMarca;
            cmbModelo.SelectedValue = detalleTraido.LaptopIdModelo;
            laptop = detalleTraido.Laptop;
            chbGarantia.Checked= (laptop.Garantia == 1) ? true : false;
            txtPantalla.Text = laptop.TamanoPantalla.ToString();
            txtPartNumber.Text = laptop.PartNumber.ToString();
            txtPrecio.Text = detalleTraido.Precio.ToString();
            txtCantidad.Text = detalleTraido.Cantidad.ToString();

            foreach (String serie in detalleTraido.Series)
            {
                DataGridViewRow row = (DataGridViewRow)dgvSerieFabrica.Rows[0].Clone();
                row.Cells[1].Value = serie;
                dgvSerieFabrica.Rows.Add(row);
            }

            foreach (String clave in detalleTraido.Windows)
            {
                DataGridViewRow row = (DataGridViewRow)dgvWindows.Rows[0].Clone();
                row.Cells[1].Value = clave;
                dgvWindows.Rows.Add(row);
            }

            /*
            foreach (String clave in detalleTraido.Office)
            {
                DataGridViewRow row = (DataGridViewRow)dgvOffice.Rows[0].Clone();
                row.Cells[1].Value = clave;
                dgvOffice.Rows.Add(row);
            }

            foreach (String clave in detalleTraido.Antivirus)
            {
                DataGridViewRow row = (DataGridViewRow)dgvAntivirus.Rows[0].Clone();
                row.Cells[1].Value = clave;
                dgvAntivirus.Rows.Add(row);
            }
            */
            tablaLicencia.Columns.Add("Seleccionar", typeof(bool));
            for (int i = 0; i < tablaLicencia.Rows.Count; i++)
            {
                tablaLicencia.Rows[i]["Seleccionar"] = false;
            }
            foreach (Licencia licencia in laptop.Licencias)
            {
                for (int i = 0; i < tablaLicencia.Rows.Count; i++)
                {
                    if (licencia.IdModelo == int.Parse(tablaLicencia.Rows[i]["IdModelo"].ToString()))
                        tablaLicencia.Rows[i]["Seleccionar"] = true;
                }
            }
            dgvLicencia.PrimaryGrid.DataSource = tablaLicencia;


            tablaMemoria.Columns.Add("Seleccionar", typeof(bool));
            for (int i = 0; i < tablaMemoria.Rows.Count; i++)
            {
                tablaMemoria.Rows[i]["Seleccionar"] = false;
            }
            foreach (Memoria memoria in laptop.Memorias)
            {
                for (int i = 0; i < tablaMemoria.Rows.Count; i++)
                {
                    if (memoria.IdMemoria == int.Parse(tablaMemoria.Rows[i]["IdMemoria"].ToString()))
                        tablaMemoria.Rows[i]["Seleccionar"] = true;
                }
            }
            dgvMemoria.PrimaryGrid.DataSource = tablaMemoria;



            tablaDisco.Columns.Add("Seleccionar", typeof(bool));
            for (int i = 0; i < tablaDisco.Rows.Count; i++)
            {
                tablaDisco.Rows[i]["Seleccionar"] = false;
            }
            foreach (DiscoDuro disco in laptop.Discos)
            {
                for (int i = 0; i < tablaDisco.Rows.Count; i++)
                {
                    if (disco.IdDisco == int.Parse(tablaDisco.Rows[i]["IdDisco"].ToString()))
                        tablaDisco.Rows[i]["Seleccionar"] = true;
                }
            }
            dgvDiscoDuro.PrimaryGrid.DataSource = tablaDisco;


            tablaVideo.Columns.Add("Seleccionar", typeof(bool));
            for(int i=0;i< tablaVideo.Rows.Count; i++)
            {
                if (laptop.Video.IdVideo == int.Parse(tablaVideo.Rows[i]["IdVideo"].ToString()))
                    tablaVideo.Rows[i]["Seleccionar"] = true;
                else
                    tablaVideo.Rows[i]["Seleccionar"] = false;
            }
            dgvVideo.PrimaryGrid.DataSource = tablaVideo;


            tablaProcesador.Columns.Add("Seleccionar", typeof(bool));
            for (int i = 0; i < tablaProcesador.Rows.Count; i++)
            {
                if (laptop.Procesador.IdProcesador == int.Parse(tablaProcesador.Rows[i]["IdProcesador"].ToString()))
                    tablaProcesador.Rows[i]["Seleccionar"] = true;
                else
                    tablaProcesador.Rows[i]["Seleccionar"] = false;
            }
            dgvProcesador.PrimaryGrid.DataSource = tablaProcesador;


        }
        public bool llenarListaLaptops()
        {
            bool flag = false;
            laptop = new LC();
            

            int j = cmbMarca.SelectedIndex;
            laptop.Modelo.IdMarca = Convert.ToInt32(cmbMarca.SelectedValue.ToString());
            laptop.Modelo.NombreMarca = tablaMarca.Rows[j]["nombre"].ToString();
            j = cmbModelo.SelectedIndex;
            laptop.Modelo.IdModelo = Convert.ToInt32(cmbModelo.SelectedValue.ToString());
            laptop.Modelo.NombreModelo = tablaModelo.Rows[j]["nombre"].ToString();
            laptop.TamanoPantalla = Double.Parse(txtPantalla.Text);
            laptop.PartNumber = txtPartNumber.Text;
            laptop.Garantia = (chbGarantia.Checked) ? 1 : 0;
            detalle.Laptop = laptop;
            detalle.Precio = Double.Parse(txtPrecio.Text);
            detalle.Cantidad = Convert.ToInt32(txtCantidad.Text);
            detalle.Series=null;
            detalle.Windows = null;
            detalle.Office = null;
            detalle.Antivirus = null;
            BindingList<String> series = new BindingList<String>();
            BindingList<String> windows = new BindingList<String>();
            BindingList<String> offices = new BindingList<String>();
            BindingList<String> antivirus = new BindingList<String>();

            for (int i = 0; i < dgvSerieFabrica.Rows.Count; i++)
            {
                if (!dgvSerieFabrica.Rows[i].IsNewRow)
                {
                    if (dgvSerieFabrica.Rows[i].Cells[1].Value != null)
                    {
                        String serie = dgvSerieFabrica.Rows[i].Cells[1].Value.ToString();
                        series.Add(serie);
                    }
                }
            }
            detalle.Series = series;

            for (int i = 0; i < dgvWindows.Rows.Count; i++)
            {
                if (!dgvWindows.Rows[i].IsNewRow)
                {
                    if (dgvWindows.Rows[i].Cells[1].Value != null)
                    {
                        String window = dgvWindows.Rows[i].Cells[1].Value.ToString();
                        windows.Add(window);
                    }
                }
            }
            detalle.Windows = windows;
            /*
            for (int i = 0; i < dgvOffice.Rows.Count; i++)
            {
                if (!dgvOffice.Rows[i].IsNewRow)
                {
                    if (dgvOffice.Rows[i].Cells[1].Value != null)
                    {
                        String office = dgvOffice.Rows[i].Cells[1].Value.ToString();
                        offices.Add(office);
                    }
                }
            }
            detalle.Office = offices;

            for (int i = 0; i < dgvAntivirus.Rows.Count; i++)
            {
                if (!dgvAntivirus.Rows[i].IsNewRow)
                {
                    if (dgvAntivirus.Rows[i].Cells[1].Value != null)
                    {
                        String antiviru = dgvAntivirus.Rows[i].Cells[1].Value.ToString();
                        antivirus.Add(antiviru);
                    }
                }
            }
            detalle.Antivirus = antivirus;
            */

            int filas = tablaProcesador.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvProcesador.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvProcesador.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        procesador = new Procesador();
                        procesador.IdProcesador = int.Parse(((GridCell)(dgvProcesador.PrimaryGrid.GetCell(i, 7))).Value.ToString());
                        procesador.IdModelo = int.Parse(((GridCell)(dgvProcesador.PrimaryGrid.GetCell(i, 8))).Value.ToString());
                        procesador.Generacion = int.Parse(((GridCell)(dgvProcesador.PrimaryGrid.GetCell(i, 3))).Value.ToString());
                        procesador.Modelo.NombreModelo = ((GridCell)(dgvProcesador.PrimaryGrid.GetCell(i, 2))).Value.ToString();
                        laptop.Procesador=procesador;
                        flag = true;
                    }
                }
            }

            filas = tablaVideo.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvVideo.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvVideo.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        video = new Video();
                        video.IdVideo = int.Parse(((GridCell)(dgvVideo.PrimaryGrid.GetCell(i, 6))).Value.ToString());
                        video.IdModelo = int.Parse(((GridCell)(dgvVideo.PrimaryGrid.GetCell(i, 7))).Value.ToString());
                        video.Capacidad = int.Parse(((GridCell)(dgvVideo.PrimaryGrid.GetCell(i, 4))).Value.ToString());
                        video.Modelo.NombreModelo = ((GridCell)(dgvVideo.PrimaryGrid.GetCell(i, 2))).Value.ToString();
                        laptop.Video = video;
                        flag = true;
                    }
                }
            }

            filas = tablaMemoria.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        memoria = new Memoria();
                        memoria.IdMemoria = int.Parse(((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 5))).Value.ToString());
                        memoria.IdModelo = int.Parse(((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 6))).Value.ToString());
                        memoria.Capacidad = int.Parse(((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 3))).Value.ToString());
                        memoria.Modelo.NombreModelo = ((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 1))).Value.ToString();
                        memoria.Tipo = ((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 9))).Value.ToString();
                        memoria.Cantidad = 1;
                        laptop.Memorias.Add(memoria);
                        flag = true;
                    }
                }
            }


            filas = tablaDisco.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        disco = new DiscoDuro();
                        disco.IdDisco = int.Parse(((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 5))).Value.ToString());
                        disco.IdTipo = int.Parse(((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 6))).Value.ToString());
                        disco.Capacidad = int.Parse(((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 3))).Value.ToString());
                        disco.Tamano = ((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 2))).Value.ToString();
                        disco.TipoDisco = ((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 1))).Value.ToString();
                        disco.Cantidad = 1;
                        laptop.Discos.Add(disco);
                        flag = true;
                    }
                }
            }


            filas = tablaLicencia.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        licencia = new Licencia();
                        licencia.IdCategoria = int.Parse(((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 4))).Value.ToString());
                        licencia.IdModelo = int.Parse(((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 6))).Value.ToString());
                        licencia.Categoria = ((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 1))).Value.ToString();
                        licencia.Version = ((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 3))).Value.ToString();
                        laptop.Licencias.Add(licencia);
                        flag = true;
                    }
                }
            }

            return flag;
        }

        public bool validarDatos()
        {
            bool flag = true;

            tabControl1.SelectedTab = tabProcesador;
            tabControl1.SelectedTab = tabMemoria;
            tabControl1.SelectedTab = tabVideo;
            tabControl1.SelectedTab = tabDiscoDuro;
            tabControl1.SelectedTab = tabLicencia;
            tabControl1.SelectedTab = tabClavesLicencias;
            tabControl1.SelectedTab = tabDetalle;

            //==============================================================================================
            int filas = tablaVideo.Rows.Count;
            int cantVideos = 0;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvVideo.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvVideo.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        cantVideos++;
                    }
                }
            }
            if (cantVideos > 1)
            {
                MessageBox.Show("Solo seleccione una tarjeta de video", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tabControl1.SelectedTab = tabVideo;
                return false;
            }
            //==============================================================================================
            if (cmbModelo.SelectedValue == null)
            {
                MessageBox.Show("No se puede grabar si no\nha seleccionado un modelo correcto.", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabDetalle;
                return false;
            }
            //==============================================================================================
            filas = tablaProcesador.Rows.Count;
            int cantProcesadores = 0;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvProcesador.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvProcesador.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        cantProcesadores++;
                    }
                }
            }
            if (cantProcesadores > 1)
            {
                MessageBox.Show("Solo seleccione un procesador", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tabControl1.SelectedTab = tabProcesador;
                return false;
            }
            else if (cantProcesadores == 0)
            {
                MessageBox.Show("Debe seleccionar un procesador", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tabControl1.SelectedTab = tabProcesador;
                return false;
            }

            //==============================================================================================
            filas = tablaDisco.Rows.Count;
            int cantDiscos = 0;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        cantDiscos++;
                    }
                }
            }
            if (cantDiscos > 2)
            {
                MessageBox.Show("Solo puede seleccionar 2 discos", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tabControl1.SelectedTab = tabDiscoDuro;
                return false;
            }
            else if (cantDiscos == 0)
            {
                MessageBox.Show("Debe seleccionar almenos un disco duro", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tabControl1.SelectedTab = tabDiscoDuro;
                return false;
            }

            //==============================================================================================
            filas = tablaMemoria.Rows.Count;
            int cantMemorias = 0;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        cantMemorias++;
                    }
                }
            }
            if (cantMemorias > 4)
            {
                MessageBox.Show("Solo puede seleccionar 4 memorias", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tabControl1.SelectedTab = tabMemoria;
                return false;
            }
            else if (cantMemorias == 0)
            {
                MessageBox.Show("Debe seleccionar almenos una memoria", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tabControl1.SelectedTab = tabMemoria;
                return false;
            }


            //==============================================================================================
            filas = tablaLicencia.Rows.Count;
            int cantWindows = 0;
            //int cantOffice = 0;
            //int cantAntivirus = 0;

            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        if (((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 1))).Value.ToString() == LicenciaSO)
                        {
                            cantWindows++;
                        }
                        /*
                        else if (((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 1))).Value.ToString() == "OFFICE")
                        {
                            cantOffice++;
                        }
                        else if (((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 1))).Value.ToString() == "ANTIVIRUS")
                        {
                            cantAntivirus++;
                        }
                        */
                    }
                }
            }
            if (cantWindows > 1) //! AQUI SE VALIDA QUE SOLO SE PUEDA INGRESAR 1 LICENCIA O NIGUNA, PERO NUNCA MAS DE 1
            {
                MessageBox.Show($"Solo puede seleccionar una licencia. Usted seleccionó {cantWindows}", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tabControl1.SelectedTab = tabLicencia;
                return false;
            }
            
            /*
            if (cantOffice > 1)
            {
                MessageBox.Show("Solo puede seleccionar una licencia office", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tabControl1.SelectedTab = tabLicencia;
                return false;
            }

            if (cantAntivirus > 1)
            {
                MessageBox.Show("Solo puede seleccionar una licencia de Antivirus", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tabControl1.SelectedTab = tabLicencia;
                return false;
            }
            */

            int aux;
            int filasDgv;
            //==============================================================================================



            /*

            //! CODIGO DE LICENCIAS SEGUN EL NUMERO DE ACTIVOS A INGRESAR 
            int canActivos = int.Parse(txtCantidad.Text);
            int claveSO = dgvWindows.RowCount;

            if (cantWindows == 1)
            { 
                if (canActivos < claveSO)
                {
                    MessageBox.Show("NO PUEDE HABER MAS LICENCIAS DE S.O QUE ACTIVOS");
                    return false;
                }

                if (canActivos < claveSO)
                {
                    MessageBox.Show("NO PUEDE HABER MAS LICENCIAS DE S.O QUE ACTIVOS");
                    return false;
                }
            }


            */
            if (cantWindows == 1)
            {
                for (int i = 0; i < dgvWindows.Rows.Count; i++)
                {
                    if (dgvWindows.Rows[i].Cells[1].Value == null)
                    {
                        if (!dgvWindows.Rows[i].IsNewRow)
                        {
                            dgvWindows.Rows.Remove(dgvWindows.Rows[i]);
                            i = -1;
                        }
                    }
                }
                aux = int.Parse(txtCantidad.Text);
                filasDgv = dgvWindows.Rows.Count - 1;

                if (filasDgv < aux)
                {
                    MessageBox.Show("Falta ingresar " + (aux - filasDgv) + " filas para la licencia de Windows", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    tabControl1.SelectedTab = tabClavesLicencias;
                    return false;
                }
                else if (filasDgv > aux)
                {
                    MessageBox.Show("Hay " + (filasDgv - aux) + " filas de más en la licencia de Windows", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    tabControl1.SelectedTab = tabClavesLicencias;
                    return false;
                }

            }


            //==============================================================================================

            /*
            if (cantOffice == 1)
            {
                for (int i = 0; i < dgvOffice.Rows.Count; i++)
                {
                    if (dgvOffice.Rows[i].Cells[1].Value == null)
                    {
                        if (!dgvOffice.Rows[i].IsNewRow)
                        {
                            dgvOffice.Rows.Remove(dgvOffice.Rows[i]);
                            i = -1;
                        }
                    }
                }
                aux = int.Parse(txtCantidad.Text);
                filasDgv = dgvOffice.Rows.Count - 1;

                if (filasDgv < aux)
                {
                    MessageBox.Show("Falta ingresar " + (aux - filasDgv) + " filas para la licencia de Office", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    tabControl1.SelectedTab = tabClavesLicencias;
                    return false;
                }
                else if (filasDgv > aux)
                {
                    MessageBox.Show("Hay " + (filasDgv - aux) + " filas de más en la licencia de Office", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    tabControl1.SelectedTab = tabClavesLicencias;
                    return false;
                }
            }


            //==============================================================================================


            if (cantAntivirus == 1)
            {

                for (int i = 0; i < dgvAntivirus.Rows.Count; i++)
                {
                    if (dgvAntivirus.Rows[i].Cells[1].Value == null)
                    {
                        if (!dgvAntivirus.Rows[i].IsNewRow)
                        {
                            dgvAntivirus.Rows.Remove(dgvAntivirus.Rows[i]);
                            i = -1;
                        }
                    }
                }
                aux = int.Parse(txtCantidad.Text);
                filasDgv = dgvAntivirus.Rows.Count - 1;

                if (filasDgv < aux)
                {
                    MessageBox.Show("Falta ingresar " + (aux - filasDgv) + " filas para la licencia de Antivirus", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    tabControl1.SelectedTab = tabClavesLicencias;
                    return false;
                }
                else if (filasDgv > aux)
                {
                    MessageBox.Show("Hay " + (filasDgv - aux) + " filas de más en la licencia de Antivirus", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    tabControl1.SelectedTab = tabClavesLicencias;
                    return false;
                }
            }

    */

            //==============================================================================================

            string partNumber = txtPartNumber.Text;
            partNumber = partNumber.Trim();
            if (!(partNumber.Length > 0))
            {
                MessageBox.Show("Ingrese un part number", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tabControl1.SelectedTab = tabDetalle;
                return false;
            }

            //==============================================================================================
            string pantalla = txtPantalla.Text;
            pantalla = pantalla.Trim();
            if (!(pantalla.Length > 0))
            {
                MessageBox.Show("Ingrese un tamaño de pantalla válida", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tabControl1.SelectedTab = tabDetalle;
                return false;
            }

            //==============================================================================================
            string precio = txtPrecio.Text;
            precio = precio.Trim();
            if (!(precio.Length > 0))
            {
                MessageBox.Show("Ingrese un precio válido", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tabControl1.SelectedTab = tabDetalle;
                return false;
            }
            //==============================================================================================

            for (int i = 0; i < dgvSerieFabrica.Rows.Count; i++)
            {
                if (dgvSerieFabrica.Rows[i].Cells[1].Value == null)
                {
                    if (!dgvSerieFabrica.Rows[i].IsNewRow)
                    {
                        dgvSerieFabrica.Rows.Remove(dgvSerieFabrica.Rows[i]);
                        i = -1;
                    }
                }
            }

            aux = int.Parse(txtCantidad.Text);
            filasDgv = dgvSerieFabrica.Rows.Count - 1;
            
            if (filasDgv < aux)
            {
                MessageBox.Show("Falta ingresar " + (aux - filasDgv) + " filas para las series de fábrica", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tabControl1.SelectedTab = tabDetalle;
                return false;
            }
            else if (filasDgv > aux)
            {
                MessageBox.Show("Hay " + (filasDgv - aux) + " filas de más para las series de fábrica", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tabControl1.SelectedTab = tabDetalle;
                return false;
            }
            //==============================================================================================
            return true;
        }

        public IngresoDetalle DETALLE { get => detalle; set => detalle = value; }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            // 'Comprobar que tenga filas
            if (validarDatos())
            {
                if (llenarListaLaptops())//Si entra es porque se ha seleccionado almenos solo
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            //string aux = txtCantidad.Text;
            //aux = aux.Trim();
            //if (aux.Length > 0)
            //{
            //    int cantidad = int.Parse(txtCantidad.Text);
            //    int cantFilas = dgvSerieFabrica.RowCount;
            //    if (cantFilas < cantidad)
            //    {
            //        for (int i = cantFilas; i < cantidad; i++)
            //        {
            //            DataGridViewRow row = (DataGridViewRow)dgvSerieFabrica.Rows[0].Clone();
            //            row.Cells[0].Value = i++;
            //            dgvSerieFabrica.Rows.Add(row);
            //        }
            //    }
            //    else
            //    {

            //    }

            //}
            string myStr = txtCantidad.Text;
            myStr = myStr.TrimStart('0');
            txtCantidad.Text = myStr.Length > 0 ? myStr : "1";
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void dgvSerieFabrica_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvSerieFabrica.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvSerieFabrica_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
       {
            if (dgvSerieFabrica.CurrentRow == null)
                return;
            if (MessageBox.Show("Estas seguro deseas Eliminar esta serie", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                dgvSerieFabrica.Rows.Remove(dgvSerieFabrica.CurrentRow);
            }
        }

        private void dgvWindows_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvWindows.CurrentRow == null)
                return;
            if (MessageBox.Show("Estas seguro deseas Eliminar esta clave de windows", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                dgvWindows.Rows.Remove(dgvWindows.CurrentRow);
            }

        }

        private void dgvWindows_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvWindows.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        /*
        private void dgvOffice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOffice.CurrentRow == null)
                return;
            if (MessageBox.Show("Estas seguro deseas Eliminar esta clave de office", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                dgvOffice.Rows.Remove(dgvOffice.CurrentRow);
            }

        }

        private void dgvOffice_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvOffice.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvAntivirus_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAntivirus.CurrentRow == null)
                return;
            if (MessageBox.Show("Estas seguro deseas Eliminar esta clave de antivirus", "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                dgvAntivirus.Rows.Remove(dgvAntivirus.CurrentRow);
            }

        }

        private void dgvAntivirus_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvAntivirus.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        */
        private void txtPantalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = solonumeros1(Convert.ToInt32(e.KeyChar));
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = solonumeros2(Convert.ToInt32(e.KeyChar));
        }
        public bool solonumeros1(int code)
        {
            bool resultado;
            if (code == 46 && txtPantalla.Text.Contains("."))//se evalua si es punto y si es punto se rebiza si ya existe en el textbox
                resultado = true;
            else if ((((code >= 48) && (code <= 57)) || (code == 8) || code == 46)) //se evaluan las teclas validas
                resultado = false;
            else if (!permitir)
                resultado = permitir;
            else
                resultado = true;
            return resultado;
        }
        public bool solonumeros2(int code)
        {
            bool resultado;
            if (code == 46 && txtPrecio.Text.Contains("."))//se evalua si es punto y si es punto se rebiza si ya existe en el textbox
                resultado = true;
            else if ((((code >= 48) && (code <= 57)) || (code == 8) || code == 46)) //se evaluan las teclas validas
                resultado = false;
            else if (!permitir)
                resultado = permitir;
            else
                resultado = true;
            return resultado;
        }

        private void btnSubirSeries_Click(object sender, EventArgs e)
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
                    DataTable miDataTable = new DataTable();
                    miDataTable.Columns.Add("serie");

                    path = openFileDialog.FileName;
                    SLDocument sl = new SLDocument(path);

                    int iRow = 2;
                    while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                    {
                        DataRow Renglon = miDataTable.NewRow();
                        Renglon["serie"] = sl.GetCellValueAsString(iRow, 1);
                        iRow++;
                        miDataTable.Rows.Add(Renglon);
                    }

                    dgvSerieFabrica.DataSource = miDataTable;
                    dgvSerieFabrica.AutoGenerateColumns= false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }


        }

        private void btnSubirSO_Click(object sender, EventArgs e)
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
                    DataTable miDataTable = new DataTable();
                    miDataTable.Columns.Add("sistemaOperativo");

                    path = openFileDialog.FileName;
                    SLDocument sl = new SLDocument(path);

                    int iRow = 2;
                    while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                    {
                        DataRow Renglon = miDataTable.NewRow();
                        Renglon["sistemaOperativo"] = sl.GetCellValueAsString(iRow, 1);
                        iRow++;
                        miDataTable.Rows.Add(Renglon);
                    }

                    dgvWindows.DataSource = miDataTable;
                    dgvWindows.AutoGenerateColumns = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "◄ AVISO | LEASEIN S.A.C. ►", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void btnAgregarMarcaLaptop_Click(object sender, EventArgs e)
        {
            frmArchivoMarca frmBP = new frmArchivoMarca(this.idUsuario, this.nombreUsuario, this.laptopIdCategoria);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
            }

            tablaMarca = ingresoDA.ListarMarcas();
            cmbMarca.DataSource = tablaMarca;
            cmbMarca.DisplayMember = "nombre";
            cmbMarca.ValueMember = "idMarca";
            cmbMarca.SelectedIndex = 0;
            int i = cmbMarca.SelectedIndex;

            if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                int idMarca = Convert.ToInt32(cmbMarca.SelectedValue.ToString());
                tablaModelo = ingresoDA.ListarModelos(idMarca);
                cmbModelo.DataSource = tablaModelo;
                cmbModelo.DisplayMember = "nombre";
                cmbModelo.ValueMember = "idModelo";
                cmbModelo.SelectedIndex = 0;
            }

        }

        private void btnAgregarModeloLaptop_Click(object sender, EventArgs e)
        {
            frmArchivoModelo frmBP = new frmArchivoModelo(this.idUsuario, this.nombreUsuario, this.laptopIdCategoria);
            if (frmBP.ShowDialog() == DialogResult.OK)
            {
            }

            tablaMarca = ingresoDA.ListarMarcas();
            cmbMarca.DataSource = tablaMarca;
            cmbMarca.DisplayMember = "nombre";
            cmbMarca.ValueMember = "idMarca";
            cmbMarca.SelectedIndex = 0;
            int i = cmbMarca.SelectedIndex;

            if (i >= 0) //Esto verifica que se ha seleccionado algún item del comboBox
            {
                int idMarca = Convert.ToInt32(cmbMarca.SelectedValue.ToString());
                tablaModelo = ingresoDA.ListarModelos(idMarca);
                cmbModelo.DataSource = tablaModelo;
                cmbModelo.DisplayMember = "nombre";
                cmbModelo.ValueMember = "idModelo";
                cmbModelo.SelectedIndex = 0;
            }
        }

        private void tabControlPanel5_Click(object sender, EventArgs e)
        {

        }

        private void txtProcesadorSeleccionado_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = true;

            tabControl1.SelectedTab = tabProcesador;
            tabControl1.SelectedTab = tabMemoria;
            tabControl1.SelectedTab = tabVideo;
            tabControl1.SelectedTab = tabDiscoDuro;
            tabControl1.SelectedTab = tabLicencia;
            tabControl1.SelectedTab = tabClavesLicencias;
            tabControl1.SelectedTab = tabDetalle;

            //============================================================================================== PROCESADOR
            int filas = tablaProcesador.Rows.Count;
            int canProces = 0;
            for (int i = 0; i < filas; i++)
            {
                if (((GridCell)(dgvProcesador.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvProcesador.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        
                        string MarcaP = (((GridCell)(dgvProcesador.PrimaryGrid.GetCell(i, 1))).Value.ToString());
                        string TipoP = (((GridCell)(dgvProcesador.PrimaryGrid.GetCell(i, 2))).Value.ToString());
                        string GeneracionP = (((GridCell)(dgvProcesador.PrimaryGrid.GetCell(i, 3))).Value.ToString());

                        canProces++;
                        txtProcesadorSeleccionado.ForeColor = Color.White;
                        txtProcesadorSeleccionado.BackColor = Color.Green;
                        txtProcesadorSeleccionado.Text = $"{MarcaP} {TipoP} {GeneracionP}";
                    }
                }
            }
            if (canProces > 1)
            {
                txtProcesadorSeleccionado.ForeColor = Color.Yellow;
                txtProcesadorSeleccionado.BackColor = Color.Red;
                txtProcesadorSeleccionado.Text = $"{canProces} SELECCIOANADOS";
            }
            if (canProces == 0)
            {
                txtProcesadorSeleccionado.ForeColor = Color.Yellow;
                txtProcesadorSeleccionado.BackColor = Color.Red;
                txtProcesadorSeleccionado.Text = "NN";
            }

            //============================================================================================== MEMORIAS
            int filas2 = tablaMemoria.Rows.Count;
            int canMemo = 0;
            for (int i = 0; i < filas2; i++)
            {
                if (((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        string ModeloM = (((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 1))).Value.ToString());
                        string CapacidadM = (((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 3))).Value.ToString());
                        string TipoM = (((GridCell)(dgvMemoria.PrimaryGrid.GetCell(i, 9))).Value.ToString());

                        canMemo++;
                        txtMemoriaSeleccionada.ForeColor = Color.White;
                        txtMemoriaSeleccionada.BackColor = Color.Green;
                        txtMemoriaSeleccionada.Text = $"{ModeloM} {CapacidadM} {TipoM}";
                    }
                }
            }
            if (canMemo > 1) //MAXIMO 4
            {
                if (canMemo > 4)
                {
                    txtMemoriaSeleccionada.ForeColor = Color.Yellow;
                    txtMemoriaSeleccionada.BackColor = Color.Red;
                    txtMemoriaSeleccionada.Text = $"{canMemo} SELECCIONADAS";
                }
                else
                {
                    txtMemoriaSeleccionada.ForeColor = Color.White;
                    txtMemoriaSeleccionada.BackColor = Color.Green;
                    txtMemoriaSeleccionada.Text = $"{canMemo} SELECCIONADAS";
                }

            }
            if (canMemo == 0)
            {
                txtMemoriaSeleccionada.ForeColor = Color.Yellow;
                txtMemoriaSeleccionada.BackColor = Color.Red;
                txtMemoriaSeleccionada.Text = "NN";
            }

            //============================================================================================== DISCO DURO
            int filas3 = tablaDisco.Rows.Count;
            int canDis = 0;
            for (int i = 0; i < filas3; i++)
            {
                if (((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        string TipoDD = (((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 1))).Value.ToString());
                        string TamDD = (((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 2))).Value.ToString());
                        string CapacidadDD = (((GridCell)(dgvDiscoDuro.PrimaryGrid.GetCell(i, 3))).Value.ToString());
                        

                        canDis++;
                        txtDiscoDuroSeleccionado.ForeColor = Color.White;
                        txtDiscoDuroSeleccionado.BackColor = Color.Green;
                        txtDiscoDuroSeleccionado.Text = $"{TipoDD} {TamDD} {CapacidadDD}";

                    }
                }
            }
            if (canDis > 1) //MAXIMO 2
            {
                if (canDis > 2)
                {
                    txtDiscoDuroSeleccionado.ForeColor = Color.Yellow;
                    txtDiscoDuroSeleccionado.BackColor = Color.Red;
                    txtDiscoDuroSeleccionado.Text = $"{canDis} SELECCIONADOS";
                }
                else
                {
                    txtDiscoDuroSeleccionado.ForeColor = Color.White;
                    txtDiscoDuroSeleccionado.BackColor = Color.Green;
                    txtDiscoDuroSeleccionado.Text = $"{canDis} SELECCIONADOS";
                }

            }
            if (canDis == 0)
            {
                txtDiscoDuroSeleccionado.ForeColor = Color.Yellow;
                txtDiscoDuroSeleccionado.BackColor = Color.Red;
                txtDiscoDuroSeleccionado.Text = "NN";
            }


            //============================================================================================== TARJETA DE VIDEO
            int filas4 = tablaVideo.Rows.Count;
            int canTarj = 0;
            for (int i = 0; i < filas4; i++)
            {
                if (((GridCell)(dgvVideo.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvVideo.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        string MarcaTDV = (((GridCell)(dgvVideo.PrimaryGrid.GetCell(i, 1))).Value.ToString());
                        string TipoTDV = (((GridCell)(dgvVideo.PrimaryGrid.GetCell(i, 3))).Value.ToString());
                        string CapacidadTDV = (((GridCell)(dgvVideo.PrimaryGrid.GetCell(i, 4))).Value.ToString());

                        canTarj++;
                        txtTdvSeleccionado.ForeColor = Color.White;
                        txtTdvSeleccionado.BackColor = Color.Green;
                        txtTdvSeleccionado.Text = $"{MarcaTDV} {TipoTDV} {CapacidadTDV}";

                    }
                }
            }
            if (canTarj > 1) 
            {
                txtTdvSeleccionado.ForeColor = Color.Yellow;
                txtTdvSeleccionado.BackColor = Color.Red;
                txtTdvSeleccionado.Text = $"{canTarj} SELECCIONADOS";


            }
            if (canTarj == 0)
            {
                txtTdvSeleccionado.ForeColor = Color.White;
                txtTdvSeleccionado.BackColor = Color.Green;
                txtTdvSeleccionado.Text = "NN";
            }

            //============================================================================================== LICENCIAS

            int filas5 = tablaLicencia.Rows.Count;
            int canLic = 0;
            for (int i = 0; i < filas4; i++)
            {
                if (((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 0))).Value != null)
                {
                    if (Convert.ToBoolean(((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 0))).Value.ToString()) == true)
                    {
                        string CategoriaLic = (((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 1))).Value.ToString());
                        string VersionLic = (((GridCell)(dgvLicencia.PrimaryGrid.GetCell(i, 3))).Value.ToString());

                        canLic++;
                        txtLicenciaSeleccionada.ForeColor = Color.White;
                        txtLicenciaSeleccionada.BackColor = Color.Green;
                        txtLicenciaSeleccionada.Text = $"{CategoriaLic} {VersionLic}";
                    }
                }
            }
            if (canLic > 1)
            {
                txtLicenciaSeleccionada.ForeColor = Color.Yellow;
                txtLicenciaSeleccionada.BackColor = Color.Red;
                txtLicenciaSeleccionada.Text = $"{canLic} SELECCIONADAS";


            }
            if (canLic == 0)
            {
                txtLicenciaSeleccionada.ForeColor = Color.White;
                txtLicenciaSeleccionada.BackColor = Color.Green;
                txtLicenciaSeleccionada.Text = "NN";
            }

        }
    }
}
