using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Modelo;
using AccesoDatos;
using DevComponents.DotNetBar.SuperGrid;
using DevExpress.Export;
using DevExpress.Printing.ExportHelpers;
using DevExpress.XtraPrinting;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.XtraGrid.Views.Grid;

namespace Apolo
{
    public partial class TEST_MENU_PRINCIPAL : Form
    {
        int canDisponibles = 0;

        DataTable tablaLaptops;
        DataTable tablaMontos;
        ReporteDA reporteDA;
        private int idUsuario;
        private string nombreUsuario = "CEAS";
        DataTable tablaDisco;
        DataTable tablaMemoria;
        DataTable tablaLicencia;
        DataTable MontoFacturadoMes;

        private string licenciaCategoriaSO = "S.O";
        private string licenciaCategoriaOffice = "OFFICE";
        private string licenciaCategoriaAntivirus = "ANTIVIRUS";

        DataTable tablaProcesadoresModelos;
        DataTable tablaProcesadoresGeneracion;

        private BindingList<LC> laptops;

        private int estadoDisponible = 2;
        private int idMarcaAppleLC = 1;
        private int idMarcaApplePC = 8;
        private int idCategoriaProcesador = 9;
        private string codTablaProcesadorGeneracion = "PROCESADOR_GENERACION";
        private int cantGeneraciones;
        private int cantModeloProcesador;
        private int[][] arregloLCGeneral;
        private int[][] arregloLCApple;

        Accesos_usuarios accesos_usuarios;
        AccesosUsuarioDA accesos_usuarioDA;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect, // x-coordinate of upper-left corner
        int nTopRect, // y-coordinate of upper-left corner
        int nRightRect, // x-coordinate of lower-right corner
        int nBottomRect, // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
        );

        private int idUser;
        private string nameUser;

        public TEST_MENU_PRINCIPAL(int idUsuario, string nombreUsuario)
        {
            
            this.FormBorderStyle = FormBorderStyle.None;
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 1300, 650, 20, 20));
            InitializeComponent();
            
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.White;
            Inicializado();
            customizeDesign();
            MenuVertical.Width = 0;


            //MessageBox.Show(idUsuario.ToString());
            usuarioConectado.Text = idUsuario.ToString();
            this.idUser = idUsuario;
            this.nameUser = nombreUsuario;

            //VERIFICACION DE PERMISOS (INICIO)
            verificandoPermisosMaestro();
            verificandoPermisosProcesos();
            verificandoPermisosReportes();
            verificandoPermisosConfiguracion();

        }

        public void CargarDataLaptopsDisponibles()
        {

            try
            {
                reporteDA = new ReporteDA();
                tablaLaptops = reporteDA.ListarLaptopsInventario();
                tablaProcesadoresModelos = reporteDA.tablaProcesadoresModelos(idCategoriaProcesador);
                tablaProcesadoresGeneracion = reporteDA.tablaProcesadoresGeneracion(codTablaProcesadorGeneracion);

                laptops = new BindingList<LC>();
                /*
                tablaDisco = reporteDA.ListarLaptopDisco();
                tablaMemoria = reporteDA.ListarLaptopMemoria();
                tablaLicencia = reporteDA.ListarLaptopLicencia();
                */
                DataView viewDisco = new DataView(tablaDisco);
                DataView viewMemoria = new DataView(tablaMemoria);
                DataView viewLicencia = new DataView(tablaLicencia);
                
                int rec = 0;
                while (rec < tablaLaptops.Rows.Count)
                {
                    LC laptop = new LC();
                    laptop.IdLC = Convert.ToInt32(tablaLaptops.Rows[rec]["idLC"].ToString());
                    laptop.Codigo = tablaLaptops.Rows[rec]["codigo"].ToString();
                    laptop.IdMarca = int.Parse(tablaLaptops.Rows[rec]["idMarca"].ToString());
                    laptop.MarcaLC = tablaLaptops.Rows[rec]["marcaLC"].ToString();
                    laptop.NombreModeloLC = tablaLaptops.Rows[rec]["nombreModeloLC"].ToString();
                    laptop.TipoProcesador = tablaLaptops.Rows[rec]["tipoProcesador"].ToString();
                    laptop.IdGeneracionProcesador = int.Parse(tablaLaptops.Rows[rec]["idGeneracionProcesador"].ToString());
                    laptop.GeneracionProcesador = int.Parse(tablaLaptops.Rows[rec]["generacionProcesador"].ToString());
                    laptop.IdTipoProcesador = int.Parse(tablaLaptops.Rows[rec]["idTipoProcesador"].ToString());
                    laptop.NombreModeloVideo = tablaLaptops.Rows[rec]["nombreModeloVideo"].ToString().Length > 0 ? tablaLaptops.Rows[rec]["nombreModeloVideo"].ToString() : "";
                    laptop.CapacidadVideo = Convert.ToInt32(tablaLaptops.Rows[rec]["capacidadVideo"].ToString());
                    laptop.EstadoNombre = tablaLaptops.Rows[rec]["estado"].ToString();
                    laptop.Estado = int.Parse(tablaLaptops.Rows[rec]["idEstado"].ToString());
                    laptop.Cliente = tablaLaptops.Rows[rec]["cliente"].ToString();
                    laptop.Ubicacion = tablaLaptops.Rows[rec]["ubicacion"].ToString();
                    laptop.SerieFabrica = tablaLaptops.Rows[rec]["serieFabrica"].ToString();

                    viewDisco.RowFilter = "idLC = " + laptop.IdLC.ToString();
                    viewMemoria.RowFilter = "idLC = " + laptop.IdLC.ToString();
                    viewLicencia.RowFilter = "idLC = " + laptop.IdLC.ToString();
                    laptop.SetDisco(viewDisco);
                    laptop.SetMemoria(viewMemoria);
                    laptop.SetLicencia(viewLicencia);
                    /*
                    if (laptop.Discos.Count > 0)
                    {
                        if (laptop.Discos.Count == 1)
                        {
                            laptop.Disco1 = laptop.Discos[0].TipoDisco;
                            laptop.CapacidadDisco1 = (laptop.Discos[0].Cantidad * laptop.Discos[0].Capacidad).ToString() + " GB";
                            laptop.Disco2 = "";
                            laptop.CapacidadDisco2 = "";
                        }
                        else if (laptop.Discos.Count >= 2)
                        {
                            laptop.Disco1 = laptop.Discos[0].TipoDisco;
                            laptop.CapacidadDisco1 = (laptop.Discos[0].Cantidad * laptop.Discos[0].Capacidad).ToString() + " GB";

                            laptop.Disco2 = laptop.Discos[1].TipoDisco;
                            laptop.CapacidadDisco2 = (laptop.Discos[1].Cantidad * laptop.Discos[1].Capacidad).ToString() + " GB";
                        }
                    }
                    else if (laptop.Discos.Count == 0)
                    {
                        laptop.Disco1 = "";
                        laptop.CapacidadDisco1 = "";
                        laptop.Disco2 = "";
                        laptop.CapacidadDisco2 = "";
                    }

                    int capacidadMem = 0;
                    foreach (Memoria mem in laptop.Memorias)
                    {
                        capacidadMem += mem.Capacidad * mem.Cantidad;
                    }
                    laptop.CapacidadMemoria = capacidadMem.ToString() + " GB";

                    Licencia windows = null; Licencia office = null; Licencia antivirus = null;

                    
                    if (laptop.Licencias.Count > 0)
                    {
                        windows = laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaSO);
                        office = laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaOffice);
                        antivirus = laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaAntivirus);

                    }

                    laptop.LicenciaWindows = (windows != null) ? windows.Version : "";
                    laptop.LicenciaOffice = (office != null) ? office.Version : "";
                    laptop.LicenciaAntivirus = (antivirus != null) ? antivirus.Version : "";

                    laptop.Licencias = null;
                    laptop.Discos = null;
                    laptop.Memorias = null;

                    laptop.IdSalida = tablaLaptops.Rows[rec]["idSalida"].ToString();
                    */
                    laptops.Add(laptop);
                    rec++;
                    
                }

                this.cantGeneraciones = tablaProcesadoresGeneracion.Rows.Count;
                this.cantModeloProcesador = tablaProcesadoresModelos.Rows.Count;
                /*
                this.arregloLCGeneral = new int[cantGeneraciones][];
                this.arregloLCApple = new int[cantGeneraciones][];

                
                for (int i = 0; i < this.cantGeneraciones; i++)
                {
                    this.arregloLCGeneral[i] = new int[this.cantModeloProcesador];
                    this.arregloLCApple[i] = new int[this.cantModeloProcesador];

                    for (int j = 0; j < this.cantModeloProcesador; j++)
                    {
                        int idGen = int.Parse(tablaProcesadoresGeneracion.Rows[i]["idAuxiliar"].ToString());
                        int idModPro = int.Parse(tablaProcesadoresModelos.Rows[j]["idModelo"].ToString());
                        var cantidad = new BindingList<LC>(laptops.Where(p => p.IdMarca != this.idMarcaAppleLC && p.IdGeneracionProcesador == idGen && p.IdTipoProcesador == idModPro && p.IdMarca != this.idMarcaApplePC && p.Estado == this.estadoDisponible).ToList());
                        this.arregloLCGeneral[i][j] = cantidad.Count;
                        cantidad = new BindingList<LC>(laptops.Where(p => p.IdMarca == this.idMarcaAppleLC && p.IdGeneracionProcesador == idGen && p.IdTipoProcesador == idModPro && p.IdMarca != this.idMarcaApplePC && p.Estado == this.estadoDisponible).ToList());
                        this.arregloLCApple[i][j] = cantidad.Count;
                    }
                }
                
                */
                dgvLaptops.DataSource = laptops;
                vista.OptionsBehavior.AutoPopulateColumns = false;
                vista.OptionsSelection.MultiSelect = true;

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message); OMITIMOS EL MENSAJE
            }
        }

        private void verificandoPermisosMaestro()
        {
            //BLOQUEAR O DESBLOQUEAR ITEMS DENTRO DE ARCHIVO-------------------
            Button[] botones_archivo = { button2, button4, button6, button3, button5, button8, button9,btnKAM,btnLicencias };
            string[] idSubmodulo_archivo = { "1a", "2a", "3a", "4a", "5a", "6a", "7a", "8a", "9a" };

            foreach (Button btn in botones_archivo)
            {
                btn.Enabled = false;
            }
            List<string> accesos = new List<string>();
            accesos = accesos_usuarioDA.Obtener_accessos(usuarioConectado.Text, 1);
            int index = 0;

            foreach (string codigo in accesos)
            {
                index = Array.IndexOf(idSubmodulo_archivo, codigo);
                //MessageBox.Show(codigo+" "+index);
                botones_archivo[index].Enabled = true;
            }
            //FIN LOGICA-------------------

        }

        private void verificandoPermisosProcesos()
        {
            //BLOQUEAR O DESBLOQUEAR ITEMS DENTRO DE ARCHIVO-------------------
            Button[] botones_procesos = { button16, button14, button12, button15, button13, button11, button10, button17, button18, button19,btnMovimientosInternos,btnCorteAlquiler };
            string[] idSubmodulo_procesos = { "1b", "2b", "3b", "4b", "5b", "6b", "7b", "8b", "9b", "10b","11b","12b" };

            foreach (Button btn in botones_procesos)
            {
                btn.Enabled = false;
            }
            List<string> accesos = new List<string>();
            accesos = accesos_usuarioDA.Obtener_accessos(usuarioConectado.Text, 2);
            int index = 0;



            foreach (string codigo in accesos)
            {
                index = Array.IndexOf(idSubmodulo_procesos, codigo);
                botones_procesos[index].Enabled = true;
            }
            //FIN LOGICA-------------------
        }
        private void verificandoPermisosReportes()
        {
            //BLOQUEAR O DESBLOQUEAR ITEMS DENTRO DE ARCHIVO-------------------
            Button[] botones_reportes = { button30, button28, button26, button29, button27, button25, button24, button23, button22, button21, button31, button32, button33 };
            string[] idSubmodulo_reportes = { "1c", "2c", "3c", "4c", "5c", "6c", "7c", "8c", "9c", "10c", "11c", "12c", "13c" };

            foreach (Button btn in botones_reportes)
            {
                btn.Enabled = false;
            }
            List<string> accesos = new List<string>();
            accesos = accesos_usuarioDA.Obtener_accessos(usuarioConectado.Text, 3);
            int index = 0;

            foreach (string codigo in accesos)
            {
                index = Array.IndexOf(idSubmodulo_reportes, codigo);
                botones_reportes[index].Enabled = true;
            }
            //FIN LOGICA-------------------
        }

        private void verificandoPermisosConfiguracion()
        {
            //BLOQUEAR O DESBLOQUEAR ITEMS DENTRO DE ARCHIVO-------------------
            Button[] botones_configuracion = { btnConfiguracionClientes, btnConfiguracionPermisos };
            string[] idSubmodulo_configuracion = { "1d", "2d" };

            foreach (Button btn in botones_configuracion)
            {
                btn.Enabled = false;
            }
            List<string> accesos = new List<string>();
            accesos = accesos_usuarioDA.Obtener_accessos(usuarioConectado.Text, 4);
            int index = 0;

            foreach (string codigo in accesos)
            {
                index = Array.IndexOf(idSubmodulo_configuracion, codigo);
                botones_configuracion[index].Enabled = true;
            }
            //FIN LOGICA-------------------
        }



        private void customizeDesign()
        {
            ARCHIVO.Visible = false;
            PROCESOS.Visible = false;
            REPORTES.Visible = false;
            panelConfiguracion.Visible = false;
        }


        private void hideSubMenu()
        {
            if (ARCHIVO.Visible == true)
                ARCHIVO.Visible = false;
            if (PROCESOS.Visible == true)
                PROCESOS.Visible = false;
            if (REPORTES.Visible == true)
                REPORTES.Visible = false;
            if (panelConfiguracion.Visible == true)
                panelConfiguracion.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }


        public void Inicializado()
        {
            accesos_usuarioDA = new AccesosUsuarioDA();
            accesos_usuarios = new Accesos_usuarios();

            
        }




        private void btnSlideMenu_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 350)
            {
                MenuVertical.Width = 80;                
            }
            else
            {
                MenuVertical.Width = 350;
            }

            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("DESEAS SALIR DE APOLO?", "◄ AVISO | LEASEIN S.A.C. ►",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //frmLogueo log = new frmLogueo();
                this.Hide();
                //log.Show();
                

            }
        }

        private void button7_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("aa");
        }

        private void ARCHIVO_MouseHover(object sender, EventArgs e)
        {
            //MessageBox.Show("sss");
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            ARCHIVO.Visible = true;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            ARCHIVO.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            ARCHIVO.Visible = false;
        }

        private void button7_MouseClick_1(object sender, MouseEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmArchivoCrearProcesador")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmArchivoCrearProcesador f2 = new frmArchivoCrearProcesador(this.idUser,this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }

            hideSubMenu();
        }

        private void TEST_MENU_PRINCIPAL_Load(object sender, EventArgs e)
        {
            btnDash.PerformClick();
            
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            /*
            if (PROCESOS.Visible == true)
            { 
                PROCESOS.Visible = false;

                button20.Location = new Point(3, button1.Location.Y + button1.Height);
                REPORTES.Location = new Point(3, button20.Location.Y + button20.Height + 5);

                btnConfiguracion.Location = new Point(3, button20.Location.Y + button20.Height);
                panelConfiguracion.Location = new Point(3, btnConfiguracion.Location.Y + btnConfiguracion.Height + 5);
            }
            else
            {
                //BLOQUEAR O DESBLOQUEAR ITEMS DENTRO DE ARCHIVO-------------------
                Button[] botones_procesos = { button16, button14, button12, button15, button13, button11, button10, button17, button18, button19 };
                string[] idSubmodulo_procesos = { "1b", "2b", "3b", "4b", "5b", "6b", "7b", "8b", "9b", "10b" };

                foreach (Button btn in botones_procesos)
                {
                    btn.Enabled = false;
                }
                List<string> accesos = new List<string>();
                accesos = accesos_usuarioDA.Obtener_accessos(usuarioConectado.Text, 2);
                int index = 0;

                

                foreach (string codigo in accesos)
                {
                    index = Array.IndexOf(idSubmodulo_procesos, codigo);
                    botones_procesos[index].Enabled = true;
                }
                //FIN LOGICA-------------------


                PROCESOS.Location = new Point(3, button1.Location.Y +button1.Height+5);
                PROCESOS.Visible = true;
                
                //REPORTE
                button20.Location = new Point(3, PROCESOS.Location.Y + PROCESOS.Height+5);
                REPORTES.Location = new Point(3, button20.Location.Y + button20.Height+5);

                //REPORTE
                btnConfiguracion.Location = new Point(3, REPORTES.Location.Y + REPORTES.Height + 5);
                panelConfiguracion.Location = new Point(3, btnConfiguracion.Location.Y + btnConfiguracion.Height + 5);
            }
            */

           

            showSubMenu(PROCESOS);
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmArchivoCrearDiscoDuro")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmArchivoCrearDiscoDuro f2 = new frmArchivoCrearDiscoDuro(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmArchivoCrearMemoria")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmArchivoCrearMemoria f2 = new frmArchivoCrearMemoria(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmArchivoCrearTarjetaVideo")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmArchivoCrearTarjetaVideo f2 = new frmArchivoCrearTarjetaVideo(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmCrearCliente")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmArchivoCrearCliente f2 = new frmArchivoCrearCliente(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmArchivoClienteSucursal")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmArchivoClienteSucursal f2 = new frmArchivoClienteSucursal(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmCrearProveedor")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmArchivoCrearProveedor f2 = new frmArchivoCrearProveedor(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmProcesoIngreso")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmProcesoIngreso f2 = new frmProcesoIngreso(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmProcesoDevolucion")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmProcesoDevolucion f2 = new frmProcesoDevolucion(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmProcesoAlquiler")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmProcesoAlquiler f2 = new frmProcesoAlquiler(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmProcesoRenovacion")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmProcesoRenovacion f2 = new frmProcesoRenovacion(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmProcesoCambio")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmProcesoCambio f2 = new frmProcesoCambio(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmProcesoSubirFacturas")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmProcesoSubirFacturas f2 = new frmProcesoSubirFacturas(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmProcesoReparacion")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmProcesoReparacion f2 = new frmProcesoReparacion(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmProcesoCambioComponentes")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmProcesoCambioComponentes f2 = new frmProcesoCambioComponentes(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmProcesoCambioDescripcion")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmProcesoCambioDescripcion f2 = new frmProcesoCambioDescripcion(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmProcesoLevantamientoObservaciones")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmProcesoLevantamientoObservaciones f2 = new frmProcesoLevantamientoObservaciones(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            /*
            if (REPORTES.Visible == true)
            { 
                REPORTES.Visible = false;

            btnConfiguracion.Location = new Point(3, button20.Location.Y + button20.Height);
            panelConfiguracion.Location = new Point(3, btnConfiguracion.Location.Y + btnConfiguracion.Height + 5);
            }

            else
            {
                //BLOQUEAR O DESBLOQUEAR ITEMS DENTRO DE ARCHIVO-------------------
                Button[] botones_reportes = { button30, button28, button26, button29, button27, button25, button24, button23, button22, button21, button31, button32, button33};
                string[] idSubmodulo_reportes = { "1c", "2c", "3c", "4c", "5c", "6c", "7c", "8c", "9c", "10c", "11c", "12c", "13c" };

                foreach (Button btn in botones_reportes)
                {
                    btn.Enabled = false;
                }
                List<string> accesos = new List<string>();
                accesos = accesos_usuarioDA.Obtener_accessos(usuarioConectado.Text, 3);
                int index = 0;

                foreach (string codigo in accesos)
                {
                    index = Array.IndexOf(idSubmodulo_reportes, codigo);
                    botones_reportes[index].Enabled = true;
                }
                //FIN LOGICA-------------------


                REPORTES.Location = new Point(3, button20.Location.Y + button20.Height + 5);
                REPORTES.Visible = true;

                //CONFIGURACION
                btnConfiguracion.Location = new Point(3, REPORTES.Location.Y + REPORTES.Height);
                panelConfiguracion.Location = new Point(3, btnConfiguracion.Location.Y + btnConfiguracion.Height + 5);
            }
            */
            
            showSubMenu(REPORTES);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmReporteCV")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmReporteCV f2 = new frmReporteCV(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {

            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmReporteFacturasPorVencer")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmReporteFacturasPorVencer f2 = new frmReporteFacturasPorVencer(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmReportePendienteFacturar")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmReportePendienteFacturar f2 = new frmReportePendienteFacturar(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmReportePendienteRecoger")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmReportePendienteRecoger f2 = new frmReportePendienteRecoger(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
            //frmReportePendienteRecoger frm = new frmReportePendienteRecoger();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmReportePendienteReposicion")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmReportePendienteReposicion f2 = new frmReportePendienteReposicion(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmReporteAlquileresPorVencer")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmReporteAlquileresPorVencer f2 = new frmReporteAlquileresPorVencer(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmReporteStocksLaptops")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmReporteStocksLaptops f2 = new frmReporteStocksLaptops(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmReporteMemoria")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmReporteMemoria f2 = new frmReporteMemoria(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmReporteDisco")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmReporteDisco f2 = new frmReporteDisco(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmReporteLicencia")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmReporteLicencia f2 = new frmReporteLicencia(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmReporteAlquiler")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmReporteAlquiler f2 = new frmReporteAlquiler(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmReporteCompras")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmReporteCompras f2 = new frmReporteCompras();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmReporteMantenimiento")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmReporteMantenimiento f2 = new frmReporteMantenimiento(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void usuarioConectado_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            showSubMenu(ARCHIVO);
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            showSubMenu(panelConfiguracion);
        }

        private void button34_Click(object sender, EventArgs e)
        {
           
        }

        private void button34_Click_1(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 350)
            {
                pictureBox1.Visible = true;
                MenuVertical.Width = 0;
            }
            else
            {
                pictureBox1.Visible = false;
                MenuVertical.Width = 350;
            }
        }

        private void btnConfiguracionPermisos_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmConfiguracionPermisos")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmConfiguracionPermisos f2 = new frmConfiguracionPermisos();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnConfiguracionClientes_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmConfiguracionUsuarios")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmConfiguracionUsuarios f2 = new frmConfiguracionUsuarios();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmArchivoKam")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmArchivoKam f2 = new frmArchivoKam(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnLicencias_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmArchivoLicencias")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmArchivoLicencias f2 = new frmArchivoLicencias(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button35_Click_1(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmProcesoSalida")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmProcesoSalida f2 = new frmProcesoSalida(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void button35_Click_2(object sender, EventArgs e)
        {
            if (panelDashboard.Visible == false)
            {
                CargarDataLaptopsDisponibles();
                vista.ActiveFilterString = "[EstadoNombre] like '%DISPONIBLE%'";
                canDisponibles = vista.RowCount;
                lblLaptopsDisponibles.Text = canDisponibles.ToString();
                
                panelDashboard.Visible = true;
                //pnlDispo.Visible = true;
                
                pnlPronosticador.Visible = false;
            }
            else
                panelDashboard.Visible = false;


        }

        private void btnVerDetalleDispo_Click(object sender, EventArgs e)
        {
            /*
            if (pnlDispo.Visible == false)
            {
                vista.ActiveFilterString = "[EstadoNombre] like '%DISPONIBLE%'";
                dgvLaptops.Visible = true;
                
            }
            else
            {
                
                dgvLaptops.Visible = false;
            }
      
            */

        }

        private  void VerDetallePronos_Click(object sender, EventArgs e)
        {
            VerDetallePronos.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, VerDetallePronos.Width,
                VerDetallePronos.Height, 30, 30));
            laptops = new BindingList<LC>();

            List<String> codigosPronosticador = new List<String>();
            int canDisponibles = 0;


            //PENDIENTE POR RECOGER
            reporteDA = new ReporteDA();
            tablaLaptops = reporteDA.ListarLaptopsPorRecogerDASH();


            int rec = 0;
            while (rec < tablaLaptops.Rows.Count)
            {
                LC laptop = new LC();
                laptop.IdLC = Convert.ToInt32(tablaLaptops.Rows[rec]["idLC"].ToString());
                laptop.Codigo = tablaLaptops.Rows[rec]["codigo"].ToString();
                laptop.IdMarca = int.Parse(tablaLaptops.Rows[rec]["idMarca"].ToString());
                laptop.MarcaLC = tablaLaptops.Rows[rec]["marcaLC"].ToString();
                laptop.NombreModeloLC = tablaLaptops.Rows[rec]["nombreModeloLC"].ToString();
                laptop.TipoProcesador = tablaLaptops.Rows[rec]["tipoProcesador"].ToString();
                laptop.IdGeneracionProcesador = int.Parse(tablaLaptops.Rows[rec]["idGeneracionProcesador"].ToString());
                laptop.GeneracionProcesador = int.Parse(tablaLaptops.Rows[rec]["generacionProcesador"].ToString());
                laptop.IdTipoProcesador = int.Parse(tablaLaptops.Rows[rec]["idTipoProcesador"].ToString());
                laptop.EstadoNombre = tablaLaptops.Rows[rec]["estado"].ToString();
                laptop.Estado = int.Parse(tablaLaptops.Rows[rec]["idEstado"].ToString());

                laptops.Add(laptop);
                rec++;
            }

            //MessageBox.Show(laptops.Count.ToString());

            //LAPTOPS POR VENCER
            tablaLaptops = reporteDA.ListarLaptopsPorVencerPRONOSTICADOR();

            DataView aux = new DataView(tablaLaptops);
            aux.RowFilter= $"fecFinContrato < #{FechaPronosticador.SelectionRange.Start.ToString("yyyy-MM-dd")}#";

            //MessageBox.Show(aux.Count.ToString());
            /*
            gridControl2.DataSource = tablaLaptops;
            gridView2.ActiveFilterString = $"[fecFinContrato] < #{FechaPronosticador.SelectionRange.Start.ToString("yyyy-MM-dd")}#";
            */

            rec = 0;


            foreach (DataRowView row in aux)
            {
                LC laptop = new LC();
                laptop.IdLC = Convert.ToInt32(row["idLC"].ToString());
                laptop.Codigo = row["Codigo"].ToString();
                laptop.IdMarca = Convert.ToInt32(row["idMarca"].ToString());
                laptop.MarcaLC = row["MarcaLC"].ToString();
                laptop.NombreModeloLC = row["NombreModeloLC"].ToString();
                laptop.TipoProcesador = row["TipoProcesador"].ToString();
                laptop.IdGeneracionProcesador = Convert.ToInt32(row["idGeneracionProcesador"].ToString());
                laptop.GeneracionProcesador = Convert.ToInt32(row["GeneracionProcesador"].ToString());
                laptop.IdTipoProcesador = Convert.ToInt32(row["idTipoProcesador"].ToString());
                laptop.EstadoNombre = row["estado"].ToString();
                laptop.Estado = Convert.ToInt32(row["idEstado"].ToString());

                laptops.Add(laptop);
                rec++;
            }



            //MessageBox.Show(laptops.Count.ToString());

            canDisponibles = laptops.Count;
            pnlPronosticador.Visible = true;
            lblCantidadPronosticador.Text = canDisponibles.ToString();

            //!---------------------------------------------------------------------
            lblFechaPronosticador.Text = $"FECHA: {FechaPronosticador.SelectionRange.Start.ToShortDateString()}";
            lblTotal.Text = canDisponibles.ToString();


            this.cantGeneraciones = tablaProcesadoresGeneracion.Rows.Count;
            this.cantModeloProcesador = tablaProcesadoresModelos.Rows.Count;

            this.arregloLCGeneral = new int[cantGeneraciones][];
            this.arregloLCApple = new int[cantGeneraciones][];


            for (int i = 0; i < this.cantGeneraciones; i++)
            {
                this.arregloLCGeneral[i] = new int[this.cantModeloProcesador];
                this.arregloLCApple[i] = new int[this.cantModeloProcesador];

                for (int j = 0; j < this.cantModeloProcesador; j++)
                {
                    int idGen = int.Parse(tablaProcesadoresGeneracion.Rows[i]["idAuxiliar"].ToString());
                    int idModPro = int.Parse(tablaProcesadoresModelos.Rows[j]["idModelo"].ToString());
                    var cantidad = new BindingList<LC>(laptops.Where(p => p.IdMarca != this.idMarcaAppleLC && p.IdGeneracionProcesador == idGen && p.IdTipoProcesador == idModPro && p.IdMarca != this.idMarcaApplePC ).ToList());
                    this.arregloLCGeneral[i][j] = cantidad.Count;
                    cantidad = new BindingList<LC>(laptops.Where(p => p.IdMarca == this.idMarcaAppleLC && p.IdGeneracionProcesador == idGen && p.IdTipoProcesador == idModPro && p.IdMarca != this.idMarcaApplePC ).ToList());
                    this.arregloLCApple[i][j] = cantidad.Count;
                }
            }


            dgvLaptops.DataSource = laptops;
            vista.OptionsBehavior.AutoPopulateColumns = false;
            vista.OptionsSelection.MultiSelect = true;


            //-------------------------------------------------
            DataTable resumen = new DataTable();
            resumen.Columns.Add("PROCESADOR");
            resumen.Columns.Add("LAP");
            resumen.Columns.Add("MAC");
            DataRow dr = null;


            //CANTIDAD DE LAPTOP POR PROCESADOR -> LAP Y MAC
            for (int j = 0; j < this.cantModeloProcesador; j++)
            {
                dr = resumen.NewRow();
                dr["PROCESADOR"] = tablaProcesadoresModelos.Rows[j]["nombre"].ToString();
                int cantProLCGeneral = 0;
                int cantProLCApple = 0;
                for (int i = 0; i < this.cantGeneraciones; i++)
                {
                    cantProLCGeneral += arregloLCGeneral[i][j];
                    cantProLCApple += arregloLCApple[i][j];
                }
                dr["LAP"] = cantProLCGeneral.ToString();
                dr["MAC"] = cantProLCApple.ToString();

                resumen.Rows.Add(dr);

                //MessageBox.Show($"{cantProLCGeneral} {cantProLCApple}");
            }



            lblTotal.Text = (int.Parse(lblLaptopsDisponibles.Text)+ int.Parse(lblCantidadPronosticador.Text)).ToString();

            gridControl3.DataSource = laptops;
                gridView3.OptionsBehavior.AutoPopulateColumns = false;
                gridView3.OptionsSelection.MultiSelect = true;

            

          

            /*


            DataTable dt = new DataTable();
            dt.Columns.Add("Codigo");
            dt.Columns.Add("MarcaLC");
            dt.Columns.Add("NombreModeloLC");
            dt.Columns.Add("TipoProcesador");
            
            dt.Columns.Add("NombreModeloVideo");
            dt.Columns.Add("CapacidadVideo");
            dt.Columns.Add("Disco1");
            dt.Columns.Add("CapacidadDisco1");
            dt.Columns.Add("Disco2");
            dt.Columns.Add("CapacidadDisco2");
            dt.Columns.Add("CapacidadMemoria");
            dt.Columns.Add("EstadoNombre");
            dt.Columns.Add("Cliente");
            dt.Columns.Add("Ubicacion");
            dt.Columns.Add("SerieFabrica");
            dt.Columns.Add("IdSalida");
            
            DataRow dr = null;


            for (int i = 0; i < codigosPronosticador.Count; i++)
            {
                gridView3.ActiveFilterString = $"[Codigo] = ('{codigosPronosticador[i]}')";

                dr = dt.NewRow();
                dr["Codigo"] = gridView3.GetRowCellValue(0, "Codigo");
                dr["MarcaLC"] = gridView3.GetRowCellValue(0, "MarcaLC");
                dr["NombreModeloLC"] = gridView3.GetRowCellValue(0, "NombreModeloLC");
                dr["TipoProcesador"] = gridView3.GetRowCellValue(0, "TipoProcesador");
                
                dr["NombreModeloVideo"] = gridView3.GetRowCellValue(0, "NombreModeloVideo");
                dr["CapacidadVideo"] = gridView3.GetRowCellValue(0, "CapacidadVideo");                
                dr["Disco1"] = gridView3.GetRowCellValue(0, "Disco1");
                dr["CapacidadDisco1"] = gridView3.GetRowCellValue(0, "CapacidadDisco1");
                dr["Disco2"] = gridView3.GetRowCellValue(0, "Disco2");
                dr["CapacidadDisco2"] = gridView3.GetRowCellValue(0, "CapacidadDisco2");
                dr["CapacidadMemoria"] = gridView3.GetRowCellValue(0, "CapacidadMemoria");
                dr["EstadoNombre"] = gridView3.GetRowCellValue(0, "EstadoNombre");
                dr["Cliente"] = gridView3.GetRowCellValue(0, "Cliente");
                dr["Ubicacion"] = gridView3.GetRowCellValue(0, "Ubicacion");
                dr["SerieFabrica"] = gridView3.GetRowCellValue(0, "SerieFabrica");
                dr["IdSalida"] = gridView3.GetRowCellValue(0, "IdSalida");
                
                dt.Rows.Add(dr);
            }
            */


            gridControl4.DataSource = resumen;
            gridView4.OptionsBehavior.AutoPopulateColumns = true;
            gridView4.OptionsSelection.MultiSelect = true;
            pnlPronosticador.Visible = true;

            
            label15.Text = "FECHA: " + FechaPronosticador.SelectionRange.Start.ToShortDateString();
            btnCargarResumenDispo.PerformClick();
        }


        private void dgvLaptops_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void dgvLaptops_MouseLeave(object sender, EventArgs e)
        {
            
        }

        public void CargarDataLaptopsDisponiblesPronosticador()
        {

            try
            {
                reporteDA = new ReporteDA();
                tablaLaptops = reporteDA.ListarLaptopsInventario();
                tablaProcesadoresModelos = reporteDA.tablaProcesadoresModelos(idCategoriaProcesador);
                tablaProcesadoresGeneracion = reporteDA.tablaProcesadoresGeneracion(codTablaProcesadorGeneracion);

                laptops = new BindingList<LC>();
                /*
                tablaDisco = reporteDA.ListarLaptopDisco();
                tablaMemoria = reporteDA.ListarLaptopMemoria();
                tablaLicencia = reporteDA.ListarLaptopLicencia();
                */
                DataView viewDisco = new DataView(tablaDisco);
                DataView viewMemoria = new DataView(tablaMemoria);
                DataView viewLicencia = new DataView(tablaLicencia);
                int rec = 0;
                while (rec < tablaLaptops.Rows.Count)
                {
                    LC laptop = new LC();
                    laptop.IdLC = Convert.ToInt32(tablaLaptops.Rows[rec]["idLC"].ToString());
                    laptop.Codigo = tablaLaptops.Rows[rec]["codigo"].ToString();
                    laptop.IdMarca = int.Parse(tablaLaptops.Rows[rec]["idMarca"].ToString());
                    laptop.MarcaLC = tablaLaptops.Rows[rec]["marcaLC"].ToString();
                    laptop.NombreModeloLC = tablaLaptops.Rows[rec]["nombreModeloLC"].ToString();
                    laptop.TipoProcesador = tablaLaptops.Rows[rec]["tipoProcesador"].ToString();
                    laptop.IdGeneracionProcesador = int.Parse(tablaLaptops.Rows[rec]["idGeneracionProcesador"].ToString());
                    laptop.GeneracionProcesador = int.Parse(tablaLaptops.Rows[rec]["generacionProcesador"].ToString());
                    laptop.IdTipoProcesador = int.Parse(tablaLaptops.Rows[rec]["idTipoProcesador"].ToString());
                    laptop.NombreModeloVideo = tablaLaptops.Rows[rec]["nombreModeloVideo"].ToString().Length > 0 ? tablaLaptops.Rows[rec]["nombreModeloVideo"].ToString() : "";
                    laptop.CapacidadVideo = Convert.ToInt32(tablaLaptops.Rows[rec]["capacidadVideo"].ToString());
                    laptop.EstadoNombre = tablaLaptops.Rows[rec]["estado"].ToString();
                    laptop.Estado = int.Parse(tablaLaptops.Rows[rec]["idEstado"].ToString());
                    laptop.Cliente = tablaLaptops.Rows[rec]["cliente"].ToString();
                    laptop.Ubicacion = tablaLaptops.Rows[rec]["ubicacion"].ToString();
                    laptop.SerieFabrica = tablaLaptops.Rows[rec]["serieFabrica"].ToString();

                    viewDisco.RowFilter = "idLC = " + laptop.IdLC.ToString();
                    viewMemoria.RowFilter = "idLC = " + laptop.IdLC.ToString();
                    viewLicencia.RowFilter = "idLC = " + laptop.IdLC.ToString();
                    laptop.SetDisco(viewDisco);
                    laptop.SetMemoria(viewMemoria);
                    laptop.SetLicencia(viewLicencia);

                    /*
                    if (laptop.Discos.Count > 0)
                    {
                        if (laptop.Discos.Count == 1)
                        {
                            laptop.Disco1 = laptop.Discos[0].TipoDisco;
                            laptop.CapacidadDisco1 = (laptop.Discos[0].Cantidad * laptop.Discos[0].Capacidad).ToString() + " GB";
                            laptop.Disco2 = "";
                            laptop.CapacidadDisco2 = "";
                        }
                        else if (laptop.Discos.Count >= 2)
                        {
                            laptop.Disco1 = laptop.Discos[0].TipoDisco;
                            laptop.CapacidadDisco1 = (laptop.Discos[0].Cantidad * laptop.Discos[0].Capacidad).ToString() + " GB";

                            laptop.Disco2 = laptop.Discos[1].TipoDisco;
                            laptop.CapacidadDisco2 = (laptop.Discos[1].Cantidad * laptop.Discos[1].Capacidad).ToString() + " GB";
                        }
                    }
                    else if (laptop.Discos.Count == 0)
                    {
                        laptop.Disco1 = "";
                        laptop.CapacidadDisco1 = "";
                        laptop.Disco2 = "";
                        laptop.CapacidadDisco2 = "";
                    }

                    int capacidadMem = 0;
                    foreach (Memoria mem in laptop.Memorias)
                    {
                        capacidadMem += mem.Capacidad * mem.Cantidad;
                    }
                    laptop.CapacidadMemoria = capacidadMem.ToString() + " GB";

                    Licencia windows = null; Licencia office = null; Licencia antivirus = null;

                    if (laptop.Licencias.Count > 0)
                    {
                        windows = laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaSO);
                        office = laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaOffice);
                        antivirus = laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaAntivirus);

                    }

                    laptop.LicenciaWindows = (windows != null) ? windows.Version : "";
                    laptop.LicenciaOffice = (office != null) ? office.Version : "";
                    laptop.LicenciaAntivirus = (antivirus != null) ? antivirus.Version : "";

                    laptop.Licencias = null;
                    laptop.Discos = null;
                    laptop.Memorias = null;

                    laptop.IdSalida = tablaLaptops.Rows[rec]["idSalida"].ToString();
                    */
                    laptops.Add(laptop);
                    rec++;
                }

                this.cantGeneraciones = tablaProcesadoresGeneracion.Rows.Count;
                this.cantModeloProcesador = tablaProcesadoresModelos.Rows.Count;

                /*
                this.arregloLCGeneral = new int[cantGeneraciones][];
                this.arregloLCApple = new int[cantGeneraciones][];

                for (int i = 0; i < this.cantGeneraciones; i++)
                {
                    this.arregloLCGeneral[i] = new int[this.cantModeloProcesador];
                    this.arregloLCApple[i] = new int[this.cantModeloProcesador];

                    for (int j = 0; j < this.cantModeloProcesador; j++)
                    {
                        int idGen = int.Parse(tablaProcesadoresGeneracion.Rows[i]["idAuxiliar"].ToString());
                        int idModPro = int.Parse(tablaProcesadoresModelos.Rows[j]["idModelo"].ToString());
                        var cantidad = new BindingList<LC>(laptops.Where(p => p.IdMarca != this.idMarcaAppleLC && p.IdGeneracionProcesador == idGen && p.IdTipoProcesador == idModPro && p.IdMarca != this.idMarcaApplePC && p.Estado == this.estadoDisponible).ToList());
                        this.arregloLCGeneral[i][j] = cantidad.Count;
                        cantidad = new BindingList<LC>(laptops.Where(p => p.IdMarca == this.idMarcaAppleLC && p.IdGeneracionProcesador == idGen && p.IdTipoProcesador == idModPro && p.IdMarca != this.idMarcaApplePC && p.Estado == this.estadoDisponible).ToList());
                        this.arregloLCApple[i][j] = cantidad.Count;
                    }
                }

                */
                gridControl3.DataSource = laptops;
                gridView3.OptionsBehavior.AutoPopulateColumns = false;
                gridView3.OptionsSelection.MultiSelect = true;

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message); OMITIMOS EL MENSAJE
            }
        }

        private void gridControl4_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void gridControl4_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void btnVerDashboard_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            if (panelDashboard.Visible == false)
            {
                CargarDataLaptopsDisponibles();
                vista.ActiveFilterString = "[EstadoNombre] like '%DISPONIBLE%'";
                lblLaptopsDisponibles.Text = canDisponibles.ToString();
                panelDashboard.Visible = true;
                //pnlDispo.Visible = true;
                pnlPronosticador.Visible = false;
                lblLaptopsDisponibles.Text = vista.RowCount.ToString();
                label10.Text = "FECHA: "+DateTime.Now.ToShortDateString();
                label15.Text = "FECHA: "+DateTime.Now.ToShortDateString();
                

                //VER LA INFO DE LAS TABLAS
                VerDetallePronos.PerformClick();
                btnCargarResumenDispo.PerformClick();


            }
            else
            {
                panelDashboard.Visible = false;
                pnlDispo.Visible = false;
            }
        }

        private void button35_Click_3(object sender, EventArgs e)
        {

            if (pnlFacturacion.Visible == false)
            {
                reporteDA = new ReporteDA();
                tablaLaptops = reporteDA.ListarLaptopsPorFacturarDASH();

                dgvFacturas.DataSource = tablaLaptops;
                gridView5.OptionsBehavior.AutoPopulateColumns = false;
                gridView5.OptionsSelection.MultiSelect = true;

                gridView5.Columns["cliente"].GroupIndex = -1;
                //gridView5.Columns["factura"].GroupIndex = -1;

                float MontoPendienteFacturar = 0;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    MontoPendienteFacturar = MontoPendienteFacturar + float.Parse(tablaLaptops.Rows[i]["PendienteFacturarSoles"].ToString());
                }
                //MessageBox.Show(MontoPendienteFacturar.ToString());
                //gridView5.Columns["cliente"].GroupIndex = 1;
                
                //gridView5.Columns["factura"].GroupIndex = 2;
                textBox2.Text = string.Format("{0:C0}", MontoPendienteFacturar);
                MontoFacturadoMes = reporteDA.VerMontoFacturadoMes();

               
                txtMontoFacturadoMes.Text = string.Format("{0:C0}", MontoFacturadoMes.Rows[0]["total"]);//MONTO FACTURADO EN EL MES

                lblFacturadoMes.Text = $"MONTO FACTURADO A LA ";
                label18.Text=$"FECHA: { DateTime.Now.ToShortDateString()}. Y HORA: { DateTime.Now.ToLongTimeString()}";
                label18.ForeColor = Color.Orange;

                //TOTAL DE MONTOS


                tablaMontos = reporteDA.ListarLaptopsPorFacturarDASH_segun_dias();

                double menor_15 = 0;
                double entre_15_45 = 0;
                double mas_45 = 0;

                for (int i = 0; i < tablaMontos.Rows.Count; i++)
                {
                    if (int.Parse(tablaMontos.Rows[i]["diasVencidos"].ToString()) < 15)
                    {
                        menor_15 = menor_15 + double.Parse(tablaMontos.Rows[i]["PendienteFacturarSoles"].ToString());
                    }
                    if (int.Parse(tablaMontos.Rows[i]["diasVencidos"].ToString())>=15 && int.Parse(tablaMontos.Rows[i]["diasVencidos"].ToString()) <= 45)
                    {
                        entre_15_45 = entre_15_45 + double.Parse(tablaMontos.Rows[i]["PendienteFacturarSoles"].ToString());
                    }
                    if (int.Parse(tablaMontos.Rows[i]["diasVencidos"].ToString()) > 45 )
                    {
                        mas_45 = mas_45 + double.Parse(tablaMontos.Rows[i]["PendienteFacturarSoles"].ToString());
                    }
                }

                //RESUMEN DE MONTOS
                txtMenos15.Text = string.Format("{0:C0}", menor_15);
                txtEntre15y45.Text = string.Format("{0:C0}", entre_15_45);
                txtMasde45.Text = string.Format("{0:C0}", mas_45);



                



                pnlFacturacion.Visible = true;
            }
            else
            {
                pnlFacturacion.Visible = false;
            }
            
        }

        private void btnCorteAlquiler_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmProcesoCorteAlquiler")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                frmProcesoCorteAlquiler f2 = new frmProcesoCorteAlquiler(this.idUser, this.nameUser);
                f2.MdiParent = this;
                f2.Show();
            }
        }
        
        private void button39_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            btnCargarResumenDispo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnCargarResumenDispo.Width, 
                btnCargarResumenDispo.Height, 50, 50));



            /*
            reporteDA = new ReporteDA();
            tablaLaptops = reporteDA.ListarLaptopsInventario();
            tablaProcesadoresModelos = reporteDA.tablaProcesadoresModelos(idCategoriaProcesador);
            tablaProcesadoresGeneracion = reporteDA.tablaProcesadoresGeneracion(codTablaProcesadorGeneracion);

            laptops = new BindingList<LC>();
            tablaDisco = reporteDA.ListarLaptopDisco();
            tablaMemoria = reporteDA.ListarLaptopMemoria();
            tablaLicencia = reporteDA.ListarLaptopLicencia();
            DataView viewDisco = new DataView(tablaDisco);
            DataView viewMemoria = new DataView(tablaMemoria);
            DataView viewLicencia = new DataView(tablaLicencia);
            int rec = 0;
            while (rec < tablaLaptops.Rows.Count)
            {
                LC laptop = new LC();
                laptop.IdLC = Convert.ToInt32(tablaLaptops.Rows[rec]["idLC"].ToString());
                laptop.Codigo = tablaLaptops.Rows[rec]["codigo"].ToString();
                laptop.IdMarca = int.Parse(tablaLaptops.Rows[rec]["idMarca"].ToString());
                laptop.MarcaLC = tablaLaptops.Rows[rec]["marcaLC"].ToString();
                laptop.NombreModeloLC = tablaLaptops.Rows[rec]["nombreModeloLC"].ToString();
                laptop.TipoProcesador = tablaLaptops.Rows[rec]["tipoProcesador"].ToString();
                laptop.IdGeneracionProcesador = int.Parse(tablaLaptops.Rows[rec]["idGeneracionProcesador"].ToString());
                laptop.GeneracionProcesador = int.Parse(tablaLaptops.Rows[rec]["generacionProcesador"].ToString());
                laptop.IdTipoProcesador = int.Parse(tablaLaptops.Rows[rec]["idTipoProcesador"].ToString());
                laptop.EstadoNombre = tablaLaptops.Rows[rec]["estado"].ToString();
                laptop.Estado = int.Parse(tablaLaptops.Rows[rec]["idEstado"].ToString());


                laptops.Add(laptop);
                rec++;
            }

            this.cantGeneraciones = tablaProcesadoresGeneracion.Rows.Count;
            this.cantModeloProcesador = tablaProcesadoresModelos.Rows.Count;
            */


            /*
              dgvLaptops.DataSource = laptops;
              vista.OptionsBehavior.AutoPopulateColumns = false;
              vista.OptionsSelection.MultiSelect = true;
          */

            reporteDA = new ReporteDA();
            tablaLaptops = reporteDA.ListarLaptopsInventario();
            tablaProcesadoresModelos = reporteDA.tablaProcesadoresModelos(idCategoriaProcesador);
            tablaProcesadoresGeneracion = reporteDA.tablaProcesadoresGeneracion(codTablaProcesadorGeneracion);

            laptops = new BindingList<LC>();
            /*
            tablaDisco = reporteDA.ListarLaptopDisco();
            tablaMemoria = reporteDA.ListarLaptopMemoria();
            tablaLicencia = reporteDA.ListarLaptopLicencia();
            */
            DataView viewDisco = new DataView(tablaDisco);
            DataView viewMemoria = new DataView(tablaMemoria);
            DataView viewLicencia = new DataView(tablaLicencia);

            int rec = 0;
            while (rec < tablaLaptops.Rows.Count)
            {
                LC laptop = new LC();
                laptop.IdLC = Convert.ToInt32(tablaLaptops.Rows[rec]["idLC"].ToString());
                laptop.Codigo = tablaLaptops.Rows[rec]["codigo"].ToString();
                laptop.IdMarca = int.Parse(tablaLaptops.Rows[rec]["idMarca"].ToString());
                laptop.MarcaLC = tablaLaptops.Rows[rec]["marcaLC"].ToString();
                laptop.NombreModeloLC = tablaLaptops.Rows[rec]["nombreModeloLC"].ToString();
                laptop.TipoProcesador = tablaLaptops.Rows[rec]["tipoProcesador"].ToString();
                laptop.IdGeneracionProcesador = int.Parse(tablaLaptops.Rows[rec]["idGeneracionProcesador"].ToString());
                laptop.GeneracionProcesador = int.Parse(tablaLaptops.Rows[rec]["generacionProcesador"].ToString());
                laptop.IdTipoProcesador = int.Parse(tablaLaptops.Rows[rec]["idTipoProcesador"].ToString());
                laptop.NombreModeloVideo = tablaLaptops.Rows[rec]["nombreModeloVideo"].ToString().Length > 0 ? tablaLaptops.Rows[rec]["nombreModeloVideo"].ToString() : "";
                laptop.CapacidadVideo = Convert.ToInt32(tablaLaptops.Rows[rec]["capacidadVideo"].ToString());
                laptop.EstadoNombre = tablaLaptops.Rows[rec]["estado"].ToString();
                laptop.Estado = int.Parse(tablaLaptops.Rows[rec]["idEstado"].ToString());
                laptop.Cliente = tablaLaptops.Rows[rec]["cliente"].ToString();
                laptop.Ubicacion = tablaLaptops.Rows[rec]["ubicacion"].ToString();
                laptop.SerieFabrica = tablaLaptops.Rows[rec]["serieFabrica"].ToString();

                viewDisco.RowFilter = "idLC = " + laptop.IdLC.ToString();
                viewMemoria.RowFilter = "idLC = " + laptop.IdLC.ToString();
                viewLicencia.RowFilter = "idLC = " + laptop.IdLC.ToString();
                laptop.SetDisco(viewDisco);
                laptop.SetMemoria(viewMemoria);
                laptop.SetLicencia(viewLicencia);
                
                if (laptop.Discos.Count > 0)
                {
                    if (laptop.Discos.Count == 1)
                    {
                        laptop.Disco1 = laptop.Discos[0].TipoDisco;
                        laptop.CapacidadDisco1 = (laptop.Discos[0].Cantidad * laptop.Discos[0].Capacidad).ToString() + " GB";
                        laptop.Disco2 = "";
                        laptop.CapacidadDisco2 = "";
                    }
                    else if (laptop.Discos.Count >= 2)
                    {
                        laptop.Disco1 = laptop.Discos[0].TipoDisco;
                        laptop.CapacidadDisco1 = (laptop.Discos[0].Cantidad * laptop.Discos[0].Capacidad).ToString() + " GB";

                        laptop.Disco2 = laptop.Discos[1].TipoDisco;
                        laptop.CapacidadDisco2 = (laptop.Discos[1].Cantidad * laptop.Discos[1].Capacidad).ToString() + " GB";
                    }
                }
                else if (laptop.Discos.Count == 0)
                {
                    laptop.Disco1 = "";
                    laptop.CapacidadDisco1 = "";
                    laptop.Disco2 = "";
                    laptop.CapacidadDisco2 = "";
                }

                int capacidadMem = 0;
                foreach (Memoria mem in laptop.Memorias)
                {
                    capacidadMem += mem.Capacidad * mem.Cantidad;
                }
                laptop.CapacidadMemoria = capacidadMem.ToString() + " GB";

                Licencia windows = null; Licencia office = null; Licencia antivirus = null;


                if (laptop.Licencias.Count > 0)
                {
                    windows = laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaSO);
                    office = laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaOffice);
                    antivirus = laptop.Licencias.SingleOrDefault(p => p.Categoria == this.licenciaCategoriaAntivirus);

                }

                laptop.LicenciaWindows = (windows != null) ? windows.Version : "";
                laptop.LicenciaOffice = (office != null) ? office.Version : "";
                laptop.LicenciaAntivirus = (antivirus != null) ? antivirus.Version : "";

                laptop.Licencias = null;
                laptop.Discos = null;
                laptop.Memorias = null;

                laptop.IdSalida = tablaLaptops.Rows[rec]["idSalida"].ToString();
                
                laptops.Add(laptop);
                rec++;

            }

            this.cantGeneraciones = tablaProcesadoresGeneracion.Rows.Count;
            this.cantModeloProcesador = tablaProcesadoresModelos.Rows.Count;
            
            this.arregloLCGeneral = new int[cantGeneraciones][];
            this.arregloLCApple = new int[cantGeneraciones][];


            for (int i = 0; i < this.cantGeneraciones; i++)
            {
                this.arregloLCGeneral[i] = new int[this.cantModeloProcesador];
                this.arregloLCApple[i] = new int[this.cantModeloProcesador];

                for (int j = 0; j < this.cantModeloProcesador; j++)
                {
                    int idGen = int.Parse(tablaProcesadoresGeneracion.Rows[i]["idAuxiliar"].ToString());
                    int idModPro = int.Parse(tablaProcesadoresModelos.Rows[j]["idModelo"].ToString());
                    var cantidad = new BindingList<LC>(laptops.Where(p => p.IdMarca != this.idMarcaAppleLC && p.IdGeneracionProcesador == idGen && p.IdTipoProcesador == idModPro && p.IdMarca != this.idMarcaApplePC && p.Estado == this.estadoDisponible).ToList());
                    this.arregloLCGeneral[i][j] = cantidad.Count;
                    cantidad = new BindingList<LC>(laptops.Where(p => p.IdMarca == this.idMarcaAppleLC && p.IdGeneracionProcesador == idGen && p.IdTipoProcesador == idModPro && p.IdMarca != this.idMarcaApplePC && p.Estado == this.estadoDisponible).ToList());
                    this.arregloLCApple[i][j] = cantidad.Count;
                }
            }

            
            dgvLaptops.DataSource = laptops;
            vista.OptionsBehavior.AutoPopulateColumns = false;
            vista.OptionsSelection.MultiSelect = true;


            //-------------------------------------------------
                DataTable resumen = new DataTable();
                resumen.Columns.Add("PROCESADOR");
                resumen.Columns.Add("LAP");
                resumen.Columns.Add("MAC");
                DataRow dr = null;


                //CANTIDAD DE LAPTOP POR PROCESADOR -> LAP Y MAC
                for (int j = 0; j < this.cantModeloProcesador; j++)
                {
                    dr = resumen.NewRow();
                    dr["PROCESADOR"] = tablaProcesadoresModelos.Rows[j]["nombre"].ToString();
                    int cantProLCGeneral = 0;
                    int cantProLCApple = 0;
                    for (int i = 0; i < this.cantGeneraciones; i++)
                    {
                        cantProLCGeneral += arregloLCGeneral[i][j];
                        cantProLCApple += arregloLCApple[i][j];
                    }
                    dr["LAP"] = cantProLCGeneral.ToString();
                    dr["MAC"] = cantProLCApple.ToString();

                    resumen.Rows.Add(dr);

                    //MessageBox.Show($"{cantProLCGeneral} {cantProLCApple}");
                }

        

        dgvLaptops.DataSource = resumen;
        vista.OptionsBehavior.AutoPopulateColumns = false;
        vista.OptionsSelection.MultiSelect = true;
        pnlDispo.Visible = true;

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel6_MouseHover(object sender, EventArgs e)
        {
            FechaPronosticador.Visible = true;
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            FechaPronosticador.Visible = false;
        }

        private void btnVerCalendario_Click(object sender, EventArgs e)
        {
            btnVerCalendario.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnVerCalendario.Width,
                btnVerCalendario.Height, 30, 30));
            if (FechaPronosticador.Visible == true)
            {
                FechaPronosticador.Visible = false;
            }
            else 
            {
                FechaPronosticador.Visible = true;
            }
            
        }

        private void btnPagFact_Click(object sender, EventArgs e)
        {
            btnPagFact.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnPagFact.Width,
                btnPagFact.Height, 30, 30));
            panelDashboard.Visible = false;
            button35.PerformClick();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            pnlFacturacion.Visible = false;
            btnDash.PerformClick();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width,
                panel1.Height, 30, 30));
        }

        private void lblLaptopsDisponibles_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width,
                panel3.Height, 30, 30));
        }

        private void btnPagProno_Click(object sender, EventArgs e)
        {
            btnPagProno.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnPagProno.Width,
                btnPagProno.Height, 30, 30));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width,
                panel2.Height, 30, 30));
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("aa");
        }

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {
            panel5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel5.Width,
                 panel5.Height, 30, 30));

        }

        private void panel5_Click_1(object sender, EventArgs e)
        {
            btnCargarResumenDispo.PerformClick();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            btnCargarResumenDispo.PerformClick();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            panel6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel6.Width,
             panel6.Height, 30, 30));
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            VerDetallePronos.PerformClick();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            VerDetallePronos.PerformClick();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (panelDashboard.Visible == true || pnlFacturacion.Visible == true)
            {
                panelDashboard.Visible = false;
                pnlFacturacion.Visible = false;
                btnVer.Text = "ABRIR DASH";
            }
            else if (panelDashboard.Visible == false && pnlFacturacion.Visible == false)
            {
                btnVer.Text = "CERRAR DASH";
                btnDash.PerformClick();
            }
            else
            { 

            }
        }
    }
}

