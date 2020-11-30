namespace Apolo
{
    partial class frmReporteFacturasPorVencer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteFacturasPorVencer));
            this.btnExportar = new System.Windows.Forms.Button();
            this.dgvFacturas = new DevExpress.XtraGrid.GridControl();
            this.vista = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ruc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaInicioContrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaFinContrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Factura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaInicioFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaFinFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CódigoLC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Guía = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoAntiguo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DíasAntesVencer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KAM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.verResumen = new System.Windows.Forms.Button();
            this.giftCarga = new System.Windows.Forms.PictureBox();
            this.cargarData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giftCarga)).BeginInit();
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
            this.btnExportar.Location = new System.Drawing.Point(1115, 27);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 63);
            this.btnExportar.TabIndex = 137;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFacturas.Location = new System.Drawing.Point(29, 109);
            this.dgvFacturas.MainView = this.vista;
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.Size = new System.Drawing.Size(1161, 378);
            this.dgvFacturas.TabIndex = 136;
            this.dgvFacturas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.vista});
            this.dgvFacturas.MouseLeave += new System.EventHandler(this.dgvFacturas_MouseLeave);
            this.dgvFacturas.MouseHover += new System.EventHandler(this.dgvFacturas_MouseHover);
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
            this.ruc,
            this.Cliente,
            this.FechaInicioContrato,
            this.FechaFinContrato,
            this.Factura,
            this.FechaInicioFactura,
            this.FechaFinFactura,
            this.CódigoLC,
            this.Guía,
            this.CodigoAntiguo,
            this.DíasAntesVencer,
            this.KAM});
            this.vista.GridControl = this.dgvFacturas;
            this.vista.Name = "vista";
            this.vista.OptionsBehavior.Editable = false;
            this.vista.OptionsView.ColumnAutoWidth = false;
            this.vista.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.vista.OptionsView.ShowAutoFilterRow = true;
            // 
            // ruc
            // 
            this.ruc.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ruc.AppearanceHeader.Options.UseBackColor = true;
            this.ruc.Caption = "Ruc";
            this.ruc.FieldName = "ruc";
            this.ruc.Name = "ruc";
            this.ruc.Visible = true;
            this.ruc.VisibleIndex = 1;
            // 
            // Cliente
            // 
            this.Cliente.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Cliente.AppearanceHeader.Options.UseBackColor = true;
            this.Cliente.Caption = "Cliente";
            this.Cliente.FieldName = "cliente";
            this.Cliente.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.Cliente.MinWidth = 40;
            this.Cliente.Name = "Cliente";
            this.Cliente.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Cliente.Visible = true;
            this.Cliente.VisibleIndex = 0;
            this.Cliente.Width = 200;
            // 
            // FechaInicioContrato
            // 
            this.FechaInicioContrato.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FechaInicioContrato.AppearanceHeader.Options.UseBackColor = true;
            this.FechaInicioContrato.Caption = "Inicio Plazo Alquiler";
            this.FechaInicioContrato.FieldName = "fecIniPlazoAlquiler";
            this.FechaInicioContrato.MinWidth = 40;
            this.FechaInicioContrato.Name = "FechaInicioContrato";
            this.FechaInicioContrato.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.FechaInicioContrato.Visible = true;
            this.FechaInicioContrato.VisibleIndex = 2;
            this.FechaInicioContrato.Width = 140;
            // 
            // FechaFinContrato
            // 
            this.FechaFinContrato.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FechaFinContrato.AppearanceHeader.Options.UseBackColor = true;
            this.FechaFinContrato.Caption = "Fin Plazo Alquiler";
            this.FechaFinContrato.FieldName = "fecFinPlazoAlquiler";
            this.FechaFinContrato.MinWidth = 40;
            this.FechaFinContrato.Name = "FechaFinContrato";
            this.FechaFinContrato.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.FechaFinContrato.Visible = true;
            this.FechaFinContrato.VisibleIndex = 3;
            this.FechaFinContrato.Width = 140;
            // 
            // Factura
            // 
            this.Factura.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Factura.AppearanceHeader.Options.UseBackColor = true;
            this.Factura.Caption = "Factura";
            this.Factura.FieldName = "factura";
            this.Factura.MinWidth = 40;
            this.Factura.Name = "Factura";
            this.Factura.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Factura.Visible = true;
            this.Factura.VisibleIndex = 4;
            this.Factura.Width = 140;
            // 
            // FechaInicioFactura
            // 
            this.FechaInicioFactura.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FechaInicioFactura.AppearanceHeader.Options.UseBackColor = true;
            this.FechaInicioFactura.Caption = "Fecha Inicio Factura";
            this.FechaInicioFactura.FieldName = "fecInicioFactura";
            this.FechaInicioFactura.MinWidth = 40;
            this.FechaInicioFactura.Name = "FechaInicioFactura";
            this.FechaInicioFactura.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.FechaInicioFactura.Visible = true;
            this.FechaInicioFactura.VisibleIndex = 5;
            this.FechaInicioFactura.Width = 140;
            // 
            // FechaFinFactura
            // 
            this.FechaFinFactura.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FechaFinFactura.AppearanceHeader.Options.UseBackColor = true;
            this.FechaFinFactura.Caption = "Fecha Fin Factura";
            this.FechaFinFactura.FieldName = "fecFinFactura";
            this.FechaFinFactura.MinWidth = 40;
            this.FechaFinFactura.Name = "FechaFinFactura";
            this.FechaFinFactura.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.FechaFinFactura.Visible = true;
            this.FechaFinFactura.VisibleIndex = 6;
            this.FechaFinFactura.Width = 140;
            // 
            // CódigoLC
            // 
            this.CódigoLC.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CódigoLC.AppearanceHeader.Options.UseBackColor = true;
            this.CódigoLC.Caption = "Código";
            this.CódigoLC.FieldName = "codigoEquipo";
            this.CódigoLC.MinWidth = 40;
            this.CódigoLC.Name = "CódigoLC";
            this.CódigoLC.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.CódigoLC.Visible = true;
            this.CódigoLC.VisibleIndex = 7;
            this.CódigoLC.Width = 140;
            // 
            // Guía
            // 
            this.Guía.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Guía.AppearanceHeader.Options.UseBackColor = true;
            this.Guía.Caption = "Guía";
            this.Guía.FieldName = "guia";
            this.Guía.MinWidth = 40;
            this.Guía.Name = "Guía";
            this.Guía.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Guía.Visible = true;
            this.Guía.VisibleIndex = 8;
            this.Guía.Width = 140;
            // 
            // CodigoAntiguo
            // 
            this.CodigoAntiguo.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CodigoAntiguo.AppearanceHeader.Options.UseBackColor = true;
            this.CodigoAntiguo.Caption = "Código Antiguo";
            this.CodigoAntiguo.FieldName = "CodigoAntiguo";
            this.CodigoAntiguo.MinWidth = 40;
            this.CodigoAntiguo.Name = "CodigoAntiguo";
            this.CodigoAntiguo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.CodigoAntiguo.Visible = true;
            this.CodigoAntiguo.VisibleIndex = 9;
            this.CodigoAntiguo.Width = 140;
            // 
            // DíasAntesVencer
            // 
            this.DíasAntesVencer.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DíasAntesVencer.AppearanceHeader.Options.UseBackColor = true;
            this.DíasAntesVencer.Caption = "Días Antes Vencer";
            this.DíasAntesVencer.FieldName = "diasAntesVencer";
            this.DíasAntesVencer.MinWidth = 40;
            this.DíasAntesVencer.Name = "DíasAntesVencer";
            this.DíasAntesVencer.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.DíasAntesVencer.Visible = true;
            this.DíasAntesVencer.VisibleIndex = 10;
            this.DíasAntesVencer.Width = 100;
            // 
            // KAM
            // 
            this.KAM.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.KAM.AppearanceHeader.Options.UseBackColor = true;
            this.KAM.Caption = "KAM";
            this.KAM.FieldName = "KAM";
            this.KAM.MinWidth = 40;
            this.KAM.Name = "KAM";
            this.KAM.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.KAM.Visible = true;
            this.KAM.VisibleIndex = 11;
            this.KAM.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 16);
            this.label1.TabIndex = 148;
            this.label1.Text = "CANTIDAD REGISTROS:";
            // 
            // verResumen
            // 
            this.verResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.verResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.verResumen.Location = new System.Drawing.Point(42, 17);
            this.verResumen.Name = "verResumen";
            this.verResumen.Size = new System.Drawing.Size(115, 19);
            this.verResumen.TabIndex = 147;
            this.verResumen.Text = "VER RESUMEN";
            this.verResumen.UseVisualStyleBackColor = false;
            // 
            // giftCarga
            // 
            this.giftCarga.Location = new System.Drawing.Point(550, -1);
            this.giftCarga.Name = "giftCarga";
            this.giftCarga.Size = new System.Drawing.Size(123, 82);
            this.giftCarga.TabIndex = 146;
            this.giftCarga.TabStop = false;
            // 
            // cargarData
            // 
            this.cargarData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cargarData.Location = new System.Drawing.Point(550, 87);
            this.cargarData.Name = "cargarData";
            this.cargarData.Size = new System.Drawing.Size(113, 19);
            this.cargarData.TabIndex = 145;
            this.cargarData.Text = "CARGANDO DATA";
            this.cargarData.UseVisualStyleBackColor = true;
            this.cargarData.Click += new System.EventHandler(this.cargarData_Click_1);
            // 
            // frmReporteFacturasPorVencer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1219, 515);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.verResumen);
            this.Controls.Add(this.giftCarga);
            this.Controls.Add(this.cargarData);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvFacturas);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "frmReporteFacturasPorVencer";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturas Por Vencer";
            this.Load += new System.EventHandler(this.frmReporteFacturasPorVencer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giftCarga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportar;
        private DevExpress.XtraGrid.GridControl dgvFacturas;
        private DevExpress.XtraGrid.Views.Grid.GridView vista;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn FechaInicioContrato;
        private DevExpress.XtraGrid.Columns.GridColumn FechaFinContrato;
        private DevExpress.XtraGrid.Columns.GridColumn Factura;
        private DevExpress.XtraGrid.Columns.GridColumn FechaInicioFactura;
        private DevExpress.XtraGrid.Columns.GridColumn FechaFinFactura;
        private DevExpress.XtraGrid.Columns.GridColumn CódigoLC;
        private DevExpress.XtraGrid.Columns.GridColumn Guía;
        private DevExpress.XtraGrid.Columns.GridColumn DíasAntesVencer;
        private DevExpress.XtraGrid.Columns.GridColumn KAM;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoAntiguo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button verResumen;
        public System.Windows.Forms.PictureBox giftCarga;
        public System.Windows.Forms.Button cargarData;
        private DevExpress.XtraGrid.Columns.GridColumn ruc;
    }
}