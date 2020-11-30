namespace Apolo
{
    partial class frmReportePendienteRecoger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportePendienteRecoger));
            this.dgvLaptops = new DevExpress.XtraGrid.GridControl();
            this.vista = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ruc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Contacto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DireccionCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TelefonoContacto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CódigoLC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Guía = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MarcaLC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NombreModeloLC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoAntiguo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaInicioContrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaFinContrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoProcesador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NombreModeloVideo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiasAtrasoRecojo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MotivoNoRecojo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.factura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fecInicioFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fecFinFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MontoSoles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MontoDolares = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TotalDolares = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CostoSoles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CostoDolares = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VersionOffice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KAM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.verResumen = new System.Windows.Forms.Button();
            this.giftCarga = new System.Windows.Forms.PictureBox();
            this.cargarData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaptops)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giftCarga)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLaptops
            // 
            this.dgvLaptops.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLaptops.Location = new System.Drawing.Point(29, 126);
            this.dgvLaptops.MainView = this.vista;
            this.dgvLaptops.Name = "dgvLaptops";
            this.dgvLaptops.Size = new System.Drawing.Size(1249, 494);
            this.dgvLaptops.TabIndex = 133;
            this.dgvLaptops.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.vista});
            this.dgvLaptops.MouseLeave += new System.EventHandler(this.dgvLaptops_MouseLeave);
            this.dgvLaptops.MouseHover += new System.EventHandler(this.dgvLaptops_MouseHover);
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
            this.Ruc,
            this.Contacto,
            this.DireccionCliente,
            this.TelefonoContacto,
            this.CódigoLC,
            this.Guía,
            this.MarcaLC,
            this.NombreModeloLC,
            this.CodigoAntiguo,
            this.FechaInicioContrato,
            this.FechaFinContrato,
            this.TipoProcesador,
            this.NombreModeloVideo,
            this.DiasAtrasoRecojo,
            this.MotivoNoRecojo,
            this.factura,
            this.fecInicioFactura,
            this.fecFinFactura,
            this.MontoSoles,
            this.MontoDolares,
            this.TotalDolares,
            this.CostoSoles,
            this.CostoDolares,
            this.VersionOffice,
            this.KAM});
            this.vista.GridControl = this.dgvLaptops;
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
            this.Cliente.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.Cliente.MinWidth = 40;
            this.Cliente.Name = "Cliente";
            this.Cliente.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Cliente.Visible = true;
            this.Cliente.VisibleIndex = 0;
            this.Cliente.Width = 200;
            // 
            // Ruc
            // 
            this.Ruc.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Ruc.AppearanceHeader.Options.UseBackColor = true;
            this.Ruc.Caption = "Ruc";
            this.Ruc.FieldName = "Ruc";
            this.Ruc.Name = "Ruc";
            this.Ruc.Visible = true;
            this.Ruc.VisibleIndex = 1;
            // 
            // Contacto
            // 
            this.Contacto.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Contacto.AppearanceHeader.Options.UseBackColor = true;
            this.Contacto.Caption = "Contacto";
            this.Contacto.FieldName = "Contacto";
            this.Contacto.MinWidth = 40;
            this.Contacto.Name = "Contacto";
            this.Contacto.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Contacto.Visible = true;
            this.Contacto.VisibleIndex = 2;
            this.Contacto.Width = 200;
            // 
            // DireccionCliente
            // 
            this.DireccionCliente.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DireccionCliente.AppearanceHeader.Options.UseBackColor = true;
            this.DireccionCliente.Caption = "Dirección Cliente";
            this.DireccionCliente.FieldName = "DireccionCliente";
            this.DireccionCliente.MinWidth = 40;
            this.DireccionCliente.Name = "DireccionCliente";
            this.DireccionCliente.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.DireccionCliente.Visible = true;
            this.DireccionCliente.VisibleIndex = 3;
            this.DireccionCliente.Width = 300;
            // 
            // TelefonoContacto
            // 
            this.TelefonoContacto.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.TelefonoContacto.AppearanceHeader.Options.UseBackColor = true;
            this.TelefonoContacto.Caption = "Telefono Contacto";
            this.TelefonoContacto.FieldName = "TelefonoContacto";
            this.TelefonoContacto.MinWidth = 40;
            this.TelefonoContacto.Name = "TelefonoContacto";
            this.TelefonoContacto.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.TelefonoContacto.Visible = true;
            this.TelefonoContacto.VisibleIndex = 4;
            this.TelefonoContacto.Width = 100;
            // 
            // CódigoLC
            // 
            this.CódigoLC.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CódigoLC.AppearanceHeader.Options.UseBackColor = true;
            this.CódigoLC.Caption = "Código";
            this.CódigoLC.FieldName = "Codigo";
            this.CódigoLC.MinWidth = 40;
            this.CódigoLC.Name = "CódigoLC";
            this.CódigoLC.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.CódigoLC.Visible = true;
            this.CódigoLC.VisibleIndex = 5;
            this.CódigoLC.Width = 150;
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
            this.Guía.VisibleIndex = 6;
            this.Guía.Width = 200;
            // 
            // MarcaLC
            // 
            this.MarcaLC.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.MarcaLC.AppearanceHeader.Options.UseBackColor = true;
            this.MarcaLC.Caption = "Marca LC";
            this.MarcaLC.FieldName = "MarcaLC";
            this.MarcaLC.MinWidth = 40;
            this.MarcaLC.Name = "MarcaLC";
            this.MarcaLC.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.MarcaLC.Visible = true;
            this.MarcaLC.VisibleIndex = 7;
            this.MarcaLC.Width = 150;
            // 
            // NombreModeloLC
            // 
            this.NombreModeloLC.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.NombreModeloLC.AppearanceHeader.Options.UseBackColor = true;
            this.NombreModeloLC.Caption = "Nombre Modelo LC";
            this.NombreModeloLC.FieldName = "NombreModeloLC";
            this.NombreModeloLC.MinWidth = 40;
            this.NombreModeloLC.Name = "NombreModeloLC";
            this.NombreModeloLC.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.NombreModeloLC.Visible = true;
            this.NombreModeloLC.VisibleIndex = 8;
            this.NombreModeloLC.Width = 200;
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
            // FechaInicioContrato
            // 
            this.FechaInicioContrato.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FechaInicioContrato.AppearanceHeader.Options.UseBackColor = true;
            this.FechaInicioContrato.Caption = "Fecha Inicio Contrato";
            this.FechaInicioContrato.FieldName = "fecIniContrato";
            this.FechaInicioContrato.MinWidth = 40;
            this.FechaInicioContrato.Name = "FechaInicioContrato";
            this.FechaInicioContrato.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.FechaInicioContrato.Visible = true;
            this.FechaInicioContrato.VisibleIndex = 10;
            this.FechaInicioContrato.Width = 150;
            // 
            // FechaFinContrato
            // 
            this.FechaFinContrato.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FechaFinContrato.AppearanceHeader.Options.UseBackColor = true;
            this.FechaFinContrato.Caption = "Fecha Fin Contrato";
            this.FechaFinContrato.FieldName = "fecFinContrato";
            this.FechaFinContrato.MinWidth = 40;
            this.FechaFinContrato.Name = "FechaFinContrato";
            this.FechaFinContrato.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.FechaFinContrato.Visible = true;
            this.FechaFinContrato.VisibleIndex = 11;
            this.FechaFinContrato.Width = 150;
            // 
            // TipoProcesador
            // 
            this.TipoProcesador.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.TipoProcesador.AppearanceHeader.Options.UseBackColor = true;
            this.TipoProcesador.Caption = "Tipo Procesador";
            this.TipoProcesador.FieldName = "TipoProcesador";
            this.TipoProcesador.MinWidth = 40;
            this.TipoProcesador.Name = "TipoProcesador";
            this.TipoProcesador.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.TipoProcesador.Visible = true;
            this.TipoProcesador.VisibleIndex = 12;
            this.TipoProcesador.Width = 150;
            // 
            // NombreModeloVideo
            // 
            this.NombreModeloVideo.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.NombreModeloVideo.AppearanceHeader.Options.UseBackColor = true;
            this.NombreModeloVideo.Caption = "Nombre Modelo Video";
            this.NombreModeloVideo.FieldName = "NombreModeloVideo";
            this.NombreModeloVideo.MinWidth = 40;
            this.NombreModeloVideo.Name = "NombreModeloVideo";
            this.NombreModeloVideo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.NombreModeloVideo.Width = 200;
            // 
            // DiasAtrasoRecojo
            // 
            this.DiasAtrasoRecojo.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DiasAtrasoRecojo.AppearanceHeader.Options.UseBackColor = true;
            this.DiasAtrasoRecojo.Caption = "Dias Atraso Recojo";
            this.DiasAtrasoRecojo.FieldName = "diasAtrasoRecojo";
            this.DiasAtrasoRecojo.MinWidth = 40;
            this.DiasAtrasoRecojo.Name = "DiasAtrasoRecojo";
            this.DiasAtrasoRecojo.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.DiasAtrasoRecojo.Visible = true;
            this.DiasAtrasoRecojo.VisibleIndex = 13;
            this.DiasAtrasoRecojo.Width = 150;
            // 
            // MotivoNoRecojo
            // 
            this.MotivoNoRecojo.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.MotivoNoRecojo.AppearanceHeader.Options.UseBackColor = true;
            this.MotivoNoRecojo.Caption = "Motivo No Recojo";
            this.MotivoNoRecojo.FieldName = "motivoNoRecojo";
            this.MotivoNoRecojo.MinWidth = 40;
            this.MotivoNoRecojo.Name = "MotivoNoRecojo";
            this.MotivoNoRecojo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.MotivoNoRecojo.Width = 200;
            // 
            // factura
            // 
            this.factura.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.factura.AppearanceHeader.Options.UseBackColor = true;
            this.factura.Caption = "Factura";
            this.factura.FieldName = "factura";
            this.factura.MinWidth = 40;
            this.factura.Name = "factura";
            this.factura.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.factura.Visible = true;
            this.factura.VisibleIndex = 14;
            this.factura.Width = 150;
            // 
            // fecInicioFactura
            // 
            this.fecInicioFactura.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.fecInicioFactura.AppearanceHeader.Options.UseBackColor = true;
            this.fecInicioFactura.Caption = "Fecha Inicio Factura";
            this.fecInicioFactura.FieldName = "fecInicioFactura";
            this.fecInicioFactura.MinWidth = 40;
            this.fecInicioFactura.Name = "fecInicioFactura";
            this.fecInicioFactura.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.fecInicioFactura.Visible = true;
            this.fecInicioFactura.VisibleIndex = 15;
            this.fecInicioFactura.Width = 150;
            // 
            // fecFinFactura
            // 
            this.fecFinFactura.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.fecFinFactura.AppearanceHeader.Options.UseBackColor = true;
            this.fecFinFactura.Caption = "Fecha Fin Factura";
            this.fecFinFactura.FieldName = "fecFinFactura";
            this.fecFinFactura.MinWidth = 40;
            this.fecFinFactura.Name = "fecFinFactura";
            this.fecFinFactura.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.fecFinFactura.Visible = true;
            this.fecFinFactura.VisibleIndex = 16;
            this.fecFinFactura.Width = 150;
            // 
            // MontoSoles
            // 
            this.MontoSoles.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.MontoSoles.AppearanceHeader.Options.UseBackColor = true;
            this.MontoSoles.Caption = "Monto Soles";
            this.MontoSoles.FieldName = "MontoSoles";
            this.MontoSoles.MinWidth = 40;
            this.MontoSoles.Name = "MontoSoles";
            this.MontoSoles.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.MontoSoles.Visible = true;
            this.MontoSoles.VisibleIndex = 17;
            this.MontoSoles.Width = 150;
            // 
            // MontoDolares
            // 
            this.MontoDolares.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.MontoDolares.AppearanceHeader.Options.UseBackColor = true;
            this.MontoDolares.Caption = "Monto Dolares";
            this.MontoDolares.FieldName = "MontoDolares";
            this.MontoDolares.MinWidth = 40;
            this.MontoDolares.Name = "MontoDolares";
            this.MontoDolares.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.MontoDolares.Visible = true;
            this.MontoDolares.VisibleIndex = 18;
            this.MontoDolares.Width = 150;
            // 
            // TotalDolares
            // 
            this.TotalDolares.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.TotalDolares.AppearanceHeader.Options.UseBackColor = true;
            this.TotalDolares.Caption = "Total Dolares";
            this.TotalDolares.FieldName = "TotalDolares";
            this.TotalDolares.MinWidth = 40;
            this.TotalDolares.Name = "TotalDolares";
            this.TotalDolares.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.TotalDolares.Visible = true;
            this.TotalDolares.VisibleIndex = 19;
            this.TotalDolares.Width = 150;
            // 
            // CostoSoles
            // 
            this.CostoSoles.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CostoSoles.AppearanceHeader.Options.UseBackColor = true;
            this.CostoSoles.Caption = "Costo Soles";
            this.CostoSoles.FieldName = "CostoSoles";
            this.CostoSoles.MinWidth = 40;
            this.CostoSoles.Name = "CostoSoles";
            this.CostoSoles.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.CostoSoles.Visible = true;
            this.CostoSoles.VisibleIndex = 20;
            this.CostoSoles.Width = 100;
            // 
            // CostoDolares
            // 
            this.CostoDolares.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CostoDolares.AppearanceHeader.Options.UseBackColor = true;
            this.CostoDolares.Caption = "Costo Dolares";
            this.CostoDolares.FieldName = "CostoDolares";
            this.CostoDolares.MinWidth = 40;
            this.CostoDolares.Name = "CostoDolares";
            this.CostoDolares.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.CostoDolares.Visible = true;
            this.CostoDolares.VisibleIndex = 21;
            this.CostoDolares.Width = 100;
            // 
            // VersionOffice
            // 
            this.VersionOffice.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.VersionOffice.AppearanceHeader.Options.UseBackColor = true;
            this.VersionOffice.Caption = "Versión Office";
            this.VersionOffice.FieldName = "VersionOffice";
            this.VersionOffice.MinWidth = 40;
            this.VersionOffice.Name = "VersionOffice";
            this.VersionOffice.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.VersionOffice.Visible = true;
            this.VersionOffice.VisibleIndex = 22;
            this.VersionOffice.Width = 100;
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
            this.KAM.VisibleIndex = 23;
            this.KAM.Width = 200;
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
            this.btnExportar.Location = new System.Drawing.Point(1196, 9);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 63);
            this.btnExportar.TabIndex = 135;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 16);
            this.label1.TabIndex = 152;
            this.label1.Text = "CANTIDAD REGISTROS:";
            // 
            // verResumen
            // 
            this.verResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.verResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.verResumen.Location = new System.Drawing.Point(29, 12);
            this.verResumen.Name = "verResumen";
            this.verResumen.Size = new System.Drawing.Size(115, 19);
            this.verResumen.TabIndex = 151;
            this.verResumen.Text = "VER RESUMEN";
            this.verResumen.UseVisualStyleBackColor = false;
            this.verResumen.Click += new System.EventHandler(this.verResumen_Click);
            // 
            // giftCarga
            // 
            this.giftCarga.Location = new System.Drawing.Point(553, 5);
            this.giftCarga.Name = "giftCarga";
            this.giftCarga.Size = new System.Drawing.Size(123, 82);
            this.giftCarga.TabIndex = 150;
            this.giftCarga.TabStop = false;
            // 
            // cargarData
            // 
            this.cargarData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cargarData.Location = new System.Drawing.Point(563, 93);
            this.cargarData.Name = "cargarData";
            this.cargarData.Size = new System.Drawing.Size(113, 19);
            this.cargarData.TabIndex = 149;
            this.cargarData.Text = "CARGANDO DATA";
            this.cargarData.UseVisualStyleBackColor = true;
            this.cargarData.Click += new System.EventHandler(this.cargarData_Click);
            // 
            // frmReportePendienteRecoger
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1296, 656);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.verResumen);
            this.Controls.Add(this.giftCarga);
            this.Controls.Add(this.cargarData);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvLaptops);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "frmReportePendienteRecoger";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pendiente Recoger";
            this.Load += new System.EventHandler(this.frmReportePendienteRecoger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaptops)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giftCarga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl dgvLaptops;
        private DevExpress.XtraGrid.Views.Grid.GridView vista;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn Contacto;
        private DevExpress.XtraGrid.Columns.GridColumn DireccionCliente;
        private DevExpress.XtraGrid.Columns.GridColumn TelefonoContacto;
        private DevExpress.XtraGrid.Columns.GridColumn CódigoLC;
        private DevExpress.XtraGrid.Columns.GridColumn MarcaLC;
        private DevExpress.XtraGrid.Columns.GridColumn NombreModeloLC;
        private DevExpress.XtraGrid.Columns.GridColumn FechaInicioContrato;
        private DevExpress.XtraGrid.Columns.GridColumn FechaFinContrato;
        private DevExpress.XtraGrid.Columns.GridColumn TipoProcesador;
        private DevExpress.XtraGrid.Columns.GridColumn NombreModeloVideo;
        private DevExpress.XtraGrid.Columns.GridColumn DiasAtrasoRecojo;
        private DevExpress.XtraGrid.Columns.GridColumn Guía;
        private DevExpress.XtraGrid.Columns.GridColumn MotivoNoRecojo;
        private DevExpress.XtraGrid.Columns.GridColumn KAM;
        private System.Windows.Forms.Button btnExportar;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoAntiguo;
        private DevExpress.XtraGrid.Columns.GridColumn factura;
        private DevExpress.XtraGrid.Columns.GridColumn fecInicioFactura;
        private DevExpress.XtraGrid.Columns.GridColumn fecFinFactura;
        private DevExpress.XtraGrid.Columns.GridColumn MontoSoles;
        private DevExpress.XtraGrid.Columns.GridColumn MontoDolares;
        private DevExpress.XtraGrid.Columns.GridColumn TotalDolares;
        private DevExpress.XtraGrid.Columns.GridColumn VersionOffice;
        private DevExpress.XtraGrid.Columns.GridColumn CostoSoles;
        private DevExpress.XtraGrid.Columns.GridColumn CostoDolares;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button verResumen;
        public System.Windows.Forms.PictureBox giftCarga;
        public System.Windows.Forms.Button cargarData;
        private DevExpress.XtraGrid.Columns.GridColumn Ruc;
    }
}