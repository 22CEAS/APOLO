namespace Apolo
{
    partial class frmReportePendienteReposicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportePendienteReposicion));
            this.dgvObservaciones = new DevExpress.XtraGrid.GridControl();
            this.vista = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RUC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoLC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ObservaciónDeuda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GuiaLevantamiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ObservacionLevantamiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaLevantamiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Estado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KAM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.verResumen = new System.Windows.Forms.Button();
            this.giftCarga = new System.Windows.Forms.PictureBox();
            this.cargarData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObservaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giftCarga)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvObservaciones
            // 
            this.dgvObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvObservaciones.Location = new System.Drawing.Point(27, 177);
            this.dgvObservaciones.MainView = this.vista;
            this.dgvObservaciones.Name = "dgvObservaciones";
            this.dgvObservaciones.Size = new System.Drawing.Size(1018, 359);
            this.dgvObservaciones.TabIndex = 133;
            this.dgvObservaciones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.vista});
            this.dgvObservaciones.MouseLeave += new System.EventHandler(this.dgvObservaciones_MouseLeave);
            this.dgvObservaciones.MouseHover += new System.EventHandler(this.dgvObservaciones_MouseHover);
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
            this.Cliente,
            this.RUC,
            this.CodigoLC,
            this.ObservaciónDeuda,
            this.GuiaLevantamiento,
            this.ObservacionLevantamiento,
            this.FechaLevantamiento,
            this.Estado,
            this.KAM});
            this.vista.GridControl = this.dgvObservaciones;
            this.vista.Name = "vista";
            this.vista.OptionsBehavior.Editable = false;
            this.vista.OptionsView.ColumnAutoWidth = false;
            this.vista.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.vista.OptionsView.ShowAutoFilterRow = true;
            // 
            // Cliente
            // 
            this.Cliente.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Cliente.AppearanceHeader.Options.UseBackColor = true;
            this.Cliente.Caption = "Cliente";
            this.Cliente.FieldName = "Cliente";
            this.Cliente.MinWidth = 40;
            this.Cliente.Name = "Cliente";
            this.Cliente.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Cliente.Visible = true;
            this.Cliente.VisibleIndex = 0;
            this.Cliente.Width = 150;
            // 
            // RUC
            // 
            this.RUC.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.RUC.AppearanceHeader.Options.UseBackColor = true;
            this.RUC.Caption = "RUC";
            this.RUC.FieldName = "RUC";
            this.RUC.MinWidth = 40;
            this.RUC.Name = "RUC";
            this.RUC.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.RUC.Visible = true;
            this.RUC.VisibleIndex = 1;
            // 
            // CodigoLC
            // 
            this.CodigoLC.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CodigoLC.AppearanceHeader.Options.UseBackColor = true;
            this.CodigoLC.Caption = "Código";
            this.CodigoLC.FieldName = "CodigoLC";
            this.CodigoLC.MinWidth = 40;
            this.CodigoLC.Name = "CodigoLC";
            this.CodigoLC.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.CodigoLC.Visible = true;
            this.CodigoLC.VisibleIndex = 2;
            this.CodigoLC.Width = 100;
            // 
            // ObservaciónDeuda
            // 
            this.ObservaciónDeuda.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ObservaciónDeuda.AppearanceHeader.Options.UseBackColor = true;
            this.ObservaciónDeuda.Caption = "Observación Deuda";
            this.ObservaciónDeuda.FieldName = "ObservacionDeuda";
            this.ObservaciónDeuda.MinWidth = 40;
            this.ObservaciónDeuda.Name = "ObservaciónDeuda";
            this.ObservaciónDeuda.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.ObservaciónDeuda.Visible = true;
            this.ObservaciónDeuda.VisibleIndex = 3;
            this.ObservaciónDeuda.Width = 250;
            // 
            // GuiaLevantamiento
            // 
            this.GuiaLevantamiento.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.GuiaLevantamiento.AppearanceHeader.Options.UseBackColor = true;
            this.GuiaLevantamiento.Caption = "Guia Levantamiento";
            this.GuiaLevantamiento.FieldName = "GuiaLevantamiento";
            this.GuiaLevantamiento.MinWidth = 40;
            this.GuiaLevantamiento.Name = "GuiaLevantamiento";
            this.GuiaLevantamiento.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.GuiaLevantamiento.Visible = true;
            this.GuiaLevantamiento.VisibleIndex = 4;
            this.GuiaLevantamiento.Width = 150;
            // 
            // ObservacionLevantamiento
            // 
            this.ObservacionLevantamiento.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ObservacionLevantamiento.AppearanceHeader.Options.UseBackColor = true;
            this.ObservacionLevantamiento.Caption = "Observación Levantamiento";
            this.ObservacionLevantamiento.FieldName = "ObservacionLevantamiento";
            this.ObservacionLevantamiento.MinWidth = 40;
            this.ObservacionLevantamiento.Name = "ObservacionLevantamiento";
            this.ObservacionLevantamiento.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.ObservacionLevantamiento.Visible = true;
            this.ObservacionLevantamiento.VisibleIndex = 5;
            this.ObservacionLevantamiento.Width = 250;
            // 
            // FechaLevantamiento
            // 
            this.FechaLevantamiento.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FechaLevantamiento.AppearanceHeader.Options.UseBackColor = true;
            this.FechaLevantamiento.Caption = "Fecha Levantamiento";
            this.FechaLevantamiento.FieldName = "FechaLevantamiento";
            this.FechaLevantamiento.MinWidth = 40;
            this.FechaLevantamiento.Name = "FechaLevantamiento";
            this.FechaLevantamiento.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.FechaLevantamiento.Visible = true;
            this.FechaLevantamiento.VisibleIndex = 6;
            this.FechaLevantamiento.Width = 150;
            // 
            // Estado
            // 
            this.Estado.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Estado.AppearanceHeader.Options.UseBackColor = true;
            this.Estado.Caption = "Estado";
            this.Estado.FieldName = "Estado";
            this.Estado.MinWidth = 40;
            this.Estado.Name = "Estado";
            this.Estado.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Estado.Visible = true;
            this.Estado.VisibleIndex = 7;
            this.Estado.Width = 80;
            // 
            // KAM
            // 
            this.KAM.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.KAM.AppearanceHeader.Options.UseBackColor = true;
            this.KAM.Caption = "KAM";
            this.KAM.FieldName = "KAM";
            this.KAM.Name = "KAM";
            this.KAM.Visible = true;
            this.KAM.VisibleIndex = 8;
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
            this.btnExportar.Location = new System.Drawing.Point(970, 12);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 63);
            this.btnExportar.TabIndex = 134;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 16);
            this.label1.TabIndex = 156;
            this.label1.Text = "CANTIDAD REGISTROS:";
            // 
            // verResumen
            // 
            this.verResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.verResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.verResumen.Location = new System.Drawing.Point(43, 32);
            this.verResumen.Name = "verResumen";
            this.verResumen.Size = new System.Drawing.Size(115, 19);
            this.verResumen.TabIndex = 155;
            this.verResumen.Text = "VER RESUMEN";
            this.verResumen.UseVisualStyleBackColor = false;
            this.verResumen.Click += new System.EventHandler(this.verResumen_Click);
            // 
            // giftCarga
            // 
            this.giftCarga.Location = new System.Drawing.Point(567, 25);
            this.giftCarga.Name = "giftCarga";
            this.giftCarga.Size = new System.Drawing.Size(123, 82);
            this.giftCarga.TabIndex = 154;
            this.giftCarga.TabStop = false;
            // 
            // cargarData
            // 
            this.cargarData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cargarData.Location = new System.Drawing.Point(577, 113);
            this.cargarData.Name = "cargarData";
            this.cargarData.Size = new System.Drawing.Size(113, 19);
            this.cargarData.TabIndex = 153;
            this.cargarData.Text = "CARGANDO DATA";
            this.cargarData.UseVisualStyleBackColor = true;
            this.cargarData.Click += new System.EventHandler(this.cargarData_Click);
            // 
            // frmReportePendienteReposicion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1075, 548);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.verResumen);
            this.Controls.Add(this.giftCarga);
            this.Controls.Add(this.cargarData);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvObservaciones);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "frmReportePendienteReposicion";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Observaciones";
            this.Load += new System.EventHandler(this.frmReportePendienteReposicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObservaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giftCarga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl dgvObservaciones;
        private DevExpress.XtraGrid.Views.Grid.GridView vista;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn RUC;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoLC;
        private DevExpress.XtraGrid.Columns.GridColumn ObservaciónDeuda;
        private DevExpress.XtraGrid.Columns.GridColumn GuiaLevantamiento;
        private DevExpress.XtraGrid.Columns.GridColumn ObservacionLevantamiento;
        private DevExpress.XtraGrid.Columns.GridColumn FechaLevantamiento;
        private DevExpress.XtraGrid.Columns.GridColumn Estado;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button verResumen;
        public System.Windows.Forms.PictureBox giftCarga;
        public System.Windows.Forms.Button cargarData;
        private DevExpress.XtraGrid.Columns.GridColumn KAM;
    }
}