namespace Apolo
{
    partial class frmReportePendienteFacturar
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportePendienteFacturar));
            this.DíasVencidos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CódigoLC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvFacturas = new DevExpress.XtraGrid.GridControl();
            this.vista = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ruc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaInicioContrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaFinContrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Factura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaInicioFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaFinFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Guía = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoAntiguo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TotalSoles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TotalDolares = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CostoSoles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CostoDolares = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PendienteFacturarSoles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PendienteFacturarDolares = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KAM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PendienteFacturarUtilidadSoles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.verResumen = new System.Windows.Forms.Button();
            this.giftCarga = new System.Windows.Forms.PictureBox();
            this.cargarData = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button38 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giftCarga)).BeginInit();
            this.SuspendLayout();
            // 
            // DíasVencidos
            // 
            this.DíasVencidos.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DíasVencidos.AppearanceHeader.Options.UseBackColor = true;
            this.DíasVencidos.Caption = "Días Vencidos";
            this.DíasVencidos.FieldName = "diasVencidos";
            this.DíasVencidos.MinWidth = 40;
            this.DíasVencidos.Name = "DíasVencidos";
            this.DíasVencidos.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.DíasVencidos.Visible = true;
            this.DíasVencidos.VisibleIndex = 10;
            this.DíasVencidos.Width = 100;
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
            // dgvFacturas
            // 
            this.dgvFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFacturas.Location = new System.Drawing.Point(27, 125);
            this.dgvFacturas.MainView = this.vista;
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.Size = new System.Drawing.Size(1161, 458);
            this.dgvFacturas.TabIndex = 132;
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
            this.Cliente,
            this.ruc,
            this.FechaInicioContrato,
            this.FechaFinContrato,
            this.Factura,
            this.FechaInicioFactura,
            this.FechaFinFactura,
            this.CódigoLC,
            this.Guía,
            this.CodigoAntiguo,
            this.DíasVencidos,
            this.TotalSoles,
            this.TotalDolares,
            this.CostoSoles,
            this.CostoDolares,
            this.PendienteFacturarSoles,
            this.PendienteFacturarDolares,
            this.PendienteFacturarUtilidadSoles,
            this.KAM});
            gridFormatRule1.Column = this.DíasVencidos;
            gridFormatRule1.ColumnApplyTo = this.CódigoLC;
            gridFormatRule1.Name = "Mas de 7";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.Red;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue1.Expression = "[diasVencidos] > 45";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.Column = this.DíasVencidos;
            gridFormatRule2.ColumnApplyTo = this.CódigoLC;
            gridFormatRule2.Name = "2 a 7";
            formatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue2.Expression = "[diasVencidos] >= 15 And [diasVencidos] <=45";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridFormatRule3.Column = this.DíasVencidos;
            gridFormatRule3.ColumnApplyTo = this.CódigoLC;
            gridFormatRule3.Name = "Menos de 2 ";
            formatConditionRuleValue3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            formatConditionRuleValue3.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue3.Expression = "[diasVencidos] < 15";
            gridFormatRule3.Rule = formatConditionRuleValue3;
            this.vista.FormatRules.Add(gridFormatRule1);
            this.vista.FormatRules.Add(gridFormatRule2);
            this.vista.FormatRules.Add(gridFormatRule3);
            this.vista.GridControl = this.dgvFacturas;
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
            this.Cliente.FieldName = "cliente";
            this.Cliente.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.Cliente.MinWidth = 40;
            this.Cliente.Name = "Cliente";
            this.Cliente.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Cliente.Visible = true;
            this.Cliente.VisibleIndex = 0;
            this.Cliente.Width = 200;
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
            // TotalSoles
            // 
            this.TotalSoles.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.TotalSoles.AppearanceHeader.Options.UseBackColor = true;
            this.TotalSoles.Caption = "Total Soles";
            this.TotalSoles.FieldName = "TotalSoles";
            this.TotalSoles.MinWidth = 40;
            this.TotalSoles.Name = "TotalSoles";
            this.TotalSoles.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.TotalSoles.Visible = true;
            this.TotalSoles.VisibleIndex = 11;
            this.TotalSoles.Width = 100;
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
            this.TotalDolares.VisibleIndex = 12;
            this.TotalDolares.Width = 100;
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
            this.CostoSoles.VisibleIndex = 13;
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
            this.CostoDolares.VisibleIndex = 14;
            this.CostoDolares.Width = 100;
            // 
            // PendienteFacturarSoles
            // 
            this.PendienteFacturarSoles.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PendienteFacturarSoles.AppearanceHeader.Options.UseBackColor = true;
            this.PendienteFacturarSoles.Caption = "Pendiente Facturar Soles";
            this.PendienteFacturarSoles.FieldName = "PendienteFacturarSoles";
            this.PendienteFacturarSoles.MinWidth = 40;
            this.PendienteFacturarSoles.Name = "PendienteFacturarSoles";
            this.PendienteFacturarSoles.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.PendienteFacturarSoles.Width = 100;
            // 
            // PendienteFacturarDolares
            // 
            this.PendienteFacturarDolares.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PendienteFacturarDolares.AppearanceHeader.Options.UseBackColor = true;
            this.PendienteFacturarDolares.Caption = "Pendiente Facturar Dolares";
            this.PendienteFacturarDolares.FieldName = "PendienteFacturarDolares";
            this.PendienteFacturarDolares.MinWidth = 40;
            this.PendienteFacturarDolares.Name = "PendienteFacturarDolares";
            this.PendienteFacturarDolares.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.PendienteFacturarDolares.Width = 100;
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
            this.KAM.VisibleIndex = 16;
            this.KAM.Width = 200;
            // 
            // PendienteFacturarUtilidadSoles
            // 
            this.PendienteFacturarUtilidadSoles.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PendienteFacturarUtilidadSoles.AppearanceHeader.Options.UseBackColor = true;
            this.PendienteFacturarUtilidadSoles.Caption = "Pendiente Facturar Utilidad Soles";
            this.PendienteFacturarUtilidadSoles.FieldName = "PendienteFacturarUtilidadSoles";
            this.PendienteFacturarUtilidadSoles.MinWidth = 40;
            this.PendienteFacturarUtilidadSoles.Name = "PendienteFacturarUtilidadSoles";
            this.PendienteFacturarUtilidadSoles.Visible = true;
            this.PendienteFacturarUtilidadSoles.VisibleIndex = 15;
            this.PendienteFacturarUtilidadSoles.Width = 140;
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
            this.btnExportar.Location = new System.Drawing.Point(1113, 12);
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
            this.label1.Location = new System.Drawing.Point(20, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 16);
            this.label1.TabIndex = 148;
            this.label1.Text = "CANTIDAD REGISTROS:";
            // 
            // verResumen
            // 
            this.verResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.verResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.verResumen.Location = new System.Drawing.Point(17, 11);
            this.verResumen.Name = "verResumen";
            this.verResumen.Size = new System.Drawing.Size(115, 19);
            this.verResumen.TabIndex = 147;
            this.verResumen.Text = "VER RESUMEN";
            this.verResumen.UseVisualStyleBackColor = false;
            this.verResumen.Click += new System.EventHandler(this.verResumen_Click_1);
            // 
            // giftCarga
            // 
            this.giftCarga.Location = new System.Drawing.Point(531, 11);
            this.giftCarga.Name = "giftCarga";
            this.giftCarga.Size = new System.Drawing.Size(123, 82);
            this.giftCarga.TabIndex = 146;
            this.giftCarga.TabStop = false;
            // 
            // cargarData
            // 
            this.cargarData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cargarData.Location = new System.Drawing.Point(541, 100);
            this.cargarData.Name = "cargarData";
            this.cargarData.Size = new System.Drawing.Size(113, 19);
            this.cargarData.TabIndex = 145;
            this.cargarData.Text = "CARGANDO DATA";
            this.cargarData.UseVisualStyleBackColor = true;
            this.cargarData.Click += new System.EventHandler(this.cargarData_Click_1);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(54, 661);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(393, 15);
            this.label14.TabIndex = 162;
            this.label14.Text = "EL CLIENTE TIENES MAS DE 45 DIAS SIN SER FACTURADO";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(54, 633);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(410, 15);
            this.label13.TabIndex = 161;
            this.label13.Text = "EL CLIENTE TIENE ENTRE 15 Y 45 DIAS SIN SER FACTURADO";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(54, 608);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(405, 15);
            this.label12.TabIndex = 160;
            this.label12.Text = "EL CLIENTE TIENE MENOS DE 15 DIAS SIN SER FACTURADO";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(24, 586);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 15);
            this.label11.TabIndex = 159;
            this.label11.Text = "LEYENDA";
            // 
            // button38
            // 
            this.button38.BackColor = System.Drawing.Color.Red;
            this.button38.Enabled = false;
            this.button38.Location = new System.Drawing.Point(27, 657);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(21, 19);
            this.button38.TabIndex = 158;
            this.button38.UseVisualStyleBackColor = false;
            // 
            // button37
            // 
            this.button37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button37.Enabled = false;
            this.button37.Location = new System.Drawing.Point(27, 632);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(21, 19);
            this.button37.TabIndex = 157;
            this.button37.UseVisualStyleBackColor = false;
            // 
            // button36
            // 
            this.button36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button36.Enabled = false;
            this.button36.Location = new System.Drawing.Point(27, 607);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(21, 19);
            this.button36.TabIndex = 156;
            this.button36.UseVisualStyleBackColor = false;
            // 
            // frmReportePendienteFacturar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1219, 700);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button38);
            this.Controls.Add(this.button37);
            this.Controls.Add(this.button36);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.verResumen);
            this.Controls.Add(this.giftCarga);
            this.Controls.Add(this.cargarData);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvFacturas);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "frmReportePendienteFacturar";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pendientes de Facturar";
            this.Load += new System.EventHandler(this.frmReportePendienteFacturar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giftCarga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl dgvFacturas;
        private DevExpress.XtraGrid.Views.Grid.GridView vista;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn Factura;
        private DevExpress.XtraGrid.Columns.GridColumn CódigoLC;
        private DevExpress.XtraGrid.Columns.GridColumn Guía;
        private DevExpress.XtraGrid.Columns.GridColumn DíasVencidos;
        private DevExpress.XtraGrid.Columns.GridColumn KAM;
        private DevExpress.XtraGrid.Columns.GridColumn FechaInicioContrato;
        private DevExpress.XtraGrid.Columns.GridColumn FechaFinContrato;
        private DevExpress.XtraGrid.Columns.GridColumn FechaInicioFactura;
        private DevExpress.XtraGrid.Columns.GridColumn FechaFinFactura;
        private System.Windows.Forms.Button btnExportar;
        private DevExpress.XtraGrid.Columns.GridColumn TotalSoles;
        private DevExpress.XtraGrid.Columns.GridColumn TotalDolares;
        private DevExpress.XtraGrid.Columns.GridColumn CostoSoles;
        private DevExpress.XtraGrid.Columns.GridColumn CostoDolares;
        private DevExpress.XtraGrid.Columns.GridColumn PendienteFacturarSoles;
        private DevExpress.XtraGrid.Columns.GridColumn PendienteFacturarDolares;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoAntiguo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button verResumen;
        public System.Windows.Forms.PictureBox giftCarga;
        public System.Windows.Forms.Button cargarData;
        private DevExpress.XtraGrid.Columns.GridColumn ruc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button38;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button button36;
        private DevExpress.XtraGrid.Columns.GridColumn PendienteFacturarUtilidadSoles;
    }
}