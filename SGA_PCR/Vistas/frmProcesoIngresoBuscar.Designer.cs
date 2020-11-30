namespace Apolo
{
    partial class frmProcesoIngresoBuscar
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesoIngresoBuscar));
            this.dgvIngreso = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.panelNumOP = new System.Windows.Forms.GroupBox();
            this.txtNumIngreso = new System.Windows.Forms.TextBox();
            this.rbtnFiltros = new System.Windows.Forms.RadioButton();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panelFiltros = new System.Windows.Forms.GroupBox();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.chbEstado = new System.Windows.Forms.CheckBox();
            this.chbProveedor = new System.Windows.Forms.CheckBox();
            this.chbUsuario = new System.Windows.Forms.CheckBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.chbFecProceso = new System.Windows.Forms.CheckBox();
            this.dtpFecProceso = new System.Windows.Forms.DateTimePicker();
            this.rbtnNumAlquiler = new System.Windows.Forms.RadioButton();
            this.panelNumOP.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvIngreso
            // 
            this.dgvIngreso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIngreso.BackColor = System.Drawing.Color.White;
            this.dgvIngreso.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvIngreso.ForeColor = System.Drawing.Color.Black;
            this.dgvIngreso.Location = new System.Drawing.Point(18, 295);
            this.dgvIngreso.Name = "dgvIngreso";
            this.dgvIngreso.PrimaryGrid.AllowRowHeaderResize = true;
            this.dgvIngreso.PrimaryGrid.AllowRowResize = true;
            this.dgvIngreso.PrimaryGrid.ColumnHeader.RowHeight = 30;
            gridColumn1.AllowEdit = false;
            gridColumn1.DataPropertyName = "idIngreso";
            gridColumn1.Name = "ID INGRESO";
            gridColumn2.AllowEdit = false;
            gridColumn2.DataPropertyName = "razonSocial";
            gridColumn2.Name = "PROVEEDOR";
            gridColumn2.Width = 210;
            gridColumn3.AllowEdit = false;
            gridColumn3.DataPropertyName = "nombreKam";
            gridColumn3.MinimumWidth = 100;
            gridColumn3.Name = "USUARIO";
            gridColumn3.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn3.Width = 200;
            gridColumn4.AllowEdit = false;
            gridColumn4.DataPropertyName = "fechaProceso";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDateTimePickerEditControl);
            gridColumn4.MinimumWidth = 100;
            gridColumn4.Name = "FECHA PROCESO";
            gridColumn4.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn4.Width = 115;
            gridColumn5.AllowEdit = false;
            gridColumn5.DataPropertyName = "estado";
            gridColumn5.MinimumWidth = 100;
            gridColumn5.Name = "ESTADO";
            gridColumn6.DataPropertyName = "idEstado";
            gridColumn6.Name = "idEstado";
            gridColumn6.Visible = false;
            this.dgvIngreso.PrimaryGrid.Columns.Add(gridColumn1);
            this.dgvIngreso.PrimaryGrid.Columns.Add(gridColumn2);
            this.dgvIngreso.PrimaryGrid.Columns.Add(gridColumn3);
            this.dgvIngreso.PrimaryGrid.Columns.Add(gridColumn4);
            this.dgvIngreso.PrimaryGrid.Columns.Add(gridColumn5);
            this.dgvIngreso.PrimaryGrid.Columns.Add(gridColumn6);
            this.dgvIngreso.PrimaryGrid.DefaultRowHeight = 24;
            this.dgvIngreso.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvIngreso.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvIngreso.PrimaryGrid.EnableColumnFiltering = true;
            this.dgvIngreso.PrimaryGrid.EnableFiltering = true;
            this.dgvIngreso.PrimaryGrid.EnableRowFiltering = true;
            this.dgvIngreso.PrimaryGrid.Filter.Visible = true;
            this.dgvIngreso.PrimaryGrid.MultiSelect = false;
            this.dgvIngreso.PrimaryGrid.NoRowsText = "No hay ningun ingreso";
            this.dgvIngreso.PrimaryGrid.NullString = "<<null>>";
            this.dgvIngreso.PrimaryGrid.RowHeaderWidth = 45;
            this.dgvIngreso.PrimaryGrid.ShowRowHeaders = false;
            this.dgvIngreso.PrimaryGrid.UseAlternateColumnStyle = true;
            this.dgvIngreso.Size = new System.Drawing.Size(725, 266);
            this.dgvIngreso.TabIndex = 142;
            this.dgvIngreso.Text = "Tabla Ingreso";
            // 
            // panelNumOP
            // 
            this.panelNumOP.Controls.Add(this.txtNumIngreso);
            this.panelNumOP.Location = new System.Drawing.Point(21, 224);
            this.panelNumOP.Name = "panelNumOP";
            this.panelNumOP.Size = new System.Drawing.Size(722, 41);
            this.panelNumOP.TabIndex = 141;
            this.panelNumOP.TabStop = false;
            // 
            // txtNumIngreso
            // 
            this.txtNumIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumIngreso.Location = new System.Drawing.Point(13, 13);
            this.txtNumIngreso.MaxLength = 5;
            this.txtNumIngreso.Name = "txtNumIngreso";
            this.txtNumIngreso.Size = new System.Drawing.Size(172, 22);
            this.txtNumIngreso.TabIndex = 12;
            this.txtNumIngreso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumIngreso_KeyPress);
            // 
            // rbtnFiltros
            // 
            this.rbtnFiltros.AutoSize = true;
            this.rbtnFiltros.Checked = true;
            this.rbtnFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnFiltros.Location = new System.Drawing.Point(27, 12);
            this.rbtnFiltros.Name = "rbtnFiltros";
            this.rbtnFiltros.Size = new System.Drawing.Size(102, 20);
            this.rbtnFiltros.TabIndex = 140;
            this.rbtnFiltros.TabStop = true;
            this.rbtnFiltros.Text = "Buscar Por";
            this.rbtnFiltros.UseVisualStyleBackColor = true;
            this.rbtnFiltros.CheckedChanged += new System.EventHandler(this.rbtnFiltros_CheckedChanged);
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
            this.btnSeleccionar.Location = new System.Drawing.Point(761, 207);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(111, 67);
            this.btnSeleccionar.TabIndex = 139;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.Location = new System.Drawing.Point(761, 70);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(93, 60);
            this.btnBuscar.TabIndex = 138;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panelFiltros
            // 
            this.panelFiltros.Controls.Add(this.cmbUsuario);
            this.panelFiltros.Controls.Add(this.cmbProveedor);
            this.panelFiltros.Controls.Add(this.chbEstado);
            this.panelFiltros.Controls.Add(this.chbProveedor);
            this.panelFiltros.Controls.Add(this.chbUsuario);
            this.panelFiltros.Controls.Add(this.cmbEstado);
            this.panelFiltros.Controls.Add(this.chbFecProceso);
            this.panelFiltros.Controls.Add(this.dtpFecProceso);
            this.panelFiltros.Location = new System.Drawing.Point(21, 29);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(722, 149);
            this.panelFiltros.TabIndex = 136;
            this.panelFiltros.TabStop = false;
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(110, 37);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(274, 24);
            this.cmbUsuario.TabIndex = 134;
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(110, 104);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(274, 24);
            this.cmbProveedor.TabIndex = 133;
            // 
            // chbEstado
            // 
            this.chbEstado.AutoSize = true;
            this.chbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbEstado.Location = new System.Drawing.Point(407, 104);
            this.chbEstado.Name = "chbEstado";
            this.chbEstado.Size = new System.Drawing.Size(84, 20);
            this.chbEstado.TabIndex = 47;
            this.chbEstado.Text = "Estados";
            this.chbEstado.UseVisualStyleBackColor = true;
            this.chbEstado.CheckedChanged += new System.EventHandler(this.chbEstado_CheckedChanged);
            // 
            // chbProveedor
            // 
            this.chbProveedor.AutoSize = true;
            this.chbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbProveedor.Location = new System.Drawing.Point(6, 104);
            this.chbProveedor.Name = "chbProveedor";
            this.chbProveedor.Size = new System.Drawing.Size(100, 20);
            this.chbProveedor.TabIndex = 46;
            this.chbProveedor.Text = "Proveedor";
            this.chbProveedor.UseVisualStyleBackColor = true;
            this.chbProveedor.CheckedChanged += new System.EventHandler(this.chbCliente_CheckedChanged);
            // 
            // chbUsuario
            // 
            this.chbUsuario.AutoSize = true;
            this.chbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbUsuario.Location = new System.Drawing.Point(10, 41);
            this.chbUsuario.Name = "chbUsuario";
            this.chbUsuario.Size = new System.Drawing.Size(81, 20);
            this.chbUsuario.TabIndex = 45;
            this.chbUsuario.Text = "Usuario";
            this.chbUsuario.UseVisualStyleBackColor = true;
            this.chbUsuario.CheckedChanged += new System.EventHandler(this.chbKam_CheckedChanged);
            // 
            // cmbEstado
            // 
            this.cmbEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(512, 102);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(182, 24);
            this.cmbEstado.TabIndex = 9;
            // 
            // chbFecProceso
            // 
            this.chbFecProceso.AutoSize = true;
            this.chbFecProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbFecProceso.Location = new System.Drawing.Point(406, 43);
            this.chbFecProceso.Name = "chbFecProceso";
            this.chbFecProceso.Size = new System.Drawing.Size(119, 20);
            this.chbFecProceso.TabIndex = 44;
            this.chbFecProceso.Text = "Fec. Proceso";
            this.chbFecProceso.UseVisualStyleBackColor = true;
            this.chbFecProceso.CheckedChanged += new System.EventHandler(this.chbFecProceso_CheckedChanged);
            // 
            // dtpFecProceso
            // 
            this.dtpFecProceso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpFecProceso.CustomFormat = "dd-MM-yyyy";
            this.dtpFecProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecProceso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecProceso.Location = new System.Drawing.Point(531, 43);
            this.dtpFecProceso.Name = "dtpFecProceso";
            this.dtpFecProceso.Size = new System.Drawing.Size(163, 22);
            this.dtpFecProceso.TabIndex = 8;
            // 
            // rbtnNumAlquiler
            // 
            this.rbtnNumAlquiler.AutoSize = true;
            this.rbtnNumAlquiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnNumAlquiler.Location = new System.Drawing.Point(23, 204);
            this.rbtnNumAlquiler.Name = "rbtnNumAlquiler";
            this.rbtnNumAlquiler.Size = new System.Drawing.Size(113, 20);
            this.rbtnNumAlquiler.TabIndex = 137;
            this.rbtnNumAlquiler.Text = "Num Ingreso";
            this.rbtnNumAlquiler.UseVisualStyleBackColor = true;
            this.rbtnNumAlquiler.CheckedChanged += new System.EventHandler(this.rbtnNumAlquiler_CheckedChanged);
            // 
            // frmProcesoIngresoBuscar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(882, 606);
            this.Controls.Add(this.dgvIngreso);
            this.Controls.Add(this.panelNumOP);
            this.Controls.Add(this.rbtnFiltros);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.rbtnNumAlquiler);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcesoIngresoBuscar";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso Buscar";
            this.panelNumOP.ResumeLayout(false);
            this.panelNumOP.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvIngreso;
        private System.Windows.Forms.GroupBox panelNumOP;
        private System.Windows.Forms.TextBox txtNumIngreso;
        private System.Windows.Forms.RadioButton rbtnFiltros;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox panelFiltros;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.CheckBox chbEstado;
        private System.Windows.Forms.CheckBox chbProveedor;
        private System.Windows.Forms.CheckBox chbUsuario;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.CheckBox chbFecProceso;
        private System.Windows.Forms.DateTimePicker dtpFecProceso;
        private System.Windows.Forms.RadioButton rbtnNumAlquiler;
    }
}