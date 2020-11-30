namespace Apolo
{
    partial class frmReporteInventarioPrueba
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteInventarioPrueba));
            this.btnExportar = new System.Windows.Forms.Button();
            this.dgvLaptops = new DevExpress.XtraGrid.GridControl();
            this.vista = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            this.CodigoLC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Marca = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Modelo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Procesador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Video = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CapacidadVideo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Disco1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CapacidadDisco1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Disco2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CapacidadDisco2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MemoriaRam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Estado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ubicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SerieFabrica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdSalida = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaptops)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.AutoSize = true;
            this.btnExportar.BackColor = System.Drawing.Color.Transparent;
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExportar.Location = new System.Drawing.Point(1077, 14);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(89, 63);
            this.btnExportar.TabIndex = 142;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dgvLaptops
            // 
            this.dgvLaptops.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLaptops.Location = new System.Drawing.Point(21, 83);
            this.dgvLaptops.MainView = this.vista;
            this.dgvLaptops.Name = "dgvLaptops";
            this.dgvLaptops.Size = new System.Drawing.Size(1145, 367);
            this.dgvLaptops.TabIndex = 141;
            this.dgvLaptops.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.vista});
            // 
            // vista
            // 
            this.vista.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vista.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.vista.Appearance.HeaderPanel.Options.UseFont = true;
            this.vista.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.vista.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.vista.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vista.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vista.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vista.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.vista.Appearance.Row.Options.UseFont = true;
            this.vista.Appearance.Row.Options.UseForeColor = true;
            this.vista.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CodigoLC,
            this.Marca,
            this.Modelo,
            this.Procesador,
            this.Video,
            this.CapacidadVideo,
            this.Disco1,
            this.CapacidadDisco1,
            this.Disco2,
            this.CapacidadDisco2,
            this.MemoriaRam,
            this.Estado,
            this.Cliente,
            this.Ubicacion,
            this.SerieFabrica,
            this.IdSalida});
            this.vista.GridControl = this.dgvLaptops;
            this.vista.Name = "vista";
            this.vista.OptionsBehavior.Editable = false;
            this.vista.OptionsView.ColumnAutoWidth = false;
            this.vista.OptionsView.ShowAutoFilterRow = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 140;
            this.label1.Text = "Reporte de Laptops";
            // 
            // CodigoLC
            // 
            this.CodigoLC.Caption = "Código LC";
            this.CodigoLC.FieldName = "Codigo";
            this.CodigoLC.MinWidth = 40;
            this.CodigoLC.Name = "CodigoLC";
            this.CodigoLC.Visible = true;
            this.CodigoLC.VisibleIndex = 0;
            this.CodigoLC.Width = 130;
            // 
            // Marca
            // 
            this.Marca.Caption = "Marca";
            this.Marca.FieldName = "MarcaLC";
            this.Marca.MinWidth = 40;
            this.Marca.Name = "Marca";
            this.Marca.Visible = true;
            this.Marca.VisibleIndex = 1;
            this.Marca.Width = 100;
            // 
            // Modelo
            // 
            this.Modelo.Caption = "Modelo";
            this.Modelo.FieldName = "NombreModeloLC";
            this.Modelo.MinWidth = 40;
            this.Modelo.Name = "Modelo";
            this.Modelo.Visible = true;
            this.Modelo.VisibleIndex = 2;
            this.Modelo.Width = 200;
            // 
            // Procesador
            // 
            this.Procesador.Caption = "Procesador";
            this.Procesador.FieldName = "TipoProcesador";
            this.Procesador.MinWidth = 40;
            this.Procesador.Name = "Procesador";
            this.Procesador.Visible = true;
            this.Procesador.VisibleIndex = 3;
            this.Procesador.Width = 100;
            // 
            // Video
            // 
            this.Video.Caption = "Video";
            this.Video.FieldName = "NombreModeloVideo";
            this.Video.MinWidth = 40;
            this.Video.Name = "Video";
            this.Video.Width = 170;
            // 
            // CapacidadVideo
            // 
            this.CapacidadVideo.Caption = "Capacidad Video";
            this.CapacidadVideo.FieldName = "CapacidadVideo";
            this.CapacidadVideo.MinWidth = 40;
            this.CapacidadVideo.Name = "CapacidadVideo";
            this.CapacidadVideo.Visible = true;
            this.CapacidadVideo.VisibleIndex = 4;
            this.CapacidadVideo.Width = 130;
            // 
            // Disco1
            // 
            this.Disco1.Caption = "Disco1";
            this.Disco1.FieldName = "Disco1";
            this.Disco1.MinWidth = 40;
            this.Disco1.Name = "Disco1";
            this.Disco1.Visible = true;
            this.Disco1.VisibleIndex = 5;
            this.Disco1.Width = 70;
            // 
            // CapacidadDisco1
            // 
            this.CapacidadDisco1.Caption = "Capacidad Disco1";
            this.CapacidadDisco1.FieldName = "CapacidadDisco1";
            this.CapacidadDisco1.MinWidth = 40;
            this.CapacidadDisco1.Name = "CapacidadDisco1";
            this.CapacidadDisco1.Visible = true;
            this.CapacidadDisco1.VisibleIndex = 6;
            this.CapacidadDisco1.Width = 130;
            // 
            // Disco2
            // 
            this.Disco2.Caption = "Disco2";
            this.Disco2.FieldName = "Disco2";
            this.Disco2.MinWidth = 40;
            this.Disco2.Name = "Disco2";
            this.Disco2.Visible = true;
            this.Disco2.VisibleIndex = 7;
            this.Disco2.Width = 70;
            // 
            // CapacidadDisco2
            // 
            this.CapacidadDisco2.Caption = "Capacidad Disco2";
            this.CapacidadDisco2.FieldName = "CapacidadDisco2";
            this.CapacidadDisco2.MinWidth = 40;
            this.CapacidadDisco2.Name = "CapacidadDisco2";
            this.CapacidadDisco2.Visible = true;
            this.CapacidadDisco2.VisibleIndex = 8;
            this.CapacidadDisco2.Width = 130;
            // 
            // MemoriaRam
            // 
            this.MemoriaRam.Caption = "Memoria Ram";
            this.MemoriaRam.FieldName = "CapacidadMemoria";
            this.MemoriaRam.MinWidth = 40;
            this.MemoriaRam.Name = "MemoriaRam";
            this.MemoriaRam.Visible = true;
            this.MemoriaRam.VisibleIndex = 9;
            this.MemoriaRam.Width = 100;
            // 
            // Estado
            // 
            this.Estado.Caption = "Estado";
            this.Estado.FieldName = "EstadoNombre";
            this.Estado.MinWidth = 40;
            this.Estado.Name = "Estado";
            this.Estado.Visible = true;
            this.Estado.VisibleIndex = 10;
            this.Estado.Width = 130;
            // 
            // Cliente
            // 
            this.Cliente.Caption = "Cliente";
            this.Cliente.FieldName = "Cliente";
            this.Cliente.MinWidth = 40;
            this.Cliente.Name = "Cliente";
            this.Cliente.Visible = true;
            this.Cliente.VisibleIndex = 11;
            this.Cliente.Width = 150;
            // 
            // Ubicacion
            // 
            this.Ubicacion.Caption = "Ubicación";
            this.Ubicacion.FieldName = "Ubicacion";
            this.Ubicacion.MinWidth = 40;
            this.Ubicacion.Name = "Ubicacion";
            this.Ubicacion.Visible = true;
            this.Ubicacion.VisibleIndex = 12;
            this.Ubicacion.Width = 150;
            // 
            // SerieFabrica
            // 
            this.SerieFabrica.Caption = "Serie Fabrica";
            this.SerieFabrica.FieldName = "SerieFabrica";
            this.SerieFabrica.MinWidth = 40;
            this.SerieFabrica.Name = "SerieFabrica";
            this.SerieFabrica.Visible = true;
            this.SerieFabrica.VisibleIndex = 13;
            this.SerieFabrica.Width = 150;
            // 
            // IdSalida
            // 
            this.IdSalida.Caption = "Id Salida";
            this.IdSalida.FieldName = "IdSalida";
            this.IdSalida.MinWidth = 40;
            this.IdSalida.Name = "IdSalida";
            this.IdSalida.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.IdSalida.Visible = true;
            this.IdSalida.VisibleIndex = 14;
            this.IdSalida.Width = 80;
            // 
            // frmReporteInventarioPrueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 461);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvLaptops);
            this.Controls.Add(this.label1);
            this.Name = "frmReporteInventarioPrueba";
            this.Text = "frmReporteInventarioPrueba";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaptops)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportar;
        private DevExpress.XtraGrid.GridControl dgvLaptops;
        private DevExpress.XtraGrid.Views.Grid.GridView vista;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoLC;
        private DevExpress.XtraGrid.Columns.GridColumn Marca;
        private DevExpress.XtraGrid.Columns.GridColumn Modelo;
        private DevExpress.XtraGrid.Columns.GridColumn Procesador;
        private DevExpress.XtraGrid.Columns.GridColumn Video;
        private DevExpress.XtraGrid.Columns.GridColumn CapacidadVideo;
        private DevExpress.XtraGrid.Columns.GridColumn Disco1;
        private DevExpress.XtraGrid.Columns.GridColumn CapacidadDisco1;
        private DevExpress.XtraGrid.Columns.GridColumn Disco2;
        private DevExpress.XtraGrid.Columns.GridColumn CapacidadDisco2;
        private DevExpress.XtraGrid.Columns.GridColumn MemoriaRam;
        private DevExpress.XtraGrid.Columns.GridColumn Estado;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn Ubicacion;
        private DevExpress.XtraGrid.Columns.GridColumn SerieFabrica;
        private DevExpress.XtraGrid.Columns.GridColumn IdSalida;
        private System.Windows.Forms.Label label1;
    }
}