namespace Apolo
{
    partial class frmReporteMantenimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteMantenimiento));
            this.btnExportar = new System.Windows.Forms.Button();
            this.dgvReparaciones = new DevExpress.XtraGrid.GridControl();
            this.vista = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IdReparacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoLC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaReparacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescripcionComoSeEncontro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EstadoAntesReparacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescripcionReparacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EstadoLuegoReparacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Responsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EstadoReparacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.verResumen = new System.Windows.Forms.Button();
            this.giftCarga = new System.Windows.Forms.PictureBox();
            this.cargarData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReparaciones)).BeginInit();
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
            this.btnExportar.Location = new System.Drawing.Point(950, 13);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 63);
            this.btnExportar.TabIndex = 136;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dgvReparaciones
            // 
            this.dgvReparaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReparaciones.Location = new System.Drawing.Point(25, 134);
            this.dgvReparaciones.MainView = this.vista;
            this.dgvReparaciones.Name = "dgvReparaciones";
            this.dgvReparaciones.Size = new System.Drawing.Size(1000, 320);
            this.dgvReparaciones.TabIndex = 135;
            this.dgvReparaciones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.vista});
            this.dgvReparaciones.MouseLeave += new System.EventHandler(this.dgvReparaciones_MouseLeave);
            this.dgvReparaciones.MouseHover += new System.EventHandler(this.dgvReparaciones_MouseHover);
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
            this.IdReparacion,
            this.CodigoLC,
            this.FechaReparacion,
            this.DescripcionComoSeEncontro,
            this.EstadoAntesReparacion,
            this.DescripcionReparacion,
            this.EstadoLuegoReparacion,
            this.Responsable,
            this.EstadoReparacion});
            this.vista.GridControl = this.dgvReparaciones;
            this.vista.Name = "vista";
            this.vista.OptionsBehavior.Editable = false;
            this.vista.OptionsView.ColumnAutoWidth = false;
            this.vista.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.vista.OptionsView.ShowAutoFilterRow = true;
            // 
            // IdReparacion
            // 
            this.IdReparacion.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.IdReparacion.AppearanceHeader.Options.UseBackColor = true;
            this.IdReparacion.Caption = "Id Reparación";
            this.IdReparacion.FieldName = "IdReparacion";
            this.IdReparacion.MinWidth = 40;
            this.IdReparacion.Name = "IdReparacion";
            this.IdReparacion.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.IdReparacion.Visible = true;
            this.IdReparacion.VisibleIndex = 0;
            this.IdReparacion.Width = 100;
            // 
            // CodigoLC
            // 
            this.CodigoLC.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CodigoLC.AppearanceHeader.Options.UseBackColor = true;
            this.CodigoLC.Caption = "Codigo";
            this.CodigoLC.FieldName = "CodigoLC";
            this.CodigoLC.MinWidth = 40;
            this.CodigoLC.Name = "CodigoLC";
            this.CodigoLC.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.CodigoLC.Visible = true;
            this.CodigoLC.VisibleIndex = 1;
            this.CodigoLC.Width = 100;
            // 
            // FechaReparacion
            // 
            this.FechaReparacion.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FechaReparacion.AppearanceHeader.Options.UseBackColor = true;
            this.FechaReparacion.Caption = "Fecha Reparación";
            this.FechaReparacion.FieldName = "FechaReparacion";
            this.FechaReparacion.MinWidth = 40;
            this.FechaReparacion.Name = "FechaReparacion";
            this.FechaReparacion.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.FechaReparacion.Visible = true;
            this.FechaReparacion.VisibleIndex = 2;
            this.FechaReparacion.Width = 100;
            // 
            // DescripcionComoSeEncontro
            // 
            this.DescripcionComoSeEncontro.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DescripcionComoSeEncontro.AppearanceHeader.Options.UseBackColor = true;
            this.DescripcionComoSeEncontro.Caption = "Descripcion Como Se Encontro";
            this.DescripcionComoSeEncontro.FieldName = "DescripcionComoSeEncontro";
            this.DescripcionComoSeEncontro.MinWidth = 40;
            this.DescripcionComoSeEncontro.Name = "DescripcionComoSeEncontro";
            this.DescripcionComoSeEncontro.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.DescripcionComoSeEncontro.Visible = true;
            this.DescripcionComoSeEncontro.VisibleIndex = 3;
            this.DescripcionComoSeEncontro.Width = 250;
            // 
            // EstadoAntesReparacion
            // 
            this.EstadoAntesReparacion.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.EstadoAntesReparacion.AppearanceHeader.Options.UseBackColor = true;
            this.EstadoAntesReparacion.Caption = "Estado Antes Reparación";
            this.EstadoAntesReparacion.FieldName = "EstadoAntesReparacion";
            this.EstadoAntesReparacion.MinWidth = 40;
            this.EstadoAntesReparacion.Name = "EstadoAntesReparacion";
            this.EstadoAntesReparacion.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.EstadoAntesReparacion.Visible = true;
            this.EstadoAntesReparacion.VisibleIndex = 4;
            this.EstadoAntesReparacion.Width = 150;
            // 
            // DescripcionReparacion
            // 
            this.DescripcionReparacion.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DescripcionReparacion.AppearanceHeader.Options.UseBackColor = true;
            this.DescripcionReparacion.Caption = "Descripción Reparación";
            this.DescripcionReparacion.FieldName = "DescripcionReparacion";
            this.DescripcionReparacion.MinWidth = 40;
            this.DescripcionReparacion.Name = "DescripcionReparacion";
            this.DescripcionReparacion.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.DescripcionReparacion.Visible = true;
            this.DescripcionReparacion.VisibleIndex = 5;
            this.DescripcionReparacion.Width = 250;
            // 
            // EstadoLuegoReparacion
            // 
            this.EstadoLuegoReparacion.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.EstadoLuegoReparacion.AppearanceHeader.Options.UseBackColor = true;
            this.EstadoLuegoReparacion.Caption = "Estado Luego Reparación";
            this.EstadoLuegoReparacion.FieldName = "EstadoLuegoReparacion";
            this.EstadoLuegoReparacion.MinWidth = 40;
            this.EstadoLuegoReparacion.Name = "EstadoLuegoReparacion";
            this.EstadoLuegoReparacion.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.EstadoLuegoReparacion.Visible = true;
            this.EstadoLuegoReparacion.VisibleIndex = 6;
            this.EstadoLuegoReparacion.Width = 150;
            // 
            // Responsable
            // 
            this.Responsable.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Responsable.AppearanceHeader.Options.UseBackColor = true;
            this.Responsable.Caption = "Responsable";
            this.Responsable.FieldName = "Responsable";
            this.Responsable.MinWidth = 40;
            this.Responsable.Name = "Responsable";
            this.Responsable.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Responsable.Visible = true;
            this.Responsable.VisibleIndex = 7;
            this.Responsable.Width = 150;
            // 
            // EstadoReparacion
            // 
            this.EstadoReparacion.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.EstadoReparacion.AppearanceHeader.Options.UseBackColor = true;
            this.EstadoReparacion.Caption = "Estado Reparación";
            this.EstadoReparacion.FieldName = "Estado";
            this.EstadoReparacion.MinWidth = 40;
            this.EstadoReparacion.Name = "EstadoReparacion";
            this.EstadoReparacion.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.EstadoReparacion.Visible = true;
            this.EstadoReparacion.VisibleIndex = 8;
            this.EstadoReparacion.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 16);
            this.label1.TabIndex = 156;
            this.label1.Text = "CANTIDAD REGISTROS:";
            // 
            // verResumen
            // 
            this.verResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.verResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.verResumen.Location = new System.Drawing.Point(56, 20);
            this.verResumen.Name = "verResumen";
            this.verResumen.Size = new System.Drawing.Size(115, 19);
            this.verResumen.TabIndex = 155;
            this.verResumen.Text = "VER RESUMEN";
            this.verResumen.UseVisualStyleBackColor = false;
            this.verResumen.Click += new System.EventHandler(this.verResumen_Click);
            // 
            // giftCarga
            // 
            this.giftCarga.Location = new System.Drawing.Point(483, 12);
            this.giftCarga.Name = "giftCarga";
            this.giftCarga.Size = new System.Drawing.Size(123, 82);
            this.giftCarga.TabIndex = 154;
            this.giftCarga.TabStop = false;
            // 
            // cargarData
            // 
            this.cargarData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cargarData.Location = new System.Drawing.Point(483, 100);
            this.cargarData.Name = "cargarData";
            this.cargarData.Size = new System.Drawing.Size(113, 19);
            this.cargarData.TabIndex = 153;
            this.cargarData.Text = "CARGANDO DATA";
            this.cargarData.UseVisualStyleBackColor = true;
            this.cargarData.Click += new System.EventHandler(this.cargarData_Click);
            // 
            // frmReporteMantenimiento
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1058, 491);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.verResumen);
            this.Controls.Add(this.giftCarga);
            this.Controls.Add(this.cargarData);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvReparaciones);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "frmReporteMantenimiento";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Mantenimientos";
            this.Load += new System.EventHandler(this.frmReporteMantenimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReparaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giftCarga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportar;
        private DevExpress.XtraGrid.GridControl dgvReparaciones;
        private DevExpress.XtraGrid.Views.Grid.GridView vista;
        private DevExpress.XtraGrid.Columns.GridColumn IdReparacion;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoLC;
        private DevExpress.XtraGrid.Columns.GridColumn FechaReparacion;
        private DevExpress.XtraGrid.Columns.GridColumn DescripcionComoSeEncontro;
        private DevExpress.XtraGrid.Columns.GridColumn EstadoAntesReparacion;
        private DevExpress.XtraGrid.Columns.GridColumn DescripcionReparacion;
        private DevExpress.XtraGrid.Columns.GridColumn EstadoLuegoReparacion;
        private DevExpress.XtraGrid.Columns.GridColumn EstadoReparacion;
        private DevExpress.XtraGrid.Columns.GridColumn Responsable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button verResumen;
        public System.Windows.Forms.PictureBox giftCarga;
        public System.Windows.Forms.Button cargarData;
    }
}