namespace Apolo
{
    partial class frmProcesoCorteAlquilerAgregarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesoCorteAlquilerAgregarProducto));
            this.btnDeseleccionarFilas = new System.Windows.Forms.Button();
            this.btnSeleccionarFilas = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.dgvRenovacionProductos = new DevExpress.XtraGrid.GridControl();
            this.vista = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Seleccionar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoAntiguo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Marca = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Modelo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Pantalla = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Procesador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Generacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Video = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Capacidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fecIniContrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fecFinContrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdLC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdVideo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdProcesador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdSalidaDetalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdSalida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GuiaSalida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaIniContratoAntiguo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaFinContratoAntiguo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRenovacionProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeseleccionarFilas
            // 
            this.btnDeseleccionarFilas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeseleccionarFilas.AutoSize = true;
            this.btnDeseleccionarFilas.BackColor = System.Drawing.Color.Transparent;
            this.btnDeseleccionarFilas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeseleccionarFilas.FlatAppearance.BorderSize = 0;
            this.btnDeseleccionarFilas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeseleccionarFilas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeseleccionarFilas.Image = ((System.Drawing.Image)(resources.GetObject("btnDeseleccionarFilas.Image")));
            this.btnDeseleccionarFilas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeseleccionarFilas.Location = new System.Drawing.Point(142, 12);
            this.btnDeseleccionarFilas.Name = "btnDeseleccionarFilas";
            this.btnDeseleccionarFilas.Size = new System.Drawing.Size(144, 50);
            this.btnDeseleccionarFilas.TabIndex = 145;
            this.btnDeseleccionarFilas.Text = "Deseleccionar Filas";
            this.btnDeseleccionarFilas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeseleccionarFilas.UseVisualStyleBackColor = false;
            this.btnDeseleccionarFilas.Click += new System.EventHandler(this.btnDeseleccionarFilas_Click);
            // 
            // btnSeleccionarFilas
            // 
            this.btnSeleccionarFilas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionarFilas.AutoSize = true;
            this.btnSeleccionarFilas.BackColor = System.Drawing.Color.Transparent;
            this.btnSeleccionarFilas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarFilas.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarFilas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarFilas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarFilas.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionarFilas.Image")));
            this.btnSeleccionarFilas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeleccionarFilas.Location = new System.Drawing.Point(20, 12);
            this.btnSeleccionarFilas.Name = "btnSeleccionarFilas";
            this.btnSeleccionarFilas.Size = new System.Drawing.Size(128, 50);
            this.btnSeleccionarFilas.TabIndex = 144;
            this.btnSeleccionarFilas.Text = "Seleccionar Filas";
            this.btnSeleccionarFilas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSeleccionarFilas.UseVisualStyleBackColor = false;
            this.btnSeleccionarFilas.Click += new System.EventHandler(this.btnSeleccionarFilas_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionar.AutoSize = true;
            this.btnSeleccionar.BackColor = System.Drawing.Color.Transparent;
            this.btnSeleccionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionar.FlatAppearance.BorderSize = 0;
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionar.Image")));
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeleccionar.Location = new System.Drawing.Point(767, 414);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(111, 67);
            this.btnSeleccionar.TabIndex = 142;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // dgvRenovacionProductos
            // 
            this.dgvRenovacionProductos.Location = new System.Drawing.Point(22, 77);
            this.dgvRenovacionProductos.MainView = this.vista;
            this.dgvRenovacionProductos.Name = "dgvRenovacionProductos";
            this.dgvRenovacionProductos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.dgvRenovacionProductos.Size = new System.Drawing.Size(874, 321);
            this.dgvRenovacionProductos.TabIndex = 140;
            this.dgvRenovacionProductos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.Seleccionar,
            this.Codigo,
            this.CodigoAntiguo,
            this.Marca,
            this.Modelo,
            this.Pantalla,
            this.Procesador,
            this.Generacion,
            this.Video,
            this.Capacidad,
            this.fecIniContrato,
            this.fecFinContrato,
            this.IdLC,
            this.IdVideo,
            this.IdProcesador,
            this.IdSalidaDetalle,
            this.IdSucursal,
            this.IdSalida,
            this.GuiaSalida,
            this.FechaIniContratoAntiguo,
            this.FechaFinContratoAntiguo});
            this.vista.GridControl = this.dgvRenovacionProductos;
            this.vista.Name = "vista";
            this.vista.OptionsSelection.MultiSelect = true;
            this.vista.OptionsView.ColumnAutoWidth = false;
            this.vista.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.vista.OptionsView.ShowAutoFilterRow = true;
            // 
            // Seleccionar
            // 
            this.Seleccionar.Caption = "Seleccionar";
            this.Seleccionar.ColumnEdit = this.repositoryItemCheckEdit1;
            this.Seleccionar.FieldName = "Seleccion";
            this.Seleccionar.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.Seleccionar.MinWidth = 50;
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.Seleccionar.Visible = true;
            this.Seleccionar.VisibleIndex = 0;
            this.Seleccionar.Width = 100;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Código";
            this.Codigo.FieldName = "Codigo";
            this.Codigo.MinWidth = 140;
            this.Codigo.Name = "Codigo";
            this.Codigo.OptionsColumn.AllowEdit = false;
            this.Codigo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Codigo.Visible = true;
            this.Codigo.VisibleIndex = 1;
            this.Codigo.Width = 140;
            // 
            // CodigoAntiguo
            // 
            this.CodigoAntiguo.Caption = "Código Antiguo";
            this.CodigoAntiguo.FieldName = "CodigoAntiguo";
            this.CodigoAntiguo.MinWidth = 140;
            this.CodigoAntiguo.Name = "CodigoAntiguo";
            this.CodigoAntiguo.OptionsColumn.AllowEdit = false;
            this.CodigoAntiguo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.CodigoAntiguo.Visible = true;
            this.CodigoAntiguo.VisibleIndex = 2;
            this.CodigoAntiguo.Width = 140;
            // 
            // Marca
            // 
            this.Marca.Caption = "Marca";
            this.Marca.FieldName = "MarcaLC";
            this.Marca.MinWidth = 100;
            this.Marca.Name = "Marca";
            this.Marca.OptionsColumn.AllowEdit = false;
            this.Marca.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Marca.Visible = true;
            this.Marca.VisibleIndex = 3;
            this.Marca.Width = 100;
            // 
            // Modelo
            // 
            this.Modelo.Caption = "Modelo";
            this.Modelo.FieldName = "NombreModeloLC";
            this.Modelo.MinWidth = 100;
            this.Modelo.Name = "Modelo";
            this.Modelo.OptionsColumn.AllowEdit = false;
            this.Modelo.Visible = true;
            this.Modelo.VisibleIndex = 4;
            this.Modelo.Width = 100;
            // 
            // Pantalla
            // 
            this.Pantalla.Caption = "Pantalla";
            this.Pantalla.FieldName = "TamanoPantalla";
            this.Pantalla.MinWidth = 60;
            this.Pantalla.Name = "Pantalla";
            this.Pantalla.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.Pantalla.Width = 60;
            // 
            // Procesador
            // 
            this.Procesador.Caption = "Procesador";
            this.Procesador.FieldName = "TipoProcesador";
            this.Procesador.MinWidth = 70;
            this.Procesador.Name = "Procesador";
            this.Procesador.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Procesador.Width = 70;
            // 
            // Generacion
            // 
            this.Generacion.Caption = "Generación";
            this.Generacion.FieldName = "GeneracionProcesador";
            this.Generacion.MinWidth = 70;
            this.Generacion.Name = "Generacion";
            this.Generacion.Width = 70;
            // 
            // Video
            // 
            this.Video.Caption = "Video";
            this.Video.FieldName = "NombreModeloVideo";
            this.Video.MinWidth = 100;
            this.Video.Name = "Video";
            this.Video.Width = 100;
            // 
            // Capacidad
            // 
            this.Capacidad.Caption = "Capacidad";
            this.Capacidad.FieldName = "CapacidadVideo";
            this.Capacidad.MinWidth = 70;
            this.Capacidad.Name = "Capacidad";
            this.Capacidad.Width = 70;
            // 
            // fecIniContrato
            // 
            this.fecIniContrato.Caption = "Inicio Plazo Alquiler";
            this.fecIniContrato.FieldName = "fecIniContrato";
            this.fecIniContrato.MinWidth = 140;
            this.fecIniContrato.Name = "fecIniContrato";
            this.fecIniContrato.OptionsColumn.AllowEdit = false;
            this.fecIniContrato.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.fecIniContrato.Visible = true;
            this.fecIniContrato.VisibleIndex = 5;
            this.fecIniContrato.Width = 140;
            // 
            // fecFinContrato
            // 
            this.fecFinContrato.Caption = "Fin Plazo Alquiler";
            this.fecFinContrato.FieldName = "fecFinContrato";
            this.fecFinContrato.MinWidth = 140;
            this.fecFinContrato.Name = "fecFinContrato";
            this.fecFinContrato.OptionsColumn.AllowEdit = false;
            this.fecFinContrato.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.fecFinContrato.Visible = true;
            this.fecFinContrato.VisibleIndex = 6;
            this.fecFinContrato.Width = 140;
            // 
            // IdLC
            // 
            this.IdLC.Caption = "IdLC";
            this.IdLC.FieldName = "IdLC";
            this.IdLC.Name = "IdLC";
            // 
            // IdVideo
            // 
            this.IdVideo.Caption = "IdVideo";
            this.IdVideo.FieldName = "IdVideo";
            this.IdVideo.Name = "IdVideo";
            // 
            // IdProcesador
            // 
            this.IdProcesador.Caption = "IdProcesador";
            this.IdProcesador.FieldName = "IdProcesador";
            this.IdProcesador.Name = "IdProcesador";
            // 
            // IdSalidaDetalle
            // 
            this.IdSalidaDetalle.Caption = "IdSalidaDetalle";
            this.IdSalidaDetalle.FieldName = "IdSalidaDetalle";
            this.IdSalidaDetalle.Name = "IdSalidaDetalle";
            // 
            // IdSucursal
            // 
            this.IdSucursal.Caption = "IdSucursal";
            this.IdSucursal.FieldName = "IdSucursal";
            this.IdSucursal.Name = "IdSucursal";
            // 
            // IdSalida
            // 
            this.IdSalida.Caption = "IdSalida";
            this.IdSalida.FieldName = "IdSalida";
            this.IdSalida.Name = "IdSalida";
            this.IdSalida.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            // 
            // GuiaSalida
            // 
            this.GuiaSalida.Caption = "GuiaSalida";
            this.GuiaSalida.FieldName = "GuiaSalida";
            this.GuiaSalida.Name = "GuiaSalida";
            this.GuiaSalida.UnboundType = DevExpress.Data.UnboundColumnType.String;
            // 
            // FechaIniContratoAntiguo
            // 
            this.FechaIniContratoAntiguo.Caption = "FechaIniContratoAntiguo";
            this.FechaIniContratoAntiguo.FieldName = "FechaIniContratoAntiguo";
            this.FechaIniContratoAntiguo.Name = "FechaIniContratoAntiguo";
            this.FechaIniContratoAntiguo.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            // 
            // FechaFinContratoAntiguo
            // 
            this.FechaFinContratoAntiguo.Caption = "FechaFinContratoAntiguo";
            this.FechaFinContratoAntiguo.FieldName = "FechaFinContratoAntiguo";
            this.FechaFinContratoAntiguo.Name = "FechaFinContratoAntiguo";
            this.FechaFinContratoAntiguo.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(669, 416);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 65);
            this.btnCancelar.TabIndex = 138;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmProcesoCorteAlquilerAgregarProducto
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(916, 493);
            this.Controls.Add(this.btnDeseleccionarFilas);
            this.Controls.Add(this.btnSeleccionarFilas);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.dgvRenovacionProductos);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcesoCorteAlquilerAgregarProducto";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Producto";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRenovacionProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeseleccionarFilas;
        private System.Windows.Forms.Button btnSeleccionarFilas;
        private System.Windows.Forms.Button btnSeleccionar;
        private DevExpress.XtraGrid.GridControl dgvRenovacionProductos;
        private DevExpress.XtraGrid.Views.Grid.GridView vista;
        private DevExpress.XtraGrid.Columns.GridColumn Seleccionar;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoAntiguo;
        private DevExpress.XtraGrid.Columns.GridColumn Marca;
        private DevExpress.XtraGrid.Columns.GridColumn Modelo;
        private DevExpress.XtraGrid.Columns.GridColumn Pantalla;
        private DevExpress.XtraGrid.Columns.GridColumn Procesador;
        private DevExpress.XtraGrid.Columns.GridColumn Generacion;
        private DevExpress.XtraGrid.Columns.GridColumn Video;
        private DevExpress.XtraGrid.Columns.GridColumn Capacidad;
        private DevExpress.XtraGrid.Columns.GridColumn fecIniContrato;
        private DevExpress.XtraGrid.Columns.GridColumn fecFinContrato;
        private DevExpress.XtraGrid.Columns.GridColumn IdLC;
        private DevExpress.XtraGrid.Columns.GridColumn IdVideo;
        private DevExpress.XtraGrid.Columns.GridColumn IdProcesador;
        private DevExpress.XtraGrid.Columns.GridColumn IdSalidaDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn IdSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn IdSalida;
        private DevExpress.XtraGrid.Columns.GridColumn GuiaSalida;
        private DevExpress.XtraGrid.Columns.GridColumn FechaIniContratoAntiguo;
        private DevExpress.XtraGrid.Columns.GridColumn FechaFinContratoAntiguo;
        private System.Windows.Forms.Button btnCancelar;
    }
}