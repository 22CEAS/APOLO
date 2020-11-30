namespace Apolo
{
    partial class frmProcesoReparacionBuscar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesoReparacionBuscar));
            this.dgvReparacion = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.panelNumOP = new System.Windows.Forms.GroupBox();
            this.txtNumCambio = new System.Windows.Forms.TextBox();
            this.rbtnFiltros = new System.Windows.Forms.RadioButton();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panelFiltros = new System.Windows.Forms.GroupBox();
            this.cmbResponsable = new System.Windows.Forms.ComboBox();
            this.cmbCodigoLC = new System.Windows.Forms.ComboBox();
            this.chbEstado = new System.Windows.Forms.CheckBox();
            this.chbCodigoLC = new System.Windows.Forms.CheckBox();
            this.chbResponsable = new System.Windows.Forms.CheckBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.chbFecProceso = new System.Windows.Forms.CheckBox();
            this.dtpFecProceso = new System.Windows.Forms.DateTimePicker();
            this.rbtnNumReparacion = new System.Windows.Forms.RadioButton();
            this.panelNumOP.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReparacion
            // 
            this.dgvReparacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReparacion.BackColor = System.Drawing.Color.White;
            this.dgvReparacion.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvReparacion.ForeColor = System.Drawing.Color.Black;
            this.dgvReparacion.Location = new System.Drawing.Point(39, 304);
            this.dgvReparacion.Name = "dgvReparacion";
            this.dgvReparacion.PrimaryGrid.AllowRowHeaderResize = true;
            this.dgvReparacion.PrimaryGrid.AllowRowResize = true;
            this.dgvReparacion.PrimaryGrid.ColumnHeader.RowHeight = 30;
            gridColumn1.AllowEdit = false;
            gridColumn1.DataPropertyName = "IdReparacion";
            gridColumn1.Name = "ID REPARACION";
            gridColumn2.AllowEdit = false;
            gridColumn2.DataPropertyName = "CodigoLC";
            gridColumn2.Name = "CODIGO LC";
            gridColumn2.Width = 210;
            gridColumn3.AllowEdit = false;
            gridColumn3.DataPropertyName = "NombreResponsable";
            gridColumn3.MinimumWidth = 100;
            gridColumn3.Name = "RESPONSABLE";
            gridColumn3.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn3.Width = 200;
            gridColumn4.AllowEdit = false;
            gridColumn4.DataPropertyName = "FechaProceso";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDateTimePickerEditControl);
            gridColumn4.MinimumWidth = 100;
            gridColumn4.Name = "FECHA PROCESO";
            gridColumn4.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn4.Width = 115;
            gridColumn5.AllowEdit = false;
            gridColumn5.DataPropertyName = "Estado";
            gridColumn5.MinimumWidth = 100;
            gridColumn5.Name = "ESTADO";
            gridColumn6.DataPropertyName = "IdEstado";
            gridColumn6.Name = "idEstado";
            gridColumn6.Visible = false;
            this.dgvReparacion.PrimaryGrid.Columns.Add(gridColumn1);
            this.dgvReparacion.PrimaryGrid.Columns.Add(gridColumn2);
            this.dgvReparacion.PrimaryGrid.Columns.Add(gridColumn3);
            this.dgvReparacion.PrimaryGrid.Columns.Add(gridColumn4);
            this.dgvReparacion.PrimaryGrid.Columns.Add(gridColumn5);
            this.dgvReparacion.PrimaryGrid.Columns.Add(gridColumn6);
            this.dgvReparacion.PrimaryGrid.DefaultRowHeight = 24;
            this.dgvReparacion.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvReparacion.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvReparacion.PrimaryGrid.EnableColumnFiltering = true;
            this.dgvReparacion.PrimaryGrid.EnableFiltering = true;
            this.dgvReparacion.PrimaryGrid.EnableRowFiltering = true;
            this.dgvReparacion.PrimaryGrid.Filter.Visible = true;
            this.dgvReparacion.PrimaryGrid.MultiSelect = false;
            this.dgvReparacion.PrimaryGrid.NoRowsText = "No hay ninguna reparacion";
            this.dgvReparacion.PrimaryGrid.NullString = "<<null>>";
            this.dgvReparacion.PrimaryGrid.RowHeaderWidth = 45;
            this.dgvReparacion.PrimaryGrid.ShowRowHeaders = false;
            this.dgvReparacion.PrimaryGrid.UseAlternateColumnStyle = true;
            this.dgvReparacion.Size = new System.Drawing.Size(725, 227);
            this.dgvReparacion.TabIndex = 156;
            this.dgvReparacion.Text = "Tabla Reparaciones";
            // 
            // panelNumOP
            // 
            this.panelNumOP.Controls.Add(this.txtNumCambio);
            this.panelNumOP.Location = new System.Drawing.Point(33, 231);
            this.panelNumOP.Name = "panelNumOP";
            this.panelNumOP.Size = new System.Drawing.Size(722, 41);
            this.panelNumOP.TabIndex = 155;
            this.panelNumOP.TabStop = false;
            // 
            // txtNumCambio
            // 
            this.txtNumCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumCambio.Location = new System.Drawing.Point(13, 13);
            this.txtNumCambio.MaxLength = 5;
            this.txtNumCambio.Name = "txtNumCambio";
            this.txtNumCambio.Size = new System.Drawing.Size(172, 22);
            this.txtNumCambio.TabIndex = 12;
            // 
            // rbtnFiltros
            // 
            this.rbtnFiltros.AutoSize = true;
            this.rbtnFiltros.Checked = true;
            this.rbtnFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnFiltros.Location = new System.Drawing.Point(39, 19);
            this.rbtnFiltros.Name = "rbtnFiltros";
            this.rbtnFiltros.Size = new System.Drawing.Size(102, 20);
            this.rbtnFiltros.TabIndex = 154;
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
            this.btnSeleccionar.Location = new System.Drawing.Point(760, 161);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(111, 67);
            this.btnSeleccionar.TabIndex = 153;
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
            this.btnBuscar.Location = new System.Drawing.Point(760, 34);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(93, 60);
            this.btnBuscar.TabIndex = 152;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panelFiltros
            // 
            this.panelFiltros.Controls.Add(this.cmbResponsable);
            this.panelFiltros.Controls.Add(this.cmbCodigoLC);
            this.panelFiltros.Controls.Add(this.chbEstado);
            this.panelFiltros.Controls.Add(this.chbCodigoLC);
            this.panelFiltros.Controls.Add(this.chbResponsable);
            this.panelFiltros.Controls.Add(this.cmbEstado);
            this.panelFiltros.Controls.Add(this.chbFecProceso);
            this.panelFiltros.Controls.Add(this.dtpFecProceso);
            this.panelFiltros.Location = new System.Drawing.Point(33, 36);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(722, 149);
            this.panelFiltros.TabIndex = 150;
            this.panelFiltros.TabStop = false;
            // 
            // cmbResponsable
            // 
            this.cmbResponsable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbResponsable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbResponsable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbResponsable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbResponsable.FormattingEnabled = true;
            this.cmbResponsable.Location = new System.Drawing.Point(134, 37);
            this.cmbResponsable.Name = "cmbResponsable";
            this.cmbResponsable.Size = new System.Drawing.Size(237, 24);
            this.cmbResponsable.TabIndex = 134;
            // 
            // cmbCodigoLC
            // 
            this.cmbCodigoLC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCodigoLC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCodigoLC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbCodigoLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCodigoLC.FormattingEnabled = true;
            this.cmbCodigoLC.Location = new System.Drawing.Point(134, 104);
            this.cmbCodigoLC.Name = "cmbCodigoLC";
            this.cmbCodigoLC.Size = new System.Drawing.Size(237, 24);
            this.cmbCodigoLC.TabIndex = 133;
            // 
            // chbEstado
            // 
            this.chbEstado.AutoSize = true;
            this.chbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbEstado.Location = new System.Drawing.Point(394, 104);
            this.chbEstado.Name = "chbEstado";
            this.chbEstado.Size = new System.Drawing.Size(84, 20);
            this.chbEstado.TabIndex = 47;
            this.chbEstado.Text = "Estados";
            this.chbEstado.UseVisualStyleBackColor = true;
            this.chbEstado.CheckedChanged += new System.EventHandler(this.chbEstado_CheckedChanged);
            // 
            // chbCodigoLC
            // 
            this.chbCodigoLC.AutoSize = true;
            this.chbCodigoLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbCodigoLC.Location = new System.Drawing.Point(6, 104);
            this.chbCodigoLC.Name = "chbCodigoLC";
            this.chbCodigoLC.Size = new System.Drawing.Size(95, 20);
            this.chbCodigoLC.TabIndex = 46;
            this.chbCodigoLC.Text = "CodigoLC";
            this.chbCodigoLC.UseVisualStyleBackColor = true;
            this.chbCodigoLC.CheckedChanged += new System.EventHandler(this.chbCodigoLC_CheckedChanged);
            // 
            // chbResponsable
            // 
            this.chbResponsable.AutoSize = true;
            this.chbResponsable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbResponsable.Location = new System.Drawing.Point(10, 41);
            this.chbResponsable.Name = "chbResponsable";
            this.chbResponsable.Size = new System.Drawing.Size(120, 20);
            this.chbResponsable.TabIndex = 45;
            this.chbResponsable.Text = "Responsable";
            this.chbResponsable.UseVisualStyleBackColor = true;
            this.chbResponsable.CheckedChanged += new System.EventHandler(this.chbKam_CheckedChanged);
            // 
            // cmbEstado
            // 
            this.cmbEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(499, 102);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(182, 24);
            this.cmbEstado.TabIndex = 9;
            // 
            // chbFecProceso
            // 
            this.chbFecProceso.AutoSize = true;
            this.chbFecProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbFecProceso.Location = new System.Drawing.Point(393, 43);
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
            this.dtpFecProceso.Location = new System.Drawing.Point(518, 43);
            this.dtpFecProceso.Name = "dtpFecProceso";
            this.dtpFecProceso.Size = new System.Drawing.Size(163, 22);
            this.dtpFecProceso.TabIndex = 8;
            // 
            // rbtnNumReparacion
            // 
            this.rbtnNumReparacion.AutoSize = true;
            this.rbtnNumReparacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnNumReparacion.Location = new System.Drawing.Point(35, 211);
            this.rbtnNumReparacion.Name = "rbtnNumReparacion";
            this.rbtnNumReparacion.Size = new System.Drawing.Size(142, 20);
            this.rbtnNumReparacion.TabIndex = 151;
            this.rbtnNumReparacion.Text = "Num Reparacion";
            this.rbtnNumReparacion.UseVisualStyleBackColor = true;
            this.rbtnNumReparacion.CheckedChanged += new System.EventHandler(this.rbtnNumReparacion_CheckedChanged);
            // 
            // frmProcesoReparacionBuscar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(882, 606);
            this.Controls.Add(this.dgvReparacion);
            this.Controls.Add(this.panelNumOP);
            this.Controls.Add(this.rbtnFiltros);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.rbtnNumReparacion);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcesoReparacionBuscar";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reparacion Buscar";
            this.panelNumOP.ResumeLayout(false);
            this.panelNumOP.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvReparacion;
        private System.Windows.Forms.GroupBox panelNumOP;
        private System.Windows.Forms.TextBox txtNumCambio;
        private System.Windows.Forms.RadioButton rbtnFiltros;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox panelFiltros;
        private System.Windows.Forms.ComboBox cmbResponsable;
        private System.Windows.Forms.ComboBox cmbCodigoLC;
        private System.Windows.Forms.CheckBox chbEstado;
        private System.Windows.Forms.CheckBox chbCodigoLC;
        private System.Windows.Forms.CheckBox chbResponsable;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.CheckBox chbFecProceso;
        private System.Windows.Forms.DateTimePicker dtpFecProceso;
        private System.Windows.Forms.RadioButton rbtnNumReparacion;
    }
}