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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apolo
{
    public partial class frmArchivoKam : Form
    {
        
        DataTable tablaKAM;
        ClienteDA clienteDA;
        Cliente relacion;
        BindingList<Cliente> relaciones;
        BindingList<Cliente> auxiliares;
        private int idUsuario;
        private string nombreUsuario = "CEAS";


        public frmArchivoKam()
        {
            InitializeComponent();
            Inicializado();

        }

        public frmArchivoKam(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            Inicializado();
        }

        public void InicializarRelacionClienteKam()
        {
            clienteDA = new ClienteDA();
            relaciones = new BindingList<Cliente>();

            tablaKAM = clienteDA.ListarClientesKAM();
            auxiliares = new BindingList<Cliente>();
            int rec = 0;
            while (rec < tablaKAM.Rows.Count)
            {
                Cliente auxiliar = new Cliente();
                auxiliar.Nombre_razonSocial = tablaKAM.Rows[rec]["nombre_razonSocial"].ToString();
                auxiliar.KAM1 = tablaKAM.Rows[rec]["nombre"].ToString();
                auxiliares.Add(auxiliar);
                rec++;
            }

            dgvClienteKam.DataSource = auxiliares;
            vista.OptionsBehavior.AutoPopulateColumns = false;
            vista.OptionsSelection.MultiSelect = true;
        }

        public void Inicializado()
        {

            InicializarRelacionClienteKam();


            clienteDA = new ClienteDA();
            tablaKAM = clienteDA.ListarKams();
            cmbKAM.DataSource = tablaKAM;
            cmbKAM.DisplayMember = "nombre";
            cmbKAM.ValueMember = "idUsuario";

        }

        private void btnSeleccionarFilas_Click(object sender, EventArgs e)
        {
            int filas = vista.RowCount;
            for (int i = 0; i < filas; i++)
            {
                vista.SetRowCellValue(i, "Seleccionar", true);
            }
        }

        private void btnDeseleccionarFilas_Click(object sender, EventArgs e)
        {
            int filas = vista.RowCount;
            for (int i = 0; i < filas; i++)
            {
                vista.SetRowCellValue(i, "Seleccionar", false);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int filas = vista.RowCount;
            int cantidadSeleccionado = 0;
            int idKam = Convert.ToInt32(cmbKAM.SelectedValue);
            


            for (int i = 0; i < filas; i++)
            {
                bool aux = bool.Parse(vista.GetRowCellValue(i, "Seleccionar").ToString());

                if (aux)
                {
                    cantidadSeleccionado++;
                    string cliente = (vista.GetRowCellValue(i, "Nombre_razonSocial").ToString());
                    //! AQUI CORRER PROCEDURE PARA ACTUALIZAR RELACION DE CLIENTE-KAM
                    int resultado = clienteDA.RelacionKAM(cliente,idKam);
                }

            }
            InicializarRelacionClienteKam();

        }
    }
}
