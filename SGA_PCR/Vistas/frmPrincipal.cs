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
    public partial class frmPrincipal : Form
    {
        public enum TipoVista { Archivo, Proceso, Reportes, Configuracion }


        public frmPrincipal()
        {
            InitializeComponent();
            lblUsuario.Text = lblUsuario.Text + "TEST";
        }

        private void btnIngreso_Click(object sender, EventArgs e)
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
                frmProcesoIngreso f2 = new frmProcesoIngreso();
                f2.MdiParent = this;
                f2.Show();
            }
            
        }

        private void btnCrearProcesador_Click(object sender, EventArgs e)
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
                frmArchivoCrearProcesador f2 = new frmArchivoCrearProcesador();
                f2.MdiParent = this;
                f2.Show();
            }
            
        }

        private void btnCrearMemoria_Click(object sender, EventArgs e)
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
                frmArchivoCrearMemoria f2 = new frmArchivoCrearMemoria();
                f2.MdiParent = this;
                f2.Show();
            }
            
        }

        private void btnCrearDisco_Click(object sender, EventArgs e)
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
                frmArchivoCrearDiscoDuro f2 = new frmArchivoCrearDiscoDuro();
                f2.MdiParent = this;
                f2.Show();
            }
            
        }

        private void btnCrearTarjetaVideo_Click(object sender, EventArgs e)
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
                frmArchivoCrearTarjetaVideo f2 = new frmArchivoCrearTarjetaVideo();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnCrearCliente_Click(object sender, EventArgs e)
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
                frmArchivoCrearCliente f2 = new frmArchivoCrearCliente();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnProveedor_Click(object sender, EventArgs e)
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
                frmArchivoCrearProveedor f2 = new frmArchivoCrearProveedor();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnDevolucion_Click(object sender, EventArgs e)
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
                frmProcesoDevolucion f2 = new frmProcesoDevolucion();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnAlquiler_Click(object sender, EventArgs e)
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
                frmProcesoAlquiler f2 = new frmProcesoAlquiler();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnCambio_Click(object sender, EventArgs e)
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
                frmProcesoCambio f2 = new frmProcesoCambio();
                f2.MdiParent = this;
                f2.Show();
            }

        }

        private void btnCambioComponente_Click(object sender, EventArgs e)
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
                frmProcesoCambioComponentes f2 = new frmProcesoCambioComponentes();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
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
                frmProcesoReparacion f2 = new frmProcesoReparacion();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnReportMantenimiento_Click(object sender, EventArgs e)
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
                frmReporteMantenimiento f2 = new frmReporteMantenimiento();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnStock_Click(object sender, EventArgs e)
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
                frmReporteCV f2 = new frmReporteCV();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnFacturasPorVencer_Click(object sender, EventArgs e)
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
                frmReporteFacturasPorVencer f2 = new frmReporteFacturasPorVencer();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnSubirFactura_Click(object sender, EventArgs e)
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
                frmProcesoSubirFacturas f2 = new frmProcesoSubirFacturas();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnReportePendienteFacturar_Click(object sender, EventArgs e)
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
                frmReportePendienteFacturar f2 = new frmReportePendienteFacturar();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnLevantarObservacion_Click(object sender, EventArgs e)
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
                frmProcesoLevantamientoObservaciones f2 = new frmProcesoLevantamientoObservaciones();
                f2.MdiParent = this;
                f2.Show();
            }

        }

        private void btnReporteCompras_Click(object sender, EventArgs e)
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

        private void btnReporteAlquileres_Click(object sender, EventArgs e)
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
                frmReporteAlquiler f2 = new frmReporteAlquiler();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnMemorias_Click(object sender, EventArgs e)
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
                frmReporteMemoria f2 = new frmReporteMemoria();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnReporteLaptop_Click(object sender, EventArgs e)
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
                frmReporteStocksLaptops f2 = new frmReporteStocksLaptops();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnPendienteRecoger_Click(object sender, EventArgs e)
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
                frmReportePendienteRecoger f2 = new frmReportePendienteRecoger();
                f2.MdiParent = this;
                f2.Show();
            }
            //frmReportePendienteRecoger frm = new frmReportePendienteRecoger();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void btnPendienteReposicion_Click(object sender, EventArgs e)
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
                frmReportePendienteReposicion f2 = new frmReportePendienteReposicion();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnSucursal_Click(object sender, EventArgs e)
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
                frmArchivoClienteSucursal f2 = new frmArchivoClienteSucursal();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnRenovacion_Click(object sender, EventArgs e)
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
                frmProcesoRenovacion f2 = new frmProcesoRenovacion();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnLaptopVencer_Click(object sender, EventArgs e)
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
                frmReporteAlquileresPorVencer f2 = new frmReporteAlquileresPorVencer();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnDiscos_Click(object sender, EventArgs e)
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
                frmReporteDisco f2 = new frmReporteDisco();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnCambioDescripcion_Click(object sender, EventArgs e)
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
                frmProcesoCambioDescripcion f2 = new frmProcesoCambioDescripcion();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void btnLicencias_Click(object sender, EventArgs e)
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
                frmReporteLicencia f2 = new frmReporteLicencia();
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
