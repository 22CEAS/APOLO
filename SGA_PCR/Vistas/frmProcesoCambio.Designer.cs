namespace Apolo
{
    partial class frmProcesoCambio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesoCambio));
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaCambio = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtGuiaRemision = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodigoLaptop = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNroTicket = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNroCambio = new System.Windows.Forms.TextBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtRucDni = new System.Windows.Forms.TextBox();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.dgvLaptopsSeleccionados = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.chbEquipoDanado = new System.Windows.Forms.CheckBox();
            this.chbEquipoDevuelto = new System.Windows.Forms.CheckBox();
            this.chbPagaraCliente = new System.Windows.Forms.CheckBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaCambio)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(219, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 48;
            this.label4.Text = "Fecha Cambio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 47;
            this.label3.Text = "Guía de Remisión";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 46;
            this.label1.Text = "Cliente";
            // 
            // dtpFechaCambio
            // 
            // 
            // 
            // 
            this.dtpFechaCambio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpFechaCambio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpFechaCambio.ButtonDropDown.Visible = true;
            this.dtpFechaCambio.IsPopupCalendarOpen = false;
            this.dtpFechaCambio.Location = new System.Drawing.Point(222, 152);
            // 
            // 
            // 
            this.dtpFechaCambio.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpFechaCambio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.dtpFechaCambio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpFechaCambio.MonthCalendar.DisplayMonth = new System.DateTime(2020, 5, 1, 0, 0, 0, 0);
            this.dtpFechaCambio.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpFechaCambio.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpFechaCambio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpFechaCambio.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpFechaCambio.Name = "dtpFechaCambio";
            this.dtpFechaCambio.Size = new System.Drawing.Size(141, 20);
            this.dtpFechaCambio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpFechaCambio.TabIndex = 5;
            // 
            // txtGuiaRemision
            // 
            this.txtGuiaRemision.Location = new System.Drawing.Point(25, 152);
            this.txtGuiaRemision.Name = "txtGuiaRemision";
            this.txtGuiaRemision.Size = new System.Drawing.Size(148, 20);
            this.txtGuiaRemision.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 16);
            this.label8.TabIndex = 79;
            this.label8.Text = "Código Laptop a Buscar";
            // 
            // txtCodigoLaptop
            // 
            this.txtCodigoLaptop.Location = new System.Drawing.Point(25, 94);
            this.txtCodigoLaptop.Name = "txtCodigoLaptop";
            this.txtCodigoLaptop.Size = new System.Drawing.Size(148, 20);
            this.txtCodigoLaptop.TabIndex = 1;
            this.txtCodigoLaptop.TextChanged += new System.EventHandler(this.txtCodigoLaptop_TextChanged);
            this.txtCodigoLaptop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoLaptop_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(379, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 16);
            this.label9.TabIndex = 81;
            this.label9.Text = "N° Ticket Técnico";
            // 
            // txtNroTicket
            // 
            this.txtNroTicket.Location = new System.Drawing.Point(381, 152);
            this.txtNroTicket.Name = "txtNroTicket";
            this.txtNroTicket.Size = new System.Drawing.Size(110, 20);
            this.txtNroTicket.TabIndex = 6;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.Location = new System.Drawing.Point(233, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(59, 56);
            this.btnBuscar.TabIndex = 153;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 152;
            this.label2.Text = "Cambio N°:";
            // 
            // txtNroCambio
            // 
            this.txtNroCambio.Location = new System.Drawing.Point(104, 26);
            this.txtNroCambio.Name = "txtNroCambio";
            this.txtNroCambio.ReadOnly = true;
            this.txtNroCambio.Size = new System.Drawing.Size(123, 20);
            this.txtNroCambio.TabIndex = 151;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(543, 73);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(64, 16);
            this.labelX1.TabIndex = 155;
            this.labelX1.Text = "RUC / DNI:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(222, 94);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(269, 20);
            this.txtCliente.TabIndex = 2;
            // 
            // txtRucDni
            // 
            this.txtRucDni.Location = new System.Drawing.Point(543, 94);
            this.txtRucDni.Name = "txtRucDni";
            this.txtRucDni.ReadOnly = true;
            this.txtRucDni.Size = new System.Drawing.Size(124, 20);
            this.txtRucDni.TabIndex = 3;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarProducto.Location = new System.Drawing.Point(543, 147);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(124, 29);
            this.btnAgregarProducto.TabIndex = 7;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnular.AutoSize = true;
            this.btnAnular.BackColor = System.Drawing.Color.Transparent;
            this.btnAnular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnular.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.Image = ((System.Drawing.Image)(resources.GetObject("btnAnular.Image")));
            this.btnAnular.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAnular.Location = new System.Drawing.Point(288, 506);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(60, 66);
            this.btnAnular.TabIndex = 174;
            this.btnAnular.Text = "Anular";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnular.UseVisualStyleBackColor = false;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.AutoSize = true;
            this.btnImprimir.BackColor = System.Drawing.Color.Transparent;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.Location = new System.Drawing.Point(440, 506);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 66);
            this.btnImprimir.TabIndex = 173;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(354, 507);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 65);
            this.btnCancelar.TabIndex = 172;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.AutoSize = true;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditar.Location = new System.Drawing.Point(129, 506);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(80, 65);
            this.btnEditar.TabIndex = 171;
            this.btnEditar.Text = "Modificar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.AutoSize = true;
            this.btnNuevo.BackColor = System.Drawing.Color.Transparent;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevo.Location = new System.Drawing.Point(61, 508);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 63);
            this.btnNuevo.TabIndex = 170;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar.AutoSize = true;
            this.btnGrabar.BackColor = System.Drawing.Color.Transparent;
            this.btnGrabar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrabar.FlatAppearance.BorderSize = 0;
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGrabar.Location = new System.Drawing.Point(202, 508);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(94, 64);
            this.btnGrabar.TabIndex = 169;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // dgvLaptopsSeleccionados
            // 
            this.dgvLaptopsSeleccionados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLaptopsSeleccionados.BackColor = System.Drawing.Color.White;
            this.dgvLaptopsSeleccionados.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvLaptopsSeleccionados.ForeColor = System.Drawing.Color.Black;
            this.dgvLaptopsSeleccionados.Location = new System.Drawing.Point(25, 200);
            this.dgvLaptopsSeleccionados.Name = "dgvLaptopsSeleccionados";
            this.dgvLaptopsSeleccionados.PrimaryGrid.AllowRowHeaderResize = true;
            this.dgvLaptopsSeleccionados.PrimaryGrid.AllowRowResize = true;
            this.dgvLaptopsSeleccionados.PrimaryGrid.ColumnHeader.RowHeight = 30;
            gridColumn1.AllowEdit = false;
            gridColumn1.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn1.DataPropertyName = "Codigo";
            gridColumn1.MinimumWidth = 100;
            gridColumn1.Name = "Código";
            gridColumn1.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn1.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn2.AllowEdit = false;
            gridColumn2.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn2.DataPropertyName = "MarcaLC";
            gridColumn2.MinimumWidth = 100;
            gridColumn2.Name = "Marca";
            gridColumn2.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn2.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn3.AllowEdit = false;
            gridColumn3.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn3.DataPropertyName = "NombreModeloLC";
            gridColumn3.MinimumWidth = 100;
            gridColumn3.Name = "Modelo";
            gridColumn3.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn4.AllowEdit = false;
            gridColumn4.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn4.DataPropertyName = "TamanoPantalla";
            gridColumn4.MinimumWidth = 60;
            gridColumn4.Name = "Pantalla";
            gridColumn4.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn4.Width = 60;
            gridColumn5.AllowEdit = false;
            gridColumn5.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn5.DataPropertyName = "TipoProcesador";
            gridColumn5.MinimumWidth = 70;
            gridColumn5.Name = "Procesador";
            gridColumn5.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn5.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn5.Width = 70;
            gridColumn6.AllowEdit = false;
            gridColumn6.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn6.DataPropertyName = "GeneracionProcesador";
            gridColumn6.MinimumWidth = 70;
            gridColumn6.Name = "Generacion";
            gridColumn6.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn6.Width = 70;
            gridColumn7.AllowEdit = false;
            gridColumn7.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn7.DataPropertyName = "NombreModeloVideo";
            gridColumn7.Name = "Video";
            gridColumn7.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn8.AllowEdit = false;
            gridColumn8.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn8.DataPropertyName = "CapacidadVideo";
            gridColumn8.MinimumWidth = 70;
            gridColumn8.Name = "Capacidad";
            gridColumn8.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn8.Width = 70;
            gridColumn9.DataPropertyName = "IdLC";
            gridColumn9.Name = "Id LC";
            gridColumn9.Visible = false;
            this.dgvLaptopsSeleccionados.PrimaryGrid.Columns.Add(gridColumn1);
            this.dgvLaptopsSeleccionados.PrimaryGrid.Columns.Add(gridColumn2);
            this.dgvLaptopsSeleccionados.PrimaryGrid.Columns.Add(gridColumn3);
            this.dgvLaptopsSeleccionados.PrimaryGrid.Columns.Add(gridColumn4);
            this.dgvLaptopsSeleccionados.PrimaryGrid.Columns.Add(gridColumn5);
            this.dgvLaptopsSeleccionados.PrimaryGrid.Columns.Add(gridColumn6);
            this.dgvLaptopsSeleccionados.PrimaryGrid.Columns.Add(gridColumn7);
            this.dgvLaptopsSeleccionados.PrimaryGrid.Columns.Add(gridColumn8);
            this.dgvLaptopsSeleccionados.PrimaryGrid.Columns.Add(gridColumn9);
            this.dgvLaptopsSeleccionados.PrimaryGrid.DefaultRowHeight = 24;
            this.dgvLaptopsSeleccionados.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvLaptopsSeleccionados.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvLaptopsSeleccionados.PrimaryGrid.MultiSelect = false;
            this.dgvLaptopsSeleccionados.PrimaryGrid.NoRowsText = "No hay ninguna laptop seleccionada";
            this.dgvLaptopsSeleccionados.PrimaryGrid.NullString = "<<null>>";
            this.dgvLaptopsSeleccionados.PrimaryGrid.RowHeaderWidth = 45;
            this.dgvLaptopsSeleccionados.PrimaryGrid.ShowRowHeaders = false;
            this.dgvLaptopsSeleccionados.PrimaryGrid.UseAlternateColumnStyle = true;
            this.dgvLaptopsSeleccionados.Size = new System.Drawing.Size(670, 79);
            this.dgvLaptopsSeleccionados.TabIndex = 168;
            this.dgvLaptopsSeleccionados.Text = "Tabla Laptops";
            this.dgvLaptopsSeleccionados.DoubleClick += new System.EventHandler(this.dgvLaptopsSeleccionados_DoubleClick);
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(23, 84);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(648, 87);
            this.txtObservacion.TabIndex = 175;
            // 
            // chbEquipoDanado
            // 
            this.chbEquipoDanado.AutoSize = true;
            this.chbEquipoDanado.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbEquipoDanado.Location = new System.Drawing.Point(177, 31);
            this.chbEquipoDanado.Name = "chbEquipoDanado";
            this.chbEquipoDanado.Size = new System.Drawing.Size(130, 21);
            this.chbEquipoDanado.TabIndex = 176;
            this.chbEquipoDanado.Text = "Equipo Dañado";
            this.chbEquipoDanado.UseVisualStyleBackColor = true;
            // 
            // chbEquipoDevuelto
            // 
            this.chbEquipoDevuelto.AutoSize = true;
            this.chbEquipoDevuelto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbEquipoDevuelto.Location = new System.Drawing.Point(36, 31);
            this.chbEquipoDevuelto.Name = "chbEquipoDevuelto";
            this.chbEquipoDevuelto.Size = new System.Drawing.Size(135, 21);
            this.chbEquipoDevuelto.TabIndex = 177;
            this.chbEquipoDevuelto.Text = "Equipo Devuelto";
            this.chbEquipoDevuelto.UseVisualStyleBackColor = true;
            // 
            // chbPagaraCliente
            // 
            this.chbPagaraCliente.AutoSize = true;
            this.chbPagaraCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPagaraCliente.Location = new System.Drawing.Point(314, 31);
            this.chbPagaraCliente.Name = "chbPagaraCliente";
            this.chbPagaraCliente.Size = new System.Drawing.Size(125, 21);
            this.chbPagaraCliente.TabIndex = 178;
            this.chbPagaraCliente.Text = "Pagará Cliente";
            this.chbPagaraCliente.UseVisualStyleBackColor = true;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(36, 58);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(96, 20);
            this.labelX2.TabIndex = 179;
            this.labelX2.Text = "Observación";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtObservacion);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.chbEquipoDanado);
            this.groupBox1.Controls.Add(this.chbPagaraCliente);
            this.groupBox1.Controls.Add(this.chbEquipoDevuelto);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(693, 190);
            this.groupBox1.TabIndex = 180;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Observaciones del Cambio";
            // 
            // frmProcesoCambio
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(749, 583);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dgvLaptopsSeleccionados);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.txtRucDni);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNroCambio);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNroTicket);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCodigoLaptop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechaCambio);
            this.Controls.Add(this.txtGuiaRemision);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcesoCambio";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio";
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaCambio)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpFechaCambio;
        private System.Windows.Forms.TextBox txtGuiaRemision;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodigoLaptop;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNroTicket;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNroCambio;
        internal DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtRucDni;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvLaptopsSeleccionados;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.CheckBox chbEquipoDanado;
        private System.Windows.Forms.CheckBox chbEquipoDevuelto;
        private System.Windows.Forms.CheckBox chbPagaraCliente;
        internal DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}